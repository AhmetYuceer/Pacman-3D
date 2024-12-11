using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerController _player;
    [SerializeField] private List<Ghost> ghosts = new List<Ghost>();
    
    [SerializeField] private float respawnDelay = 3f;
    public bool IsPlay = false;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartGame();
    }
    
    private void StartGame()
    {
        StartCoroutine(Respawn());
        StartCoroutine(UIManager.Instance.ShowMessage("Eat All The Food", 3f));
    }
    
    public IEnumerator EndGame()
    {
        IsPlay = false;
        foreach (var ghost in ghosts)
            ghost.PlayerIsDie();
        StartCoroutine(UIManager.Instance.ShowMessage("You Won!", 3f));
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }

    public IEnumerator Respawn()
    {
        IsPlay = false;

        foreach (var ghost in ghosts)
            ghost.PlayerIsDie();

        StartCoroutine(UIManager.Instance.Timer(respawnDelay));
        
        yield return new WaitForSeconds(respawnDelay);

        foreach (var ghost in ghosts)
            ghost.RestartGhostPosition();
        
        _player.RestartPlayerPosition();
        
        IsPlay = true;
    }
}
