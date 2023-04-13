using UnityEditor;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLebeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockeColor = Color.gray;
    
    private WayPoint wayPoint;
    private TMP_Text label;
    private Vector2Int _coordenates;
    private void Awake()
    {
        wayPoint = GetComponentInParent<WayPoint>();
        label = GetComponent<TextMeshPro>();
        label.enabled = true;
        DisplayCoordinates();
    }
    private void Update()
    {
        ColorCoordinates();
        ToggleLabel();
        if (Application.isPlaying)
        {
            return;
        }
        if (label == null)
            label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
        UpadateObjectName();
    }
    void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
            label.enabled = !label.enabled;
    }

    private void ColorCoordinates()
    {
        label.color = wayPoint.IsFree ? defaultColor : blockeColor;
        if (wayPoint.IsFree)
         label.color = defaultColor;
        else 
            label.color = blockeColor;
    }

    private void UpadateObjectName()
    {
        transform.parent.name = _coordenates.ToString();
    }

    void DisplayCoordinates()
    {
        var position = transform.parent.position;
        _coordenates.x = Mathf.RoundToInt(position.x/ EditorSnapSettings.move.x);
        _coordenates.y = Mathf.RoundToInt(position.z / EditorSnapSettings.move.z);

        label.text = $"{ _coordenates.x}.{ _coordenates.y}";
    }
}

