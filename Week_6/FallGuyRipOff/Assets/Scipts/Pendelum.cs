using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendelum : MonoBehaviour
{

   private Quaternion start, end;

    [SerializeField] float angle = 90.0f;
    [SerializeField] float speed = 2.0f;
    [SerializeField] float startTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        start = PendelumRotation(angle);
        end = PendelumRotation(-angle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(start, end, (Mathf.Sin(startTime * speed + Mathf.PI / 2) + 1.0f) / 2.0f);
        //Lerp is a function I discovered that interpolates between an a and b variable
        //and then normalizes them automatically
        //this is obviously a formula I found online,
        //I am not smart enough to remember this high level math haha
    }
    private void ResetTimer()
    {
        startTime = 0.0f;
        
    }
    private Quaternion PendelumRotation(float angle)
    {
        var pendelumRotation = transform.rotation;
        var angleZ = pendelumRotation.eulerAngles.z + angle;

        if(angleZ > 180)
        {
            angleZ -= 360;
        }
        else if(angleZ < -180)
        {
            angleZ += 360;
        }
        pendelumRotation.eulerAngles = new Vector3(pendelumRotation.eulerAngles.x, pendelumRotation.eulerAngles.y, angleZ);
        return pendelumRotation;
    }
}
