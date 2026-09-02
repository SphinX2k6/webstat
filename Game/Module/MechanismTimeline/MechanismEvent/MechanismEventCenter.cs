using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

namespace CSharpScript.Game.Module.MechanismTimeline.MechanismEvent
{
	// Token: 0x020057E2 RID: 22498
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MechanismEventCenter : Singleton<MechanismEventCenter>
	{
		// Token: 0x060392A7 RID: 234151 RVA: 0x00E7DE88 File Offset: 0x00E7C088
		public void RegisterEvents()
		{
			<>f__AnonymousDelegate7<EAction, MechanismEventCenter.EventBaseConstructor, bool> <>f__AnonymousDelegate = new <>f__AnonymousDelegate7<EAction, MechanismEventCenter.EventBaseConstructor, bool>(this.SetupEvent);
			<>f__AnonymousDelegate(EAction.SeqEventAddTagToSelf, (IMechanismEventInfo eventInfo, MechanismEventContext context, SceneItemEventListenerComponent eventListenerComponent, bool isServerAction) => new MechanismEventAddTagToSelf(eventInfo, context, eventListenerComponent, isServerAction), false);
			<>f__AnonymousDelegate(EAction.SeqEventFireBullet, (IMechanismEventInfo eventInfo, MechanismEventContext context, SceneItemEventListenerComponent eventListenerComponent, bool isServerAction) => new MechanismEventFireBullet(eventInfo, context, eventListenerComponent, isServerAction), false);
		}

		// Token: 0x060392A8 RID: 234152 RVA: 0x00E7DEF6 File Offset: 0x00E7C0F6
		public void Clear()
		{
			this.EventMap.Clear();
		}

		// Token: 0x060392A9 RID: 234153 RVA: 0x00E7DF03 File Offset: 0x00E7C103
		private void SetupEvent(EAction actionName, MechanismEventCenter.EventBaseConstructor actionClass, bool bServerAction = false)
		{
			this.EventMap.TryAdd(actionName, actionClass);
			this.ServerActions[actionName] = bServerAction;
		}

		// Token: 0x060392AA RID: 234154 RVA: 0x00E7DF20 File Offset: 0x00E7C120
		[NullableContext(2)]
		public MechanismEventCenter.EventBaseConstructor GetEventClass(EAction eventType)
		{
			return this.EventMap.GetValueOrDefault(eventType);
		}

		// Token: 0x060392AB RID: 234155 RVA: 0x00E7DF30 File Offset: 0x00E7C130
		public bool GetEventIsServerAction(EAction eventType)
		{
			bool flag;
			return this.ServerActions.TryGetValue(eventType, out flag) && flag;
		}

		// Token: 0x060392AC RID: 234156 RVA: 0x00E7DF50 File Offset: 0x00E7C150
		public unsafe bool DeleteEvent(EAction eventType, EMechanismEventExecuteType executeType, UMovieSceneSequencePlayer sequencePlayer, int sectionId)
		{
			if (executeType != EMechanismEventExecuteType.End)
			{
				return false;
			}
			Dictionary<int, MechanismEventBase> dictionary2;
			Dictionary<int, MechanismEventBase> dictionary = this.EventStateMap.TryGetValue(sequencePlayer, out dictionary2) ? dictionary2 : null;
			if (dictionary == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "MechanismEventCenter.DeleteEvent,通过sequencePlayer获取EventStates失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("eventType", eventType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("sequence", sequencePlayer.Sequence);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("sectionId", sectionId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return false;
			}
			return dictionary.Remove(sectionId);
		}

		// Token: 0x04020875 RID: 133237
		private readonly Dictionary<EAction, MechanismEventCenter.EventBaseConstructor> EventMap = new Dictionary<EAction, MechanismEventCenter.EventBaseConstructor>();

		// Token: 0x04020876 RID: 133238
		private readonly Dictionary<EAction, bool> ServerActions = new Dictionary<EAction, bool>();

		// Token: 0x04020877 RID: 133239
		private readonly ConditionalWeakTable<UMovieSceneSequencePlayer, Dictionary<int, MechanismEventBase>> EventStateMap = new ConditionalWeakTable<UMovieSceneSequencePlayer, Dictionary<int, MechanismEventBase>>();

		// Token: 0x0200B85D RID: 47197
		// (Invoke) Token: 0x0604D3B8 RID: 316344
		[NullableContext(0)]
		public delegate MechanismEventBase EventBaseConstructor(IMechanismEventInfo eventInfo, MechanismEventContext context, SceneItemEventListenerComponent eventListenerComponent, bool isServerAction);
	}
}
