using UnityEngine;
using UnityEngine.Events;

public class QuestDestuctable : MonoBehaviour
{
    public UnityAction Destructed;

    private Destructable _destructable;

    private void Awake()
    {        
        _destructable = GetComponent<Destructable>();        
        _destructable.Destructed += OnDestructed;
    }

    private void OnDestructed()
    {        
        Destructed?.Invoke();
    }

    private void OnDestroy()
    {        
        _destructable.Destructed -= OnDestructed;
    }
}