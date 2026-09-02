using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x020056A4 RID: 22180
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueSeasonEntranceView : UiTickViewBase
	{
		// Token: 0x06038765 RID: 231269 RVA: 0x00E4DF04 File Offset: 0x00E4C104
		[NullableContext(1)]
		public RogueSeasonEntranceView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038766 RID: 231270 RVA: 0x00E4DF10 File Offset: 0x00E4C110
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUITexture)),
				new ValueTuple<int, Type>(14, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickHelpInfo)),
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickCancel)),
				new ValueTuple<int, Delegate>(11, new Action(this.OnClickEntry)),
				new ValueTuple<int, Delegate>(12, new Action(this.OnClickTrial))
			};
		}

		// Token: 0x06038767 RID: 231271 RVA: 0x00E4E15C File Offset: 0x00E4C35C
		protected override UniTask OnBeforeStartAsync()
		{
			RogueSeasonEntranceView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueSeasonEntranceView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038768 RID: 231272 RVA: 0x00E4E1A0 File Offset: 0x00E4C3A0
		protected UniTask CheckDungeonProgress()
		{
			RogueSeasonEntranceView.<CheckDungeonProgress>d__12 <CheckDungeonProgress>d__;
			<CheckDungeonProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckDungeonProgress>d__.<>4__this = this;
			<CheckDungeonProgress>d__.<>1__state = -1;
			<CheckDungeonProgress>d__.<>t__builder.Start<RogueSeasonEntranceView.<CheckDungeonProgress>d__12>(ref <CheckDungeonProgress>d__);
			return <CheckDungeonProgress>d__.<>t__builder.Task;
		}

		// Token: 0x06038769 RID: 231273 RVA: 0x00E4E1E4 File Offset: 0x00E4C3E4
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickBack));
			this.CaptionItem.SetTitleTextActive(false);
			this.CaptionItem.SetTitleIconVisible(false);
			this.CaptionItem.SetHelpBtnActive(false);
			long trailEndTime = ModelBase<ActivityPermanentRogueModel>.Instance.GetTrailEndTime(this.SeasonId);
			long cacheTrailOpen = ModelBase<ActivityPermanentRogueModel>.Instance.GetCacheTrailOpen(this.SeasonId);
			UUIItem item = base.GetItem(15);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(trailEndTime != cacheTrailOpen);
		}

		// Token: 0x0603876A RID: 231274 RVA: 0x00E4E27C File Offset: 0x00E4C47C
		protected override void OnBeforeShow()
		{
			RogueResTheme? config = ConfigRogueResThemeById.GetConfig(this.SeasonId, true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), config.Value.Name, Array.Empty<object>());
			this.RefreshButton();
			this.BindRedDot();
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RogueResInst, base.GetItem(16), null, this.SeasonId);
		}

		// Token: 0x0603876B RID: 231275 RVA: 0x00E4E2E8 File Offset: 0x00E4C4E8
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			RogueSeasonEntranceView.<OnBeforeShowAsyncImplement>d__15 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<RogueSeasonEntranceView.<OnBeforeShowAsyncImplement>d__15>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603876C RID: 231276 RVA: 0x00E4E32B File Offset: 0x00E4C52B
		protected override void OnBeforeHide()
		{
			this.UnbindRedDot();
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RogueResInst, base.GetItem(16), 0);
		}

		// Token: 0x0603876D RID: 231277 RVA: 0x00E4E34B File Offset: 0x00E4C54B
		protected override void OnBeforeDestroy()
		{
			this.CaptionItem = null;
			this.IllustratedBtnComp = null;
			this.TaskBtnComp = null;
			this.ShopBtnComp = null;
			this.SkillTreeBtnComp = null;
			this.EndingBtnComp = null;
		}

		// Token: 0x0603876E RID: 231278 RVA: 0x00E4E377 File Offset: 0x00E4C577
		protected override void OnAddEventListener()
		{
		}

		// Token: 0x0603876F RID: 231279 RVA: 0x00E4E379 File Offset: 0x00E4C579
		protected override void OnRemoveEventListener()
		{
		}

		// Token: 0x06038770 RID: 231280 RVA: 0x00E4E37C File Offset: 0x00E4C57C
		protected override void OnTick(float delta)
		{
			bool taskIsEnd = ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskIsEnd();
			UUIItem item = base.GetItem(18);
			if (item != null)
			{
				item.SetUIActive(!taskIsEnd);
			}
			if (!taskIsEnd)
			{
				RogueButtonItemA taskBtnComp = this.TaskBtnComp;
				if (taskBtnComp == null)
				{
					return;
				}
				taskBtnComp.SetLimitTime(this.GetRemainTime());
			}
		}

		// Token: 0x06038771 RID: 231281 RVA: 0x00E4E3C4 File Offset: 0x00E4C5C4
		[NullableContext(1)]
		protected string GetRemainTime()
		{
			long endTime = Singleton<MathUtils>.Instance.LongToNumber(ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskEndTime());
			return ModelBase<ActivityModel>.Instance.GetRemainTimeText(endTime, "{0}") ?? "";
		}

		// Token: 0x06038772 RID: 231282 RVA: 0x00E4E3FF File Offset: 0x00E4C5FF
		private void OnClickBack()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038773 RID: 231283 RVA: 0x00E4E408 File Offset: 0x00E4C608
		private void OnClickHelpInfo()
		{
			int? seasonHelpId = ModelBase<ActivityPermanentRogueModel>.Instance.GetSeasonHelpId(this.SeasonId);
			if (seasonHelpId != null)
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(seasonHelpId.Value);
			}
		}

		// Token: 0x06038774 RID: 231284 RVA: 0x00E4E440 File Offset: 0x00E4C640
		private void OnClickIllustrate()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueIllustratedView, null, null);
		}

		// Token: 0x06038775 RID: 231285 RVA: 0x00E4E454 File Offset: 0x00E4C654
		private void OnClickTask()
		{
			long cacheTaskOpen = ModelBase<ActivityPermanentRogueModel>.Instance.GetCacheTaskOpen();
			if (Singleton<TimeUtil>.Instance.GetServerTime() >= (double)cacheTaskOpen)
			{
				ModelBase<ActivityPermanentRogueModel>.Instance.SetCacheTaskOpen();
				Singleton<EventSystem>.Instance.Emit(EEventName.PermanentRogueRewardUpdate);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueTaskView, null, null);
		}

		// Token: 0x06038776 RID: 231286 RVA: 0x00E4E4A8 File Offset: 0x00E4C6A8
		private void OnClickShop()
		{
			if (ModelBase<ActivityPermanentRogueModel>.Instance.CheckShopRedDot(this.SeasonId))
			{
				ModelBase<ActivityPermanentRogueModel>.Instance.RefreshShopRedDot(this.SeasonId);
			}
			int shopId = ConfigRogueResThemeById.GetConfig(this.SeasonId, true).Value.ShopId;
			PayShopViewData payShopViewData = new PayShopViewData();
			payShopViewData.PayShopId = (PayShopDefine.EPayShopTabType)shopId;
			payShopViewData.ShowShopIdList = new List<int>
			{
				shopId
			};
			ControllerBase<PayShopController>.Instance.OpenPayShopView(payShopViewData, delegate(bool success, int viewId)
			{
				int[] shopCount = ModelBase<ActivityPermanentRogueModel>.Instance.GetShopCount(this.SeasonId);
				EventSystem instance = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.RefreshShopAccumulateCurrency;
				string p = "Item_Cumulative_Acquisition";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(shopCount[0]);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(shopCount[1]);
				instance.Emit<string, IReadOnlyList<string>>(name, p, new <>z__ReadOnlySingleElementList<string>(defaultInterpolatedStringHandler.ToStringAndClear()));
			});
		}

		// Token: 0x06038777 RID: 231287 RVA: 0x00E4E52A File Offset: 0x00E4C72A
		private void OnClickSkillTree()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueResSkillView, this.SeasonId, null);
		}

		// Token: 0x06038778 RID: 231288 RVA: 0x00E4E547 File Offset: 0x00E4C747
		private void OnClickAchievement()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueResEndingView, this.SeasonId, null);
		}

		// Token: 0x06038779 RID: 231289 RVA: 0x00E4E564 File Offset: 0x00E4C764
		private void OnClickCancel()
		{
			if (this.CancelDungeonClicked)
			{
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RogueResCancelDungeonConfirm);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap.Add(2, new Action(this.ClickedCancelConfirmFunc));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603877A RID: 231290 RVA: 0x00E4E5B0 File Offset: 0x00E4C7B0
		private void ClickedCancelConfirmFunc()
		{
			this.CancelDungeonClicked = true;
			ControllerBase<MapRogueController>.Instance.RequestInstResultEnd().ContinueWith(delegate()
			{
				UUIItem item = base.GetItem(10);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				this.CancelDungeonClicked = false;
				this.CurrentDungeon = new int?(0);
			});
		}

		// Token: 0x0603877B RID: 231291 RVA: 0x00E4E5D8 File Offset: 0x00E4C7D8
		private void OnClickEntry()
		{
			if (this.CancelDungeonClicked)
			{
				Singleton<Log>.Instance.Info(ELogModule.RogueBattle, ELogAuthor.WHJ, "肉鸽进度请求中，未返回。", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int? num;
			int num2;
			if (this.CurrentDungeon != null)
			{
				num = this.CurrentDungeon;
				num2 = 0;
				if (num.GetValueOrDefault() > num2 & num != null)
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RogueResDungeonContinue);
					confirmBoxDataNew.IsEscViewTriggerCallBack = false;
					confirmBoxDataNew.FunctionMap.Add(1, new Action(this.OnClickCancel));
					confirmBoxDataNew.FunctionMap.Add(2, new Action(this.OnConfirmDungeonEntry));
					ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
					return;
				}
			}
			RogueResTheme? config = ConfigRogueResThemeById.GetConfig(this.SeasonId, true);
			RogueDungeonParam rogueDungeonParam = new RogueDungeonParam();
			rogueDungeonParam.SeasonId = this.SeasonId;
			rogueDungeonParam.DungeonList = config.Value.InstsIter().ToArray<int>();
			int? cacheDungeonNewest = ModelBase<ActivityPermanentRogueModel>.Instance.GetCacheDungeonNewest(this.SeasonId);
			int latestDungeon = ModelBase<ActivityPermanentRogueModel>.Instance.GetLatestDungeon(this.SeasonId);
			num = cacheDungeonNewest;
			num2 = latestDungeon;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				ModelBase<ActivityPermanentRogueModel>.Instance.SetCacheDungeonNewest(this.SeasonId);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.PermanentRogueSeasonRedDotUpdate, this.SeasonId);
				ModelBase<ActivityPermanentRogueModel>.Instance.SetCurrentSelectedInst(latestDungeon);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueDungeonEntryView, rogueDungeonParam, null);
		}

		// Token: 0x0603877C RID: 231292 RVA: 0x00E4E748 File Offset: 0x00E4C948
		private void OnClickTrial()
		{
			UUIItem item = base.GetItem(15);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			long trailEndTime = ModelBase<ActivityPermanentRogueModel>.Instance.GetTrailEndTime(this.SeasonId);
			long cacheTrailOpen = ModelBase<ActivityPermanentRogueModel>.Instance.GetCacheTrailOpen(this.SeasonId);
			if (trailEndTime != cacheTrailOpen)
			{
				ModelBase<ActivityPermanentRogueModel>.Instance.SetCacheTrailOpen(this.SeasonId);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueResTrialView, this.SeasonId, null);
		}

		// Token: 0x0603877D RID: 231293 RVA: 0x00E4E7B8 File Offset: 0x00E4C9B8
		private void RefreshButton()
		{
			ActivityPermanentRogueModel instance = ModelBase<ActivityPermanentRogueModel>.Instance;
			RogueButtonItemA illustratedBtnComp = this.IllustratedBtnComp;
			if (illustratedBtnComp != null)
			{
				illustratedBtnComp.SetNum("");
			}
			int[] taskCount = instance.GetTaskCount();
			bool taskIsEnd = instance.GetTaskIsEnd();
			UUIItem item = base.GetItem(18);
			if (item != null)
			{
				item.SetUIActive(!taskIsEnd);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (!taskIsEnd)
			{
				RogueButtonItemA taskBtnComp = this.TaskBtnComp;
				if (taskBtnComp != null)
				{
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(taskCount[0]);
					defaultInterpolatedStringHandler.AppendLiteral("/");
					defaultInterpolatedStringHandler.AppendFormatted<int>(taskCount[1]);
					taskBtnComp.SetNum(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				RogueButtonItemA taskBtnComp2 = this.TaskBtnComp;
				if (taskBtnComp2 != null)
				{
					taskBtnComp2.SetLimitTime(this.GetRemainTime());
				}
			}
			int[] shopCount = instance.GetShopCount(this.SeasonId);
			RogueButtonItemA shopBtnComp = this.ShopBtnComp;
			if (shopBtnComp != null)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(shopCount[0]);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(shopCount[1]);
				shopBtnComp.SetNum(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			int skillTreeLevel = instance.GetSkillTreeLevel(this.SeasonId);
			RogueButtonItemA skillTreeBtnComp = this.SkillTreeBtnComp;
			if (skillTreeBtnComp != null)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Lv.");
				defaultInterpolatedStringHandler.AppendFormatted<int>(skillTreeLevel);
				skillTreeBtnComp.SetNum(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			int[] endingCount = instance.GetEndingCount(this.SeasonId);
			RogueButtonItemA endingBtnComp = this.EndingBtnComp;
			if (endingBtnComp == null)
			{
				return;
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(endingCount[0]);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(endingCount[1]);
			endingBtnComp.SetNum(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0603877E RID: 231294 RVA: 0x00E4E940 File Offset: 0x00E4CB40
		private void BindRedDot()
		{
			RogueButtonItemA illustratedBtnComp = this.IllustratedBtnComp;
			if (illustratedBtnComp != null)
			{
				illustratedBtnComp.BindRedDot(ERedDotName.RogueResIllustrated, null);
			}
			RogueButtonItemA taskBtnComp = this.TaskBtnComp;
			if (taskBtnComp != null)
			{
				taskBtnComp.BindRedDot(ERedDotName.RogueResTask, null);
			}
			RogueButtonItemA shopBtnComp = this.ShopBtnComp;
			if (shopBtnComp != null)
			{
				shopBtnComp.BindRedDot(ERedDotName.RogueResShop, new int?(this.SeasonId));
			}
			RogueButtonItemA skillTreeBtnComp = this.SkillTreeBtnComp;
			if (skillTreeBtnComp != null)
			{
				skillTreeBtnComp.BindRedDot(ERedDotName.RogueResSkillTree, new int?(this.SeasonId));
			}
			RogueButtonItemA endingBtnComp = this.EndingBtnComp;
			if (endingBtnComp == null)
			{
				return;
			}
			endingBtnComp.BindRedDot(ERedDotName.RogueResEnding, new int?(this.SeasonId));
		}

		// Token: 0x0603877F RID: 231295 RVA: 0x00E4E9F0 File Offset: 0x00E4CBF0
		private void UnbindRedDot()
		{
			RogueButtonItemA illustratedBtnComp = this.IllustratedBtnComp;
			if (illustratedBtnComp != null)
			{
				illustratedBtnComp.UnBindRedDot();
			}
			RogueButtonItemA taskBtnComp = this.TaskBtnComp;
			if (taskBtnComp != null)
			{
				taskBtnComp.UnBindRedDot();
			}
			RogueButtonItemA shopBtnComp = this.ShopBtnComp;
			if (shopBtnComp != null)
			{
				shopBtnComp.UnBindRedDot();
			}
			RogueButtonItemA endingBtnComp = this.EndingBtnComp;
			if (endingBtnComp != null)
			{
				endingBtnComp.UnBindRedDot();
			}
			RogueButtonItemA skillTreeBtnComp = this.SkillTreeBtnComp;
			if (skillTreeBtnComp == null)
			{
				return;
			}
			skillTreeBtnComp.UnBindRedDot();
		}

		// Token: 0x06038780 RID: 231296 RVA: 0x00E4EA51 File Offset: 0x00E4CC51
		private void OnConfirmDungeonEntry()
		{
			(ActivityManager.GetActivityController(ActivityType.RogueRes) as ActivityPermanentRogueController).RequestEnterDungeon(this.CurrentDungeon.Value);
		}

		// Token: 0x040203D9 RID: 132057
		private PopupCaptionItem CaptionItem;

		// Token: 0x040203DA RID: 132058
		private int SeasonId;

		// Token: 0x040203DB RID: 132059
		private RogueButtonItemA IllustratedBtnComp;

		// Token: 0x040203DC RID: 132060
		private RogueButtonItemA TaskBtnComp;

		// Token: 0x040203DD RID: 132061
		private RogueButtonItemA ShopBtnComp;

		// Token: 0x040203DE RID: 132062
		private RogueButtonItemA SkillTreeBtnComp;

		// Token: 0x040203DF RID: 132063
		private RogueButtonItemA EndingBtnComp;

		// Token: 0x040203E0 RID: 132064
		private int? CurrentDungeon;

		// Token: 0x040203E1 RID: 132065
		private bool CancelDungeonClicked;
	}
}
