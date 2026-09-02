using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002C95 RID: 11413
[NullableContext(1)]
[Nullable(0)]
public class UiDangoCollisionComponent : UiModelComponentBase
{
	// Token: 0x06016E80 RID: 93824 RVA: 0x0065A019 File Offset: 0x00658219
	protected override void OnInit()
	{
		this.UiModelActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
	}

	// Token: 0x06016E81 RID: 93825 RVA: 0x0065A02C File Offset: 0x0065822C
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
	}

	// Token: 0x06016E82 RID: 93826 RVA: 0x0065A050 File Offset: 0x00658250
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
	}

	// Token: 0x06016E83 RID: 93827 RVA: 0x0065A074 File Offset: 0x00658274
	private void OnModelLoadComplete()
	{
		this.InitCollisionComponent();
	}

	// Token: 0x06016E84 RID: 93828 RVA: 0x0065A07C File Offset: 0x0065827C
	private void InitCollisionComponent()
	{
		AActor actor = this.UiModelActorComponent.Actor;
		TSubclassOf<UActorComponent> @class = UBoxComponent.StaticClass();
		bool bManualAttachment = true;
		FTransform transform = this.UiModelActorComponent.Actor.GetTransform();
		this.CollisionComponent = (actor.AddComponentByClass(@class, bManualAttachment, transform, false, default(FName)) as UBoxComponent);
		this.CollisionComponent.SetTickableWhenPaused(true);
		this.CollisionComponent.SetBoxExtent(new FVector(35f, 35f, 35f), false);
		FVector newLocation = this.UiModelActorComponent.Actor.K2_GetActorLocation();
		float z = this.UiModelActorComponent.Actor.GetActorScale3D().Z;
		newLocation.Z += 35f * z;
		FHitResult fhitResult = new FHitResult();
		this.CollisionComponent.K2_SetWorldLocation(newLocation, false, ref fhitResult, false);
		this.CollisionComponent.SetCollisionEnabled(ECollisionEnabled.QueryOnly);
		this.CollisionComponent.SetCollisionObjectType(ECollisionChannel.ECC_Visibility);
		this.CollisionComponent.SetCollisionResponseToAllChannels(ECollisionResponse.ECR_Block);
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			ULGUIBPLibrary.AddInstanceComponent(this.UiModelActorComponent.Actor, this.CollisionComponent);
		}
	}

	// Token: 0x0400B0AA RID: 45226
	private const float DANGO_COLLISION_SIZE = 35f;

	// Token: 0x0400B0AB RID: 45227
	protected UiModelActorComponent UiModelActorComponent;

	// Token: 0x0400B0AC RID: 45228
	protected UBoxComponent CollisionComponent;
}
