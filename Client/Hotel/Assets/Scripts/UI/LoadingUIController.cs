using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingUIController : MonoBehaviour
{
    private Text progressText;
    private Image progressBar;

    // Use this for initialization
    void Start()
    {
        progressBar = this.transform.GetChild(1).GetComponent<Image>();
        progressText = this.transform.GetChild(2).GetComponent<Text>();

        StartCoroutine(LoadScene("Demo"));
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator LoadScene(string sceneName)
    {
        int displayProgress = 0;
        int targetProgress = 0;

        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        ao.allowSceneActivation = false;

        while (ao.progress < 0.9f)
        {
            targetProgress = (int)(ao.progress * 100);

            Debug.Log("targetProgress:" + targetProgress);
            while (displayProgress < targetProgress)
            {
                displayProgress++;
                Debug.Log("displayProgress:" + displayProgress);
                progressText.text = displayProgress + "%";
                progressBar.fillAmount = (float)displayProgress / 100;
                yield return new WaitForEndOfFrame();
            }
        }

        targetProgress = 100;

        while(displayProgress < targetProgress)
        {
            displayProgress++;
            progressText.text = displayProgress + "%";
            progressBar.fillAmount = (float)displayProgress / 100;
            yield return new WaitForEndOfFrame();
        }

        ao.allowSceneActivation = true;
    }
}
