using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FF7 RID: 28663
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EKey : IEquatable<EKey>
	{
		// Token: 0x060455E3 RID: 284131 RVA: 0x01220CD3 File Offset: 0x0121EED3
		private EKey(string value)
		{
			this._value = value;
		}

		// Token: 0x060455E4 RID: 284132 RVA: 0x01220CDC File Offset: 0x0121EEDC
		public bool Equals(EKey other)
		{
			return this._value == other._value;
		}

		// Token: 0x060455E5 RID: 284133 RVA: 0x01220CF0 File Offset: 0x0121EEF0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is EKey)
			{
				EKey other = (EKey)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060455E6 RID: 284134 RVA: 0x01220D15 File Offset: 0x0121EF15
		public override int GetHashCode()
		{
			if (this._value == null)
			{
				return 0;
			}
			return this._value.GetHashCode();
		}

		// Token: 0x060455E7 RID: 284135 RVA: 0x01220D2C File Offset: 0x0121EF2C
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x060455E8 RID: 284136 RVA: 0x01220D34 File Offset: 0x0121EF34
		public static implicit operator string(EKey key)
		{
			return key.ToString();
		}

		// Token: 0x060455E9 RID: 284137 RVA: 0x01220D43 File Offset: 0x0121EF43
		public static explicit operator EKey(string value)
		{
			return new EKey(value);
		}

		// Token: 0x060455EA RID: 284138 RVA: 0x01220D4B File Offset: 0x0121EF4B
		public static bool operator ==(EKey left, EKey right)
		{
			return left.Equals(right);
		}

		// Token: 0x060455EB RID: 284139 RVA: 0x01220D55 File Offset: 0x0121EF55
		public static bool operator !=(EKey left, EKey right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04026AFC RID: 158460
		private readonly string _value;

		// Token: 0x04026AFD RID: 158461
		public static readonly EKey AnyKey = new EKey("AnyKey");

		// Token: 0x04026AFE RID: 158462
		public static readonly EKey MouseX = new EKey("MouseX");

		// Token: 0x04026AFF RID: 158463
		public static readonly EKey MouseY = new EKey("MouseY");

		// Token: 0x04026B00 RID: 158464
		public static readonly EKey Mouse2D = new EKey("Mouse2D");

		// Token: 0x04026B01 RID: 158465
		public static readonly EKey MouseScrollUp = new EKey("MouseScrollUp");

		// Token: 0x04026B02 RID: 158466
		public static readonly EKey MouseScrollDown = new EKey("MouseScrollDown");

		// Token: 0x04026B03 RID: 158467
		public static readonly EKey MouseWheelAxis = new EKey("MouseWheelAxis");

		// Token: 0x04026B04 RID: 158468
		public static readonly EKey LeftMouseButton = new EKey("LeftMouseButton");

		// Token: 0x04026B05 RID: 158469
		public static readonly EKey RightMouseButton = new EKey("RightMouseButton");

		// Token: 0x04026B06 RID: 158470
		public static readonly EKey MiddleMouseButton = new EKey("MiddleMouseButton");

		// Token: 0x04026B07 RID: 158471
		public static readonly EKey ThumbMouseButton = new EKey("ThumbMouseButton");

		// Token: 0x04026B08 RID: 158472
		public static readonly EKey ThumbMouseButton2 = new EKey("ThumbMouseButton2");

		// Token: 0x04026B09 RID: 158473
		public static readonly EKey BackSpace = new EKey("BackSpace");

		// Token: 0x04026B0A RID: 158474
		public static readonly EKey Tab = new EKey("Tab");

		// Token: 0x04026B0B RID: 158475
		public static readonly EKey Enter = new EKey("Enter");

		// Token: 0x04026B0C RID: 158476
		public static readonly EKey Pause = new EKey("Pause");

		// Token: 0x04026B0D RID: 158477
		public static readonly EKey CapsLock = new EKey("CapsLock");

		// Token: 0x04026B0E RID: 158478
		public static readonly EKey Escape = new EKey("Escape");

		// Token: 0x04026B0F RID: 158479
		public static readonly EKey SpaceBar = new EKey("SpaceBar");

		// Token: 0x04026B10 RID: 158480
		public static readonly EKey PageUp = new EKey("PageUp");

		// Token: 0x04026B11 RID: 158481
		public static readonly EKey PageDown = new EKey("PageDown");

		// Token: 0x04026B12 RID: 158482
		public static readonly EKey End = new EKey("End");

		// Token: 0x04026B13 RID: 158483
		public static readonly EKey Home = new EKey("Home");

		// Token: 0x04026B14 RID: 158484
		public static readonly EKey Left = new EKey("Left");

		// Token: 0x04026B15 RID: 158485
		public static readonly EKey Up = new EKey("Up");

		// Token: 0x04026B16 RID: 158486
		public static readonly EKey Right = new EKey("Right");

		// Token: 0x04026B17 RID: 158487
		public static readonly EKey Down = new EKey("Down");

		// Token: 0x04026B18 RID: 158488
		public static readonly EKey Insert = new EKey("Insert");

		// Token: 0x04026B19 RID: 158489
		public static readonly EKey Delete = new EKey("Delete");

		// Token: 0x04026B1A RID: 158490
		public static readonly EKey Zero = new EKey("Zero");

		// Token: 0x04026B1B RID: 158491
		public static readonly EKey One = new EKey("One");

		// Token: 0x04026B1C RID: 158492
		public static readonly EKey Two = new EKey("Two");

		// Token: 0x04026B1D RID: 158493
		public static readonly EKey Three = new EKey("Three");

		// Token: 0x04026B1E RID: 158494
		public static readonly EKey Four = new EKey("Four");

		// Token: 0x04026B1F RID: 158495
		public static readonly EKey Five = new EKey("Five");

		// Token: 0x04026B20 RID: 158496
		public static readonly EKey Six = new EKey("Six");

		// Token: 0x04026B21 RID: 158497
		public static readonly EKey Seven = new EKey("Seven");

		// Token: 0x04026B22 RID: 158498
		public static readonly EKey Eight = new EKey("Eight");

		// Token: 0x04026B23 RID: 158499
		public static readonly EKey Nine = new EKey("Nine");

		// Token: 0x04026B24 RID: 158500
		public static readonly EKey A = new EKey("A");

		// Token: 0x04026B25 RID: 158501
		public static readonly EKey B = new EKey("B");

		// Token: 0x04026B26 RID: 158502
		public static readonly EKey C = new EKey("C");

		// Token: 0x04026B27 RID: 158503
		public static readonly EKey D = new EKey("D");

		// Token: 0x04026B28 RID: 158504
		public static readonly EKey E = new EKey("E");

		// Token: 0x04026B29 RID: 158505
		public static readonly EKey F = new EKey("F");

		// Token: 0x04026B2A RID: 158506
		public static readonly EKey G = new EKey("G");

		// Token: 0x04026B2B RID: 158507
		public static readonly EKey H = new EKey("H");

		// Token: 0x04026B2C RID: 158508
		public static readonly EKey I = new EKey("I");

		// Token: 0x04026B2D RID: 158509
		public static readonly EKey J = new EKey("J");

		// Token: 0x04026B2E RID: 158510
		public static readonly EKey K = new EKey("K");

		// Token: 0x04026B2F RID: 158511
		public static readonly EKey L = new EKey("L");

		// Token: 0x04026B30 RID: 158512
		public static readonly EKey M = new EKey("M");

		// Token: 0x04026B31 RID: 158513
		public static readonly EKey N = new EKey("N");

		// Token: 0x04026B32 RID: 158514
		public static readonly EKey O = new EKey("O");

		// Token: 0x04026B33 RID: 158515
		public static readonly EKey P = new EKey("P");

		// Token: 0x04026B34 RID: 158516
		public static readonly EKey Q = new EKey("Q");

		// Token: 0x04026B35 RID: 158517
		public static readonly EKey R = new EKey("R");

		// Token: 0x04026B36 RID: 158518
		public static readonly EKey S = new EKey("S");

		// Token: 0x04026B37 RID: 158519
		public static readonly EKey T = new EKey("T");

		// Token: 0x04026B38 RID: 158520
		public static readonly EKey U = new EKey("U");

		// Token: 0x04026B39 RID: 158521
		public static readonly EKey V = new EKey("V");

		// Token: 0x04026B3A RID: 158522
		public static readonly EKey W = new EKey("W");

		// Token: 0x04026B3B RID: 158523
		public static readonly EKey X = new EKey("X");

		// Token: 0x04026B3C RID: 158524
		public static readonly EKey Y = new EKey("Y");

		// Token: 0x04026B3D RID: 158525
		public static readonly EKey Z = new EKey("Z");

		// Token: 0x04026B3E RID: 158526
		public static readonly EKey NumPadZero = new EKey("NumPadZero");

		// Token: 0x04026B3F RID: 158527
		public static readonly EKey NumPadOne = new EKey("NumPadOne");

		// Token: 0x04026B40 RID: 158528
		public static readonly EKey NumPadTwo = new EKey("NumPadTwo");

		// Token: 0x04026B41 RID: 158529
		public static readonly EKey NumPadThree = new EKey("NumPadThree");

		// Token: 0x04026B42 RID: 158530
		public static readonly EKey NumPadFour = new EKey("NumPadFour");

		// Token: 0x04026B43 RID: 158531
		public static readonly EKey NumPadFive = new EKey("NumPadFive");

		// Token: 0x04026B44 RID: 158532
		public static readonly EKey NumPadSix = new EKey("NumPadSix");

		// Token: 0x04026B45 RID: 158533
		public static readonly EKey NumPadSeven = new EKey("NumPadSeven");

		// Token: 0x04026B46 RID: 158534
		public static readonly EKey NumPadEight = new EKey("NumPadEight");

		// Token: 0x04026B47 RID: 158535
		public static readonly EKey NumPadNine = new EKey("NumPadNine");

		// Token: 0x04026B48 RID: 158536
		public static readonly EKey Multiply = new EKey("Multiply");

		// Token: 0x04026B49 RID: 158537
		public static readonly EKey Add = new EKey("Add");

		// Token: 0x04026B4A RID: 158538
		public static readonly EKey Subtract = new EKey("Subtract");

		// Token: 0x04026B4B RID: 158539
		public static readonly EKey Decimal = new EKey("Decimal");

		// Token: 0x04026B4C RID: 158540
		public static readonly EKey Divide = new EKey("Divide");

		// Token: 0x04026B4D RID: 158541
		public static readonly EKey F1 = new EKey("F1");

		// Token: 0x04026B4E RID: 158542
		public static readonly EKey F2 = new EKey("F2");

		// Token: 0x04026B4F RID: 158543
		public static readonly EKey F3 = new EKey("F3");

		// Token: 0x04026B50 RID: 158544
		public static readonly EKey F4 = new EKey("F4");

		// Token: 0x04026B51 RID: 158545
		public static readonly EKey F5 = new EKey("F5");

		// Token: 0x04026B52 RID: 158546
		public static readonly EKey F6 = new EKey("F6");

		// Token: 0x04026B53 RID: 158547
		public static readonly EKey F7 = new EKey("F7");

		// Token: 0x04026B54 RID: 158548
		public static readonly EKey F8 = new EKey("F8");

		// Token: 0x04026B55 RID: 158549
		public static readonly EKey F9 = new EKey("F9");

		// Token: 0x04026B56 RID: 158550
		public static readonly EKey F10 = new EKey("F10");

		// Token: 0x04026B57 RID: 158551
		public static readonly EKey F11 = new EKey("F11");

		// Token: 0x04026B58 RID: 158552
		public static readonly EKey F12 = new EKey("F12");

		// Token: 0x04026B59 RID: 158553
		public static readonly EKey NumLock = new EKey("NumLock");

		// Token: 0x04026B5A RID: 158554
		public static readonly EKey ScrollLock = new EKey("ScrollLock");

		// Token: 0x04026B5B RID: 158555
		public static readonly EKey LeftShift = new EKey("LeftShift");

		// Token: 0x04026B5C RID: 158556
		public static readonly EKey RightShift = new EKey("RightShift");

		// Token: 0x04026B5D RID: 158557
		public static readonly EKey LeftControl = new EKey("LeftControl");

		// Token: 0x04026B5E RID: 158558
		public static readonly EKey RightControl = new EKey("RightControl");

		// Token: 0x04026B5F RID: 158559
		public static readonly EKey LeftAlt = new EKey("LeftAlt");

		// Token: 0x04026B60 RID: 158560
		public static readonly EKey RightAlt = new EKey("RightAlt");

		// Token: 0x04026B61 RID: 158561
		public static readonly EKey LeftCommand = new EKey("LeftCommand");

		// Token: 0x04026B62 RID: 158562
		public static readonly EKey RightCommand = new EKey("RightCommand");

		// Token: 0x04026B63 RID: 158563
		public static readonly EKey Semicolon = new EKey("Semicolon");

		// Token: 0x04026B64 RID: 158564
		public static readonly EKey EqualsKey = new EKey("Equals");

		// Token: 0x04026B65 RID: 158565
		public static readonly EKey Comma = new EKey("Comma");

		// Token: 0x04026B66 RID: 158566
		public static readonly EKey Underscore = new EKey("Underscore");

		// Token: 0x04026B67 RID: 158567
		public static readonly EKey Hyphen = new EKey("Hyphen");

		// Token: 0x04026B68 RID: 158568
		public static readonly EKey Period = new EKey("Period");

		// Token: 0x04026B69 RID: 158569
		public static readonly EKey Slash = new EKey("Slash");

		// Token: 0x04026B6A RID: 158570
		public static readonly EKey Tilde = new EKey("Tilde");

		// Token: 0x04026B6B RID: 158571
		public static readonly EKey LeftBracket = new EKey("LeftBracket");

		// Token: 0x04026B6C RID: 158572
		public static readonly EKey Backslash = new EKey("Backslash");

		// Token: 0x04026B6D RID: 158573
		public static readonly EKey RightBracket = new EKey("RightBracket");

		// Token: 0x04026B6E RID: 158574
		public static readonly EKey Apostrophe = new EKey("Apostrophe");

		// Token: 0x04026B6F RID: 158575
		public static readonly EKey Ampersand = new EKey("Ampersand");

		// Token: 0x04026B70 RID: 158576
		public static readonly EKey Asterix = new EKey("Asterix");

		// Token: 0x04026B71 RID: 158577
		public static readonly EKey Caret = new EKey("Caret");

		// Token: 0x04026B72 RID: 158578
		public static readonly EKey Colon = new EKey("Colon");

		// Token: 0x04026B73 RID: 158579
		public static readonly EKey Dollar = new EKey("Dollar");

		// Token: 0x04026B74 RID: 158580
		public static readonly EKey Exclamation = new EKey("Exclamation");

		// Token: 0x04026B75 RID: 158581
		public static readonly EKey LeftParantheses = new EKey("LeftParantheses");

		// Token: 0x04026B76 RID: 158582
		public static readonly EKey RightParantheses = new EKey("RightParantheses");

		// Token: 0x04026B77 RID: 158583
		public static readonly EKey Quote = new EKey("Quote");

		// Token: 0x04026B78 RID: 158584
		public static readonly EKey A_AccentGrave = new EKey("A_AccentGrave");

		// Token: 0x04026B79 RID: 158585
		public static readonly EKey E_AccentGrave = new EKey("E_AccentGrave");

		// Token: 0x04026B7A RID: 158586
		public static readonly EKey E_AccentAigu = new EKey("E_AccentAigu");

		// Token: 0x04026B7B RID: 158587
		public static readonly EKey C_Cedille = new EKey("C_Cedille");

		// Token: 0x04026B7C RID: 158588
		public static readonly EKey Section = new EKey("Section");

		// Token: 0x04026B7D RID: 158589
		public static readonly EKey Keyboard_Invalid = new EKey("Keyboard_Invalid");

		// Token: 0x04026B7E RID: 158590
		public static readonly EKey Platform_Delete = new EKey("Platform_Delete");

		// Token: 0x04026B7F RID: 158591
		public static readonly EKey Gamepad_Left2D = new EKey("Gamepad_Left2D");

		// Token: 0x04026B80 RID: 158592
		public static readonly EKey Gamepad_LeftX = new EKey("Gamepad_LeftX");

		// Token: 0x04026B81 RID: 158593
		public static readonly EKey Gamepad_LeftY = new EKey("Gamepad_LeftY");

		// Token: 0x04026B82 RID: 158594
		public static readonly EKey Gamepad_Right2D = new EKey("Gamepad_Right2D");

		// Token: 0x04026B83 RID: 158595
		public static readonly EKey Gamepad_RightX = new EKey("Gamepad_RightX");

		// Token: 0x04026B84 RID: 158596
		public static readonly EKey Gamepad_RightY = new EKey("Gamepad_RightY");

		// Token: 0x04026B85 RID: 158597
		public static readonly EKey Gamepad_LeftTriggerAxis = new EKey("Gamepad_LeftTriggerAxis");

		// Token: 0x04026B86 RID: 158598
		public static readonly EKey Gamepad_RightTriggerAxis = new EKey("Gamepad_RightTriggerAxis");

		// Token: 0x04026B87 RID: 158599
		public static readonly EKey Gamepad_LeftThumbstick = new EKey("Gamepad_LeftThumbstick");

		// Token: 0x04026B88 RID: 158600
		public static readonly EKey Gamepad_RightThumbstick = new EKey("Gamepad_RightThumbstick");

		// Token: 0x04026B89 RID: 158601
		public static readonly EKey Gamepad_Special_Left = new EKey("Gamepad_Special_Left");

		// Token: 0x04026B8A RID: 158602
		public static readonly EKey Gamepad_Special_Left_X = new EKey("Gamepad_Special_Left_X");

		// Token: 0x04026B8B RID: 158603
		public static readonly EKey Gamepad_Special_Left_Y = new EKey("Gamepad_Special_Left_Y");

		// Token: 0x04026B8C RID: 158604
		public static readonly EKey Gamepad_Special_Right = new EKey("Gamepad_Special_Right");

		// Token: 0x04026B8D RID: 158605
		public static readonly EKey Gamepad_FaceButton_Bottom = new EKey("Gamepad_FaceButton_Bottom");

		// Token: 0x04026B8E RID: 158606
		public static readonly EKey Gamepad_FaceButton_Right = new EKey("Gamepad_FaceButton_Right");

		// Token: 0x04026B8F RID: 158607
		public static readonly EKey Gamepad_FaceButton_Left = new EKey("Gamepad_FaceButton_Left");

		// Token: 0x04026B90 RID: 158608
		public static readonly EKey Gamepad_FaceButton_Top = new EKey("Gamepad_FaceButton_Top");

		// Token: 0x04026B91 RID: 158609
		public static readonly EKey Gamepad_LeftShoulder = new EKey("Gamepad_LeftShoulder");

		// Token: 0x04026B92 RID: 158610
		public static readonly EKey Gamepad_RightShoulder = new EKey("Gamepad_RightShoulder");

		// Token: 0x04026B93 RID: 158611
		public static readonly EKey Gamepad_LeftTrigger = new EKey("Gamepad_LeftTrigger");

		// Token: 0x04026B94 RID: 158612
		public static readonly EKey Gamepad_RightTrigger = new EKey("Gamepad_RightTrigger");

		// Token: 0x04026B95 RID: 158613
		public static readonly EKey Gamepad_DPad_Up = new EKey("Gamepad_DPad_Up");

		// Token: 0x04026B96 RID: 158614
		public static readonly EKey Gamepad_DPad_Down = new EKey("Gamepad_DPad_Down");

		// Token: 0x04026B97 RID: 158615
		public static readonly EKey Gamepad_DPad_Right = new EKey("Gamepad_DPad_Right");

		// Token: 0x04026B98 RID: 158616
		public static readonly EKey Gamepad_DPad_Left = new EKey("Gamepad_DPad_Left");

		// Token: 0x04026B99 RID: 158617
		public static readonly EKey Gamepad_LeftStick_Up = new EKey("Gamepad_LeftStick_Up");

		// Token: 0x04026B9A RID: 158618
		public static readonly EKey Gamepad_LeftStick_Down = new EKey("Gamepad_LeftStick_Down");

		// Token: 0x04026B9B RID: 158619
		public static readonly EKey Gamepad_LeftStick_Right = new EKey("Gamepad_LeftStick_Right");

		// Token: 0x04026B9C RID: 158620
		public static readonly EKey Gamepad_LeftStick_Left = new EKey("Gamepad_LeftStick_Left");

		// Token: 0x04026B9D RID: 158621
		public static readonly EKey Gamepad_RightStick_Up = new EKey("Gamepad_RightStick_Up");

		// Token: 0x04026B9E RID: 158622
		public static readonly EKey Gamepad_RightStick_Down = new EKey("Gamepad_RightStick_Down");

		// Token: 0x04026B9F RID: 158623
		public static readonly EKey Gamepad_RightStick_Right = new EKey("Gamepad_RightStick_Right");

		// Token: 0x04026BA0 RID: 158624
		public static readonly EKey Gamepad_RightStick_Left = new EKey("Gamepad_RightStick_Left");

		// Token: 0x04026BA1 RID: 158625
		public static readonly EKey Gamepad_Invalid = new EKey("Gamepad_Invalid");

		// Token: 0x04026BA2 RID: 158626
		public static readonly EKey Tilt = new EKey("Tilt");

		// Token: 0x04026BA3 RID: 158627
		public static readonly EKey RotationRate = new EKey("RotationRate");

		// Token: 0x04026BA4 RID: 158628
		public static readonly EKey Gravity = new EKey("Gravity");

		// Token: 0x04026BA5 RID: 158629
		public static readonly EKey Acceleration = new EKey("Acceleration");

		// Token: 0x04026BA6 RID: 158630
		public static readonly EKey Gesture_Pinch = new EKey("Gesture_Pinch");

		// Token: 0x04026BA7 RID: 158631
		public static readonly EKey Gesture_Flick = new EKey("Gesture_Flick");

		// Token: 0x04026BA8 RID: 158632
		public static readonly EKey Gesture_Rotate = new EKey("Gesture_Rotate");

		// Token: 0x04026BA9 RID: 158633
		public static readonly EKey PS4_Special = new EKey("PS4_Special");

		// Token: 0x04026BAA RID: 158634
		public static readonly EKey Steam_Touch_0 = new EKey("Steam_Touch_0");

		// Token: 0x04026BAB RID: 158635
		public static readonly EKey Steam_Touch_1 = new EKey("Steam_Touch_1");

		// Token: 0x04026BAC RID: 158636
		public static readonly EKey Steam_Touch_2 = new EKey("Steam_Touch_2");

		// Token: 0x04026BAD RID: 158637
		public static readonly EKey Steam_Touch_3 = new EKey("Steam_Touch_3");

		// Token: 0x04026BAE RID: 158638
		public static readonly EKey Steam_Back_Left = new EKey("Steam_Back_Left");

		// Token: 0x04026BAF RID: 158639
		public static readonly EKey Steam_Back_Right = new EKey("Steam_Back_Right");

		// Token: 0x04026BB0 RID: 158640
		public static readonly EKey Global_Menu = new EKey("Global_Menu");

		// Token: 0x04026BB1 RID: 158641
		public static readonly EKey Global_View = new EKey("Global_View");

		// Token: 0x04026BB2 RID: 158642
		public static readonly EKey Global_Pause = new EKey("Global_Pause");

		// Token: 0x04026BB3 RID: 158643
		public static readonly EKey Global_Play = new EKey("Global_Play");

		// Token: 0x04026BB4 RID: 158644
		public static readonly EKey Global_Back = new EKey("Global_Back");

		// Token: 0x04026BB5 RID: 158645
		public static readonly EKey Android_Back = new EKey("Android_Back");

		// Token: 0x04026BB6 RID: 158646
		public static readonly EKey Android_Volume_Up = new EKey("Android_Volume_Up");

		// Token: 0x04026BB7 RID: 158647
		public static readonly EKey Android_Volume_Down = new EKey("Android_Volume_Down");

		// Token: 0x04026BB8 RID: 158648
		public static readonly EKey Android_Menu = new EKey("Android_Menu");

		// Token: 0x04026BB9 RID: 158649
		public static readonly EKey Daydream_Left_Select_Click = new EKey("Daydream_Left_Select_Click");

		// Token: 0x04026BBA RID: 158650
		public static readonly EKey Daydream_Left_Trackpad_X = new EKey("Daydream_Left_Trackpad_X");

		// Token: 0x04026BBB RID: 158651
		public static readonly EKey Daydream_Left_Trackpad_Y = new EKey("Daydream_Left_Trackpad_Y");

		// Token: 0x04026BBC RID: 158652
		public static readonly EKey Daydream_Left_Trackpad_Click = new EKey("Daydream_Left_Trackpad_Click");

		// Token: 0x04026BBD RID: 158653
		public static readonly EKey Daydream_Left_Trackpad_Touch = new EKey("Daydream_Left_Trackpad_Touch");

		// Token: 0x04026BBE RID: 158654
		public static readonly EKey Daydream_Right_Select_Click = new EKey("Daydream_Right_Select_Click");

		// Token: 0x04026BBF RID: 158655
		public static readonly EKey Daydream_Right_Trackpad_X = new EKey("Daydream_Right_Trackpad_X");

		// Token: 0x04026BC0 RID: 158656
		public static readonly EKey Daydream_Right_Trackpad_Y = new EKey("Daydream_Right_Trackpad_Y");

		// Token: 0x04026BC1 RID: 158657
		public static readonly EKey Daydream_Right_Trackpad_Click = new EKey("Daydream_Right_Trackpad_Click");

		// Token: 0x04026BC2 RID: 158658
		public static readonly EKey Daydream_Right_Trackpad_Touch = new EKey("Daydream_Right_Trackpad_Touch");

		// Token: 0x04026BC3 RID: 158659
		public static readonly EKey Vive_Left_System_Click = new EKey("Vive_Left_System_Click");

		// Token: 0x04026BC4 RID: 158660
		public static readonly EKey Vive_Left_Grip_Click = new EKey("Vive_Left_Grip_Click");

		// Token: 0x04026BC5 RID: 158661
		public static readonly EKey Vive_Left_Menu_Click = new EKey("Vive_Left_Menu_Click");

		// Token: 0x04026BC6 RID: 158662
		public static readonly EKey Vive_Left_Trigger_Click = new EKey("Vive_Left_Trigger_Click");

		// Token: 0x04026BC7 RID: 158663
		public static readonly EKey Vive_Left_Trigger_Axis = new EKey("Vive_Left_Trigger_Axis");

		// Token: 0x04026BC8 RID: 158664
		public static readonly EKey Vive_Left_Trackpad_X = new EKey("Vive_Left_Trackpad_X");

		// Token: 0x04026BC9 RID: 158665
		public static readonly EKey Vive_Left_Trackpad_Y = new EKey("Vive_Left_Trackpad_Y");

		// Token: 0x04026BCA RID: 158666
		public static readonly EKey Vive_Left_Trackpad_Click = new EKey("Vive_Left_Trackpad_Click");

		// Token: 0x04026BCB RID: 158667
		public static readonly EKey Vive_Left_Trackpad_Touch = new EKey("Vive_Left_Trackpad_Touch");

		// Token: 0x04026BCC RID: 158668
		public static readonly EKey Vive_Left_Trackpad_Up = new EKey("Vive_Left_Trackpad_Up");

		// Token: 0x04026BCD RID: 158669
		public static readonly EKey Vive_Left_Trackpad_Down = new EKey("Vive_Left_Trackpad_Down");

		// Token: 0x04026BCE RID: 158670
		public static readonly EKey Vive_Left_Trackpad_Left = new EKey("Vive_Left_Trackpad_Left");

		// Token: 0x04026BCF RID: 158671
		public static readonly EKey Vive_Left_Trackpad_Right = new EKey("Vive_Left_Trackpad_Right");

		// Token: 0x04026BD0 RID: 158672
		public static readonly EKey Vive_Right_System_Click = new EKey("Vive_Right_System_Click");

		// Token: 0x04026BD1 RID: 158673
		public static readonly EKey Vive_Right_Grip_Click = new EKey("Vive_Right_Grip_Click");

		// Token: 0x04026BD2 RID: 158674
		public static readonly EKey Vive_Right_Menu_Click = new EKey("Vive_Right_Menu_Click");

		// Token: 0x04026BD3 RID: 158675
		public static readonly EKey Vive_Right_Trigger_Click = new EKey("Vive_Right_Trigger_Click");

		// Token: 0x04026BD4 RID: 158676
		public static readonly EKey Vive_Right_Trigger_Axis = new EKey("Vive_Right_Trigger_Axis");

		// Token: 0x04026BD5 RID: 158677
		public static readonly EKey Vive_Right_Trackpad_X = new EKey("Vive_Right_Trackpad_X");

		// Token: 0x04026BD6 RID: 158678
		public static readonly EKey Vive_Right_Trackpad_Y = new EKey("Vive_Right_Trackpad_Y");

		// Token: 0x04026BD7 RID: 158679
		public static readonly EKey Vive_Right_Trackpad_Click = new EKey("Vive_Right_Trackpad_Click");

		// Token: 0x04026BD8 RID: 158680
		public static readonly EKey Vive_Right_Trackpad_Touch = new EKey("Vive_Right_Trackpad_Touch");

		// Token: 0x04026BD9 RID: 158681
		public static readonly EKey Vive_Right_Trackpad_Up = new EKey("Vive_Right_Trackpad_Up");

		// Token: 0x04026BDA RID: 158682
		public static readonly EKey Vive_Right_Trackpad_Down = new EKey("Vive_Right_Trackpad_Down");

		// Token: 0x04026BDB RID: 158683
		public static readonly EKey Vive_Right_Trackpad_Left = new EKey("Vive_Right_Trackpad_Left");

		// Token: 0x04026BDC RID: 158684
		public static readonly EKey Vive_Right_Trackpad_Right = new EKey("Vive_Right_Trackpad_Right");

		// Token: 0x04026BDD RID: 158685
		public static readonly EKey MixedReality_Left_Menu_Click = new EKey("MixedReality_Left_Menu_Click");

		// Token: 0x04026BDE RID: 158686
		public static readonly EKey MixedReality_Left_Grip_Click = new EKey("MixedReality_Left_Grip_Click");

		// Token: 0x04026BDF RID: 158687
		public static readonly EKey MixedReality_Left_Trigger_Click = new EKey("MixedReality_Left_Trigger_Click");

		// Token: 0x04026BE0 RID: 158688
		public static readonly EKey MixedReality_Left_Trigger_Axis = new EKey("MixedReality_Left_Trigger_Axis");

		// Token: 0x04026BE1 RID: 158689
		public static readonly EKey MixedReality_Left_Thumbstick_X = new EKey("MixedReality_Left_Thumbstick_X");

		// Token: 0x04026BE2 RID: 158690
		public static readonly EKey MixedReality_Left_Thumbstick_Y = new EKey("MixedReality_Left_Thumbstick_Y");

		// Token: 0x04026BE3 RID: 158691
		public static readonly EKey MixedReality_Left_Thumbstick_Click = new EKey("MixedReality_Left_Thumbstick_Click");

		// Token: 0x04026BE4 RID: 158692
		public static readonly EKey MixedReality_Left_Thumbstick_Up = new EKey("MixedReality_Left_Thumbstick_Up");

		// Token: 0x04026BE5 RID: 158693
		public static readonly EKey MixedReality_Left_Thumbstick_Down = new EKey("MixedReality_Left_Thumbstick_Down");

		// Token: 0x04026BE6 RID: 158694
		public static readonly EKey MixedReality_Left_Thumbstick_Left = new EKey("MixedReality_Left_Thumbstick_Left");

		// Token: 0x04026BE7 RID: 158695
		public static readonly EKey MixedReality_Left_Thumbstick_Right = new EKey("MixedReality_Left_Thumbstick_Right");

		// Token: 0x04026BE8 RID: 158696
		public static readonly EKey MixedReality_Left_Trackpad_X = new EKey("MixedReality_Left_Trackpad_X");

		// Token: 0x04026BE9 RID: 158697
		public static readonly EKey MixedReality_Left_Trackpad_Y = new EKey("MixedReality_Left_Trackpad_Y");

		// Token: 0x04026BEA RID: 158698
		public static readonly EKey MixedReality_Left_Trackpad_Click = new EKey("MixedReality_Left_Trackpad_Click");

		// Token: 0x04026BEB RID: 158699
		public static readonly EKey MixedReality_Left_Trackpad_Touch = new EKey("MixedReality_Left_Trackpad_Touch");

		// Token: 0x04026BEC RID: 158700
		public static readonly EKey MixedReality_Left_Trackpad_Up = new EKey("MixedReality_Left_Trackpad_Up");

		// Token: 0x04026BED RID: 158701
		public static readonly EKey MixedReality_Left_Trackpad_Down = new EKey("MixedReality_Left_Trackpad_Down");

		// Token: 0x04026BEE RID: 158702
		public static readonly EKey MixedReality_Left_Trackpad_Left = new EKey("MixedReality_Left_Trackpad_Left");

		// Token: 0x04026BEF RID: 158703
		public static readonly EKey MixedReality_Left_Trackpad_Right = new EKey("MixedReality_Left_Trackpad_Right");

		// Token: 0x04026BF0 RID: 158704
		public static readonly EKey MixedReality_Right_Menu_Click = new EKey("MixedReality_Right_Menu_Click");

		// Token: 0x04026BF1 RID: 158705
		public static readonly EKey MixedReality_Right_Grip_Click = new EKey("MixedReality_Right_Grip_Click");

		// Token: 0x04026BF2 RID: 158706
		public static readonly EKey MixedReality_Right_Trigger_Click = new EKey("MixedReality_Right_Trigger_Click");

		// Token: 0x04026BF3 RID: 158707
		public static readonly EKey MixedReality_Right_Trigger_Axis = new EKey("MixedReality_Right_Trigger_Axis");

		// Token: 0x04026BF4 RID: 158708
		public static readonly EKey MixedReality_Right_Thumbstick_X = new EKey("MixedReality_Right_Thumbstick_X");

		// Token: 0x04026BF5 RID: 158709
		public static readonly EKey MixedReality_Right_Thumbstick_Y = new EKey("MixedReality_Right_Thumbstick_Y");

		// Token: 0x04026BF6 RID: 158710
		public static readonly EKey MixedReality_Right_Thumbstick_Click = new EKey("MixedReality_Right_Thumbstick_Click");

		// Token: 0x04026BF7 RID: 158711
		public static readonly EKey MixedReality_Right_Thumbstick_Up = new EKey("MixedReality_Right_Thumbstick_Up");

		// Token: 0x04026BF8 RID: 158712
		public static readonly EKey MixedReality_Right_Thumbstick_Down = new EKey("MixedReality_Right_Thumbstick_Down");

		// Token: 0x04026BF9 RID: 158713
		public static readonly EKey MixedReality_Right_Thumbstick_Left = new EKey("MixedReality_Right_Thumbstick_Left");

		// Token: 0x04026BFA RID: 158714
		public static readonly EKey MixedReality_Right_Thumbstick_Right = new EKey("MixedReality_Right_Thumbstick_Right");

		// Token: 0x04026BFB RID: 158715
		public static readonly EKey MixedReality_Right_Trackpad_X = new EKey("MixedReality_Right_Trackpad_X");

		// Token: 0x04026BFC RID: 158716
		public static readonly EKey MixedReality_Right_Trackpad_Y = new EKey("MixedReality_Right_Trackpad_Y");

		// Token: 0x04026BFD RID: 158717
		public static readonly EKey MixedReality_Right_Trackpad_Click = new EKey("MixedReality_Right_Trackpad_Click");

		// Token: 0x04026BFE RID: 158718
		public static readonly EKey MixedReality_Right_Trackpad_Touch = new EKey("MixedReality_Right_Trackpad_Touch");

		// Token: 0x04026BFF RID: 158719
		public static readonly EKey MixedReality_Right_Trackpad_Up = new EKey("MixedReality_Right_Trackpad_Up");

		// Token: 0x04026C00 RID: 158720
		public static readonly EKey MixedReality_Right_Trackpad_Down = new EKey("MixedReality_Right_Trackpad_Down");

		// Token: 0x04026C01 RID: 158721
		public static readonly EKey MixedReality_Right_Trackpad_Left = new EKey("MixedReality_Right_Trackpad_Left");

		// Token: 0x04026C02 RID: 158722
		public static readonly EKey MixedReality_Right_Trackpad_Right = new EKey("MixedReality_Right_Trackpad_Right");

		// Token: 0x04026C03 RID: 158723
		public static readonly EKey OculusTouch_Left_X_Click = new EKey("OculusTouch_Left_X_Click");

		// Token: 0x04026C04 RID: 158724
		public static readonly EKey OculusTouch_Left_Y_Click = new EKey("OculusTouch_Left_Y_Click");

		// Token: 0x04026C05 RID: 158725
		public static readonly EKey OculusTouch_Left_X_Touch = new EKey("OculusTouch_Left_X_Touch");

		// Token: 0x04026C06 RID: 158726
		public static readonly EKey OculusTouch_Left_Y_Touch = new EKey("OculusTouch_Left_Y_Touch");

		// Token: 0x04026C07 RID: 158727
		public static readonly EKey OculusTouch_Left_Menu_Click = new EKey("OculusTouch_Left_Menu_Click");

		// Token: 0x04026C08 RID: 158728
		public static readonly EKey OculusTouch_Left_Grip_Click = new EKey("OculusTouch_Left_Grip_Click");

		// Token: 0x04026C09 RID: 158729
		public static readonly EKey OculusTouch_Left_Grip_Axis = new EKey("OculusTouch_Left_Grip_Axis");

		// Token: 0x04026C0A RID: 158730
		public static readonly EKey OculusTouch_Left_Trigger_Click = new EKey("OculusTouch_Left_Trigger_Click");

		// Token: 0x04026C0B RID: 158731
		public static readonly EKey OculusTouch_Left_Trigger_Axis = new EKey("OculusTouch_Left_Trigger_Axis");

		// Token: 0x04026C0C RID: 158732
		public static readonly EKey OculusTouch_Left_Trigger_Touch = new EKey("OculusTouch_Left_Trigger_Touch");

		// Token: 0x04026C0D RID: 158733
		public static readonly EKey OculusTouch_Left_Thumbstick_X = new EKey("OculusTouch_Left_Thumbstick_X");

		// Token: 0x04026C0E RID: 158734
		public static readonly EKey OculusTouch_Left_Thumbstick_Y = new EKey("OculusTouch_Left_Thumbstick_Y");

		// Token: 0x04026C0F RID: 158735
		public static readonly EKey OculusTouch_Left_Thumbstick_Click = new EKey("OculusTouch_Left_Thumbstick_Click");

		// Token: 0x04026C10 RID: 158736
		public static readonly EKey OculusTouch_Left_Thumbstick_Touch = new EKey("OculusTouch_Left_Thumbstick_Touch");

		// Token: 0x04026C11 RID: 158737
		public static readonly EKey OculusTouch_Left_Thumbstick_Up = new EKey("OculusTouch_Left_Thumbstick_Up");

		// Token: 0x04026C12 RID: 158738
		public static readonly EKey OculusTouch_Left_Thumbstick_Down = new EKey("OculusTouch_Left_Thumbstick_Down");

		// Token: 0x04026C13 RID: 158739
		public static readonly EKey OculusTouch_Left_Thumbstick_Left = new EKey("OculusTouch_Left_Thumbstick_Left");

		// Token: 0x04026C14 RID: 158740
		public static readonly EKey OculusTouch_Left_Thumbstick_Right = new EKey("OculusTouch_Left_Thumbstick_Right");

		// Token: 0x04026C15 RID: 158741
		public static readonly EKey OculusTouch_Right_A_Click = new EKey("OculusTouch_Right_A_Click");

		// Token: 0x04026C16 RID: 158742
		public static readonly EKey OculusTouch_Right_B_Click = new EKey("OculusTouch_Right_B_Click");

		// Token: 0x04026C17 RID: 158743
		public static readonly EKey OculusTouch_Right_A_Touch = new EKey("OculusTouch_Right_A_Touch");

		// Token: 0x04026C18 RID: 158744
		public static readonly EKey OculusTouch_Right_B_Touch = new EKey("OculusTouch_Right_B_Touch");

		// Token: 0x04026C19 RID: 158745
		public static readonly EKey OculusTouch_Right_System_Click = new EKey("OculusTouch_Right_System_Click");

		// Token: 0x04026C1A RID: 158746
		public static readonly EKey OculusTouch_Right_Grip_Click = new EKey("OculusTouch_Right_Grip_Click");

		// Token: 0x04026C1B RID: 158747
		public static readonly EKey OculusTouch_Right_Grip_Axis = new EKey("OculusTouch_Right_Grip_Axis");

		// Token: 0x04026C1C RID: 158748
		public static readonly EKey OculusTouch_Right_Trigger_Click = new EKey("OculusTouch_Right_Trigger_Click");

		// Token: 0x04026C1D RID: 158749
		public static readonly EKey OculusTouch_Right_Trigger_Axis = new EKey("OculusTouch_Right_Trigger_Axis");

		// Token: 0x04026C1E RID: 158750
		public static readonly EKey OculusTouch_Right_Trigger_Touch = new EKey("OculusTouch_Right_Trigger_Touch");

		// Token: 0x04026C1F RID: 158751
		public static readonly EKey OculusTouch_Right_Thumbstick_X = new EKey("OculusTouch_Right_Thumbstick_X");

		// Token: 0x04026C20 RID: 158752
		public static readonly EKey OculusTouch_Right_Thumbstick_Y = new EKey("OculusTouch_Right_Thumbstick_Y");

		// Token: 0x04026C21 RID: 158753
		public static readonly EKey OculusTouch_Right_Thumbstick_Click = new EKey("OculusTouch_Right_Thumbstick_Click");

		// Token: 0x04026C22 RID: 158754
		public static readonly EKey OculusTouch_Right_Thumbstick_Touch = new EKey("OculusTouch_Right_Thumbstick_Touch");

		// Token: 0x04026C23 RID: 158755
		public static readonly EKey OculusTouch_Right_Thumbstick_Up = new EKey("OculusTouch_Right_Thumbstick_Up");

		// Token: 0x04026C24 RID: 158756
		public static readonly EKey OculusTouch_Right_Thumbstick_Down = new EKey("OculusTouch_Right_Thumbstick_Down");

		// Token: 0x04026C25 RID: 158757
		public static readonly EKey OculusTouch_Right_Thumbstick_Left = new EKey("OculusTouch_Right_Thumbstick_Left");

		// Token: 0x04026C26 RID: 158758
		public static readonly EKey OculusTouch_Right_Thumbstick_Right = new EKey("OculusTouch_Right_Thumbstick_Right");

		// Token: 0x04026C27 RID: 158759
		public static readonly EKey ValveIndex_Left_A_Click = new EKey("ValveIndex_Left_A_Click");

		// Token: 0x04026C28 RID: 158760
		public static readonly EKey ValveIndex_Left_B_Click = new EKey("ValveIndex_Left_B_Click");

		// Token: 0x04026C29 RID: 158761
		public static readonly EKey ValveIndex_Left_A_Touch = new EKey("ValveIndex_Left_A_Touch");

		// Token: 0x04026C2A RID: 158762
		public static readonly EKey ValveIndex_Left_B_Touch = new EKey("ValveIndex_Left_B_Touch");

		// Token: 0x04026C2B RID: 158763
		public static readonly EKey ValveIndex_Left_System_Click = new EKey("ValveIndex_Left_System_Click");

		// Token: 0x04026C2C RID: 158764
		public static readonly EKey ValveIndex_Left_System_Touch = new EKey("ValveIndex_Left_System_Touch");

		// Token: 0x04026C2D RID: 158765
		public static readonly EKey ValveIndex_Left_Grip_Axis = new EKey("ValveIndex_Left_Grip_Axis");

		// Token: 0x04026C2E RID: 158766
		public static readonly EKey ValveIndex_Left_Grip_Force = new EKey("ValveIndex_Left_Grip_Force");

		// Token: 0x04026C2F RID: 158767
		public static readonly EKey ValveIndex_Left_Trigger_Click = new EKey("ValveIndex_Left_Trigger_Click");

		// Token: 0x04026C30 RID: 158768
		public static readonly EKey ValveIndex_Left_Trigger_Axis = new EKey("ValveIndex_Left_Trigger_Axis");

		// Token: 0x04026C31 RID: 158769
		public static readonly EKey ValveIndex_Left_Trigger_Touch = new EKey("ValveIndex_Left_Trigger_Touch");

		// Token: 0x04026C32 RID: 158770
		public static readonly EKey ValveIndex_Left_Thumbstick_X = new EKey("ValveIndex_Left_Thumbstick_X");

		// Token: 0x04026C33 RID: 158771
		public static readonly EKey ValveIndex_Left_Thumbstick_Y = new EKey("ValveIndex_Left_Thumbstick_Y");

		// Token: 0x04026C34 RID: 158772
		public static readonly EKey ValveIndex_Left_Thumbstick_Click = new EKey("ValveIndex_Left_Thumbstick_Click");

		// Token: 0x04026C35 RID: 158773
		public static readonly EKey ValveIndex_Left_Thumbstick_Touch = new EKey("ValveIndex_Left_Thumbstick_Touch");

		// Token: 0x04026C36 RID: 158774
		public static readonly EKey ValveIndex_Left_Thumbstick_Up = new EKey("ValveIndex_Left_Thumbstick_Up");

		// Token: 0x04026C37 RID: 158775
		public static readonly EKey ValveIndex_Left_Thumbstick_Down = new EKey("ValveIndex_Left_Thumbstick_Down");

		// Token: 0x04026C38 RID: 158776
		public static readonly EKey ValveIndex_Left_Thumbstick_Left = new EKey("ValveIndex_Left_Thumbstick_Left");

		// Token: 0x04026C39 RID: 158777
		public static readonly EKey ValveIndex_Left_Thumbstick_Right = new EKey("ValveIndex_Left_Thumbstick_Right");

		// Token: 0x04026C3A RID: 158778
		public static readonly EKey ValveIndex_Left_Trackpad_X = new EKey("ValveIndex_Left_Trackpad_X");

		// Token: 0x04026C3B RID: 158779
		public static readonly EKey ValveIndex_Left_Trackpad_Y = new EKey("ValveIndex_Left_Trackpad_Y");

		// Token: 0x04026C3C RID: 158780
		public static readonly EKey ValveIndex_Left_Trackpad_Force = new EKey("ValveIndex_Left_Trackpad_Force");

		// Token: 0x04026C3D RID: 158781
		public static readonly EKey ValveIndex_Left_Trackpad_Touch = new EKey("ValveIndex_Left_Trackpad_Touch");

		// Token: 0x04026C3E RID: 158782
		public static readonly EKey ValveIndex_Left_Trackpad_Up = new EKey("ValveIndex_Left_Trackpad_Up");

		// Token: 0x04026C3F RID: 158783
		public static readonly EKey ValveIndex_Left_Trackpad_Down = new EKey("ValveIndex_Left_Trackpad_Down");

		// Token: 0x04026C40 RID: 158784
		public static readonly EKey ValveIndex_Left_Trackpad_Left = new EKey("ValveIndex_Left_Trackpad_Left");

		// Token: 0x04026C41 RID: 158785
		public static readonly EKey ValveIndex_Left_Trackpad_Right = new EKey("ValveIndex_Left_Trackpad_Right");

		// Token: 0x04026C42 RID: 158786
		public static readonly EKey ValveIndex_Right_A_Click = new EKey("ValveIndex_Right_A_Click");

		// Token: 0x04026C43 RID: 158787
		public static readonly EKey ValveIndex_Right_B_Click = new EKey("ValveIndex_Right_B_Click");

		// Token: 0x04026C44 RID: 158788
		public static readonly EKey ValveIndex_Right_A_Touch = new EKey("ValveIndex_Right_A_Touch");

		// Token: 0x04026C45 RID: 158789
		public static readonly EKey ValveIndex_Right_B_Touch = new EKey("ValveIndex_Right_B_Touch");

		// Token: 0x04026C46 RID: 158790
		public static readonly EKey ValveIndex_Right_System_Click = new EKey("ValveIndex_Right_System_Click");

		// Token: 0x04026C47 RID: 158791
		public static readonly EKey ValveIndex_Right_System_Touch = new EKey("ValveIndex_Right_System_Touch");

		// Token: 0x04026C48 RID: 158792
		public static readonly EKey ValveIndex_Right_Grip_Axis = new EKey("ValveIndex_Right_Grip_Axis");

		// Token: 0x04026C49 RID: 158793
		public static readonly EKey ValveIndex_Right_Grip_Force = new EKey("ValveIndex_Right_Grip_Force");

		// Token: 0x04026C4A RID: 158794
		public static readonly EKey ValveIndex_Right_Trigger_Click = new EKey("ValveIndex_Right_Trigger_Click");

		// Token: 0x04026C4B RID: 158795
		public static readonly EKey ValveIndex_Right_Trigger_Axis = new EKey("ValveIndex_Right_Trigger_Axis");

		// Token: 0x04026C4C RID: 158796
		public static readonly EKey ValveIndex_Right_Trigger_Touch = new EKey("ValveIndex_Right_Trigger_Touch");

		// Token: 0x04026C4D RID: 158797
		public static readonly EKey ValveIndex_Right_Thumbstick_X = new EKey("ValveIndex_Right_Thumbstick_X");

		// Token: 0x04026C4E RID: 158798
		public static readonly EKey ValveIndex_Right_Thumbstick_Y = new EKey("ValveIndex_Right_Thumbstick_Y");

		// Token: 0x04026C4F RID: 158799
		public static readonly EKey ValveIndex_Right_Thumbstick_Click = new EKey("ValveIndex_Right_Thumbstick_Click");

		// Token: 0x04026C50 RID: 158800
		public static readonly EKey ValveIndex_Right_Thumbstick_Touch = new EKey("ValveIndex_Right_Thumbstick_Touch");

		// Token: 0x04026C51 RID: 158801
		public static readonly EKey ValveIndex_Right_Thumbstick_Up = new EKey("ValveIndex_Right_Thumbstick_Up");

		// Token: 0x04026C52 RID: 158802
		public static readonly EKey ValveIndex_Right_Thumbstick_Down = new EKey("ValveIndex_Right_Thumbstick_Down");

		// Token: 0x04026C53 RID: 158803
		public static readonly EKey ValveIndex_Right_Thumbstick_Left = new EKey("ValveIndex_Right_Thumbstick_Left");

		// Token: 0x04026C54 RID: 158804
		public static readonly EKey ValveIndex_Right_Thumbstick_Right = new EKey("ValveIndex_Right_Thumbstick_Right");

		// Token: 0x04026C55 RID: 158805
		public static readonly EKey ValveIndex_Right_Trackpad_X = new EKey("ValveIndex_Right_Trackpad_X");

		// Token: 0x04026C56 RID: 158806
		public static readonly EKey ValveIndex_Right_Trackpad_Y = new EKey("ValveIndex_Right_Trackpad_Y");

		// Token: 0x04026C57 RID: 158807
		public static readonly EKey ValveIndex_Right_Trackpad_Force = new EKey("ValveIndex_Right_Trackpad_Force");

		// Token: 0x04026C58 RID: 158808
		public static readonly EKey ValveIndex_Right_Trackpad_Touch = new EKey("ValveIndex_Right_Trackpad_Touch");

		// Token: 0x04026C59 RID: 158809
		public static readonly EKey ValveIndex_Right_Trackpad_Up = new EKey("ValveIndex_Right_Trackpad_Up");

		// Token: 0x04026C5A RID: 158810
		public static readonly EKey ValveIndex_Right_Trackpad_Down = new EKey("ValveIndex_Right_Trackpad_Down");

		// Token: 0x04026C5B RID: 158811
		public static readonly EKey ValveIndex_Right_Trackpad_Left = new EKey("ValveIndex_Right_Trackpad_Left");

		// Token: 0x04026C5C RID: 158812
		public static readonly EKey ValveIndex_Right_Trackpad_Right = new EKey("ValveIndex_Right_Trackpad_Right");

		// Token: 0x04026C5D RID: 158813
		public static readonly EKey Virtual_Accept = new EKey("Virtual_Accept");

		// Token: 0x04026C5E RID: 158814
		public static readonly EKey Virtual_Back = new EKey("Virtual_Back");

		// Token: 0x04026C5F RID: 158815
		public static readonly EKey GenericUSBController_Button1 = new EKey("GenericUSBController_Button1");

		// Token: 0x04026C60 RID: 158816
		public static readonly EKey GenericUSBController_Button2 = new EKey("GenericUSBController_Button2");

		// Token: 0x04026C61 RID: 158817
		public static readonly EKey GenericUSBController_Button3 = new EKey("GenericUSBController_Button3");

		// Token: 0x04026C62 RID: 158818
		public static readonly EKey GenericUSBController_Button4 = new EKey("GenericUSBController_Button4");

		// Token: 0x04026C63 RID: 158819
		public static readonly EKey GenericUSBController_Button5 = new EKey("GenericUSBController_Button5");

		// Token: 0x04026C64 RID: 158820
		public static readonly EKey GenericUSBController_Button6 = new EKey("GenericUSBController_Button6");

		// Token: 0x04026C65 RID: 158821
		public static readonly EKey GenericUSBController_Button7 = new EKey("GenericUSBController_Button7");

		// Token: 0x04026C66 RID: 158822
		public static readonly EKey GenericUSBController_Button8 = new EKey("GenericUSBController_Button8");

		// Token: 0x04026C67 RID: 158823
		public static readonly EKey GenericUSBController_Button9 = new EKey("GenericUSBController_Button9");

		// Token: 0x04026C68 RID: 158824
		public static readonly EKey GenericUSBController_Button10 = new EKey("GenericUSBController_Button10");

		// Token: 0x04026C69 RID: 158825
		public static readonly EKey GenericUSBController_Button11 = new EKey("GenericUSBController_Button11");

		// Token: 0x04026C6A RID: 158826
		public static readonly EKey GenericUSBController_Button12 = new EKey("GenericUSBController_Button12");

		// Token: 0x04026C6B RID: 158827
		public static readonly EKey GenericUSBController_Button13 = new EKey("GenericUSBController_Button13");

		// Token: 0x04026C6C RID: 158828
		public static readonly EKey GenericUSBController_Button14 = new EKey("GenericUSBController_Button14");

		// Token: 0x04026C6D RID: 158829
		public static readonly EKey GenericUSBController_Button15 = new EKey("GenericUSBController_Button15");

		// Token: 0x04026C6E RID: 158830
		public static readonly EKey GenericUSBController_Button16 = new EKey("GenericUSBController_Button16");

		// Token: 0x04026C6F RID: 158831
		public static readonly EKey GenericUSBController_Button17 = new EKey("GenericUSBController_Button17");

		// Token: 0x04026C70 RID: 158832
		public static readonly EKey GenericUSBController_Button18 = new EKey("GenericUSBController_Button18");

		// Token: 0x04026C71 RID: 158833
		public static readonly EKey GenericUSBController_Button19 = new EKey("GenericUSBController_Button19");

		// Token: 0x04026C72 RID: 158834
		public static readonly EKey GenericUSBController_Button20 = new EKey("GenericUSBController_Button20");

		// Token: 0x04026C73 RID: 158835
		public static readonly EKey GenericUSBController_Button21 = new EKey("GenericUSBController_Button21");

		// Token: 0x04026C74 RID: 158836
		public static readonly EKey GenericUSBController_Button22 = new EKey("GenericUSBController_Button22");

		// Token: 0x04026C75 RID: 158837
		public static readonly EKey GenericUSBController_Button23 = new EKey("GenericUSBController_Button23");

		// Token: 0x04026C76 RID: 158838
		public static readonly EKey GenericUSBController_Button24 = new EKey("GenericUSBController_Button24");

		// Token: 0x04026C77 RID: 158839
		public static readonly EKey GenericUSBController_Button25 = new EKey("GenericUSBController_Button25");

		// Token: 0x04026C78 RID: 158840
		public static readonly EKey GenericUSBController_Button26 = new EKey("GenericUSBController_Button26");

		// Token: 0x04026C79 RID: 158841
		public static readonly EKey GenericUSBController_Button27 = new EKey("GenericUSBController_Button27");

		// Token: 0x04026C7A RID: 158842
		public static readonly EKey GenericUSBController_Button28 = new EKey("GenericUSBController_Button28");

		// Token: 0x04026C7B RID: 158843
		public static readonly EKey GenericUSBController_Button29 = new EKey("GenericUSBController_Button29");

		// Token: 0x04026C7C RID: 158844
		public static readonly EKey GenericUSBController_Button30 = new EKey("GenericUSBController_Button30");

		// Token: 0x04026C7D RID: 158845
		public static readonly EKey GenericUSBController_ButtonInvalid = new EKey("GenericUSBController_ButtonInvalid");

		// Token: 0x04026C7E RID: 158846
		public static readonly EKey GenericUSBController_Axis1 = new EKey("GenericUSBController_Axis1");

		// Token: 0x04026C7F RID: 158847
		public static readonly EKey GenericUSBController_Axis2 = new EKey("GenericUSBController_Axis2");

		// Token: 0x04026C80 RID: 158848
		public static readonly EKey GenericUSBController_Axis3 = new EKey("GenericUSBController_Axis3");

		// Token: 0x04026C81 RID: 158849
		public static readonly EKey GenericUSBController_Axis4 = new EKey("GenericUSBController_Axis4");

		// Token: 0x04026C82 RID: 158850
		public static readonly EKey GenericUSBController_Axis5 = new EKey("GenericUSBController_Axis5");

		// Token: 0x04026C83 RID: 158851
		public static readonly EKey GenericUSBController_Axis6 = new EKey("GenericUSBController_Axis6");

		// Token: 0x04026C84 RID: 158852
		public static readonly EKey GenericUSBController_Axis7 = new EKey("GenericUSBController_Axis7");

		// Token: 0x04026C85 RID: 158853
		public static readonly EKey Invalid = new EKey("Invalid");
	}
}
