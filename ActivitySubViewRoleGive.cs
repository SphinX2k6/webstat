using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001573 RID: 5491
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewRoleGive : ActivitySubViewBase
{
	// Token: 0x06009A21 RID: 39457 RVA: 0x00285BFC File Offset: 0x00283DFC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
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
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickPreview));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009A22 RID: 39458 RVA: 0x00285D68 File Offset: 0x00283F68
	protected override void OnSetData()
	{
		this.Data = (this.ActivityBaseData as ActivityRoleGiveData);
	}

	// Token: 0x06009A23 RID: 39459 RVA: 0x00285D7C File Offset: 0x00283F7C
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewRoleGive.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewRoleGive.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009A24 RID: 39460 RVA: 0x00285DC0 File Offset: 0x00283FC0
	protected override void OnStart()
	{
		Activity? localConfig = this.Data.LocalConfig;
		TrackMoonPhaseActivity? extraConfig = this.Data.GetExtraConfig();
		if (localConfig == null || extraConfig == null)
		{
			return;
		}
		string descTheme = localConfig.Value.DescTheme;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		string desc = localConfig.Value.Desc;
		this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		ActivityButtonItem functionButton = this.FunctionalComponent.FunctionButton;
		if (functionButton != null)
		{
			functionButton.SetFunction(new Action(this.FunctionExecute));
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("CollectActivity_Button_ahead", null);
		this.FunctionalComponent.FunctionButton.SetText(localTextNew);
		TrialRoleInfo? trialRoleConfig = ConfigBase<TrialRoleConfig>.Instance.GetTrialRoleConfig(extraConfig.Value.RoleTrialId);
		if (trialRoleConfig != null)
		{
			RoleDescribeComponent roleDescComponent = this.RoleDescComponent;
			if (roleDescComponent != null)
			{
				roleDescComponent.Update(trialRoleConfig.Value.ParentId, false);
			}
		}
		if (trialRoleConfig != null)
		{
			CommonItemSmallItemGrid commonItemGrid = this.CommonItemGrid;
			if (commonItemGrid != null)
			{
				commonItemGrid.RefreshByConfigId(trialRoleConfig.Value.ParentId, null, null, false, false);
			}
		}
		this.OnRefreshView();
	}

	// Token: 0x06009A25 RID: 39461 RVA: 0x00285F43 File Offset: 0x00284143
	protected override void OnTimer(float gap)
	{
		this.OnRefreshView();
	}

	// Token: 0x06009A26 RID: 39462 RVA: 0x00285F4B File Offset: 0x0028414B
	protected override void OnRefreshView()
	{
		this.RefreshCondition();
		this.RefreshTimerText();
		this.RefreshRedDot();
		this.RefreshProgress();
	}

	// Token: 0x06009A27 RID: 39463 RVA: 0x00285F68 File Offset: 0x00284168
	private void RefreshProgress()
	{
		TrackMoonPhaseActivity? extraConfig = this.Data.GetExtraConfig();
		if (extraConfig == null)
		{
			return;
		}
		MoonChasingModel instance = ModelBase<MoonChasingModel>.Instance;
		int num = (instance != null) ? instance.GetPopularityValue() : 0;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Moonfiesta_PopularityProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			num,
			extraConfig.Value.PopularityNeed
		}));
		UUISprite sprite = base.GetSprite(7);
		if (sprite == null)
		{
			return;
		}
		sprite.SetFillAmount((float)num / (float)extraConfig.Value.PopularityNeed);
	}

	// Token: 0x06009A28 RID: 39464 RVA: 0x00286004 File Offset: 0x00284204
	private void RefreshTimerText()
	{
		string item = this.GetTimeVisibleAndRemainTime().Item2;
		this.TitleComponent.SetTimeTextByText(item);
	}

	// Token: 0x06009A29 RID: 39465 RVA: 0x0028602C File Offset: 0x0028422C
	protected void RefreshCondition()
	{
		TrackMoonPhaseActivity? extraConfig = this.Data.GetExtraConfig();
		if (extraConfig == null)
		{
			return;
		}
		if (!this.ActivityBaseData.IsUnLock())
		{
			ActivityButtonItem functionButton = this.FunctionalComponent.FunctionButton;
			if (functionButton != null)
			{
				functionButton.SetUiActive(false);
			}
			this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
			return;
		}
		ActivityRoleGiveData data = this.Data;
		if (data != null && data.IsGetReward)
		{
			ActivityButtonItem functionButton2 = this.FunctionalComponent.FunctionButton;
			if (functionButton2 != null)
			{
				functionButton2.SetUiActive(false);
			}
			this.FunctionalComponent.SetActivatePanelConditionVisible(true);
			this.FunctionalComponent.SetPanelConditionVisible(false);
		}
		else
		{
			ActivityButtonItem functionButton3 = this.FunctionalComponent.FunctionButton;
			if (functionButton3 != null)
			{
				functionButton3.SetUiActive(true);
			}
			this.FunctionalComponent.SetActivatePanelConditionVisible(false);
			this.FunctionalComponent.SetPanelConditionVisible(false);
		}
		ActivityRoleGiveData data2 = this.Data;
		if (data2 == null || !data2.IsGetReward)
		{
			MoonChasingModel instance = ModelBase<MoonChasingModel>.Instance;
			if (((instance != null) ? instance.GetPopularityValue() : 0) >= extraConfig.Value.PopularityNeed)
			{
				ActivityButtonItem functionButton4 = this.FunctionalComponent.FunctionButton;
				if (functionButton4 == null)
				{
					return;
				}
				functionButton4.SetText(ConfigMultiTextLang.GetLocalTextNew("CollectActivity_state_CanRecive", null));
				return;
			}
		}
		ActivityButtonItem functionButton5 = this.FunctionalComponent.FunctionButton;
		if (functionButton5 == null)
		{
			return;
		}
		functionButton5.SetText(ConfigMultiTextLang.GetLocalTextNew("CollectActivity_Button_ahead", null));
	}

	// Token: 0x06009A2A RID: 39466 RVA: 0x00286183 File Offset: 0x00284383
	private void RefreshRedDot()
	{
		ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
		if (functionalComponent == null)
		{
			return;
		}
		functionalComponent.SetFunctionRedDotVisible(this.Data.RedPointShowState);
	}

	// Token: 0x06009A2B RID: 39467 RVA: 0x002861A0 File Offset: 0x002843A0
	private void FunctionExecute()
	{
		Singleton<Log>.Instance.Info(ELogModule.MoonChasing, ELogAuthor.LPH, "点击领取奖励", default(ReadOnlySpan<ValueTuple<string, object>>));
		ActivityRoleGiveData data = this.Data;
		if (data == null || !data.RedPointShowState)
		{
			foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetActivitiesByType(17))
			{
				ActivityMoonChasingData activityMoonChasingData = activityBaseData as ActivityMoonChasingData;
				if (activityMoonChasingData != null && activityMoonChasingData.ActivityFlowState == EMoonChasingActivityFlow.Activity)
				{
					if (!activityMoonChasingData.GetPreGuideQuestFinishState())
					{
						Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, activityMoonChasingData.GetUnFinishPreGuideQuestId(), null);
						return;
					}
					TrackMoonActivity? activityMoonChasingConfig = ConfigBase<ActivityMoonChasingConfig>.Instance.GetActivityMoonChasingConfig(activityBaseData.Id);
					if (activityMoonChasingConfig != null)
					{
						WorldMapViewOpenParams data2 = new WorldMapViewOpenParams
						{
							MarkId = new int?(activityMoonChasingConfig.Value.FocusMarkId),
							MarkType = EMarkType.SmallTeleport
						};
						ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data2, null);
						return;
					}
				}
			}
			return;
		}
		ActivityRoleGiveData data3 = this.Data;
		TrackMoonPhaseActivity? trackMoonPhaseActivity = (data3 != null) ? data3.GetExtraConfig() : null;
		MoonChasingModel instance = ModelBase<MoonChasingModel>.Instance;
		int? num = (instance != null) ? new int?(instance.GetPopularityValue()) : null;
		if (trackMoonPhaseActivity == null)
		{
			return;
		}
		if (num == null)
		{
			return;
		}
		if (num.Value < trackMoonPhaseActivity.Value.PopularityNeed)
		{
			return;
		}
		ControllerBase<ActivityRoleGiveController>.Instance.TrackMoonActivityRewardRequest();
	}

	// Token: 0x06009A2C RID: 39468 RVA: 0x00286348 File Offset: 0x00284548
	private unsafe void OnClickPreview()
	{
		TrackMoonPhaseActivity? extraConfig = this.Data.GetExtraConfig();
		if (extraConfig != null)
		{
			RoleController instance = ControllerBase<RoleController>.Instance;
			ERoleAgentType agentType = ERoleAgentType.Preview;
			int selectRoleId = 0;
			int num = 1;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list, num);
			Span<int> span = CollectionsMarshal.AsSpan<int>(list);
			int index = 0;
			*span[index] = extraConfig.Value.RoleTrialId;
			instance.OpenRoleMainView(agentType, selectRoleId, list, null, null);
		}
	}

	// Token: 0x04004714 RID: 18196
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04004715 RID: 18197
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x04004716 RID: 18198
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x04004717 RID: 18199
	private RoleDescribeComponent RoleDescComponent;

	// Token: 0x04004718 RID: 18200
	private CommonItemSmallItemGrid CommonItemGrid;

	// Token: 0x04004719 RID: 18201
	private ActivityRoleGiveData Data;

	// Token: 0x02007937 RID: 31031
	[NullableContext(0)]
	private class EActivitySubViewRoleGiveDefine
	{
		// Token: 0x04029A5B RID: 170587
		public const int TitleItem = 0;

		// Token: 0x04029A5C RID: 170588
		public const int DescItem = 1;

		// Token: 0x04029A5D RID: 170589
		public const int RoleDescriptionItem = 2;

		// Token: 0x04029A5E RID: 170590
		public const int BtnPreview = 3;

		// Token: 0x04029A5F RID: 170591
		public const int FunctionItem = 4;

		// Token: 0x04029A60 RID: 170592
		public const int RewardItem = 5;

		// Token: 0x04029A61 RID: 170593
		public const int TxtProgress = 6;

		// Token: 0x04029A62 RID: 170594
		public const int SpriteProgress = 7;
	}
}
