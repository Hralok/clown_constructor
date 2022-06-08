public class Resource
{
    public ResourceTypeEnum type { get; private set; }
    public int count { get; private set; }

    public Resource(ResourceTypeEnum type, int count)
    {
        this.type = type;
        this.count = count;
    }

    public override bool Equals(object obj)
    {
        return this.Equals(obj as Resource);
    }

    public override int GetHashCode()
    {
        return type.GetHashCode();
    }

    private bool Equals(Resource that)
    {
        if (that == null)
        {
            return false;
        }
        return type == that.type;
    }

    public bool TakeResource(int takeCount)
    {
        if (count >= takeCount)
        {
            count -= takeCount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PutResource(int putCount)
    {
        if (putCount > 0)
        {
            count += putCount;
        }
        else
        {
            throw new System.Exception("Невозможно добавить отрицательное количество ресурсов!");
        }
    }
}
