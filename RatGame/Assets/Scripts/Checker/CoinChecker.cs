using Move;
using Session;
using UnityEngine;

namespace Checker
{
    public class CoinChecker : MainChecker
    {
        private GameSession _gameSession;
        private AudioSource _source;

        private IStorageServis _servis;
        
        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
            _source = GetComponent<AudioSource>();
            _servis = new JsonStarageServis();
             _gameSession.playerData.Cheese  = _servis.Load<int>("Coin");
             Debug.Log("Load Coin");
        }

       
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerMovement>() != null)
            {
                _source.Play();
                _gameSession.playerData.Cheese += 1;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(true);
                _servis.Save("COIN",_gameSession);
                Debug.Log("Save Coin");
            }
           
        }
    }
}
