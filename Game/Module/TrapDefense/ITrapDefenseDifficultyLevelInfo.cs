using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DE2 RID: 19938
	[NullableContext(1)]
	public interface ITrapDefenseDifficultyLevelInfo
	{
		// Token: 0x17008878 RID: 34936
		// (get) Token: 0x06033955 RID: 211285
		ETrapDefenseDifficultyLevel DifficultyLevel { get; }

		// Token: 0x17008879 RID: 34937
		// (get) Token: 0x06033956 RID: 211286
		string NameKey { get; }

		// Token: 0x1700887A RID: 34938
		// (get) Token: 0x06033957 RID: 211287
		string NameBgKey { get; }

		// Token: 0x1700887B RID: 34939
		// (get) Token: 0x06033958 RID: 211288
		string BgKey { get; }

		// Token: 0x1700887C RID: 34940
		// (get) Token: 0x06033959 RID: 211289
		string BgLightKey { get; }

		// Token: 0x1700887D RID: 34941
		// (get) Token: 0x0603395A RID: 211290
		string BgTitleKey { get; }

		// Token: 0x1700887E RID: 34942
		// (get) Token: 0x0603395B RID: 211291
		string BgFlowerColor { get; }

		// Token: 0x1700887F RID: 34943
		// (get) Token: 0x0603395C RID: 211292
		string ArtTextShadowColor { get; }
	}
}
