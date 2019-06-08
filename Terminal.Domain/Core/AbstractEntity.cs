using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Domain.Core
{
  public abstract class AbstractEntity<TID> : EntityBase
  {
    public TID Id { get; protected set; }

    public override bool Equals(object obj)
    {
      var compareTo = obj as AbstractEntity<TID>;

      if (ReferenceEquals(this, compareTo)) return true;
      if (ReferenceEquals(null, compareTo)) return false;

      return Id.Equals(compareTo.Id);
    }

    public static bool operator == (AbstractEntity<TID> a, AbstractEntity<TID> b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return true;

      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return false;

      return a.Equals(b);
    }

    public static bool operator != (AbstractEntity<TID> a, AbstractEntity<TID> b)
    {
      return !(a == b);
    }

    public override int GetHashCode()
    {
      return (GetType().GetHashCode() * 1134) + Id.GetHashCode();
    }

    public override string ToString()
    {
      return GetType().Name + " [Id=" + Id + "]";
    }
  }
}
