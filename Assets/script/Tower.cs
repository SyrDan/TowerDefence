using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 75;

    public bool CreateTower(Tower tower, Vector3 posiition)
    {
        var bank = FindObjectOfType<Bank>();

        if (bank == null)
            return false;
        if (bank.CurentBalance < cost)
            return false;

        Instantiate(tower.gameObject, posiition, Quaternion.identity);
        bank.WithDraw(cost);
        return true;
    }
}
