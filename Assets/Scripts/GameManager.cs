using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private string game1Scene = "SampleScene";
    private string menuScene = "Menu";

    private static GameManager instance = null;
    public GameObject pauseCanvas;
    //public GameObject player;
    public static GameState state;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        state = GameState.Menu;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(pauseCanvas);
        //SceneManager.LoadScene(menuScene);
        pauseCanvas.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    public static void pause()
    {
        state = GameState.Pause;
        instance.pauseCanvas.SetActive(true);
        //instance.player.SetActive(false);
    }
    public static void resume()
    {
        state = GameState.Playing;
        instance.pauseCanvas.SetActive(false);
        //instance.player.SetActive(true);
    }
    public void startGame()
    {
        state = GameState.Playing;
        Scene nextScene = SceneManager.GetSceneByName(game1Scene);
        SceneManager.LoadScene(game1Scene);
        //SceneManager.MoveGameObjectToScene(pauseCanvas, nextScene);
    }
}

public enum GameState
{
    Menu,
    Pause,
    Playing
}
