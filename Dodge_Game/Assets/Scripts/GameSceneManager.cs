using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private Player player;
    private EnemySpawner spawner;
    private UI_Time timer;

    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<UI_Time>();
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetHP() <= 0)
        {
            gameOverUI.SetActive(true);
            spawner.OffSpawner();
            timer.OffTimer();

            //Time.timescale(0); 을 넣어주는 방법도 있지만, 이 방법은 아예 게임이 멈춰버리기 때문에 추천하지 않아요!
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");//씬 이름을 지정해서, 나중에 씬 변경에도 사용
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //현재 씬 자체를 가져와서 재 로딩하는 동작
    }

    public void QuitButton()
    { //# if문은 컴파일러에게 주는 조건문이다.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit()
#endif
    }
}
