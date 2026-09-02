using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

namespace CSharpScript.Game.Module.MechanismTimeline
{
	// Token: 0x020057DB RID: 22491
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MechanismTimelineController : ControllerBase<MechanismTimelineController>
	{
		// Token: 0x06039267 RID: 234087 RVA: 0x00E7D647 File Offset: 0x00E7B847
		protected override bool OnInit()
		{
			bool result = base.OnInit();
			bool isPlayInEditor = GlobalData.IsPlayInEditor;
			return result;
		}

		// Token: 0x06039268 RID: 234088 RVA: 0x00E7D655 File Offset: 0x00E7B855
		protected override bool OnClear()
		{
			bool result = base.OnClear();
			if (GlobalData.IsPlayInEditor)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FName, FName, EMechanismEventExecuteType, UMovieSceneSequencePlayer, uint>(this.OnTriggerMechanismEvent));
			}
			return result;
		}

		// Token: 0x06039269 RID: 234089 RVA: 0x00E7D678 File Offset: 0x00E7B878
		private unsafe void OnTriggerMechanismEvent(FName eventType, FName eventName, EMechanismEventExecuteType executeType, UMovieSceneSequencePlayer sequencePlayer, uint sectionId)
		{
			MechanismEventContext contextByPlayer = ModelBase<MechanismTimelineModel>.Instance.GetContextByPlayer(sequencePlayer);
			if (contextByPlayer == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "MechanismTimelineController.OnTriggerMechanismEvent:找不到上下文";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("eventName", eventName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("executeType", executeType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("sectionId", sectionId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			MechanismEventLevelPrefabContext mechanismEventLevelPrefabContext = contextByPlayer as MechanismEventLevelPrefabContext;
			if (mechanismEventLevelPrefabContext == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.YSQ;
				string message2 = "MechanismTimelineController.OnTriggerMechanismEvent:暂未支持的上下文类型";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("eventName", eventName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("executeType", executeType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("sectionId", sectionId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(mechanismEventLevelPrefabContext.PbDataId);
			if (entityByPbDataId == null || !entityByPbDataId.IsInit)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.LevelPlay;
				ELogAuthor author3 = ELogAuthor.YSQ;
				string message3 = "MechanismTimelineController.OnTriggerMechanismEvent:实体还未初始化";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("eventName", eventName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("executeType", executeType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("sectionId", sectionId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("pbDataId", mechanismEventLevelPrefabContext.PbDataId);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
				return;
			}
			WorldEntity entity = entityByPbDataId.Entity;
			SceneItemEventListenerComponent sceneItemEventListenerComponent = (entity != null) ? entity.GetComponent<SceneItemEventListenerComponent>() : null;
			if (sceneItemEventListenerComponent == null)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.LevelPlay;
				ELogAuthor author4 = ELogAuthor.YSQ;
				string message4 = "MechanismTimelineController.OnTriggerMechanismEvent:找不到SceneItemEventListenerComponent组件";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("eventName", eventName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("executeType", executeType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("sectionId", sectionId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("pbDataId", mechanismEventLevelPrefabContext.PbDataId);
				instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 4));
				return;
			}
			sceneItemEventListenerComponent.ExecuteEvent(sequencePlayer, eventType.ToString(), eventName.ToString(), executeType, mechanismEventLevelPrefabContext);
		}

		// Token: 0x0603926A RID: 234090 RVA: 0x00E7D940 File Offset: 0x00E7BB40
		public void RequestSceneItemSequenceFrameStart(int playerId, long createDataId, string seqGuid, string eventName)
		{
			SceneItemSequenceFrameStartRequest sceneItemSequenceFrameStartRequest = SceneItemSequenceFrameStartRequest.Create();
			sceneItemSequenceFrameStartRequest.HostPlayerId = playerId;
			sceneItemSequenceFrameStartRequest.EntityId = createDataId;
			sceneItemSequenceFrameStartRequest.SeqGuid = seqGuid;
			sceneItemSequenceFrameStartRequest.EventName = eventName;
			Singleton<Net>.Instance.Call<SceneItemSequenceFrameStartResponse>(ERequestMessageId.SceneItemSequenceFrameStartRequest, sceneItemSequenceFrameStartRequest, delegate(SceneItemSequenceFrameStartResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.Code != ErrorCode.Success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "MechanismTimelineController.RequestSceneItemSequenceFrameStart";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ErrorCode", response.Code);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}, 0);
		}

		// Token: 0x0603926B RID: 234091 RVA: 0x00E7D9A0 File Offset: 0x00E7BBA0
		public void RequestSceneItemSequenceFrameEnd(int playerId, long createDataId, string seqGuid, string eventName)
		{
			SceneItemSequenceFrameEndRequest sceneItemSequenceFrameEndRequest = SceneItemSequenceFrameEndRequest.Create();
			sceneItemSequenceFrameEndRequest.HostPlayerId = playerId;
			sceneItemSequenceFrameEndRequest.EntityId = createDataId;
			sceneItemSequenceFrameEndRequest.SeqGuid = seqGuid;
			sceneItemSequenceFrameEndRequest.EventName = eventName;
			Singleton<Net>.Instance.Call<SceneItemSequenceFrameEndResponse>(ERequestMessageId.SceneItemSequenceFrameEndRequest, sceneItemSequenceFrameEndRequest, delegate(SceneItemSequenceFrameEndResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.Code != ErrorCode.Success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "MechanismTimelineController.RequestSceneItemSequenceFrameEnd";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ErrorCode", response.Code);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}, 0);
		}
	}
}
