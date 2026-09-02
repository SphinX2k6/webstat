using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007004 RID: 28676
	[NullableContext(1)]
	[Nullable(0)]
	public class InputActionMapping
	{
		// Token: 0x060456A5 RID: 284325 RVA: 0x012260BC File Offset: 0x012242BC
		public void Initialize()
		{
			IReadOnlyList<ActionMapping> allActionMappingConfig = ConfigBase<InputSettingsConfig>.Instance.GetAllActionMappingConfig();
			if (allActionMappingConfig == null)
			{
				return;
			}
			for (int i = 0; i < allActionMappingConfig.Count; i++)
			{
				ActionMapping config = allActionMappingConfig[i];
				this.NewActionBinding(config);
			}
		}

		// Token: 0x060456A6 RID: 284326 RVA: 0x012260F8 File Offset: 0x012242F8
		public void Clear()
		{
			foreach (InputActionBinding inputActionBinding in this.ActionBindingMap.Values)
			{
				inputActionBinding.Clear();
			}
			this.ActionBindingMap.Clear();
			this.ActionBindingIdMapping.Clear();
			this.ActionBindingTypeMapping.Clear();
		}

		// Token: 0x060456A7 RID: 284327 RVA: 0x01226170 File Offset: 0x01224370
		public void NewActionBinding(ActionMapping config)
		{
			string actionName = config.ActionName;
			InputActionBinding inputActionBinding = new InputActionBinding();
			inputActionBinding.Initialize(config);
			int configId = inputActionBinding.GetConfigId();
			this.ActionBindingMap[actionName] = inputActionBinding;
			this.ActionBindingIdMapping[configId] = inputActionBinding;
			EActionMappingType actionMappingType = inputActionBinding.GetActionMappingType();
			HashSet<InputActionBinding> hashSet;
			if (!this.ActionBindingTypeMapping.TryGetValue(actionMappingType, out hashSet))
			{
				hashSet = new HashSet<InputActionBinding>();
				this.ActionBindingTypeMapping[actionMappingType] = hashSet;
			}
			hashSet.Add(inputActionBinding);
		}

		// Token: 0x060456A8 RID: 284328 RVA: 0x012261E8 File Offset: 0x012243E8
		public void RemoveActionBinding(string actionName)
		{
			InputActionBinding inputActionBinding;
			if (!this.ActionBindingMap.TryGetValue(actionName, out inputActionBinding))
			{
				return;
			}
			int configId = inputActionBinding.GetConfigId();
			EActionMappingType actionMappingType = inputActionBinding.GetActionMappingType();
			HashSet<InputActionBinding> hashSet;
			if (this.ActionBindingTypeMapping.TryGetValue(actionMappingType, out hashSet))
			{
				hashSet.Remove(inputActionBinding);
			}
			this.ActionBindingMap.Remove(actionName);
			this.ActionBindingIdMapping.Remove(configId);
			inputActionBinding.Clear();
		}

		// Token: 0x060456A9 RID: 284329 RVA: 0x0122624C File Offset: 0x0122444C
		public void ClearAllActionKeys()
		{
			foreach (InputActionBinding inputActionBinding in this.ActionBindingMap.Values)
			{
				inputActionBinding.ClearAllKeys();
			}
		}

		// Token: 0x060456AA RID: 284330 RVA: 0x012262A4 File Offset: 0x012244A4
		[return: Nullable(2)]
		public InputActionBinding GetActionBinding(string actionName)
		{
			InputActionBinding result;
			if (this.ActionBindingMap.TryGetValue(actionName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060456AB RID: 284331 RVA: 0x012262C4 File Offset: 0x012244C4
		public Dictionary<string, InputActionBinding> GetActionBindingMap()
		{
			return this.ActionBindingMap;
		}

		// Token: 0x060456AC RID: 284332 RVA: 0x012262CC File Offset: 0x012244CC
		[NullableContext(2)]
		public InputActionBinding GetActionBindingByConfigId(int configId)
		{
			InputActionBinding result;
			if (this.ActionBindingIdMapping.TryGetValue(configId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060456AD RID: 284333 RVA: 0x012262EC File Offset: 0x012244EC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<InputActionBinding> GetActionBindingByActionMappingType(EActionMappingType actionMappingType)
		{
			HashSet<InputActionBinding> result;
			if (this.ActionBindingTypeMapping.TryGetValue(actionMappingType, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060456AE RID: 284334 RVA: 0x0122630C File Offset: 0x0122450C
		public void SetKeys(string actionName, List<string> keys, EInputBindingType bindingType)
		{
			InputActionBinding inputActionBinding;
			if (!this.ActionBindingMap.TryGetValue(actionName, out inputActionBinding))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "设置Action按键时，找不到对应Action";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionName", actionName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputActionBinding.SetKeys(keys, bindingType);
			Singleton<EventSystem>.Instance.Emit<string, InputActionBinding>(EEventName.OnChangedActionKeys, actionName, inputActionBinding);
		}

		// Token: 0x060456AF RID: 284335 RVA: 0x0122636C File Offset: 0x0122456C
		public void RefreshKeysByActionMappings(string actionName, TArray<FInputActionKeyMapping> actionMappings, EInputBindingType bindingType)
		{
			InputActionBinding inputActionBinding;
			if (!this.ActionBindingMap.TryGetValue(actionName, out inputActionBinding))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputSettings;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "设置Action按键时，找不到对应Action";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionName", actionName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			inputActionBinding.RefreshKeysByActionMappings(actionMappings, bindingType);
			Singleton<EventSystem>.Instance.Emit<string, InputActionBinding>(EEventName.OnChangedActionKeys, actionName, inputActionBinding);
		}

		// Token: 0x060456B0 RID: 284336 RVA: 0x012263CC File Offset: 0x012245CC
		public void SwitchKeysByBindingType(EInputBindingType bindingType)
		{
			foreach (InputActionBinding inputActionBinding in this.ActionBindingMap.Values)
			{
				inputActionBinding.SwitchKeysByBindingType(bindingType);
			}
		}

		// Token: 0x04026CD1 RID: 158929
		private readonly Dictionary<string, InputActionBinding> ActionBindingMap = new Dictionary<string, InputActionBinding>();

		// Token: 0x04026CD2 RID: 158930
		private readonly Dictionary<int, InputActionBinding> ActionBindingIdMapping = new Dictionary<int, InputActionBinding>();

		// Token: 0x04026CD3 RID: 158931
		private readonly Dictionary<EActionMappingType, HashSet<InputActionBinding>> ActionBindingTypeMapping = new Dictionary<EActionMappingType, HashSet<InputActionBinding>>();
	}
}
