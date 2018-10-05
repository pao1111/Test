using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public int myDamage;
    public Transform batPrefab;
    public Transform batParent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //raycast
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green, 0.5f);
                if (hit.transform.tag == "Monster")
                {
                    hit.transform.GetComponent<Enemy>().Damage(myDamage);
                }
            }
            else
            {
                //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.5f);
            }
        }

        //clone
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform clone = Instantiate(batPrefab);
            clone.SetParent(batParent);
            clone.localPosition = new Vector3(Random.Range(-2f,2f), 0, 0);
            clone.localEulerAngles = new Vector3(0, 0, 0);
            clone.localScale = new Vector3(1, 1, 1);
        }
    }
}
