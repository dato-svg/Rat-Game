using System;
using UnityEngine;
using GoogleMobileAds.Api;


namespace Ads
{
    public class RewShow : MonoBehaviour
    {
        private RewardedAd _rewardedAd;

        private string rewardedStatus = "ca-app-pub-3940256099942544/5224354917";


        private void OnEnable()
        {
            _rewardedAd = new RewardedAd(rewardedStatus);
            AdRequest adRequest = new AdRequest.Builder().Build();
            _rewardedAd.LoadAd(adRequest);
            _rewardedAd.OnUserEarnedReward += GiveHimSomething;
        }

        private void  GiveHimSomething(object sender, Reward e)
        {
            
        }

        public void ShowAd()
        {
            if (_rewardedAd.IsLoaded())
            {
                _rewardedAd.Show();
            }
        }
    }
}
