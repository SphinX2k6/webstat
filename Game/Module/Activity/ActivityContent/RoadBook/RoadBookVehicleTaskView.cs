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

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064BE RID: 25790
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookVehicleTaskView : UiViewBase
	{
		// Token: 0x060409F4 RID: 264692 RVA: 0x01090ABC File Offset: 0x0108ECBC
		public RoadBookVehicleTaskView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060409F5 RID: 264693 RVA: 0x01090ACC File Offset: 0x0108ECCC
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
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(8, new Action(this.OnClickBtnJump))
			};
		}

		// Token: 0x060409F6 RID: 264694 RVA: 0x01090BD0 File Offset: 0x0108EDD0
		protected override UniTask OnBeforeStartAsync()
		{
			RoadBookVehicleTaskView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoadBookVehicleTaskView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060409F7 RID: 264695 RVA: 0x01090C13 File Offset: 0x0108EE13
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoadBookMotorRefresh, new Action(this.OnRoadBookMotorRefresh));
		}

		// Token: 0x060409F8 RID: 264696 RVA: 0x01090C31 File Offset: 0x0108EE31
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoadBookMotorRefresh, new Action(this.OnRoadBookMotorRefresh));
		}

		// Token: 0x060409F9 RID: 264697 RVA: 0x01090C50 File Offset: 0x0108EE50
		private void OnRoadBookMotorRefresh()
		{
			MotorChallengePlayData tabData = this.ActivityBaseData.GetAllMotorTabData()[this.SelectedTabIndex];
			this.RefreshTabGroup().Forget();
			this.RefreshContent(tabData);
		}

		// Token: 0x060409FA RID: 264698 RVA: 0x01090C86 File Offset: 0x0108EE86
		private TabGroupGridItem OnCreateMenuItem()
		{
			return new TabGroupGridItem
			{
				OnChildToggleCallback = new Action<MotorChallengePlayData, MenuTabToggleItem>(this.OnClickChildToggle)
			};
		}

		// Token: 0x060409FB RID: 264699 RVA: 0x01090C9F File Offset: 0x0108EE9F
		private MotorChallengeItem OnCreateTaskItem()
		{
			MotorChallengeItem motorChallengeItem = new MotorChallengeItem(this.ActivityBaseData);
			motorChallengeItem.SetClickRewardCb(new Action(this.OnClickRewardCb));
			return motorChallengeItem;
		}

		// Token: 0x060409FC RID: 264700 RVA: 0x01090CC0 File Offset: 0x0108EEC0
		private void OnClickRewardCb()
		{
			MotorChallengePlayData motorChallengePlayData = this.ActivityBaseData.GetAllMotorTabData()[this.SelectedTabIndex];
			List<int> list = new List<int>();
			foreach (ActivityTaskData activityTaskData in this.ActivityBaseData.GetMotorItemDataList(motorChallengePlayData.RewardIds))
			{
				if (activityTaskData.Status == EActivityTaskState.FinishedAndUnclaimed)
				{
					list.Add(activityTaskData.Id);
				}
			}
			ControllerBase<ActivityRoadBookController>.Instance.RequestMultiTakeMotorChallengeReward(list.ToArray());
		}

		// Token: 0x060409FD RID: 264701 RVA: 0x01090D58 File Offset: 0x0108EF58
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
			if (tabData.IsUnlock && !this.ActivityBaseData.SaveFirstCheckRedDotState(ERoadBookSaveFlag.MotorChallengeNewUnlock, tabData.TabIndex))
			{
				tabItem.SetItemNewVisible(false);
			}
			this.RefreshContent(tabData);
		}

		// Token: 0x060409FE RID: 264702 RVA: 0x01090DD4 File Offset: 0x0108EFD4
		private UniTask RefreshTabGroup()
		{
			RoadBookVehicleTaskView.<RefreshTabGroup>d__17 <RefreshTabGroup>d__;
			<RefreshTabGroup>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTabGroup>d__.<>4__this = this;
			<RefreshTabGroup>d__.<>1__state = -1;
			<RefreshTabGroup>d__.<>t__builder.Start<RoadBookVehicleTaskView.<RefreshTabGroup>d__17>(ref <RefreshTabGroup>d__);
			return <RefreshTabGroup>d__.<>t__builder.Task;
		}

		// Token: 0x060409FF RID: 264703 RVA: 0x01090E18 File Offset: 0x0108F018
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

		// Token: 0x06040A00 RID: 264704 RVA: 0x01090EA8 File Offset: 0x0108F0A8
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

		// Token: 0x06040A01 RID: 264705 RVA: 0x01090F18 File Offset: 0x0108F118
		private void OnClickHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(this.ActivityBaseData.LocalConfig.Value.HelpId);
		}

		// Token: 0x04024319 RID: 148249
		[Nullable(2)]
		private PopupCaptionItem CaptionComponent;

		// Token: 0x0402431A RID: 148250
		private ActivityRoadBookData ActivityBaseData;

		// Token: 0x0402431B RID: 148251
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0402431C RID: 148252
		private GenericScrollViewNew<TabGroupGridItem, ITabGroupData> MenuScroll;

		// Token: 0x0402431D RID: 148253
		private GenericScrollViewNew<MotorChallengeItem, ActivityTaskData> TaskScroll;

		// Token: 0x0402431E RID: 148254
		private int SelectedTabIndex = -1;

		// Token: 0x0402431F RID: 148255
		[Nullable(2)]
		private MenuTabToggleItem SelectChildToggle;
	}
}
