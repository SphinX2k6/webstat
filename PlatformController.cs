using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x020025F1 RID: 9713
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PlatformController : ControllerBase<PlatformController>
{
	// Token: 0x06013085 RID: 77957 RVA: 0x00546AB0 File Offset: 0x00544CB0
	protected override bool OnInit()
	{
		this.ControlScreenSaver(false);
		this.InitDeviceInfo();
		this.BindInput();
		return true;
	}

	// Token: 0x06013086 RID: 77958 RVA: 0x00546AC6 File Offset: 0x00544CC6
	protected override bool OnClear()
	{
		this.UnBindInput();
		return true;
	}

	// Token: 0x06013087 RID: 77959 RVA: 0x00546ACF File Offset: 0x00544CCF
	private void BindInput()
	{
		ControllerBase<InputDistributeController>.Instance.BindAxis("MouseMove", new TInputHandle<float>(this.OnMouseAxisInput));
	}

	// Token: 0x06013088 RID: 77960 RVA: 0x00546AEC File Offset: 0x00544CEC
	private void UnBindInput()
	{
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("MouseMove", new TInputHandle<float>(this.OnMouseAxisInput));
	}

	// Token: 0x06013089 RID: 77961 RVA: 0x00546B09 File Offset: 0x00544D09
	private void OnMouseAxisInput(string axisName, float value, InputIdentification _)
	{
		if (value == 0f)
		{
			return;
		}
		if (Singleton<Info>.Instance.IsInKeyBoard())
		{
			return;
		}
		if (Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			return;
		}
		Singleton<Info>.Instance.SwitchInputControllerType(EInputControllerType.Keyboard, "MouseAxisInput");
	}

	// Token: 0x0601308A RID: 77962 RVA: 0x00546B3E File Offset: 0x00544D3E
	private void InitDeviceInfo()
	{
		if (!Singleton<Info>.Instance.IsPcPlatform())
		{
			ModelBase<PlatformModel>.Instance.RefreshPlatformByDevice("InitDeviceInfo");
		}
	}

	// Token: 0x0601308B RID: 77963 RVA: 0x00546B5C File Offset: 0x00544D5C
	public void ControlScreenSaver(bool state)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Platform;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "控制屏幕";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKismetSystemLibrary.ControlScreensaver(state);
	}

	// Token: 0x0601308C RID: 77964 RVA: 0x00546BA0 File Offset: 0x00544DA0
	public unsafe void SendClientBasicInfo()
	{
		ClientBasicInfoRequest clientBasicInfoRequest = new ClientBasicInfoRequest();
		ClientBasicInfo clientBasicInfo = this.PackageClientBasicInfo();
		clientBasicInfoRequest.ClientBasicInfo = clientBasicInfo;
		Singleton<Net>.Instance.Call<ClientBasicInfoResponse>(ERequestMessageId.ClientBasicInfoRequest, clientBasicInfoRequest, null, 0);
		if (clientBasicInfo != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Platform;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "客户端上报一些设备基础信息";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CPU", clientBasicInfo.CPU);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DeviceId", clientBasicInfo.DeviceId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Model", clientBasicInfo.Model);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("NetStatus", clientBasicInfo.NetStatus);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Platform", clientBasicInfo.Platform);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
		}
	}

	// Token: 0x0601308D RID: 77965 RVA: 0x00546C98 File Offset: 0x00544E98
	public ClientBasicInfo PackageClientBasicInfo()
	{
		ClientBasicInfo clientBasicInfo = new ClientBasicInfo();
		clientBasicInfo.NetStatus = ModelBase<PlatformModel>.Instance.GetNetStatus();
		clientBasicInfo.Platform = KuroApplication.IniPlatformName();
		FBasicInfo basicInfo = ModelBase<KuroSdkModel>.Instance.GetBasicInfo();
		clientBasicInfo.CPU = (((basicInfo != null) ? basicInfo.CPUModelName : null) ?? string.Empty);
		clientBasicInfo.DeviceId = (((basicInfo != null) ? basicInfo.DeviceId : null) ?? string.Empty);
		clientBasicInfo.Model = (((basicInfo != null) ? basicInfo.ModelName : null) ?? string.Empty);
		clientBasicInfo.DistinctId = UThinkingAnalytics.GetDeviceId(0);
		clientBasicInfo.Language = Singleton<LanguageSystem>.Instance.GetLanguageDefineByCode(Singleton<LanguageSystem>.Instance.PackageLanguage).LanguageType;
		clientBasicInfo.PkgId = (ControllerBase<KuroSdkController>.Instance.GetPackageId() ?? string.Empty);
		if (Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			clientBasicInfo.ServerTag = Singleton<CloudGameManagerLauncher>.Instance.ServerTag;
		}
		string macAddress = UKuroStaticLibrary.GetMacAddress();
		if (!StringUtils.IsEmpty(macAddress))
		{
			clientBasicInfo.MacAddress = macAddress;
		}
		PresetProperties presetProperties = ModelBase<LogReportModel>.Instance.GetPresetProperties();
		clientBasicInfo.SystemLanguage = presetProperties.system_language;
		clientBasicInfo.OSVersion = presetProperties.os_version;
		clientBasicInfo.DeviceId2ShuShu = presetProperties.device_id;
		int num;
		clientBasicInfo.ScreenHeight = (int.TryParse(presetProperties.screen_height, out num) ? num : 0);
		int num2;
		clientBasicInfo.ScreenWidth = (int.TryParse(presetProperties.screen_width, out num2) ? num2 : 0);
		clientBasicInfo.DeviceInfo = (ModelBase<LoginModel>.Instance.DeviceInfo() ?? string.Empty);
		clientBasicInfo.DriverDate = (ModelBase<LoginModel>.Instance.DriverDate() ?? string.Empty);
		clientBasicInfo.ClientVersion = Singleton<BaseConfigController>.Instance.GetVersionString();
		return clientBasicInfo;
	}
}
