using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Transform[] backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float delta)
    {
        int i;
        for(i = 0; i < backgrounds.Length; i++)
        {
            //backgrounds[i].transform.position += delta * Vector3.right;
            backgrounds[i].position += (delta * Vector3.right);

            if(backgrounds[i].transform.position.x < -6.4f)
            {
                backgrounds[i].transform.position += 19.2f * Vector3.right;
            }
            else if (backgrounds[i].transform.position.x > 6.4f)
            {
                backgrounds[i].transform.position -= 19.2f * Vector3.right;
            }
        }
    }
}
