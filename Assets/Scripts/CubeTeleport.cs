using UnityEngine;
using UnityEngine.UI;

public class CubeTeleport : MonoBehaviour
{

    private float delX, delY, delZ, dist;
    public Transform teleporttarget;
    public GameObject player;
    public Image Crosshair;
    NewRaycast newraycast_script;
    

    float sqrt(Vector3 initial, Transform teleport)
    {
        float dist = Vector3.Distance(initial, teleport.transform.position);
        Debug.Log(dist);
        return dist;
    }

    public void teleport_if_more_than_min_dist()
    {
        Debug.Log(teleporttarget.transform.position);
        Vector3 pos = player.transform.position;
        float newdist = sqrt(pos,teleporttarget);
        if (newdist < 8.0f)
        {
            newraycast_script.Crosshairchange();
        }
        else
        {
            CharacterController charr = player.gameObject.GetComponent<CharacterController>();
            charr.enabled = false;
            Vector3 temp = teleporttarget.transform.position;
            charr.transform.position = new Vector3(temp.x, temp.y, temp.z);
            charr.enabled = true;
            newraycast_script.CrosshairWhite();
        }
    }

}
