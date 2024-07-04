using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePosition2Zone : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube_Black(Clone)" || other.name == "Cube_White(Clone)")
        {
            
            if(this.gameObject.name == "WhiteEmptyObject(Clone)" & other.name == "Cube_Black(Clone)")
            {
                GlobalVariables.myVariable++;
            }
            else if (this.gameObject.name == "BlackEmptyObject(Clone)" & other.name == "Cube_White(Clone)")
            {
                GlobalVariables.myVariable++;
            }
            rb = other.gameObject.GetComponent<Rigidbody>();

            other.tag = "Finish";
            other.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.4f, this.transform.position.z);
            other.gameObject.transform.rotation = this.transform.rotation;

            Destroy(rb);
            Destroy(this.gameObject);
        }
    }
}
