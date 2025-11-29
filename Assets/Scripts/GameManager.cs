using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TableArea roundTable;
    public TableArea squareTable;
    public TextMeshProUGUI roundCounterText;
    public TextMeshProUGUI squareCounterText;
    public int resetScene;
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateCounts()
    {
        int roundCount = roundTable.propsOnTable.Count;
        int squareCount = squareTable.propsOnTable.Count;
        roundCounterText.text = "Round Table: " + roundCount;
        squareCounterText.text = "Square Table: " + squareCount;
    }

    public void Reset()
    {
        SceneManager.LoadScene(resetScene);
    }
}
