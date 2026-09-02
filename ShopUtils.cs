using System;
using System.Runtime.CompilerServices;

// Token: 0x020029FC RID: 10748
public class ShopUtils
{
	// Token: 0x06015705 RID: 87813 RVA: 0x005F0680 File Offset: 0x005EE880
	public static int GetResource(int id)
	{
		if (id == 1)
		{
			int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.Experience);
			if (numberPropById == null)
			{
				return 0;
			}
			return numberPropById.Value;
		}
		else if (id == 2)
		{
			int? numberPropById2 = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.MoneyGold);
			if (numberPropById2 == null)
			{
				return 0;
			}
			return numberPropById2.Value;
		}
		else
		{
			if (id != 3)
			{
				return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(id, 0);
			}
			int? numberPropById3 = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.MoneyDiamond);
			if (numberPropById3 == null)
			{
				return 0;
			}
			return numberPropById3.Value;
		}
	}

	// Token: 0x06015706 RID: 87814 RVA: 0x005F0704 File Offset: 0x005EE904
	[NullableContext(1)]
	public static string FormatTime(int seconds)
	{
		int num = seconds / 86400;
		int num2 = seconds % 86400 / 3600;
		int num3 = seconds % 3600 / 60;
		int num4 = seconds % 60;
		if (num > 0)
		{
			return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("ShopTimeStr1"), new string[]
			{
				num.ToString(),
				num2.ToString()
			});
		}
		if (num2 > 0)
		{
			return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("ShopTimeStr2"), new string[]
			{
				num2.ToString(),
				num3.ToString()
			});
		}
		if (num3 > 0)
		{
			return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("ShopTimeStr3"), new string[]
			{
				num3.ToString()
			});
		}
		return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("ShopTimeStr4"), new string[]
		{
			num4.ToString()
		});
	}

	// Token: 0x0400A4F8 RID: 42232
	private const int EXP_ID = 1;

	// Token: 0x0400A4F9 RID: 42233
	private const int GOLD_ID = 2;

	// Token: 0x0400A4FA RID: 42234
	private const int DIAMOND_ID = 3;
}
