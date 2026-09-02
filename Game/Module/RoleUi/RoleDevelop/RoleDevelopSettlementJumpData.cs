using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x02005090 RID: 20624
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopSettlementJumpData : IRoleDevelopSettlementJumpData
	{
		// Token: 0x17008BBB RID: 35771
		// (get) Token: 0x06035269 RID: 217705 RVA: 0x00D52ED1 File Offset: 0x00D510D1
		// (set) Token: 0x0603526A RID: 217706 RVA: 0x00D52ED9 File Offset: 0x00D510D9
		public bool CanShow { get; set; }

		// Token: 0x17008BBC RID: 35772
		// (get) Token: 0x0603526B RID: 217707 RVA: 0x00D52EE2 File Offset: 0x00D510E2
		// (set) Token: 0x0603526C RID: 217708 RVA: 0x00D52EEA File Offset: 0x00D510EA
		public int RoleId { get; set; }

		// Token: 0x17008BBD RID: 35773
		// (get) Token: 0x0603526D RID: 217709 RVA: 0x00D52EF3 File Offset: 0x00D510F3
		// (set) Token: 0x0603526E RID: 217710 RVA: 0x00D52EFB File Offset: 0x00D510FB
		public string RoleIconPath { get; set; }

		// Token: 0x17008BBE RID: 35774
		// (get) Token: 0x0603526F RID: 217711 RVA: 0x00D52F04 File Offset: 0x00D51104
		// (set) Token: 0x06035270 RID: 217712 RVA: 0x00D52F0C File Offset: 0x00D5110C
		public List<int> MatchedItemIds { get; set; }

		// Token: 0x17008BBF RID: 35775
		// (get) Token: 0x06035271 RID: 217713 RVA: 0x00D52F15 File Offset: 0x00D51115
		// (set) Token: 0x06035272 RID: 217714 RVA: 0x00D52F1D File Offset: 0x00D5111D
		public List<int> NeedCheckItemIds { get; set; }

		// Token: 0x17008BC0 RID: 35776
		// (get) Token: 0x06035273 RID: 217715 RVA: 0x00D52F26 File Offset: 0x00D51126
		// (set) Token: 0x06035274 RID: 217716 RVA: 0x00D52F2E File Offset: 0x00D5112E
		public ERoleDevelopSettlementSourceDungeonType SourceDungeonType { get; set; }
	}
}
