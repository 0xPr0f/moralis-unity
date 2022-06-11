using System.Collections;
using System.Collections.Generic;
using Moralis.Web3Api.Models;
using MoralisWeb3ApiSdk;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Moralis.SolanaApi.Models;
using Moralis.SolanaApi;
using Moralis.Platform.Objects;
using Nethereum.RPC.Eth.DTOs;
using System;
using Nethereum.Hex.HexTypes;

public class MoralisManager : MonoBehaviour
{
    public InputField AddressText;

    public InputField TokenText;
    public TMP_InputField OutPutAddress;
    public TMP_InputField OutPutToken;
    public TMP_InputField search;
#if !UNITY_WEBGL
    public async void GetNFT()
    {
        Type status = await MoralisInterface.GetClient().Web3Api.Token.ReSyncMetadata(address: "0x7de3085b3190b3a787822ee16f23be010f5f8686", tokenId: "1", chain: ChainList.eth);
        print(status.ToString());
        OutPutAddress.text = status.ToString();
    }
    public async void GetNFTT()
    {
        Moralis.SolanaApi.Models.NftMetadata nftmetadata = await MoralisSolanaClient.SolanaApi.Nft.GetNFTMetadata(NetworkTypes.mainnet, "6XU36wCxWobLx5Rtsb58kmgAJKVYmMVqy4SHXxENAyAe");
        print(nftmetadata);
        NftOwnerCollection balance = await MoralisInterface.GetClient().Web3Api.Account.GetNFTs(AddressText.text.ToLower(), ChainList.mumbai);
        OutPutAddress.text = nftmetadata.ToString();
    
    }
    public async void GetTransactions()
    {
        TransactionCollection balance = await MoralisInterface.GetClient().Web3Api.Account.GetTransactions("0x4c6Ec2448C243B39Cd1e9E6db0F9bF7436c0c93f", ChainList.eth);
        OutPutAddress.text = balance.ToJson();
    }
    public async void GetNativeBalance()
    {
        Moralis.Web3Api.Models.NativeBalance balance = await MoralisInterface.GetClient().Web3Api.Account.GetNativeBalance("0x4c6Ec2448C243B39Cd1e9E6db0F9bF7436c0c93f".ToLower(), ChainList.eth);
        OutPutAddress.text = balance.ToJson();
    }
    

    public async void NFTInContractfromAdd()
    {
        OutPutAddress.text = "Fetching your NFTs from " + TokenText.text + "...";
        NftOwnerCollection balance = await MoralisInterface.GetClient().Web3Api.Account.GetNFTsForContract(address:AddressText.text.ToLower(), TokenText.text, ChainList.mumbai);
        string NFTbalance = balance.ToJson();
        OutPutAddress.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);
    }

    public async void TokenBalance()
    {
        OutPutAddress.text = "Fetching your ERC 20 Token balances...";
        List<Erc20TokenBalance> balance = await MoralisInterface.GetClient().Web3Api.Account.GetTokenBalances(AddressText.text.ToLower(), ChainList.eth);
        OutPutAddress.text = "";      
        for (int i = 0; i < balance.Count; i++)
        {
           
            print(balance[i].ToJson());
        }
        foreach (Erc20TokenBalance bal in balance)
        {
            OutPutAddress.text += JToken.Parse(bal.ToJson()).ToString(Formatting.Indented);
        }
    }

    public async void TokenTransfers()
    {
        OutPutAddress.text = "Fetching your Token Trasactions..";
        Erc20TransactionCollection balance = await MoralisInterface.GetClient().Web3Api.Account.GetTokenTransfers(AddressText.text.ToLower(), ChainList.eth);
        string NFTbalance = balance.ToJson();
        OutPutAddress.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);
    }

    // token queries
    public async void fetchLogsByAddress()
    {
        NftMetadataCollection metadata = await MoralisInterface.GetClient().Web3Api.Token.SearchNFTs(q: "lol", ChainList.eth,filter:"lol");
        Resolve resolve = await MoralisInterface.GetClient().Web3Api.Resolve.ResolveDomain(domain:"lol.x");
        print(resolve.ToJson());
        LogEventByAddress logEvents = await  MoralisInterface.GetClient().Web3Api.Native.GetLogsByAddress(address: "0x057Ec652A4F150f7FF94f089A38008f49a0DF88e", ChainList.bsc, topic0:"",topic1:"");
        print(logEvents.ToJson());
    }

    public async void AllNFTContract()
    {
        //TradesCollection trades = await MoralisInterface.GetClient().Web3Api.Token.GetNFTTrades(address: "0x7de3085b3190b3a787822ee16f23be010f5f8686", ChainList.eth);
        TradeCollection trades = await MoralisInterface.GetClient().Web3Api.Token.GetNFTTrades("0x7de3085b3190b3a787822ee16f23be010f5f8686", ChainList.eth, limit: 10);
        OutPutToken.text = "Fetching All metadata in " + TokenText.text;
        NftCollection nfts = await MoralisInterface.GetClient().Web3Api.Token.GetAllTokenIds(address: TokenText.text,chain:ChainList.mumbai);
        print(nfts.ToJson());
        OutPutToken.text = JToken.Parse(nfts.ToJson()).ToString(Formatting.Indented);
    }

    public async void NFTcontractTransfers()
    {
        List<SplNft> SplNFTbal = await MoralisSolanaClient.SolanaApi.Account.GetNFTs(NetworkTypes.mainnet, "6XU36wCxWobLx5Rtsb58kmgAJKVYmMVqy4SHXxENAyAe");
        foreach (SplNft splnft in SplNFTbal)
        {
            print(splnft);
        }
        Trade trade = await MoralisInterface.GetClient().Web3Api.Token.GetNFTLowestPrice(address: "0x7de3085b3190b3a787822ee16f23be010f5f8686", ChainList.eth, days: 2);
        OutPutToken.text = "Fetching All Contract transfers in " + TokenText.text;
        NftTransferCollection nftTransfers = await MoralisInterface.GetClient().Web3Api.Token.GetContractNFTTransfers(TokenText.text, ChainList.polygon);
        string NFTbalance = nftTransfers.ToJson();
        OutPutToken.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);
    }
    public async void NFTmetadata()
    {
        
        OutPutToken.text = "Fetching All Contract metadata";
        NftContractMetadata metadata = await MoralisInterface.GetClient().Web3Api.Token.GetNFTMetadata(TokenText.text, ChainList.mumbai);
        string NFTbalance = metadata.ToJson();
        OutPutToken.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);
    }
    public async void Search()
    {
       Portfolio PortfolioBal = await MoralisSolanaClient.SolanaApi.Account.GetPortfolio(NetworkTypes.mainnet, "6XU36wCxWobLx5Rtsb58kmgAJKVYmMVqy4SHXxENAyAe");
       print(PortfolioBal);
        
        OutPutToken.text = "Searching For NFT...";
        NftMetadataCollection metadata = await MoralisInterface.GetClient().Web3Api.Token.SearchNFTs(search.text, ChainList.eth, null, null, null, null, null, null, 0, 100);
        string NFTbalance = metadata.ToJson();
        OutPutToken.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);

    }

    public async void SendRawETH()
    {
        // Retrieve from address, the address used to athenticate the user.
        MoralisUser user = await MoralisInterface.GetUserAsync();
        int transferAmount = 1000;
        string fromAddress = user.authData["moralisEth"]["id"].ToString();
        string toAddress = "0xE1E891fE77ea200eaE62c9C9B3395443cc6ed7bE";
        // Create transaction request.
        TransactionInput txnRequest = new TransactionInput()
        {
            Data = String.Empty,
            From = fromAddress,
            To = toAddress,
            Value = new HexBigInteger(transferAmount)
        };
        try
        {
            // Execute the transaction.
            string txnHash = await MoralisInterface.Web3Client.Eth.TransactionManager.SendTransactionAsync(txnRequest);

            Debug.Log($"Transfered {transferAmount} WEI from {fromAddress} to {toAddress}.  TxnHash: {txnHash}");
        }
        catch (Exception exp)
        {
            Debug.Log($"Transfer of {transferAmount} WEI from {fromAddress} to {toAddress} failed! with error {exp}");
        }
    }
    public async void ReadFunction()
    {
        // Function ABI input parameters
        object[] inputParams = new object[1];
        inputParams[0] = new { internalType = "address", name = "account", type = "address"};
        // Function ABI Output parameters
        object[] outputParams = new object[1];
        outputParams[0] = new { internalType = "uint256", name = "", type = "uint256"};
        // Function ABI
        object[] abi = new object[1];
        abi[0] = new { inputs = inputParams, name = "balanceOf", outputs = outputParams, stateMutability = "view", type = "function" };
        // Define request object
        RunContractDto rcd = new RunContractDto()
        {
            Abi = abi,
            Params = new { account = "0x3355d6E71585d4e619f4dB4C7c5Bfe549b278299" }
        };
        string resp = await MoralisInterface.GetClient().Web3Api.Native.RunContractFunction("0xdAC17F958D2ee523a2206206994597C13D831ec7", "balanceOf", rcd, ChainList.eth);
        print(resp);
    }
    public async void ReadMoreInputsFunction()
    {
        // Function ABI input parameters
        object[] inputParams = new object[3];
        inputParams[0] = new { internalType = "address", name = "account", type = "address" };
        inputParams[1] = new { internalType = "address", name = "test", type = "address" };
        inputParams[2] = new { internalType = "uint24", name = "lol", type = "uint24" };
        // Function ABI Output parameters
        object[] outputParams = new object[1];
        outputParams[0] = new { internalType = "address", name = "", type = "address" };
        // Function ABI
        object[] abi = new object[1];
        abi[0] = new { inputs = inputParams, name = "getPool", outputs = outputParams, stateMutability = "view", type = "function" };
        // Define request object
        RunContractDto rcd = new RunContractDto()
        {
            Abi = abi,
            Params = new { account = "0x3355d6E71585d4e619f4dB4C7c5Bfe549b278299", test = "0x3355d6E71585d4e619f4dB4C7c5Bfe549b278299", lol = "1" }
        };
        string resp = await MoralisInterface.GetClient().Web3Api.Native.RunContractFunction("0xdAC17F958D2ee523a2206206994597C13D831ec7", "getPool", rcd, ChainList.eth);
        print(resp);
    }
#endif
}
