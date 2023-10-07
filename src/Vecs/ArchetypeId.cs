namespace Vecs
{
    public struct ArchetypeId : IEquatable<ArchetypeId>
    {
        public SortedSet<Type> Types {get;}
        public int Count {get => Types.Count;}
        public ArchetypeId(in Type[] types)
        {
            this.Types = new SortedSet<Type>(types, new TypeComparer());
        }
        public ArchetypeId(in Type[] types, in Type type)
        {
            Type[] joinedArray = new Type[types.Length+1];
            Array.Copy(types, joinedArray, types.Length);
            joinedArray[joinedArray.Length-1] = type;
            this.Types = new SortedSet<Type>(joinedArray, new TypeComparer());
        }
        public bool Contains(Type type)
        {
            return Types.Contains(type);
        }
        public Type[] GetTypes()
        {
            return Types.ToArray();
        }

        public bool Equals(ArchetypeId other)
        {
            if (Types.Count != other.Types.Count)
            {
                return false;
            }
            for (int i = 0; i < Types.Count; i++)
            {
                if (Types.ElementAt(i).Equals(other.Types.ElementAt(i)) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class TypeComparer : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }

    class ArchetypeIdComparer : IEqualityComparer<ArchetypeId>
    {
        public bool Equals(ArchetypeId x, ArchetypeId y)
        {
            if (x.Types.Count != y.Types.Count)
            {
                return false;
            }
            for (int i = 0; i < x.Types.Count; i++)
            {
                if (x.Types.ElementAt(i).Equals(y.Types.ElementAt(i)) == false)
                {
                    return false;
                }
            }
            return true;
        }
        public int GetHashCode(ArchetypeId obj)
        {
            int hash = obj.Types.Count;
            for (int i = 0; i < obj.Types.Count; i++)
            {
                HashCode.Combine(hash, obj.Types.ElementAt(i));
            }
            return hash;
        }
    }
}