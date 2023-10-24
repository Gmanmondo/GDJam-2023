using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WardenDialogueBox : MonoBehaviour
{
    public GameObject camera;
    public float distance = 5f;
    public GameObject inGameText;
    public Image UITextbox;
    public TextMeshProUGUI UIText;
    public GameObject wardenBox;
    private UIManager manager;

    void Start()
    {
        manager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        RaycastHit seeDialogue;
        //if (Physics.Raycast(camera.transform.position, camera.transform.forward, out seeDialogue, 10f))
        if(manager.speaking | !inGameText.GetComponent<Renderer>().isVisible)
        {
            ShowUI();
        }
        else
        {
            HideUI();
        }
        FollowPlayer();
        //Debug.Log(seeDialogue.transform.gameObject.name);
        //Debug.Log(UITextbox.color.a);
        Debug.Log(manager.speaking);
    }

    void ShowUI()
    {
        var tempColor = UITextbox.color;
        var tempColor1 = UIText.color;
        tempColor.a = 1f;
        tempColor1.a = 1f;
        UITextbox.color = tempColor;
        UIText.color = tempColor1;
    }

    void HideUI()
    {
        var tempColor = UITextbox.color;
        var tempColor1 = UIText.color;
        tempColor.a = 0f;
        tempColor1.a = 0f;
        UITextbox.color = tempColor;
        UIText.color = tempColor1;
    }

    void FollowPlayer()
    {
        wardenBox.transform.LookAt(PlayerSingleton._pRef.pTrans); 
    }
}
