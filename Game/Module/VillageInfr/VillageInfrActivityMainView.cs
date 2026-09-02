using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C05 RID: 19461
	[NullableContext(2)]
	[Nullable(0)]
	public class VillageInfrActivityMainView : ActivitySubViewBase
	{
		// Token: 0x1700872E RID: 34606
		// (get) Token: 0x06032C84 RID: 208004 RVA: 0x00CB8C60 File Offset: 0x00CB6E60
		protected new VillageInfrActivityData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as VillageInfrActivityData;
			}
		}

		// Token: 0x06032C85 RID: 208005 RVA: 0x00CB8C70 File Offset: 0x00CB6E70
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06032C86 RID: 208006 RVA: 0x00CB8CE0 File Offset: 0x00CB6EE0
		protected override UniTask OnBeforeStartAsync()
		{
			VillageInfrActivityMainView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VillageInfrActivityMainView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032C87 RID: 208007 RVA: 0x00CB8D24 File Offset: 0x00CB6F24
		[NullableContext(0)]
		private UniTask<bool> RequestInfrV2Info()
		{
			VillageInfrActivityMainView.<RequestInfrV2Info>d__6 <RequestInfrV2Info>d__;
			<RequestInfrV2Info>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrV2Info>d__.<>1__state = -1;
			<RequestInfrV2Info>d__.<>t__builder.Start<VillageInfrActivityMainView.<RequestInfrV2Info>d__6>(ref <RequestInfrV2Info>d__);
			return <RequestInfrV2Info>d__.<>t__builder.Task;
		}

		// Token: 0x06032C88 RID: 208008 RVA: 0x00CB8D60 File Offset: 0x00CB6F60
		private UniTask CreateRewardButton()
		{
			VillageInfrActivityMainView.<CreateRewardButton>d__7 <CreateRewardButton>d__;
			<CreateRewardButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateRewardButton>d__.<>4__this = this;
			<CreateRewardButton>d__.<>1__state = -1;
			<CreateRewardButton>d__.<>t__builder.Start<VillageInfrActivityMainView.<CreateRewardButton>d__7>(ref <CreateRewardButton>d__);
			return <CreateRewardButton>d__.<>t__builder.Task;
		}

		// Token: 0x06032C89 RID: 208009 RVA: 0x00CB8DA3 File Offset: 0x00CB6FA3
		protected override void OnStart()
		{
			this.RefreshActivityInfo();
			this.RefreshRewardBtn();
		}

		// Token: 0x06032C8A RID: 208010 RVA: 0x00CB8DB1 File Offset: 0x00CB6FB1
		protected override void OnRefreshView()
		{
			this.RefreshRewardBtn();
		}

		// Token: 0x06032C8B RID: 208011 RVA: 0x00CB8DBC File Offset: 0x00CB6FBC
		private void RefreshActivityInfo()
		{
			this.CommonInfoPanel.SetBtnText("LongShanStage_Join01", Array.Empty<object>());
			this.CommonInfoPanel.SetClickFunc(new Action<ActivityBaseData>(this.OnConfirmBtnClick));
			this.CommonInfoPanel.SetFunctionRedDotVisible(this.ActivityBaseData.CheckRedDot());
			ActivityFunctionalTypeA functional = this.CommonInfoPanel.GetFunctional();
			ActivityFunctionAreaParams parameters = new ActivityFunctionAreaParams
			{
				UnlockBtnTextId = "LongShanStage_Join01",
				UnlockBtnFunction = new Action(this.OnConfirmBtnClick)
			};
			functional.RefreshGeneralPerformance(parameters);
		}

		// Token: 0x06032C8C RID: 208012 RVA: 0x00CB8E40 File Offset: 0x00CB7040
		private void RefreshRewardBtn()
		{
			if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.VillageInfr))
			{
				this.RewardButton.SetUiActive(false);
				return;
			}
			this.RewardButton.SetUiActive(true);
			this.RewardButton.BindRedDot(ERedDotName.VillageInfrTask, 0);
			List<VillageInfrLimitTaskData> activityTaskDataList = ModelBase<VillageInfrModel>.Instance.GetActivityTaskDataList();
			int num = 0;
			using (List<VillageInfrLimitTaskData>.Enumerator enumerator = activityTaskDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == ConditionTaskState.ConditionTaskTaken)
					{
						num++;
					}
				}
			}
			ButtonItem rewardButton = this.RewardButton;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(activityTaskDataList.Count);
			rewardButton.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06032C8D RID: 208013 RVA: 0x00CB8F18 File Offset: 0x00CB7118
		private void OnConfirmBtnClick(ActivityBaseData _)
		{
			this.OnConfirmBtnClick();
		}

		// Token: 0x06032C8E RID: 208014 RVA: 0x00CB8F20 File Offset: 0x00CB7120
		private void OnConfirmBtnClick()
		{
			VillageInfrActivityData activityBaseData = this.ActivityBaseData;
			List<int> list = ((activityBaseData != null) ? activityBaseData.GetPreGuideQuestIds() : null) ?? new List<int>();
			if (list.Count <= 0)
			{
				ControllerBase<VillageInfrController>.Instance.OpenVillageInfrMainView(null).Forget<int?>();
				return;
			}
			int num = list[0];
			if (ModelBase<QuestNewModel>.Instance.CheckQuestFinished(num))
			{
				ControllerBase<VillageInfrController>.Instance.OpenVillageInfrMainView(null).Forget<int?>();
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, num, null);
		}

		// Token: 0x06032C8F RID: 208015 RVA: 0x00CB8F9F File Offset: 0x00CB719F
		private void OnClickBtnReward(int _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VillageInfrTaskMainView, null, null);
		}

		// Token: 0x0401D8C5 RID: 121029
		[Nullable(1)]
		protected ActivitySubViewGeneralInfo CommonInfoPanel = new ActivitySubViewGeneralInfo();

		// Token: 0x0401D8C6 RID: 121030
		[Nullable(1)]
		private readonly ButtonItem RewardButton = new ButtonItem(null);
	}
}
