using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Poder_Colision : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.transform.TryGetComponent<Poder>(out Poder poder))
      {
         ArkanoidEvent.OnPoderReachDeadZoneEvent?.Invoke(poder);
      }
   }
}
