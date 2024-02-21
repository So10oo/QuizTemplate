using UnityEngine;

public class btmAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var c = gameObject.AddComponent<Collider2D>();
        //c.isTrigger = true;
    }


    void OnMouseOver()
    {
        gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
}
