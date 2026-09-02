using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200135F RID: 4959
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SevenHillsRewardBoxItem : GridProxyAbstract<LongShanScoreRewardData>
{
	// Token: 0x060087E0 RID: 34784 RVA: 0x0023D4A0 File Offset: 0x0023B6A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickRewardButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060087E1 RID: 34785 RVA: 0x0023D62E File Offset: 0x0023B82E
	protected override void OnStart()
	{
		base.GetUiNiagara(7).SetAlpha(0f);
		base.GetUiNiagara(7).SetUIActive(true);
		base.GetUiNiagara(8).SetUIActive(false);
	}

	// Token: 0x060087E2 RID: 34786 RVA: 0x0023D65C File Offset: 0x0023B85C
	[NullableContext(1)]
	public override void Refresh(LongShanScoreRewardData rewardData, bool isSelected, int gridIndex)
	{
		this.Data = rewardData;
		EActivityTaskState state = rewardData.GetState();
		base.GetText(6).SetText(rewardData.Goal.ToString(), true);
		this.RefreshRewardState(state);
	}

	// Token: 0x060087E3 RID: 34787 RVA: 0x0023D698 File Offset: 0x0023B898
	public void RefreshRewardState(EActivityTaskState state)
	{
		UUINiagara uiNiagara = base.GetUiNiagara(8);
		uiNiagara.SetUIActive(false);
		uiNiagara.Deactivate();
		base.GetSprite(2).SetUIActive(state == EActivityTaskState.Active);
		base.GetSprite(3).SetUIActive(state == EActivityTaskState.FinishedAndUnclaimed);
		base.GetSprite(4).SetUIActive(state == EActivityTaskState.FinishedAndClaimed);
		base.GetItem(5).SetUIActive(state == EActivityTaskState.FinishedAndUnclaimed);
		float scoreRewardRelativeProgress = this.ActivityData.GetScoreRewardRelativeProgress(this.Data.Id);
		base.GetSprite(0).SetFillAmount(scoreRewardRelativeProgress);
		base.GetUiNiagara(7).SetAlpha(state == EActivityTaskState.FinishedAndUnclaimed);
		EActivityTaskState? rewardState = this.RewardState;
		EActivityTaskState eactivityTaskState = EActivityTaskState.FinishedAndUnclaimed;
		if ((rewardState.GetValueOrDefault() == eactivityTaskState & rewardState != null) && state == EActivityTaskState.FinishedAndClaimed)
		{
			uiNiagara.SetUIActive(true);
			uiNiagara.ActivateSystem(true);
		}
		this.RewardState = new EActivityTaskState?(state);
	}

	// Token: 0x060087E4 RID: 34788 RVA: 0x0023D76C File Offset: 0x0023B96C
	private void OnClickRewardButton()
	{
		EActivityTaskState? rewardState = this.RewardState;
		if (rewardState != null)
		{
			switch (rewardState.GetValueOrDefault())
			{
			case EActivityTaskState.FinishedAndUnclaimed:
				this.RequestGetAllAvailableReward();
				return;
			case EActivityTaskState.Active:
				this.RefreshRewardPopup(false);
				return;
			case EActivityTaskState.FinishedAndClaimed:
				this.RefreshRewardPopup(true);
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x060087E5 RID: 34789 RVA: 0x0023D7BC File Offset: 0x0023B9BC
	private void RequestGetAllAvailableReward()
	{
		List<int> list = this.ActivityData.GetAllAvailableScoreRewardIds().ToList<int>();
		if (list.Count > 0)
		{
			ControllerBase<ActivityLongShanController>.Instance.RequestScoreReward(this.ActivityData.Id, list);
		}
	}

	// Token: 0x060087E6 RID: 34790 RVA: 0x0023D7FC File Offset: 0x0023B9FC
	private void RefreshRewardPopup(bool isClaimed)
	{
		List<DailyActivityDefine.RewardTuple> list = new List<DailyActivityDefine.RewardTuple>();
		foreach (TItem titem in this.Data.GetPreviewReward())
		{
			DailyActivityDefine.RewardTuple item = new DailyActivityDefine.RewardTuple
			{
				Id = titem.ItemData.ItemId,
				Num = titem.Count,
				Received = isClaimed
			};
			list.Add(item);
		}
		RewardPopupData p = new RewardPopupData
		{
			RewardLists = list,
			MountItem = base.GetButton(1).RootUIComp,
			PosBias = new FVector?(new FVector(0f, this.Y_BIAS, 0f))
		};
		Singleton<EventSystem>.Instance.Emit<RewardPopupData>(EEventName.RefreshRewardPopUp, p);
	}

	// Token: 0x04003FF0 RID: 16368
	private float Y_BIAS = 30f;

	// Token: 0x04003FF1 RID: 16369
	private LongShanScoreRewardData Data;

	// Token: 0x04003FF2 RID: 16370
	private EActivityTaskState? RewardState;

	// Token: 0x04003FF3 RID: 16371
	public ActivityLongShanData ActivityData;

	// Token: 0x0200770B RID: 30475
	[NullableContext(0)]
	private class ERewardItemNode
	{
		// Token: 0x04028FEC RID: 167916
		public const int SpriteProgressBar = 0;

		// Token: 0x04028FED RID: 167917
		public const int BtnReward = 1;

		// Token: 0x04028FEE RID: 167918
		public const int SpriteUnfinished = 2;

		// Token: 0x04028FEF RID: 167919
		public const int SpriteClaimed = 3;

		// Token: 0x04028FF0 RID: 167920
		public const int SpriteReceived = 4;

		// Token: 0x04028FF1 RID: 167921
		public const int ItemRedDot = 5;

		// Token: 0x04028FF2 RID: 167922
		public const int TextGoal = 6;

		// Token: 0x04028FF3 RID: 167923
		public const int NiagaraClaimed = 7;

		// Token: 0x04028FF4 RID: 167924
		public const int NiagaraReceived = 8;
	}
}
