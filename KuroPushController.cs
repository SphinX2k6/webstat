using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Launcher.HotPatchPushSdk;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000EA1 RID: 3745
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class KuroPushController : ControllerBase<KuroPushController>
{
	// Token: 0x06005C9B RID: 23707 RVA: 0x001747AA File Offset: 0x001729AA
	public bool IfCanUsePush()
	{
		return false;
	}

	// Token: 0x06005C9C RID: 23708 RVA: 0x001747B0 File Offset: 0x001729B0
	protected override bool OnInit()
	{
		if (UKuroLauncherLibrary.IsFirstIntoLauncher())
		{
			this.FirstLaunchInitPush();
		}
		this.RefreshSettingByPushMode();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Push;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "current push clientId";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("clientId", this.GetClientId());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return true;
	}

	// Token: 0x06005C9D RID: 23709 RVA: 0x00174804 File Offset: 0x00172A04
	private UniTask FirstLaunchInitPush()
	{
		KuroPushController.<FirstLaunchInitPush>d__5 <FirstLaunchInitPush>d__;
		<FirstLaunchInitPush>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FirstLaunchInitPush>d__.<>4__this = this;
		<FirstLaunchInitPush>d__.<>1__state = -1;
		<FirstLaunchInitPush>d__.<>t__builder.Start<KuroPushController.<FirstLaunchInitPush>d__5>(ref <FirstLaunchInitPush>d__);
		return <FirstLaunchInitPush>d__.<>t__builder.Task;
	}

	// Token: 0x06005C9E RID: 23710 RVA: 0x00174848 File Offset: 0x00172A48
	private UniTask TryGetAndroidPushPermission()
	{
		KuroPushController.<TryGetAndroidPushPermission>d__6 <TryGetAndroidPushPermission>d__;
		<TryGetAndroidPushPermission>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryGetAndroidPushPermission>d__.<>4__this = this;
		<TryGetAndroidPushPermission>d__.<>1__state = -1;
		<TryGetAndroidPushPermission>d__.<>t__builder.Start<KuroPushController.<TryGetAndroidPushPermission>d__6>(ref <TryGetAndroidPushPermission>d__);
		return <TryGetAndroidPushPermission>d__.<>t__builder.Task;
	}

	// Token: 0x06005C9F RID: 23711 RVA: 0x0017488C File Offset: 0x00172A8C
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private UniTask<List<string>> RequestAndroidPermissions(TArray<string> permissions)
	{
		KuroPushController.<RequestAndroidPermissions>d__7 <RequestAndroidPermissions>d__;
		<RequestAndroidPermissions>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<string>>.Create();
		<RequestAndroidPermissions>d__.permissions = permissions;
		<RequestAndroidPermissions>d__.<>1__state = -1;
		<RequestAndroidPermissions>d__.<>t__builder.Start<KuroPushController.<RequestAndroidPermissions>d__7>(ref <RequestAndroidPermissions>d__);
		return <RequestAndroidPermissions>d__.<>t__builder.Task;
	}

	// Token: 0x06005CA0 RID: 23712 RVA: 0x001748D0 File Offset: 0x00172AD0
	[Conditional("KURO_PUSH_SDK")]
	public void BindCurrentLanguageTag()
	{
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Push;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "current push Language Tag";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", packageLanguage);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKuroPushSdkStaticLibrary.SetTag(packageLanguage, "push");
	}

	// Token: 0x06005CA1 RID: 23713 RVA: 0x00174920 File Offset: 0x00172B20
	private void RefreshSettingByPushMode()
	{
		int num = (this.GetPushState() > false) ? 1 : 0;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "刷新推送状态";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", num);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, EFunction.PushMode);
	}

	// Token: 0x06005CA2 RID: 23714 RVA: 0x00174978 File Offset: 0x00172B78
	private UniTask InitPushByNotiPermissionState()
	{
		KuroPushController.<InitPushByNotiPermissionState>d__10 <InitPushByNotiPermissionState>d__;
		<InitPushByNotiPermissionState>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPushByNotiPermissionState>d__.<>4__this = this;
		<InitPushByNotiPermissionState>d__.<>1__state = -1;
		<InitPushByNotiPermissionState>d__.<>t__builder.Start<KuroPushController.<InitPushByNotiPermissionState>d__10>(ref <InitPushByNotiPermissionState>d__);
		return <InitPushByNotiPermissionState>d__.<>t__builder.Task;
	}

	// Token: 0x06005CA3 RID: 23715 RVA: 0x001749BB File Offset: 0x00172BBB
	[Conditional("KURO_PUSH_SDK")]
	private void InitListener()
	{
		if (!this.ListenerState)
		{
			UKuroPushObject pushObject = UKuroPushSdkStaticLibrary.GetPushObject();
			if (pushObject != null)
			{
				pushObject.PushSdkMessageBluePrintDelegate.Add(new Action<string, string>(this.PushCallBack));
			}
		}
		this.ListenerState = true;
	}

	// Token: 0x06005CA4 RID: 23716 RVA: 0x001749F0 File Offset: 0x00172BF0
	[Conditional("KURO_PUSH_SDK")]
	public void RemovePushDelegate()
	{
		if (this.ListenerState)
		{
			UKuroPushObject pushObject = UKuroPushSdkStaticLibrary.GetPushObject();
			if (pushObject != null && pushObject.IsValid())
			{
				pushObject.PushSdkMessageBluePrintDelegate.Remove(new Action<string, string>(this.PushCallBack));
			}
			this.ListenerState = false;
		}
	}

	// Token: 0x06005CA5 RID: 23717 RVA: 0x00174A34 File Offset: 0x00172C34
	public void SetPushNotifyCall(Action<string, string> callBack)
	{
		this.OnPushNotifyCall = callBack;
	}

	// Token: 0x06005CA6 RID: 23718 RVA: 0x00174A3D File Offset: 0x00172C3D
	private void PushCallBack(string functionName, string result)
	{
		Action<string, string> onPushNotifyCall = this.OnPushNotifyCall;
		if (onPushNotifyCall == null)
		{
			return;
		}
		onPushNotifyCall(functionName, result);
	}

	// Token: 0x06005CA7 RID: 23719 RVA: 0x00174A51 File Offset: 0x00172C51
	public void SendLocalPush(string title, string desc, string exData)
	{
		HotPatchPushSdk.SendLocalPush(title, desc, exData);
	}

	// Token: 0x06005CA8 RID: 23720 RVA: 0x00174A5B File Offset: 0x00172C5B
	public void OpenNotification()
	{
		this.IfCanUsePush();
	}

	// Token: 0x06005CA9 RID: 23721 RVA: 0x00174A64 File Offset: 0x00172C64
	[NullableContext(0)]
	public UniTask<bool> GetPushNotiPermissionEnableState()
	{
		KuroPushController.<GetPushNotiPermissionEnableState>d__17 <GetPushNotiPermissionEnableState>d__;
		<GetPushNotiPermissionEnableState>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<GetPushNotiPermissionEnableState>d__.<>4__this = this;
		<GetPushNotiPermissionEnableState>d__.<>1__state = -1;
		<GetPushNotiPermissionEnableState>d__.<>t__builder.Start<KuroPushController.<GetPushNotiPermissionEnableState>d__17>(ref <GetPushNotiPermissionEnableState>d__);
		return <GetPushNotiPermissionEnableState>d__.<>t__builder.Task;
	}

	// Token: 0x06005CAA RID: 23722 RVA: 0x00174AA7 File Offset: 0x00172CA7
	public string GetClientId()
	{
		this.IfCanUsePush();
		return "";
	}

	// Token: 0x06005CAB RID: 23723 RVA: 0x00174AB8 File Offset: 0x00172CB8
	public UniTask TurnOnPush(bool checkPermissionState = true)
	{
		KuroPushController.<TurnOnPush>d__19 <TurnOnPush>d__;
		<TurnOnPush>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TurnOnPush>d__.<>4__this = this;
		<TurnOnPush>d__.checkPermissionState = checkPermissionState;
		<TurnOnPush>d__.<>1__state = -1;
		<TurnOnPush>d__.<>t__builder.Start<KuroPushController.<TurnOnPush>d__19>(ref <TurnOnPush>d__);
		return <TurnOnPush>d__.<>t__builder.Task;
	}

	// Token: 0x06005CAC RID: 23724 RVA: 0x00174B03 File Offset: 0x00172D03
	public void TurnOffPush()
	{
		this.RefreshSettingByPushMode();
	}

	// Token: 0x06005CAD RID: 23725 RVA: 0x00174B0B File Offset: 0x00172D0B
	public bool GetPushState()
	{
		return Singleton<LauncherStorageLib>.Instance.GetGlobal<bool>(ELauncherStorageGlobalKey.CachePushOpenState, false);
	}

	// Token: 0x06005CAE RID: 23726 RVA: 0x00174B19 File Offset: 0x00172D19
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x04002C34 RID: 11316
	private const string SELFDEFINESN = "push";

	// Token: 0x04002C35 RID: 11317
	private bool ListenerState;

	// Token: 0x04002C36 RID: 11318
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<string, string> OnPushNotifyCall;
}
