using System.Collections.Generic;
using UnityEngine;

public class TableArea : MonoBehaviour
{
    public string tableName;

    // Using List instead of HashSet
    public List<GameObject> propsOnTable = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Prop"))
        {
            if (!propsOnTable.Contains(other.gameObject))
            {
                propsOnTable.Add(other.gameObject);
                GameManager.Instance.UpdateCounts();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Prop"))
        {
            if (propsOnTable.Contains(other.gameObject))
            {
                propsOnTable.Remove(other.gameObject);
                GameManager.Instance.UpdateCounts();
            }
        }
    }
}