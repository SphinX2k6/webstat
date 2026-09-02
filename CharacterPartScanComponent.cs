using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x0200305F RID: 12383
[NullableContext(2)]
[Nullable(0)]
public class CharacterPartScanComponent : EntityComponent
{
	// Token: 0x0601971E RID: 104222 RVA: 0x0075AB99 File Offset: 0x00758D99
	protected override bool OnInit()
	{
		this.PartComponent = base.Entity.GetComponent<CharacterPartComponent>();
		this.ActorComponent = base.Entity.GetComponent<CharacterActorComponent>();
		this.RenderingComponent = this.ActorComponent.Actor.CharRenderingComponent;
		return true;
	}

	// Token: 0x0601971F RID: 104223 RVA: 0x0075ABD4 File Offset: 0x00758DD4
	public void ShowScanEffect()
	{
		if (!this.PartComponent.IsMultiPart)
		{
			return;
		}
		foreach (CharacterPart characterPart in this.PartComponent.Parts)
		{
			if (characterPart != null && characterPart.ScanEffect != null && ((characterPart != null) ? characterPart.ScanEffect : null) != "None")
			{
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				UObject gameInstance = GlobalData.GameInstance;
				FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble());
				int id = instance.SpawnEffect(gameInstance, ftransformDouble, characterPart.ScanEffect, "[CharacterPartScanComponent.ShowScanEffect]", new EffectContext(new int?(base.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false);
				if (Singleton<EffectSystem>.Instance.IsValid(id))
				{
					OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(id);
					if (effectActor.IsValid())
					{
						effectActor.K2_AttachToComponent(this.ActorComponent.Actor.Mesh, characterPart.ScanEffectSocketName, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false);
					}
				}
			}
			if (characterPart.ScanMaterialEffect != null && this.RenderingComponent != null && this.RenderingComponent.CheckInit())
			{
				this.RenderingComponent.AddMaterialControllerData(characterPart.ScanMaterialEffect);
			}
		}
	}

	// Token: 0x06019720 RID: 104224 RVA: 0x0075ACF8 File Offset: 0x00758EF8
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterPartScanComponent characterPartScanComponent = (CharacterPartScanComponent)componentTemplate;
		if (base.CanResetComponentProperty("PartComponent"))
		{
			if (characterPartScanComponent.PartComponent == null)
			{
				this.PartComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterPartComponent>(this.PartComponent), "PartComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComponent"))
		{
			if (characterPartScanComponent.ActorComponent == null)
			{
				this.ActorComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComponent), "ActorComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RenderingComponent"))
		{
			if (characterPartScanComponent.RenderingComponent == null)
			{
				this.RenderingComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharRenderingComponent>(this.RenderingComponent), "RenderingComponent"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400C98A RID: 51594
	private CharacterPartComponent PartComponent;

	// Token: 0x0400C98B RID: 51595
	private CharacterActorComponent ActorComponent;

	// Token: 0x0400C98C RID: 51596
	private CharRenderingComponent RenderingComponent;
}
