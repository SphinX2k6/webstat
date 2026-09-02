using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FA3 RID: 24483
	[NullableContext(1)]
	[Nullable(0)]
	public class GamepadSkillButtonPanel : BattleChildViewPanel
	{
		// Token: 0x0603D816 RID: 251926 RVA: 0x00FA7D2C File Offset: 0x00FA5F2C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 23;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D817 RID: 251927 RVA: 0x00FA8059 File Offset: 0x00FA6259
		public override void InitializeTemp()
		{
			this.GamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
		}

		// Token: 0x0603D818 RID: 251928 RVA: 0x00FA806C File Offset: 0x00FA626C
		public override UniTask InitializeAsync()
		{
			GamepadSkillButtonPanel.<InitializeAsync>d__21 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<GamepadSkillButtonPanel.<InitializeAsync>d__21>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D819 RID: 251929 RVA: 0x00FA80B0 File Offset: 0x00FA62B0
		public override void Reset()
		{
			this.BattleSkillItemList.Clear();
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer != null)
			{
				tweenAnimPlayer.Clear(false);
			}
			this.TweenAnimPlayer = null;
			LevelSequencePlayer dpadLevelSequencePlayer = this.DpadLevelSequencePlayer;
			if (dpadLevelSequencePlayer != null)
			{
				dpadLevelSequencePlayer.Clear();
			}
			this.DpadLevelSequencePlayer = null;
			SkillButtonUiGamepadDataBase gamepadData = this.GamepadData;
			if (gamepadData != null)
			{
				gamepadData.ClearInputAxis();
			}
			base.Reset();
		}

		// Token: 0x0603D81A RID: 251930 RVA: 0x00FA8110 File Offset: 0x00FA6310
		protected override void OnAfterShow()
		{
			foreach (BattleSkillGamepadItem battleSkillGamepadItem in this.BattleSkillItemList)
			{
				battleSkillGamepadItem.RefreshEnable(true);
			}
		}

		// Token: 0x0603D81B RID: 251931 RVA: 0x00FA8164 File Offset: 0x00FA6364
		protected override void OnShowBattleChildViewPanel(bool isFirst)
		{
			foreach (BattleSkillGamepadItem battleSkillGamepadItem in this.BattleSkillItemList)
			{
				battleSkillGamepadItem.RefreshSkillCoolDownOnShow();
			}
		}

		// Token: 0x0603D81C RID: 251932 RVA: 0x00FA81B4 File Offset: 0x00FA63B4
		public override void OnTickBattleChildViewPanel(float delta)
		{
			if (!this.Visible)
			{
				return;
			}
			foreach (BattleSkillGamepadItem battleSkillGamepadItem in this.BattleSkillItemList)
			{
				battleSkillGamepadItem.Tick(delta);
			}
		}

		// Token: 0x0603D81D RID: 251933 RVA: 0x00FA8210 File Offset: 0x00FA6410
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<ESkillButtonRefreshReason>(EEventName.OnSkillButtonDataRefresh, new Action<ESkillButtonRefreshReason>(this.OnSkillButtonDataRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSkillButtonDataClear, new Action(this.OnSkillButtonDataClear));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSkillButtonIndexRefresh, new Action(this.OnSkillButtonIndexRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType, int>(EEventName.OnSkillButtonEnableRefresh, new Action<ESkillButtonType, int>(this.OnSkillButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonVisibleRefresh, new Action<ESkillButtonType>(this.OnSkillButtonVisibleRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonDynamicEffectRefresh, new Action<ESkillButtonType>(this.OnSkillButtonDynamicEffectRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType, int, int>(EEventName.OnSkillButtonCustomRefresh, new Action<ESkillButtonType, int, int>(this.OnSkillButtonCustomRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonSkillIdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonSkillIdRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonAttributeRefresh, new Action<ESkillButtonType>(this.OnSkillButtonAttributeRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonIconPathRefresh, new Action<ESkillButtonType>(this.OnSkillButtonIconPathRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonEnableRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonVisibleRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonVisibleRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonSkillIdRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonSkillIdRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonIconPathRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonIconPathRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonDynamicEffectRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonDynamicEffectRefresh));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
			Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.CharSkillCdPauseStateChanged, new Action<bool>(this.OnCharSkillCdPauseStateChanged));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Add<EUiViewName, UiViewBase>(EEventName.OnViewDone, new Action<EUiViewName, UiViewBase>(this.OnViewDone));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiChatScrollViewVisibleChanged, new Action(this.OnChatScrollViewVisibleChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiSwitchInteractStateChanged, new Action(this.OnSwitchInteractStateChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiGamepadDataChanged, new Action(this.OnGamepadDataChanged));
			if (this.GamepadData.GamepadDataType == ESkillButtonGamepadDataType.Motorcycle)
			{
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnInputMotorcycleCombineButton));
			}
			else
			{
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiPressCombineButtonChanged, new Action<bool>(this.OnInputCombineButton));
			}
			ControllerBase<InputDistributeController>.Instance.BindActions(this.GamepadData.GetAllActionNameList(), new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			ControllerBase<InputDistributeController>.Instance.BindAxes(this.GamepadData.GetAllAxisNameList(), new TInputHandle<float>(this.OnInputAxis));
			ControllerBase<InputDistributeController>.Instance.BindAxis("MoveForward", new TInputHandle<float>(this.OnInputMoveForward));
			ControllerBase<InputDistributeController>.Instance.BindAxis("MoveRight", new TInputHandle<float>(this.OnInputMoveRight));
		}

		// Token: 0x0603D81E RID: 251934 RVA: 0x00FA8590 File Offset: 0x00FA6790
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonDataRefresh, new Action<ESkillButtonRefreshReason>(this.OnSkillButtonDataRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonDataClear, new Action(this.OnSkillButtonDataClear));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonIndexRefresh, new Action(this.OnSkillButtonIndexRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonEnableRefresh, new Action<ESkillButtonType, int>(this.OnSkillButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonVisibleRefresh, new Action<ESkillButtonType>(this.OnSkillButtonVisibleRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonDynamicEffectRefresh, new Action<ESkillButtonType>(this.OnSkillButtonDynamicEffectRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonCustomRefresh, new <>f__AnonymousDelegate3<ESkillButtonType, int, int>(this.OnSkillButtonCustomRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonSkillIdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonSkillIdRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonAttributeRefresh, new Action<ESkillButtonType>(this.OnSkillButtonAttributeRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonIconPathRefresh, new Action<ESkillButtonType>(this.OnSkillButtonIconPathRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonEnableRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonVisibleRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonVisibleRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonSkillIdRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonSkillIdRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonIconPathRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonIconPathRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonDynamicEffectRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonDynamicEffectRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
			Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
			Singleton<EventSystem>.Instance.Remove(EEventName.CharSkillCdPauseStateChanged, new Action<bool>(this.OnCharSkillCdPauseStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnViewDone, new Action<EUiViewName, UiViewBase>(this.OnViewDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiChatScrollViewVisibleChanged, new Action(this.OnChatScrollViewVisibleChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiSwitchInteractStateChanged, new Action(this.OnSwitchInteractStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiGamepadDataChanged, new Action(this.OnGamepadDataChanged));
			ControllerBase<InputDistributeController>.Instance.UnBindActions(this.GamepadData.GetAllActionNameList(), new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			ControllerBase<InputDistributeController>.Instance.UnBindAxes(this.GamepadData.GetAllAxisNameList(), new TInputHandle<float>(this.OnInputAxis));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("MoveForward", new TInputHandle<float>(this.OnInputMoveForward));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("MoveRight", new TInputHandle<float>(this.OnInputMoveRight));
			if (this.GamepadData.GamepadDataType == ESkillButtonGamepadDataType.Motorcycle)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnInputMotorcycleCombineButton));
				return;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiPressCombineButtonChanged, new Action<bool>(this.OnInputCombineButton));
		}

		// Token: 0x0603D81F RID: 251935 RVA: 0x00FA890C File Offset: 0x00FA6B0C
		private void RefreshGamepadData()
		{
			base.SetVisible(EBattleUiVisibleReason.Gamepad, Singleton<Info>.Instance.IsInGamepad());
			this.GamepadData.RefreshInteractBehaviorData();
			this.GamepadData.RefreshAimState();
		}

		// Token: 0x0603D820 RID: 251936 RVA: 0x00FA8938 File Offset: 0x00FA6B38
		private void InitKeyName()
		{
			foreach (BattleSkillGamepadItem battleSkillGamepadItem in this.BattleSkillItemList)
			{
				if (battleSkillGamepadItem.IsSubButton)
				{
					int index = battleSkillGamepadItem.GetInputIndex() - 4;
					battleSkillGamepadItem.SetKeyName(this.GamepadData.ButtonKeyList[index]);
				}
			}
		}

		// Token: 0x0603D821 RID: 251937 RVA: 0x00FA89AC File Offset: 0x00FA6BAC
		private void RefreshAllBattleSkillItems()
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.RefreshMainBattleSkillItems();
			this.RefreshDpadMiddleItem();
			this.RefreshSubBattleSkillItems();
			BattleSkillCombineItem combineItem = this.CombineItem;
			if (combineItem == null)
			{
				return;
			}
			combineItem.Refresh();
		}

		// Token: 0x0603D822 RID: 251938 RVA: 0x00FA89E0 File Offset: 0x00FA6BE0
		private void RefreshMainBattleSkillItems()
		{
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			List<int?> curButtonTypeList = this.GamepadData.CurButtonTypeList;
			for (int i = 0; i < 12; i++)
			{
				BattleSkillGamepadItem battleSkillGamepadItem = this.BattleSkillItemList[i];
				if (i >= curButtonTypeList.Count)
				{
					battleSkillGamepadItem.Refresh(null);
				}
				else
				{
					int? num = curButtonTypeList[i];
					if (num == null)
					{
						battleSkillGamepadItem.Refresh(null);
					}
					else
					{
						SkillButtonData skillButtonDataByButton = instance.GetSkillButtonDataByButton((ESkillButtonType)num.Value);
						if (skillButtonDataByButton == null)
						{
							BehaviorButtonData behaviorButtonDataByButton = instance.GetBehaviorButtonDataByButton((EBehaviorType)num.Value);
							if (behaviorButtonDataByButton != null && behaviorButtonDataByButton.IsVisible())
							{
								battleSkillGamepadItem.RefreshByBehaviorButtonData(behaviorButtonDataByButton);
								goto IL_95;
							}
						}
						this.RefreshMainSkillItemBySkillButtonData(battleSkillGamepadItem, skillButtonDataByButton);
					}
				}
				IL_95:;
			}
		}

		// Token: 0x0603D823 RID: 251939 RVA: 0x00FA8A8E File Offset: 0x00FA6C8E
		private void RefreshMainSkillItemBySkillButtonData(BattleSkillGamepadItem battleSkillItem, [Nullable(2)] SkillButtonData skillButtonData)
		{
			if (skillButtonData == null)
			{
				battleSkillItem.Refresh(null);
				return;
			}
			if (skillButtonData.GetSkillId() == 0 || !skillButtonData.IsVisible())
			{
				battleSkillItem.Refresh(null);
				return;
			}
			battleSkillItem.Refresh(skillButtonData);
		}

		// Token: 0x0603D824 RID: 251940 RVA: 0x00FA8ABC File Offset: 0x00FA6CBC
		private void RefreshDpadMiddleItem()
		{
			bool existDpadSkillItem = this.ExistDpadSkillItem;
			this.ExistDpadSkillItem = false;
			for (int i = 0; i < 4; i++)
			{
				if (this.BattleSkillItemList[i + 8].IsVisible())
				{
					this.DpadItem.SetArrowVisible(i, true);
					this.ExistDpadSkillItem = true;
				}
				else
				{
					this.DpadItem.SetArrowVisible(i, false);
				}
			}
			BattleSkillDpadItem dpadItem = this.DpadItem;
			if (dpadItem != null)
			{
				dpadItem.SetBgVisible(this.ExistDpadSkillItem);
			}
			if (existDpadSkillItem != this.ExistDpadSkillItem && this.DpadLevelSequencePlayer != null)
			{
				this.DpadLevelSequencePlayer.StopCurrentSequence(false, false);
				this.DpadLevelSequencePlayer.PlaySequencePurely(this.ExistDpadSkillItem ? "Show" : "Hide", false, false, null, null, false);
			}
		}

		// Token: 0x0603D825 RID: 251941 RVA: 0x00FA8B7C File Offset: 0x00FA6D7C
		private void RefreshSubBattleSkillItems()
		{
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			List<int?> curButtonTypeList = this.GamepadData.CurButtonTypeList;
			for (int i = 12; i < 16; i++)
			{
				BattleSkillGamepadItem battleSkillGamepadItem = this.BattleSkillItemList[i];
				if (i >= curButtonTypeList.Count)
				{
					battleSkillGamepadItem.Deactivate();
				}
				else
				{
					int? num = curButtonTypeList[i];
					if (num == null)
					{
						battleSkillGamepadItem.Deactivate();
					}
					else
					{
						SkillButtonData skillButtonDataByButton = instance.GetSkillButtonDataByButton((ESkillButtonType)num.Value);
						if (skillButtonDataByButton == null)
						{
							BehaviorButtonData behaviorButtonDataByButton = instance.GetBehaviorButtonDataByButton((EBehaviorType)num.Value);
							if (behaviorButtonDataByButton != null)
							{
								battleSkillGamepadItem.RefreshByBehaviorButtonData(behaviorButtonDataByButton);
							}
							else
							{
								battleSkillGamepadItem.Deactivate();
							}
						}
						else if (skillButtonDataByButton.GetSkillId() == 0)
						{
							battleSkillGamepadItem.Deactivate();
						}
						else
						{
							battleSkillGamepadItem.Refresh(skillButtonDataByButton);
						}
					}
				}
			}
		}

		// Token: 0x0603D826 RID: 251942 RVA: 0x00FA8C38 File Offset: 0x00FA6E38
		private void DeactivateAllBattleSkillItems()
		{
			foreach (BattleSkillGamepadItem battleSkillGamepadItem in this.BattleSkillItemList)
			{
				battleSkillGamepadItem.Deactivate();
			}
		}

		// Token: 0x0603D827 RID: 251943 RVA: 0x00FA8C88 File Offset: 0x00FA6E88
		public UniTask NewAllBattleSkillItems()
		{
			GamepadSkillButtonPanel.<NewAllBattleSkillItems>d__36 <NewAllBattleSkillItems>d__;
			<NewAllBattleSkillItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAllBattleSkillItems>d__.<>4__this = this;
			<NewAllBattleSkillItems>d__.<>1__state = -1;
			<NewAllBattleSkillItems>d__.<>t__builder.Start<GamepadSkillButtonPanel.<NewAllBattleSkillItems>d__36>(ref <NewAllBattleSkillItems>d__);
			return <NewAllBattleSkillItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603D828 RID: 251944 RVA: 0x00FA8CCC File Offset: 0x00FA6ECC
		private UniTask NewCombineItem()
		{
			GamepadSkillButtonPanel.<NewCombineItem>d__37 <NewCombineItem>d__;
			<NewCombineItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewCombineItem>d__.<>4__this = this;
			<NewCombineItem>d__.<>1__state = -1;
			<NewCombineItem>d__.<>t__builder.Start<GamepadSkillButtonPanel.<NewCombineItem>d__37>(ref <NewCombineItem>d__);
			return <NewCombineItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D829 RID: 251945 RVA: 0x00FA8D10 File Offset: 0x00FA6F10
		private UniTask NewDpadItem()
		{
			GamepadSkillButtonPanel.<NewDpadItem>d__38 <NewDpadItem>d__;
			<NewDpadItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewDpadItem>d__.<>4__this = this;
			<NewDpadItem>d__.<>1__state = -1;
			<NewDpadItem>d__.<>t__builder.Start<GamepadSkillButtonPanel.<NewDpadItem>d__38>(ref <NewDpadItem>d__);
			return <NewDpadItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D82A RID: 251946 RVA: 0x00FA8D54 File Offset: 0x00FA6F54
		private UniTask NewRouletteItem()
		{
			GamepadSkillButtonPanel.<NewRouletteItem>d__39 <NewRouletteItem>d__;
			<NewRouletteItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewRouletteItem>d__.<>4__this = this;
			<NewRouletteItem>d__.<>1__state = -1;
			<NewRouletteItem>d__.<>t__builder.Start<GamepadSkillButtonPanel.<NewRouletteItem>d__39>(ref <NewRouletteItem>d__);
			return <NewRouletteItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D82B RID: 251947 RVA: 0x00FA8D98 File Offset: 0x00FA6F98
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<BattleSkillGamepadItem> NewBattleSkillItem(AActor rootActor, int inputIndex)
		{
			GamepadSkillButtonPanel.<NewBattleSkillItem>d__40 <NewBattleSkillItem>d__;
			<NewBattleSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<BattleSkillGamepadItem>.Create();
			<NewBattleSkillItem>d__.<>4__this = this;
			<NewBattleSkillItem>d__.rootActor = rootActor;
			<NewBattleSkillItem>d__.inputIndex = inputIndex;
			<NewBattleSkillItem>d__.<>1__state = -1;
			<NewBattleSkillItem>d__.<>t__builder.Start<GamepadSkillButtonPanel.<NewBattleSkillItem>d__40>(ref <NewBattleSkillItem>d__);
			return <NewBattleSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D82C RID: 251948 RVA: 0x00FA8DEB File Offset: 0x00FA6FEB
		private BattleSkillGamepadItem GetBattleSkillItem(int inputIndex)
		{
			return this.BattleSkillItemList[inputIndex];
		}

		// Token: 0x0603D82D RID: 251949 RVA: 0x00FA8DFC File Offset: 0x00FA6FFC
		[NullableContext(2)]
		public BattleSkillGamepadItem GetBattleSkillItemByButtonType(int buttonType)
		{
			int num = ModelBase<SkillButtonUiModel>.Instance.GamepadData.CurButtonTypeList.IndexOf(new int?(buttonType));
			if (num < 0)
			{
				return null;
			}
			return this.GetBattleSkillItem(num);
		}

		// Token: 0x0603D82E RID: 251950 RVA: 0x00FA8E31 File Offset: 0x00FA7031
		[NullableContext(2)]
		private BattleSkillGamepadItem GetSwitchBattleSkillItemByButtonType(int buttonType)
		{
			if (buttonType != 7)
			{
				return null;
			}
			SkillButtonUiGamepadDataBase gamepadData = this.GamepadData;
			if (gamepadData == null || !gamepadData.SwitchInteractData.IsSwitchInteractOpen)
			{
				return null;
			}
			return this.GetBattleSkillItemByButtonType(104);
		}

		// Token: 0x0603D82F RID: 251951 RVA: 0x00FA8E5F File Offset: 0x00FA705F
		private void OnSkillButtonDataRefresh(ESkillButtonRefreshReason refreshReason)
		{
			this.RefreshAllBattleSkillItems();
		}

		// Token: 0x0603D830 RID: 251952 RVA: 0x00FA8E67 File Offset: 0x00FA7067
		private void OnSkillButtonDataClear()
		{
			this.DeactivateAllBattleSkillItems();
		}

		// Token: 0x0603D831 RID: 251953 RVA: 0x00FA8E6F File Offset: 0x00FA706F
		private void OnSkillButtonIndexRefresh()
		{
			if (this.GamepadData.RefreshButtonData())
			{
				this.RefreshAllBattleSkillItems();
			}
		}

		// Token: 0x0603D832 RID: 251954 RVA: 0x00FA8E84 File Offset: 0x00FA7084
		private void OnSkillButtonEnableRefresh(ESkillButtonType buttonType, int extendCoolDown)
		{
			if (!this.Visible)
			{
				return;
			}
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (((battleSkillItemByButtonType != null) ? battleSkillItemByButtonType.GetSkillButtonData() : null) != null)
			{
				battleSkillItemByButtonType.RefreshEnable(false);
			}
			BattleSkillGamepadItem switchBattleSkillItemByButtonType = this.GetSwitchBattleSkillItemByButtonType((int)buttonType);
			if (((switchBattleSkillItemByButtonType != null) ? switchBattleSkillItemByButtonType.GetSkillButtonData() : null) != null)
			{
				switchBattleSkillItemByButtonType.RefreshEnable(false);
			}
		}

		// Token: 0x0603D833 RID: 251955 RVA: 0x00FA8ED4 File Offset: 0x00FA70D4
		private void OnSkillButtonVisibleRefresh(ESkillButtonType buttonType)
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (battleSkillItemByButtonType == null)
			{
				this.GamepadData.RefreshButtonData();
				this.RefreshAllBattleSkillItems();
				return;
			}
			SkillButtonData skillButtonDataByButton = ModelBase<SkillButtonUiModel>.Instance.GetSkillButtonDataByButton(buttonType);
			if (skillButtonDataByButton != null)
			{
				this.RefreshMainSkillItemBySkillButtonData(battleSkillItemByButtonType, skillButtonDataByButton);
			}
			BattleSkillGamepadItem switchBattleSkillItemByButtonType = this.GetSwitchBattleSkillItemByButtonType((int)buttonType);
			if (switchBattleSkillItemByButtonType != null)
			{
				if (switchBattleSkillItemByButtonType.SrcBehaviorButtonData != null)
				{
					switchBattleSkillItemByButtonType.RefreshByBehaviorButtonData(switchBattleSkillItemByButtonType.SrcBehaviorButtonData);
					return;
				}
				if (switchBattleSkillItemByButtonType.BehaviorButtonData != null)
				{
					switchBattleSkillItemByButtonType.RefreshByBehaviorButtonData(switchBattleSkillItemByButtonType.BehaviorButtonData);
				}
			}
		}

		// Token: 0x0603D834 RID: 251956 RVA: 0x00FA8F4C File Offset: 0x00FA714C
		private void OnSkillButtonDynamicEffectRefresh(ESkillButtonType buttonType)
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (((battleSkillItemByButtonType != null) ? battleSkillItemByButtonType.GetSkillButtonData() : null) != null)
			{
				battleSkillItemByButtonType.RefreshDynamicEffect();
			}
			BattleSkillGamepadItem switchBattleSkillItemByButtonType = this.GetSwitchBattleSkillItemByButtonType((int)buttonType);
			if (((switchBattleSkillItemByButtonType != null) ? switchBattleSkillItemByButtonType.GetSkillButtonData() : null) != null)
			{
				switchBattleSkillItemByButtonType.RefreshDynamicEffect();
			}
		}

		// Token: 0x0603D835 RID: 251957 RVA: 0x00FA8F94 File Offset: 0x00FA7194
		private void OnSkillButtonCustomRefresh(ESkillButtonType buttonType, int from = -1, int param = 0)
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (((battleSkillItemByButtonType != null) ? battleSkillItemByButtonType.GetSkillButtonData() : null) != null)
			{
				battleSkillItemByButtonType.RefreshCustomHdData(from, param);
			}
			BattleSkillGamepadItem switchBattleSkillItemByButtonType = this.GetSwitchBattleSkillItemByButtonType((int)buttonType);
			if (((switchBattleSkillItemByButtonType != null) ? switchBattleSkillItemByButtonType.GetSkillButtonData() : null) != null)
			{
				switchBattleSkillItemByButtonType.RefreshCustomHdData(from, param);
			}
		}

		// Token: 0x0603D836 RID: 251958 RVA: 0x00FA8FE0 File Offset: 0x00FA71E0
		private void OnSkillButtonSkillIdRefresh(ESkillButtonType buttonType)
		{
			SkillButtonData skillButtonDataByButton = ModelBase<SkillButtonUiModel>.Instance.GetSkillButtonDataByButton(buttonType);
			if (skillButtonDataByButton == null)
			{
				return;
			}
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (battleSkillItemByButtonType != null)
			{
				battleSkillItemByButtonType.Refresh(skillButtonDataByButton);
			}
			BattleSkillGamepadItem switchBattleSkillItemByButtonType = this.GetSwitchBattleSkillItemByButtonType((int)buttonType);
			if (((switchBattleSkillItemByButtonType != null) ? switchBattleSkillItemByButtonType.SrcBehaviorButtonData : null) != null)
			{
				switchBattleSkillItemByButtonType.RefreshByBehaviorButtonData(switchBattleSkillItemByButtonType.SrcBehaviorButtonData);
				return;
			}
			if (((switchBattleSkillItemByButtonType != null) ? switchBattleSkillItemByButtonType.BehaviorButtonData : null) != null)
			{
				switchBattleSkillItemByButtonType.RefreshByBehaviorButtonData(switchBattleSkillItemByButtonType.BehaviorButtonData);
			}
		}

		// Token: 0x0603D837 RID: 251959 RVA: 0x00FA904C File Offset: 0x00FA724C
		private void OnSkillButtonAttributeRefresh(ESkillButtonType buttonType)
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (battleSkillItemByButtonType != null)
			{
				battleSkillItemByButtonType.RefreshAttribute(true);
			}
			BattleSkillGamepadItem switchBattleSkillItemByButtonType = this.GetSwitchBattleSkillItemByButtonType((int)buttonType);
			if (((switchBattleSkillItemByButtonType != null) ? switchBattleSkillItemByButtonType.GetSkillButtonData() : null) != null)
			{
				switchBattleSkillItemByButtonType.RefreshAttribute(true);
			}
		}

		// Token: 0x0603D838 RID: 251960 RVA: 0x00FA9088 File Offset: 0x00FA7288
		private void OnSkillButtonIconPathRefresh(ESkillButtonType buttonType)
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (battleSkillItemByButtonType != null)
			{
				battleSkillItemByButtonType.RefreshSkillIcon();
				battleSkillItemByButtonType.RefreshSkillName();
			}
			BattleSkillGamepadItem switchBattleSkillItemByButtonType = this.GetSwitchBattleSkillItemByButtonType((int)buttonType);
			if (((switchBattleSkillItemByButtonType != null) ? switchBattleSkillItemByButtonType.GetSkillButtonData() : null) != null)
			{
				switchBattleSkillItemByButtonType.RefreshSkillIcon();
				switchBattleSkillItemByButtonType.RefreshSkillName();
			}
		}

		// Token: 0x0603D839 RID: 251961 RVA: 0x00FA90D0 File Offset: 0x00FA72D0
		private void OnSkillButtonCdRefresh(ESkillButtonType buttonType)
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (battleSkillItemByButtonType != null)
			{
				battleSkillItemByButtonType.RefreshSkillCoolDown();
			}
			BattleSkillGamepadItem switchBattleSkillItemByButtonType = this.GetSwitchBattleSkillItemByButtonType((int)buttonType);
			if (((switchBattleSkillItemByButtonType != null) ? switchBattleSkillItemByButtonType.GetSkillButtonData() : null) != null)
			{
				switchBattleSkillItemByButtonType.RefreshSkillCoolDown();
			}
		}

		// Token: 0x0603D83A RID: 251962 RVA: 0x00FA910C File Offset: 0x00FA730C
		private void OnPauseGame(int flag)
		{
			foreach (BattleSkillGamepadItem battleSkillGamepadItem in this.BattleSkillItemList)
			{
				battleSkillGamepadItem.PauseGame(flag);
			}
		}

		// Token: 0x0603D83B RID: 251963 RVA: 0x00FA9160 File Offset: 0x00FA7360
		private void OnBehaviorButtonEnableRefresh(EBehaviorType buttonType)
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshEnable(false);
		}

		// Token: 0x0603D83C RID: 251964 RVA: 0x00FA9174 File Offset: 0x00FA7374
		private void OnBehaviorButtonVisibleRefresh(EBehaviorType buttonType)
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshVisible();
		}

		// Token: 0x0603D83D RID: 251965 RVA: 0x00FA9188 File Offset: 0x00FA7388
		private void OnBehaviorButtonSkillIdRefresh(EBehaviorType buttonType)
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (((battleSkillItemByButtonType != null) ? battleSkillItemByButtonType.BehaviorButtonData : null) != null)
			{
				battleSkillItemByButtonType.RefreshByBehaviorButtonData(battleSkillItemByButtonType.BehaviorButtonData);
			}
		}

		// Token: 0x0603D83E RID: 251966 RVA: 0x00FA91B7 File Offset: 0x00FA73B7
		private void OnBehaviorButtonIconPathRefresh(EBehaviorType buttonType)
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshSkillIcon();
		}

		// Token: 0x0603D83F RID: 251967 RVA: 0x00FA91CA File Offset: 0x00FA73CA
		private void OnBehaviorButtonDynamicEffectRefresh(EBehaviorType buttonType)
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType((int)buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshDynamicEffect();
		}

		// Token: 0x0603D840 RID: 251968 RVA: 0x00FA91E0 File Offset: 0x00FA73E0
		private void OnChangedTimeScale()
		{
			foreach (BattleSkillGamepadItem battleSkillGamepadItem in this.BattleSkillItemList)
			{
				battleSkillGamepadItem.RefreshTimeDilation();
			}
		}

		// Token: 0x0603D841 RID: 251969 RVA: 0x00FA9230 File Offset: 0x00FA7430
		private void OnCharSkillCdPauseStateChanged(bool b)
		{
			this.OnChangedTimeScale();
		}

		// Token: 0x0603D842 RID: 251970 RVA: 0x00FA9238 File Offset: 0x00FA7438
		private void InputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				base.SetVisible(EBattleUiVisibleReason.Gamepad, true);
				this.RefreshAllBattleSkillItems();
				return;
			}
			base.SetVisible(EBattleUiVisibleReason.Gamepad, false);
			SkillButtonUiGamepadDataBase gamepadData = this.GamepadData;
			if (gamepadData == null)
			{
				return;
			}
			gamepadData.ClearInputAxis();
		}

		// Token: 0x0603D843 RID: 251971 RVA: 0x00FA926D File Offset: 0x00FA746D
		private void OnInputCombineButton(bool isPress)
		{
			this.RefreshAllBattleSkillItems();
			this.RefreshCombineItem();
			this.PlayCombineItemAnim(isPress);
			this.RefreshRouletteItem();
		}

		// Token: 0x0603D844 RID: 251972 RVA: 0x00FA9288 File Offset: 0x00FA7488
		private void OnInputMotorcycleCombineButton(bool isPress)
		{
			this.RefreshAllBattleSkillItems();
			this.RefreshCombineItem();
			this.PlayCombineItemAnim(isPress);
			this.RefreshRouletteItem();
			this.RefreshDpadKeyItemEnable();
		}

		// Token: 0x0603D845 RID: 251973 RVA: 0x00FA92A9 File Offset: 0x00FA74A9
		private void RefreshCombineItem()
		{
			BattleSkillCombineItem combineItem = this.CombineItem;
			if (combineItem == null)
			{
				return;
			}
			combineItem.SetVisible(!this.GamepadData.GetIsPressCombineButton());
		}

		// Token: 0x0603D846 RID: 251974 RVA: 0x00FA92C9 File Offset: 0x00FA74C9
		private void RefreshRouletteItem()
		{
			BattleSkillRouletteItem rouletteItem = this.RouletteItem;
			if (rouletteItem == null)
			{
				return;
			}
			rouletteItem.RefreshVisible();
		}

		// Token: 0x0603D847 RID: 251975 RVA: 0x00FA92DC File Offset: 0x00FA74DC
		private void PlayCombineItemAnim(bool isPress)
		{
			if (isPress)
			{
				for (int i = 0; i < 4; i++)
				{
					if (this.GamepadData.MainSkillCombineButtonTypeList[i] != 0)
					{
						this.BattleSkillItemList[i].PlayPressCombineButtonSeq();
					}
				}
				for (int j = 8; j < 12; j++)
				{
					int num = (j >= this.GamepadData.DpadSkillCombineButtonTypeList.Length) ? 0 : this.GamepadData.DpadSkillCombineButtonTypeList[j];
					int num2 = (j >= this.GamepadData.DpadSkillButtonTypeList.Length) ? 0 : this.GamepadData.DpadSkillButtonTypeList[j];
					if (num != num2)
					{
						BattleSkillGamepadItem battleSkillGamepadItem = (j < this.BattleSkillItemList.Count) ? this.BattleSkillItemList[j] : null;
						if (battleSkillGamepadItem != null)
						{
							battleSkillGamepadItem.PlayPressCombineButtonSeq();
						}
					}
				}
				this.TweenAnimPlayer.StopTweenAnim(21);
				this.TweenAnimPlayer.PlayTweenAnim(22);
				return;
			}
			for (int k = 0; k < 4; k++)
			{
				this.BattleSkillItemList[k].PlayReleaseCombineButtonSeq();
			}
			this.TweenAnimPlayer.StopTweenAnim(22);
			this.TweenAnimPlayer.PlayTweenAnim(21);
		}

		// Token: 0x0603D848 RID: 251976 RVA: 0x00FA93EA File Offset: 0x00FA75EA
		private void OnChatScrollViewVisibleChanged()
		{
			this.RefreshDpadPosition();
		}

		// Token: 0x0603D849 RID: 251977 RVA: 0x00FA93F2 File Offset: 0x00FA75F2
		private void RefreshDpadPosition()
		{
			if (ModelBase<BattleUiModel>.Instance.ChatScrollViewVisible)
			{
				UUIItem item = base.GetItem(10);
				if (item == null)
				{
					return;
				}
				item.SetAnchorOffsetX(593f);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(10);
				if (item2 == null)
				{
					return;
				}
				item2.SetAnchorOffsetX(393f);
				return;
			}
		}

		// Token: 0x0603D84A RID: 251978 RVA: 0x00FA9430 File Offset: 0x00FA7630
		private void OnSwitchInteractStateChanged()
		{
			EGamepadSwitchInteractState state = this.GamepadData.SwitchInteractData.State;
			if (state == EGamepadSwitchInteractState.Explore)
			{
				BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(104);
				if (battleSkillItemByButtonType != null && battleSkillItemByButtonType.BehaviorButtonData != null)
				{
					battleSkillItemByButtonType.RefreshByBehaviorButtonData(battleSkillItemByButtonType.BehaviorButtonData);
				}
				this.RefreshExploreSkillItem();
				return;
			}
			if (state == EGamepadSwitchInteractState.Interact)
			{
				BattleSkillGamepadItem battleSkillItemByButtonType2 = this.GetBattleSkillItemByButtonType(104);
				if (battleSkillItemByButtonType2 != null && battleSkillItemByButtonType2.SrcBehaviorButtonData != null)
				{
					battleSkillItemByButtonType2.RefreshByBehaviorButtonData(battleSkillItemByButtonType2.SrcBehaviorButtonData);
				}
				this.RefreshExploreSkillItem();
				return;
			}
			if (state == EGamepadSwitchInteractState.Switching)
			{
				BattleSkillGamepadItem battleSkillItemByButtonType3 = this.GetBattleSkillItemByButtonType(104);
				if (battleSkillItemByButtonType3 == null)
				{
					return;
				}
				battleSkillItemByButtonType3.PlaySwitchCd();
			}
		}

		// Token: 0x0603D84B RID: 251979 RVA: 0x00FA94BC File Offset: 0x00FA76BC
		private void RefreshExploreSkillItem()
		{
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(7);
			if (battleSkillItemByButtonType != null && battleSkillItemByButtonType.IsSecondButton)
			{
				SkillButtonData skillButtonDataByButton = ModelBase<SkillButtonUiModel>.Instance.GetSkillButtonDataByButton(ESkillButtonType.幻象1);
				this.RefreshMainSkillItemBySkillButtonData(battleSkillItemByButtonType, skillButtonDataByButton);
			}
		}

		// Token: 0x0603D84C RID: 251980 RVA: 0x00FA94F0 File Offset: 0x00FA76F0
		private void OnGamepadDataChanged()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindActions(this.GamepadData.GetAllActionNameList(), new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			ControllerBase<InputDistributeController>.Instance.UnBindAxes(this.GamepadData.GetAllAxisNameList(), new TInputHandle<float>(this.OnInputAxis));
			if (this.GamepadData.GamepadDataType == ESkillButtonGamepadDataType.Motorcycle)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnInputMotorcycleCombineButton));
			}
			else
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiPressCombineButtonChanged, new Action<bool>(this.OnInputCombineButton));
			}
			this.GamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			this.RefreshGamepadData();
			foreach (BattleSkillGamepadItem battleSkillGamepadItem in this.BattleSkillItemList)
			{
				battleSkillGamepadItem.GamepadData = this.GamepadData;
			}
			this.RefreshDpadKeyItemEnable();
			this.AxisInputCacheMap.Clear();
			ControllerBase<InputDistributeController>.Instance.BindActions(this.GamepadData.GetAllActionNameList(), new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			ControllerBase<InputDistributeController>.Instance.BindAxes(this.GamepadData.GetAllAxisNameList(), new TInputHandle<float>(this.OnInputAxis));
			if (this.GamepadData.GamepadDataType == ESkillButtonGamepadDataType.Motorcycle)
			{
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnInputMotorcycleCombineButton));
				return;
			}
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiPressCombineButtonChanged, new Action<bool>(this.OnInputCombineButton));
		}

		// Token: 0x0603D84D RID: 251981 RVA: 0x00FA9680 File Offset: 0x00FA7880
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			if (this.GamepadData.GamepadDataType == ESkillButtonGamepadDataType.Normal)
			{
				if (actionName == "攻击")
				{
					return;
				}
				bool bForcePlayClickEffect = false;
				int buttonType;
				if (actionName == "手柄主攻击")
				{
					buttonType = 4;
				}
				else if (actionName == "手柄副攻击")
				{
					if (!this.GamepadData.IsAim())
					{
						return;
					}
					buttonType = 11;
					bForcePlayClickEffect = true;
				}
				else
				{
					buttonType = this.GamepadData.GetButtonTypeByActionName(actionName);
				}
				BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
				if (battleSkillItemByButtonType == null)
				{
					return;
				}
				battleSkillItemByButtonType.OnInputAction(bForcePlayClickEffect);
				return;
			}
			else
			{
				int buttonTypeByActionName = this.GamepadData.GetButtonTypeByActionName(actionName);
				BattleSkillGamepadItem battleSkillItemByButtonType2 = this.GetBattleSkillItemByButtonType(buttonTypeByActionName);
				if (battleSkillItemByButtonType2 == null)
				{
					return;
				}
				battleSkillItemByButtonType2.OnInputAction(false);
				return;
			}
		}

		// Token: 0x0603D84E RID: 251982 RVA: 0x00FA9720 File Offset: 0x00FA7920
		private void OnInputAxis(string axisName, float value, InputIdentification inputIdentification)
		{
			if (value == 0f)
			{
				this.AxisInputCacheMap[axisName] = value;
				return;
			}
			float valueOrDefault = this.AxisInputCacheMap.GetValueOrDefault(axisName, 0f);
			if (valueOrDefault > 0f && value > 0f)
			{
				return;
			}
			if (valueOrDefault < 0f && value < 0f)
			{
				return;
			}
			this.AxisInputCacheMap[axisName] = value;
			int buttonTypeByAxisName = this.GamepadData.GetButtonTypeByAxisName(axisName, value);
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonTypeByAxisName);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.OnInputAction(false);
		}

		// Token: 0x0603D84F RID: 251983 RVA: 0x00FA97A4 File Offset: 0x00FA79A4
		private void OnInputMoveForward(string axisName, float value, InputIdentification inputIdentification)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.GamepadData.CacheInputAxis(EInputAxis.MoveForward, value);
			}
		}

		// Token: 0x0603D850 RID: 251984 RVA: 0x00FA97C3 File Offset: 0x00FA79C3
		private void OnInputMoveRight(string axisName, float value, InputIdentification inputIdentification)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.GamepadData.CacheInputAxis(EInputAxis.MoveRight, value);
			}
		}

		// Token: 0x0603D851 RID: 251985 RVA: 0x00FA97E2 File Offset: 0x00FA79E2
		private void OnViewDone(EUiViewName viewName, UiViewBase uiViewBase)
		{
			if (viewName != EUiViewName.InteractionHintView)
			{
				return;
			}
			this.RefreshInteractButton();
		}

		// Token: 0x0603D852 RID: 251986 RVA: 0x00FA97F8 File Offset: 0x00FA79F8
		private void OnCloseView(EUiViewName viewName, int i)
		{
			if (viewName != EUiViewName.InteractionHintView)
			{
				return;
			}
			this.RefreshInteractButton();
		}

		// Token: 0x0603D853 RID: 251987 RVA: 0x00FA9810 File Offset: 0x00FA7A10
		private void RefreshInteractButton()
		{
			this.GamepadData.RefreshInteractBehaviorData();
			BattleSkillGamepadItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(104);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			if (!battleSkillItemByButtonType.IsMainButton)
			{
				battleSkillItemByButtonType.RefreshVisible();
			}
			battleSkillItemByButtonType.RefreshEnable(false);
		}

		// Token: 0x0603D854 RID: 251988 RVA: 0x00FA984C File Offset: 0x00FA7A4C
		private void InitLevelSequencePlayer()
		{
			this.TweenAnimPlayer = new BattleUiTweenAnimPlayer();
			this.TweenAnimPlayer.InitTweenAnim(21, base.GetItem(21), false);
			this.TweenAnimPlayer.InitTweenAnim(22, base.GetItem(22), false);
			this.DpadLevelSequencePlayer = new LevelSequencePlayer(base.GetItem(10));
		}

		// Token: 0x0603D855 RID: 251989 RVA: 0x00FA98A4 File Offset: 0x00FA7AA4
		public void RefreshDpadKeyItemEnable()
		{
			SkillButtonUiGamepadDataBase gamepadData = this.GamepadData;
			if (gamepadData == null || gamepadData.GamepadDataType != ESkillButtonGamepadDataType.Motorcycle)
			{
				for (int i = 0; i < 4; i++)
				{
					this.DpadItem.SetArrowEnable(i, true, false);
				}
				return;
			}
			SkillButtonUiMotorcycleGamepadData skillButtonUiMotorcycleGamepadData = this.GamepadData as SkillButtonUiMotorcycleGamepadData;
			if (skillButtonUiMotorcycleGamepadData != null && skillButtonUiMotorcycleGamepadData.GetIsPressCombineButton())
			{
				for (int j = 0; j < 4; j++)
				{
					string item = skillButtonUiMotorcycleGamepadData.ButtonKeyList[j + 4];
					if (skillButtonUiMotorcycleGamepadData.MusicSubKeyList.Contains(item))
					{
						this.DpadItem.SetArrowEnable(j, false, false);
					}
					else
					{
						this.DpadItem.SetArrowEnable(j, true, false);
					}
				}
				return;
			}
			for (int k = 0; k < 4; k++)
			{
				this.DpadItem.SetArrowEnable(k, true, false);
			}
		}

		// Token: 0x040228D0 RID: 141520
		private const int MAIN_KEY_NUM = 8;

		// Token: 0x040228D1 RID: 141521
		private const int MAIN_HALF_NUM = 4;

		// Token: 0x040228D2 RID: 141522
		private const int LEFT_KEY_NUM = 4;

		// Token: 0x040228D3 RID: 141523
		private const int SUB_KEY_NUM = 4;

		// Token: 0x040228D4 RID: 141524
		private const int LEFT_KEY_START_INDEX = 8;

		// Token: 0x040228D5 RID: 141525
		private const int SUB_KEY_START_INDEX = 12;

		// Token: 0x040228D6 RID: 141526
		private const int SUB_KEY_END_INDEX = 16;

		// Token: 0x040228D7 RID: 141527
		[StaticVariableRuleIgnore]
		private static readonly Stat RefreshAllBattleSkillItemObject = Stat.Create("[GamepadSkillButton]RefreshAllBattleSkillItem", "", "");

		// Token: 0x040228D8 RID: 141528
		[StaticVariableRuleIgnore]
		private static readonly Stat OnInputCombineButtonObject = Stat.Create("[GamepadSkillButton]OnInputCombineButton", "", "");

		// Token: 0x040228D9 RID: 141529
		[Nullable(2)]
		private BattleSkillCombineItem CombineItem;

		// Token: 0x040228DA RID: 141530
		[Nullable(2)]
		private BattleSkillDpadItem DpadItem;

		// Token: 0x040228DB RID: 141531
		private readonly List<BattleSkillGamepadItem> BattleSkillItemList = new List<BattleSkillGamepadItem>();

		// Token: 0x040228DC RID: 141532
		[Nullable(2)]
		private BattleSkillRouletteItem RouletteItem;

		// Token: 0x040228DD RID: 141533
		[Nullable(2)]
		private BattleUiTweenAnimPlayer TweenAnimPlayer;

		// Token: 0x040228DE RID: 141534
		[Nullable(2)]
		private LevelSequencePlayer DpadLevelSequencePlayer;

		// Token: 0x040228DF RID: 141535
		private bool ExistDpadSkillItem;

		// Token: 0x040228E0 RID: 141536
		[Nullable(2)]
		private SkillButtonUiGamepadDataBase GamepadData;

		// Token: 0x040228E1 RID: 141537
		private readonly Dictionary<string, float> AxisInputCacheMap = new Dictionary<string, float>();

		// Token: 0x0200BFAF RID: 49071
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403AFFC RID: 241660
			SkillItemY,
			// Token: 0x0403AFFD RID: 241661
			SkillItemX,
			// Token: 0x0403AFFE RID: 241662
			SkillItemA,
			// Token: 0x0403AFFF RID: 241663
			SkillItemB,
			// Token: 0x0403B000 RID: 241664
			SkillItemSecondContainer,
			// Token: 0x0403B001 RID: 241665
			SkillItemSecondY,
			// Token: 0x0403B002 RID: 241666
			SkillItemSecondX,
			// Token: 0x0403B003 RID: 241667
			SkillItemSecondA,
			// Token: 0x0403B004 RID: 241668
			SkillItemSecondB,
			// Token: 0x0403B005 RID: 241669
			CombineItem,
			// Token: 0x0403B006 RID: 241670
			SkillItemDPadContainer,
			// Token: 0x0403B007 RID: 241671
			SkillItemUp,
			// Token: 0x0403B008 RID: 241672
			SkillItemLeft,
			// Token: 0x0403B009 RID: 241673
			SkillItemDown,
			// Token: 0x0403B00A RID: 241674
			SkillItemRight,
			// Token: 0x0403B00B RID: 241675
			DPadItem,
			// Token: 0x0403B00C RID: 241676
			SkillItemSub1,
			// Token: 0x0403B00D RID: 241677
			SkillItemSub2,
			// Token: 0x0403B00E RID: 241678
			SkillItemSub3,
			// Token: 0x0403B00F RID: 241679
			SkillItemSub4,
			// Token: 0x0403B010 RID: 241680
			RouletteItem,
			// Token: 0x0403B011 RID: 241681
			SecondShow,
			// Token: 0x0403B012 RID: 241682
			SecondHide
		}
	}
}
