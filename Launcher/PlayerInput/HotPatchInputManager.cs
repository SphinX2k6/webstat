using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.HotPatch;
using CSharpScript.Launcher.InputDevice;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.PlayerInput
{
	// Token: 0x02004550 RID: 17744
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class HotPatchInputManager : Singleton<HotPatchInputManager>
	{
		// Token: 0x0602EB04 RID: 191236 RVA: 0x00B0FBC4 File Offset: 0x00B0DDC4
		private UniTask InitActionHandle()
		{
			HotPatchInputManager.<InitActionHandle>d__13 <InitActionHandle>d__;
			<InitActionHandle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitActionHandle>d__.<>4__this = this;
			<InitActionHandle>d__.<>1__state = -1;
			<InitActionHandle>d__.<>t__builder.Start<HotPatchInputManager.<InitActionHandle>d__13>(ref <InitActionHandle>d__);
			return <InitActionHandle>d__.<>t__builder.Task;
		}

		// Token: 0x0602EB05 RID: 191237 RVA: 0x00B0FC08 File Offset: 0x00B0DE08
		private void RegisterInputActionSettings(string actionName, string keyName)
		{
			UInputSettings inputSettings = UInputSettings.GetInputSettings();
			FName actionName2 = new FName(actionName);
			FKey key = new FKey(new FName(keyName));
			FInputActionKeyMapping item = new FInputActionKeyMapping(actionName2, false, false, false, false, key);
			inputSettings.AddActionMapping(item, true);
			this.InputActionKeyMappings.Add(item);
		}

		// Token: 0x0602EB06 RID: 191238 RVA: 0x00B0FC4C File Offset: 0x00B0DE4C
		private void RegisterInputAxisSettings(string axisName, [Nullable(new byte[]
		{
			0,
			1
		})] ValueTuple<string, int> keyScale)
		{
			UInputSettings inputSettings = UInputSettings.GetInputSettings();
			FName axisName2 = new FName(axisName);
			FKey key = new FKey(new FName(keyScale.Item1));
			FInputAxisKeyMapping item = new FInputAxisKeyMapping(axisName2, (float)keyScale.Item2, key);
			inputSettings.AddAxisMapping(item, true);
			this.InputAxisKeyMappings.Add(item);
		}

		// Token: 0x0602EB07 RID: 191239 RVA: 0x00B0FC98 File Offset: 0x00B0DE98
		private void RegisterAllInputSetting()
		{
			foreach (KeyValuePair<string, EMouseKey> keyValuePair in Singleton<HotPatchInputDefine>.Instance.pcInputMap)
			{
				this.RegisterInputActionSettings(keyValuePair.Key, keyValuePair.Value.ToString());
			}
			foreach (KeyValuePair<string, EGamepadKey> keyValuePair2 in Singleton<HotPatchInputDefine>.Instance.gamepadActionInputMap)
			{
				this.RegisterInputActionSettings(keyValuePair2.Key, keyValuePair2.Value.ToString());
			}
			foreach (KeyValuePair<string, ValueTuple<string, int>> keyValuePair3 in Singleton<HotPatchInputDefine>.Instance.gamepadAxisInputMap)
			{
				this.RegisterInputAxisSettings(keyValuePair3.Key, keyValuePair3.Value);
			}
		}

		// Token: 0x0602EB08 RID: 191240 RVA: 0x00B0FDC4 File Offset: 0x00B0DFC4
		private void UnRegisterAllInputSetting()
		{
			UInputSettings inputSettings = UInputSettings.GetInputSettings();
			for (int i = 0; i < this.InputActionKeyMappings.Count; i++)
			{
				FInputActionKeyMapping finputActionKeyMapping = this.InputActionKeyMappings[i];
				if (inputSettings != null)
				{
					inputSettings.RemoveActionMapping(finputActionKeyMapping, true);
				}
			}
			for (int j = 0; j < this.InputAxisKeyMappings.Count; j++)
			{
				FInputAxisKeyMapping finputAxisKeyMapping = this.InputAxisKeyMappings[j];
				if (inputSettings != null)
				{
					inputSettings.RemoveAxisMapping(finputAxisKeyMapping, true);
				}
			}
		}

		// Token: 0x0602EB09 RID: 191241 RVA: 0x00B0FE38 File Offset: 0x00B0E038
		private void NewActionHandle(string actionName)
		{
			TsHotFixActionHandle_C tsHotFixActionHandle_C = new TsHotFixActionHandle_C(this.WorldContext, null, EObjectFlags.RF_NoFlags);
			tsHotFixActionHandle_C.OnPressActionCallback.Add(new Action<bool, string, FKey>(this.InputActionCallback));
			tsHotFixActionHandle_C.AddPressBinding(actionName, this.PlayerController);
			tsHotFixActionHandle_C.AddReleaseBinding(actionName, this.PlayerController);
			this.ActionHandleMap[actionName] = tsHotFixActionHandle_C;
		}

		// Token: 0x0602EB0A RID: 191242 RVA: 0x00B0FE94 File Offset: 0x00B0E094
		private void NewAxisHandle(string axisName)
		{
			TsHotFixActionHandle_C tsHotFixActionHandle_C = new TsHotFixActionHandle_C(this.WorldContext, null, EObjectFlags.RF_NoFlags);
			tsHotFixActionHandle_C.OnAxisCallback.Add(new Action<float, string>(this.InputAxisCallback));
			tsHotFixActionHandle_C.AddAxisBinding(axisName, this.PlayerController);
			this.AxisHandleMap[axisName] = tsHotFixActionHandle_C;
		}

		// Token: 0x0602EB0B RID: 191243 RVA: 0x00B0FEE0 File Offset: 0x00B0E0E0
		private void RegisterPcAndGamepadInput()
		{
			foreach (KeyValuePair<string, EMouseKey> keyValuePair in Singleton<HotPatchInputDefine>.Instance.pcInputMap)
			{
				this.NewActionHandle(keyValuePair.Key);
			}
			foreach (KeyValuePair<string, EGamepadKey> keyValuePair2 in Singleton<HotPatchInputDefine>.Instance.gamepadActionInputMap)
			{
				this.NewActionHandle(keyValuePair2.Key);
			}
			foreach (KeyValuePair<string, ValueTuple<string, int>> keyValuePair3 in Singleton<HotPatchInputDefine>.Instance.gamepadAxisInputMap)
			{
				this.NewAxisHandle(keyValuePair3.Key);
			}
		}

		// Token: 0x0602EB0C RID: 191244 RVA: 0x00B0FFD8 File Offset: 0x00B0E1D8
		private void RegisterMobileInput()
		{
			TsHotFixActionHandle_C tsHotFixActionHandle_C = new TsHotFixActionHandle_C(this.WorldContext, null, EObjectFlags.RF_NoFlags);
			tsHotFixActionHandle_C.OnTouchActionCallback.Add(new Action<bool, TEnumAsByte<ETouchIndex>, FVector>(this.OnTouchActionCallback));
			tsHotFixActionHandle_C.OnTouchMovedActionCallback.Add(new Action<TEnumAsByte<ETouchIndex>, FVector>(this.OnTouchMovedActionCallback));
			tsHotFixActionHandle_C.AddTouchPressBinding(this.PlayerController);
			tsHotFixActionHandle_C.AddTouchReleaseBinding(this.PlayerController);
			tsHotFixActionHandle_C.AddTouchMoveBinding(this.PlayerController);
			this.TouchHandle = tsHotFixActionHandle_C;
		}

		// Token: 0x0602EB0D RID: 191245 RVA: 0x00B1004C File Offset: 0x00B0E24C
		private void RegsiterAnyKeyInput()
		{
			TsHotFixActionHandle_C tsHotFixActionHandle_C = new TsHotFixActionHandle_C(this.WorldContext, null, EObjectFlags.RF_NoFlags);
			tsHotFixActionHandle_C.OnAnyKeyPressCallback.Add(new Action<FKey>(this.OnAnyKeyPress));
			tsHotFixActionHandle_C.AddAnyKeyPress(this.PlayerController, new FInputChord(new FKey(new FName("AnyKey")), false, false, false, false));
			this.AnyKeyHandle = tsHotFixActionHandle_C;
		}

		// Token: 0x0602EB0E RID: 191246 RVA: 0x00B100AC File Offset: 0x00B0E2AC
		private void InputActionCallback(bool isPress, string actionName, FKey key)
		{
			HashSet<TInputAction> hashSet;
			if (!this.InputActionMap.TryGetValue(actionName, out hashSet))
			{
				return;
			}
			foreach (TInputAction tinputAction in hashSet)
			{
				tinputAction(isPress, actionName);
			}
		}

		// Token: 0x0602EB0F RID: 191247 RVA: 0x00B1010C File Offset: 0x00B0E30C
		private void InputAxisCallback(float value, string axisName)
		{
			HashSet<TInputAxis> hashSet;
			if (!this.InputAxisMap.TryGetValue(axisName, out hashSet))
			{
				return;
			}
			foreach (TInputAxis tinputAxis in hashSet)
			{
				tinputAxis(value, axisName);
			}
		}

		// Token: 0x0602EB10 RID: 191248 RVA: 0x00B1016C File Offset: 0x00B0E36C
		[NullableContext(0)]
		private void OnTouchActionCallback(bool isPress, TEnumAsByte<ETouchIndex> touchIndex, FVector position)
		{
			TTouchAction touchAction = this.TouchAction;
			if (touchAction == null)
			{
				return;
			}
			touchAction(isPress, (int)touchIndex, position);
		}

		// Token: 0x0602EB11 RID: 191249 RVA: 0x00B10186 File Offset: 0x00B0E386
		[NullableContext(0)]
		private void OnTouchMovedActionCallback(TEnumAsByte<ETouchIndex> touchIndex, FVector position)
		{
			TTouchMovedAction touchMovedAction = this.TouchMovedAction;
			if (touchMovedAction == null)
			{
				return;
			}
			touchMovedAction((int)touchIndex, position);
		}

		// Token: 0x0602EB12 RID: 191250 RVA: 0x00B1019F File Offset: 0x00B0E39F
		private void InputChangeDelegate(CSharpScript.Launcher.InputDevice.EInputControllerType _, CSharpScript.Launcher.InputDevice.EInputControllerType __)
		{
			this.CurrentPanelConfig.RefreshTexture();
			this.PlayerController.bShowMouseCursor = Singleton<InputDevice>.Instance.IsInKeyBoard();
		}

		// Token: 0x0602EB13 RID: 191251 RVA: 0x00B101C4 File Offset: 0x00B0E3C4
		private void OnAnyKeyPress(FKey key)
		{
			if (Singleton<Platform>.Instance.IsMobilePlatform())
			{
				string text = key.KeyName.ToString();
				if (text != null && (text.Contains("Android") || text.Contains("OpenHarmony")))
				{
					return;
				}
			}
			if (UKismetInputLibrary.Key_IsGamepadKey(key))
			{
				Singleton<HotPatchEventSystem>.Instance.SwitchToNavigationInputType();
			}
			Singleton<InputDevice>.Instance.SwitchInputControllerTypeByKey(key);
			Action waitingAnyKeyPressCallBack = this.WaitingAnyKeyPressCallBack;
			if (waitingAnyKeyPressCallBack == null)
			{
				return;
			}
			waitingAnyKeyPressCallBack();
		}

		// Token: 0x0602EB14 RID: 191252 RVA: 0x00B10240 File Offset: 0x00B0E440
		public UniTask WaitAnyKeyPress()
		{
			UniTaskCompletionSource tcs = new UniTaskCompletionSource();
			this.WaitingAnyKeyPressCallBack = delegate()
			{
				this.WaitingAnyKeyPressCallBack = null;
				tcs.TrySetResult();
			};
			return tcs.Task;
		}

		// Token: 0x0602EB15 RID: 191253 RVA: 0x00B10284 File Offset: 0x00B0E484
		public UniTask Init(UObject worldContext)
		{
			HotPatchInputManager.<Init>d__30 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.worldContext = worldContext;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<HotPatchInputManager.<Init>d__30>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0602EB16 RID: 191254 RVA: 0x00B102D0 File Offset: 0x00B0E4D0
		public void RegisterInputAction(string actionName, TInputAction inputActionFunc)
		{
			HashSet<TInputAction> hashSet;
			if (!this.InputActionMap.TryGetValue(actionName, out hashSet))
			{
				hashSet = new HashSet<TInputAction>();
				this.InputActionMap[actionName] = hashSet;
			}
			hashSet.Add(inputActionFunc);
		}

		// Token: 0x0602EB17 RID: 191255 RVA: 0x00B10308 File Offset: 0x00B0E508
		public void UnRegisterInputAction(string actionName, TInputAction inputActionFunc)
		{
			HashSet<TInputAction> hashSet;
			if (!this.InputActionMap.TryGetValue(actionName, out hashSet))
			{
				return;
			}
			if (hashSet.Remove(inputActionFunc) && hashSet.Count == 0)
			{
				this.InputActionMap.Remove(actionName);
			}
		}

		// Token: 0x0602EB18 RID: 191256 RVA: 0x00B10344 File Offset: 0x00B0E544
		public void RegisterInputAxis(string axisName, TInputAxis inputAxisFunc)
		{
			HashSet<TInputAxis> hashSet;
			if (!this.InputAxisMap.TryGetValue(axisName, out hashSet))
			{
				hashSet = new HashSet<TInputAxis>();
				this.InputAxisMap[axisName] = hashSet;
			}
			hashSet.Add(inputAxisFunc);
		}

		// Token: 0x0602EB19 RID: 191257 RVA: 0x00B1037C File Offset: 0x00B0E57C
		public void UnRegisterInputAxis(string axisName, TInputAxis inputAxisFunc)
		{
			HashSet<TInputAxis> hashSet;
			if (!this.InputAxisMap.TryGetValue(axisName, out hashSet))
			{
				return;
			}
			if (hashSet.Remove(inputAxisFunc) && hashSet.Count == 0)
			{
				this.InputAxisMap.Remove(axisName);
			}
		}

		// Token: 0x0602EB1A RID: 191258 RVA: 0x00B103B8 File Offset: 0x00B0E5B8
		public void RegisterOnTouchAction(TTouchAction touchAction)
		{
			this.TouchAction = touchAction;
		}

		// Token: 0x0602EB1B RID: 191259 RVA: 0x00B103C1 File Offset: 0x00B0E5C1
		public void UnRegisterOnTouchAction()
		{
			this.TouchAction = null;
		}

		// Token: 0x0602EB1C RID: 191260 RVA: 0x00B103CA File Offset: 0x00B0E5CA
		public void RegisterOnTouchMovedAction(TTouchMovedAction touchMovedAction)
		{
			this.TouchMovedAction = touchMovedAction;
		}

		// Token: 0x0602EB1D RID: 191261 RVA: 0x00B103D3 File Offset: 0x00B0E5D3
		public void UnRegisterOnTouchMovedAction()
		{
			this.TouchMovedAction = null;
		}

		// Token: 0x0602EB1E RID: 191262 RVA: 0x00B103DC File Offset: 0x00B0E5DC
		public void Destroy()
		{
			Singleton<InputDevice>.Instance.UnRegisterInputChangeDelegate(new Action<CSharpScript.Launcher.InputDevice.EInputControllerType, CSharpScript.Launcher.InputDevice.EInputControllerType>(this.InputChangeDelegate));
			this.UnRegisterAllInputSetting();
			this.ClearTypeCache();
			this.ClearTexture();
			foreach (TsHotFixActionHandle_C tsHotFixActionHandle_C in this.ActionHandleMap.Values)
			{
				tsHotFixActionHandle_C.ClearActionBinding(this.PlayerController);
				tsHotFixActionHandle_C.OnPressActionCallback.Clear();
			}
			this.ActionHandleMap.Clear();
			foreach (TsHotFixActionHandle_C tsHotFixActionHandle_C2 in this.AxisHandleMap.Values)
			{
				tsHotFixActionHandle_C2.ClearAxisBinding(this.PlayerController);
				tsHotFixActionHandle_C2.OnAxisCallback.Clear();
			}
			this.AxisHandleMap.Clear();
			if (this.TouchHandle != null)
			{
				this.TouchHandle.OnTouchActionCallback.Clear();
				this.TouchHandle.OnTouchMovedActionCallback.Clear();
				this.TouchHandle = null;
			}
			if (this.AnyKeyHandle != null)
			{
				this.AnyKeyHandle.ClearKeyBinding(this.PlayerController);
				this.AnyKeyHandle = null;
			}
			this.WorldContext = null;
			this.PlayerController = null;
		}

		// Token: 0x0602EB1F RID: 191263 RVA: 0x00B10534 File Offset: 0x00B0E734
		private UniTask InitHotPatchPanelConfigType()
		{
			HotPatchInputManager.<InitHotPatchPanelConfigType>d__43 <InitHotPatchPanelConfigType>d__;
			<InitHotPatchPanelConfigType>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitHotPatchPanelConfigType>d__.<>4__this = this;
			<InitHotPatchPanelConfigType>d__.<>1__state = -1;
			<InitHotPatchPanelConfigType>d__.<>t__builder.Start<HotPatchInputManager.<InitHotPatchPanelConfigType>d__43>(ref <InitHotPatchPanelConfigType>d__);
			return <InitHotPatchPanelConfigType>d__.<>t__builder.Task;
		}

		// Token: 0x0602EB20 RID: 191264 RVA: 0x00B10577 File Offset: 0x00B0E777
		private void ClearTypeCache()
		{
			this.TypeCache.Clear();
		}

		// Token: 0x0602EB21 RID: 191265 RVA: 0x00B10584 File Offset: 0x00B0E784
		public void InsertPanelConfig(TsHotPatchPanelConfig panelConfig)
		{
			TsHotPatchPanelConfig currentPanelConfig = this.CurrentPanelConfig;
			if (currentPanelConfig != null)
			{
				currentPanelConfig.HideTexture();
			}
			TsHotPatchPanelConfig currentPanelConfig2 = this.CurrentPanelConfig;
			if (currentPanelConfig2 != null)
			{
				currentPanelConfig2.UnRegisterActionAndAxis();
			}
			this.PanelConfigList.Add(panelConfig);
			this.CurrentPanelConfig = panelConfig;
			panelConfig.RefreshTexture();
			panelConfig.RegisterActionAndAxis();
		}

		// Token: 0x0602EB22 RID: 191266 RVA: 0x00B105D4 File Offset: 0x00B0E7D4
		public void RemovePanelConfig(TsHotPatchPanelConfig panelConfig)
		{
			panelConfig.HideTexture();
			panelConfig.UnRegisterActionAndAxis();
			int num = this.PanelConfigList.IndexOf(panelConfig);
			int count = this.PanelConfigList.Count;
			this.PanelConfigList.RemoveAt(num);
			if (num == count - 1 && this.PanelConfigList.Count > 0)
			{
				int count2 = this.PanelConfigList.Count;
				this.CurrentPanelConfig = this.PanelConfigList[count2 - 1];
				TsHotPatchPanelConfig currentPanelConfig = this.CurrentPanelConfig;
				if (currentPanelConfig != null)
				{
					currentPanelConfig.RefreshTexture();
				}
				TsHotPatchPanelConfig currentPanelConfig2 = this.CurrentPanelConfig;
				if (currentPanelConfig2 == null)
				{
					return;
				}
				currentPanelConfig2.RegisterActionAndAxis();
			}
		}

		// Token: 0x0602EB23 RID: 191267 RVA: 0x00B10668 File Offset: 0x00B0E868
		private UniTask LoadGamepadTexture()
		{
			HotPatchInputManager.<LoadGamepadTexture>d__49 <LoadGamepadTexture>d__;
			<LoadGamepadTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadGamepadTexture>d__.<>4__this = this;
			<LoadGamepadTexture>d__.<>1__state = -1;
			<LoadGamepadTexture>d__.<>t__builder.Start<HotPatchInputManager.<LoadGamepadTexture>d__49>(ref <LoadGamepadTexture>d__);
			return <LoadGamepadTexture>d__.<>t__builder.Task;
		}

		// Token: 0x0602EB24 RID: 191268 RVA: 0x00B106AC File Offset: 0x00B0E8AC
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<UTexture> LoadXboxTextureAsync(EGamepadKey key, string path)
		{
			UniTaskCompletionSource<UTexture> tcs = new UniTaskCompletionSource<UTexture>();
			Singleton<LauncherResourceLib>.Instance.LoadAsync<UTexture>(path, delegate([Nullable(2)] UTexture asset, string _)
			{
				tcs.TrySetResult(asset);
				if (asset != null)
				{
					this.XboxKeyAndTextureMap[key] = asset;
				}
			}, 0, "Launch.Ui");
			return tcs.Task;
		}

		// Token: 0x0602EB25 RID: 191269 RVA: 0x00B10704 File Offset: 0x00B0E904
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<UTexture> LoadPsTextureAsync(EGamepadKey key, string path)
		{
			UniTaskCompletionSource<UTexture> tcs = new UniTaskCompletionSource<UTexture>();
			Singleton<LauncherResourceLib>.Instance.LoadAsync<UTexture>(path, delegate([Nullable(2)] UTexture asset, string _)
			{
				tcs.TrySetResult(asset);
				if (asset != null)
				{
					this.PsKeyAndTextureMap[key] = asset;
				}
			}, 0, "Launch.Ui");
			return tcs.Task;
		}

		// Token: 0x0602EB26 RID: 191270 RVA: 0x00B10759 File Offset: 0x00B0E959
		private void ClearTexture()
		{
			this.XboxKeyAndTextureMap.Clear();
			this.PsKeyAndTextureMap.Clear();
		}

		// Token: 0x0602EB27 RID: 191271 RVA: 0x00B10774 File Offset: 0x00B0E974
		[return: Nullable(2)]
		public UTexture GetTextureByActionName(string actionName)
		{
			EGamepadKey key;
			if (!Singleton<HotPatchInputDefine>.Instance.gamepadActionInputMap.TryGetValue(actionName, out key))
			{
				return null;
			}
			if (Singleton<InputDevice>.Instance.IsPsGamepad())
			{
				UTexture result;
				if (this.PsKeyAndTextureMap.TryGetValue(key, out result))
				{
					return result;
				}
				return null;
			}
			else
			{
				UTexture result2;
				if (this.XboxKeyAndTextureMap.TryGetValue(key, out result2))
				{
					return result2;
				}
				return null;
			}
		}

		// Token: 0x0401A857 RID: 108631
		[Nullable(2)]
		private UObject WorldContext;

		// Token: 0x0401A858 RID: 108632
		[Nullable(2)]
		private APlayerController PlayerController;

		// Token: 0x0401A859 RID: 108633
		private readonly Dictionary<string, HashSet<TInputAction>> InputActionMap = new Dictionary<string, HashSet<TInputAction>>();

		// Token: 0x0401A85A RID: 108634
		private readonly Dictionary<string, HashSet<TInputAxis>> InputAxisMap = new Dictionary<string, HashSet<TInputAxis>>();

		// Token: 0x0401A85B RID: 108635
		private readonly Dictionary<string, TsHotFixActionHandle_C> ActionHandleMap = new Dictionary<string, TsHotFixActionHandle_C>();

		// Token: 0x0401A85C RID: 108636
		private readonly Dictionary<string, TsHotFixActionHandle_C> AxisHandleMap = new Dictionary<string, TsHotFixActionHandle_C>();

		// Token: 0x0401A85D RID: 108637
		[Nullable(2)]
		private TsHotFixActionHandle_C TouchHandle;

		// Token: 0x0401A85E RID: 108638
		[Nullable(2)]
		private TsHotFixActionHandle_C AnyKeyHandle;

		// Token: 0x0401A85F RID: 108639
		[Nullable(2)]
		private TTouchAction TouchAction;

		// Token: 0x0401A860 RID: 108640
		[Nullable(2)]
		private TTouchMovedAction TouchMovedAction;

		// Token: 0x0401A861 RID: 108641
		private readonly List<FInputActionKeyMapping> InputActionKeyMappings = new List<FInputActionKeyMapping>();

		// Token: 0x0401A862 RID: 108642
		private readonly List<FInputAxisKeyMapping> InputAxisKeyMappings = new List<FInputAxisKeyMapping>();

		// Token: 0x0401A863 RID: 108643
		[Nullable(2)]
		private Action WaitingAnyKeyPressCallBack;

		// Token: 0x0401A864 RID: 108644
		private readonly List<TsHotPatchPanelConfig> PanelConfigList = new List<TsHotPatchPanelConfig>();

		// Token: 0x0401A865 RID: 108645
		private TsHotPatchPanelConfig CurrentPanelConfig;

		// Token: 0x0401A866 RID: 108646
		private readonly Dictionary<string, UObject> TypeCache = new Dictionary<string, UObject>();

		// Token: 0x0401A867 RID: 108647
		private readonly Dictionary<EGamepadKey, UTexture> XboxKeyAndTextureMap = new Dictionary<EGamepadKey, UTexture>();

		// Token: 0x0401A868 RID: 108648
		private readonly Dictionary<EGamepadKey, UTexture> PsKeyAndTextureMap = new Dictionary<EGamepadKey, UTexture>();
	}
}
