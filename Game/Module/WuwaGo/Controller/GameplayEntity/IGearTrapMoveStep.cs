using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B0C RID: 19212
	[NullableContext(1)]
	public interface IGearTrapMoveStep
	{
		// Token: 0x1700858A RID: 34186
		// (get) Token: 0x060321A3 RID: 205219
		Vector Direction { get; }

		// Token: 0x1700858B RID: 34187
		// (get) Token: 0x060321A4 RID: 205220
		Vector TargetCoordinate { get; }
	}
}
