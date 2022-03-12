using System.Collections;
using System.Collections.Generic;
using Moralis.Platform.Objects;
using Moralis.Platform.Queries;
using MoralisWeb3ApiSdk;
using Newtonsoft.Json;
using UnityEngine;

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

public class Objects : MonoBehaviour
{
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

    public async void RetrieveObjectFromDB()
    {
        MoralisQuery<Character> character = MoralisInterface.GetClient().Query<Character>().WhereEqualTo("Level", 80);
        IEnumerable<Character> result = await character.FindAsync();
        foreach(Character c in result)
        {
            print("The warlord is " + c.Name + " with" + c.Skill);
        }
    }
}
