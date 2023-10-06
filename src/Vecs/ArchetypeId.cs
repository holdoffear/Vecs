namespace Vecs
{
    public struct ArchetypeId
    {
        private SortedSet<Type> types;
        public SortedSet<Type> Types {get => types;}
        public int Count {get => types.Count;}
        public ArchetypeId(in Type[] types)
        {
            this.types = new SortedSet<Type>(types, new TypeComparer());
        }
        public bool Contains(Type type)
        {
            throw new NotImplementedException();
        }
        public Type[] GetTypes()
        {
            throw new NotImplementedException();
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