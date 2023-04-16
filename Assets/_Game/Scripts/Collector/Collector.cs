using AtmRush.Valuables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtmRush.Collect
{
    public class Collector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Unstacked") && !ValuableController.Instance.valuableList.Contains(other.gameObject))
            {
                other.gameObject.tag = "Stacked";
                other.GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.AddComponent<Valuable>();
                ValuableController.Instance.StackMoney(other.gameObject, ValuableController.Instance.valuableList.Count - 1);
                Player.PlayerController.Instance.ValuableCounterChanging(1);
            }
        }
    }

}