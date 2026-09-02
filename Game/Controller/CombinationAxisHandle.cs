using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Controller
{
	// Token: 0x02007056 RID: 28758
	[NullableContext(1)]
	[Nullable(0)]
	public class CombinationAxisHandle
	{
		// Token: 0x06045A19 RID: 285209 RVA: 0x01231C27 File Offset: 0x0122FE27
		public void Clear()
		{
			this.PressCombinationAxisBindingMap = null;
			this.BlockInputKeySet.Clear();
		}

		// Token: 0x06045A1A RID: 285210 RVA: 0x01231C3B File Offset: 0x0122FE3B
		public IReadOnlySet<string> GetBlockInputKeySet()
		{
			return this.BlockInputKeySet;
		}

		// Token: 0x06045A1B RID: 285211 RVA: 0x01231C44 File Offset: 0x0122FE44
		public void PressAnyKey(string keyName)
		{
			if (this.PressMainKeyName != null)
			{
				if (this.PressOtherKeySet.Count > 0)
				{
					this.PressOtherKeySet.Add(keyName);
				}
				return;
			}
			if (Singleton<InputSettingsManager>.Instance.IsCombinationAxisMainKey(keyName))
			{
				this.PressMainKey(keyName);
				return;
			}
			this.PressOtherKeySet.Add(keyName);
		}

		// Token: 0x06045A1C RID: 285212 RVA: 0x01231C97 File Offset: 0x0122FE97
		public void ReleaseAnyKey(string keyName)
		{
			if (this.PressMainKeyName == keyName)
			{
				this.ReleaseMainKey();
				return;
			}
			this.PressOtherKeySet.Remove(keyName);
		}

		// Token: 0x06045A1D RID: 285213 RVA: 0x01231CBC File Offset: 0x0122FEBC
		private void PressMainKey(string keyName)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[Input]按下组合Axis主键";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MainKeyName", keyName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.PressMainKeyName = keyName;
			this.PressMainKeyTimeStamp = (long)Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			this.PressCombinationAxisBindingMap = Singleton<InputSettingsManager>.Instance.GetCombinationAxisBindingMapByMainKeyName(keyName);
		}

		// Token: 0x06045A1E RID: 285214 RVA: 0x01231D1C File Offset: 0x0122FF1C
		private void ReleaseMainKey()
		{
			if (this.PressCombinationAxisBindingMap == null)
			{
				return;
			}
			foreach (List<InputCombinationAxisBinding> list in this.PressCombinationAxisBindingMap.Values)
			{
				foreach (InputCombinationAxisBinding inputCombinationAxisBinding in list)
				{
					string axisName = inputCombinationAxisBinding.GetAxisName();
					ControllerBase<InputDistributeController>.Instance.InputAxis(axisName, 0f, false);
				}
			}
			this.PressCombinationAxisBindingMap = null;
			this.PressMainKeyName = null;
			this.PressMainKeyTimeStamp = 0L;
			this.BlockInputKeySet.Clear();
		}

		// Token: 0x06045A1F RID: 285215 RVA: 0x01231DDC File Offset: 0x0122FFDC
		public void Tick(float delta)
		{
			this.BlockInputKeySet.Clear();
			if (this.PressOtherKeySet.Count > 0)
			{
				this.InCombinationAxis = false;
				return;
			}
			if (this.PressCombinationAxisBindingMap == null)
			{
				this.InCombinationAxis = false;
				return;
			}
			if (this.PressCombinationAxisBindingMap.Count <= 0)
			{
				this.InCombinationAxis = false;
				return;
			}
			bool inCombinationAxis = false;
			TsCharacterController characterController = Global.CharacterController;
			if (Singleton<Info>.Instance.AxisInputOptimize)
			{
				this.FrameAxisNameSet.Clear();
				using (IEnumerator<KeyValuePair<string, List<InputCombinationAxisBinding>>> enumerator = this.PressCombinationAxisBindingMap.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<string, List<InputCombinationAxisBinding>> keyValuePair = enumerator.Current;
						string key = keyValuePair.Key;
						FKey ueKey = Singleton<InputSettings>.Instance.GetUeKey(key);
						float inputAnalogKeyState = characterController.GetInputAnalogKeyState(ueKey);
						foreach (InputCombinationAxisBinding inputCombinationAxisBinding in keyValuePair.Value)
						{
							string axisName = inputCombinationAxisBinding.GetAxisName();
							if (!string.IsNullOrEmpty(axisName) && !this.FrameAxisNameSet.Contains(axisName))
							{
								if (inputAnalogKeyState != 0f)
								{
									this.FrameAxisNameSet.Add(axisName);
								}
								float value = inputAnalogKeyState * inputCombinationAxisBinding.GetSourceAxisValue(key).Value;
								this.TryAddBlockInputKeys(inputCombinationAxisBinding, axisName);
								if (Math.Abs(value) > 0.02f)
								{
									inCombinationAxis = true;
								}
								ControllerBase<InputDistributeController>.Instance.InputAxis(axisName, value, false);
							}
						}
					}
					goto IL_238;
				}
			}
			foreach (KeyValuePair<string, List<InputCombinationAxisBinding>> keyValuePair2 in this.PressCombinationAxisBindingMap)
			{
				string key2 = keyValuePair2.Key;
				FKey ueKey2 = Singleton<InputSettings>.Instance.GetUeKey(key2);
				float inputAnalogKeyState2 = characterController.GetInputAnalogKeyState(ueKey2);
				foreach (InputCombinationAxisBinding inputCombinationAxisBinding2 in keyValuePair2.Value)
				{
					string axisName2 = inputCombinationAxisBinding2.GetAxisName();
					float value2 = inputAnalogKeyState2 * inputCombinationAxisBinding2.GetSourceAxisValue(key2).Value;
					this.TryAddBlockInputKeys(inputCombinationAxisBinding2, axisName2);
					if (Math.Abs(value2) > 0.02f)
					{
						inCombinationAxis = true;
					}
					ControllerBase<InputDistributeController>.Instance.InputAxis(axisName2, value2, false);
				}
			}
			IL_238:
			this.InCombinationAxis = inCombinationAxis;
		}

		// Token: 0x06045A20 RID: 285216 RVA: 0x0123205C File Offset: 0x0123025C
		private void TryAddBlockInputKeys(InputCombinationAxisBinding combinationAxisBinding, [Nullable(2)] string axisName)
		{
			if (string.IsNullOrEmpty(axisName) || !ControllerBase<InputDistributeController>.Instance.IsAxisRespondable(axisName))
			{
				return;
			}
			foreach (string item in combinationAxisBinding.GetBlockInputKeySet())
			{
				this.BlockInputKeySet.Add(item);
			}
		}

		// Token: 0x06045A21 RID: 285217 RVA: 0x012320C8 File Offset: 0x012302C8
		public bool CheckCombinationAxis(string axisName)
		{
			if (this.PressMainKeyName == null)
			{
				return true;
			}
			if (!this.InCombinationAxis)
			{
				return true;
			}
			InputAxisBinding axisBinding = Singleton<InputSettingsManager>.Instance.GetAxisBinding(axisName);
			if (axisBinding == null)
			{
				return true;
			}
			List<string> list = new List<string>();
			axisBinding.GetKeyNameList(list);
			foreach (string secondaryKeyName in list)
			{
				if (Singleton<InputSettingsManager>.Instance.IsCombinationAxis(this.PressMainKeyName, secondaryKeyName) && this.IsCombinationAxisOutputBound(this.PressMainKeyName, secondaryKeyName))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06045A22 RID: 285218 RVA: 0x0123216C File Offset: 0x0123036C
		private bool IsCombinationAxisOutputBound(string mainKeyName, string secondaryKeyName)
		{
			IReadOnlyList<InputCombinationAxisBinding> combinationAxisBindingByKeyName = Singleton<InputSettingsManager>.Instance.GetCombinationAxisBindingByKeyName(mainKeyName, secondaryKeyName);
			if (combinationAxisBindingByKeyName == null)
			{
				return false;
			}
			foreach (InputCombinationAxisBinding inputCombinationAxisBinding in combinationAxisBindingByKeyName)
			{
				string axisName = inputCombinationAxisBinding.GetAxisName();
				if (!string.IsNullOrEmpty(axisName) && ControllerBase<InputDistributeController>.Instance.HasAxisBind(axisName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04026DF5 RID: 159221
		[Nullable(2)]
		private string PressMainKeyName;

		// Token: 0x04026DF6 RID: 159222
		public long PressMainKeyTimeStamp;

		// Token: 0x04026DF7 RID: 159223
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private IReadOnlyDictionary<string, List<InputCombinationAxisBinding>> PressCombinationAxisBindingMap;

		// Token: 0x04026DF8 RID: 159224
		private readonly HashSet<string> PressOtherKeySet = new HashSet<string>();

		// Token: 0x04026DF9 RID: 159225
		public bool InCombinationAxis;

		// Token: 0x04026DFA RID: 159226
		private readonly HashSet<string> BlockInputKeySet = new HashSet<string>();

		// Token: 0x04026DFB RID: 159227
		private readonly HashSet<string> FrameAxisNameSet = new HashSet<string>();
	}
}
