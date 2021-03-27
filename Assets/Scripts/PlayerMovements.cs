using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour
{
    // Константы
    const float coyoteDelay = 0.1f;

    // На движение
    enum InputType
    {
        Tank 
    }
    private float acceleration = 20.0f;
    private float gravity = 40f;
    private float jumpSpeed = 20f;
    private float maxForwardSpeed = 5f;
    private float maxBackwardSpeed = 4f;
    private float maxRotateSpeed = 150f;
    private float rotateAcceleration = 600f;
    float airborneTime;
    float externalRotation;
    float rotateSpeed;
    float speed;
    int jumpsInAir;
    int maxJumpsInAir = 1;
    bool airborne;
    bool inputEnabled = true;
    Vector3 externalMotion;
    Vector3 moveDelta = Vector3.zero;
    CharacterController controller;
    InputType inputType = InputType.Tank;

    //Анимация
    public Animator anim;
    bool isAttack = false; 

    // На здоровье 
    public float health = 1f;
    bool isDie = false;
    public Image HealthBar;
    public float fill;

    //Рычаг
    private GameObject lever;
    public GameObject LeverRotation;
    Transform rotate;

    //Монстры
    
    public float damage;
    public LayerMask mask;
    GameObject MonsterAttack;

    void Awake()
    {
        //Анимация
        anim = GetComponent<Animator>();

        controller = GetComponent<CharacterController>();
        // Убедиться, что Character Controller на земле
        controller.Move(Vector3.down * 0.01f);

        //Рычаг
        lever = GameObject.FindWithTag("Lever");
        rotate = LeverRotation.GetComponent<Transform>();
        controller.Move(Vector3.down * 0.01f);

    }

    void Update()
    {
        
        if(health > 0)
        {
            
            if (inputEnabled)
            {
                switch (inputType)
                {
                    case InputType.Tank:
                        {
                            // Ходьба.
                            var targetSpeed = Input.GetAxisRaw("Vertical");
                            targetSpeed *= targetSpeed > 0 ? maxForwardSpeed : maxBackwardSpeed;
                            if (targetSpeed > speed)
                            {
                                speed = Mathf.Min(targetSpeed, speed + acceleration * Time.deltaTime);
                            }
                            else if (targetSpeed < speed)
                            {
                                speed = Mathf.Max(targetSpeed, speed - acceleration * Time.deltaTime);
                            }
                            // Повороты направо, налево.
                            var targetRotateSpeed = Input.GetAxisRaw("Horizontal");
                            targetRotateSpeed *= maxRotateSpeed;
                            if (targetRotateSpeed > rotateSpeed)
                            {
                                rotateSpeed = Mathf.Min(targetRotateSpeed, rotateSpeed + rotateAcceleration * Time.deltaTime);
                            }
                            else if (targetRotateSpeed < rotateSpeed)
                            {
                                rotateSpeed = Mathf.Max(targetRotateSpeed, rotateSpeed - rotateAcceleration * Time.deltaTime);
                            }
                            // Ходьба
                            moveDelta = new Vector3(0, moveDelta.y, speed);
                            moveDelta = transform.TransformDirection(moveDelta);
                            break;
                        }
                }
                // Проверка на земле ли игрок.
                if (!airborne)
                {
                    jumpsInAir = maxJumpsInAir;
                }

                // Проверка в воздухе ли игрок.
                if (Input.GetButtonDown("Jump"))
                {
                    if (!airborne || jumpsInAir > 0)
                    {
                        moveDelta.y = jumpSpeed;
                        airborne = true;
                        airborneTime = coyoteDelay;
                    }
                }

              
            }
            var wasGrounded = controller.isGrounded;

            if (!controller.isGrounded)
            {
                // Применение гравитации.
                moveDelta.y -= gravity * Time.deltaTime;
                airborneTime += Time.deltaTime;
            }
            
            // Движение игрока - проверка на ошибки чтобы избежать предупреждение от CharacterController.Move.
            if (gameObject.activeInHierarchy)
            {
                controller.Move((moveDelta + externalMotion) * Time.deltaTime);
            }

            // Заземление
            if (!wasGrounded && controller.isGrounded)
            {
                moveDelta.y = 0.0f;
                airborneTime = 0.0f;
            }

            // Прыжки
            airborne = airborneTime >= coyoteDelay;

            // Повороты направо, налево
            transform.Rotate(0, (rotateSpeed + externalRotation) * Time.deltaTime, 0);

            //Анимация
            anim.SetFloat("Speed", speed);

            //Удар
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(AttackToMonster());
                isAttack = true;
            }
            else
            {
                isAttack = false;
            }
            anim.SetBool("isAttack", isAttack);
            //Pычаг у дерева
            float direction = lever.transform.position.x - transform.position.x;
            if (Input.GetKeyDown(KeyCode.E) && (Mathf.Abs(direction) < 1))
            rotate.rotation = Quaternion.Euler(0, 0, -19);

            // На здоровье 
            HealthBar.fillAmount = health;
        }

        
    }

    public void Damage(float damage)
    {
        health -= damage * Time.deltaTime;

        if (health <= 0)
        {
            health = 0;
            isDie = true;
            anim.SetBool("isDie", isDie);
        }

    }
    
    IEnumerator AttackToMonster()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 1f))
        {
            var enemy = hit.transform.gameObject.GetComponent<MonsterAttack>();
            enemy.transform.gameObject.GetComponent<MonsterAttack>().DamageMonster(damage);
            Debug.Log(enemy);
        }
        yield return new WaitForSeconds(3);
    }
}

