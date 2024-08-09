using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float rotationSpd = 150f;
    public float currentSpd = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpd * Time.deltaTime;

        transform.Translate(0, 0, translation);
        currentSpd = translation;

        transform.Rotate(0, rotation, 0);
    }

}