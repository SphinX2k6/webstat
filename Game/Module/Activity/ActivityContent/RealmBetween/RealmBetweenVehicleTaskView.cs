using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200655E RID: 25950
	[NullableContext(1)]
	[Nullable(0)]
	public class RealmBetweenVehicleTaskView : UiViewBase
	{
		// Token: 0x06040D4A RID: 265546 RVA: 0x010A0055 File Offset: 0x0109E255
		public RealmBetweenVehicleTaskView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040D4B RID: 265547 RVA: 0x010A0068 File Offset: 0x0109E268
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
		}

		// Token: 0x06040D4C RID: 265548 RVA: 0x010A0148 File Offset: 0x0109E348
		protected override UniTask OnBeforeStartAsync()
		{
			RealmBetweenVehicleTaskView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RealmBetweenVehicleTaskView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040D4D RID: 265549 RVA: 0x010A018B File Offset: 0x0109E38B
		protected override void OnStart()
		{
			this.RefreshTabList(delegate
			{
				MenuTabToggleItem scrollItemByIndex = this.MenuScroll.GetScrollItemByIndex(0);
				if (scrollItemByIndex == null)
				{
					return;
				}
				scrollItemByIndex.SetIsSelect(true, true);
			});
		}

		// Token: 0x06040D4E RID: 265550 RVA: 0x010A019F File Offset: 0x0109E39F
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RealmBetweenMotorRefresh, new Action(this.OnMotorRefresh));
		}

		// Token: 0x06040D4F RID: 265551 RVA: 0x010A01BD File Offset: 0x0109E3BD
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RealmBetweenMotorRefresh, new Action(this.OnMotorRefresh));
		}

		// Token: 0x06040D50 RID: 265552 RVA: 0x010A01DC File Offset: 0x0109E3DC
		private void OnMotorRefresh()
		{
			List<MotorChallengePlayData> allMotorTabData = this.ActivityBaseData.GetAllMotorTabData();
			MotorChallengePlayData motorChallengePlayData = (this.SelectedTabIndex >= 0 && this.SelectedTabIndex < allMotorTabData.Count) ? allMotorTabData[this.SelectedTabIndex] : null;
			this.RefreshTabList(null);
			if (motorChallengePlayData != null)
			{
				this.RefreshContent(motorChallengePlayData);
			}
		}

		// Token: 0x06040D51 RID: 265553 RVA: 0x010A022D File Offset: 0x0109E42D
		private MenuTabToggleItem OnCreateMenuItem()
		{
			return new MenuTabToggleItem
			{
				OnChildToggleCallback = new Action<MotorChallengePlayData, MenuTabToggleItem>(this.OnClickChildToggle)
			};
		}

		// Token: 0x06040D52 RID: 265554 RVA: 0x010A0246 File Offset: 0x0109E446
		private MissionToggleItem OnCreateTaskItem()
		{
			MissionToggleItem missionToggleItem = new MissionToggleItem();
			missionToggleItem.SetClickRewardCb(new Action(this.OnClickRewardCb));
			return missionToggleItem;
		}

		// Token: 0x06040D53 RID: 265555 RVA: 0x010A0260 File Offset: 0x0109E460
		private void OnClickRewardCb()
		{
			List<MotorChallengePlayData> allMotorTabData = this.ActivityBaseData.GetAllMotorTabData();
			if (this.SelectedTabIndex < 0 || this.SelectedTabIndex >= allMotorTabData.Count)
			{
				return;
			}
			MotorChallengePlayData motorChallengePlayData = allMotorTabData[this.SelectedTabIndex];
			List<int> list = new List<int>();
			foreach (ActivityTaskData activityTaskData in this.ActivityBaseData.GetMotorItemDataList(motorChallengePlayData.RewardIds))
			{
				if (activityTaskData.Status == EActivityTaskState.FinishedAndUnclaimed)
				{
					list.Add(activityTaskData.Id);
				}
			}
			ControllerBase<ActivityRealmBetweenController>.Instance.RequestMultiMotorChallengeReward(list.ToArray());
		}

		// Token: 0x06040D54 RID: 265556 RVA: 0x010A0318 File Offset: 0x0109E518
		private void OnClickChildToggle(MotorChallengePlayData tabData, MenuTabToggleItem tabItem)
		{
			if (this.SelectChildToggle != null)
			{
				this.SelectChildToggle.SetIsSelect(false, false);
			}
			this.SelectChildToggle = tabItem;
			this.SelectChildToggle.SetIsSelect(true, false);
			if (this.SelectedTabIndex == tabData.TabIndex)
			{
				return;
			}
			this.SelectedTabIndex = tabData.TabIndex;
			if (tabData.IsUnlock && !this.ActivityBaseData.SaveFirstCheckRedDotState(ERealmBetweenSaveFlag.MotorChallengeNewUnlock, tabData.TabIndex))
			{
				tabItem.SetItemNewVisible(false);
			}
			this.RefreshContent(tabData);
		}

		// Token: 0x06040D55 RID: 265557 RVA: 0x010A0394 File Offset: 0x0109E594
		[NullableContext(2)]
		private void RefreshTabList(Action onComplete = null)
		{
			List<MotorChallengePlayData> list = new List<MotorChallengePlayData>(this.ActivityBaseData.GetAllMotorTabData());
			list.Sort(delegate(MotorChallengePlayData a, MotorChallengePlayData b)
			{
				if (a.IsFinished == b.IsFinished)
				{
					return a.TabIndex - b.TabIndex;
				}
				if (!a.IsFinished)
				{
					return -1;
				}
				return 1;
			});
			this.MenuScroll.RefreshByData(list, onComplete, false);
		}

		// Token: 0x06040D56 RID: 265558 RVA: 0x010A03E8 File Offset: 0x0109E5E8
		private void RefreshContent(MotorChallengePlayData tabData)
		{
			bool isUnlock = tabData.IsUnlock;
			List<ActivityTaskData> data = isUnlock ? this.ActivityBaseData.GetMotorItemDataList(tabData.RewardIds) : new List<ActivityTaskData>();
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(!isUnlock);
			}
			if (!isUnlock)
			{
				UUIText text = base.GetText(6);
				if (text != null)
				{
					text.ShowTextNew(this.ActivityBaseData.GetMotorPlayLockTips(tabData.PlayId));
				}
			}
			UUIItem item2 = base.GetItem(7);
			if (item2 != null)
			{
				item2.SetUIActive(isUnlock);
			}
			this.TaskScroll.RefreshByData(data, null, true);
		}

		// Token: 0x06040D57 RID: 265559 RVA: 0x010A0478 File Offset: 0x0109E678
		private void OnClickBtnJump()
		{
			foreach (MotorChallengePlayData motorChallengePlayData in this.ActivityBaseData.GetAllMotorTabData())
			{
				if (motorChallengePlayData.TabIndex == this.SelectedTabIndex)
				{
					SkipTaskManager.RunByConfigId(motorChallengePlayData.JumpId, null);
					break;
				}
			}
		}

		// Token: 0x06040D58 RID: 265560 RVA: 0x010A04E8 File Offset: 0x0109E6E8
		private void OnClickHelpBtn()
		{
			if (this.ActivityBaseData.LocalConfig != null)
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(this.ActivityBaseData.LocalConfig.Value.HelpId);
			}
		}

		// Token: 0x04024615 RID: 149013
		[Nullable(2)]
		private PopupCaptionItem CaptionComponent;

		// Token: 0x04024616 RID: 149014
		private ActivityRealmBetweenData ActivityBaseData;

		// Token: 0x04024617 RID: 149015
		private GenericScrollViewNew<MenuTabToggleItem, MotorChallengePlayData> MenuScroll;

		// Token: 0x04024618 RID: 149016
		private GenericScrollViewNew<MissionToggleItem, ActivityTaskData> TaskScroll;

		// Token: 0x04024619 RID: 149017
		private int SelectedTabIndex = -1;

		// Token: 0x0402461A RID: 149018
		[Nullable(2)]
		private MenuTabToggleItem SelectChildToggle;

		// Token: 0x0402461B RID: 149019
		private ActivityButtonItem BtnJump;
	}
}
