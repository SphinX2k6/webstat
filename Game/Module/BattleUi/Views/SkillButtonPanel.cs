using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FB2 RID: 24498
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillButtonPanel : BattleChildViewPanel
	{
		// Token: 0x0603D8F6 RID: 252150 RVA: 0x00FAD79C File Offset: 0x00FAB99C
		protected unsafe override void OnRegisterComponent()
		{
			EOperationType operationType = base.GetOperationType();
			if (operationType != EOperationType.Pad)
			{
				if (operationType == EOperationType.Desktop)
				{
					int num = 11;
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
					this.ComponentRegisterInfos = list;
					return;
				}
			}
			else
			{
				int num2 = 11;
				List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
				int num = 0;
				*span[num] = new ValueTuple<int, Type>(0, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(1, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(2, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(3, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(4, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(5, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(6, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(7, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(8, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(9, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(10, typeof(UUIItem));
				this.ComponentRegisterInfos = list2;
			}
		}

		// Token: 0x0603D8F7 RID: 252151 RVA: 0x00FADAD0 File Offset: 0x00FABCD0
		public override UniTask InitializeAsync()
		{
			SkillButtonPanel.<InitializeAsync>d__18 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<SkillButtonPanel.<InitializeAsync>d__18>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8F8 RID: 252152 RVA: 0x00FADB13 File Offset: 0x00FABD13
		public override void Reset()
		{
			this.BattleSkillItemList.Clear();
			base.Reset();
			this.OffsetTweenComp = null;
			this.ClearRefreshLayoutTimer();
		}

		// Token: 0x0603D8F9 RID: 252153 RVA: 0x00FADB34 File Offset: 0x00FABD34
		protected override void OnAfterShow()
		{
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.RefreshEnable(true);
			}
			foreach (BehaviorButton behaviorButton in this.BehaviorButtonMap.Values)
			{
				behaviorButton.UpdateAlpha();
			}
		}

		// Token: 0x0603D8FA RID: 252154 RVA: 0x00FADBCC File Offset: 0x00FABDCC
		protected override void OnHideBattleChildViewPanel()
		{
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				if (battleSkillItem.IsShowOrShowing)
				{
					battleSkillItem.TryReleaseButton();
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSkillButtonPanelVisibleChange);
		}

		// Token: 0x0603D8FB RID: 252155 RVA: 0x00FADC38 File Offset: 0x00FABE38
		protected override void OnShowBattleChildViewPanel(bool isFirst)
		{
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.RefreshSkillCoolDownOnShow();
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSkillButtonPanelVisibleChange);
		}

		// Token: 0x0603D8FC RID: 252156 RVA: 0x00FADC98 File Offset: 0x00FABE98
		public override void OnTickBattleChildViewPanel(float delta)
		{
			if (!this.Visible)
			{
				return;
			}
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.Tick(delta);
			}
		}

		// Token: 0x0603D8FD RID: 252157 RVA: 0x00FADCF4 File Offset: 0x00FABEF4
		private void RefreshAllBattleSkillItems()
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			IReadOnlyList<int> buttonTypeList = instance.GetButtonTypeList();
			for (int i = 0; i < this.BattleSkillItemList.Count; i++)
			{
				BattleSkillItem battleSkillItem = this.BattleSkillItemList[i];
				int num;
				if (!buttonTypeList.TryGetValue(i, out num) || num <= 0)
				{
					battleSkillItem.Deactivate();
				}
				else
				{
					SkillButtonData skillButtonDataByButton = instance.GetSkillButtonDataByButton((ESkillButtonType)num);
					if (skillButtonDataByButton == null)
					{
						battleSkillItem.Deactivate();
					}
					else if (skillButtonDataByButton.GetSkillId() == 0)
					{
						battleSkillItem.Deactivate();
					}
					else
					{
						battleSkillItem.Refresh(skillButtonDataByButton);
					}
				}
			}
		}

		// Token: 0x0603D8FE RID: 252158 RVA: 0x00FADD88 File Offset: 0x00FABF88
		private void DeactivateAllBattleSkillItems()
		{
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.Deactivate();
			}
		}

		// Token: 0x0603D8FF RID: 252159 RVA: 0x00FADDD8 File Offset: 0x00FABFD8
		public UniTask NewAllBattleSkillItems()
		{
			SkillButtonPanel.<NewAllBattleSkillItems>d__26 <NewAllBattleSkillItems>d__;
			<NewAllBattleSkillItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAllBattleSkillItems>d__.<>4__this = this;
			<NewAllBattleSkillItems>d__.<>1__state = -1;
			<NewAllBattleSkillItems>d__.<>t__builder.Start<SkillButtonPanel.<NewAllBattleSkillItems>d__26>(ref <NewAllBattleSkillItems>d__);
			return <NewAllBattleSkillItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603D900 RID: 252160 RVA: 0x00FADE1C File Offset: 0x00FAC01C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<BattleSkillItem> NewBattleSkillItem(AActor rootActor, int inputIndex, bool isMobile)
		{
			SkillButtonPanel.<NewBattleSkillItem>d__27 <NewBattleSkillItem>d__;
			<NewBattleSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<BattleSkillItem>.Create();
			<NewBattleSkillItem>d__.<>4__this = this;
			<NewBattleSkillItem>d__.rootActor = rootActor;
			<NewBattleSkillItem>d__.inputIndex = inputIndex;
			<NewBattleSkillItem>d__.isMobile = isMobile;
			<NewBattleSkillItem>d__.<>1__state = -1;
			<NewBattleSkillItem>d__.<>t__builder.Start<SkillButtonPanel.<NewBattleSkillItem>d__27>(ref <NewBattleSkillItem>d__);
			return <NewBattleSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D901 RID: 252161 RVA: 0x00FADE77 File Offset: 0x00FAC077
		[NullableContext(2)]
		private BattleSkillItem GetBattleSkillItem(int inputIndex)
		{
			if (inputIndex < 0 || inputIndex >= this.BattleSkillItemList.Count)
			{
				return null;
			}
			return this.BattleSkillItemList[inputIndex];
		}

		// Token: 0x0603D902 RID: 252162 RVA: 0x00FADE9C File Offset: 0x00FAC09C
		[NullableContext(2)]
		public BattleSkillItem GetBattleSkillItemByButtonType(ESkillButtonType buttonType)
		{
			int skillButtonIndexByButton = ModelBase<SkillButtonUiModel>.Instance.GetSkillButtonIndexByButton((int)buttonType);
			if (skillButtonIndexByButton < 0)
			{
				return null;
			}
			return this.GetBattleSkillItem(skillButtonIndexByButton);
		}

		// Token: 0x0603D903 RID: 252163 RVA: 0x00FADEC4 File Offset: 0x00FAC0C4
		private UniTask NewAllBehaviorButton()
		{
			SkillButtonPanel.<NewAllBehaviorButton>d__30 <NewAllBehaviorButton>d__;
			<NewAllBehaviorButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAllBehaviorButton>d__.<>4__this = this;
			<NewAllBehaviorButton>d__.<>1__state = -1;
			<NewAllBehaviorButton>d__.<>t__builder.Start<SkillButtonPanel.<NewAllBehaviorButton>d__30>(ref <NewAllBehaviorButton>d__);
			return <NewAllBehaviorButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D904 RID: 252164 RVA: 0x00FADF08 File Offset: 0x00FAC108
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<BehaviorButton> NewBehaviorButton(AActor rootActor, EBehaviorType inputActionType, bool isToggle = false)
		{
			SkillButtonPanel.<NewBehaviorButton>d__31 <NewBehaviorButton>d__;
			<NewBehaviorButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<BehaviorButton>.Create();
			<NewBehaviorButton>d__.<>4__this = this;
			<NewBehaviorButton>d__.rootActor = rootActor;
			<NewBehaviorButton>d__.inputActionType = inputActionType;
			<NewBehaviorButton>d__.<>1__state = -1;
			<NewBehaviorButton>d__.<>t__builder.Start<SkillButtonPanel.<NewBehaviorButton>d__31>(ref <NewBehaviorButton>d__);
			return <NewBehaviorButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D905 RID: 252165 RVA: 0x00FADF5C File Offset: 0x00FAC15C
		private void RefreshAllBehaviorButton()
		{
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			foreach (BehaviorButton behaviorButton in this.BehaviorButtonMap.Values)
			{
				BehaviorButtonData behaviorButtonDataByButton = instance.GetBehaviorButtonDataByButton(behaviorButton.BehaviorType);
				if (behaviorButtonDataByButton != null)
				{
					behaviorButton.Refresh(behaviorButtonDataByButton);
				}
			}
		}

		// Token: 0x0603D906 RID: 252166 RVA: 0x00FADFCC File Offset: 0x00FAC1CC
		[NullableContext(2)]
		private BehaviorButton GetBehaviorButton(EBehaviorType inputActionType)
		{
			return this.BehaviorButtonMap.GetValueOrDefault(inputActionType);
		}

		// Token: 0x0603D907 RID: 252167 RVA: 0x00FADFDC File Offset: 0x00FAC1DC
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnUiScreenRootVisibleChange, new Action<bool>(this.OnSetUiVisible));
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
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonLongPressRefresh, new Action<ESkillButtonType>(this.OnSkillButtonLongPressRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonExtraEffectRefresh, new Action<ESkillButtonType>(this.OnSkillButtonExtraEffectRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonSlideControlRefresh, new Action<ESkillButtonType>(this.OnSkillButtonEnableSlideControlRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonEnableRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonVisibleRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonVisibleRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonSkillIdRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonSkillIdRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonIconPathRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonIconPathRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonDynamicEffectRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonDynamicEffectRefresh));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
			Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.CharSkillCdPauseStateChanged, new Action<bool>(this.OnCharSkillCdPauseStateChanged));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiExploreModeChanged, new Action<bool>(this.OnBattleUiExploreModeChanged));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnMotorcycleStateChanged));
			if (base.GetOperationType() == EOperationType.Desktop)
			{
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnPressMotorcycleCombineButtonChanged));
				Singleton<EventSystem>.Instance.Add(EEventName.UIViewPortSizeChanged, new Action(this.OnViewPortSizeChange));
				ControllerBase<InputDistributeController>.Instance.BindActions(SkillButtonPanel.ActionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
		}

		// Token: 0x0603D908 RID: 252168 RVA: 0x00FAE34C File Offset: 0x00FAC54C
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUiScreenRootVisibleChange, new Action<bool>(this.OnSetUiVisible));
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
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonLongPressRefresh, new Action<ESkillButtonType>(this.OnSkillButtonLongPressRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonExtraEffectRefresh, new Action<ESkillButtonType>(this.OnSkillButtonExtraEffectRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonSlideControlRefresh, new Action<ESkillButtonType>(this.OnSkillButtonEnableSlideControlRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonEnableRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonVisibleRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonVisibleRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonSkillIdRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonSkillIdRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonIconPathRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonIconPathRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonDynamicEffectRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonDynamicEffectRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
			Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
			Singleton<EventSystem>.Instance.Remove(EEventName.CharSkillCdPauseStateChanged, new Action<bool>(this.OnCharSkillCdPauseStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiExploreModeChanged, new Action<bool>(this.OnBattleUiExploreModeChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnMotorcycleStateChanged));
			if (base.GetOperationType() == EOperationType.Desktop)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnPressMotorcycleCombineButtonChanged));
				Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.OnViewPortSizeChange));
				ControllerBase<InputDistributeController>.Instance.UnBindActions(SkillButtonPanel.ActionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
		}

		// Token: 0x0603D909 RID: 252169 RVA: 0x00FAE6BC File Offset: 0x00FAC8BC
		private void OnSetUiVisible(bool bVisible)
		{
			if (bVisible)
			{
				foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
				{
					battleSkillItem.RefreshEnable(true);
				}
			}
		}

		// Token: 0x0603D90A RID: 252170 RVA: 0x00FAE710 File Offset: 0x00FAC910
		private void OnFunctionOpenUpdate(EFunctionType functionType, bool isOpen)
		{
			if (functionType != EFunctionType.ShowLockOnButton)
			{
				return;
			}
			BehaviorButton behaviorButton = this.GetBehaviorButton(EBehaviorType.LockTarget);
			if (behaviorButton == null)
			{
				return;
			}
			behaviorButton.SetActive(isOpen);
		}

		// Token: 0x0603D90B RID: 252171 RVA: 0x00FAE72E File Offset: 0x00FAC92E
		private void OnSkillButtonDataRefresh(ESkillButtonRefreshReason refreshReason)
		{
			if (refreshReason == ESkillButtonRefreshReason.GamepadRefreshAimState || refreshReason == ESkillButtonRefreshReason.GamepadRefreshKeyAction)
			{
				return;
			}
			this.RefreshAllBattleSkillItems();
			this.RefreshAllBehaviorButton();
			this.RefreshSkillItemByExploreMode();
			this.RefreshSkillItemLayout();
		}

		// Token: 0x0603D90C RID: 252172 RVA: 0x00FAE751 File Offset: 0x00FAC951
		private void OnSkillButtonDataClear()
		{
			this.DeactivateAllBattleSkillItems();
		}

		// Token: 0x0603D90D RID: 252173 RVA: 0x00FAE759 File Offset: 0x00FAC959
		private void OnSkillButtonIndexRefresh()
		{
			if (Singleton<Info>.Instance.IsInTouch() && ModelBase<BattleUiModel>.Instance.MotorcycleData.IsDriving)
			{
				return;
			}
			this.RefreshAllBattleSkillItems();
			this.RefreshSkillItemByExploreMode();
			this.RefreshSkillItemLayout();
		}

		// Token: 0x0603D90E RID: 252174 RVA: 0x00FAE78C File Offset: 0x00FAC98C
		private void OnSkillButtonEnableRefresh(ESkillButtonType buttonType, int extendCoolDown)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			if (battleSkillItemByButtonType.GetSkillButtonData() == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshEnable(false);
		}

		// Token: 0x0603D90F RID: 252175 RVA: 0x00FAE7B8 File Offset: 0x00FAC9B8
		private void OnSkillButtonVisibleRefresh(ESkillButtonType buttonType)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			if (battleSkillItemByButtonType.GetSkillButtonData() == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshVisible();
			battleSkillItemByButtonType.RefreshKey();
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.RefreshSkillItemByExploreMode();
				this.RefreshSkillItemLayout();
			}
		}

		// Token: 0x0603D910 RID: 252176 RVA: 0x00FAE800 File Offset: 0x00FACA00
		private void OnSkillButtonDynamicEffectRefresh(ESkillButtonType buttonType)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			if (battleSkillItemByButtonType.GetSkillButtonData() == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshDynamicEffect();
		}

		// Token: 0x0603D911 RID: 252177 RVA: 0x00FAE828 File Offset: 0x00FACA28
		private void OnSkillButtonCustomRefresh(ESkillButtonType buttonType, int from = -1, int param = 0)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (((battleSkillItemByButtonType != null) ? battleSkillItemByButtonType.GetSkillButtonData() : null) != null)
			{
				battleSkillItemByButtonType.RefreshCustomHdData(from, param);
			}
		}

		// Token: 0x0603D912 RID: 252178 RVA: 0x00FAE854 File Offset: 0x00FACA54
		private void OnSkillButtonSkillIdRefresh(ESkillButtonType actionType)
		{
			SkillButtonData skillButtonDataByButton = ModelBase<SkillButtonUiModel>.Instance.GetSkillButtonDataByButton(actionType);
			if (skillButtonDataByButton == null)
			{
				return;
			}
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(actionType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			if (skillButtonDataByButton.GetSkillId() == 0)
			{
				battleSkillItemByButtonType.Deactivate();
			}
			else
			{
				battleSkillItemByButtonType.Refresh(skillButtonDataByButton);
			}
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.RefreshSkillItemByExploreMode();
			}
		}

		// Token: 0x0603D913 RID: 252179 RVA: 0x00FAE8A8 File Offset: 0x00FACAA8
		private void OnSkillButtonAttributeRefresh(ESkillButtonType buttonType)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshAttribute(true);
		}

		// Token: 0x0603D914 RID: 252180 RVA: 0x00FAE8C8 File Offset: 0x00FACAC8
		private void OnSkillButtonIconPathRefresh(ESkillButtonType buttonType)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshSkillIcon();
			battleSkillItemByButtonType.RefreshSkillName();
		}

		// Token: 0x0603D915 RID: 252181 RVA: 0x00FAE8F0 File Offset: 0x00FACAF0
		private void OnSkillButtonCdRefresh(ESkillButtonType buttonType)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshSkillCoolDown();
		}

		// Token: 0x0603D916 RID: 252182 RVA: 0x00FAE910 File Offset: 0x00FACB10
		private void OnSkillButtonLongPressRefresh(ESkillButtonType buttonType)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshSkillButtonLongPress();
			battleSkillItemByButtonType.RefreshConfigLongPress(-1, 0);
		}

		// Token: 0x0603D917 RID: 252183 RVA: 0x00FAE938 File Offset: 0x00FACB38
		private void OnSkillButtonExtraEffectRefresh(ESkillButtonType buttonType)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshExtraEffect();
		}

		// Token: 0x0603D918 RID: 252184 RVA: 0x00FAE958 File Offset: 0x00FACB58
		private void OnSkillButtonEnableSlideControlRefresh(ESkillButtonType buttonType)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshSlideControl();
		}

		// Token: 0x0603D919 RID: 252185 RVA: 0x00FAE978 File Offset: 0x00FACB78
		private void OnBehaviorButtonEnableRefresh(EBehaviorType buttonType)
		{
			BehaviorButton behaviorButton = this.GetBehaviorButton(buttonType);
			if (behaviorButton == null)
			{
				return;
			}
			behaviorButton.RefreshEnable(false);
		}

		// Token: 0x0603D91A RID: 252186 RVA: 0x00FAE998 File Offset: 0x00FACB98
		private void OnBehaviorButtonVisibleRefresh(EBehaviorType buttonType)
		{
			BehaviorButton behaviorButton = this.GetBehaviorButton(buttonType);
			if (behaviorButton == null)
			{
				return;
			}
			behaviorButton.RefreshVisible();
		}

		// Token: 0x0603D91B RID: 252187 RVA: 0x00FAE9AB File Offset: 0x00FACBAB
		private void OnBehaviorButtonSkillIdRefresh(EBehaviorType buttonType)
		{
			BehaviorButton behaviorButton = this.GetBehaviorButton(buttonType);
			if (behaviorButton == null)
			{
				return;
			}
			behaviorButton.RefreshAll();
		}

		// Token: 0x0603D91C RID: 252188 RVA: 0x00FAE9BE File Offset: 0x00FACBBE
		private void OnBehaviorButtonIconPathRefresh(EBehaviorType buttonType)
		{
			BehaviorButton behaviorButton = this.GetBehaviorButton(buttonType);
			if (behaviorButton == null)
			{
				return;
			}
			behaviorButton.RefreshSkillIcon();
		}

		// Token: 0x0603D91D RID: 252189 RVA: 0x00FAE9D1 File Offset: 0x00FACBD1
		private void OnBehaviorButtonDynamicEffectRefresh(EBehaviorType buttonType)
		{
			BehaviorButton behaviorButton = this.GetBehaviorButton(buttonType);
			if (behaviorButton == null)
			{
				return;
			}
			behaviorButton.RefreshDynamicEffect();
		}

		// Token: 0x0603D91E RID: 252190 RVA: 0x00FAE9E4 File Offset: 0x00FACBE4
		private void OnPauseGame(int flag)
		{
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.PauseGame(flag);
			}
		}

		// Token: 0x0603D91F RID: 252191 RVA: 0x00FAEA38 File Offset: 0x00FACC38
		private void OnChangedTimeScale()
		{
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.RefreshTimeDilation();
			}
		}

		// Token: 0x0603D920 RID: 252192 RVA: 0x00FAEA88 File Offset: 0x00FACC88
		private void OnCharSkillCdPauseStateChanged(bool _)
		{
			this.OnChangedTimeScale();
		}

		// Token: 0x0603D921 RID: 252193 RVA: 0x00FAEA90 File Offset: 0x00FACC90
		private void InputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				base.SetVisible(EBattleUiVisibleReason.Gamepad, false);
				return;
			}
			base.SetVisible(EBattleUiVisibleReason.Gamepad, true);
			this.RefreshAllBattleSkillItems();
			this.RefreshSkillItemByExploreMode();
			this.RefreshSkillItemLayout();
		}

		// Token: 0x0603D922 RID: 252194 RVA: 0x00FAEAC1 File Offset: 0x00FACCC1
		private void OnBattleUiExploreModeChanged(bool isInExploreMode)
		{
			if (ModelBase<SkillButtonUiModel>.Instance.CurSkillButtonIndexData.IsNormalButtonTypeList)
			{
				BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
				if (curRoleData == null || !curRoleData.IsPhantom())
				{
					if (this.IsInExploreMode == isInExploreMode)
					{
						return;
					}
					this.RefreshSkillItemByExploreModeInner(isInExploreMode, true);
					return;
				}
			}
		}

		// Token: 0x0603D923 RID: 252195 RVA: 0x00FAEB00 File Offset: 0x00FACD00
		private void RefreshSkillItemByExploreMode()
		{
			bool isInExploreMode = ModelBase<BattleUiModel>.Instance.ExploreModeData.GetIsInExploreMode();
			if (!ModelBase<SkillButtonUiModel>.Instance.CurSkillButtonIndexData.IsNormalButtonTypeList)
			{
				BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
				if (curRoleData == null || !curRoleData.IsPhantom())
				{
					if (!this.IsInExploreMode)
					{
						return;
					}
					this.RefreshSkillItemByExploreModeInner(false, false);
					return;
				}
			}
			if (this.IsInExploreMode == isInExploreMode && Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			this.RefreshSkillItemByExploreModeInner(isInExploreMode, false);
		}

		// Token: 0x0603D924 RID: 252196 RVA: 0x00FAEB78 File Offset: 0x00FACD78
		private void RefreshSkillItemByExploreModeInner(bool isInExploreMode, bool anim = false)
		{
			this.IsInExploreMode = isInExploreMode;
			bool visible = !isInExploreMode;
			BehaviorButton valueOrDefault = this.BehaviorButtonMap.GetValueOrDefault(EBehaviorType.Aim);
			if (valueOrDefault != null)
			{
				valueOrDefault.SetVisibleByExploreMode(visible, anim);
			}
			BehaviorButton valueOrDefault2 = this.BehaviorButtonMap.GetValueOrDefault(EBehaviorType.LockTarget);
			if (valueOrDefault2 != null)
			{
				valueOrDefault2.SetVisibleByExploreMode(visible, anim);
			}
			this.BattleSkillItemList[1].SetVisibleByExploreMode(visible, anim);
			this.BattleSkillItemList[2].SetVisibleByExploreMode(visible, anim);
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.BattleSkillItemList[3].SetVisibleByExploreMode(visible, anim);
				this.RefreshRootItemOffsetByExploreMode(isInExploreMode, anim);
				return;
			}
			this.BattleSkillItemList[4].SetVisibleByExploreMode(visible, anim);
		}

		// Token: 0x0603D925 RID: 252197 RVA: 0x00FAEC28 File Offset: 0x00FACE28
		private void RefreshRootItemOffsetByExploreMode(bool isInExploreMode, bool anim = false)
		{
			float num = -86f;
			if (isInExploreMode)
			{
				int num2 = 0;
				for (int i = 1; i < 4; i++)
				{
					if (this.BattleSkillItemList[i].IsShowOrShowing)
					{
						num2++;
					}
				}
				num += (float)(num2 * 144);
			}
			if (anim)
			{
				if (this.OffsetTweenComp == null)
				{
					this.OffsetTweenComp = (this.RootActor.GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
				}
				else
				{
					this.OffsetTweenComp.Stop();
				}
				ULGUIPlayTween_Float ulguiplayTween_Float = this.OffsetTweenComp.GetPlayTween() as ULGUIPlayTween_Float;
				ulguiplayTween_Float.from = this.RootItem.GetAnchorOffsetX();
				ulguiplayTween_Float.to = num;
				this.OffsetTweenComp.Play();
				return;
			}
			ULGUIPlayTweenComponent offsetTweenComp = this.OffsetTweenComp;
			if (offsetTweenComp != null)
			{
				offsetTweenComp.Stop();
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAnchorOffsetX(num);
		}

		// Token: 0x0603D926 RID: 252198 RVA: 0x00FAECFC File Offset: 0x00FACEFC
		private void UpdateAspectRatio()
		{
			int num = 0;
			int num2 = 0;
			Global.CharacterController.GetViewportSize(ref num, ref num2);
			if (num2 != 0)
			{
				this.AspectRatio = (float)num / (float)num2;
			}
		}

		// Token: 0x0603D927 RID: 252199 RVA: 0x00FAED2C File Offset: 0x00FACF2C
		private void RefreshSkillItemLayout()
		{
			if (!Singleton<Info>.Instance.IsInKeyBoard() || this.SkillItemLayoutList.Count == 0)
			{
				return;
			}
			BehaviorButton valueOrDefault = this.BehaviorButtonMap.GetValueOrDefault(EBehaviorType.Aim);
			BehaviorButton valueOrDefault2 = this.BehaviorButtonMap.GetValueOrDefault(EBehaviorType.LockTarget);
			bool flag = valueOrDefault != null && valueOrDefault.IsVisible() && valueOrDefault2 != null && valueOrDefault2.IsVisible();
			int num = 0;
			for (int i = this.BattleSkillItemList.Count - 1; i >= 0; i--)
			{
				BattleSkillItem battleSkillItem = this.BattleSkillItemList[i];
				if (battleSkillItem.IsVisible())
				{
					num++;
				}
				if (num < 6)
				{
					battleSkillItem.SetSkillItemLayout(this.SkillItemLayoutList[0]);
				}
				else if (num == 6)
				{
					if (this.AspectRatio <= this.AspectRatioThreshold || flag)
					{
						battleSkillItem.SetSkillItemLayout(this.SkillItemLayoutList[1]);
					}
					else
					{
						battleSkillItem.SetSkillItemLayout(this.SkillItemLayoutList[0]);
					}
				}
				else
				{
					battleSkillItem.SetSkillItemLayout(this.SkillItemLayoutList[1]);
				}
			}
			this.ClearRefreshLayoutTimer();
		}

		// Token: 0x0603D928 RID: 252200 RVA: 0x00FAEE3C File Offset: 0x00FAD03C
		private void OnViewPortSizeChange()
		{
			this.UpdateAspectRatio();
			this.RefreshSkillItemLayout();
		}

		// Token: 0x0603D929 RID: 252201 RVA: 0x00FAEE4A File Offset: 0x00FAD04A
		private void OnSkillItemVisibleChanged()
		{
			this.SetRefreshLayoutTimer();
		}

		// Token: 0x0603D92A RID: 252202 RVA: 0x00FAEE52 File Offset: 0x00FAD052
		private void SetRefreshLayoutTimer()
		{
			if (this.RefreshLayoutTimer != null)
			{
				return;
			}
			this.RefreshLayoutTimer = TimerSystem.Instance.Next(new TTimerAction(this.RefreshSkillItemLayoutNextTick), null, null);
		}

		// Token: 0x0603D92B RID: 252203 RVA: 0x00FAEE7B File Offset: 0x00FAD07B
		private void RefreshSkillItemLayoutNextTick(float _)
		{
			this.RefreshLayoutTimer = null;
			this.RefreshSkillItemLayout();
		}

		// Token: 0x0603D92C RID: 252204 RVA: 0x00FAEE8A File Offset: 0x00FAD08A
		private void ClearRefreshLayoutTimer()
		{
			if (this.RefreshLayoutTimer != null)
			{
				if (TimerSystem.Instance.Has(this.RefreshLayoutTimer))
				{
					TimerSystem.Instance.Remove(this.RefreshLayoutTimer);
				}
				this.RefreshLayoutTimer = null;
			}
		}

		// Token: 0x0603D92D RID: 252205 RVA: 0x00FAEEC0 File Offset: 0x00FAD0C0
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			if (actionName == "瞄准" || actionName == "载具视角切换")
			{
				BehaviorButton valueOrDefault = this.BehaviorButtonMap.GetValueOrDefault(EBehaviorType.Aim);
				if (((valueOrDefault != null) ? valueOrDefault.GetActionName() : null) == actionName)
				{
					valueOrDefault.OnInputAction();
				}
				return;
			}
			if (actionName == "锁定目标" || actionName == "载具锁定目标")
			{
				BehaviorButton valueOrDefault2 = this.BehaviorButtonMap.GetValueOrDefault(EBehaviorType.LockTarget);
				if (((valueOrDefault2 != null) ? valueOrDefault2.GetActionName() : null) == actionName)
				{
					valueOrDefault2.OnInputAction();
				}
				return;
			}
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				SkillButtonData skillButtonData = battleSkillItem.GetSkillButtonData();
				if (skillButtonData != null && !(skillButtonData.GetActionName() != actionName))
				{
					battleSkillItem.OnInputAction(false);
					break;
				}
			}
		}

		// Token: 0x0603D92E RID: 252206 RVA: 0x00FAEFBC File Offset: 0x00FAD1BC
		private void OnPressMotorcycleCombineButtonChanged(bool b)
		{
			this.RefreshKeyItemEnableInMotorcycle();
		}

		// Token: 0x0603D92F RID: 252207 RVA: 0x00FAEFC4 File Offset: 0x00FAD1C4
		public void RefreshKeyItemEnableInMotorcycle()
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
			if (motorcycleData == null || !motorcycleData.IsDriving)
			{
				return;
			}
			SkillButtonUiGamepadDataBase gamepadDataByType = ModelBase<SkillButtonUiModel>.Instance.GetGamepadDataByType(ESkillButtonGamepadDataType.Motorcycle);
			if (gamepadDataByType != null && gamepadDataByType.GetIsPressCombineButton())
			{
				foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
				{
					if (battleSkillItem.IsVisible())
					{
						InputMultiKeyItem keyItem = battleSkillItem.GetKeyItem();
						if (keyItem != null)
						{
							keyItem.SetDisableBySingleKeyList(new <>z__ReadOnlyArray<string>(new string[]
							{
								EKey.LeftMouseButton,
								EKey.RightMouseButton,
								EKey.MiddleMouseButton
							}));
						}
					}
				}
				using (Dictionary<EBehaviorType, BehaviorButton>.ValueCollection.Enumerator enumerator2 = this.BehaviorButtonMap.Values.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						BehaviorButton behaviorButton = enumerator2.Current;
						if (behaviorButton.IsVisible())
						{
							InputMultiKeyItem keyItem2 = behaviorButton.GetKeyItem();
							if (keyItem2 != null)
							{
								keyItem2.SetDisableBySingleKeyList(new <>z__ReadOnlyArray<string>(new string[]
								{
									EKey.LeftMouseButton,
									EKey.RightMouseButton,
									EKey.MiddleMouseButton
								}));
							}
						}
					}
					return;
				}
			}
			foreach (BattleSkillItem battleSkillItem2 in this.BattleSkillItemList)
			{
				InputMultiKeyItem keyItem3 = battleSkillItem2.GetKeyItem();
				if (keyItem3 != null)
				{
					keyItem3.SetEnable(true, false);
				}
			}
			foreach (BehaviorButton behaviorButton2 in this.BehaviorButtonMap.Values)
			{
				InputMultiKeyItem keyItem4 = behaviorButton2.GetKeyItem();
				if (keyItem4 != null)
				{
					keyItem4.SetEnable(true, false);
				}
			}
		}

		// Token: 0x0603D930 RID: 252208 RVA: 0x00FAF1CC File Offset: 0x00FAD3CC
		private void OnMotorcycleStateChanged(bool b)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
			if (motorcycleData == null || !motorcycleData.IsDriving)
			{
				foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
				{
					InputMultiKeyItem keyItem = battleSkillItem.GetKeyItem();
					if (keyItem != null)
					{
						keyItem.SetEnable(true, false);
					}
				}
				foreach (BehaviorButton behaviorButton in this.BehaviorButtonMap.Values)
				{
					InputMultiKeyItem keyItem2 = behaviorButton.GetKeyItem();
					if (keyItem2 != null)
					{
						keyItem2.SetEnable(true, false);
					}
				}
			}
		}

		// Token: 0x0603D932 RID: 252210 RVA: 0x00FAF2E8 File Offset: 0x00FAD4E8
		// Note: this type is marked as 'beforefieldinit'.
		unsafe static SkillButtonPanel()
		{
			int num = 18;
			List<string> list = new List<string>(num);
			CollectionsMarshal.SetCount<string>(list, num);
			Span<string> span = CollectionsMarshal.AsSpan<string>(list);
			int num2 = 0;
			*span[num2] = "跳跃";
			num2++;
			*span[num2] = "攻击";
			num2++;
			*span[num2] = "大招";
			num2++;
			*span[num2] = "幻象1";
			num2++;
			*span[num2] = "幻象2";
			num2++;
			*span[num2] = "技能1";
			num2++;
			*span[num2] = "闪避";
			num2++;
			*span[num2] = "瞄准";
			num2++;
			*span[num2] = "锁定目标";
			num2++;
			*span[num2] = "载具漂移";
			num2++;
			*span[num2] = "载具子弹跳";
			num2++;
			*span[num2] = "载具退场技和下车";
			num2++;
			*span[num2] = "载具探索工具";
			num2++;
			*span[num2] = "载具氮气";
			num2++;
			*span[num2] = "载具空中抬升";
			num2++;
			*span[num2] = "载具子弹跳1";
			num2++;
			*span[num2] = "载具视角切换";
			num2++;
			*span[num2] = "载具锁定目标";
			SkillButtonPanel.ActionNameList = list;
			SkillButtonPanel.RefreshAllBattleSkillItemObject = Stat.Create("[SkillButton]RefreshAllBattleSkillItem", "", "");
			SkillButtonPanel.RefreshSkillItemLayoutStat = Stat.Create("[SkillButton]RefreshSkillItemLayoutStat", "", "");
		}

		// Token: 0x04022924 RID: 141604
		private const float INIT_OFFSET_X = -86f;

		// Token: 0x04022925 RID: 141605
		private const int ITEM_WIDTH = 144;

		// Token: 0x04022926 RID: 141606
		private const int MOBILE_INDEX_EXPLORE_ITEM = 3;

		// Token: 0x04022927 RID: 141607
		private const int SECOND_LAYOUT_START_COUNT = 6;

		// Token: 0x04022928 RID: 141608
		[StaticVariableRuleIgnore]
		private static readonly List<string> ActionNameList;

		// Token: 0x04022929 RID: 141609
		[StaticVariableRuleIgnore]
		private static readonly Stat RefreshAllBattleSkillItemObject;

		// Token: 0x0402292A RID: 141610
		[StaticVariableRuleIgnore]
		private static readonly Stat RefreshSkillItemLayoutStat;

		// Token: 0x0402292B RID: 141611
		private readonly List<BattleSkillItem> BattleSkillItemList = new List<BattleSkillItem>();

		// Token: 0x0402292C RID: 141612
		private readonly Dictionary<EBehaviorType, BehaviorButton> BehaviorButtonMap = new Dictionary<EBehaviorType, BehaviorButton>();

		// Token: 0x0402292D RID: 141613
		[Nullable(2)]
		private ULGUIPlayTweenComponent OffsetTweenComp;

		// Token: 0x0402292E RID: 141614
		private bool IsInExploreMode;

		// Token: 0x0402292F RID: 141615
		private readonly List<SkillItemLayout> SkillItemLayoutList = new List<SkillItemLayout>();

		// Token: 0x04022930 RID: 141616
		private float AspectRatio = 1.77778f;

		// Token: 0x04022931 RID: 141617
		private float AspectRatioThreshold = 1.33333f;

		// Token: 0x04022932 RID: 141618
		[Nullable(2)]
		private TimerHandle RefreshLayoutTimer;

		// Token: 0x0200BFDD RID: 49117
		[NullableContext(0)]
		private enum EDesktopChildType
		{
			// Token: 0x0403B0F0 RID: 241904
			SkillItem1,
			// Token: 0x0403B0F1 RID: 241905
			SkillItem2,
			// Token: 0x0403B0F2 RID: 241906
			SkillItem3,
			// Token: 0x0403B0F3 RID: 241907
			SkillItem4,
			// Token: 0x0403B0F4 RID: 241908
			SkillItem5,
			// Token: 0x0403B0F5 RID: 241909
			SkillItem6,
			// Token: 0x0403B0F6 RID: 241910
			AimButtonItem,
			// Token: 0x0403B0F7 RID: 241911
			LockButtonItem,
			// Token: 0x0403B0F8 RID: 241912
			SkillItem7,
			// Token: 0x0403B0F9 RID: 241913
			SkillLayout1,
			// Token: 0x0403B0FA RID: 241914
			SkillLayout2
		}

		// Token: 0x0200BFDE RID: 49118
		[NullableContext(0)]
		private enum EPadChildType
		{
			// Token: 0x0403B0FC RID: 241916
			SkillItem1,
			// Token: 0x0403B0FD RID: 241917
			SkillItem2,
			// Token: 0x0403B0FE RID: 241918
			SkillItem3,
			// Token: 0x0403B0FF RID: 241919
			SkillItem4,
			// Token: 0x0403B100 RID: 241920
			SkillItem5,
			// Token: 0x0403B101 RID: 241921
			SkillItem6,
			// Token: 0x0403B102 RID: 241922
			SkillItem7,
			// Token: 0x0403B103 RID: 241923
			LockButtonItem,
			// Token: 0x0403B104 RID: 241924
			AimButtonItem,
			// Token: 0x0403B105 RID: 241925
			SkillItem8,
			// Token: 0x0403B106 RID: 241926
			SkillItem9
		}
	}
}
