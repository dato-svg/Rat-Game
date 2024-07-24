using System;
using UnityEngine;

namespace Ads
{
    public class StartShowInter : MonoBehaviour
    {
        private InterShow _interShow;


        private void Start()
        {
            _interShow = GetComponent<InterShow>();
            _interShow.ShowAd();
        }
    }
}
