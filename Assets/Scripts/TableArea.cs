using System.Collections.Generic;
using UnityEngine;

public class TableArea : MonoBehaviour
{
    public string tableName;
    public List<GameObject> propsOnTable = new List<GameObject>();

    private void OnCollisionEnter(Collision other)
    {
            if (!propsOnTable.Contains(other.gameObject))
            {
                propsOnTable.Add(other.gameObject);
                GameManager.Instance.UpdateCounts();
            }
    }
    private void OnCollisionExit(Collision other)
    {
        if (propsOnTable.Contains(other.gameObject))
        {
            propsOnTable.Remove(other.gameObject);
            GameManager.Instance.UpdateCounts();
        }
    }
}