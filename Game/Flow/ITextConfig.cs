using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007022 RID: 28706
	[NullableContext(1)]
	public interface ITextConfig
	{
		// Token: 0x1700A4ED RID: 42221
		// (get) Token: 0x06045856 RID: 284758
		// (set) Token: 0x06045857 RID: 284759
		string Text { get; set; }

		// Token: 0x1700A4EE RID: 42222
		// (get) Token: 0x06045858 RID: 284760
		// (set) Token: 0x06045859 RID: 284761
		string Sound { get; set; }

		// Token: 0x1700A4EF RID: 42223
		// (get) Token: 0x0604585A RID: 284762
		// (set) Token: 0x0604585B RID: 284763
		string EsKey { get; set; }
	}
}
