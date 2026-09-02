using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DE3 RID: 19939
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseDifficultyLevelInfo : ITrapDefenseDifficultyLevelInfo
	{
		// Token: 0x17008880 RID: 34944
		// (get) Token: 0x0603395D RID: 211293 RVA: 0x00CE4929 File Offset: 0x00CE2B29
		// (set) Token: 0x0603395E RID: 211294 RVA: 0x00CE4931 File Offset: 0x00CE2B31
		public ETrapDefenseDifficultyLevel DifficultyLevel { get; set; }

		// Token: 0x17008881 RID: 34945
		// (get) Token: 0x0603395F RID: 211295 RVA: 0x00CE493A File Offset: 0x00CE2B3A
		// (set) Token: 0x06033960 RID: 211296 RVA: 0x00CE4942 File Offset: 0x00CE2B42
		public string NameKey { get; set; } = "";

		// Token: 0x17008882 RID: 34946
		// (get) Token: 0x06033961 RID: 211297 RVA: 0x00CE494B File Offset: 0x00CE2B4B
		// (set) Token: 0x06033962 RID: 211298 RVA: 0x00CE4953 File Offset: 0x00CE2B53
		public string NameBgKey { get; set; } = "";

		// Token: 0x17008883 RID: 34947
		// (get) Token: 0x06033963 RID: 211299 RVA: 0x00CE495C File Offset: 0x00CE2B5C
		// (set) Token: 0x06033964 RID: 211300 RVA: 0x00CE4964 File Offset: 0x00CE2B64
		public string BgKey { get; set; } = "";

		// Token: 0x17008884 RID: 34948
		// (get) Token: 0x06033965 RID: 211301 RVA: 0x00CE496D File Offset: 0x00CE2B6D
		// (set) Token: 0x06033966 RID: 211302 RVA: 0x00CE4975 File Offset: 0x00CE2B75
		public string BgLightKey { get; set; } = "";

		// Token: 0x17008885 RID: 34949
		// (get) Token: 0x06033967 RID: 211303 RVA: 0x00CE497E File Offset: 0x00CE2B7E
		// (set) Token: 0x06033968 RID: 211304 RVA: 0x00CE4986 File Offset: 0x00CE2B86
		public string BgTitleKey { get; set; } = "";

		// Token: 0x17008886 RID: 34950
		// (get) Token: 0x06033969 RID: 211305 RVA: 0x00CE498F File Offset: 0x00CE2B8F
		// (set) Token: 0x0603396A RID: 211306 RVA: 0x00CE4997 File Offset: 0x00CE2B97
		public string BgFlowerColor { get; set; } = "";

		// Token: 0x17008887 RID: 34951
		// (get) Token: 0x0603396B RID: 211307 RVA: 0x00CE49A0 File Offset: 0x00CE2BA0
		// (set) Token: 0x0603396C RID: 211308 RVA: 0x00CE49A8 File Offset: 0x00CE2BA8
		public string ArtTextShadowColor { get; set; } = "";
	}
}
