using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject chooseArenaPanel;
    public GameObject loadingPanel;
    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
        chooseArenaPanel.SetActive(false);
        loadingPanel.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void arenaRailway()
    {
        loadingPanel.SetActive(true);
        StartCoroutine(loadRailway());
    }

    public void arenaCity()
    {
        loadingPanel.SetActive(true);
        StartCoroutine(loadCity());
    }

    IEnumerator loadRailway()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    IEnumerator loadCity()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}
