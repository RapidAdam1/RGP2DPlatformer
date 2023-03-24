using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScaler : MonoBehaviour
{
    Transform MyTransform;
    Vector3 ZoomToScale = new Vector3(1,1,1);
    bool Dead;
    bool reset = false;

    public int interpolationFrameCount = 45;
    int elapsedFrames = 0;
    // Start is called before the first frame update
    void Start()
    {
        MyTransform = GetComponent<Transform>();
        MyTransform.localScale = new Vector3 (15,15,15);
        
    }

    // Update is called once per frame
    void Update()
    {
        while (Dead)
        {
            float interpolationRatio = (float)elapsedFrames / interpolationFrameCount;
            if(MyTransform.localScale != new Vector3(1, 1, MyTransform.localScale.z))
            {
                MyTransform.localScale = Vector3.Lerp(new Vector3(15,15,15), ZoomToScale, interpolationRatio);
                elapsedFrames = (elapsedFrames+1) % (interpolationFrameCount+1);
            }
            else 
            {
                Dead = false;
                reset = true;
                break;
            }

            ;
        }
    if (Input.GetKeyDown(KeyCode.E) && reset)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    }

    IEnumerator WaitLoad()
    {
        yield return new WaitForSecondsRealtime(2);
    }

    public void Died()
    {
        Dead = true;

    }
}
