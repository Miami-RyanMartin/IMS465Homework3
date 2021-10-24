using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public LayerMask hitObject; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float gunRotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, gunRotationZ);
        if (Input.GetButtonDown("Fire1"))
        {
            FireGun();
        }


    }

    public void FireGun()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePos = new Vector2(this.transform.position.x, this.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePos, mousePos - firePos, 100.0f, hitObject);
        Debug.DrawLine(firePos, (mousePos - firePos) * 100, Color.green);
        if (hit.collider != null)
        {
            Destroy(hit.transform.gameObject);
            Debug.DrawLine(firePos, hit.point, Color.red);
            Debug.Log("We Hit" + hit.collider.name);
        }
    }
}
