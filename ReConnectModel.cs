using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Launcher;
using UnrealEngine;

// Token: 0x0200275B RID: 10075
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ReConnectModel : ModelBase<ReConnectModel>
{
	// Token: 0x06013E12 RID: 81426 RVA: 0x0058A9E0 File Offset: 0x00588BE0
	protected override bool OnInit()
	{
		this.ClearReconnectData();
		this.TotalReConnectCount = 0;
		this.TryReConnectMaxCount = ConfigCommonParamById.GetIntConfig("max_try_reconnect_count").GetValueOrDefault(3);
		this.ReConnectMaxCount = ConfigCommonParamById.GetIntConfig("reconnect_count_per_try").GetValueOrDefault(3);
		this.ServerChannelCloseSeconds = ConfigCommonParamById.GetIntConfig("reconnect_channel_close_seconds").GetValueOrDefault(60);
		this.SilentTimeMs = ConfigCommonParamById.GetIntConfig("reconnect_show_mask_timeout_ms").GetValueOrDefault(1000);
		if (!UKismetSystemLibrary.GetCommandLine().Contains("-InfinityReconnect"))
		{
			this.DebugForeverTryReconnect = false;
		}
		else
		{
			this.DebugForeverTryReconnect = true;
			Singleton<Log>.Instance.Info(ELogModule.Reconnect, ELogAuthor.XMC, "[InfinityReconnect] Enable infinity reconnect.", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return true;
	}

	// Token: 0x06013E13 RID: 81427 RVA: 0x0058AAA1 File Offset: 0x00588CA1
	protected override bool OnClear()
	{
		this.ClearReconnectData();
		return true;
	}

	// Token: 0x06013E14 RID: 81428 RVA: 0x0058AAAA File Offset: 0x00588CAA
	public void ClearReconnectData()
	{
		this.ReConnectCount = 0;
		this.TryReconnectCount = 0;
		this.ResetReconnectStatus();
		this.ReconvTraceId = string.Empty;
	}

	// Token: 0x1700196A RID: 6506
	// (get) Token: 0x06013E15 RID: 81429 RVA: 0x0058AACB File Offset: 0x00588CCB
	public int ServerChannelCloseTimeMs
	{
		get
		{
			return this.ServerChannelCloseSeconds * 1000;
		}
	}

	// Token: 0x06013E16 RID: 81430 RVA: 0x0058AAD9 File Offset: 0x00588CD9
	public void AddRpc(int rpcId)
	{
		this.RpcSet.Add(rpcId);
	}

	// Token: 0x06013E17 RID: 81431 RVA: 0x0058AAE8 File Offset: 0x00588CE8
	public void DelRpc(int rpcId)
	{
		this.RpcSet.Remove(rpcId);
	}

	// Token: 0x06013E18 RID: 81432 RVA: 0x0058AAF7 File Offset: 0x00588CF7
	public bool IsRpcEmpty()
	{
		return this.RpcSet.Count <= 0;
	}

	// Token: 0x06013E19 RID: 81433 RVA: 0x0058AB0C File Offset: 0x00588D0C
	public string GetUnResponsedRpcStr()
	{
		string text = string.Empty;
		foreach (int value in this.RpcSet)
		{
			string str = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
			defaultInterpolatedStringHandler.AppendLiteral("[");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			defaultInterpolatedStringHandler.AppendLiteral("]");
			text = str + defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return text;
	}

	// Token: 0x06013E1A RID: 81434 RVA: 0x0058AB98 File Offset: 0x00588D98
	public bool IsReConnectMaxCount()
	{
		return this.ReConnectCount > this.ReConnectMaxCount;
	}

	// Token: 0x06013E1B RID: 81435 RVA: 0x0058ABA8 File Offset: 0x00588DA8
	public int GetReConnectCount()
	{
		return this.ReConnectCount;
	}

	// Token: 0x06013E1C RID: 81436 RVA: 0x0058ABB0 File Offset: 0x00588DB0
	public void ReSetReConnectCount()
	{
		this.ReConnectCount = 0;
	}

	// Token: 0x06013E1D RID: 81437 RVA: 0x0058ABB9 File Offset: 0x00588DB9
	public int AddReConnectCount()
	{
		this.ReConnectCount++;
		this.TotalReConnectCount++;
		return this.ReConnectCount;
	}

	// Token: 0x06013E1E RID: 81438 RVA: 0x0058ABDD File Offset: 0x00588DDD
	public bool IsTryMaxCount()
	{
		return !this.DebugForeverTryReconnect && this.TryReconnectCount >= this.TryReConnectMaxCount;
	}

	// Token: 0x06013E1F RID: 81439 RVA: 0x0058ABFA File Offset: 0x00588DFA
	public void AddTryCount()
	{
		this.TryReconnectCount++;
	}

	// Token: 0x06013E20 RID: 81440 RVA: 0x0058AC0A File Offset: 0x00588E0A
	public int GetTryCount()
	{
		return this.TryReconnectCount;
	}

	// Token: 0x1700196B RID: 6507
	// (get) Token: 0x06013E21 RID: 81441 RVA: 0x0058AC12 File Offset: 0x00588E12
	public int GetTotalReConnectCount
	{
		get
		{
			return this.TotalReConnectCount;
		}
	}

	// Token: 0x06013E22 RID: 81442 RVA: 0x0058AC1A File Offset: 0x00588E1A
	public EReConnectStatus GetReConnectStatus()
	{
		return this.ReConnectStatus;
	}

	// Token: 0x06013E23 RID: 81443 RVA: 0x0058AC22 File Offset: 0x00588E22
	public void ResetReconnectStatus()
	{
		this.ReConnectStatus = EReConnectStatus.NoReConnect;
	}

	// Token: 0x06013E24 RID: 81444 RVA: 0x0058AC2B File Offset: 0x00588E2B
	public void SetReconnectDoing()
	{
		this.ReConnectStatus = EReConnectStatus.ReConnectDoing;
	}

	// Token: 0x06013E25 RID: 81445 RVA: 0x0058AC34 File Offset: 0x00588E34
	public void CancelShowMaskTimer()
	{
		if (this.ShowMaskTimer != null)
		{
			TimerSystem.Instance.Remove(this.ShowMaskTimer);
			this.ShowMaskTimer = null;
		}
	}

	// Token: 0x06013E26 RID: 81446 RVA: 0x0058AC58 File Offset: 0x00588E58
	public void StartShowMaskTimer(Action callback)
	{
		this.ShowMaskTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			callback();
			this.ShowMaskTimer = null;
		}, (float)this.SilentTimeMs, null, null, true, 1f);
	}

	// Token: 0x06013E27 RID: 81447 RVA: 0x0058ACA4 File Offset: 0x00588EA4
	public void SetCurIncId()
	{
		this.CurIncId = this.ReConnectIncId;
	}

	// Token: 0x06013E28 RID: 81448 RVA: 0x0058ACB2 File Offset: 0x00588EB2
	public bool IsReConnectIdSame()
	{
		return this.CurIncId == this.ReConnectIncId;
	}

	// Token: 0x06013E29 RID: 81449 RVA: 0x0058ACC2 File Offset: 0x00588EC2
	public void AddReConnectIncId()
	{
		this.ReConnectIncId++;
	}

	// Token: 0x1700196C RID: 6508
	// (get) Token: 0x06013E2A RID: 81450 RVA: 0x0058ACD2 File Offset: 0x00588ED2
	// (set) Token: 0x06013E2B RID: 81451 RVA: 0x0058ACDA File Offset: 0x00588EDA
	[Nullable(2)]
	public Action DisconnectedFunction
	{
		[NullableContext(2)]
		get
		{
			return this.DisconnectedFunctionInternal;
		}
		[NullableContext(2)]
		set
		{
			this.DisconnectedFunctionInternal = value;
		}
	}

	// Token: 0x1700196D RID: 6509
	// (get) Token: 0x06013E2C RID: 81452 RVA: 0x0058ACE3 File Offset: 0x00588EE3
	// (set) Token: 0x06013E2D RID: 81453 RVA: 0x0058ACEB File Offset: 0x00588EEB
	public string ReconvTraceId
	{
		get
		{
			return this.ReconvTraceIdInternal;
		}
		set
		{
			this.ReconvTraceIdInternal = value;
		}
	}

	// Token: 0x1700196E RID: 6510
	// (get) Token: 0x06013E2E RID: 81454 RVA: 0x0058ACF4 File Offset: 0x00588EF4
	// (set) Token: 0x06013E2F RID: 81455 RVA: 0x0058ACFC File Offset: 0x00588EFC
	public unsafe ENetworkType LastNetworkType
	{
		get
		{
			return this.LastNetworkTypeInternal;
		}
		set
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Reconnect;
			ELogAuthor author = ELogAuthor.MZJ;
			string message = "set LastNetworkType";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("old", this.LastNetworkTypeInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("new", value);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.LastNetworkTypeInternal = value;
		}
	}

	// Token: 0x1700196F RID: 6511
	// (get) Token: 0x06013E30 RID: 81456 RVA: 0x0058AD72 File Offset: 0x00588F72
	public UKuroNetworkChange NetworkListener
	{
		get
		{
			if (this.NetworkListenerInternal == null)
			{
				this.NetworkListenerInternal = new UKuroNetworkChange();
			}
			return this.NetworkListenerInternal;
		}
	}

	// Token: 0x04009AB4 RID: 39604
	private bool DebugForeverTryReconnect;

	// Token: 0x04009AB5 RID: 39605
	private int ReConnectIncId;

	// Token: 0x04009AB6 RID: 39606
	private int ReConnectCount;

	// Token: 0x04009AB7 RID: 39607
	private int TryReconnectCount;

	// Token: 0x04009AB8 RID: 39608
	private EReConnectStatus ReConnectStatus;

	// Token: 0x04009AB9 RID: 39609
	private int TotalReConnectCount;

	// Token: 0x04009ABA RID: 39610
	private readonly HashSet<int> RpcSet = new HashSet<int>();

	// Token: 0x04009ABB RID: 39611
	private int TryReConnectMaxCount;

	// Token: 0x04009ABC RID: 39612
	private int ReConnectMaxCount;

	// Token: 0x04009ABD RID: 39613
	private int CurIncId;

	// Token: 0x04009ABE RID: 39614
	[Nullable(2)]
	private TimerHandle ShowMaskTimer;

	// Token: 0x04009ABF RID: 39615
	private int SilentTimeMs = 1000;

	// Token: 0x04009AC0 RID: 39616
	private int ServerChannelCloseSeconds = 60;

	// Token: 0x04009AC1 RID: 39617
	[Nullable(2)]
	private Action DisconnectedFunctionInternal;

	// Token: 0x04009AC2 RID: 39618
	private string ReconvTraceIdInternal = string.Empty;

	// Token: 0x04009AC3 RID: 39619
	private ENetworkType LastNetworkTypeInternal = ENetworkType.None;

	// Token: 0x04009AC4 RID: 39620
	[Nullable(2)]
	private UKuroNetworkChange NetworkListenerInternal;
}
