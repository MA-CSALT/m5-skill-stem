using Unity.VisualScripting;
using UnityEngine;

public class parabola : MonoBehaviour
{
    [SerializeField] point point;
    int NumberOfPoint = 100;

    Vector2 minScreen, maxScreen;

    QuadraticFunction f;

    void Start()
    {
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        float dx = (maxScreen.x - minScreen.x)/NumberOfPoint;

        f = new QuadraticFunction (1,2,3);

        for (int i = 0; i <= NumberOfPoint; i++)
        {
            float x_pos = minScreen.x + i*dx;
            float y_pos = f.getY(x_pos);
            point copyOfPoint = Instantiate(point);
            copyOfPoint.transform.position = new Vector3(x_pos, y_pos, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
