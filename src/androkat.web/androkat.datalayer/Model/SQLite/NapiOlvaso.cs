﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace androkat.datalayer.Model.SQLite;

[Table("napiolvaso")]
public class Napiolvaso
{
    [Key]
    [Required]
    [DataMember(Name = "nid")]
    public Guid Nid { get; set; }

    [StringLength(100)]
    [DataMember(Name = "fulldatum")]
    public string Fulldatum { get; set; }

    [DataMember(Name = "cim")]
    public string Cim { get; set; }
}