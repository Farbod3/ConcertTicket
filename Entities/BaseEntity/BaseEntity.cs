﻿using System.ComponentModel.DataAnnotations;namespace Entities;public class BaseEntity : BaseEntity<long>{}public class BaseEntity<TKey> : IBaseEntity{    [Key] [Required] public TKey Id { get; set; }}