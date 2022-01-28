using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform gunedge;
    public ParticleSystem ps;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ps.Play();
            anim.SetTrigger("Shoot");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Reload");
        }
    }
}
