# Moralis-Unity

This is moralis unity a debugging repo for moralis unity sdk

## if this project / readme helped you, give it a star

<!--
## sending custom token with smart contract function with gas

```cs
 // sending custom erc20 specifying gas
 public async void sendCustomTokenwithcustomgas()
 {
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
-->

## web3Api methods

This includes most of the web3 api methods which all are tested and also some Json formatting `JToken.Parse(NFTbalance).ToString(Formatting.Indented)`

```cs
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
        List<Erc20TokenBalance> balance = await Moralis.Web3Api.Account.GetTokenBalances(AddressText.text, ChainList.eth);
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
        //TradesCollection trades = await Moralis.Web3Api.Token.GetNFTTrades(address: "0x7de3085b3190b3a787822ee16f23be010f5f8686", ChainList.eth);
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

```

## Custom Objects

```cs
public class Character : MoralisObject
{
    public int Strength { get; set; }
    public int Level { get; set; }
    public string Name { get; set; }
    public string Skill { get; set; }
    public List<string> Bag { get; set; }

    public Character() : base("Character")
    {
        Bag = new List<string>();
    }
}
```

## Saving objects to the database

```cs
public async void SaveObjectToDB()
    {
        Character character = Moralis.Create<Character>();
        character.Name = "Morphis";
        character.Strength = 100;
        character.Level = 80;
        character.Skill = "Strength";
        character.Bag.Add("Axe of Doom");
        character.Bag.Add("moralisSDK");
        await character.SaveAsync();
    }
```

## Retrieving from database

```cs
public async void RetrieveObjectFromDB()
    {
        MoralisQuery<Character> character = Moralis.Query<Character>();
        character = character.WhereEqualTo("Level", 80);
        IEnumerable<Character> result = await character.FindAsync();
        foreach(Character c in result)
        {
            print("The warlord is " + c.Name + " with" + c.Skill);
        }
    }
```

## edit from database

```cs
public async void updateObjectInDB()
    {
        MoralisQuery<Character> character = Moralis.Query<Character>();
        character = character.WhereEqualTo("Level", 80);
        IEnumerable<Character> result = await character.FindAsync();
        foreach(Character c in result)
        {
            c.Name = "0xprof_the_great";
            c.Skill = "10x_dev";
            await c.SaveAsync();
            print("The warlord is " + c.Name + " with" + c.Skill);
        }
    }
```

## Sending raw ETH

```cs
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
```

## Fixing ipfs link for images

```cs
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
```
