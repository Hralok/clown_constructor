using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActiveAbilityInitInfo
{
    public List<TargetArea> targetAreas { get; private set; }
    public List<EffectGroup> effects { get; private set; } 
    public bool interruptible { get; private set; }
    public double maxCooldown { get; private set; }
    public int descriptionTextIndex { get; private set; }

    private int targetsRealCount = 0;
    private List<int> targetUsed;

    public ActiveAbilityInitInfo(
        List<TargetArea> targetAreas, 
        List<EffectGroup> effects, 
        bool interruptible, 
        double maxCooldown, 
        int descriptionTextIndex)
    {
        if (!Fabricator.resourcesInitialized || !Fabricator.damageTypesInitialized || !Fabricator.healTypesInitialized)
        {
            throw new System.Exception("Необходимые элементы класса Fabricator ещё не инициализированы!");
        }

        targetUsed = new List<int>();

        foreach (var targetArea in targetAreas)
        {
            if (targetArea.targetsCount <= 0)
            {
                throw new System.Exception("В области выбора цели необходимо выбрать минимум одну цель!");
            }

            if (targetArea.rules.Contains(TargetRulesEnum.NoRepetitions) && targetArea.targetsCount < targetArea.area.Count)
            {
                throw new System.Exception("Невозможно применить способность, т.к. включено правило без повторений и вместе с этим необходимо выбрать больше целей чем предлагается на выбор!");
            }

            targetsRealCount += targetArea.targetsCount;

            for (int i = 0; i < targetArea.targetsCount; i++)
            {
                targetUsed.Add(0);
            }

        }

        this.targetAreas = targetAreas;


        foreach (var effect in effects)
        {
            if (effect.effects == null && effect.effects.Count == 0)
            {
                throw new System.Exception("Группа эффектов должна состоять минимум из одного эффекта!");
            }

            if (effect.targetsIndexes == null && effect.targetsIndexes.Count == 0)
            {
                throw new System.Exception("Должна быть выбрана минимум одна цель!");
            }

            foreach (var targetIndex in effect.targetsIndexes)
            {
                if (targetIndex >= targetsRealCount)
                {
                    throw new System.Exception("Невозможно указать цель вне диапазона целей!");
                }
                else
                {
                    targetUsed[targetIndex] = 1;
                }

            }
        }

        if (targetUsed.Sum() != targetsRealCount)
        {
            throw new System.Exception("Не все цели использованы!");
        }
        this.effects = effects;

        this.interruptible = interruptible;

        if (maxCooldown < 0)
        {
            throw new System.Exception("maxCooldown не может быть отрицательным!");
        }
        this.maxCooldown = maxCooldown;

        if (!TextManager.CheckIdExistence(descriptionTextIndex))
        {
            throw new System.Exception("Такого текстового описания не существует в проекте!");
        }
        this.descriptionTextIndex = descriptionTextIndex;
    }





}
