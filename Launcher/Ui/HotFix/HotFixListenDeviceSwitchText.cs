using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.InputDevice;
using CSharpScript.Launcher.PlayerInput;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x0200450D RID: 17677
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixListenDeviceSwitchText
	{
		// Token: 0x0602E926 RID: 190758 RVA: 0x00B08B0D File Offset: 0x00B06D0D
		public HotFixListenDeviceSwitchText(UUIText uiText, [Nullable(new byte[]
		{
			1,
			1,
			0,
			1
		})] Dictionary<string, ValueTuple<string, actionMappings>> gamepadDataMap)
		{
			this.UiText = uiText;
			this.GamepadDataMap = gamepadDataMap;
		}

		// Token: 0x0602E927 RID: 190759 RVA: 0x00B08B3C File Offset: 0x00B06D3C
		private void SetGamepadText(string textId, actionMappings actionName)
		{
			EGamepadKey key;
			if (!Singleton<HotPatchInputDefine>.Instance.gamepadActionInputMap.TryGetValue(actionName.ToString(), out key))
			{
				return;
			}
			IKeyPath keyPath;
			if (!Singleton<HotPatchInputDefine>.Instance.gamepadKeyPathMap.TryGetValue(key, out keyPath))
			{
				return;
			}
			string text = null;
			if (Singleton<InputDevice>.Instance.IsXboxGamepad() && keyPath.XBox != null)
			{
				text = keyPath.XBox;
			}
			else if (Singleton<InputDevice>.Instance.IsPsGamepad())
			{
				text = keyPath.Ps;
			}
			if (text == null)
			{
				return;
			}
			this.UiText.SetRichText(true);
			HotFixManager.SetLocalText(this.UiText, textId, new string[]
			{
				"<texture=" + text + ">"
			});
		}

		// Token: 0x0602E928 RID: 190760 RVA: 0x00B08BE6 File Offset: 0x00B06DE6
		private void RefreshText(CSharpScript.Launcher.InputDevice.EInputControllerType a, CSharpScript.Launcher.InputDevice.EInputControllerType b)
		{
			if (this.CurrentTextId == null || this.CurrentTextId == "")
			{
				return;
			}
			this.SetLocalText(this.CurrentTextId, this.CurrentArgs.ToArray());
		}

		// Token: 0x0602E929 RID: 190761 RVA: 0x00B08C1A File Offset: 0x00B06E1A
		public void AddGamepadChange()
		{
			Singleton<InputDevice>.Instance.RegisterInputChangeDelegate(new Action<CSharpScript.Launcher.InputDevice.EInputControllerType, CSharpScript.Launcher.InputDevice.EInputControllerType>(this.RefreshText));
		}

		// Token: 0x0602E92A RID: 190762 RVA: 0x00B08C32 File Offset: 0x00B06E32
		public void RemoveGamepadChange()
		{
			Singleton<InputDevice>.Instance.UnRegisterInputChangeDelegate(new Action<CSharpScript.Launcher.InputDevice.EInputControllerType, CSharpScript.Launcher.InputDevice.EInputControllerType>(this.RefreshText));
		}

		// Token: 0x0602E92B RID: 190763 RVA: 0x00B08C4C File Offset: 0x00B06E4C
		public void SetLocalText(string textId, params string[] args)
		{
			this.CurrentTextId = textId;
			this.CurrentArgs.Clear();
			this.CurrentArgs.AddRange(args);
			ValueTuple<string, actionMappings> valueTuple;
			if (!this.GamepadDataMap.TryGetValue(textId, out valueTuple) || !Singleton<InputDevice>.Instance.IsInGamepad())
			{
				HotFixManager.SetLocalText(this.UiText, textId, args);
				return;
			}
			this.SetGamepadText(valueTuple.Item1, valueTuple.Item2);
		}

		// Token: 0x0602E92C RID: 190764 RVA: 0x00B08CB3 File Offset: 0x00B06EB3
		public void SetUiActive(bool isActive)
		{
			this.UiText.SetUIActive(isActive);
		}

		// Token: 0x0401A744 RID: 108356
		protected string CurrentTextId = "";

		// Token: 0x0401A745 RID: 108357
		protected List<string> CurrentArgs = new List<string>();

		// Token: 0x0401A746 RID: 108358
		protected UUIText UiText;

		// Token: 0x0401A747 RID: 108359
		[Nullable(new byte[]
		{
			1,
			1,
			0,
			1
		})]
		protected Dictionary<string, ValueTuple<string, actionMappings>> GamepadDataMap;
	}
}
