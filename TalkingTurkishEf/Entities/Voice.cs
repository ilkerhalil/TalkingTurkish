using System;

namespace TalkingTurkishEf.Entities
{
    public class Voice:BaseEntity
    {
    
        public Language Languange { get; set; }
        public byte[] Content { get; set; }
    }
}