using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.VehicleStream.StateMachineContainer;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047E6 RID: 18406
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneBulletComponent : EntityComponent
	{
		// Token: 0x0602FBD2 RID: 195538 RVA: 0x00B6EA78 File Offset: 0x00B6CC78
		protected override bool OnInitData(IEntityArgs args = null)
		{
			this.CacheRange = global::Vector.Create(0.0, 0.0, 0.0);
			this.CacheOffset = global::Vector.Create(0.0, 0.0, 0.0);
			this.BulletState = new Dictionary<int, List<BulletData>>();
			SceneBulletComponent sceneBulletComponent = args.GetP1<CreateEntityData>().GetParam<SceneBulletComponent>() as SceneBulletComponent;
			foreach (ISceneBulletGroup sceneBulletGroup in sceneBulletComponent.BulletGroups)
			{
				int tagIdByName = GameplayTagUtils.GetTagIdByName(sceneBulletGroup.EntityState);
				if (!this.BulletState.ContainsKey(tagIdByName))
				{
					this.BulletState[tagIdByName] = new List<BulletData>();
				}
				this.BulletState.GetValueOrDefault(tagIdByName).Add(new BulletData(sceneBulletGroup, global::Transform.Create()));
			}
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			EntityComponentPb entityComponentPb = (component != null) ? component.ComponentDataMap.GetValueOrDefault("EntityBulletComponentPb") : null;
			long? contextMessageId;
			if (entityComponentPb == null)
			{
				contextMessageId = null;
			}
			else
			{
				EntityBulletComponentPb entityBulletComponentPb = entityComponentPb.EntityBulletComponentPb;
				contextMessageId = ((entityBulletComponentPb != null) ? new long?(entityBulletComponentPb.ContextId) : null);
			}
			this.ContextMessageId = contextMessageId;
			this.DisableGenerateByRange = sceneBulletComponent.DisableGenerateByRange.GetValueOrDefault();
			this.RoadNetworkComp = base.Entity.GetComponent<CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent>();
			Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.HandleUpdateState));
			return true;
		}

		// Token: 0x0602FBD3 RID: 195539 RVA: 0x00B6EC18 File Offset: 0x00B6CE18
		protected override bool OnStart()
		{
			CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent component = base.Entity.GetComponent<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>();
			if (!this.DisableGenerateByRange && component != null)
			{
				this.RangeComp = component;
				this.RangeComp.AddOnEntityOverlapCallback(new Action<bool, EntityHandle>(this.OnEntityTrigger));
			}
			else
			{
				this.IsPermanentBullet = true;
			}
			LevelTagComponent component2 = base.Entity.GetComponent<LevelTagComponent>();
			foreach (int num in this.BulletState.Keys)
			{
				if (component2.HasTag(num))
				{
					this.CurrentState = num;
					break;
				}
			}
			return true;
		}

		// Token: 0x0602FBD4 RID: 195540 RVA: 0x00B6ECC8 File Offset: 0x00B6CEC8
		protected override void OnActivate()
		{
			this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
			this.IsInitComplete = true;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null) != null && ModelBase<GameModeModel>.Instance.WorldDone)
			{
				if (this.IsPermanentBullet)
				{
					this.CreateBullets(this.CurrentState);
					return;
				}
			}
			else if (this.IsPermanentBullet)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			}
		}

		// Token: 0x0602FBD5 RID: 195541 RVA: 0x00B6ED45 File Offset: 0x00B6CF45
		private void OnWorldDone()
		{
			this.CreateBullets(this.CurrentState);
		}

		// Token: 0x0602FBD6 RID: 195542 RVA: 0x00B6ED54 File Offset: 0x00B6CF54
		[NullableContext(1)]
		private void OnEntityTrigger(bool isEnter, EntityHandle handle)
		{
			WorldEntity entity = handle.Entity;
			if (!this.IsInitComplete || entity == null)
			{
				return;
			}
			if (entity.GetComponent<CharacterHitComponent>() == null && entity.GetComponent<SceneItemHitComponent>() == null)
			{
				return;
			}
			this.IsEnterTrigger = isEnter;
			if (!isEnter)
			{
				foreach (int state in this.BulletState.Keys)
				{
					this.DestroyBullets(state);
				}
				return;
			}
			this.CreateBullets(this.CurrentState);
		}

		// Token: 0x0602FBD7 RID: 195543 RVA: 0x00B6EDE8 File Offset: 0x00B6CFE8
		protected override void OnTick(float delta)
		{
			this.ProcessTrafficBullet();
		}

		// Token: 0x0602FBD8 RID: 195544 RVA: 0x00B6EDF0 File Offset: 0x00B6CFF0
		private void ProcessTrafficBullet()
		{
			if (!ModelBase<GameModeModel>.Instance.WorldDone)
			{
				return;
			}
			if (this.BulletState == null || this.RoadNetworkComp == null)
			{
				return;
			}
			VehicleTeamMember vehicleTeamMember = this.RoadNetworkComp.GetVehicleTeamMember();
			if (vehicleTeamMember == null)
			{
				return;
			}
			List<BulletData> valueOrDefault = this.BulletState.GetValueOrDefault(this.CurrentState);
			if (valueOrDefault == null || valueOrDefault.Count == 0)
			{
				return;
			}
			foreach (BulletData bulletData in valueOrDefault)
			{
				ISceneBulletGroup bulletGroup = bulletData.BulletGroup;
				ITrafficBulletLogic trafficBulletLogic = (bulletGroup != null) ? bulletGroup.CustomBulletLogic : null;
				if (trafficBulletLogic != null && trafficBulletLogic.Type == ECustomBulletLogic.TrafficBullet)
				{
					bool flag = vehicleTeamMember.GetSpeed() >= trafficBulletLogic.MinSpeed;
					bool flag2 = this.RoadNetworkComp.IsInPerceptionRange();
					if (flag && flag2)
					{
						if (bulletData.BulletEntityId == null)
						{
							this.CreateBullet(bulletData);
						}
					}
					else
					{
						this.DestroyBullet(bulletData);
					}
				}
			}
		}

		// Token: 0x0602FBD9 RID: 195545 RVA: 0x00B6EEE8 File Offset: 0x00B6D0E8
		private void CreateBullets(int state)
		{
			if (this.BulletState == null)
			{
				return;
			}
			List<BulletData> valueOrDefault = this.BulletState.GetValueOrDefault(state);
			if (valueOrDefault == null || valueOrDefault.Count == 0)
			{
				return;
			}
			foreach (BulletData bulletData in valueOrDefault)
			{
				if (bulletData.BulletEntityId == null)
				{
					ISceneBulletGroup bulletGroup = bulletData.BulletGroup;
					bool flag;
					if (bulletGroup == null)
					{
						flag = false;
					}
					else
					{
						ITrafficBulletLogic customBulletLogic = bulletGroup.CustomBulletLogic;
						ECustomBulletLogic? ecustomBulletLogic = (customBulletLogic != null) ? new ECustomBulletLogic?(customBulletLogic.Type) : null;
						ECustomBulletLogic ecustomBulletLogic2 = ECustomBulletLogic.TrafficBullet;
						flag = (ecustomBulletLogic.GetValueOrDefault() == ecustomBulletLogic2 & ecustomBulletLogic != null);
					}
					if (flag)
					{
						if (this.RoadNetworkComp == null)
						{
							continue;
						}
						VehicleTeamMember vehicleTeamMember = this.RoadNetworkComp.GetVehicleTeamMember();
						if (vehicleTeamMember == null || vehicleTeamMember.GetSpeed() < bulletData.BulletGroup.CustomBulletLogic.MinSpeed)
						{
							continue;
						}
					}
					if (this.CreateBullet(bulletData) && Singleton<EventSystem>.Instance.Has(EEventName.WorldDone, new Action(this.OnWorldDone)))
					{
						Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
					}
				}
			}
		}

		// Token: 0x0602FBDA RID: 195546 RVA: 0x00B6F020 File Offset: 0x00B6D220
		[NullableContext(1)]
		private unsafe bool CreateBullet(BulletData bulletData)
		{
			if (bulletData.BulletEntityId != null)
			{
				return false;
			}
			this.CreateBulletTransform(bulletData);
			ISceneBulletGroup bulletGroup = bulletData.BulletGroup;
			global::Transform bulletTransform = bulletData.BulletTransform;
			BulletController.BulletCreateParams bulletCreateParams = null;
			if (bulletGroup.Range != null)
			{
				this.CacheRange.Set((double)bulletGroup.Range.X.GetValueOrDefault(), (double)bulletGroup.Range.Y.GetValueOrDefault(), (double)bulletGroup.Range.Z.GetValueOrDefault());
				bulletCreateParams = new BulletController.BulletCreateParams
				{
					Size = this.CacheRange
				};
			}
			EntityHandle sceneBulletOwner = ControllerBase<BulletController>.Instance.GetSceneBulletOwner();
			if (sceneBulletOwner == null || !sceneBulletOwner.IsInit)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "Bullet生成错误, 找不到场景子弹owner";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityID", base.Entity.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			BulletEntity bulletEntity = ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(sceneBulletOwner.Entity, bulletGroup.BulletId.ToString(), new FTransformDouble?(bulletTransform.ToUeTransform()), bulletCreateParams ?? new BulletController.BulletCreateParams(), this.ContextMessageId, global::EBulletCreateSource.Others);
			object obj;
			if (bulletEntity == null)
			{
				obj = null;
			}
			else
			{
				BulletActorComponent component = bulletEntity.GetComponent<BulletActorComponent>();
				obj = ((component != null) ? component.Owner : null);
			}
			object obj2 = obj;
			if (obj2 != null && obj2.IsValid())
			{
				EAttachmentRule value = EAttachmentRule.KeepWorld;
				BulletActionInfoAttachActor bulletActionInfoAttachActor = ControllerBase<BulletController>.Instance.GetActionCenter().CreateBulletActionInfo(EBulletAction.AttachActor) as BulletActionInfoAttachActor;
				bulletActionInfoAttachActor.IsParentActor = true;
				bulletActionInfoAttachActor.Actor = this.ActorComp.Owner;
				bulletActionInfoAttachActor.LocationRule = new EAttachmentRule?(value);
				bulletActionInfoAttachActor.RotationRule = new EAttachmentRule?(value);
				bulletActionInfoAttachActor.ScaleRule = new EAttachmentRule?(value);
				bulletActionInfoAttachActor.WeldSimulatedBodies = false;
				ControllerBase<BulletController>.Instance.GetActionRunner().AddAction(bulletEntity.GetBulletInfo(), bulletActionInfoAttachActor);
			}
			bulletData.BulletEntityId = ((bulletEntity != null) ? new int?(bulletEntity.Id) : null);
			if (bulletEntity == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.CWZ;
				string message2 = "Bullet生成错误";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BulletID", bulletGroup.BulletId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前Bullet的EntityState", bulletGroup.EntityState);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityID", base.Entity.Id);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			return bulletEntity != null && bulletEntity.Valid;
		}

		// Token: 0x0602FBDB RID: 195547 RVA: 0x00B6F2B0 File Offset: 0x00B6D4B0
		private void DestroyBullets(int state)
		{
			if (!this.BulletState.ContainsKey(state) || this.BulletState.GetValueOrDefault(state).Count == 0)
			{
				return;
			}
			foreach (BulletData bulletData in this.BulletState.GetValueOrDefault(state))
			{
				this.DestroyBullet(bulletData);
			}
		}

		// Token: 0x0602FBDC RID: 195548 RVA: 0x00B6F32C File Offset: 0x00B6D52C
		[NullableContext(1)]
		private bool DestroyBullet(BulletData bulletData)
		{
			if (bulletData.BulletEntityId == null)
			{
				return false;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(bulletData.BulletEntityId.Value);
			if (entity != null && entity.Valid)
			{
				AActor owner = entity.GetComponent<BulletActorComponent>().Owner;
				if (owner != null)
				{
					owner.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
				}
			}
			ControllerBase<BulletController>.Instance.DestroyBullet(bulletData.BulletEntityId.Value, false, EBulletDestroyReason.Normal, false);
			bulletData.BulletEntityId = null;
			return true;
		}

		// Token: 0x0602FBDD RID: 195549 RVA: 0x00B6F3A8 File Offset: 0x00B6D5A8
		private void HandleUpdateState(int stateId, bool isReady)
		{
			this.CurrentState = stateId;
			if (this.IsInitComplete && isReady)
			{
				if (this.IsEnterTrigger || this.IsPermanentBullet)
				{
					this.CreateBullets(this.CurrentState);
				}
				foreach (int num in this.BulletState.Keys)
				{
					if (num != this.CurrentState)
					{
						this.DestroyBullets(num);
					}
				}
			}
		}

		// Token: 0x0602FBDE RID: 195550 RVA: 0x00B6F438 File Offset: 0x00B6D638
		[NullableContext(1)]
		private void CreateBulletTransform(BulletData bullet)
		{
			bullet.BulletTransform = global::Transform.Create();
			global::Transform bulletTransform = bullet.BulletTransform;
			FTransformDouble actorTransform = this.ActorComp.ActorTransform;
			bulletTransform.FromUeTransform(actorTransform);
			if (bullet.BulletGroup.Offset != null)
			{
				this.CacheOffset.Set((double)bullet.BulletGroup.Offset.X.GetValueOrDefault(), (double)bullet.BulletGroup.Offset.Y.GetValueOrDefault(), (double)bullet.BulletGroup.Offset.Z.GetValueOrDefault());
				bullet.BulletTransform.TransformPositionNoScale(this.CacheOffset, this.CacheOffset);
				bullet.BulletTransform.SetLocation(this.CacheOffset);
			}
		}

		// Token: 0x0602FBDF RID: 195551 RVA: 0x00B6F4F4 File Offset: 0x00B6D6F4
		protected override bool OnEnd()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDone, new Action(this.OnWorldDone)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			}
			CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent rangeComp = this.RangeComp;
			if (rangeComp != null)
			{
				rangeComp.RemoveOnEntityOverlapCallback(new Action<bool, EntityHandle>(this.OnEntityTrigger));
			}
			foreach (int state in this.BulletState.Keys)
			{
				this.DestroyBullets(state);
			}
			this.BulletState.Clear();
			this.IsInitComplete = false;
			this.IsEnterTrigger = false;
			return true;
		}

		// Token: 0x0602FBE0 RID: 195552 RVA: 0x00B6F5BC File Offset: 0x00B6D7BC
		protected override bool OnClear()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.HandleUpdateState)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.HandleUpdateState));
			}
			return true;
		}

		// Token: 0x0602FBE1 RID: 195553 RVA: 0x00B6F610 File Offset: 0x00B6D810
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneBulletComponent sceneBulletComponent = (SceneBulletComponent)componentTemplate;
			if (base.CanResetComponentProperty("IsInitComplete"))
			{
				this.IsInitComplete = sceneBulletComponent.IsInitComplete;
			}
			if (base.CanResetComponentProperty("IsEnterTrigger"))
			{
				this.IsEnterTrigger = sceneBulletComponent.IsEnterTrigger;
			}
			if (base.CanResetComponentProperty("CurrentState"))
			{
				this.CurrentState = sceneBulletComponent.CurrentState;
			}
			if (base.CanResetComponentProperty("CacheOffset"))
			{
				if (sceneBulletComponent.CacheOffset == null)
				{
					this.CacheOffset = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CacheOffset), "CacheOffset"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CacheRange"))
			{
				if (sceneBulletComponent.CacheRange == null)
				{
					this.CacheRange = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CacheRange), "CacheRange"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("BulletState"))
			{
				if (sceneBulletComponent.BulletState == null)
				{
					this.BulletState = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, List<BulletData>>>(this.BulletState), "BulletState"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RangeComp"))
			{
				if (sceneBulletComponent.RangeComp == null)
				{
					this.RangeComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>(this.RangeComp), "RangeComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneBulletComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RoadNetworkComp"))
			{
				if (sceneBulletComponent.RoadNetworkComp == null)
				{
					this.RoadNetworkComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent>(this.RoadNetworkComp), "RoadNetworkComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ContextMessageId"))
			{
				this.ContextMessageId = sceneBulletComponent.ContextMessageId;
			}
			if (base.CanResetComponentProperty("DisableGenerateByRange"))
			{
				this.DisableGenerateByRange = sceneBulletComponent.DisableGenerateByRange;
			}
			if (base.CanResetComponentProperty("IsPermanentBullet"))
			{
				this.IsPermanentBullet = sceneBulletComponent.IsPermanentBullet;
			}
			return true;
		}

		// Token: 0x0401B5B5 RID: 112053
		private bool IsInitComplete;

		// Token: 0x0401B5B6 RID: 112054
		private bool IsEnterTrigger;

		// Token: 0x0401B5B7 RID: 112055
		private int CurrentState;

		// Token: 0x0401B5B8 RID: 112056
		private global::Vector CacheOffset;

		// Token: 0x0401B5B9 RID: 112057
		private global::Vector CacheRange;

		// Token: 0x0401B5BA RID: 112058
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<int, List<BulletData>> BulletState;

		// Token: 0x0401B5BB RID: 112059
		private CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent RangeComp;

		// Token: 0x0401B5BC RID: 112060
		private BaseActorComponent ActorComp;

		// Token: 0x0401B5BD RID: 112061
		private CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent RoadNetworkComp;

		// Token: 0x0401B5BE RID: 112062
		private long? ContextMessageId;

		// Token: 0x0401B5BF RID: 112063
		private bool DisableGenerateByRange;

		// Token: 0x0401B5C0 RID: 112064
		private bool IsPermanentBullet;
	}
}
