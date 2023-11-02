using System.Collections;
using UnityEngine;

public class PlayerControllerTwo : MonoBehaviour
{
    public float stepHeight = 0.1f;  // Her space tuþuna bastýðýnýzda atlanacak yükseklik
    public float stepSize = 0.1f;  // Her space tuþuna bastýðýnýzda ilerlenen yatay mesafe
    public float rotationAngle = 10.0f;  // Her adýmda dönme açýsý
    public float radius = 1.0f;  // Spiral merdiven yarýçapý
    private float angle = 0.0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Yatayda ilerleyin ve dönün
            angle += rotationAngle;
            angle = Mathf.Repeat(angle, 360.0f);  // 360 derecenin altýnda kalmasýný saðlayýn

            // Dönme açýsýna göre yeni pozisyonu hesaplayýn
            float radians = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(radians) * radius;
            float y = Mathf.Sin(radians) * radius;

            // Her space tuþuna bastýðýnýzda yukarý doðru çýkýn
            transform.position = new Vector3(x, y, transform.position.z + stepHeight);
        }
    }
}
