using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Update is called once per frame
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
