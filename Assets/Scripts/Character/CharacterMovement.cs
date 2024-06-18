using UnityEngine;
using DG.Tweening;

public class CharacterMovement : MonoBehaviour
{
    public float moveDistance = 0.2f;
    public float moveTime = 0.2f;

    public float jumpPower = 1f;
    public float jumpTime = 1f;
    public int numJump = 1;

    private bool isJumpMove = false;

    void Update()
    {
        if(!isJumpMove && Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (!isJumpMove && Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        if (!isJumpMove && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        if (!isJumpMove && Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }
    }

    void MoveLeft()
    {
        if (isJumpMove) return;

        if (transform.position.x > -2)
        {
            Vector3 leftClick = transform.eulerAngles;
            leftClick.y = -90;
            transform.eulerAngles = leftClick;
                
            isJumpMove = true;

            Vector3 position = new Vector3(transform.position.x - moveDistance, transform.position.y, transform.position.z);

            transform.DOJump(position, jumpPower, numJump, jumpTime).SetEase(Ease.OutQuad).
            OnComplete(() => isJumpMove = false);

        }
    }
    void MoveRight()
    {
        if (isJumpMove) return;

        if (transform.position.x < 2)
        {
            Vector3 rightClick = transform.eulerAngles;
            rightClick.y = 90;
            transform.eulerAngles = rightClick;

            isJumpMove = true;

            Vector3 position = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);

            transform.DOJump(position, jumpPower, numJump, jumpTime).SetEase(Ease.OutQuad).
            OnComplete(() => isJumpMove = false);
        }
    }
    void MoveUp()
    {
        if (isJumpMove) return;

        if (!isJumpMove)
        {
            Vector3 upClick = transform.eulerAngles;
            upClick.y = 0;
            transform.eulerAngles = upClick;

            isJumpMove = true;

            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);

            transform.DOJump(position, jumpPower, numJump, jumpTime).SetEase(Ease.OutQuad).
            OnComplete(() => isJumpMove = false);
        }
    }
    void MoveDown()
    {
        if (isJumpMove) return;

        if (transform.position.z > -2)
        {
            Vector3 downClick = transform.eulerAngles;
            downClick.y = -180;
            transform.eulerAngles = downClick;

            isJumpMove = true;

            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveDistance);

            transform.DOJump(position, jumpPower, numJump, jumpTime).SetEase(Ease.OutQuad).
            OnComplete(() => isJumpMove = false);
        }
    }
}
