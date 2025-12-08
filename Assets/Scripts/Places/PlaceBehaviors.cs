using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public static class PlaceBehaviors
{
    public static void BuildingInteraction(Place place /*, Villager source*/)
    {
        //villager disappear
        //play Building animation
        //villager's variable += some% (would be either conversion bar, food bar, wood bar, stone bar)
        Debug.Log("Building interaction");
    }

    public static void ZoneInteraction()
    {
        //play villager's work anim
        //villager's variable += some% (would be either conversion bar, food bar, wood bar, stone bar)
        Debug.Log("Zone interaction");
    }

    public static void PassiveIncrease(Place place)
    {
        //some% of certain type += some%
    }
}
