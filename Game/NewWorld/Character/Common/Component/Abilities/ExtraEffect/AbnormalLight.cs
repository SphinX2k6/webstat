using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.ExtraEffect
{
	// Token: 0x0200498A RID: 18826
	[NullableContext(1)]
	[Nullable(0)]
	public class AbnormalLight : PeriodExecution
	{
		// Token: 0x06031303 RID: 201475 RVA: 0x00C3F283 File Offset: 0x00C3D483
		public AbnormalLight(RequireAndLimits requireAndLimits) : base(requireAndLimits)
		{
		}

		// Token: 0x06031304 RID: 201476 RVA: 0x00C3F28C File Offset: 0x00C3D48C
		[return: Nullable(2)]
		public override object OnExecute(params object[] args)
		{
			return null;
		}
	}
}
