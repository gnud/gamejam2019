using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerScript : MonoBehaviour
{   
    private int score;

    public Animator animator;
    public SpriteRenderer renderer;
    public Text scoreVal;
    private float timer;

    #region events

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeScore();
    }

    #endregion

    #region helpers

    void timeScore()
    {
        timer += Time.deltaTime;

        if (timer > 5f) {

            score += 5;
            scoreVal.text = score.ToString();

            //Reset the timer to 0.
            timer = 0;
        }
    }

    #endregion

    #region Animations

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

    #endregion

    #region Joystick

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
            renderer.flipX = true;
        }
    
        public void moveRight()
        {
            StartCoroutine(moveAnimation(1));
            animator.SetTrigger("onMove");
            renderer.flipX = false;
        }

    #endregion
}
