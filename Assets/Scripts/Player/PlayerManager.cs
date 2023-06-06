using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TextMeshProUGUI numberOfCoinsText;
    public static int currentHP = 100;
    public Slider healthBar;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject pausePanel;

    public XRController rightController;


    void Start()
    {
       // var inputDevices = new List<UnityEngine.XR.InputDevice>();
       // UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        numberOfCoins = 0;
        gameOver = false;

    }


    void Update()
    {
        numberOfCoinsText.text = "CANDIES: " + numberOfCoins;

        healthBar.value = currentHP;

        /*if(Input.GetKeyDown("escape"))
        {

            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }*/

        if (currentHP <= 0)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
            currentHP = 100;
        }
    }
}
