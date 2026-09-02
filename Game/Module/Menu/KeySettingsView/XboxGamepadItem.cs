using System;
using System.Collections.Generic;
using CSharpScript.Game.InputSetting;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057CF RID: 22479
	public class XboxGamepadItem : GamepadItemBase
	{
		// Token: 0x06039240 RID: 234048 RVA: 0x00E7CE04 File Offset: 0x00E7B004
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
				new ValueTuple<int, Type>(15, typeof(UUISprite)),
				new ValueTuple<int, Type>(14, typeof(UUISprite))
			};
		}

		// Token: 0x06039241 RID: 234049 RVA: 0x00E7CF84 File Offset: 0x00E7B184
		protected override void OnStart()
		{
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
			base.AddKeySprite(EKey.Gamepad_Special_Left, base.GetSprite(15));
			base.AddKeySprite(EKey.Gamepad_Special_Right, base.GetSprite(14));
		}

		// Token: 0x0200B856 RID: 47190
		public class EChildType
		{
			// Token: 0x0403904E RID: 233550
			public const int LeftStickSprite = 0;

			// Token: 0x0403904F RID: 233551
			public const int RightStickSprite = 1;

			// Token: 0x04039050 RID: 233552
			public const int UpSprite = 2;

			// Token: 0x04039051 RID: 233553
			public const int DownSprite = 3;

			// Token: 0x04039052 RID: 233554
			public const int LeftSprite = 4;

			// Token: 0x04039053 RID: 233555
			public const int RightSprite = 5;

			// Token: 0x04039054 RID: 233556
			public const int TopButtonSprite = 6;

			// Token: 0x04039055 RID: 233557
			public const int BottomButtonSprite = 7;

			// Token: 0x04039056 RID: 233558
			public const int LeftButtonSprite = 8;

			// Token: 0x04039057 RID: 233559
			public const int RightButtonSprite = 9;

			// Token: 0x04039058 RID: 233560
			public const int LaSprite = 10;

			// Token: 0x04039059 RID: 233561
			public const int LbSprite = 11;

			// Token: 0x0403905A RID: 233562
			public const int RaSprite = 12;

			// Token: 0x0403905B RID: 233563
			public const int RbSprite = 13;

			// Token: 0x0403905C RID: 233564
			public const int SpecialRightSprite = 14;

			// Token: 0x0403905D RID: 233565
			public const int SpecialLeftSprite = 15;
		}
	}
}
