using System;
using System.Collections.Generic;
using CSharpScript.Game.InputSetting;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057CD RID: 22477
	public class PsGamepadItem : GamepadItemBase
	{
		// Token: 0x06039237 RID: 234039 RVA: 0x00E7C560 File Offset: 0x00E7A760
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUISprite)),
				new ValueTuple<int, Type>(9, typeof(UUISprite)),
				new ValueTuple<int, Type>(10, typeof(UUISprite)),
				new ValueTuple<int, Type>(11, typeof(UUISprite)),
				new ValueTuple<int, Type>(12, typeof(UUISprite)),
				new ValueTuple<int, Type>(13, typeof(UUISprite)),
				new ValueTuple<int, Type>(14, typeof(UUISprite)),
				new ValueTuple<int, Type>(15, typeof(UUISprite)),
				new ValueTuple<int, Type>(16, typeof(UUISprite))
			};
		}

		// Token: 0x06039238 RID: 234040 RVA: 0x00E7C6F8 File Offset: 0x00E7A8F8
		protected override void OnStart()
		{
			base.AddKeySprite(EKey.GenericUSBController_Axis1, base.GetSprite(0));
			base.AddKeySprite(EKey.GenericUSBController_Axis2, base.GetSprite(0));
			base.AddKeySprite(EKey.GenericUSBController_Axis3, base.GetSprite(1));
			base.AddKeySprite(EKey.GenericUSBController_Axis4, base.GetSprite(1));
			base.AddKeySprite(EKey.GenericUSBController_Axis5, base.GetSprite(0));
			base.AddKeySprite(EKey.GenericUSBController_Axis6, base.GetSprite(1));
			base.AddKeySprite(EKey.GenericUSBController_Button11, base.GetSprite(0));
			base.AddKeySprite(EKey.GenericUSBController_Button12, base.GetSprite(1));
			base.AddKeySprite(EKey.GenericUSBController_Button4, base.GetSprite(6));
			base.AddKeySprite(EKey.GenericUSBController_Button2, base.GetSprite(7));
			base.AddKeySprite(EKey.GenericUSBController_Button1, base.GetSprite(8));
			base.AddKeySprite(EKey.GenericUSBController_Button3, base.GetSprite(9));
			base.AddKeySprite(EKey.GenericUSBController_Button5, base.GetSprite(10));
			base.AddKeySprite(EKey.GenericUSBController_Button7, base.GetSprite(11));
			base.AddKeySprite(EKey.GenericUSBController_Button6, base.GetSprite(12));
			base.AddKeySprite(EKey.GenericUSBController_Button8, base.GetSprite(13));
			base.AddKeySprite(EKey.GenericUSBController_Button14, base.GetSprite(14));
			base.AddKeySprite(EKey.GenericUSBController_Button10, base.GetSprite(15));
			base.AddKeySprite(EKey.GenericUSBController_Button9, base.GetSprite(16));
			base.AddKeySprite(EKey.GenericUSBController_Button16, base.GetSprite(2));
			base.AddKeySprite(EKey.GenericUSBController_Button17, base.GetSprite(5));
			base.AddKeySprite(EKey.GenericUSBController_Button18, base.GetSprite(3));
			base.AddKeySprite(EKey.GenericUSBController_Button19, base.GetSprite(4));
			base.AddKeySprite(EKey.Gamepad_Left2D, base.GetSprite(0));
			base.AddKeySprite(EKey.Gamepad_LeftY, base.GetSprite(0));
			base.AddKeySprite(EKey.Gamepad_LeftX, base.GetSprite(0));
			base.AddKeySprite(EKey.Gamepad_LeftThumbstick, base.GetSprite(0));
			base.AddKeySprite(EKey.Gamepad_Right2D, base.GetSprite(1));
			base.AddKeySprite(EKey.Gamepad_RightY, base.GetSprite(1));
			base.AddKeySprite(EKey.Gamepad_RightX, base.GetSprite(1));
			base.AddKeySprite(EKey.Gamepad_RightThumbstick, base.GetSprite(1));
			base.AddKeySprite(EKey.Gamepad_DPad_Up, base.GetSprite(2));
			base.AddKeySprite(EKey.Gamepad_DPad_Down, base.GetSprite(3));
			base.AddKeySprite(EKey.Gamepad_DPad_Left, base.GetSprite(4));
			base.AddKeySprite(EKey.Gamepad_DPad_Right, base.GetSprite(5));
			base.AddKeySprite(EKey.Gamepad_FaceButton_Top, base.GetSprite(6));
			base.AddKeySprite(EKey.Gamepad_FaceButton_Bottom, base.GetSprite(7));
			base.AddKeySprite(EKey.Gamepad_FaceButton_Left, base.GetSprite(8));
			base.AddKeySprite(EKey.Gamepad_FaceButton_Right, base.GetSprite(9));
			base.AddKeySprite(EKey.Gamepad_LeftShoulder, base.GetSprite(10));
			base.AddKeySprite(EKey.Gamepad_LeftTriggerAxis, base.GetSprite(11));
			base.AddKeySprite(EKey.Gamepad_LeftTrigger, base.GetSprite(11));
			base.AddKeySprite(EKey.Gamepad_RightShoulder, base.GetSprite(12));
			base.AddKeySprite(EKey.Gamepad_RightTriggerAxis, base.GetSprite(13));
			base.AddKeySprite(EKey.Gamepad_RightTrigger, base.GetSprite(13));
			base.AddKeySprite(EKey.Gamepad_Special_Left, base.GetSprite(14));
			base.AddKeySprite(EKey.Gamepad_Special_Right, base.GetSprite(15));
		}

		// Token: 0x0200B854 RID: 47188
		public class EChildType
		{
			// Token: 0x04039035 RID: 233525
			public const int LeftStickSprite = 0;

			// Token: 0x04039036 RID: 233526
			public const int RightStickSprite = 1;

			// Token: 0x04039037 RID: 233527
			public const int UpSprite = 2;

			// Token: 0x04039038 RID: 233528
			public const int DownSprite = 3;

			// Token: 0x04039039 RID: 233529
			public const int LeftSprite = 4;

			// Token: 0x0403903A RID: 233530
			public const int RightSprite = 5;

			// Token: 0x0403903B RID: 233531
			public const int TopButtonSprite = 6;

			// Token: 0x0403903C RID: 233532
			public const int BottomButtonSprite = 7;

			// Token: 0x0403903D RID: 233533
			public const int LeftButtonSprite = 8;

			// Token: 0x0403903E RID: 233534
			public const int RightButtonSprite = 9;

			// Token: 0x0403903F RID: 233535
			public const int LaSprite = 10;

			// Token: 0x04039040 RID: 233536
			public const int LbSprite = 11;

			// Token: 0x04039041 RID: 233537
			public const int RaSprite = 12;

			// Token: 0x04039042 RID: 233538
			public const int RbSprite = 13;

			// Token: 0x04039043 RID: 233539
			public const int HomeButtonSprite = 14;

			// Token: 0x04039044 RID: 233540
			public const int MiniRightButtonSprite = 15;

			// Token: 0x04039045 RID: 233541
			public const int MiniLeftButtonSprite = 16;
		}
	}
}
