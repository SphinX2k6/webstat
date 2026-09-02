using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Pawn.Component
{
	// Token: 0x020048AD RID: 18605
	[NullableContext(2)]
	[Nullable(0)]
	public class PawnInteractBaseComponent : EntityComponent
	{
		// Token: 0x060307CA RID: 198602 RVA: 0x00BE566C File Offset: 0x00BE386C
		public virtual bool InteractPawn(int optionInstanceId = -1, CommonInteractOption autoOption = null)
		{
			return true;
		}

		// Token: 0x060307CB RID: 198603 RVA: 0x00BE566F File Offset: 0x00BE386F
		public virtual void CloseInteract(string reason = null)
		{
		}

		// Token: 0x060307CC RID: 198604 RVA: 0x00BE5671 File Offset: 0x00BE3871
		public virtual void ForceUpdate()
		{
		}

		// Token: 0x060307CD RID: 198605 RVA: 0x00BE5673 File Offset: 0x00BE3873
		public virtual bool IsPawnInteractive()
		{
			return false;
		}

		// Token: 0x170082B0 RID: 33456
		// (get) Token: 0x060307CE RID: 198606 RVA: 0x00BE5676 File Offset: 0x00BE3876
		public virtual AActor OwnerActor
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060307CF RID: 198607 RVA: 0x00BE5679 File Offset: 0x00BE3879
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			PawnInteractBaseComponent pawnInteractBaseComponent = (PawnInteractBaseComponent)componentTemplate;
			return true;
		}
	}
}
