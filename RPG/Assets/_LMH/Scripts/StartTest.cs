using UnityEngine;
using UnityStandardAssets.Utility;

public class StartTest : MonoBehaviour
{
    public CameraTest ct;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetStart()
    {
        ct.StartGame();
        gameObject.SetActive(false);
        

    }
}
