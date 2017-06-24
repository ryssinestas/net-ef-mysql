using System;

namespace Project.Domain.Entities
{
    public abstract class BaseEntity<TId>
    {
        public virtual TId Id { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity<TId>);
        }

        public virtual bool Equals(BaseEntity<TId> other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;

            if (!IsTransient(this) && !IsTransient(other) && Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        private static bool IsTransient(BaseEntity<TId> obj)
        {
            return obj != null && Equals(obj.Id, default(TId));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        private int? _hashCode;

        public override int GetHashCode()
        {
            if (_hashCode.HasValue)
            {
                return _hashCode.Value;
            }

            bool isTransient = Equals(Id, default(TId));

            if (isTransient)
            {
                _hashCode = base.GetHashCode();
                return _hashCode.Value;
            }

            return Id.GetHashCode();
        }
    }
}
