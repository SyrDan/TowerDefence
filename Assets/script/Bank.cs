using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 250;
    
    private int currentBalance;

    [SerializeField] private TextMeshProUGUI displayBalance;
    private void Start()
    {
        currentBalance = startingBalance;
    }
    private void Update()
    {
        UpdateBalance();
    }
    public int CurentBalance
    {
        get { return currentBalance; }
    }
    public void Deposit(int value)
    {
        currentBalance += Mathf.Abs(value);

        if (currentBalance > 500)
            ReloadScene();
    }

    public void WithDraw(int value)
    {
        currentBalance -= Mathf.Abs(value);

        if (currentBalance < 0)
            ReloadScene();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void UpdateBalance()
    {
        displayBalance.text = $"Gold {currentBalance}";
    }
}
