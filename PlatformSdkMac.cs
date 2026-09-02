using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000F0D RID: 3853
[NullableContext(1)]
[Nullable(0)]
public class PlatformSdkMac : PlatformSdkBase
{
	// Token: 0x06005FE9 RID: 24553 RVA: 0x0017FB3C File Offset: 0x0017DD3C
	public PlatformSdkMac()
	{
		this.SdkParamCacheMap = new Dictionary<string, string>();
	}

	// Token: 0x06005FEA RID: 24554 RVA: 0x0017FB50 File Offset: 0x0017DD50
	protected override void OnInit()
	{
		this.CurrentDid = UKuroSDKManager.GetBasicInfo().DeviceId;
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk() && UKuroLauncherLibrary.IsFirstIntoLauncher())
		{
			UKuroSDKManager.PostSplashScreenEndSuccess();
		}
		FCrashSightProxy.SetCustomData("SdkDeviceId", this.CurrentDid);
		FCrashSightProxy.SetCustomData("SdkChannelId", this.GetChannelId());
	}

	// Token: 0x06005FEB RID: 24555 RVA: 0x0017FBA5 File Offset: 0x0017DDA5
	protected override void BindSpecialEvent()
	{
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Clear();
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Add(new Action<string>(this.CustomerServiceResultCallBack));
	}

	// Token: 0x06005FEC RID: 24556 RVA: 0x0017FBD4 File Offset: 0x0017DDD4
	public void CustomerServiceResultCallBack(string result)
	{
		PlatformSdkMac.ISdkCustomerService sdkCustomerService = Json.Parse<PlatformSdkMac.ISdkCustomerService>(result, null);
		if (sdkCustomerService != null)
		{
			this.CurrentCustomerShowState = (sdkCustomerService.isredot > 0);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x06005FED RID: 24557 RVA: 0x0017FC0C File Offset: 0x0017DE0C
	public override void OpenCustomerService(EKuroSdkOpenCustomerServerType fromType)
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		PlayerInfoModel instance2 = ModelBase<PlayerInfoModel>.Instance;
		OpenCustomerServiceParamMac openCustomerServiceParamMac = new OpenCustomerServiceParamMac();
		openCustomerServiceParamMac.islogin = ((instance.IsSdkLoggedIn() > false) ? 1 : 0);
		openCustomerServiceParamMac.from = fromType;
		openCustomerServiceParamMac.RoleId = this.GetCustomServerRoleId();
		openCustomerServiceParamMac.RoleName = instance2.GetAccountName(true);
		openCustomerServiceParamMac.ServerId = (instance.GetServerId() ?? "");
		openCustomerServiceParamMac.ServerName = (instance.GetServerName() ?? "");
		int? playerLevel = instance2.GetPlayerLevel();
		openCustomerServiceParamMac.RoleLevel = ((playerLevel != null && playerLevel.Value != 0) ? playerLevel.Value.ToString() : "");
		openCustomerServiceParamMac.ExtendsInfo = this.GetCustomServerExtendsInfo();
		UKuroSDKManager.OpenCustomerService(Json.Stringify<OpenCustomerServiceParamMac>(openCustomerServiceParamMac, null));
	}

	// Token: 0x06005FEE RID: 24558 RVA: 0x0017FCCF File Offset: 0x0017DECF
	public override string GetChannelId()
	{
		return this.GetSdkParamData("channelId");
	}

	// Token: 0x06005FEF RID: 24559 RVA: 0x0017FCDC File Offset: 0x0017DEDC
	public override void SetFont()
	{
		string deviceFontAsset = ModelBase<KuroSdkModel>.Instance.GetDeviceFontAsset();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "Mac SetFont";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("fontPath", deviceFontAsset);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKuroSDKManager.SetFont(deviceFontAsset);
	}

	// Token: 0x06005FF0 RID: 24560 RVA: 0x0017FD24 File Offset: 0x0017DF24
	private string GetSdkParamData(string needParam)
	{
		if (this.SdkParamCacheMap.Count == 0)
		{
			string[] array = UKuroSDKManager.GetSdkParams("").Split(',', StringSplitOptions.None);
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				string[] array2 = array[i].Split('=', StringSplitOptions.None);
				if (array2.Length == 2)
				{
					this.SdkParamCacheMap[array2[0]] = array2[1];
				}
			}
		}
		string text;
		if (this.SdkParamCacheMap.TryGetValue(needParam, out text) && text != null && !StringUtils.IsEmpty(text))
		{
			return text;
		}
		return "";
	}

	// Token: 0x06005FF1 RID: 24561 RVA: 0x0017FDAA File Offset: 0x0017DFAA
	public override void SdkExit()
	{
		UKuroSDKManager.ShowExitGameDialog();
	}

	// Token: 0x04002E0F RID: 11791
	private readonly Dictionary<string, string> SdkParamCacheMap;

	// Token: 0x0200732E RID: 29486
	[NullableContext(0)]
	private class ISdkCustomerService
	{
		// Token: 0x04027EF2 RID: 163570
		[Nullable(1)]
		public string cuid = "";

		// Token: 0x04027EF3 RID: 163571
		public int isredot;
	}
}
