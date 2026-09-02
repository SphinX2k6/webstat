using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02001F95 RID: 8085
[NullableContext(2)]
[Nullable(0)]
public class ManipulateAimHandle : HudUnitHandleBase
{
	// Token: 0x0600F2A4 RID: 62116 RVA: 0x00424C6C File Offset: 0x00422E6C
	protected override void OnDestroyed()
	{
		this.DestroyManipulateAimUnit();
		this.ManipulateAimUnit = null;
		this.TargetActorComponent = null;
		this.TargetSkeletalMesh = null;
		this.HasTargetSocketName = false;
	}

	// Token: 0x0600F2A5 RID: 62117 RVA: 0x00424C90 File Offset: 0x00422E90
	protected override void OnTick(float delta)
	{
		this.RefreshScreenPosition();
	}

	// Token: 0x0600F2A6 RID: 62118 RVA: 0x00424C98 File Offset: 0x00422E98
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<bool, Entity, bool>(EEventName.OnManipulateSwitchToNewTarget, new Action<bool, Entity, bool>(this.OnSwitchToNewTarget));
		Singleton<EventSystem>.Instance.Add<float, string>(EEventName.OnManipulateStartChanting, new Action<float, string>(this.OnManipulateStart));
		Singleton<EventSystem>.Instance.Add<Entity, CharacterPart>(EEventName.ManipulateStartLockCastTarget, new Action<Entity, CharacterPart>(this.OnManipulateStartLockCastTarget));
		Singleton<EventSystem>.Instance.Add(EEventName.ManipulateEndLockCastTarget, new Action(this.OnManipulateEndLockCastTarget));
		Singleton<EventSystem>.Instance.Add(EEventName.HiddenManipulateUI, new Action(this.OnManipulateEnded));
	}

	// Token: 0x0600F2A7 RID: 62119 RVA: 0x00424D34 File Offset: 0x00422F34
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<bool, Entity, bool>(EEventName.OnManipulateSwitchToNewTarget, new Action<bool, Entity, bool>(this.OnSwitchToNewTarget));
		Singleton<EventSystem>.Instance.Remove<float, string>(EEventName.OnManipulateStartChanting, new Action<float, string>(this.OnManipulateStart));
		Singleton<EventSystem>.Instance.Remove<Entity, CharacterPart>(EEventName.ManipulateStartLockCastTarget, new Action<Entity, CharacterPart>(this.OnManipulateStartLockCastTarget));
		Singleton<EventSystem>.Instance.Remove(EEventName.ManipulateEndLockCastTarget, new Action(this.OnManipulateEndLockCastTarget));
		Singleton<EventSystem>.Instance.Remove(EEventName.HiddenManipulateUI, new Action(this.OnManipulateEnded));
	}

	// Token: 0x0600F2A8 RID: 62120 RVA: 0x00424DCD File Offset: 0x00422FCD
	private void OnSwitchToNewTarget(bool isActive, Entity entity, bool isCastTarget)
	{
		if (isActive)
		{
			return;
		}
		if (this.TargetActorComponent != null)
		{
			return;
		}
		ManipulateAimUnit manipulateAimUnit = this.ManipulateAimUnit;
		if (manipulateAimUnit == null)
		{
			return;
		}
		manipulateAimUnit.PlayCloseAnim();
	}

	// Token: 0x0600F2A9 RID: 62121 RVA: 0x00424DEC File Offset: 0x00422FEC
	[NullableContext(1)]
	private void OnManipulateStart(float time, string resId)
	{
		this.ResId = resId;
		if (this.ManipulateAimUnit == null)
		{
			this.NewManipulateAimUnit();
			return;
		}
		if (this.ManipulateAimUnit.ResourceId != this.ResId)
		{
			this.DestroyManipulateAimUnit();
			this.NewManipulateAimUnit();
			return;
		}
		this.RefreshScreenPosition();
		this.RefreshWeakness();
		this.ManipulateAimUnit.PlayStartAnim();
	}

	// Token: 0x0600F2AA RID: 62122 RVA: 0x00424E4C File Offset: 0x0042304C
	[NullableContext(1)]
	private void OnManipulateStartLockCastTarget(Entity lockEntity, CharacterPart lockPart)
	{
		if (lockEntity == null)
		{
			return;
		}
		this.TargetActorComponent = lockEntity.GetComponent<CharacterActorComponent>();
		CharacterActorComponent targetActorComponent = this.TargetActorComponent;
		this.TargetSkeletalMesh = ((targetActorComponent != null) ? targetActorComponent.Actor.Mesh : null);
		this.TargetSocketName = ((lockPart != null) ? lockPart.PartSocketName : null);
		this.HasTargetSocketName = true;
		this.TargetIsWeakness = (lockPart != null && lockPart.IsWeakness);
		if (this.ManipulateAimUnit == null)
		{
			this.NewManipulateAimUnit();
			return;
		}
		if (this.ManipulateAimUnit.ResourceId != this.ResId)
		{
			this.DestroyManipulateAimUnit();
			this.NewManipulateAimUnit();
			return;
		}
		this.RefreshScreenPosition();
		this.RefreshWeakness();
	}

	// Token: 0x0600F2AB RID: 62123 RVA: 0x00424EF9 File Offset: 0x004230F9
	private void OnManipulateEndLockCastTarget()
	{
		this.TargetActorComponent = null;
		this.TargetSkeletalMesh = null;
		this.HasTargetSocketName = false;
		ManipulateAimUnit manipulateAimUnit = this.ManipulateAimUnit;
		if (manipulateAimUnit == null)
		{
			return;
		}
		manipulateAimUnit.SetTargetAimVisible(false);
	}

	// Token: 0x0600F2AC RID: 62124 RVA: 0x00424F21 File Offset: 0x00423121
	private void OnManipulateEnded()
	{
		this.TargetActorComponent = null;
		this.TargetSkeletalMesh = null;
		this.HasTargetSocketName = false;
		this.ResId = null;
		ManipulateAimUnit manipulateAimUnit = this.ManipulateAimUnit;
		if (manipulateAimUnit == null)
		{
			return;
		}
		manipulateAimUnit.PlayCloseAnim();
	}

	// Token: 0x0600F2AD RID: 62125 RVA: 0x00424F50 File Offset: 0x00423150
	private void NewManipulateAimUnit()
	{
		if (string.IsNullOrEmpty(this.ResId))
		{
			return;
		}
		base.NewHudUnitWithReturn<ManipulateAimUnit>(typeof(ManipulateAimUnit), this.ResId, out this.ManipulateAimUnit, true, delegate(ManipulateAimUnit _)
		{
			string resId = this.ResId;
			ManipulateAimUnit manipulateAimUnit = this.ManipulateAimUnit;
			if (resId != ((manipulateAimUnit != null) ? manipulateAimUnit.ResourceId : null))
			{
				this.DestroyManipulateAimUnit();
				return;
			}
			ManipulateAimUnit manipulateAimUnit2 = this.ManipulateAimUnit;
			if (manipulateAimUnit2 != null)
			{
				manipulateAimUnit2.SetCloseAnimCallback(new Action(this.DestroyManipulateAimUnit));
			}
			this.RefreshScreenPosition();
			this.RefreshWeakness();
		}, false);
		Singleton<EventSystem>.Instance.Emit<bool, ECameraAimVisibleReason, string, string>(EEventName.SetCameraAimVisible, false, ECameraAimVisibleReason.InManipulate, null, null);
	}

	// Token: 0x0600F2AE RID: 62126 RVA: 0x00424FA9 File Offset: 0x004231A9
	private void DestroyManipulateAimUnit()
	{
		if (this.ManipulateAimUnit == null)
		{
			return;
		}
		base.DestroyHudUnit(this.ManipulateAimUnit);
		this.ManipulateAimUnit = null;
		Singleton<EventSystem>.Instance.Emit<bool, ECameraAimVisibleReason, string, string>(EEventName.SetCameraAimVisible, true, ECameraAimVisibleReason.InManipulate, null, null);
	}

	// Token: 0x0600F2AF RID: 62127 RVA: 0x00424FDC File Offset: 0x004231DC
	private void RefreshScreenPosition()
	{
		if (this.ManipulateAimUnit == null)
		{
			return;
		}
		if (this.ManipulateAimUnit.InAsyncLoading())
		{
			return;
		}
		FVectorDouble? targetLocation = this.GetTargetLocation();
		if (targetLocation == null)
		{
			this.ManipulateAimUnit.SetTargetAimVisible(false);
			return;
		}
		FVector2D? fvector2D = base.ProjectWorldToScreen(targetLocation.Value);
		if (fvector2D == null)
		{
			this.ManipulateAimUnit.SetTargetAimVisible(false);
			return;
		}
		this.ManipulateAimUnit.SetTargetItemOffset(fvector2D.Value.X, fvector2D.Value.Y);
		this.ManipulateAimUnit.SetTargetAimVisible(true);
	}

	// Token: 0x0600F2B0 RID: 62128 RVA: 0x00425070 File Offset: 0x00423270
	private void RefreshWeakness()
	{
		if (this.ManipulateAimUnit == null)
		{
			return;
		}
		if (this.ManipulateAimUnit.InAsyncLoading())
		{
			return;
		}
		this.ManipulateAimUnit.SetIsWeakness(this.TargetIsWeakness);
	}

	// Token: 0x0600F2B1 RID: 62129 RVA: 0x0042509C File Offset: 0x0042329C
	private FVectorDouble? GetTargetLocation()
	{
		if (this.TargetActorComponent == null)
		{
			return null;
		}
		if (this.TargetSkeletalMesh == null || !this.HasTargetSocketName)
		{
			return new FVectorDouble?(this.TargetActorComponent.ActorLocation);
		}
		FName inSocketName = this.TargetSocketName ?? FNameUtil.EMPTY;
		if (!this.TargetSkeletalMesh.DoesSocketExist(inSocketName))
		{
			return new FVectorDouble?(this.TargetActorComponent.ActorLocation);
		}
		return new FVectorDouble?(this.TargetSkeletalMesh.D_GetSocketLocation(inSocketName));
	}

	// Token: 0x04007486 RID: 29830
	private ManipulateAimUnit ManipulateAimUnit;

	// Token: 0x04007487 RID: 29831
	private CharacterActorComponent TargetActorComponent;

	// Token: 0x04007488 RID: 29832
	private USkeletalMeshComponent TargetSkeletalMesh;

	// Token: 0x04007489 RID: 29833
	private FName? TargetSocketName;

	// Token: 0x0400748A RID: 29834
	private bool HasTargetSocketName;

	// Token: 0x0400748B RID: 29835
	private bool TargetIsWeakness;

	// Token: 0x0400748C RID: 29836
	private string ResId;
}
