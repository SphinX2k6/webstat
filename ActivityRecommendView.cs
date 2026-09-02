using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001156 RID: 4438
[NullableContext(2)]
[Nullable(0)]
public class ActivityRecommendView : UiViewBase
{
	// Token: 0x060074EE RID: 29934 RVA: 0x001EB660 File Offset: 0x001E9860
	[NullableContext(1)]
	public ActivityRecommendView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060074EF RID: 29935 RVA: 0x001EB66C File Offset: 0x001E986C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x060074F0 RID: 29936 RVA: 0x001EB6DC File Offset: 0x001E98DC
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRecommendView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRecommendView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060074F1 RID: 29937 RVA: 0x001EB720 File Offset: 0x001E9920
	protected override void OnStart()
	{
		base.OnStart();
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnBackButtonClick));
		this.RecommendItemScrollView = new GenericLayout<ActivityRecommendItem, int>(base.GetVerticalLayout(2), new Func<ActivityRecommendItem>(this.InitItem), null, false, true);
	}

	// Token: 0x060074F2 RID: 29938 RVA: 0x001EB780 File Offset: 0x001E9980
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		if (this.Vm == null)
		{
			return;
		}
		ActivityRecommendItem mainQuestItem = this.MainQuestItem;
		if (mainQuestItem != null)
		{
			mainQuestItem.Refresh(this.Vm.GetMainQuestItemId(), false, 0);
		}
		List<int> recommendIdList = this.Vm.GetRecommendIdList();
		GenericLayout<ActivityRecommendItem, int> recommendItemScrollView = this.RecommendItemScrollView;
		if (recommendItemScrollView != null)
		{
			recommendItemScrollView.RefreshByData(recommendIdList, null, true);
		}
		bool uiactive = this.Vm.IsMainQuestAvailable();
		base.GetItem(3).SetUIActive(uiactive);
	}

	// Token: 0x060074F3 RID: 29939 RVA: 0x001EB7F3 File Offset: 0x001E99F3
	protected override void OnBeforeDestroy()
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.Destroy(null);
		}
		this.CaptionItem = null;
	}

	// Token: 0x060074F4 RID: 29940 RVA: 0x001EB80E File Offset: 0x001E9A0E
	[NullableContext(1)]
	private ActivityRecommendItem InitItem()
	{
		ActivityRecommendItem activityRecommendItem = new ActivityRecommendItem();
		activityRecommendItem.SetViewModel(this.Vm);
		return activityRecommendItem;
	}

	// Token: 0x060074F5 RID: 29941 RVA: 0x001EB821 File Offset: 0x001E9A21
	private void OnBackButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400388F RID: 14479
	private ActivityRecommendViewModel Vm;

	// Token: 0x04003890 RID: 14480
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003891 RID: 14481
	private ActivityRecommendItem MainQuestItem;

	// Token: 0x04003892 RID: 14482
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<ActivityRecommendItem, int> RecommendItemScrollView;
}
