using System;
using System.Runtime.CompilerServices;

// Token: 0x020016FB RID: 5883
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class <WheelTowerSeasonRewardView>F374E42E7655038950DBBBE437EEFD57A3D495E1FD4395DB7A595CC9EA351A727__CategoryGridData : MultiTemplateGridDataBase<ETaskCategory, WheelTowerSeasonTaskCategoryItem>
{
	// Token: 0x0600A307 RID: 41735 RVA: 0x002B0BFC File Offset: 0x002AEDFC
	public <WheelTowerSeasonRewardView>F374E42E7655038950DBBBE437EEFD57A3D495E1FD4395DB7A595CC9EA351A727__CategoryGridData(ETaskCategory data)
	{
		base.Data = data;
	}

	// Token: 0x0600A308 RID: 41736 RVA: 0x002B0C0B File Offset: 0x002AEE0B
	public override int GetTemplateIndex()
	{
		return 0;
	}

	// Token: 0x0600A309 RID: 41737 RVA: 0x002B0C0E File Offset: 0x002AEE0E
	public override WheelTowerSeasonTaskCategoryItem CreateProxy()
	{
		return new WheelTowerSeasonTaskCategoryItem();
	}
}
