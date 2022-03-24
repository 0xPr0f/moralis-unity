using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Moralis.Platform.Objects;
using Moralis.Web3Api.Models;
using MoralisWeb3ApiSdk;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using UnityEngine;


public class SendCustomToken : MonoBehaviour
{
   public string ABI;
    public string NFt721ABI;
    public RunContractDto runContractDto;
   
   // public static NetworkVariable<FixedString64Bytes> PlayerName = new NetworkVariable<FixedString64Bytes>();
    /*
     * ABI for erc20 token
     * 
     [ 	{ 		"inputs": [], 		"stateMutability": "nonpayable", 		"type": "constructor" 	}, 	{ 		"anonymous": false, 		"inputs": [ 			{ 				"indexed": true, 				"internalType": "address", 				"name": "owner", 				"type": "address" 			}, 			{ 				"indexed": true, 				"internalType": "address", 				"name": "spender", 				"type": "address" 			}, 			{ 				"indexed": false, 				"internalType": "uint256", 				"name": "value", 				"type": "uint256" 			} 		], 		"name": "Approval", 		"type": "event" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "spender", 				"type": "address" 			}, 			{ 				"internalType": "uint256", 				"name": "amount", 				"type": "uint256" 			} 		], 		"name": "approve", 		"outputs": [ 			{ 				"internalType": "bool", 				"name": "", 				"type": "bool" 			} 		], 		"stateMutability": "nonpayable", 		"type": "function" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "spender", 				"type": "address" 			}, 			{ 				"internalType": "uint256", 				"name": "subtractedValue", 				"type": "uint256" 			} 		], 		"name": "decreaseAllowance", 		"outputs": [ 			{ 				"internalType": "bool", 				"name": "", 				"type": "bool" 			} 		], 		"stateMutability": "nonpayable", 		"type": "function" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "spender", 				"type": "address" 			}, 			{ 				"internalType": "uint256", 				"name": "addedValue", 				"type": "uint256" 			} 		], 		"name": "increaseAllowance", 		"outputs": [ 			{ 				"internalType": "bool", 				"name": "", 				"type": "bool" 			} 		], 		"stateMutability": "nonpayable", 		"type": "function" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "to", 				"type": "address" 			}, 			{ 				"internalType": "uint256", 				"name": "amount", 				"type": "uint256" 			} 		], 		"name": "transfer", 		"outputs": [ 			{ 				"internalType": "bool", 				"name": "", 				"type": "bool" 			} 		], 		"stateMutability": "nonpayable", 		"type": "function" 	}, 	{ 		"anonymous": false, 		"inputs": [ 			{ 				"indexed": true, 				"internalType": "address", 				"name": "from", 				"type": "address" 			}, 			{ 				"indexed": true, 				"internalType": "address", 				"name": "to", 				"type": "address" 			}, 			{ 				"indexed": false, 				"internalType": "uint256", 				"name": "value", 				"type": "uint256" 			} 		], 		"name": "Transfer", 		"type": "event" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "from", 				"type": "address" 			}, 			{ 				"internalType": "address", 				"name": "to", 				"type": "address" 			}, 			{ 				"internalType": "uint256", 				"name": "amount", 				"type": "uint256" 			} 		], 		"name": "transferFrom", 		"outputs": [ 			{ 				"internalType": "bool", 				"name": "", 				"type": "bool" 			} 		], 		"stateMutability": "nonpayable", 		"type": "function" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "owner", 				"type": "address" 			}, 			{ 				"internalType": "address", 				"name": "spender", 				"type": "address" 			} 		], 		"name": "allowance", 		"outputs": [ 			{ 				"internalType": "uint256", 				"name": "", 				"type": "uint256" 			} 		], 		"stateMutability": "view", 		"type": "function" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "account", 				"type": "address" 			} 		], 		"name": "balanceOf", 		"outputs": [ 			{ 				"internalType": "uint256", 				"name": "", 				"type": "uint256" 			} 		], 		"stateMutability": "view", 		"type": "function" 	}, 	{ 		"inputs": [], 		"name": "decimals", 		"outputs": [ 			{ 				"internalType": "uint8", 				"name": "", 				"type": "uint8" 			} 		], 		"stateMutability": "view", 		"type": "function" 	}, 	{ 		"inputs": [], 		"name": "name", 		"outputs": [ 			{ 				"internalType": "string", 				"name": "", 				"type": "string" 			} 		], 		"stateMutability": "view", 		"type": "function" 	}, 	{ 		"inputs": [], 		"name": "symbol", 		"outputs": [ 			{ 				"internalType": "string", 				"name": "", 				"type": "string" 			} 		], 		"stateMutability": "view", 		"type": "function" 	}, 	{ 		"inputs": [], 		"name": "totalSupply", 		"outputs": [ 			{ 				"internalType": "uint256", 				"name": "", 				"type": "uint256" 			} 		], 		"stateMutability": "view", 		"type": "function" 	} ]
     */

    /*
     * ABI for erc721 token
     * 
     * [{"inputs":[],"stateMutability":"nonpayable","type":"constructor"},{"anonymous":false,"inputs":[{"indexed":true,"internalType":"address","name":"owner","type":"address"},{"indexed":true,"internalType":"address","name":"approved","type":"address"},{"indexed":true,"internalType":"uint256","name":"tokenId","type":"uint256"}],"name":"Approval","type":"event"},{"anonymous":false,"inputs":[{"indexed":true,"internalType":"address","name":"owner","type":"address"},{"indexed":true,"internalType":"address","name":"operator","type":"address"},{"indexed":false,"internalType":"bool","name":"approved","type":"bool"}],"name":"ApprovalForAll","type":"event"},{"anonymous":false,"inputs":[{"indexed":true,"internalType":"address","name":"previousOwner","type":"address"},{"indexed":true,"internalType":"address","name":"newOwner","type":"address"}],"name":"OwnershipTransferred","type":"event"},{"anonymous":false,"inputs":[{"indexed":true,"internalType":"address","name":"from","type":"address"},{"indexed":true,"internalType":"address","name":"to","type":"address"},{"indexed":true,"internalType":"uint256","name":"tokenId","type":"uint256"}],"name":"Transfer","type":"event"},{"inputs":[{"internalType":"address","name":"to","type":"address"},{"internalType":"uint256","name":"tokenId","type":"uint256"}],"name":"approve","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"owner","type":"address"}],"name":"balanceOf","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"baseURI","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"uint256","name":"amount","type":"uint256"}],"name":"batchMint","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[],"name":"contractMetadataURI","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"contractURI","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"uint256","name":"tokenId","type":"uint256"}],"name":"getApproved","outputs":[{"internalType":"address","name":"","type":"address"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"address","name":"owner","type":"address"},{"internalType":"address","name":"operator","type":"address"}],"name":"isApprovedForAll","outputs":[{"internalType":"bool","name":"","type":"bool"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"maxMintable","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"name","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"owner","outputs":[{"internalType":"address","name":"","type":"address"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"uint256","name":"tokenId","type":"uint256"}],"name":"ownerOf","outputs":[{"internalType":"address","name":"","type":"address"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"renounceOwnership","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"to","type":"address"}],"name":"safeMint","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"from","type":"address"},{"internalType":"address","name":"to","type":"address"},{"internalType":"uint256","name":"tokenId","type":"uint256"}],"name":"safeTransferFrom","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"from","type":"address"},{"internalType":"address","name":"to","type":"address"},{"internalType":"uint256","name":"tokenId","type":"uint256"},{"internalType":"bytes","name":"_data","type":"bytes"}],"name":"safeTransferFrom","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"operator","type":"address"},{"internalType":"bool","name":"approved","type":"bool"}],"name":"setApprovalForAll","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"string","name":"newURI","type":"string"}],"name":"setContractURI","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"string","name":"newURI","type":"string"}],"name":"setURI","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"bytes4","name":"interfaceId","type":"bytes4"}],"name":"supportsInterface","outputs":[{"internalType":"bool","name":"","type":"bool"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"symbol","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"uint256","name":"tokenId","type":"uint256"}],"name":"tokenURI","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"address","name":"from","type":"address"},{"internalType":"address","name":"to","type":"address"},{"internalType":"uint256","name":"tokenId","type":"uint256"}],"name":"transferFrom","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"newOwner","type":"address"}],"name":"transferOwnership","outputs":[],"stateMutability":"nonpayable","type":"function"}]
     */

    // sending custom erc20 with out specifying gas
    public async void sendCustomTokenwithoutcustomgas()
{
    MoralisInterface.InsertContractInstance("LOL", ABI, "rinkeby", "0xfF75215204108992CFc2e902E560D461776BC906");
    Function f = MoralisInterface.EvmContractFunctionInstance("LOL", "rinkeby", "transfer");
    string playerAddress = "0xE1E891fE77ea200eaE62c9C9B3395443cc6ed7bE";
    string jsonresult = await f.SendTransactionAsync("0x37Ad540C876FceCf80090493F02068b115dDf8B6", playerAddress, 20);
    print(jsonresult);
}
   
// sending custom erc20cc specifying gas
public async void sendCustomTokenwithcustomgas()
{      
    MoralisInterface.InsertContractInstance("LOL", ABI, "rinkeby", "0x1f9840a85d5aF5bf1D1762F925BDADdC4201F984");
    // Set gas estimate
    HexBigInteger gas = new HexBigInteger(80000);
    string recieverAddress = "0xE1E891fE77ea200eaE62c9C9B3395443cc6ed7bE";
    string senderAddress = "0x37Ad540C876FceCf80090493F02068b115dDf8B6";
    object[] pars = { recieverAddress, 2000 };
    // Call the contract to claim the NFT reward.
    string resp = await MoralisInterface.SendEvmTransactionAsync("LOL", "rinkeby", "transfer", senderAddress, gas, new HexBigInteger("0x0"), pars);      
    print(resp);
}
// transfer nft
 public async static Task TransferNft()
    {
        string NftTokenId = "1";
    // Need the user for the wallet address
    MoralisUser user = await MoralisInterface.GetUserAsync();

        string addr = user.authData["moralisEth"]["id"].ToString();

        BigInteger bi = 0;

        if (BigInteger.TryParse(NftTokenId, out bi))
        {
            // Convert token id to hex as this is what the contract call expects
            object[] pars = new object[] { 
                // from
                addr, 
                // to
                "0xc539a39719Ad4D2DE7bf6f1e16F86383B6FF59C6", 
                // Token Id
                bi.ToString(),
                // Amount (count)
                (new HexBigInteger(1)).ToString(),
                // data
                new byte[] {0}
            };

            // Set gas estimate
            HexBigInteger gas = new HexBigInteger(30000);

            try
            {
                // Call the contract to transfer the NFT.
                string resp = await MoralisInterface.SendEvmTransactionAsync("Rewards", "mumbai", "safeTransferFrom", addr, gas, new HexBigInteger("0x0"), pars);

                Debug.Log($"$Send Transaction respo: {resp}");
            }
            catch (Exception exp)
            {
                Debug.Log($"Send transaction failed: {exp.Message}");
            }
        }
    }

// send an nft by calling a contract function
/*public async void sendErc721()
{
        string NftTokenId = "1";

        BigInteger bi = 3;
        // Convert token id to integer
        // Convert token id to hex as this is what the contract call expects
        if (BigInteger.TryParse(NftTokenId, out bi))
        {
            MoralisInterface.InsertContractInstance("721NFT",NFt721ABI, "rinkeby", "0xdE921D5FbbD0b688e6c8d249F32FA78AD48a4201");
    //Set gas estimate
    HexBigInteger gas = new HexBigInteger(80000); 
    string recieverAddress = "0xE1E891fE77ea200eaE62c9C9B3395443cc6ed7bE";
    string senderAddress = "0x37Ad540C876FceCf80090493F02068b115dDf8B6";
 object[] pars = { senderAddress,recieverAddress, bi.ToString("x") };
    
   string resp = await MoralisInterface.SendEvmTransactionAsync("721NFT", "rinkeby", "safeTransferFrom", senderAddress, gas, new HexBigInteger("0x0"), pars);
    print(resp);

      
        }else
        {
            print("not working");
        }
    }


public string FixImageUri(string imageuri)
{
    if (imageuri.StartsWith("ipfs://"))
    {
        return imageuri.Replace("ipfs://", "https://ipfs.moralis.io:2053/ipfs/");
    }
    return imageuri;

}
public void call()
{
  string result =  FixImageUri("ipfs://QmW5qHWBfE7yH8LFkeCmDNjBRPGEWqYDqjHgaLiQBDsuQg/4731.png");
    print(result);
}
    */
}
