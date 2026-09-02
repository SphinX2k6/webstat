using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004A9D RID: 19101
	[RequiredMember]
	public class WallFrame : IWallFrame
	{
		// Token: 0x170084BA RID: 33978
		// (get) Token: 0x06031CFD RID: 204029 RVA: 0x00C79834 File Offset: 0x00C77A34
		// (set) Token: 0x06031CFE RID: 204030 RVA: 0x00C7983C File Offset: 0x00C77A3C
		[RequiredMember]
		public int WallNormalX { get; set; }

		// Token: 0x170084BB RID: 33979
		// (get) Token: 0x06031CFF RID: 204031 RVA: 0x00C79845 File Offset: 0x00C77A45
		// (set) Token: 0x06031D00 RID: 204032 RVA: 0x00C7984D File Offset: 0x00C77A4D
		[RequiredMember]
		public int WallNormalY { get; set; }

		// Token: 0x170084BC RID: 33980
		// (get) Token: 0x06031D01 RID: 204033 RVA: 0x00C79856 File Offset: 0x00C77A56
		// (set) Token: 0x06031D02 RID: 204034 RVA: 0x00C7985E File Offset: 0x00C77A5E
		[RequiredMember]
		public int WallTangentX { get; set; }

		// Token: 0x170084BD RID: 33981
		// (get) Token: 0x06031D03 RID: 204035 RVA: 0x00C79867 File Offset: 0x00C77A67
		// (set) Token: 0x06031D04 RID: 204036 RVA: 0x00C7986F File Offset: 0x00C77A6F
		[RequiredMember]
		public int WallTangentY { get; set; }

		// Token: 0x170084BE RID: 33982
		// (get) Token: 0x06031D05 RID: 204037 RVA: 0x00C79878 File Offset: 0x00C77A78
		// (set) Token: 0x06031D06 RID: 204038 RVA: 0x00C79880 File Offset: 0x00C77A80
		[RequiredMember]
		public int OwnerSign { get; set; }

		// Token: 0x170084BF RID: 33983
		// (get) Token: 0x06031D07 RID: 204039 RVA: 0x00C79889 File Offset: 0x00C77A89
		// (set) Token: 0x06031D08 RID: 204040 RVA: 0x00C79891 File Offset: 0x00C77A91
		[RequiredMember]
		public float OwnerOffsetX { get; set; }

		// Token: 0x170084C0 RID: 33984
		// (get) Token: 0x06031D09 RID: 204041 RVA: 0x00C7989A File Offset: 0x00C77A9A
		// (set) Token: 0x06031D0A RID: 204042 RVA: 0x00C798A2 File Offset: 0x00C77AA2
		[RequiredMember]
		public float OwnerOffsetY { get; set; }

		// Token: 0x06031D0B RID: 204043 RVA: 0x00C798AB File Offset: 0x00C77AAB
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public WallFrame()
		{
		}
	}
}
