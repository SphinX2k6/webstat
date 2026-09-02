using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Extensions;
using CSharpScript.Game.Common.Event;
using CSharpScript.Typing;
using Google.Protobuf;
using UnrealEngine;

// Token: 0x020020EA RID: 8426
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class Heartbeat : Singleton<Heartbeat>
{
	// Token: 0x06010174 RID: 65908 RVA: 0x0046A262 File Offset: 0x00468462
	public int GetHeartbeatInterval()
	{
		return this.HeartbeatInterval;
	}

	// Token: 0x06010175 RID: 65909 RVA: 0x0046A26A File Offset: 0x0046846A
	public void SendHeartbeatImmediately()
	{
		this.SinceLastSendTimeMs = 9999999;
	}

	// Token: 0x06010176 RID: 65910 RVA: 0x0046A277 File Offset: 0x00468477
	public void SetMaxTimeOutHandler(Action handler)
	{
		this.MaxTimeOutHandler = handler;
	}

	// Token: 0x06010177 RID: 65911 RVA: 0x0046A280 File Offset: 0x00468480
	public unsafe void BeginHeartBeat(HeartbeatDefine.EBeginHeartbeat reason)
	{
		this.IsHeartBeatOpen = true;
		this.IsWaitingResponse = false;
		this.LastTickMs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
		this.CurTimeOutCount = 0;
		this.SetHeartBeatMode(HeartbeatDefine.EHeartBeatType.NormalHeartBeat);
		this.SendHeartbeatImmediately();
		Singleton<EventSystem>.Instance.Emit(EEventName.StartHeartBeat);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Heartbeat;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "开启心跳";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MaxTimeOutCount", this.TimeOutMaxCount);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ConnectTimeOut", this.ConnectTimeOut);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("HeartbeatInterval", this.HeartbeatInterval);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", reason.ToString());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
	}

	// Token: 0x06010178 RID: 65912 RVA: 0x0046A384 File Offset: 0x00468584
	public void SetHeartBeatMode(HeartbeatDefine.EHeartBeatType type)
	{
		HeartbeatDefine.EHeartBeatType? currentHeartBeatState = this.CurrentHeartBeatState;
		if (type == currentHeartBeatState.GetValueOrDefault() & currentHeartBeatState != null)
		{
			return;
		}
		this.CurrentHeartBeatState = new HeartbeatDefine.EHeartBeatType?(type);
		if (type == HeartbeatDefine.EHeartBeatType.NormalHeartBeat)
		{
			this.TimeOutMaxCount = ConfigCommonParamById.GetIntConfig("normal_heartbeat_timeout_reconnect").GetValueOrDefault(3);
			this.ConnectTimeOut = ConfigCommonParamById.GetIntConfig("normal_heartbeat_timeout_ms").GetValueOrDefault(3000);
			this.HeartbeatInterval = ConfigCommonParamById.GetIntConfig("normal_heartbeat_interval_ms").GetValueOrDefault(7000);
			return;
		}
		if (type != HeartbeatDefine.EHeartBeatType.BattleHeartBeat)
		{
			return;
		}
		this.TimeOutMaxCount = ConfigCommonParamById.GetIntConfig("battle_heartbeat_timeout_reconnect").GetValueOrDefault(3);
		this.ConnectTimeOut = ConfigCommonParamById.GetIntConfig("battle_heartbeat_timeout_ms").GetValueOrDefault(900);
		this.HeartbeatInterval = ConfigCommonParamById.GetIntConfig("battle_heartbeat_interval_ms").GetValueOrDefault(1000);
	}

	// Token: 0x06010179 RID: 65913 RVA: 0x0046A46C File Offset: 0x0046866C
	public unsafe void StopHeartBeat(HeartbeatDefine.EStopHeartbeat reason)
	{
		this.IsHeartBeatOpen = false;
		int curTimeOutCount = this.CurTimeOutCount;
		this.CurTimeOutCount = 0;
		this.SetHeartBeatMode(HeartbeatDefine.EHeartBeatType.NormalHeartBeat);
		Singleton<EventSystem>.Instance.Emit(EEventName.StopHeartBeat);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Heartbeat;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "结束心跳";
		<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MaxTimeOutCount", this.TimeOutMaxCount);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ConnectTimeOut", this.ConnectTimeOut);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("HeartbeatInterval", this.HeartbeatInterval);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("TimeOutCount", curTimeOutCount);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4);
		string item = "Reason";
		HeartbeatDefine.EStopHeartbeat estopHeartbeat = reason;
		ptr = new ValueTuple<string, object>(item, estopHeartbeat.ToString());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
	}

	// Token: 0x0601017A RID: 65914 RVA: 0x0046A574 File Offset: 0x00468774
	private void AddTimeOutCount()
	{
		this.CurTimeOutCount++;
		if (!this.IsHeartBeatOpen)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Heartbeat;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "心跳超时";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("次数", this.CurTimeOutCount);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (this.CurTimeOutCount < this.TimeOutMaxCount)
		{
			this.SendHeartbeatImmediately();
			return;
		}
		TimerSystem.Instance.Next(delegate(float handleId)
		{
			Action maxTimeOutHandler = this.MaxTimeOutHandler;
			if (maxTimeOutHandler == null)
			{
				return;
			}
			maxTimeOutHandler();
		}, null, null);
	}

	// Token: 0x0601017B RID: 65915 RVA: 0x0046A5F9 File Offset: 0x004687F9
	public void RegisterTick()
	{
		if (this.TickTimerHandle == null)
		{
			this.TickTimerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.Tick), 20f, 1f, null, null, true);
		}
	}

	// Token: 0x0601017C RID: 65916 RVA: 0x0046A62C File Offset: 0x0046882C
	private void Tick(float deltaMs)
	{
		if (!this.IsHeartBeatOpen)
		{
			return;
		}
		long num = DateTimeOffset.Now.ToUnixTimeMilliseconds();
		float num2 = Math.Max((float)(num - this.LastTickMs), deltaMs);
		this.SinceLastSendTimeMs += (int)num2;
		this.LastTickMs = num;
		if (this.SinceLastSendTimeMs < this.HeartbeatInterval)
		{
			return;
		}
		if (this.IsWaitingResponse)
		{
			return;
		}
		this.SendHeartbeat();
	}

	// Token: 0x0601017D RID: 65917 RVA: 0x0046A694 File Offset: 0x00468894
	private void SendHeartbeat()
	{
		this.SinceLastSendTimeMs = 0;
		HeartbeatRequest heartbeatRequest = new HeartbeatRequest();
		FArrayBuffer antiData = FTpSafeProxy.GetAntiData2();
		if (antiData.Length > 0UL)
		{
			heartbeatRequest.ReportData = ByteString.CopyFrom(antiData.ToByteArray());
		}
		Singleton<Net>.Instance.Call<HeartbeatResponse>(ERequestMessageId.HeartbeatRequest, heartbeatRequest, new Action<HeartbeatResponse, Net.CallbackStatus>(this.HeartbeatResponse), this.ConnectTimeOut);
		this.IsWaitingResponse = true;
		Singleton<EventSystem>.Instance.Emit(EEventName.SendHeartbeat);
	}

	// Token: 0x0601017E RID: 65918 RVA: 0x0046A705 File Offset: 0x00468905
	private void HeartbeatResponse(HeartbeatResponse response, [Nullable(2)] Net.CallbackStatus status)
	{
		this.IsWaitingResponse = false;
		if (response == null)
		{
			this.AddTimeOutCount();
		}
	}

	// Token: 0x04007B5F RID: 31583
	private bool IsHeartBeatOpen;

	// Token: 0x04007B60 RID: 31584
	private bool IsWaitingResponse;

	// Token: 0x04007B61 RID: 31585
	private int CurTimeOutCount;

	// Token: 0x04007B62 RID: 31586
	public int TimeOutMaxCount;

	// Token: 0x04007B63 RID: 31587
	private int ConnectTimeOut;

	// Token: 0x04007B64 RID: 31588
	private int HeartbeatInterval;

	// Token: 0x04007B65 RID: 31589
	private int SinceLastSendTimeMs;

	// Token: 0x04007B66 RID: 31590
	private long LastTickMs;

	// Token: 0x04007B67 RID: 31591
	[Nullable(2)]
	private TimerHandle TickTimerHandle;

	// Token: 0x04007B68 RID: 31592
	private Action MaxTimeOutHandler;

	// Token: 0x04007B69 RID: 31593
	private HeartbeatDefine.EHeartBeatType? CurrentHeartBeatState;
}
