using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
     [SerializeField] private Button _startGameButton, _exitGameButton, _backButton;
     [SerializeField] private Button _level1, _level2;
     [SerializeField] private GameObject _buttonsPanel, _levelsPanel;


     private void Start()
     {
          _buttonsPanel.SetActive(true);
          _levelsPanel.SetActive(false);
          
          _startGameButton.onClick.AddListener(() =>
          {
               _buttonsPanel.SetActive(false);
               _levelsPanel.SetActive(true);
          }); 
          
          _exitGameButton.onClick.AddListener(Application.Quit);
          
          _backButton.onClick.AddListener(() =>
          {
               _buttonsPanel.SetActive(true);
               _levelsPanel.SetActive(false);
          });
          
          _level1.onClick.AddListener(() => SceneManager.LoadScene(1));
          _level2.onClick.AddListener(() => SceneManager.LoadScene(2));
     }
}
