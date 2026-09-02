using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.ExtraEffect
{
	// Token: 0x02004989 RID: 18825
	[NullableContext(1)]
	[Nullable(0)]
	public class AbnormalWind : PeriodExecution
	{
		// Token: 0x06031301 RID: 201473 RVA: 0x00C3F277 File Offset: 0x00C3D477
		public AbnormalWind(RequireAndLimits requireAndLimits) : base(requireAndLimits)
		{
		}

		// Token: 0x06031302 RID: 201474 RVA: 0x00C3F280 File Offset: 0x00C3D480
		[return: Nullable(2)]
		public override object OnExecute(params object[] args)
		{
			return null;
		}
	}
}
