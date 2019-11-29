using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class MenuTrigger : MonoBehaviour
{
    [SerializeField]
    public UnityEvent actions;

    public void Run()
    {
        actions.Invoke();
    }
}

