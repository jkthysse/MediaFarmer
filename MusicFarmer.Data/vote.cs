//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicFarmer.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vote
    {
        public int VoteId { get; set; }
        public bool VoteValue { get; set; }
        public int UserId { get; set; }
        public int PlayHistoryId { get; set; }
    
        public virtual PlayHistory PlayHistory { get; set; }
        public virtual User User { get; set; }
    }
}
