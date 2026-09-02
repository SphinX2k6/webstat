using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020014F1 RID: 5361
public class ActivityRegressRecommendView : ActivityRegressMainSubViewBase
{
	// Token: 0x060095FE RID: 38398 RVA: 0x00272574 File Offset: 0x00270774
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout))
		};
	}

	// Token: 0x060095FF RID: 38399 RVA: 0x002725B0 File Offset: 0x002707B0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressRecommendView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressRecommendView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009600 RID: 38400 RVA: 0x002725F3 File Offset: 0x002707F3
	protected override void OnStart()
	{
		base.OnStart();
		this.RecommendItemScrollView = new GenericLayout<ActivityRegressRecommendItem, int>(base.GetVerticalLayout(1), new Func<ActivityRegressRecommendItem>(this.InitItem), null, false, true);
	}

	// Token: 0x06009601 RID: 38401 RVA: 0x0027261C File Offset: 0x0027081C
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		List<int> recommendDataList = ModelBase<ActivityRegressModel>.Instance.GetRecommendDataList();
		this.RecommendItemScrollView.RefreshByData(recommendDataList, null, true);
	}

	// Token: 0x06009602 RID: 38402 RVA: 0x00272648 File Offset: 0x00270848
	[NullableContext(1)]
	private ActivityRegressRecommendItem InitItem()
	{
		return new ActivityRegressRecommendItem();
	}

	// Token: 0x04004571 RID: 17777
	private const int MAIN_QUEST_ITEM_ID = 1;

	// Token: 0x04004572 RID: 17778
	[Nullable(2)]
	private ActivityRegressRecommendItem MainQuestItem;

	// Token: 0x04004573 RID: 17779
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<ActivityRegressRecommendItem, int> RecommendItemScrollView;

	// Token: 0x020078AB RID: 30891
	private class EComponents
	{
		// Token: 0x040297B8 RID: 169912
		public const int MainQuestItem = 0;

		// Token: 0x040297B9 RID: 169913
		public const int RecommendItemLayout = 1;
	}
}
