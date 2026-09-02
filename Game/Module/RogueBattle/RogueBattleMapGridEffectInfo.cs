using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005253 RID: 21075
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleMapGridEffectInfo : IRogueBattleMapGridEffectInfo
	{
		// Token: 0x17008CE5 RID: 36069
		// (get) Token: 0x06035F3B RID: 220987 RVA: 0x00D921D2 File Offset: 0x00D903D2
		// (set) Token: 0x06035F3C RID: 220988 RVA: 0x00D921DA File Offset: 0x00D903DA
		public string TagKey { get; set; } = string.Empty;

		// Token: 0x17008CE6 RID: 36070
		// (get) Token: 0x06035F3D RID: 220989 RVA: 0x00D921E3 File Offset: 0x00D903E3
		// (set) Token: 0x06035F3E RID: 220990 RVA: 0x00D921EB File Offset: 0x00D903EB
		public int Count { get; set; }

		// Token: 0x17008CE7 RID: 36071
		// (get) Token: 0x06035F3F RID: 220991 RVA: 0x00D921F4 File Offset: 0x00D903F4
		// (set) Token: 0x06035F40 RID: 220992 RVA: 0x00D921FC File Offset: 0x00D903FC
		public bool IsRatio { get; set; }

		// Token: 0x17008CE8 RID: 36072
		// (get) Token: 0x06035F41 RID: 220993 RVA: 0x00D92205 File Offset: 0x00D90405
		// (set) Token: 0x06035F42 RID: 220994 RVA: 0x00D9220D File Offset: 0x00D9040D
		public string Icon { get; set; } = string.Empty;
	}
}
