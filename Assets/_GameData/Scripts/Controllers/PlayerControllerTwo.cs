using System.Collections;
using UnityEngine;

public class PlayerControllerTwo : MonoBehaviour
{
    public float stepHeight = 0.1f;  // Her space tu�una bast���n�zda atlanacak y�kseklik
    public float stepSize = 0.1f;  // Her space tu�una bast���n�zda ilerlenen yatay mesafe
    public float rotationAngle = 10.0f;  // Her ad�mda d�nme a��s�
    public float radius = 1.0f;  // Spiral merdiven yar��ap�
    private float angle = 0.0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Yatayda ilerleyin ve d�n�n
            angle += rotationAngle;
            angle = Mathf.Repeat(angle, 360.0f);  // 360 derecenin alt�nda kalmas�n� sa�lay�n

            // D�nme a��s�na g�re yeni pozisyonu hesaplay�n
            float radians = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(radians) * radius;
            float y = Mathf.Sin(radians) * radius;

            // Her space tu�una bast���n�zda yukar� do�ru ��k�n
            transform.position = new Vector3(x, y, transform.position.z + stepHeight);
        }
    }
}
