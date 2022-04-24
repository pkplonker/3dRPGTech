using System;
using System.Collections;
using Save;
using UnityEditor;
using UnityEngine;
public class Despawner : MonoBehaviour
{
   public float remainingTime { get; private set; }
   public void Init( float despawnTime)
   {
      remainingTime = despawnTime;
      if (EditorApplication.isPlaying)
      {
         StartCoroutine(Despawn());
      }
   }

   private void OnEnable()
   {
      if (remainingTime > 0)
      {
         StartCoroutine(Despawn());
      }
   }

   IEnumerator Despawn()
   {
      while(remainingTime > 0f) 
      {
         remainingTime -= Time.deltaTime; 
         yield return null;
      }
      Destroy(gameObject);
   }

   
}
