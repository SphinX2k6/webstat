using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

// Token: 0x02002EBD RID: 11965
[NullableContext(1)]
[Nullable(0)]
public class CharacterMontageComponent : BaseMontageComponent
{
	// Token: 0x06018940 RID: 100672 RVA: 0x006EAB9F File Offset: 0x006E8D9F
	protected override bool OnStart()
	{
		this.AnimationComponent = base.Entity.CheckGetComponent<CharacterAnimationComponent>();
		return base.OnStart();
	}

	// Token: 0x06018941 RID: 100673 RVA: 0x006EABBD File Offset: 0x006E8DBD
	[NullableContext(2)]
	public override UAnimInstance GetMainAnimInstance()
	{
		return this.AnimationComponent.MainAnimInstance;
	}

	// Token: 0x06018942 RID: 100674 RVA: 0x006EABCC File Offset: 0x006E8DCC
	public override void AddMontage(string name, UAnimMontage montage, string path)
	{
		if (this.HasMorphMontage)
		{
			this.MorphComponent = (this.MorphComponent ?? base.Entity.GetComponent<CharacterMorphComponent>());
			CharacterMorphComponent morphComponent = this.MorphComponent;
			if (morphComponent != null)
			{
				EMorphType montagePathMorphType = morphComponent.GetMontagePathMorphType(path);
				if (montagePathMorphType != EMorphType.默认形态)
				{
					morphComponent.AddMorphMontagePath(path, montagePathMorphType);
					if (montage == null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Battle;
						ELogAuthor author = ELogAuthor.WWJ;
						string message = "添加的多形态蒙太奇不存在";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", name);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return;
					}
					morphComponent.AddMontage(name, montage, path);
					UKuroStaticLibrary.SetMontageANIndex(montage);
					return;
				}
			}
		}
		base.AddMontage(name, montage, path);
	}

	// Token: 0x06018943 RID: 100675 RVA: 0x006EAC60 File Offset: 0x006E8E60
	[return: Nullable(2)]
	public override UAnimMontage GetMontageByName(string name, bool includeMorphMontage = true, bool replaceMorphMontage = false)
	{
		if (includeMorphMontage && this.HasMorphMontage)
		{
			CharacterMorphComponent morphComponent = this.MorphComponent;
			if (morphComponent != null && morphComponent.IsMorphing())
			{
				UAnimMontage montageByName = morphComponent.GetMontageByName(name);
				if (montageByName == null && replaceMorphMontage)
				{
					montageByName = base.GetMontageByName(name, true, false);
				}
				return montageByName;
			}
		}
		return base.GetMontageByName(name, true, false);
	}

	// Token: 0x06018944 RID: 100676 RVA: 0x006EACB0 File Offset: 0x006E8EB0
	[return: Nullable(2)]
	public override string GetMontagePathByName(string name, bool includeMorphMontage = true, bool replaceMorphMontage = false)
	{
		if (includeMorphMontage && this.HasMorphMontage)
		{
			CharacterMorphComponent morphComponent = this.MorphComponent;
			if (morphComponent != null && morphComponent.IsMorphing())
			{
				string montagePathByName = morphComponent.GetMontagePathByName(name);
				if (montagePathByName == null && replaceMorphMontage)
				{
					montagePathByName = base.GetMontagePathByName(name, true, false);
				}
				return montagePathByName;
			}
		}
		return base.GetMontagePathByName(name, true, false);
	}

	// Token: 0x06018945 RID: 100677 RVA: 0x006EACFF File Offset: 0x006E8EFF
	public void SetHasMorphMontage(bool hasMorphMontage)
	{
		this.HasMorphMontage = hasMorphMontage;
	}

	// Token: 0x06018946 RID: 100678 RVA: 0x006EAD08 File Offset: 0x006E8F08
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterMontageComponent characterMontageComponent = (CharacterMontageComponent)componentTemplate;
		if (base.CanResetComponentProperty("AnimationComponent"))
		{
			if (characterMontageComponent.AnimationComponent == null)
			{
				this.AnimationComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimationComponent), "AnimationComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MorphComponent"))
		{
			if (characterMontageComponent.MorphComponent == null)
			{
				this.MorphComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMorphComponent>(this.MorphComponent), "MorphComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HasMorphMontage"))
		{
			this.HasMorphMontage = characterMontageComponent.HasMorphMontage;
		}
		return true;
	}

	// Token: 0x0400BE11 RID: 48657
	[Nullable(2)]
	public CharacterAnimationComponent AnimationComponent;

	// Token: 0x0400BE12 RID: 48658
	[Nullable(2)]
	public CharacterMorphComponent MorphComponent;

	// Token: 0x0400BE13 RID: 48659
	private bool HasMorphMontage;
}
