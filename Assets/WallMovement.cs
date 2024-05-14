using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 4f; // �ړ�����

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingToEnd = true;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.forward * distance; // �ǂ̈ړ����������s�������Ɏw��
    }

    private void Update()
    {
        MoveWall();
    }

    private void MoveWall()
    {
        float step = speed * Time.deltaTime;
        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
            if (transform.position == endPos)
                movingToEnd = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            if (transform.position == startPos)
                movingToEnd = true;
        }
    }
}
