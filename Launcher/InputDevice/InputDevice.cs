using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Platform;
using UnrealEngine;

namespace CSharpScript.Launcher.InputDevice
{
	// Token: 0x020045F8 RID: 17912
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InputDevice : Singleton<InputDevice>
	{
		// Token: 0x0602EDD0 RID: 191952 RVA: 0x00B18F60 File Offset: 0x00B17160
		public void Initialize()
		{
			switch (Singleton<Platform>.Instance.Type)
			{
			case EPlatformType.Android:
			case EPlatformType.IOS:
			case EPlatformType.OpenHarmony:
				this.TypeInternal = EInputControllerType.Touch;
				goto IL_79;
			case EPlatformType.Linux:
			case EPlatformType.Mac:
			case EPlatformType.Windows:
				this.TypeInternal = EInputControllerType.Keyboard;
				goto IL_79;
			case EPlatformType.PS4:
				this.TypeInternal = EInputControllerType.PS4;
				goto IL_79;
			case EPlatformType.PS5:
				this.TypeInternal = EInputControllerType.PS5;
				goto IL_79;
			case EPlatformType.XboxOne:
				this.TypeInternal = EInputControllerType.XboxOne;
				goto IL_79;
			}
			this.TypeInternal = EInputControllerType.Keyboard;
			IL_79:
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]初始化输入类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlatformType", this.TypeInternal);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (!Singleton<Platform>.Instance.IsPcPlatform())
			{
				this.RefreshPlatformByDevice();
			}
		}

		// Token: 0x0602EDD1 RID: 191953 RVA: 0x00B19028 File Offset: 0x00B17228
		private unsafe void SetInputControllerType(EInputControllerType inputControllerType)
		{
			if (this.TypeInternal == inputControllerType)
			{
				return;
			}
			EInputControllerType typeInternal = this.TypeInternal;
			this.TypeInternal = inputControllerType;
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]设置输入方式";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("lastInputController", typeInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("InputController", this.TypeInternal);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			foreach (Action<EInputControllerType, EInputControllerType> action in this.InputChangeDelegateSet)
			{
				action(typeInternal, inputControllerType);
			}
		}

		// Token: 0x0602EDD2 RID: 191954 RVA: 0x00B190F0 File Offset: 0x00B172F0
		private EInputControllerType? GetCurrentDeviceInputController()
		{
			return null;
		}

		// Token: 0x0602EDD3 RID: 191955 RVA: 0x00B19108 File Offset: 0x00B17308
		private bool RefreshPlatformByDevice()
		{
			if (Singleton<Platform>.Instance.IsPs5Platform())
			{
				this.SwitchInputControllerType(EInputControllerType.PS5);
				return true;
			}
			if (Singleton<Platform>.Instance.IsPcPlatform())
			{
				EInputControllerType? currentDeviceInputController = this.GetCurrentDeviceInputController();
				if (currentDeviceInputController != null)
				{
					this.SwitchInputControllerType(currentDeviceInputController.Value);
					return true;
				}
			}
			string currentActiveGamepadName = UKismetSystemLibrary.GetCurrentActiveGamepadName();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]当前激活的手柄";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("设备名", currentActiveGamepadName);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (Singleton<Platform>.Instance.IsAndroidPlatform())
			{
				if (currentActiveGamepadName == "None")
				{
					return false;
				}
				EInputControllerType inputControllerType;
				if (InputDevice.deviceIdMap.TryGetValue(currentActiveGamepadName, out inputControllerType))
				{
					this.SwitchInputControllerType(inputControllerType);
					return true;
				}
				foreach (KeyValuePair<string, EInputControllerType> keyValuePair in InputDevice.deviceIdMap)
				{
					int num = keyValuePair.Key.IndexOf("_*", StringComparison.Ordinal);
					if (num > 0 && num == keyValuePair.Key.Length - 2)
					{
						string value = keyValuePair.Key.Substring(0, num);
						if (currentActiveGamepadName.StartsWith(value))
						{
							this.SwitchInputControllerType(keyValuePair.Value);
							return true;
						}
					}
				}
				return false;
			}
			else if (Singleton<Platform>.Instance.IsIOSPlatform())
			{
				if (currentActiveGamepadName == "None")
				{
					return false;
				}
				if (currentActiveGamepadName.Contains("Xbox"))
				{
					this.SwitchInputControllerType(EInputControllerType.XboxOne);
					return true;
				}
				if (currentActiveGamepadName.Contains("DualShock"))
				{
					this.SwitchInputControllerType(EInputControllerType.PS5);
					return true;
				}
				if (currentActiveGamepadName.Contains("BackBoneOne"))
				{
					this.SwitchInputControllerType(EInputControllerType.BackBone);
					return true;
				}
				if (currentActiveGamepadName.Contains("nspro"))
				{
					this.SwitchInputControllerType(EInputControllerType.NsPro);
					return true;
				}
				return false;
			}
			else
			{
				if (!Singleton<Platform>.Instance.IsOpenHarmonyPlatform())
				{
					return false;
				}
				if (currentActiveGamepadName == "None")
				{
					return false;
				}
				if (currentActiveGamepadName.Contains("Pro Controller"))
				{
					this.SwitchInputControllerType(EInputControllerType.NsPro);
					return true;
				}
				if (currentActiveGamepadName.Contains("Backbone"))
				{
					this.SwitchInputControllerType(EInputControllerType.BackBone);
					return true;
				}
				if (currentActiveGamepadName.Contains("PS5") || currentActiveGamepadName.Contains("DualSense"))
				{
					this.SwitchInputControllerType(EInputControllerType.PS5);
					return true;
				}
				if (currentActiveGamepadName.Contains("PS4"))
				{
					this.SwitchInputControllerType(EInputControllerType.PS4);
					return true;
				}
				this.SwitchInputControllerType(EInputControllerType.XboxOne);
				return true;
			}
		}

		// Token: 0x0602EDD4 RID: 191956 RVA: 0x00B19354 File Offset: 0x00B17554
		private void SwitchInputControllerType(EInputControllerType inputControllerType)
		{
			this.SetInputControllerType(inputControllerType);
		}

		// Token: 0x0602EDD5 RID: 191957 RVA: 0x00B1935D File Offset: 0x00B1755D
		public void SwitchInputControllerTypeByKey(FKey key)
		{
			if (UKismetInputLibrary.Key_IsGamepadKey(key))
			{
				if (!this.RefreshPlatformByDevice())
				{
					this.SwitchInputControllerType(EInputControllerType.XboxOne);
					return;
				}
			}
			else
			{
				if (UKismetInputLibrary.Key_IsKeyboardKey(key) || UKismetInputLibrary.Key_IsMouseButton(key))
				{
					this.SwitchInputControllerType(EInputControllerType.Keyboard);
					return;
				}
				this.SwitchInputControllerType(EInputControllerType.Touch);
			}
		}

		// Token: 0x0602EDD6 RID: 191958 RVA: 0x00B19399 File Offset: 0x00B17599
		public void SwitchInputControllerTypeByMouseMove()
		{
			this.SwitchInputControllerType(EInputControllerType.Keyboard);
		}

		// Token: 0x0602EDD7 RID: 191959 RVA: 0x00B193A2 File Offset: 0x00B175A2
		public void RegisterInputChangeDelegate(Action<EInputControllerType, EInputControllerType> inputChangeDelegate)
		{
			this.InputChangeDelegateSet.Add(inputChangeDelegate);
		}

		// Token: 0x0602EDD8 RID: 191960 RVA: 0x00B193B1 File Offset: 0x00B175B1
		public void UnRegisterInputChangeDelegate(Action<EInputControllerType, EInputControllerType> inputChangeDelegate)
		{
			this.InputChangeDelegateSet.Remove(inputChangeDelegate);
		}

		// Token: 0x0602EDD9 RID: 191961 RVA: 0x00B193C0 File Offset: 0x00B175C0
		public bool IsInKeyBoard()
		{
			return this.TypeInternal == EInputControllerType.Keyboard;
		}

		// Token: 0x0602EDDA RID: 191962 RVA: 0x00B193CB File Offset: 0x00B175CB
		public bool IsInTouch()
		{
			return this.TypeInternal == EInputControllerType.Touch;
		}

		// Token: 0x0602EDDB RID: 191963 RVA: 0x00B193D6 File Offset: 0x00B175D6
		public bool IsInGamepad()
		{
			return this.IsPsGamepad() || this.IsXboxGamepad() || this.IsBackBoneGamepad() || this.IsNsProGamepad();
		}

		// Token: 0x0602EDDC RID: 191964 RVA: 0x00B193F8 File Offset: 0x00B175F8
		public bool IsPsGamepad()
		{
			return this.TypeInternal == EInputControllerType.PS4 || this.TypeInternal == EInputControllerType.PS5;
		}

		// Token: 0x0602EDDD RID: 191965 RVA: 0x00B1940E File Offset: 0x00B1760E
		public bool IsXboxGamepad()
		{
			return this.TypeInternal == EInputControllerType.XboxOne;
		}

		// Token: 0x0602EDDE RID: 191966 RVA: 0x00B19419 File Offset: 0x00B17619
		public bool IsBackBoneGamepad()
		{
			return this.TypeInternal == EInputControllerType.BackBone;
		}

		// Token: 0x0602EDDF RID: 191967 RVA: 0x00B19424 File Offset: 0x00B17624
		public bool IsNsProGamepad()
		{
			return this.TypeInternal == EInputControllerType.NsPro;
		}

		// Token: 0x0602EDE1 RID: 191969 RVA: 0x00B19444 File Offset: 0x00B17644
		// Note: this type is marked as 'beforefieldinit'.
		static InputDevice()
		{
			Dictionary<string, EInputControllerType> dictionary = new Dictionary<string, EInputControllerType>();
			dictionary["1356_3302"] = EInputControllerType.PS4;
			dictionary["1356_3570"] = EInputControllerType.PS4;
			dictionary["1356_1476"] = EInputControllerType.PS4;
			dictionary["1356_2508"] = EInputControllerType.PS4;
			dictionary["1118_2834"] = EInputControllerType.XboxOne;
			dictionary["1118_2816"] = EInputControllerType.XboxOne;
			dictionary["1118_733"] = EInputControllerType.XboxOne;
			dictionary["1118_736"] = EInputControllerType.XboxOne;
			dictionary["1118_739"] = EInputControllerType.XboxOne;
			dictionary["1118_746"] = EInputControllerType.XboxOne;
			dictionary["1118_765"] = EInputControllerType.XboxOne;
			dictionary["1118_766"] = EInputControllerType.XboxOne;
			dictionary["13706_770"] = EInputControllerType.BackBone;
			dictionary["1406_8201"] = EInputControllerType.NsPro;
			dictionary["5426_*"] = EInputControllerType.XboxOne;
			dictionary["5426_4112"] = EInputControllerType.PS5;
			dictionary["5426_4103"] = EInputControllerType.PS5;
			InputDevice.deviceIdMap = dictionary;
		}

		// Token: 0x0401AAA1 RID: 109217
		public const string DualSenseWirelessController = "1356_3302";

		// Token: 0x0401AAA2 RID: 109218
		public const string DualSenseEdgeWirelessController = "1356_3570";

		// Token: 0x0401AAA3 RID: 109219
		public const string DualShock4_Cuhzct1x = "1356_1476";

		// Token: 0x0401AAA4 RID: 109220
		public const string DualShock4_Cuhzct2x = "1356_2508";

		// Token: 0x0401AAA5 RID: 109221
		public const string XboxController = "1118_2834";

		// Token: 0x0401AAA6 RID: 109222
		public const string XboxEliteSeries2Controller = "1118_2816";

		// Token: 0x0401AAA7 RID: 109223
		public const string XboxOneController2015 = "1118_733";

		// Token: 0x0401AAA8 RID: 109224
		public const string XboxOneWirelessController = "1118_736";

		// Token: 0x0401AAA9 RID: 109225
		public const string XboxOneEliteController = "1118_739";

		// Token: 0x0401AAAA RID: 109226
		public const string XboxOneController = "1118_746";

		// Token: 0x0401AAAB RID: 109227
		public const string XboxOneSController = "1118_765";

		// Token: 0x0401AAAC RID: 109228
		public const string XboxWirelessAdapterForWindows = "1118_766";

		// Token: 0x0401AAAD RID: 109229
		public const string BackboneOne = "13706_770";

		// Token: 0x0401AAAE RID: 109230
		public const string NsPro = "1406_8201";

		// Token: 0x0401AAAF RID: 109231
		public const string RazerDefault = "5426_*";

		// Token: 0x0401AAB0 RID: 109232
		public const string RazerWolverineV2Pro = "5426_4112";

		// Token: 0x0401AAB1 RID: 109233
		public const string RazerRaijuTournament = "5426_4103";

		// Token: 0x0401AAB2 RID: 109234
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<string, EInputControllerType> deviceIdMap;

		// Token: 0x0401AAB3 RID: 109235
		private EInputControllerType TypeInternal;

		// Token: 0x0401AAB4 RID: 109236
		private readonly HashSet<Action<EInputControllerType, EInputControllerType>> InputChangeDelegateSet = new HashSet<Action<EInputControllerType, EInputControllerType>>();
	}
}
