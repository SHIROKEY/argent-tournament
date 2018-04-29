﻿using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Abstract;
using Assets.Scripts.Management;

namespace Assets.Scripts.UI
{
    public class EnemyHealth : Bar
    {
        private Name _enemyName;
        private ElementManager _elementManager;

        private void Awake()
        {
            _elementManager = FindObjectOfType<ElementManager>();
            _elementManager.EnemyHealthBar = this;
            Debug.Log(this.GetType() + " loaded");
        }

        private void Start()
        {
            _enemyName = GetComponentInChildren<Name>();
            InitializeIndication();
            Increase(MaxAmount);
        }

        public void Refresh(float maxAmount, string newName)
        {
            this.MaxAmount = maxAmount;
            _enemyName.SetName(newName);
            Increase(MaxAmount);
        }

        public bool IsOutOfHP(float amount)
        {
            var remainingHP = Decrease(amount);
            if (remainingHP <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}