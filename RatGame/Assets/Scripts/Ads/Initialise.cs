using UnityEngine;
using GoogleMobileAds.Api;

namespace Ads
{
    
    
    public class Initialise : MonoBehaviour
    {
        private void Start()
        {
          MobileAds.Initialize(status => { });
        }
    }
}
