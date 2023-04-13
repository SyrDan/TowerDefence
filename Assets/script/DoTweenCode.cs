using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class DoTweenCode : MonoBehaviour
{
    [SerializeField] private TMP_Text MainMenuText;

    private void Update()
    {
        transform.DOLocalMove(GetMousePos(), 1f);
    }

    private Vector3 GetMousePos()
    {
        Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        new Plane(Vector3.forward, new Vector3(0, 0, -0.5f)).Raycast(ray, out float enter);
        return ray.GetPoint(enter);
        
    }
}
