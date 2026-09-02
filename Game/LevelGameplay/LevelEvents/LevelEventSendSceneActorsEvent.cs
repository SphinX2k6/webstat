using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Render.RuntimeBP.SceneCapture_3To2;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BE0 RID: 27616
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventSendSceneActorsEvent : LevelEventBase
	{
		// Token: 0x060440B8 RID: 278712 RVA: 0x011A71FF File Offset: 0x011A53FF
		public LevelEventSendSceneActorsEvent(int id) : base(id)
		{
		}

		// Token: 0x060440B9 RID: 278713 RVA: 0x011A7208 File Offset: 0x011A5408
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			SendSceneActorEvent sendSceneActorEvent = inParams as SendSceneActorEvent;
			if (sendSceneActorEvent == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CK, "[LevelEventSendSceneActorsEvent] 参数不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (sendSceneActorEvent.ActorEvent.Type == ESceneActorEventType.Projection3dTo2d)
			{
				this.HandleProjection3dTo2d(sendSceneActorEvent.ActorEvent as ISceneActorProjection3dTo2dEvent, context);
				base.FinishExecute(true, false, true);
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[LevelEventSendSceneActorsEvent] LevelEvent向蓝图发送音乐节拍事件";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MusicEventType", sendSceneActorEvent.ActorEvent.Type);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			GlobalData.BpEventManager.音乐节拍事件触发时.Broadcast(sendSceneActorEvent.ActorEvent.Type.ToEnumString());
			base.FinishExecute(true, false, true);
		}

		// Token: 0x060440BA RID: 278714 RVA: 0x011A72C4 File Offset: 0x011A54C4
		private void HandleProjection3dTo2d([Nullable(2)] ISceneActorProjection3dTo2dEvent param, GeneralContext context)
		{
			if (param == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.HF, "[LevelEventSendSceneActorsEvent] Projection3dTo2d参数不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			AActor sceneRefActor = this.GetSceneRefActor(param.BpActor.PathName, context);
			AActor sceneRefActor2 = this.GetSceneRefActor(param.PPVolume.PathName, context);
			BP_SceneCapture_3To2_C bp_SceneCapture_3To2_C = sceneRefActor as BP_SceneCapture_3To2_C;
			if (bp_SceneCapture_3To2_C == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.HF;
				string message = "[LevelEventSendSceneActorsEvent] BpActor不是BP_SceneCapture_3To2_C";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RefPath", param.BpActor.PathName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			AKuroPostProcessVolume akuroPostProcessVolume = sceneRefActor2 as AKuroPostProcessVolume;
			if (akuroPostProcessVolume == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.HF;
				string message2 = "[LevelEventSendSceneActorsEvent] PPVolume不是KuroPostProcessVolume";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("RefPath", param.PPVolume.PathName);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.HF, "[LevelEventSendSceneActorsEvent] HandleProjection3dTo2d", default(ReadOnlySpan<ValueTuple<string, object>>));
			bp_SceneCapture_3To2_C.PPV = akuroPostProcessVolume;
			bp_SceneCapture_3To2_C.CaptureScene_Running();
		}

		// Token: 0x060440BB RID: 278715 RVA: 0x011A73B8 File Offset: 0x011A55B8
		[return: Nullable(2)]
		private AActor GetSceneRefActor(string pathName, GeneralContext context)
		{
			EntityContext entityContext = context as EntityContext;
			if (entityContext == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.HF, "[LevelEventSendSceneActorsEvent] 此事件只能配置在SceneActorRefComponent中", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			if (entityContext.EntityId == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.HF, "[LevelEventSendSceneActorsEvent] EntityId不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityContext.EntityId.Value);
			if (entity == null || !entity.Valid)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.HF;
				string message = "[LevelEventSendSceneActorsEvent] 状态控制entity不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entityContext.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			SceneItemReferenceComponent component = entity.GetComponent<SceneItemReferenceComponent>();
			if (component == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.HF, "[LevelEventSendSceneActorsEvent] 状态控制组件不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			string[] array = pathName.Split('.', StringSplitOptions.None);
			if (array.Length < 3)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.HF;
				string message2 = "[LevelEventSendSceneActorsEvent] actor路径错误";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("RefPath", pathName);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			string text = array[1] + "." + array[2];
			if (!component.IsValidPlatFormPath(text))
			{
				return null;
			}
			UKuroActorSubsystem ukuroActorSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroActorSubsystem.StaticClass()) as UKuroActorSubsystem;
			AActor aactor = (ukuroActorSubsystem != null) ? ukuroActorSubsystem.GetActor(new FName(text)) : null;
			if (aactor == null || !aactor.IsValid())
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.LevelEvent;
				ELogAuthor author3 = ELogAuthor.HF;
				string message3 = "[LevelEventSendSceneActorsEvent] 目标actor不存在";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("RefPath", pathName);
				instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return null;
			}
			return aactor;
		}
	}
}
