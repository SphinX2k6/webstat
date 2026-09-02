using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004747 RID: 18247
	public class CharEnviInteractionEffect : CharRenderBase
	{
		// Token: 0x0602F5A3 RID: 193955 RVA: 0x00B3B798 File Offset: 0x00B39998
		public override void Start()
		{
			if (this.EnviInteractionComponent == null)
			{
				AActor owner = base.GetRenderingComponent().GetOwner();
				AActor aactor = owner;
				TSubclassOf<UActorComponent> @class = UKuroEnviInteractionComponent.StaticClass();
				bool bManualAttachment = false;
				FTransform ftransform = new FTransform();
				this.EnviInteractionComponent = (aactor.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as UKuroEnviInteractionComponent);
			}
			if (this.EnviInteractionComponent != null)
			{
				this.EnviInteractionComponent.bCalEnviInteractionData = true;
				this.EnviInteractionComponent.RegisterComponentToSystem();
				this.EnviInteractionComponent.bUpdateWaterEID = false;
				FVector rayToOffset = this.EnviInteractionComponent.RayToOffset;
				rayToOffset.Z = -3000f;
				this.EnviInteractionComponent.RayToOffset = rayToOffset;
			}
			base.OnInitSuccess();
		}

		// Token: 0x0602F5A4 RID: 193956 RVA: 0x00B3B83C File Offset: 0x00B39A3C
		public override void Destroy()
		{
			if (this.EnviInteractionComponent != null)
			{
				AActor owner = this.EnviInteractionComponent.GetOwner();
				if (owner == null)
				{
					return;
				}
				owner.K2_DestroyComponent(this.EnviInteractionComponent);
			}
		}

		// Token: 0x0602F5A5 RID: 193957 RVA: 0x00B3B861 File Offset: 0x00B39A61
		[NullableContext(1)]
		public override string GetStatName()
		{
			return "CharEnviInteractionEffect";
		}

		// Token: 0x0602F5A6 RID: 193958 RVA: 0x00B3B868 File Offset: 0x00B39A68
		public override int GetComponentId()
		{
			return 15;
		}

		// Token: 0x0401AF6E RID: 110446
		[Nullable(2)]
		public UKuroEnviInteractionComponent EnviInteractionComponent;
	}
}
