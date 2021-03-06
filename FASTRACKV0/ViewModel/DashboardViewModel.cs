﻿using FASTrack.Model.DTO;
using System;

namespace FASTrack.ViewModel
{
    public class DashboardViewModel : BaseDto
    {
        public string fanumber { get; set; }
        public string reference { get; set; }
        public string overall_incharge { get; set; }
        public string status { get; set; }
        public string bu { get; set; }
        public string product { get; set; }
        public DateTime last_update { get; set; }
        public string last_update_by { get; set; }
        public string current_process { get; set; }
        public string comments { get; set; }
        public decimal overall_ct { get; set; }
        public decimal current_process_ct { get; set; }
        public string submission_status { get; set; }
        public int with_initial_report { get; set; }
        public int with_final_report { get; set; }
    }
}