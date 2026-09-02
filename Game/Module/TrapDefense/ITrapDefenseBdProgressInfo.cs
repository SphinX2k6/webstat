using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DDF RID: 19935
	[NullableContext(1)]
	public interface ITrapDefenseBdProgressInfo
	{
		// Token: 0x17008870 RID: 34928
		// (get) Token: 0x06033948 RID: 211272
		TrapDefenseBdData BdData { get; }

		// Token: 0x17008871 RID: 34929
		// (get) Token: 0x06033949 RID: 211273
		bool IsActive { get; }

		// Token: 0x17008872 RID: 34930
		// (get) Token: 0x0603394A RID: 211274
		bool IsShowQualityArrow { get; }

		// Token: 0x17008873 RID: 34931
		// (get) Token: 0x0603394B RID: 211275
		ETrapDefenseResKey QualityArrowRes { get; }
	}
}
