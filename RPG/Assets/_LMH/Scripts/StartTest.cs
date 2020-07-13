using UnityEngine;
using UnityStandardAssets.Utility;

public class StartTest : MonoBehaviour
{
    public CameraTest ct;
    [SerializeField] GameObject startImg;
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
        startImg.SetActive(false);
        gameObject.SetActive(false);
        

    }
}
