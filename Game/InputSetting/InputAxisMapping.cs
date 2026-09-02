using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007005 RID: 28677
	[NullableContext(1)]
	[Nullable(0)]
	public class InputAxisMapping
	{
		// Token: 0x060456B2 RID: 284338 RVA: 0x01226450 File Offset: 0x01224650
		public void Initialize()
		{
			IReadOnlyList<AxisMapping> allAxisMappingConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllAxisMappingConfig();
			if (allAxisMappingConfig == null)
			{
				return;
			}
			for (int i = 0; i < allAxisMappingConfig.Count; i++)
			{
				AxisMapping config = allAxisMappingConfig[i];
				this.NewAxisBinding(config);
			}
		}

		// Token: 0x060456B3 RID: 284339 RVA: 0x0122648C File Offset: 0x0122468C
		public void Clear()
		{
			foreach (InputAxisBinding inputAxisBinding in this.AxisBindingMap.Values)
			{
				inputAxisBinding.Clear();
			}
			this.AxisBindingMap.Clear();
			this.AxisBindingTypeMapping.Clear();
		}

		// Token: 0x060456B4 RID: 284340 RVA: 0x012264F8 File Offset: 0x012246F8
		public void NewAxisBinding(AxisMapping config)
		{
			string axisName = config.AxisName;
			InputAxisBinding inputAxisBinding = new InputAxisBinding();
			inputAxisBinding.Initialize(config);
			this.AxisBindingMap[axisName] = inputAxisBinding;
			EAxisMappingType axisMappingType = inputAxisBinding.GetAxisMappingType();
			HashSet<InputAxisBinding> hashSet;
			if (!this.AxisBindingTypeMapping.TryGetValue(axisMappingType, out hashSet))
			{
				hashSet = new HashSet<InputAxisBinding>();
				this.AxisBindingTypeMapping[axisMappingType] = hashSet;
			}
			hashSet.Add(inputAxisBinding);
		}

		// Token: 0x060456B5 RID: 284341 RVA: 0x0122655C File Offset: 0x0122475C
		public void RemoveAxisBinding(string axisName)
		{
			InputAxisBinding inputAxisBinding;
			if (!this.AxisBindingMap.TryGetValue(axisName, out inputAxisBinding))
			{
				return;
			}
			EAxisMappingType axisMappingType = inputAxisBinding.GetAxisMappingType();
			HashSet<InputAxisBinding> hashSet;
			if (this.AxisBindingTypeMapping.TryGetValue(axisMappingType, out hashSet))
			{
				hashSet.Remove(inputAxisBinding);
			}
			this.AxisBindingMap.Remove(axisName);
			inputAxisBinding.Clear();
		}

		// Token: 0x060456B6 RID: 284342 RVA: 0x012265AC File Offset: 0x012247AC
		public void ClearAllAxisKeys()
		{
			foreach (InputAxisBinding inputAxisBinding in this.AxisBindingMap.Values)
			{
				inputAxisBinding.ClearAllKeys();
			}
		}

		// Token: 0x060456B7 RID: 284343 RVA: 0x01226604 File Offset: 0x01224804
		[return: Nullable(2)]
		public InputAxisBinding GetAxisBinding(string actionName)
		{
			InputAxisBinding result;
			if (this.AxisBindingMap.TryGetValue(actionName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060456B8 RID: 284344 RVA: 0x01226624 File Offset: 0x01224824
		public Dictionary<string, InputAxisBinding> GetAxisBindingMap()
		{
			return this.AxisBindingMap;
		}

		// Token: 0x060456B9 RID: 284345 RVA: 0x0122662C File Offset: 0x0122482C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<InputAxisBinding> GetAxisBindingByAxisMappingType(EAxisMappingType axisMappingType)
		{
			HashSet<InputAxisBinding> result;
			if (this.AxisBindingTypeMapping.TryGetValue(axisMappingType, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060456BA RID: 284346 RVA: 0x0122664C File Offset: 0x0122484C
		public void SetKeys(string axisName, Dictionary<string, float> keyScaleMap, EInputBindingType bindingType)
		{
			InputAxisBinding inputAxisBinding;
			if (!this.AxisBindingMap.TryGetValue(axisName, out inputAxisBinding))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "设置Axis按键时，找不到对应Axis";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AxisName", axisName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputAxisBinding.SetKeys(keyScaleMap, bindingType);
			Singleton<EventSystem>.Instance.Emit<string, InputAxisBinding>(EEventName.OnChangedAxisKeys, axisName, inputAxisBinding);
		}

		// Token: 0x060456BB RID: 284347 RVA: 0x012266AC File Offset: 0x012248AC
		public void RefreshKeys(string axisName, TArray<FInputAxisKeyMapping> axisMappings, EInputBindingType bindingType)
		{
			InputAxisBinding inputAxisBinding;
			if (!this.AxisBindingMap.TryGetValue(axisName, out inputAxisBinding))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "设置Axis按键时，找不到对应Axis";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AxisName", axisName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputAxisBinding.RefreshKeys(axisMappings, bindingType);
			Singleton<EventSystem>.Instance.Emit<string, InputAxisBinding>(EEventName.OnChangedAxisKeys, axisName, inputAxisBinding);
		}

		// Token: 0x060456BC RID: 284348 RVA: 0x0122670C File Offset: 0x0122490C
		public void SwitchKeysByBindingType(EInputBindingType bindingType)
		{
			foreach (InputAxisBinding inputAxisBinding in this.AxisBindingMap.Values)
			{
				inputAxisBinding.SwitchKeysByBindingType(bindingType);
			}
		}

		// Token: 0x04026CD4 RID: 158932
		private readonly Dictionary<string, InputAxisBinding> AxisBindingMap = new Dictionary<string, InputAxisBinding>();

		// Token: 0x04026CD5 RID: 158933
		private readonly Dictionary<EAxisMappingType, HashSet<InputAxisBinding>> AxisBindingTypeMapping = new Dictionary<EAxisMappingType, HashSet<InputAxisBinding>>();
	}
}
