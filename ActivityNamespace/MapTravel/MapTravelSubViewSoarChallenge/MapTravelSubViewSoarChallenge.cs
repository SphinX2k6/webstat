using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace ActivityNamespace.MapTravel.MapTravelSubViewSoarChallenge
{
	// Token: 0x020043CC RID: 17356
	[NullableContext(1)]
	[Nullable(0)]
	public class MapTravelSubViewSoarChallenge : UiPanelBase, IMapTravelSubViewInterface
	{
		// Token: 0x17007F09 RID: 32521
		// (get) Token: 0x0602E220 RID: 188960 RVA: 0x00AD9066 File Offset: 0x00AD7266
		// (set) Token: 0x0602E221 RID: 188961 RVA: 0x00AD906E File Offset: 0x00AD726E
		public bool NeedDestroySelf { get; set; }

		// Token: 0x0602E222 RID: 188962 RVA: 0x00AD9077 File Offset: 0x00AD7277
		public MapTravelSubViewSoarChallenge(ActivityMapTravelData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x17007F0A RID: 32522
		// (get) Token: 0x0602E223 RID: 188963 RVA: 0x00AD908D File Offset: 0x00AD728D
		// (set) Token: 0x0602E224 RID: 188964 RVA: 0x00AD9095 File Offset: 0x00AD7295
		protected ActivityMapTravelData ActivityBaseData { get; set; }

		// Token: 0x0602E225 RID: 188965 RVA: 0x00AD90A0 File Offset: 0x00AD72A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDynScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.JumpButtonClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0602E226 RID: 188966 RVA: 0x00AD920C File Offset: 0x00AD740C
		protected override UniTask OnBeforeStartAsync()
		{
			MapTravelSubViewSoarChallenge.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapTravelSubViewSoarChallenge.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E227 RID: 188967 RVA: 0x00AD924F File Offset: 0x00AD744F
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.MapTravelSoarRefresh, new Action(this.OnMapTravelSoarRefresh));
		}

		// Token: 0x0602E228 RID: 188968 RVA: 0x00AD926D File Offset: 0x00AD746D
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MapTravelSoarRefresh, new Action(this.OnMapTravelSoarRefresh));
		}

		// Token: 0x0602E229 RID: 188969 RVA: 0x00AD928B File Offset: 0x00AD748B
		private SoarChallengeTabDynamicScrollItem CreateTabItem(SoarChallengePlayData data, UUIItem uiItem, int index)
		{
			SoarChallengeTabDynamicScrollItem soarChallengeTabDynamicScrollItem = new SoarChallengeTabDynamicScrollItem();
			soarChallengeTabDynamicScrollItem.BindSelectedCallBack(new Action<SoarChallengePlayData>(this.TabSelectedCallBack));
			soarChallengeTabDynamicScrollItem.BindIsSelectedOn(new Func<SoarChallengePlayData, bool>(this.IsSelectOn));
			return soarChallengeTabDynamicScrollItem;
		}

		// Token: 0x0602E22A RID: 188970 RVA: 0x00AD92B6 File Offset: 0x00AD74B6
		private SoarChallengeItem InitItem()
		{
			SoarChallengeItem soarChallengeItem = new SoarChallengeItem(this.ActivityBaseData);
			soarChallengeItem.SetClickRewardCb(new Action(this.OnClickRewardCb));
			return soarChallengeItem;
		}

		// Token: 0x0602E22B RID: 188971 RVA: 0x00AD92D8 File Offset: 0x00AD74D8
		private void OnClickRewardCb()
		{
			SoarChallengePlayData soarChallengePlayData = this.ActivityBaseData.GetAllSoarTabData()[this.SelectedTabIndex];
			List<int> rewardIds = (from taskData in this.ActivityBaseData.GetSoarItemDataList(soarChallengePlayData.RewardIds)
			where taskData.Status == EActivityTaskState.FinishedAndUnclaimed
			select taskData.Id).ToList<int>();
			ControllerBase<ActivityMapTravelController>.Instance.RequestMultiTakeSoarChallengeReward(rewardIds);
		}

		// Token: 0x0602E22C RID: 188972 RVA: 0x00AD9368 File Offset: 0x00AD7568
		private void OnMapTravelSoarRefresh()
		{
			SoarChallengePlayData soarChallengePlayData = this.ActivityBaseData.GetAllSoarTabData()[this.SelectedTabIndex];
			this.TabLayout.GetScrollItemFromIndex(this.SelectedTabIndex).Update(soarChallengePlayData, this.SelectedTabIndex);
			this.RefreshContent(soarChallengePlayData);
		}

		// Token: 0x0602E22D RID: 188973 RVA: 0x00AD93B0 File Offset: 0x00AD75B0
		protected UniTask Refresh()
		{
			MapTravelSubViewSoarChallenge.<Refresh>d__22 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<MapTravelSubViewSoarChallenge.<Refresh>d__22>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x0602E22E RID: 188974 RVA: 0x00AD93F4 File Offset: 0x00AD75F4
		private void TabSelectedCallBack(SoarChallengePlayData tabData)
		{
			if (this.SelectedTabIndex >= 0 && tabData.TabIndex != this.SelectedTabIndex)
			{
				this.SelectTab(this.SelectedTabIndex, false, false);
			}
			this.SelectedTabIndex = tabData.TabIndex;
			if (tabData.IsUnlock && !this.ActivityBaseData.SaveFirstCheckRedDotState(EMapTravelSaveFlag.SoarChallengeNewUnlock, tabData.PlayId))
			{
				SoarChallengeTabDynamicScrollItem scrollItemFromIndex = this.TabLayout.GetScrollItemFromIndex(this.SelectedTabIndex);
				if (scrollItemFromIndex != null)
				{
					scrollItemFromIndex.SetItemNewVisible(false);
				}
			}
			this.RefreshContent(tabData);
		}

		// Token: 0x0602E22F RID: 188975 RVA: 0x00AD9472 File Offset: 0x00AD7672
		private bool IsSelectOn(SoarChallengePlayData tabData)
		{
			return this.SelectedTabIndex == tabData.TabIndex;
		}

		// Token: 0x0602E230 RID: 188976 RVA: 0x00AD9482 File Offset: 0x00AD7682
		private void SelectTab(int index, bool bOn, bool bFireEvent)
		{
			this.TabLayout.GetScrollItemFromIndex(index).SetSelected(bOn, bFireEvent);
		}

		// Token: 0x0602E231 RID: 188977 RVA: 0x00AD9497 File Offset: 0x00AD7697
		private void JumpButtonClicked()
		{
			SkipTaskManager.RunByConfigId(this.ActivityBaseData.GetAllSoarTabData()[this.SelectedTabIndex].JumpId, null);
		}

		// Token: 0x0602E232 RID: 188978 RVA: 0x00AD94BC File Offset: 0x00AD76BC
		private void RefreshContent(SoarChallengePlayData tabData)
		{
			bool isUnlock = tabData.IsUnlock;
			List<ActivityTaskData> data = isUnlock ? this.ActivityBaseData.GetSoarItemDataList(tabData.RewardIds) : new List<ActivityTaskData>();
			this.LayoutList.RefreshByData(data, null, true);
			base.GetItem(4).SetUIActive(!isUnlock);
			if (!isUnlock)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), this.ActivityBaseData.GetSoarPlayLockTips(tabData.PlayId), Array.Empty<object>());
			}
			base.GetButton(6).RootUIComp.Get().SetUIActive(isUnlock);
		}

		// Token: 0x0602E233 RID: 188979 RVA: 0x00AD9550 File Offset: 0x00AD7750
		public UniTask PlayStartSequence()
		{
			MapTravelSubViewSoarChallenge.<PlayStartSequence>d__28 <PlayStartSequence>d__;
			<PlayStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequence>d__.<>4__this = this;
			<PlayStartSequence>d__.<>1__state = -1;
			<PlayStartSequence>d__.<>t__builder.Start<MapTravelSubViewSoarChallenge.<PlayStartSequence>d__28>(ref <PlayStartSequence>d__);
			return <PlayStartSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0602E234 RID: 188980 RVA: 0x00AD9594 File Offset: 0x00AD7794
		public UniTask PlayCloseSequence()
		{
			MapTravelSubViewSoarChallenge.<PlayCloseSequence>d__29 <PlayCloseSequence>d__;
			<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCloseSequence>d__.<>4__this = this;
			<PlayCloseSequence>d__.<>1__state = -1;
			<PlayCloseSequence>d__.<>t__builder.Start<MapTravelSubViewSoarChallenge.<PlayCloseSequence>d__29>(ref <PlayCloseSequence>d__);
			return <PlayCloseSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0401A188 RID: 106888
		private GenericScrollViewNew<SoarChallengeItem, ActivityTaskData> LayoutList;

		// Token: 0x0401A189 RID: 106889
		protected DynamicScrollView<SoarChallengeTabDynamicScrollItem, SoarTabDynamicItem, SoarChallengePlayData> TabLayout;

		// Token: 0x0401A18A RID: 106890
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401A18B RID: 106891
		private int SelectedTabIndex = -1;

		// Token: 0x0200A63E RID: 42558
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403367E RID: 210558
			public const int TabLayout = 0;

			// Token: 0x0403367F RID: 210559
			public const int TabItem = 1;

			// Token: 0x04033680 RID: 210560
			public const int Content = 2;

			// Token: 0x04033681 RID: 210561
			public const int Item = 3;

			// Token: 0x04033682 RID: 210562
			public const int LockItem = 4;

			// Token: 0x04033683 RID: 210563
			public const int LockText = 5;

			// Token: 0x04033684 RID: 210564
			public const int ButtonGo = 6;
		}
	}
}
