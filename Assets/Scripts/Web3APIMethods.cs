using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoralisUnity;
using MoralisUnity.Web3Api.Models;
using TMPro;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Nethereum.Hex.HexTypes;
using MoralisUnity.Platform.Objects;
using Nethereum.RPC.Eth.DTOs;
using System;

public class Web3APIMethods : MonoBehaviour
{
    public TMP_InputField OutPutAddress;
    public TMP_InputField TokenText;
    public TMP_InputField AddressText;
    private async void Start()
    {
        try
        {
            Moralis.GetClient();

        }
        catch (Exception)
        {
            Moralis.Start(MoralisSettings.MoralisData.DappUrl, MoralisSettings.MoralisData.DappId);
        }
        MoralisUser user = await Moralis.GetUserAsync();
        if (user != null)
        {
            AddressText.text = user.authData["moralisEth"]["id"].ToString().ToLower();
        }
    }
    public async void ResolveAddress()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        Ens resolve = await Moralis.Web3Api.Resolve.ResolveAddress(AddressText.text);
        OutPutAddress.text = resolve.ToJson();
    }

    public async void GetNFTOwners()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        NftOwnerCollection owners = await Moralis.Web3Api.Token.GetNFTOwners(AddressText.text, ChainList.eth);
        OutPutAddress.text = owners.ToJson();
    }
    public async void getAllTokenId()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        NftCollection tokenid = await Moralis.Web3Api.Token.GetAllTokenIds(AddressText.text, ChainList.eth);
        OutPutAddress.text = tokenid.ToJson();
    }
    public async void GetNFT()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        NftOwnerCollection nft = await Moralis.Web3Api.Account.GetNFTs(AddressText.text, ChainList.eth);
        OutPutAddress.text = nft.ToJson();

    }
    public async void GetTransactions()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        TransactionCollection balance = await Moralis.Web3Api.Account.GetTransactions(AddressText.text, ChainList.eth);
        OutPutAddress.text = balance.ToJson();
    }
    public async void GetNativeBalance()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        NativeBalance balance = await Moralis.Web3Api.Account.GetNativeBalance(AddressText.text, ChainList.eth);
        OutPutAddress.text = balance.ToJson();
    }


    public async void NFTInContractfromAdd()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        OutPutAddress.text = "Fetching your NFTs from " + TokenText.text + "...";
        NftOwnerCollection balance = await Moralis.Web3Api.Account.GetNFTsForContract(address: AddressText.text, TokenText.text, ChainList.mumbai);
        string NFTbalance = balance.ToJson();
        OutPutAddress.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);
    }

    public async void TokenBalance()
    {
        OutPutAddress.text = "Fetching your ERC 20 Token balances...";
        List<Erc20TokenBalance> balance = await Moralis.Web3Api.Account.GetTokenBalances(AddressText.text, ChainList.bsc_testnet);
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
        Erc20TransactionCollection balance = await Moralis.Web3Api.Account.GetTokenTransfers(AddressText.text, ChainList.eth);
        string NFTbalance = balance.ToJson();
        OutPutAddress.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);
    }

    public async void searchNFT()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        NftMetadataCollection metadata = await Moralis.Web3Api.Token.SearchNFTs(q: "lol", ChainList.eth, filter: "lol");
        print(metadata.ToJson());

    }
    public async void ResolveDomain()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        Resolve resolve = await Moralis.Web3Api.Resolve.ResolveDomain(domain: "lol.x");
        print(resolve.ToJson());
    }
    // token queries
    public async void fetchLogsByAddress()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        LogEventByAddress logEvents = await Moralis.Web3Api.Native.GetLogsByAddress(address: "0x057Ec652A4F150f7FF94f089A38008f49a0DF88e", ChainList.bsc, topic0: "", topic1: "");
        print(logEvents.ToJson());
    }
    public async void GetNFTTrades()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        //TradesCollection trades = await MoralisInterface.GetClient().Web3Api.Token.GetNFTTrades(address: "0x7de3085b3190b3a787822ee16f23be010f5f8686", ChainList.eth);
        TradeCollection trades = await Moralis.Web3Api.Token.GetNFTTrades("0x7de3085b3190b3a787822ee16f23be010f5f8686", ChainList.eth, limit: 10);
        OutPutAddress.text = JToken.Parse(trades.ToJson()).ToString(Formatting.Indented);
    }

    public async void AllNFTContract()
    {
        OutPutAddress.text = "spining the bits ... for :" + AddressText.text;
        NftCollection nfts = await Moralis.Web3Api.Token.GetAllTokenIds(address: AddressText.text, chain: ChainList.mumbai);
        print(nfts.ToJson());
        OutPutAddress.text = JToken.Parse(nfts.ToJson()).ToString(Formatting.Indented);
    }
    public async void NFTmetadata()
    {

        OutPutAddress.text = "Fetching All Contract metadata";
        NftContractMetadata metadata = await Moralis.Web3Api.Token.GetNFTMetadata(AddressText.text, ChainList.mumbai);
        string NFTbalance = metadata.ToJson();
        OutPutAddress.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);
    }

    public async void SendRawETH()
    {
        // Retrieve from address, the address used to athenticate the user.
        MoralisUser user = await Moralis.GetUserAsync();
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
            string txnHash = await Moralis.Web3Client.Eth.TransactionManager.SendTransactionAsync(txnRequest);

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
        inputParams[0] = new { internalType = "address", name = "account", type = "address" };
        // Function ABI Output parameters
        object[] outputParams = new object[1];
        outputParams[0] = new { internalType = "uint256", name = "", type = "uint256" };
        // Function ABI
        object[] abi = new object[1];
        abi[0] = new { inputs = inputParams, name = "balanceOf", outputs = outputParams, stateMutability = "view", type = "function" };
        // Define request object
        RunContractDto rcd = new RunContractDto()
        {
            Abi = abi,
            Params = new { account = "0x3355d6E71585d4e619f4dB4C7c5Bfe549b278299" }
        };
        string resp = await Moralis.Web3Api.Native.RunContractFunction("0xdAC17F958D2ee523a2206206994597C13D831ec7", "balanceOf", rcd, ChainList.eth);
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
        string resp = await Moralis.Web3Api.Native.RunContractFunction("0xdAC17F958D2ee523a2206206994597C13D831ec7", "getPool", rcd, ChainList.eth);
        print(resp);
    }
}
