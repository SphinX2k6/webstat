using System;
using System.Runtime.CompilerServices;

// Token: 0x020017A0 RID: 6048
public class TipsDataTool
{
	// Token: 0x0600AAAF RID: 43695 RVA: 0x002D951C File Offset: 0x002D771C
	[NullableContext(1)]
	public static CommonComponentDefine.TipsAttributeData GetCommonTipsAttributeData(double propValue, double ratio, bool isRatio, int propId)
	{
		double attributeValue = TipsDataTool.GetAttributeValue(propValue, ratio, isRatio);
		return new CommonComponentDefine.TipsAttributeData(propId, attributeValue, isRatio);
	}

	// Token: 0x0600AAB0 RID: 43696 RVA: 0x002D953C File Offset: 0x002D773C
	public static double GetAttributeValue(double propValue, double ratio, bool isRatio)
	{
		double result;
		if (isRatio)
		{
			result = propValue / 10000.0 * (ratio / 10000.0);
		}
		else
		{
			result = propValue * (ratio / 10000.0);
		}
		return result;
	}

	// Token: 0x0600AAB1 RID: 43697 RVA: 0x002D9580 File Offset: 0x002D7780
	public static double GetPropRatioValue(double propValue, bool isRatio)
	{
		double result;
		if (isRatio)
		{
			result = propValue / 10000.0;
		}
		else
		{
			result = propValue;
		}
		return result;
	}
}
