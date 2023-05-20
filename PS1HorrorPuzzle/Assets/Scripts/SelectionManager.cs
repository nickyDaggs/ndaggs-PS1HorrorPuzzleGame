using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    string selectableTag = "Selectable";
    string colorTag = "color";
    string pipeTag = "Pipe";
    string keyTag = "KeyPiece";
    string formTag = "KeyForm";
    string panelTag = "CorrectColor";
    string purpleTag = "PurpleButton";
    public Material highlightMaterial;
    Material defaultMaterial;
    public float dist;
    Transform _selection;
    public PlayerMovement Player;
    public GameObject key;
    public Camera cam;
    public GameObject podiumGlassYlw;
    public QuizManager qMan;
    public Animator sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (_selection != null)
        {
            /*
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
            */
        }
        //RectTransformUtility.ScreenPointToLocalPointInRectangle();
        //var tempTex = cam.targetTexture;
        // Stop camera from rendering to a texture.
        //cam.targetTexture = null;
        // Raycast here;
        
        var ray = cam.ScreenPointToRay(Input.mousePosition);//Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            dist = hit.distance;
            if(selection.CompareTag(selectableTag))
            {
                float distt = Vector3.Distance(hit.transform.position, Player.holdPos.position);
                if (hit.distance < 4)
                {
                    if(Input.GetKeyDown(KeyCode.E) && Player.holding == null && !Player.throwable)
                    {
                        hit.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        hit.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        
                        Player.holding = hit.transform.gameObject;
                        Player.holding.transform.SetParent(Player.holdPos);
                        Player.holding.transform.localPosition = Vector3.zero;
                        Player.lastWeapon = Player.curWeapon;
                        Player.curWeapon = "None";
                    }
                    
                }
                if (distt < 16 && Player.curWeapon == "GravityGun")
                {
                    Vector3 diff = Player.holdPos.position - hit.transform.position;//new Vector3(Player.holdPos.position.x - hit.transform.position.x, hit.transform.position.y, Player.holdPos.position.z - hit.transform.position.z);
                    
                    if (Input.GetMouseButton(1) && Player.holding == null)
                    {
                        hit.transform.GetComponent<Collider>().enabled = false;
                        hit.transform.GetComponent<CharacterController>().enabled = true;
                        //hit.transform.LookAt(Player.transform);
                        hit.transform.GetComponent<CharacterController>().Move(diff * 3f * Time.deltaTime);
                        if (distt < 2)
                        {
                            hit.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                            hit.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                            Player.holding = hit.transform.gameObject;
                            Player.holding.transform.SetParent(Player.holdPos);
                            Player.holding.transform.localPosition = Vector3.zero;
                        }
                    } 
                    
                }
                if (Player.holding == null)
                {
                    hit.transform.GetComponent<BoxCollider>().enabled = true;
                    hit.transform.GetComponent<CharacterController>().enabled = false;
                    hit.transform.GetComponent<Rigidbody>().useGravity = true;
                    hit.transform.GetComponent<Rigidbody>().freezeRotation = false;
                }
                _selection = selection;
            } else if(selection.CompareTag(colorTag))
            {
                var selectionn = hit.transform;
                //float distt = Vector3.Distance(hit.transform.position, Player.holdPos.position);
                if (hit.distance < 4)
                {
                    /*if (Input.GetKeyDown(KeyCode.E) && !colorOrderPuzzle.Instance.complete && colorOrderPuzzle.Instance.sprite.GetCurrentAnimatorStateInfo(0).IsName("indicatorIdle"))
                    {
                        colorOrderPuzzle.Instance.Check(selectionn.gameObject);
                    }*/
                    if (Input.GetKeyDown(KeyCode.E) && !qMan.complete)
                    {
                        qMan.Check(selectionn.gameObject);
                    }
                }
            }
            else if (selection.CompareTag(pipeTag))
            {
                var selectionn = hit.transform;
                //float distt = Vector3.Distance(hit.transform.position, Player.holdPos.position);
                if (hit.distance < 4)
                {
                    if (Input.GetKeyDown(KeyCode.E) && !pipePuzzle.Instance.complete && selectionn.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Idle") || Input.GetKeyDown(KeyCode.E) && selection.gameObject.name == "SMILE")
                    {
                        selectionn.GetComponent<Animator>().SetTrigger("Next");
                    }
                }
            }
            else if (selection.CompareTag(keyTag))
            {
                var selectionn = hit.transform;
                //float distt = Vector3.Distance(hit.transform.position, Player.holdPos.position);
                if (hit.distance < 4)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Player.keyParts++;
                        selectionn.GetComponent<MeshRenderer>().enabled = false;
                        selectionn.GetComponent<MeshCollider>().enabled = false;
                    }
                }
            }
            else if (selection.CompareTag(formTag))
            {
                var selectionn = hit.transform;
                //float distt = Vector3.Distance(hit.transform.position, Player.holdPos.position);
                if (hit.distance < 4)
                {
                    if (Input.GetKeyDown(KeyCode.E) && Player.keyParts == 3)
                    {
                        key.SetActive(true);
                    }
                }
            }
            //NEW CODE FOR THIS PROJECT
            //panel tag added for the code room, disables glass that keeps the yellow key away from the player
            else if(selection.CompareTag(panelTag))
            {
                if (hit.distance < 4)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        sprite.SetTrigger("Complete");
                        podiumGlassYlw.SetActive(false);
                    }
                }
                
            } 
            //purple tag is specifically for the purple button that checks if the future puzzle is completed
            else if(selection.CompareTag(purpleTag))
            {
                var selectionn = hit.transform;
                if (hit.distance < 4)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        selectionn.GetComponentInChildren<Animator>().SetTrigger("Press");
                        selectionn.GetComponent<FuturePuzzleCheck>().Check();

                    }
                }
            }
        }
        // Put texture back on camera.
        //cam.targetTexture = tempTex;
    }
}
