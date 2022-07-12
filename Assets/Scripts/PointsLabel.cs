using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PointsLabel : MonoBehaviour
{
    [SerializeField] private string _pattern;
    
    private Text _label;

    private void Awake()
    {
        _label = GetComponent<Text>();
    }

    public void Init(int points)
    {
        _label.text = string.Format(_pattern, points);
    }
}
