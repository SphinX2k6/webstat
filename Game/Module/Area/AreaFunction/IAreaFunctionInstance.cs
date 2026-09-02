using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Area.AreaFunction
{
	// Token: 0x0200617E RID: 24958
	[NullableContext(1)]
	public interface IAreaFunctionInstance
	{
		// Token: 0x0603F141 RID: 258369
		void OnEnter();

		// Token: 0x0603F142 RID: 258370
		void OnTick(double deltaMs);

		// Token: 0x0603F143 RID: 258371
		void OnLeave(string reason);
	}
}
