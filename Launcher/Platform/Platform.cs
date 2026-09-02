using System;
using System.Runtime.CompilerServices;
using CSharpScript.Typing;
using UnrealEngine;

namespace CSharpScript.Launcher.Platform
{
	// Token: 0x02004554 RID: 17748
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class Platform : Singleton<Platform>
	{
		// Token: 0x1700805D RID: 32861
		// (get) Token: 0x0602EB2B RID: 191275 RVA: 0x00B109C4 File Offset: 0x00B0EBC4
		public EPlatformType Type
		{
			get
			{
				if (!this.IsInitialized)
				{
					Singleton<LauncherLog>.Instance.Debug("[PlatformSdkNew]平台类型未初始化,初始化平台信息", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.Initialize();
				}
				return this.TypeInternal;
			}
		}

		// Token: 0x0602EB2C RID: 191276 RVA: 0x00B109FD File Offset: 0x00B0EBFD
		public bool IsAndroidPlatform()
		{
			return this.Type == EPlatformType.Android;
		}

		// Token: 0x0602EB2D RID: 191277 RVA: 0x00B10A08 File Offset: 0x00B0EC08
		public bool IsIOSPlatform()
		{
			return this.Type == EPlatformType.IOS;
		}

		// Token: 0x0602EB2E RID: 191278 RVA: 0x00B10A13 File Offset: 0x00B0EC13
		public bool IsMacPlatform()
		{
			return this.Type == EPlatformType.Mac;
		}

		// Token: 0x0602EB2F RID: 191279 RVA: 0x00B10A1E File Offset: 0x00B0EC1E
		public bool IsPs5Platform()
		{
			return this.Type == EPlatformType.PS5;
		}

		// Token: 0x0602EB30 RID: 191280 RVA: 0x00B10A29 File Offset: 0x00B0EC29
		public bool IsXSXPlatform()
		{
			return this.Type == EPlatformType.XSX;
		}

		// Token: 0x0602EB31 RID: 191281 RVA: 0x00B10A35 File Offset: 0x00B0EC35
		public bool IsWinGDKPlatform()
		{
			return this.Type == EPlatformType.WinGDK;
		}

		// Token: 0x0602EB32 RID: 191282 RVA: 0x00B10A41 File Offset: 0x00B0EC41
		public bool IsOpenHarmonyPlatform()
		{
			return this.Type == EPlatformType.OpenHarmony;
		}

		// Token: 0x0602EB33 RID: 191283 RVA: 0x00B10A4D File Offset: 0x00B0EC4D
		public bool IsXboxPlatform()
		{
			return this.Type == EPlatformType.XboxOne || this.Type == EPlatformType.XSX || this.Type == EPlatformType.WinGDK;
		}

		// Token: 0x0602EB34 RID: 191284 RVA: 0x00B10A6F File Offset: 0x00B0EC6F
		public bool IsHomeConsolePlatform()
		{
			return this.IsPs5Platform() || this.IsXboxPlatform();
		}

		// Token: 0x0602EB35 RID: 191285 RVA: 0x00B10A81 File Offset: 0x00B0EC81
		public bool IsWindowsPlatform()
		{
			return this.Type == EPlatformType.Windows || this.IsWinGDKPlatform();
		}

		// Token: 0x0602EB36 RID: 191286 RVA: 0x00B10A94 File Offset: 0x00B0EC94
		public bool IsWindowsOnlyPlatform()
		{
			return this.Type == EPlatformType.Windows;
		}

		// Token: 0x0602EB37 RID: 191287 RVA: 0x00B10A9F File Offset: 0x00B0EC9F
		public bool IsPcOrGamepadPlatform()
		{
			return this.IsPcPlatform() || this.IsGamepadPlatform();
		}

		// Token: 0x0602EB38 RID: 191288 RVA: 0x00B10AB1 File Offset: 0x00B0ECB1
		public bool IsPcPlatform()
		{
			return this.Type == EPlatformType.Windows || this.Type == EPlatformType.Mac || this.Type == EPlatformType.Linux || this.Type == EPlatformType.WinGDK;
		}

		// Token: 0x0602EB39 RID: 191289 RVA: 0x00B10ADA File Offset: 0x00B0ECDA
		public bool IsMobilePlatform()
		{
			return this.Type == EPlatformType.IOS || this.Type == EPlatformType.Android || this.Type == EPlatformType.OpenHarmony;
		}

		// Token: 0x1700805E RID: 32862
		// (set) Token: 0x0602EB3A RID: 191290 RVA: 0x00B10AFA File Offset: 0x00B0ECFA
		public bool IsFakeCloudGame
		{
			set
			{
				this.IsFakeCloudGameInternal = value;
			}
		}

		// Token: 0x0602EB3B RID: 191291 RVA: 0x00B10B03 File Offset: 0x00B0ED03
		public bool IsCloudGame()
		{
			return this.IsFakeCloudGameInternal || this.IsCloudGameInternal;
		}

		// Token: 0x0602EB3C RID: 191292 RVA: 0x00B10B15 File Offset: 0x00B0ED15
		public bool IsCloudGameRunningHotPatch()
		{
			return this.IsCloudGameHotPatch;
		}

		// Token: 0x1700805F RID: 32863
		// (get) Token: 0x0602EB3D RID: 191293 RVA: 0x00B10B1D File Offset: 0x00B0ED1D
		// (set) Token: 0x0602EB3E RID: 191294 RVA: 0x00B10B34 File Offset: 0x00B0ED34
		public string CloudGamePlatform
		{
			get
			{
				if (this.IsFakeCloudGameInternal)
				{
					return ECloudGamePlatform.Windows.ToEnumString();
				}
				return this.CloudGamePlatformInternal;
			}
			set
			{
				this.CloudGamePlatformInternal = value;
			}
		}

		// Token: 0x0602EB3F RID: 191295 RVA: 0x00B10B3D File Offset: 0x00B0ED3D
		public bool IsHuaWeiDevice()
		{
			return UKuroStaticLibrary.GetVendorInfo().ToUpper().Contains("HUAWEI");
		}

		// Token: 0x0602EB40 RID: 191296 RVA: 0x00B10B53 File Offset: 0x00B0ED53
		public bool IsHonorDevice()
		{
			return UKuroStaticLibrary.GetVendorInfo().ToUpper().Contains("HONOR");
		}

		// Token: 0x0602EB41 RID: 191297 RVA: 0x00B10B6C File Offset: 0x00B0ED6C
		public bool IsRedMagicDeviceLow()
		{
			string mobileDeviceModel = UKuroRenderingRuntimeBPPluginBPLibrary.GetMobileDeviceModel();
			return mobileDeviceModel.Contains("NX789J") || mobileDeviceModel.Contains("NP05J") || mobileDeviceModel.Contains("NX799J") || mobileDeviceModel.Contains("NX809J") || mobileDeviceModel.Contains("NP06J");
		}

		// Token: 0x0602EB42 RID: 191298 RVA: 0x00B10BC0 File Offset: 0x00B0EDC0
		public bool IsRedMagicDeviceHigh()
		{
			return false;
		}

		// Token: 0x0602EB43 RID: 191299 RVA: 0x00B10BC3 File Offset: 0x00B0EDC3
		public bool IsRedMagicDevice()
		{
			return this.IsRedMagicDeviceLow() || this.IsRedMagicDeviceHigh();
		}

		// Token: 0x0602EB44 RID: 191300 RVA: 0x00B10BD8 File Offset: 0x00B0EDD8
		public bool IsFoldingScreen()
		{
			FVector2D androidRawResolution = UKuroRenderingRuntimeBPPluginBPLibrary.GetAndroidRawResolution();
			float num = androidRawResolution.X / androidRawResolution.Y;
			if ((double)num < 1.8 || (double)num > 2.6)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "折叠屏适配";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ScreenRatio", num);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return true;
			}
			return false;
		}

		// Token: 0x0602EB45 RID: 191301 RVA: 0x00B10C3E File Offset: 0x00B0EE3E
		public bool IsGamepadPlatform()
		{
			return this.Type == EPlatformType.XboxOne || this.Type == EPlatformType.XSX || this.Type == EPlatformType.PS4 || this.Type == EPlatformType.PS5;
		}

		// Token: 0x0602EB46 RID: 191302 RVA: 0x00B10C68 File Offset: 0x00B0EE68
		private unsafe void Initialize()
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
									this.TypeInternal = EPlatformType.PS5;
									goto IL_1E7;
								}
							}
						}
						else if (text == "PS4")
						{
							this.TypeInternal = EPlatformType.PS4;
							goto IL_1E7;
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
									this.TypeInternal = EPlatformType.Mac;
									goto IL_1E7;
								}
							}
						}
						else if (text == "XSX")
						{
							this.TypeInternal = EPlatformType.XSX;
							goto IL_1E7;
						}
					}
					else if (text == "IOS")
					{
						this.TypeInternal = EPlatformType.IOS;
						goto IL_1E7;
					}
					break;
				}
				case 5:
					if (text == "Linux")
					{
						this.TypeInternal = EPlatformType.Linux;
						goto IL_1E7;
					}
					break;
				case 6:
					if (text == "WinGDK")
					{
						this.TypeInternal = EPlatformType.WinGDK;
						goto IL_1E7;
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
									this.TypeInternal = EPlatformType.XboxOne;
									goto IL_1E7;
								}
							}
						}
						else if (text == "Windows")
						{
							this.TypeInternal = EPlatformType.Windows;
							goto IL_1E7;
						}
					}
					else if (text == "Android")
					{
						this.TypeInternal = EPlatformType.Android;
						goto IL_1E7;
					}
					break;
				}
				case 11:
					if (text == "OpenHarmony")
					{
						this.TypeInternal = EPlatformType.OpenHarmony;
						goto IL_1E7;
					}
					break;
				}
			}
			this.TypeInternal = EPlatformType.None;
			IL_1E7:
			string commandLine = UKismetSystemLibrary.GetCommandLine();
			this.IsCloudGameInternal = commandLine.Contains("-CloudGame");
			this.IsCloudGameHotPatch = commandLine.Contains("-CloudGameHotPatch");
			this.IsInitialized = true;
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[PlatformSdkNew]初始化平台类型";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlatformType", this.TypeInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CloudGame", this.IsCloudGameInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CloudGameHotPatch", this.IsCloudGameHotPatch);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x0602EB47 RID: 191303 RVA: 0x00B10F10 File Offset: 0x00B0F110
		public bool CheckAssetPlatformInclude(string platFormTag)
		{
			return UKuroActorSubsystem.CheckAssetPlatformInclude(platFormTag);
		}

		// Token: 0x0401A882 RID: 108674
		private bool IsInitialized;

		// Token: 0x0401A883 RID: 108675
		private EPlatformType TypeInternal;

		// Token: 0x0401A884 RID: 108676
		private bool IsCloudGameInternal;

		// Token: 0x0401A885 RID: 108677
		private bool IsCloudGameHotPatch;

		// Token: 0x0401A886 RID: 108678
		private string CloudGamePlatformInternal = "";

		// Token: 0x0401A887 RID: 108679
		private bool IsFakeCloudGameInternal;
	}
}
