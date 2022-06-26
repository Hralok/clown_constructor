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
            throw new System.Exception("����������� �������� ������ Fabricator ��� �� ����������������!");
        }

        targetUsed = new List<int>();

        foreach (var targetArea in targetAreas)
        {
            if (targetArea.targetsCount <= 0)
            {
                throw new System.Exception("� ������� ������ ���� ���������� ������� ������� ���� ����!");
            }

            if (targetArea.rules.Contains(TargetRulesEnum.NoRepetitions) && targetArea.targetsCount < targetArea.area.Count)
            {
                throw new System.Exception("���������� ��������� �����������, �.�. �������� ������� ��� ���������� � ������ � ���� ���������� ������� ������ ����� ��� ������������ �� �����!");
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
                throw new System.Exception("������ �������� ������ �������� ������� �� ������ �������!");
            }

            if (effect.targetsIndexes == null && effect.targetsIndexes.Count == 0)
            {
                throw new System.Exception("������ ���� ������� ������� ���� ����!");
            }

            foreach (var targetIndex in effect.targetsIndexes)
            {
                if (targetIndex >= targetsRealCount)
                {
                    throw new System.Exception("���������� ������� ���� ��� ��������� �����!");
                }
                else
                {
                    targetUsed[targetIndex] = 1;
                }

            }
        }

        if (targetUsed.Sum() != targetsRealCount)
        {
            throw new System.Exception("�� ��� ���� ������������!");
        }
        this.effects = effects;

        this.interruptible = interruptible;

        if (maxCooldown < 0)
        {
            throw new System.Exception("maxCooldown �� ����� ���� �������������!");
        }
        this.maxCooldown = maxCooldown;

        if (!TextManager.CheckIdExistence(descriptionTextIndex))
        {
            throw new System.Exception("������ ���������� �������� �� ���������� � �������!");
        }
        this.descriptionTextIndex = descriptionTextIndex;
    }





}
