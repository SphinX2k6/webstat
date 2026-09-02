using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Ai;
using Aki.Protocol.CombatMessage;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.NewWorld.Vehicle.Common;
using CSharpScript.Game.Utils;
using CSharpScript.Typing;
using Google.Protobuf;
using Google.Protobuf.Collections;
using UnrealEngine;

namespace CSharpScript.Game.Module.CombatMessage
{
	// Token: 0x02005E8E RID: 24206
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class CombatMessageController : ControllerBase<CombatMessageController>
	{
		// Token: 0x17009975 RID: 39285
		// (get) Token: 0x0603CDDA RID: 249306 RVA: 0x00F72A83 File Offset: 0x00F70C83
		protected override bool IsTickEvenPausedInternal
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17009976 RID: 39286
		// (get) Token: 0x0603CDDB RID: 249307 RVA: 0x00F72A86 File Offset: 0x00F70C86
		public CombatMessageModel Model
		{
			get
			{
				return ModelBase<CombatMessageModel>.Instance;
			}
		}

		// Token: 0x0603CDDC RID: 249308 RVA: 0x00F72A90 File Offset: 0x00F70C90
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<ResetLocationForZRangeNotify>(ENotifyMessageId.ResetLocationForZRangeNotify, new Action<ResetLocationForZRangeNotify, Net.CallbackStatus>(this.ResetLocationForZRangeNotify));
			Singleton<Net>.Instance.Register<MovePackageNotify>(ENotifyMessageId.MovePackageNotify, new Action<MovePackageNotify, Net.CallbackStatus>(this.MovePackageNotify));
			Singleton<Net>.Instance.Register<UDPMovePackageNotify>(ENotifyMessageId.UDPMovePackageNotify, new Action<UDPMovePackageNotify, Net.CallbackStatus>(this.UDPMovePackageNotify));
			Singleton<Net>.Instance.Register<MotorAnimReplaySampleUdpNotify>(ENotifyMessageId.MotorAnimReplaySampleUdpNotify, new Action<MotorAnimReplaySampleUdpNotify, Net.CallbackStatus>(this.UDPMotorAnimNotify));
			Singleton<Net>.Instance.Register<SceneItemMoveTargetNotify>(ENotifyMessageId.SceneItemMoveTargetNotify, new Action<SceneItemMoveTargetNotify, Net.CallbackStatus>(this.SceneItemMoveTargetNotify));
			Singleton<Net>.Instance.Register<AiControlSwitchNotify>(ENotifyMessageId.AiControlSwitchNotify, new Action<AiControlSwitchNotify, Net.CallbackStatus>(this.AiControlSwitchNotify));
			Singleton<Net>.Instance.Register<PreAiControlSwitchNotify>(ENotifyMessageId.PreAiControlSwitchNotify, new Action<PreAiControlSwitchNotify, Net.CallbackStatus>(this.PreAiControlSwitchNotify));
			Singleton<Net>.Instance.Register<CombatReceivePackNotify>(ENotifyMessageId.CombatReceivePackNotify, new Action<CombatReceivePackNotify, Net.CallbackStatus>(this.OnPackNotify));
			Singleton<Net>.Instance.Register<SplineMoveNotify>(ENotifyMessageId.SplineMoveNotify, new Action<SplineMoveNotify, Net.CallbackStatus>(this.SplineMoveNotify));
			Singleton<EventSystem>.Instance.Add<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.RegisterAiHateEntity));
			return true;
		}

		// Token: 0x0603CDDD RID: 249309 RVA: 0x00F72BB8 File Offset: 0x00F70DB8
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ResetLocationForZRangeNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MovePackageNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.UDPMovePackageNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SceneItemMoveTargetNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AiControlSwitchNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PreAiControlSwitchNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CombatReceivePackNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SplineMoveNotify);
			Singleton<EventSystem>.Instance.Remove<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.RegisterAiHateEntity));
			Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
			return true;
		}

		// Token: 0x0603CDDE RID: 249310 RVA: 0x00F72C70 File Offset: 0x00F70E70
		[return: Nullable(2)]
		private Stat GetCombatStat(string name)
		{
			Stat stat;
			if (!this.CombatStatMap.TryGetValue(name, out stat))
			{
				stat = Stat.CreateNoFlameGraph(name, "", "STATGROUP_KuroBattle");
				this.CombatStatMap[name] = stat;
			}
			return stat;
		}

		// Token: 0x0603CDDF RID: 249311 RVA: 0x00F72CAC File Offset: 0x00F70EAC
		[NullableContext(2)]
		private void OnPackNotify(CombatReceivePackNotify pack, Net.CallbackStatus status)
		{
			foreach (CombatReceiveData combatReceiveData in pack.Data)
			{
				if (combatReceiveData.CombatNotifyData != null)
				{
					CombatNotifyData combatNotifyData = combatReceiveData.CombatNotifyData;
					this.GetCombatStat(combatNotifyData.MessageCase.ToString());
					this.OnCombatNotify(combatNotifyData.CombatCommon, combatNotifyData);
				}
				else if (combatReceiveData.CombatResponseData != null)
				{
					CombatResponseData combatResponseData = combatReceiveData.CombatResponseData;
					this.GetCombatStat(combatResponseData.MessageCase.ToString());
					this.OnCombatResponse(combatResponseData.CombatCommon, combatResponseData);
				}
			}
		}

		// Token: 0x0603CDE0 RID: 249312 RVA: 0x00F72D6C File Offset: 0x00F70F6C
		private unsafe void OnCombatNotify(CombatCommon combatCommon, CombatNotifyData notify)
		{
			CombatExactNotifyDataPack exactNotifyDataPack = notify.GetExactNotifyDataPack();
			string value = notify.MessageCase.ToString();
			ECombatNotifyDataMessage ecombatNotifyDataMessage;
			if (exactNotifyDataPack == null || !Enum.TryParse<ECombatNotifyDataMessage>(value, true, out ecombatNotifyDataMessage))
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Message;
				Entity entity = null;
				string message = "无法解析协议数据";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MessageCase :", notify.MessageCase);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CombatCommon :", combatCommon);
				instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			ControllerBase<CombatDebugController>.Instance.CombatInfoMessage(CombatLog.EDebugModule.Notify, (EMessageId)ecombatNotifyDataMessage, combatCommon);
			long entityId = combatCommon.EntityId;
			EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			Entity entity3 = (entity2 != null) ? entity2.Entity : null;
			if (entity3 == null)
			{
				CombatLog instance2 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Notify;
				long entityId2 = entityId;
				string message2 = "服务器下发打包协议找不到实体";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("MessageCase :", notify.MessageCase);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("CombatCommon :", combatCommon);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("msg", notify);
				instance2.Warn(flag2, entityId2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return;
			}
			IHandler handler;
			if (!Singleton<CombatNet>.Instance.NotifyMap.TryGetValue((ENotifyMessageId)ecombatNotifyDataMessage, out handler))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MultiplayerCombat;
				ELogAuthor author = ELogAuthor.ZQR;
				string message3 = "协议找不到对应的监听器";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("MessageCase :", notify.MessageCase);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("CombatCommon :", combatCommon);
				instance3.Error(module, author, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			}
			long originator = combatCommon.Originator;
			CombatMessageBuffer messageBuffer = this.Model.GetMessageBuffer(originator);
			if (entity2 != null && !entity2.IsInit && handler != null)
			{
				bool flag3 = !(handler.IsCache ?? false);
				if (flag3)
				{
					CombatLog instance4 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag4 = CombatLog.EDebugModule.Notify;
					long entityId3 = entityId;
					string message4 = "协议丢弃，实体未加载完成";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("MessageCase :", notify.MessageCase);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("CombatCommon :", combatCommon);
					instance4.Warn(flag4, entityId3, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
					return;
				}
				if (messageBuffer != null)
				{
					messageBuffer.AddToQueue((ENotifyMessageId)ecombatNotifyDataMessage, entity3, combatCommon, exactNotifyDataPack.Message);
					return;
				}
			}
			else if (handler != null)
			{
				EHandlerType type = handler.Type;
				if (type != EHandlerType.Static)
				{
					return;
				}
				StaticHandler staticHandler = handler as StaticHandler;
				if (staticHandler != null)
				{
					Func<Entity, IMessage, CombatCommon, bool> preprocessor = staticHandler.Preprocessor;
					if (preprocessor == null || preprocessor(entity3, exactNotifyDataPack.Message, combatCommon))
					{
						bool? isSync = handler.IsSync;
						if (isSync != null && isSync.GetValueOrDefault() && messageBuffer != null && ModelBase<GameModeModel>.Instance.IsMulti)
						{
							messageBuffer.AddToQueue((ENotifyMessageId)ecombatNotifyDataMessage, entity3, combatCommon, exactNotifyDataPack.Message);
							return;
						}
						Action<Entity, IMessage, CombatCommon> listener = staticHandler.Listener;
						if (listener == null)
						{
							return;
						}
						listener(entity3, exactNotifyDataPack.Message, combatCommon);
					}
				}
			}
		}

		// Token: 0x0603CDE1 RID: 249313 RVA: 0x00F73088 File Offset: 0x00F71288
		[Conditional("DEBUG")]
		[Conditional("DEBUG_EDITOR")]
		[Conditional("DEVELOPMENT")]
		[Conditional("DEVELOPMENT_EDITOR")]
		private void NotifyDataReport(ECombatNotifyDataMessage id, [Nullable(2)] EntityHandle handle, CombatNotifyData notify)
		{
			int num = notify.CalculateSize();
			object obj;
			if (handle == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = handle.Entity;
				obj = ((entity != null) ? entity.GetComponent<CreatureDataComponent>() : null);
			}
			object obj2 = obj;
			int? num2 = (obj2 != null) ? new int?(obj2.GetPbDataId()) : null;
			EEntityType? eentityType = (obj2 != null) ? new EEntityType?(obj2.GetEntityType()) : null;
			long? num3 = (obj2 != null) ? new long?(obj2.GetCreatureDataId()) : null;
			if (num > 0)
			{
				string data = Json.Encode(new Dictionary<string, object>
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
						"is_notify",
						true
					},
					{
						"ed",
						this.IS_WITH_EDITOR
					},
					{
						"br",
						Singleton<LogAnalyzer>.Instance.GetBranch()
					}
				}, null);
				ControllerBase<CombatDebugController>.Instance.DataReport("COMBAT_MESSAGE_INFO", data);
			}
		}

		// Token: 0x0603CDE2 RID: 249314 RVA: 0x00F73208 File Offset: 0x00F71408
		private unsafe void OnCombatResponse(CombatCommon combatCommon, CombatResponseData response)
		{
			Dictionary<int, Action<IMessage>> requestMap = Singleton<CombatNet>.Instance.RequestMap;
			int requestId = response.RequestId;
			Action<IMessage> action;
			if (!requestMap.TryGetValue(requestId, out action))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MultiplayerCombat;
				ELogAuthor author = ELogAuthor.ZQR;
				string message = "unexpected response RPC id from server";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("messageType", response.MessageCase);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			CombatExactResponseDataPack exactResponseDataPack = response.GetExactResponseDataPack();
			requestMap.Remove(requestId);
			if (exactResponseDataPack == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.MultiplayerCombat;
				ELogAuthor author2 = ELogAuthor.ZQR;
				string message2 = "unexpected null combat response";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("messageType", response.MessageCase);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			try
			{
				if (action != null)
				{
					action(exactResponseDataPack.Message);
				}
			}
			catch (Exception ex)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.CombatInfo;
				ELogAuthor author3 = ELogAuthor.WCL;
				string message3 = "战斗协议执行response异常";
				Exception error = ex;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("response", exactResponseDataPack.Message);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
				instance3.ErrorWithStack(module3, author3, message3, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x0603CDE3 RID: 249315 RVA: 0x00F73338 File Offset: 0x00F71538
		public void Process(ENotifyMessageId id, Entity entity, IMessage message, CombatCommon combatCommon)
		{
			IHandler handler;
			if (Singleton<CombatNet>.Instance.NotifyMap.TryGetValue(id, out handler))
			{
				StaticHandler staticHandler = handler as StaticHandler;
				if (staticHandler != null)
				{
					Action<Entity, IMessage, CombatCommon> listener = staticHandler.Listener;
					if (listener == null)
					{
						return;
					}
					listener(entity, message, combatCommon);
					return;
				}
			}
			Action<Entity, object> action;
			if (this.NotifyHandles.TryGetValue((int)id, out action))
			{
				action(entity, message);
			}
		}

		// Token: 0x0603CDE4 RID: 249316 RVA: 0x00F73390 File Offset: 0x00F71590
		public void RegisterAiHateEntity(EAddEntityType addType, EntityHandle handle, [Nullable(2)] AActor actor)
		{
			if (handle.EntityType != 2 && handle.EntityType != 7)
			{
				return;
			}
			if (!this.AiHateEntities.Add(handle))
			{
				Singleton<Log>.Instance.Warn(ELogModule.CombatInfo, ELogAuthor.WCL, "[CombatMessageController.RegisterAiHateEntity] 当前已经注册过Monster", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<ERemoveEntityType, EntityHandle>(this, handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.UnregisterMonster));
		}

		// Token: 0x0603CDE5 RID: 249317 RVA: 0x00F733FC File Offset: 0x00F715FC
		public void UnregisterMonster(ERemoveEntityType removeType, EntityHandle handle)
		{
			if (handle.EntityType != 2 && handle.EntityType != 7)
			{
				return;
			}
			if (!this.AiHateEntities.Remove(handle))
			{
				Singleton<Log>.Instance.Warn(ELogModule.CombatInfo, ELogAuthor.WCL, "[CombatMessageController.RegisterAiHateEntity] 当前Monster未被注册", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<EventSystem>.Instance.RemoveWithTargetUseKey<ERemoveEntityType, EntityHandle>(this, handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.UnregisterMonster));
		}

		// Token: 0x0603CDE6 RID: 249318 RVA: 0x00F73468 File Offset: 0x00F71668
		public void RegisterPreTick(EntityComponent comp, Action<float> func)
		{
			if (!this.PreTickFunctions.TryAdd(comp, func))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CombatInfo;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "[CombatMessageController.RegisterPreTick] 当前Comp已经注册过PreTick";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Comp", comp.ToString());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0603CDE7 RID: 249319 RVA: 0x00F734B4 File Offset: 0x00F716B4
		public void UnregisterPreTick(EntityComponent comp)
		{
			if (!this.PreTickFunctions.Remove(comp))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CombatInfo;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "[CombatMessageController.RegisterPreTick] 当前Comp未注册过PreTick";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Comp", comp.ToString());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0603CDE8 RID: 249320 RVA: 0x00F73500 File Offset: 0x00F71700
		public void RegisterAfterTick(EntityComponent comp, Action<float> func)
		{
			if (!this.AfterTickFunctions.TryAdd(comp, func))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CombatInfo;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "[CombatMessageController.RegisterAfterTick] 当前Comp已经注册过AfterTick";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Comp", comp.ToString());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0603CDE9 RID: 249321 RVA: 0x00F7354C File Offset: 0x00F7174C
		public void UnregisterAfterTick(EntityComponent comp)
		{
			if (!this.AfterTickFunctions.Remove(comp))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CombatInfo;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "[CombatMessageController.UnregisterAfterTick] 当前Comp未注册过AfterTick";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Comp", comp.ToString());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0603CDEA RID: 249322 RVA: 0x00F73598 File Offset: 0x00F71798
		public unsafe void TickPriority1(float delta)
		{
			if (!Singleton<Net>.Instance.IsServerConnected() || !ModelBase<GameModeModel>.Instance.MapDone)
			{
				return;
			}
			float delta2 = delta * 0.001f;
			foreach (CombatMessageBuffer combatMessageBuffer in this.Model.CombatMessageBufferMap.Values)
			{
				combatMessageBuffer.OnTick(delta2);
			}
			foreach (KeyValuePair<EntityComponent, Action<float>> keyValuePair in this.PreTickFunctions)
			{
				EntityComponent key = keyValuePair.Key;
				Action<float> value = keyValuePair.Value;
				try
				{
					Entity entity = key.Entity;
					if (entity != null && entity.Valid)
					{
						value(delta);
					}
				}
				catch (Exception ex)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.CombatInfo;
					ELogAuthor author = ELogAuthor.WCL;
					string message = "处理方法执行异常";
					Exception error = ex;
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("comp", key);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
					instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}

		// Token: 0x0603CDEB RID: 249323 RVA: 0x00F736FC File Offset: 0x00F718FC
		protected unsafe override void OnAfterTick(float delta)
		{
			if (!Singleton<Net>.Instance.IsServerConnected() || !ModelBase<GameModeModel>.Instance.MapDone)
			{
				return;
			}
			foreach (KeyValuePair<EntityComponent, Action<float>> keyValuePair in this.AfterTickFunctions)
			{
				EntityComponent key = keyValuePair.Key;
				Action<float> value = keyValuePair.Value;
				try
				{
					Entity entity = key.Entity;
					if (entity != null && entity.Valid)
					{
						if (!key.Entity.Active && !this.LastEntityActive.Contains(key.Entity))
						{
							this.LastEntityActive.Remove(key.Entity);
						}
						else
						{
							value(delta);
							if (key.Entity.Active)
							{
								this.LastEntityActive.Add(key.Entity);
							}
							else
							{
								this.LastEntityActive.Remove(key.Entity);
							}
						}
					}
				}
				catch (Exception ex)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.CombatInfo;
					ELogAuthor author = ELogAuthor.WCL;
					string message = "处理方法执行异常";
					Exception error = ex;
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("comp", key.ToString());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
					instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
			if (Singleton<Time>.Instance.NowSeconds > this.LastPushAiInformationTime + 1.0 || this.Model.AnyHateChange)
			{
				bool flag = false;
				foreach (EntityHandle entityHandle in this.AiHateEntities.ToList<EntityHandle>())
				{
					if (entityHandle.IsInit)
					{
						if (!flag)
						{
							WorldEntity entity2 = entityHandle.Entity;
							CharacterUnifiedStateComponent characterUnifiedStateComponent = (entity2 != null) ? entity2.GetComponent<CharacterUnifiedStateComponent>() : null;
							flag = (characterUnifiedStateComponent != null && characterUnifiedStateComponent.IsInFightState());
						}
						AiHatePush aiHatePush = new AiHatePush();
						bool flag2 = ModelBase<GameModeModel>.Instance.IsMulti || this.Model.AnyHateChange;
						if (flag2)
						{
							WorldEntity entity3 = entityHandle.Entity;
							CharacterAiComponent characterAiComponent = (entity3 != null) ? entity3.GetComponent<CharacterAiComponent>() : null;
							if (characterAiComponent != null)
							{
								foreach (KeyValuePair<int, HatredItem> keyValuePair2 in characterAiComponent.AiController.AiHateList.GetHatredMap())
								{
									AiHateEntity aiHateEntity = new AiHateEntity();
									aiHateEntity.EntityId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(keyValuePair2.Key);
									aiHateEntity.HatredValue = (int)keyValuePair2.Value.HatredValue;
									aiHatePush.HateList.Add(aiHateEntity);
								}
							}
						}
						if (aiHatePush.HateList.Count > 100)
						{
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.MultiplayerCombat;
							ELogAuthor author2 = ELogAuthor.ZQR;
							string message2 = "仇恨数据过大";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureData", entityHandle.CreatureDataId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("HateList", aiHatePush.HateList.Count);
							instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
						}
						if (flag2)
						{
							Singleton<CombatNet>.Instance.Send(EPushMessageId.AiHatePush, entityHandle.Entity, aiHatePush, null, null, null);
						}
					}
				}
				this.LastPushAiInformationTime = Singleton<Time>.Instance.NowSeconds;
			}
			this.Model.AnyHateChange = false;
			if (ModelBase<GameModeModel>.Instance.IsMulti && ControllerBase<BlackboardController>.Instance.PendingBlackboardParams.Count > 0)
			{
				foreach (EntityHandle entityHandle2 in this.AiHateEntities.ToList<EntityHandle>())
				{
					if (entityHandle2.IsInit)
					{
						AiBlackboardsPush aiBlackboardsPush = new AiBlackboardsPush();
						Dictionary<string, BlackboardParam> dictionary;
						if (ControllerBase<BlackboardController>.Instance.PendingBlackboardParams.TryGetValue(entityHandle2.CreatureDataId, out dictionary))
						{
							aiBlackboardsPush.AiBlackboards.AddRange(dictionary.Values);
							Singleton<CombatNet>.Instance.Send(EPushMessageId.AiBlackboardsPush, entityHandle2.Entity, aiBlackboardsPush, null, null, null);
						}
						if (aiBlackboardsPush.AiBlackboards.Count > 100)
						{
							Log instance3 = Singleton<Log>.Instance;
							ELogModule module3 = ELogModule.MultiplayerCombat;
							ELogAuthor author3 = ELogAuthor.ZQR;
							string message3 = "黑板数据过大";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("CreatureData", entityHandle2.CreatureDataId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("AiBlackboards", aiBlackboardsPush.AiBlackboards.Count);
							instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
						}
					}
				}
				ControllerBase<BlackboardController>.Instance.PendingBlackboardParams.Clear();
			}
			if ((!ModelBase<CombatMessageModel>.Instance.MoveSyncUdpMode || !ModelBase<GameModeModel>.Instance.IsMulti) && ModelBase<CombatMessageModel>.Instance.NeedPushMove)
			{
				MovePackagePush movePackagePush = new MovePackagePush();
				movePackagePush.SceneOwnerId = (ModelBase<GameModeModel>.Instance.IsMulti ? ModelBase<OnlineModel>.Instance.OwnerId : ModelBase<CreatureModel>.Instance.GetPlayerId());
				foreach (IMoveSync moveSync in ModelBase<CombatMessageModel>.Instance.MoveSyncSet)
				{
					MovingEntityData movingEntityData = moveSync.CollectPendingMoveInfos();
					if (movingEntityData != null)
					{
						movePackagePush.MovingEntities.Add(movingEntityData);
					}
				}
				if (movePackagePush.MovingEntities.Count > 0)
				{
					Singleton<Net>.Instance.Send(EPushMessageId.MovePackagePush, movePackagePush);
				}
				if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
				{
					string data = Json.Encode(new Dictionary<string, object>
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
							"msg_id",
							17573
						},
						{
							"sub_count",
							movePackagePush.MovingEntities.Count
						},
						{
							"is_multi",
							ModelBase<GameModeModel>.Instance.IsMulti
						},
						{
							"ed",
							this.IS_WITH_EDITOR
						},
						{
							"br",
							Singleton<LogAnalyzer>.Instance.GetBranch()
						}
					}, null);
					ControllerBase<CombatDebugController>.Instance.DataReport("COMBAT_MESSAGE_COUNT", data);
				}
				ModelBase<CombatMessageModel>.Instance.NeedPushMove = false;
			}
			this.FlushMessagePack();
			if (ModelBase<CombatMessageModel>.Instance.SkillDirtySet.Count > 0)
			{
				foreach (long num in ModelBase<CombatMessageModel>.Instance.SkillDirtySet.ToList<long>())
				{
					int num2 = (int)num;
					CombatMessageModel instance4 = ModelBase<CombatMessageModel>.Instance;
					if (instance4 != null)
					{
						instance4.TryClearSkillCount((long)num2);
					}
				}
				ModelBase<CombatMessageModel>.Instance.SkillDirtySet.Clear();
			}
		}

		// Token: 0x0603CDEC RID: 249324 RVA: 0x00F73EC8 File Offset: 0x00F720C8
		public void FlushMessagePack()
		{
			List<string> list = new List<string>();
			CombatSendPackRequest messagePack = this.Model.MessagePack;
			messagePack.HostPlayerId = ModelBase<CreatureModel>.Instance.GetWorldOwner();
			if (messagePack.Data.Count > 0 && Singleton<Time>.Instance.SystemNowSeconds >= ModelBase<CombatMessageModel>.Instance.CombatMessageSendLastTime + (double)ModelBase<CombatMessageModel>.Instance.CombatMessageSendInterval)
			{
				foreach (CombatSendData combatSendData in messagePack.Data)
				{
					CombatRequestData request = combatSendData.Request;
					if (request != null)
					{
						string text = request.MessageCase.ToString();
						ECombatRequestDataMessage messageName;
						Enum.TryParse<ECombatRequestDataMessage>(text, true, out messageName);
						ControllerBase<CombatDebugController>.Instance.CombatContextInfoMessage(CombatLog.EDebugModule.Request, (EMessageId)messageName, request);
						list.Add(text);
					}
				}
				Singleton<Net>.Instance.Call<CombatSendPackResponse>(ERequestMessageId.CombatSendPackRequest, messagePack, delegate(CombatSendPackResponse response, Net.CallbackStatus _)
				{
					if (response.ReceivePackNotify != null)
					{
						this.OnPackNotify(response.ReceivePackNotify, _);
					}
				}, 0);
				if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
				{
					string data = Json.Encode(new Dictionary<string, object>
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
							"msg_id",
							21430
						},
						{
							"sub_count",
							messagePack.Data.Count
						},
						{
							"is_multi",
							ModelBase<GameModeModel>.Instance.IsMulti
						},
						{
							"sub_msg",
							list
						},
						{
							"frame",
							Singleton<Time>.Instance.Frame
						},
						{
							"ed",
							this.IS_WITH_EDITOR
						},
						{
							"br",
							Singleton<LogAnalyzer>.Instance.GetBranch()
						}
					}, null);
					ControllerBase<CombatDebugController>.Instance.DataReport("COMBAT_MESSAGE_COUNT", data);
				}
				this.Model.MessagePack = new CombatSendPackRequest();
				ModelBase<CombatMessageModel>.Instance.CombatMessageSendLastTime = Singleton<Time>.Instance.SystemNowSeconds;
			}
		}

		// Token: 0x0603CDED RID: 249325 RVA: 0x00F740E0 File Offset: 0x00F722E0
		[NullableContext(2)]
		private void ResetLocationForZRangeNotify(ResetLocationForZRangeNotify data, Net.CallbackStatus status)
		{
			long entityId = data.EntityId;
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			if (entity == null || !entity.Valid)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[ResetLocationForZRangeNotify] 找不到对应的Entity";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", entityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.ResetLocationForZRangeInternal(entity, data);
		}

		// Token: 0x0603CDEE RID: 249326 RVA: 0x00F74148 File Offset: 0x00F72348
		private unsafe void ResetLocationForZRangeInternal(EntityHandle handle, ResetLocationForZRangeNotify data)
		{
			global::Vector vector = global::Vector.Create(data.ResetLocation);
			WorldEntity entity = handle.Entity;
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			WorldEntity entity2 = handle.Entity;
			BaseActorComponent baseActorComponent = (entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null;
			if (handle.IsInit)
			{
				CharacterActorComponent characterActorComponent = baseActorComponent as CharacterActorComponent;
				if (characterActorComponent != null)
				{
					if (!characterActorComponent.FixBornLocation("ResetLocationForZRangeNotify", true, vector, false, true, true) && baseActorComponent != null)
					{
						baseActorComponent.SetActorLocation(vector.ToUeVector(false), "ResetLocationForZRangeNotify", false);
					}
				}
				else
				{
					VehicleActorComponent vehicleActorComponent = baseActorComponent as VehicleActorComponent;
					if (vehicleActorComponent != null)
					{
						vehicleActorComponent.FixBornLocation(vector, "ResetLocationForZRangeNotify");
					}
					else if (baseActorComponent != null)
					{
						baseActorComponent.SetActorLocation(vector.ToUeVector(false), "ResetLocationForZRangeNotify", false);
					}
				}
				if (data.NotifyRot)
				{
					FRotator frotator = WorldGlobal.ToUeRotator(data.Rotation);
					if (baseActorComponent != null)
					{
						baseActorComponent.SetActorRotation(frotator, "ResetLocationForZRangeNotify", true);
					}
					WorldEntity entity3 = handle.Entity;
					if (((entity3 != null) ? entity3.GetComponent<NpcMoveComponent>() : null) != null)
					{
						CharacterActorComponent characterActorComponent2 = baseActorComponent as CharacterActorComponent;
						if (characterActorComponent2 != null)
						{
							characterActorComponent2.SetInputRotator(frotator);
						}
					}
				}
				WorldEntity entity4 = handle.Entity;
				object obj = (entity4 != null) ? entity4.GetComponent<CharacterMoveComponent>() : null;
				WorldEntity entity5 = handle.Entity;
				VehicleMoveComponent vehicleMoveComponent = (entity5 != null) ? entity5.GetComponent<VehicleMoveComponent>() : null;
				object obj2 = obj;
				if (obj2 != null)
				{
					obj2.SetForceSpeed(global::Vector.ZeroVectorProxy);
				}
				if (vehicleMoveComponent != null)
				{
					vehicleMoveComponent.SetForceSpeed(global::Vector.ZeroVectorProxy);
				}
				WorldEntity entity6 = handle.Entity;
				BaseMovementSyncComponent baseMovementSyncComponent = (entity6 != null) ? entity6.GetComponent<BaseMovementSyncComponent>() : null;
				if (baseMovementSyncComponent != null)
				{
					baseMovementSyncComponent.ClearReplaySamples();
				}
				WorldEntity entity7 = handle.Entity;
				SceneItemManipulatableComponent sceneItemManipulatableComponent = (entity7 != null) ? entity7.GetComponent<SceneItemManipulatableComponent>() : null;
				if (sceneItemManipulatableComponent != null)
				{
					sceneItemManipulatableComponent.ResetManipulatableState();
				}
			}
			else
			{
				if (creatureDataComponent != null)
				{
					creatureDataComponent.SetLocation(vector.ToProtocolVector());
				}
				if (data.NotifyRot && creatureDataComponent != null)
				{
					creatureDataComponent.SetRotation(data.Rotation);
				}
			}
			if (data.ChangeInitPos)
			{
				if (creatureDataComponent != null)
				{
					creatureDataComponent.SetInitLocation(vector.ToProtocolVector());
				}
				WorldEntity entity8 = handle.Entity;
				CharacterActorComponent characterActorComponent3 = (entity8 != null) ? entity8.GetComponent<CharacterActorComponent>() : null;
				if (characterActorComponent3 != null)
				{
					characterActorComponent3.SetInitLocation(vector.ToProtocolVector());
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.WCL;
			string message = "ResetLocationForZRangeNotify 重置实体位置";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", handle.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", handle.PbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", handle.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ChangeInitPos", data.ChangeInitPos);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("IsInit", handle.IsInit);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Location", vector.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("FinalLocation", (baseActorComponent != null) ? baseActorComponent.ActorLocationProxy : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
		}

		// Token: 0x0603CDEF RID: 249327 RVA: 0x00F7444C File Offset: 0x00F7264C
		private void MoveInfoHandle(MovingEntityData data)
		{
			long entityId = data.EntityId;
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			long originator = data.Originator;
			bool isDebugMessageLog = this.IsDebugMessageLog;
			if (entity == null)
			{
				return;
			}
			if (data.MoveInfos == null || data.MoveInfos.Count <= 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MultiplayerCombat;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "[CombatMessageController.MoveInfosHandle], MoveInfos 是空的";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Originator", originator);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			float timeStamp = data.MoveInfos[0].TimeStamp;
			if (!entity.Entity.Active)
			{
				if (!entity.IsInit)
				{
					return;
				}
				BaseMovementSyncComponent component = entity.Entity.GetComponent<BaseMovementSyncComponent>();
				CharacterDriveVehicleComponent component2 = entity.Entity.GetComponent<CharacterDriveVehicleComponent>();
				if (component2 != null && component2.Seat >= 0)
				{
					if (component != null)
					{
						component.ClearReplaySamples();
					}
					return;
				}
				RepeatedField<MoveReplaySample> moveInfos = data.MoveInfos;
				MoveReplaySample moveReplaySample = moveInfos[moveInfos.Count - 1];
				this.CopyToUeVector(moveReplaySample.Location, ref this.LocationCatch);
				this.CopyToUeRotator(moveReplaySample.Rotation, ref this.RotationCatch);
				CharacterActorComponent component3 = entity.Entity.GetComponent<CharacterActorComponent>();
				if (component3 != null)
				{
					component3.SetActorLocationAndRotation(this.LocationCatch, this.RotationCatch, "MoveInfosHandle", false, null);
				}
				if (component != null)
				{
					component.ClearReplaySamples();
				}
				return;
			}
			else
			{
				CombatMessageBuffer messageBuffer = this.Model.GetMessageBuffer(originator);
				if (messageBuffer != null)
				{
					CreatureDataComponent component4 = entity.Entity.GetComponent<CreatureDataComponent>();
					this.Model.SetEntityMap(entity.Id, originator);
					messageBuffer.RecordMessageTime((double)timeStamp, component4.GetPbDataId(), true);
				}
				BaseMovementSyncComponent component5 = entity.Entity.GetComponent<BaseMovementSyncComponent>();
				if (component5 != null)
				{
					component5.ReceiveMoveInfos(data.MoveInfos, (int)originator, timeStamp);
					return;
				}
				CombatLog instance2 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Move;
				Entity entity2 = entity.Entity;
				string message2 = "entity不存在组件CharacterMovementSyncComponent";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("creatureDataId", entityId);
				instance2.Warn(flag, entity2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
		}

		// Token: 0x0603CDF0 RID: 249328 RVA: 0x00F74634 File Offset: 0x00F72834
		private void MotorAnimInfoHandle(MotorAnimEntity data)
		{
			long entityId = data.EntityId;
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			if (entity == null)
			{
				return;
			}
			if (data.MotorAnimInfos == null || data.MotorAnimInfos.Count <= 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MultiplayerCombat;
				ELogAuthor author = ELogAuthor.ZFJ;
				string message = "[CombatMessageController.MotorAnimInfoHandle], MotorAnimInfos 是空的";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("creatureDataId", entityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			WorldEntity entity2 = entity.Entity;
			MotorAnimationSyncComponent motorAnimationSyncComponent = (entity2 != null) ? entity2.GetComponent<MotorAnimationSyncComponent>() : null;
			if (motorAnimationSyncComponent != null)
			{
				motorAnimationSyncComponent.ReceiveMotorAnimSample(data.MotorAnimInfos);
			}
		}

		// Token: 0x0603CDF1 RID: 249329 RVA: 0x00F746C0 File Offset: 0x00F728C0
		[NullableContext(2)]
		private void MovePackageNotify(MovePackageNotify data, Net.CallbackStatus status)
		{
			foreach (MovingEntityData data2 in data.MovingEntities)
			{
				this.MoveInfoHandle(data2);
			}
		}

		// Token: 0x0603CDF2 RID: 249330 RVA: 0x00F74710 File Offset: 0x00F72910
		[NullableContext(2)]
		private void UDPMovePackageNotify(UDPMovePackageNotify data, Net.CallbackStatus status)
		{
			foreach (MovingEntityData data2 in data.MovingEntities)
			{
				this.MoveInfoHandle(data2);
			}
		}

		// Token: 0x0603CDF3 RID: 249331 RVA: 0x00F74760 File Offset: 0x00F72960
		[NullableContext(2)]
		private void UDPMotorAnimNotify(MotorAnimReplaySampleUdpNotify data, Net.CallbackStatus status)
		{
			foreach (MotorAnimEntity data2 in data.MotorAnimEntities)
			{
				this.MotorAnimInfoHandle(data2);
			}
		}

		// Token: 0x0603CDF4 RID: 249332 RVA: 0x00F747B0 File Offset: 0x00F729B0
		[NullableContext(2)]
		private void SceneItemMoveTargetNotify(SceneItemMoveTargetNotify data, Net.CallbackStatus status)
		{
			long entityId = data.MoveInfo.EntityId;
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			if (entity == null)
			{
				return;
			}
			WorldEntity entity2 = entity.Entity;
			SceneItemMoveComponent sceneItemMoveComponent = (entity2 != null) ? entity2.GetComponent<SceneItemMoveComponent>() : null;
			if (sceneItemMoveComponent != null)
			{
				sceneItemMoveComponent.HandleMoveToTarget(data);
			}
		}

		// Token: 0x0603CDF5 RID: 249333 RVA: 0x00F747F8 File Offset: 0x00F729F8
		[CombatListen(ENotifyMessageId.EntityIsVisibleNotify, true, true)]
		public static void EntityIsVisibleNotify(Entity entity, EntityIsVisibleNotify data, [Nullable(2)] CombatCommon combatCommon = null)
		{
			if (entity.IsInit)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Actor;
				string message = "Entity通知设置显隐";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("v", data.IsVisible);
				instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ControllerBase<CreatureController>.Instance.SetEntityEnable(entity, data.IsVisible, "CombatMessageController.EntityIsVisibleNotify", false);
				return;
			}
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				return;
			}
			component.SetVisible(data.IsVisible);
		}

		// Token: 0x0603CDF6 RID: 249334 RVA: 0x00F7486C File Offset: 0x00F72A6C
		[CombatListen(ENotifyMessageId.ActorVisibleNotify, true, true)]
		public static void ActorIsVisibleNotify(Entity entity, ActorVisibleNotify data, [Nullable(2)] CombatCommon combatCommon = null)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component != null)
			{
				component.ActorVisible = data.IsActorVisible;
			}
			if (!entity.IsInit)
			{
				return;
			}
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Actor;
			string message = "Actor通知设置显隐";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("v", data.IsActorVisible);
			instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<CreatureController>.Instance.SetActorVisible(entity, data.IsActorVisible, data.IsActorVisible, data.IsActorVisible, "ActorIsVisibleNotify", false);
		}

		// Token: 0x0603CDF7 RID: 249335 RVA: 0x00F748EC File Offset: 0x00F72AEC
		private void OnSyncAiInformation(AiControlSwitch switchInfo)
		{
			long entityId = switchInfo.EntityId;
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			if (entity == null)
			{
				Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Ai, entityId, "OnSyncAiInformation 不存在实体", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			WorldEntity entity2 = entity.Entity;
			CharacterAiComponent characterAiComponent = (entity2 != null) ? entity2.GetComponent<CharacterAiComponent>() : null;
			if (characterAiComponent == null)
			{
				Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Ai, entityId, "OnSyncAiInformation 不存在CharacterAiComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			characterAiComponent.OnSyncAiInformation(switchInfo);
		}

		// Token: 0x0603CDF8 RID: 249336 RVA: 0x00F74964 File Offset: 0x00F72B64
		[NullableContext(2)]
		private void AiControlSwitchNotify(AiControlSwitchNotify data, Net.CallbackStatus status)
		{
			foreach (AiControlSwitch switchInfo in data.AiControlSwitchInfos)
			{
				this.OnSyncAiInformation(switchInfo);
			}
		}

		// Token: 0x0603CDF9 RID: 249337 RVA: 0x00F749B4 File Offset: 0x00F72BB4
		[NullableContext(2)]
		protected void PreAiControlSwitchNotify(PreAiControlSwitchNotify data, Net.CallbackStatus status)
		{
			foreach (long num in data.EntityIds)
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num);
				if (entity == null)
				{
					CombatLog instance = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag = CombatLog.EDebugModule.Ai;
					long entityId = num;
					string message = "PreAiControlSwitchNotify 不存在实体";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", num);
					instance.Warn(flag, entityId, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					WorldEntity entity2 = entity.Entity;
					CharacterAiComponent characterAiComponent = (entity2 != null) ? entity2.GetComponent<CharacterAiComponent>() : null;
					if (characterAiComponent != null)
					{
						characterAiComponent.AiController.PreSwitchControl();
					}
				}
			}
		}

		// Token: 0x0603CDFA RID: 249338 RVA: 0x00F74A58 File Offset: 0x00F72C58
		[CombatListen(ENotifyMessageId.EntityLoadCompleteNotify, false, false)]
		public static void EntityLoadCompleteNotify(Entity entity, EntityLoadCompleteNotify data, [Nullable(2)] CombatCommon combatCommon = null)
		{
			int playerId = data.PlayerId;
			foreach (long creatureDataId in data.EntityIds)
			{
				EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
				if (entity2 != null)
				{
					WorldEntity entity3 = entity2.Entity;
					CharacterAiComponent characterAiComponent = (entity3 != null) ? entity3.GetComponent<CharacterAiComponent>() : null;
					if (characterAiComponent != null)
					{
						characterAiComponent.SetLoadCompletePlayer(playerId);
					}
				}
			}
		}

		// Token: 0x0603CDFB RID: 249339 RVA: 0x00F74AD4 File Offset: 0x00F72CD4
		[CombatListen(ENotifyMessageId.PlayerRebackSceneNotify, false, false)]
		public static void PlayerRebackSceneNotify(Entity entity, PlayerRebackSceneNotify data, [Nullable(2)] CombatCommon combatCommon = null)
		{
			long curControlEntityId = data.CurControlEntityId;
			EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(curControlEntityId);
			if (entity2 == null)
			{
				return;
			}
			entity2.Entity.GetComponent<CharacterMovementSyncComponent>().ClearReplaySamples();
		}

		// Token: 0x0603CDFC RID: 249340 RVA: 0x00F74B08 File Offset: 0x00F72D08
		[CombatListen(ENotifyMessageId.MaterialNotify, true, true)]
		public static void MaterialNotify(Entity entity, MaterialNotify data, [Nullable(2)] CombatCommon combatCommon = null)
		{
			if (string.IsNullOrEmpty(data.MaterialInfo.AssetName) || data.MaterialInfo.AssetName == "None")
			{
				Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Material, entity, "材质同步失败，参数非法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			BaseCharacterComponent baseChar = (entity != null) ? entity.GetComponent<BaseCharacterComponent>() : null;
			BaseCharacterComponent baseChar2 = baseChar;
			if (((baseChar2 != null) ? baseChar2.Actor : null) == null)
			{
				Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Material, entity, "材质同步失败，Actor为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (data.MaterialInfo.IsGroup)
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerDataGroup_C>(data.MaterialInfo.AssetName, delegate([Nullable(2)] PD_CharacterControllerDataGroup_C asset, string assetPath)
				{
					if (asset == null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Battle;
						ELogAuthor author = ELogAuthor.YZ;
						string message = "无法找到材质效果";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data.MaterialInfo.AssetName", data.MaterialInfo.AssetName);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return;
					}
					baseChar.Actor.CharRenderingComponent.AddMaterialControllerDataGroup(asset);
				}, 100, "js_undefined");
				return;
			}
			Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(data.MaterialInfo.AssetName, delegate([Nullable(2)] PD_CharacterControllerData_C asset, string assetPath)
			{
				if (asset == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.YZ;
					string message = "无法找到材质效果组";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data.MaterialInfo.AssetName", data.MaterialInfo.AssetName);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				baseChar.Actor.CharRenderingComponent.AddMaterialControllerData(asset);
			}, 100, "js_undefined");
		}

		// Token: 0x0603CDFD RID: 249341 RVA: 0x00F74C24 File Offset: 0x00F72E24
		[NullableContext(2)]
		private void SplineMoveNotify(SplineMoveNotify data, Net.CallbackStatus status)
		{
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(data.EntityId);
			if (entity == null || !entity.IsInit)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Notify;
				Entity entity2 = null;
				string message = "SplineMoveNotify实体不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", data.EntityId);
				instance.Warn(flag, entity2, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			WorldEntity entity3 = entity.Entity;
			VehicleMovementSyncComponent vehicleMovementSyncComponent = (entity3 != null) ? entity3.GetComponent<VehicleMovementSyncComponent>() : null;
			if (vehicleMovementSyncComponent != null)
			{
				vehicleMovementSyncComponent.HandleSplineMoveNotify(data.PathId, data.PathRatio);
			}
		}

		// Token: 0x0603CDFE RID: 249342 RVA: 0x00F74CAB File Offset: 0x00F72EAB
		private void CopyToUeVector(Aki.Protocol.Vector inV, ref FVectorDouble outV)
		{
			outV.X = (double)inV.X;
			outV.Y = (double)inV.Y;
			outV.Z = (double)inV.Z;
		}

		// Token: 0x0603CDFF RID: 249343 RVA: 0x00F74CD4 File Offset: 0x00F72ED4
		private void CopyToUeRotator(Aki.Protocol.Rotator inV, ref FRotator outV)
		{
			outV.Pitch = inV.Pitch;
			outV.Roll = inV.Roll;
			outV.Yaw = inV.Yaw;
		}

		// Token: 0x040222AE RID: 139950
		public bool IsDebugMessageLog;

		// Token: 0x040222AF RID: 139951
		public bool IsDebugMoveMessage;

		// Token: 0x040222B0 RID: 139952
		public float StartTime;

		// Token: 0x040222B1 RID: 139953
		public int MoveData;

		// Token: 0x040222B2 RID: 139954
		public int MoveDataCount;

		// Token: 0x040222B3 RID: 139955
		public int StateData;

		// Token: 0x040222B4 RID: 139956
		public int StateDataCount;

		// Token: 0x040222B5 RID: 139957
		private readonly Dictionary<int, Action<Entity, object>> NotifyHandles = new Dictionary<int, Action<Entity, object>>();

		// Token: 0x040222B6 RID: 139958
		private readonly Dictionary<EntityComponent, Action<float>> PreTickFunctions = new Dictionary<EntityComponent, Action<float>>();

		// Token: 0x040222B7 RID: 139959
		private readonly Dictionary<EntityComponent, Action<float>> AfterTickFunctions = new Dictionary<EntityComponent, Action<float>>();

		// Token: 0x040222B8 RID: 139960
		private readonly HashSet<EntityHandle> AiHateEntities = new HashSet<EntityHandle>();

		// Token: 0x040222B9 RID: 139961
		private readonly HashSet<Entity> LastEntityActive = new HashSet<Entity>();

		// Token: 0x040222BA RID: 139962
		private readonly Dictionary<string, Stat> CombatStatMap = new Dictionary<string, Stat>();

		// Token: 0x040222BB RID: 139963
		private FVectorDouble LocationCatch = new FVectorDouble();

		// Token: 0x040222BC RID: 139964
		private FRotator RotationCatch = new FRotator();

		// Token: 0x040222BD RID: 139965
		private double LastPushAiInformationTime;

		// Token: 0x040222BE RID: 139966
		private const float SendAiInformationInterval = 1f;

		// Token: 0x040222BF RID: 139967
		private const int MAX_AI_INFO_COUNT = 100;

		// Token: 0x040222C0 RID: 139968
		private readonly int? IS_WITH_EDITOR = KuroApplication.IsWithEditor() ? new int?(1) : null;

		// Token: 0x040222C1 RID: 139969
		private readonly Stat CombatReceivePackNotifyStat = Stat.Create("CombatPackNotify.CombatReceivePackNotifyStat", "", "STATGROUP_KuroBattle");

		// Token: 0x040222C2 RID: 139970
		private readonly Stat CombatMessageBufferStat = Stat.Create("CombatMessageBuffer", "", "");

		// Token: 0x040222C3 RID: 139971
		private readonly Stat CombatMessageHatredStat = Stat.Create("CombatMessageHatred", "", "");
	}
}
