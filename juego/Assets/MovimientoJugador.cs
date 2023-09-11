using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad;
    public float salto;
    public float velocidadRotacion;
    private Rigidbody fisicas;
    private bool enElSuelo; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fisicas = GetComponent<Rigidbody>();

    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movimiento = new Vector3(horizontal, 0, vertical).normalized *
                         (Time.deltaTime * velocidad);
        transform.Translate(movimiento);

        var mouseX = Input.GetAxis("Mouse X");
        var rotacion = new Vector3(0, mouseX, 0) * (Time.deltaTime * velocidadRotacion);
        transform.Rotate(rotacion);

        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            enElSuelo = true;
        }
        else
        {
            enElSuelo = false;
        }

        if (enElSuelo && Input.GetKey(KeyCode.Space))
        {
            fisicas.AddForce(new Vector3(0, salto, 0));
        }
    }
}