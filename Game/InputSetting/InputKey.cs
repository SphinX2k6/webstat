using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FFE RID: 28670
	[NullableContext(1)]
	[Nullable(0)]
	public class InputKey
	{
		// Token: 0x0604567B RID: 284283 RVA: 0x01225BEC File Offset: 0x01223DEC
		public InputKey(string keyName)
		{
			this.KeyName = keyName;
			this.Key = new FKey(new FName(keyName));
			this.IsKeyboardKey = (UKismetInputLibrary.Key_IsKeyboardKey(this.Key) || keyName == EKey.Keyboard_Invalid);
			this.IsModifierKey = UKismetInputLibrary.Key_IsModifierKey(this.Key);
			this.IsGamepadKey = (UKismetInputLibrary.Key_IsGamepadKey(this.Key) || keyName == EKey.Gamepad_Invalid);
			this.IsMouseButton = UKismetInputLibrary.Key_IsMouseButton(this.Key);
			this.IsDigital = UKismetInputLibrary.Key_IsDigital(this.Key);
			this.IsAnalog = UKismetInputLibrary.Key_IsAnalog(this.Key);
			this.IsButtonAxis = UKismetInputLibrary.Key_IsButtonAxis(this.Key);
			this.IsAxis1D = UKismetInputLibrary.Key_IsAxis1D(this.Key);
			this.IsAxis2D = UKismetInputLibrary.Key_IsAxis2D(this.Key);
			this.IsAxis3D = UKismetInputLibrary.Key_IsAxis3D(this.Key);
			this.IsPcPsTouchPadKey = (keyName == EKey.GenericUSBController_Button14);
		}

		// Token: 0x0604567C RID: 284284 RVA: 0x01225D0C File Offset: 0x01223F0C
		public string GetKeyName()
		{
			return this.KeyName;
		}

		// Token: 0x0604567D RID: 284285 RVA: 0x01225D14 File Offset: 0x01223F14
		public FKey ToUeKey()
		{
			return this.Key;
		}

		// Token: 0x0604567E RID: 284286 RVA: 0x01225D1C File Offset: 0x01223F1C
		[NullableContext(0)]
		public OneOf<GamepadKey, PcKey>? GetConfig()
		{
			if (this.IsKeyboardKey || this.IsMouseButton)
			{
				PcKey? pcKeyConfig = ConfigBase<InputSettingsConfig>.Instance.GetPcKeyConfig(this.KeyName);
				if (pcKeyConfig == null)
				{
					return null;
				}
				return new OneOf<GamepadKey, PcKey>?(pcKeyConfig.GetValueOrDefault());
			}
			else
			{
				if (!this.IsGamepadKey)
				{
					return null;
				}
				GamepadKey? gamepadKeyConfig = ConfigBase<InputSettingsConfig>.Instance.GetGamepadKeyConfig(this.KeyName);
				if (gamepadKeyConfig == null)
				{
					return null;
				}
				return new OneOf<GamepadKey, PcKey>?(gamepadKeyConfig.GetValueOrDefault());
			}
		}

		// Token: 0x0604567F RID: 284287 RVA: 0x01225DB6 File Offset: 0x01223FB6
		public string GetKeyIconPath()
		{
			if (this.IsKeyboardKey || this.IsMouseButton)
			{
				return InputKeyUtils.GetPcKeyIconPathByCurrentPlatform(this.KeyName) ?? "";
			}
			if (this.IsGamepadKey)
			{
				return InputKeyUtils.GetGamepadKeyIconPath(this.KeyName);
			}
			return "";
		}

		// Token: 0x06045680 RID: 284288 RVA: 0x01225DF6 File Offset: 0x01223FF6
		public bool IsInputKeyDown()
		{
			return Global.PlayerController.IsInputKeyDown(this.ToUeKey());
		}

		// Token: 0x06045681 RID: 284289 RVA: 0x01225E08 File Offset: 0x01224008
		public float GetInputAnalogKeyState()
		{
			return Global.PlayerController.GetInputAnalogKeyState(this.ToUeKey());
		}

		// Token: 0x04026CC1 RID: 158913
		private readonly string KeyName = "";

		// Token: 0x04026CC2 RID: 158914
		public readonly bool IsKeyboardKey;

		// Token: 0x04026CC3 RID: 158915
		public readonly bool IsModifierKey;

		// Token: 0x04026CC4 RID: 158916
		public readonly bool IsGamepadKey;

		// Token: 0x04026CC5 RID: 158917
		public readonly bool IsPcPsTouchPadKey;

		// Token: 0x04026CC6 RID: 158918
		public readonly bool IsMouseButton;

		// Token: 0x04026CC7 RID: 158919
		public readonly bool IsDigital;

		// Token: 0x04026CC8 RID: 158920
		public readonly bool IsAnalog;

		// Token: 0x04026CC9 RID: 158921
		public readonly bool IsButtonAxis;

		// Token: 0x04026CCA RID: 158922
		public readonly bool IsAxis1D;

		// Token: 0x04026CCB RID: 158923
		public readonly bool IsAxis2D;

		// Token: 0x04026CCC RID: 158924
		public readonly bool IsAxis3D;

		// Token: 0x04026CCD RID: 158925
		[Nullable(2)]
		private readonly FKey Key;
	}
}
