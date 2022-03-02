# Moralis-Unity

This is moralis unity query where we call different api methods.

# sending custom token with smart contract function (with and without gas)

```cs
    // sending custom erc20 with out specifying gas
    public async void sendCustomTokenwithoutcustomgas()
    {
        MoralisInterface.InsertContractInstance("LOL", ABI, "rinkeby", "0xfF75215204108992CFc2e902E560D461776BC906");
        Function f = MoralisInterface.EvmContractFunctionInstance("LOL", "rinkeby", "transfer");
        string playerAddress = "0xE1E891fE77ea200eaE62c9C9B3395443cc6ed7bE";
        string result = await f.SendTransactionAsync("0x37Ad540C876FceCf80090493F02068b115dDf8B6", playerAddress, 20);
        print(result);
    }
```

```cs
 // sending custom erc20 specifying gas
 public async void sendCustomTokenwithcustomgas()
 {
     MoralisInterface.InsertContractInstance("LOL", ABI, "rinkeby", "0xfF75215204108992CFc2e902E560D461776BC906");
     // Set gas estimate
     HexBigInteger gas = new HexBigInteger(80000);
     string recieverAddress = "0xE1E891fE77ea200eaE62c9C9B3395443cc6ed7bE";
     string senderAddress = "0x37Ad540C876FceCf80090493F02068b115dDf8B6";
     object[] pars = { recieverAddress, 20};
     // Call the contract to claim the NFT reward.
     string result = await MoralisInterface.SendEvmTransactionAsync("LOL", "rinkeby", "transfer", senderAddress, gas, new HexBigInteger("0x0"), pars);

     print(result);
 }
```

# web3Api endpoints

```cs
    public async void GetNFT()
    {
        OutPutAddress.text = "Fetching your NFTs...";
        NftOwnerCollection balance = await MoralisInterface.GetClient().Web3Api.Account.GetNFTs(AddressText.text.ToLower(), ChainList.mumbai);
        string NFTbalance = balance.ToJson();
        OutPutAddress.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);

    }

    public async void NFTInContractfromAdd()
    {
        OutPutAddress.text = "Fetching your NFTs from " + TokenText.text + "...";
        NftOwnerCollection balance = await MoralisInterface.GetClient().Web3Api.Account.GetNFTsForContract(AddressText.text.ToLower(), TokenText.text, ChainList.mumbai);
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
            OutPutAddress.text += JToken.Parse(balance[i].ToJson()).ToString(Formatting.Indented);
        }

    }

    public async void TokenTransfers()
    {
        OutPutAddress.text = "Fetching your Token Trasactions..";
        Erc20TransactionCollection balance = await MoralisInterface.GetClient().Web3Api.Account.GetTokenTransfers(AddressText.text.ToLower(), ChainList.eth);
        string NFTbalance = balance.ToJson();
        OutPutAddress.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);
    }



    public async void AllNFTContract()
    {
        OutPutToken.text = "Fetching All metadata in " + TokenText.text;
        NftCollection nfts = await MoralisInterface.GetClient().Web3Api.Token.GetAllTokenIds(TokenText.text, ChainList.mumbai);
        string NFTbalance = nfts.ToJson();
        OutPutToken.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);
    }

    public async void NFTcontractTransfers()
    {
        OutPutToken.text = "Fetching All Contract transfers in " + TokenText.text;
        NftTransferCollection nftTransfers = await MoralisInterface.GetClient().Web3Api.Token.GetContractNFTTransfers(TokenText.text, ChainList.mumbai);
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
        OutPutToken.text = "Searching For NFT...";
        NftMetadataCollection metadata = await MoralisInterface.GetClient().Web3Api.Token.SearchNFTs(search.text, ChainList.eth, null, null, null, null, null, null, 0, 100);
        string NFTbalance = metadata.ToJson();
        OutPutToken.text = JToken.Parse(NFTbalance).ToString(Formatting.Indented);

    }
```
