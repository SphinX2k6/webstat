using System;
using System.Runtime.CompilerServices;

// Token: 0x020016FC RID: 5884
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
internal class <WheelTowerSeasonRewardView>F374E42E7655038950DBBBE437EEFD57A3D495E1FD4395DB7A595CC9EA351A727__TaskGridData : MultiTemplateGridDataBase<ActivityTaskData, WheelTowerSeasonTaskItem>
{
	// Token: 0x0600A30A RID: 41738 RVA: 0x002B0C15 File Offset: 0x002AEE15
	public <WheelTowerSeasonRewardView>F374E42E7655038950DBBBE437EEFD57A3D495E1FD4395DB7A595CC9EA351A727__TaskGridData(ActivityTaskData data, Action onClickToGet)
	{
		base.Data = data;
		this.OnClickToGet = onClickToGet;
	}

	// Token: 0x0600A30B RID: 41739 RVA: 0x002B0C2B File Offset: 0x002AEE2B
	public override int GetTemplateIndex()
	{
		return 1;
	}

	// Token: 0x0600A30C RID: 41740 RVA: 0x002B0C2E File Offset: 0x002AEE2E
	public override WheelTowerSeasonTaskItem CreateProxy()
	{
		return new WheelTowerSeasonTaskItem
		{
			OnClickToGet = this.OnClickToGet
		};
	}

	// Token: 0x04004D80 RID: 19840
	private readonly Action OnClickToGet;
}
