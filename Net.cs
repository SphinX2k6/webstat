using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Core.Extensions;
using CSharpScript.Core.Net;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf;
using UnrealEngine;

// Token: 0x02000BCA RID: 3018
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class Net : Singleton<Net>
{
	// Token: 0x170000B3 RID: 179
	// (get) Token: 0x06003145 RID: 12613 RVA: 0x0001BEE3 File Offset: 0x0001A0E3
	public float RttMs
	{
		get
		{
			return Singleton<NetInfo>.Instance.RttMs;
		}
	}

	// Token: 0x170000B4 RID: 180
	// (get) Token: 0x06003146 RID: 12614 RVA: 0x0001BEEF File Offset: 0x0001A0EF
	public float LastReceiveTimeMs
	{
		get
		{
			return (float)this.LastReceiveTimeMsInternal;
		}
	}

	// Token: 0x06003147 RID: 12615 RVA: 0x0001BEF8 File Offset: 0x0001A0F8
	public void StartReconnecting()
	{
		this.IsReconnecting = true;
	}

	// Token: 0x06003148 RID: 12616 RVA: 0x0001BF01 File Offset: 0x0001A101
	private void EndReconnecting()
	{
		this.IsReconnecting = false;
	}

	// Token: 0x06003149 RID: 12617 RVA: 0x0001BF0A File Offset: 0x0001A10A
	public bool IsServerConnected()
	{
		return this.IsReconnecting || this.LoginState == Net.EServerLoginState.FinishedLogin;
	}

	// Token: 0x0600314A RID: 12618 RVA: 0x0001BF1F File Offset: 0x0001A11F
	public bool IsFinishLogin()
	{
		return this.LoginState == Net.EServerLoginState.FinishedLogin;
	}

	// Token: 0x0600314B RID: 12619 RVA: 0x0001BF2A File Offset: 0x0001A12A
	public void ChangeState1()
	{
		this.LoginState = Net.EServerLoginState.AskingProtoKey;
	}

	// Token: 0x0600314C RID: 12620 RVA: 0x0001BF33 File Offset: 0x0001A133
	private void ChangeStateKeyReady()
	{
		if (this.LoginState != Net.EServerLoginState.AskingProtoKey)
		{
			this.PrintChangeStateError(Net.EServerLoginState.ProtoKeyReady);
		}
		this.LoginState = Net.EServerLoginState.ProtoKeyReady;
	}

	// Token: 0x0600314D RID: 12621 RVA: 0x0001BF4C File Offset: 0x0001A14C
	private bool IsProtoKeyReady()
	{
		return this.LoginState >= Net.EServerLoginState.ProtoKeyReady && this.LoginState <= Net.EServerLoginState.FinishedLogin;
	}

	// Token: 0x0600314E RID: 12622 RVA: 0x0001BF65 File Offset: 0x0001A165
	public void ChangeStateEnterGame()
	{
		if (this.LoginState != Net.EServerLoginState.ProtoKeyReady && this.LoginState != Net.EServerLoginState.DoingLogin)
		{
			this.PrintChangeStateError(Net.EServerLoginState.DoingLogin);
		}
		this.LoginState = Net.EServerLoginState.DoingLogin;
	}

	// Token: 0x0600314F RID: 12623 RVA: 0x0001BF87 File Offset: 0x0001A187
	private void ChangeStateFinishLogin()
	{
		if (this.LoginState != Net.EServerLoginState.DoingLogin)
		{
			this.PrintChangeStateError(Net.EServerLoginState.FinishedLogin);
		}
		this.LoginState = Net.EServerLoginState.FinishedLogin;
		this.EndReconnecting();
	}

	// Token: 0x06003150 RID: 12624 RVA: 0x0001BFA6 File Offset: 0x0001A1A6
	public bool IsNotifyCallbackPaused()
	{
		return this.IsNotifyCallbackPausedInternal;
	}

	// Token: 0x06003151 RID: 12625 RVA: 0x0001BFB0 File Offset: 0x0001A1B0
	public void PauseAllNotifyCallback()
	{
		this.IsNotifyCallbackPausedInternal = true;
		Singleton<Log>.Instance.Info(ELogModule.Net, ELogAuthor.MZJ, "暂停消息处理", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06003152 RID: 12626 RVA: 0x0001BFE0 File Offset: 0x0001A1E0
	public void ResumeAllNotifyCallback()
	{
		this.IsNotifyCallbackPausedInternal = false;
		Singleton<Log>.Instance.Info(ELogModule.Net, ELogAuthor.MZJ, "恢复消息处理", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06003153 RID: 12627 RVA: 0x0001C010 File Offset: 0x0001A210
	private unsafe void PrintChangeStateError(Net.EServerLoginState destState)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Net;
		ELogAuthor author = ELogAuthor.MZJ;
		string message = "状态切换错误";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Current", this.LoginState);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Dest", destState);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06003154 RID: 12628 RVA: 0x0001C07F File Offset: 0x0001A27F
	public void SetNetworkErrorHandle(Net.TNetworkErrorHandle handle)
	{
		this.NetErrorHandle = handle;
	}

	// Token: 0x06003155 RID: 12629 RVA: 0x0001C088 File Offset: 0x0001A288
	public void SetExceptionHandle(Net.TExceptionHandle handle)
	{
		this.ExceptionHandle = handle;
	}

	// Token: 0x06003156 RID: 12630 RVA: 0x0001C091 File Offset: 0x0001A291
	public void SetAddRequestMaskHandle(Action<int> handle)
	{
		this.AddRequestMaskHandle = handle;
	}

	// Token: 0x06003157 RID: 12631 RVA: 0x0001C09A File Offset: 0x0001A29A
	public void SetRemoveRequestMaskHandle(Action<int> handle)
	{
		this.RemoveRequestMaskHandle = handle;
	}

	// Token: 0x06003158 RID: 12632 RVA: 0x0001C0A4 File Offset: 0x0001A2A4
	public bool Initialize()
	{
		this.SetKcpConnectStatus(Net.EKcpConnectStatus.NoConnect);
		this.KcpClient = new UKuroKcpClient();
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
		{
			this.KcpClient.UseNewResolveIp = false;
		}
		this.KcpClient.IsTickDrivenOutside = true;
		this.KcpClient.OnConnectSuccess.Add(new Action(this.OnKcpConnectSuccess));
		this.KcpClient.OnRecResp.Bind(new Action<int, short, ushort, FArrayBuffer>(this.OnReceiveResponse));
		this.KcpClient.OnRecException.Bind(new Action<int, short, uint, FArrayBuffer>(this.OnReceiveException));
		this.KcpClient.OnRecTcpException.Bind(new Action<uint>(this.OnReceiveTcpException));
		this.KcpClient.OnRecPush.Bind(new Action<int, ushort, FArrayBuffer>(this.OnReceivePush));
		this.KcpClient.OnError.Bind(new Action<int, int, int, int, int>(this.OnError));
		this.KcpClient.SetEnType(2, 111);
		this.KcpClient.SetEnType(2, 112);
		bool disableCrc = false;
		UKuroVariableFunctionLibrary.GetBoolValue("DisableCrc", ref disableCrc);
		Singleton<NetInfo>.Instance.DisableCrc = disableCrc;
		this.RpcId = 0;
		this.UpStreamSeqNo = 0;
		this.DownStreamSeqNo = 0;
		if (!Singleton<Info>.Instance.IsBuildShipping)
		{
			this.IsNetLogEnabled = true;
			this.IsNetStatEnable = true;
			this.IsHeartLogEnabled = true;
			this.IsSyncLogEnabled = true;
			this.KcpClient.OpenSendVerify = true;
		}
		this.FillMessageNameAndStatMap(NetDefine.PushMessageIds, "Net.Push", true);
		this.FillMessageNameAndStatMap(NetDefine.RequestMessageIds, "Net.Request", false);
		this.FillMessageNameAndStatMap(NetDefine.ResponseMessageIds, "Net.Response", true);
		this.FillMessageNameAndStatMap(NetDefine.NotifyMessageIds, "Net.Notify", true);
		uint num = 1000U;
		if (this.KcpClient.RemoteMtu > 0U)
		{
			num = this.KcpClient.RemoteMtu;
		}
		uint kcpSegmentSize = (num - 24U) * 127U;
		this.KcpClient.SetKcpMtu((int)num);
		this.KcpClient.SetKcpSegmentSize((int)kcpSegmentSize);
		this.KcpClient.SetKcpWndSize(256, 256);
		this.KcpClient.SetKcpNoDelay(1, 10, 2, 1);
		this.KcpClient.SetKcpStream(true);
		NetGameBudgetOnceTaskGroup groupObject = new NetGameBudgetOnceTaskGroup(new FName("NetOnceTaskGroup"), 100, new Func<bool>(this.IsCacheQueueEmpty), new Action(this.ConsumeCacheQueue));
		Singleton<GameBudgetInterfaceController>.Instance.RegisterOnceTaskCustomGroup(groupObject);
		return true;
	}

	// Token: 0x06003159 RID: 12633 RVA: 0x0001C2FA File Offset: 0x0001A4FA
	public void Tick(float deltaTime)
	{
		if (this.KcpClient != null)
		{
			this.KcpClient.TickOutside(deltaTime);
		}
	}

	// Token: 0x0600315A RID: 12634 RVA: 0x0001C310 File Offset: 0x0001A510
	public void InitCanTimerOutMessage(HashSet<ERequestMessageId> messageIdsSet)
	{
		this.CanTimeOutMessages = messageIdsSet;
	}

	// Token: 0x0600315B RID: 12635 RVA: 0x0001C319 File Offset: 0x0001A519
	private bool IsCacheQueueEmpty()
	{
		return this.CallbackList.Count == 0 || (this.IsNotifyCallbackPausedInternal && this.NonePausedCallbackCount == 0);
	}

	// Token: 0x0600315C RID: 12636 RVA: 0x0001C33D File Offset: 0x0001A53D
	private bool CallCurrentCallback()
	{
		if (this.CurrentProcessedCallback != null)
		{
			if (this.CurrentProcessedCallback.DoCallback())
			{
				this.CurrentProcessedCallback = null;
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600315D RID: 12637 RVA: 0x0001C360 File Offset: 0x0001A560
	private void ConsumeCacheQueue()
	{
		MicrotaskQueue.Drain();
		if (this.CallCurrentCallback())
		{
			return;
		}
		LinkedNode<Net.CallbackQueueItem> linkedNode = this.CallbackList.GetHeadNextNode();
		while (linkedNode != null)
		{
			if (this.IsNotifyCallbackPausedInternal)
			{
				Net.CallbackQueueItem element = linkedNode.Element;
				if (element != null && element.IsPaused())
				{
					linkedNode = linkedNode.Next;
					continue;
				}
			}
			this.CurrentProcessedCallback = linkedNode.Element;
			this.CallbackList.RemoveNode(linkedNode);
			int nonePausedCallbackCount = this.NonePausedCallbackCount;
			Net.CallbackQueueItem element2 = linkedNode.Element;
			this.NonePausedCallbackCount = nonePausedCallbackCount - ((element2 == null || !element2.IsPaused()) ? 1 : 0);
			this.CallCurrentCallback();
			return;
		}
	}

	// Token: 0x0600315E RID: 12638 RVA: 0x0001C3F4 File Offset: 0x0001A5F4
	public void Connect(string ip, int port, Net.TConnectResultCallback callback, int timeoutMsPerTry, int retryCount)
	{
		if (!this.CanKcpConnect())
		{
			Singleton<Log>.Instance.Error(ELogModule.Net, ELogAuthor.ZJC, "已经连接或者正在连接中", default(ReadOnlySpan<ValueTuple<string, object>>));
			callback(Net.EConnectResult.Other);
			return;
		}
		this.ConnectCallback = callback;
		this.ConnectMaxRetryCount = retryCount;
		this.ConnectRetryCount = 0;
		this.ConnectServerIp = ip;
		this.ConnectServerPort = port;
		this.ConnectTimeoutMsPerTry = timeoutMsPerTry;
		this.DoConnect();
	}

	// Token: 0x0600315F RID: 12639 RVA: 0x0001C460 File Offset: 0x0001A660
	[NullableContext(0)]
	public UniTask<Net.EConnectResult> ConnectAsync([Nullable(1)] string ip, int port, int timeoutMsPerTry, int retryCount)
	{
		Net.<ConnectAsync>d__91 <ConnectAsync>d__;
		<ConnectAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<Net.EConnectResult>.Create();
		<ConnectAsync>d__.<>4__this = this;
		<ConnectAsync>d__.ip = ip;
		<ConnectAsync>d__.port = port;
		<ConnectAsync>d__.timeoutMsPerTry = timeoutMsPerTry;
		<ConnectAsync>d__.retryCount = retryCount;
		<ConnectAsync>d__.<>1__state = -1;
		<ConnectAsync>d__.<>t__builder.Start<Net.<ConnectAsync>d__91>(ref <ConnectAsync>d__);
		return <ConnectAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06003160 RID: 12640 RVA: 0x0001C4C4 File Offset: 0x0001A6C4
	public void Disconnect(Net.EDisconnectReason disconnectReason)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Net;
		ELogAuthor author = ELogAuthor.MZJ;
		string message = "断开连接";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", disconnectReason);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.SetKcpConnectStatus(Net.EKcpConnectStatus.NoConnect);
		if (this.ConnectCallback != null)
		{
			this.SetConnectResult(Net.EConnectResult.Disconnect);
		}
		if (disconnectReason == Net.EDisconnectReason.Logout)
		{
			this.LoginState = Net.EServerLoginState.Logout;
		}
		else
		{
			this.LoginState = Net.EServerLoginState.NoLogin;
		}
		if (disconnectReason != Net.EDisconnectReason.Reconnect)
		{
			this.CleanMessageCaches();
			this.RpcId = 0;
			this.UpStreamSeqNo = 0;
			this.EndReconnecting();
		}
	}

	// Token: 0x06003161 RID: 12641 RVA: 0x0001C544 File Offset: 0x0001A744
	public unsafe void SetDynamicProtoKey(Net.EServerEncryptType sType, byte[] key)
	{
		Net.EClientEncryptType eclientEncryptType = Singleton<Net>.Instance.s2cEncryptType[sType];
		this.ChangeStateKeyReady();
		fixed (byte* arrayDataReference = MemoryMarshal.GetArrayDataReference<byte>(key))
		{
			byte* data = arrayDataReference;
			FArrayBuffer farrayBuffer = new FArrayBuffer
			{
				Data = (void*)data,
				Length = (ulong)((long)key.Length)
			};
			if (!this.KcpClient.SetK((byte)eclientEncryptType, farrayBuffer))
			{
				Singleton<Log>.Instance.Warn(ELogModule.Net, ELogAuthor.LRA, "网络 key 设置失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}
	}

	// Token: 0x06003162 RID: 12642 RVA: 0x0001C5C1 File Offset: 0x0001A7C1
	public int GetDownStreamSeqNo()
	{
		return this.DownStreamSeqNo;
	}

	// Token: 0x06003163 RID: 12643 RVA: 0x0001C5CC File Offset: 0x0001A7CC
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public unsafe ValueTuple<int, int, string, string> GetCachedMessageData(int seqNo)
	{
		LinkedNode<Net.SendMessageCache> linkedNode = this.MessageCacheList.GetHeadNextNode();
		Net.SendMessageCache sendMessageCache = null;
		while (linkedNode != null)
		{
			if (linkedNode.Element.SeqNo == seqNo)
			{
				sendMessageCache = linkedNode.Element;
				break;
			}
			linkedNode = linkedNode.Next;
		}
		if (sendMessageCache != null)
		{
			fixed (byte* pinnableReference = sendMessageCache.EncodeMessage.GetPinnableReference())
			{
				byte* data = pinnableReference;
				FArrayBuffer farrayBuffer = new FArrayBuffer
				{
					Data = (void*)data,
					Length = (ulong)((long)sendMessageCache.EncodeMessage.Length)
				};
				string[] array = this.KcpClient.GetDebugString(farrayBuffer, ";", (short)sendMessageCache.MessageId, sendMessageCache.SeqNo).Split(';', StringSplitOptions.None);
				return new ValueTuple<int, int, string, string>((int)sendMessageCache.MessageId, int.Parse(array[0]), array[1], array[3]);
			}
		}
		return new ValueTuple<int, int, string, string>(0, 0, "", "");
	}

	// Token: 0x06003164 RID: 12644 RVA: 0x0001C6A5 File Offset: 0x0001A8A5
	public int GetUnVerifiedMessageCount()
	{
		return this.MessageCacheList.Count;
	}

	// Token: 0x06003165 RID: 12645 RVA: 0x0001C6B4 File Offset: 0x0001A8B4
	public unsafe void ReconnectSuccessAndReSend(int lastReceivedClientSeq)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Net;
		ELogAuthor author = ELogAuthor.MZJ;
		string message = "重连流程";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("lastReceived", lastReceivedClientSeq);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		int count = this.MessageCacheList.Count;
		if (count > 0)
		{
			LinkedNode<Net.SendMessageCache> linkedNode = this.MessageCacheList.GetHeadNextNode();
			bool includeThis = false;
			while (linkedNode != null)
			{
				int seqNo = linkedNode.Element.SeqNo;
				if (seqNo >= lastReceivedClientSeq)
				{
					includeThis = (seqNo == lastReceivedClientSeq);
					break;
				}
				linkedNode = linkedNode.Next;
			}
			if (linkedNode != null)
			{
				Net.SendMessageCache.DisposeAndRemoveBefore(this.MessageCacheList, linkedNode, includeThis);
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Net;
				ELogAuthor author2 = ELogAuthor.MZJ;
				string message2 = "重连流程, 清理掉已经被服务器收到的缓存消息";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("beforeCount", count);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("afterCount", this.MessageCacheList.Count);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("find SeqNo", linkedNode.Element.SeqNo);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
		}
		if (this.MessageCacheList.Count > 0)
		{
			int num = 0;
			int num2 = 0;
			EMessageId emessageId = (EMessageId)0;
			for (LinkedNode<Net.SendMessageCache> linkedNode2 = this.MessageCacheList.GetHeadNextNode(); linkedNode2 != null; linkedNode2 = linkedNode2.Next)
			{
				Net.SendMessageCache element = linkedNode2.Element;
				EMessageId messageId = element.MessageId;
				if ((NetDefine.ProtoConfig[messageId] & 3) != 0)
				{
					int rpcId = element.RpcId;
					Net.EMessageType emessageType = (rpcId != 0) ? Net.EMessageType.Request : Net.EMessageType.Push;
					if (emessageType == Net.EMessageType.Push || element.Handle != null)
					{
						num++;
						num2 = element.SeqNo;
						emessageId = messageId;
						this.DoSend(emessageType, element.SeqNo, new int?(rpcId), messageId, element.EncodeMessage, null);
					}
				}
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Net;
			ELogAuthor author3 = ELogAuthor.MZJ;
			string message3 = "重连流程, 重发未被服务器确认的消息";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Count", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("lastSeqNo", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("lastMsgId", emessageId);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		this.ChangeStateFinishLogin();
	}

	// Token: 0x06003166 RID: 12646 RVA: 0x0001C91C File Offset: 0x0001AB1C
	[NullableContext(0)]
	public bool Register<T>(ENotifyMessageId id, [Nullable(new byte[]
	{
		1,
		1,
		2
	})] Action<T, Net.CallbackStatus> callback) where T : IMessage
	{
		Net.<>c__DisplayClass98_0<T> CS$<>8__locals1 = new Net.<>c__DisplayClass98_0<T>();
		CS$<>8__locals1.callback = callback;
		if (this.NotifyHandles.ContainsKey(id))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "网络消息重复注册";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.NotifyHandles[id] = new Net.MessageCallback<T>(new Action<T, Net.CallbackStatus>(CS$<>8__locals1.<Register>g__NotifyHandle|0));
		return true;
	}

	// Token: 0x06003167 RID: 12647 RVA: 0x0001C990 File Offset: 0x0001AB90
	public bool UnRegister(ENotifyMessageId id)
	{
		if (!this.NotifyHandles.Remove(id))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "Notify消息未注册";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return true;
	}

	// Token: 0x06003168 RID: 12648 RVA: 0x0001C9DC File Offset: 0x0001ABDC
	public void Send(EPushMessageId pushMessageId, IMessage message)
	{
		if (!this.IsPassLoginCheck((EMessageId)pushMessageId))
		{
			return;
		}
		this.EncodeAddToCacheAndSend(Net.EMessageType.Push, (EMessageId)pushMessageId, message, null, null);
	}

	// Token: 0x06003169 RID: 12649 RVA: 0x0001CA08 File Offset: 0x0001AC08
	public void Call<[Nullable(0)] T>(ERequestMessageId requestMessageId, IMessage message, [Nullable(2)] Action<T, Net.CallbackStatus> handle, int timeoutMs = 0) where T : IMessage
	{
		if (this.IsRequestLocked(requestMessageId))
		{
			if (handle != null)
			{
				handle(default(T), null);
			}
			return;
		}
		if (!this.IsPassLoginCheck((EMessageId)requestMessageId))
		{
			if (handle != null)
			{
				handle(default(T), null);
			}
			return;
		}
		int rpcId = this.GetRpcId();
		LinkedNode<Net.SendMessageCache> linkedNode = this.EncodeAddToCacheAndSend(Net.EMessageType.Request, (EMessageId)requestMessageId, message, new int?(rpcId), new Net.MessageCallback<T>(handle));
		this.SaveCallbackAndLockRequest(requestMessageId, linkedNode);
		if (timeoutMs > 0)
		{
			this.AddMessageTimeout(timeoutMs, linkedNode.Element);
		}
		if ((NetDefine.ProtoConfig[(EMessageId)requestMessageId] & 4) == 4)
		{
			Action<int> addRequestMaskHandle = this.AddRequestMaskHandle;
			if (addRequestMaskHandle == null)
			{
				return;
			}
			addRequestMaskHandle(rpcId);
		}
	}

	// Token: 0x0600316A RID: 12650 RVA: 0x0001CAA8 File Offset: 0x0001ACA8
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<T> CallAsync<[Nullable(0)] T>(ERequestMessageId requestMessageId, IMessage message, int timeoutMs = 0) where T : IMessage
	{
		Net.<CallAsync>d__104<T> <CallAsync>d__;
		<CallAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
		<CallAsync>d__.<>4__this = this;
		<CallAsync>d__.requestMessageId = requestMessageId;
		<CallAsync>d__.message = message;
		<CallAsync>d__.timeoutMs = timeoutMs;
		<CallAsync>d__.<>1__state = -1;
		<CallAsync>d__.<>t__builder.Start<Net.<CallAsync>d__104<T>>(ref <CallAsync>d__);
		return <CallAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600316B RID: 12651 RVA: 0x0001CB04 File Offset: 0x0001AD04
	private unsafe LinkedNode<Net.SendMessageCache> EncodeAddToCacheAndSend(Net.EMessageType msgType, EMessageId msgId, IMessage message, int? rpcId, [Nullable(2)] Net.IMessageCallBack handle)
	{
		int num = this.IncUpStreamSeqNo();
		LinkedNode<Net.SendMessageCache> result;
		using (MessageSerializationBuffer buffer = MessageSerializationBuffer.GetBuffer(msgId, message))
		{
			if (buffer.Length > 30720)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Net;
				ELogAuthor author = ELogAuthor.MZJ;
				string message2 = "消息过大";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("message", msgId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("length", buffer.Length);
				instance.Error(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			Net.SendMessageCache messageCache = new Net.SendMessageCache(rpcId, new int?(num), new EMessageId?(msgId), buffer.MessageSpan, handle);
			LinkedNode<Net.SendMessageCache> linkedNode = this.AddToMessageCache(messageCache);
			if (!this.CacheDueToReconnecting((int)msgId))
			{
				this.DoSend(msgType, num, rpcId, msgId, buffer.MessageSpan, null);
			}
			result = linkedNode;
		}
		return result;
	}

	// Token: 0x0600316C RID: 12652 RVA: 0x0001CBF8 File Offset: 0x0001ADF8
	private unsafe void AddMessageTimeout(int timeoutMs, Net.SendMessageCache messageCache)
	{
		ERequestMessageId requestMessageId = (ERequestMessageId)messageCache.MessageId;
		if (this.CanTimeOutMessages.Contains(requestMessageId))
		{
			TimerHandle timeoutHandle = TimerSystem.Instance.Delay(delegate(float id)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Net;
				ELogAuthor author2 = ELogAuthor.MZJ;
				string message2 = "协议超时";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("message", requestMessageId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("timeout", timeoutMs);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				Net.IMessageCallBack handle = messageCache.Handle;
				messageCache.ClearHandle();
				messageCache.TimeoutHandle = null;
				if ((NetDefine.ProtoConfig[messageCache.MessageId] & 4) == 4)
				{
					Action<int> removeRequestMaskHandle = this.RemoveRequestMaskHandle;
					if (removeRequestMaskHandle != null)
					{
						removeRequestMaskHandle(messageCache.RpcId);
					}
				}
				if ((NetDefine.ProtoConfig[messageCache.MessageId] & 8) == 8)
				{
					this.RequestLock.Remove(requestMessageId);
				}
				this.RequestMessageMap.Remove(messageCache.RpcId);
				if (handle != null)
				{
					try
					{
						if (this.IsNetStatEnable)
						{
							this.MessageIdStatMap.GetValueOrDefault((EMessageId)requestMessageId, null);
						}
						handle.Invoke(null, null);
					}
					catch (Exception ex) when (1)
					{
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.Net;
						ELogAuthor author3 = ELogAuthor.MZJ;
						string message3 = "callback执行异常";
						Exception error = ex;
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("requestId", requestMessageId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("error", ex.Message);
						instance3.ErrorWithStack(module3, author3, message3, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					}
					finally
					{
					}
				}
			}, (float)timeoutMs, null, null, true, 1f);
			messageCache.TimeoutHandle = timeoutHandle;
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Net;
		ELogAuthor author = ELogAuthor.MZJ;
		string message = "该协议未配置可超时";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("message", requestMessageId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600316D RID: 12653 RVA: 0x0001CCA8 File Offset: 0x0001AEA8
	private void FillMessageNameAndStatMap(EMessageId[] messageIds, string namePrefix, bool createStat)
	{
		if (this.IsNetLogEnabled || this.IsNetStatEnable)
		{
			foreach (EMessageId emessageId in messageIds)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
				defaultInterpolatedStringHandler.AppendFormatted(namePrefix);
				defaultInterpolatedStringHandler.AppendLiteral(".(");
				defaultInterpolatedStringHandler.AppendFormatted<EMessageId>(emessageId);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				string text = defaultInterpolatedStringHandler.ToStringAndClear();
				if (this.IsNetLogEnabled)
				{
					this.MessageIdNameMap[emessageId] = text;
				}
				if (createStat && this.IsNetStatEnable)
				{
					Stat value = Stat.CreateNoFlameGraph(text, "", "");
					this.MessageIdStatMap[emessageId] = value;
				}
			}
		}
	}

	// Token: 0x0600316E RID: 12654 RVA: 0x0001CD5C File Offset: 0x0001AF5C
	private bool IsRequestLocked(ERequestMessageId requestMessageId)
	{
		if (this.RequestLock.Contains(requestMessageId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.MZJ;
			string message = "Request重复发送。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("message", requestMessageId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return true;
		}
		return false;
	}

	// Token: 0x0600316F RID: 12655 RVA: 0x0001CDA6 File Offset: 0x0001AFA6
	private void SetKcpConnectStatus(Net.EKcpConnectStatus connectStatus)
	{
		if (this.KcpConnectStatus != connectStatus)
		{
			this.KcpConnectStatus = connectStatus;
			if (connectStatus == Net.EKcpConnectStatus.NoConnect && this.KcpClient != null)
			{
				this.KcpClient.Disconnect();
			}
		}
	}

	// Token: 0x06003170 RID: 12656 RVA: 0x0001CDCE File Offset: 0x0001AFCE
	private bool CanKcpConnect()
	{
		return this.KcpConnectStatus == Net.EKcpConnectStatus.NoConnect;
	}

	// Token: 0x06003171 RID: 12657 RVA: 0x0001CDDC File Offset: 0x0001AFDC
	private void DoConnect()
	{
		this.ConnectTimeoutTimer = TimerSystem.Instance.Delay(delegate(float id)
		{
			this.SetConnectResult(Net.EConnectResult.Timeout);
		}, (float)this.ConnectTimeoutMsPerTry, null, null, true, 1f);
		this.SetKcpConnectStatus(Net.EKcpConnectStatus.Connecting);
		if (this.KcpClient != null)
		{
			this.KcpClient.Connect(this.ConnectServerIp, this.ConnectServerPort, Singleton<NetInfo>.Instance.DisableCrc);
		}
	}

	// Token: 0x06003172 RID: 12658 RVA: 0x0001CE45 File Offset: 0x0001B045
	private bool IsReconnectControlMessage(ERequestMessageId messageId)
	{
		return messageId == ERequestMessageId.ProtoKeyRequest || messageId == ERequestMessageId.ReconnectRequest;
	}

	// Token: 0x06003173 RID: 12659 RVA: 0x0001CE53 File Offset: 0x0001B053
	private bool CacheDueToReconnecting(int messageId)
	{
		return this.IsReconnecting && !this.IsReconnectControlMessage((ERequestMessageId)messageId);
	}

	// Token: 0x06003174 RID: 12660 RVA: 0x0001CE6C File Offset: 0x0001B06C
	private unsafe bool IsPassLoginCheck(EMessageId messageId)
	{
		if (this.LoginState == Net.EServerLoginState.Logout)
		{
			return false;
		}
		if (this.IsReconnecting)
		{
			if (messageId == EMessageId.ReconnectRequest && !this.IsProtoKeyReady())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Net;
				ELogAuthor author = ELogAuthor.MZJ;
				string message = "上行协议时机不对，未发送";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("messageId", messageId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return true;
		}
		else
		{
			if (!this.IsMsgUseBuiltinEncrypt(messageId) && !this.IsProtoKeyReady())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Net;
				ELogAuthor author2 = ELogAuthor.LRA;
				string message2 = "上行协议时机不对，未发送";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("messageId", messageId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (this.LoginState != Net.EServerLoginState.FinishedLogin && (NetDefine.ProtoConfig[messageId] & 3) != 0)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Net;
				ELogAuthor author3 = ELogAuthor.ZJC;
				string message3 = "尚未完成登录流程, 登录流程以外的协议会被丢弃";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("state", this.LoginState);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("messageId", messageId);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			return true;
		}
	}

	// Token: 0x06003175 RID: 12661 RVA: 0x0001CF88 File Offset: 0x0001B188
	private int GetRpcId()
	{
		if (this.RpcId < 32767)
		{
			short num = this.RpcId + 1;
			this.RpcId = num;
			return (int)num;
		}
		this.RpcId = 1;
		return (int)this.RpcId;
	}

	// Token: 0x06003176 RID: 12662 RVA: 0x0001CFC4 File Offset: 0x0001B1C4
	private int IncUpStreamSeqNo()
	{
		if (this.UpStreamSeqNo < 2147483647)
		{
			int num = this.UpStreamSeqNo + 1;
			this.UpStreamSeqNo = num;
			return num;
		}
		this.UpStreamSeqNo = 1;
		return this.UpStreamSeqNo;
	}

	// Token: 0x06003177 RID: 12663 RVA: 0x0001D000 File Offset: 0x0001B200
	private unsafe bool SetDownStreamSeqNo(int downStreamSeqNo)
	{
		if (downStreamSeqNo == 0)
		{
			return true;
		}
		int downStreamSeqNo2 = this.DownStreamSeqNo;
		this.DownStreamSeqNo = downStreamSeqNo;
		int num = downStreamSeqNo2 + 1;
		if (downStreamSeqNo2 == 2147483647)
		{
			num = 1;
		}
		if (downStreamSeqNo != num)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.MZJ;
			string message = "下行包序号不对";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("old", downStreamSeqNo2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("new", num);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		return true;
	}

	// Token: 0x06003178 RID: 12664 RVA: 0x0001D092 File Offset: 0x0001B292
	private LinkedNode<Net.SendMessageCache> AddToMessageCache(Net.SendMessageCache messageCache)
	{
		bool isNetLogEnabled = this.IsNetLogEnabled;
		messageCache.InList = true;
		return this.MessageCacheList.AddTail(messageCache);
	}

	// Token: 0x06003179 RID: 12665 RVA: 0x0001D0AE File Offset: 0x0001B2AE
	private void SaveCallbackAndLockRequest(ERequestMessageId requestMessageId, LinkedNode<Net.SendMessageCache> node)
	{
		this.RequestMessageMap[node.Element.RpcId] = node;
		if ((NetDefine.ProtoConfig[(EMessageId)requestMessageId] & 8) == 8)
		{
			this.RequestLock.Add(requestMessageId);
		}
	}

	// Token: 0x0600317A RID: 12666 RVA: 0x0001D0E4 File Offset: 0x0001B2E4
	private void DeleteServerReceivedRequest(LinkedNode<Net.SendMessageCache> nodeRequestMsg)
	{
		Net.SendMessageCache element = nodeRequestMsg.Element;
		EMessageId messageId = element.MessageId;
		this.RequestMessageMap.Remove(element.RpcId);
		if ((NetDefine.ProtoConfig[messageId] & 8) == 8)
		{
			this.RequestLock.Remove((ERequestMessageId)messageId);
		}
		if (messageId == EMessageId.EnterGameRequest)
		{
			this.ChangeStateFinishLogin();
		}
		if (this.IsReconnectControlMessage((ERequestMessageId)messageId))
		{
			return;
		}
		Net.SendMessageCache.DisposeAndRemoveBefore(this.MessageCacheList, nodeRequestMsg, true);
		bool isNetLogEnabled = this.IsNetLogEnabled;
	}

	// Token: 0x0600317B RID: 12667 RVA: 0x0001D157 File Offset: 0x0001B357
	private bool IsMsgUseBuiltinEncrypt(EMessageId msgId)
	{
		return msgId == EMessageId.ProtoKeyRequest;
	}

	// Token: 0x0600317C RID: 12668 RVA: 0x0001D164 File Offset: 0x0001B364
	private void OnKcpConnectSuccess()
	{
		Singleton<Log>.Instance.Info(ELogModule.Net, ELogAuthor.LRX, "[CSharp] OnKcpConnectSuccess", default(ReadOnlySpan<ValueTuple<string, object>>));
		UKuroKcpClient kcpClient = Singleton<Net>.Instance.KcpClient;
		if (kcpClient != null)
		{
			kcpClient.SetKcpStream(true);
		}
		Singleton<Net>.Instance.SetConnectResult(Net.EConnectResult.Success);
	}

	// Token: 0x0600317D RID: 12669 RVA: 0x0001D1B0 File Offset: 0x0001B3B0
	private void SetConnectResult(Net.EConnectResult result)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Net;
		ELogAuthor author = ELogAuthor.MZJ;
		string message = "Kcp连接结果:";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", result);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (this.ConnectTimeoutTimer != null && TimerSystem.Instance.Has(this.ConnectTimeoutTimer))
		{
			TimerSystem.Instance.Remove(this.ConnectTimeoutTimer);
			this.ConnectTimeoutTimer = null;
		}
		if (result == Net.EConnectResult.Timeout && Singleton<Net>.Instance.HandleConnectTimeout(false))
		{
			return;
		}
		if ((result == Net.EConnectResult.TCPConnectFailed || result == Net.EConnectResult.TCPConnectTimeOut) && Singleton<Net>.Instance.HandleConnectTimeout(true))
		{
			return;
		}
		if (this.ConnectCallback != null)
		{
			this.ConnectCallback(result);
			this.ConnectCallback = null;
		}
		this.SetKcpConnectStatus((result == Net.EConnectResult.Success) ? Net.EKcpConnectStatus.Connected : Net.EKcpConnectStatus.NoConnect);
	}

	// Token: 0x0600317E RID: 12670 RVA: 0x0001D270 File Offset: 0x0001B470
	private unsafe void OnError(int code1, int code2, int code3, int code4, int code5)
	{
		switch (code1)
		{
		case 1:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.MZJ;
			string message = "SocketError";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("errorCode", code2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Size", code3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Read", code4);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (code2 != 0)
			{
				Net.TNetworkErrorHandle netErrorHandle = Singleton<Net>.Instance.NetErrorHandle;
				if (netErrorHandle == null)
				{
					return;
				}
				netErrorHandle(code2);
				return;
			}
			break;
		}
		case 2:
			break;
		case 3:
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Net;
			ELogAuthor author2 = ELogAuthor.MZJ;
			string message2 = "DecryptError";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Result", code2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Type", code3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("RpcId", code4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("MessageId", code5);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
			return;
		}
		case 4:
			this.HandleKcpRecvError(code2);
			break;
		default:
			return;
		}
	}

	// Token: 0x0600317F RID: 12671 RVA: 0x0001D3D0 File Offset: 0x0001B5D0
	private void HandleKcpRecvError(int code)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Net;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "KcpRecvError";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ErrorCode", code);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (code == -4)
		{
			Singleton<NetInfo>.Instance.DisableCrc = true;
			UKuroVariableFunctionLibrary.SetBoolValue("DisableCrc", true);
		}
	}

	// Token: 0x06003180 RID: 12672 RVA: 0x0001D425 File Offset: 0x0001B625
	private void OnReceiveResponse(int seqNo, short rpcId, ushort messageId, FArrayBuffer messageBuffer)
	{
		this.ProcessReceiveMessage(Net.EMessageType.Response, seqNo, (int)messageId, messageBuffer, new int?((int)rpcId), false);
	}

	// Token: 0x06003181 RID: 12673 RVA: 0x0001D43A File Offset: 0x0001B63A
	private void OnReceiveException(int seqNo, short rpcId, uint errorCode, FArrayBuffer stringBuffer)
	{
		this.ProcessReceiveMessage(Net.EMessageType.Exception, seqNo, (int)errorCode, stringBuffer, new int?((int)rpcId), false);
	}

	// Token: 0x06003182 RID: 12674 RVA: 0x0001D450 File Offset: 0x0001B650
	private unsafe void OnReceiveTcpException(uint errorCode)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Net;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "TCP连接建立失败:";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TcpHosts", Singleton<NetInfo>.Instance.TcpHosts.FormatNetHostInfo());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ErrorCode", errorCode);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.SetConnectResult(Net.EConnectResult.TCPConnectFailed);
	}

	// Token: 0x06003183 RID: 12675 RVA: 0x0001D4CC File Offset: 0x0001B6CC
	private void OnReceivePush(int seqNo, ushort messageId, FArrayBuffer messageBuffer)
	{
		this.ProcessReceiveMessage(Net.EMessageType.Push, seqNo, (int)messageId, messageBuffer, null, false);
	}

	// Token: 0x06003184 RID: 12676 RVA: 0x0001D4F0 File Offset: 0x0001B6F0
	private unsafe bool ProcessReceiveMessage(Net.EMessageType messageType, int serverSeqNo, int messageIdOrErrorCode, FArrayBuffer messageBuffer, int? rpcId = null, bool recvFromTs = false)
	{
		Net.<>c__DisplayClass131_0 CS$<>8__locals1 = new Net.<>c__DisplayClass131_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.rpcId = rpcId;
		CS$<>8__locals1.messageIdOrErrorCode = messageIdOrErrorCode;
		Span<byte> span = messageBuffer.ToSpan();
		this.SetDownStreamSeqNo(serverSeqNo);
		CS$<>8__locals1.nodeRequestMsg = null;
		CS$<>8__locals1.message = null;
		CS$<>8__locals1.handle = null;
		CS$<>8__locals1.messageId = (EMessageId)CS$<>8__locals1.messageIdOrErrorCode;
		CS$<>8__locals1.requestId = null;
		if (CS$<>8__locals1.messageId == EMessageId.KcpConvResponse)
		{
			this.ProcessKcpConvResponseMessage(CS$<>8__locals1.messageId, span);
			return true;
		}
		bool flag = false;
		CS$<>8__locals1.receivedTimeMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
		this.LastReceiveTimeMsInternal = CS$<>8__locals1.receivedTimeMs;
		if (CS$<>8__locals1.rpcId != null)
		{
			this.RequestMessageMap.TryGetValue(CS$<>8__locals1.rpcId.Value, out CS$<>8__locals1.nodeRequestMsg);
			if (CS$<>8__locals1.nodeRequestMsg != null)
			{
				this.DeleteServerReceivedRequest(CS$<>8__locals1.nodeRequestMsg);
				Net.SendMessageCache element = CS$<>8__locals1.nodeRequestMsg.Element;
				long num = CS$<>8__locals1.receivedTimeMs - element.SendTimeMs;
				CS$<>8__locals1.requestId = new ERequestMessageId?((ERequestMessageId)element.MessageId);
				Singleton<NetInfo>.Instance.SetRttMs((int)num);
				if (num > 300L)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Net;
					ELogAuthor author = ELogAuthor.MZJ;
					string message = "RTT过高";
					<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("requestId", CS$<>8__locals1.requestId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("rpcId", CS$<>8__locals1.rpcId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("seqNo", element.SeqNo);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("serverSeqNo", serverSeqNo);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("rtt", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("deltaTime", Singleton<Time>.Instance.DeltaTime);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
				}
				CS$<>8__locals1.handle = element.Handle;
				if (element.TimeoutHandle != null)
				{
					TimerSystem.Instance.Remove(element.TimeoutHandle);
				}
			}
			else if (!recvFromTs)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Net;
				ELogAuthor author2 = ELogAuthor.LCC;
				string message2 = "网络 rpc 响应不存在";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("rpcId", CS$<>8__locals1.rpcId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("messageId", CS$<>8__locals1.messageIdOrErrorCode);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}
		}
		else
		{
			Net.IMessageCallBack handle;
			this.NotifyHandles.TryGetValue((ENotifyMessageId)CS$<>8__locals1.messageId, out handle);
			CS$<>8__locals1.handle = handle;
			if (CS$<>8__locals1.handle == null && this.IsNetLogEnabled && !recvFromTs)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Net;
				ELogAuthor author3 = ELogAuthor.LCC;
				string message3 = "网络 notify 响应不存在";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Id", CS$<>8__locals1.messageId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Name", this.MessageIdNameMap.GetValueOrDefault(CS$<>8__locals1.messageId, ""));
				instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			}
			flag = true;
		}
		if (messageType == Net.EMessageType.Exception)
		{
			string errMessage = "[异常信息:" + Encoding.UTF8.GetString(span) + "]";
			Net.IMessageCallBack originalHandle = CS$<>8__locals1.handle;
			CS$<>8__locals1.handle = new Net.MessageCallback<IMessage>(delegate(IMessage resp, Net.CallbackStatus status)
			{
				Net.TExceptionHandle exceptionHandle = CS$<>8__locals1.<>4__this.ExceptionHandle;
				if (exceptionHandle != null)
				{
					exceptionHandle(CS$<>8__locals1.rpcId.GetValueOrDefault(0), CS$<>8__locals1.messageIdOrErrorCode, (int)CS$<>8__locals1.requestId.Value, (CS$<>8__locals1.nodeRequestMsg != null) ? CS$<>8__locals1.<>4__this.ParseToMessage((EMessageId)CS$<>8__locals1.requestId.Value, CS$<>8__locals1.nodeRequestMsg.Element.EncodeMessage) : null, errMessage);
				}
				Net.IMessageCallBack originalHandle = originalHandle;
				if (originalHandle == null)
				{
					return;
				}
				originalHandle.Invoke(null, null);
			});
		}
		else
		{
			CS$<>8__locals1.message = this.ParseToMessage(CS$<>8__locals1.messageId, span);
			if (CS$<>8__locals1.message == null)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Net;
				ELogAuthor author4 = ELogAuthor.LCC;
				string message4 = "协议解析异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("messageId", CS$<>8__locals1.messageId);
				instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		if (CS$<>8__locals1.message != null && this.IsNetLogEnabled)
		{
			this.LogNet((int)CS$<>8__locals1.messageId, serverSeqNo, CS$<>8__locals1.rpcId, CS$<>8__locals1.message);
		}
		if (this.UseBudget)
		{
			this.CallbackList.AddTail(new Net.CallbackQueueItem(new Net.WrappedCallback(CS$<>8__locals1.<ProcessReceiveMessage>g__TickBudgetCallback|0), CS$<>8__locals1.messageId, flag));
			this.NonePausedCallbackCount += ((!flag) ? 1 : 0);
		}
		else
		{
			Net.CallbackStatus callbackStatus = new Net.CallbackStatus(CS$<>8__locals1.messageId);
			do
			{
				CS$<>8__locals1.<ProcessReceiveMessage>g__TickBudgetCallback|0(callbackStatus);
			}
			while (!callbackStatus.IsJobFinished);
		}
		return true;
	}

	// Token: 0x06003185 RID: 12677 RVA: 0x0001D990 File Offset: 0x0001BB90
	[NullableContext(0)]
	private unsafe bool DoSend(Net.EMessageType msgType, int seqNo, int? rpcId, EMessageId msgId, Span<byte> encodedMsg, [Nullable(2)] IMessage originalMessage = null)
	{
		if (this.IsNetLogEnabled)
		{
			IMessage message = originalMessage ?? this.ParseToMessage(msgId, encodedMsg);
			this.LogNet((int)msgId, seqNo, rpcId, message);
		}
		fixed (byte* pinnableReference = encodedMsg.GetPinnableReference())
		{
			byte* data = pinnableReference;
			FArrayBuffer farrayBuffer = new FArrayBuffer
			{
				Data = (void*)data,
				Length = (ulong)((long)encodedMsg.Length)
			};
			return this.KcpClient.SendM((sbyte)msgType, seqNo, (short)rpcId.GetValueOrDefault(0), (short)msgId, farrayBuffer, (NetDefine.ProtoConfig[msgId] & 32) == 0);
		}
	}

	// Token: 0x06003186 RID: 12678 RVA: 0x0001DA1C File Offset: 0x0001BC1C
	private void CleanMessageCaches()
	{
		this.RequestLock.Clear();
		this.RequestMessageMap.Clear();
		Net.SendMessageCache.DisposeAllAndClear(this.MessageCacheList);
	}

	// Token: 0x06003187 RID: 12679 RVA: 0x0001DA40 File Offset: 0x0001BC40
	private void LogNet(int id, int seqNo, int? rpcId, object message)
	{
		if (!this.IsHeartLogEnabled && (id == 1650 || id == 1651 || id == 28810))
		{
			return;
		}
		if (id == 17573 || id == 23017 || id == 29722 || id == 19804 || id == 15350 || id == 24352 || id == 18687 || id == 27958 || id == 25753)
		{
			return;
		}
		if (!this.IsSyncLogEnabled && (id == 29564 || id == 19053 || id == 17525 || id == 19459 || id == 26333 || id == 21592 || id == 21430 || id == 27783 || id == 17269))
		{
			return;
		}
		int num = message.GetType().GetProperties().Length;
		bool isNetLogEnabled = this.IsNetLogEnabled;
	}

	// Token: 0x06003188 RID: 12680 RVA: 0x0001DB20 File Offset: 0x0001BD20
	[NullableContext(0)]
	[return: Nullable(2)]
	public unsafe IMessage ParseToMessage(EMessageId messageId, Span<byte> encodedMsg)
	{
		IMessage message = NetDefine.CreateMessageById((int)messageId);
		if (message == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.LRX;
			string message2 = "未注册的消息类型->请重新导出网络消息";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("messageId:", messageId);
			instance.Error(module, author, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		IMessage result;
		try
		{
			message.MergeFrom(encodedMsg);
			result = message;
		}
		catch (Exception ex)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Net;
			ELogAuthor author2 = ELogAuthor.LRX;
			string message3 = "Net.ParseToMessage->解析消息异常";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("messageId:", messageId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ex:", ex.ToString());
			instance2.Error(module2, author2, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			result = null;
		}
		return result;
	}

	// Token: 0x06003189 RID: 12681 RVA: 0x0001DBEC File Offset: 0x0001BDEC
	private unsafe bool HandleConnectTimeout(bool ignoreTcp)
	{
		if (!ignoreTcp)
		{
			int num = 10000;
			int num2 = 0;
			bool flag = Singleton<NetInfo>.Instance.TcpRatio >= num;
			if (Singleton<NetInfo>.Instance.TcpRatio < num && Singleton<NetInfo>.Instance.TcpRatio > 0)
			{
				num2 = new Random().Next(0, num);
				flag = (num2 < Singleton<NetInfo>.Instance.TcpRatio && Singleton<NetInfo>.Instance.TcpRetry < Singleton<NetInfo>.Instance.TcpMaxRetry);
			}
			bool flag2 = Singleton<NetInfo>.Instance.TcpRetry >= Singleton<NetInfo>.Instance.TcpMaxRetry;
			if (flag && !flag2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Net;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "kcp会话id使用Tcp获取:";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TcpRatio", Singleton<NetInfo>.Instance.TcpRatio);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RandomValue", num2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("RetryCount", this.ConnectRetryCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("TcpRetry", Singleton<NetInfo>.Instance.TcpRetry);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				this.StartTcpConnect();
				return true;
			}
		}
		if (this.ConnectRetryCount >= this.ConnectMaxRetryCount)
		{
			return false;
		}
		this.ConnectRetryCount++;
		this.SetKcpConnectStatus(Net.EKcpConnectStatus.NoConnect);
		this.DoConnect();
		return true;
	}

	// Token: 0x0600318A RID: 12682 RVA: 0x0001DD70 File Offset: 0x0001BF70
	private unsafe void StartTcpConnect()
	{
		if (this.KcpClient == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Net, ELogAuthor.LRX, "KCP未初始化,无法启动TCP连接", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.KcpConnectStatus == Net.EKcpConnectStatus.Connected)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Net, ELogAuthor.LRX, "KCP已连接,无需建立TCP连接", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (Singleton<NetInfo>.Instance.TcpHosts == null || Singleton<NetInfo>.Instance.TcpHosts.Count == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Net, ELogAuthor.LRX, "TCP服务器列表为空, 无法建立TCP连接", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.KcpClient == null)
		{
			return;
		}
		this.KcpClient.CloseTcpConnect();
		string host = Singleton<NetInfo>.Instance.TcpHosts[0].host;
		int port = Singleton<NetInfo>.Instance.TcpHosts[0].port;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Net;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "开始建立TCP连接:";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("addr", host);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("port", port);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TcpHosts", Singleton<NetInfo>.Instance.TcpHosts.FormatNetHostInfo());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("LoginTraceId", Singleton<NetInfo>.Instance.LoginTraceId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		this.KcpClient.OnTcpConnected.Add(new Action(this.OnTcpConnected));
		this.KcpClient.OnTcpConnectFailed.Add(new Action(this.OnTcpConnectFailed));
		this.KcpClient.StartTcpConnect(host, port);
		this.ConnectTimeoutTimer = TimerSystem.Instance.Delay(delegate(float id)
		{
			this.SetConnectResult(Net.EConnectResult.TCPConnectTimeOut);
		}, (float)this.ConnectTimeoutMsPerTry, null, null, true, 1f);
		NetInfo instance2 = Singleton<NetInfo>.Instance;
		int tcpRetry = instance2.TcpRetry;
		instance2.TcpRetry = tcpRetry + 1;
	}

	// Token: 0x0600318B RID: 12683 RVA: 0x0001DF68 File Offset: 0x0001C168
	private unsafe void OnTcpConnected()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Net;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "TCP连接建立成功:";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TcpHosts", Singleton<NetInfo>.Instance.TcpHosts.FormatNetHostInfo());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LoginTraceId", Singleton<NetInfo>.Instance.LoginTraceId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (Singleton<Net>.Instance.KcpClient == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Net, ELogAuthor.LRX, "获取KCPConv失败,KCP实例不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		byte[] array = new KcpConvRequest
		{
			LoginTraceId = Singleton<NetInfo>.Instance.LoginTraceId,
			DeviceId = Singleton<NetInfo>.Instance.DeviceId,
			UdpPort = this.ConnectServerPort,
			Token = Singleton<NetInfo>.Instance.Token
		}.ToByteArray();
		fixed (byte* arrayDataReference = MemoryMarshal.GetArrayDataReference<byte>(array))
		{
			byte* data = arrayDataReference;
			FArrayBuffer farrayBuffer = new FArrayBuffer
			{
				Data = (void*)data,
				Length = (ulong)((long)array.Length)
			};
			Singleton<Net>.Instance.KcpClient.SendTcpMessage(0, 3728, farrayBuffer);
		}
	}

	// Token: 0x0600318C RID: 12684 RVA: 0x0001E098 File Offset: 0x0001C298
	private void OnTcpConnectFailed()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Net;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "TCP连接建立失败:";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TcpHosts", Singleton<NetInfo>.Instance.TcpHosts.FormatNetHostInfo());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<Net>.Instance.SetConnectResult(Net.EConnectResult.TCPConnectFailed);
	}

	// Token: 0x0600318D RID: 12685 RVA: 0x0001E0E8 File Offset: 0x0001C2E8
	[NullableContext(0)]
	private unsafe void ProcessKcpConvResponseMessage(EMessageId messageId, Span<byte> bufferSpan)
	{
		KcpConvResponse kcpConvResponse = this.ParseToMessage(messageId, bufferSpan) as KcpConvResponse;
		if (kcpConvResponse == null || kcpConvResponse.Code != ErrorCode.Success)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "TCP连接建立失败:";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TcpHosts", Singleton<NetInfo>.Instance.TcpHosts.FormatNetHostInfo());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Code", (kcpConvResponse != null) ? new ErrorCode?(kcpConvResponse.Code) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.SetConnectResult(Net.EConnectResult.TCPConnectFailed);
			return;
		}
		uint conv = kcpConvResponse.Conv;
		this.KcpClient.CloseTcpConnect();
		this.KcpClient.RemoteMtu = (uint)kcpConvResponse.KcpMtu;
		this.KcpClient.HandleKcpConnect((uint)kcpConvResponse.CrcCheck, conv);
	}

	// Token: 0x0600318E RID: 12686 RVA: 0x0001E1CC File Offset: 0x0001C3CC
	public Net()
	{
		Dictionary<Net.EServerEncryptType, Net.EClientEncryptType> dictionary = new Dictionary<Net.EServerEncryptType, Net.EClientEncryptType>();
		dictionary[Net.EServerEncryptType.NoEncrypt] = Net.EClientEncryptType.NoEncrypt;
		dictionary[Net.EServerEncryptType.Aes] = Net.EClientEncryptType.Aes;
		this.s2cEncryptType = dictionary;
		this.UseBudget = true;
		this.ConnectServerIp = "";
		this.NotifyHandles = new Dictionary<ENotifyMessageId, Net.IMessageCallBack>();
		this.RequestLock = new HashSet<ERequestMessageId>();
		this.MessageCacheList = new global::LinkedList<Net.SendMessageCache>(Net.SendMessageCache.NullMessageCache);
		this.RequestMessageMap = new Dictionary<int, LinkedNode<Net.SendMessageCache>>();
		this.MessageIdNameMap = new Dictionary<EMessageId, string>();
		this.MessageIdStatMap = new Dictionary<EMessageId, Stat>();
		this.StatCall = Stat.Create("Net.Call", "", "");
		this.StatSend = Stat.Create("Net.SendInternal", "", "");
		this.CanTimeOutMessages = new HashSet<ERequestMessageId>();
		this.CallbackList = new global::LinkedList<Net.CallbackQueueItem>(new Net.CallbackQueueItem(delegate(Net.CallbackStatus status)
		{
		}, EMessageId.LoginRequest, true));
		this.StatAddRequestMask = Stat.Create("Net.AddRequestMask", "", "");
		this.StatRemoveRequestMask = Stat.Create("Net.RemoveRequestMask", "", "");
		this.StatEncode = Stat.Create("Net.Encode", "", "");
		base..ctor();
	}

	// Token: 0x04000459 RID: 1113
	public const bool ENABLE_NET_STAT = true;

	// Token: 0x0400045A RID: 1114
	public const bool ENABLE_NET_LOG = true;

	// Token: 0x0400045B RID: 1115
	public const bool ENABLE_HEARTBEAT_LOG = true;

	// Token: 0x0400045C RID: 1116
	public const bool ENABLE_SYNC_LOG = true;

	// Token: 0x0400045D RID: 1117
	public const bool ENABLE_MESSAGE_LOG = false;

	// Token: 0x0400045E RID: 1118
	private readonly Dictionary<Net.EServerEncryptType, Net.EClientEncryptType> s2cEncryptType;

	// Token: 0x0400045F RID: 1119
	private long LastReceiveTimeMsInternal;

	// Token: 0x04000460 RID: 1120
	public bool UseBudget;

	// Token: 0x04000461 RID: 1121
	[Nullable(2)]
	private UKuroKcpClient KcpClient;

	// Token: 0x04000462 RID: 1122
	[Nullable(2)]
	private Net.TConnectResultCallback ConnectCallback;

	// Token: 0x04000463 RID: 1123
	private string ConnectServerIp;

	// Token: 0x04000464 RID: 1124
	private int ConnectServerPort;

	// Token: 0x04000465 RID: 1125
	private int ConnectTimeoutMsPerTry;

	// Token: 0x04000466 RID: 1126
	[Nullable(2)]
	private TimerHandle ConnectTimeoutTimer;

	// Token: 0x04000467 RID: 1127
	private int ConnectRetryCount;

	// Token: 0x04000468 RID: 1128
	private int ConnectMaxRetryCount;

	// Token: 0x04000469 RID: 1129
	private readonly Dictionary<ENotifyMessageId, Net.IMessageCallBack> NotifyHandles;

	// Token: 0x0400046A RID: 1130
	private readonly HashSet<ERequestMessageId> RequestLock;

	// Token: 0x0400046B RID: 1131
	private readonly global::LinkedList<Net.SendMessageCache> MessageCacheList;

	// Token: 0x0400046C RID: 1132
	private readonly Dictionary<int, LinkedNode<Net.SendMessageCache>> RequestMessageMap;

	// Token: 0x0400046D RID: 1133
	private readonly Dictionary<EMessageId, string> MessageIdNameMap;

	// Token: 0x0400046E RID: 1134
	private readonly Dictionary<EMessageId, Stat> MessageIdStatMap;

	// Token: 0x0400046F RID: 1135
	private readonly Stat StatCall;

	// Token: 0x04000470 RID: 1136
	private readonly Stat StatSend;

	// Token: 0x04000471 RID: 1137
	private HashSet<ERequestMessageId> CanTimeOutMessages;

	// Token: 0x04000472 RID: 1138
	private short RpcId;

	// Token: 0x04000473 RID: 1139
	private int UpStreamSeqNo;

	// Token: 0x04000474 RID: 1140
	private int DownStreamSeqNo;

	// Token: 0x04000475 RID: 1141
	private Net.EKcpConnectStatus KcpConnectStatus;

	// Token: 0x04000476 RID: 1142
	private Net.EServerLoginState LoginState;

	// Token: 0x04000477 RID: 1143
	private bool IsReconnecting;

	// Token: 0x04000478 RID: 1144
	private bool IsNetLogEnabled;

	// Token: 0x04000479 RID: 1145
	private bool IsNetStatEnable;

	// Token: 0x0400047A RID: 1146
	private bool IsHeartLogEnabled;

	// Token: 0x0400047B RID: 1147
	private bool IsSyncLogEnabled;

	// Token: 0x0400047C RID: 1148
	private Net.TExceptionHandle ExceptionHandle;

	// Token: 0x0400047D RID: 1149
	private Action<int> AddRequestMaskHandle;

	// Token: 0x0400047E RID: 1150
	private Action<int> RemoveRequestMaskHandle;

	// Token: 0x0400047F RID: 1151
	private Net.TNetworkErrorHandle NetErrorHandle;

	// Token: 0x04000480 RID: 1152
	[Nullable(2)]
	private Net.CallbackQueueItem CurrentProcessedCallback;

	// Token: 0x04000481 RID: 1153
	private readonly global::LinkedList<Net.CallbackQueueItem> CallbackList;

	// Token: 0x04000482 RID: 1154
	private int NonePausedCallbackCount;

	// Token: 0x04000483 RID: 1155
	private bool IsNotifyCallbackPausedInternal;

	// Token: 0x04000484 RID: 1156
	private readonly Stat StatAddRequestMask;

	// Token: 0x04000485 RID: 1157
	private readonly Stat StatRemoveRequestMask;

	// Token: 0x04000486 RID: 1158
	private readonly Stat StatEncode;

	// Token: 0x02007199 RID: 29081
	[NullableContext(0)]
	public enum EMsgTypeIndex
	{
		// Token: 0x040278F8 RID: 162040
		Request,
		// Token: 0x040278F9 RID: 162041
		Response
	}

	// Token: 0x0200719A RID: 29082
	[NullableContext(2)]
	public interface IMessageCallBack
	{
		// Token: 0x060467A6 RID: 288678
		void Invoke(IMessage message, Net.CallbackStatus callbackStatus);
	}

	// Token: 0x0200719B RID: 29083
	[NullableContext(2)]
	[Nullable(0)]
	public class MessageCallback<T> : Net.IMessageCallBack
	{
		// Token: 0x060467A7 RID: 288679 RVA: 0x012AD28A File Offset: 0x012AB48A
		public MessageCallback([Nullable(new byte[]
		{
			1,
			2,
			2
		})] Action<T, Net.CallbackStatus> callback)
		{
		}

		// Token: 0x060467A8 RID: 288680 RVA: 0x012AD29C File Offset: 0x012AB49C
		public void Invoke(IMessage message, Net.CallbackStatus callbackStatus)
		{
			try
			{
				if (this.Callback != null)
				{
					T arg = (T)((object)message);
					this.Callback(arg, callbackStatus);
				}
			}
			catch (Exception ex) when (1)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Net;
				ELogAuthor author = ELogAuthor.LRX;
				string message2 = "Callback执行异常:";
				Exception error = ex;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "声明类型";
				Action<T, Net.CallbackStatus> callback = this.Callback;
				object item2;
				if (callback == null)
				{
					item2 = null;
				}
				else
				{
					Type declaringType = callback.Method.DeclaringType;
					item2 = ((declaringType != null) ? declaringType.FullName : null);
				}
				ptr = new ValueTuple<string, object>(item, item2);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item3 = "方法:";
				Action<T, Net.CallbackStatus> callback2 = this.Callback;
				ptr2 = new ValueTuple<string, object>(item3, (callback2 != null) ? callback2.Method.Name : null);
				instance.ErrorWithStack(module, author, message2, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x040278FA RID: 162042
		private readonly Action<T, Net.CallbackStatus> Callback = callback;
	}

	// Token: 0x0200719C RID: 29084
	[NullableContext(0)]
	private enum EMessageType
	{
		// Token: 0x040278FC RID: 162044
		Request = 1,
		// Token: 0x040278FD RID: 162045
		Response,
		// Token: 0x040278FE RID: 162046
		Exception,
		// Token: 0x040278FF RID: 162047
		Push
	}

	// Token: 0x0200719D RID: 29085
	[NullableContext(0)]
	public enum EServerEncryptType
	{
		// Token: 0x04027901 RID: 162049
		NoEncrypt,
		// Token: 0x04027902 RID: 162050
		Aes = 2
	}

	// Token: 0x0200719E RID: 29086
	[NullableContext(0)]
	private enum EClientEncryptType
	{
		// Token: 0x04027904 RID: 162052
		Aes,
		// Token: 0x04027905 RID: 162053
		NoEncrypt,
		// Token: 0x04027906 RID: 162054
		Rsa
	}

	// Token: 0x0200719F RID: 29087
	[NullableContext(0)]
	private enum EKcpConnectStatus
	{
		// Token: 0x04027908 RID: 162056
		NoConnect,
		// Token: 0x04027909 RID: 162057
		Connecting,
		// Token: 0x0402790A RID: 162058
		Connected
	}

	// Token: 0x020071A0 RID: 29088
	[NullableContext(0)]
	public enum EConnectResult
	{
		// Token: 0x0402790C RID: 162060
		Success,
		// Token: 0x0402790D RID: 162061
		Timeout,
		// Token: 0x0402790E RID: 162062
		Disconnect,
		// Token: 0x0402790F RID: 162063
		Other,
		// Token: 0x04027910 RID: 162064
		TCPConnectFailed,
		// Token: 0x04027911 RID: 162065
		TCPConnectTimeOut
	}

	// Token: 0x020071A1 RID: 29089
	[NullableContext(0)]
	public enum EDisconnectReason
	{
		// Token: 0x04027913 RID: 162067
		Logout,
		// Token: 0x04027914 RID: 162068
		Reconnect,
		// Token: 0x04027915 RID: 162069
		LoginFail
	}

	// Token: 0x020071A2 RID: 29090
	[NullableContext(0)]
	public class CallbackStatus
	{
		// Token: 0x060467A9 RID: 288681 RVA: 0x012AD37C File Offset: 0x012AB57C
		public CallbackStatus(EMessageId messageId)
		{
			this.CallbackMessageId = messageId;
		}

		// Token: 0x1700A76A RID: 42858
		// (get) Token: 0x060467AA RID: 288682 RVA: 0x012AD392 File Offset: 0x012AB592
		public EMessageId MessageId
		{
			get
			{
				return this.CallbackMessageId;
			}
		}

		// Token: 0x1700A76B RID: 42859
		// (get) Token: 0x060467AB RID: 288683 RVA: 0x012AD39A File Offset: 0x012AB59A
		public bool IsJobFinished
		{
			get
			{
				return this.IsFinished;
			}
		}

		// Token: 0x1700A76C RID: 42860
		// (get) Token: 0x060467AC RID: 288684 RVA: 0x012AD3A2 File Offset: 0x012AB5A2
		public int CallbackCount
		{
			get
			{
				return this.Count;
			}
		}

		// Token: 0x060467AD RID: 288685 RVA: 0x012AD3AA File Offset: 0x012AB5AA
		public void IncrementCount()
		{
			this.Count++;
		}

		// Token: 0x04027916 RID: 162070
		[Nullable(2)]
		public object UserData;

		// Token: 0x04027917 RID: 162071
		public bool IsFinished = true;

		// Token: 0x04027918 RID: 162072
		private int Count;

		// Token: 0x04027919 RID: 162073
		private readonly EMessageId CallbackMessageId;
	}

	// Token: 0x020071A3 RID: 29091
	// (Invoke) Token: 0x060467AF RID: 288687
	[NullableContext(0)]
	public delegate void WrappedCallback(Net.CallbackStatus status);

	// Token: 0x020071A4 RID: 29092
	[Nullable(0)]
	private class CallbackQueueItem
	{
		// Token: 0x060467B2 RID: 288690 RVA: 0x012AD3BA File Offset: 0x012AB5BA
		public CallbackQueueItem(Net.WrappedCallback callback, EMessageId messageId, bool isPaused)
		{
			this.Callback = callback;
			this.Status = new Net.CallbackStatus(messageId);
			this.IsPausedInternal = isPaused;
		}

		// Token: 0x060467B3 RID: 288691 RVA: 0x012AD3DC File Offset: 0x012AB5DC
		public bool DoCallback()
		{
			Net.WrappedCallback callback = this.Callback;
			if (callback != null)
			{
				callback(this.Status);
			}
			return this.Status.IsJobFinished;
		}

		// Token: 0x060467B4 RID: 288692 RVA: 0x012AD400 File Offset: 0x012AB600
		public bool IsPaused()
		{
			return this.IsPausedInternal;
		}

		// Token: 0x0402791A RID: 162074
		private readonly Net.WrappedCallback Callback;

		// Token: 0x0402791B RID: 162075
		private readonly Net.CallbackStatus Status;

		// Token: 0x0402791C RID: 162076
		private readonly bool IsPausedInternal;
	}

	// Token: 0x020071A5 RID: 29093
	[NullableContext(0)]
	public enum EServerLoginState
	{
		// Token: 0x0402791E RID: 162078
		NoLogin,
		// Token: 0x0402791F RID: 162079
		AskingProtoKey,
		// Token: 0x04027920 RID: 162080
		ProtoKeyReady,
		// Token: 0x04027921 RID: 162081
		DoingLogin,
		// Token: 0x04027922 RID: 162082
		FinishedLogin,
		// Token: 0x04027923 RID: 162083
		Logout
	}

	// Token: 0x020071A6 RID: 29094
	[NullableContext(0)]
	private enum EKcpErrorCodeLevel1
	{
		// Token: 0x04027925 RID: 162085
		NoError,
		// Token: 0x04027926 RID: 162086
		SocketReceiveError,
		// Token: 0x04027927 RID: 162087
		PayloadError,
		// Token: 0x04027928 RID: 162088
		DecryptError,
		// Token: 0x04027929 RID: 162089
		KcpRecvError
	}

	// Token: 0x020071A7 RID: 29095
	[NullableContext(0)]
	private enum EKcpConnectError
	{
		// Token: 0x0402792B RID: 162091
		CrcCheckError = -4
	}

	// Token: 0x020071A8 RID: 29096
	[NullableContext(0)]
	private enum ESocketErrors
	{
		// Token: 0x0402792D RID: 162093
		SE_NO_ERROR
	}

	// Token: 0x020071A9 RID: 29097
	[NullableContext(0)]
	public class SendMessageCache : IDisposable
	{
		// Token: 0x1700A76D RID: 42861
		// (get) Token: 0x060467B5 RID: 288693 RVA: 0x012AD408 File Offset: 0x012AB608
		public Span<byte> EncodeMessage
		{
			get
			{
				if (this.EncodeMessageBuffer == null)
				{
					return Span<byte>.Empty;
				}
				return new Span<byte>(this.EncodeMessageBuffer, 0, this.MessageSize);
			}
		}

		// Token: 0x060467B6 RID: 288694 RVA: 0x012AD42C File Offset: 0x012AB62C
		public SendMessageCache(int? rpcId, int? seqNo, EMessageId? id, Span<byte> encodeMessage, [Nullable(2)] Net.IMessageCallBack handle)
		{
			this.RpcId = rpcId.GetValueOrDefault();
			this.SeqNo = seqNo.GetValueOrDefault();
			this.MessageId = id.GetValueOrDefault();
			if (!encodeMessage.IsEmpty)
			{
				this.EncodeMessageBuffer = ArrayPool<byte>.Shared.Rent(encodeMessage.Length);
				this.MessageSize = encodeMessage.Length;
				encodeMessage.CopyTo(this.EncodeMessageBuffer);
			}
			this.Handle = handle;
			this.SendTimeMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			this.TimeoutHandle = null;
		}

		// Token: 0x060467B7 RID: 288695 RVA: 0x012AD4C7 File Offset: 0x012AB6C7
		public void ClearHandle()
		{
			this.Handle = null;
		}

		// Token: 0x060467B8 RID: 288696 RVA: 0x012AD4D0 File Offset: 0x012AB6D0
		public void Dispose()
		{
			if (this.EncodeMessageBuffer != null)
			{
				ArrayPool<byte>.Shared.Return(this.EncodeMessageBuffer, false);
				this.EncodeMessageBuffer = null;
				this.MessageSize = 0;
			}
		}

		// Token: 0x060467B9 RID: 288697 RVA: 0x012AD4FC File Offset: 0x012AB6FC
		[NullableContext(1)]
		public static void DisposeAndRemoveBefore(global::LinkedList<Net.SendMessageCache> list, LinkedNode<Net.SendMessageCache> node, bool includeThis)
		{
			Net.SendMessageCache element = node.Element;
			if (element == null || !element.InList)
			{
				return;
			}
			LinkedNode<Net.SendMessageCache> linkedNode = list.GetHeadNextNode();
			while (linkedNode != null && linkedNode != node)
			{
				Net.SendMessageCache element2 = linkedNode.Element;
				if (element2 != null)
				{
					element2.Dispose();
				}
				if (linkedNode.Element != null)
				{
					linkedNode.Element.InList = false;
				}
				linkedNode = linkedNode.Next;
			}
			if (includeThis)
			{
				Net.SendMessageCache element3 = node.Element;
				if (element3 != null)
				{
					element3.Dispose();
				}
				node.Element.InList = false;
			}
			list.RemoveNodesBeforeThis(node, includeThis);
		}

		// Token: 0x060467BA RID: 288698 RVA: 0x012AD584 File Offset: 0x012AB784
		[NullableContext(1)]
		public static void DisposeAllAndClear(global::LinkedList<Net.SendMessageCache> list)
		{
			for (LinkedNode<Net.SendMessageCache> linkedNode = list.GetHeadNextNode(); linkedNode != null; linkedNode = linkedNode.Next)
			{
				Net.SendMessageCache element = linkedNode.Element;
				if (element != null)
				{
					element.Dispose();
				}
				if (linkedNode.Element != null)
				{
					linkedNode.Element.InList = false;
				}
			}
			list.RemoveAllNodeWithoutHead();
		}

		// Token: 0x1700A76E RID: 42862
		// (get) Token: 0x060467BB RID: 288699 RVA: 0x012AD5CF File Offset: 0x012AB7CF
		[Nullable(1)]
		public static Net.SendMessageCache NullMessageCache { [NullableContext(1)] get; } = new Net.SendMessageCache(null, null, null, null, null);

		// Token: 0x0402792E RID: 162094
		public int RpcId;

		// Token: 0x0402792F RID: 162095
		public int SeqNo;

		// Token: 0x04027930 RID: 162096
		public EMessageId MessageId;

		// Token: 0x04027931 RID: 162097
		[Nullable(2)]
		private byte[] EncodeMessageBuffer;

		// Token: 0x04027932 RID: 162098
		private int MessageSize;

		// Token: 0x04027933 RID: 162099
		public long SendTimeMs;

		// Token: 0x04027934 RID: 162100
		[Nullable(2)]
		public TimerHandle TimeoutHandle;

		// Token: 0x04027935 RID: 162101
		[Nullable(2)]
		public Net.IMessageCallBack Handle;

		// Token: 0x04027936 RID: 162102
		public bool InList;
	}

	// Token: 0x020071AA RID: 29098
	// (Invoke) Token: 0x060467BE RID: 288702
	[NullableContext(0)]
	public delegate void TExceptionHandle(int rpcId, int errorCode, int messageId, [Nullable(2)] object message, string errorMessage);

	// Token: 0x020071AB RID: 29099
	// (Invoke) Token: 0x060467C2 RID: 288706
	[NullableContext(0)]
	public delegate void TConnectResultCallback(Net.EConnectResult result);

	// Token: 0x020071AC RID: 29100
	// (Invoke) Token: 0x060467C6 RID: 288710
	[NullableContext(0)]
	public delegate void TNetworkErrorHandle(int errorCode);
}
