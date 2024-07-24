using UnityEngine;
using GoogleMobileAds.Api;

namespace Ads
{
    
    public class InterShow : MonoBehaviour
    {
        private InterstitialAd _interstitialAd;

        private string interstialStatus = "ca-app-pub-3940256099942544/6300978111";



        private void OnEnable()
        {
               _interstitialAd = new InterstitialAd(interstialStatus);
               AdRequest adRequest = new AdRequest.Builder().Build();
               _interstitialAd.LoadAd(adRequest);
               
        }

        public void ShowAd()
        {
            if (_interstitialAd.IsLoaded())
            {
                _interstitialAd.Show();
            }
        }
        
        
        }
}
