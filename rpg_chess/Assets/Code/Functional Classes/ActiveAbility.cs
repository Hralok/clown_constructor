using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbility : Ability
{

    List<(Map, Vector2Int)> targetsList;

    List<TargetArea> targetAreas;
    List<Effect> effects;

    protected struct Effect
    {
        readonly AbilityEffect effect;
        readonly int delay;
        readonly List<int> targetsIndexes;

        public Effect(AbilityEffect effect, int delay, List<int> targetsIndexes)
        {
            this.effect = effect;
            this.delay = delay;
            this.targetsIndexes = targetsIndexes;
        }
    }

    struct TargetArea
    {
        readonly Map map;
        readonly HashSet<Vector2Int> area;
        readonly int targetsCount;
        readonly HashSet<TargetRulesEnum> rules;

        public TargetArea(
            Map map,
            HashSet<Vector2Int> area,
            int targetsCount,
            HashSet<TargetRulesEnum> rules)
        {
            this.map = map;
            this.area = area;
            this.targetsCount = targetsCount;
            this.rules = rules;
        }
    }







    protected struct SingleEffect
    {
        AbilityEffect effect;
        List<int> inputTargets;

    }

    // ”казываютс€ координаты точки применени€ относительно примен€ющего.
    // ѕустое множество означает что выбрать целью можно любую точку карты.
    // ”казание координаты (0,0) равносильно применению на себ€,
    // если позвол€ют услови€ способности.

    // —писок всех эффектов способностей, сгруппированных по возможным точкам применени€,
    // по длительности произношени€? 
    // —тоимость способности, услови€ применени€, восстановление способности



    public ActiveAbility(Entity owner) : base(owner)
    {
    }


}
