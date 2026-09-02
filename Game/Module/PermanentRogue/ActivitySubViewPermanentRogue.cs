using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005668 RID: 22120
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySubViewPermanentRogue : ActivitySubViewBase
	{
		// Token: 0x1700909B RID: 37019
		// (get) Token: 0x0603860F RID: 230927 RVA: 0x00E460F8 File Offset: 0x00E442F8
		protected new ActivityPermanentRogueData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as ActivityPermanentRogueData;
			}
		}

		// Token: 0x06038610 RID: 230928 RVA: 0x00E46108 File Offset: 0x00E44308
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUITexture)),
				new ValueTuple<int, Type>(8, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickedHelp))
			};
		}

		// Token: 0x06038611 RID: 230929 RVA: 0x00E46238 File Offset: 0x00E44438
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySubViewPermanentRogue.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewPermanentRogue.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038612 RID: 230930 RVA: 0x00E4627B File Offset: 0x00E4447B
		protected override void OnStart()
		{
			this.ActivityInfoComp.SetBtnText("PrefabTextItem_632974650_Text", Array.Empty<object>());
		}

		// Token: 0x06038613 RID: 230931 RVA: 0x00E46294 File Offset: 0x00E44494
		protected override void OnRefreshView()
		{
			this.NewSeasonId = ModelBase<ActivityPermanentRogueModel>.Instance.GetNewSeasonId();
			bool functionRedDotVisible = ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData().CheckAllRightSideRedDot();
			RogueResActivitySubViewGeneralInfo activityInfoComp = this.ActivityInfoComp;
			if (activityInfoComp != null)
			{
				activityInfoComp.SetFunctionRedDotVisible(functionRedDotVisible);
			}
			this.RefreshBtn();
			this.BindRedDot();
			this.RefreshChallenge();
			RogueResTheme value = ConfigRogueResThemeById.GetConfig(this.NewSeasonId, true).Value;
			RogueResActivitySubViewGeneralInfo activityInfoComp2 = this.ActivityInfoComp;
			if (activityInfoComp2 != null)
			{
				activityInfoComp2.SetSubTitleTextById(value.Name);
			}
			RogueResTheme value2 = ConfigRogueResThemeById.GetConfig(this.NewSeasonId, true).Value;
			string path = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? value2.CoverF : value2.CoverM;
			base.SetTextureByPath(path, base.GetTexture(7), null, null);
			base.GetSpine(8).SetAnimation(0, ESpineAnimation.Idle.ToString(), true);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
			if (!this.ActivityBaseData.SaveFirstCheckRedDotState(EPermanentRogueSaveFlag.FirstOpen))
			{
				this.OnClickedHelp();
			}
		}

		// Token: 0x06038614 RID: 230932 RVA: 0x00E463AD File Offset: 0x00E445AD
		protected override void OnBeforeHide()
		{
			this.UnbindRedDot();
		}

		// Token: 0x06038615 RID: 230933 RVA: 0x00E463B5 File Offset: 0x00E445B5
		protected override void OnBeforeDestroy()
		{
			this.ActivityInfoComp = null;
			this.BtnRogueA = null;
			this.BtnRogueB = null;
		}

		// Token: 0x06038616 RID: 230934 RVA: 0x00E463CC File Offset: 0x00E445CC
		protected override void OnAddEventListener()
		{
		}

		// Token: 0x06038617 RID: 230935 RVA: 0x00E463CE File Offset: 0x00E445CE
		protected override void OnRemoveEventListener()
		{
		}

		// Token: 0x06038618 RID: 230936 RVA: 0x00E463D0 File Offset: 0x00E445D0
		private void OnClickEnterFunc(ActivityBaseData _)
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			RogueResTheme value = ConfigRogueResThemeById.GetConfig(this.NewSeasonId, true).Value;
			Singleton<UiManager>.Instance.OpenView((EUiViewName)value.ViewName, this.NewSeasonId, null);
		}

		// Token: 0x06038619 RID: 230937 RVA: 0x00E46444 File Offset: 0x00E44644
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

		// Token: 0x0603861A RID: 230938 RVA: 0x00E46498 File Offset: 0x00E44698
		private unsafe void OnClickShop()
		{
			if (ModelBase<ActivityPermanentRogueModel>.Instance.CheckShopRedDot(this.NewSeasonId))
			{
				ModelBase<ActivityPermanentRogueModel>.Instance.RefreshShopRedDot(this.NewSeasonId);
			}
			int shopId = ConfigRogueResThemeById.GetConfig(this.NewSeasonId, true).Value.ShopId;
			PayShopViewData payShopViewData = new PayShopViewData();
			payShopViewData.PayShopId = (PayShopDefine.EPayShopTabType)shopId;
			PayShopViewData payShopViewData2 = payShopViewData;
			int num = 1;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list, num);
			Span<int> span = CollectionsMarshal.AsSpan<int>(list);
			int index = 0;
			*span[index] = shopId;
			payShopViewData2.ShowShopIdList = list;
			ControllerBase<PayShopController>.Instance.OpenPayShopView(payShopViewData, delegate(bool _, int _)
			{
				int[] shopCount = ModelBase<ActivityPermanentRogueModel>.Instance.GetShopCount(this.NewSeasonId);
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

		// Token: 0x0603861B RID: 230939 RVA: 0x00E46538 File Offset: 0x00E44738
		private void BindRedDot()
		{
			RogueButtonItemA btnRogueA = this.BtnRogueA;
			if (btnRogueA != null)
			{
				btnRogueA.BindRedDot(ERedDotName.RogueResTask, null);
			}
			RogueButtonItemA btnRogueB = this.BtnRogueB;
			if (btnRogueB == null)
			{
				return;
			}
			btnRogueB.BindRedDot(ERedDotName.RogueResShop, new int?(this.NewSeasonId));
		}

		// Token: 0x0603861C RID: 230940 RVA: 0x00E46584 File Offset: 0x00E44784
		private void UnbindRedDot()
		{
			RogueButtonItemA btnRogueA = this.BtnRogueA;
			if (btnRogueA != null)
			{
				btnRogueA.UnBindRedDot();
			}
			RogueButtonItemA btnRogueB = this.BtnRogueB;
			if (btnRogueB == null)
			{
				return;
			}
			btnRogueB.UnBindRedDot();
		}

		// Token: 0x0603861D RID: 230941 RVA: 0x00E465A8 File Offset: 0x00E447A8
		private void RefreshBtn()
		{
			ActivityPermanentRogueModel instance = ModelBase<ActivityPermanentRogueModel>.Instance;
			bool flag = this.ActivityBaseData.IsUnLock();
			bool preGuideQuestFinishState = this.ActivityBaseData.GetPreGuideQuestFinishState();
			if (flag && preGuideQuestFinishState)
			{
				int[] taskCount = instance.GetTaskCount();
				bool taskIsEnd = instance.GetTaskIsEnd();
				UUIItem item = base.GetItem(9);
				if (item != null)
				{
					item.SetUIActive(!taskIsEnd);
				}
				RogueButtonItemA btnRogueA = this.BtnRogueA;
				if (btnRogueA != null)
				{
					btnRogueA.SetUiActive(!taskIsEnd);
				}
				RogueButtonItemA btnRogueA2 = this.BtnRogueA;
				if (btnRogueA2 != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(taskCount[0]);
					defaultInterpolatedStringHandler.AppendLiteral("/");
					defaultInterpolatedStringHandler.AppendFormatted<int>(taskCount[1]);
					btnRogueA2.SetNum(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				RogueButtonItemA btnRogueB = this.BtnRogueB;
				if (btnRogueB != null)
				{
					btnRogueB.SetUiActive(true);
				}
				int[] shopCount = instance.GetShopCount(this.NewSeasonId);
				RogueButtonItemA btnRogueB2 = this.BtnRogueB;
				if (btnRogueB2 != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(shopCount[0]);
					defaultInterpolatedStringHandler.AppendLiteral("/");
					defaultInterpolatedStringHandler.AppendFormatted<int>(shopCount[1]);
					btnRogueB2.SetNum(defaultInterpolatedStringHandler.ToStringAndClear());
				}
			}
			else
			{
				RogueButtonItemA btnRogueA3 = this.BtnRogueA;
				if (btnRogueA3 != null)
				{
					btnRogueA3.SetUiActive(false);
				}
				RogueButtonItemA btnRogueB3 = this.BtnRogueB;
				if (btnRogueB3 != null)
				{
					btnRogueB3.SetUiActive(false);
				}
			}
			RogueResActivitySubViewGeneralInfo activityInfoComp = this.ActivityInfoComp;
			ActivityFunctionalTypeA activityFunctionalTypeA = (activityInfoComp != null) ? activityInfoComp.GetFunctional() : null;
			if (activityFunctionalTypeA == null)
			{
				return;
			}
			ActivityButtonItem functionButton = activityFunctionalTypeA.FunctionButton;
			if (functionButton == null)
			{
				return;
			}
			functionButton.SetUiActive(flag);
		}

		// Token: 0x0603861E RID: 230942 RVA: 0x00E4670C File Offset: 0x00E4490C
		private void RefreshChallenge()
		{
			bool flag = this.ActivityBaseData.IsUnLock();
			bool preGuideQuestFinishState = this.ActivityBaseData.GetPreGuideQuestFinishState();
			if (flag && preGuideQuestFinishState)
			{
				UUIItem item = base.GetItem(4);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				int latestDungeonIndex = ModelBase<ActivityPermanentRogueModel>.Instance.GetLatestDungeonIndex(this.NewSeasonId);
				base.GetItem(6).SetUIActive(false);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "PrefabTextItem_2589264504_Text", new <>z__ReadOnlySingleElementList<object>(latestDungeonIndex + 1));
				return;
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x0603861F RID: 230943 RVA: 0x00E4679C File Offset: 0x00E4499C
		private void OnClickedHelp()
		{
			int? seasonHelpId = ModelBase<ActivityPermanentRogueModel>.Instance.GetSeasonHelpId(this.NewSeasonId);
			if (seasonHelpId != null && seasonHelpId.GetValueOrDefault() != 0)
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(seasonHelpId.Value);
			}
		}

		// Token: 0x06038620 RID: 230944 RVA: 0x00E467E0 File Offset: 0x00E449E0
		protected void OnTimer(int gap)
		{
			if (!ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskIsEnd())
			{
				UUIItem item = base.GetItem(9);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				RogueButtonItemA btnRogueA = this.BtnRogueA;
				if (btnRogueA == null)
				{
					return;
				}
				btnRogueA.SetLimitTime(this.GetRemainTime());
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(9);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x06038621 RID: 230945 RVA: 0x00E46838 File Offset: 0x00E44A38
		[NullableContext(1)]
		protected string GetRemainTime()
		{
			long taskEndTime = ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskEndTime();
			return ModelBase<ActivityModel>.Instance.GetRemainTimeText(taskEndTime, "{0}");
		}

		// Token: 0x04020276 RID: 131702
		private RogueResActivitySubViewGeneralInfo ActivityInfoComp;

		// Token: 0x04020277 RID: 131703
		private RogueButtonItemA BtnRogueA;

		// Token: 0x04020278 RID: 131704
		private RogueButtonItemA BtnRogueB;

		// Token: 0x04020279 RID: 131705
		private int NewSeasonId;
	}
}
