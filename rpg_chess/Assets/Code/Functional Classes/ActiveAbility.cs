using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbility : Ability
{
    public List<TargetArea> targetAreas { get; private set; }
    public List<EffectGroup> effects { get; private set; } // Возможно стоит сделать приватным полем, а всю информацию о способности игрок будет получать из текстового описания
    public bool interruptible { get; private set; }
    public double maxCooldown { get; private set; }
    public int descriptionTextIndex { get; private set; }

    public ActiveAbility(ActiveAbilityInitInfo info)
    {
        targetAreas = info.targetAreas;
        effects = info.effects;
        interruptible = info.interruptible;
        maxCooldown = info.maxCooldown;
        descriptionTextIndex = info.descriptionTextIndex;
    }

    public override int DoTheTurnStuff(Entity owner, int currentEffectGroup, List<(Vector2Int, Map)> targetsList)
    {
        int curEffect = currentEffectGroup;

        List<(Vector2Int, Map)> targets = new List<(Vector2Int, Map)>();

        foreach (int i in effects[curEffect].targetsIndexes)
        {
            targets.Add(targetsList[i]);
        }

        UseEffectGroup(effects[curEffect], targets, owner);
        curEffect++;

        while (effects[curEffect].delay == 0)
        {
            foreach (int i in effects[curEffect].targetsIndexes)
            {
                targets.Add(targetsList[i]);
            }

            UseEffectGroup(effects[curEffect], targets, owner);
            curEffect++;
        }

        if (curEffect < effects.Count - 1)
        {
            return  curEffect;
        }
        else
        {
            return -1;
        }


    }

    public int UseAbility(List<(Vector2Int, Map)> targetsList, Entity owner)
    {
        //if (inUse)
        //{
        //    throw new System.Exception("Невозможно использовать уже используемую способность!");
        //}
        //else if (currentCooldown > 0)
        //{
        //    throw new System.Exception("Невозможно использовать способность, которая находится на перезарядке!");
        //}
        int currentEffectGroup = 0;

        while (effects[currentEffectGroup].delay == 0)
        {
            List<(Vector2Int, Map)> targets = new List<(Vector2Int, Map)>();

            foreach (int i in effects[currentEffectGroup].targetsIndexes)
            {
                targets.Add(targetsList[i]);
            }

            UseEffectGroup(effects[currentEffectGroup], targets, owner);
            currentEffectGroup++;
        }

        if (currentEffectGroup < effects.Count - 1)
        {
            return currentEffectGroup;
        }
        else
        {
            return -1;
        }
    }

    private void UseEffectGroup(EffectGroup group, List<(Vector2Int, Map)> targets, Entity owner)
    {
        foreach (var effect in group.effects)
        {
            effect.DoTheStuff(targets, owner);
        }
    }




}
