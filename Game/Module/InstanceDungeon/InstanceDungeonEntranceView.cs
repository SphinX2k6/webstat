using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BBE RID: 23486
	[NullableContext(2)]
	[Nullable(0)]
	public class InstanceDungeonEntranceView : UiTickViewBase
	{
		// Token: 0x0603B70F RID: 243471 RVA: 0x00F10D30 File Offset: 0x00F0EF30
		[NullableContext(1)]
		public InstanceDungeonEntranceView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x17009779 RID: 38777
		// (get) Token: 0x0603B710 RID: 243472 RVA: 0x00F10D44 File Offset: 0x00F0EF44
		private InstanceDungeon? InstanceConfig
		{
			get
			{
				if (this.InstanceId == 0)
				{
					return null;
				}
				return ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceId);
			}
		}

		// Token: 0x0603B711 RID: 243473 RVA: 0x00F10D74 File Offset: 0x00F0EF74
		protected unsafe override void OnRegisterComponent()
		{
			this.Vm = ((this.OpenParam as InstanceDungeonViewModelBase) ?? new BaseInstanceDungeonViewModel());
			this.Vm.RegisterView(this);
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDynScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B712 RID: 243474 RVA: 0x00F10F10 File Offset: 0x00F0F110
		protected override UniTask OnBeforeStartAsync()
		{
			InstanceDungeonEntranceView.<OnBeforeStartAsync>d__28 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<OnBeforeStartAsync>d__28>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B713 RID: 243475 RVA: 0x00F10F53 File Offset: 0x00F0F153
		protected override void OnStart()
		{
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			this.TitleInstanceGridNumberMap = new Dictionary<int, int>();
			this.SetDefaultSelect();
		}

		// Token: 0x0603B714 RID: 243476 RVA: 0x00F10F79 File Offset: 0x00F0F179
		private void OpenPowerView(int index)
		{
			ControllerBase<PowerController>.Instance.OpenPowerView(EPowerMenuType.Supply, 0);
		}

		// Token: 0x0603B715 RID: 243477 RVA: 0x00F10F87 File Offset: 0x00F0F187
		protected override void OnTick(float delta)
		{
			if (!this.NeedOnTimer)
			{
				return;
			}
			this.Vm.TimerRefreshFunction(delta);
		}

		// Token: 0x0603B716 RID: 243478 RVA: 0x00F10F9E File Offset: 0x00F0F19E
		protected override void OnBeforeShow()
		{
			this.InitView();
		}

		// Token: 0x0603B717 RID: 243479 RVA: 0x00F10FA8 File Offset: 0x00F0F1A8
		protected override void OnAfterShow()
		{
			this.MatchingCountDownItem.BindOnClickBtnCancelMatching(delegate
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.CancelMatchRequest();
			});
			this.MatchingCountDownItem.BindOnAfterCloseAnimation(delegate(string sequenceName)
			{
				if (sequenceName == "Close")
				{
					this.SetMatchingItemActive(false);
				}
			});
			if (this.Vm.InstanceIdList.Length == 0)
			{
				base.GetItem(2).SetUIActive(false);
				return;
			}
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Matching)
			{
				this.SetMatchingItemActive(true);
				InstanceDungeonMatchingCountDown matchingCountDownItem = this.MatchingCountDownItem;
				if (matchingCountDownItem != null)
				{
					matchingCountDownItem.PlayAnimation("Start");
				}
				this.MatchingCountDownItem.StartTimer();
			}
		}

		// Token: 0x0603B718 RID: 243480 RVA: 0x00F11047 File Offset: 0x00F0F247
		protected override void OnBeforeHide()
		{
			this.Vm.OnBeforeHide();
		}

		// Token: 0x0603B719 RID: 243481 RVA: 0x00F11054 File Offset: 0x00F0F254
		protected override void OnBeforeDestroy()
		{
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Matching)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("MatchingBackground", Array.Empty<object>());
			}
			ControllerBase<InstanceDungeonEntranceController>.Instance.RestoreDungeonEntranceEntity();
			this.Vm.OnBeforeDestroy();
			this.MatchingCountDownItem = null;
			PowerCurrencyItem powerCurrencyItem = this.PowerCurrencyItem;
			if (powerCurrencyItem != null)
			{
				powerCurrencyItem.Destroy(null);
			}
			PowerCurrencyItem overPowerCurrencyItem = this.OverPowerCurrencyItem;
			if (overPowerCurrencyItem != null)
			{
				overPowerCurrencyItem.Destroy(null);
			}
			if (this.InstanceLoopScroll != null)
			{
				this.InstanceLoopScroll.ClearChildren();
				this.InstanceLoopScroll = null;
			}
			this.DynamicScrollViewComponent = null;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBeforeDestroyInstanceDungeonEntranceView);
			ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = 0;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.CloseInstanceEntrancePositively, this.Vm.EntranceId);
		}

		// Token: 0x0603B71A RID: 243482 RVA: 0x00F1111C File Offset: 0x00F0F31C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnViewClose));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
		}

		// Token: 0x0603B71B RID: 243483 RVA: 0x00F1117C File Offset: 0x00F0F37C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnViewClose));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
		}

		// Token: 0x0603B71C RID: 243484 RVA: 0x00F111DC File Offset: 0x00F0F3DC
		private void SetDefaultSelect()
		{
			int selectInstanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId;
			if (selectInstanceId > 0)
			{
				foreach (KeyValuePair<int, List<int>> keyValuePair in this.Vm.InstanceByTitleMap)
				{
					int num;
					List<int> list;
					keyValuePair.Deconstruct(out num, out list);
					int seriesId = num;
					if (list.Contains(selectInstanceId))
					{
						this.SeriesId = seriesId;
						this.InstanceId = selectInstanceId;
						return;
					}
				}
			}
			InstanceDungeonEntranceViewSelectData defaultSelectData = this.Vm.GetDefaultSelectData();
			if (defaultSelectData == null)
			{
				return;
			}
			this.SeriesId = defaultSelectData.SeriesId;
			this.InstanceId = defaultSelectData.InstanceId;
		}

		// Token: 0x0603B71D RID: 243485 RVA: 0x00F11290 File Offset: 0x00F0F490
		private void OnClickCaptionStateBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(242);
		}

		// Token: 0x0603B71E RID: 243486 RVA: 0x00F112A4 File Offset: 0x00F0F4A4
		private void InitView()
		{
			UiAsyncTask task = new UiAsyncTask("InstanceDungeonEntranceView.RefreshInstance", delegate()
			{
				InstanceDungeonEntranceView.<<InitView>b__40_0>d <<InitView>b__40_0>d;
				<<InitView>b__40_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<InitView>b__40_0>d.<>4__this = this;
				<<InitView>b__40_0>d.<>1__state = -1;
				<<InitView>b__40_0>d.<>t__builder.Start<InstanceDungeonEntranceView.<<InitView>b__40_0>d>(ref <<InitView>b__40_0>d);
				return <<InitView>b__40_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603B71F RID: 243487 RVA: 0x00F112D4 File Offset: 0x00F0F4D4
		private UniTask InitViewAsync()
		{
			InstanceDungeonEntranceView.<InitViewAsync>d__41 <InitViewAsync>d__;
			<InitViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitViewAsync>d__.<>4__this = this;
			<InitViewAsync>d__.<>1__state = -1;
			<InitViewAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<InitViewAsync>d__41>(ref <InitViewAsync>d__);
			return <InitViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B720 RID: 243488 RVA: 0x00F11318 File Offset: 0x00F0F518
		public void RefreshMowingInstance()
		{
			UiAsyncTask task = new UiAsyncTask("InstanceDungeonEntranceView.RefreshInstance", delegate()
			{
				InstanceDungeonEntranceView.<<RefreshMowingInstance>b__42_0>d <<RefreshMowingInstance>b__42_0>d;
				<<RefreshMowingInstance>b__42_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshMowingInstance>b__42_0>d.<>4__this = this;
				<<RefreshMowingInstance>b__42_0>d.<>1__state = -1;
				<<RefreshMowingInstance>b__42_0>d.<>t__builder.Start<InstanceDungeonEntranceView.<<RefreshMowingInstance>b__42_0>d>(ref <<RefreshMowingInstance>b__42_0>d);
				return <<RefreshMowingInstance>b__42_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603B721 RID: 243489 RVA: 0x00F11348 File Offset: 0x00F0F548
		private UniTask RefreshMowingInstanceAsync()
		{
			InstanceDungeonEntranceView.<RefreshMowingInstanceAsync>d__43 <RefreshMowingInstanceAsync>d__;
			<RefreshMowingInstanceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshMowingInstanceAsync>d__.<>4__this = this;
			<RefreshMowingInstanceAsync>d__.<>1__state = -1;
			<RefreshMowingInstanceAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<RefreshMowingInstanceAsync>d__43>(ref <RefreshMowingInstanceAsync>d__);
			return <RefreshMowingInstanceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B722 RID: 243490 RVA: 0x00F1138C File Offset: 0x00F0F58C
		public void RefreshTowerDefenseInstance()
		{
			UiAsyncTask task = new UiAsyncTask("InstanceDungeonEntranceView.RefreshInstance", delegate()
			{
				InstanceDungeonEntranceView.<<RefreshTowerDefenseInstance>b__44_0>d <<RefreshTowerDefenseInstance>b__44_0>d;
				<<RefreshTowerDefenseInstance>b__44_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshTowerDefenseInstance>b__44_0>d.<>4__this = this;
				<<RefreshTowerDefenseInstance>b__44_0>d.<>1__state = -1;
				<<RefreshTowerDefenseInstance>b__44_0>d.<>t__builder.Start<InstanceDungeonEntranceView.<<RefreshTowerDefenseInstance>b__44_0>d>(ref <<RefreshTowerDefenseInstance>b__44_0>d);
				return <<RefreshTowerDefenseInstance>b__44_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603B723 RID: 243491 RVA: 0x00F113BC File Offset: 0x00F0F5BC
		private UniTask RefreshTowerDefenceInstanceAsync()
		{
			InstanceDungeonEntranceView.<RefreshTowerDefenceInstanceAsync>d__45 <RefreshTowerDefenceInstanceAsync>d__;
			<RefreshTowerDefenceInstanceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTowerDefenceInstanceAsync>d__.<>4__this = this;
			<RefreshTowerDefenceInstanceAsync>d__.<>1__state = -1;
			<RefreshTowerDefenceInstanceAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<RefreshTowerDefenceInstanceAsync>d__45>(ref <RefreshTowerDefenceInstanceAsync>d__);
			return <RefreshTowerDefenceInstanceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B724 RID: 243492 RVA: 0x00F11400 File Offset: 0x00F0F600
		public void RefreshSolarSpeedInstance(float delta, bool force = false)
		{
			if (!force)
			{
				this.CountDownMs -= delta;
				if (this.CountDownMs > 0f)
				{
					return;
				}
			}
			if (this.InstanceLoopScroll != null)
			{
				for (int i = 0; i < this.InstanceLoopScroll.GetScrollItemCount(); i++)
				{
					InstanceDetectItem scrollItemFromIndex = this.InstanceLoopScroll.GetScrollItemFromIndex(i);
					if (scrollItemFromIndex != null)
					{
						scrollItemFromIndex.UpdateSelf();
					}
				}
			}
			this.UpdateUnlockStateItem();
			this.CountDownMs = 1000f;
		}

		// Token: 0x0603B725 RID: 243493 RVA: 0x00F11474 File Offset: 0x00F0F674
		private void RefreshCaptionStateItemByData(int dungeonId)
		{
			bool flag = ModelBase<InstanceDungeonEntranceModel>.Instance.IsDungeonArchiveActivate(dungeonId);
			this.InstanceDungeonCaptionItem.SetCaptionStateActive(flag);
			this.InstanceDungeonCaptionItem.SetCaptionChangeColor(false);
			if (flag)
			{
				if (ModelBase<InstanceDungeonEntranceModel>.Instance.HasDungeonArchive(dungeonId))
				{
					this.InstanceDungeonCaptionItem.SetCaptionStateTip("instance_HaveRecord");
					this.InstanceDungeonCaptionItem.SetCaptionChangeColor(true);
					return;
				}
				if (ModelBase<InstanceDungeonEntranceModel>.Instance.IsDungeonSupportAndWithoutArchive(dungeonId))
				{
					this.InstanceDungeonCaptionItem.SetCaptionStateTip("instance_Record_leave");
				}
			}
		}

		// Token: 0x0603B726 RID: 243494 RVA: 0x00F114F0 File Offset: 0x00F0F6F0
		private void UpdateInstancesView()
		{
			InstanceDetectionDynamicData[] instanceListBySelectSeriesId = this.GetInstanceListBySelectSeriesId();
			this.InstanceLoopScroll.RefreshByData(instanceListBySelectSeriesId, false, false);
			base.GetItem(2).SetUIActive(true);
			this.InstanceLoopScroll.BindLateUpdate(delegate(float _)
			{
				int scrollItemCount = this.InstanceLoopScroll.GetScrollItemCount();
				if (this.ScrollIndex + 1 < scrollItemCount)
				{
					this.InstanceLoopScroll.UnBindLateUpdate();
					return;
				}
				Dictionary<int, List<int>> instanceByTitleMap = this.Vm.InstanceByTitleMap;
				int num = (instanceByTitleMap != null) ? instanceByTitleMap.Count : 0;
				if (this.ScrollIndex >= num)
				{
					this.ScrollIndex = num - 1;
				}
				this.InstanceLoopScroll.ScrollToItemIndex(this.ScrollIndex, true, false).Forget();
				this.InstanceLoopScroll.UnBindLateUpdate();
			});
		}

		// Token: 0x0603B727 RID: 243495 RVA: 0x00F11538 File Offset: 0x00F0F738
		private UniTask UpdateScorePanelAsync()
		{
			InstanceDungeonEntranceView.<UpdateScorePanelAsync>d__49 <UpdateScorePanelAsync>d__;
			<UpdateScorePanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateScorePanelAsync>d__.<>4__this = this;
			<UpdateScorePanelAsync>d__.<>1__state = -1;
			<UpdateScorePanelAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<UpdateScorePanelAsync>d__49>(ref <UpdateScorePanelAsync>d__);
			return <UpdateScorePanelAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B728 RID: 243496 RVA: 0x00F1157C File Offset: 0x00F0F77C
		private UniTask UpdateInstanceDungeonTowerDefenseItemAsync()
		{
			InstanceDungeonEntranceView.<UpdateInstanceDungeonTowerDefenseItemAsync>d__50 <UpdateInstanceDungeonTowerDefenseItemAsync>d__;
			<UpdateInstanceDungeonTowerDefenseItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateInstanceDungeonTowerDefenseItemAsync>d__.<>4__this = this;
			<UpdateInstanceDungeonTowerDefenseItemAsync>d__.<>1__state = -1;
			<UpdateInstanceDungeonTowerDefenseItemAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<UpdateInstanceDungeonTowerDefenseItemAsync>d__50>(ref <UpdateInstanceDungeonTowerDefenseItemAsync>d__);
			return <UpdateInstanceDungeonTowerDefenseItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B729 RID: 243497 RVA: 0x00F115C0 File Offset: 0x00F0F7C0
		private UniTask UpdateInstanceDungeonSolarSpeedItemAsync()
		{
			InstanceDungeonEntranceView.<UpdateInstanceDungeonSolarSpeedItemAsync>d__51 <UpdateInstanceDungeonSolarSpeedItemAsync>d__;
			<UpdateInstanceDungeonSolarSpeedItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateInstanceDungeonSolarSpeedItemAsync>d__.<>4__this = this;
			<UpdateInstanceDungeonSolarSpeedItemAsync>d__.<>1__state = -1;
			<UpdateInstanceDungeonSolarSpeedItemAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<UpdateInstanceDungeonSolarSpeedItemAsync>d__51>(ref <UpdateInstanceDungeonSolarSpeedItemAsync>d__);
			return <UpdateInstanceDungeonSolarSpeedItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B72A RID: 243498 RVA: 0x00F11604 File Offset: 0x00F0F804
		private UniTask UpdateMowingScorePanelItemAsync()
		{
			InstanceDungeonEntranceView.<UpdateMowingScorePanelItemAsync>d__52 <UpdateMowingScorePanelItemAsync>d__;
			<UpdateMowingScorePanelItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateMowingScorePanelItemAsync>d__.<>4__this = this;
			<UpdateMowingScorePanelItemAsync>d__.<>1__state = -1;
			<UpdateMowingScorePanelItemAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<UpdateMowingScorePanelItemAsync>d__52>(ref <UpdateMowingScorePanelItemAsync>d__);
			return <UpdateMowingScorePanelItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B72B RID: 243499 RVA: 0x00F11648 File Offset: 0x00F0F848
		[NullableContext(1)]
		private InstanceDetectItem CreateInstanceGrid(InstanceDetectionDynamicData data, UUIItem uiItem, int index)
		{
			InstanceDetectItem instanceDetectItem = new InstanceDetectItem();
			instanceDetectItem.OpenParam = this.Vm;
			instanceDetectItem.BindClickInstanceCallback(new Action<int, UUIExtendToggle, InstanceDetectionDynamicData>(this.RefreshInstanceById));
			instanceDetectItem.BindClickSeriesCallback(new Action<int, UUIExtendToggle, bool>(this.RefreshSeriesById));
			instanceDetectItem.BindCanExecuteChange(new Func<int, bool>(this.CanExecuteChange));
			instanceDetectItem.BindCanShowRedDot(new Func<int, bool>(this.CanShowRedDot));
			instanceDetectItem.BindIconRightPathGetter(new Func<int, string>(ControllerBase<InstanceDungeonEntranceController>.Instance.GetIconRightPathGetter));
			return instanceDetectItem;
		}

		// Token: 0x0603B72C RID: 243500 RVA: 0x00F116C4 File Offset: 0x00F0F8C4
		[NullableContext(1)]
		private void RefreshSeriesById(int id, UUIExtendToggle toggle, bool isShow)
		{
			if (this.CurrentSeriesToggle != null && this.CurrentSeriesToggle != toggle)
			{
				this.CurrentSeriesToggle.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
			}
			this.CurrentSeriesToggle = toggle;
			this.SeriesId = (isShow ? id : -1);
			this.InstanceId = (isShow ? this.Vm.InstanceByTitleMap[id][0] : this.InstanceId);
			InstanceDetectionDynamicData[] instanceListBySelectSeriesId = this.GetInstanceListBySelectSeriesId();
			this.InstanceLoopScroll.RefreshByData(instanceListBySelectSeriesId, false, false);
			this.InstanceLoopScroll.BindLateUpdate(new Action<float>(this.ScrollToItem));
		}

		// Token: 0x0603B72D RID: 243501 RVA: 0x00F1175C File Offset: 0x00F0F95C
		private void ScrollToItem(float delta)
		{
			int valueOrDefault = this.TitleInstanceGridNumberMap.GetValueOrDefault(this.SeriesId, 0);
			float scrollProgress = (float)(this.ScrollIndex - 1) / (float)(this.Vm.InstanceByTitleMap.Count + valueOrDefault);
			base.GetUIDynScrollViewComponent(0).SetScrollProgress(scrollProgress);
			DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll = this.InstanceLoopScroll;
			if (instanceLoopScroll == null)
			{
				return;
			}
			instanceLoopScroll.UnBindLateUpdate();
		}

		// Token: 0x0603B72E RID: 243502 RVA: 0x00F117B8 File Offset: 0x00F0F9B8
		[NullableContext(1)]
		private void RefreshInstanceById(int id, UUIExtendToggle toggle, [Nullable(2)] InstanceDetectionDynamicData data = null)
		{
			InstanceDungeonEntranceView.<>c__DisplayClass56_0 CS$<>8__locals1 = new InstanceDungeonEntranceView.<>c__DisplayClass56_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.id = id;
			CS$<>8__locals1.toggle = toggle;
			CS$<>8__locals1.data = data;
			UiAsyncTask task = new UiAsyncTask("InstanceDungeonEntranceView.RefreshInstance", delegate()
			{
				InstanceDungeonEntranceView.<>c__DisplayClass56_0.<<RefreshInstanceById>b__0>d <<RefreshInstanceById>b__0>d;
				<<RefreshInstanceById>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshInstanceById>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshInstanceById>b__0>d.<>1__state = -1;
				<<RefreshInstanceById>b__0>d.<>t__builder.Start<InstanceDungeonEntranceView.<>c__DisplayClass56_0.<<RefreshInstanceById>b__0>d>(ref <<RefreshInstanceById>b__0>d);
				return <<RefreshInstanceById>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603B72F RID: 243503 RVA: 0x00F11808 File Offset: 0x00F0FA08
		[NullableContext(1)]
		private UniTask RefreshInstanceByIdAsync(int id, UUIExtendToggle toggle, [Nullable(2)] InstanceDetectionDynamicData data = null)
		{
			InstanceDungeonEntranceView.<RefreshInstanceByIdAsync>d__57 <RefreshInstanceByIdAsync>d__;
			<RefreshInstanceByIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshInstanceByIdAsync>d__.<>4__this = this;
			<RefreshInstanceByIdAsync>d__.id = id;
			<RefreshInstanceByIdAsync>d__.toggle = toggle;
			<RefreshInstanceByIdAsync>d__.data = data;
			<RefreshInstanceByIdAsync>d__.<>1__state = -1;
			<RefreshInstanceByIdAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<RefreshInstanceByIdAsync>d__57>(ref <RefreshInstanceByIdAsync>d__);
			return <RefreshInstanceByIdAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B730 RID: 243504 RVA: 0x00F11864 File Offset: 0x00F0FA64
		private void CheckAndShowDungeonArchiveExpireTips()
		{
			int selectInstanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId;
			ControllerBase<InstanceDungeonController>.Instance.CheckAndShowDungeonArchiveExpireTips(selectInstanceId);
		}

		// Token: 0x0603B731 RID: 243505 RVA: 0x00F11887 File Offset: 0x00F0FA87
		private bool CanExecuteChange(int id)
		{
			return this.InstanceId != id;
		}

		// Token: 0x0603B732 RID: 243506 RVA: 0x00F11898 File Offset: 0x00F0FA98
		private bool CanShowRedDot(int id)
		{
			InstanceDungeon? instanceConfig = this.InstanceConfig;
			if (instanceConfig != null && instanceConfig.GetValueOrDefault().InstSubType == 21)
			{
				List<int> list;
				if (!this.Vm.InstanceByTitleMap.TryGetValue(id, out list))
				{
					return false;
				}
				using (List<int>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int instanceId = enumerator.Current;
						if (this.Vm.CheckInstanceItemHasRedDot(instanceId))
						{
							return true;
						}
					}
					return false;
				}
			}
			instanceConfig = this.InstanceConfig;
			if (instanceConfig != null && instanceConfig.GetValueOrDefault().InstSubType == 28)
			{
				return ModelBase<SolarSpeedModel>.Instance.HasRedDotByInstanceId(id);
			}
			return false;
		}

		// Token: 0x0603B733 RID: 243507 RVA: 0x00F1196C File Offset: 0x00F0FB6C
		private UniTask UpdateInstanceAllItemAsync()
		{
			InstanceDungeonEntranceView.<UpdateInstanceAllItemAsync>d__61 <UpdateInstanceAllItemAsync>d__;
			<UpdateInstanceAllItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateInstanceAllItemAsync>d__.<>4__this = this;
			<UpdateInstanceAllItemAsync>d__.<>1__state = -1;
			<UpdateInstanceAllItemAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<UpdateInstanceAllItemAsync>d__61>(ref <UpdateInstanceAllItemAsync>d__);
			return <UpdateInstanceAllItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B734 RID: 243508 RVA: 0x00F119B0 File Offset: 0x00F0FBB0
		private UniTask UpdateInstanceBg()
		{
			InstanceDungeonEntranceView.<UpdateInstanceBg>d__62 <UpdateInstanceBg>d__;
			<UpdateInstanceBg>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateInstanceBg>d__.<>4__this = this;
			<UpdateInstanceBg>d__.<>1__state = -1;
			<UpdateInstanceBg>d__.<>t__builder.Start<InstanceDungeonEntranceView.<UpdateInstanceBg>d__62>(ref <UpdateInstanceBg>d__);
			return <UpdateInstanceBg>d__.<>t__builder.Task;
		}

		// Token: 0x0603B735 RID: 243509 RVA: 0x00F119F4 File Offset: 0x00F0FBF4
		private UniTask UpdateInstanceInfoItemAsync()
		{
			InstanceDungeonEntranceView.<UpdateInstanceInfoItemAsync>d__63 <UpdateInstanceInfoItemAsync>d__;
			<UpdateInstanceInfoItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateInstanceInfoItemAsync>d__.<>4__this = this;
			<UpdateInstanceInfoItemAsync>d__.<>1__state = -1;
			<UpdateInstanceInfoItemAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<UpdateInstanceInfoItemAsync>d__63>(ref <UpdateInstanceInfoItemAsync>d__);
			return <UpdateInstanceInfoItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B736 RID: 243510 RVA: 0x00F11A37 File Offset: 0x00F0FC37
		private void UpdateTimeAndCountItem()
		{
			this.InstanceDungeonTimeAndCountItem.RefreshItem(this.InstanceId);
		}

		// Token: 0x0603B737 RID: 243511 RVA: 0x00F11A4A File Offset: 0x00F0FC4A
		private void UpdateUnlockStateItem()
		{
			this.InstanceDungeonInfoItem.UpdateInstanceDungeonLockItemAndCostItem();
		}

		// Token: 0x0603B738 RID: 243512 RVA: 0x00F11A58 File Offset: 0x00F0FC58
		private void UpdatePowerItem()
		{
			bool flag = !(ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstancePowerCost(this.InstanceId) > 0);
			if (flag)
			{
				this.PowerCurrencyItem.SetActive(false);
				this.OverPowerCurrencyItem.SetActive(false);
				return;
			}
			this.PowerCurrencyItem.SetActive(true);
			this.OverPowerCurrencyItem.SetActive(true);
		}

		// Token: 0x0603B739 RID: 243513 RVA: 0x00F11AC3 File Offset: 0x00F0FCC3
		private void SetMatchingItemActive(bool isShow)
		{
			InstanceDungeonInfoItem instanceDungeonInfoItem = this.InstanceDungeonInfoItem;
			if (instanceDungeonInfoItem == null)
			{
				return;
			}
			instanceDungeonInfoItem.SetMatchingItemActive(isShow);
		}

		// Token: 0x0603B73A RID: 243514 RVA: 0x00F11AD6 File Offset: 0x00F0FCD6
		private void OnClickBtnClose()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PowerView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.PowerView, null);
			}
			this.UiViewSequence.CloseSequenceName = "Close01";
			base.CloseMe(null);
		}

		// Token: 0x0603B73B RID: 243515 RVA: 0x00F11B10 File Offset: 0x00F0FD10
		private void PlayPopupLevelSequenceReverse()
		{
			this.UiViewSequence.StopSequenceByKey("Popup", false, false);
			this.UiViewSequence.PlaySequencePurely("Popup", false, true);
		}

		// Token: 0x0603B73C RID: 243516 RVA: 0x00F11B38 File Offset: 0x00F0FD38
		private void OnViewClose(EUiViewName name, int viewId)
		{
			InstanceDungeonEntranceView.<>c__DisplayClass70_0 CS$<>8__locals1 = new InstanceDungeonEntranceView.<>c__DisplayClass70_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.name = name;
			UiAsyncTask task = new UiAsyncTask("InstanceDungeonEntranceView.RefreshInstance", delegate()
			{
				InstanceDungeonEntranceView.<>c__DisplayClass70_0.<<OnViewClose>b__0>d <<OnViewClose>b__0>d;
				<<OnViewClose>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OnViewClose>b__0>d.<>4__this = CS$<>8__locals1;
				<<OnViewClose>b__0>d.<>1__state = -1;
				<<OnViewClose>b__0>d.<>t__builder.Start<InstanceDungeonEntranceView.<>c__DisplayClass70_0.<<OnViewClose>b__0>d>(ref <<OnViewClose>b__0>d);
				return <<OnViewClose>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603B73D RID: 243517 RVA: 0x00F11B7C File Offset: 0x00F0FD7C
		private UniTask OnViewCloseAsync(EUiViewName name)
		{
			InstanceDungeonEntranceView.<OnViewCloseAsync>d__71 <OnViewCloseAsync>d__;
			<OnViewCloseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnViewCloseAsync>d__.<>4__this = this;
			<OnViewCloseAsync>d__.name = name;
			<OnViewCloseAsync>d__.<>1__state = -1;
			<OnViewCloseAsync>d__.<>t__builder.Start<InstanceDungeonEntranceView.<OnViewCloseAsync>d__71>(ref <OnViewCloseAsync>d__);
			return <OnViewCloseAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B73E RID: 243518 RVA: 0x00F11BC7 File Offset: 0x00F0FDC7
		private void BeginMatching()
		{
			this.MatchingCountDownItem.SetMatchingTime(0);
			this.MatchingCountDownItem.StartTimer();
		}

		// Token: 0x0603B73F RID: 243519 RVA: 0x00F11BE0 File Offset: 0x00F0FDE0
		private void OnMatchingChange()
		{
			switch (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState())
			{
			case EInstanceMatchState.Default:
			{
				InstanceDungeonMatchingCountDown matchingCountDownItem = this.MatchingCountDownItem;
				if (matchingCountDownItem == null)
				{
					return;
				}
				matchingCountDownItem.PlayAnimation("Close");
				return;
			}
			case EInstanceMatchState.Matching:
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("MatchingOtherCancel", Array.Empty<object>());
				InstanceDungeonMatchingCountDown matchingCountDownItem2 = this.MatchingCountDownItem;
				if (matchingCountDownItem2 != null)
				{
					matchingCountDownItem2.PlayAnimation("Start");
				}
				this.SetMatchingItemActive(true);
				this.BeginMatching();
				return;
			}
			case EInstanceMatchState.MatchConfirm:
			{
				InstanceDungeonMatchingCountDown matchingCountDownItem3 = this.MatchingCountDownItem;
				if (matchingCountDownItem3 != null)
				{
					matchingCountDownItem3.PlayAnimation("Finish");
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineInstanceMatchTips, null, null);
				return;
			}
			case EInstanceMatchState.Waiting:
				break;
			case EInstanceMatchState.ConfirmToReady:
				this.SetMatchingItemActive(false);
				ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InstanceDungeonMonsterPreView))
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.InstanceDungeonMonsterPreView, null);
				}
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingId(), true, true, false, null);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnEnterTeam);
				break;
			default:
				return;
			}
		}

		// Token: 0x0603B740 RID: 243520 RVA: 0x00F11CEC File Offset: 0x00F0FEEC
		private void OnMatchingBegin()
		{
			this.SetMatchingItemActive(true);
			InstanceDungeonMatchingCountDown matchingCountDownItem = this.MatchingCountDownItem;
			if (matchingCountDownItem != null)
			{
				matchingCountDownItem.PlayAnimation("Start");
			}
			InstanceDungeonMatchingCountDown matchingCountDownItem2 = this.MatchingCountDownItem;
			if (matchingCountDownItem2 != null)
			{
				matchingCountDownItem2.BindOnStopTimer(() => ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() != EInstanceMatchState.Matching);
			}
			this.BeginMatching();
			this.UpdateUnlockStateItem();
		}

		// Token: 0x0603B741 RID: 243521 RVA: 0x00F11D54 File Offset: 0x00F0FF54
		[NullableContext(1)]
		private InstanceDetectionDynamicData[] GetInstanceListBySelectSeriesId()
		{
			this.ScrollIndex = 0;
			List<InstanceDetectionDynamicData> list = new List<InstanceDetectionDynamicData>();
			int num = -1;
			this.RefreshInstanceIdByTitleMap();
			ValueTuple<InstanceDetectionDynamicData[], int> diyInstanceDetectionDynamicData = this.Vm.GetDiyInstanceDetectionDynamicData(this.SeriesId, this.InstanceId);
			InstanceDetectionDynamicData[] item = diyInstanceDetectionDynamicData.Item1;
			if (item.Length != 0)
			{
				this.ScrollIndex = diyInstanceDetectionDynamicData.Item2;
				return item;
			}
			bool flag = this.TitleInstanceGridNumberMap.Count == 1;
			bool flag2 = false;
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.Vm.InstanceByTitleMap)
			{
				int num2;
				List<int> list2;
				keyValuePair.Deconstruct(out num2, out list2);
				int num3 = num2;
				List<int> list3 = list2;
				bool flag3 = num3 == this.SeriesId;
				bool flag4 = this.TitleInstanceGridNumberMap.GetValueOrNull(num3).GetValueOrDefault() == 1;
				this.Vm.SortInstanceArray(list3);
				foreach (int num4 in list3)
				{
					if ((num != num3 && !flag) || (num != num3 && flag && flag4))
					{
						InstanceDetectionDynamicData instanceDetectionDynamicData = new InstanceDetectionDynamicData();
						instanceDetectionDynamicData.InstanceSeriesTitle = num3;
						instanceDetectionDynamicData.InstanceGirdId = num4;
						instanceDetectionDynamicData.IsSelect = flag3;
						instanceDetectionDynamicData.IsOnlyOneGrid = flag4;
						num = num3;
						list.Add(instanceDetectionDynamicData);
						if (this.SeriesId == this.InstanceId && this.InstanceId == num4)
						{
							flag2 = true;
						}
						if (!flag2)
						{
							this.ScrollIndex++;
						}
						if (flag && flag4)
						{
							break;
						}
					}
					if (flag3 && !flag4)
					{
						InstanceDetectionDynamicData instanceDetectionDynamicData2 = new InstanceDetectionDynamicData();
						instanceDetectionDynamicData2.InstanceGirdId = num4;
						instanceDetectionDynamicData2.IsSelect = (num4 == this.InstanceId);
						instanceDetectionDynamicData2.IsShow = flag3;
						list.Add(instanceDetectionDynamicData2);
						if (instanceDetectionDynamicData2.IsSelect)
						{
							flag2 = true;
						}
						if (!flag2)
						{
							this.ScrollIndex++;
						}
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x0603B742 RID: 243522 RVA: 0x00F11F88 File Offset: 0x00F10188
		private void RefreshInstanceIdByTitleMap()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			this.TitleInstanceGridNumberMap.Clear();
			bool flag = this.InstanceId != 0;
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.Vm.InstanceByTitleMap)
			{
				int num4;
				List<int> list;
				keyValuePair.Deconstruct(out num4, out list);
				int num5 = num4;
				List<int> list2 = list;
				if (num2 == 0)
				{
					num2 = num5;
				}
				this.TitleInstanceGridNumberMap[num5] = list2.Count;
				if (!flag)
				{
					foreach (int num6 in list2)
					{
						if (this.SeriesId == 0 || num5 == this.SeriesId)
						{
							if (num == 0)
							{
								num = num6;
							}
							bool flag2 = ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(num6);
							if (flag2 && num6 > this.InstanceId)
							{
								bool flag3 = ModelBase<ExchangeRewardModel>.Instance.IsFinishInstance(num6);
								int recommendLevel = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(num6, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
								if (flag2 && !flag3 && recommendLevel > num3)
								{
									this.InstanceId = num6;
									this.SeriesId = num5;
									num3 = recommendLevel;
								}
							}
						}
					}
				}
			}
			if (this.InstanceId == 0)
			{
				this.InstanceId = num;
			}
			if (this.SeriesId == 0)
			{
				this.SeriesId = num2;
			}
			ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = this.InstanceId;
		}

		// Token: 0x0603B743 RID: 243523 RVA: 0x00F12118 File Offset: 0x00F10318
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			int index = int.Parse(configParams[0]) - 1;
			InstanceDetectItem scrollItemFromIndex = this.InstanceLoopScroll.GetScrollItemFromIndex(index);
			if (scrollItemFromIndex == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "副本入口聚焦引导extraParam字段配置错误, 找不到对应的副本选项";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			UUIItem uuiitem = scrollItemFromIndex.GetExtendToggleForGuide().RootUIComp.Get();
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x0603B744 RID: 243524 RVA: 0x00F1218C File Offset: 0x00F1038C
		private void OnClickedHelpButton()
		{
			int helpButtonId = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(this.Vm.EntranceId).Value.HelpButtonId;
			ControllerBase<HelpController>.Instance.OpenHelpById(helpButtonId);
		}

		// Token: 0x0603B745 RID: 243525 RVA: 0x00F121CC File Offset: 0x00F103CC
		private void OnClickBtnSolo()
		{
			int instanceId = this.InstanceId;
			if (instanceId == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.InstanceDungeon, ELogAuthor.TL, "副本入口界面点击挑战错误，当前未选择副本", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceCanChallenge(instanceId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InstanceDungeonLackChallengeTimes", Array.Empty<object>());
				return;
			}
			if (ControllerBase<RoleController>.Instance.IsInRoleTrial() && !ControllerBase<InstanceDungeonController>.Instance.CanTrialRoleEnterDungeon(this.Vm.EntranceId, instanceId))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
				return;
			}
			if (ControllerBase<InstanceDungeonController>.Instance.IsForbidDungeon(instanceId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterInstanceTip", Array.Empty<object>());
			}
			ModelBase<InstanceDungeonModel>.Instance.InstanceContinue = false;
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.IsDungeonArchiveActivate(instanceId) && ModelBase<InstanceDungeonEntranceModel>.Instance.HasDungeonArchive(instanceId))
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DungeonContinuePlayConfirm);
				Action value = delegate()
				{
					ModelBase<InstanceDungeonModel>.Instance.InstanceContinue = true;
					this.HandleSoloEnterDungeon();
				};
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				confirmBoxDataNew.FunctionMap[2] = value;
				confirmBoxDataNew.FunctionMap[1] = new Action(this.<OnClickBtnSolo>g__ContinueCallback|79_1);
				confirmBoxDataNew.FunctionMap[-1] = new Action(InstanceDungeonEntranceView.<OnClickBtnSolo>g__CloseCallBack|79_2);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.HandleSoloEnterDungeon();
		}

		// Token: 0x0603B746 RID: 243526 RVA: 0x00F12310 File Offset: 0x00F10510
		private void HandleSoloEnterDungeon()
		{
			InstanceDungeonEntranceView.<>c__DisplayClass80_0 CS$<>8__locals1 = new InstanceDungeonEntranceView.<>c__DisplayClass80_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.instanceId = this.InstanceId;
			ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = false;
			CS$<>8__locals1.powerEnough = ModelBase<PowerModel>.Instance.IsPowerWithConvertedEnough(ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstancePowerCost(this.InstanceId));
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceLevelTooLow(this.InstanceId))
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.InstanceLevelTooLowToGetPhantom);
				confirmBoxDataNew.FunctionMap[2] = new Action(CS$<>8__locals1.<HandleSoloEnterDungeon>g__ConfirmCallback|0);
				confirmBoxDataNew.FunctionMap[1] = new Action(CS$<>8__locals1.<HandleSoloEnterDungeon>g__CancelCallback|1);
				int[] unlockCondition = ConfigBase<InstanceDungeonConfig>.Instance.GetUnlockCondition(CS$<>8__locals1.instanceId);
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					unlockCondition[1].ToString()
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			if (!CS$<>8__locals1.powerEnough)
			{
				InstanceDungeonModel instance = ModelBase<InstanceDungeonModel>.Instance;
				if (instance == null || !instance.HidePowerLackConfirmBox)
				{
					this.OpenPowerConfirm();
					return;
				}
			}
			ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId = CS$<>8__locals1.instanceId;
			ControllerBase<InstanceDungeonEntranceController>.Instance.ContinueEntranceFlow();
		}

		// Token: 0x0603B747 RID: 243527 RVA: 0x00F12428 File Offset: 0x00F10628
		private void OpenPowerConfirm()
		{
			int instanceId = this.InstanceId;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PowerNotEnoughForDungeon);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.PlayPopupLevelSequenceReverse();
				ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId = instanceId;
				ControllerBase<InstanceDungeonEntranceController>.Instance.ContinueEntranceFlow();
			};
			confirmBoxDataNew.FunctionMap[1] = new Action(this.PlayPopupLevelSequenceReverse);
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleText = ConfigBase<TextConfig>.Instance.GetTextById("PlotSkipConfirmToggle");
			confirmBoxDataNew.SetToggleFunction(new Action<bool>(this.OnClickedNotShowConfirm));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603B748 RID: 243528 RVA: 0x00F124C0 File Offset: 0x00F106C0
		private void OnClickBtnTeam()
		{
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				Singleton<Log>.Instance.Error(ELogModule.InstanceDungeon, ELogAuthor.LJQ, "非联机下无法进行组队挑战，请联系程序查BUG", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
			ModelBase<InstanceDungeonModel>.Instance.InstanceContinue = false;
			ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingId(this.InstanceId);
			if (ModelBase<OnlineModel>.Instance.GetCurrentTeamSize() <= 1)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.TeamChallengeRequest(this.InstanceId, false);
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.InstanceDungeonMultiStart);
			Action value = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.TeamChallengeRequest(this.InstanceId, true);
			};
			Action value2 = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.TeamChallengeRequest(this.InstanceId, false);
			};
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap[2] = value;
			confirmBoxDataNew.FunctionMap[1] = value2;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603B749 RID: 243529 RVA: 0x00F1258C File Offset: 0x00F1078C
		private void OnClickBtnMultiple()
		{
			if (!ControllerBase<OnlineController>.Instance.ShowTipsWhenOnlineDisabled(null))
			{
				return;
			}
			if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceCanChallenge(this.InstanceId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InstanceDungeonLackChallengeTimes", Array.Empty<object>());
				return;
			}
			if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
				return;
			}
			if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.Online))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("IsNotOpenOnline", Array.Empty<object>());
				return;
			}
			if (ControllerBase<InstanceDungeonController>.Instance.IsForbidDungeon(this.InstanceId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterInstanceTip", Array.Empty<object>());
				return;
			}
			ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
			ModelBase<InstanceDungeonModel>.Instance.InstanceContinue = false;
			this.MatchingCountDownItem.BindOnStopTimer(() => ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() != EInstanceMatchState.Matching);
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(this.InstanceId, false, true);
				return;
			}
			int currentTeamSize = ModelBase<OnlineModel>.Instance.GetCurrentTeamSize();
			if (currentTeamSize <= 1)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(this.InstanceId, false, true);
				return;
			}
			if (currentTeamSize < ModelBase<OnlineModel>.Instance.TeamMaxSize)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.InstanceDungeonMatchStart);
				Action value = delegate()
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(this.InstanceId, true, true);
				};
				Action value2 = delegate()
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(this.InstanceId, false, true);
				};
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				confirmBoxDataNew.FunctionMap[2] = value;
				confirmBoxDataNew.FunctionMap[1] = value2;
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CanNotMatching", Array.Empty<object>());
		}

		// Token: 0x0603B74A RID: 243530 RVA: 0x00F12734 File Offset: 0x00F10934
		private void OnClickedNotShowConfirm(bool isSelectedOn)
		{
			ModelBase<InstanceDungeonModel>.Instance.HidePowerLackConfirmBox = isSelectedOn;
		}

		// Token: 0x0603B74B RID: 243531 RVA: 0x00F12741 File Offset: 0x00F10941
		public UUIItem GetRewardPanelItem()
		{
			return base.GetItem(8);
		}

		// Token: 0x0603B752 RID: 243538 RVA: 0x00F128BC File Offset: 0x00F10ABC
		[CompilerGenerated]
		private void <OnClickBtnSolo>g__ContinueCallback|79_1()
		{
			this.HandleSoloEnterDungeon();
		}

		// Token: 0x0603B753 RID: 243539 RVA: 0x00F128C4 File Offset: 0x00F10AC4
		[CompilerGenerated]
		internal static void <OnClickBtnSolo>g__CloseCallBack|79_2()
		{
			ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
		}

		// Token: 0x040217E9 RID: 137193
		private int InstanceId;

		// Token: 0x040217EA RID: 137194
		private int SeriesId;

		// Token: 0x040217EB RID: 137195
		private Dictionary<int, int> TitleInstanceGridNumberMap;

		// Token: 0x040217EC RID: 137196
		private UUIExtendToggle CurrentSeriesToggle;

		// Token: 0x040217ED RID: 137197
		private UUIExtendToggle CurrentInstanceToggle;

		// Token: 0x040217EE RID: 137198
		private InstanceDetectionDynamicData CurrentInstanceDynaimcData;

		// Token: 0x040217EF RID: 137199
		private UUIDynScrollViewComponent DynamicScrollViewComponent;

		// Token: 0x040217F0 RID: 137200
		private InstanceDetectDynamicItem InstanceDetectDynamicItem;

		// Token: 0x040217F1 RID: 137201
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> InstanceLoopScroll;

		// Token: 0x040217F2 RID: 137202
		private int ScrollIndex;

		// Token: 0x040217F3 RID: 137203
		private bool NeedOnTimer;

		// Token: 0x040217F4 RID: 137204
		private float CountDownMs = 1000f;

		// Token: 0x040217F5 RID: 137205
		private InstanceDungeonInfoItem InstanceDungeonInfoItem;

		// Token: 0x040217F6 RID: 137206
		private InstanceDungeonMatchingCountDown MatchingCountDownItem;

		// Token: 0x040217F7 RID: 137207
		private PowerCurrencyItem PowerCurrencyItem;

		// Token: 0x040217F8 RID: 137208
		private PowerCurrencyItem OverPowerCurrencyItem;

		// Token: 0x040217F9 RID: 137209
		private PopupCaptionItem InstanceDungeonCaptionItem;

		// Token: 0x040217FA RID: 137210
		private InstanceDungeonTimeAndCountItem InstanceDungeonTimeAndCountItem;

		// Token: 0x040217FB RID: 137211
		private InstanceDungeonTowerDefensePanelItem InstanceDungeonTowerDefenseItem;

		// Token: 0x040217FC RID: 137212
		private InstanceDungeonMowingPanelItem InstanceDungeonMowingPanelItem;

		// Token: 0x040217FD RID: 137213
		private InstanceDungeonSolarSpeedPanelItem InstanceDungeonSolarSpeedItem;

		// Token: 0x040217FE RID: 137214
		[Nullable(1)]
		private InstanceDungeonViewModelBase Vm;

		// Token: 0x040217FF RID: 137215
		private const int MATCHING_ITEM_OFFSET = -98;

		// Token: 0x0200BC12 RID: 48146
		[NullableContext(0)]
		private enum EChildCom
		{
			// Token: 0x0403A034 RID: 237620
			ScrollInstanceSeries,
			// Token: 0x0403A035 RID: 237621
			IntanceDetectItem,
			// Token: 0x0403A036 RID: 237622
			UiItemEntrance,
			// Token: 0x0403A037 RID: 237623
			TextureInstanceBG,
			// Token: 0x0403A038 RID: 237624
			TopItem,
			// Token: 0x0403A039 RID: 237625
			ContentItem,
			// Token: 0x0403A03A RID: 237626
			CaptionItem,
			// Token: 0x0403A03B RID: 237627
			TimeAndCountItem,
			// Token: 0x0403A03C RID: 237628
			LeftRewardItem,
			// Token: 0x0403A03D RID: 237629
			GrayMask
		}
	}
}
