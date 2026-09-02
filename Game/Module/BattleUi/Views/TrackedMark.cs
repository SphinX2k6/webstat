using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.RecallQuest.Model;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006120 RID: 24864
	[NullableContext(1)]
	[Nullable(0)]
	public class TrackedMark : UiPanelBase
	{
		// Token: 0x0603ECEC RID: 257260 RVA: 0x01015918 File Offset: 0x01013B18
		public TrackedMark(ITrackData TrackData)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			this.TrackSource = TrackData.TrackSource;
			this.IconPath = TrackData.IconPath;
			this.ShowGroupId = TrackData.ShowGroupId;
			this.MarkId = TrackData.Id;
			this.MarkType = TrackData.MarkType.GetValueOrDefault();
			this.IsWeakTrackExpress = TrackData.WeakTrack.GetValueOrDefault();
			if (TrackData.TaskMarkConfigId != null)
			{
				TaskMark? taskMarkConfig = ConfigBase<MapConfig>.Instance.GetTaskMarkConfig(TrackData.TaskMarkConfigId.Value);
				if (taskMarkConfig != null)
				{
					TaskMark valueOrDefault = taskMarkConfig.GetValueOrDefault();
					this.IsNewTrackExpress = true;
					this.MarkRingPic = valueOrDefault.MarkRingPic;
					this.MarkIconPic = valueOrDefault.MarkIcon;
					this.MarkRingColor = valueOrDefault.RingColor;
					this.SmallHaloColor = valueOrDefault.SmallHaloColor;
					this.LargeHaloColor = valueOrDefault.LargeHaloColor;
					this.IsNewTrackExpress = (!string.IsNullOrEmpty(this.MarkRingPic) || !string.IsNullOrEmpty(this.MarkIconPic) || !string.IsNullOrEmpty(this.SmallHaloColor) || !string.IsNullOrEmpty(this.LargeHaloColor));
				}
			}
			QuestMarkCreateInfo questMarkCreateInfo = ModelBase<MapModel>.Instance.GetDynamicMark(this.MarkId) as QuestMarkCreateInfo;
			if (questMarkCreateInfo != null)
			{
				this.TaskTrackedMarkItem = new TaskTrackedMarkItem(questMarkCreateInfo, this.TrackSource);
			}
			float? trackAutoCancelDistance = TrackData.TrackAutoCancelDistance;
			float num = (float)-1;
			if (!(trackAutoCancelDistance.GetValueOrDefault() == num & trackAutoCancelDistance != null) && TrackData.TrackAutoCancelDistance != null)
			{
				this.TrackAutoCancelDistance = new float?(TrackData.TrackAutoCancelDistance.Value * 0.01f);
			}
			this.AlreadyCancelTrack = false;
			this.MarkHideDis = TrackData.TrackHideDis;
			this.TrackTarget = TrackData.TrackTarget;
			this.TrackInstanceId = (TrackData.TrackInstanceId ?? ModelBase<GameModeModel>.Instance.InstanceDungeon.Value.Id);
			this.IsInTrackRange = TrackData.IsInTrackRange.GetValueOrDefault();
			this.AutoHide = TrackData.AutoHideTrack.GetValueOrDefault();
			this.ConfigShowTime = (float)ConfigCommonParamById.GetIntConfig("QuestMarkTrackStayTime").GetValueOrDefault(10);
			this.Offset = (TrackData.Offset ?? global::Vector.Create());
			this.NiagaraDuration = 0f;
			this.CurNiagaraShowTime = 0f;
			this.NiagaraNeedActivateNextTick = false;
			this.IsSubTrack = TrackData.IsSubTrack.GetValueOrDefault();
			this.TrackType = TrackData.TrackType.GetValueOrDefault();
			if (this.TrackType == ETrackType.AudioHint)
			{
				this.IsForceHideDistance = true;
				this.IsForceHideDirection = true;
				this.IsForceNotPlayStartSeq = true;
				this.IsForceHideIcon = true;
				EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.MarkId);
				SceneItemNearbyTrackingComponent sceneItemNearbyTrackingComponent;
				if (entityById == null)
				{
					sceneItemNearbyTrackingComponent = null;
				}
				else
				{
					WorldEntity entity = entityById.Entity;
					sceneItemNearbyTrackingComponent = ((entity != null) ? entity.GetComponent<SceneItemNearbyTrackingComponent>() : null);
				}
				SceneItemNearbyTrackingComponent sceneItemNearbyTrackingComponent2 = sceneItemNearbyTrackingComponent;
				this.AudioNearRadius = (double)((float)((sceneItemNearbyTrackingComponent2 != null) ? sceneItemNearbyTrackingComponent2.AudioPointNearRadius : null).GetValueOrDefault() * 0.01f);
				this.AudioMiddleRadius = (double)((float)((sceneItemNearbyTrackingComponent2 != null) ? sceneItemNearbyTrackingComponent2.AudioPointMiddleRadius : null).GetValueOrDefault() * 0.01f);
				this.AudioFarRadius = (double)((float)((sceneItemNearbyTrackingComponent2 != null) ? sceneItemNearbyTrackingComponent2.AudioPointFarRadius : null).GetValueOrDefault() * 0.01f);
			}
			else
			{
				this.IsForceHideDistance = false;
				this.IsForceHideDirection = false;
				this.IsForceNotPlayStartSeq = false;
				this.IsForceHideIcon = false;
			}
			this.TempTrackPosition = global::Vector.Create();
			this.ScreenPosition = Vector2D.Create();
			this.LastScreenPosition = Vector2D.Create();
			this.TempRotator = global::Rotator.Create();
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			this.LimitA = Math.Min(1176f, (((uiRootItem != null) ? uiRootItem.GetWidth() : 0f) - 1008f) / 2f);
			this.LimitB = Math.Min(712.5f, (((uiRootItem != null) ? uiRootItem.GetHeight() : 0f) - 495f) / 2f);
			Singleton<EventSystem>.Instance.Add<ETrackSource, long, int, int, bool>(EEventName.TaskRangeTrackStateChange, new Action<ETrackSource, long, int, int, bool>(this.OnTaskRangeTrackStateChange));
		}

		// Token: 0x0603ECED RID: 257261 RVA: 0x01015DE8 File Offset: 0x01013FE8
		public virtual void Initialize(UUIItem parent)
		{
			base.CreateThenShowByResourceIdAsync("UiItem_TrackedMarkMain", parent, true).Forget();
		}

		// Token: 0x0603ECEE RID: 257262 RVA: 0x01015DFC File Offset: 0x01013FFC
		public void CreateMark()
		{
			this.FirstStartSequencePlaying = true;
			this.PlayTrackStartSequence(0f);
		}

		// Token: 0x0603ECEF RID: 257263 RVA: 0x01015E10 File Offset: 0x01014010
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickedTrackedButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603ECF0 RID: 257264 RVA: 0x0101606C File Offset: 0x0101426C
		protected override void OnStart()
		{
			this.DistanceComp = base.GetItem(4);
			this.DirectionComp = base.GetItem(2);
			this.IconComp = base.GetItem(6);
			this.DistanceComp.SetUIActive(false);
			this.DirectionComp.SetUIActive(!this.IsInTrackRange && !this.IsForceHideDirection);
			this.IconComp.SetUIActive(false);
			UUISprite sprite = base.GetSprite(7);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUISprite sprite2 = base.GetSprite(10);
			UUISprite sprite3 = base.GetSprite(8);
			UUISprite sprite4 = base.GetSprite(9);
			UUIItem item = base.GetItem(11);
			if (this.IsNewTrackExpress)
			{
				bool flag = string.IsNullOrEmpty(this.MarkRingPic);
				sprite2.SetUIActive(!flag);
				item.SetUIActive(!flag);
				if (!flag)
				{
					this.SetSpriteByPath(this.MarkRingPic, sprite2, false, null, null);
				}
				if (!string.IsNullOrEmpty(this.MarkRingColor))
				{
					FColor color = FColor.FromHex(this.MarkRingColor);
					sprite2.SetColor(color);
					item.SetColor(color);
				}
				bool flag2 = string.IsNullOrEmpty(this.LargeHaloColor);
				sprite3.SetUIActive(!flag2);
				if (!flag2)
				{
					sprite3.SetColor(FColor.FromHex(this.LargeHaloColor));
				}
				bool flag3 = string.IsNullOrEmpty(this.SmallHaloColor);
				sprite4.SetUIActive(!flag3);
				if (!flag3)
				{
					sprite4.SetColor(FColor.FromHex(this.SmallHaloColor));
				}
			}
			else
			{
				sprite3.SetUIActive(false);
				sprite4.SetUIActive(false);
				sprite2.SetUIActive(false);
				item.SetUIActive(false);
			}
			this.IconTextureLevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.IconTextureLevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceEvent), false);
			this.WaveNiagara = base.GetUiNiagara(5);
			this.WaveNiagara.SetUIActive(false);
			this.UpdateIcon(true);
			this.IconComp.SetUIActive(!this.IsInTrackRange && !this.IsForceHideIcon);
			if (this.TrackSource == ETrackSource.Quest)
			{
				UUIItem rootItem = this.RootItem;
				if (rootItem != null)
				{
					rootItem.SetHierarchyIndex(999);
				}
			}
			this.CreateMark();
			this.OnUiShow();
		}

		// Token: 0x0603ECF1 RID: 257265 RVA: 0x01016290 File Offset: 0x01014490
		protected override void OnBeforeDestroy()
		{
			this.TrackTarget = null;
			this.TaskTrackedMarkItem = null;
			LevelSequencePlayer iconTextureLevelSequencePlayer = this.IconTextureLevelSequencePlayer;
			if (iconTextureLevelSequencePlayer != null)
			{
				iconTextureLevelSequencePlayer.Clear();
			}
			this.IconTextureLevelSequencePlayer = null;
			if (TimerSystem.Instance.Has(this.DelayTrackSequenceTimerId))
			{
				TimerSystem.Instance.Remove(this.DelayTrackSequenceTimerId);
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.TaskRangeTrackStateChange, new Action<ETrackSource, long, int, int, bool>(this.OnTaskRangeTrackStateChange)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.TaskRangeTrackStateChange, new Action<ETrackSource, long, int, int, bool>(this.OnTaskRangeTrackStateChange));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnOnLogicTreeNodeStatusChange)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnOnLogicTreeNodeStatusChange));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnQuestTrackUpdate)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnQuestTrackUpdate));
			}
		}

		// Token: 0x0603ECF2 RID: 257266 RVA: 0x01016394 File Offset: 0x01014594
		public virtual void OnUiShow()
		{
			if (this.TrackType == ETrackType.AudioHint)
			{
				EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.MarkId);
				if (entityById != null && !Singleton<EventSystem>.Instance.HasWithTarget(entityById.Entity, EEventName.PlaySoundTrackEffect, new Action<float>(this.OnPlaySoundTrackEffect)))
				{
					Singleton<EventSystem>.Instance.AddWithTarget(entityById.Entity, EEventName.PlaySoundTrackEffect, new Action<float>(this.OnPlaySoundTrackEffect));
				}
			}
			this.DelayTrackSequenceTimerId = TimerSystem.Instance.Delay(new TTimerAction(this.PlayTrackStartSequence), 500f, null, null, true, 1f);
			if (!Singleton<EventSystem>.Instance.Has(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnOnLogicTreeNodeStatusChange)))
			{
				Singleton<EventSystem>.Instance.Add<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnOnLogicTreeNodeStatusChange));
			}
			if (!Singleton<EventSystem>.Instance.Has(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnQuestTrackUpdate)))
			{
				Singleton<EventSystem>.Instance.Add<BtType, long?>(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnQuestTrackUpdate));
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetRelativeScale3D(this.IsSubTrack ? new FVector(0.8f, 0.8f, 0.8f) : new FVector(1f, 1f, 1f));
			}
			this.UpdateUpStateSprite();
			this.UpdateDownStateSprite();
			this.UpdateGravity();
		}

		// Token: 0x0603ECF3 RID: 257267 RVA: 0x010164F4 File Offset: 0x010146F4
		public virtual void OnUiHide()
		{
			if (this.TrackType == ETrackType.AudioHint)
			{
				EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.MarkId);
				if (entityById != null && Singleton<EventSystem>.Instance.HasWithTarget(entityById.Entity, EEventName.PlaySoundTrackEffect, new Action<float>(this.OnPlaySoundTrackEffect)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(entityById.Entity, EEventName.PlaySoundTrackEffect, new Action<float>(this.OnPlaySoundTrackEffect));
				}
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnOnLogicTreeNodeStatusChange)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnOnLogicTreeNodeStatusChange));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnQuestTrackUpdate)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnQuestTrackUpdate));
			}
		}

		// Token: 0x0603ECF4 RID: 257268 RVA: 0x010165D8 File Offset: 0x010147D8
		private void OnClickedTrackedButton()
		{
			if (ModelBase<TrackModel>.Instance.IsForceCloseTracked())
			{
				return;
			}
			global::Vector trackPositionByTrackTarget = MapUtil.GetTrackPositionByTrackTarget(this.TrackTarget, true, null, null, true);
			if (trackPositionByTrackTarget == null)
			{
				return;
			}
			ControllerBase<BattleUiControl>.Instance.FocusToTargetLocation(trackPositionByTrackTarget);
		}

		// Token: 0x0603ECF5 RID: 257269 RVA: 0x01016619 File Offset: 0x01014819
		private void SequenceEvent(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				this.FirstStartSequencePlaying = false;
				return;
			}
			if (sequenceName == "Close")
			{
				UUIItem rootItem = this.RootItem;
				if (rootItem == null)
				{
					return;
				}
				rootItem.SetUIActive(false);
			}
		}

		// Token: 0x0603ECF6 RID: 257270 RVA: 0x0101664E File Offset: 0x0101484E
		public void UpdateTrackTarget(in TTrackTarget trackTarget)
		{
			this.TrackTarget = trackTarget;
		}

		// Token: 0x0603ECF7 RID: 257271 RVA: 0x01016658 File Offset: 0x01014858
		private void UpdateIcon(bool force = false)
		{
			string text = (this.IsNewTrackExpress && !string.IsNullOrEmpty(this.MarkIconPic)) ? this.MarkIconPic : this.IconPath;
			bool flag = force || text != this.IconPath;
			this.IconPath = text;
			if (flag && !string.IsNullOrEmpty(this.IconPath))
			{
				this.SetSpriteByPath(this.IconPath, base.GetSprite(0), false, null, null);
			}
		}

		// Token: 0x0603ECF8 RID: 257272 RVA: 0x010166D0 File Offset: 0x010148D0
		public void UpdateUpStateSprite()
		{
			UUISprite sprite = base.GetSprite(14);
			bool flag = ModelBase<MapModel>.Instance.GetMarkExtraShowState(this.MarkId).ShowFlag == MapMarkShowFlag.ShowDisable;
			InstanceDungeon? instanceDungeon;
			int? num = (ModelBase<GameModeModel>.Instance.InstanceDungeon != null) ? new int?(instanceDungeon.GetValueOrDefault().MapConfigId) : null;
			int? relativeId = this.GetRelativeId();
			int? relativeDungeonId = this.GetRelativeDungeonId();
			bool flag2 = false;
			if (num != null)
			{
				TTrackTarget_Int ttrackTarget_Int = this.TrackTarget as TTrackTarget_Int;
				if (ttrackTarget_Int != null)
				{
					flag2 = ModelBase<MapModel>.Instance.IsMarkHideByServer(num.Value, ttrackTarget_Int.Value);
				}
			}
			if (relativeId != null && relativeDungeonId != null)
			{
				flag2 |= ModelBase<LevelPlayReportModel>.Instance.IsCommonLevelPlayHide(relativeDungeonId.Value, relativeId.Value);
			}
			bool isDisable = flag || flag2;
			bool isGameplayFinish = this.MarkType == EMarkType.CommonGamePlay && MarkItemDataUtil.IsCommonGamePlayMarkComplete(this.MarkId);
			string markTopRightIconPath = MarkItemDataUtil.GetMarkTopRightIconPath(this.MarkId, this.MarkType, isDisable, isGameplayFinish);
			if (!string.IsNullOrEmpty(markTopRightIconPath))
			{
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				if (sprite != null)
				{
					this.SetSpriteByPath(markTopRightIconPath, sprite, false, null, null);
					return;
				}
			}
			else if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
		}

		// Token: 0x0603ECF9 RID: 257273 RVA: 0x01016818 File Offset: 0x01014A18
		private int? GetRelativeId()
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(this.MarkId);
			if (configMark != null)
			{
				return new int?(configMark.Value.RelativeId);
			}
			return null;
		}

		// Token: 0x0603ECFA RID: 257274 RVA: 0x01016860 File Offset: 0x01014A60
		private int? GetRelativeDungeonId()
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(this.MarkId);
			if (configMark != null)
			{
				return new int?(configMark.Value.RelativeDungeonId);
			}
			return null;
		}

		// Token: 0x0603ECFB RID: 257275 RVA: 0x010168A8 File Offset: 0x01014AA8
		public void UpdateDownStateSprite()
		{
			UUISprite sprite = base.GetSprite(13);
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(this.MarkId);
			bool flag = false;
			int[] array = ((configMark != null) ? configMark.GetValueOrDefault().GetConnetMultiMapFloorIdArray() : null) ?? Array.Empty<int>();
			bool flag2 = configMark != null && configMark.GetValueOrDefault().MultiMapFloorId == 0 && array.Length != 0;
			int num = 0;
			if (configMark != null)
			{
				if (configMark.Value.MultiMapFloorId == 0 && array.Length != 0)
				{
					num = array[0];
				}
				else
				{
					num = configMark.Value.MultiMapFloorId;
				}
			}
			bool flag3 = false;
			if (num != 0 || flag2)
			{
				flag = true;
				int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(null);
				MultiMap? subMapConfigById = ConfigBase<MapConfig>.Instance.GetSubMapConfigById(num);
				if (subMapConfigById != null && subMapConfigById.Value.GetAreaArray().Contains(currentAreaId))
				{
					flag3 = true;
				}
			}
			if (!flag)
			{
				if (sprite != null)
				{
					sprite.SetUIActive(false);
					return;
				}
			}
			else
			{
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(flag3 ? "SP_MarkMultiMapSelect" : "SP_MarkMultiMap");
				if (sprite != null)
				{
					this.SetSpriteByPath(resourcePath, sprite, false, null, null);
				}
			}
		}

		// Token: 0x0603ECFC RID: 257276 RVA: 0x01016A04 File Offset: 0x01014C04
		public void UpdateGravity()
		{
			InstanceDungeon? instanceDungeon;
			int? num = (ModelBase<GameModeModel>.Instance.InstanceDungeon != null) ? new int?(instanceDungeon.GetValueOrDefault().MapConfigId) : null;
			UUISprite sprite = base.GetSprite(7);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			if (num == null)
			{
				return;
			}
			if (!ModelBase<WorldMapModel>.Instance.IsGravityMap(num.Value))
			{
				return;
			}
			EMapGravityDirection markMapGravity = ModelBase<MapModel>.Instance.GetMarkMapGravity(this.MarkId, this.MarkType);
			if (markMapGravity == EMapGravityDirection.All)
			{
				return;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath((markMapGravity == EMapGravityDirection.Down) ? "SP_OverviewDown" : "SP_OverviewUp");
			bool flag = ModelBase<MapModel>.Instance.CurrentPlayerGravity == markMapGravity;
			if (sprite != null)
			{
				sprite.SetUIActive(true);
				this.SetSpriteByPath(resourcePath, sprite, false, null, null);
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAlpha(flag ? 1f : 0.4f);
		}

		// Token: 0x0603ECFD RID: 257277 RVA: 0x01016AFB File Offset: 0x01014CFB
		public void SetVisibleByOccupied(bool bOccupied)
		{
			this.IsOccupied = bOccupied;
		}

		// Token: 0x0603ECFE RID: 257278 RVA: 0x01016B04 File Offset: 0x01014D04
		public void SetVisibleByInteractionSpotOccupied(bool bOccupied)
		{
			this.IsOccupiedByInteractionSpot = bOccupied;
		}

		// Token: 0x0603ECFF RID: 257279 RVA: 0x01016B10 File Offset: 0x01014D10
		public void UpdateTrackDistance()
		{
			global::Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
			if (playerLocation == null)
			{
				return;
			}
			MapUtil.GetTrackPositionByTrackTarget(this.TrackTarget, true, this.TempTrackPosition, new int?(this.TrackInstanceId), true);
			if (!this.Offset.Equals(global::Vector.ZeroVectorProxy, 9.999999747378752E-05))
			{
				TTrackTarget_AActor ttrackTarget_AActor = this.TrackTarget as TTrackTarget_AActor;
				if (ttrackTarget_AActor != null && ttrackTarget_AActor.Value.IsValid())
				{
					global::Vector vector = global::Vector.Create();
					global::Vector vector2 = vector;
					FTransformDouble ftransformDouble = ttrackTarget_AActor.Value.D_GetTransform();
					FVectorDouble fvectorDouble = this.Offset.ToUeVector(false);
					FVectorDouble fvectorDouble2 = ftransformDouble.TransformPositionNoScale(fvectorDouble);
					vector2.FromUeVector(fvectorDouble2);
					this.TempTrackPosition = vector;
				}
			}
			double trackDistance = global::Vector.Distance(playerLocation, this.TempTrackPosition) * 0.009999999776482582;
			this.TrackDistance = trackDistance;
			ModelBase<TrackModel>.Instance.UpdateGroupMinDistance(this.ShowGroupId.GetValueOrDefault(0), trackDistance);
		}

		// Token: 0x0603ED00 RID: 257280 RVA: 0x01016BF4 File Offset: 0x01014DF4
		public unsafe virtual void Update(float delta)
		{
			if (GlobalData.World == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Map, ELogAuthor.LYX, "【疑难杂症】标记固定在屏幕中心，GameWorld为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (Singleton<UiLayer>.Instance.UiRootItem == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Map, ELogAuthor.LYX, "【疑难杂症】标记固定在屏幕中心，RootItem为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.RootItem == null)
			{
				return;
			}
			TaskTrackedMarkItem taskTrackedMarkItem = this.TaskTrackedMarkItem;
			if (taskTrackedMarkItem != null)
			{
				taskTrackedMarkItem.Update();
			}
			double trackDistance = this.TrackDistance;
			float? num;
			double? num2;
			if (!this.AlreadyCancelTrack)
			{
				num = this.TrackAutoCancelDistance;
				num2 = ((num != null) ? new double?((double)num.GetValueOrDefault()) : null);
				double num3 = trackDistance;
				if (num2.GetValueOrDefault() >= num3 & num2 != null)
				{
					if (this.MarkType != EMarkType.None)
					{
						MapController instance = ControllerBase<MapController>.Instance;
						TrackMapMarkParams trackMapMarkParams = new TrackMapMarkParams();
						trackMapMarkParams.MarkType = this.MarkType;
						trackMapMarkParams.MarkId = this.MarkId;
						trackMapMarkParams.Track = false;
						Action<ETrackMapMarkResultType, bool> resultCallBack;
						if ((resultCallBack = TrackedMark.<>O.<0>__ResultFunction) == null)
						{
							resultCallBack = (TrackedMark.<>O.<0>__ResultFunction = new Action<ETrackMapMarkResultType, bool>(TrackedMark.<Update>g__ResultFunction|91_0));
						}
						instance.RequestTrackMapMark(trackMapMarkParams, resultCallBack);
						this.AlreadyCancelTrack = true;
					}
					else
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Map;
						ELogAuthor author = ELogAuthor.LYX;
						string message = "[追踪标记]->自动取消标记追踪失败，请检查配置或是否逻辑漏传参数";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MarkType", this.MarkType);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MarkId", this.MarkId);
						instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
				}
			}
			this.CurShowTime += delta / 1000f;
			bool flag = this.IsShowTrackingMark();
			bool flag2 = flag != this.IsShowTrackingMarkCurrent;
			this.IsShowTrackingMarkCurrent = flag;
			if (!this.IsShowTrackingMarkCurrent)
			{
				this.SetRootItemState(false);
				return;
			}
			if (flag2)
			{
				this.UpdateIcon(false);
			}
			double num4 = trackDistance;
			num = this.MarkHideDis;
			num2 = ((num != null) ? new double?((double)num.GetValueOrDefault()) : null);
			if ((num4 < num2.GetValueOrDefault() & num2 != null) && !this.FirstStartSequencePlaying)
			{
				this.RootItem.SetUIActive(false);
				if (this.TrackType == ETrackType.AudioHint)
				{
					this.StopWaveNiagara();
				}
				return;
			}
			this.SetRootItemState(true);
			this.UpdatePositionAndRotation(delta);
			UUIItem item = base.GetItem(4);
			if (this.InRange && !this.IsInTrackRange && !this.IsForceHideDistance)
			{
				int num5 = (int)Math.Round(trackDistance);
				if (this.TrackDistanceDisplay != num5)
				{
					this.TrackDistanceDisplay = num5;
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_Meter_Text", new <>z__ReadOnlySingleElementList<object>(this.TrackDistanceDisplay.ToString()));
				}
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUISprite sprite = base.GetSprite(12);
				if (sprite != null)
				{
					sprite.SetUIActive(ModelBase<AutoPilotModel>.Instance.GetIsTracking(this.MarkId));
				}
			}
			else
			{
				if (item != null)
				{
					item.SetUIActive(false);
				}
				UUISprite sprite2 = base.GetSprite(12);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(false);
				}
			}
			if (this.TrackType == ETrackType.AudioHint)
			{
				this.UpdateAudioHintDisplay(delta);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!this.IsInTrackRange && !this.IsForceHideIcon);
		}

		// Token: 0x0603ED01 RID: 257281 RVA: 0x01016F28 File Offset: 0x01015128
		protected virtual void UpdatePositionAndRotation(float delta)
		{
			TsCharacterController characterController = Global.CharacterController;
			FVectorDouble fvectorDouble = this.TempTrackPosition.ToUeVector(false);
			bool flag = UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble, ref this.ScreenPositionRef, false);
			if (!flag)
			{
				FTransformDouble value = ModelBase<CameraModel>.Instance.MainModel.CameraTransform.Value;
				FVectorDouble fvectorDouble2 = value.InverseTransformPositionNoScale(fvectorDouble);
				fvectorDouble2.X = -fvectorDouble2.X;
				FVectorDouble fvectorDouble3 = value.TransformPositionNoScale(fvectorDouble2);
				UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble3, ref this.ScreenPositionRef, false);
			}
			FVector2D screenPositionRef = this.ScreenPositionRef;
			this.ScreenPosition.Set((double)screenPositionRef.X, (double)screenPositionRef.Y);
			if (!this.LastScreenPosition.Equals(this.ScreenPosition, 1.0) || this.NiagaraNeedActivateNextTick)
			{
				this.LastScreenPosition.DeepCopy(this.ScreenPosition);
				BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
				this.ScreenPosition.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset).MultiplyEqual(this.PointTransport);
				this.InRange = this.ClampToEllipse(this.ScreenPosition, flag);
				Vector2D vector2D = this.ScreenPosition.AdditionEqual(TrackDefine.center);
				this.RootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
				UUIItem item = base.GetItem(2);
				if (!this.InRange && !this.IsInTrackRange && !this.IsForceHideDirection)
				{
					this.TempRotator.Reset();
					this.TempRotator.Yaw = (float)(Math.Atan2(this.ScreenPosition.Y, this.ScreenPosition.X) * 57.2957763671875);
					if (item != null)
					{
						UUIItem uuiitem = item;
						FRotator frotator = this.TempRotator.ToUeRotator();
						uuiitem.SetUIRelativeRotation(frotator);
					}
					if (item != null)
					{
						item.SetUIActive(true);
					}
				}
				else if (item != null)
				{
					item.SetUIActive(false);
				}
				UUINiagara uiNiagara = base.GetUiNiagara(5);
				if (!this.InRange && this.TrackType == ETrackType.AudioHint)
				{
					float value2 = (float)(Math.Atan2(this.ScreenPosition.Y, this.ScreenPosition.X) / 6.283185307179586);
					if (uiNiagara != null)
					{
						uiNiagara.SetNiagaraVarFloat("Rotation", value2);
						return;
					}
				}
				else if (uiNiagara != null)
				{
					uiNiagara.SetNiagaraVarFloat("Rotation", 0.25f);
				}
			}
		}

		// Token: 0x0603ED02 RID: 257282 RVA: 0x01017164 File Offset: 0x01015364
		public Vector2D MoveTowards(Vector2D current, Vector2D target, float speed)
		{
			double num = target.X - current.X;
			double num2 = target.Y - current.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			float num4 = (float)Math.Atan2(num2, num);
			float num5 = speed * Math.Abs(num3) / (num3 + 1f);
			return new Vector2D(current.X + (double)(num5 * (float)Math.Cos((double)num4)), current.Y + (double)(num5 * (float)Math.Sin((double)num4)));
		}

		// Token: 0x0603ED03 RID: 257283 RVA: 0x010171E4 File Offset: 0x010153E4
		private bool IsShowTrackingMark()
		{
			global::Vector tempTrackPosition = this.TempTrackPosition;
			if (tempTrackPosition != null && tempTrackPosition.IsNearlyZero(9.999999747378752E-05))
			{
				return false;
			}
			if (this.IsOccupied || this.IsOccupiedByInteractionSpot)
			{
				return false;
			}
			if (this.AutoHide && this.CurShowTime > this.ConfigShowTime)
			{
				return false;
			}
			if (this.TaskTrackedMarkItem != null && this.TaskTrackedMarkItem.TargetInDiffWorld())
			{
				return false;
			}
			if (!ModelBase<TrackModel>.Instance.CanShowInGroup(this.ShowGroupId.GetValueOrDefault(0), this.TrackDistance) || !this.ShouldShowTrackMark)
			{
				return false;
			}
			TTrackTarget_Int ttrackTarget_Int = this.TrackTarget as TTrackTarget_Int;
			if (ttrackTarget_Int != null && !ModelBase<CreatureModel>.Instance.CheckEntityVisible(ttrackTarget_Int.Value))
			{
				return false;
			}
			if (ControllerBase<GameModeController>.Instance.IsInInstance() && !ModelBase<RecallQuestModel>.Instance.IsInRecallInstance())
			{
				bool flag = false;
				foreach (ETrackSource type in this.TrackMarkSourceTypeList)
				{
					flag = (flag || ModelBase<TrackModel>.Instance.IsTracking(type, this.MarkId));
					if (flag)
					{
						break;
					}
				}
				return flag;
			}
			return ModelBase<TrackModel>.Instance.IsTracking(this.TrackSource, this.MarkId);
		}

		// Token: 0x0603ED04 RID: 257284 RVA: 0x01017304 File Offset: 0x01015504
		protected bool ClampToEllipse(Vector2D vector, bool inFront)
		{
			double x = vector.X;
			double y = vector.Y;
			float limitA = this.LimitA;
			float limitB = this.LimitB;
			if (inFront && x * x / (double)(limitA * limitA) + y * y / (double)(limitB * limitB) <= 1.0)
			{
				return true;
			}
			float num = limitA * limitB / (float)Math.Sqrt((double)(limitB * limitB) * x * x + (double)(limitA * limitA) * y * y);
			vector.MultiplyEqual((double)num);
			return false;
		}

		// Token: 0x0603ED05 RID: 257285 RVA: 0x01017376 File Offset: 0x01015576
		private void OnQuestTrackUpdate(BtType contextType, long? _)
		{
			if ((contextType != BtType.Quest && contextType != BtType.Recall) || this.IsInTrackRange)
			{
				return;
			}
			this.PlayTrackStartSequence(0f);
		}

		// Token: 0x0603ED06 RID: 257286 RVA: 0x01017394 File Offset: 0x01015594
		private void OnOnLogicTreeNodeStatusChange(GeneralContext context, NodeStatus oldStatus, NodeStatus newStatus, ENodeStatusUpdateReason reason)
		{
			GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
			if (generalLogicTreeContext == null)
			{
				return;
			}
			if (generalLogicTreeContext.BtType != BtType.Quest && generalLogicTreeContext.BtType != BtType.Recall)
			{
				return;
			}
			this.PlayTrackStartSequence(0f);
		}

		// Token: 0x0603ED07 RID: 257287 RVA: 0x010173CC File Offset: 0x010155CC
		private void OnPlaySoundTrackEffect(float effectDuration)
		{
			if (this.TrackType != ETrackType.AudioHint)
			{
				return;
			}
			if (effectDuration <= 0f)
			{
				return;
			}
			if (!this.RootItem.IsUIActiveSelf())
			{
				return;
			}
			this.StopWaveNiagara();
			this.NiagaraDuration = effectDuration / 1000f;
			this.CurNiagaraShowTime = 0f;
			this.NiagaraNeedActivateNextTick = true;
		}

		// Token: 0x0603ED08 RID: 257288 RVA: 0x01017420 File Offset: 0x01015620
		private void PlayTrackStartSequence(float _ = 0f)
		{
			if (this.IconTextureLevelSequencePlayer == null)
			{
				return;
			}
			string text = this.IsWeakTrackExpress ? "TrackB" : "TrackA";
			if (!this.IsNewTrackExpress)
			{
				text = "TrackC";
			}
			string currentSequence = this.IconTextureLevelSequencePlayer.GetCurrentSequence();
			if (this.IsForceNotPlayStartSeq)
			{
				if (currentSequence == text)
				{
					this.IconTextureLevelSequencePlayer.StopCurrentSequence(true, true);
					return;
				}
				this.IconTextureLevelSequencePlayer.PlayLevelSequenceByName(text, false, null, false);
				this.IconTextureLevelSequencePlayer.StopCurrentSequence(true, true);
				return;
			}
			else
			{
				if (currentSequence == text)
				{
					return;
				}
				if (this.IconComp.bIsUIActive)
				{
					this.CurShowTime = 0f;
					this.IconTextureLevelSequencePlayer.PlayLevelSequenceByName(text, false, null, false);
				}
				return;
			}
		}

		// Token: 0x0603ED09 RID: 257289 RVA: 0x010174E2 File Offset: 0x010156E2
		private void OnTaskRangeTrackStateChange(ETrackSource trackSource, long treeIncId, int behaviorId, int markId, bool rangeImageActive)
		{
			if (trackSource != this.TrackSource || markId != this.MarkId)
			{
				return;
			}
			this.IsInTrackRange = rangeImageActive;
			UUIItem iconComp = this.IconComp;
			if (iconComp == null)
			{
				return;
			}
			iconComp.SetUIActive(!rangeImageActive);
		}

		// Token: 0x0603ED0A RID: 257290 RVA: 0x01017518 File Offset: 0x01015718
		private void UpdateAudioHintDisplay(float delta)
		{
			if (this.TrackType != ETrackType.AudioHint)
			{
				return;
			}
			if (!this.WaveNiagara.IsUIActiveSelf() && !this.NiagaraNeedActivateNextTick)
			{
				return;
			}
			if (this.NiagaraNeedActivateNextTick)
			{
				this.NiagaraNeedActivateNextTick = false;
				this.WaveNiagara.SetNiagaraVarFloat("LifeTime", this.NiagaraDuration);
				if (this.TrackDistance <= this.AudioNearRadius)
				{
					this.WaveNiagara.SetNiagaraVarFloat("Scale", 1f);
					UUINiagara waveNiagara = this.WaveNiagara;
					string varName = "Color";
					FColor fcolor = FColor.FromHex("86FF83");
					waveNiagara.SetNiagaraVarLinearColor(varName, new FLinearColor(ref fcolor));
				}
				else if (this.TrackDistance > this.AudioNearRadius && this.TrackDistance <= this.AudioMiddleRadius)
				{
					this.WaveNiagara.SetNiagaraVarFloat("Scale", 0.6666667f);
					UUINiagara waveNiagara2 = this.WaveNiagara;
					string varName2 = "Color";
					FColor fcolor = FColor.FromHex("FFE683");
					waveNiagara2.SetNiagaraVarLinearColor(varName2, new FLinearColor(ref fcolor));
				}
				else if (this.TrackDistance > this.AudioMiddleRadius && this.TrackDistance <= this.AudioFarRadius)
				{
					this.WaveNiagara.SetNiagaraVarFloat("Scale", 0.33333334f);
					UUINiagara waveNiagara3 = this.WaveNiagara;
					string varName3 = "Color";
					FColor fcolor = FColor.FromHex("FFFFFF");
					waveNiagara3.SetNiagaraVarLinearColor(varName3, new FLinearColor(ref fcolor));
				}
				this.WaveNiagara.SetUIActive(true);
			}
			if (this.CurNiagaraShowTime >= this.NiagaraDuration)
			{
				this.StopWaveNiagara();
				return;
			}
			this.CurNiagaraShowTime += delta / 1000f;
		}

		// Token: 0x0603ED0B RID: 257291 RVA: 0x01017694 File Offset: 0x01015894
		private void StopWaveNiagara()
		{
			this.WaveNiagara.SetUIActive(false);
			this.NiagaraDuration = 0f;
			this.CurNiagaraShowTime = 0f;
			this.NiagaraNeedActivateNextTick = false;
		}

		// Token: 0x0603ED0C RID: 257292 RVA: 0x010176C0 File Offset: 0x010158C0
		private void SetRootItemState(bool bActive)
		{
			if (this.RootItem == null)
			{
				return;
			}
			if (this.RootItem.IsUIActiveSelf() == bActive)
			{
				return;
			}
			if (bActive)
			{
				this.RootItem.SetUIActive(true);
				this.PlayTrackStartSequence(0f);
				return;
			}
			if (this.TrackDistanceDisplay < 0)
			{
				this.RootItem.SetUIActive(false);
				return;
			}
			LevelSequencePlayer iconTextureLevelSequencePlayer = this.IconTextureLevelSequencePlayer;
			if (iconTextureLevelSequencePlayer == null)
			{
				return;
			}
			iconTextureLevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		}

		// Token: 0x0603ED0D RID: 257293 RVA: 0x01017736 File Offset: 0x01015936
		[CompilerGenerated]
		internal static void <Update>g__ResultFunction|91_0(ETrackMapMarkResultType result, bool track)
		{
			if (result == ETrackMapMarkResultType.Success)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MapTrackingCanceled_Text", Array.Empty<object>());
			}
		}

		// Token: 0x0402339D RID: 144285
		private const string WAVE_COLOR_NEAR = "86FF83";

		// Token: 0x0402339E RID: 144286
		private const string WAVE_COLOR_MIDDLE = "FFE683";

		// Token: 0x0402339F RID: 144287
		private const string WAVE_COLOR_FAR = "FFFFFF";

		// Token: 0x040233A0 RID: 144288
		private const string VARNAME_WAVE_CYCLE_TIME = "LifeTime";

		// Token: 0x040233A1 RID: 144289
		private const string VARNAME_WAVE_NUM_SCALE = "Scale";

		// Token: 0x040233A2 RID: 144290
		private const string VARNAME_WAVE_COLOR = "Color";

		// Token: 0x040233A3 RID: 144291
		private const string VARNAME_WAVE_ROTATION = "Rotation";

		// Token: 0x040233A4 RID: 144292
		private const string TRACKA = "TrackA";

		// Token: 0x040233A5 RID: 144293
		private const string TRACKB = "TrackB";

		// Token: 0x040233A6 RID: 144294
		private const string TRACKC = "TrackC";

		// Token: 0x040233A7 RID: 144295
		private const int DELAY_TIME = 500;

		// Token: 0x040233A8 RID: 144296
		private const float SUB_SCALE = 0.8f;

		// Token: 0x040233A9 RID: 144297
		private const int QUEST_TRACK_MARK_INDEX = 999;

		// Token: 0x040233AA RID: 144298
		[Nullable(2)]
		public TTrackTarget TrackTarget;

		// Token: 0x040233AB RID: 144299
		private readonly int TrackInstanceId;

		// Token: 0x040233AC RID: 144300
		protected readonly bool IsSubTrack;

		// Token: 0x040233AD RID: 144301
		private readonly float? TrackAutoCancelDistance;

		// Token: 0x040233AE RID: 144302
		private bool AlreadyCancelTrack;

		// Token: 0x040233AF RID: 144303
		private bool IsOccupied;

		// Token: 0x040233B0 RID: 144304
		private bool IsOccupiedByInteractionSpot;

		// Token: 0x040233B1 RID: 144305
		private string IconPath = string.Empty;

		// Token: 0x040233B2 RID: 144306
		private readonly float LimitA;

		// Token: 0x040233B3 RID: 144307
		private readonly float LimitB;

		// Token: 0x040233B4 RID: 144308
		protected FVector2D ScreenPositionRef = new FVector2D();

		// Token: 0x040233B5 RID: 144309
		protected FVector2D PointTransport = new FVector2D(1f, -1f);

		// Token: 0x040233B6 RID: 144310
		protected readonly float? MarkHideDis = new float?(0f);

		// Token: 0x040233B7 RID: 144311
		private readonly int? ShowGroupId = new int?(0);

		// Token: 0x040233B8 RID: 144312
		private readonly int MarkId;

		// Token: 0x040233B9 RID: 144313
		private readonly EMarkType MarkType;

		// Token: 0x040233BA RID: 144314
		private readonly ETrackSource TrackSource;

		// Token: 0x040233BB RID: 144315
		[Nullable(2)]
		private TimerHandle DelayTrackSequenceTimerId;

		// Token: 0x040233BC RID: 144316
		protected bool IsInTrackRange;

		// Token: 0x040233BD RID: 144317
		[Nullable(2)]
		protected global::Vector TempTrackPosition;

		// Token: 0x040233BE RID: 144318
		[Nullable(2)]
		protected readonly Vector2D ScreenPosition;

		// Token: 0x040233BF RID: 144319
		[Nullable(2)]
		protected readonly Vector2D LastScreenPosition;

		// Token: 0x040233C0 RID: 144320
		protected bool InRange;

		// Token: 0x040233C1 RID: 144321
		[Nullable(2)]
		protected readonly global::Rotator TempRotator;

		// Token: 0x040233C2 RID: 144322
		private double TrackDistance;

		// Token: 0x040233C3 RID: 144323
		private int TrackDistanceDisplay = -1;

		// Token: 0x040233C4 RID: 144324
		public bool ShouldShowTrackMark = true;

		// Token: 0x040233C5 RID: 144325
		[Nullable(2)]
		private LevelSequencePlayer IconTextureLevelSequencePlayer;

		// Token: 0x040233C6 RID: 144326
		private readonly global::Vector Offset = global::Vector.Create();

		// Token: 0x040233C7 RID: 144327
		private readonly bool AutoHide;

		// Token: 0x040233C8 RID: 144328
		private bool FirstStartSequencePlaying;

		// Token: 0x040233C9 RID: 144329
		[Nullable(2)]
		private UUIItem DistanceComp;

		// Token: 0x040233CA RID: 144330
		[Nullable(2)]
		protected UUIItem DirectionComp;

		// Token: 0x040233CB RID: 144331
		[Nullable(2)]
		private UUIItem IconComp;

		// Token: 0x040233CC RID: 144332
		[Nullable(2)]
		private UUINiagara WaveNiagara;

		// Token: 0x040233CD RID: 144333
		protected bool NiagaraNeedActivateNextTick;

		// Token: 0x040233CE RID: 144334
		private float NiagaraDuration;

		// Token: 0x040233CF RID: 144335
		private float CurNiagaraShowTime;

		// Token: 0x040233D0 RID: 144336
		protected float CurShowTime;

		// Token: 0x040233D1 RID: 144337
		private readonly float ConfigShowTime;

		// Token: 0x040233D2 RID: 144338
		private readonly bool IsForceHideDistance;

		// Token: 0x040233D3 RID: 144339
		protected readonly bool IsForceHideDirection;

		// Token: 0x040233D4 RID: 144340
		private readonly bool IsForceHideIcon;

		// Token: 0x040233D5 RID: 144341
		private readonly bool IsForceNotPlayStartSeq;

		// Token: 0x040233D6 RID: 144342
		private readonly ETrackType TrackType;

		// Token: 0x040233D7 RID: 144343
		private readonly double AudioNearRadius;

		// Token: 0x040233D8 RID: 144344
		private readonly double AudioMiddleRadius;

		// Token: 0x040233D9 RID: 144345
		private readonly double AudioFarRadius;

		// Token: 0x040233DA RID: 144346
		[Nullable(2)]
		private TaskTrackedMarkItem TaskTrackedMarkItem;

		// Token: 0x040233DB RID: 144347
		private bool IsShowTrackingMarkCurrent;

		// Token: 0x040233DC RID: 144348
		private readonly bool IsWeakTrackExpress;

		// Token: 0x040233DD RID: 144349
		private readonly bool IsNewTrackExpress;

		// Token: 0x040233DE RID: 144350
		[Nullable(2)]
		private readonly string MarkRingPic;

		// Token: 0x040233DF RID: 144351
		[Nullable(2)]
		private readonly string MarkIconPic;

		// Token: 0x040233E0 RID: 144352
		[Nullable(2)]
		private readonly string MarkRingColor;

		// Token: 0x040233E1 RID: 144353
		[Nullable(2)]
		private readonly string SmallHaloColor;

		// Token: 0x040233E2 RID: 144354
		[Nullable(2)]
		private readonly string LargeHaloColor;

		// Token: 0x040233E3 RID: 144355
		private readonly ETrackSource[] TrackMarkSourceTypeList = new ETrackSource[]
		{
			ETrackSource.Instance,
			ETrackSource.SceneGameplay,
			ETrackSource.NearbyTrack
		};

		// Token: 0x0200C2AA RID: 49834
		[NullableContext(0)]
		private enum ETrackedMark
		{
			// Token: 0x0403C03E RID: 245822
			Icon,
			// Token: 0x0403C03F RID: 245823
			Distance,
			// Token: 0x0403C040 RID: 245824
			Direction,
			// Token: 0x0403C041 RID: 245825
			TrackedButton,
			// Token: 0x0403C042 RID: 245826
			DistanceItem,
			// Token: 0x0403C043 RID: 245827
			WaveNiagara,
			// Token: 0x0403C044 RID: 245828
			PanelIcon,
			// Token: 0x0403C045 RID: 245829
			SpriteOverview,
			// Token: 0x0403C046 RID: 245830
			SpriteLightB,
			// Token: 0x0403C047 RID: 245831
			SpriteLightA,
			// Token: 0x0403C048 RID: 245832
			SpriteCircle,
			// Token: 0x0403C049 RID: 245833
			PanelCircle,
			// Token: 0x0403C04A RID: 245834
			SpiteDistance,
			// Token: 0x0403C04B RID: 245835
			SpriteStateDown,
			// Token: 0x0403C04C RID: 245836
			SpriteStateUp
		}

		// Token: 0x0200C2AB RID: 49835
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403C04D RID: 245837
			[Nullable(0)]
			public static Action<ETrackMapMarkResultType, bool> <0>__ResultFunction;
		}
	}
}
