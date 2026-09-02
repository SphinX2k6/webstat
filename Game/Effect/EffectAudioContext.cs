using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Effect
{
	// Token: 0x0200703F RID: 28735
	public class EffectAudioContext : EffectContext
	{
		// Token: 0x060458B4 RID: 284852 RVA: 0x0122D174 File Offset: 0x0122B374
		[NullableContext(1)]
		public override void ToKuroEffectContext(FKuroEffectContext context)
		{
			base.ToKuroEffectContext(context);
			FKuroEffectAudioContext fkuroEffectAudioContext = context as FKuroEffectAudioContext;
			if (fkuroEffectAudioContext != null)
			{
				fkuroEffectAudioContext.FromPrimaryRole = this.FromPrimaryRole;
			}
		}

		// Token: 0x04026D43 RID: 159043
		public bool FromPrimaryRole;
	}
}
