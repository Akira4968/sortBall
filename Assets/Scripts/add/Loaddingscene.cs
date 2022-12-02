using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using dotmob;

public class Loaddingscene : MonoBehaviour
{
    [SerializeField] Image _loadding;
    //[SerializeField] float _timeCount;
    public static LoadGameData LoadGameData { get; set; }
    private void Start()
    {
        StartCoroutine(IsLoadding(500));
    }
    public void loadLevel()
    {
        //Mainmenu.SetActive(false);
        //StartCoroutine(IsLoadding());
        //GameManager.LoadScene("Level", true, 5f);
    }
    IEnumerator IsLoadding(float speed)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Level");

        while (!operation.isDone)
        {
            _loadding.fillAmount = Mathf.Lerp(0, 1, speed);
            yield return null;
        }

    }
    public static void LoadScene(string sceneName, bool showLoading = true, float loadingScreenSpeed = 5f)
    {
        var loadingPanel = SharedUIManager.LoadingPanel;
        if (showLoading && loadingPanel != null)
        {
            loadingPanel.Speed = loadingScreenSpeed;
            loadingPanel.Show(completed: () =>
            {
                SceneManager.LoadScene(sceneName);
                loadingPanel.Hide();
            });
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    public static void LoadGame(LoadGameData data, bool showLoading = true, float loadingScreenSpeed = 1f)
    {
        LoadGameData = data;
        LoadScene("Level", showLoading, loadingScreenSpeed);
    }
    /*public void Update()
    {
        _timeCount += Time.deltaTime;
        if(_timeCount>2)
        {
            StartCoroutine(ReadyFire());
            _timeCount= 0;
        }
    }
    IEnumerator ReadyFire()
    {
        //instance bullet tai day
        yield return null;
    }*/
    
}
public struct LoadGameData
{
    public Level Level { get; set; }
}
