using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.HotPatchKuroSdk;
using CSharpScript.Launcher.Notice;
using CSharpScript.Launcher.Server;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using CSharpScript.Launcher.Update.ResourceDiffUpdate.Config;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004510 RID: 17680
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixManager : IStaticVariableResetter
	{
		// Token: 0x0602E92D RID: 190765 RVA: 0x00B08CC4 File Offset: 0x00B06EC4
		static HotFixManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(HotFixManager.CreateStaticDefaultValue), new Action(HotFixManager.ResetStaticDefaultValue));
		}

		// Token: 0x0602E92E RID: 190766 RVA: 0x00B08D4D File Offset: 0x00B06F4D
		public static void CreateStaticDefaultValue()
		{
			HotFixManager.DownLoadType = EVideoResSizeType.StartMaxNeed;
			HotFixManager.ResDownLoadType = EResUpdateType.Max;
		}

		// Token: 0x0602E92F RID: 190767 RVA: 0x00B08D5C File Offset: 0x00B06F5C
		public static void ResetStaticDefaultValue()
		{
			HotFixManager.DownLoadViewChosePromise = null;
			HotFixManager.DownLoadViewChoseDoneCallBack = null;
			HotFixManager.FreeSpaceCheckPromise = null;
			HotFixManager.FreeSpaceCheckDoneCallBack = null;
			HotFixManager.DownLoadType = EVideoResSizeType.StartMaxNeed;
			HotFixManager.NeedDownLoadByte = 0L;
			HotFixManager.SdkLoginHotFixManagerHandle = null;
			HotFixManager.SdkLoginPromiseResolve = null;
			HotFixManager.OnSdkLoginSuccessCallBack = null;
			HotFixManager.LaunchSdkLoginServerIp = "";
			HotFixManager.LaunchSubPackageHttpData = null;
			HotFixManager.HandleLoginData = null;
			HotFixManager.GetLoginSubPackageDownLoadHttpTimes = 0;
			HotFixManager.SuggestSeverData = null;
			HotFixManager.LoginUrlPollingIndex = 0;
			HotFixManager.ResDownLoadType = EResUpdateType.Max;
			HotFixManager.HandleAutoClear = false;
		}

		// Token: 0x0602E930 RID: 190768 RVA: 0x00B08DD4 File Offset: 0x00B06FD4
		public void SetNetworkType(ENetworkType networkType)
		{
			this.NetworkType = new ENetworkType?(networkType);
		}

		// Token: 0x0602E931 RID: 190769 RVA: 0x00B08DE2 File Offset: 0x00B06FE2
		public ENetworkType? GetNetworkType()
		{
			return this.NetworkType;
		}

		// Token: 0x0602E932 RID: 190770 RVA: 0x00B08DEC File Offset: 0x00B06FEC
		public UniTask Init(UObject worldContextObject)
		{
			HotFixManager.<Init>d__15 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.worldContextObject = worldContextObject;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<HotFixManager.<Init>d__15>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0602E933 RID: 190771 RVA: 0x00B08E38 File Offset: 0x00B07038
		public static UniTask SdkLogin(Action callBack, bool isFormView = false)
		{
			HotFixManager.<SdkLogin>d__19 <SdkLogin>d__;
			<SdkLogin>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SdkLogin>d__.callBack = callBack;
			<SdkLogin>d__.isFormView = isFormView;
			<SdkLogin>d__.<>1__state = -1;
			<SdkLogin>d__.<>t__builder.Start<HotFixManager.<SdkLogin>d__19>(ref <SdkLogin>d__);
			return <SdkLogin>d__.<>t__builder.Task;
		}

		// Token: 0x17008047 RID: 32839
		// (get) Token: 0x0602E934 RID: 190772 RVA: 0x00B08E83 File Offset: 0x00B07083
		[Nullable(2)]
		public static FLoginStruct LoginData
		{
			[NullableContext(2)]
			get
			{
				return HotFixManager.HandleLoginData;
			}
		}

		// Token: 0x0602E935 RID: 190773 RVA: 0x00B08E8C File Offset: 0x00B0708C
		public static void RefreshLoginStateOnLogin(FLoginStruct data)
		{
			if (HotFixManager.SdkLoginPromiseResolve == null)
			{
				Singleton<LauncherLog>.Instance.Error("触发HotFix阶段Sdk登录回调时，SdkLoginPromiseResolve为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (data.LoginCode < 1)
			{
				Singleton<LauncherLog>.Instance.Warn("HotFix阶段进行Sdk登录失败 - 直接全量下载资源", default(ReadOnlySpan<ValueTuple<string, object>>));
				HotFixManager.LaunchSubPackageHttpData = null;
				Action sdkLoginPromiseResolve = HotFixManager.SdkLoginPromiseResolve;
				if (sdkLoginPromiseResolve == null)
				{
					return;
				}
				sdkLoginPromiseResolve();
				return;
			}
			else
			{
				Singleton<LauncherLog>.Instance.Info("HotFix阶段进行Sdk登录成功", default(ReadOnlySpan<ValueTuple<string, object>>));
				HotFixManager.SaveHotFixSdkLoginState(true);
				Action onSdkLoginSuccessCallBack = HotFixManager.OnSdkLoginSuccessCallBack;
				if (onSdkLoginSuccessCallBack != null)
				{
					onSdkLoginSuccessCallBack();
				}
				HotFixManager.OnSdkLoginSuccessCallBack = null;
				HotFixManager.HandleLoginData = data;
				if (Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
				{
					HotFixManager.RequestSuggestServerData();
					return;
				}
				Singleton<LauncherLog>.Instance.Info("HotFix阶段进行Sdk登录成功后 - 分包灰度未命中", default(ReadOnlySpan<ValueTuple<string, object>>));
				Action sdkLoginPromiseResolve2 = HotFixManager.SdkLoginPromiseResolve;
				if (sdkLoginPromiseResolve2 == null)
				{
					return;
				}
				sdkLoginPromiseResolve2();
				return;
			}
		}

		// Token: 0x0602E936 RID: 190774 RVA: 0x00B08F68 File Offset: 0x00B07168
		public static void SaveHotFixSdkLoginState(bool isLogin)
		{
			if (UKuroVariableFunctionLibrary.HasBoolValue("hot_fix_login"))
			{
				UKuroVariableFunctionLibrary.RemoveBoolValue("hot_fix_login");
			}
			UKuroVariableFunctionLibrary.SetBoolValue("hot_fix_login", isLogin);
		}

		// Token: 0x0602E937 RID: 190775 RVA: 0x00B08F90 File Offset: 0x00B07190
		public static bool GetHotFixSdkLoginState()
		{
			if (!UKuroVariableFunctionLibrary.HasBoolValue("hot_fix_login"))
			{
				return false;
			}
			bool flag = false;
			return UKuroVariableFunctionLibrary.GetBoolValue("hot_fix_login", ref flag) && flag;
		}

		// Token: 0x0602E938 RID: 190776 RVA: 0x00B08FC0 File Offset: 0x00B071C0
		private static void RequestSuggestServerData()
		{
			if (HotFixManager.HandleLoginData == null)
			{
				Singleton<LauncherLog>.Instance.Error("HotFix阶段RequestSuggestServerData失败，没有登录数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				HotFixManager.LaunchSubPackageHttpData = null;
				HotFixManager.SdkLoginPromiseResolve();
				return;
			}
			Singleton<LauncherServer>.Instance.RequestSuggestServerData(HotFixManager.HandleLoginData.Uid, HotFixManager.HandleLoginData.UserName, HotFixManager.HandleLoginData.Token, delegate(ILoginServersData result)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "HotFix阶段获取推荐服务器";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", result.name);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				HotFixManager.SuggestSeverData = result;
				HotFixManager.LoginUrlPollingIndex = 0;
				HotFixManager.GetLoginSubPackageDownLoadHttp();
			});
		}

		// Token: 0x0602E939 RID: 190777 RVA: 0x00B0904C File Offset: 0x00B0724C
		private static UniTask GetLoginSubPackageDownLoadHttp()
		{
			HotFixManager.<GetLoginSubPackageDownLoadHttp>d__32 <GetLoginSubPackageDownLoadHttp>d__;
			<GetLoginSubPackageDownLoadHttp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GetLoginSubPackageDownLoadHttp>d__.<>1__state = -1;
			<GetLoginSubPackageDownLoadHttp>d__.<>t__builder.Start<HotFixManager.<GetLoginSubPackageDownLoadHttp>d__32>(ref <GetLoginSubPackageDownLoadHttp>d__);
			return <GetLoginSubPackageDownLoadHttp>d__.<>t__builder.Task;
		}

		// Token: 0x0602E93A RID: 190778 RVA: 0x00B09088 File Offset: 0x00B07288
		private static void ContinueLauncherSdkLogin(bool isSuccess)
		{
			if (isSuccess)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "HotFix阶段登录-等待Promise结束";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Resolve", HotFixManager.SdkLoginPromiseResolve);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				HotFixManager.SdkLoginPromiseResolve();
				return;
			}
			HotFixManager sdkLoginHotFixManagerHandle = HotFixManager.SdkLoginHotFixManagerHandle;
			if (sdkLoginHotFixManagerHandle == null)
			{
				return;
			}
			sdkLoginHotFixManagerHandle.ShowDialog(true, "HotFixTipsTitle", "SubPackageHttp_Fail_Content", "SubPackageHttp_Fail_ButtonText_0", "SubPackageHttp_Fail_ButtonText_1", null, Array.Empty<string>()).ContinueWith(delegate(bool result)
			{
				if (!result)
				{
					Singleton<LauncherLog>.Instance.Info("HotFix阶段获取分包资源Http失败，直接全量下载", default(ReadOnlySpan<ValueTuple<string, object>>));
					HotFixManager.LaunchSubPackageHttpData = null;
					HotFixManager.SdkLoginPromiseResolve();
					return;
				}
				Singleton<LauncherLog>.Instance.Info("HotFix阶段获取分包资源Http失败，尝试重新获取HTTP", default(ReadOnlySpan<ValueTuple<string, object>>));
				HotFixManager.LoginUrlPollingIndex++;
				HotFixManager.GetLoginSubPackageDownLoadHttp();
			}).Forget();
		}

		// Token: 0x0602E93B RID: 190779 RVA: 0x00B0911D File Offset: 0x00B0731D
		public void RefreshViewLoginStateBeforeLogin()
		{
			this.SdkLoginFinish = false;
			this.WaitFrame(30).ContinueWith(delegate()
			{
				if (this.SdkLoginFinish)
				{
					return;
				}
				this.HotFixView.SetProgressActive(false);
				this.HotFixView.RefreshLoginStateBeforeLogin();
			});
		}

		// Token: 0x0602E93C RID: 190780 RVA: 0x00B09140 File Offset: 0x00B07340
		public void RefreshViewLoginStateOnLoginSuccess()
		{
			this.SdkLoginFinish = true;
			this.HotFixView.RefreshLoginStateOnLoginSuccess();
		}

		// Token: 0x0602E93D RID: 190781 RVA: 0x00B09154 File Offset: 0x00B07354
		public unsafe static string BuildSubPackageHttp(string uId, string userName, string token)
		{
			string serverPort = HotFixManager.GetServerPort();
			string launchSdkLoginServerIp = HotFixManager.LaunchSdkLoginServerIp;
			string value = Uri.EscapeDataString(userName);
			string item = UKuroStaticLibrary.HashStringWithSHA1(token);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "BuildSubPackageHttp";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("uId", uId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("userName", userName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("token", item);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			FBasicInfo basicInfo = UKuroSDKManager.GetBasicInfo();
			string value2 = (basicInfo != null) ? basicInfo.DeviceId : null;
			string value3 = launchSdkLoginServerIp.StartsWith("http") ? launchSdkLoginServerIp : ("http://" + launchSdkLoginServerIp + ":" + serverPort);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(88, 6);
			defaultInterpolatedStringHandler.AppendFormatted(value3);
			defaultInterpolatedStringHandler.AppendLiteral("/api/getResourcePackageInfo?loginType=1&userId=");
			defaultInterpolatedStringHandler.AppendFormatted(uId);
			defaultInterpolatedStringHandler.AppendLiteral("&userName=");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("&token=");
			defaultInterpolatedStringHandler.AppendFormatted(token);
			defaultInterpolatedStringHandler.AppendLiteral("&deviceId=");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral("&loginTraceId=");
			defaultInterpolatedStringHandler.AppendFormatted(LauncherSdk.Get().LauncherTraceId);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602E93E RID: 190782 RVA: 0x00B092A0 File Offset: 0x00B074A0
		public static string GetServerPort()
		{
			string result = "5500";
			string[] array = UKismetSystemLibrary.GetCommandLine().Split(' ', StringSplitOptions.None);
			int num = -1;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == "-LocalGameServerStartPort")
				{
					num = i;
					break;
				}
			}
			int num2;
			if (num == -1 || num + 1 >= array.Length || !int.TryParse(array[num + 1], out num2))
			{
				return result;
			}
			return (num2 + 1).ToString();
		}

		// Token: 0x0602E93F RID: 190783 RVA: 0x00B09314 File Offset: 0x00B07514
		public UniTask CloseHotFix()
		{
			HotFixManager.<CloseHotFix>d__39 <CloseHotFix>d__;
			<CloseHotFix>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseHotFix>d__.<>4__this = this;
			<CloseHotFix>d__.<>1__state = -1;
			<CloseHotFix>d__.<>t__builder.Start<HotFixManager.<CloseHotFix>d__39>(ref <CloseHotFix>d__);
			return <CloseHotFix>d__.<>t__builder.Task;
		}

		// Token: 0x0602E940 RID: 190784 RVA: 0x00B09357 File Offset: 0x00B07557
		public void Destroy()
		{
			this.HotFixView.Destroy();
			this.HotFixView = null;
		}

		// Token: 0x0602E941 RID: 190785 RVA: 0x00B0936C File Offset: 0x00B0756C
		public UniTask ShowInfo(bool bWithProgress, [Nullable(2)] string textId, params string[] args)
		{
			HotFixManager.<ShowInfo>d__41 <ShowInfo>d__;
			<ShowInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowInfo>d__.<>4__this = this;
			<ShowInfo>d__.bWithProgress = bWithProgress;
			<ShowInfo>d__.textId = textId;
			<ShowInfo>d__.args = args;
			<ShowInfo>d__.<>1__state = -1;
			<ShowInfo>d__.<>t__builder.Start<HotFixManager.<ShowInfo>d__41>(ref <ShowInfo>d__);
			return <ShowInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0602E942 RID: 190786 RVA: 0x00B093C8 File Offset: 0x00B075C8
		public UniTask UpdateProgress(bool bNeedWait, float rate, string textId, params string[] args)
		{
			HotFixManager.<UpdateProgress>d__42 <UpdateProgress>d__;
			<UpdateProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateProgress>d__.<>4__this = this;
			<UpdateProgress>d__.bNeedWait = bNeedWait;
			<UpdateProgress>d__.rate = rate;
			<UpdateProgress>d__.textId = textId;
			<UpdateProgress>d__.args = args;
			<UpdateProgress>d__.<>1__state = -1;
			<UpdateProgress>d__.<>t__builder.Start<HotFixManager.<UpdateProgress>d__42>(ref <UpdateProgress>d__);
			return <UpdateProgress>d__.<>t__builder.Task;
		}

		// Token: 0x0602E943 RID: 190787 RVA: 0x00B0942C File Offset: 0x00B0762C
		public UniTask UpdatePatchDownProgress(bool bNeedWait, float rate, string fileName, string speedText, string sizeCurrent, string sizeTotal)
		{
			HotFixManager.<UpdatePatchDownProgress>d__43 <UpdatePatchDownProgress>d__;
			<UpdatePatchDownProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdatePatchDownProgress>d__.<>4__this = this;
			<UpdatePatchDownProgress>d__.bNeedWait = bNeedWait;
			<UpdatePatchDownProgress>d__.rate = rate;
			<UpdatePatchDownProgress>d__.fileName = fileName;
			<UpdatePatchDownProgress>d__.speedText = speedText;
			<UpdatePatchDownProgress>d__.sizeCurrent = sizeCurrent;
			<UpdatePatchDownProgress>d__.sizeTotal = sizeTotal;
			<UpdatePatchDownProgress>d__.<>1__state = -1;
			<UpdatePatchDownProgress>d__.<>t__builder.Start<HotFixManager.<UpdatePatchDownProgress>d__43>(ref <UpdatePatchDownProgress>d__);
			return <UpdatePatchDownProgress>d__.<>t__builder.Task;
		}

		// Token: 0x0602E944 RID: 190788 RVA: 0x00B094A4 File Offset: 0x00B076A4
		public unsafe void ShowToolView()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "SetToolWindowActive";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("value", true);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("this.HotFixView", this.HotFixView);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.HotFixView.SetToolWindowActive(true);
		}

		// Token: 0x0602E945 RID: 190789 RVA: 0x00B09516 File Offset: 0x00B07716
		public void SetDownLoadActive(bool value)
		{
			this.HotFixView.SetDownLoadActive(value);
		}

		// Token: 0x0602E946 RID: 190790 RVA: 0x00B09524 File Offset: 0x00B07724
		public void SetFreeSpaceTipsPopActive(bool value)
		{
			this.HotFixView.SetFreeSpaceTipsPopActive(value);
		}

		// Token: 0x0602E947 RID: 190791 RVA: 0x00B09534 File Offset: 0x00B07734
		[return: Nullable(0)]
		public UniTask<bool> ShowDialog(bool bSelect, string titleId, string contentId, [Nullable(2)] string leftId, [Nullable(2)] string rightId, [Nullable(2)] string middleId, params string[] contentArgs)
		{
			HotFixManager.<ShowDialog>d__47 <ShowDialog>d__;
			<ShowDialog>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowDialog>d__.<>4__this = this;
			<ShowDialog>d__.bSelect = bSelect;
			<ShowDialog>d__.titleId = titleId;
			<ShowDialog>d__.contentId = contentId;
			<ShowDialog>d__.leftId = leftId;
			<ShowDialog>d__.rightId = rightId;
			<ShowDialog>d__.middleId = middleId;
			<ShowDialog>d__.contentArgs = contentArgs;
			<ShowDialog>d__.<>1__state = -1;
			<ShowDialog>d__.<>t__builder.Start<HotFixManager.<ShowDialog>d__47>(ref <ShowDialog>d__);
			return <ShowDialog>d__.<>t__builder.Task;
		}

		// Token: 0x0602E948 RID: 190792 RVA: 0x00B095B3 File Offset: 0x00B077B3
		[NullableContext(2)]
		public void ShowNoticeWindow(string logMsg = null)
		{
			Singleton<LauncherNoticeUtils>.Instance.OpenNotice(logMsg);
		}

		// Token: 0x0602E949 RID: 190793 RVA: 0x00B095C0 File Offset: 0x00B077C0
		public static void ShowNoticeWindowByUser()
		{
			Singleton<LauncherNoticeUtils>.Instance.OpenNoticeByUser();
		}

		// Token: 0x0602E94A RID: 190794 RVA: 0x00B095CC File Offset: 0x00B077CC
		public UniTask WaitFrame(int num = 1)
		{
			HotFixManager.<WaitFrame>d__50 <WaitFrame>d__;
			<WaitFrame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitFrame>d__.num = num;
			<WaitFrame>d__.<>1__state = -1;
			<WaitFrame>d__.<>t__builder.Start<HotFixManager.<WaitFrame>d__50>(ref <WaitFrame>d__);
			return <WaitFrame>d__.<>t__builder.Task;
		}

		// Token: 0x0602E94B RID: 190795 RVA: 0x00B0960F File Offset: 0x00B0780F
		private void ShowContainerItemAndCloseConfirmationItem()
		{
			this.HotFixView.SetContainerItemActive(true);
			this.HotFixView.SetConfirmationItemActive(false);
		}

		// Token: 0x0602E94C RID: 190796 RVA: 0x00B0962C File Offset: 0x00B0782C
		[NullableContext(0)]
		private UniTask<bool> InitConfirmItemLeftRight(bool canCloseOff)
		{
			HotFixManager.<InitConfirmItemLeftRight>d__52 <InitConfirmItemLeftRight>d__;
			<InitConfirmItemLeftRight>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<InitConfirmItemLeftRight>d__.<>4__this = this;
			<InitConfirmItemLeftRight>d__.canCloseOff = canCloseOff;
			<InitConfirmItemLeftRight>d__.<>1__state = -1;
			<InitConfirmItemLeftRight>d__.<>t__builder.Start<HotFixManager.<InitConfirmItemLeftRight>d__52>(ref <InitConfirmItemLeftRight>d__);
			return <InitConfirmItemLeftRight>d__.<>t__builder.Task;
		}

		// Token: 0x0602E94D RID: 190797 RVA: 0x00B09678 File Offset: 0x00B07878
		[NullableContext(0)]
		private UniTask<bool> InitConfirmItemMiddle(bool canCloseOff)
		{
			HotFixManager.<InitConfirmItemMiddle>d__53 <InitConfirmItemMiddle>d__;
			<InitConfirmItemMiddle>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<InitConfirmItemMiddle>d__.<>4__this = this;
			<InitConfirmItemMiddle>d__.canCloseOff = canCloseOff;
			<InitConfirmItemMiddle>d__.<>1__state = -1;
			<InitConfirmItemMiddle>d__.<>t__builder.Start<HotFixManager.<InitConfirmItemMiddle>d__53>(ref <InitConfirmItemMiddle>d__);
			return <InitConfirmItemMiddle>d__.<>t__builder.Task;
		}

		// Token: 0x0602E94E RID: 190798 RVA: 0x00B096C3 File Offset: 0x00B078C3
		private void CloseConfirmation()
		{
			this.HotFixView.SetConfirmationItemActive(false);
		}

		// Token: 0x0602E94F RID: 190799 RVA: 0x00B096D4 File Offset: 0x00B078D4
		[NullableContext(0)]
		public UniTask<bool> ShowPrivacyProtocolView()
		{
			HotFixManager.<ShowPrivacyProtocolView>d__55 <ShowPrivacyProtocolView>d__;
			<ShowPrivacyProtocolView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowPrivacyProtocolView>d__.<>4__this = this;
			<ShowPrivacyProtocolView>d__.<>1__state = -1;
			<ShowPrivacyProtocolView>d__.<>t__builder.Start<HotFixManager.<ShowPrivacyProtocolView>d__55>(ref <ShowPrivacyProtocolView>d__);
			return <ShowPrivacyProtocolView>d__.<>t__builder.Task;
		}

		// Token: 0x0602E950 RID: 190800 RVA: 0x00B09718 File Offset: 0x00B07918
		public static void SetLocalText(UUIText uiText, [Nullable(2)] string textTableId, params string[] args)
		{
			string hotPatchText = Singleton<LauncherConfigLib>.Instance.GetHotPatchText(textTableId);
			if (hotPatchText == null)
			{
				uiText.SetText("", true);
				return;
			}
			string text = hotPatchText;
			if (args != null)
			{
				for (int i = 0; i < args.Length; i++)
				{
					string separator = args[i];
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
					defaultInterpolatedStringHandler.AppendLiteral("{");
					defaultInterpolatedStringHandler.AppendFormatted<int>(i);
					defaultInterpolatedStringHandler.AppendLiteral("}");
					string separator2 = defaultInterpolatedStringHandler.ToStringAndClear();
					text = string.Join(separator, text.Split(separator2, StringSplitOptions.None));
				}
			}
			uiText.SetText(text, true);
		}

		// Token: 0x0602E951 RID: 190801 RVA: 0x00B097A0 File Offset: 0x00B079A0
		public void TryShowNoticeBtn()
		{
			bool noticeBtnActive = Singleton<LauncherNoticeUtils>.Instance.CheckGrayBoxHit();
			HotFixUiView hotFixView = this.HotFixView;
			if (hotFixView == null)
			{
				return;
			}
			hotFixView.SetNoticeBtnActive(noticeBtnActive);
		}

		// Token: 0x0602E952 RID: 190802 RVA: 0x00B097CC File Offset: 0x00B079CC
		public static string ByteConverter(long byte_)
		{
			if (byte_ < 0L)
			{
				return "<0.01MB";
			}
			double num = (double)byte_;
			double num2 = 1073741824.0;
			double num3 = (num >= num2) ? (num / 1073741824.0) : (num / 1048576.0);
			string str = (num >= num2) ? "GB" : "MB";
			return num3.ToString("0.##") + " " + str;
		}

		// Token: 0x0602E953 RID: 190803 RVA: 0x00B09838 File Offset: 0x00B07A38
		public static List<int> GetCanCleanSceneIdList()
		{
			List<int> list = new List<int>();
			if (!Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
			{
				return list;
			}
			HashSet<int> blockIds = Singleton<ResourceDiffUpdaterManager>.Instance.BlockModule.GetCoreBlockIds(Singleton<ResourceDiffUpdaterManager>.Instance.Context);
			Func<int, bool> <>9__0;
			foreach (DownLoadSubPackageRow downLoadSubPackageRow in PackSelectionTables.DownLoadSubPackageTableInstance.GetAll())
			{
				if (downLoadSubPackageRow.Type == 2)
				{
					IEnumerable<int> area = downLoadSubPackageRow.Area;
					Func<int, bool> predicate;
					if ((predicate = <>9__0) == null)
					{
						predicate = (<>9__0 = ((int item) => blockIds.Contains(item)));
					}
					if (!area.Any(predicate))
					{
						list.Add(downLoadSubPackageRow.Id);
					}
				}
			}
			return list;
		}

		// Token: 0x0602E954 RID: 190804 RVA: 0x00B09908 File Offset: 0x00B07B08
		public static long GetCanCleanVideoSpace()
		{
			HashSet<int> unusedVideos = Singleton<ResourceDiffUpdaterManager>.Instance.VideoModule.GetUnusedVideos(Singleton<ResourceDiffUpdaterManager>.Instance.Context.FinishedQuests);
			return Singleton<ResourceDiffUpdaterManager>.Instance.VideoModule.GetLocalSizeByVideoIds(unusedVideos);
		}

		// Token: 0x0602E955 RID: 190805 RVA: 0x00B09944 File Offset: 0x00B07B44
		public static long GetSubPackageSpace(int packId)
		{
			DownLoadSubPackageRow byId = PackSelectionTables.DownLoadSubPackageTableInstance.GetById(packId);
			List<int> list = ((byId != null) ? byId.Area : null) ?? new List<int>();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (int blockId in list)
			{
				string blockPackName = Singleton<ResourceDiffUpdaterManager>.Instance.BlockModule.GetBlockPackName(blockId);
				if (blockPackName != null)
				{
					hashSet.Add(blockPackName);
				}
			}
			return Singleton<ResourceDiffUpdaterManager>.Instance.BlockModule.GetLocalSize(hashSet.ToList<string>());
		}

		// Token: 0x0602E956 RID: 190806 RVA: 0x00B099E8 File Offset: 0x00B07BE8
		public static long GetAllCanClearSpace()
		{
			List<int> canCleanSceneIdList = HotFixManager.GetCanCleanSceneIdList();
			long num = 0L;
			foreach (int packId in canCleanSceneIdList)
			{
				num += HotFixManager.GetSubPackageSpace(packId);
			}
			long canCleanVideoSpace = HotFixManager.GetCanCleanVideoSpace();
			num += canCleanVideoSpace;
			num += HotFixManager.GetAllCanClearVoiceSpace();
			return num;
		}

		// Token: 0x0602E957 RID: 190807 RVA: 0x00B09A54 File Offset: 0x00B07C54
		public static long GetAllCanClearVoiceSpace()
		{
			long num = 0L;
			string packageAudioLanguage = Singleton<LauncherLanguageLib>.Instance.GetPackageAudioLanguage();
			IEnumerable<LaunchLangDefine> allLanguageDefines = Singleton<LauncherLanguageLib>.Instance.GetAllLanguageDefines();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (LaunchLangDefine launchLangDefine in allLanguageDefines)
			{
				string audioCode = launchLangDefine.AudioCode;
				if (!hashSet.Contains(audioCode))
				{
					hashSet.Add(audioCode);
					if (!(audioCode == packageAudioLanguage))
					{
						LanguageUpdater updater = Singleton<LanguageUpdateManager>.Instance.GetUpdater(audioCode);
						if (updater != null && updater.Status == ELanguageDownloadStatus.Done && Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.GetLocalSizeByAudioCode(audioCode) > 0L)
						{
							num += updater.TotalDiskSize;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0602E958 RID: 190808 RVA: 0x00B09B14 File Offset: 0x00B07D14
		public static void ClearSubPackage(List<int> sceneIdList, bool clearVideo)
		{
			int num = clearVideo ? ((int)HotFixManager.GetCanCleanVideoSpace()) : 0;
			foreach (int packId in sceneIdList)
			{
				num += (int)HotFixManager.GetSubPackageSpace(packId);
			}
			List<MobileResCleanUpStateLogContentData> list = new List<MobileResCleanUpStateLogContentData>();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (int value in sceneIdList)
			{
				foreach (int num2 in PackSelectionTables.DownLoadSubPackageTableInstance.GetById(value).Area)
				{
					string blockPackName = Singleton<ResourceDiffUpdaterManager>.Instance.BlockModule.GetBlockPackName(num2);
					if (blockPackName != null)
					{
						hashSet.Add(blockPackName);
						list.Add(new MobileResCleanUpStateLogContentData
						{
							Type = 1,
							Id = num2
						});
					}
				}
			}
			Singleton<ResourceDiffUpdaterManager>.Instance.BlockModule.Delete(hashSet.ToList<string>());
			if (clearVideo)
			{
				HashSet<int> unusedVideos = Singleton<ResourceDiffUpdaterManager>.Instance.VideoModule.GetUnusedVideos(Singleton<ResourceDiffUpdaterManager>.Instance.Context.FinishedQuests);
				foreach (int id in unusedVideos)
				{
					list.Add(new MobileResCleanUpStateLogContentData
					{
						Type = 2,
						Id = id
					});
				}
				Singleton<ResourceDiffUpdaterManager>.Instance.VideoModule.DeleteByVideoIds(unusedVideos);
			}
			int cleanUpSpace = num;
			FLoginStruct loginData = HotFixManager.LoginData;
			new MobileResCleanUpStateLog(cleanUpSpace, ((loginData != null) ? loginData.Uid : null) ?? "", Singleton<ResourceDiffUpdaterManager>.Instance.TraceId.ToString(), list, 1, null).Report();
			FLoginStruct loginData2 = HotFixManager.LoginData;
			new MobileResCleanUpFinishStateLog(((loginData2 != null) ? loginData2.Uid : null) ?? "", Singleton<ResourceDiffUpdaterManager>.Instance.TraceId.ToString(), null).Report();
		}

		// Token: 0x0401A757 RID: 108375
		private const long GB_BYTES = 1073741824L;

		// Token: 0x0401A758 RID: 108376
		private const long MB_BYTES = 1048576L;

		// Token: 0x0401A759 RID: 108377
		private const int LOGINURL_TIMEOUT = 3;

		// Token: 0x0401A75A RID: 108378
		private const int LOGIN_BUTTON_SHOW_TIME = 30;

		// Token: 0x0401A75B RID: 108379
		private const int LOGIN_SUCCESS = 1;

		// Token: 0x0401A75C RID: 108380
		private const string HOTFIX_LOGIN = "hot_fix_login";

		// Token: 0x0401A75D RID: 108381
		[Nullable(2)]
		private HotFixUiView HotFixView;

		// Token: 0x0401A75E RID: 108382
		private ENetworkType? NetworkType;

		// Token: 0x0401A75F RID: 108383
		private bool HasDialogBeenShowed;

		// Token: 0x0401A760 RID: 108384
		public static bool HandleAutoClear = false;

		// Token: 0x0401A761 RID: 108385
		[Nullable(2)]
		private static HotFixManager SdkLoginHotFixManagerHandle = null;

		// Token: 0x0401A762 RID: 108386
		[Nullable(2)]
		private static Action SdkLoginPromiseResolve = null;

		// Token: 0x0401A763 RID: 108387
		[Nullable(2)]
		private static Action OnSdkLoginSuccessCallBack = null;

		// Token: 0x0401A764 RID: 108388
		public static string LaunchSdkLoginServerIp = "";

		// Token: 0x0401A765 RID: 108389
		[Nullable(2)]
		public static SubPackageHttpData LaunchSubPackageHttpData = null;

		// Token: 0x0401A766 RID: 108390
		[Nullable(2)]
		private static FLoginStruct HandleLoginData = null;

		// Token: 0x0401A767 RID: 108391
		private static int GetLoginSubPackageDownLoadHttpTimes = 0;

		// Token: 0x0401A768 RID: 108392
		[Nullable(2)]
		private static ILoginServersData SuggestSeverData = null;

		// Token: 0x0401A769 RID: 108393
		private static int LoginUrlPollingIndex = 0;

		// Token: 0x0401A76A RID: 108394
		private bool SdkLoginFinish;

		// Token: 0x0401A76B RID: 108395
		[Nullable(2)]
		public static UniTaskCompletionSource DownLoadViewChosePromise = null;

		// Token: 0x0401A76C RID: 108396
		[Nullable(2)]
		public static Action DownLoadViewChoseDoneCallBack = null;

		// Token: 0x0401A76D RID: 108397
		[Nullable(2)]
		public static UniTaskCompletionSource FreeSpaceCheckPromise = null;

		// Token: 0x0401A76E RID: 108398
		[Nullable(2)]
		public static Action FreeSpaceCheckDoneCallBack = null;

		// Token: 0x0401A76F RID: 108399
		public static EVideoResSizeType DownLoadType;

		// Token: 0x0401A770 RID: 108400
		public static EResUpdateType ResDownLoadType;

		// Token: 0x0401A771 RID: 108401
		public static long NeedDownLoadByte = 0L;

		// Token: 0x0200A71A RID: 42778
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04033DC0 RID: 212416
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<FLoginStruct> <0>__RefreshLoginStateOnLogin;
		}
	}
}
