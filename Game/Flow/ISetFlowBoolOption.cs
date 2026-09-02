using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007032 RID: 28722
	[NullableContext(1)]
	public interface ISetFlowBoolOption
	{
		// Token: 0x1700A50B RID: 42251
		// (get) Token: 0x06045896 RID: 284822
		// (set) Token: 0x06045897 RID: 284823
		string Option { get; set; }

		// Token: 0x1700A50C RID: 42252
		// (get) Token: 0x06045898 RID: 284824
		// (set) Token: 0x06045899 RID: 284825
		bool Value { get; set; }
	}
}
