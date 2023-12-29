using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float cameraDistance;
    [SerializeField] float waitTime;
    [SerializeField] int numberRestartScene;

    CinemachineComponentBase componentBase;
    bool checkZoom = true;
    private void Update()
    {
        GetComponentBase();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Road")
        {
            StartCoroutine(ShowPanel());
            Zoom();
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(numberRestartScene);
    }

    IEnumerator ShowPanel()
    {
        yield return new WaitForSeconds(waitTime);
        gameOverPanel.SetActive(true);
    }

    void Zoom()
    {
        if (componentBase is CinemachineFramingTransposer && checkZoom)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
            checkZoom = false;
        }
    }

    void GetComponentBase()
    {
        if (componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }
    }
}
