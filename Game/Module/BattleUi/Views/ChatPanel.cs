using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FA0 RID: 24480
	[NullableContext(2)]
	[Nullable(0)]
	public class ChatPanel : BattleChildViewPanel
	{
		// Token: 0x0603D7B5 RID: 251829 RVA: 0x00FA5B38 File Offset: 0x00FA3D38
		protected unsafe override void OnRegisterComponent()
		{
			EOperationType operationType = base.GetOperationType();
			if (operationType == EOperationType.Desktop)
			{
				int num = 11;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIDynScrollViewComponent));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
				this.ComponentRegisterInfos = list;
				num2 = 1;
				List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
				CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
				Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
				num = 0;
				*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickChatButton));
				this.BtnBindInfo = list2;
				return;
			}
			if (operationType == EOperationType.Pad)
			{
				int num = 3;
				List<ValueTuple<int, Type>> list3 = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list3, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list3);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
				this.ComponentRegisterInfos = list3;
				num2 = 1;
				List<ValueTuple<int, Delegate>> list4 = new List<ValueTuple<int, Delegate>>(num2);
				CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list4, num2);
				Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list4);
				num = 0;
				*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickChatButton));
				this.BtnBindInfo = list4;
			}
		}

		// Token: 0x0603D7B6 RID: 251830 RVA: 0x00FA5DE0 File Offset: 0x00FA3FE0
		public override void InitializeTemp()
		{
			this.ChatViewTimeDown = ConfigCommonParamById.GetIntConfig("ChatViewTimeDown").Value;
			EOperationType operationType = base.GetOperationType();
			if (operationType == EOperationType.Desktop)
			{
				this.RefreshChatRowItem();
				this.LevelSequencePlayer = new LevelSequencePlayer(base.GetItem(3));
			}
			if (operationType == EOperationType.Pad)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ChatView, base.GetItem(1), null, 0);
				this.LevelSequencePlayer = new LevelSequencePlayer(base.GetItem(2));
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
			{
				if (sequenceName == "Close")
				{
					this.SetChatScrollViewRootVisible(false);
				}
			}, false);
		}

		// Token: 0x0603D7B7 RID: 251831 RVA: 0x00FA5E70 File Offset: 0x00FA4070
		public override UniTask InitializeAsync()
		{
			ChatPanel.<InitializeAsync>d__14 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<ChatPanel.<InitializeAsync>d__14>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D7B8 RID: 251832 RVA: 0x00FA5EB3 File Offset: 0x00FA40B3
		[NullableContext(1)]
		private ChatRowDynamicItem CreateNodeGrid(ChatRowData data, UUIItem uiItem, int index)
		{
			return new ChatRowDynamicItem();
		}

		// Token: 0x0603D7B9 RID: 251833 RVA: 0x00FA5EBA File Offset: 0x00FA40BA
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshChatRedDot);
		}

		// Token: 0x0603D7BA RID: 251834 RVA: 0x00FA5ECC File Offset: 0x00FA40CC
		public override void Reset()
		{
			base.Reset();
			this.RemoveScrollDelay();
			this.RemoveChatViewTimeDown();
			if (base.GetOperationType() == EOperationType.Pad)
			{
				ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.ChatView);
			}
		}

		// Token: 0x0603D7BB RID: 251835 RVA: 0x00FA5EF5 File Offset: 0x00FA40F5
		protected override void OnAfterDestroy()
		{
			base.OnAfterDestroy();
			ModelBase<BattleUiModel>.Instance.ChatScrollViewVisible = false;
		}

		// Token: 0x0603D7BC RID: 251836 RVA: 0x00FA5F08 File Offset: 0x00FA4108
		private UniTask NewRouletteItem()
		{
			ChatPanel.<NewRouletteItem>d__19 <NewRouletteItem>d__;
			<NewRouletteItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewRouletteItem>d__.<>4__this = this;
			<NewRouletteItem>d__.<>1__state = -1;
			<NewRouletteItem>d__.<>t__builder.Start<ChatPanel.<NewRouletteItem>d__19>(ref <NewRouletteItem>d__);
			return <NewRouletteItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D7BD RID: 251837 RVA: 0x00FA5F4C File Offset: 0x00FA414C
		protected override void OnShowBattleChildViewPanel(bool isFirst)
		{
			if (Singleton<Info>.Instance.OperationType != EOperationType.Desktop)
			{
				return;
			}
			this.RefreshChatRowItem();
			this.RefreshAfterInit();
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.TowerBuff, this.CheckInTower());
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.RogueInfo, this.CheckInRogue());
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.RogueRes, this.CheckInRogueRes());
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.MoraleAreaSum, this.CheckInMorale());
			CommonKeyItem environmentKeyItem = this.EnvironmentKeyItem;
			if (environmentKeyItem != null)
			{
				environmentKeyItem.RefreshAction("功能菜单");
			}
			this.RefreshEnvironmentKeyText();
			this.RefreshItemVisibleByPlatform();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlaySequencePurely("Start", false, false, null, null, false);
		}

		// Token: 0x0603D7BE RID: 251838 RVA: 0x00FA6008 File Offset: 0x00FA4208
		private void RefreshItemVisibleByPlatform()
		{
			bool uiactive = Singleton<Info>.Instance.IsInGamepad();
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			this.RefreshEnvironmentKeyVisible();
			this.RefreshRouletteItemVisible();
		}

		// Token: 0x0603D7BF RID: 251839 RVA: 0x00FA6040 File Offset: 0x00FA4240
		private void RefreshEnvironmentKeyVisible()
		{
			bool flag = Singleton<Info>.Instance.IsInGamepad();
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			EEnvironmentKey eenvironmentKey = (environmentKeyData != null) ? environmentKeyData.GetCurEnvironmentalKey() : EEnvironmentKey.None;
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(eenvironmentKey != EEnvironmentKey.None && this.IsPressMainCombineAction && flag);
		}

		// Token: 0x0603D7C0 RID: 251840 RVA: 0x00FA6090 File Offset: 0x00FA4290
		private void RefreshEnvironmentKeyText()
		{
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			string text = (environmentKeyData != null) ? environmentKeyData.GetCurKeyText() : null;
			if (!string.IsNullOrEmpty(text))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), text, Array.Empty<object>());
			}
		}

		// Token: 0x0603D7C1 RID: 251841 RVA: 0x00FA60D4 File Offset: 0x00FA42D4
		private void RefreshRouletteItemVisible()
		{
			BattleSkillLeftRouletteItem rouletteItem = this.RouletteItem;
			if (rouletteItem == null)
			{
				return;
			}
			rouletteItem.RefreshVisible();
		}

		// Token: 0x0603D7C2 RID: 251842 RVA: 0x00FA60E8 File Offset: 0x00FA42E8
		protected override void AddEvents()
		{
			if (base.GetOperationType() == EOperationType.Desktop)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshChatRowData, new Action<bool>(this.OnRefreshChatRowData));
				Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
				Singleton<EventSystem>.Instance.Add(EEventName.BattleUiEnvironmentKeyChanged, new Action(this.OnEnvironmentKeyChanged));
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiPressCombineButtonChanged, new Action<bool>(this.OnInputCombineButton));
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnInputCombineButton));
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.BattleUiMotorcycleStateChanged));
				ControllerBase<InputDistributeController>.Instance.BindActions(new <>z__ReadOnlyArray<string>(new string[]
				{
					"环境特性",
					"组合主键"
				}), new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
		}

		// Token: 0x0603D7C3 RID: 251843 RVA: 0x00FA61DC File Offset: 0x00FA43DC
		protected override void RemoveEvents()
		{
			if (base.GetOperationType() == EOperationType.Desktop)
			{
				if (Singleton<EventSystem>.Instance.Has(EEventName.OnRefreshChatRowData, new Action<bool>(this.OnRefreshChatRowData)))
				{
					Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshChatRowData, new Action<bool>(this.OnRefreshChatRowData));
				}
				if (Singleton<EventSystem>.Instance.Has(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange)))
				{
					Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
				}
				if (Singleton<EventSystem>.Instance.Has(EEventName.BattleUiEnvironmentKeyChanged, new Action(this.OnEnvironmentKeyChanged)))
				{
					Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiEnvironmentKeyChanged, new Action(this.OnEnvironmentKeyChanged));
				}
				if (Singleton<EventSystem>.Instance.Has(EEventName.BattleUiPressCombineButtonChanged, new Action<bool>(this.OnInputCombineButton)))
				{
					Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiPressCombineButtonChanged, new Action<bool>(this.OnInputCombineButton));
				}
				if (Singleton<EventSystem>.Instance.Has(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnInputCombineButton)))
				{
					Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnInputCombineButton));
				}
				if (Singleton<EventSystem>.Instance.Has(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.BattleUiMotorcycleStateChanged)))
				{
					Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.BattleUiMotorcycleStateChanged));
				}
				ControllerBase<InputDistributeController>.Instance.UnBindActions(new <>z__ReadOnlyArray<string>(new string[]
				{
					"环境特性",
					"组合主键"
				}), new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
		}

		// Token: 0x0603D7C4 RID: 251844 RVA: 0x00FA637C File Offset: 0x00FA457C
		private void OnRefreshChatRowData(bool bHistory)
		{
			if (base.GetOperationType() == EOperationType.Desktop)
			{
				this.RefreshChatRowItem();
				this.RefreshAfterUpdate(bHistory);
			}
		}

		// Token: 0x0603D7C5 RID: 251845 RVA: 0x00FA6394 File Offset: 0x00FA4594
		private void InputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.RefreshItemVisibleByPlatform();
		}

		// Token: 0x0603D7C6 RID: 251846 RVA: 0x00FA639C File Offset: 0x00FA459C
		private void OnEnvironmentKeyChanged()
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			this.RefreshEnvironmentKeyVisible();
			this.RefreshEnvironmentKeyText();
		}

		// Token: 0x0603D7C7 RID: 251847 RVA: 0x00FA63B7 File Offset: 0x00FA45B7
		private void OnInputCombineButton(bool isPress)
		{
			this.RefreshRouletteItemVisible();
		}

		// Token: 0x0603D7C8 RID: 251848 RVA: 0x00FA63BF File Offset: 0x00FA45BF
		private void BattleUiMotorcycleStateChanged(bool isDriving)
		{
			this.RefreshRouletteItemVisible();
		}

		// Token: 0x0603D7C9 RID: 251849 RVA: 0x00FA63C7 File Offset: 0x00FA45C7
		private void OnClickChatButton()
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ChatView))
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ChatView, null, null);
		}

		// Token: 0x0603D7CA RID: 251850 RVA: 0x00FA63EC File Offset: 0x00FA45EC
		[NullableContext(1)]
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionName == "环境特性")
			{
				if (!Singleton<InputManager>.Instance.IsAllowOpenViewByShortcutKey())
				{
					return;
				}
				if (actionType == InputDistributeDefine.EActionType.Press)
				{
					BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
					switch ((environmentKeyData != null) ? environmentKeyData.GetCurEnvironmentalKey() : EEnvironmentKey.None)
					{
					case EEnvironmentKey.SilentArea:
						ChatPanel.OpenSilentInfoView();
						return;
					case EEnvironmentKey.TowerBuff:
						this.OpenTowerBuffView();
						return;
					case EEnvironmentKey.DungeonGuide:
						this.OpenDungeonGuideView();
						return;
					case EEnvironmentKey.RogueInfo:
						this.OpenRogueInfoView();
						return;
					case EEnvironmentKey.TowerDefense:
						ChatPanel.OpenTowerDefenseInfoView();
						return;
					case EEnvironmentKey.ShipTowerBuff:
						ChatPanel.OpenShipTowerBuffView();
						return;
					case EEnvironmentKey.RogueRes:
						ChatPanel.OpenRogueResSummaryView();
						return;
					case EEnvironmentKey.MoraleBuff:
						ChatPanel.OpenMoraleBuffView();
						return;
					case EEnvironmentKey.MoraleAreaSum:
						ChatPanel.OpenMoraleAreaSumView();
						return;
					default:
						return;
					}
				}
			}
			else if (actionName == "组合主键")
			{
				this.OnInputMainCombineAction(actionType);
			}
		}

		// Token: 0x0603D7CB RID: 251851 RVA: 0x00FA64AD File Offset: 0x00FA46AD
		private void OnInputMainCombineAction(InputDistributeDefine.EActionType actionType)
		{
			this.IsPressMainCombineAction = (actionType == InputDistributeDefine.EActionType.Press);
			this.RefreshEnvironmentKeyVisible();
		}

		// Token: 0x0603D7CC RID: 251852 RVA: 0x00FA64BF File Offset: 0x00FA46BF
		private bool CheckInTower()
		{
			return ModelBase<TowerModel>.Instance.CheckInTower();
		}

		// Token: 0x0603D7CD RID: 251853 RVA: 0x00FA64CB File Offset: 0x00FA46CB
		private bool CheckInRogue()
		{
			return ModelBase<RoguelikeModel>.Instance.CheckInRoguelike() || ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue();
		}

		// Token: 0x0603D7CE RID: 251854 RVA: 0x00FA64E5 File Offset: 0x00FA46E5
		private bool CheckInRogueRes()
		{
			return ControllerBase<MapRogueController>.Instance.CheckInMapRogueInstance();
		}

		// Token: 0x0603D7CF RID: 251855 RVA: 0x00FA64F1 File Offset: 0x00FA46F1
		private bool CheckInMorale()
		{
			return ModelBase<MoraleBattleModel>.Instance.IsMoraleActive();
		}

		// Token: 0x0603D7D0 RID: 251856 RVA: 0x00FA64FD File Offset: 0x00FA46FD
		private void OpenTowerBuffView()
		{
			if (!this.CheckInTower())
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.TowerGuideView))
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerGuideView, null, null);
		}

		// Token: 0x0603D7D1 RID: 251857 RVA: 0x00FA652B File Offset: 0x00FA472B
		private void OpenDungeonGuideView()
		{
			InstanceDungeonGuideController.StartReplayGuide();
		}

		// Token: 0x0603D7D2 RID: 251858 RVA: 0x00FA6534 File Offset: 0x00FA4734
		private void OpenRogueInfoView()
		{
			if (!this.CheckInRogue())
			{
				return;
			}
			EUiViewName euiViewName = ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue() ? EUiViewName.WeeklyRogueInfo : EUiViewName.RogueInfoView;
			if (Singleton<UiManager>.Instance.IsViewShow(euiViewName))
			{
				return;
			}
			if (euiViewName == EUiViewName.RogueInfoView)
			{
				ControllerBase<RoguelikeController>.Instance.OpenRogueInfoView(null, true, true, ERogueInfoViewPage.Overview);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(euiViewName, null, null);
		}

		// Token: 0x0603D7D3 RID: 251859 RVA: 0x00FA659A File Offset: 0x00FA479A
		private static void OpenSilentInfoView()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiToggleSilentAreaInfoView);
		}

		// Token: 0x0603D7D4 RID: 251860 RVA: 0x00FA65AC File Offset: 0x00FA47AC
		private static void OpenTowerDefenseInfoView()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiToggleTowerDefenseInfoView);
		}

		// Token: 0x0603D7D5 RID: 251861 RVA: 0x00FA65BE File Offset: 0x00FA47BE
		private static void OpenShipTowerBuffView()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiToggleShipTowerBuffInfo);
		}

		// Token: 0x0603D7D6 RID: 251862 RVA: 0x00FA65D0 File Offset: 0x00FA47D0
		private static void OpenMoraleBuffView()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiToggleMoraleBuffInfo);
		}

		// Token: 0x0603D7D7 RID: 251863 RVA: 0x00FA65E2 File Offset: 0x00FA47E2
		private static void OpenRogueResSummaryView()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RogueBattleSummary))
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleSummary, null, null);
		}

		// Token: 0x0603D7D8 RID: 251864 RVA: 0x00FA6607 File Offset: 0x00FA4807
		private static void OpenMoraleAreaSumView()
		{
			if (!ModelBase<MoraleModel>.Instance.IsInitData)
			{
				return;
			}
			if (!ModelBase<MoraleBattleModel>.Instance.IsMoraleActive())
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MoraleAreaSumView, null, null);
		}

		// Token: 0x0603D7D9 RID: 251865 RVA: 0x00FA6634 File Offset: 0x00FA4834
		private void RefreshChatRowItem()
		{
			this.ActualChatDataList.Clear();
			this.BuildActualChatDataList();
			DynamicScrollView<ChatRowDynamicItem, ChatRowDynamicItemSize, ChatRowData> chatLoopScrollView = this.ChatLoopScrollView;
			if (chatLoopScrollView != null)
			{
				chatLoopScrollView.RefreshByData(this.ActualChatDataList.ToArray(), true, true);
			}
			DynamicScrollView<ChatRowDynamicItem, ChatRowDynamicItemSize, ChatRowData> chatLoopScrollView2 = this.ChatLoopScrollView;
			if (chatLoopScrollView2 == null)
			{
				return;
			}
			chatLoopScrollView2.BindLateUpdate(delegate(float _)
			{
				DynamicScrollView<ChatRowDynamicItem, ChatRowDynamicItemSize, ChatRowData> chatLoopScrollView3 = this.ChatLoopScrollView;
				if (chatLoopScrollView3 != null)
				{
					chatLoopScrollView3.ScrollToItemIndex(this.ActualChatDataList.Count - 1, true, false).Forget();
				}
				DynamicScrollView<ChatRowDynamicItem, ChatRowDynamicItemSize, ChatRowData> chatLoopScrollView4 = this.ChatLoopScrollView;
				if (chatLoopScrollView4 == null)
				{
					return;
				}
				chatLoopScrollView4.UnBindLateUpdate();
			});
		}

		// Token: 0x0603D7DA RID: 251866 RVA: 0x00FA668C File Offset: 0x00FA488C
		private void RefreshAfterInit()
		{
			if (this.ActualChatDataList.Count <= 0)
			{
				this.SetChatScrollViewRootVisible(false);
				return;
			}
			if (ModelBase<ChatModel>.Instance.HasOfflineMassage())
			{
				this.ActivateChatScrollView();
				this.DelayScroll(200f);
				return;
			}
			this.SetChatScrollViewRootVisible(false);
		}

		// Token: 0x0603D7DB RID: 251867 RVA: 0x00FA66C9 File Offset: 0x00FA48C9
		private void RefreshAfterUpdate(bool bHistory)
		{
			if (this.ActualChatDataList.Count <= 0)
			{
				this.SetChatScrollViewRootVisible(false);
				return;
			}
			this.DelayScroll(200f);
			if (!bHistory)
			{
				this.ActivateChatScrollView();
				return;
			}
			if (ModelBase<ChatModel>.Instance.HasOfflineMassage())
			{
				this.ActivateChatScrollView();
			}
		}

		// Token: 0x0603D7DC RID: 251868 RVA: 0x00FA6708 File Offset: 0x00FA4908
		private void BuildActualChatDataList()
		{
			foreach (ChatRowData chatRowData in ModelBase<ChatModel>.Instance.GetChatRowDataList())
			{
				if (chatRowData.ContentChatRoomType == EChatRoomType.Private)
				{
					int? targetPlayerId = chatRowData.TargetPlayerId;
					if (targetPlayerId == null)
					{
						continue;
					}
					FriendModel instance = ModelBase<FriendModel>.Instance;
					FriendData friendById = instance.GetFriendById(targetPlayerId.Value);
					if (friendById == null || instance.HasBlockedPlayer(targetPlayerId.Value) || friendById.GetBlockBySdk())
					{
						continue;
					}
				}
				this.ActualChatDataList.Add(chatRowData);
			}
		}

		// Token: 0x0603D7DD RID: 251869 RVA: 0x00FA67A8 File Offset: 0x00FA49A8
		public void DelayScroll(float delayTime)
		{
			this.RemoveScrollDelay();
			if (base.GetOperationType() != EOperationType.Desktop)
			{
				return;
			}
			this.ScrollDelayId = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.OnSetScrollProgressDelay), delayTime, null, null, true, 1f);
		}

		// Token: 0x0603D7DE RID: 251870 RVA: 0x00FA67DF File Offset: 0x00FA49DF
		private void RemoveScrollDelay()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.ScrollDelayId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.ScrollDelayId);
			}
			this.ScrollDelayId = null;
		}

		// Token: 0x0603D7DF RID: 251871 RVA: 0x00FA680B File Offset: 0x00FA4A0B
		private void RemoveChatViewTimeDown()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.ChatViewTimeDownId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.ChatViewTimeDownId);
			}
			this.ChatViewTimeDownId = null;
		}

		// Token: 0x0603D7E0 RID: 251872 RVA: 0x00FA6837 File Offset: 0x00FA4A37
		private void OnSetScrollProgressDelay(float _)
		{
			if (this.ActualChatDataList.Count <= 0)
			{
				return;
			}
			DynamicScrollView<ChatRowDynamicItem, ChatRowDynamicItemSize, ChatRowData> chatLoopScrollView = this.ChatLoopScrollView;
			if (chatLoopScrollView == null)
			{
				return;
			}
			chatLoopScrollView.ScrollToItemIndex(this.ActualChatDataList.Count - 1, true, false).Forget();
		}

		// Token: 0x0603D7E1 RID: 251873 RVA: 0x00FA686C File Offset: 0x00FA4A6C
		private void ActivateChatScrollView()
		{
			this.RemoveChatViewTimeDown();
			UUIItem item = base.GetItem(3);
			if (item == null || !item.bIsUIActive)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.StopCurrentSequence(false, false);
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.PlaySequencePurely("Start", false, false, null, null, false);
				}
			}
			this.SetChatScrollViewRootVisible(true);
			this.ChatViewTimeDownId = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.OnChatViewTimeDown), (float)this.ChatViewTimeDown, null, null, true, 1f);
		}

		// Token: 0x0603D7E2 RID: 251874 RVA: 0x00FA6900 File Offset: 0x00FA4B00
		private void OnChatViewTimeDown(float _)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlaySequencePurely("Close", false, false, null, null, false);
		}

		// Token: 0x0603D7E3 RID: 251875 RVA: 0x00FA6942 File Offset: 0x00FA4B42
		private void SetChatScrollViewRootVisible(bool bVisible)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(bVisible);
			}
			ModelBase<BattleUiModel>.Instance.ChatScrollViewVisible = bVisible;
		}

		// Token: 0x040228B9 RID: 141497
		private TimerHandle ChatViewTimeDownId;

		// Token: 0x040228BA RID: 141498
		private int ChatViewTimeDown;

		// Token: 0x040228BB RID: 141499
		private TimerHandle ScrollDelayId;

		// Token: 0x040228BC RID: 141500
		private bool IsPressMainCombineAction;

		// Token: 0x040228BD RID: 141501
		private CommonKeyItem EnvironmentKeyItem;

		// Token: 0x040228BE RID: 141502
		private BattleSkillLeftRouletteItem RouletteItem;

		// Token: 0x040228BF RID: 141503
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040228C0 RID: 141504
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private DynamicScrollView<ChatRowDynamicItem, ChatRowDynamicItemSize, ChatRowData> ChatLoopScrollView;

		// Token: 0x040228C1 RID: 141505
		private ChatRowDynamicItemSize ChatBaseItem;

		// Token: 0x040228C2 RID: 141506
		[Nullable(1)]
		private readonly List<ChatRowData> ActualChatDataList = new List<ChatRowData>();

		// Token: 0x0200BFA1 RID: 49057
		[NullableContext(0)]
		private enum EDesktopChildType
		{
			// Token: 0x0403AFB6 RID: 241590
			ChatButton,
			// Token: 0x0403AFB7 RID: 241591
			ChatScrollView,
			// Token: 0x0403AFB8 RID: 241592
			ChatRowItemContent,
			// Token: 0x0403AFB9 RID: 241593
			PanelChatScrollViewRoot,
			// Token: 0x0403AFBA RID: 241594
			ChatItem,
			// Token: 0x0403AFBB RID: 241595
			ChatKeyItem,
			// Token: 0x0403AFBC RID: 241596
			KeyItemGroup,
			// Token: 0x0403AFBD RID: 241597
			EnvironmentKeyItemContainer,
			// Token: 0x0403AFBE RID: 241598
			EnvironmentKeyItem,
			// Token: 0x0403AFBF RID: 241599
			EnvironmentKeyItemText,
			// Token: 0x0403AFC0 RID: 241600
			RouletteItem,
			// Token: 0x0403AFC1 RID: 241601
			PanelChatItem
		}

		// Token: 0x0200BFA2 RID: 49058
		[NullableContext(0)]
		private enum EPadChildType
		{
			// Token: 0x0403AFC3 RID: 241603
			ChatButton,
			// Token: 0x0403AFC4 RID: 241604
			RedDotItem,
			// Token: 0x0403AFC5 RID: 241605
			ChatPadItem
		}
	}
}
