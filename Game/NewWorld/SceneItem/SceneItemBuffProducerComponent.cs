using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Controller;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047EC RID: 18412
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemBuffProducerComponent : EntityComponent
	{
		// Token: 0x0602FC56 RID: 195670 RVA: 0x00B74A38 File Offset: 0x00B72C38
		protected override bool OnInitData(IEntityArgs args = null)
		{
			BuffProducerComponent buffProducerComponent = args.GetP1<CreateEntityData>().GetParam<SceneItemBuffProducerComponent>() as BuffProducerComponent;
			this.Config = buffProducerComponent;
			this.BuffId = buffProducerComponent.BuffId;
			switch (buffProducerComponent.AddBuffMode.Type)
			{
			case EBuffProducerMode.Adsorb:
				this.Direction = global::Vector.Create();
				this.LocationCache = global::Vector.Create();
				break;
			case EBuffProducerMode.FireBullet:
			{
				IFireBulletAddBuff fireBulletAddBuff = buffProducerComponent.AddBuffMode as IFireBulletAddBuff;
				this.BulletId = fireBulletAddBuff.BulletId.ToString();
				this.BulletOffset = global::Vector.Create((double)fireBulletAddBuff.BulletOffset.X.GetValueOrDefault(), (double)fireBulletAddBuff.BulletOffset.Y.GetValueOrDefault(), (double)fireBulletAddBuff.BulletOffset.Z.GetValueOrDefault());
				break;
			}
			}
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			EntityComponentPb entityComponentPb = (component != null) ? component.ComponentDataMap.GetValueOrDefault("BuffProducerComponentPb") : null;
			long? contextMessageId;
			if (entityComponentPb == null)
			{
				contextMessageId = null;
			}
			else
			{
				BuffProducerComponentPb buffProducerComponentPb = entityComponentPb.BuffProducerComponentPb;
				contextMessageId = ((buffProducerComponentPb != null) ? new long?(buffProducerComponentPb.ContextId) : null);
			}
			this.ContextMessageId = contextMessageId;
			return true;
		}

		// Token: 0x0602FC57 RID: 195671 RVA: 0x00B74B68 File Offset: 0x00B72D68
		protected unsafe override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			if (this.ActorComp == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneGameplay, ELogAuthor.CJH, "[BuffProducerComp] 组件初始化失败 Actor Component Undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.ConfigId = this.ActorComp.CreatureData.GetPbDataId();
			this.CommonTagComp = base.Entity.GetComponent<LevelTagComponent>();
			if (this.CommonTagComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.CJH;
				string message = "[BuffProducerComp] 组件初始化失败 实体缺少LevelTagComponent";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", this.ActorComp.CreatureData.GetCreatureDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.ConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PlayerId", this.ActorComp.CreatureData.GetPlayerId());
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return false;
			}
			this.StateComp = base.Entity.GetComponent<SceneItemStateComponent>();
			if (this.StateComp == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneGameplay;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[BuffProducerComp] 组件初始化失败 实体缺少SceneItemStateComponent";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureDataId", this.ActorComp.CreatureData.GetCreatureDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PbDataId", this.ConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("PlayerId", this.ActorComp.CreatureData.GetPlayerId());
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return false;
			}
			this.IsInRange = true;
			this.WorldOwner = true;
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
				int worldOwner = ModelBase<CreatureModel>.Instance.GetWorldOwner();
				if (!(id.GetValueOrDefault() == worldOwner & id != null))
				{
					this.WorldOwner = false;
					return true;
				}
			}
			this.RangeComp = base.Entity.GetComponent<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>();
			if (this.RangeComp != null)
			{
				this.IsInRange = false;
				this.RangeComp.AddOnPlayerOverlapCallback(new Action<bool>(this.OnPlayerTriggerCallback));
			}
			this.SelfState = this.StateComp.State;
			this.AddEvents();
			return true;
		}

		// Token: 0x0602FC58 RID: 195672 RVA: 0x00B74DD6 File Offset: 0x00B72FD6
		protected override void OnActivate()
		{
			if (!this.StateComp.IsInState(SceneItemStateComponent.ESceneItemState.Born))
			{
				this.OnSceneItemStateChange();
			}
		}

		// Token: 0x0602FC59 RID: 195673 RVA: 0x00B74DEC File Offset: 0x00B72FEC
		protected override void OnTick(float delta)
		{
			if (!this.WorldOwner || this.SelfState != SceneItemStateComponent.ESceneItemState.Active)
			{
				return;
			}
			if (this.IsInPerformance)
			{
				this.OnPerformanceUpdate(delta);
				return;
			}
			if (!this.IsInRange)
			{
				this.UndoApplyBuffToPlayer();
			}
		}

		// Token: 0x0602FC5A RID: 195674 RVA: 0x00B74E1E File Offset: 0x00B7301E
		protected override bool OnEnd()
		{
			if (this.RangeComp != null)
			{
				this.RangeComp.RemoveOnPlayerOverlapCallback(new Action<bool>(this.OnPlayerTriggerCallback));
			}
			this.RemoveEvents();
			return true;
		}

		// Token: 0x0602FC5B RID: 195675 RVA: 0x00B74E46 File Offset: 0x00B73046
		private void AddEvents()
		{
			if (this.EventsInited)
			{
				return;
			}
			Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
			this.EventsInited = true;
		}

		// Token: 0x0602FC5C RID: 195676 RVA: 0x00B74E7A File Offset: 0x00B7307A
		private void RemoveEvents()
		{
			if (!this.EventsInited)
			{
				return;
			}
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
			this.EventsInited = false;
		}

		// Token: 0x0602FC5D RID: 195677 RVA: 0x00B74EAE File Offset: 0x00B730AE
		private void OnPlayerTriggerCallback(bool isEnter)
		{
			this.IsInRange = isEnter;
			if (!this.WorldOwner || this.SelfState != SceneItemStateComponent.ESceneItemState.Active)
			{
				return;
			}
			if (!this.IsInRange)
			{
				this.UndoApplyBuffToPlayer();
			}
		}

		// Token: 0x0602FC5E RID: 195678 RVA: 0x00B74ED7 File Offset: 0x00B730D7
		private void OnSceneItemStateChange(int stateId, bool isReady)
		{
			this.OnSceneItemStateChange();
		}

		// Token: 0x0602FC5F RID: 195679 RVA: 0x00B74EE0 File Offset: 0x00B730E0
		private void OnSceneItemStateChange()
		{
			if (!this.WorldOwner)
			{
				return;
			}
			this.SelfState = this.StateComp.State;
			SceneItemStateComponent.ESceneItemState state = this.StateComp.State;
			if (state != SceneItemStateComponent.ESceneItemState.Normal)
			{
				if (state == SceneItemStateComponent.ESceneItemState.Active && !this.CheckPlayerHasBuff())
				{
					this.IsInPerformance = true;
					return;
				}
			}
			else
			{
				this.UndoApplyBuffToPlayer();
			}
		}

		// Token: 0x0602FC60 RID: 195680 RVA: 0x00B74F34 File Offset: 0x00B73134
		private void OnPerformanceUpdate(float delta)
		{
			BuffProducerComponent config = this.Config;
			EBuffProducerMode? ebuffProducerMode = (config != null) ? new EBuffProducerMode?(config.AddBuffMode.Type) : null;
			if (ebuffProducerMode != null)
			{
				switch (ebuffProducerMode.GetValueOrDefault())
				{
				case EBuffProducerMode.Immediate:
					this.OnPerformanceComplete();
					return;
				case EBuffProducerMode.Adsorb:
					this.FlyToPlayer(delta);
					return;
				case EBuffProducerMode.FireBullet:
					this.CreateBullet(delta);
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x0602FC61 RID: 195681 RVA: 0x00B74FA0 File Offset: 0x00B731A0
		private void OnPerformanceComplete()
		{
			this.IsInPerformance = false;
			this.ApplyBuffToPlayer();
		}

		// Token: 0x0602FC62 RID: 195682 RVA: 0x00B74FB0 File Offset: 0x00B731B0
		private bool CheckPlayerHasBuff()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return false;
			}
			Entity entity = baseCharacter.CharacterActorComponent.Entity;
			CharacterBuffComponent characterBuffComponent = entity.CheckGetComponent<CharacterBuffComponent>();
			if (characterBuffComponent == null)
			{
				return false;
			}
			bool flag = characterBuffComponent.GetBuffTotalStackById(this.BuffId, false) > 0;
			RoleBuffComponent roleBuffComponent = entity.CheckGetComponent<RoleBuffComponent>();
			if (roleBuffComponent != null)
			{
				bool flag2;
				if (!flag)
				{
					PlayerBuffComponent formationBuffComp = roleBuffComponent.GetFormationBuffComp();
					flag2 = (((formationBuffComp != null) ? formationBuffComp.GetBuffTotalStackById(this.BuffId, false) : 0) > 0);
				}
				else
				{
					flag2 = true;
				}
				flag = flag2;
			}
			return flag;
		}

		// Token: 0x0602FC63 RID: 195683 RVA: 0x00B75022 File Offset: 0x00B73222
		private void UndoApplyBuffToPlayer()
		{
			if (this.IsBusyOperatingBuff || !this.CheckPlayerHasBuff())
			{
				return;
			}
			this.IsBusyOperatingBuff = true;
			ControllerBase<SceneItemBuffController>.Instance.BuffOperate(base.Entity.Id, BuffOperateType.UndoBuff, new Action<BuffOperateType, bool>(this.OnBuffOperateCallBack));
		}

		// Token: 0x0602FC64 RID: 195684 RVA: 0x00B7505E File Offset: 0x00B7325E
		private void ApplyBuffToPlayer()
		{
			if (this.IsBusyOperatingBuff || this.CheckPlayerHasBuff())
			{
				return;
			}
			this.IsBusyOperatingBuff = true;
			ControllerBase<SceneItemBuffController>.Instance.BuffOperate(base.Entity.Id, BuffOperateType.AddBuff, new Action<BuffOperateType, bool>(this.OnBuffOperateCallBack));
		}

		// Token: 0x0602FC65 RID: 195685 RVA: 0x00B7509A File Offset: 0x00B7329A
		private void OnBuffOperateCallBack(BuffOperateType type, bool isSuccess)
		{
			this.IsBusyOperatingBuff = false;
		}

		// Token: 0x0602FC66 RID: 195686 RVA: 0x00B750A4 File Offset: 0x00B732A4
		private void FlyToPlayer(float delta)
		{
			if (Global.BaseCharacter == null)
			{
				return;
			}
			CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
			AActor owner = this.ActorComp.Owner;
			if (owner != null && owner.IsValid())
			{
				AActor owner2 = characterActorComponent.Owner;
				if (owner2 != null && owner2.IsValid())
				{
					float num = delta * 0.001f;
					global::Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
					characterActorComponent.ActorLocationProxy.Subtraction(actorLocationProxy, this.Direction);
					if (this.Direction.SizeSquared() < 100.0)
					{
						Aki.Protocol.Vector initLocation = this.ActorComp.CreatureData.GetInitLocation();
						this.LocationCache.X = (double)initLocation.X;
						this.LocationCache.Y = (double)initLocation.Y;
						this.LocationCache.Z = (double)initLocation.Z;
						this.ActorComp.SetActorLocation(this.LocationCache.ToUeVector(false), "unknown", true);
						this.Direction.DeepCopy(global::Vector.ZeroVectorProxy);
						this.LocationCache.DeepCopy(global::Vector.ZeroVectorProxy);
						this.OnPerformanceComplete();
						return;
					}
					this.Direction.Normalize(0.009999999776482582);
					this.Direction.MultiplyEqual((double)(600f * num));
					this.LocationCache.DeepCopy(this.ActorComp.ActorLocationProxy);
					this.LocationCache.AdditionEqual(this.Direction);
					this.ActorComp.SetActorLocation(this.LocationCache.ToUeVector(false), "unknown", true);
					return;
				}
			}
		}

		// Token: 0x0602FC67 RID: 195687 RVA: 0x00B75234 File Offset: 0x00B73434
		private void CreateBullet(float delta)
		{
			if (string.IsNullOrEmpty(this.BulletId))
			{
				return;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return;
			}
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			FTransformDouble actorTransform = this.ActorComp.ActorTransform;
			FQuat rotation = actorTransform.GetRotation();
			FVectorDouble fvectorDouble = actorTransform.GetTranslation();
			FVector scale3D = actorTransform.GetScale3D();
			FTransformDouble value = new FTransformDouble(ref rotation, ref fvectorDouble, ref scale3D);
			global::Vector vector = global::Vector.Create();
			global::Vector vector2 = vector;
			rotation = actorTransform.GetRotation();
			fvectorDouble = this.BulletOffset.ToUeVector(false);
			FVectorDouble fvectorDouble2 = rotation.RotateVectorDouble(fvectorDouble);
			vector2.DeepCopy(fvectorDouble2);
			fvectorDouble = vector.ToUeVector(false);
			value.AddToTranslation(fvectorDouble);
			this.BulletEntity = ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(characterActorComponent.Actor, this.BulletId, new FTransformDouble?(value), new BulletController.BulletCreateParams(), this.ContextMessageId, global::EBulletCreateSource.Others);
			this.TimerHandle = TimerSystem.Instance.Delay(new TTimerAction(this.OnBulletTimeOut), 5000f, null, null, true, 1f);
			Singleton<EventSystem>.Instance.AddWithTarget<global::HitInformation, IAttributeSet>(this.BulletEntity, EEventName.BulletHit, new Action<global::HitInformation, IAttributeSet>(this.OnBulletHit));
			this.IsInPerformance = false;
		}

		// Token: 0x0602FC68 RID: 195688 RVA: 0x00B75358 File Offset: 0x00B73558
		[NullableContext(1)]
		private void OnBulletHit(global::HitInformation hitData, [Nullable(2)] IAttributeSet attackerAttribute)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return;
			}
			Entity entity = baseCharacter.CharacterActorComponent.Entity;
			if (hitData.Target == entity)
			{
				if (this.TimerHandle != null)
				{
					TimerSystem.Instance.Remove(this.TimerHandle);
					this.TimerHandle = null;
				}
				Singleton<EventSystem>.Instance.RemoveWithTarget<global::HitInformation, IAttributeSet>(this.BulletEntity, EEventName.BulletHit, new Action<global::HitInformation, IAttributeSet>(this.OnBulletHit));
				this.BulletEntity = null;
				this.OnPerformanceComplete();
			}
		}

		// Token: 0x0602FC69 RID: 195689 RVA: 0x00B753D4 File Offset: 0x00B735D4
		private void OnBulletTimeOut(float delta)
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget<global::HitInformation, IAttributeSet>(this.BulletEntity, EEventName.BulletHit, new Action<global::HitInformation, IAttributeSet>(this.OnBulletHit)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<global::HitInformation, IAttributeSet>(this.BulletEntity, EEventName.BulletHit, new Action<global::HitInformation, IAttributeSet>(this.OnBulletHit));
			}
			this.TimerHandle = null;
			this.BulletEntity = null;
			this.OnPerformanceComplete();
		}

		// Token: 0x0602FC6A RID: 195690 RVA: 0x00B7543C File Offset: 0x00B7363C
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemBuffProducerComponent sceneItemBuffProducerComponent = (SceneItemBuffProducerComponent)componentTemplate;
			if (base.CanResetComponentProperty("ConfigId"))
			{
				this.ConfigId = sceneItemBuffProducerComponent.ConfigId;
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemBuffProducerComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CommonTagComp"))
			{
				if (sceneItemBuffProducerComponent.CommonTagComp == null)
				{
					this.CommonTagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.CommonTagComp), "CommonTagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StateComp"))
			{
				if (sceneItemBuffProducerComponent.StateComp == null)
				{
					this.StateComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemStateComponent>(this.StateComp), "StateComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RangeComp"))
			{
				if (sceneItemBuffProducerComponent.RangeComp == null)
				{
					this.RangeComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>(this.RangeComp), "RangeComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsInPerformance"))
			{
				this.IsInPerformance = sceneItemBuffProducerComponent.IsInPerformance;
			}
			if (base.CanResetComponentProperty("IsBusyOperatingBuff"))
			{
				this.IsBusyOperatingBuff = sceneItemBuffProducerComponent.IsBusyOperatingBuff;
			}
			if (base.CanResetComponentProperty("SelfState"))
			{
				this.SelfState = sceneItemBuffProducerComponent.SelfState;
			}
			if (base.CanResetComponentProperty("IsInRange"))
			{
				this.IsInRange = sceneItemBuffProducerComponent.IsInRange;
			}
			if (base.CanResetComponentProperty("EventsInited"))
			{
				this.EventsInited = sceneItemBuffProducerComponent.EventsInited;
			}
			if (base.CanResetComponentProperty("WorldOwner"))
			{
				this.WorldOwner = sceneItemBuffProducerComponent.WorldOwner;
			}
			if (base.CanResetComponentProperty("BuffId"))
			{
				this.BuffId = sceneItemBuffProducerComponent.BuffId;
			}
			if (base.CanResetComponentProperty("Config"))
			{
				if (sceneItemBuffProducerComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BuffProducerComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ContextMessageId"))
			{
				this.ContextMessageId = sceneItemBuffProducerComponent.ContextMessageId;
			}
			if (base.CanResetComponentProperty("Direction"))
			{
				if (sceneItemBuffProducerComponent.Direction == null)
				{
					this.Direction = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.Direction), "Direction"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LocationCache"))
			{
				if (sceneItemBuffProducerComponent.LocationCache == null)
				{
					this.LocationCache = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.LocationCache), "LocationCache"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("BulletOffset"))
			{
				if (sceneItemBuffProducerComponent.BulletOffset == null)
				{
					this.BulletOffset = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.BulletOffset), "BulletOffset"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("BulletId"))
			{
				this.BulletId = sceneItemBuffProducerComponent.BulletId;
			}
			if (base.CanResetComponentProperty("BulletEntity"))
			{
				if (sceneItemBuffProducerComponent.BulletEntity == null)
				{
					this.BulletEntity = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Entity>(this.BulletEntity), "BulletEntity"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TimerHandle"))
			{
				if (sceneItemBuffProducerComponent.TimerHandle == null)
				{
					this.TimerHandle = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.TimerHandle), "TimerHandle"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B608 RID: 112136
		private const float DISTANCE_THRESHOLD = 100f;

		// Token: 0x0401B609 RID: 112137
		private const float NORMALIZE = 0.01f;

		// Token: 0x0401B60A RID: 112138
		private const float SPEED = 600f;

		// Token: 0x0401B60B RID: 112139
		private const int MAX_BULLET_HIT_TIME = 5000;

		// Token: 0x0401B60C RID: 112140
		private int ConfigId;

		// Token: 0x0401B60D RID: 112141
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401B60E RID: 112142
		private LevelTagComponent CommonTagComp;

		// Token: 0x0401B60F RID: 112143
		private SceneItemStateComponent StateComp;

		// Token: 0x0401B610 RID: 112144
		private CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent RangeComp;

		// Token: 0x0401B611 RID: 112145
		private bool IsInPerformance;

		// Token: 0x0401B612 RID: 112146
		private bool IsBusyOperatingBuff;

		// Token: 0x0401B613 RID: 112147
		private SceneItemStateComponent.ESceneItemState SelfState = SceneItemStateComponent.ESceneItemState.Normal;

		// Token: 0x0401B614 RID: 112148
		private bool IsInRange = true;

		// Token: 0x0401B615 RID: 112149
		private bool EventsInited;

		// Token: 0x0401B616 RID: 112150
		private bool WorldOwner;

		// Token: 0x0401B617 RID: 112151
		private long BuffId;

		// Token: 0x0401B618 RID: 112152
		private BuffProducerComponent Config;

		// Token: 0x0401B619 RID: 112153
		private long? ContextMessageId;

		// Token: 0x0401B61A RID: 112154
		private global::Vector Direction;

		// Token: 0x0401B61B RID: 112155
		private global::Vector LocationCache;

		// Token: 0x0401B61C RID: 112156
		private global::Vector BulletOffset;

		// Token: 0x0401B61D RID: 112157
		[Nullable(1)]
		private string BulletId = "";

		// Token: 0x0401B61E RID: 112158
		private Entity BulletEntity;

		// Token: 0x0401B61F RID: 112159
		private TimerHandle TimerHandle;
	}
}
