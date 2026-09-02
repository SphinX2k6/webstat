using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200127B RID: 4731
public class AnniversaryCelebrationAwardSubView : ActivitySubViewBase
{
	// Token: 0x06007EA2 RID: 32418 RVA: 0x00217BB4 File Offset: 0x00215DB4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
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

	// Token: 0x06007EA3 RID: 32419 RVA: 0x00217CC2 File Offset: 0x00215EC2
	protected override void OnSetData()
	{
		this.ActivityTimePointRewardData = (this.ActivityBaseData as ActivityTimePointRewardData);
	}

	// Token: 0x06007EA4 RID: 32420 RVA: 0x00217CD8 File Offset: 0x00215ED8
	protected override UniTask OnBeforeStartAsync()
	{
		AnniversaryCelebrationAwardSubView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AnniversaryCelebrationAwardSubView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007EA5 RID: 32421 RVA: 0x00217D1B File Offset: 0x00215F1B
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06007EA6 RID: 32422 RVA: 0x00217D39 File Offset: 0x00215F39
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06007EA7 RID: 32423 RVA: 0x00217D58 File Offset: 0x00215F58
	protected override void OnStart()
	{
		base.GetText(4).SetText(this.ActivityBaseData.GetTitle(), true);
		string activityLogo = CelebrationUtils.GetActivityLogo();
		base.SetTextureByPath(activityLogo, base.GetTexture(6), null, null);
		this.RefreshTimeTitle();
		this.RefreshRewardPanels();
		this.RefreshRewardState();
		this.ActivityTimePointRewardData.SaveClickRedDotState();
	}

	// Token: 0x06007EA8 RID: 32424 RVA: 0x00217DB8 File Offset: 0x00215FB8
	private void RefreshRewardPanels()
	{
		List<TimePointRewardData> rewardDataList = this.ActivityTimePointRewardData.GetRewardDataList();
		for (int i = 0; i < this.AwardPanelArray.Count; i++)
		{
			AwardPanel awardPanel = this.AwardPanelArray[i];
			TimePointRewardData data = rewardDataList[i];
			awardPanel.SetActivityId(this.ActivityTimePointRewardData.Id);
			awardPanel.Refresh(data);
		}
	}

	// Token: 0x06007EA9 RID: 32425 RVA: 0x00217E12 File Offset: 0x00216012
	[NullableContext(1)]
	private string GetTipsTextId(int i)
	{
		if (i == 0)
		{
			return "Anniversary_WelfareTime_430";
		}
		return "Anniversary_WelfareTime_523";
	}

	// Token: 0x06007EAA RID: 32426 RVA: 0x00217E24 File Offset: 0x00216024
	private void RefreshRewardState()
	{
		List<TimePointRewardData> rewardDataList = this.ActivityTimePointRewardData.GetRewardDataList();
		for (int i = 0; i < this.AwardPanelArray.Count; i++)
		{
			AwardPanel awardPanel = this.AwardPanelArray[i];
			TimePointRewardData data = rewardDataList[i];
			awardPanel.RefreshState(data, this.GetTipsTextId(i));
		}
	}

	// Token: 0x06007EAB RID: 32427 RVA: 0x00217E74 File Offset: 0x00216074
	private void OnRefreshCommonActivityRedDot(int id)
	{
		if (this.ActivityBaseData.Id != id)
		{
			return;
		}
		this.RefreshRewardPanels();
		this.RefreshRewardState();
	}

	// Token: 0x06007EAC RID: 32428 RVA: 0x00217E94 File Offset: 0x00216094
	private void RefreshTimeTitle()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityTimePointRewardData, null);
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		base.GetText(1).SetText(item2, true);
		base.GetItem(0).SetUIActive(item);
	}

	// Token: 0x06007EAD RID: 32429 RVA: 0x00217EDA File Offset: 0x002160DA
	protected override void OnTimer(float gap)
	{
		this.RefreshRewardState();
		this.RefreshTimeTitle();
	}

	// Token: 0x04003CBB RID: 15547
	[Nullable(2)]
	protected ActivityTimePointRewardData ActivityTimePointRewardData;

	// Token: 0x04003CBC RID: 15548
	[Nullable(1)]
	private readonly List<AwardPanel> AwardPanelArray = new List<AwardPanel>();

	// Token: 0x04003CBD RID: 15549
	private const int AwardPanelBegin = 2;

	// Token: 0x04003CBE RID: 15550
	private const int AwardPanelEnd = 3;

	// Token: 0x020075FD RID: 30205
	private class EComponentDefine
	{
		// Token: 0x04028AD9 RID: 166617
		public const int TimeItem = 0;

		// Token: 0x04028ADA RID: 166618
		public const int TimeText = 1;

		// Token: 0x04028ADB RID: 166619
		public const int AwardItemA = 2;

		// Token: 0x04028ADC RID: 166620
		public const int AwardItemB = 3;

		// Token: 0x04028ADD RID: 166621
		public const int TitleText = 4;

		// Token: 0x04028ADE RID: 166622
		public const int TipsText = 5;

		// Token: 0x04028ADF RID: 166623
		public const int ActivityLogoTexture = 6;
	}
}
