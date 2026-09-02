using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000BDF RID: 3039
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PerfSight : Singleton<PerfSight>
{
	// Token: 0x060031FA RID: 12794 RVA: 0x0002044C File Offset: 0x0001E64C
	public bool Initialize()
	{
		if (!this.IsEnable)
		{
			return true;
		}
		bool flag = Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN";
		if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			if (flag)
			{
				UPerfSightHelper.SetPCServerURL("pc.perfsight.wetest.net");
			}
			else
			{
				UPerfSightHelper.SetPCServerURL("pc.perfsight.qq.com");
			}
		}
		if (flag)
		{
			UPerfSightHelper.InitContext("424155224");
		}
		else
		{
			UPerfSightHelper.InitContext("688476493");
		}
		FKuroPerfSightHelper.SetFlameGraphQueueSize(20480);
		FKuroPerfSightHelper.SetFlameGraphDropThresholds(Singleton<Info>.Instance.IsPlayInEditor ? 100000 : 50000);
		if (!Singleton<Info>.Instance.IsPlayInEditor && !Singleton<Info>.Instance.IsPs5Platform())
		{
			FKuroPerfSightHelper.RegisterOnFrameBegin("FrameTime");
			FKuroPerfSightHelper.RegisterTickGroupEvent();
		}
		return true;
	}

	// Token: 0x060031FB RID: 12795 RVA: 0x0002050A File Offset: 0x0001E70A
	public void SetPcAppVersion(string version)
	{
		UPerfSightHelper.SetPCAppVersion(version);
	}

	// Token: 0x060031FC RID: 12796 RVA: 0x00020512 File Offset: 0x0001E712
	public void SetVersionIden(string version)
	{
		UPerfSightHelper.SetVersionIden(version);
	}

	// Token: 0x060031FD RID: 12797 RVA: 0x0002051A File Offset: 0x0001E71A
	[NullableContext(2)]
	public void PostEvent(int key, string info = null)
	{
		UPerfSightHelper.PostEvent(key, info);
	}

	// Token: 0x060031FE RID: 12798 RVA: 0x00020523 File Offset: 0x0001E723
	public void MarkLevelLoad(string sceneName, int? quality = null)
	{
		UPerfSightHelper.MarkLevelLoad(sceneName, quality.GetValueOrDefault());
	}

	// Token: 0x060031FF RID: 12799 RVA: 0x00020532 File Offset: 0x0001E732
	public void MarkLevelFin()
	{
		UPerfSightHelper.MarkLevelFin();
	}

	// Token: 0x06003200 RID: 12800 RVA: 0x00020539 File Offset: 0x0001E739
	public void MarkLevelLoadCompleted()
	{
		UPerfSightHelper.MarkLevelLoadCompleted();
	}

	// Token: 0x06003201 RID: 12801 RVA: 0x00020540 File Offset: 0x0001E740
	public void SetUserId(string playerId)
	{
		UPerfSightHelper.SetUserId(playerId);
	}

	// Token: 0x06003202 RID: 12802 RVA: 0x00020548 File Offset: 0x0001E748
	[NullableContext(2)]
	public void PostNetworkLatency(int latency, string customInfo = null, string ipAddress = null)
	{
		UPerfSightHelper.PostNetworkLatency(latency, customInfo, ipAddress);
	}

	// Token: 0x040004E5 RID: 1253
	private const bool DEBUG_LOG = false;

	// Token: 0x040004E6 RID: 1254
	private const string APP_ID_LOCAL = "688476493";

	// Token: 0x040004E7 RID: 1255
	private const string APP_ID_GLOBAL = "424155224";

	// Token: 0x040004E8 RID: 1256
	public bool IsEnable = true;
}
