using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite walkUpSprite;
    [SerializeField] private Sprite walkDownSprite;
    [SerializeField] private Sprite walkRightSprite;
    [SerializeField] private Sprite walkLeftSprite;


    private bool isWalking;
    private float walkSpeed;
    
    
    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            walkSpeed = 0.05f;
        }
        else
        {
            walkSpeed = 0.3f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!isWalking) {StartCoroutine(HandleMovement(Direction.UP, walkSpeed));}            
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!isWalking) {StartCoroutine(HandleMovement(Direction.DOWN, walkSpeed));}
            
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!isWalking) {StartCoroutine(HandleMovement(Direction.RIGHT, walkSpeed));}            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!isWalking) {StartCoroutine(HandleMovement(Direction.LEFT, walkSpeed));}            
        }
    }

    private IEnumerator HandleMovement(Direction dir, float time)
    {
        isWalking = true;
        switch (dir)
        {
            case Direction.UP:
                transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
                spriteRenderer.sprite = walkUpSprite;
                break;

            case Direction.DOWN:
                transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
                spriteRenderer.sprite = walkDownSprite;
                break;

            case Direction.RIGHT:
                transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                spriteRenderer.sprite = walkRightSprite;
                break;

            case Direction.LEFT:
                transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
                spriteRenderer.sprite = walkLeftSprite;
                break;
        }
        yield return new WaitForSeconds(time);
        isWalking = false;
    }
}

public enum Direction
{
    UP,
    DOWN,
    RIGHT,
    LEFT,
}
