using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // player object
    public GameObject Player;
    GameObject playerContainer;
    PlayerController playerControl;

    // player statusbar manager
    public Image HPbar;
    public Image MPbar;
    public Image STAbar;
    // Start is called before the first frame update
    void Start()
    {
        playerContainer = Instantiate(Player, Vector2.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        barUpdate();
    }

    void barUpdate() {
        playerControl = playerContainer.GetComponent<PlayerController>();
        HPbar.fillAmount = playerControl.getHPrate();
        MPbar.fillAmount = playerControl.getMPrate();
        STAbar.fillAmount = playerControl.getSTArate();
    }
}
