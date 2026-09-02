using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200126A RID: 4714
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewBlackCoast : ActivitySubViewBase
{
	// Token: 0x06007DBC RID: 32188 RVA: 0x00212A89 File Offset: 0x00210C89
	protected override void OnSetData()
	{
		this.ActivityData = (ActivityBlackCoastData)this.ActivityBaseData;
	}

	// Token: 0x06007DBD RID: 32189 RVA: 0x00212A9C File Offset: 0x00210C9C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007DBE RID: 32190 RVA: 0x00212BAC File Offset: 0x00210DAC
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewBlackCoast.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewBlackCoast.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007DBF RID: 32191 RVA: 0x00212BF0 File Offset: 0x00210DF0
	protected override void OnStart()
	{
		Activity? localConfig = this.ActivityData.LocalConfig;
		this.TitleComponent.SetActivityBaseData(this.ActivityData);
		this.TitleComponent.SetTitleByText(this.ActivityData.GetTitle());
		this.TitleComponent.SetSubTitleVisible(!StringUtils.IsEmpty((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null));
		if (((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null) != null)
		{
			this.TitleComponent.SetSubTitleByTextId(localConfig.Value.DescTheme, Array.Empty<string>());
		}
		this.DescriptionComponent.SetContentVisible(!StringUtils.IsEmpty((localConfig != null) ? localConfig.GetValueOrDefault().Desc : null));
		if (((localConfig != null) ? localConfig.GetValueOrDefault().Desc : null) != null)
		{
			this.DescriptionComponent.SetContentByTextId(localConfig.Value.Desc, Array.Empty<string>());
		}
		UUITexture textureIcon = base.GetTexture(6);
		textureIcon.SetUIActive(false);
		base.SetItemIcon(textureIcon, this.ActivityData.GetProgressItemId, null, delegate(bool _)
		{
			textureIcon.SetUIActive(true);
		});
		List<TItem> previewReward = this.ActivityData.GetPreviewReward(null);
		this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
		this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.ButtonFunction));
		this.OnRefreshView();
	}

	// Token: 0x06007DC0 RID: 32192 RVA: 0x00212DB1 File Offset: 0x00210FB1
	protected override void OnRefreshView()
	{
		this.RefreshCount();
		this.RefreshState();
		this.RefreshRedDot();
	}

	// Token: 0x06007DC1 RID: 32193 RVA: 0x00212DC5 File Offset: 0x00210FC5
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06007DC2 RID: 32194 RVA: 0x00212DD0 File Offset: 0x00210FD0
	private void RefreshTimerText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x06007DC3 RID: 32195 RVA: 0x00212E10 File Offset: 0x00211010
	private void RefreshCount()
	{
		base.GetText(4).SetText(this.ActivityData.GetProgressItemCount().ToString() + "/", true);
		base.GetText(5).SetText(this.ActivityData.GetProgressItemTotal().ToString(), true);
	}

	// Token: 0x06007DC4 RID: 32196 RVA: 0x00212E68 File Offset: 0x00211068
	private void RefreshState()
	{
		bool flag = this.ActivityData.IsUnLock();
		this.FunctionalComponent.SetPanelConditionVisible(!flag);
		if (!flag)
		{
			this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityData.ConditionGroupId, this.ActivityData.Id);
		}
		this.FunctionalComponent.FunctionButton.SetActive(flag);
	}

	// Token: 0x06007DC5 RID: 32197 RVA: 0x00212EC8 File Offset: 0x002110C8
	private void RefreshRedDot()
	{
		bool functionRedDotVisible = this.ActivityData.RewardRedDotState();
		this.FunctionalComponent.SetFunctionRedDotVisible(functionRedDotVisible);
	}

	// Token: 0x06007DC6 RID: 32198 RVA: 0x00212EED File Offset: 0x002110ED
	private void ButtonFunction()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BlackCoastActivityMainView, this.ActivityData, null);
	}

	// Token: 0x04003C5D RID: 15453
	protected ActivityBlackCoastData ActivityData;

	// Token: 0x04003C5E RID: 15454
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04003C5F RID: 15455
	private ActivityDescriptionTypeB DescriptionComponent;

	// Token: 0x04003C60 RID: 15456
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x04003C61 RID: 15457
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x020075DD RID: 30173
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028A4F RID: 166479
		public const int TitleItem = 0;

		// Token: 0x04028A50 RID: 166480
		public const int TextItem = 1;

		// Token: 0x04028A51 RID: 166481
		public const int RewardItem = 2;

		// Token: 0x04028A52 RID: 166482
		public const int PanelBottom = 3;

		// Token: 0x04028A53 RID: 166483
		public const int DataCount = 4;

		// Token: 0x04028A54 RID: 166484
		public const int DataTotal = 5;

		// Token: 0x04028A55 RID: 166485
		public const int DataIcon = 6;
	}
}
