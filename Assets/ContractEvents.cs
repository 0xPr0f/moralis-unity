using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Moralis.Web3Api.Models;
using MoralisWeb3ApiSdk;

public class ContractEvents : MonoBehaviour
{
    
    //string abil = "{     \"anonymous\": false,     \"inputs\": [       {         \"indexed\": false,         \"internalType\": \"address\",         \"name\": \"_from\",         \"type\": \"address\"       },       {         \"indexed\": false,         \"internalType\": \"uint256\",         \"name\": \"_amount\",         \"type\": \"uint256\"       }     ],     \"name\": \"TokenPurchased\",     \"type\": \"event\"   }";
   // public string abi; // passed through the inspector
                       // The Abi passed should only be the needed abi not the whole abi
    /*
    {      "anonymous": false,      "inputs": [        {          "indexed": true,          "internalType": "address",          "name": "from",          "type": "address"        },        {          "indexed": true,          "internalType": "address",          "name": "to",          "type": "address"        },        {          "indexed": false,          "internalType": "uint256",          "name": "value",          "type": "uint256"        }      ],      "name": "Transfer",      "type": "event"    }
    */
    /// <summary>
    /*////////
    /// </summary>
    public async void fetchContractEvents()
    {
        List<LogEvent> logEvents = await MoralisInterface.GetClient().Web3Api.Native.GetContractEvents(address: "0xdBeFFE67FcAc67F11e18934E82e60Af17EE982A7", topic: "0x55c18555197c6574627cf460c66073d10aa05d412468800b7b71feeaf82ea92d", abi: abi, ChainList.mumbai);
        foreach (LogEvent logEvent in logEvents)
        {
            print(logEvent.ToJson());
        }
    }
    */
}