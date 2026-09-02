using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay.SunSpirit;
using CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritState;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004810 RID: 18448
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemSunSpiritLauncherComponent : EntityComponent
	{
		// Token: 0x06030016 RID: 196630 RVA: 0x00B9F8A4 File Offset: 0x00B9DAA4
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			CreateEntityData p = args.GetP1<CreateEntityData>();
			this.LauncherConfig = (p.GetParam<SceneItemSunSpiritLauncherComponent>() as SunSpiritLauncherComponent);
			return true;
		}

		// Token: 0x06030017 RID: 196631 RVA: 0x00B9F8CA File Offset: 0x00B9DACA
		protected override bool OnInit()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			return true;
		}

		// Token: 0x06030018 RID: 196632 RVA: 0x00B9F8E0 File Offset: 0x00B9DAE0
		public bool GetHintViewLocation(Vector outVec)
		{
			if (this.ActorComp == null)
			{
				return false;
			}
			AActor referenceActor = this.ActorComp.GetReferenceActor("HintViewAnchor");
			if (referenceActor != null)
			{
				FVectorDouble fvectorDouble = referenceActor.D_K2_GetActorLocation();
				outVec.FromUeVector(fvectorDouble);
			}
			else
			{
				outVec.DeepCopy(this.ActorComp.ActorLocationProxy);
			}
			return true;
		}

		// Token: 0x06030019 RID: 196633 RVA: 0x00B9F92E File Offset: 0x00B9DB2E
		public bool GetCanBeWatchSelect()
		{
			if (this.ActorComp != null)
			{
				SceneItemActorComponent actorComp = this.ActorComp;
				if (actorComp == null || !actorComp.GetIsSceneInteractionLoadCompleted())
				{
					return false;
				}
			}
			return this.GetTargetGear() != null;
		}

		// Token: 0x0603001A RID: 196634 RVA: 0x00B9F95C File Offset: 0x00B9DB5C
		public int GetNumOfNeededSunSpirit()
		{
			SunSpiritLauncherComponent launcherConfig = this.LauncherConfig;
			if (launcherConfig == null)
			{
				return 0;
			}
			return launcherConfig.NeedsCount;
		}

		// Token: 0x0603001B RID: 196635 RVA: 0x00B9F970 File Offset: 0x00B9DB70
		[NullableContext(2)]
		public SceneItemSunSpiritGearComponent GetTargetGear()
		{
			SunSpiritLauncherComponent launcherConfig = this.LauncherConfig;
			bool flag = (((launcherConfig != null) ? new int?(launcherConfig.SunSpiritGearId) : null) ?? 0) == 0;
			if (flag)
			{
				return null;
			}
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			EntityHandle entityHandle = (instance != null) ? instance.GetEntityByPbDataId(this.LauncherConfig.SunSpiritGearId) : null;
			if (entityHandle == null || !entityHandle.Valid)
			{
				return null;
			}
			WorldEntity entity = entityHandle.Entity;
			if (entity == null)
			{
				return null;
			}
			return entity.GetComponent<SceneItemSunSpiritGearComponent>();
		}

		// Token: 0x0603001C RID: 196636 RVA: 0x00B9F9FC File Offset: 0x00B9DBFC
		public bool CheckIsSunSpiritOccupiedByTargetGear(SunSpiritData sunSpiritData)
		{
			SunSpiritOccupiedByGearState sunSpiritOccupiedByGearState = sunSpiritData.GetSunSpiritState() as SunSpiritOccupiedByGearState;
			if (sunSpiritOccupiedByGearState != null)
			{
				int gearConfigId = sunSpiritOccupiedByGearState.GearConfigId;
				SunSpiritLauncherComponent launcherConfig = this.LauncherConfig;
				int? num = (launcherConfig != null) ? new int?(launcherConfig.SunSpiritGearId) : null;
				if (gearConfigId == num.GetValueOrDefault() & num != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603001D RID: 196637 RVA: 0x00B9FA54 File Offset: 0x00B9DC54
		public bool CheckIsSunSpiritFlyingFromPlayerToTargetGear(SunSpiritData sunSpiritData)
		{
			SunSpiritFlyingToGearState sunSpiritFlyingToGearState = sunSpiritData.GetSunSpiritState() as SunSpiritFlyingToGearState;
			if (sunSpiritFlyingToGearState != null)
			{
				int gearConfigId = sunSpiritFlyingToGearState.GearConfigId;
				SunSpiritLauncherComponent launcherConfig = this.LauncherConfig;
				int? num = (launcherConfig != null) ? new int?(launcherConfig.SunSpiritGearId) : null;
				if (gearConfigId == num.GetValueOrDefault() & num != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603001E RID: 196638 RVA: 0x00B9FAAC File Offset: 0x00B9DCAC
		public bool CheckIsSunSpiritOccupiedByPlayer(SunSpiritData sunSpiritData)
		{
			return sunSpiritData.GetSunSpiritState() is SunSpiritOccupiedByPlayerState;
		}

		// Token: 0x0603001F RID: 196639 RVA: 0x00B9FAC0 File Offset: 0x00B9DCC0
		public bool CheckIsSunSpiritFlyingFromTargetGearToPlayer(SunSpiritData sunSpiritData)
		{
			SunSpiritFlyingToPlayerState sunSpiritFlyingToPlayerState = sunSpiritData.GetSunSpiritState() as SunSpiritFlyingToPlayerState;
			if (sunSpiritFlyingToPlayerState != null)
			{
				int gearConfigId = sunSpiritFlyingToPlayerState.GearConfigId;
				SunSpiritLauncherComponent launcherConfig = this.LauncherConfig;
				int? num = (launcherConfig != null) ? new int?(launcherConfig.SunSpiritGearId) : null;
				if (gearConfigId == num.GetValueOrDefault() & num != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06030020 RID: 196640 RVA: 0x00B9FB18 File Offset: 0x00B9DD18
		public int GetNumOfSunSpiritRelatedToLauncher(bool bIncludeSunSpiritOccupiedByTargetGear, bool bIncludeSunSpiritOccupiedByPlayer, bool bIncludeSunSpiritFlyingFromPlayerToTargetGear, bool bIncludeSunSpiritFlyingFromTargetGearToPlayer)
		{
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			SunSpiritLauncherComponent launcherConfig = this.LauncherConfig;
			return instance.GetSunSpiritNumByPlayerIdAndAreaId(playerId, (launcherConfig != null) ? launcherConfig.AreaId : 0, true, (SunSpiritData sunSpiritData) => (bIncludeSunSpiritOccupiedByTargetGear && this.CheckIsSunSpiritOccupiedByTargetGear(sunSpiritData)) || (bIncludeSunSpiritOccupiedByPlayer && this.CheckIsSunSpiritOccupiedByPlayer(sunSpiritData)) || (bIncludeSunSpiritFlyingFromPlayerToTargetGear && this.CheckIsSunSpiritFlyingFromPlayerToTargetGear(sunSpiritData)) || (bIncludeSunSpiritFlyingFromTargetGearToPlayer && this.CheckIsSunSpiritFlyingFromTargetGearToPlayer(sunSpiritData)));
		}

		// Token: 0x06030021 RID: 196641 RVA: 0x00B9FB84 File Offset: 0x00B9DD84
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemSunSpiritLauncherComponent sceneItemSunSpiritLauncherComponent = (SceneItemSunSpiritLauncherComponent)componentTemplate;
			if (base.CanResetComponentProperty("LauncherConfig"))
			{
				if (sceneItemSunSpiritLauncherComponent.LauncherConfig == null)
				{
					this.LauncherConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SunSpiritLauncherComponent>(this.LauncherConfig), "LauncherConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemSunSpiritLauncherComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B8E7 RID: 112871
		[Nullable(2)]
		private SunSpiritLauncherComponent LauncherConfig;

		// Token: 0x0401B8E8 RID: 112872
		[Nullable(2)]
		private SceneItemActorComponent ActorComp;
	}
}
