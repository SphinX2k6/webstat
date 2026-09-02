using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025C5 RID: 9669
public class FightPhotoMissionPanel : FightPhotoTabPanelBase
{
	// Token: 0x06012E65 RID: 77413 RVA: 0x0053A5B5 File Offset: 0x005387B5
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06012E66 RID: 77414 RVA: 0x0053A5F0 File Offset: 0x005387F0
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotoMissionPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotoMissionPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012E67 RID: 77415 RVA: 0x0053A634 File Offset: 0x00538834
	public UniTask RefreshCondition()
	{
		FightPhotoMissionPanel.<RefreshCondition>d__4 <RefreshCondition>d__;
		<RefreshCondition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCondition>d__.<>4__this = this;
		<RefreshCondition>d__.<>1__state = -1;
		<RefreshCondition>d__.<>t__builder.Start<FightPhotoMissionPanel.<RefreshCondition>d__4>(ref <RefreshCondition>d__);
		return <RefreshCondition>d__.<>t__builder.Task;
	}

	// Token: 0x06012E68 RID: 77416 RVA: 0x0053A677 File Offset: 0x00538877
	[NullableContext(1)]
	private FightPhotoConditionItem CreateConditionItem()
	{
		return new FightPhotoConditionItem();
	}

	// Token: 0x040093A9 RID: 37801
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<FightPhotoConditionItem, FightPhotoConditionData> ConditionLayout;

	// Token: 0x02008928 RID: 35112
	private enum EComponents
	{
		// Token: 0x0402E478 RID: 189560
		LayoutCondition,
		// Token: 0x0402E479 RID: 189561
		ItemCondition
	}
}
