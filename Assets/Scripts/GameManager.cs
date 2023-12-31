using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance;
    [SerializeField] GameObject obstacles;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] TextMeshProUGUI tooltipGrapple;
    [SerializeField] GameObject player;


    [Tooltip("How much money does the player have?")]
    public int money = 0;

    public bool snared = false;
    public int totalBoost = 0;
    public int totalDashes = 0;
    private int attempts = 1;

    public TextMeshProUGUI tooltipJetpack; // Tooltip text

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryAgain()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ResetPlayer();
        GameObject.FindGameObjectWithTag("LoseScreen").GetComponent<LoseScreen>().ShowLoseScreen(false);
        attempts++;
        foreach(Transform child in obstacles.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void HardReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateMoney(int moneyGained)
    {
        money += moneyGained;
        moneyText.text = "$: " + money.ToString();
    }


    public void SetWinScreen(bool b)
    {
        winScreen.SetActive(b);
        if (b)
        {
            winScreen.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"You reached the bottom in {attempts} attempts";
        }
    }

    public void SetLoseScreen(bool b)
    {
        loseScreen.SetActive(b);
    }

    public void ShowTooltip(string message)
    {
        tooltipGrapple.text = message;
        tooltipJetpack.text = message;
        tooltipGrapple.gameObject.SetActive(true);
        tooltipJetpack.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipGrapple.gameObject.SetActive(false);
        tooltipJetpack.gameObject.SetActive(false);
    }

    public void UpgradeJetpack()
    {
        totalBoost++;
        player.GetComponent<PlayerController>().ResetJetpackUses();
    }

    public void UpgradeGrapple()
    {
        totalDashes++;
        player.GetComponent<PlayerController>().ResetGrappleUses();
    }

}
