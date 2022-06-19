using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbility : Ability
{
    public struct EffectGroup
    {
        readonly public List<AbilityEffect> effects;
        readonly public int delay;
        readonly public List<int> targetsIndexes;

        public EffectGroup(List<AbilityEffect> effects, int delay, List<int> targetsIndexes)
        {
            this.effects = effects;
            this.delay = delay;
            this.targetsIndexes = targetsIndexes;
        }
    }

    public struct TargetArea
    {
        readonly Map map;
        readonly HashSet<Vector2Int> area;
        readonly int targetsCount;
        readonly HashSet<TargetRulesEnum> rules;
        readonly bool isAbsolute;
        public TargetArea(
            Map map,
            HashSet<Vector2Int> area,
            bool isAbsolute,
            int targetsCount,
            HashSet<TargetRulesEnum> rules)
        {
            this.map = map;
            this.area = area;
            this.isAbsolute = isAbsolute;
            this.targetsCount = targetsCount;
            this.rules = rules;
        }
    }

    private List<(Vector2Int, Map)> targetsList;
    public List<TargetArea> targetAreas { get; private set; }
    public List<EffectGroup> effects { get; private set; } // Возможно стоит сделать приватным полем, а всю информацию о способности игрок будет получать из текстового описания
    public bool interruptible { get; private set; }
    public double maxCooldown { get; private set; }
    public double currentCooldown { get; private set; }
    public double currentDelay { get; private set; }
    public int currentEffectGroup { get; private set; }
    public bool inUse { get; private set; }
    public int descriptionTextIndex { get; private set; }

    public override void DoTheTurnStuff(Entity owner)
    {
        if (!inUse)
        {
            if (currentCooldown > 0)
            {
                currentCooldown -= 1;
            }
        }
        else
        {
            currentDelay -= 1;
            if (currentDelay <= 0)
            {

                List<(Vector2Int, Map)> targets = new List<(Vector2Int, Map)>();

                foreach (int i in effects[currentEffectGroup].targetsIndexes)
                {
                    targets.Add(targetsList[i]);
                }

                UseEffectGroup(effects[currentEffectGroup], targets, owner);
                currentEffectGroup++;

                while (effects[currentEffectGroup].delay == 0)
                {
                    foreach (int i in effects[currentEffectGroup].targetsIndexes)
                    {
                        targets.Add(targetsList[i]);
                    }

                    UseEffectGroup(effects[currentEffectGroup], targets, owner);
                    currentEffectGroup++;
                }

                if (currentEffectGroup < effects.Count - 1)
                {
                    currentDelay = effects[currentEffectGroup].delay;
                }
                else
                {
                    inUse = false;
                    currentCooldown = maxCooldown;
                }
            }
        }
    }

    public void UseAbility(List<(Vector2Int, Map)> targetsList, Entity owner)
    {
        if (inUse)
        {
            throw new System.Exception("Невозможно использовать уже используемую способность!");
        }
        else if (currentCooldown > 0)
        {
            throw new System.Exception("Невозможно использовать способность, которая находится на перезарядке!");
        }

        inUse = true;
        currentEffectGroup = 0;

        while (effects[currentEffectGroup].delay == 0)
        {
            List<(Vector2Int, Map)> targets = new List<(Vector2Int, Map)> ();

            foreach (int i in effects[currentEffectGroup].targetsIndexes)
            {
                targets.Add(targetsList[i]);
            }

            UseEffectGroup(effects[currentEffectGroup], targets, owner);
            currentEffectGroup++;
        }

        if (currentEffectGroup < effects.Count - 1)
        {
            currentDelay = effects[currentEffectGroup].delay;

            this.targetsList = targetsList;
        }
        else
        {
            inUse = false;
            currentCooldown = maxCooldown;
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
