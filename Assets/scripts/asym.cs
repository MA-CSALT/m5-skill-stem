using UnityEngine;

public class asym : MonoBehaviour
{
    Vector3 velocity = new Vector3(0,0,0);
    Vector3 accel = new Vector3(0,0,0);
    [SerializeField] private float t = 0f;
    private float tmax = 0.583f;
    private float g;
    [SerializeField] private float vbegin = 5f;
    Animator animator;

    enum State
    {
        idle, jump
    }
    State state = State.idle;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.idle)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity = new Vector3(0, vbegin, 0);
                g = -2 * vbegin / tmax;
                accel = new Vector3(0, g, 0);
                state = State.jump;
                
            }
        }

        if (state == State.jump)
        {
            animator.Play("jump2");
            t += Time.deltaTime;
            Debug.Log(t.ToString());
            if (t > tmax) 
            {
                t = 0f;
                velocity = Vector3.zero;
                accel = Vector3.zero;
                state = State.idle;
            }
        }


        velocity += accel * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;


    }
}
