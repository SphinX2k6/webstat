using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006825 RID: 26661
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingShipData
	{
		// Token: 0x06042793 RID: 272275 RVA: 0x0110EC50 File Offset: 0x0110CE50
		public void RefreshData(FishingShipInfo info)
		{
			this.CurrentSkinId = info.SkinId;
			this.IsSailingInternal = info.IsSailing;
			this.IsInPortInternal = info.IsInPort;
			this.CreatureDataId = info.EntityId;
			this.LastPortId = info.LastPortId;
			this.RefreshShipEntity(this.CreatureDataId);
		}

		// Token: 0x06042794 RID: 272276 RVA: 0x0110ECA5 File Offset: 0x0110CEA5
		public void SetLastPortId(int portId)
		{
			this.LastPortId = portId;
		}

		// Token: 0x06042795 RID: 272277 RVA: 0x0110ECAE File Offset: 0x0110CEAE
		public void SetIsInPortInternal(bool isInPortInternal)
		{
			this.IsInPortInternal = isInPortInternal;
		}

		// Token: 0x06042796 RID: 272278 RVA: 0x0110ECB8 File Offset: 0x0110CEB8
		public void RefreshShipEntity(long creatureDataId)
		{
			if (creatureDataId != this.CreatureDataId)
			{
				return;
			}
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.CreatureDataId);
			WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
			if (entity != null && entity.Valid)
			{
				int id = entity.Id;
				if (worldEntity != null && worldEntity.IsStart)
				{
					int num = id;
					EntityHandle entityHandle = this.EntityHandle;
					int? num2 = (entityHandle != null) ? new int?(entityHandle.Id) : null;
					if (!(num == num2.GetValueOrDefault() & num2 != null))
					{
						this.ClearShipEntity(ERemoveEntityType.RemoveTypeForce, null);
						this.EntityHandle = entity;
						this.AttributeComp = worldEntity.GetComponent<BaseAttributeComponent>();
						BaseActorComponent component = worldEntity.GetComponent<BaseActorComponent>();
						AActor aactor = (component != null) ? component.Owner : null;
						if (aactor != null && aactor.IsValid())
						{
							GlobalData.BpEventManager.当捕鱼船创建时.Broadcast(aactor);
						}
						Singleton<EventSystem>.Instance.Emit(EEventName.FishingShipDataRefresh);
						BaseVehiclePerformComponent component2 = worldEntity.GetComponent<BaseVehiclePerformComponent>();
						EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
						WorldEntity worldEntity2 = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
						bool isDriving = false;
						if (component2 != null && worldEntity2 != null)
						{
							isDriving = component2.IsDriver(worldEntity2);
						}
						this.RefreshDriveFishingShipState(isDriving);
						Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(entity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.ClearShipEntity));
						Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(worldEntity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
						Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(worldEntity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnLeaveVehicle));
						this.CreateShipMark(this.EntityHandle);
					}
				}
			}
		}

		// Token: 0x06042797 RID: 272279 RVA: 0x0110EE4C File Offset: 0x0110D04C
		private void CreateShipMark(EntityHandle entityHandle)
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
				int ownerId = ModelBase<OnlineModel>.Instance.OwnerId;
				if (!(id.GetValueOrDefault() == ownerId & id != null))
				{
					return;
				}
			}
			FishingShipMarkCreateInfo info = new FishingShipMarkCreateInfo(new DynamicMarkCreateParams
			{
				TrackTarget = entityHandle.Id,
				MarkConfigId = 8,
				MarkType = EMarkType.FishingShip,
				TrackSource = new ETrackSource?(ETrackSource.MapMark),
				EntityConfigId = new int?(entityHandle.PbDataId),
				MapAndDungeonInfo = new MapAndDungeonInfo
				{
					MapConfigId = new int?(8)
				}
			});
			ModelBase<MapModel>.Instance.RemoveMapMarkByType(EMarkType.FishingShip);
			ModelBase<MapModel>.Instance.CreateMapMark(info);
		}

		// Token: 0x06042798 RID: 272280 RVA: 0x0110EF08 File Offset: 0x0110D108
		private void ClearShipEntity(ERemoveEntityType _1 = ERemoveEntityType.RemoveTypeForce, EntityHandle _2 = null)
		{
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle != null && Singleton<EventSystem>.Instance.HasWithTarget<ERemoveEntityType, EntityHandle>(entityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.ClearShipEntity)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<ERemoveEntityType, EntityHandle>(entityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.ClearShipEntity));
				ModelBase<MapModel>.Instance.SyncLocalShipLocationToCacheInfo();
				ModelBase<MapModel>.Instance.RemoveMapMarkByType(EMarkType.FishingShip);
				ModelBase<MapModel>.Instance.TryRecreateShipMark();
			}
			if (entityHandle != null && entityHandle.Entity != null)
			{
				if (Singleton<EventSystem>.Instance.HasWithTarget<VehiclePassengerInfo, bool>(entityHandle.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(entityHandle.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
				}
				if (Singleton<EventSystem>.Instance.HasWithTarget<VehiclePassengerInfo, bool>(entityHandle.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnLeaveVehicle)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(entityHandle.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnLeaveVehicle));
				}
			}
			this.RefreshDriveFishingShipState(false);
			this.EntityHandle = null;
			this.AttributeComp = null;
		}

		// Token: 0x06042799 RID: 272281 RVA: 0x0110F02A File Offset: 0x0110D22A
		private void OnEnterVehicle(VehiclePassengerInfo _, bool byChangeRole)
		{
			this.RefreshDriveFishingShipState(true);
		}

		// Token: 0x0604279A RID: 272282 RVA: 0x0110F033 File Offset: 0x0110D233
		private void OnLeaveVehicle(VehiclePassengerInfo _, bool byChangeRole)
		{
			this.RefreshDriveFishingShipState(false);
		}

		// Token: 0x0604279B RID: 272283 RVA: 0x0110F03C File Offset: 0x0110D23C
		private void RefreshDriveFishingShipState(bool isDriving)
		{
			this.IsDrivingInternal = isDriving;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.DriveFishingShipStateChanged, isDriving);
		}

		// Token: 0x0604279C RID: 272284 RVA: 0x0110F056 File Offset: 0x0110D256
		public long GetCreatureDataId()
		{
			return this.CreatureDataId;
		}

		// Token: 0x0604279D RID: 272285 RVA: 0x0110F060 File Offset: 0x0110D260
		[NullableContext(2)]
		public EntityHandle GetEntityHandle()
		{
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle != null && entityHandle.Valid)
			{
				return entityHandle;
			}
			return null;
		}

		// Token: 0x0604279E RID: 272286 RVA: 0x0110F082 File Offset: 0x0110D282
		public float GetCurrentHp()
		{
			BaseAttributeComponent attributeComp = this.AttributeComp;
			if (attributeComp == null)
			{
				return 0f;
			}
			return attributeComp.GetCurrentValue(EAttributeType.Life);
		}

		// Token: 0x0604279F RID: 272287 RVA: 0x0110F09A File Offset: 0x0110D29A
		public float GetMaxHp()
		{
			BaseAttributeComponent attributeComp = this.AttributeComp;
			if (attributeComp == null)
			{
				return 0f;
			}
			return attributeComp.GetCurrentValue(EAttributeType.LifeMax);
		}

		// Token: 0x060427A0 RID: 272288 RVA: 0x0110F0B2 File Offset: 0x0110D2B2
		public int GetCurrentSkinId()
		{
			return this.CurrentSkinId;
		}

		// Token: 0x060427A1 RID: 272289 RVA: 0x0110F0BA File Offset: 0x0110D2BA
		public void AddAttributeListener(EAttributeType attrId, Action<EAttributeType, float, float> callback)
		{
			BaseAttributeComponent attributeComp = this.AttributeComp;
			if (attributeComp == null)
			{
				return;
			}
			attributeComp.AddListener(attrId, callback, null);
		}

		// Token: 0x060427A2 RID: 272290 RVA: 0x0110F0CF File Offset: 0x0110D2CF
		public void RemoveAttributeListener(EAttributeType attrId, Action<EAttributeType, float, float> callback)
		{
			BaseAttributeComponent attributeComp = this.AttributeComp;
			if (attributeComp == null)
			{
				return;
			}
			attributeComp.RemoveListener(attrId, callback);
		}

		// Token: 0x060427A3 RID: 272291 RVA: 0x0110F0E4 File Offset: 0x0110D2E4
		public float GetAttributeValue(EAttributeType attrId)
		{
			BaseAttributeComponent attributeComp = this.AttributeComp;
			if (attributeComp == null)
			{
				return 0f;
			}
			return attributeComp.GetCurrentValue(attrId);
		}

		// Token: 0x060427A4 RID: 272292 RVA: 0x0110F0FC File Offset: 0x0110D2FC
		public bool IsShipInPort()
		{
			return this.IsInPortInternal;
		}

		// Token: 0x060427A5 RID: 272293 RVA: 0x0110F104 File Offset: 0x0110D304
		public bool IsShipSailing()
		{
			return this.IsSailingInternal;
		}

		// Token: 0x060427A6 RID: 272294 RVA: 0x0110F10C File Offset: 0x0110D30C
		public bool IsShipDriving()
		{
			return this.IsDrivingInternal;
		}

		// Token: 0x060427A7 RID: 272295 RVA: 0x0110F114 File Offset: 0x0110D314
		public int GetLastPortId()
		{
			return this.LastPortId;
		}

		// Token: 0x0402500A RID: 151562
		private int CurrentSkinId = 1;

		// Token: 0x0402500B RID: 151563
		private bool IsInPortInternal;

		// Token: 0x0402500C RID: 151564
		private bool IsSailingInternal;

		// Token: 0x0402500D RID: 151565
		private bool IsDrivingInternal;

		// Token: 0x0402500E RID: 151566
		private long CreatureDataId;

		// Token: 0x0402500F RID: 151567
		[Nullable(2)]
		private EntityHandle EntityHandle;

		// Token: 0x04025010 RID: 151568
		[Nullable(2)]
		private BaseAttributeComponent AttributeComp;

		// Token: 0x04025011 RID: 151569
		private int LastPortId;
	}
}
