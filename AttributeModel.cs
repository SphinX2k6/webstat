using System;
using System.Runtime.CompilerServices;

// Token: 0x0200179F RID: 6047
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class AttributeModel : ModelBase<AttributeModel>
{
	// Token: 0x0600AAAC RID: 43692 RVA: 0x002D9430 File Offset: 0x002D7630
	public string GetFormatAttributeValueString(int id, double value, bool isRatio = false)
	{
		if (ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(id).Value.IsPercent)
		{
			int num = 100;
			return Singleton<MathUtils>.Instance.GetFloatPointFloorString(value / (double)num, 1) + "%";
		}
		if (isRatio)
		{
			int num2 = 100;
			return Singleton<MathUtils>.Instance.GetFloatPointFloorString(value * (double)num2, 1) + "%";
		}
		return Math.Floor(value).ToString();
	}

	// Token: 0x0600AAAD RID: 43693 RVA: 0x002D94AC File Offset: 0x002D76AC
	public string GetFormatAttributeValueByAddType(double value, int addType)
	{
		if (addType == 1)
		{
			return TipsDataTool.GetPropRatioValue(value, false).ToString() ?? "";
		}
		if (addType == 2)
		{
			return TipsDataTool.GetPropRatioValue(value, true).ToString() + "%";
		}
		if (addType == 3)
		{
			return value.ToString() + "s";
		}
		return value.ToString();
	}
}
