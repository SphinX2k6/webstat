using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform.PlatformSdk;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004601 RID: 17921
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class HotPatchKuroSdk : Singleton<HotPatchKuroSdk>
	{
		// Token: 0x0602EE14 RID: 192020 RVA: 0x00B1A2A0 File Offset: 0x00B184A0
		public bool GetIfGlobalSdk()
		{
			return Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN";
		}

		// Token: 0x0602EE15 RID: 192021 RVA: 0x00B1A2BB File Offset: 0x00B184BB
		public bool CanUseSdk()
		{
			return UKuroStaticLibrary.IsModuleLoaded("KuroSDK") && Singleton<BaseConfigController>.Instance.GetPublicValue("UseSDK") == "1";
		}

		// Token: 0x0602EE16 RID: 192022 RVA: 0x00B1A2E8 File Offset: 0x00B184E8
		public void Init()
		{
			LauncherSdk.Init();
			if (!this.CanUseSdk())
			{
				HotPatchKuroTdm.Init();
				return;
			}
			UniTaskCompletionSource tcs = new UniTaskCompletionSource();
			this.InitPromise = tcs;
			if (UKuroLauncherLibrary.IsFirstIntoLauncher())
			{
				this.InitSdk(delegate
				{
					tcs.TrySetResult();
				});
				this.ReportEvent(HotPatchReportData.CreateData(ESdkHotPatchReportEnum.Logo, null));
				return;
			}
			tcs.TrySetResult();
		}

		// Token: 0x0602EE17 RID: 192023 RVA: 0x00B1A358 File Offset: 0x00B18558
		private void InitSdk(Action resolve)
		{
			if (!this.CanUseSdk())
			{
				Action resolve2 = resolve;
				if (resolve2 == null)
				{
					return;
				}
				resolve2();
				return;
			}
			else
			{
				UKuroSDKManager.Start();
				if (!UKuroSDKManager.GetSdkInitState())
				{
					Action<bool> cb = null;
					cb = delegate(bool result)
					{
						UKuroSDKManager.Get().InitDelegate.Remove(cb);
						Singleton<LauncherLog>.Instance.Debug("SDK初始化完成", default(ReadOnlySpan<ValueTuple<string, object>>));
						HotPatchKuroTdm.Init();
						Action resolve4 = resolve;
						if (resolve4 == null)
						{
							return;
						}
						resolve4();
					};
					UKuroSDKManager.Get().InitDelegate.Add(cb);
					UKuroSDKManager.DoInitSdkProcedure();
					UKuroSDKManager.Get().ExitDelegate.Clear();
					UKuroSDKManager.Get().ExitDelegate.Add(delegate()
					{
						Singleton<LauncherLog>.Instance.Debug("HotPatchKuroSdk KuroSDKManager.Get()!.ExitDelegate Call", default(ReadOnlySpan<ValueTuple<string, object>>));
						KuroApplication.ExitWithReason(false, "SDK");
					});
					return;
				}
				Singleton<LauncherLog>.Instance.Info("SDK初始化已完成，无需再次初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				HotPatchKuroTdm.Init();
				Action resolve3 = resolve;
				if (resolve3 == null)
				{
					return;
				}
				resolve3();
				return;
			}
		}

		// Token: 0x0602EE18 RID: 192024 RVA: 0x00B1A436 File Offset: 0x00B18636
		[NullableContext(2)]
		public void ReportEvent(SdkReportData data)
		{
			if (data == null)
			{
				return;
			}
			if (!this.CanUseSdk())
			{
				return;
			}
			this.PushReportMsgTrySendReport(data);
		}

		// Token: 0x0602EE19 RID: 192025 RVA: 0x00B1A450 File Offset: 0x00B18650
		private UniTask PushReportMsgTrySendReport(SdkReportData reportData)
		{
			HotPatchKuroSdk.<PushReportMsgTrySendReport>d__7 <PushReportMsgTrySendReport>d__;
			<PushReportMsgTrySendReport>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PushReportMsgTrySendReport>d__.<>4__this = this;
			<PushReportMsgTrySendReport>d__.reportData = reportData;
			<PushReportMsgTrySendReport>d__.<>1__state = -1;
			<PushReportMsgTrySendReport>d__.<>t__builder.Start<HotPatchKuroSdk.<PushReportMsgTrySendReport>d__7>(ref <PushReportMsgTrySendReport>d__);
			return <PushReportMsgTrySendReport>d__.<>t__builder.Task;
		}

		// Token: 0x0602EE1A RID: 192026 RVA: 0x00B1A49B File Offset: 0x00B1869B
		public string GetChannelId()
		{
			if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
			{
				return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetChannelId();
			}
			if (!this.CanUseSdk())
			{
				return "";
			}
			return UKuroSDKManager.GetChannelId();
		}

		// Token: 0x0602EE1B RID: 192027 RVA: 0x00B1A4CC File Offset: 0x00B186CC
		public string GetPackageId()
		{
			if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
			{
				return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetPackageId();
			}
			if (!this.CanUseSdk())
			{
				return "";
			}
			return UKuroSDKManager.GetPackageId();
		}

		// Token: 0x0401AACB RID: 109259
		private const string USESDK = "1";

		// Token: 0x0401AACC RID: 109260
		[Nullable(2)]
		private UniTaskCompletionSource InitPromise;
	}
}
