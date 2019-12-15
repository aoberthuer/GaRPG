﻿using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    [SerializeField] private UseAction[] _actions = new UseAction[0];
    [SerializeField] private CrosshairDefinition _crosshairDefinition;

    private bool _wasPickedUp;
    
    public UseAction[] Actions => _actions;
    public CrosshairDefinition CrosshairDefinition => _crosshairDefinition;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (_wasPickedUp)
            return;
        
        var inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.Pickup(this);
            _wasPickedUp = true;
        }
    }

    private void OnValidate()
    {
        var collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }
}