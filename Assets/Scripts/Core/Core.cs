using System;
using Core.CoreComponents;
using System.Collections.Generic;
using System.Collections;

using UnityEngine;

namespace Core
{
    public class Core : MonoBehaviour
    {
        public Movement Movement { get; private set; }
        public Combat Combat { get; private set; }
        public Stats Stats { get; private set; }

        private void Awake()

        {
            Movement = GetComponentInChildren<Movement>();
            Combat = GetComponentInChildren<Combat>();
            Stats = GetComponentInChildren<Stats>();
        }

        public void LogicUpdate()
        {
            Movement.LogicUpdate();
        }
    }
}