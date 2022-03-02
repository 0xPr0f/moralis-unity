using System.Collections;
using System.Collections.Generic;
using Moralis.Web3Api.Models;
using MoralisWeb3ApiSdk;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using UnityEngine;

public class SendCustomToken : MonoBehaviour
{
    public string ABI;
    public RunContractDto runContractDto;
   
    /*
     * ABI
     * 
     [ 	{ 		"inputs": [], 		"stateMutability": "nonpayable", 		"type": "constructor" 	}, 	{ 		"anonymous": false, 		"inputs": [ 			{ 				"indexed": true, 				"internalType": "address", 				"name": "owner", 				"type": "address" 			}, 			{ 				"indexed": true, 				"internalType": "address", 				"name": "spender", 				"type": "address" 			}, 			{ 				"indexed": false, 				"internalType": "uint256", 				"name": "value", 				"type": "uint256" 			} 		], 		"name": "Approval", 		"type": "event" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "spender", 				"type": "address" 			}, 			{ 				"internalType": "uint256", 				"name": "amount", 				"type": "uint256" 			} 		], 		"name": "approve", 		"outputs": [ 			{ 				"internalType": "bool", 				"name": "", 				"type": "bool" 			} 		], 		"stateMutability": "nonpayable", 		"type": "function" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "spender", 				"type": "address" 			}, 			{ 				"internalType": "uint256", 				"name": "subtractedValue", 				"type": "uint256" 			} 		], 		"name": "decreaseAllowance", 		"outputs": [ 			{ 				"internalType": "bool", 				"name": "", 				"type": "bool" 			} 		], 		"stateMutability": "nonpayable", 		"type": "function" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "spender", 				"type": "address" 			}, 			{ 				"internalType": "uint256", 				"name": "addedValue", 				"type": "uint256" 			} 		], 		"name": "increaseAllowance", 		"outputs": [ 			{ 				"internalType": "bool", 				"name": "", 				"type": "bool" 			} 		], 		"stateMutability": "nonpayable", 		"type": "function" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "to", 				"type": "address" 			}, 			{ 				"internalType": "uint256", 				"name": "amount", 				"type": "uint256" 			} 		], 		"name": "transfer", 		"outputs": [ 			{ 				"internalType": "bool", 				"name": "", 				"type": "bool" 			} 		], 		"stateMutability": "nonpayable", 		"type": "function" 	}, 	{ 		"anonymous": false, 		"inputs": [ 			{ 				"indexed": true, 				"internalType": "address", 				"name": "from", 				"type": "address" 			}, 			{ 				"indexed": true, 				"internalType": "address", 				"name": "to", 				"type": "address" 			}, 			{ 				"indexed": false, 				"internalType": "uint256", 				"name": "value", 				"type": "uint256" 			} 		], 		"name": "Transfer", 		"type": "event" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "from", 				"type": "address" 			}, 			{ 				"internalType": "address", 				"name": "to", 				"type": "address" 			}, 			{ 				"internalType": "uint256", 				"name": "amount", 				"type": "uint256" 			} 		], 		"name": "transferFrom", 		"outputs": [ 			{ 				"internalType": "bool", 				"name": "", 				"type": "bool" 			} 		], 		"stateMutability": "nonpayable", 		"type": "function" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "owner", 				"type": "address" 			}, 			{ 				"internalType": "address", 				"name": "spender", 				"type": "address" 			} 		], 		"name": "allowance", 		"outputs": [ 			{ 				"internalType": "uint256", 				"name": "", 				"type": "uint256" 			} 		], 		"stateMutability": "view", 		"type": "function" 	}, 	{ 		"inputs": [ 			{ 				"internalType": "address", 				"name": "account", 				"type": "address" 			} 		], 		"name": "balanceOf", 		"outputs": [ 			{ 				"internalType": "uint256", 				"name": "", 				"type": "uint256" 			} 		], 		"stateMutability": "view", 		"type": "function" 	}, 	{ 		"inputs": [], 		"name": "decimals", 		"outputs": [ 			{ 				"internalType": "uint8", 				"name": "", 				"type": "uint8" 			} 		], 		"stateMutability": "view", 		"type": "function" 	}, 	{ 		"inputs": [], 		"name": "name", 		"outputs": [ 			{ 				"internalType": "string", 				"name": "", 				"type": "string" 			} 		], 		"stateMutability": "view", 		"type": "function" 	}, 	{ 		"inputs": [], 		"name": "symbol", 		"outputs": [ 			{ 				"internalType": "string", 				"name": "", 				"type": "string" 			} 		], 		"stateMutability": "view", 		"type": "function" 	}, 	{ 		"inputs": [], 		"name": "totalSupply", 		"outputs": [ 			{ 				"internalType": "uint256", 				"name": "", 				"type": "uint256" 			} 		], 		"stateMutability": "view", 		"type": "function" 	} ]
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
        MoralisInterface.InsertContractInstance("LOL", ABI, "rinkeby", "0xfF75215204108992CFc2e902E560D461776BC906");
        // Set gas estimate
        HexBigInteger gas = new HexBigInteger(80000);
        string recieverAddress = "0xE1E891fE77ea200eaE62c9C9B3395443cc6ed7bE";
        string senderAddress = "0x37Ad540C876FceCf80090493F02068b115dDf8B6";
        object[] pars = { recieverAddress, 2000 };
        // Call the contract to claim the NFT reward.
        string resp = await MoralisInterface.SendEvmTransactionAsync("LOL", "rinkeby", "transfer", senderAddress, gas, new HexBigInteger("0x0"), pars);      
        print(resp);
    }

    public async void sendErc721()
    {
       
    }

}
