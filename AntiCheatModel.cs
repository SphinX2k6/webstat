using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using UnrealEngine;

// Token: 0x0200179A RID: 6042
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class AntiCheatModel : ModelBase<AntiCheatModel>
{
	// Token: 0x0600AA98 RID: 43672 RVA: 0x002D916A File Offset: 0x002D736A
	public string GetVersion()
	{
		return this.Version;
	}

	// Token: 0x0600AA99 RID: 43673 RVA: 0x002D9172 File Offset: 0x002D7372
	public string GetBundleId()
	{
		return this.BundleId;
	}

	// Token: 0x0600AA9A RID: 43674 RVA: 0x002D917C File Offset: 0x002D737C
	protected override bool OnInit()
	{
		string appVersion = UKuroLauncherLibrary.GetAppVersion();
		this.Version = LocalStorage.GetDeviceSaved<string>(ELocalStorageDeviceKey.PatchVersion, appVersion);
		this.BundleId = UKismetSystemLibrary.GetGameBundleId();
		return true;
	}

	// Token: 0x0600AA9B RID: 43675 RVA: 0x002D91A8 File Offset: 0x002D73A8
	public static AntiCheatBundleData GetBundleData()
	{
		AntiCheatBundleData antiCheatBundleData = new AntiCheatBundleData();
		antiCheatBundleData.event_id = "8";
		string unique_id = ModelBase<LoginModel>.Instance.GetAccount();
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			unique_id = ModelBase<LoginModel>.Instance.GetSdkLoginConfig().Uid;
		}
		antiCheatBundleData.unique_id = unique_id;
		antiCheatBundleData.s_bundle_id = ModelBase<AntiCheatModel>.Instance.GetBundleId();
		antiCheatBundleData.s_version = ModelBase<AntiCheatModel>.Instance.GetVersion();
		return antiCheatBundleData;
	}

	// Token: 0x0600AA9C RID: 43676 RVA: 0x002D9213 File Offset: 0x002D7413
	public void ResetHeartbeatException()
	{
		this.HeartbeatExceptionCount = 0;
	}

	// Token: 0x0600AA9D RID: 43677 RVA: 0x002D921C File Offset: 0x002D741C
	public void HitHeartbeatException()
	{
		this.HeartbeatExceptionCount++;
	}

	// Token: 0x0600AA9E RID: 43678 RVA: 0x002D922C File Offset: 0x002D742C
	public int GetHeartbeatException()
	{
		return this.HeartbeatExceptionCount;
	}

	// Token: 0x0600AA9F RID: 43679 RVA: 0x002D9234 File Offset: 0x002D7434
	public bool HasHeartbeatException()
	{
		return this.HeartbeatExceptionCount > 0;
	}

	// Token: 0x0600AAA0 RID: 43680 RVA: 0x002D9240 File Offset: 0x002D7440
	public AntiCheatHeartbeatData GetHeartbeatData()
	{
		AntiCheatHeartbeatData antiCheatHeartbeatData = new AntiCheatHeartbeatData();
		antiCheatHeartbeatData.event_id = "9";
		string unique_id = ModelBase<LoginModel>.Instance.GetAccount();
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			unique_id = ModelBase<LoginModel>.Instance.GetSdkLoginConfig().Uid;
		}
		antiCheatHeartbeatData.unique_id = unique_id;
		antiCheatHeartbeatData.i_exception_count = this.HeartbeatExceptionCount;
		return antiCheatHeartbeatData;
	}

	// Token: 0x04005029 RID: 20521
	private const string BUNDLE_DATA_EVENT_ID = "8";

	// Token: 0x0400502A RID: 20522
	private const string HEARTBEAT_DATA_EVENT_ID = "9";

	// Token: 0x0400502B RID: 20523
	private string Version = "";

	// Token: 0x0400502C RID: 20524
	private string BundleId = "";

	// Token: 0x0400502D RID: 20525
	private int HeartbeatExceptionCount;
}
