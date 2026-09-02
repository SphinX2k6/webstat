using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.GameplayABP;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x02004901 RID: 18689
	public class CharacterLinkedAnimInstComponent : EntityComponent, IComponentDependency
	{
		// Token: 0x1700832D RID: 33581
		// (get) Token: 0x06030CEF RID: 199919 RVA: 0x00C11E50 File Offset: 0x00C10050
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Type[] Dependencies
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return new Type[]
				{
					typeof(CharacterActorComponent),
					typeof(BaseTagComponent),
					typeof(CharacterAnimationComponent)
				};
			}
		}

		// Token: 0x06030CF0 RID: 199920 RVA: 0x00C11E7F File Offset: 0x00C1007F
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
			this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
			return true;
		}

		// Token: 0x06030CF1 RID: 199921 RVA: 0x00C11EA4 File Offset: 0x00C100A4
		public virtual bool SyncLinkGameplayAnimBlueprint(EGameplayABPType gameplayType)
		{
			if (this.CurrentActivate == gameplayType)
			{
				return false;
			}
			this.CurrentActivate = gameplayType;
			string gameplayABPAssetPath = this.GetGameplayABPAssetPath(gameplayType);
			if (gameplayABPAssetPath == "")
			{
				return false;
			}
			UClass classPtr = Singleton<ResourceSystem>.Instance.Load<UClass>(gameplayABPAssetPath, "js_undefined");
			CharacterAnimationComponent animComp = this.AnimComp;
			USkeletalMeshComponent uskeletalMeshComponent;
			if (animComp == null)
			{
				uskeletalMeshComponent = null;
			}
			else
			{
				TsBaseCharacter actor = animComp.Actor;
				uskeletalMeshComponent = ((actor != null) ? actor.Mesh : null);
			}
			USkeletalMeshComponent uskeletalMeshComponent2 = uskeletalMeshComponent;
			if (uskeletalMeshComponent2 != null)
			{
				uskeletalMeshComponent2.LinkAnimGraphByTag(Singleton<CharacterNameDefines>.Instance.ABP_GAMEPLAY, classPtr);
			}
			return uskeletalMeshComponent2 != null && uskeletalMeshComponent2.IsValid();
		}

		// Token: 0x06030CF2 RID: 199922 RVA: 0x00C11F30 File Offset: 0x00C10130
		[NullableContext(1)]
		protected string GetGameplayABPAssetPath(EGameplayABPType gameplayABPType)
		{
			if (gameplayABPType == EGameplayABPType.None)
			{
				return "";
			}
			UDataTable dtGameplayAbpConfig = this.ActorComp.Actor.DtGameplayAbpConfig;
			if (dtGameplayAbpConfig == null)
			{
				return "";
			}
			foreach (SGameplayABPAssetConfig sgameplayABPAssetConfig in DataTableUtil.GetDataTableAllRowFromTable<SGameplayABPAssetConfig>(dtGameplayAbpConfig))
			{
				if (sgameplayABPAssetConfig.Type == gameplayABPType)
				{
					TSoftClassPtr<UKuroAnimInstance> animInstance = sgameplayABPAssetConfig.AnimInstance;
					return ((animInstance != null) ? animInstance.ToAssetPathName() : null) ?? "";
				}
			}
			return "";
		}

		// Token: 0x06030CF3 RID: 199923 RVA: 0x00C11FD8 File Offset: 0x00C101D8
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterLinkedAnimInstComponent characterLinkedAnimInstComponent = (CharacterLinkedAnimInstComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (characterLinkedAnimInstComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("AnimComp"))
			{
				if (characterLinkedAnimInstComponent.AnimComp == null)
				{
					this.AnimComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurrentActivate"))
			{
				this.CurrentActivate = characterLinkedAnimInstComponent.CurrentActivate;
			}
			return true;
		}

		// Token: 0x0401C0CB RID: 114891
		[Nullable(2)]
		public CharacterActorComponent ActorComp;

		// Token: 0x0401C0CC RID: 114892
		[Nullable(2)]
		public CharacterAnimationComponent AnimComp;

		// Token: 0x0401C0CD RID: 114893
		protected EGameplayABPType CurrentActivate;
	}
}
