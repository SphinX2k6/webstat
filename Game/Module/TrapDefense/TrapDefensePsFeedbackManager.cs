using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Gamepad;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E00 RID: 19968
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefensePsFeedbackManager : IStaticVariableResetter
	{
		// Token: 0x06033A12 RID: 211474 RVA: 0x00CE664E File Offset: 0x00CE484E
		static TrapDefensePsFeedbackManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(TrapDefensePsFeedbackManager.CreateStaticDefaultValue), new Action(TrapDefensePsFeedbackManager.ResetStaticDefaultValue));
		}

		// Token: 0x06033A13 RID: 211475 RVA: 0x00CE666D File Offset: 0x00CE486D
		public static void CreateStaticDefaultValue()
		{
			TrapDefensePsFeedbackManager.IsInCombinationKey = false;
		}

		// Token: 0x06033A14 RID: 211476 RVA: 0x00CE6675 File Offset: 0x00CE4875
		public static void ResetStaticDefaultValue()
		{
			TrapDefensePsFeedbackManager.IsInCombinationKey = false;
		}

		// Token: 0x06033A15 RID: 211477 RVA: 0x00CE667D File Offset: 0x00CE487D
		public static void Initialize()
		{
			TrapDefensePsFeedbackManager.AddEvent();
		}

		// Token: 0x06033A16 RID: 211478 RVA: 0x00CE6684 File Offset: 0x00CE4884
		public static void Clear()
		{
			TrapDefensePsFeedbackManager.RemoveEvent();
			TrapDefensePsFeedbackManager.StopFeedback();
		}

		// Token: 0x06033A17 RID: 211479 RVA: 0x00CE6690 File Offset: 0x00CE4890
		public static void TryRefreshFeedback()
		{
			if (!TrapDefensePsFeedbackManager.CheckFeedbackCondition())
			{
				TrapDefensePsFeedbackManager.StopFeedback();
				return;
			}
			TrapDefensePsFeedbackManager.RefreshFeedback();
		}

		// Token: 0x06033A18 RID: 211480 RVA: 0x00CE66A4 File Offset: 0x00CE48A4
		private static void AddEvent()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnInputDistributeTagChanged;
			Action<IReadOnlyList<InputDistributeTag>> handle;
			if ((handle = TrapDefensePsFeedbackManager.<>O.<0>__OnInputDistributeTagChanged) == null)
			{
				handle = (TrapDefensePsFeedbackManager.<>O.<0>__OnInputDistributeTagChanged = new Action<IReadOnlyList<InputDistributeTag>>(TrapDefensePsFeedbackManager.OnInputDistributeTagChanged));
			}
			instance.Add<IReadOnlyList<InputDistributeTag>>(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.OnCommonKeySettingKeyChange;
			Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType> handle2;
			if ((handle2 = TrapDefensePsFeedbackManager.<>O.<1>__OnCommonKeySettingKeyChange) == null)
			{
				handle2 = (TrapDefensePsFeedbackManager.<>O.<1>__OnCommonKeySettingKeyChange = new Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(TrapDefensePsFeedbackManager.OnCommonKeySettingKeyChange));
			}
			instance2.Add<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(name2, handle2);
			EventSystem instance3 = Singleton<EventSystem>.Instance;
			EEventName name3 = EEventName.RefreshTrapDefensePsFeedback;
			Action handle3;
			if ((handle3 = TrapDefensePsFeedbackManager.<>O.<2>__RefreshTrapDefensePsFeedback) == null)
			{
				handle3 = (TrapDefensePsFeedbackManager.<>O.<2>__RefreshTrapDefensePsFeedback = new Action(TrapDefensePsFeedbackManager.RefreshTrapDefensePsFeedback));
			}
			instance3.Add(name3, handle3);
			InputDistributeController instance4 = ControllerBase<InputDistributeController>.Instance;
			string actionName = "组合主键";
			TInputHandle<InputDistributeDefine.EActionType> actionCallback;
			if ((actionCallback = TrapDefensePsFeedbackManager.<>O.<3>__OnInputCombineButton) == null)
			{
				actionCallback = (TrapDefensePsFeedbackManager.<>O.<3>__OnInputCombineButton = new TInputHandle<InputDistributeDefine.EActionType>(TrapDefensePsFeedbackManager.OnInputCombineButton));
			}
			instance4.BindAction(actionName, actionCallback);
		}

		// Token: 0x06033A19 RID: 211481 RVA: 0x00CE675C File Offset: 0x00CE495C
		private static void RemoveEvent()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnInputDistributeTagChanged;
			Action<IReadOnlyList<InputDistributeTag>> handle;
			if ((handle = TrapDefensePsFeedbackManager.<>O.<0>__OnInputDistributeTagChanged) == null)
			{
				handle = (TrapDefensePsFeedbackManager.<>O.<0>__OnInputDistributeTagChanged = new Action<IReadOnlyList<InputDistributeTag>>(TrapDefensePsFeedbackManager.OnInputDistributeTagChanged));
			}
			instance.Remove<IReadOnlyList<InputDistributeTag>>(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.OnCommonKeySettingKeyChange;
			Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType> handle2;
			if ((handle2 = TrapDefensePsFeedbackManager.<>O.<1>__OnCommonKeySettingKeyChange) == null)
			{
				handle2 = (TrapDefensePsFeedbackManager.<>O.<1>__OnCommonKeySettingKeyChange = new Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(TrapDefensePsFeedbackManager.OnCommonKeySettingKeyChange));
			}
			instance2.Remove<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(name2, handle2);
			EventSystem instance3 = Singleton<EventSystem>.Instance;
			EEventName name3 = EEventName.RefreshTrapDefensePsFeedback;
			Action handle3;
			if ((handle3 = TrapDefensePsFeedbackManager.<>O.<2>__RefreshTrapDefensePsFeedback) == null)
			{
				handle3 = (TrapDefensePsFeedbackManager.<>O.<2>__RefreshTrapDefensePsFeedback = new Action(TrapDefensePsFeedbackManager.RefreshTrapDefensePsFeedback));
			}
			instance3.Remove(name3, handle3);
			InputDistributeController instance4 = ControllerBase<InputDistributeController>.Instance;
			string actionName = "组合主键";
			TInputHandle<InputDistributeDefine.EActionType> actionCallback;
			if ((actionCallback = TrapDefensePsFeedbackManager.<>O.<3>__OnInputCombineButton) == null)
			{
				actionCallback = (TrapDefensePsFeedbackManager.<>O.<3>__OnInputCombineButton = new TInputHandle<InputDistributeDefine.EActionType>(TrapDefensePsFeedbackManager.OnInputCombineButton));
			}
			instance4.UnBindAction(actionName, actionCallback);
		}

		// Token: 0x06033A1A RID: 211482 RVA: 0x00CE6814 File Offset: 0x00CE4A14
		private static void OnInputDistributeTagChanged(IReadOnlyList<InputDistributeTag> inputDistributeTags)
		{
			TrapDefensePsFeedbackManager.TryRefreshFeedback();
		}

		// Token: 0x06033A1B RID: 211483 RVA: 0x00CE681B File Offset: 0x00CE4A1B
		private static void RefreshTrapDefensePsFeedback()
		{
			TrapDefensePsFeedbackManager.TryRefreshFeedback();
		}

		// Token: 0x06033A1C RID: 211484 RVA: 0x00CE6824 File Offset: 0x00CE4A24
		private static void OnCommonKeySettingKeyChange(KeySettingRowData keyData, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
		{
			GamepadConfig instance = ConfigBase<GamepadConfig>.Instance;
			PsFeedback? psFeedback = (instance != null) ? instance.GetPsFeedbackReason(EGamepadPsFeedbackReason.TrapDefense.ToString()) : null;
			if (keyData.GetActionOrAxisName() == ((psFeedback != null) ? psFeedback.GetValueOrDefault().ActionName : null) && inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad)
			{
				TrapDefensePsFeedbackManager.TryRefreshFeedback();
			}
		}

		// Token: 0x06033A1D RID: 211485 RVA: 0x00CE688B File Offset: 0x00CE4A8B
		private static void OnInputCombineButton(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification identification)
		{
			TrapDefensePsFeedbackManager.IsInCombinationKey = (actionType == InputDistributeDefine.EActionType.Press);
			TrapDefensePsFeedbackManager.TryRefreshFeedback();
		}

		// Token: 0x06033A1E RID: 211486 RVA: 0x00CE689B File Offset: 0x00CE4A9B
		private static bool CheckInputDistribute()
		{
			return ModelBase<InputDistributeModel>.Instance.IsTagMatchAnyCurrentInputTag("FightInputRoot", false);
		}

		// Token: 0x06033A1F RID: 211487 RVA: 0x00CE68AD File Offset: 0x00CE4AAD
		private static bool CheckFeedbackCondition()
		{
			return TrapDefensePsFeedbackManager.CheckInputDistribute() && TowerDefensePlayerController.IsPlayerFollowerEnabled() && !TrapDefensePsFeedbackManager.IsInCombinationKey && TowerDefensePlayerController.Model.FollowerState == TDPlayerDefine.EFollowerState.CDReady;
		}

		// Token: 0x06033A20 RID: 211488 RVA: 0x00CE68DC File Offset: 0x00CE4ADC
		[NullableContext(2)]
		private static string GetDefaultFeedback()
		{
			int? currentFollowerProxyId = TowerDefensePlayerController.Model.CurrentFollowerProxyId;
			bool flag = (currentFollowerProxyId ?? 0) == 0;
			if (flag)
			{
				return null;
			}
			TrapDefenseAuxiliary? auxiliaryById = ConfigBase<TrapDefenseConfig>.Instance.GetAuxiliaryById(currentFollowerProxyId.Value);
			if (auxiliaryById == null)
			{
				return null;
			}
			TrapDefenseAuxiliaryType? auxiliaryTypeById = ConfigBase<TrapDefenseConfig>.Instance.GetAuxiliaryTypeById(auxiliaryById.Value.AuxiliaryType);
			if (auxiliaryTypeById == null)
			{
				return null;
			}
			return auxiliaryTypeById.Value.PsFeedbackId;
		}

		// Token: 0x06033A21 RID: 211489 RVA: 0x00CE6964 File Offset: 0x00CE4B64
		private static void RefreshFeedback()
		{
			bool flag = (TowerDefensePlayerController.Model.CurrentFollowerProxyId ?? 0) == 0;
			if (flag)
			{
				return;
			}
			string text = TowerDefensePlayerController.Model.PsFeedbackId;
			if (string.IsNullOrEmpty(text))
			{
				text = TrapDefensePsFeedbackManager.GetDefaultFeedback();
			}
			if (string.IsNullOrEmpty(text))
			{
				TrapDefensePsFeedbackManager.StopFeedback();
				return;
			}
			ControllerBase<GamepadController>.Instance.TryAddFeedbackReason(EGamepadPsFeedbackReason.TrapDefense, text);
		}

		// Token: 0x06033A22 RID: 211490 RVA: 0x00CE69CB File Offset: 0x00CE4BCB
		private static void StopFeedback()
		{
			ControllerBase<GamepadController>.Instance.RemoveFeedbackReason(EGamepadPsFeedbackReason.TrapDefense);
		}

		// Token: 0x0401DE97 RID: 122519
		private static bool IsInCombinationKey;

		// Token: 0x0200AD76 RID: 44406
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04035DFF RID: 220671
			[Nullable(new byte[]
			{
				0,
				1,
				1
			})]
			public static Action<IReadOnlyList<InputDistributeTag>> <0>__OnInputDistributeTagChanged;

			// Token: 0x04035E00 RID: 220672
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType> <1>__OnCommonKeySettingKeyChange;

			// Token: 0x04035E01 RID: 220673
			[Nullable(0)]
			public static Action <2>__RefreshTrapDefensePsFeedback;

			// Token: 0x04035E02 RID: 220674
			[Nullable(0)]
			public static TInputHandle<InputDistributeDefine.EActionType> <3>__OnInputCombineButton;
		}
	}
}
