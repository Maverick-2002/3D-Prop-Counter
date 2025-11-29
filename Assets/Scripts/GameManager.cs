using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TableArea roundTable;
    public TableArea squareTable;

    public Text roundCounterText;
    public Text squareCounterText;

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
}
