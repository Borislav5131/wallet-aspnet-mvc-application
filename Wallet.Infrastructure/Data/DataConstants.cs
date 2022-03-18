﻿namespace Wallet.Infrastructure.Data
{
    public class DataConstants
    {
        public const double UserBalanceMaxValue = double.MaxValue;
        public const double UserBalanceMinValue = 0;

        public const int AssetMaxNameLenght = 30;
        public const int AssetMinNameLenght = 3;
        public const int AssetMaxAbbreviationLenght = 10;
        public const int AssetMinAbbreviationLenght = 2;
        public const double AssetMaxValue = 100000;
        public const double AssetMinValue = 1;
        public const double AssetMaxAmount = 100000;
        public const double AssetMinAmount = 1;
        public const int AssetMaxLogoSize = 2 * 1024 * 1024;

        public const int CategoryMaxNameLenght = 30;
        public const int CategoryMinNameLenght = 3;
        public const int CategoryDescriptionMaxLenght = 500;
        public const int CategoryDescriptionMinLenght = 0;

        public const double WalletTotalAmountMaxValue = double.MaxValue;
        public const double WalletTotalAmountMinValue = 0;
    }
}
