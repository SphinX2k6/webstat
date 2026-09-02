using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Controller
{
	// Token: 0x02007058 RID: 28760
	[NullableContext(1)]
	[Nullable(0)]
	public class PlayerInputHandle
	{
		// Token: 0x06045A2F RID: 285231 RVA: 0x012324F0 File Offset: 0x012306F0
		public void Initialize()
		{
			this.CombinationActionHandle = new CombinationActionHandle();
			this.CombinationAxisHandle = new CombinationAxisHandle();
			if (Singleton<Info>.Instance.AxisInputOptimize)
			{
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursor));
			}
			Singleton<EventSystem>.Instance.Add(EEventName.MobileGamepadDisconnect, new Action(this.OnMobileGamepadDisconnect));
			Singleton<EventSystem>.Instance.Add(EEventName.DisableCustomInputData, new Action<string>(this.OnDisableCustomInputData));
			Singleton<EventSystem>.Instance.Add(EEventName.EnableCacheCustomInputData, new Action<string>(this.OnEnableCacheCustomInputData));
			Singleton<EventSystem>.Instance.Add(EEventName.EnableActionRecord, new Action<bool>(this.OnEnableActionRecord));
		}

		// Token: 0x06045A30 RID: 285232 RVA: 0x012325AC File Offset: 0x012307AC
		public void Clear()
		{
			CombinationActionHandle combinationActionHandle = this.CombinationActionHandle;
			if (combinationActionHandle != null)
			{
				combinationActionHandle.Clear();
			}
			this.CombinationActionHandle = null;
			CombinationAxisHandle combinationAxisHandle = this.CombinationAxisHandle;
			if (combinationAxisHandle != null)
			{
				combinationAxisHandle.Clear();
			}
			this.CombinationAxisHandle = null;
			this.AlwaysTickAxisValueMap.Clear();
			this.CustomKeyActionData.Clear();
			if (Singleton<Info>.Instance.AxisInputOptimize)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursor));
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.MobileGamepadDisconnect, new Action(this.OnMobileGamepadDisconnect));
			Singleton<EventSystem>.Instance.Remove(EEventName.DisableCustomInputData, new Action<string>(this.OnDisableCustomInputData));
			Singleton<EventSystem>.Instance.Remove(EEventName.EnableCacheCustomInputData, new Action<string>(this.OnEnableCacheCustomInputData));
			Singleton<EventSystem>.Instance.Remove(EEventName.EnableActionRecord, new Action<bool>(this.OnEnableActionRecord));
		}

		// Token: 0x06045A31 RID: 285233 RVA: 0x01232697 File Offset: 0x01230897
		private void OnShowMouseCursor(bool value)
		{
			if (this.LastShowMouseCursor != value)
			{
				this.LastShowMouseCursor = value;
				if (value)
				{
					this.LastFrameShowMouseCursor = true;
				}
			}
		}

		// Token: 0x06045A32 RID: 285234 RVA: 0x012326B4 File Offset: 0x012308B4
		private void OnMobileGamepadDisconnect()
		{
			Singleton<Log>.Instance.Info(ELogModule.MobileInputSwitch, ELogAuthor.XXJ, "手柄断开,清理输入缓存", default(ReadOnlySpan<ValueTuple<string, object>>));
			foreach (KeyValuePair<string, float> keyValuePair in this.AlwaysTickAxisValueMap)
			{
				ControllerBase<InputDistributeController>.Instance.InputAxis(keyValuePair.Key, 0f, false);
			}
			this.AlwaysTickAxisValueMap.Clear();
			foreach (KeyValuePair<string, float> keyValuePair2 in this.OptimizeTickAxisValueMap)
			{
				ControllerBase<InputDistributeController>.Instance.InputAxis(keyValuePair2.Key, 0f, false);
			}
			this.OptimizeTickAxisValueMap.Clear();
		}

		// Token: 0x06045A33 RID: 285235 RVA: 0x012327A0 File Offset: 0x012309A0
		public void Tick(float delta)
		{
			CombinationAxisHandle combinationAxisHandle = this.CombinationAxisHandle;
			if (combinationAxisHandle != null)
			{
				combinationAxisHandle.Tick(delta);
			}
			if (Singleton<Info>.Instance.AxisInputOptimize)
			{
				if (this.LastFrameShowMouseCursor)
				{
					this.LastFrameShowMouseCursor = false;
					foreach (KeyValuePair<string, float> keyValuePair in this.AlwaysTickAxisValueMap)
					{
						ControllerBase<InputDistributeController>.Instance.InputAxis(keyValuePair.Key, 0f, false);
					}
					using (Dictionary<string, float>.Enumerator enumerator = this.OptimizeTickAxisValueMap.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<string, float> keyValuePair2 = enumerator.Current;
							ControllerBase<InputDistributeController>.Instance.InputAxis(keyValuePair2.Key, 0f, false);
						}
						return;
					}
				}
				foreach (KeyValuePair<string, float> keyValuePair3 in this.AlwaysTickAxisValueMap)
				{
					ControllerBase<InputDistributeController>.Instance.InputAxis(keyValuePair3.Key, keyValuePair3.Value, false);
				}
				if (ModelBase<InputModel>.GetOrCreateInstance().LastClearAxisValue)
				{
					foreach (KeyValuePair<string, float> keyValuePair4 in this.OptimizeTickAxisValueMap)
					{
						ControllerBase<InputDistributeController>.Instance.InputAxis(keyValuePair4.Key, keyValuePair4.Value, true);
					}
					ModelBase<InputModel>.Instance.ResetLastTemporaryClearAxisValues();
				}
			}
		}

		// Token: 0x06045A34 RID: 285236 RVA: 0x0123294C File Offset: 0x01230B4C
		public void InputAction(string actionName, bool bPress, FKey key)
		{
			if (!this.CustomKeyActionData.IsActionEnable(actionName))
			{
				return;
			}
			string keyName = key.KeyName.ToString();
			if (!this.CanInputActionOnMobilePlatform(keyName))
			{
				return;
			}
			if (!this.IsInputActionSameAsInputType(keyName))
			{
				return;
			}
			if (this.IsRecording)
			{
				Singleton<EventSystem>.Instance.Emit<string, bool, FKey>(EEventName.CharInputAction, actionName, bPress, key);
			}
			if (!this.CheckCombinationAction(actionName) || this.IsKeyBlockedByCombination(keyName))
			{
				this.HandleInputActionInCombinationAction(actionName, bPress);
				return;
			}
			ControllerBase<InputDistributeController>.Instance.InputAction(actionName, bPress);
		}

		// Token: 0x06045A35 RID: 285237 RVA: 0x012329D4 File Offset: 0x01230BD4
		public void InputAxis(string axisName, float value, bool alwaysTick = false)
		{
			if (Singleton<Info>.Instance.IsMobileInputModel() && Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			CombinationAxisHandle combinationAxisHandle = this.CombinationAxisHandle;
			if (combinationAxisHandle == null || combinationAxisHandle.CheckCombinationAxis(axisName))
			{
				CombinationActionHandle combinationActionHandle = this.CombinationActionHandle;
				if ((combinationActionHandle == null || combinationActionHandle.CheckCombinationActionByAxisName(axisName)) && !this.IsAxisBlockedByCombination(axisName))
				{
					if (!Singleton<Info>.Instance.AxisInputOptimize)
					{
						ControllerBase<InputDistributeController>.Instance.InputAxis(axisName, value, false);
						return;
					}
					if (alwaysTick)
					{
						this.AlwaysTickAxisValueMap[axisName] = value;
						return;
					}
					this.OptimizeTickAxisValueMap[axisName] = value;
					ControllerBase<InputDistributeController>.Instance.InputAxis(axisName, value, false);
					return;
				}
			}
			this.HandleInputAxisInCombinationAxis(axisName, value, alwaysTick);
		}

		// Token: 0x06045A36 RID: 285238 RVA: 0x01232A7C File Offset: 0x01230C7C
		public void TouchBegin(ETouchIndex touchIndex, FVector position)
		{
			Vector touchPosition = this.SetTouchVector((int)touchIndex, position);
			InputDistributeDefine.TouchData touchData = new InputDistributeDefine.TouchData
			{
				TouchType = InputDistributeDefine.ETouchType.TouchBegin,
				TouchId = (int)touchIndex,
				TouchPosition = touchPosition
			};
			Singleton<TouchFingerManager>.Instance.StartTouch((EFingerIndex)touchIndex, position);
			Singleton<LguiEventSystemManager>.Instance.InputTouchTrigger(true, (int)touchIndex, position);
			ControllerBase<InputDistributeController>.Instance.InputTouch((int)touchIndex, touchData);
		}

		// Token: 0x06045A37 RID: 285239 RVA: 0x01232AD4 File Offset: 0x01230CD4
		public void TouchEnd(ETouchIndex touchIndex, FVector position)
		{
			Vector touchPosition = this.SetTouchVector((int)touchIndex, position);
			InputDistributeDefine.TouchData touchData = new InputDistributeDefine.TouchData
			{
				TouchType = InputDistributeDefine.ETouchType.TouchEnd,
				TouchId = (int)touchIndex,
				TouchPosition = touchPosition
			};
			Singleton<TouchFingerManager>.Instance.EndTouch((EFingerIndex)touchIndex);
			Singleton<LguiEventSystemManager>.Instance.InputTouchTrigger(false, (int)touchIndex, position);
			ControllerBase<InputDistributeController>.Instance.InputTouch((int)touchIndex, touchData);
		}

		// Token: 0x06045A38 RID: 285240 RVA: 0x01232B2C File Offset: 0x01230D2C
		public void TouchMove(ETouchIndex touchIndex, FVector position)
		{
			Vector touchPosition = this.SetTouchVector((int)touchIndex, position);
			InputDistributeDefine.TouchData touchData = new InputDistributeDefine.TouchData
			{
				TouchType = InputDistributeDefine.ETouchType.TouchMove,
				TouchId = (int)touchIndex,
				TouchPosition = touchPosition
			};
			Singleton<TouchFingerManager>.Instance.MoveTouch((EFingerIndex)touchIndex, position);
			Singleton<LguiEventSystemManager>.Instance.InputLguiTouchMove((int)touchIndex, position);
			ControllerBase<InputDistributeController>.Instance.InputTouch((int)touchIndex, touchData);
		}

		// Token: 0x06045A39 RID: 285241 RVA: 0x01232B84 File Offset: 0x01230D84
		public void PressAnyKey(FKey key)
		{
			if (Singleton<Info>.Instance.IsMobileInputModel() && Singleton<Info>.Instance.IsInTouch() && ModelBase<PlatformModel>.Instance.IsKeyFromGamepadKey(key.KeyName.ToString()))
			{
				return;
			}
			string text = key.KeyName.ToString();
			CombinationActionHandle combinationActionHandle = this.CombinationActionHandle;
			if (combinationActionHandle != null)
			{
				combinationActionHandle.PressAnyKey(text);
			}
			CombinationAxisHandle combinationAxisHandle = this.CombinationAxisHandle;
			if (combinationAxisHandle != null)
			{
				combinationAxisHandle.PressAnyKey(text);
			}
			this.TryInputCustomAction(text, true);
			if (this.IsPrintKeyName)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "按下按键";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("KeyName", text);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			ControllerBase<InputDistributeController>.Instance.InputKey(text, true);
			Singleton<EventSystem>.Instance.Emit<bool, FKey>(EEventName.OnInputAnyKey, true, key);
		}

		// Token: 0x06045A3A RID: 285242 RVA: 0x01232C58 File Offset: 0x01230E58
		public void ReleaseAnyKey(FKey key)
		{
			if (Singleton<Info>.Instance.IsMobileInputModel() && Singleton<Info>.Instance.IsInTouch() && ModelBase<PlatformModel>.Instance.IsKeyFromGamepadKey(key.KeyName.ToString()))
			{
				return;
			}
			string text = key.KeyName.ToString();
			CombinationActionHandle combinationActionHandle = this.CombinationActionHandle;
			if (combinationActionHandle != null)
			{
				combinationActionHandle.ReleaseAnyKey(text);
			}
			CombinationAxisHandle combinationAxisHandle = this.CombinationAxisHandle;
			if (combinationAxisHandle != null)
			{
				combinationAxisHandle.ReleaseAnyKey(text);
			}
			this.TryInputCustomAction(text, false);
			if (this.IsPrintKeyName)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "抬起按键";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("KeyName", text);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			ControllerBase<InputDistributeController>.Instance.InputKey(text, false);
			Singleton<EventSystem>.Instance.Emit<bool, FKey>(EEventName.OnInputAnyKey, false, key);
		}

		// Token: 0x06045A3B RID: 285243 RVA: 0x01232D2C File Offset: 0x01230F2C
		private void TryInputCustomAction(string keyName, bool bPress)
		{
			IReadOnlySet<string> customActionName = this.CustomKeyActionData.GetCustomActionName(keyName);
			if (customActionName == null)
			{
				return;
			}
			if (!this.CanInputActionOnMobilePlatform(keyName))
			{
				return;
			}
			if (!this.IsInputActionSameAsInputType(keyName))
			{
				return;
			}
			if (bPress && this.IsKeyBlockedByCombination(keyName))
			{
				return;
			}
			foreach (string actionName in customActionName)
			{
				if (!this.CheckCombinationAction(actionName) && bPress)
				{
					break;
				}
				ControllerBase<InputDistributeController>.Instance.InputAction(actionName, bPress);
			}
		}

		// Token: 0x06045A3C RID: 285244 RVA: 0x01232DBC File Offset: 0x01230FBC
		private void OnDisableCustomInputData(string reason)
		{
			this.CustomKeyActionData.DisableCustomInputData(reason);
		}

		// Token: 0x06045A3D RID: 285245 RVA: 0x01232DCA File Offset: 0x01230FCA
		private void OnEnableCacheCustomInputData(string reason)
		{
			this.CustomKeyActionData.EnableCustomInputData(reason);
		}

		// Token: 0x06045A3E RID: 285246 RVA: 0x01232DD8 File Offset: 0x01230FD8
		private void OnEnableActionRecord(bool isRecording)
		{
			this.IsRecording = isRecording;
		}

		// Token: 0x06045A3F RID: 285247 RVA: 0x01232DE4 File Offset: 0x01230FE4
		private bool CanInputActionOnMobilePlatform(string keyName)
		{
			if (Singleton<Info>.Instance.IsMobileInputModel())
			{
				if (Singleton<InputSettings>.Instance.IsKeyboardKey(keyName) || Singleton<InputSettings>.Instance.IsMouseButton(keyName))
				{
					return false;
				}
				if (Singleton<Info>.Instance.IsInTouch() && ModelBase<PlatformModel>.Instance.IsKeyFromGamepadKey(keyName))
				{
					return false;
				}
				if (Singleton<Info>.Instance.IsInGamepad() && !ModelBase<PlatformModel>.Instance.IsKeyFromGamepadKey(keyName))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06045A40 RID: 285248 RVA: 0x01232E50 File Offset: 0x01231050
		private bool CheckCombinationAction(string actionName)
		{
			CombinationActionHandle combinationActionHandle = this.CombinationActionHandle;
			return combinationActionHandle == null || combinationActionHandle.CheckCombinationAction(actionName);
		}

		// Token: 0x06045A41 RID: 285249 RVA: 0x01232E64 File Offset: 0x01231064
		private bool IsKeyBlockedByCombination(string keyName)
		{
			return this.CombinationActionHandle.GetBlockInputKeySet().Contains(keyName) || this.CombinationAxisHandle.GetBlockInputKeySet().Contains(keyName);
		}

		// Token: 0x06045A42 RID: 285250 RVA: 0x01232E8C File Offset: 0x0123108C
		private bool IsAxisBlockedByCombination(string axisName)
		{
			IReadOnlySet<string> blockInputKeySet = this.CombinationActionHandle.GetBlockInputKeySet();
			IReadOnlySet<string> blockInputKeySet2 = this.CombinationAxisHandle.GetBlockInputKeySet();
			if (blockInputKeySet.Count <= 0 && blockInputKeySet2.Count <= 0)
			{
				return false;
			}
			InputAxisBinding axisBinding = Singleton<InputSettingsManager>.Instance.GetAxisBinding(axisName);
			if (axisBinding == null)
			{
				return false;
			}
			this.BlockCheckKeyNameList.Clear();
			axisBinding.GetKeyNameList(this.BlockCheckKeyNameList);
			foreach (string item in this.BlockCheckKeyNameList)
			{
				if (blockInputKeySet.Contains(item) || blockInputKeySet2.Contains(item))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06045A43 RID: 285251 RVA: 0x01232F4C File Offset: 0x0123114C
		private void HandleInputActionInCombinationAction(string actionName, bool bPress)
		{
			if (!bPress && ModelBase<InputDistributeModel>.Instance.IsActionInPress(actionName))
			{
				ControllerBase<InputDistributeController>.Instance.InputAction(actionName, false);
			}
		}

		// Token: 0x06045A44 RID: 285252 RVA: 0x01232F6C File Offset: 0x0123116C
		private void HandleInputAxisInCombinationAxis(string axisName, float value, bool alwaysTick)
		{
			if (value != 0f)
			{
				if (!ModelBase<InputDistributeModel>.Instance.IsAxisInPress(axisName))
				{
					return;
				}
				if (Singleton<Info>.Instance.AxisInputOptimize)
				{
					if (alwaysTick)
					{
						this.AlwaysTickAxisValueMap[axisName] = 0f;
						return;
					}
					this.OptimizeTickAxisValueMap[axisName] = 0f;
					ControllerBase<InputDistributeController>.Instance.InputAxis(axisName, 0f, false);
					return;
				}
				else
				{
					ControllerBase<InputDistributeController>.Instance.InputAxis(axisName, 0f, false);
				}
			}
		}

		// Token: 0x06045A45 RID: 285253 RVA: 0x01232FE4 File Offset: 0x012311E4
		[NullableContext(2)]
		private Vector GetTouchVector(int touchId)
		{
			Vector result;
			if (!this.TouchVectorMap.TryGetValue(touchId, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x06045A46 RID: 285254 RVA: 0x01233004 File Offset: 0x01231204
		private Vector SetTouchVector(int touchId, FVector ueVector)
		{
			Vector touchVector = this.GetTouchVector(touchId);
			if (touchVector != null)
			{
				touchVector.Set((double)ueVector.X, (double)ueVector.Y, (double)ueVector.Z);
				return touchVector;
			}
			return this.NewTouchVector(touchId, ueVector);
		}

		// Token: 0x06045A47 RID: 285255 RVA: 0x01233044 File Offset: 0x01231244
		private Vector NewTouchVector(int touchId, FVector ueVector)
		{
			Vector vector = Vector.Create(ueVector);
			this.TouchVectorMap[touchId] = vector;
			return vector;
		}

		// Token: 0x06045A48 RID: 285256 RVA: 0x0123306C File Offset: 0x0123126C
		private bool IsInputActionSameAsInputType(string keyName)
		{
			return Singleton<Info>.Instance.IsGmLockGamepad || ((!Singleton<Info>.Instance.IsInGamepad() || !Singleton<InputSettings>.Instance.IsKeyboardKey(keyName)) && (!Singleton<Info>.Instance.IsInKeyBoard() || !Singleton<InputSettings>.Instance.IsGamepadKey(keyName)));
		}

		// Token: 0x06045A49 RID: 285257 RVA: 0x012330BE File Offset: 0x012312BE
		public void SetCustomAction(string keyName, string actionName)
		{
			this.CustomKeyActionData.SetCustomAction(keyName, actionName);
		}

		// Token: 0x06045A4A RID: 285258 RVA: 0x012330CD File Offset: 0x012312CD
		public void ResetAllCustomAction(string keyName)
		{
			this.TryInputCustomAction(keyName, false);
			this.CustomKeyActionData.ResetAllCustomAction(keyName);
		}

		// Token: 0x06045A4B RID: 285259 RVA: 0x012330E3 File Offset: 0x012312E3
		public void ResetCustomAction(string keyName, string actionName)
		{
			this.CustomKeyActionData.ResetCustomAction(keyName, actionName);
		}

		// Token: 0x06045A4C RID: 285260 RVA: 0x012330F2 File Offset: 0x012312F2
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> GetCurrentPlatformCustomActionKeyNameList(string actionName)
		{
			return this.CustomKeyActionData.GetCurrentPlatformCustomActionKeyNameList(actionName);
		}

		// Token: 0x06045A4D RID: 285261 RVA: 0x01233100 File Offset: 0x01231300
		public void SetActionEnable(string actionName, bool bEnable)
		{
			this.CustomKeyActionData.SetActionEnable(actionName, bEnable);
		}

		// Token: 0x04026DFF RID: 159231
		private readonly Dictionary<int, Vector> TouchVectorMap = new Dictionary<int, Vector>();

		// Token: 0x04026E00 RID: 159232
		public bool IsPrintKeyName;

		// Token: 0x04026E01 RID: 159233
		public bool IsRecording;

		// Token: 0x04026E02 RID: 159234
		[Nullable(2)]
		private CombinationActionHandle CombinationActionHandle;

		// Token: 0x04026E03 RID: 159235
		[Nullable(2)]
		private CombinationAxisHandle CombinationAxisHandle;

		// Token: 0x04026E04 RID: 159236
		private readonly Dictionary<string, float> AlwaysTickAxisValueMap = new Dictionary<string, float>();

		// Token: 0x04026E05 RID: 159237
		private readonly Dictionary<string, float> OptimizeTickAxisValueMap = new Dictionary<string, float>();

		// Token: 0x04026E06 RID: 159238
		private readonly CustomKeyActionData CustomKeyActionData = new CustomKeyActionData();

		// Token: 0x04026E07 RID: 159239
		private bool LastShowMouseCursor;

		// Token: 0x04026E08 RID: 159240
		private bool LastFrameShowMouseCursor;

		// Token: 0x04026E09 RID: 159241
		private readonly List<string> BlockCheckKeyNameList = new List<string>();
	}
}
