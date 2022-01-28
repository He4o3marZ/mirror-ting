using UnityEngine;

public class isGrounded : MonoBehaviour
{
    public bool Grounded;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ground")
        {
            Grounded = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "ground")
        {
            Grounded = false;
        }
    }
}
