using System.Collections;
using Save;
using UnityEngine;

public class Despawner : MonoBehaviour
{
   public float remainingTime { get; private set; }
   public void Init(ItemSpawner spawner, float despawnTime)
   {
      remainingTime = despawnTime;
      StartCoroutine(Despawn(remainingTime));
   }

   IEnumerator Despawn(float remainingTime)
   {
      while(remainingTime > 0f) 
      {
         remainingTime -= Time.deltaTime; 
         yield return null;
      }
      Destroy(gameObject);
   }


 
}
