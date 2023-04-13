using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField]public bool isFree;
    [SerializeField] private Tower tower;
    public bool IsFree
    {
        get { return isFree; }
    }
    private void OnMouseDown()
    {
        if (!isFree)
            return;
        bool isPlaced = tower.CreateTower(tower, transform.position);
        isFree = false;
    }
}
