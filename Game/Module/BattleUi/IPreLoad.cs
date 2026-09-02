using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F81 RID: 24449
	[NullableContext(1)]
	public interface IPreLoad
	{
		// Token: 0x17009A5B RID: 39515
		// (get) Token: 0x0603D634 RID: 251444
		string ResourceId { get; }

		// Token: 0x17009A5C RID: 39516
		// (get) Token: 0x0603D635 RID: 251445
		int PreloadCount { get; }
	}
}
