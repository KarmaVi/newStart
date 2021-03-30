using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour
{
    // Константы
    const float СoyoteDelay = 0.1f;

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
    private float airborneTime;
    private float externalRotation;
    private float rotateSpeed;
    private float speed;
    private int jumpsInAir;
    private int maxJumpsInAir = 1;
    bool airborne;
    bool inputEnabled = true;
    Vector3 externalMotion;
    Vector3 moveDelta = Vector3.zero;
    CharacterController controller;
    InputType inputType = InputType.Tank;

    //Анимация
    private Animator anim;
    //bool isAttack = false; 

    // На здоровье 
    [HideInInspector]
    public float health;
    

    //Рычаг
    private GameObject lever;
    [HideInInspector]
    public GameObject LeverRotation;
    Transform rotate;

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
        if (!(health > 0))
            return;
        
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
                        airborneTime = СoyoteDelay;
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
            airborne = airborneTime >= СoyoteDelay;

            // Повороты направо, налево
            transform.Rotate(0, (rotateSpeed + externalRotation) * Time.deltaTime, 0);

            //Анимация
            anim.SetFloat("Speed", speed);

            //Pычаг у дерева
            float direction = lever.transform.position.x - transform.position.x;
            if (Input.GetKeyDown(KeyCode.E) && (Mathf.Abs(direction) < 1))
            rotate.rotation = Quaternion.Euler(0, 0, -19);   
    }
}

