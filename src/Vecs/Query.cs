using System;
using System.Collections.Generic;

namespace Vecs
{
    public struct Query
    {
        private HashSet<Type> withComponents;
        private HashSet<Type> withoutComponents;
        public HashSet<Type> WithComponents {get {return withComponents;}}
        public HashSet<Type> WithoutComponents {get {return withoutComponents;}}
        public Query()
        {
            this.withComponents = new HashSet<Type>();
            this.withoutComponents = new HashSet<Type>();
        }
        public void Clear()
        {
            withComponents = new HashSet<Type>();
            withoutComponents = new HashSet<Type>();
        }
        public Query With(params Type[] components)
        {
            WithComponents.UnionWith(components);
            return this;
        }
        public Query Without(params Type[] components)
        {
            WithoutComponents.UnionWith(components);
            return this;
        }
    }
}