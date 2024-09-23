using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject trail;        // only this needs to be public
    private float speed;
    private Renderer cubeRenderer;
    private float trailTimer;  
    
    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        trailTimer = 0f; speed = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
       float moveHorizontal = Input.GetAxis("Horizontal"); // A and D for left and right       
       float moveVertical = Input.GetAxis("Vertical");     // W and S for forward and backward
       trailTimer += Time.deltaTime;
       
       // move and leave a trail of small cubes
       MoveTrail();
       
       // if a space is clicked, change the color of the cube to a random color
       if (Input.GetKeyDown(KeyCode.Space))     ChangeColor();
       
       // if keys are pressed, make the cube change its direction
       
       
    }
    
    void MoveTrail()
        {   /* 
                Move the cube and have a trail mini-cubes as it moves.
                The cubes appear every second and disappear every 10 seconds.
            */
            this.gameObject.transform.position += Time.deltaTime * speed * new Vector3(0.5f, 0, 0); 
            
            if (trailTimer > 1f)    // create the trail to appear every second
            {    
                GameObject trailInstance = Instantiate(trail, this.gameObject.transform.position, Quaternion.identity);
                //change trail color to match the cube
                Color cubeColor = cubeRenderer.material.color;  
                Renderer trailRenderer = trailInstance.GetComponent<Renderer>();  
                trailRenderer.material.color = cubeColor;  // Set the trail's color to match the cube's
                // destroy and reset
                Destroy(trailInstance, 10f);  
                trailTimer = 0f;
            }
        }
        
    void ChangeColor()
        {   /* 
                Change the Cube color to a random color :)
             */      
            Color randomColor = new Color(Random.value, Random.value, Random.value);    
            if (cubeRenderer != null)
            {
                cubeRenderer.material.color = randomColor;
            }
        }

    
}
