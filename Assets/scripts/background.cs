using UnityEngine;

public class background : MonoBehaviour
{
    [SerializeField] Renderer renderer;
    [SerializeField] float speed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
