using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DE5 RID: 19941
	[NullableContext(1)]
	public interface ITrapDefenseLevelTargetInfo
	{
		// Token: 0x17008888 RID: 34952
		// (get) Token: 0x0603396E RID: 211310
		ETrapDefenseLevelTarget TargetType { get; }

		// Token: 0x17008889 RID: 34953
		// (get) Token: 0x0603396F RID: 211311
		string NameKey { get; }

		// Token: 0x1700888A RID: 34954
		// (get) Token: 0x06033970 RID: 211312
		string IconKey { get; }
	}
}
