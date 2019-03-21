using System;
using System.Collections.Generic;
using System.Text;

namespace playground
{
    class FunTupling
    {
        public static (string Relation, bool IsNew) GetComponentRelationship()
        {
            var foo = new { RelationshipType = "Parent", IsExisting = true };
            var t =  (foo.RelationshipType, foo.IsExisting);

            return (t.RelationshipType, t.IsExisting);
        }
    }
}
