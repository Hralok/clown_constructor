public class Resource
{
    public int id { get; private set; }
    public int count { get; private set; }
    public int nameId { get; private set; }
    public int descriptionId { get; private set; }

    public Resource(ResourceInitInfo info, int count)
    {
        id = info.id;
        this.count = count;
        nameId = info.nameId;
        descriptionId = info.descriptionId;
    }

    public override bool Equals(object obj)
    {
        return this.Equals(obj as Resource);
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }

    private bool Equals(Resource that)
    {
        if (that == null)
        {
            return false;
        }
        return id == that.id;
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
