using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.PlayerInput
{
	// Token: 0x02004545 RID: 17733
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class HotPatchInputDefine : Singleton<HotPatchInputDefine>
	{
		// Token: 0x0602EAE9 RID: 191209 RVA: 0x00B0F968 File Offset: 0x00B0DB68
		public HotPatchInputDefine()
		{
			Dictionary<string, EMouseKey> dictionary = new Dictionary<string, EMouseKey>();
			dictionary["UI左键点击"] = EMouseKey.LeftMouseButton;
			this.pcInputMap = dictionary;
			Dictionary<string, EGamepadKey> dictionary2 = new Dictionary<string, EGamepadKey>();
			dictionary2["手柄右边上键"] = EGamepadKey.Gamepad_FaceButton_Top;
			dictionary2["手柄右边左键"] = EGamepadKey.Gamepad_FaceButton_Left;
			dictionary2["手柄右边右键"] = EGamepadKey.Gamepad_FaceButton_Right;
			dictionary2["手柄右边下键"] = EGamepadKey.Gamepad_FaceButton_Bottom;
			dictionary2["手柄左边上键"] = EGamepadKey.Gamepad_DPad_Up;
			dictionary2["手柄左边左键"] = EGamepadKey.Gamepad_DPad_Left;
			dictionary2["手柄左边右键"] = EGamepadKey.Gamepad_DPad_Right;
			dictionary2["手柄左边下键"] = EGamepadKey.Gamepad_DPad_Down;
			dictionary2["手柄左摇杆上"] = EGamepadKey.Gamepad_LeftStick_Up;
			dictionary2["手柄左摇杆下"] = EGamepadKey.Gamepad_LeftStick_Down;
			dictionary2["手柄LB"] = EGamepadKey.Gamepad_LeftShoulder;
			dictionary2["手柄LT"] = EGamepadKey.Gamepad_LeftTrigger;
			dictionary2["手柄RB"] = EGamepadKey.Gamepad_RightShoulder;
			dictionary2["手柄RT"] = EGamepadKey.Gamepad_RightTrigger;
			this.gamepadActionInputMap = dictionary2;
			Dictionary<string, ValueTuple<string, int>> dictionary3 = new Dictionary<string, ValueTuple<string, int>>();
			dictionary3["手柄右摇杆垂直方向"] = new ValueTuple<string, int>("Gamepad_RightY", 1);
			dictionary3["手柄左摇杆垂直方向"] = new ValueTuple<string, int>("Gamepad_LeftY", 1);
			this.gamepadAxisInputMap = dictionary3;
			Dictionary<EGamepadKey, IKeyPath> dictionary4 = new Dictionary<EGamepadKey, IKeyPath>();
			dictionary4[EGamepadKey.Gamepad_FaceButton_Top] = new KeyPath
			{
				XBox = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_XboxGamepad_FaceButton_Top_UI.T_IconPcBtn_XboxGamepad_FaceButton_Top_UI",
				Ps = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_PsJian_UI.T_IconPcBtn_PsJian_UI"
			};
			dictionary4[EGamepadKey.Gamepad_FaceButton_Left] = new KeyPath
			{
				XBox = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_XboxGamepad_FaceButton_Left_UI.T_IconPcBtn_XboxGamepad_FaceButton_Left_UI",
				Ps = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_PsKuang_UI.T_IconPcBtn_PsKuang_UI"
			};
			dictionary4[EGamepadKey.Gamepad_FaceButton_Right] = new KeyPath
			{
				XBox = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_KeyB_UI.T_IconPcBtn_KeyB_UI",
				Ps = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_PsYuan_UI.T_IconPcBtn_PsYuan_UI"
			};
			dictionary4[EGamepadKey.Gamepad_FaceButton_Bottom] = new KeyPath
			{
				XBox = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_KeyA_UI.T_IconPcBtn_KeyA_UI",
				Ps = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_PsCha_UI.T_IconPcBtn_PsCha_UI"
			};
			dictionary4[EGamepadKey.Gamepad_LeftShoulder] = new KeyPath
			{
				Ps = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_PsL1_UI.T_IconPcBtn_PsL1_UI"
			};
			dictionary4[EGamepadKey.Gamepad_LeftTrigger] = new KeyPath
			{
				Ps = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_PsL2_UI.T_IconPcBtn_PsL2_UI"
			};
			dictionary4[EGamepadKey.Gamepad_RightShoulder] = new KeyPath
			{
				Ps = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_PsR1_UI.T_IconPcBtn_PsR1_UI"
			};
			dictionary4[EGamepadKey.Gamepad_RightTrigger] = new KeyPath
			{
				Ps = "/Game/Aki/UI/Module/HotFix/Image/T_IconPcBtn_PsR2_UI.T_IconPcBtn_PsR2_UI"
			};
			this.gamepadKeyPathMap = dictionary4;
			base..ctor();
		}

		// Token: 0x0401A82A RID: 108586
		public const string ANY_KEY = "AnyKey";

		// Token: 0x0401A82B RID: 108587
		public const int SCROLLBAR_INTERVAL = 800;

		// Token: 0x0401A82C RID: 108588
		public readonly Dictionary<string, EMouseKey> pcInputMap;

		// Token: 0x0401A82D RID: 108589
		public readonly Dictionary<string, EGamepadKey> gamepadActionInputMap;

		// Token: 0x0401A82E RID: 108590
		[Nullable(new byte[]
		{
			1,
			1,
			0,
			1
		})]
		public readonly Dictionary<string, ValueTuple<string, int>> gamepadAxisInputMap;

		// Token: 0x0401A82F RID: 108591
		public readonly Dictionary<EGamepadKey, IKeyPath> gamepadKeyPathMap;
	}
}
