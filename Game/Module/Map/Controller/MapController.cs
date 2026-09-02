using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.WorldMap;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Controller
{
	// Token: 0x020058EE RID: 22766
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MapController : ControllerWithAssistantBase<MapController>
	{
		// Token: 0x06039C48 RID: 236616 RVA: 0x00EA0CD5 File Offset: 0x00E9EED5
		protected override bool OnInit()
		{
			bool result = base.OnInit();
			this.LineTraceSaver = new LineTraceSaver();
			this.RegisterAssistant();
			return result;
		}

		// Token: 0x06039C49 RID: 236617 RVA: 0x00EA0CEE File Offset: 0x00E9EEEE
		protected override bool OnClear()
		{
			LineTraceSaver lineTraceSaver = this.LineTraceSaver;
			if (lineTraceSaver != null)
			{
				lineTraceSaver.OnClear();
			}
			this.LineTraceSaver = null;
			Dictionary<int, ControllerAssistantBase> assistants = this.Assistants;
			if (assistants != null)
			{
				assistants.Clear();
			}
			this.Assistants = null;
			return base.OnClear();
		}

		// Token: 0x06039C4A RID: 236618 RVA: 0x00EA0D28 File Offset: 0x00E9EF28
		protected override void OnAddEvents()
		{
			base.OnAddEvents();
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.OnEnterOnlineWorld, new Action(this.OnEnterOnlineWorld));
			Singleton<EventSystem>.Instance.Add(EEventName.OnLeaveOnlineWorld, new Action(this.OnLeaveOnlineWorld));
		}

		// Token: 0x06039C4B RID: 236619 RVA: 0x00EA0D90 File Offset: 0x00E9EF90
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnEnterOnlineWorld, new Action(this.OnEnterOnlineWorld));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLeaveOnlineWorld, new Action(this.OnLeaveOnlineWorld));
			base.OnRemoveEvents();
		}

		// Token: 0x06039C4C RID: 236620 RVA: 0x00EA0DF7 File Offset: 0x00E9EFF7
		protected override void RegisterAssistant()
		{
			this.Assistants = new Dictionary<int, ControllerAssistantBase>();
			this.Assistants[0] = new MarkAssistant();
			this.Assistants[1] = new TeleportAssistant();
			this.Assistants[2] = new AreaAssistant();
		}

		// Token: 0x06039C4D RID: 236621 RVA: 0x00EA0E38 File Offset: 0x00E9F038
		[NullableContext(0)]
		[return: Nullable(2)]
		private T GetAssistant<T>(MapController.EAssistantType type) where T : ControllerAssistantBase
		{
			if (this.Assistants == null)
			{
				return default(T);
			}
			ControllerAssistantBase controllerAssistantBase;
			if (this.Assistants.TryGetValue((int)type, out controllerAssistantBase))
			{
				return controllerAssistantBase as T;
			}
			return default(T);
		}

		// Token: 0x06039C4E RID: 236622 RVA: 0x00EA0E7C File Offset: 0x00E9F07C
		private void OnWorldDone()
		{
			this.WorldDoneRequest();
		}

		// Token: 0x06039C4F RID: 236623 RVA: 0x00EA0E85 File Offset: 0x00E9F085
		private void ClearAllTrack()
		{
			ModelBase<TrackModel>.Instance.ClearTrackData();
			ModelBase<MapModel>.Instance.SetCurTrackMark(null);
		}

		// Token: 0x06039C50 RID: 236624 RVA: 0x00EA0E9C File Offset: 0x00E9F09C
		private void OnEnterOnlineWorld()
		{
			this.ClearAllTrack();
			MarkAssistant assistant = this.GetAssistant<MarkAssistant>(MapController.EAssistantType.Mark);
			if (assistant == null)
			{
				return;
			}
			assistant.RequestTrackInfo();
		}

		// Token: 0x06039C51 RID: 236625 RVA: 0x00EA0EB6 File Offset: 0x00E9F0B6
		private void OnLeaveOnlineWorld()
		{
			this.ClearAllTrack();
			MarkAssistant assistant = this.GetAssistant<MarkAssistant>(MapController.EAssistantType.Mark);
			if (assistant == null)
			{
				return;
			}
			assistant.RequestTrackInfo();
		}

		// Token: 0x06039C52 RID: 236626 RVA: 0x00EA0ED0 File Offset: 0x00E9F0D0
		private UniTask WorldDoneRequest()
		{
			MapController.<WorldDoneRequest>d__15 <WorldDoneRequest>d__;
			<WorldDoneRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WorldDoneRequest>d__.<>4__this = this;
			<WorldDoneRequest>d__.<>1__state = -1;
			<WorldDoneRequest>d__.<>t__builder.Start<MapController.<WorldDoneRequest>d__15>(ref <WorldDoneRequest>d__);
			return <WorldDoneRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06039C53 RID: 236627 RVA: 0x00EA0F14 File Offset: 0x00E9F114
		public UniTask RequestMapData()
		{
			MapController.<RequestMapData>d__16 <RequestMapData>d__;
			<RequestMapData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestMapData>d__.<>4__this = this;
			<RequestMapData>d__.<>1__state = -1;
			<RequestMapData>d__.<>t__builder.Start<MapController.<RequestMapData>d__16>(ref <RequestMapData>d__);
			return <RequestMapData>d__.<>t__builder.Task;
		}

		// Token: 0x06039C54 RID: 236628 RVA: 0x00EA0F57 File Offset: 0x00E9F157
		[NullableContext(2)]
		public Vector GetMarkPosition(double x, double y)
		{
			return this.LineTraceSaver.GetMarkPosition(x, y);
		}

		// Token: 0x06039C55 RID: 236629 RVA: 0x00EA0F68 File Offset: 0x00E9F168
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public OneOf<Vector, Vector2D>? GetNewCustomMarkPosition(double x, double y)
		{
			Vector markPosition = this.GetMarkPosition(x, y);
			if (markPosition == null)
			{
				return new OneOf<Vector, Vector2D>?(Vector2D.Create(x, -y));
			}
			IReadOnlyList<int> commonIntArray = ConfigBase<WorldMapConfig>.Instance.GetCommonIntArray("MarkCollisionRange");
			float num = (float)commonIntArray[0];
			float num2 = (float)commonIntArray[1];
			bool flag = markPosition.Z >= (double)num && markPosition.Z <= (double)num2;
			if (!flag)
			{
				return new OneOf<Vector, Vector2D>?(Vector2D.Create(x, -y));
			}
			if (!flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "MapController.GetNewCustomMarkPosition()";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("自定义地图标记不在有效范围 Z轴坐标:", markPosition.Z);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return new OneOf<Vector, Vector2D>?(markPosition);
		}

		// Token: 0x06039C56 RID: 236630 RVA: 0x00EA1024 File Offset: 0x00E9F224
		public void RequestMapMarkReplace(int markId, int configId)
		{
			this.GetAssistant<MarkAssistant>(MapController.EAssistantType.Mark).RequestMapMarkReplace(markId, configId);
		}

		// Token: 0x06039C57 RID: 236631 RVA: 0x00EA1034 File Offset: 0x00E9F234
		public void RequestCreateCustomMark(TTrackTarget trackPosition, int configId, [Nullable(2)] Action<bool> successCallBack = null)
		{
			MarkAssistant assistant = this.GetAssistant<MarkAssistant>(MapController.EAssistantType.Mark);
			if (assistant == null)
			{
				return;
			}
			assistant.RequestCreateCustomMark(trackPosition, configId, successCallBack);
		}

		// Token: 0x06039C58 RID: 236632 RVA: 0x00EA104C File Offset: 0x00E9F24C
		public void RequestRemoveMapMarks(EMarkType markType, List<int> markIds)
		{
			TrackMapMarkParams curTrackMark = ModelBase<MapModel>.Instance.GetCurTrackMark();
			foreach (int num in markIds)
			{
				if (curTrackMark != null && curTrackMark.MarkType == markType && curTrackMark.MarkId == num)
				{
					ModelBase<MapModel>.Instance.SetCurTrackMark(null);
				}
			}
			MarkAssistant assistant = this.GetAssistant<MarkAssistant>(MapController.EAssistantType.Mark);
			if (assistant == null)
			{
				return;
			}
			assistant.RequestRemoveMapMarks(markType, markIds);
		}

		// Token: 0x06039C59 RID: 236633 RVA: 0x00EA10D4 File Offset: 0x00E9F2D4
		public void RequestTrackMapMark(TrackMapMarkParams @params, [Nullable(2)] Action<ETrackMapMarkResultType, bool> resultCallBack = null)
		{
			if (@params.TrackMode == null)
			{
				if (@params.MarkType == EMarkType.Custom || ConfigBase<MapConfig>.Instance.GetConfigMark(@params.MarkId) != null)
				{
					@params.TrackMode = new ETrackMapMarkMode?(ETrackMapMarkMode.Remote);
				}
				else
				{
					@params.TrackMode = new ETrackMapMarkMode?(ETrackMapMarkMode.Local);
				}
			}
			if (@params.Track)
			{
				this.HandleUnTrackCurrent(@params);
				if (@params.TrackMode.GetValueOrDefault() == ETrackMapMarkMode.Remote)
				{
					this.HandleRemoteTrack(@params, resultCallBack);
					return;
				}
				this.HandleLocalTrack(@params, resultCallBack);
				return;
			}
			else
			{
				if (@params.TrackMode.GetValueOrDefault() == ETrackMapMarkMode.Remote)
				{
					this.HandleRemoteUnTrack(@params, resultCallBack);
					return;
				}
				this.HandleLocalUnTrack(@params, resultCallBack);
				return;
			}
		}

		// Token: 0x06039C5A RID: 236634 RVA: 0x00EA117C File Offset: 0x00E9F37C
		private void HandleUnTrackCurrent(TrackMapMarkParams newTrackParams)
		{
			TrackMapMarkParams curTrackMark = ModelBase<MapModel>.Instance.GetCurTrackMark();
			if (curTrackMark != null && (curTrackMark.MarkType != newTrackParams.MarkType || curTrackMark.MarkId != newTrackParams.MarkId))
			{
				if (curTrackMark.TrackMode.GetValueOrDefault() == ETrackMapMarkMode.Remote)
				{
					this.HandleRemoteUnTrack(curTrackMark, null);
					return;
				}
				this.HandleLocalUnTrack(curTrackMark, null);
			}
		}

		// Token: 0x06039C5B RID: 236635 RVA: 0x00EA11D2 File Offset: 0x00E9F3D2
		private void HandleRemoteTrack(TrackMapMarkParams @params, [Nullable(2)] Action<ETrackMapMarkResultType, bool> resultCallBack = null)
		{
			this.GetAssistant<MarkAssistant>(MapController.EAssistantType.Mark).RequestTrackMapMark(@params.MarkType, @params.MarkId, resultCallBack);
			ModelBase<MapModel>.Instance.SetCurTrackMark(@params);
		}

		// Token: 0x06039C5C RID: 236636 RVA: 0x00EA11F8 File Offset: 0x00E9F3F8
		private void HandleLocalTrack(TrackMapMarkParams @params, [Nullable(2)] Action<ETrackMapMarkResultType, bool> resultCallBack)
		{
			ModelBase<MapModel>.Instance.SetCurTrackMark(@params);
			ModelBase<MapModel>.Instance.SetTrackMark(@params.MarkType, @params.MarkId, @params.Track);
			if (resultCallBack != null)
			{
				resultCallBack(ETrackMapMarkResultType.Success, true);
			}
		}

		// Token: 0x06039C5D RID: 236637 RVA: 0x00EA122C File Offset: 0x00E9F42C
		private void HandleRemoteUnTrack(TrackMapMarkParams @params, [Nullable(2)] Action<ETrackMapMarkResultType, bool> resultCallBack = null)
		{
			ModelBase<MapModel>.Instance.SetCurTrackMark(null);
			MarkAssistant assistant = this.GetAssistant<MarkAssistant>(MapController.EAssistantType.Mark);
			if (assistant == null)
			{
				return;
			}
			assistant.RequestCancelTrackMapMark(@params.MarkType, @params.MarkId, resultCallBack);
		}

		// Token: 0x06039C5E RID: 236638 RVA: 0x00EA1257 File Offset: 0x00E9F457
		private void HandleLocalUnTrack(TrackMapMarkParams @params, [Nullable(2)] Action<ETrackMapMarkResultType, bool> resultCallBack = null)
		{
			ModelBase<MapModel>.Instance.SetCurTrackMark(null);
			ModelBase<MapModel>.Instance.SetTrackMark(@params.MarkType, @params.MarkId, false);
			if (resultCallBack != null)
			{
				resultCallBack(ETrackMapMarkResultType.Success, false);
			}
		}

		// Token: 0x06039C5F RID: 236639 RVA: 0x00EA1286 File Offset: 0x00E9F486
		public void UpdateCustomMapMarkPosition(int markId, Vector markPos)
		{
			MarkAssistant assistant = this.GetAssistant<MarkAssistant>(MapController.EAssistantType.Mark);
			if (assistant == null)
			{
				return;
			}
			assistant.UpdateCustomMapMarkPosition(markId, markPos);
		}

		// Token: 0x06039C60 RID: 236640 RVA: 0x00EA129B File Offset: 0x00E9F49B
		public void RequestTrackEnrichmentArea(int? itemId = null)
		{
			MarkAssistant assistant = this.GetAssistant<MarkAssistant>(MapController.EAssistantType.Mark);
			if (assistant == null)
			{
				return;
			}
			assistant.RequestTrackEnrichmentArea(itemId, null);
		}

		// Token: 0x06039C61 RID: 236641 RVA: 0x00EA12B0 File Offset: 0x00E9F4B0
		[NullableContext(2)]
		public void RequestTeleportToTargetByTemporaryTeleport(int teleportId, TOnTelSuccessCallBack successAction = null)
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid)
			{
				return;
			}
			CharacterActorComponent component = getCurrentEntity.Entity.GetComponent<CharacterActorComponent>();
			if (component == null)
			{
				return;
			}
			MarkAssistant assistant = this.GetAssistant<MarkAssistant>(MapController.EAssistantType.Mark);
			if (assistant == null)
			{
				return;
			}
			assistant.RequestTeleportToTargetByTemporaryTeleport(teleportId, Rotator.Create(component.ActorRotationProxy), successAction);
		}

		// Token: 0x06039C62 RID: 236642 RVA: 0x00EA1308 File Offset: 0x00E9F508
		public void ForceSetMarkVisible(EMarkType markType, int markId, bool visible)
		{
			ModelBase<MapModel>.Instance.ForceSetMarkVisible(markType, markId, visible);
			Singleton<EventSystem>.Instance.Emit<EMarkType, int, bool>(EEventName.MarkForceVisibleChanged, markType, markId, visible);
		}

		// Token: 0x06039C63 RID: 236643 RVA: 0x00EA132A File Offset: 0x00E9F52A
		[NullableContext(2)]
		public void OpenMapViewAndFocusMark(EMarkType markType, int markId, Action<bool, int> callback = null, bool isFocusTween = true, float startScale = 1f)
		{
			MarkAssistant assistant = this.GetAssistant<MarkAssistant>(MapController.EAssistantType.Mark);
			if (assistant == null)
			{
				return;
			}
			assistant.OpenMapViewAndFocus(markType, markId, callback, isFocusTween, startScale, false);
		}

		// Token: 0x04020C07 RID: 134151
		public const int SCALE_XY = 100;

		// Token: 0x04020C08 RID: 134152
		public const int SCALE_Z = 1000000;

		// Token: 0x04020C09 RID: 134153
		public const string PROFILE_KEY = "WorldMapView_CreateNewCustomMarkItem";

		// Token: 0x04020C0A RID: 134154
		[Nullable(2)]
		private LineTraceSaver LineTraceSaver;

		// Token: 0x0200B8E0 RID: 47328
		[NullableContext(0)]
		public enum EAssistantType
		{
			// Token: 0x04039245 RID: 234053
			Mark,
			// Token: 0x04039246 RID: 234054
			Teleport,
			// Token: 0x04039247 RID: 234055
			Area
		}
	}
}
