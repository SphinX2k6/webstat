using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MechanismTimeline;
using CSharpScript.Game.Module.MechanismTimeline.MechanismEvent;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047F4 RID: 18420
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemEventListenerComponent : EntityComponent
	{
		// Token: 0x0602FCEB RID: 195819 RVA: 0x00B7B674 File Offset: 0x00B79874
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			CreateEntityData p = args.GetP1<CreateEntityData>();
			SceneItemEventListenerComponent sceneItemEventListenerComponent = p.GetParam<SceneItemEventListenerComponent>() as SceneItemEventListenerComponent;
			this.PbDataId = p.PbDataId;
			if (((sceneItemEventListenerComponent != null) ? sceneItemEventListenerComponent.Events : null) != null)
			{
				foreach (ISceneItemEventConfig sceneItemEventConfig in sceneItemEventListenerComponent.Events)
				{
					if (sceneItemEventConfig.SequenceEvents != null)
					{
						foreach (ISceneItemSequenceEventData sceneItemSequenceEventData in sceneItemEventConfig.SequenceEvents)
						{
							List<ISceneItemSeqEventCbType> list = new List<ISceneItemSeqEventCbType>();
							Dictionary<string, IMechanismEventInfo> dictionary = new Dictionary<string, IMechanismEventInfo>();
							foreach (ISceneItemSeqEventCbType sceneItemSeqEventCbType in sceneItemSequenceEventData.EventCallbacks)
							{
								MechanismEventInfo value = new MechanismEventInfo
								{
									Info = sceneItemSeqEventCbType,
									SeqGuid = sceneItemSequenceEventData.SeqGuid
								};
								dictionary[sceneItemSeqEventCbType.EventName] = value;
								if (sceneItemSeqEventCbType.Type == ESceneItemSeqEventCbType.AN)
								{
									list.Add(sceneItemSeqEventCbType);
								}
							}
							this.EventConfigMap[sceneItemSequenceEventData.SeqPath] = dictionary;
							this.SeqEventsConfig[sceneItemSequenceEventData.SeqGuid] = list;
						}
					}
				}
			}
			this.TagComponent = base.Entity.GetComponent<LevelTagComponent>();
			this.ActorComponent = base.Entity.GetComponent<BaseActorComponent>();
			this.CreatureDataComponent = base.Entity.GetComponent<CreatureDataComponent>();
			CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
			SceneItemEventListenerComponentPb sceneItemEventListenerComponentPb;
			if (creatureDataComponent == null)
			{
				sceneItemEventListenerComponentPb = null;
			}
			else
			{
				Dictionary<string, EntityComponentPb> componentDataMap = creatureDataComponent.ComponentDataMap;
				if (componentDataMap == null)
				{
					sceneItemEventListenerComponentPb = null;
				}
				else
				{
					EntityComponentPb valueOrDefault = componentDataMap.GetValueOrDefault("ListenerComponentPb");
					sceneItemEventListenerComponentPb = ((valueOrDefault != null) ? valueOrDefault.ListenerComponentPb : null);
				}
			}
			SceneItemEventListenerComponentPb sceneItemEventListenerComponentPb2 = sceneItemEventListenerComponentPb;
			if (sceneItemEventListenerComponentPb2 != null)
			{
				this.ContextId = sceneItemEventListenerComponentPb2.ContextId;
			}
			return true;
		}

		// Token: 0x0602FCEC RID: 195820 RVA: 0x00B7B894 File Offset: 0x00B79A94
		protected override bool OnStart()
		{
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneInteractionSequencePlay, new Action<int, UMovieSceneSequencePlayer>(this.OnSequencePlay));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneInteractionSequenceOver, new Action<int, UMovieSceneSequencePlayer>(this.OnSequenceOver));
			return true;
		}

		// Token: 0x0602FCED RID: 195821 RVA: 0x00B7B8E8 File Offset: 0x00B79AE8
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneInteractionSequencePlay, new Action<int, UMovieSceneSequencePlayer>(this.OnSequencePlay));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneInteractionSequenceOver, new Action<int, UMovieSceneSequencePlayer>(this.OnSequenceOver));
			foreach (Dictionary<string, MechanismEventBase> dictionary in this.EventStateMap.Values)
			{
				foreach (MechanismEventBase mechanismEventBase in dictionary.Values)
				{
					mechanismEventBase.End();
					mechanismEventBase.Dispose();
				}
			}
			this.EventConfigMap.Clear();
			this.EventStateMap.Clear();
			this.ExecutedEventMap.Clear();
			this.SeqPlayerToGuid.Clear();
			this.SeqEventsConfig.Clear();
			this.TagComponent = null;
			this.ActorComponent = null;
			return true;
		}

		// Token: 0x0602FCEE RID: 195822 RVA: 0x00B7BA08 File Offset: 0x00B79C08
		private void OnSequencePlay(int handleId, UMovieSceneSequencePlayer seqPlayer)
		{
			WeakReference<UMovieSceneSequencePlayer> orAddWeakSequencePlayer = this.GetOrAddWeakSequencePlayer(seqPlayer);
			List<string> list;
			if (!this.ExecutedEventMap.TryGetValue(orAddWeakSequencePlayer, out list))
			{
				list = new List<string>();
				this.ExecutedEventMap[orAddWeakSequencePlayer] = list;
				return;
			}
			list.Clear();
		}

		// Token: 0x0602FCEF RID: 195823 RVA: 0x00B7BA48 File Offset: 0x00B79C48
		private void OnSequenceOver(int handleId, UMovieSceneSequencePlayer seqPlayer)
		{
			WeakReference<UMovieSceneSequencePlayer> orAddWeakSequencePlayer = this.GetOrAddWeakSequencePlayer(seqPlayer);
			this.ClearEventStateObjOnSeqOver(orAddWeakSequencePlayer);
			this.ExecuteMissingEventOnSeqOver(orAddWeakSequencePlayer, handleId);
		}

		// Token: 0x0602FCF0 RID: 195824 RVA: 0x00B7BA6C File Offset: 0x00B79C6C
		private void ClearEventStateObjOnSeqOver(WeakReference<UMovieSceneSequencePlayer> sequencePlayerWeakRef)
		{
			Dictionary<string, MechanismEventBase> dictionary;
			if (!this.EventStateMap.TryGetValue(sequencePlayerWeakRef, out dictionary))
			{
				return;
			}
			foreach (MechanismEventBase mechanismEventBase in dictionary.Values)
			{
				mechanismEventBase.End();
				mechanismEventBase.Dispose();
			}
			dictionary.Clear();
			this.EventStateMap.Remove(sequencePlayerWeakRef);
		}

		// Token: 0x0602FCF1 RID: 195825 RVA: 0x00B7BAE8 File Offset: 0x00B79CE8
		private void ExecuteMissingEventOnSeqOver(WeakReference<UMovieSceneSequencePlayer> sequencePlayerWeakRef, int handleId)
		{
			List<string> list;
			if (!this.ExecutedEventMap.TryGetValue(sequencePlayerWeakRef, out list))
			{
				return;
			}
			string text;
			if (!this.SeqPlayerToGuid.TryGetValue(sequencePlayerWeakRef, out text))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "SceneItemEventListenerComponent.ExecuteMissingEventOnSeqOver:找不到Sequence的Guid";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", this.PbDataId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			List<ISceneItemSeqEventCbType> list2;
			if (!this.SeqEventsConfig.TryGetValue(text, out list2) || list2.Count == 0)
			{
				return;
			}
			foreach (ISceneItemSeqEventCbType sceneItemSeqEventCbType in list2)
			{
				if (!list.Contains(sceneItemSeqEventCbType.EventName))
				{
					MechanismEventInfo eventInfo = new MechanismEventInfo
					{
						Info = sceneItemSeqEventCbType,
						SeqGuid = text
					};
					MechanismEventLevelPrefabContext context = new MechanismEventLevelPrefabContext(this.PbDataId, handleId);
					MechanismEventBase eventObj = this.GetEventObj(sequencePlayerWeakRef, eventInfo, EMechanismEventExecuteType.Trigger, context);
					if (eventObj != null)
					{
						eventObj.Trigger();
						list.Add(sceneItemSeqEventCbType.EventName);
					}
				}
			}
		}

		// Token: 0x0602FCF2 RID: 195826 RVA: 0x00B7BBF8 File Offset: 0x00B79DF8
		public int GetPlayerId()
		{
			return this.CreatureDataComponent.GetPlayerId();
		}

		// Token: 0x0602FCF3 RID: 195827 RVA: 0x00B7BC05 File Offset: 0x00B79E05
		public long GetCreatureDataId()
		{
			return this.CreatureDataComponent.GetCreatureDataId();
		}

		// Token: 0x0602FCF4 RID: 195828 RVA: 0x00B7BC14 File Offset: 0x00B79E14
		public unsafe void ExecuteEvent(UMovieSceneSequencePlayer sequencePlayer, string eventType, string eventName, EMechanismEventExecuteType executeType, MechanismEventContext context)
		{
			string pathName = UKismetSystemLibrary.GetPathName(sequencePlayer.Sequence);
			if (StringUtils.IsBlank(pathName) || pathName == "None")
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "SceneItemEventListenerComponent.ExecuteEvent:找不到SequencePath";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("pbDataId", this.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("eventType", eventType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("eventName", eventName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			Dictionary<string, IMechanismEventInfo> dictionary;
			IMechanismEventInfo mechanismEventInfo;
			if (!this.EventConfigMap.TryGetValue(pathName, out dictionary) || !dictionary.TryGetValue(eventName, out mechanismEventInfo))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.YSQ;
				string message2 = "SceneItemEventListenerComponent.ExecuteEvent:找不到事件配置";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("pbDataId", this.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("sequencePath", pathName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("eventType", eventType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("eventName", eventName);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
				return;
			}
			ISceneItemSeqEventCbType info = mechanismEventInfo.Info;
			if (eventType != info.Action.Name.ToEnumString())
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.SceneItem;
				ELogAuthor author3 = ELogAuthor.YSQ;
				string message3 = "SceneItemEventListenerComponent.ExecuteEvent:事件类型不相同，配置有误";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("pbDataId", this.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("sequencePath", pathName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("eventType", eventType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("eventName", eventName);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
				return;
			}
			if (info.Type == ESceneItemSeqEventCbType.AN && executeType != EMechanismEventExecuteType.Trigger)
			{
				global::Log instance4 = Singleton<global::Log>.Instance;
				ELogModule module4 = ELogModule.SceneItem;
				ELogAuthor author4 = ELogAuthor.YSQ;
				string message4 = "SceneItemEventListenerComponent.ExecuteEvent:执行事件错误，事件配置中不为ANS";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("pbDataId", this.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("sequencePath", pathName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("eventType", eventType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("eventName", eventName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 4) = new ValueTuple<string, object>("executeType", executeType);
				instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 5));
				return;
			}
			if (info.Type == ESceneItemSeqEventCbType.ANS && executeType == EMechanismEventExecuteType.Trigger)
			{
				global::Log instance5 = Singleton<global::Log>.Instance;
				ELogModule module5 = ELogModule.SceneItem;
				ELogAuthor author5 = ELogAuthor.YSQ;
				string message5 = "SceneItemEventListenerComponent.ExecuteEvent:执行事件错误，事件配置中不为AN";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("pbDataId", this.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("sequencePath", pathName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 2) = new ValueTuple<string, object>("eventType", eventType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 3) = new ValueTuple<string, object>("eventName", eventName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 4) = new ValueTuple<string, object>("executeType", executeType);
				instance5.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 5));
				return;
			}
			WeakReference<UMovieSceneSequencePlayer> orAddWeakSequencePlayer = this.GetOrAddWeakSequencePlayer(sequencePlayer);
			this.SeqPlayerToGuid[orAddWeakSequencePlayer] = mechanismEventInfo.SeqGuid;
			MechanismEventBase eventObj = this.GetEventObj(orAddWeakSequencePlayer, mechanismEventInfo, executeType, context);
			if (eventObj == null)
			{
				return;
			}
			switch (executeType)
			{
			case EMechanismEventExecuteType.Trigger:
			{
				eventObj.Trigger();
				List<string> list;
				if (this.ExecutedEventMap.TryGetValue(orAddWeakSequencePlayer, out list))
				{
					list.Add(eventName);
					return;
				}
				break;
			}
			case EMechanismEventExecuteType.Start:
				eventObj.Start();
				return;
			case EMechanismEventExecuteType.Tick:
				eventObj.Tick();
				return;
			case EMechanismEventExecuteType.End:
				eventObj.End();
				this.DestroyEventObj(orAddWeakSequencePlayer, mechanismEventInfo, executeType);
				break;
			default:
				return;
			}
		}

		// Token: 0x0602FCF5 RID: 195829 RVA: 0x00B7C020 File Offset: 0x00B7A220
		private WeakReference<UMovieSceneSequencePlayer> GetOrAddWeakSequencePlayer(UMovieSceneSequencePlayer sequencePlayer)
		{
			WeakReference<UMovieSceneSequencePlayer> weakReference;
			if (!this.SeqPlayerToWeak.TryGetValue(sequencePlayer, out weakReference))
			{
				weakReference = new WeakReference<UMovieSceneSequencePlayer>(sequencePlayer);
				this.SeqPlayerToWeak.Set(sequencePlayer, weakReference);
			}
			return weakReference;
		}

		// Token: 0x0602FCF6 RID: 195830 RVA: 0x00B7C054 File Offset: 0x00B7A254
		[return: Nullable(2)]
		private unsafe MechanismEventBase GetEventObj(WeakReference<UMovieSceneSequencePlayer> sequencePlayer, IMechanismEventInfo eventInfo, EMechanismEventExecuteType executeType, MechanismEventContext context)
		{
			EAction name = eventInfo.Info.Action.Name;
			MechanismEventCenter.EventBaseConstructor eventClass = Singleton<MechanismEventCenter>.Instance.GetEventClass(name);
			if (eventClass == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "SceneItemEventListenerComponent.GetEventObj,机关时间轴事件未定义";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("sequence", eventInfo.SeqGuid);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("eventType", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("eventName", eventInfo.Info.EventName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				return null;
			}
			bool eventIsServerAction = Singleton<MechanismEventCenter>.Instance.GetEventIsServerAction(name);
			MechanismEventBase mechanismEventBase = null;
			switch (executeType)
			{
			case EMechanismEventExecuteType.Trigger:
				mechanismEventBase = eventClass(eventInfo, context, this, eventIsServerAction);
				break;
			case EMechanismEventExecuteType.Start:
			{
				Dictionary<string, MechanismEventBase> dictionary;
				if (!this.EventStateMap.TryGetValue(sequencePlayer, out dictionary))
				{
					dictionary = new Dictionary<string, MechanismEventBase>();
					this.EventStateMap[sequencePlayer] = dictionary;
				}
				mechanismEventBase = eventClass(eventInfo, context, this, eventIsServerAction);
				dictionary[eventInfo.Info.EventName] = mechanismEventBase;
				break;
			}
			case EMechanismEventExecuteType.Tick:
			case EMechanismEventExecuteType.End:
			{
				Dictionary<string, MechanismEventBase> dictionary2;
				if (!this.EventStateMap.TryGetValue(sequencePlayer, out dictionary2))
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.LevelEvent;
					ELogAuthor author2 = ELogAuthor.YSQ;
					string message2 = "SceneItemEventListenerComponent.GetEventObj,通过sequencePlayer获取EventStates失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", this.PbDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("sequence", eventInfo.SeqGuid);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				else
				{
					dictionary2.TryGetValue(eventInfo.Info.EventName, out mechanismEventBase);
				}
				break;
			}
			}
			return mechanismEventBase;
		}

		// Token: 0x0602FCF7 RID: 195831 RVA: 0x00B7C234 File Offset: 0x00B7A434
		private unsafe bool DestroyEventObj(WeakReference<UMovieSceneSequencePlayer> sequencePlayer, IMechanismEventInfo eventInfo, EMechanismEventExecuteType executeType)
		{
			if (executeType != EMechanismEventExecuteType.End)
			{
				return false;
			}
			Dictionary<string, MechanismEventBase> dictionary;
			if (!this.EventStateMap.TryGetValue(sequencePlayer, out dictionary))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "SceneItemEventListenerComponent.DestroyEventObj,通过sequencePlayer获取EventStates失败";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("sequence", eventInfo.SeqGuid);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("eventType", eventInfo.Info.Action.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("eventName", eventInfo.Info.EventName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				return false;
			}
			MechanismEventBase mechanismEventBase;
			if (!dictionary.TryGetValue(eventInfo.Info.EventName, out mechanismEventBase))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.YSQ;
				string message2 = "SceneItemEventListenerComponent.DestroyEventObj,通过sequencePlayer获取EventObj失败";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", this.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("sequence", eventInfo.SeqGuid);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("eventType", eventInfo.Info.Action.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("eventName", eventInfo.Info.EventName);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
				return false;
			}
			mechanismEventBase.Dispose();
			return dictionary.Remove(eventInfo.Info.EventName);
		}

		// Token: 0x0602FCF8 RID: 195832 RVA: 0x00B7C3F0 File Offset: 0x00B7A5F0
		public void AddTags(IList<int> tagIds)
		{
			foreach (int tagId in tagIds)
			{
				FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(tagId);
				if (gameplayTagById != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 1);
					defaultInterpolatedStringHandler.AppendLiteral("SceneItemEventListenerComponent_");
					defaultInterpolatedStringHandler.AppendFormatted<int>(this.PbDataId);
					defaultInterpolatedStringHandler.AppendLiteral("_AddTag");
					string reason = defaultInterpolatedStringHandler.ToStringAndClear();
					LevelTagComponent tagComponent = this.TagComponent;
					if (tagComponent != null)
					{
						tagComponent.AddServerTagByIdLocal(gameplayTagById.Value.TagId(), reason);
					}
				}
			}
		}

		// Token: 0x0602FCF9 RID: 195833 RVA: 0x00B7C494 File Offset: 0x00B7A694
		public void RemoveTags(IList<int> tagIds)
		{
			foreach (int tagId in tagIds)
			{
				FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(tagId);
				if (gameplayTagById != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 1);
					defaultInterpolatedStringHandler.AppendLiteral("SceneItemEventListenerComponent_");
					defaultInterpolatedStringHandler.AppendFormatted<int>(this.PbDataId);
					defaultInterpolatedStringHandler.AppendLiteral("_AddTag");
					string reason = defaultInterpolatedStringHandler.ToStringAndClear();
					LevelTagComponent tagComponent = this.TagComponent;
					if (tagComponent != null)
					{
						tagComponent.RemoveServerTagByIdLocal(gameplayTagById.Value.TagId(), reason);
					}
				}
			}
		}

		// Token: 0x0602FCFA RID: 195834 RVA: 0x00B7C538 File Offset: 0x00B7A738
		public int CreateBullet(SeqEventFireBullet param, string eventName)
		{
			EntityHandle sceneBulletOwner = ControllerBase<BulletController>.Instance.GetSceneBulletOwner();
			if (sceneBulletOwner == null || !sceneBulletOwner.IsInit)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "Bullet生成错误, 找不到场景子弹owner";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityID", (long)base.Entity.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			BulletController instance2 = ControllerBase<BulletController>.Instance;
			Entity entity = sceneBulletOwner.Entity;
			string bulletRowName = param.BulletId.ToString();
			BaseActorComponent actorComponent = this.ActorComponent;
			BulletEntity bulletEntity = instance2.CreateBulletCustomTarget(entity, bulletRowName, (actorComponent != null) ? new FTransformDouble?(actorComponent.ActorTransform) : null, new BulletController.BulletCreateParams(), new long?(this.ContextId), global::EBulletCreateSource.Others);
			if (bulletEntity == null)
			{
				return 0;
			}
			return bulletEntity.Id;
		}

		// Token: 0x0602FCFB RID: 195835 RVA: 0x00B7C5F3 File Offset: 0x00B7A7F3
		public void DestroyBullet(int bulletEntityId)
		{
			ControllerBase<BulletController>.Instance.DestroyBullet(bulletEntityId, false, EBulletDestroyReason.Normal, false);
		}

		// Token: 0x0602FCFC RID: 195836 RVA: 0x00B7C604 File Offset: 0x00B7A804
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemEventListenerComponent sceneItemEventListenerComponent = (SceneItemEventListenerComponent)componentTemplate;
			if (base.CanResetComponentProperty("TagComponent"))
			{
				if (sceneItemEventListenerComponent.TagComponent == null)
				{
					this.TagComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.TagComponent), "TagComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComponent"))
			{
				if (sceneItemEventListenerComponent.ActorComponent == null)
				{
					this.ActorComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComponent), "ActorComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComponent"))
			{
				if (sceneItemEventListenerComponent.CreatureDataComponent == null)
				{
					this.CreatureDataComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SeqPlayerToWeak") && sceneItemEventListenerComponent.SeqPlayerToWeak != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<UMovieSceneSequencePlayer, WeakReference<UMovieSceneSequencePlayer>>(this.SeqPlayerToWeak), "SeqPlayerToWeak"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EventConfigMap") && sceneItemEventListenerComponent.EventConfigMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, Dictionary<string, IMechanismEventInfo>>>(this.EventConfigMap), "EventConfigMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EventStateMap") && sceneItemEventListenerComponent.EventStateMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<WeakReference<UMovieSceneSequencePlayer>, Dictionary<string, MechanismEventBase>>>(this.EventStateMap), "EventStateMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ExecutedEventMap") && sceneItemEventListenerComponent.ExecutedEventMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<WeakReference<UMovieSceneSequencePlayer>, List<string>>>(this.ExecutedEventMap), "ExecutedEventMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("SeqPlayerToGuid") && sceneItemEventListenerComponent.SeqPlayerToGuid != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<WeakReference<UMovieSceneSequencePlayer>, string>>(this.SeqPlayerToGuid), "SeqPlayerToGuid"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("SeqEventsConfig") && sceneItemEventListenerComponent.SeqEventsConfig != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, List<ISceneItemSeqEventCbType>>>(this.SeqEventsConfig), "SeqEventsConfig"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("PbDataId"))
			{
				this.PbDataId = sceneItemEventListenerComponent.PbDataId;
			}
			if (base.CanResetComponentProperty("ContextId"))
			{
				this.ContextId = sceneItemEventListenerComponent.ContextId;
			}
			return true;
		}

		// Token: 0x0401B6A2 RID: 112290
		private const string SERVER_DATA = "ListenerComponentPb";

		// Token: 0x0401B6A3 RID: 112291
		[Nullable(2)]
		private LevelTagComponent TagComponent;

		// Token: 0x0401B6A4 RID: 112292
		[Nullable(2)]
		private BaseActorComponent ActorComponent;

		// Token: 0x0401B6A5 RID: 112293
		[Nullable(2)]
		private CreatureDataComponent CreatureDataComponent;

		// Token: 0x0401B6A6 RID: 112294
		private readonly WeakMap<UMovieSceneSequencePlayer, WeakReference<UMovieSceneSequencePlayer>> SeqPlayerToWeak = new WeakMap<UMovieSceneSequencePlayer, WeakReference<UMovieSceneSequencePlayer>>();

		// Token: 0x0401B6A7 RID: 112295
		private readonly Dictionary<string, Dictionary<string, IMechanismEventInfo>> EventConfigMap = new Dictionary<string, Dictionary<string, IMechanismEventInfo>>();

		// Token: 0x0401B6A8 RID: 112296
		private readonly Dictionary<WeakReference<UMovieSceneSequencePlayer>, Dictionary<string, MechanismEventBase>> EventStateMap = new Dictionary<WeakReference<UMovieSceneSequencePlayer>, Dictionary<string, MechanismEventBase>>();

		// Token: 0x0401B6A9 RID: 112297
		private readonly Dictionary<WeakReference<UMovieSceneSequencePlayer>, List<string>> ExecutedEventMap = new Dictionary<WeakReference<UMovieSceneSequencePlayer>, List<string>>();

		// Token: 0x0401B6AA RID: 112298
		private readonly Dictionary<WeakReference<UMovieSceneSequencePlayer>, string> SeqPlayerToGuid = new Dictionary<WeakReference<UMovieSceneSequencePlayer>, string>();

		// Token: 0x0401B6AB RID: 112299
		private readonly Dictionary<string, List<ISceneItemSeqEventCbType>> SeqEventsConfig = new Dictionary<string, List<ISceneItemSeqEventCbType>>();

		// Token: 0x0401B6AC RID: 112300
		private int PbDataId;

		// Token: 0x0401B6AD RID: 112301
		private long ContextId;
	}
}
