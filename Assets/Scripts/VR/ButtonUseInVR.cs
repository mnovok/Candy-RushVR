using UnityEngine.UI;
using UnityEngine;

public class ButtonUseInVR : MonoBehaviour
{
    public GameObject GOForCanvasForServerAndMessages;
    RaycastHit raycastHit;
    public void ButtonPressInVR()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit))
        {
            if (raycastHit.transform.CompareTag("MarkerButton") || raycastHit.transform.CompareTag("CanvasForSAndMButton"))
            {
                raycastHit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
            }
            if(raycastHit.transform.CompareTag("CanvasForSAndMButton"))
            {
                GOForCanvasForServerAndMessages.SetActive(false);
            }
        }
    }
}
