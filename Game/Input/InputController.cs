using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input.BattleInputData;
using CSharpScript.Game.Input.InputActionLogic;
using CSharpScript.Game.Input.InputDataTypeCreator;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform;
using UnrealEngine;

namespace CSharpScript.Game.Input
{
	// Token: 0x02006FCB RID: 28619
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class InputController : ControllerBase<InputController>
	{
		// Token: 0x060453D5 RID: 283605 RVA: 0x01215B7C File Offset: 0x01213D7C
		public bool IsAllMoveEnable()
		{
			return this.CanMoveFront && this.CanMoveBack && this.CanMoveLeft && this.CanMoveRight;
		}

		// Token: 0x060453D6 RID: 283606 RVA: 0x01215BA0 File Offset: 0x01213DA0
		public void InitializeEnvironment()
		{
			InputDataTypeCreatorFactory.Initialize();
			InputActionLogicFactory.Initialize();
			if (Singleton<Info>.Instance.UseFastInputCallback)
			{
				UKuroInputDelegateLibrary.InitializeEnvironment();
			}
			if (Singleton<Info>.Instance.AxisInputOptimize)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Kuro.Input.AxisOptimize 1", null);
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Kuro.Input.AxisOptimize 0", null);
		}

		// Token: 0x1700A4BA RID: 42170
		// (get) Token: 0x060453D7 RID: 283607 RVA: 0x01215BF5 File Offset: 0x01213DF5
		[Nullable(2)]
		public InputModel Model
		{
			[NullableContext(2)]
			get
			{
				return ModelBase<InputModel>.Instance;
			}
		}

		// Token: 0x060453D8 RID: 283608 RVA: 0x01215BFC File Offset: 0x01213DFC
		protected override bool OnInit()
		{
			this.AddEvents();
			return true;
		}

		// Token: 0x060453D9 RID: 283609 RVA: 0x01215C05 File Offset: 0x01213E05
		protected override bool OnClear()
		{
			this.RemoveEvents();
			return true;
		}

		// Token: 0x060453DA RID: 283610 RVA: 0x01215C10 File Offset: 0x01213E10
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnCloseLoadingView, new Action(this.OnCloseLoadingView));
			Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
			Singleton<EventSystem>.Instance.Add(EEventName.ForceReleaseInput, new Action<string>(this.OnForceReleaseInput));
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<InputDistributeTag>>(EEventName.OnInputDistributeTagChanged, new Action<IReadOnlyList<InputDistributeTag>>(this.OnInputDistributeTagChanged));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
			Singleton<EventSystem>.Instance.Add<string, int?>(EEventName.RefreshInputData, new Action<string, int?>(this.OnRefreshInputData));
		}

		// Token: 0x060453DB RID: 283611 RVA: 0x01215CC8 File Offset: 0x01213EC8
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseLoadingView, new Action(this.OnCloseLoadingView));
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnInputDistributeTagChanged, new Action<IReadOnlyList<InputDistributeTag>>(this.OnInputDistributeTagChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.ForceReleaseInput, new Action<string>(this.OnForceReleaseInput));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshInputData, new Action<string, int?>(this.OnRefreshInputData));
		}

		// Token: 0x060453DC RID: 283612 RVA: 0x01215D80 File Offset: 0x01213F80
		private void OnInputCameraAxis(string axisName, float value, InputIdentification inputIdentification)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			BattleInputData currentInputData = model.GetCurrentInputData();
			if (currentInputData == null)
			{
				return;
			}
			EInputAxis? inputAxis = inputIdentification.GetInputAxis(currentInputData);
			if (inputAxis == null)
			{
				return;
			}
			this.InputAxis(inputAxis.Value, value, false);
			APlayerController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return;
			}
			if (value > 0f && inputAxis.Value != EInputAxis.Zoom && Singleton<Info>.Instance.IsInKeyBoard() && !characterController.bShowMouseCursor)
			{
				Singleton<InputManager>.Instance.MoveCursorToCenter();
			}
		}

		// Token: 0x060453DD RID: 283613 RVA: 0x01215E08 File Offset: 0x01214008
		private void OnInputMoveAxis(string axisName, float value, InputIdentification inputIdentification)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			BattleInputData currentInputData = model.GetCurrentInputData();
			if (currentInputData == null)
			{
				return;
			}
			EInputAxis? inputAxis = inputIdentification.GetInputAxis(currentInputData);
			if (inputAxis == null)
			{
				return;
			}
			this.InputAxis(inputAxis.Value, value, false);
		}

		// Token: 0x060453DE RID: 283614 RVA: 0x01215E4C File Offset: 0x0121404C
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			EInputState state = (actionType == InputDistributeDefine.EActionType.Press) ? EInputState.Press : EInputState.Release;
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			BattleInputData currentInputData = model.GetCurrentInputData();
			if (currentInputData == null)
			{
				return;
			}
			EInputAction? inputAction = inputIdentification.GetInputAction(currentInputData);
			if (inputAction == null)
			{
				return;
			}
			this.InputAction(inputAction.Value, state);
		}

		// Token: 0x060453DF RID: 283615 RVA: 0x01215E97 File Offset: 0x01214097
		public void BindInputActions(List<string> actionNames)
		{
			ControllerBase<InputDistributeController>.Instance.BindActions(actionNames, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x060453E0 RID: 283616 RVA: 0x01215EB0 File Offset: 0x012140B0
		public void UnBindInputActions(List<string> actionNames)
		{
			ControllerBase<InputDistributeController>.Instance.UnBindActions(actionNames, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x060453E1 RID: 283617 RVA: 0x01215EC9 File Offset: 0x012140C9
		public void BindInputMoveAxes(List<string> axisNames)
		{
			ControllerBase<InputDistributeController>.Instance.BindAxes(axisNames, new TInputHandle<float>(this.OnInputMoveAxis));
		}

		// Token: 0x060453E2 RID: 283618 RVA: 0x01215EE2 File Offset: 0x012140E2
		public void UnBindInputMoveAxes(List<string> axisNames)
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAxes(axisNames, new TInputHandle<float>(this.OnInputMoveAxis));
		}

		// Token: 0x060453E3 RID: 283619 RVA: 0x01215EFC File Offset: 0x012140FC
		private void OnSequenceNetworkStart(PlotInfo plotInfo)
		{
			bool flag = plotInfo.PlotLevel == EPlotLevel.LevelD || plotInfo.PlotLevel == EPlotLevel.LevelE;
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			EInputDataType currentInputDataType = model.GetCurrentInputDataType();
			foreach (KeyValuePair<EInputAction, float> keyValuePair in model.GetPressTimes())
			{
				EInputAction key = keyValuePair.Key;
				if (flag)
				{
					InputActionLogicBase inputActionLogic = InputActionLogicFactory.GetInputActionLogic(key);
					if (inputActionLogic != null && !inputActionLogic.IsAllowReleaseInput(currentInputDataType))
					{
						continue;
					}
				}
				this.InputAction(key, EInputState.Release);
			}
		}

		// Token: 0x060453E4 RID: 283620 RVA: 0x01215FA0 File Offset: 0x012141A0
		private void OnCloseLoadingView()
		{
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS || Singleton<Platform>.Instance.CloudGamePlatform == ECloudGamePlatform.IOS.ToEnumString() || Singleton<Platform>.Instance.CloudGamePlatform == ECloudGamePlatform.Mac.ToEnumString())
			{
				int num = 0;
				int playerIndex = 0;
				UKuroStaticLibrary.SetInputKeyDeadZone(Global.CharacterController, playerIndex, new FKey(new FName(EKey.Gamepad_LeftY)), (float)num);
				UKuroStaticLibrary.SetInputKeyDeadZone(Global.CharacterController, playerIndex, new FKey(new FName(EKey.Gamepad_RightX)), (float)num);
				UKuroStaticLibrary.SetInputKeyDeadZone(Global.CharacterController, playerIndex, new FKey(new FName(EKey.Gamepad_RightY)), (float)num);
				UKuroStaticLibrary.SetInputKeyDeadZone(Global.CharacterController, playerIndex, new FKey(new FName(EKey.Gamepad_LeftX)), (float)num);
			}
		}

		// Token: 0x060453E5 RID: 283621 RVA: 0x01216074 File Offset: 0x01214274
		private void OnForceReleaseInput(string reason)
		{
			if (!string.IsNullOrEmpty(reason))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "强制释放所有按键";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			EInputDataType currentInputDataType = model.GetCurrentInputDataType();
			foreach (KeyValuePair<EInputAction, float> keyValuePair in model.GetPressTimes())
			{
				EInputAction key = keyValuePair.Key;
				InputActionLogicBase inputActionLogic = InputActionLogicFactory.GetInputActionLogic(key);
				if (inputActionLogic == null || inputActionLogic.IsAllowReleaseInput(currentInputDataType))
				{
					this.InputAction(key, EInputState.Release);
				}
			}
		}

		// Token: 0x060453E6 RID: 283622 RVA: 0x0121612C File Offset: 0x0121432C
		private void ForceClearAxisInput(string reason)
		{
			if (reason.Length > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "强制清理所有轴输入";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			if (this.Model == null)
			{
				return;
			}
			Dictionary<EInputAxis, float> axisValues = this.Model.GetAxisValues();
			List<IInputHandler> handlers = this.Model.GetHandlers();
			foreach (KeyValuePair<EInputAxis, float> keyValuePair in axisValues)
			{
				EInputAxis key = keyValuePair.Key;
				if (keyValuePair.Value != 0f)
				{
					axisValues[key] = 0f;
					foreach (IInputHandler inputHandler in handlers)
					{
						inputHandler.ClearSingleAxisInput(key, false);
					}
				}
			}
		}

		// Token: 0x060453E7 RID: 283623 RVA: 0x01216228 File Offset: 0x01214428
		private unsafe void TryUnBindCurrentInputData()
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			BattleInputData currentInputData = model.GetCurrentInputData();
			if (currentInputData != null)
			{
				string[] actionNameList = currentInputData.GetActionNameList();
				string[] moveAxisList = currentInputData.GetMoveAxisList();
				string[] cameraAxisList = currentInputData.GetCameraAxisList();
				ControllerBase<InputDistributeController>.Instance.UnBindActions(actionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
				ControllerBase<InputDistributeController>.Instance.UnBindAxes(moveAxisList, new TInputHandle<float>(this.OnInputMoveAxis));
				ControllerBase<InputDistributeController>.Instance.UnBindAxes(cameraAxisList, new TInputHandle<float>(this.OnInputCameraAxis));
				Singleton<InputManager>.Instance.RemoveViewHotKeyActionByType(currentInputData.Type);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "InstanceChange解除绑定";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("输入数据类型", currentInputData.Type);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("actionNameList", actionNameList);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("moveAxisNameList", moveAxisList);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("cameraAxisNameList", cameraAxisList);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
		}

		// Token: 0x060453E8 RID: 283624 RVA: 0x0121634C File Offset: 0x0121454C
		private unsafe void HandleBindInputData(EInputDataType inputDataType)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			model.SetCurrentInputDataType(inputDataType);
			BattleInputData currentInputData = model.GetCurrentInputData();
			if (currentInputData != null)
			{
				string[] actionNameList = currentInputData.GetActionNameList();
				string[] moveAxisList = currentInputData.GetMoveAxisList();
				string[] cameraAxisList = currentInputData.GetCameraAxisList();
				ControllerBase<InputDistributeController>.Instance.BindActions(actionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
				ControllerBase<InputDistributeController>.Instance.BindAxes(moveAxisList, new TInputHandle<float>(this.OnInputMoveAxis));
				ControllerBase<InputDistributeController>.Instance.BindAxes(cameraAxisList, new TInputHandle<float>(this.OnInputCameraAxis));
				Singleton<InputManager>.Instance.AddViewHotKeyActionByType(currentInputData.Type);
				Singleton<InputSettingsManager>.Instance.SwitchKeysByBindingType(currentInputData.KeyBindingType);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "InstanceChange绑定输入";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("输入数据类型", currentInputData.Type);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("actionNameList", actionNameList);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("moveAxisNameList", moveAxisList);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("cameraAxisNameList", cameraAxisList);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
		}

		// Token: 0x060453E9 RID: 283625 RVA: 0x01216488 File Offset: 0x01214688
		private void TryBindInputData(int instanceId)
		{
			InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
			if (instance == null)
			{
				return;
			}
			InstanceDungeon? config = instance.GetConfig(instanceId);
			if (config == null)
			{
				return;
			}
			InputDataTypeCreator inputDataCreator = InputDataTypeCreatorFactory.GetInputDataCreator((EDungeonSubType)config.Value.InstSubType, (EWorldDungeonSubType)config.Value.WorldDungeonSubType);
			if (inputDataCreator == null)
			{
				return;
			}
			EInputDataType inputDataType = inputDataCreator.GetInputDataType();
			this.HandleBindInputData(inputDataType);
		}

		// Token: 0x060453EA RID: 283626 RVA: 0x012164E9 File Offset: 0x012146E9
		private void TryRefreshInputData(int instanceId)
		{
			this.TryUnBindCurrentInputData();
			this.TryBindInputData(instanceId);
		}

		// Token: 0x060453EB RID: 283627 RVA: 0x012164F8 File Offset: 0x012146F8
		private void OnInstanceChange(int lastInstanceId, int newInstanceId)
		{
			this.TryRefreshInputData(newInstanceId);
		}

		// Token: 0x060453EC RID: 283628 RVA: 0x01216504 File Offset: 0x01214704
		private unsafe void OnRefreshInputData(string reason, int? type)
		{
			if (type.GetValueOrDefault() == 1)
			{
				this.OnForceReleaseInput("OnRefreshInputData");
			}
			else if (type.GetValueOrDefault() == 2)
			{
				this.ForceClearAxisInput("OnRefreshInputData");
			}
			else
			{
				this.OnForceReleaseInput("OnRefreshInputData");
				this.ForceClearAxisInput("OnRefreshInputData");
			}
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			if (instance == null)
			{
				return;
			}
			int instanceId = instance.GetInstanceId();
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "刷新当前绑定输入";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("原因", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前副本id", instanceId);
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.TryRefreshInputData(instanceId);
		}

		// Token: 0x060453ED RID: 283629 RVA: 0x012165C8 File Offset: 0x012147C8
		private void OnInputDistributeTagChanged(IReadOnlyList<InputDistributeTag> inputDistributeTags)
		{
			InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
			if (instance == null)
			{
				return;
			}
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			foreach (KeyValuePair<EInputAction, float> keyValuePair in model.GetPressTimes())
			{
				EInputAction key = keyValuePair.Key;
				string actionInputDistributeTagName = instance.GetActionInputDistributeTagName(keyValuePair.Key.Name);
				if (!string.IsNullOrEmpty(actionInputDistributeTagName) && !instance.IsTagMatchAnyCurrentInputTag(actionInputDistributeTagName, false) && !instance.IsPreventIgnoredAction(keyValuePair.Key.Name))
				{
					this.InputAction(key, EInputState.Release);
				}
			}
			model.NextFrameRefreshAxisValues();
		}

		// Token: 0x060453EE RID: 283630 RVA: 0x01216680 File Offset: 0x01214880
		public void GmSwitchBattleInputData(EInputDataType inputDataType)
		{
			this.TryUnBindCurrentInputData();
			this.HandleBindInputData(inputDataType);
		}

		// Token: 0x060453EF RID: 283631 RVA: 0x01216690 File Offset: 0x01214890
		public void AddInputHandler(IInputHandler handler)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			model.AddInputHandler(handler);
		}

		// Token: 0x060453F0 RID: 283632 RVA: 0x012166B0 File Offset: 0x012148B0
		public void RemoveInputHandler(IInputHandler handler)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			model.RemoveInputHandler(handler);
		}

		// Token: 0x060453F1 RID: 283633 RVA: 0x012166D0 File Offset: 0x012148D0
		public void InputAction(EInputAction action, EInputState state)
		{
			if (EInputAction.锁定目标 == action && !ModelBase<FunctionModel>.Instance.IsOpen(10031))
			{
				return;
			}
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			Dictionary<EInputAction, float> pressTimes = model.GetPressTimes();
			if (state == EInputState.Press)
			{
				model.SetHoldTime(action, null);
				float num = (float)Singleton<Time>.Instance.WorldTimeSeconds;
				pressTimes[action] = num;
				List<IInputHandler> handlers = model.GetHandlers();
				for (int i = 0; i < handlers.Count; i++)
				{
					IInputHandler inputHandler = handlers[i];
					InputFilter inputFilter = inputHandler.GetInputFilter();
					if (inputFilter.BlockAction(action))
					{
						return;
					}
					if (inputFilter.ListenToAction(action))
					{
						inputHandler.HandlePressEvent(action, num);
					}
				}
				return;
			}
			if (state != EInputState.Release)
			{
				return;
			}
			float num2;
			if (!pressTimes.TryGetValue(action, out num2))
			{
				num2 = -1f;
			}
			if (num2 == -1f)
			{
				return;
			}
			float time = this.QueryHoldTimeAccumulate(action);
			model.SetHoldTime(action, new float?((float)-1));
			pressTimes[action] = -1f;
			List<IInputHandler> handlers2 = model.GetHandlers();
			for (int j = 0; j < handlers2.Count; j++)
			{
				IInputHandler inputHandler2 = handlers2[j];
				InputFilter inputFilter2 = inputHandler2.GetInputFilter();
				if (inputFilter2.BlockAction(action))
				{
					break;
				}
				if (inputFilter2.ListenToAction(action))
				{
					inputHandler2.HandleReleaseEvent(action, time);
				}
			}
		}

		// Token: 0x060453F2 RID: 283634 RVA: 0x0121681C File Offset: 0x01214A1C
		public void SetMoveControlEnabled(bool bFront, bool bBack, bool bLeft, bool bRight)
		{
			this.CanMoveFront = bFront;
			this.CanMoveBack = bBack;
			this.CanMoveLeft = bLeft;
			this.CanMoveRight = bRight;
			if (!Singleton<Info>.Instance.AxisInputOptimize)
			{
				return;
			}
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			model.NextFrameRefreshAxisValues();
			if (bFront && bBack && bLeft && bRight)
			{
				return;
			}
			Dictionary<EInputAxis, float> axisValues = model.GetAxisValues();
			List<IInputHandler> handlers = model.GetHandlers();
			if (!bFront || !bBack)
			{
				axisValues[EInputAxis.MoveForward] = 0f;
				for (int i = 0; i < handlers.Count; i++)
				{
					handlers[i].ClearSingleAxisInput(EInputAxis.MoveForward, false);
				}
			}
			if (!bRight || !bLeft)
			{
				axisValues[EInputAxis.MoveRight] = 0f;
				for (int j = 0; j < handlers.Count; j++)
				{
					handlers[j].ClearSingleAxisInput(EInputAxis.MoveRight, false);
				}
			}
		}

		// Token: 0x060453F3 RID: 283635 RVA: 0x012168F8 File Offset: 0x01214AF8
		public unsafe void InputAxis(EInputAxis axis, float value, bool autoClear = true)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			Dictionary<EInputAxis, float> axisValues = model.GetAxisValues();
			if (Singleton<Info>.Instance.AxisInputOptimize)
			{
				if (autoClear)
				{
					this.AutoClearAxisSet.Add(axis);
				}
				float num;
				if (axisValues.TryGetValue(axis, out num) && num == value)
				{
					return;
				}
			}
			else if (value == 0f && axisValues.ContainsKey(axis))
			{
				return;
			}
			if (ModelBase<InputModel>.Instance.IsOpenInputAxisLog && axis == (EInputAxis)3)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[InputLog][InputController]开始接收输入";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("axis", axis);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			if (axis == EInputAxis.MoveForward)
			{
				if (!this.CanMoveFront && value > 0f)
				{
					return;
				}
				if (!this.CanMoveBack && value < 0f)
				{
					return;
				}
			}
			if (axis == EInputAxis.MoveRight)
			{
				if (!this.CanMoveRight && value > 0f)
				{
					return;
				}
				if (!this.CanMoveLeft && value < 0f)
				{
					return;
				}
			}
			axisValues[axis] = value;
			if (ModelBase<InputModel>.Instance.IsOpenInputAxisLog)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Input;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "[InputLog][InputController]完成接收输入";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisSet", axisValues);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x060453F4 RID: 283636 RVA: 0x01216A68 File Offset: 0x01214C68
		public void PreProcessInput(float deltaTime, bool gamePaused)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			List<IInputHandler> handlers = model.GetHandlers();
			for (int i = 0; i < handlers.Count; i++)
			{
				handlers[i].PreProcessInput(deltaTime, gamePaused);
			}
		}

		// Token: 0x060453F5 RID: 283637 RVA: 0x01216AA8 File Offset: 0x01214CA8
		public unsafe void PostProcessInput(float deltaTime, bool gamePaused)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			List<IInputHandler> handlers = model.GetHandlers();
			foreach (KeyValuePair<EInputAxis, float> keyValuePair in model.GetAxisValues())
			{
				EInputAxis key = keyValuePair.Key;
				float value = keyValuePair.Value;
				for (int i = 0; i < handlers.Count; i++)
				{
					IInputHandler inputHandler = handlers[i];
					InputFilter inputFilter = inputHandler.GetInputFilter();
					if (inputFilter.BlockAxis(key))
					{
						inputHandler.ClearSingleAxisInput(key, false);
						break;
					}
					if (inputFilter.ListenToAxis(key))
					{
						if (ModelBase<InputModel>.Instance.IsOpenInputAxisLog && key == (EInputAxis)3)
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.Input;
							ELogAuthor author = ELogAuthor.XXJ;
							string message = "[InputLog][InputController]开始处理轴输入";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("axis", key);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
							instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						}
						inputHandler.HandleInputAxis(key, value);
					}
				}
			}
			foreach (KeyValuePair<EInputAction, float> keyValuePair2 in model.GetHoldTimes())
			{
				EInputAction key2 = keyValuePair2.Key;
				float value2 = keyValuePair2.Value;
				if (value2 != -1f)
				{
					float num = this.InvertDeltaTimeBySelfCenter(deltaTime);
					float num2 = value2 + num;
					model.SetHoldTime(key2, new float?(num2));
					for (int j = 0; j < handlers.Count; j++)
					{
						IInputHandler inputHandler2 = handlers[j];
						InputFilter inputFilter2 = inputHandler2.GetInputFilter();
						if (inputFilter2.BlockAction(key2))
						{
							break;
						}
						if (inputFilter2.ListenToAction(key2))
						{
							inputHandler2.HandleHoldEvent(key2, num2);
						}
					}
				}
			}
			try
			{
				for (int k = 0; k < handlers.Count; k++)
				{
					handlers[k].PostProcessInput(deltaTime, gamePaused);
				}
			}
			catch (Exception ex)
			{
				if (ex != null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Json;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "PostProcessInput";
					Exception error = ex;
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("msg", ex.Message);
					instance2.ErrorWithStack(module2, author2, message2, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Json;
					ELogAuthor author3 = ELogAuthor.XXJ;
					string message3 = "PostProcessInput";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("error", ex);
					instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
			}
			finally
			{
			}
			if (!Singleton<Info>.Instance.AxisInputOptimize)
			{
				model.GetAxisValues().Clear();
			}
			else
			{
				foreach (EInputAxis einputAxis in this.AutoClearAxisSet)
				{
					if (model.GetAxisValues().ContainsKey(einputAxis))
					{
						model.GetAxisValues().Remove(einputAxis);
					}
					for (int l = 0; l < handlers.Count; l++)
					{
						handlers[l].ClearSingleAxisInput(einputAxis, true);
					}
				}
				this.AutoClearAxisSet.Clear();
			}
			if (ModelBase<InputModel>.Instance.IsOpenInputAxisLog)
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputLog][InputController]开始输入处理完成", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x060453F6 RID: 283638 RVA: 0x01216E6C File Offset: 0x0121506C
		public int? QueryCommandPriority(ECommandType commandType)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return null;
			}
			return model.QueryCommandPriority(commandType);
		}

		// Token: 0x060453F7 RID: 283639 RVA: 0x01216E94 File Offset: 0x01215094
		public bool IsKeyDown(EInputAction action)
		{
			InputModel model = this.Model;
			float num;
			return model != null && model.GetPressTimes().TryGetValue(action, out num) && num != -1f;
		}

		// Token: 0x060453F8 RID: 283640 RVA: 0x01216ECC File Offset: 0x012150CC
		public float GetKeyDownTime(EInputAction action)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return 0f;
			}
			float num;
			if (!model.GetPressTimes().TryGetValue(action, out num))
			{
				return 0f;
			}
			if (num != -1f)
			{
				return (float)Math.Max(0.0, Singleton<Time>.Instance.WorldTimeSeconds - (double)num);
			}
			return 0f;
		}

		// Token: 0x060453F9 RID: 283641 RVA: 0x01216F2C File Offset: 0x0121512C
		private float QueryHoldTimeAccumulate(EInputAction action)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return -1f;
			}
			float? holdTime = model.GetHoldTime(action);
			if (holdTime != null)
			{
				float? num = holdTime;
				float num2 = (float)-1;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					return holdTime.Value;
				}
			}
			return -1f;
		}

		// Token: 0x060453FA RID: 283642 RVA: 0x01216F80 File Offset: 0x01215180
		private float InvertDeltaTimeBySelfCenter(float deltaTime)
		{
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			float num = (instance != null) ? instance.InverseSelfCenteredTimeDilation : 1f;
			return deltaTime * num;
		}

		// Token: 0x060453FB RID: 283643 RVA: 0x01216FA6 File Offset: 0x012151A6
		public void SetForceFeedbackConfig(EGlobalKuroForceFeedbackType feedbackConfig, int globalFeedbackCoef)
		{
			ABasePlayerController.SetKuroForceFeedbackConfig(feedbackConfig, globalFeedbackCoef);
		}

		// Token: 0x060453FC RID: 283644 RVA: 0x01216FB0 File Offset: 0x012151B0
		public void AddInputLayer(int unitId, InputLayer layer)
		{
			layer.UnitId = unitId;
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			model.AddInputLayer(unitId, layer);
		}

		// Token: 0x060453FD RID: 283645 RVA: 0x01216FD8 File Offset: 0x012151D8
		public void RemoveInputLayer(InputLayer layer)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return;
			}
			model.RemoveInputLayer(layer);
		}

		// Token: 0x060453FE RID: 283646 RVA: 0x01216FF8 File Offset: 0x012151F8
		[NullableContext(2)]
		public InputLayer CreateInputLayer(EInputLayer layerType)
		{
			switch (layerType)
			{
			case EInputLayer.None:
				return null;
			case EInputLayer.Character:
				return new CharacterInputLayer();
			case EInputLayer.Extra:
				return new ExtraInputLayer();
			case EInputLayer.Vision:
				return new VisionInputLayer();
			case EInputLayer.Vehicle:
				return new VehicleInputLayer();
			case EInputLayer.Interaction:
				return new InteractionInputLayer();
			case EInputLayer.FollowShooter:
				return new FollowShooterInputLayer();
			case EInputLayer.Manipulate:
				return new ManipulateInputLayer();
			case EInputLayer.TowerDefense:
				return new TowerDefenseInputLayer();
			case EInputLayer.SurvivorsRogue:
				return new SurvivorsRogueInputLayer();
			case EInputLayer.HoldingHands:
				return new HoldingHandsInputLayer();
			case EInputLayer.Panoramic:
				return new PanoramicInputLayer();
			case EInputLayer.OverShoulder:
				return new OverShoulderInputLayer();
			case EInputLayer.Potato:
				return new PotatoInputLayer();
			default:
				if (layerType != EInputLayer.AceAntiCheat)
				{
					return null;
				}
				return new AceAntiCheatInputLayer();
			}
		}

		// Token: 0x060453FF RID: 283647 RVA: 0x012170A4 File Offset: 0x012152A4
		[NullableContext(2)]
		public InputLayer GetInputLayer(int unitId, EInputLayer layerType)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return null;
			}
			return model.GetInputLayer(unitId, layerType);
		}

		// Token: 0x06045400 RID: 283648 RVA: 0x012170C8 File Offset: 0x012152C8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<InputLayer> GetInputLayers(int unitId)
		{
			InputModel model = this.Model;
			if (model == null)
			{
				return null;
			}
			return model.GetInputLayers(unitId);
		}

		// Token: 0x04026A09 RID: 158217
		private const int KEY_RELEASED_TIME = -1;

		// Token: 0x04026A0A RID: 158218
		private readonly Stat PostProcessInputStat = Stat.Create("InputController.PostProcessInput", "", "");

		// Token: 0x04026A0B RID: 158219
		private readonly Stat HandleInputAxisStat = Stat.Create("InputController.HandleInputAxis", "", "");

		// Token: 0x04026A0C RID: 158220
		private readonly Stat HandleHoldStat = Stat.Create("InputController.HandleHold", "", "");

		// Token: 0x04026A0D RID: 158221
		private readonly Stat UnBindInputDataStat = Stat.Create("InputController.UnBindInputData", "", "");

		// Token: 0x04026A0E RID: 158222
		private readonly Stat HandleBindInputDataStat = Stat.Create("InputController.HandleBindInputData", "", "");

		// Token: 0x04026A0F RID: 158223
		private readonly Stat BindInputDataStat = Stat.Create("InputController.BindInputData", "", "");

		// Token: 0x04026A10 RID: 158224
		private readonly Stat AddViewHotKeyActionByTypeStat = Stat.Create("InputController.AddViewHotKeyActionByType", "", "");

		// Token: 0x04026A11 RID: 158225
		private readonly Stat SwitchKeysByBindingTypeStat = Stat.Create("InputController.SwitchKeysByBindingType", "", "");

		// Token: 0x04026A12 RID: 158226
		private bool CanMoveFront = true;

		// Token: 0x04026A13 RID: 158227
		private bool CanMoveBack = true;

		// Token: 0x04026A14 RID: 158228
		private bool CanMoveLeft = true;

		// Token: 0x04026A15 RID: 158229
		private bool CanMoveRight = true;

		// Token: 0x04026A16 RID: 158230
		private HashSet<EInputAxis> AutoClearAxisSet = new HashSet<EInputAxis>();
	}
}
