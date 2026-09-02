using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.CombatMessage;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.Utils;
using CSharpScript.Typing;
using Google.Protobuf;

// Token: 0x0200186C RID: 6252
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CombatNet : Singleton<CombatNet>
{
	// Token: 0x17000E91 RID: 3729
	// (get) Token: 0x0600B319 RID: 45849 RVA: 0x002FCB5D File Offset: 0x002FAD5D
	// (set) Token: 0x0600B31A RID: 45850 RVA: 0x002FCB65 File Offset: 0x002FAD65
	public Dictionary<ENotifyMessageId, IHandler> NotifyMap { get; set; } = new Dictionary<ENotifyMessageId, IHandler>();

	// Token: 0x17000E92 RID: 3730
	// (get) Token: 0x0600B31B RID: 45851 RVA: 0x002FCB6E File Offset: 0x002FAD6E
	// (set) Token: 0x0600B31C RID: 45852 RVA: 0x002FCB76 File Offset: 0x002FAD76
	public Dictionary<int, Action<IMessage>> RequestMap { get; set; } = new Dictionary<int, Action<IMessage>>();

	// Token: 0x17000E93 RID: 3731
	// (get) Token: 0x0600B31D RID: 45853 RVA: 0x002FCB7F File Offset: 0x002FAD7F
	// (set) Token: 0x0600B31E RID: 45854 RVA: 0x002FCB87 File Offset: 0x002FAD87
	[Nullable(new byte[]
	{
		1,
		1,
		2,
		1,
		1
	})]
	private Dictionary<long, Tuple<int, Action<IMessage>, CombatSendData>> PendingCallList { [return: Nullable(new byte[]
	{
		1,
		1,
		2,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		1,
		1,
		2,
		1,
		1
	})] set; } = new Dictionary<long, Tuple<int, Action<IMessage>, CombatSendData>>();

	// Token: 0x17000E94 RID: 3732
	// (get) Token: 0x0600B31F RID: 45855 RVA: 0x002FCB90 File Offset: 0x002FAD90
	// (set) Token: 0x0600B320 RID: 45856 RVA: 0x002FCB98 File Offset: 0x002FAD98
	private Stat CallStat { get; set; } = Stat.Create("CombatNet.Call", "", "");

	// Token: 0x17000E95 RID: 3733
	// (get) Token: 0x0600B321 RID: 45857 RVA: 0x002FCBA1 File Offset: 0x002FADA1
	// (set) Token: 0x0600B322 RID: 45858 RVA: 0x002FCBA9 File Offset: 0x002FADA9
	private Stat SendStat { get; set; } = Stat.Create("CombatNet.Send", "", "");

	// Token: 0x0600B323 RID: 45859 RVA: 0x002FCBB4 File Offset: 0x002FADB4
	[NullableContext(0)]
	[CombatListenImplement]
	public unsafe static void Listen<T>([Nullable(new byte[]
	{
		1,
		2,
		1,
		2
	})] Action<Entity, T, CombatCommon> callBack, ENotifyMessageId notifyId, bool needSync, bool needCache = false) where T : IMessage
	{
		CombatNet.<>c__DisplayClass22_0<T> CS$<>8__locals1 = new CombatNet.<>c__DisplayClass22_0<T>();
		CS$<>8__locals1.callBack = callBack;
		IHandler handler;
		if (!Singleton<CombatNet>.Instance.NotifyMap.TryGetValue(notifyId, out handler))
		{
			handler = new StaticHandler
			{
				IsSync = new bool?(needSync),
				IsCache = new bool?(needCache),
				Listener = null,
				Preprocessor = null
			};
			Singleton<CombatNet>.Instance.NotifyMap[notifyId] = handler;
		}
		StaticHandler staticHandler = handler as StaticHandler;
		if (handler.Type == EHandlerType.Component || (staticHandler != null && staticHandler.Listener != null))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiplayerCombat;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "重复注册函数监听或类型不匹配";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MessageKey", notifyId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MessageId", notifyId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FunctionName", CS$<>8__locals1.callBack);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		staticHandler.IsSync = new bool?(needSync);
		staticHandler.Listener = new Action<Entity, IMessage, CombatCommon>(CS$<>8__locals1.<Listen>g__WrappedCallBack|0);
	}

	// Token: 0x0600B324 RID: 45860 RVA: 0x002FCCDC File Offset: 0x002FAEDC
	[NullableContext(0)]
	[CombatPreprocessImplement]
	public unsafe static void Preprocess<T>([Nullable(new byte[]
	{
		1,
		2,
		1,
		2
	})] Func<Entity, T, CombatCommon, bool> callBack, ENotifyMessageId notifyId) where T : IMessage
	{
		CombatNet.<>c__DisplayClass23_0<T> CS$<>8__locals1 = new CombatNet.<>c__DisplayClass23_0<T>();
		CS$<>8__locals1.callBack = callBack;
		IHandler handler;
		if (!Singleton<CombatNet>.Instance.NotifyMap.TryGetValue(notifyId, out handler))
		{
			handler = new StaticHandler
			{
				IsSync = null,
				IsCache = null,
				Listener = null,
				Preprocessor = null
			};
			Singleton<CombatNet>.Instance.NotifyMap[notifyId] = handler;
		}
		StaticHandler staticHandler = handler as StaticHandler;
		if (handler.Type == EHandlerType.Component || (staticHandler != null && staticHandler.Preprocessor != null))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiplayerCombat;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "不能为组件listener注册预处理函数或类型不匹配";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MessageKey", notifyId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MessageId", notifyId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FunctionName", CS$<>8__locals1.callBack);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		staticHandler.Preprocessor = new Func<Entity, IMessage, CombatCommon, bool>(CS$<>8__locals1.<Preprocess>g__WrappedCallBack|0);
	}

	// Token: 0x0600B325 RID: 45861 RVA: 0x002FCE00 File Offset: 0x002FB000
	protected unsafe bool CheckHandle(object target, ECombatNotifyDataMessage notifyKey, int notifyId, string property)
	{
		if (!(target is Type))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiplayerCombat;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "CombatMessage notify callback should be static function";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MessageKey", notifyKey);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MessageId", notifyId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FunctionName", property);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		return true;
	}

	// Token: 0x0600B326 RID: 45862 RVA: 0x002FCE91 File Offset: 0x002FB091
	public void RemovePendingCall(long msgId)
	{
		this.PendingCallList.Remove(msgId);
	}

	// Token: 0x0600B327 RID: 45863 RVA: 0x002FCEA0 File Offset: 0x002FB0A0
	public int GenerateRpcId()
	{
		if (this.RequestId < 32767)
		{
			int num = this.RequestId + 1;
			this.RequestId = num;
			return num;
		}
		return this.RequestId = 0;
	}

	// Token: 0x0600B328 RID: 45864 RVA: 0x002FCED8 File Offset: 0x002FB0D8
	public long Call<[Nullable(0)] T>(ERequestMessageId id, [Nullable(2)] Entity entity, IMessage data, [Nullable(new byte[]
	{
		2,
		1
	})] Action<T> handle = null, long? preMessageId = null, long? messageId = null, bool? isServerRequest = null, bool? isPending = null) where T : IMessage
	{
		CombatNet.<>c__DisplayClass27_0<T> CS$<>8__locals1 = new CombatNet.<>c__DisplayClass27_0<T>();
		CS$<>8__locals1.handle = handle;
		if (preMessageId != null && this.PendingCallList.ContainsKey(preMessageId.Value))
		{
			Tuple<int, Action<IMessage>, CombatSendData> tuple = this.PendingCallList[preMessageId.Value];
			int item = tuple.Item1;
			Action<IMessage> item2 = tuple.Item2;
			CombatSendData item3 = tuple.Item3;
			if (item2 != null)
			{
				this.RequestMap[item] = item2;
			}
			ModelBase<CombatMessageModel>.Instance.MessagePack.Data.Add(item3);
			this.PendingCallList.Remove(preMessageId.Value);
		}
		long? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			num = ((component != null) ? new long?(component.GetCreatureDataId()) : null);
		}
		long? num2 = num;
		long valueOrDefault = num2.GetValueOrDefault();
		int num3 = this.GenerateRpcId();
		long num4 = messageId ?? ModelBase<CombatMessageModel>.Instance.GenMessageId();
		CombatRequestData combatRequestData = new CombatRequestData();
		combatRequestData.RequestId = num3;
		combatRequestData.CombatCommon = this.CreateCombatCommon(valueOrDefault, isServerRequest, preMessageId, new long?(num4));
		CombatMessageExtension.SetRequestDataMessage(combatRequestData, (ECombatRequestDataMessage)id, data);
		CombatSendData combatSendData = new CombatSendData();
		combatSendData.Request = combatRequestData;
		if (isPending.GetValueOrDefault())
		{
			this.PendingCallList[num4] = new Tuple<int, Action<IMessage>, CombatSendData>(num3, new Action<IMessage>(CS$<>8__locals1.<Call>g__WrapHandle|0), combatSendData);
		}
		else
		{
			this.RequestMap[num3] = new Action<IMessage>(CS$<>8__locals1.<Call>g__WrapHandle|0);
			ModelBase<CombatMessageModel>.Instance.MessagePack.Data.Add(combatSendData);
		}
		return num4;
	}

	// Token: 0x0600B329 RID: 45865 RVA: 0x002FD078 File Offset: 0x002FB278
	[Conditional("DEBUG")]
	private void DataReport(ERequestMessageId id, [Nullable(2)] Entity entity, IMessage data)
	{
		int num = data.CalculateSize();
		CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
		int? num2 = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null;
		EEntityType? eentityType = (creatureDataComponent != null) ? new EEntityType?(creatureDataComponent.GetEntityType()) : null;
		long? num3 = (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null;
		if (num > 0)
		{
			string data2 = Json.Encode(new Dictionary<string, object>
			{
				{
					"scene_id",
					ModelBase<CreatureModel>.Instance.GetSceneId()
				},
				{
					"instance_id",
					ModelBase<CreatureModel>.Instance.GetInstanceId()
				},
				{
					"creature_id",
					num3
				},
				{
					"pb_data_id",
					num2
				},
				{
					"entity_type",
					eentityType
				},
				{
					"msg_id",
					(int)id
				},
				{
					"length",
					num
				},
				{
					"is_multi",
					ModelBase<GameModeModel>.Instance.IsMulti
				},
				{
					"is_request",
					true
				},
				{
					"ed",
					this.IsWithEditor
				},
				{
					"br",
					Singleton<LogAnalyzer>.Instance.GetBranch()
				}
			}, null);
			ControllerBase<CombatDebugController>.Instance.DataReport("COMBAT_MESSAGE_INFO", data2);
		}
	}

	// Token: 0x0600B32A RID: 45866 RVA: 0x002FD1EC File Offset: 0x002FB3EC
	public long Send(EPushMessageId id, Entity entity, IMessage message, long? preMessageId = null, long? messageId = null, bool? isServerRequest = null)
	{
		if (preMessageId != null && this.PendingCallList.ContainsKey(preMessageId.Value))
		{
			Tuple<int, Action<IMessage>, CombatSendData> tuple = this.PendingCallList[preMessageId.Value];
			int item = tuple.Item1;
			Action<IMessage> item2 = tuple.Item2;
			CombatSendData item3 = tuple.Item3;
			if (item2 != null)
			{
				this.RequestMap[item] = item2;
			}
			ModelBase<CombatMessageModel>.Instance.MessagePack.Data.Add(item3);
			this.PendingCallList.Remove(preMessageId.Value);
		}
		CombatPushData combatPushData = new CombatPushData();
		long? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			num = ((component != null) ? new long?(component.GetCreatureDataId()) : null);
		}
		long? num2 = num;
		long valueOrDefault = num2.GetValueOrDefault();
		long value = messageId.GetValueOrDefault();
		if (messageId == null)
		{
			value = ModelBase<CombatMessageModel>.Instance.GenMessageId();
			messageId = new long?(value);
		}
		combatPushData.CombatCommon = this.CreateCombatCommon(valueOrDefault, isServerRequest, preMessageId, messageId);
		CombatMessageExtension.SetPushDataMessage(combatPushData, (ECombatPushDataMessage)id, message);
		CombatSendData combatSendData = new CombatSendData();
		combatSendData.Push = combatPushData;
		ModelBase<CombatMessageModel>.Instance.MessagePack.Data.Add(combatSendData);
		return messageId.Value;
	}

	// Token: 0x0600B32B RID: 45867 RVA: 0x002FD328 File Offset: 0x002FB528
	public CombatCommon CreateCombatCommon(long creatureDataId, bool? isServerRequest = null, long? preMessageId = null, long? messageId = null)
	{
		return new CombatCommon
		{
			EntityId = creatureDataId,
			PreMessageId = preMessageId.GetValueOrDefault(),
			MessageId = (messageId ?? ModelBase<CombatMessageModel>.Instance.GenMessageId()),
			Originator = (long)ModelBase<CreatureModel>.Instance.GetPlayerId(),
			TimeStamp = (float)Singleton<Time>.Instance.NowSeconds,
			IsServerRequest = isServerRequest.GetValueOrDefault()
		};
	}

	// Token: 0x040054C5 RID: 21701
	private readonly int IsWithEditor = (KuroApplication.IsWithEditor() > false) ? 1 : 0;

	// Token: 0x040054C7 RID: 21703
	private int RequestId;
}
