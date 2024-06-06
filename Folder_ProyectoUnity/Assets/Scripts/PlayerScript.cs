using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using DG.Tweening;

public class PlayerScript : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] Animator animatorPlayer;

    [Header("Input")]
    [SerializeField] Vector2 movimiento;


    [Header("Rotacion y velocidad")]
    [SerializeField] float velocidadMovimiento = 3.0f;
    [SerializeField] float velocidadRotacion;
    private Rigidbody rb;

    [Header("Vida")]
    public int curHealth = 0;
    public int maxHealth = 50;
    public VidaScript healthBar;

    [Header("DoTween")]
    [SerializeField] private float duration;
    [SerializeField] private Ease EaseValue = Ease.Linear;

    [SerializeField] private GameManage gameManage;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<Animator>();
    }

    void Start()
    {
        curHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dog")
        {
            DamagePlayer(10);
            if (curHealth == 0)
            {
                Time.timeScale = 0;
                StartCoroutine(ScalePlayerAndLoadGameOver());
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(movimiento.x, 0, movimiento.y).normalized;

        animatorPlayer.SetBool("IsRunning", direction.magnitude >= 0.1f);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocidadRotacion, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            rb.MovePosition(transform.position + moveDirection * velocidadMovimiento * Time.deltaTime);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movimiento = context.ReadValue<Vector2>();
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }
    private IEnumerator ScalePlayerAndLoadGameOver()
    {
        transform.DOScale(Vector3.zero, duration).SetEase(EaseValue).SetUpdate(true);

        yield return new WaitForSecondsRealtime(duration + 0.2f);

        gameManage.Perder();
        Time.timeScale = 1;
    }
}