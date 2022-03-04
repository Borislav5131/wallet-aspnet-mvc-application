﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Wallet.Data.DataConstants;

namespace Wallet.Data.Models
{
    public class Asset
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(AssetMaxNameLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(AssetMaxAbbreviationLenght)]
        public string Abbreviation { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; init; }

        [Required]
        [Range(AssetMinValue,AssetMaxValue)]
        public decimal Value { get; set; }
        
        [Required]
        [Range(AssetMinAmount,AssetMaxAmount)]
        public decimal Amount { get; set; }

        //public FileStream Logo { get; set; }
    }
}
