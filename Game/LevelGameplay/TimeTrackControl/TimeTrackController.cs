using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.StaticScene;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.TimeTrackControl
{
	// Token: 0x02006A94 RID: 27284
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TimeTrackController : UiControllerBase<TimeTrackController>
	{
		// Token: 0x06043774 RID: 276340 RVA: 0x01161A31 File Offset: 0x0115FC31
		protected override void OnAddEvents()
		{
			if (!Singleton<EventSystem>.Instance.Has(EEventName.CameraViewTargetChanged, new Action<float, string>(this.OnViewTargetChanged)))
			{
				Singleton<EventSystem>.Instance.Add<float, string>(EEventName.CameraViewTargetChanged, new Action<float, string>(this.OnViewTargetChanged));
			}
		}

		// Token: 0x06043775 RID: 276341 RVA: 0x01161A6C File Offset: 0x0115FC6C
		protected override void OnRemoveEvents()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.CameraViewTargetChanged, new Action<float, string>(this.OnViewTargetChanged)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.CameraViewTargetChanged, new Action<float, string>(this.OnViewTargetChanged));
			}
		}

		// Token: 0x06043776 RID: 276342 RVA: 0x01161AA8 File Offset: 0x0115FCA8
		protected void SafeRegisterEvents(EntityHandle inEntity)
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget(inEntity.Entity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
			{
				return;
			}
			Singleton<EventSystem>.Instance.AddWithTarget(inEntity.Entity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}

		// Token: 0x06043777 RID: 276343 RVA: 0x01161AFC File Offset: 0x0115FCFC
		protected void SafeUnRegisterEvents(EntityHandle inEntityHandle)
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget(inEntityHandle.Entity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(inEntityHandle.Entity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			}
		}

		// Token: 0x06043778 RID: 276344 RVA: 0x01161B4E File Offset: 0x0115FD4E
		private void CameraViewTargetEnd(float _)
		{
			this.FinishCallback(true);
		}

		// Token: 0x06043779 RID: 276345 RVA: 0x01161B58 File Offset: 0x0115FD58
		protected void OnViewTargetChanged(float blendTime, string cameraName)
		{
			if (cameraName != "MainCamera")
			{
				return;
			}
			if (ControllerBase<CameraController>.Instance.MainModel.IsToLockOnCameraMode() && this.Callback != null)
			{
				if (blendTime <= 1f)
				{
					TimerSystem.Instance.Delay(new TTimerAction(this.CameraViewTargetEnd), 1000f, null, null, true, 1f);
					return;
				}
				TimerSystem.Instance.Delay(new TTimerAction(this.CameraViewTargetEnd), (float)((long)(blendTime * 1000f)), null, null, true, 1f);
			}
		}

		// Token: 0x0604377A RID: 276346 RVA: 0x01161BE4 File Offset: 0x0115FDE4
		[NullableContext(2)]
		public void OpenTimeTrackControlView(long entityId, int index, Action<bool> callback = null)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TimeTrackControlView))
			{
				if (callback != null)
				{
					callback(false);
					this.Callback = null;
				}
				return;
			}
			ModelBase<TimeTrackControlModel>.Instance.SetCurrentTimeTrackControl(entityId, index);
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			this.SafeRegisterEvents(entity);
			this.Callback = callback;
			this.TimelineTraceStartRequest(entityId, index);
		}

		// Token: 0x0604377B RID: 276347 RVA: 0x01161C44 File Offset: 0x0115FE44
		public void HandleTimeTrackControlViewClose()
		{
			this.TimelineTraceExitRequest();
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(ModelBase<TimeTrackControlModel>.Instance.RefEntityId);
			SceneItemReferenceComponent sceneItemReferenceComponent;
			if (entity == null)
			{
				sceneItemReferenceComponent = null;
			}
			else
			{
				WorldEntity entity2 = entity.Entity;
				sceneItemReferenceComponent = ((entity2 != null) ? entity2.GetComponent<SceneItemReferenceComponent>() : null);
			}
			SceneItemReferenceComponent sceneItemReferenceComponent2 = sceneItemReferenceComponent;
			if (sceneItemReferenceComponent2 != null)
			{
				sceneItemReferenceComponent2.ForceExitSeqCamera();
			}
			ModelBase<StaticSceneModel>.Instance.IsNotAutoExitSceneCamera = false;
			ModelBase<StaticSceneModel>.Instance.IsForceKeepUi = false;
		}

		// Token: 0x0604377C RID: 276348 RVA: 0x01161CA4 File Offset: 0x0115FEA4
		public void TimelineTraceStartRequest(long entityId, int index)
		{
			long creatureDataId = ModelBase<TimeTrackControlModel>.Instance.CreatureDataId;
			if (creatureDataId == 0L)
			{
				Singleton<Log>.Instance.Warn(ELogModule.SceneGameplay, ELogAuthor.YZH, "时间控制装置启动请求:当前没有有效的控制实体", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			Action<TimelineTraceStartResponse, Net.CallbackStatus> handle = delegate(TimelineTraceStartResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneGameplay;
					ELogAuthor author = ELogAuthor.JYS;
					string message = "时间控制装置启动请求:response请求失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityid", entityId);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.FinishCallback(false);
					return;
				}
				ModelBase<TimeTrackControlModel>.Instance.InitControlInfo(response);
				ModelBase<StaticSceneModel>.Instance.IsNotAutoExitSceneCamera = true;
				ModelBase<StaticSceneModel>.Instance.IsForceKeepUi = true;
				if (this.HandleStaticSceneSeq(response.EntityIds, entityId))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SceneGameplay;
					ELogAuthor author2 = ELogAuthor.JYS;
					string message2 = "时间控制装置启动请求:HandleStaticSceneSeq成功";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityid", entityId);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
				TsInteractionUtils.ClearCurrentOpenViewName();
				this.HandleTimeTrackControlViewClose();
				this.FinishCallback(false);
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.SceneGameplay;
				ELogAuthor author3 = ELogAuthor.JYS;
				string message3 = "时间控制装置启动请求:HandleStaticSceneSeq失败";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("entityid", entityId);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			};
			TimelineTraceStartRequest timelineTraceStartRequest = Aki.Protocol.TimelineTraceStartRequest.Create();
			timelineTraceStartRequest.EntityId = creatureDataId;
			timelineTraceStartRequest.Index = index;
			Singleton<Net>.Instance.Call<TimelineTraceStartResponse>(ERequestMessageId.TimelineTraceStartRequest, timelineTraceStartRequest, handle, 0);
		}

		// Token: 0x0604377D RID: 276349 RVA: 0x01161D20 File Offset: 0x0115FF20
		public void TimelineTraceControlRequest(bool inForward)
		{
			long creatureDataId = ModelBase<TimeTrackControlModel>.Instance.CreatureDataId;
			if (creatureDataId == 0L)
			{
				Singleton<Log>.Instance.Warn(ELogModule.SceneGameplay, ELogAuthor.YZH, "时间控制装置变更请求:当前没有有效的控制实体", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			ModelBase<TimeTrackControlModel>.Instance.CanUpdated = false;
			Action<TimelineTraceControlResponse, Net.CallbackStatus> handle = delegate(TimelineTraceControlResponse response, Net.CallbackStatus _)
			{
				ModelBase<TimeTrackControlModel>.Instance.CanUpdated = true;
				if (response == null)
				{
					return;
				}
				if (response.Code == ErrorCode.ErrTimelineMove)
				{
					Singleton<EventSystem>.Instance.Emit<int, ErrorCode>(EEventName.OnTimeTrackControlUpdate, response.ControlPoint, response.Code);
					return;
				}
				if (response.Code != ErrorCode.Success)
				{
					return;
				}
				int controlPoint = ModelBase<TimeTrackControlModel>.Instance.ControlPoint;
				ModelBase<TimeTrackControlModel>.Instance.UpdateControlInfo(response.ControlPoint);
				this.HandleControlEntitySeq(controlPoint, response.ControlPoint);
				Singleton<EventSystem>.Instance.Emit<int, ErrorCode>(EEventName.OnTimeTrackControlUpdate, response.ControlPoint, response.Code);
			};
			TimelineTraceControlRequest timelineTraceControlRequest = Aki.Protocol.TimelineTraceControlRequest.Create();
			timelineTraceControlRequest.Forward = inForward;
			timelineTraceControlRequest.EntityId = creatureDataId;
			Singleton<Net>.Instance.Call<TimelineTraceControlResponse>(ERequestMessageId.TimelineTraceControlRequest, timelineTraceControlRequest, handle, 0);
		}

		// Token: 0x0604377E RID: 276350 RVA: 0x01161D94 File Offset: 0x0115FF94
		public void TimelineTraceExitRequest()
		{
			long creatureDataId = ModelBase<TimeTrackControlModel>.Instance.CreatureDataId;
			if (creatureDataId == 0L)
			{
				Singleton<Log>.Instance.Warn(ELogModule.SceneGameplay, ELogAuthor.YZH, "时间控制装置退出请求:当前没有有效的控制实体", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			TimelineTraceExitRequest timelineTraceExitRequest = Aki.Protocol.TimelineTraceExitRequest.Create();
			timelineTraceExitRequest.EntityId = creatureDataId;
			Singleton<Net>.Instance.Call<TimelineTraceExitResponse>(ERequestMessageId.TimelineTraceExitRequest, timelineTraceExitRequest, null, 0);
		}

		// Token: 0x0604377F RID: 276351 RVA: 0x01161DE9 File Offset: 0x0115FFE9
		private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			ControllerBase<TimeTrackController>.Instance.SafeUnRegisterEvents(handle);
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TimeTrackControlView))
			{
				return;
			}
			Singleton<UiManager>.Instance.CloseView(EUiViewName.TimeTrackControlView, null);
		}

		// Token: 0x06043780 RID: 276352 RVA: 0x01161E18 File Offset: 0x01160018
		private bool HandleStaticSceneSeq(IList<long> inIds, long entityId)
		{
			if (inIds == null || inIds.Count == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.JYS;
				string message = "时间控制装置启动请求:失败，inId数组长度异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityid", entityId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.FinishCallback(false);
				return false;
			}
			for (int i = inIds.Count - 1; i >= 0; i--)
			{
				long num = inIds[i];
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num);
				if (entity != null && entity.Valid)
				{
					WorldEntity entity2 = entity.Entity;
					SceneItemReferenceComponent sceneItemReferenceComponent = (entity2 != null) ? entity2.GetComponent<SceneItemReferenceComponent>() : null;
					if (sceneItemReferenceComponent != null && sceneItemReferenceComponent.ForceEnterSeqCamera())
					{
						ModelBase<TimeTrackControlModel>.Instance.RefEntityId = num;
						ModelBase<TimeTrackControlModel>.Instance.RefTrueEntityId = entityId;
						return true;
					}
				}
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.SceneGameplay;
			ELogAuthor author2 = ELogAuthor.JYS;
			string message2 = "时间控制装置启动请求:失败，没找到合适的entityId";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityid", entityId);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.FinishCallback(false);
			return false;
		}

		// Token: 0x06043781 RID: 276353 RVA: 0x01161F10 File Offset: 0x01160110
		private void HandleControlEntitySeq(int oldPoint, int newPoint)
		{
			EntityHandle controllerEntity = ModelBase<TimeTrackControlModel>.Instance.ControllerEntity;
			if (controllerEntity == null || !controllerEntity.Valid)
			{
				Singleton<Log>.Instance.Warn(ELogModule.SceneGameplay, ELogAuthor.ZYL, "时间控制装置自身表现变化:当前没有有效的控制实体", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			SceneItemTimeTrackControlComponent component = controllerEntity.Entity.GetComponent<SceneItemTimeTrackControlComponent>();
			if (ModelBase<TimeTrackControlModel>.Instance.GetConfigStatesCounts() < 2)
			{
				return;
			}
			if (newPoint == oldPoint)
			{
				return;
			}
			if (component != null)
			{
				component.PlayActiveSeqForDuration(newPoint < oldPoint, -1f);
			}
		}

		// Token: 0x06043782 RID: 276354 RVA: 0x01161F88 File Offset: 0x01160188
		public void FinishCallback(bool value)
		{
			if (this.Callback != null)
			{
				Singleton<Log>.Instance.Info(ELogModule.SceneGameplay, ELogAuthor.JYS, "时间控制装置启动请求:FinishCallback", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.Callback(value);
				this.Callback = null;
			}
		}

		// Token: 0x04025AE5 RID: 154341
		[Nullable(2)]
		private Action<bool> Callback;
	}
}
