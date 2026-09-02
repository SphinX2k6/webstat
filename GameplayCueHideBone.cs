using System;
using UnrealEngine;

// Token: 0x02002FA8 RID: 12200
public class GameplayCueHideBone : GameplayCueBase
{
	// Token: 0x06018E17 RID: 101911 RVA: 0x0070C333 File Offset: 0x0070A533
	protected override void OnCreate()
	{
		this.HideBone(true);
	}

	// Token: 0x06018E18 RID: 101912 RVA: 0x0070C33C File Offset: 0x0070A53C
	protected override void OnDestroy()
	{
		this.HideBone(false);
	}

	// Token: 0x06018E19 RID: 101913 RVA: 0x0070C348 File Offset: 0x0070A548
	private void HideBone(bool bStart)
	{
		FName value = FNameUtil.GetDynamicFName(this.CueConfig.Parameters(0)).Value;
		bool flag = ((this.CueConfig.ParametersLength > 1) ? this.CueConfig.Parameters(1) : "1") == "1";
		if (!bStart)
		{
			flag = !flag;
		}
		if (this.ActorInternal.Mesh.IsBoneHiddenByName(value) == flag)
		{
			return;
		}
		if (flag)
		{
			int num;
			EPhysBodyOp physBodyOption = (EPhysBodyOp)((this.CueConfig.ParametersLength > 1 && int.TryParse(this.CueConfig.Parameters(1), out num)) ? num : 0);
			this.ActorInternal.Mesh.HideBoneByName(value, physBodyOption);
			return;
		}
		this.ActorInternal.Mesh.UnHideBoneByName(value);
	}
}
