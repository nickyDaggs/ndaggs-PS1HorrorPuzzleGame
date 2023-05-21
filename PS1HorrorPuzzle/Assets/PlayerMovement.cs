using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public int keyParts = 0;
    public float speed = 12f;
    public float moveObjSpd;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float thrust;
    public float ggThrust;
    public float dis;
    public int sceneInd;
    public Vector3 resetPos;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 velocity;
    Vector3 impact;
    bool isGrounded;
    public bool throwable = false;

    public string curWeapon = "None";
    public string lastWeapon = "";
    public GameObject holding = null;
    public Transform holdPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (impact.magnitude > 0.2F)
        {
            controller.Move(impact * Time.deltaTime);
            // consumes the impact energy each cycle:
            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
        }
        //velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curWeapon = "None";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curWeapon = "GravityGun";
        }
        if (holding != null)
        {
            holding.GetComponent<Collider>().enabled = true;
            holding.GetComponent<CharacterController>().enabled = false;
            float dist = Vector3.Distance(holding.transform.position, holdPos.position);
            dis = dist;
            float step = moveObjSpd * Time.deltaTime;
            Vector3 diff = (holdPos.position - holding.transform.position); //* moveObjSpd * Time.deltaTime;
            holding.transform.LookAt(transform);
            //holding.transform.localPosition = Vector3.zero;
            holding.GetComponent<Rigidbody>().useGravity = false;
            holding.GetComponent<Rigidbody>().freezeRotation = true;
            //holding.GetComponent<Rigidbody>().freezePosition = true;
            if (!throwable)
            {
                StartCoroutine(wThrow());
            }
            if (dist > .1f)
            {
                Vector3 newPos = Vector3.Lerp(holding.transform.position, holdPos.position, step);
                holding.GetComponent<Rigidbody>().velocity = diff * step;
            }
            else
            {
                holding.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            
            if ((Input.GetKeyDown(KeyCode.E)  || dist > 4) && throwable)
            {
                //Debug.Log("FF");
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<Rigidbody>().freezeRotation = false;
                holding.GetComponent<Collider>().enabled = true;
                holding.GetComponent<CharacterController>().enabled = false;
                holding.transform.parent = null;
                //holding.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);
                //holding.GetComponent<gravityScript>().isHeld = false;
                throwable = false;
                holding = null;
                if(curWeapon == "None")
                {
                    //curWeapon = lastWeapon;
                }
            } 
            if (Input.GetMouseButtonDown(0) && throwable)
            {
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<Rigidbody>().freezeRotation = false;
                holding.GetComponent<Collider>().enabled = true;
                holding.GetComponent<CharacterController>().enabled = false;
                holding.transform.parent = null;
                if (curWeapon == "None")
                {
                    holding.GetComponent<Rigidbody>().AddForce(holdPos.forward * thrust);
                    //curWeapon = lastWeapon;
                } else if(curWeapon == "GravityGun")
                {
                    holding.GetComponent<Rigidbody>().AddForce(holdPos.forward * ggThrust);
                }
                //holding.GetComponent<gravityScript>().isHeld = false;
                throwable = false;
                holding = null;
            }
        } else
        {
            throwable = false;
        }
    }
    public IEnumerator wThrow()
    {
        if(!throwable)
        {
            yield return new WaitForSeconds(.3f);
            throwable = true;
        }
    }

    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / 3;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Reset")
        {
            controller.enabled = false;
            
            if(holding != null)
            {
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<Rigidbody>().freezeRotation = false;
                holding.GetComponent<Collider>().enabled = true;
                holding.GetComponent<CharacterController>().enabled = false;
                holding.transform.parent = null;
                //holding.transform.position = holding.GetComponent<ResetScript>().resetPos;
                throwable = false;
                holding = null;
            }
            
            transform.position = resetPos;
            controller.enabled = true;
        } else if(hit.gameObject.tag == "Goal")
        {
            if (holding != null)
            {
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<Rigidbody>().freezeRotation = false;
                holding.GetComponent<Collider>().enabled = true;
                holding.GetComponent<CharacterController>().enabled = false;
                holding.transform.parent = null;
                //holding.transform.position = holding.GetComponent<ResetScript>().resetPos;
                throwable = false;
                holding = null;
            }
            sceneInd++;
            if(sceneInd < SceneManager.sceneCount)
            {
                SceneManager.LoadScene(sceneInd);
            }
        }
    }
}
