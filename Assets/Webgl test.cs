
using UnityEngine;
using MoralisWeb3ApiSdk;
#if UNITY_WEBGL
using System.Collections.Generic;
using Moralis.WebGL.Platform.Queries;
using Moralis.WebGL.Platform.Objects;
using Moralis.WebGL.Web3Api.Models;
#else
using System.Collections.Generic;
using Moralis.Platform.Queries;
using Moralis.Platform.Objects;
using Moralis.Web3Api.Models;
#endif
public class Webgltest : MonoBehaviour
{

    public class PlayerData : MoralisObject
    {
        public int frameIndex { get; set; }
        public string gotenstring { get; set; }
        public string nftLink { get; set; }
        public string address { get; set; }
        public GameObject frame { get; set; }
        public PlayerData() : base("PlayerData")
        {
        }
    } 

    public async void GetUser()
    { 
        Debug.LogError("Calling frames 1");
       MoralisUser user = await MoralisInterface.GetUserAsync();
        int frameIndex = 1;
        Debug.LogError("Calling frames");
        string addr = user.authData["moralisEth"]["id"].ToString();

#if UNITY_WEBGL
        MoralisQuery<PlayerData> addrQuery = await MoralisInterface.GetClient().Query<PlayerData>();

        addrQuery = addrQuery.WhereEqualTo("address", addr);
        IEnumerable<PlayerData> result = await addrQuery.FindAsync();
        print(addr + " gotten");
        foreach (PlayerData p in result)
        {
            print(p.frameIndex + " " + p.nftLink);
            if (p.frameIndex == frameIndex)
            {
              //  gotenstring = p.nftLink;
               // StartCoroutine(Nfts(gotenstring));
            }
        }
#endif

    }
}
