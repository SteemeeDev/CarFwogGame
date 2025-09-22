using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuDeath : MonoBehaviour
{
    [SerializeField] GameObject deathscreen;
    [SerializeField] GameObject Canvas;

    ContinuosCarController carController;
    Animator frogAnimator;
    // Start is called before the first frame update
    void Start()
    {
        carController = FindAnyObjectByType<ContinuosCarController>();
        frogAnimator = carController.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playerdeath()
    {
        Object.Instantiate(deathscreen, Canvas.transform);
        carController.enabled = false;
        frogAnimator.SetTrigger("DrownFrog");
    }
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("menu_screen");
    }
}
