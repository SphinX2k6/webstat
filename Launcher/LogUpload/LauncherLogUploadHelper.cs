using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;
using CSharpScript.Launcher.Util;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045EA RID: 17898
	public class LauncherLogUploadHelper
	{
		// Token: 0x0602EDA4 RID: 191908 RVA: 0x00B18D60 File Offset: 0x00B16F60
		[NullableContext(1)]
		public static ILogUploadParams CreateParams()
		{
			LogUploadParams logUploadParams = new LogUploadParams();
			Net net = new Net();
			net.IsServerConnected = (() => false);
			logUploadParams.Net = net;
			PlayerInfoModel playerInfoModel = new PlayerInfoModel();
			playerInfoModel.GetId = (() => new int?(0));
			logUploadParams.PlayerInfoModel = playerInfoModel;
			LocalStorage localStorage = new LocalStorage();
			localStorage.GetRecentlyLoginUid = (() => new int?(Singleton<LauncherStorageLib>.Instance.GetGlobal<int>(ELauncherStorageGlobalKey.RecentlyLoginUID, 0)));
			logUploadParams.LocalStorage = localStorage;
			KuroSdkController kuroSdkController = new KuroSdkController();
			kuroSdkController.CanUseSdk = (() => Singleton<HotPatchKuroSdk>.Instance.CanUseSdk());
			logUploadParams.KuroSdkController = kuroSdkController;
			LoginModel loginModel = new LoginModel();
			loginModel.GetSdkLoginConfigUid = (() => null);
			logUploadParams.LoginModel = loginModel;
			return logUploadParams;
		}

		// Token: 0x0602EDA5 RID: 191909 RVA: 0x00B18E62 File Offset: 0x00B17062
		public static void InitLogUpload()
		{
			Singleton<LauncherLogUpload>.Instance.SetParams(LauncherLogUploadHelper.CreateParams());
			Singleton<LauncherLogUpload>.Instance.Init();
		}
	}
}
