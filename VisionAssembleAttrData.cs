using System;
using Aki.Config;

// Token: 0x0200249D RID: 9373
public class VisionAssembleAttrData
{
	// Token: 0x060122FA RID: 74490 RVA: 0x00500CAC File Offset: 0x004FEEAC
	public int GetPriority()
	{
		int[] visionAttrSortArray = ConfigBase<PhantomBattleConfig>.Instance.GetVisionAttrSortArray();
		int num = -1;
		for (int i = 0; i < visionAttrSortArray.Length; i++)
		{
			if (visionAttrSortArray[i] == this.AttrId)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			return 0;
		}
		return 999 - num;
	}

	// Token: 0x060122FB RID: 74491 RVA: 0x00500CF0 File Offset: 0x004FEEF0
	public int GetId()
	{
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(this.AttrId);
		if (propertyIndexInfo == null)
		{
			return 0;
		}
		return propertyIndexInfo.Value.Id;
	}

	// Token: 0x04008DEE RID: 36334
	public bool CompareMode;

	// Token: 0x04008DEF RID: 36335
	public int AttrId;

	// Token: 0x04008DF0 RID: 36336
	public bool IfPercentage;

	// Token: 0x04008DF1 RID: 36337
	public int CurrentValue;

	// Token: 0x04008DF2 RID: 36338
	public int CompareValue;

	// Token: 0x04008DF3 RID: 36339
	public bool IsHighLight;
}
