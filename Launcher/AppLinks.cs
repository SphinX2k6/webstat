using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.HotPatchKuroSdk;
using CSharpScript.Launcher.Platform;
using UnrealEngine;

namespace CSharpScript.Launcher
{
	// Token: 0x0200447B RID: 17531
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AppLinks : Singleton<AppLinks>
	{
		// Token: 0x0602E4D4 RID: 189652 RVA: 0x00ADD720 File Offset: 0x00ADB920
		public void Init()
		{
			if (this.Initialized)
			{
				return;
			}
			if (!Singleton<Platform>.Instance.IsMobilePlatform())
			{
				return;
			}
			bool flag = Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN";
			if (Singleton<Platform>.Instance.IsIOSPlatform() && flag)
			{
				UKuroLauncherLibrary.IsFirstIntoLauncher();
				return;
			}
			if (!Singleton<HotPatchKuroSdk>.Instance.CanUseSdk())
			{
				return;
			}
			UKuroSDKManager.Get().OnActivatedByApplinksDelegate.Clear();
			UKuroSDKManager.Get().OnActivatedByApplinksDelegate.Add(delegate(string host, string deepValue, string source)
			{
				Singleton<AppLinks>.Instance.ReportApplinksActivation(host, deepValue, source);
			});
			if (Singleton<Platform>.Instance.IsAndroidPlatform())
			{
				UKuroSDKManager.CheckApplinksActivation();
			}
			else if (Singleton<Platform>.Instance.IsIOSPlatform())
			{
				UKuroLauncherLibrary.IsFirstIntoLauncher();
			}
			this.Initialized = true;
		}

		// Token: 0x0602E4D5 RID: 189653 RVA: 0x00ADD7E8 File Offset: 0x00ADB9E8
		public void Destroy()
		{
			if (!this.Initialized)
			{
				return;
			}
			UKuroSDKManager.Get().OnActivatedByApplinksDelegate.Clear();
			this.DeepValueHandleMap.Clear();
			this.Initialized = false;
		}

		// Token: 0x0602E4D6 RID: 189654 RVA: 0x00ADD814 File Offset: 0x00ADBA14
		public void ReportApplinksActivation(string host, string deepValue, string source)
		{
			if (host == "mc.kurogame.com" || host == "wutheringwaves.kurogame.com")
			{
				Singleton<HotPatchLogReport>.Instance.ReportAppLinksEvent(deepValue, source);
				if (deepValue != "" && this.DeepValueHandleMap.ContainsKey(deepValue))
				{
					this.DeepValueHandleMap[deepValue](deepValue, source);
				}
			}
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 3);
			defaultInterpolatedStringHandler.AppendLiteral("Application Activated By AppLinks: ");
			defaultInterpolatedStringHandler.AppendFormatted(host);
			defaultInterpolatedStringHandler.AppendLiteral(", ");
			defaultInterpolatedStringHandler.AppendFormatted(deepValue);
			defaultInterpolatedStringHandler.AppendLiteral(", ");
			defaultInterpolatedStringHandler.AppendFormatted(source);
			instance.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602E4D7 RID: 189655 RVA: 0x00ADD8D8 File Offset: 0x00ADBAD8
		public void SetDeepValueHandle(string deepValue, Action<string, string> handle)
		{
			if (this.DeepValueHandleMap.ContainsKey(deepValue))
			{
				Singleton<LauncherLog>.Instance.Error("Try to set duplicated handle for deepvalue: " + deepValue, default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.DeepValueHandleMap[deepValue] = handle;
		}

		// Token: 0x0602E4D8 RID: 189656 RVA: 0x00ADD920 File Offset: 0x00ADBB20
		public void RemoveDeepValueHandle(string deepValue)
		{
			if (!this.DeepValueHandleMap.ContainsKey(deepValue))
			{
				Singleton<LauncherLog>.Instance.Error("Can't find handle for deepvalue: " + deepValue, default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.DeepValueHandleMap.Remove(deepValue);
		}

		// Token: 0x0401A43F RID: 107583
		private const string APP_LINKS_HOST = "mc.kurogame.com";

		// Token: 0x0401A440 RID: 107584
		private const string APP_LINKS_HOST_GLOBAL = "wutheringwaves.kurogame.com";

		// Token: 0x0401A441 RID: 107585
		private bool Initialized;

		// Token: 0x0401A442 RID: 107586
		private readonly Dictionary<string, Action<string, string>> DeepValueHandleMap = new Dictionary<string, Action<string, string>>();
	}
}
