using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public HashSet<Entity> entities { get; private set; }
    public HashSet<Resource> resources { get; private set; }
    public HashSet<Player> enemies { get; private set; }
    public HashSet<Player> allies { get; private set; }

    public Player()
    {
        entities = new HashSet<Entity>();
        resources = new HashSet<Resource>();
        enemies = new HashSet<Player>();
        allies = new HashSet<Player>();
    }

    public bool CheckForWin()
    {
        return false;
    }

    public bool CheckForDefeat()
    {
        bool defeated = false;

        if (entities.Count == 0)
        {
            defeated = true;
        }

        return defeated;
    }

    public bool RemoveFromEnemies(Player player)
    {
        return enemies.Remove(player);
    }

    public bool RemoveFromAllies(Player player)
    {
        return allies.Remove(player);
    }

    public bool AddToEnemies(Player player)
    {
        if (allies.Contains(player))
        {
            return false;
        }
        else
        {
            return enemies.Add(player);
        }
    }

    public bool AddToAllies(Player player)
    {
        if (enemies.Contains(player))
        {
            return false;
        }
        else
        {
            return allies.Add(player);
        }
    }

    public bool MovePlayerToOppositeGroup(Player player)
    {
        if (allies.Contains(player))
        {
            return enemies.Add(player) && allies.Remove(player);
        }

        if (enemies.Contains(player))
        {
            return allies.Add(player) && enemies.Remove(player);
        }

        return false;
    }

    public void AddResources(HashSet<Resource> newResources)
    {
        foreach (var resource in newResources)
        {
            if (!resources.Contains(resource))
            {
                if (Fabricator.allowedResources.Contains(resource.type))
                {
                    resources.Add(resource);
                }
                else
                {
                    throw new System.Exception("Произведена попытка добавить игроку неразрешённый тип ресурса");
                }
            }
            else
            {
                foreach (var j in newResources)
                {
                    if (j.type == resource.type)
                    {
                        j.PutResource(resource.count);
                    }
                }
            }
        }
    }

    public bool AddEntity(Entity entity)
    {
        if (entities.Add(entity))
        {
            entity.SetNewPlayer(this);
            return true;
        }
        else
        {
            return false;
        }

    }



}
