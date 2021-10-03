using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position; 
    }
    // Update is called once per frame
    void LateUpdate()
    {
        //  Debug.Log(player.position);
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
        transform.position = newPos;
    }
}
