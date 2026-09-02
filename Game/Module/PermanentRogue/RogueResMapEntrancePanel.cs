using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.SubViews;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200568B RID: 22155
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueResMapEntrancePanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x1700909C RID: 37020
		// (get) Token: 0x06038700 RID: 231168 RVA: 0x00E4B738 File Offset: 0x00E49938
		private InstanceDungeonEntrance? EntranceConfig
		{
			get
			{
				int? num = (this.EntranceId != 0) ? new int?(ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetEntranceIdByMarkId(this.EntranceId)) : null;
				if (num == null)
				{
					return null;
				}
				return ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(num.Value);
			}
		}

		// Token: 0x06038701 RID: 231169 RVA: 0x00E4B792 File Offset: 0x00E49992
		public override string GetResourceId()
		{
			return "UiView_InstanceEntranceTip_Prefab";
		}

		// Token: 0x06038702 RID: 231170 RVA: 0x00E4B799 File Offset: 0x00E49999
		[NullableContext(2)]
		public override UUIItem GetGuideFocusUiItem()
		{
			return base.GetButton(11).GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
		}

		// Token: 0x06038703 RID: 231171 RVA: 0x00E4B7BC File Offset: 0x00E499BC
		protected override UniTask OnBeforeStartAsync()
		{
			RogueResMapEntrancePanel.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueResMapEntrancePanel.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038704 RID: 231172 RVA: 0x00E4B800 File Offset: 0x00E49A00
		protected override void OnStart()
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(5);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(true);
			}
			this.InstanceCostTipView = new GenericLayoutAdd<InstanceDungeonCostTip>(base.GetVerticalLayout(5), new TLayoutRefresh<InstanceDungeonCostTip>(this.OnInstanceRefresh));
			base.OnStart();
		}

		// Token: 0x06038705 RID: 231173 RVA: 0x00E4B851 File Offset: 0x00E49A51
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			base.GetItem(32).SetUIActive(false);
		}

		// Token: 0x06038706 RID: 231174 RVA: 0x00E4B867 File Offset: 0x00E49A67
		protected override void OnBeforeDestroy()
		{
			this.InstanceCostTipView.ClearChildren();
			if (this.TimerId != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x06038707 RID: 231175 RVA: 0x00E4B894 File Offset: 0x00E49A94
		protected ILayoutItem<InstanceDungeonCostTip> OnInstanceRefresh(object data, UUIItem uiItem, int index, int originalItemIndex)
		{
			InstanceDungeonCostTip instanceDungeonCostTip = new InstanceDungeonCostTip();
			instanceDungeonCostTip.SetRootActor(uiItem.GetOwner(), true);
			return new LayoutItem<InstanceDungeonCostTip>
			{
				Key = data,
				Value = instanceDungeonCostTip
			};
		}

		// Token: 0x06038708 RID: 231176 RVA: 0x00E4B8C8 File Offset: 0x00E49AC8
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				TeleportMarkItem teleportMarkItem = param[0] as TeleportMarkItem;
				if (teleportMarkItem != null)
				{
					this.SelectedMarkItem = teleportMarkItem;
					this.LayoutContext.MarkItem = teleportMarkItem;
					this.EntranceId = this.SelectedMarkItem.MarkConfigId;
					if (this.EntranceId == 0)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.InstanceDungeon;
						ELogAuthor author = ELogAuthor.WHJ;
						string message = "副本入口弹窗打开错误，副本入口表中找不到对应的地图标记Id！";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", teleportMarkItem.MarkConfigId);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return;
					}
					this.InitView();
					this.UpdateInstanceList();
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					int unLockCondition = this.EntranceConfig.Value.UnLockCondition;
					if (unLockCondition != 0 && !ModelBase<FunctionModel>.Instance.IsOpen(unLockCondition))
					{
						FunctionCondition? functionCondition = ConfigBase<FunctionConfig>.Instance.GetFunctionCondition(unLockCondition);
						ConditionGroup? conditionGroupConfig = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(functionCondition.Value.OpenConditionId);
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), conditionGroupConfig.Value.HintText, Array.Empty<object>());
					}
				}
			}
		}

		// Token: 0x06038709 RID: 231177 RVA: 0x00E4B9E2 File Offset: 0x00E49BE2
		protected override void OnCloseWorldMapSecondaryUi()
		{
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView == null)
			{
				return;
			}
			instanceCostTipView.ClearChildren();
		}

		// Token: 0x0603870A RID: 231178 RVA: 0x00E4B9F4 File Offset: 0x00E49BF4
		protected string GetRemainTime()
		{
			long endTime = Singleton<MathUtils>.Instance.LongToNumber(ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskEndTime());
			return ModelBase<ActivityModel>.Instance.GetRemainTimeText(endTime, this.RemainTimeText) ?? "";
		}

		// Token: 0x0603870B RID: 231179 RVA: 0x00E4BA30 File Offset: 0x00E49C30
		private void InitView()
		{
			InstanceDungeonEntrance? entranceConfig = this.EntranceConfig;
			if (entranceConfig == null)
			{
				return;
			}
			base.GetText(4).ShowTextNew(entranceConfig.Value.Description);
			WorldMapSecondaryUiLayoutHelper.UpdateIcon(this.LayoutContext);
			base.GetText(1).ShowTextNew(entranceConfig.Value.Name);
			WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
			base.GetItem(9).SetUIActive(!this.SelectedMarkItem.IsFogUnlock);
			base.GetText(10).ShowTextNew("Instance_Dungeon_Rcommand_Text");
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(36), "Instance_RogueInstanceEntrance_Progress", Array.Empty<object>());
			bool flag = base.UpdateQuickGoto();
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext == null)
			{
				return;
			}
			layoutContext.SetConfirmBtnActive(!flag);
		}

		// Token: 0x0603870C RID: 231180 RVA: 0x00E4BB00 File Offset: 0x00E49D00
		private void RefreshReward()
		{
			List<TItem> previewReward = ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData().GetPreviewReward(null);
			if (previewReward.Count == 0)
			{
				base.GetItem(8).SetUIActive(false);
				return;
			}
			List<TItem> list = (previewReward.Count > 5) ? previewReward.GetRange(0, 5) : previewReward;
			for (int i = 0; i < list.Count; i++)
			{
				TItem value = list[i];
				value.Count = 0;
				list[i] = value;
			}
			base.GetItem(8).SetUIActive(true);
			this.RewardsView.RebuildRewardsByData(list);
		}

		// Token: 0x0603870D RID: 231181 RVA: 0x00E4BB98 File Offset: 0x00E49D98
		private void UpdateInstanceList()
		{
			this.RefreshReward();
			if (!ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskIsEnd())
			{
				this.RefreshTimeItem();
				this.RefreshTaskItem();
				if (this.TimerId != null)
				{
					TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
				}
				this.TimerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float delta)
				{
					this.RefreshTimeItem();
				}, 1000f, 1f, null, null, true);
			}
			this.RefreshInstItem();
			this.RefreshShopProgressItem();
		}

		// Token: 0x0603870E RID: 231182 RVA: 0x00E4BC14 File Offset: 0x00E49E14
		private void RefreshTimeItem()
		{
			if (ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData() != null)
			{
				InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.GetLayoutItemByKey("rogueTime", 0) as InstanceDungeonCostTip;
				if (instanceDungeonCostTip == null)
				{
					this.InstanceCostTipView.AddItemToLayout(new object[]
					{
						"rogueTime"
					}, 0);
					instanceDungeonCostTip = (this.InstanceCostTipView.GetLayoutItemByKey("rogueTime", 0) as InstanceDungeonCostTip);
				}
				instanceDungeonCostTip.SetIconVisible(false);
				instanceDungeonCostTip.SetStarVisible(false);
				string remainTime = this.GetRemainTime();
				instanceDungeonCostTip.SetRightText(remainTime);
				string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("RogueRes_MapNote_4", null) ?? "", new string[]
				{
					""
				});
				instanceDungeonCostTip.SetLeftText(leftText);
				instanceDungeonCostTip.SetHelpButtonVisible(false);
			}
		}

		// Token: 0x0603870F RID: 231183 RVA: 0x00E4BCD0 File Offset: 0x00E49ED0
		private void RefreshInstItem()
		{
			if (ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData() != null)
			{
				InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.GetLayoutItemByKey("rougeProgress", 0) as InstanceDungeonCostTip;
				if (instanceDungeonCostTip == null)
				{
					this.InstanceCostTipView.AddItemToLayout(new object[]
					{
						"rougeProgress"
					}, 0);
					instanceDungeonCostTip = (this.InstanceCostTipView.GetLayoutItemByKey("rougeProgress", 0) as InstanceDungeonCostTip);
				}
				instanceDungeonCostTip.SetIconVisible(false);
				instanceDungeonCostTip.SetStarVisible(false);
				int newSeasonId = ModelBase<ActivityPermanentRogueModel>.Instance.GetNewSeasonId();
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigRogueResDungeonConfigById.GetConfig(ModelBase<ActivityPermanentRogueModel>.Instance.GetLatestDungeon(newSeasonId), true).Value.Title, null);
				instanceDungeonCostTip.SetRightText(localTextNew);
				string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("RogueRes_MapNote_1", null) ?? "", new string[]
				{
					""
				});
				instanceDungeonCostTip.SetLeftText(leftText);
				instanceDungeonCostTip.SetHelpButtonVisible(false);
			}
		}

		// Token: 0x06038710 RID: 231184 RVA: 0x00E4BDB8 File Offset: 0x00E49FB8
		private void RefreshTaskItem()
		{
			if (ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData() != null)
			{
				InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.GetLayoutItemByKey("rougeTask", 0) as InstanceDungeonCostTip;
				if (instanceDungeonCostTip == null)
				{
					this.InstanceCostTipView.AddItemToLayout(new object[]
					{
						"rougeTask"
					}, 0);
					instanceDungeonCostTip = (this.InstanceCostTipView.GetLayoutItemByKey("rougeTask", 0) as InstanceDungeonCostTip);
				}
				instanceDungeonCostTip.SetIconVisible(false);
				instanceDungeonCostTip.SetStarVisible(false);
				int[] taskCount = ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskCount();
				InstanceDungeonCostTip instanceDungeonCostTip2 = instanceDungeonCostTip;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(taskCount[0]);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(taskCount[1]);
				instanceDungeonCostTip2.SetRightText(defaultInterpolatedStringHandler.ToStringAndClear());
				string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("RogueRes_MapNote_2", null) ?? "", new string[]
				{
					""
				});
				instanceDungeonCostTip.SetLeftText(leftText);
				instanceDungeonCostTip.SetHelpButtonVisible(false);
			}
		}

		// Token: 0x06038711 RID: 231185 RVA: 0x00E4BEA4 File Offset: 0x00E4A0A4
		private void RefreshShopProgressItem()
		{
			if (ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData() != null)
			{
				this.InstanceCostTipView.AddItemToLayout(new object[]
				{
					"rougeScore"
				}, 0);
				InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.GetLayoutItemByKey("rougeScore", 0) as InstanceDungeonCostTip;
				instanceDungeonCostTip.SetIconVisible(false);
				instanceDungeonCostTip.SetStarVisible(false);
				int newSeasonId = ModelBase<ActivityPermanentRogueModel>.Instance.GetNewSeasonId();
				int[] shopCount = ModelBase<ActivityPermanentRogueModel>.Instance.GetShopCount(newSeasonId);
				string inString = ConfigMultiTextLang.GetLocalTextNew("Text_Weekly_Rogue_Score", null) ?? "{0}";
				string[] array = new string[1];
				int num = 0;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(shopCount[0]);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(shopCount[1]);
				array[num] = defaultInterpolatedStringHandler.ToStringAndClear();
				string rightText = StringUtils.Format(inString, array);
				instanceDungeonCostTip.SetRightText(rightText);
				string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("RogueRes_MapNote_3", null) ?? "", new string[]
				{
					""
				});
				instanceDungeonCostTip.SetLeftText(leftText);
				instanceDungeonCostTip.SetHelpButtonVisible(false);
			}
		}

		// Token: 0x04020352 RID: 131922
		[Nullable(2)]
		protected RewardItemBar RewardsView;

		// Token: 0x04020353 RID: 131923
		private int EntranceId;

		// Token: 0x04020354 RID: 131924
		[Nullable(2)]
		private TeleportMarkItem SelectedMarkItem;

		// Token: 0x04020355 RID: 131925
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutAdd<InstanceDungeonCostTip> InstanceCostTipView;

		// Token: 0x04020356 RID: 131926
		[Nullable(2)]
		private TimerHandle TimerId;

		// Token: 0x04020357 RID: 131927
		private readonly string RemainTimeText = "{0}";

		// Token: 0x04020358 RID: 131928
		private const string ROGUE_SCORE_KEY = "rougeScore";

		// Token: 0x04020359 RID: 131929
		private const string ROGUE_TASK = "rougeTask";

		// Token: 0x0402035A RID: 131930
		private const string ROGUE_PROGRESS = "rougeProgress";

		// Token: 0x0402035B RID: 131931
		private const string ROGUE_TIME = "rogueTime";
	}
}
