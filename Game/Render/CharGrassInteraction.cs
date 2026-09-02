using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200474A RID: 18250
	[NullableContext(2)]
	[Nullable(0)]
	public class CharGrassInteraction : CharRenderBase
	{
		// Token: 0x0602F5B2 RID: 193970 RVA: 0x00B3BBA4 File Offset: 0x00B39DA4
		private double GetRefBoneHeight()
		{
			return this.OwnerSkeletal.D_GetSocketTransform(new FName("Bip001Head"), ERelativeTransformSpace.RTS_Component).GetLocation().Z;
		}

		// Token: 0x0602F5B3 RID: 193971 RVA: 0x00B3BBD4 File Offset: 0x00B39DD4
		public void SetEnabled(bool enabled)
		{
			this.Enabled = enabled;
			if (this.GrassInteractionComponent != null)
			{
				this.GrassInteractionComponent.bEnabled = enabled;
			}
		}

		// Token: 0x0602F5B4 RID: 193972 RVA: 0x00B3BBF4 File Offset: 0x00B39DF4
		public void SetConfig(PDA_InteractionPlayerConfig_C config)
		{
			if (config == null)
			{
				return;
			}
			if (this.IsOnMobile)
			{
				return;
			}
			float 植被交互半径 = config.植被交互半径;
			FVector 植被交互相对位置 = config.植被交互相对位置;
			bool 启用植被交互 = config.启用植被交互;
			this.UpdateInteraction(植被交互半径, 植被交互相对位置, 启用植被交互);
		}

		// Token: 0x0602F5B5 RID: 193973 RVA: 0x00B3BC2C File Offset: 0x00B39E2C
		private void UpdateInteraction(float radius, FVector bias, bool enabled)
		{
			if (this.IsOnMobile)
			{
				return;
			}
			AActor cachedOwner = this.RenderComponent.GetCachedOwner();
			if (cachedOwner != null)
			{
				TsBaseCharacter tsBaseCharacter = cachedOwner as TsBaseCharacter;
				if (tsBaseCharacter != null)
				{
					this.OwnerCapsule = tsBaseCharacter.CapsuleComponent;
					this.OwnerSkeletal = tsBaseCharacter.Mesh;
				}
				else
				{
					TsBaseVehicle tsBaseVehicle = cachedOwner as TsBaseVehicle;
					if (tsBaseVehicle != null)
					{
						this.OwnerCapsule = tsBaseVehicle.CapsuleComponent;
						this.OwnerSkeletal = tsBaseVehicle.Mesh;
					}
				}
			}
			if (this.OwnerCapsule == null || this.OwnerSkeletal == null)
			{
				return;
			}
			ECharacterRenderingType? renderType = base.GetRenderingComponent().GetRenderType();
			bool flag;
			if (renderType != null)
			{
				ECharacterRenderingType valueOrDefault = renderType.GetValueOrDefault();
				if (valueOrDefault <= ECharacterRenderingType.RemotePlayer)
				{
					flag = true;
					goto IL_9A;
				}
			}
			flag = false;
			IL_9A:
			if (flag && this.OwnerSkeletal.GetBoneIndex(new FName("Bip001Head")) != -1)
			{
				this.AverageBoneHeight = (float)this.GetRefBoneHeight();
				this.NeedBoneMotion = true;
			}
			this.BaseBias = new FVector?(new FVector(bias.X, bias.Y, bias.Z - this.OwnerCapsule.CapsuleHalfHeight));
			if (this.GrassInteractionComponent == null)
			{
				AActor owner = base.GetRenderingComponent().GetOwner();
				AActor aactor = owner;
				TSubclassOf<UActorComponent> @class = UKuroGrassInteractionSphereComponent.StaticClass();
				bool bManualAttachment = false;
				FVector value = this.BaseBias.Value;
				FTransform ftransform = new FTransform(ref value);
				this.GrassInteractionComponent = (aactor.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as UKuroGrassInteractionSphereComponent);
			}
			this.GrassInteractionComponent.Radius = radius;
			this.GrassInteractionComponent.bEnabled = enabled;
			this.Enabled = enabled;
			this.UpdateForAimisi();
		}

		// Token: 0x0602F5B6 RID: 193974 RVA: 0x00B3BDAC File Offset: 0x00B39FAC
		public override void Start()
		{
			this.IsOnMobile = (UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldFeatureLevel(GlobalData.World) == KuroFeatureLevel.ES3_1);
			if (this.IsOnMobile)
			{
				base.OnInitSuccess();
				return;
			}
			if (this.RenderComponent.InteractionConfig != null)
			{
				this.SetConfig(this.RenderComponent.InteractionConfig);
			}
			else
			{
				this.UpdateInteraction(this.InteractionDefaultRadius, this.InteractionDefaultBias, true);
			}
			base.OnInitSuccess();
		}

		// Token: 0x0602F5B7 RID: 193975 RVA: 0x00B3BE14 File Offset: 0x00B3A014
		public override void Update()
		{
			if (this.IsOnMobile || this.GrassInteractionComponent == null)
			{
				return;
			}
			if (!this.NeedBoneMotion)
			{
				return;
			}
			float num = (float)this.GetRefBoneHeight();
			this.AverageBoneHeight = this.AverageBoneHeight * 0.9f + num * 0.1f;
			float num2 = num - this.AverageBoneHeight;
			if (num2 < -10f)
			{
				num2 = -10f;
			}
			FVectorDouble newLocation = new FVectorDouble((double)this.BaseBias.Value.X, (double)this.BaseBias.Value.Y, (double)this.BaseBias.Value.Z + (double)num2 * 3.0);
			FHitResult fhitResult = new FHitResult();
			this.GrassInteractionComponent.D_K2_SetRelativeLocation(newLocation, false, ref fhitResult, false);
		}

		// Token: 0x0602F5B8 RID: 193976 RVA: 0x00B3BED1 File Offset: 0x00B3A0D1
		public override void PostBodyInfoRuntimeInit(FName bodyName)
		{
			this.UpdateForAimisi();
		}

		// Token: 0x0602F5B9 RID: 193977 RVA: 0x00B3BEDC File Offset: 0x00B3A0DC
		public void UpdateForAimisi()
		{
			if (this.GrassInteractionComponent != null)
			{
				USkeletalMeshComponent ownerSkeletal = this.OwnerSkeletal;
				USkeletalMesh uskeletalMesh = (ownerSkeletal != null) ? ownerSkeletal.SkeletalMesh : null;
				if (uskeletalMesh != null)
				{
					string name = uskeletalMesh.GetName();
					if (name == "R2T1AimisiGDMd10011")
					{
						this.GrassInteractionComponent.Radius = 150f;
						this.AverageBoneHeight = (float)this.GetRefBoneHeight();
						this.BaseBias = new FVector?(new FVector(0f, 0f, -7f));
						return;
					}
					if (name == "R2T1AimisiMd10011")
					{
						this.GrassInteractionComponent.Radius = 70f;
						this.AverageBoneHeight = (float)this.GetRefBoneHeight();
						this.OwnerCapsule.CapsuleHalfHeight = 77f;
						this.BaseBias = new FVector?(new FVector(0f, 0f, -7f));
					}
				}
			}
		}

		// Token: 0x0602F5BA RID: 193978 RVA: 0x00B3BFB7 File Offset: 0x00B3A1B7
		public override void Destroy()
		{
			if (this.GrassInteractionComponent != null)
			{
				AActor owner = this.GrassInteractionComponent.GetOwner();
				if (owner == null)
				{
					return;
				}
				owner.K2_DestroyComponent(this.GrassInteractionComponent);
			}
		}

		// Token: 0x0602F5BB RID: 193979 RVA: 0x00B3BFDC File Offset: 0x00B3A1DC
		[NullableContext(1)]
		public override string GetStatName()
		{
			return "CharGrassInteraction";
		}

		// Token: 0x0602F5BC RID: 193980 RVA: 0x00B3BFE3 File Offset: 0x00B3A1E3
		public override int GetComponentId()
		{
			return 11;
		}

		// Token: 0x0401AF74 RID: 110452
		public UKuroGrassInteractionSphereComponent GrassInteractionComponent;

		// Token: 0x0401AF75 RID: 110453
		public bool Enabled = true;

		// Token: 0x0401AF76 RID: 110454
		public bool IsOnMobile;

		// Token: 0x0401AF77 RID: 110455
		public UCapsuleComponent OwnerCapsule;

		// Token: 0x0401AF78 RID: 110456
		public USkeletalMeshComponent OwnerSkeletal;

		// Token: 0x0401AF79 RID: 110457
		public FVector? BaseBias;

		// Token: 0x0401AF7A RID: 110458
		private float AverageBoneHeight;

		// Token: 0x0401AF7B RID: 110459
		private bool NeedBoneMotion;

		// Token: 0x0401AF7C RID: 110460
		public readonly float InteractionDefaultRadius = 70f;

		// Token: 0x0401AF7D RID: 110461
		public readonly FVector InteractionDefaultBias = new FVector(0f, 0f, 70f);
	}
}
