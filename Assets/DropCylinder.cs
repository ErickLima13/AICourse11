using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCylinder : MonoBehaviour
{
    private GameObject[] agents;
    private GameObject newObstacle;
    public GameObject obstacle;



    // Start is called before the first frame update
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("agent");
    }

    // Update is called once per frame
    void Update()
    {
        Drop();
    }

    private void Drop()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                newObstacle = Instantiate(obstacle, hitInfo.point, obstacle.transform.rotation);

                foreach (GameObject a in agents)
                {
                    a.GetComponent<AIControl>().DetectNewObstacle(hitInfo.point);
                }
            }
        }

        //Destroy(newObstacle, 1f);
    }
}
