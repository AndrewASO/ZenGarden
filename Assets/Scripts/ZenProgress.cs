using UnityEngine;

public static class ZenProgress{


    public enum Zone { Rocks, Water, Lanterns, Pets }

    public static Zone lastCompletedZone;

    public static readonly string[] zoneMessages = {
        "You have found stillness in the stones.",      //Stones
        "Peace flows through you.",                     //Water
        "Your light lifts the spirit",                  //Lanterns
        "Compassion is the root of zen",                //Pets
    }; 

    public static readonly string[] zenLevels = {
        "Level 1: Zen Apprentice",       //1
        "Level 2: Zen Seeker",           //2
        "Level 3: Zen Adept",            //3
        "Level 4: Zen Master"            //4
    };

    public static bool rocksComplete = false;
    public static bool waterComplete = false;
    public static bool lanternComplete = false;
    public static bool petsComplete = false;

    public static void MarkComplete(Zone zone) {
        lastCompletedZone = zone;
        switch(zone) {
            case Zone.Rocks:        rocksComplete = true;       break;
            case Zone.Water:        waterComplete = true;       break;
            case Zone.Lanterns:     lanternComplete = true;     break;
            case Zone.Pets:         petsComplete = true;        break;
        }
    }

    public static string GetZoneMessage() => zoneMessages[ (int) lastCompletedZone ];

    public static string GetZenLevel() {
        int count = CompletedCount();
        if (count == 0) return "";
        return zenLevels[count - 1];
    }

    public static int CompletedCount() {
        int count = 0;
        if ( rocksComplete ) count++;
        if ( waterComplete ) count++;
        if ( lanternComplete ) count++;
        if ( petsComplete ) count++;
        return count;
    }

    public static bool AllComplete() => CompletedCount() >= 4;

    public static void Reset() {
        rocksComplete = false;
        waterComplete = false;
        lanternComplete = false;
        petsComplete = false;
    }
}
