using System;
using System.Collections.Generic;

namespace TalkingTurkishEf.Entities
{
    public class Thing:BaseEntity
    {
 

        public string PictureName { get; set; }

        public byte[] Content { get; set; }

        public Voice Voice { get; set; }

        public string Text { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(PictureName)}: {PictureName}, {nameof(Content)}: {Content}, {nameof(Text)}: {Text}";
        }

        private sealed class ThingEqualityComparer : IEqualityComparer<Thing>
        {
            public bool Equals(Thing x, Thing y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id) && string.Equals(x.PictureName, y.PictureName) && x.Content == y.Content && Equals(x.Voice, y.Voice) && string.Equals(x.Text, y.Text);
            }

            public int GetHashCode(Thing obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.PictureName != null ? obj.PictureName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Content.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Voice != null ? obj.Voice.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Text != null ? obj.Text.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<Thing> ThingComparer { get; } = new ThingEqualityComparer();
    }
}
