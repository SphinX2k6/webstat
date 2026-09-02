using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001341 RID: 4929
[NullableContext(2)]
[Nullable(0)]
public class InviteNewbieActivityItem : UiPanelBase
{
	// Token: 0x060086AA RID: 34474 RVA: 0x00237600 File Offset: 0x00235800
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060086AB RID: 34475 RVA: 0x002376AC File Offset: 0x002358AC
	protected override UniTask OnBeforeStartAsync()
	{
		InviteNewbieActivityItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<InviteNewbieActivityItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060086AC RID: 34476 RVA: 0x002376F0 File Offset: 0x002358F0
	protected override void OnStart()
	{
		Activity value = this.ActivityDataCache.LocalConfig.Value;
		this.TitleComponent.SetActivityBaseData(this.ActivityDataCache);
		this.TitleComponent.SetTitleByText(this.ActivityDataCache.GetTitle());
		this.TitleComponent.SetSubTitleVisible(!StringUtils.IsEmpty(value.DescTheme));
		if (!StringUtils.IsEmpty(value.DescTheme))
		{
			this.TitleComponent.SetSubTitleByTextId(value.DescTheme, Array.Empty<string>());
		}
		this.DescriptionComponent.SetContentVisible(!StringUtils.IsEmpty(value.Desc));
		if (!StringUtils.IsEmpty(value.Desc))
		{
			this.DescriptionComponent.SetContentByTextId(value.Desc, Array.Empty<string>());
		}
		List<TItem> previewReward = this.ActivityDataCache.GetPreviewReward(null);
		this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
		this.RewardListComponent.SetTitleByTextId("Activity_104600001_Reward");
		this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.OnClickEnter));
		this.FunctionalComponent.FunctionButton.SetLocalTextNew("Activity_104600001_GObutton", Array.Empty<object>());
	}

	// Token: 0x060086AD RID: 34477 RVA: 0x00237838 File Offset: 0x00235A38
	private void OnClickEnter()
	{
		InviteNewbieProtocolContext activityData = this.ActivityDataCache as InviteNewbieProtocolContext;
		ControllerBase<ActivityInviteNewbieController>.Instance.HandleOnEnterClick(activityData);
	}

	// Token: 0x060086AE RID: 34478 RVA: 0x0023785C File Offset: 0x00235A5C
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		this.FunctionalComponent.FunctionButton.BindRedDot(ERedDotName.InviteNewbie, 0);
	}

	// Token: 0x060086AF RID: 34479 RVA: 0x0023787A File Offset: 0x00235A7A
	protected override void OnAfterHide()
	{
		base.OnAfterHide();
		this.FunctionalComponent.FunctionButton.UnBindGivenUid(0);
	}

	// Token: 0x060086B0 RID: 34480 RVA: 0x00237893 File Offset: 0x00235A93
	[NullableContext(1)]
	public void RefreshTimerTextByData(bool isShow, string timeText)
	{
		this.TitleComponent.SetTimeTextVisible(isShow);
		if (isShow)
		{
			this.TitleComponent.SetTimeTextByText(timeText);
		}
	}

	// Token: 0x04003F9D RID: 16285
	private ActivityBaseData ActivityDataCache;

	// Token: 0x04003F9E RID: 16286
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04003F9F RID: 16287
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x04003FA0 RID: 16288
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x04003FA1 RID: 16289
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x020076E4 RID: 30436
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04028F26 RID: 167718
		public const int TitleItem = 0;

		// Token: 0x04028F27 RID: 167719
		public const int DescriptionItem = 1;

		// Token: 0x04028F28 RID: 167720
		public const int RewardListItem = 2;

		// Token: 0x04028F29 RID: 167721
		public const int FunctionalItem = 3;
	}
}
