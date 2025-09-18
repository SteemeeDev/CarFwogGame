using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MenuMain : MonoBehaviour
{
    [SerializeField] string gamescene;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Its over UI elements");
            anim.SetTrigger("Over");
        }
        else
        {
            Debug.Log("Its NOT over UI elements");
            anim.SetTrigger("Not Over");
        }
    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene(gamescene);
    }
}
