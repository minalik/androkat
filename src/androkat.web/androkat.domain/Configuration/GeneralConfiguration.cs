﻿using System.ComponentModel.DataAnnotations;

namespace androkat.domain.Configuration;

public class GeneralConfiguration
{
    [Required]
    public string HostUrl { get; set; }
}