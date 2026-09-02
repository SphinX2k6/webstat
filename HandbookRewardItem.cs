using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020013EB RID: 5099
[NullableContext(1)]
[Nullable(0)]
public class HandbookRewardItem : GridProxyAbstract<int>
{
	// Token: 0x06008D59 RID: 36185 RVA: 0x002529FC File Offset: 0x00250BFC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUINiagara)),
			new ValueTuple<int, Type>(7, typeof(UUINiagara)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.ClickRewardButton))
		};
	}

	// Token: 0x06008D5A RID: 36186 RVA: 0x00252B2B File Offset: 0x00250D2B
	protected override void OnStart()
	{
		base.GetUiNiagara(6).SetAlpha(0f);
		base.GetUiNiagara(6).SetUIActive(true);
		base.GetUiNiagara(7).SetUIActive(false);
	}

	// Token: 0x06008D5B RID: 36187 RVA: 0x00252B58 File Offset: 0x00250D58
	public override void Refresh(int rewardId, bool isSelected, int gridIndex)
	{
		HandbookRewardData handbookRewardDataById = ModelBase<MoonChasingModel>.Instance.GetHandbookRewardDataById(rewardId);
		if (handbookRewardDataById == null)
		{
			return;
		}
		this.Data = handbookRewardDataById;
		int handbookUnlockCount = ModelBase<MoonChasingModel>.Instance.GetHandbookUnlockCount();
		EHandbookRewardState state = handbookRewardDataById.GetState(handbookUnlockCount);
		this.SetRewardGoalValue(state, handbookRewardDataById.Goal);
		this.RefreshRewardState(state, this.RewardState == null);
	}

	// Token: 0x06008D5C RID: 36188 RVA: 0x00252BB4 File Offset: 0x00250DB4
	public void SetRewardGoalValue(EHandbookRewardState state, int value)
	{
		UUIText[] array = new UUIText[]
		{
			base.GetText(0),
			base.GetText(10),
			base.GetText(9)
		};
		for (int i = 0; i < array.Length; i++)
		{
			bool flag = i == (int)state;
			array[i].SetUIActive(flag);
			if (flag)
			{
				array[i].SetText(value.ToString(), true);
			}
		}
	}

	// Token: 0x06008D5D RID: 36189 RVA: 0x00252C18 File Offset: 0x00250E18
	public void RefreshRewardState(EHandbookRewardState state, bool isInit)
	{
		UUINiagara uiNiagara = base.GetUiNiagara(7);
		uiNiagara.SetUIActive(false);
		uiNiagara.Deactivate();
		if (!isInit)
		{
			EHandbookRewardState? rewardState = this.RewardState;
			if (rewardState.GetValueOrDefault() == state & rewardState != null)
			{
				return;
			}
		}
		UUISprite[] array = new UUISprite[]
		{
			base.GetSprite(2),
			base.GetSprite(4),
			base.GetSprite(3)
		};
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetUIActive(i == (int)state);
		}
		base.GetItem(8).SetUIActive(state == EHandbookRewardState.FinishedAndUnclaimed);
		FColor color = FColor.FromHex((state == EHandbookRewardState.Active) ? "00000033" : "F3EAAB1E");
		base.GetSprite(5).SetColor(color);
		base.GetUiNiagara(6).SetAlpha(state == EHandbookRewardState.FinishedAndUnclaimed);
		if (state == EHandbookRewardState.FinishedAndClaimed && !isInit)
		{
			uiNiagara.SetUIActive(true);
			uiNiagara.ActivateSystem(true);
		}
		this.RewardState = new EHandbookRewardState?(state);
	}

	// Token: 0x06008D5E RID: 36190 RVA: 0x00252D08 File Offset: 0x00250F08
	private void ClickRewardButton()
	{
		EHandbookRewardState? rewardState = this.RewardState;
		if (rewardState != null)
		{
			switch (rewardState.GetValueOrDefault())
			{
			case EHandbookRewardState.Active:
				this.RefreshRewardPopup(false);
				return;
			case EHandbookRewardState.FinishedAndUnclaimed:
				this.RequestGetAllAvailableReward();
				return;
			case EHandbookRewardState.FinishedAndClaimed:
				this.RefreshRewardPopup(true);
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x06008D5F RID: 36191 RVA: 0x00252D56 File Offset: 0x00250F56
	private void RequestGetAllAvailableReward()
	{
		ControllerBase<MoonChasingController>.Instance.RequestAllAvailableHandbookReward();
	}

	// Token: 0x06008D60 RID: 36192 RVA: 0x00252D64 File Offset: 0x00250F64
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
			PosBias = new FVector?(new FVector(0f, 30f, 0f))
		};
		Singleton<EventSystem>.Instance.Emit<RewardPopupData>(EEventName.RefreshRewardPopUp, p);
	}

	// Token: 0x040041D4 RID: 16852
	private EHandbookRewardState? RewardState;

	// Token: 0x040041D5 RID: 16853
	private HandbookRewardData Data;

	// Token: 0x040041D6 RID: 16854
	private const int Y_BIAS = 30;

	// Token: 0x040041D7 RID: 16855
	private const string REWARD_BACKGROUND_COLOR_UNFINISHED = "00000033";

	// Token: 0x040041D8 RID: 16856
	private const string REWARD_BACKGROUND_COLOR_FINISHED = "F3EAAB1E";

	// Token: 0x020077E2 RID: 30690
	[NullableContext(0)]
	private class ERewardItemNode
	{
		// Token: 0x04029406 RID: 168966
		public const int TxtValueUnFinished = 0;

		// Token: 0x04029407 RID: 168967
		public const int BtnReward = 1;

		// Token: 0x04029408 RID: 168968
		public const int SpriteUnfinished = 2;

		// Token: 0x04029409 RID: 168969
		public const int SpriteClaimed = 3;

		// Token: 0x0402940A RID: 168970
		public const int SpriteFinished = 4;

		// Token: 0x0402940B RID: 168971
		public const int SpriteBackground = 5;

		// Token: 0x0402940C RID: 168972
		public const int NiagaraWait = 6;

		// Token: 0x0402940D RID: 168973
		public const int NiagaraGet = 7;

		// Token: 0x0402940E RID: 168974
		public const int RedDot = 8;

		// Token: 0x0402940F RID: 168975
		public const int TxtValueFinished = 9;

		// Token: 0x04029410 RID: 168976
		public const int TxtValueReceivable = 10;
	}
}
