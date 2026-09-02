using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007025 RID: 28709
	[NullableContext(1)]
	public interface ILog
	{
		// Token: 0x1700A4F3 RID: 42227
		// (get) Token: 0x06045864 RID: 284772
		// (set) Token: 0x06045865 RID: 284773
		string Level { get; set; }

		// Token: 0x1700A4F4 RID: 42228
		// (get) Token: 0x06045866 RID: 284774
		// (set) Token: 0x06045867 RID: 284775
		string Content { get; set; }
	}
}
