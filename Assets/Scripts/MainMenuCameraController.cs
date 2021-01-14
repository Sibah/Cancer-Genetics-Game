using UnityEngine;
using UnityEngine.UI;

public class MainMenuCameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera zoomCamera;
    public GameObject canvas;
    public GameObject canvasMain;
    public Button yourButton;

    void Start()
    {
        mainCamera.enabled = true;
        zoomCamera.enabled = false;
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        mainCamera.enabled = true;
        zoomCamera.enabled = false;
        canvas.SetActive(false);
        canvasMain.SetActive(true);
    }

    private void OnMouseDown()
    {
        mainCamera.enabled = false;
        zoomCamera.enabled = true;
        canvas.SetActive(true);
        canvasMain.SetActive(false);
    }
}
