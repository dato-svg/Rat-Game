using UnityEngine;

public class RandomObjectGiver : MonoBehaviour
{
   private Spawner spawner;

   private int randomIndex;

   private void Start()
   {
      spawner = GetComponent<Spawner>();
   }


   public void RandomGiver()
   {
       randomIndex = Random.Range(0, 2);

       if (randomIndex == 1)
       {
           spawner.Spawn("Cheese");
       }
       else
       {
           Debug.Log("Nothing");
       }
   }
}
