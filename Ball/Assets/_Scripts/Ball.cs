using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float checkFloorRadius;
    [SerializeField] private float checkFloorPosition;

    private Rigidbody rigid;
    private Vector3 move;

    private bool isbrake;

    private new AudioSource audio;

    private bool IsGround
    {
        get
        {
            return Physics.CheckSphere(transform.position + new Vector3(0f, checkFloorPosition), checkFloorRadius, 1 << 6);
        }
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Coin.ballAudio = audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isbrake)
        {
            rigid.AddForce(new Vector3(-rigid.linearVelocity.x * speed, 0f, -rigid.linearVelocity.z * speed), ForceMode.Acceleration);
        }
        else
        {
            rigid.AddForce(speed * Time.deltaTime * (Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * move), ForceMode.VelocityChange);
        }
    }

#pragma warning disable
    private void OnMove(InputValue value)
    {
        move = value.Get<Vector3>();
    }

    private void OnJump()
    {
        if (IsGround)
        {
            var v = rigid.linearVelocity;
            v.y = 0f;
            rigid.linearVelocity = v;
            rigid.AddForce(new Vector3(0f, jumpForce), ForceMode.VelocityChange);
            audio.Play();
        }
    }

    private void OnBrake()
    {
        isbrake = !isbrake;
    }
#pragma warning enable
}
