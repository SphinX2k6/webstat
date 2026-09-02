using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AA4 RID: 6820
[NullableContext(2)]
[Nullable(0)]
internal class DailyActivityRewardItemContent : GridProxyAbstract<int>
{
	// Token: 0x0600C353 RID: 50003 RVA: 0x003375E4 File Offset: 0x003357E4
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
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.ClickRewardButton))
		};
	}

	// Token: 0x0600C354 RID: 50004 RVA: 0x00337713 File Offset: 0x00335913
	protected override void OnStart()
	{
		base.GetUiNiagara(6).SetAlpha(0f);
		base.GetUiNiagara(7).SetUIActive(false);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600C355 RID: 50005 RVA: 0x00337744 File Offset: 0x00335944
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x0600C356 RID: 50006 RVA: 0x00337748 File Offset: 0x00335948
	public override void Refresh(int rewardId, bool isSelected, int gridIndex)
	{
		this.RewardId = rewardId;
		DailyActivityDefine.IActivityGoalData activityGoalData;
		(this.DataAdapter ?? new DailyActivityRewardAdapter()).GoalMap.TryGetValue(this.RewardId, out activityGoalData);
		if (activityGoalData == null)
		{
			return;
		}
		this.SetRewardGoalValue(activityGoalData.Goal);
		EDailyActiveState? dailyActiveState = this.DailyActiveState;
		EDailyActiveState state = activityGoalData.State;
		if (!(dailyActiveState.GetValueOrDefault() == state & dailyActiveState != null))
		{
			this.RefreshRewardState(activityGoalData.State, this.DailyActiveState == null);
		}
		else if (this.DailyActiveState.GetValueOrDefault() == EDailyActiveState.FinishedAndTaken)
		{
			base.GetUiNiagara(7).SetUIActive(false);
		}
		this.RefreshShowItem(gridIndex);
	}

	// Token: 0x0600C357 RID: 50007 RVA: 0x003377F0 File Offset: 0x003359F0
	private void RefreshShowItem(int gridIndex)
	{
		IReadOnlyDictionary<int, DailyActivityDefine.IActivityGoalData> goalMap = (this.DataAdapter ?? new DailyActivityRewardAdapter()).GoalMap;
		bool flag = gridIndex == goalMap.Count - 1;
		UUIItem item = base.GetItem(9);
		UUIItem item2 = base.GetItem(10);
		item.SetUIActive(!flag);
		item2.SetUIActive(flag);
	}

	// Token: 0x0600C358 RID: 50008 RVA: 0x0033783F File Offset: 0x00335A3F
	public void RefreshSelf()
	{
		this.Refresh(this.RewardId, false, 0);
	}

	// Token: 0x0600C359 RID: 50009 RVA: 0x00337850 File Offset: 0x00335A50
	public UniTask PlayRewardAnimAsync()
	{
		DailyActivityRewardItemContent.<PlayRewardAnimAsync>d__11 <PlayRewardAnimAsync>d__;
		<PlayRewardAnimAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayRewardAnimAsync>d__.<>4__this = this;
		<PlayRewardAnimAsync>d__.<>1__state = -1;
		<PlayRewardAnimAsync>d__.<>t__builder.Start<DailyActivityRewardItemContent.<PlayRewardAnimAsync>d__11>(ref <PlayRewardAnimAsync>d__);
		return <PlayRewardAnimAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C35A RID: 50010 RVA: 0x00337893 File Offset: 0x00335A93
	public void SetRewardGoalValue(int value)
	{
		base.GetText(0).SetText(value.ToString(), true);
	}

	// Token: 0x0600C35B RID: 50011 RVA: 0x003378AC File Offset: 0x00335AAC
	public void RefreshRewardState(EDailyActiveState state, bool isInit)
	{
		List<UUISprite> list = new List<UUISprite>
		{
			base.GetSprite(4),
			base.GetSprite(2),
			base.GetSprite(3)
		};
		for (int i = 0; i < list.Count; i++)
		{
			list[i].SetUIActive(i + EDailyActiveState.FinishedAndNotTaken == state);
		}
		base.GetItem(8).SetUIActive(state == EDailyActiveState.FinishedAndNotTaken);
		base.GetUiNiagara(6).SetAlpha(state == EDailyActiveState.FinishedAndNotTaken);
		UUINiagara uiNiagara = base.GetUiNiagara(7);
		if (state == EDailyActiveState.FinishedAndTaken && !isInit)
		{
			uiNiagara.SetUIActive(true);
			uiNiagara.ActivateSystem(true);
		}
		else
		{
			uiNiagara.SetUIActive(false);
			uiNiagara.Deactivate();
		}
		if (state == EDailyActiveState.FinishedAndNotTaken && !isInit)
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Activate", false, null, false);
		}
		FColor color = FColor.FromHex((state == EDailyActiveState.Unfinished) ? "00000033" : "F3EAAB1E");
		base.GetSprite(5).SetColor(color);
		UUIItem text = base.GetText(0);
		bool bUseChangeColor = state != EDailyActiveState.Unfinished;
		FColor? fcolor = new FColor?(base.GetText(0).changeColor);
		text.SetChangeColor(bUseChangeColor, fcolor);
		this.DailyActiveState = new EDailyActiveState?(state);
	}

	// Token: 0x0600C35C RID: 50012 RVA: 0x003379D0 File Offset: 0x00335BD0
	private void ClickRewardButton()
	{
		EDailyActiveState? dailyActiveState = this.DailyActiveState;
		if (dailyActiveState != null)
		{
			switch (dailyActiveState.GetValueOrDefault())
			{
			case EDailyActiveState.FinishedAndNotTaken:
			{
				Action rewardRequestDelegate = this.RewardRequestDelegate;
				if (rewardRequestDelegate == null)
				{
					return;
				}
				rewardRequestDelegate();
				return;
			}
			case EDailyActiveState.Unfinished:
				this.RefreshRewardPopup(false);
				return;
			case EDailyActiveState.FinishedAndTaken:
				this.RefreshRewardPopup(true);
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x0600C35D RID: 50013 RVA: 0x00337A2C File Offset: 0x00335C2C
	private void RefreshRewardPopup(bool isClaimed)
	{
		List<TItem> rewardById = (this.DataAdapter ?? new DailyActivityRewardAdapter()).GetRewardById(this.RewardId);
		List<DailyActivityDefine.RewardTuple> list = new List<DailyActivityDefine.RewardTuple>();
		foreach (TItem titem in rewardById)
		{
			DailyActivityDefine.RewardTuple item = new DailyActivityDefine.RewardTuple
			{
				Id = titem.ItemData.ItemId,
				Num = titem.Count,
				Received = isClaimed,
				IsDoubleRewardVisible = ModelBase<DailyActivityModel>.Instance.ShouldShowLivenessRewardDoubleTag(titem.ItemData.ItemId)
			};
			list.Add(item);
		}
		RewardPopupData rewardData = new RewardPopupData
		{
			RewardLists = list,
			MountItem = base.GetButton(1).RootUIComp.Get(),
			PosBias = new FVector?(new FVector(0f, 30f, 0f))
		};
		ModelBase<DailyActivityModel>.Instance.RewardData = rewardData;
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshActivityRewardPopUp);
	}

	// Token: 0x04005DA0 RID: 23968
	private int RewardId;

	// Token: 0x04005DA1 RID: 23969
	public EDailyActiveState? DailyActiveState;

	// Token: 0x04005DA2 RID: 23970
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04005DA3 RID: 23971
	public Action RewardRequestDelegate;

	// Token: 0x04005DA4 RID: 23972
	public DailyActivityDefine.IActivityRewardPanelDataAdapter DataAdapter;
}
