using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007037 RID: 28727
	[NullableContext(1)]
	public interface IPlaySequenceData
	{
		// Token: 0x1700A50F RID: 42255
		// (get) Token: 0x060458A2 RID: 284834
		// (set) Token: 0x060458A3 RID: 284835
		string Path { get; set; }

		// Token: 0x1700A510 RID: 42256
		// (get) Token: 0x060458A4 RID: 284836
		// (set) Token: 0x060458A5 RID: 284837
		bool? ResetCamera { get; set; }
	}
}
