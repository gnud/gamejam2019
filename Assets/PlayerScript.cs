using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Vector2 speed = new Vector2(1, 1);
    
    private Vector3 position;
    private float startTouchPosition;
    private float endTouchPosition;
    private float width;
    private float height;

    public Animator animator;
    
    void Awake() {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

        void OnGUI()
    {
        // Compute a fontSize based on the size of the screen width.
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

        GUI.Label(new Rect(20, 20, width, height * 0.25f),
            "x = " + position.x.ToString("f2") +
            ", y = " + position.y.ToString("f2"));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator jumpAnimation()
    {
        
        for (int i = 0; i < 10; i++)
        {
            transform.Translate(0, 0.3f, 0);
            yield return null;
        }
    }
    private IEnumerator moveAnimation(int direction)
    {
        float step = 0.3f;
        switch (direction)
        {
            case 0:
                step = step;
                break;
            case 1:
                step = -step;
                break;
        }
        
        for (int i = 0; i < 10; i++)
        {
            transform.Translate(step, 0, 0);
            yield return null;
        }
    }
    
    public void jump()
    {
        StartCoroutine(jumpAnimation());
        animator.SetTrigger("onJump");        
    }

    public void moveLeft()
    {
        StartCoroutine(moveAnimation(0));
        animator.SetTrigger("onMove");
        transform.rotation = Quaternion.Euler(0,0,0);
    }
    public void moveRight()
    {
        StartCoroutine(moveAnimation(1));
        animator.SetTrigger("onMove"); 
        transform.rotation = Quaternion.Euler(0,0,0);
    }
}
