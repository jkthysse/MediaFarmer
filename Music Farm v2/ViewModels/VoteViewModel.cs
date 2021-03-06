﻿using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaFarmer.ViewModels
{
    public class VoteViewModel
    {
        public int VoteId { get; set; }
        [Required(ErrorMessage ="A User is not linked to this vote")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please select your vote")]
        [DisplayName("Vote")]
        public bool VoteValue { get; set; }
        public int PlayHistoryId { get; set; }
        public PlayHistory PlayHistory { get; set; }
        public User User { get; set; }
    }
}