using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public bool needscolor;
    public bool setVisOnStart = false;
    public bool visstate = false;
    public bool isenemy = false;
    private float despawntimer = 20;

    private void Start()
    {
        if (isenemy)
        {
            setVis(setVisOnStart);
        }
    }

    private void Update()
    { 
        //if object is enemy despawn if not loaded in
        if (isenemy)
        {
            if (visstate == true)
            {
                despawntimer = 20;
            }
            if (visstate == false)
            {
                despawntimer -= Time.deltaTime;
            }
            if (despawntimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void setParent(Transform newparent)
    {
        transform.parent = newparent;
    }
    public void setVis(bool boolean)
    {
        //sets the visibility of self and children
        visstate = boolean;
        if (gameObject.GetComponent<MeshRenderer>())
        {
            gameObject.GetComponent<MeshRenderer>().enabled = boolean;
        }
        if (gameObject.GetComponentInChildren<MeshRenderer>())
        {
            for (int i = 0; i < gameObject.GetComponentsInChildren<MeshRenderer>().Length; i++)
            {
                gameObject.GetComponentsInChildren<MeshRenderer>()[i].enabled = boolean;
            }
        }
        else if (gameObject.GetComponentInChildren<MeshRenderer>())
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = !boolean;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isenemy)
        {
            if (collision.gameObject.tag == "Boss" || collision.gameObject.tag == "BossWeapon")
            {
                Destroy(gameObject);
            }
        }
    }
}
