using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001565 RID: 5477
public class ActivityRegressRoleCultivateSubView : ActivityRegressTaskSubViewBase
{
	// Token: 0x060099BA RID: 39354 RVA: 0x00283F68 File Offset: 0x00282168
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x060099BB RID: 39355 RVA: 0x00283FCD File Offset: 0x002821CD
	protected override void OnStart()
	{
		this.LoopScrollView = new LoopScrollView<ActivityRegressCultivateTaskSubViewLoopItem, IActivityRegressRoleCultivateSubViewLoopData>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<ActivityRegressCultivateTaskSubViewLoopItem>(this.CreateLoopItem), false);
	}

	// Token: 0x060099BC RID: 39356 RVA: 0x00283FFF File Offset: 0x002821FF
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x060099BD RID: 39357 RVA: 0x00284007 File Offset: 0x00282207
	protected override void OnUpdate()
	{
		this.RefreshView();
	}

	// Token: 0x060099BE RID: 39358 RVA: 0x00284010 File Offset: 0x00282210
	private void RefreshView()
	{
		List<IActivityRegressRoleCultivateSubViewLoopData> regressCultivateLoopSvDataList = ModelBase<ActivityRegressModel>.Instance.GetRegressCultivateLoopSvDataList();
		this.LoopScrollView.RefreshByData(regressCultivateLoopSvDataList, false, null, true);
		int value = ModelBase<ActivityRegressModel>.Instance.CalculateRegressCultivateReachTaskCount(regressCultivateLoopSvDataList);
		LguiUtil instance = Singleton<LguiUtil>.Instance;
		UUIText text = base.GetText(0);
		string textStringId = "PrefabTextItem_4217661232_Text";
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(regressCultivateLoopSvDataList.Count);
		instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
	}

	// Token: 0x060099BF RID: 39359 RVA: 0x0028408F File Offset: 0x0028228F
	protected override void OnBeforeDestroy()
	{
		LoopScrollView<ActivityRegressCultivateTaskSubViewLoopItem, IActivityRegressRoleCultivateSubViewLoopData> loopScrollView = this.LoopScrollView;
		if (loopScrollView == null)
		{
			return;
		}
		loopScrollView.ClearGridProxies();
	}

	// Token: 0x060099C0 RID: 39360 RVA: 0x002840A1 File Offset: 0x002822A1
	[NullableContext(1)]
	private ActivityRegressCultivateTaskSubViewLoopItem CreateLoopItem()
	{
		return new ActivityRegressCultivateTaskSubViewLoopItem();
	}

	// Token: 0x040046F7 RID: 18167
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<ActivityRegressCultivateTaskSubViewLoopItem, IActivityRegressRoleCultivateSubViewLoopData> LoopScrollView;

	// Token: 0x0200792B RID: 31019
	private class EActivityRegressRoleCultivateSubViewComponents
	{
		// Token: 0x04029A26 RID: 170534
		public const int TxtNum = 0;

		// Token: 0x04029A27 RID: 170535
		public const int SVLoop = 1;

		// Token: 0x04029A28 RID: 170536
		public const int MissionItem = 2;
	}
}
