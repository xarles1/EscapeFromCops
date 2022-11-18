using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{
    public Vector3 firstPos;
    public Vector3 lastPos;

    public float moveSpeed;

                //RAY ATTIGIN KATMAN ICIN
    public LayerMask targetLayer;
    public float speed;
    public float distance;
    [SerializeField] private Color color;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            firstPos = Camera.main.ScreenToWorldPoint(pos);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            lastPos = Camera.main.ScreenToWorldPoint(pos);
            Vector3 dif = lastPos - firstPos;
            transform.position += new Vector3(dif.x, 0, dif.z) * Time.deltaTime * moveSpeed;
            firstPos = lastPos;

                    //OBJENIN KENDI ETRAFINDA DONMESI ICIN
            //transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, Time.deltaTime * 75, 0));
        }


                //ISIN YOLLAMAK ICIN
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
            if (hit.collider != null)
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = color;
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            }
            Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }

                //ENEMYI RAY ILE DESTROY ETME
        //if (hit.collider.tag == "Enemy")
        //{
        //    Destroy(hit.collider.gameObject);
        //}
    }
}