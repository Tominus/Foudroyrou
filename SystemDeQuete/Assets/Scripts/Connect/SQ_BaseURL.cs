using UnityEngine;

public static class SQ_BaseURL
{
    const string BASE_LINK = "http://localhost/quests/";
    //const string BASE_LINK = "https://nassimpastissimulator.000webhostapp.com/Quests/";
    public static string QUEST_LINK = $"{BASE_LINK}getQuest.php";
}