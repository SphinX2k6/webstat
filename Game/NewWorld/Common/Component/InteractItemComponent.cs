using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048C2 RID: 18626
	[NullableContext(2)]
	[Nullable(0)]
	public class InteractItemComponent : EntityComponent
	{
		// Token: 0x0603091A RID: 198938 RVA: 0x00BF0BC4 File Offset: 0x00BEEDC4
		protected override bool OnStart()
		{
			AActor dynamicEntity = WorldFunctionLibrary.GetDynamicEntity(base.Entity.Id);
			if (dynamicEntity != null)
			{
				TArray<UActorComponent> componentsByTag = dynamicEntity.GetComponentsByTag(UChildActorComponent.StaticClass(), InteractItemComponent.POSITION_TAG);
				if (componentsByTag != null && componentsByTag.Num() > 0)
				{
					this.Position = (componentsByTag.Get(0) as UChildActorComponent);
				}
				this.Arrow = (dynamicEntity.GetComponentByClass(UArrowComponent.StaticClass()) as UArrowComponent);
				this.IsInit = true;
			}
			return true;
		}

		// Token: 0x0603091B RID: 198939 RVA: 0x00BF0C3C File Offset: 0x00BEEE3C
		public FVectorDouble? GetInteractPosition()
		{
			if (this.Position != null)
			{
				return new FVectorDouble?(this.Position.D_K2_GetComponentLocation());
			}
			return null;
		}

		// Token: 0x0603091C RID: 198940 RVA: 0x00BF0C6C File Offset: 0x00BEEE6C
		public FRotator? GetInteractRotator()
		{
			if (this.Arrow != null)
			{
				return new FRotator?(this.Arrow.K2_GetComponentRotation());
			}
			return null;
		}

		// Token: 0x0603091D RID: 198941 RVA: 0x00BF0C9C File Offset: 0x00BEEE9C
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			InteractItemComponent interactItemComponent = (InteractItemComponent)componentTemplate;
			if (base.CanResetComponentProperty("Position"))
			{
				if (interactItemComponent.Position == null)
				{
					this.Position = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UChildActorComponent>(this.Position), "Position"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Arrow"))
			{
				if (interactItemComponent.Arrow == null)
				{
					this.Arrow = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UArrowComponent>(this.Arrow), "Arrow"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsInit"))
			{
				this.IsInit = interactItemComponent.IsInit;
			}
			return true;
		}

		// Token: 0x0401BE95 RID: 114325
		private static readonly FName POSITION_TAG = new FName("Position");

		// Token: 0x0401BE96 RID: 114326
		private UChildActorComponent Position;

		// Token: 0x0401BE97 RID: 114327
		private UArrowComponent Arrow;

		// Token: 0x0401BE98 RID: 114328
		public bool IsInit;
	}
}
