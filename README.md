# Moralis-Unity

This is moralis unity query where we call different api methods.

## sending custom token with smart contract function without gas

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
## sending custom token with smart contract function with gas
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

## web3Api methods

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
        Character character = MoralisInterface.GetClient().Create<Character>();
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
        MoralisQuery<Character> character = MoralisInterface.GetClient().Query<Character>().WhereEqualTo("Level", 80);
        IEnumerable<Character> result = await character.FindAsync();
        foreach(Character c in result)
        {
            print("The warlord is " + c.Name + " with" + c.Skill);
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

if this project / readme helped you, give it a star 
