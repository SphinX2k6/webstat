using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001562 RID: 5474
[NullableContext(2)]
[Nullable(0)]
public class ActivityRegressTaskScrollItemPanel : UiPanelBase
{
	// Token: 0x0600999A RID: 39322 RVA: 0x002830C0 File Offset: 0x002812C0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
	}

	// Token: 0x0600999B RID: 39323 RVA: 0x002831CC File Offset: 0x002813CC
	protected override void OnStart()
	{
		this.ItemGrid = new SmallItemGrid();
		this.ItemGrid.Initialize(base.GetItem(4).GetOwner());
		this.ItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		this.ItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleClicked));
		UUIItem item = base.GetItem(7);
		this.ButtonItemE = new ButtonItem(item);
		this.ButtonItemE.SetFunction(new Action<int>(this.OnConfirmBtnClick));
		this.ButtonItemE.SetShowText("RecallActivity_Go");
		UUIItem item2 = base.GetItem(10);
		this.ButtonItemB = new ButtonItem(item2);
		this.ButtonItemB.SetFunction(new Action<int>(this.OnConfirmBtnClick));
	}

	// Token: 0x0600999C RID: 39324 RVA: 0x002832A4 File Offset: 0x002814A4
	[NullableContext(1)]
	public void RefreshByData(ActivityRegressTaskDynamicData data)
	{
		this.Data = data;
		RegressQuest? config = data.Config;
		ERegressRewardState taskRewardStateForShow = this.GetTaskRewardStateForShow();
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, config.Value.TargetName, Array.Empty<object>());
		UUIText text2 = base.GetText(8);
		if (data.TaskType == ERegressTaskType.Constant)
		{
			this.SetupConstantTaskVisuals();
		}
		else
		{
			this.SetupDailyTaskVisuals();
		}
		if (taskRewardStateForShow == ERegressRewardState.Claim)
		{
			text2.SetText("", true);
		}
		IRegressRewardItemInfo regressTaskRewardItemInfo = ModelBase<ActivityRegressModel>.Instance.GetRegressTaskRewardItemInfo(config.Value);
		ActivityRegressHelper.RefreshItemGridByData(this.ItemGrid, regressTaskRewardItemInfo);
		ItemInfo? itemInfo = regressTaskRewardItemInfo.ItemInfo;
		int itemCount = regressTaskRewardItemInfo.ItemCount;
		bool item = regressTaskRewardItemInfo.RewardState == ERegressRewardState.UnReach;
		bool item2 = false;
		bool item3 = regressTaskRewardItemInfo.RewardState == ERegressRewardState.Claim;
		ActivityRegressHelper.RefreshItemGrid(this.ItemGrid, itemInfo.Value, itemCount, new ValueTuple<bool, bool, bool>(item, item2, item3));
		this.ButtonItemE.SetUiActive(taskRewardStateForShow == ERegressRewardState.UnReach);
		this.ButtonItemB.SetUiActive(taskRewardStateForShow == ERegressRewardState.Reached);
		base.GetText(6).SetUIActive(false);
		base.GetItem(5).SetUIActive(taskRewardStateForShow == ERegressRewardState.Claim);
		base.GetItem(9).SetUIActive(taskRewardStateForShow == ERegressRewardState.Claim);
	}

	// Token: 0x0600999D RID: 39325 RVA: 0x002833D4 File Offset: 0x002815D4
	private void SetupConstantTaskVisuals()
	{
		RegressQuest? config = this.Data.Config;
		int id = config.Value.Id;
		ValueTuple<int, int> taskProgressTuple = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskProgressTuple(id);
		int item = taskProgressTuple.Item1;
		int item2 = taskProgressTuple.Item2;
		UUIText text = base.GetText(3);
		text.SetUIActive(true);
		UUIText uuitext = text;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(item);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
		uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		ERegressRewardState taskRewardState = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskRewardState(id);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RecallActivity_Task_Tips", new <>z__ReadOnlyArray<object>(new object[]
		{
			item.ToString(),
			item2.ToString()
		}));
		base.GetItem(2).SetUIActive(true);
		int taskSubType = config.Value.TaskSubType;
		if (taskSubType == 1)
		{
			global::Quest firstShowQuestByType = ModelBase<QuestNewModel>.Instance.GetFirstShowQuestByType(1);
			global::RoleQuest firstShowRoleQuest = ModelBase<ActivityRegressModel>.Instance.GetFirstShowRoleQuest();
			if (firstShowQuestByType == null && firstShowRoleQuest == null && taskRewardState != ERegressRewardState.Reached)
			{
				base.GetItem(2).SetUIActive(false);
				text.SetUIActive(false);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Recall_task_new_Finish01", Array.Empty<object>());
				base.GetText(8).SetText("", true);
			}
			else if (firstShowQuestByType != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "RecallActivity_Recommended_Role", new <>z__ReadOnlySingleElementList<object>(firstShowQuestByType.Name));
			}
			else if (firstShowRoleQuest != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "RecallActivity_Recommended_Role", new <>z__ReadOnlySingleElementList<object>(firstShowRoleQuest.Name));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "RecallActivity_Recommended_Role_Lock", Array.Empty<object>());
			}
		}
		if (taskSubType == 2)
		{
			bool flag = ModelBase<ExploreProgressModel>.Instance.IsCollectAllStageReward();
			if (flag && taskRewardState != ERegressRewardState.Reached)
			{
				base.GetItem(2).SetUIActive(false);
				text.SetUIActive(false);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Recall_task_new_Finish02", Array.Empty<object>());
			}
			else
			{
				Area? minExploreAreaInfo = ActivityRegressHelper.GetMinExploreAreaInfo();
				if (minExploreAreaInfo != null)
				{
					int deliveryMarkId = minExploreAreaInfo.Value.DeliveryMarkId;
					MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(deliveryMarkId);
					string multiText = ConfigBase<TextConfig>.Instance.GetMultiText(configMark.Value.MarkTitle, Array.Empty<string>());
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "RecallActivity_Recommended_Area", new <>z__ReadOnlySingleElementList<object>(multiText));
				}
			}
			if (flag)
			{
				base.GetText(8).SetText("", true);
			}
		}
	}

	// Token: 0x0600999E RID: 39326 RVA: 0x00283670 File Offset: 0x00281870
	private void SetupDailyTaskVisuals()
	{
		RegressQuest? config = this.Data.Config;
		int id = config.Value.Id;
		ValueTuple<int, int> taskProgressTuple = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskProgressTuple(id);
		int item = taskProgressTuple.Item1;
		int item2 = taskProgressTuple.Item2;
		UUIText text = base.GetText(3);
		text.SetUIActive(true);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
		defaultInterpolatedStringHandler.AppendLiteral("(");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
		defaultInterpolatedStringHandler.AppendLiteral(")");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.GetText(8).SetText("", true);
	}

	// Token: 0x0600999F RID: 39327 RVA: 0x00283724 File Offset: 0x00281924
	private ERegressRewardState GetTaskRewardStateForShow()
	{
		RegressQuest? config = this.Data.Config;
		int id = config.Value.Id;
		bool taskType = config.Value.TaskType != 0;
		ERegressRewardState eregressRewardState = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskRewardState(id);
		if (taskType)
		{
			return eregressRewardState;
		}
		int taskSubType = this.Data.Config.Value.TaskSubType;
		if (taskSubType == 1)
		{
			int? firstUnFinishMainQuestId = ModelBase<ActivityRegressModel>.Instance.GetFirstUnFinishMainQuestId();
			global::RoleQuest firstShowRoleQuest = ModelBase<ActivityRegressModel>.Instance.GetFirstShowRoleQuest();
			if (firstUnFinishMainQuestId == null && firstShowRoleQuest == null && eregressRewardState != ERegressRewardState.Reached)
			{
				eregressRewardState = ERegressRewardState.Claim;
			}
		}
		if (taskSubType == 2 && ModelBase<ExploreProgressModel>.Instance.IsCollectAllStageReward() && eregressRewardState != ERegressRewardState.Reached)
		{
			eregressRewardState = ERegressRewardState.Claim;
		}
		return eregressRewardState;
	}

	// Token: 0x060099A0 RID: 39328 RVA: 0x002837D4 File Offset: 0x002819D4
	private void OnConfirmBtnClick(int _)
	{
		RegressQuest? config = this.Data.Config;
		ERegressRewardState taskRewardState = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskRewardState(config.Value.Id);
		if (taskRewardState == ERegressRewardState.UnReach)
		{
			ControllerBase<ActivityRegressController>.Instance.JumpByQuestConfig(this.Data.Config.Value);
			return;
		}
		if (taskRewardState == ERegressRewardState.Reached)
		{
			if (ModelBase<ActivityRegressModel>.Instance.ActivityData.IsRegressTaskScoreOverExp())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Task_Max", Array.Empty<object>());
			}
			ControllerBase<ActivityRegressController>.Instance.RequestClaimTaskReward(config.Value.Id);
		}
	}

	// Token: 0x060099A1 RID: 39329 RVA: 0x00283870 File Offset: 0x00281A70
	[NullableContext(1)]
	private void OnExtendToggleClicked(MediumItemGridExtendCallback _)
	{
		RegressQuest? config = this.Data.Config;
		int id = ModelBase<ActivityRegressModel>.Instance.GetRegressTaskRewardItemInfo(config.Value).ItemInfo.Value.Id;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(id, true, null);
	}

	// Token: 0x040046ED RID: 18157
	private SmallItemGrid ItemGrid;

	// Token: 0x040046EE RID: 18158
	private ActivityRegressTaskDynamicData Data;

	// Token: 0x040046EF RID: 18159
	private ButtonItem ButtonItemE;

	// Token: 0x040046F0 RID: 18160
	private ButtonItem ButtonItemB;

	// Token: 0x02007925 RID: 31013
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029A05 RID: 170501
		public const int StripBtn = 0;

		// Token: 0x04029A06 RID: 170502
		public const int NameTxt = 1;

		// Token: 0x04029A07 RID: 170503
		public const int LinePanel = 2;

		// Token: 0x04029A08 RID: 170504
		public const int NumTxt = 3;

		// Token: 0x04029A09 RID: 170505
		public const int ItemBaseB = 4;

		// Token: 0x04029A0A RID: 170506
		public const int DoneSpr = 5;

		// Token: 0x04029A0B RID: 170507
		public const int DoingTxt = 6;

		// Token: 0x04029A0C RID: 170508
		public const int BtnSecConfirm = 7;

		// Token: 0x04029A0D RID: 170509
		public const int RecommendTxt = 8;

		// Token: 0x04029A0E RID: 170510
		public const int SprDone = 9;

		// Token: 0x04029A0F RID: 170511
		public const int BtnSecConfirmB = 10;
	}
}
