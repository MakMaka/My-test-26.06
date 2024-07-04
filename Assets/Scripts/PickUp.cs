using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PickUp : NetworkBehaviour
{
    private float distance = 5;
    [SerializeField] Transform posi;
    [SerializeField] GameObject E_button;
    private  bool Take;
    [SerializeField] Rigidbody rb;
    private Camera fps_camera;

    void Start()
    {
        fps_camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            Ray ray = fps_camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance) && hit.collider.CompareTag("Player"))
            {
                if (!Take)
                {
                    E_button.SetActive(true);
                }
                rb = hit.collider.gameObject.GetComponent<Rigidbody>();


                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Take)
                    {
                        ReleaseCube();
                    }
                    else
                    {
                        Take_Item();
                    }
                }
            }
            else
            {
                E_button.SetActive(false);
            }

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        }
    }

    void Take_Item()
    {
        E_button.SetActive(false);
        Take = true;
        rb.isKinematic = true;
        rb.MovePosition(posi.position);
    }

    void ReleaseCube()
    {
        Take = false;
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (rb != null && rb.isKinematic)
        {
            rb.gameObject.transform.position = posi.position;
        }
    }
}
