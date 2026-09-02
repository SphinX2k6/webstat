using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Core.World;
using AkiClient.Game.Aki.GamePlay.Portal;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x020048FD RID: 18685
	[NullableContext(2)]
	[Nullable(0)]
	public class BaseSceneInteractComponent : EntityComponent
	{
		// Token: 0x06030CA4 RID: 199844 RVA: 0x00C0F908 File Offset: 0x00C0DB08
		public bool GetIsHooking()
		{
			return this.IsHooking;
		}

		// Token: 0x06030CA5 RID: 199845 RVA: 0x00C0F910 File Offset: 0x00C0DB10
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
			this.ExploreComponent = base.Entity.GetComponent<BaseExploreComponent>();
			return true;
		}

		// Token: 0x17008326 RID: 33574
		// (get) Token: 0x06030CA6 RID: 199846 RVA: 0x00C0F938 File Offset: 0x00C0DB38
		// (set) Token: 0x06030CA7 RID: 199847 RVA: 0x00C0F981 File Offset: 0x00C0DB81
		protected HookPointInfo CurrentInteractingTarget
		{
			get
			{
				GrapplingHookPointComponent interactingTarget = this.ExploreComponent.InteractingTarget;
				if (interactingTarget == null)
				{
					return null;
				}
				if (this.CurrentInteractingTargetWrapper == null)
				{
					this.CurrentInteractingTargetWrapper = new HookPointInfo(interactingTarget, 0L, true);
				}
				else
				{
					this.CurrentInteractingTargetWrapper.Point = interactingTarget;
				}
				return this.CurrentInteractingTargetWrapper;
			}
			set
			{
				this.ExploreComponent.InteractingTarget = ((value != null) ? value.Point : null);
			}
		}

		// Token: 0x06030CA8 RID: 199848 RVA: 0x00C0F99A File Offset: 0x00C0DB9A
		public GrapplingHookPointComponent GetCurrentTarget()
		{
			HookPointInfo currentInteractingTarget = this.CurrentInteractingTarget;
			if (currentInteractingTarget == null)
			{
				return null;
			}
			return currentInteractingTarget.Point;
		}

		// Token: 0x06030CA9 RID: 199849 RVA: 0x00C0F9AD File Offset: 0x00C0DBAD
		public AActor GetCurrentTargetActor()
		{
			HookPointInfo currentInteractingTarget = this.CurrentInteractingTarget;
			if (currentInteractingTarget == null)
			{
				return null;
			}
			BaseActorComponent component = currentInteractingTarget.Point.Entity.GetComponent<BaseActorComponent>();
			if (component == null)
			{
				return null;
			}
			return component.Owner;
		}

		// Token: 0x06030CAA RID: 199850 RVA: 0x00C0F9D5 File Offset: 0x00C0DBD5
		public bool GetInheritSpeed()
		{
			return this.CurrentInteractingTarget.Point.InheritSpeed;
		}

		// Token: 0x06030CAB RID: 199851 RVA: 0x00C0F9E7 File Offset: 0x00C0DBE7
		public bool GetIsClimb()
		{
			return this.CurrentInteractingTarget.Point.IsClimb;
		}

		// Token: 0x06030CAC RID: 199852 RVA: 0x00C0F9FC File Offset: 0x00C0DBFC
		public BP_KuroPortalCapture_C GetCurrentTargetEnterPortalCapture()
		{
			HookPointInfo currentInteractingTarget = this.CurrentInteractingTarget;
			if (((currentInteractingTarget != null) ? currentInteractingTarget.Point : null) == null || currentInteractingTarget.PortalPairId == 0L)
			{
				return null;
			}
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			SceneItemPortalComponent sceneItemPortalComponent;
			if (instance == null)
			{
				sceneItemPortalComponent = null;
			}
			else
			{
				EntityHandle entity = instance.GetEntity(currentInteractingTarget.PortalPairId);
				if (entity == null)
				{
					sceneItemPortalComponent = null;
				}
				else
				{
					WorldEntity entity2 = entity.Entity;
					sceneItemPortalComponent = ((entity2 != null) ? entity2.GetComponent<SceneItemPortalComponent>() : null);
				}
			}
			SceneItemPortalComponent sceneItemPortalComponent2 = sceneItemPortalComponent;
			if (sceneItemPortalComponent2 == null)
			{
				return null;
			}
			BP_KuroPortalCapture_C bp_KuroPortalCapture_C = (sceneItemPortalComponent2 != null) ? sceneItemPortalComponent2.PortalCapture : null;
			if (currentInteractingTarget.PortalA2B)
			{
				return bp_KuroPortalCapture_C;
			}
			BP_KuroPortalCapture_C result = null;
			if (bp_KuroPortalCapture_C != null)
			{
				bp_KuroPortalCapture_C.GetPair(ref result);
			}
			return result;
		}

		// Token: 0x06030CAD RID: 199853 RVA: 0x00C0FA84 File Offset: 0x00C0DC84
		public BP_KuroPortalCapture_C GetCurrentTargetExitPortalCapture()
		{
			HookPointInfo currentInteractingTarget = this.CurrentInteractingTarget;
			if (((currentInteractingTarget != null) ? currentInteractingTarget.Point : null) == null || currentInteractingTarget.PortalPairId == 0L)
			{
				return null;
			}
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			SceneItemPortalComponent sceneItemPortalComponent;
			if (instance == null)
			{
				sceneItemPortalComponent = null;
			}
			else
			{
				EntityHandle entity = instance.GetEntity(currentInteractingTarget.PortalPairId);
				if (entity == null)
				{
					sceneItemPortalComponent = null;
				}
				else
				{
					WorldEntity entity2 = entity.Entity;
					sceneItemPortalComponent = ((entity2 != null) ? entity2.GetComponent<SceneItemPortalComponent>() : null);
				}
			}
			SceneItemPortalComponent sceneItemPortalComponent2 = sceneItemPortalComponent;
			if (sceneItemPortalComponent2 == null)
			{
				return null;
			}
			BP_KuroPortalCapture_C bp_KuroPortalCapture_C = (sceneItemPortalComponent2 != null) ? sceneItemPortalComponent2.PortalCapture : null;
			if (currentInteractingTarget.PortalA2B)
			{
				return bp_KuroPortalCapture_C;
			}
			BP_KuroPortalCapture_C result = null;
			if (bp_KuroPortalCapture_C != null)
			{
				bp_KuroPortalCapture_C.GetPair(ref result);
			}
			return result;
		}

		// Token: 0x06030CAE RID: 199854 RVA: 0x00C0FB0A File Offset: 0x00C0DD0A
		public void SetIsHookEndByInterrupt(bool isInterrupt)
		{
			BaseExploreComponent exploreComponent = this.ExploreComponent;
			if (exploreComponent == null)
			{
				return;
			}
			exploreComponent.SetIsHookEndByInterruptProxy(isInterrupt);
		}

		// Token: 0x17008327 RID: 33575
		// (get) Token: 0x06030CAF RID: 199855 RVA: 0x00C0FB1D File Offset: 0x00C0DD1D
		// (set) Token: 0x06030CB0 RID: 199856 RVA: 0x00C0FB2A File Offset: 0x00C0DD2A
		protected bool NextLegal
		{
			get
			{
				return this.ExploreComponent.FocusTargetLegal;
			}
			set
			{
				this.ExploreComponent.FocusTargetLegal = value;
			}
		}

		// Token: 0x17008328 RID: 33576
		// (get) Token: 0x06030CB1 RID: 199857 RVA: 0x00C0FB38 File Offset: 0x00C0DD38
		// (set) Token: 0x06030CB2 RID: 199858 RVA: 0x00C0FB45 File Offset: 0x00C0DD45
		protected bool NextLegalExceptSkill
		{
			get
			{
				return this.ExploreComponent.FocusTargetLegalExceptSkill;
			}
			set
			{
				this.ExploreComponent.FocusTargetLegalExceptSkill = value;
			}
		}

		// Token: 0x17008329 RID: 33577
		// (get) Token: 0x06030CB3 RID: 199859 RVA: 0x00C0FB53 File Offset: 0x00C0DD53
		// (set) Token: 0x06030CB4 RID: 199860 RVA: 0x00C0FB60 File Offset: 0x00C0DD60
		protected bool SyncEnabled
		{
			get
			{
				return this.ExploreComponent.SyncEnabled;
			}
			set
			{
				this.ExploreComponent.SyncEnabled = value;
			}
		}

		// Token: 0x1700832A RID: 33578
		// (get) Token: 0x06030CB5 RID: 199861 RVA: 0x00C0FB70 File Offset: 0x00C0DD70
		// (set) Token: 0x06030CB6 RID: 199862 RVA: 0x00C0FBB9 File Offset: 0x00C0DDB9
		protected HookPointInfo NextTarget
		{
			get
			{
				GrapplingHookPointComponent focusTarget = this.ExploreComponent.FocusTarget;
				if (focusTarget == null)
				{
					return null;
				}
				if (this.NextTargetWrapper == null)
				{
					this.NextTargetWrapper = new HookPointInfo(focusTarget, 0L, true);
				}
				else
				{
					this.NextTargetWrapper.Point = focusTarget;
				}
				return this.NextTargetWrapper;
			}
			set
			{
				this.ExploreComponent.SetFocusTarget((value != null) ? value.Point : null, true);
			}
		}

		// Token: 0x06030CB7 RID: 199863 RVA: 0x00C0FBD3 File Offset: 0x00C0DDD3
		public FVectorDouble GetNextTargetLocation()
		{
			return this.NextTarget.Point.HookLocation.ToUeVector(false);
		}

		// Token: 0x06030CB8 RID: 199864 RVA: 0x00C0FBEB File Offset: 0x00C0DDEB
		[NullableContext(1)]
		public Vector GetNextTargetVector()
		{
			return this.NextTarget.Point.HookLocation;
		}

		// Token: 0x06030CB9 RID: 199865 RVA: 0x00C0FC00 File Offset: 0x00C0DE00
		public bool CheckNextTargetCanInteract()
		{
			GrapplingHookPointComponent focusTarget = this.ExploreComponent.FocusTarget;
			return focusTarget != null && this.NextLegal && focusTarget.OnlineTypeCanInteract;
		}

		// Token: 0x06030CBA RID: 199866 RVA: 0x00C0FC2C File Offset: 0x00C0DE2C
		public bool GetNextTargetIsIgnorePlayerCollision()
		{
			GrapplingHookPointComponent focusTarget = this.ExploreComponent.FocusTarget;
			return focusTarget != null && focusTarget.IsIgnorePlayerCollision;
		}

		// Token: 0x06030CBB RID: 199867 RVA: 0x00C0FC50 File Offset: 0x00C0DE50
		public EntityHandle GetCurrentTargetEntity()
		{
			BaseActorComponent actorComp = this.ActorComp;
			if (actorComp == null || !actorComp.IsAutonomousProxy)
			{
				return this.SimulateHookTargetEntity;
			}
			if (this.CurrentInteractingTarget == null)
			{
				return null;
			}
			return ModelBase<CreatureModel>.Instance.GetEntityById(this.CurrentInteractingTarget.Point.Entity.Id);
		}

		// Token: 0x06030CBC RID: 199868 RVA: 0x00C0FCA4 File Offset: 0x00C0DEA4
		[NullableContext(1)]
		public Vector GetCurrentTargetLocation()
		{
			BaseActorComponent actorComp = this.ActorComp;
			Vector vector2;
			if (actorComp == null || !actorComp.IsAutonomousProxy)
			{
				EntityHandle simulateHookTargetEntity = this.SimulateHookTargetEntity;
				Vector vector;
				if (simulateHookTargetEntity == null)
				{
					vector = null;
				}
				else
				{
					WorldEntity entity = simulateHookTargetEntity.Entity;
					if (entity == null)
					{
						vector = null;
					}
					else
					{
						GrapplingHookPointComponent component = entity.GetComponent<GrapplingHookPointComponent>();
						vector = ((component != null) ? component.HookLocation : null);
					}
				}
				vector2 = (vector ?? this.SimulateHookTargetLocation);
			}
			else
			{
				HookPointInfo currentInteractingTarget = this.CurrentInteractingTarget;
				vector2 = ((currentInteractingTarget != null) ? currentInteractingTarget.Point.HookLocation : null);
			}
			return vector2 ?? this.ActorComp.ActorLocationProxy;
		}

		// Token: 0x06030CBD RID: 199869 RVA: 0x00C0FD2C File Offset: 0x00C0DF2C
		[NullableContext(1)]
		public Vector GetCurrentPathwayEndLocation()
		{
			Vector vector = null;
			BaseActorComponent actorComp = this.ActorComp;
			if (actorComp != null && actorComp.IsAutonomousProxy && this.CurrentPathwayIndex >= 0 && this.CurrentPathwayIndex < this.CurrentPathways.Count)
			{
				vector = this.CurrentPathways[this.CurrentPathwayIndex].Item2;
			}
			Vector result;
			if ((result = vector) == null)
			{
				HookPointInfo currentInteractingTarget = this.CurrentInteractingTarget;
				result = (((currentInteractingTarget != null) ? currentInteractingTarget.Point.HookLocation : null) ?? this.ActorComp.ActorLocationProxy);
			}
			return result;
		}

		// Token: 0x06030CBE RID: 199870 RVA: 0x00C0FDB0 File Offset: 0x00C0DFB0
		[return: Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public List<ValueTuple<Vector, Vector>> GetCurrentPathways()
		{
			return this.CurrentPathways;
		}

		// Token: 0x06030CBF RID: 199871 RVA: 0x00C0FDB8 File Offset: 0x00C0DFB8
		public bool GetIsInLastPathway()
		{
			return this.CurrentPathwayIndex < 0 || this.CurrentPathwayIndex >= this.CurrentPathways.Count || this.CurrentPathwayIndex >= this.CurrentPathways.Count - 1;
		}

		// Token: 0x06030CC0 RID: 199872 RVA: 0x00C0FDF0 File Offset: 0x00C0DFF0
		public FVectorDouble GetCurrentTargetForward()
		{
			CreatureDataComponent component = this.CurrentInteractingTarget.Point.Entity.GetComponent<CreatureDataComponent>();
			if (component != null && component.Valid)
			{
				return component.GetRotation().RotateVectorDouble(Vector.ForwardVectorDouble);
			}
			return this.ActorComp.ActorForward;
		}

		// Token: 0x06030CC1 RID: 199873 RVA: 0x00C0FE40 File Offset: 0x00C0E040
		public bool GetTargetIsSuiGuangType()
		{
			HookPointInfo currentInteractingTarget = this.CurrentInteractingTarget;
			int? num;
			if (currentInteractingTarget == null)
			{
				num = null;
			}
			else
			{
				GrapplingHookPointComponent point = currentInteractingTarget.Point;
				num = ((point != null) ? point.GetHookInteractType() : null);
			}
			return num == 2;
		}

		// Token: 0x06030CC2 RID: 199874 RVA: 0x00C0FE94 File Offset: 0x00C0E094
		public EHookInteractTypeBp GetTargetType()
		{
			HookPointInfo currentInteractingTarget = this.CurrentInteractingTarget;
			EHookInteractType? ehookInteractType;
			if (currentInteractingTarget == null)
			{
				ehookInteractType = null;
			}
			else
			{
				GrapplingHookPointComponent point = currentInteractingTarget.Point;
				ehookInteractType = ((point != null) ? point.GetHookInteractType() : null);
			}
			EHookInteractType? ehookInteractType2 = ehookInteractType;
			if (ehookInteractType2 == null)
			{
				return EHookInteractTypeBp.FixedPointHook;
			}
			if (ehookInteractType2.GetValueOrDefault() == EHookInteractType.SlashHook)
			{
				HookPointInfo currentInteractingTarget2 = this.CurrentInteractingTarget;
				ESlashHitType? eslashHitType = (currentInteractingTarget2 != null) ? currentInteractingTarget2.Point.GetSlashHitType() : null;
				if (eslashHitType != null)
				{
					ESlashHitType valueOrDefault = eslashHitType.GetValueOrDefault();
					if (valueOrDefault == ESlashHitType.HeavySlash)
					{
						return EHookInteractTypeBp.SlashHook;
					}
					if (valueOrDefault == ESlashHitType.LightSlash)
					{
						return EHookInteractTypeBp.LightSlashHook;
					}
				}
			}
			EHookInteractTypeBp result;
			if (!BaseSceneInteractComponent.InteractTsType2BpType.TryGetValue(ehookInteractType2.Value, out result))
			{
				return EHookInteractTypeBp.FixedPointHook;
			}
			return result;
		}

		// Token: 0x06030CC3 RID: 199875 RVA: 0x00C0FF3F File Offset: 0x00C0E13F
		public bool CanActivateFixHook()
		{
			return this.NextLegal && this.NextTarget != null && this.CurrentInteractingTarget != this.NextTarget;
		}

		// Token: 0x06030CC4 RID: 199876 RVA: 0x00C0FF64 File Offset: 0x00C0E164
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			BaseSceneInteractComponent baseSceneInteractComponent = (BaseSceneInteractComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (baseSceneInteractComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ExploreComponent"))
			{
				if (baseSceneInteractComponent.ExploreComponent == null)
				{
					this.ExploreComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseExploreComponent>(this.ExploreComponent), "ExploreComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsHooking"))
			{
				this.IsHooking = baseSceneInteractComponent.IsHooking;
			}
			if (base.CanResetComponentProperty("CurrentInteractingTargetWrapper"))
			{
				if (baseSceneInteractComponent.CurrentInteractingTargetWrapper == null)
				{
					this.CurrentInteractingTargetWrapper = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<HookPointInfo>(this.CurrentInteractingTargetWrapper), "CurrentInteractingTargetWrapper"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("NextTargetWrapper"))
			{
				if (baseSceneInteractComponent.NextTargetWrapper == null)
				{
					this.NextTargetWrapper = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<HookPointInfo>(this.NextTargetWrapper), "NextTargetWrapper"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SimulateHookTargetEntity"))
			{
				if (baseSceneInteractComponent.SimulateHookTargetEntity == null)
				{
					this.SimulateHookTargetEntity = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EntityHandle>(this.SimulateHookTargetEntity), "SimulateHookTargetEntity"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SimulateHookTargetLocation"))
			{
				if (baseSceneInteractComponent.SimulateHookTargetLocation == null)
				{
					this.SimulateHookTargetLocation = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.SimulateHookTargetLocation), "SimulateHookTargetLocation"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurrentPathways"))
			{
				if (baseSceneInteractComponent.CurrentPathways == null)
				{
					this.CurrentPathways = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<ValueTuple<Vector, Vector>>>(this.CurrentPathways), "CurrentPathways"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurrentPathwayIndex"))
			{
				this.CurrentPathwayIndex = baseSceneInteractComponent.CurrentPathwayIndex;
			}
			return true;
		}

		// Token: 0x0401C0A8 RID: 114856
		public BaseActorComponent ActorComp;

		// Token: 0x0401C0A9 RID: 114857
		protected BaseExploreComponent ExploreComponent;

		// Token: 0x0401C0AA RID: 114858
		protected bool IsHooking;

		// Token: 0x0401C0AB RID: 114859
		protected HookPointInfo CurrentInteractingTargetWrapper;

		// Token: 0x0401C0AC RID: 114860
		protected HookPointInfo NextTargetWrapper;

		// Token: 0x0401C0AD RID: 114861
		public EntityHandle SimulateHookTargetEntity;

		// Token: 0x0401C0AE RID: 114862
		public Vector SimulateHookTargetLocation;

		// Token: 0x0401C0AF RID: 114863
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		protected List<ValueTuple<Vector, Vector>> CurrentPathways = new List<ValueTuple<Vector, Vector>>();

		// Token: 0x0401C0B0 RID: 114864
		protected int CurrentPathwayIndex = -1;

		// Token: 0x0401C0B1 RID: 114865
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EHookInteractType, EHookInteractTypeBp> InteractTsType2BpType = new Dictionary<EHookInteractType, EHookInteractTypeBp>
		{
			{
				EHookInteractType.FixedPointHook,
				EHookInteractTypeBp.FixedPointHook
			},
			{
				EHookInteractType.SuiGuangHook,
				EHookInteractTypeBp.SuiGuangHook
			},
			{
				EHookInteractType.KiteHook,
				EHookInteractTypeBp.KiteHook
			},
			{
				EHookInteractType.RagDollJumpingPoint,
				EHookInteractTypeBp.RagDollJumpingPoint
			},
			{
				EHookInteractType.RagDollClimbingPoint,
				EHookInteractTypeBp.RagDollClimbingPoint
			},
			{
				EHookInteractType.MovementPointHook,
				EHookInteractTypeBp.MovementPointHook
			},
			{
				EHookInteractType.SlashHook,
				EHookInteractTypeBp.SlashHook
			},
			{
				EHookInteractType.ChargeSlashHook,
				EHookInteractTypeBp.ChargeSlashHook
			},
			{
				EHookInteractType.CableWay,
				EHookInteractTypeBp.CableWayHook
			}
		};
	}
}
