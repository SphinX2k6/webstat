using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006087 RID: 24711
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleSkillButtonMobilePanel : UiPanelBase
	{
		// Token: 0x0603E562 RID: 255330 RVA: 0x00FEB4D4 File Offset: 0x00FE96D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E563 RID: 255331 RVA: 0x00FEB648 File Offset: 0x00FE9848
		protected override UniTask OnBeforeStartAsync()
		{
			MotorcycleSkillButtonMobilePanel.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleSkillButtonMobilePanel.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E564 RID: 255332 RVA: 0x00FEB68B File Offset: 0x00FE988B
		protected override void OnBeforeDestroy()
		{
			this.BattleSkillItemList.Clear();
			this.BehaviorButtonMap.Clear();
			ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveCallback(EBattleUiChild.MotorcycleMobileSkillButton, new Action(this.OnSkillButtonVisibleChanged));
		}

		// Token: 0x0603E565 RID: 255333 RVA: 0x00FEB6C0 File Offset: 0x00FE98C0
		protected override void OnAfterShow()
		{
			this.AddEvents();
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.RefreshEnable(true);
			}
			foreach (BehaviorButton behaviorButton in this.BehaviorButtonMap.Values)
			{
				behaviorButton.UpdateAlpha();
			}
			this.DataDirty = true;
		}

		// Token: 0x0603E566 RID: 255334 RVA: 0x00FEB764 File Offset: 0x00FE9964
		protected override void OnBeforeHide()
		{
			this.RemoveEvents();
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				if (battleSkillItem.IsShowOrShowing)
				{
					battleSkillItem.TryReleaseButton();
				}
			}
		}

		// Token: 0x0603E567 RID: 255335 RVA: 0x00FEB7C4 File Offset: 0x00FE99C4
		protected override void OnBeforeShow()
		{
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.RefreshSkillCoolDownOnShow();
			}
		}

		// Token: 0x0603E568 RID: 255336 RVA: 0x00FEB814 File Offset: 0x00FE9A14
		public void Tick(float delta)
		{
			if (!base.IsShowOrShowing)
			{
				return;
			}
			if (this.DataDirty)
			{
				this.DataDirty = false;
				this.RefreshAllBattleSkillItems();
				this.RefreshAllBehaviorButton();
			}
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.Tick(delta);
			}
		}

		// Token: 0x0603E569 RID: 255337 RVA: 0x00FEB88C File Offset: 0x00FE9A8C
		private void RefreshAllBattleSkillItems()
		{
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			IList<int> motorPadButtonTypeList = instance.GetMotorPadButtonTypeList();
			for (int i = 0; i < this.BattleSkillItemList.Count; i++)
			{
				int num = (motorPadButtonTypeList.Count > i) ? motorPadButtonTypeList[i] : 0;
				BattleSkillItem battleSkillItem = this.BattleSkillItemList[i];
				SkillButtonData skillButtonDataByButton = instance.GetSkillButtonDataByButton((ESkillButtonType)num);
				if (skillButtonDataByButton == null)
				{
					battleSkillItem.Deactivate();
				}
				else if (num == 0)
				{
					battleSkillItem.Deactivate();
				}
				else if (num < 0)
				{
					battleSkillItem.Deactivate();
				}
				else
				{
					skillButtonDataByButton.GetSkillId();
					battleSkillItem.Refresh(skillButtonDataByButton);
				}
			}
		}

		// Token: 0x0603E56A RID: 255338 RVA: 0x00FEB920 File Offset: 0x00FE9B20
		private void DeactivateAllBattleSkillItems()
		{
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.Deactivate();
			}
		}

		// Token: 0x0603E56B RID: 255339 RVA: 0x00FEB970 File Offset: 0x00FE9B70
		public UniTask NewAllBattleSkillItems()
		{
			MotorcycleSkillButtonMobilePanel.<NewAllBattleSkillItems>d__17 <NewAllBattleSkillItems>d__;
			<NewAllBattleSkillItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAllBattleSkillItems>d__.<>4__this = this;
			<NewAllBattleSkillItems>d__.<>1__state = -1;
			<NewAllBattleSkillItems>d__.<>t__builder.Start<MotorcycleSkillButtonMobilePanel.<NewAllBattleSkillItems>d__17>(ref <NewAllBattleSkillItems>d__);
			return <NewAllBattleSkillItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603E56C RID: 255340 RVA: 0x00FEB9B4 File Offset: 0x00FE9BB4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<BattleSkillItem> NewBattleSkillItem(AActor rootActor, int inputIndex)
		{
			MotorcycleSkillButtonMobilePanel.<NewBattleSkillItem>d__18 <NewBattleSkillItem>d__;
			<NewBattleSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<BattleSkillItem>.Create();
			<NewBattleSkillItem>d__.<>4__this = this;
			<NewBattleSkillItem>d__.rootActor = rootActor;
			<NewBattleSkillItem>d__.inputIndex = inputIndex;
			<NewBattleSkillItem>d__.<>1__state = -1;
			<NewBattleSkillItem>d__.<>t__builder.Start<MotorcycleSkillButtonMobilePanel.<NewBattleSkillItem>d__18>(ref <NewBattleSkillItem>d__);
			return <NewBattleSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E56D RID: 255341 RVA: 0x00FEBA07 File Offset: 0x00FE9C07
		private BattleSkillItem GetBattleSkillItem(int inputIndex)
		{
			return this.BattleSkillItemList[inputIndex];
		}

		// Token: 0x0603E56E RID: 255342 RVA: 0x00FEBA18 File Offset: 0x00FE9C18
		[NullableContext(2)]
		public BattleSkillItem GetBattleSkillItemByButtonType(ESkillButtonType buttonType)
		{
			int motorPadSkillButtonIndexByButton = ModelBase<SkillButtonUiModel>.Instance.GetMotorPadSkillButtonIndexByButton((int)buttonType);
			if (motorPadSkillButtonIndexByButton < 0)
			{
				return null;
			}
			return this.GetBattleSkillItem(motorPadSkillButtonIndexByButton);
		}

		// Token: 0x0603E56F RID: 255343 RVA: 0x00FEBA40 File Offset: 0x00FE9C40
		private UniTask NewAllBehaviorButton()
		{
			MotorcycleSkillButtonMobilePanel.<NewAllBehaviorButton>d__21 <NewAllBehaviorButton>d__;
			<NewAllBehaviorButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAllBehaviorButton>d__.<>4__this = this;
			<NewAllBehaviorButton>d__.<>1__state = -1;
			<NewAllBehaviorButton>d__.<>t__builder.Start<MotorcycleSkillButtonMobilePanel.<NewAllBehaviorButton>d__21>(ref <NewAllBehaviorButton>d__);
			return <NewAllBehaviorButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603E570 RID: 255344 RVA: 0x00FEBA84 File Offset: 0x00FE9C84
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<BehaviorButton> NewBehaviorButton(AActor rootActor, EBehaviorType inputActionType)
		{
			MotorcycleSkillButtonMobilePanel.<NewBehaviorButton>d__22 <NewBehaviorButton>d__;
			<NewBehaviorButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<BehaviorButton>.Create();
			<NewBehaviorButton>d__.<>4__this = this;
			<NewBehaviorButton>d__.rootActor = rootActor;
			<NewBehaviorButton>d__.inputActionType = inputActionType;
			<NewBehaviorButton>d__.<>1__state = -1;
			<NewBehaviorButton>d__.<>t__builder.Start<MotorcycleSkillButtonMobilePanel.<NewBehaviorButton>d__22>(ref <NewBehaviorButton>d__);
			return <NewBehaviorButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603E571 RID: 255345 RVA: 0x00FEBAD8 File Offset: 0x00FE9CD8
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

		// Token: 0x0603E572 RID: 255346 RVA: 0x00FEBB48 File Offset: 0x00FE9D48
		[NullableContext(2)]
		private BehaviorButton GetBehaviorButton(EBehaviorType inputActionType)
		{
			return this.BehaviorButtonMap.GetValueOrDefault(inputActionType);
		}

		// Token: 0x0603E573 RID: 255347 RVA: 0x00FEBB58 File Offset: 0x00FE9D58
		protected void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnUiScreenRootVisibleChange, new Action<bool>(this.OnSetUiVisible));
			Singleton<EventSystem>.Instance.Add<ESkillButtonRefreshReason>(EEventName.OnSkillButtonDataRefresh, new Action<ESkillButtonRefreshReason>(this.OnSkillButtonDataRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSkillButtonDataClear, new Action(this.OnSkillButtonDataClear));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMotorPadSkillButtonIndexRefresh, new Action(this.OnSkillButtonIndexRefresh));
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
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonEnableRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonVisibleRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonVisibleRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonSkillIdRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonSkillIdRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonIconPathRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonIconPathRefresh));
			Singleton<EventSystem>.Instance.Add<EBehaviorType>(EEventName.OnBehaviorButtonDynamicEffectRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonDynamicEffectRefresh));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
			Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.CharSkillCdPauseStateChanged, new Action<bool>(this.OnCharSkillCdPauseStateChanged));
		}

		// Token: 0x0603E574 RID: 255348 RVA: 0x00FEBDC8 File Offset: 0x00FE9FC8
		protected void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUiScreenRootVisibleChange, new Action<bool>(this.OnSetUiVisible));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonDataRefresh, new Action<ESkillButtonRefreshReason>(this.OnSkillButtonDataRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonDataClear, new Action(this.OnSkillButtonDataClear));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMotorPadSkillButtonIndexRefresh, new Action(this.OnSkillButtonIndexRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonEnableRefresh, new Action<ESkillButtonType, int>(this.OnSkillButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonVisibleRefresh, new Action<ESkillButtonType>(this.OnSkillButtonVisibleRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonDynamicEffectRefresh, new Action<ESkillButtonType>(this.OnSkillButtonDynamicEffectRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonCustomRefresh, new Action<ESkillButtonType, int, int>(this.OnSkillButtonCustomRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonSkillIdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonSkillIdRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonAttributeRefresh, new Action<ESkillButtonType>(this.OnSkillButtonAttributeRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonIconPathRefresh, new Action<ESkillButtonType>(this.OnSkillButtonIconPathRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonLongPressRefresh, new Action<ESkillButtonType>(this.OnSkillButtonLongPressRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonExtraEffectRefresh, new Action<ESkillButtonType>(this.OnSkillButtonExtraEffectRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonEnableRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonVisibleRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonVisibleRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonSkillIdRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonSkillIdRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonIconPathRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonIconPathRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBehaviorButtonDynamicEffectRefresh, new Action<EBehaviorType>(this.OnBehaviorButtonDynamicEffectRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
			Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
			Singleton<EventSystem>.Instance.Remove(EEventName.CharSkillCdPauseStateChanged, new Action<bool>(this.OnCharSkillCdPauseStateChanged));
		}

		// Token: 0x0603E575 RID: 255349 RVA: 0x00FEC038 File Offset: 0x00FEA238
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

		// Token: 0x0603E576 RID: 255350 RVA: 0x00FEC08C File Offset: 0x00FEA28C
		private void OnSkillButtonDataRefresh(ESkillButtonRefreshReason refreshReason)
		{
			if (refreshReason == ESkillButtonRefreshReason.GamepadRefreshAimState || refreshReason == ESkillButtonRefreshReason.GamepadRefreshKeyAction)
			{
				return;
			}
			this.DataDirty = true;
		}

		// Token: 0x0603E577 RID: 255351 RVA: 0x00FEC09E File Offset: 0x00FEA29E
		private void OnSkillButtonDataClear()
		{
			this.DeactivateAllBattleSkillItems();
		}

		// Token: 0x0603E578 RID: 255352 RVA: 0x00FEC0A6 File Offset: 0x00FEA2A6
		private void OnSkillButtonIndexRefresh()
		{
			if (!ModelBase<BattleUiModel>.Instance.MotorcycleData.IsDriving)
			{
				return;
			}
			this.DataDirty = true;
		}

		// Token: 0x0603E579 RID: 255353 RVA: 0x00FEC0C4 File Offset: 0x00FEA2C4
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

		// Token: 0x0603E57A RID: 255354 RVA: 0x00FEC0F0 File Offset: 0x00FEA2F0
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
		}

		// Token: 0x0603E57B RID: 255355 RVA: 0x00FEC120 File Offset: 0x00FEA320
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

		// Token: 0x0603E57C RID: 255356 RVA: 0x00FEC148 File Offset: 0x00FEA348
		private void OnSkillButtonCustomRefresh(ESkillButtonType buttonType, int from, int param)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (((battleSkillItemByButtonType != null) ? battleSkillItemByButtonType.GetSkillButtonData() : null) != null)
			{
				battleSkillItemByButtonType.RefreshCustomHdData(from, param);
			}
		}

		// Token: 0x0603E57D RID: 255357 RVA: 0x00FEC174 File Offset: 0x00FEA374
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
			skillButtonDataByButton.GetSkillId();
			battleSkillItemByButtonType.Refresh(skillButtonDataByButton);
		}

		// Token: 0x0603E57E RID: 255358 RVA: 0x00FEC1AC File Offset: 0x00FEA3AC
		private void OnSkillButtonAttributeRefresh(ESkillButtonType buttonType)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshAttribute(true);
		}

		// Token: 0x0603E57F RID: 255359 RVA: 0x00FEC1CC File Offset: 0x00FEA3CC
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

		// Token: 0x0603E580 RID: 255360 RVA: 0x00FEC1F4 File Offset: 0x00FEA3F4
		private void OnSkillButtonCdRefresh(ESkillButtonType buttonType)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshSkillCoolDown();
		}

		// Token: 0x0603E581 RID: 255361 RVA: 0x00FEC214 File Offset: 0x00FEA414
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

		// Token: 0x0603E582 RID: 255362 RVA: 0x00FEC23C File Offset: 0x00FEA43C
		private void OnSkillButtonExtraEffectRefresh(ESkillButtonType buttonType)
		{
			BattleSkillItem battleSkillItemByButtonType = this.GetBattleSkillItemByButtonType(buttonType);
			if (battleSkillItemByButtonType == null)
			{
				return;
			}
			battleSkillItemByButtonType.RefreshExtraEffect();
		}

		// Token: 0x0603E583 RID: 255363 RVA: 0x00FEC25C File Offset: 0x00FEA45C
		private void OnBehaviorButtonEnableRefresh(EBehaviorType buttonType)
		{
			BehaviorButton behaviorButton = this.GetBehaviorButton(buttonType);
			if (behaviorButton == null)
			{
				return;
			}
			behaviorButton.RefreshEnable(false);
		}

		// Token: 0x0603E584 RID: 255364 RVA: 0x00FEC27C File Offset: 0x00FEA47C
		private void OnBehaviorButtonVisibleRefresh(EBehaviorType buttonType)
		{
			BehaviorButton behaviorButton = this.GetBehaviorButton(buttonType);
			if (behaviorButton == null)
			{
				return;
			}
			behaviorButton.RefreshVisible();
		}

		// Token: 0x0603E585 RID: 255365 RVA: 0x00FEC29C File Offset: 0x00FEA49C
		private void OnBehaviorButtonSkillIdRefresh(EBehaviorType buttonType)
		{
			BehaviorButton behaviorButton = this.GetBehaviorButton(buttonType);
			if (behaviorButton == null)
			{
				return;
			}
			behaviorButton.RefreshAll();
		}

		// Token: 0x0603E586 RID: 255366 RVA: 0x00FEC2BC File Offset: 0x00FEA4BC
		private void OnBehaviorButtonIconPathRefresh(EBehaviorType buttonType)
		{
			BehaviorButton behaviorButton = this.GetBehaviorButton(buttonType);
			if (behaviorButton == null)
			{
				return;
			}
			behaviorButton.RefreshSkillIcon();
		}

		// Token: 0x0603E587 RID: 255367 RVA: 0x00FEC2DC File Offset: 0x00FEA4DC
		private void OnBehaviorButtonDynamicEffectRefresh(EBehaviorType buttonType)
		{
			BehaviorButton behaviorButton = this.GetBehaviorButton(buttonType);
			if (behaviorButton == null)
			{
				return;
			}
			behaviorButton.RefreshDynamicEffect();
		}

		// Token: 0x0603E588 RID: 255368 RVA: 0x00FEC2FC File Offset: 0x00FEA4FC
		private void OnPauseGame(int flag)
		{
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.PauseGame(flag);
			}
		}

		// Token: 0x0603E589 RID: 255369 RVA: 0x00FEC350 File Offset: 0x00FEA550
		private void OnChangedTimeScale()
		{
			foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
			{
				battleSkillItem.RefreshTimeDilation();
			}
		}

		// Token: 0x0603E58A RID: 255370 RVA: 0x00FEC3A0 File Offset: 0x00FEA5A0
		private void OnCharSkillCdPauseStateChanged(bool _)
		{
			this.OnChangedTimeScale();
		}

		// Token: 0x0603E58B RID: 255371 RVA: 0x00FEC3A8 File Offset: 0x00FEA5A8
		private void OnSkillButtonVisibleChanged()
		{
			bool visible = this.GetVisible();
			this.BaseVisible = ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.MotorcycleMobileSkillButton);
			this.CheckVisibleChange(visible);
		}

		// Token: 0x0603E58C RID: 255372 RVA: 0x00FEC3DC File Offset: 0x00FEA5DC
		public override void SetActive(bool visibility)
		{
			if (this.GetVisible() != visibility)
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "战斗子界面不要直接调用SetActive, 请调用SetVisible", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			base.SetActive(visibility);
		}

		// Token: 0x0603E58D RID: 255373 RVA: 0x00FEC418 File Offset: 0x00FEA618
		public void SetVisible(int visibleReason, bool bVisible)
		{
			bool visible = this.GetVisible();
			this.SetVisibleInner(visibleReason, bVisible);
			this.CheckVisibleChange(visible);
		}

		// Token: 0x0603E58E RID: 255374 RVA: 0x00FEC43B File Offset: 0x00FEA63B
		private void SetVisibleInner(int visibleReason, bool bVisible)
		{
			this.InnerVisibleState = VisibleStateUtil.SetVisible(this.InnerVisibleState, bVisible, visibleReason);
		}

		// Token: 0x0603E58F RID: 255375 RVA: 0x00FEC450 File Offset: 0x00FEA650
		public bool GetVisible()
		{
			return this.BaseVisible && this.InnerVisibleState == 0;
		}

		// Token: 0x0603E590 RID: 255376 RVA: 0x00FEC468 File Offset: 0x00FEA668
		private void CheckVisibleChange(bool oldVisible)
		{
			bool visible = this.GetVisible();
			if (oldVisible == visible)
			{
				return;
			}
			this.SetActive(visible);
		}

		// Token: 0x04022F11 RID: 143121
		private const int MOBILE_INDEX_EXPLORE_ITEM = 3;

		// Token: 0x04022F12 RID: 143122
		private readonly List<BattleSkillItem> BattleSkillItemList = new List<BattleSkillItem>();

		// Token: 0x04022F13 RID: 143123
		private readonly Dictionary<EBehaviorType, BehaviorButton> BehaviorButtonMap = new Dictionary<EBehaviorType, BehaviorButton>();

		// Token: 0x04022F14 RID: 143124
		[StaticVariableRuleIgnore]
		private static readonly Stat RefreshAllBattleSkillItemObject = Stat.Create("[SkillButton]RefreshAllBattleSkillItem", "", "");

		// Token: 0x04022F15 RID: 143125
		private bool BaseVisible;

		// Token: 0x04022F16 RID: 143126
		private int InnerVisibleState = 1;

		// Token: 0x04022F17 RID: 143127
		private bool DataDirty;

		// Token: 0x0200C171 RID: 49521
		[NullableContext(0)]
		private enum EPadChildType
		{
			// Token: 0x0403B912 RID: 243986
			SkillItem1,
			// Token: 0x0403B913 RID: 243987
			SkillItem2,
			// Token: 0x0403B914 RID: 243988
			SkillItem3,
			// Token: 0x0403B915 RID: 243989
			SkillItem4,
			// Token: 0x0403B916 RID: 243990
			SkillItem5,
			// Token: 0x0403B917 RID: 243991
			SkillItem6,
			// Token: 0x0403B918 RID: 243992
			SkillItem7,
			// Token: 0x0403B919 RID: 243993
			LockButtonItem,
			// Token: 0x0403B91A RID: 243994
			AimItem,
			// Token: 0x0403B91B RID: 243995
			SkillItem8
		}
	}
}
