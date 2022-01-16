using UnityEngine;
using UnityEngine.UI;

public class NewRaycast : MonoBehaviour
{
    public float range = 100.0f;
    public Transform player;
    public Camera raycam;
    public Image croshair;
    [SerializeField] private string selectableTag = "trigger";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    private Transform solid_models;
    Renderer render_selec;
    public Animator crosshair_anim;


    void start ()
    {
        render_selec = solid_models.GetComponent<Renderer>();
    }

    void Update()
    {         
        RaycastHit hitinfo;
        if (Physics.Raycast(raycam.transform.position, raycam.transform.forward, out hitinfo, 10.0f))
        {
            if (hitinfo.collider.CompareTag(selectableTag))
            {
                CrosshairBlack();
                crosshair_anim.SetBool("looking", true);
                solid_models = hitinfo.transform.GetChild(0);
                render_selec = solid_models.GetComponent<Renderer>();
                if(render_selec != null)
                {
                    render_selec.material = highlightMaterial;
                }
                if (Input.GetButton("Fire1"))
                {
                    if (hitinfo.collider.isTrigger == true)
                    {
                        CubeTeleport cubetele = hitinfo.collider.gameObject.GetComponent<CubeTeleport>();
                        if (cubetele != null)
                        {
                            Debug.Log(player.transform.position);
                            cubetele.teleport_if_more_than_min_dist();
                        }
                    }
                }
            }
            else
            {
                crosshair_anim.SetBool("looking", false);
                CrosshairWhite();
                render_selec.material = defaultMaterial;
            }
        }
        else 
        {
            crosshair_anim.SetBool("looking", false);
            CrosshairWhite();
            render_selec.material = defaultMaterial;
        }
    }

    
    public void Crosshairchange()
    {
        croshair.color = Color.red;
    }

    public void CrosshairBlack()
    {
        croshair.color = Color.black;
    }

    public void CrosshairWhite()
    {
        croshair.color = Color.white;        
    }
}
