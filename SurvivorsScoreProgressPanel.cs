using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B2A RID: 11050
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsScoreProgressPanel : UiPanelBase
{
	// Token: 0x060160E5 RID: 90341 RVA: 0x0061EEA4 File Offset: 0x0061D0A4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite))
		};
	}

	// Token: 0x060160E6 RID: 90342 RVA: 0x0061EF2A File Offset: 0x0061D12A
	protected override void OnStart()
	{
		this.ProgressLayout = new GenericLayout<SurvivorsScoreProgressItem, SurvivorsMilestoneData>(base.GetHorizontalLayout(1), new Func<SurvivorsScoreProgressItem>(this.ProgressItemProxyCreate), null, false, true);
		this.ProgressBarWidth = base.GetSprite(4).GetWidth();
	}

	// Token: 0x060160E7 RID: 90343 RVA: 0x0061EF5F File Offset: 0x0061D15F
	private SurvivorsScoreProgressItem ProgressItemProxyCreate()
	{
		return new SurvivorsScoreProgressItem
		{
			OnClickToGet = this.OnClickToGet
		};
	}

	// Token: 0x060160E8 RID: 90344 RVA: 0x0061EF74 File Offset: 0x0061D174
	public UniTask RefreshProgressItem(int currentProgress, IReadOnlyList<SurvivorsMilestoneData> dataList)
	{
		SurvivorsScoreProgressPanel.<RefreshProgressItem>d__7 <RefreshProgressItem>d__;
		<RefreshProgressItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshProgressItem>d__.<>4__this = this;
		<RefreshProgressItem>d__.currentProgress = currentProgress;
		<RefreshProgressItem>d__.dataList = dataList;
		<RefreshProgressItem>d__.<>1__state = -1;
		<RefreshProgressItem>d__.<>t__builder.Start<SurvivorsScoreProgressPanel.<RefreshProgressItem>d__7>(ref <RefreshProgressItem>d__);
		return <RefreshProgressItem>d__.<>t__builder.Task;
	}

	// Token: 0x0400A9BE RID: 43454
	protected GenericLayout<SurvivorsScoreProgressItem, SurvivorsMilestoneData> ProgressLayout;

	// Token: 0x0400A9BF RID: 43455
	protected float ProgressBarWidth;

	// Token: 0x0400A9C0 RID: 43456
	[Nullable(2)]
	public Action OnClickToGet;

	// Token: 0x0400A9C1 RID: 43457
	private const float REWARD_ITEM_WIDTH = 108f;
}
