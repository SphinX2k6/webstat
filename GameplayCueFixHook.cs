using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.GamePlay.Portal;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using UnrealEngine;

// Token: 0x02002FA4 RID: 12196
[NullableContext(2)]
[Nullable(0)]
public class GameplayCueFixHook : GameplayCueBase
{
	// Token: 0x06018DF4 RID: 101876 RVA: 0x0070AFAE File Offset: 0x007091AE
	protected override void OnInit()
	{
	}

	// Token: 0x06018DF5 RID: 101877 RVA: 0x0070AFB0 File Offset: 0x007091B0
	protected override void OnTick(float delta)
	{
		if (this.IsMovableHookPoint)
		{
			return;
		}
		if (this.HookItem != null)
		{
			FVectorDouble targetPosition = this.GetTargetPosition(false);
			this.HookItem.Tick(targetPosition);
		}
	}

	// Token: 0x06018DF6 RID: 101878 RVA: 0x0070AFE4 File Offset: 0x007091E4
	protected override void OnAfterTick(float delta)
	{
		if (!this.IsMovableHookPoint)
		{
			return;
		}
		if (this.HookItem != null)
		{
			FVectorDouble targetPosition = this.GetTargetPosition(true);
			this.HookItem.Tick(targetPosition);
		}
	}

	// Token: 0x06018DF7 RID: 101879 RVA: 0x0070B018 File Offset: 0x00709218
	protected override void OnCreate()
	{
		BaseSceneInteractComponent sceneInteractComponent = this.GetSceneInteractComponent();
		GrapplingHookPointComponent grapplingHookPointComponent = (sceneInteractComponent != null) ? sceneInteractComponent.GetCurrentTarget() : null;
		if (grapplingHookPointComponent == null || !grapplingHookPointComponent.Valid)
		{
			return;
		}
		EHookInteractType? hookInteractType = grapplingHookPointComponent.GetHookInteractType();
		this.IsMovableHookPoint = (hookInteractType != null && GameplayCueFixHook.MovableHookPointTypes.Contains(hookInteractType.Value));
		WorldEntity entity = this.EntityHandle.Entity;
		bool? flag;
		if (entity == null)
		{
			flag = null;
		}
		else
		{
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			flag = ((component != null) ? new bool?(component.IsAutonomousProxy) : null);
		}
		bool? flag2 = flag;
		FVectorDouble targetPosition = flag2.GetValueOrDefault() ? this.GetCurrentPathwayEndLocation() : this.GetTargetPosition(false);
		this.HookItem = GameplayCueHookCommonItem.Spawn(this.ActorInternal, FNameUtil.GetDynamicFName(this.CueConfig.Socket).Value, targetPosition, this.CueConfig.Resources(), true);
		if (flag2.GetValueOrDefault() && !this.GetIsInLastPathway())
		{
			this.EnterPortal = this.GetTargetEnterPortalCapture();
			if (this.EnterPortal == null)
			{
				return;
			}
			this.EnterPortal.RoleTeleport.Add(new Action<FVector>(this.OnRoleTeleport));
		}
	}

	// Token: 0x06018DF8 RID: 101880 RVA: 0x0070B144 File Offset: 0x00709344
	protected override void OnDestroy()
	{
		if (this.HookItem != null)
		{
			this.HookItem.Destroy();
			this.HookItem = null;
		}
		BP_KuroPortalCapture_C enterPortal = this.EnterPortal;
		if (enterPortal != null)
		{
			enterPortal.RoleTeleport.Remove(new Action<FVector>(this.OnRoleTeleport));
		}
		this.EnterPortal = null;
	}

	// Token: 0x06018DF9 RID: 101881 RVA: 0x0070B194 File Offset: 0x00709394
	private FVectorDouble GetTargetPosition(bool realtime = false)
	{
		BaseSceneInteractComponent sceneInteractComponent = this.GetSceneInteractComponent();
		if (realtime)
		{
			GrapplingHookPointComponent currentTarget = sceneInteractComponent.GetCurrentTarget();
			if (currentTarget != null)
			{
				SceneItemActorComponent actorComp = currentTarget.ActorComp;
				if (actorComp != null)
				{
					actorComp.ResetLocationCachedTime();
				}
			}
		}
		return sceneInteractComponent.GetCurrentTargetLocation().ToUeVector(false);
	}

	// Token: 0x06018DFA RID: 101882 RVA: 0x0070B1D3 File Offset: 0x007093D3
	private FVectorDouble GetCurrentPathwayEndLocation()
	{
		return this.GetSceneInteractComponent().GetCurrentPathwayEndLocation().ToUeVector(false);
	}

	// Token: 0x06018DFB RID: 101883 RVA: 0x0070B1E6 File Offset: 0x007093E6
	private bool GetIsInLastPathway()
	{
		return this.GetSceneInteractComponent().GetIsInLastPathway();
	}

	// Token: 0x06018DFC RID: 101884 RVA: 0x0070B1F3 File Offset: 0x007093F3
	private BP_KuroPortalCapture_C GetTargetEnterPortalCapture()
	{
		return this.GetSceneInteractComponent().GetCurrentTargetEnterPortalCapture();
	}

	// Token: 0x06018DFD RID: 101885 RVA: 0x0070B200 File Offset: 0x00709400
	private void OnRoleTeleport(FVector vector)
	{
		if (!this.IsActive || this.EnterPortal == null)
		{
			return;
		}
		if (this.HookItem != null)
		{
			this.HookItem.Destroy();
			this.HookItem = null;
		}
		FVectorDouble currentPathwayEndLocation = this.GetCurrentPathwayEndLocation();
		this.HookItem = GameplayCueHookCommonItem.Spawn(this.ActorInternal, FNameUtil.GetDynamicFName(this.CueConfig.Socket).Value, currentPathwayEndLocation, this.CueConfig.Resources(), true);
	}

	// Token: 0x06018DFE RID: 101886 RVA: 0x0070B278 File Offset: 0x00709478
	private BaseSceneInteractComponent GetSceneInteractComponent()
	{
		BaseSceneInteractComponent component = this.EntityHandle.Entity.GetComponent<BaseSceneInteractComponent>();
		if (component != null)
		{
			return component;
		}
		VehiclePerformComponent component2 = this.EntityHandle.Entity.GetComponent<VehiclePerformComponent>();
		if (component2 == null)
		{
			return null;
		}
		Entity driver = component2.Driver;
		if (driver == null)
		{
			return null;
		}
		return driver.GetComponent<BaseSceneInteractComponent>();
	}

	// Token: 0x0400C240 RID: 49728
	private GameplayCueHookCommonItem HookItem;

	// Token: 0x0400C241 RID: 49729
	private BP_KuroPortalCapture_C EnterPortal;

	// Token: 0x0400C242 RID: 49730
	private bool IsMovableHookPoint;

	// Token: 0x0400C243 RID: 49731
	[Nullable(1)]
	private static readonly HashSet<EHookInteractType> MovableHookPointTypes = new HashSet<EHookInteractType>
	{
		EHookInteractType.KiteHook
	};
}
