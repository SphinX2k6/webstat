using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020018A9 RID: 6313
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RewardPanelItem : GridProxyAbstract<DailyActivityDefine.RewardTuple>
{
	// Token: 0x0600B55D RID: 46429 RVA: 0x003047EB File Offset: 0x003029EB
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600B55E RID: 46430 RVA: 0x00304810 File Offset: 0x00302A10
	protected override void OnStart()
	{
		AActor owner = base.GetItem(0).GetOwner();
		this.Grid = new CommonItemSmallItemGrid();
		this.Grid.Initialize(owner);
	}

	// Token: 0x0600B55F RID: 46431 RVA: 0x00304844 File Offset: 0x00302A44
	[NullableContext(1)]
	public override void Refresh(DailyActivityDefine.RewardTuple data, bool isSelected, int gridIndex)
	{
		this.RewardData = data;
		this.Grid.RefreshByConfigId(this.RewardData.Id, new int?(this.RewardData.Num), null, this.RewardData.Received, this.RewardData.IsDoubleRewardVisible);
	}

	// Token: 0x0600B560 RID: 46432 RVA: 0x00304895 File Offset: 0x00302A95
	protected override void OnBeforeDestroy()
	{
		this.RewardData = null;
	}

	// Token: 0x040055A0 RID: 21920
	private DailyActivityDefine.RewardTuple RewardData;

	// Token: 0x040055A1 RID: 21921
	private CommonItemSmallItemGrid Grid;

	// Token: 0x02007C34 RID: 31796
	[NullableContext(0)]
	private enum EItemComponent
	{
		// Token: 0x0402A6BE RID: 173758
		ButtonItem
	}
}
