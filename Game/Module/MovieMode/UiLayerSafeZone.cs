using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056F0 RID: 22256
	[RequiredMember]
	public class UiLayerSafeZone : IUiLayerSafeZone
	{
		// Token: 0x1700910E RID: 37134
		// (get) Token: 0x06038A2F RID: 231983 RVA: 0x00E579C5 File Offset: 0x00E55BC5
		// (set) Token: 0x06038A30 RID: 231984 RVA: 0x00E579CD File Offset: 0x00E55BCD
		[RequiredMember]
		public float StretchLeft { get; set; }

		// Token: 0x1700910F RID: 37135
		// (get) Token: 0x06038A31 RID: 231985 RVA: 0x00E579D6 File Offset: 0x00E55BD6
		// (set) Token: 0x06038A32 RID: 231986 RVA: 0x00E579DE File Offset: 0x00E55BDE
		[RequiredMember]
		public float StretchRight { get; set; }

		// Token: 0x17009110 RID: 37136
		// (get) Token: 0x06038A33 RID: 231987 RVA: 0x00E579E7 File Offset: 0x00E55BE7
		// (set) Token: 0x06038A34 RID: 231988 RVA: 0x00E579EF File Offset: 0x00E55BEF
		[RequiredMember]
		public float StretchTop { get; set; }

		// Token: 0x17009111 RID: 37137
		// (get) Token: 0x06038A35 RID: 231989 RVA: 0x00E579F8 File Offset: 0x00E55BF8
		// (set) Token: 0x06038A36 RID: 231990 RVA: 0x00E57A00 File Offset: 0x00E55C00
		[RequiredMember]
		public float StretchBottom { get; set; }

		// Token: 0x06038A37 RID: 231991 RVA: 0x00E57A09 File Offset: 0x00E55C09
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public UiLayerSafeZone()
		{
		}
	}
}
