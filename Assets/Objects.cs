using System.Collections.Generic;
using MoralisUnity.Platform.Queries;
using MoralisUnity.Platform.Objects;
using MoralisUnity;
using UnityEngine;

public class Character : MoralisObject
{
    public int Strength { get; set; }
    public int Level { get; set; }
    public string Name { get; set; }
    public string Skill { get; set; }
}

public class Objects : MonoBehaviour
{
    //  public string password;
    // public string email;
    //  public string username;

    public async void SaveObjectToDB()
    {
        Character character = Moralis.Create<Character>();
        character.Name = "Morphis";
        character.Strength = 100;
        character.Level = 80;
        character.Skill = "Strength";
        await character.SaveAsync();
    }
    public async void StorePlayer()
    {
        MoralisUser u = Moralis.Create<MoralisUser>();
        u.username = "clair@clem.clem";
        u.password = "Password1234";
        await u.SignUpAsync();

        u = await Moralis.LogInAsync(u.username, u.password);
        print(u);
    }

    public async void FetchedStoredPlayer()
    {

        MoralisUser loggedInUser = await Moralis.LogInAsync("profxyz", "potential");
        print(loggedInUser);
    }
    public async void RetrieveObjectFromDB()

    {
        MoralisQuery<Character> character = await Moralis.GetClient().Query<Character>();
        character = character.WhereEqualTo("Level", 80);
        IEnumerable<Character> result = await character.FindAsync();
        foreach (Character c in result)
        {
            print("The warlord is " + c.Name + " with" + c.Skill);
        }
    }

}
