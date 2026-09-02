using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Extensions;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform;
using CSharpScript.Typing;
using Google.Protobuf;
using UnrealEngine;

// Token: 0x02000FB2 RID: 4018
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ThirdPartySdkManager : Singleton<ThirdPartySdkManager>
{
	// Token: 0x060066F1 RID: 26353 RVA: 0x0019F544 File Offset: 0x0019D744
	public void Init()
	{
		string packageConfigOrDefault = Singleton<BaseConfigController>.Instance.GetPackageConfigOrDefault("Stream", null);
		string packageConfigOrDefault2 = Singleton<BaseConfigController>.Instance.GetPackageConfigOrDefault("Changelist", "");
		FCrashSightProxy.SetBranchInfo(packageConfigOrDefault, packageConfigOrDefault2);
		string appChangeList = UKuroLauncherLibrary.GetAppChangeList();
		FCrashSightProxy.SetCustomData("AppChangelist", appChangeList);
		if (UKuroStaticLibrary.IsModuleLoaded("TpSafe"))
		{
			if (this.AceDataTransferTimerId != null)
			{
				TimerSystem.Instance.Remove(this.AceDataTransferTimerId);
				this.AceDataTransferTimerId = null;
			}
			this.InitDataTransferTimerForTpSafe();
			Singleton<Net>.Instance.Register<AceAntiDataNotify>(ENotifyMessageId.AceAntiDataNotify, new Action<AceAntiDataNotify, Net.CallbackStatus>(this.AceAntiDataNotify));
		}
		if (Singleton<Platform>.Instance.IsAndroidPlatform())
		{
			bool flag = UKuroAudioStatics.IsAndroidApiUsingOpenSL();
			FCrashSightProxy.SetCustomData("AudioAPI", flag ? "OpenSL" : "AAudio");
		}
		this.TestCrashSight();
	}

	// Token: 0x060066F2 RID: 26354 RVA: 0x0019F60C File Offset: 0x0019D80C
	private void TestCrashSight()
	{
		if (UBlueprintPathsLibrary.FileExists(UKuroLauncherLibrary.GameSavedDir() + "crashes/trigger"))
		{
			Singleton<Log>.Instance.Error(ELogModule.Login, ELogAuthor.LRA, "崩溃测试！", default(ReadOnlySpan<ValueTuple<string, object>>));
			FCrashSightProxy.Test();
		}
	}

	// Token: 0x060066F3 RID: 26355 RVA: 0x0019F650 File Offset: 0x0019D850
	public void SetUserInfo(string userId)
	{
		if (userId == "")
		{
			return;
		}
		this.SetUserIdForCrashSight(userId);
	}

	// Token: 0x060066F4 RID: 26356 RVA: 0x0019F667 File Offset: 0x0019D867
	private void SetUserIdForCrashSight(string userId)
	{
		FCrashSightProxy.SetUserId(userId);
	}

	// Token: 0x060066F5 RID: 26357 RVA: 0x0019F670 File Offset: 0x0019D870
	public void SetUserInfoForTpSafe(string userId, int playerId)
	{
		FCrashSightProxy.SetCustomData("PlayerId", playerId.ToString());
		if (UKuroStaticLibrary.IsModuleLoaded("TpSafe"))
		{
			int accountTypeByChannel = this.GetAccountTypeByChannel();
			int worldId = 0;
			FTpSafeProxy.SetUserInfo(accountTypeByChannel, worldId, userId, playerId);
		}
	}

	// Token: 0x060066F6 RID: 26358 RVA: 0x0019F6AC File Offset: 0x0019D8AC
	public void InitDataTransferTimerForTpSafe()
	{
		int num = 4000;
		if (Singleton<Platform>.Instance.IsWindowsPlatform())
		{
			num = 100;
		}
		this.AceDataTransferTimerId = TimerSystem.Instance.Forever(delegate(float _)
		{
			this.SendAceData();
		}, (float)num, 1f, null, null, true);
	}

	// Token: 0x060066F7 RID: 26359 RVA: 0x0019F6F4 File Offset: 0x0019D8F4
	private void SendAceData()
	{
		if (!Singleton<Net>.Instance.IsServerConnected())
		{
			return;
		}
		FArrayBuffer antiData = FTpSafeProxy.GetAntiData();
		if (antiData.Length > 0UL)
		{
			AceAntiDataPush aceAntiDataPush = AceAntiDataPush.Create();
			aceAntiDataPush.AntiData = ByteString.CopyFrom(antiData.ToByteArray());
			Singleton<Net>.Instance.Send(EPushMessageId.AceAntiDataPush, aceAntiDataPush);
		}
	}

	// Token: 0x060066F8 RID: 26360 RVA: 0x0019F748 File Offset: 0x0019D948
	private unsafe void AceAntiDataNotify(AceAntiDataNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		byte[] array = data.AntiData.ToByteArray();
		byte[] array2;
		byte* data2;
		if ((array2 = array) == null || array2.Length == 0)
		{
			data2 = null;
		}
		else
		{
			data2 = &array2[0];
		}
		FArrayBuffer farrayBuffer = new FArrayBuffer
		{
			Data = (void*)data2,
			Length = (ulong)((long)array.Length)
		};
		FTpSafeProxy.RecvAntiData(farrayBuffer);
		array2 = null;
	}

	// Token: 0x060066F9 RID: 26361 RVA: 0x0019F7A0 File Offset: 0x0019D9A0
	private int GetAccountTypeByChannel()
	{
		if (Singleton<Platform>.Instance.IsWindowsPlatform())
		{
			return 601;
		}
		return 99;
	}

	// Token: 0x060066FA RID: 26362 RVA: 0x0019F7B6 File Offset: 0x0019D9B6
	public void Logout()
	{
		FTpSafeProxy.Logout();
	}

	// Token: 0x060066FB RID: 26363 RVA: 0x0019F7BD File Offset: 0x0019D9BD
	public void Clear()
	{
		if (this.AceDataTransferTimerId != null)
		{
			TimerSystem.Instance.Remove(this.AceDataTransferTimerId);
			this.AceDataTransferTimerId = null;
		}
	}

	// Token: 0x0400313F RID: 12607
	private const int ACE_DATA_TRANSFER_INTERVAL_PC = 100;

	// Token: 0x04003140 RID: 12608
	private const int ACE_DATA_TRANSFER_INTERVAL_MOBILE = 4000;

	// Token: 0x04003141 RID: 12609
	[Nullable(2)]
	private TimerHandle AceDataTransferTimerId;
}
