using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Pawn.Component
{
	// Token: 0x020048AC RID: 18604
	public class PawnGamePlayComponent : EntityComponent
	{
		// Token: 0x060307C5 RID: 198597 RVA: 0x00BE5649 File Offset: 0x00BE3849
		public void ScanResponse()
		{
		}

		// Token: 0x060307C6 RID: 198598 RVA: 0x00BE564B File Offset: 0x00BE384B
		public void WeightResponse()
		{
		}

		// Token: 0x060307C7 RID: 198599 RVA: 0x00BE564D File Offset: 0x00BE384D
		public void GrabResponse()
		{
		}

		// Token: 0x060307C8 RID: 198600 RVA: 0x00BE564F File Offset: 0x00BE384F
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			PawnGamePlayComponent pawnGamePlayComponent = (PawnGamePlayComponent)componentTemplate;
			return true;
		}
	}
}
