using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Platform;
using CSharpScript.Typing;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Core.Common
{
	// Token: 0x0200714C RID: 29004
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class Info : Singleton<Info>
	{
		// Token: 0x1700A5FE RID: 42494
		// (get) Token: 0x0604636C RID: 287596 RVA: 0x01271193 File Offset: 0x0126F393
		public UGameInstance GameInstance
		{
			get
			{
				return this.GameInstanceInternal;
			}
		}

		// Token: 0x1700A5FF RID: 42495
		// (get) Token: 0x0604636D RID: 287597 RVA: 0x0127119B File Offset: 0x0126F39B
		[Nullable(2)]
		public UWorld World
		{
			[NullableContext(2)]
			get
			{
				UGameInstance gameInstanceInternal = this.GameInstanceInternal;
				return ((gameInstanceInternal != null) ? gameInstanceInternal.GetWorld() : null) ?? null;
			}
		}

		// Token: 0x0604636E RID: 287598 RVA: 0x012711B4 File Offset: 0x0126F3B4
		public void Initialize(UGameInstance gameInstance)
		{
			this.GameInstanceInternal = gameInstance;
			this.Environment = EEnvironment.UE4;
			this.IsInEditor = UKuroStaticLibrary.IsEditor(gameInstance);
			this.IsShipping = KuroApplication.IsBuildShipping();
			this.IsTest = KuroApplication.IsBuildTest();
			this.IsDevelopmentOrDebug = (!this.IsShipping && !this.IsTest);
			this.IsLowMemoryDeviceInternal = UKuroStaticLibrary.IsLowMemoryDevice();
			this.IsInCgInternal = (this.IsInEditor && UKuroRenderingRuntimeBPPluginBPLibrary.GetCVarFloat("r.Kuro.Movie.EnableCGMovieRendering") > 0f);
			this.IsInSimulateInEditorInternal = false;
			this.InitializePlatformType();
			this.InitCloudGame(Singleton<Platform>.Instance.CloudGamePlatform);
		}

		// Token: 0x1700A600 RID: 42496
		// (get) Token: 0x0604636F RID: 287599 RVA: 0x01271255 File Offset: 0x0126F455
		public bool IsPlayInEditor
		{
			get
			{
				return this.IsInEditor;
			}
		}

		// Token: 0x1700A601 RID: 42497
		// (get) Token: 0x06046370 RID: 287600 RVA: 0x0127125D File Offset: 0x0126F45D
		public bool IsBuildShipping
		{
			get
			{
				return this.IsShipping;
			}
		}

		// Token: 0x1700A602 RID: 42498
		// (get) Token: 0x06046371 RID: 287601 RVA: 0x01271265 File Offset: 0x0126F465
		public bool IsBuildTest
		{
			get
			{
				return this.IsTest;
			}
		}

		// Token: 0x1700A603 RID: 42499
		// (get) Token: 0x06046372 RID: 287602 RVA: 0x0127126D File Offset: 0x0126F46D
		public bool IsBuildDevelopmentOrDebug
		{
			get
			{
				return this.IsDevelopmentOrDebug;
			}
		}

		// Token: 0x06046373 RID: 287603 RVA: 0x01271275 File Offset: 0x0126F475
		public bool IsGameRunning()
		{
			return this.Environment == EEnvironment.UE4;
		}

		// Token: 0x06046374 RID: 287604 RVA: 0x01271280 File Offset: 0x0126F480
		public bool IsInCg()
		{
			return this.IsInCgInternal;
		}

		// Token: 0x06046375 RID: 287605 RVA: 0x01271288 File Offset: 0x0126F488
		public void SetInCg(bool value)
		{
			if (this.IsInCgInternal != value)
			{
				this.IsInCgInternal = value;
				UKuroEffectSystemFunctionLibrary.OnIsInEditorTickChange(this.IsInEditorTick());
			}
		}

		// Token: 0x06046376 RID: 287606 RVA: 0x012712A5 File Offset: 0x0126F4A5
		public bool IsInEditorTick()
		{
			return this.IsInSimulateInEditorInternal || this.IsInCgInternal;
		}

		// Token: 0x1700A604 RID: 42500
		// (get) Token: 0x06046377 RID: 287607 RVA: 0x012712B7 File Offset: 0x0126F4B7
		public bool IsLowMemoryDevice
		{
			get
			{
				return this.IsLowMemoryDeviceInternal;
			}
		}

		// Token: 0x1700A605 RID: 42501
		// (get) Token: 0x06046378 RID: 287608 RVA: 0x012712BF File Offset: 0x0126F4BF
		public ESourcePlatformType PlatformType
		{
			get
			{
				return this.PlatformTypeInternal;
			}
		}

		// Token: 0x1700A606 RID: 42502
		// (get) Token: 0x06046379 RID: 287609 RVA: 0x012712C7 File Offset: 0x0126F4C7
		public EInputControllerType InputControllerType
		{
			get
			{
				return this.InputControllerTypeInternal;
			}
		}

		// Token: 0x1700A607 RID: 42503
		// (get) Token: 0x0604637A RID: 287610 RVA: 0x012712CF File Offset: 0x0126F4CF
		// (set) Token: 0x0604637B RID: 287611 RVA: 0x012712D7 File Offset: 0x0126F4D7
		public EInputControllerMainType InputControllerMainType
		{
			get
			{
				return this.InputControllerMainTypeInternal;
			}
			set
			{
				if (UKuroVariableFunctionLibrary.HasIntValue("InputControllerMainType"))
				{
					UKuroVariableFunctionLibrary.RemoveIntValue("InputControllerMainType");
				}
				UKuroVariableFunctionLibrary.SetIntValue("InputControllerMainType", (int)value);
				this.InputControllerMainTypeInternal = value;
			}
		}

		// Token: 0x1700A608 RID: 42504
		// (get) Token: 0x0604637C RID: 287612 RVA: 0x01271303 File Offset: 0x0126F503
		public EOperationType OperationType
		{
			get
			{
				return this.OperationTypeInternal;
			}
		}

		// Token: 0x0604637D RID: 287613 RVA: 0x0127130C File Offset: 0x0126F50C
		private void InitializePlatformType()
		{
			string text = KuroApplication.IniPlatformName();
			if (text != null)
			{
				switch (text.Length)
				{
				case 3:
				{
					char c = text[2];
					if (c <= '5')
					{
						if (c != '4')
						{
							if (c == '5')
							{
								if (text == "PS5")
								{
									this.PlatformTypeInternal = ESourcePlatformType.PS5;
									goto IL_1E8;
								}
							}
						}
						else if (text == "PS4")
						{
							this.PlatformTypeInternal = ESourcePlatformType.PS4;
							goto IL_1E8;
						}
					}
					else if (c != 'S')
					{
						if (c != 'X')
						{
							if (c == 'c')
							{
								if (text == "Mac")
								{
									this.PlatformTypeInternal = ESourcePlatformType.Mac;
									goto IL_1E8;
								}
							}
						}
						else if (text == "XSX")
						{
							this.PlatformTypeInternal = ESourcePlatformType.XSX;
							goto IL_1E8;
						}
					}
					else if (text == "IOS")
					{
						this.PlatformTypeInternal = ESourcePlatformType.IOS;
						goto IL_1E8;
					}
					break;
				}
				case 5:
					if (text == "Linux")
					{
						this.PlatformTypeInternal = ESourcePlatformType.Linux;
						goto IL_1E8;
					}
					break;
				case 6:
					if (text == "WinGDK")
					{
						this.PlatformTypeInternal = ESourcePlatformType.WinGDK;
						goto IL_1E8;
					}
					break;
				case 7:
				{
					char c = text[0];
					if (c != 'A')
					{
						if (c != 'W')
						{
							if (c == 'X')
							{
								if (text == "XboxOne")
								{
									this.PlatformTypeInternal = ESourcePlatformType.XboxOne;
									goto IL_1E8;
								}
							}
						}
						else if (text == "Windows")
						{
							this.PlatformTypeInternal = ESourcePlatformType.Windows;
							goto IL_1E8;
						}
					}
					else if (text == "Android")
					{
						this.PlatformTypeInternal = ESourcePlatformType.Android;
						goto IL_1E8;
					}
					break;
				}
				case 11:
					if (text == "OpenHarmony")
					{
						this.PlatformTypeInternal = ESourcePlatformType.OpenHarmony;
						goto IL_1E8;
					}
					break;
				}
			}
			this.PlatformTypeInternal = ESourcePlatformType.None;
			IL_1E8:
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Platform;
			ELogAuthor author = ELogAuthor.WY;
			string message = "初始化平台类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlatformType", this.PlatformTypeInternal);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			EInputControllerType inputControllerType;
			if (InfoDefine.DefaultPlatformAndInputControllerMap.TryGetValue(this.PlatformTypeInternal, out inputControllerType))
			{
				this.SwitchInputControllerType(inputControllerType, "InitializePlatformType");
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Platform;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "找不到平台默认对应的输入类型";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PlatformType", this.PlatformTypeInternal);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}

		// Token: 0x0604637E RID: 287614 RVA: 0x0127158C File Offset: 0x0126F78C
		private void InitCloudGame(string platform)
		{
			if (!Singleton<Platform>.Instance.IsCloudGame())
			{
				return;
			}
			if (platform == ECloudGamePlatform.Android.ToEnumString() || platform == ECloudGamePlatform.IOS.ToEnumString())
			{
				this.SwitchInputControllerType(EInputControllerType.Touch, "InitCloudGame Mobile");
				return;
			}
			if (platform == ECloudGamePlatform.Mac.ToEnumString() || platform == ECloudGamePlatform.Windows.ToEnumString())
			{
				this.SwitchInputControllerType(EInputControllerType.Keyboard, "InitCloudGame Desktop");
			}
		}

		// Token: 0x0604637F RID: 287615 RVA: 0x012715F8 File Offset: 0x0126F7F8
		public unsafe void SetInputControllerType(EInputControllerType inputController, string reason)
		{
			if (this.InputControllerTypeInternal == inputController)
			{
				return;
			}
			if (inputController == EInputControllerType.Keyboard && this.InputControllerTypeInternal == EInputControllerType.Touch)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Platform;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[PlatformDebug]从Touch输入方式切换成了键鼠的输入方式";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("lastInputController", this.InputControllerTypeInternal);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("inputController", inputController);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			EInputControllerType inputControllerTypeInternal = this.InputControllerTypeInternal;
			this.InputControllerTypeInternal = inputController;
			this.SetInputControllerMainType();
			TInputTypeChange inputTypeChangeFunc = this.InputTypeChangeFunc;
			if (inputTypeChangeFunc != null)
			{
				inputTypeChangeFunc(inputControllerTypeInternal, this.InputControllerTypeInternal);
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Platform;
			ELogAuthor author2 = ELogAuthor.TL;
			string message2 = "设置输入方式";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("lastInputController", inputControllerTypeInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("InputController", this.InputControllerTypeInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Reason", reason);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}

		// Token: 0x06046380 RID: 287616 RVA: 0x0127172C File Offset: 0x0126F92C
		private void SetShowType(EInputControllerType inputController)
		{
			EOperationType eoperationType = InfoDefine.ShowTypeAndInputControllerMap[inputController];
			if (eoperationType == this.OperationTypeInternal)
			{
				return;
			}
			EOperationType operationTypeInternal = this.OperationTypeInternal;
			this.OperationTypeInternal = eoperationType;
			TShowTypeChange showTypeChangeFunc = this.ShowTypeChangeFunc;
			if (showTypeChangeFunc == null)
			{
				return;
			}
			showTypeChangeFunc(operationTypeInternal, eoperationType);
		}

		// Token: 0x06046381 RID: 287617 RVA: 0x01271770 File Offset: 0x0126F970
		private void SetInputControllerMainType()
		{
			EInputControllerMainType einputControllerMainType = InfoDefine.InputControllerMainTypeMap[this.InputControllerTypeInternal];
			if (einputControllerMainType == this.InputControllerMainTypeInternal)
			{
				return;
			}
			EInputControllerMainType inputControllerMainTypeInternal = this.InputControllerMainTypeInternal;
			this.InputControllerMainType = einputControllerMainType;
			TInputMainTypeChange inputMainTypeChangeFunc = this.InputMainTypeChangeFunc;
			if (inputMainTypeChangeFunc == null)
			{
				return;
			}
			inputMainTypeChangeFunc(inputControllerMainTypeInternal, einputControllerMainType);
		}

		// Token: 0x06046382 RID: 287618 RVA: 0x012717B8 File Offset: 0x0126F9B8
		public bool IsPcOrGamepadPlatform()
		{
			return this.IsPcPlatform() || this.IsGamepadPlatform();
		}

		// Token: 0x06046383 RID: 287619 RVA: 0x012717CA File Offset: 0x0126F9CA
		public bool IsPcPlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.Windows || this.PlatformTypeInternal == ESourcePlatformType.Mac || this.PlatformTypeInternal == ESourcePlatformType.Linux || this.PlatformTypeInternal == ESourcePlatformType.WinGDK;
		}

		// Token: 0x06046384 RID: 287620 RVA: 0x012717F3 File Offset: 0x0126F9F3
		public bool IsXboxPlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.XboxOne || this.PlatformTypeInternal == ESourcePlatformType.XSX || this.PlatformTypeInternal == ESourcePlatformType.WinGDK;
		}

		// Token: 0x06046385 RID: 287621 RVA: 0x01271814 File Offset: 0x0126FA14
		public bool IsXSXPlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.XSX;
		}

		// Token: 0x06046386 RID: 287622 RVA: 0x01271820 File Offset: 0x0126FA20
		public bool IsWinGDKPlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.WinGDK;
		}

		// Token: 0x06046387 RID: 287623 RVA: 0x0127182C File Offset: 0x0126FA2C
		public bool IsHomeConsolePlatform()
		{
			return this.IsPs5Platform() || this.IsXboxPlatform();
		}

		// Token: 0x06046388 RID: 287624 RVA: 0x0127183E File Offset: 0x0126FA3E
		public bool IsMobilePlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.IOS || this.PlatformTypeInternal == ESourcePlatformType.Android || this.PlatformTypeInternal == ESourcePlatformType.OpenHarmony;
		}

		// Token: 0x06046389 RID: 287625 RVA: 0x0127185E File Offset: 0x0126FA5E
		public bool IsIosPlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.IOS;
		}

		// Token: 0x0604638A RID: 287626 RVA: 0x01271869 File Offset: 0x0126FA69
		public bool IsGamepadPlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.XboxOne || this.PlatformTypeInternal == ESourcePlatformType.XSX || this.PlatformTypeInternal == ESourcePlatformType.PS4 || this.PlatformTypeInternal == ESourcePlatformType.PS5;
		}

		// Token: 0x0604638B RID: 287627 RVA: 0x01271892 File Offset: 0x0126FA92
		public bool IsPs5Platform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.PS5;
		}

		// Token: 0x0604638C RID: 287628 RVA: 0x0127189D File Offset: 0x0126FA9D
		public bool IsMacPlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.Mac;
		}

		// Token: 0x0604638D RID: 287629 RVA: 0x012718A8 File Offset: 0x0126FAA8
		public bool IsWindowsPlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.Windows || this.IsWinGDKPlatform();
		}

		// Token: 0x0604638E RID: 287630 RVA: 0x012718BB File Offset: 0x0126FABB
		public bool IsWindowsOnlyPlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.Windows;
		}

		// Token: 0x0604638F RID: 287631 RVA: 0x012718C6 File Offset: 0x0126FAC6
		public bool IsAndroidPlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.Android;
		}

		// Token: 0x06046390 RID: 287632 RVA: 0x012718D1 File Offset: 0x0126FAD1
		public bool IsOpenHarmonyPlatform()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.OpenHarmony;
		}

		// Token: 0x06046391 RID: 287633 RVA: 0x012718DD File Offset: 0x0126FADD
		public bool IsInKeyBoard()
		{
			return this.InputControllerMainType == EInputControllerMainType.Keyboard;
		}

		// Token: 0x06046392 RID: 287634 RVA: 0x012718E8 File Offset: 0x0126FAE8
		public bool IsInTouch()
		{
			return this.InputControllerMainType == EInputControllerMainType.Touch;
		}

		// Token: 0x06046393 RID: 287635 RVA: 0x012718F3 File Offset: 0x0126FAF3
		public bool IsInGamepad()
		{
			return this.InputControllerMainType == EInputControllerMainType.Gamepad;
		}

		// Token: 0x06046394 RID: 287636 RVA: 0x012718FE File Offset: 0x0126FAFE
		public bool IsXboxGamepad()
		{
			return this.IsInGamepad() && this.InputControllerType == EInputControllerType.XboxOne;
		}

		// Token: 0x06046395 RID: 287637 RVA: 0x01271913 File Offset: 0x0126FB13
		public bool IsPsGamepad()
		{
			return this.IsInGamepad() && (this.InputControllerType == EInputControllerType.PS4 || this.InputControllerType == EInputControllerType.PS5);
		}

		// Token: 0x06046396 RID: 287638 RVA: 0x01271933 File Offset: 0x0126FB33
		public bool IsBackBoneGamepad()
		{
			return this.IsInGamepad() && this.InputControllerType == EInputControllerType.BackBone;
		}

		// Token: 0x06046397 RID: 287639 RVA: 0x01271948 File Offset: 0x0126FB48
		public bool IsNsProGamepad()
		{
			return this.IsInGamepad() && this.InputControllerType == EInputControllerType.NsPro;
		}

		// Token: 0x06046398 RID: 287640 RVA: 0x0127195D File Offset: 0x0126FB5D
		public bool CheckIsBackBoneGamepad(EInputControllerType type)
		{
			return type == EInputControllerType.BackBone;
		}

		// Token: 0x06046399 RID: 287641 RVA: 0x01271963 File Offset: 0x0126FB63
		public bool CheckIsNsProGamepad(EInputControllerType type)
		{
			return type == EInputControllerType.NsPro;
		}

		// Token: 0x0604639A RID: 287642 RVA: 0x01271969 File Offset: 0x0126FB69
		public bool CheckIsPsGamepad(EInputControllerType type)
		{
			return type == EInputControllerType.PS4 || type == EInputControllerType.PS5;
		}

		// Token: 0x0604639B RID: 287643 RVA: 0x01271978 File Offset: 0x0126FB78
		public bool IsMobileInputModel()
		{
			return this.IsMobilePlatform() || (this.PlatformTypeInternal == ESourcePlatformType.Windows && Singleton<Platform>.Instance.IsCloudGame() && (Singleton<Platform>.Instance.CloudGamePlatform == ECloudGamePlatform.Android.ToEnumString() || Singleton<Platform>.Instance.CloudGamePlatform == ECloudGamePlatform.IOS.ToEnumString()));
		}

		// Token: 0x0604639C RID: 287644 RVA: 0x012719D8 File Offset: 0x0126FBD8
		public bool IsPcInputModel()
		{
			return this.PlatformTypeInternal == ESourcePlatformType.Mac || this.PlatformTypeInternal == ESourcePlatformType.Linux || this.PlatformTypeInternal == ESourcePlatformType.WinGDK || (this.PlatformTypeInternal == ESourcePlatformType.Windows && (!Singleton<Platform>.Instance.IsCloudGame() || !(Singleton<Platform>.Instance.CloudGamePlatform != ECloudGamePlatform.Mac.ToEnumString()) || !(Singleton<Platform>.Instance.CloudGamePlatform != ECloudGamePlatform.Windows.ToEnumString())));
		}

		// Token: 0x0604639D RID: 287645 RVA: 0x01271A4C File Offset: 0x0126FC4C
		public void SwitchInputControllerType(EInputControllerType inputControllerType, string reason)
		{
			if (inputControllerType == EInputControllerType.None)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Platform;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "传入了EInputControllerType.None类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.IsGmLockGamepad)
			{
				return;
			}
			if (this.IsMobileInputModel() && inputControllerType == EInputControllerType.Keyboard)
			{
				return;
			}
			if (this.IsPcInputModel() && inputControllerType == EInputControllerType.Touch)
			{
				return;
			}
			this.SetInputControllerType(inputControllerType, reason);
			this.SetShowType(inputControllerType);
		}

		// Token: 0x0604639E RID: 287646 RVA: 0x01271ABC File Offset: 0x0126FCBC
		[Conditional("DEBUG")]
		public void GmSwitchInputControllerType(EInputControllerType inputControllerType, string reason)
		{
			if (inputControllerType == EInputControllerType.None)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Platform;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "传入了EInputControllerType.None类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.IsGmLockGamepad)
			{
				return;
			}
			this.SetInputControllerType(inputControllerType, reason);
			this.SetShowType(inputControllerType);
		}

		// Token: 0x0604639F RID: 287647 RVA: 0x01271B0F File Offset: 0x0126FD0F
		public void SetInputTypeChangeFunc(TInputTypeChange func)
		{
			this.InputTypeChangeFunc = func;
		}

		// Token: 0x060463A0 RID: 287648 RVA: 0x01271B18 File Offset: 0x0126FD18
		public void ClearInputTypeChangeFunc()
		{
			this.InputTypeChangeFunc = null;
		}

		// Token: 0x060463A1 RID: 287649 RVA: 0x01271B21 File Offset: 0x0126FD21
		public void SetShowTypeChangeFunc(TShowTypeChange func)
		{
			this.ShowTypeChangeFunc = func;
		}

		// Token: 0x060463A2 RID: 287650 RVA: 0x01271B2A File Offset: 0x0126FD2A
		public void ClearShowTypeChangeFunc()
		{
			this.ShowTypeChangeFunc = null;
		}

		// Token: 0x060463A3 RID: 287651 RVA: 0x01271B33 File Offset: 0x0126FD33
		public void SetInputMainTypeChangeFunc(TInputMainTypeChange func)
		{
			this.InputMainTypeChangeFunc = func;
		}

		// Token: 0x060463A4 RID: 287652 RVA: 0x01271B3C File Offset: 0x0126FD3C
		public void ClearInputMainTypeChangeFunc()
		{
			this.InputMainTypeChangeFunc = null;
		}

		// Token: 0x040275C2 RID: 161218
		private UGameInstance GameInstanceInternal;

		// Token: 0x040275C3 RID: 161219
		public readonly string Version = "1.0.0";

		// Token: 0x040275C4 RID: 161220
		public EEnvironment Environment;

		// Token: 0x040275C5 RID: 161221
		public readonly bool EnableForceTick;

		// Token: 0x040275C6 RID: 161222
		private bool IsInEditor = true;

		// Token: 0x040275C7 RID: 161223
		private bool IsShipping = true;

		// Token: 0x040275C8 RID: 161224
		private bool IsTest;

		// Token: 0x040275C9 RID: 161225
		private bool IsDevelopmentOrDebug;

		// Token: 0x040275CA RID: 161226
		private bool IsInCgInternal;

		// Token: 0x040275CB RID: 161227
		public bool UseFastInputCallback = true;

		// Token: 0x040275CC RID: 161228
		public bool AxisInputOptimize = true;

		// Token: 0x040275CD RID: 161229
		private bool IsInSimulateInEditorInternal;

		// Token: 0x040275CE RID: 161230
		private bool IsLowMemoryDeviceInternal;

		// Token: 0x040275CF RID: 161231
		private ESourcePlatformType PlatformTypeInternal;

		// Token: 0x040275D0 RID: 161232
		private EInputControllerType InputControllerTypeInternal;

		// Token: 0x040275D1 RID: 161233
		private EInputControllerMainType InputControllerMainTypeInternal;

		// Token: 0x040275D2 RID: 161234
		private EOperationType OperationTypeInternal;

		// Token: 0x040275D3 RID: 161235
		public bool IsGmLockGamepad;

		// Token: 0x040275D4 RID: 161236
		[Nullable(2)]
		private TInputTypeChange InputTypeChangeFunc;

		// Token: 0x040275D5 RID: 161237
		[Nullable(2)]
		private TShowTypeChange ShowTypeChangeFunc;

		// Token: 0x040275D6 RID: 161238
		[Nullable(2)]
		private TInputMainTypeChange InputMainTypeChangeFunc;
	}
}
