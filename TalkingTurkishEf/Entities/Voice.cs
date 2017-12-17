using System;

namespace TalkingTurkishEf.Entities
{
    public class Voice
    {
    
        public Guid VoiceId { get; set; }
        public Language Languange { get; set; }
        public byte[] Content { get; set; }
    }
}