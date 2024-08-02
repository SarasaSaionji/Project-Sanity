using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClearSky
{

    public class DemoCollegeStudentController : MonoBehaviour
    {
        public float movePower = 6f; 
        public float KickBoardMovePower = 15f;
        

        private Rigidbody2D YEETMAN;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        
        private bool alive = true;
        private bool isKickboard = false;
        public AudioSource WalkSoundEffect;
        
        public float delayTimer = 0.02f;

        // Start is called before the first frame update
        void Start()
        {
            YEETMAN = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            delayTimer -= Time.deltaTime;
            if (alive)
            {

                Run();

            }

            if ((Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)) && delayTimer <= 0f )
            {
                delayTimer = 0.15f;
                WalkSoundEffect.enabled = true;

                
            }

            
            else if (delayTimer <= 0f)
            {
                
                WalkSoundEffect.enabled = false;
                delayTimer = 0.15f;
            }
        }



        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }



        void Run()
        {
            if (!isKickboard)
            {
                Vector3 moveVelocity = Vector3.zero;
                anim.SetBool("isRun", false);
               
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    
                    

                    
                    
                    direction = -1;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 1, 1);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);
                        
                    
                    
                }
                if (Input.GetAxisRaw("Horizontal") > 0) 
                {
                    
                    
                    direction = 1;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(direction, 1, 1);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);

                    


                }
                transform.position += moveVelocity * movePower * Time.deltaTime;

            }


        }






    }

}