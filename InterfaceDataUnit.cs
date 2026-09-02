using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Reward;

// Token: 0x02002055 RID: 8277
public class InterfaceDataUnit
{
	// Token: 0x0600FC28 RID: 64552 RVA: 0x004548BF File Offset: 0x00452ABF
	public InterfaceDataUnit(int index)
	{
		this.Index = index;
	}

	// Token: 0x0600FC29 RID: 64553 RVA: 0x004548DC File Offset: 0x00452ADC
	public int GetMaxCount()
	{
		int result = 1;
		if (this.Mode == EPlayMode.Low)
		{
			result = ConfigBase<RewardConfig>.Instance.GetLowModeCount();
		}
		else if (this.Mode == EPlayMode.Fast)
		{
			result = ConfigBase<RewardConfig>.Instance.GetFastModeCount();
		}
		return result;
	}

	// Token: 0x0600FC2A RID: 64554 RVA: 0x00454918 File Offset: 0x00452B18
	public int GetAddItemTime()
	{
		int result = 0;
		if (this.Mode == EPlayMode.Low)
		{
			result = ConfigBase<RewardConfig>.Instance.GetLowModeNextAddItemTime();
		}
		else if (this.Mode == EPlayMode.Fast)
		{
			result = ConfigBase<RewardConfig>.Instance.GetFastModeNextAddItemTime();
		}
		return result;
	}

	// Token: 0x04007904 RID: 30980
	public int Index;

	// Token: 0x04007905 RID: 30981
	public EPlayMode Mode;

	// Token: 0x04007906 RID: 30982
	[Nullable(1)]
	public List<ItemRewardInfo> WaitList = new List<ItemRewardInfo>();
}
