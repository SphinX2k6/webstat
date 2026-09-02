using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015E1 RID: 5601
[NullableContext(1)]
[Nullable(0)]
public class ActivitySubViewTrapDefense : ActivitySubViewBase
{
	// Token: 0x17000D56 RID: 3414
	// (get) Token: 0x06009D96 RID: 40342 RVA: 0x00293E66 File Offset: 0x00292066
	// (set) Token: 0x06009D97 RID: 40343 RVA: 0x00293E73 File Offset: 0x00292073
	protected new ActivityTrapDefenseData ActivityBaseData
	{
		get
		{
			return this.ActivityBaseData as ActivityTrapDefenseData;
		}
		set
		{
			this.ActivityBaseData = value;
		}
	}

	// Token: 0x06009D98 RID: 40344 RVA: 0x00293E7C File Offset: 0x0029207C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(USpineSkeletonAnimationComponent))
		};
	}

	// Token: 0x06009D99 RID: 40345 RVA: 0x00293F18 File Offset: 0x00292118
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewTrapDefense.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewTrapDefense.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009D9A RID: 40346 RVA: 0x00293F5C File Offset: 0x0029215C
	protected override void OnAddEventListener()
	{
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			ActivityFunctionalTypeA functional = commonInfoPanel.GetFunctional();
			if (functional != null)
			{
				ActivityButtonItem functionButton = functional.FunctionButton;
				if (functionButton != null)
				{
					functionButton.BindRedDot(ERedDotName.TrapDefense, 0);
				}
			}
		}
		this.FixedRewardItem.BindRedDot(ERedDotName.TrapDefenseFixedReward, 0);
		this.LimitRewardItem.BindRedDot(ERedDotName.TrapDefenseLimitReward, 0);
	}

	// Token: 0x06009D9B RID: 40347 RVA: 0x00293FB8 File Offset: 0x002921B8
	protected override void OnRemoveEventListener()
	{
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			ActivityFunctionalTypeA functional = commonInfoPanel.GetFunctional();
			if (functional != null)
			{
				ActivityButtonItem functionButton = functional.FunctionButton;
				if (functionButton != null)
				{
					functionButton.UnBindGivenUid(0);
				}
			}
		}
		this.FixedRewardItem.UnBindGivenUid(0);
		this.LimitRewardItem.UnBindGivenUid(0);
	}

	// Token: 0x06009D9C RID: 40348 RVA: 0x00294005 File Offset: 0x00292205
	protected override void OnRefreshView()
	{
		this.UpdateFixedReward();
		this.UpdateLimitReward();
		this.UpdateRougeModeTips();
	}

	// Token: 0x06009D9D RID: 40349 RVA: 0x0029401C File Offset: 0x0029221C
	[NullableContext(2)]
	private void ClickCommonInfo(ActivityBaseData _)
	{
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		if (instance != null)
		{
			instance.OpenMainEntryView();
		}
		TrapDefenseModel instance2 = ModelBase<TrapDefenseModel>.Instance;
		if (instance2 != null && instance2.RougeModeData.CheckModeOpenSubState())
		{
			this.UpdateRougeModeTips();
		}
	}

	// Token: 0x06009D9E RID: 40350 RVA: 0x00294087 File Offset: 0x00292287
	public void OnClickBtnFixedReward()
	{
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.OpenViewFixedReward();
	}

	// Token: 0x06009D9F RID: 40351 RVA: 0x00294098 File Offset: 0x00292298
	public void OnClickBtnLimitReward()
	{
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.OpenViewLimitReward();
	}

	// Token: 0x06009DA0 RID: 40352 RVA: 0x002940AC File Offset: 0x002922AC
	public void UpdateFixedReward()
	{
		ValueTuple<int, int> fixedRewardTotalProgress = ModelBase<TrapDefenseModel>.Instance.RewardData.GetFixedRewardTotalProgress();
		int item = fixedRewardTotalProgress.Item1;
		int item2 = fixedRewardTotalProgress.Item2;
		this.FixedRewardItem.GetProgressText().SetText(item.ToString() + "/" + item2.ToString(), true);
	}

	// Token: 0x06009DA1 RID: 40353 RVA: 0x00294100 File Offset: 0x00292300
	public void UpdateLimitReward()
	{
		TrapDefenseRewardData rewardData = ModelBase<TrapDefenseModel>.Instance.RewardData;
		bool flag = rewardData.IsOpenLimitReward();
		this.LimitRewardItem.SetActive(flag);
		if (flag)
		{
			ValueTuple<int, int> limitRewardTotalProgress = rewardData.GetLimitRewardTotalProgress();
			int item = limitRewardTotalProgress.Item1;
			int item2 = limitRewardTotalProgress.Item2;
			this.LimitRewardItem.GetProgressText().SetText(item.ToString() + "/" + item2.ToString(), true);
			this.UpdateLimitRewardDownTime();
		}
	}

	// Token: 0x06009DA2 RID: 40354 RVA: 0x00294170 File Offset: 0x00292370
	public void UpdateLimitRewardDownTime()
	{
		UUIText text = base.GetText(1);
		TrapDefenseRewardData rewardData = ModelBase<TrapDefenseModel>.Instance.RewardData;
		bool flag = rewardData.IsOpenLimitReward();
		text.SetUIActive(flag);
		if (flag)
		{
			string limitRewardRemainTimeStr = rewardData.GetLimitRewardRemainTimeStr();
			text.SetText(limitRewardRemainTimeStr, true);
		}
	}

	// Token: 0x06009DA3 RID: 40355 RVA: 0x002941B0 File Offset: 0x002923B0
	protected override void OnTimer(float gap)
	{
		this.UpdateLimitRewardDownTime();
	}

	// Token: 0x06009DA4 RID: 40356 RVA: 0x002941B8 File Offset: 0x002923B8
	public UniTask UpdateSpine()
	{
		ActivitySubViewTrapDefense.<UpdateSpine>d__20 <UpdateSpine>d__;
		<UpdateSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateSpine>d__.<>4__this = this;
		<UpdateSpine>d__.<>1__state = -1;
		<UpdateSpine>d__.<>t__builder.Start<ActivitySubViewTrapDefense.<UpdateSpine>d__20>(ref <UpdateSpine>d__);
		return <UpdateSpine>d__.<>t__builder.Task;
	}

	// Token: 0x06009DA5 RID: 40357 RVA: 0x002941FC File Offset: 0x002923FC
	public void UpdateRougeModeTips()
	{
		bool active = ModelBase<TrapDefenseModel>.Instance.RougeModeData.IsShowRougeModeTipsToActivity();
		this.PanelRougeModeTips.SetActive(active);
	}

	// Token: 0x04004895 RID: 18581
	[Nullable(2)]
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x04004896 RID: 18582
	public ActivityTrapDefenseRewardBtn FixedRewardItem;

	// Token: 0x04004897 RID: 18583
	public ActivityTrapDefenseRewardBtn LimitRewardItem;

	// Token: 0x04004898 RID: 18584
	public RecommendQuestTipsSubPanel PanelRougeModeTips;

	// Token: 0x02007993 RID: 31123
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x04029C11 RID: 171025
		public const int ItemCommonPanel = 0;

		// Token: 0x04029C12 RID: 171026
		public const int TextDownTime = 1;

		// Token: 0x04029C13 RID: 171027
		public const int ItemFixedReward = 2;

		// Token: 0x04029C14 RID: 171028
		public const int ItemLimitReward = 3;

		// Token: 0x04029C15 RID: 171029
		public const int ItemRougeModeOpenTips = 4;

		// Token: 0x04029C16 RID: 171030
		public const int SpineMainRole = 5;
	}
}
