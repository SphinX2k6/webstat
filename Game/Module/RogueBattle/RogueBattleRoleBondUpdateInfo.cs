using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005240 RID: 21056
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleRoleBondUpdateInfo : IRogueBattleRoleBondUpdateInfo
	{
		// Token: 0x17008CAA RID: 36010
		// (get) Token: 0x06035EBC RID: 220860 RVA: 0x00D91F5B File Offset: 0x00D9015B
		// (set) Token: 0x06035EBD RID: 220861 RVA: 0x00D91F63 File Offset: 0x00D90163
		public RoleBondInfo OldRoleBondInfo { get; set; }

		// Token: 0x17008CAB RID: 36011
		// (get) Token: 0x06035EBE RID: 220862 RVA: 0x00D91F6C File Offset: 0x00D9016C
		// (set) Token: 0x06035EBF RID: 220863 RVA: 0x00D91F74 File Offset: 0x00D90174
		public RoleBondInfo NewRoleBondInfo { get; set; }

		// Token: 0x17008CAC RID: 36012
		// (get) Token: 0x06035EC0 RID: 220864 RVA: 0x00D91F7D File Offset: 0x00D9017D
		// (set) Token: 0x06035EC1 RID: 220865 RVA: 0x00D91F85 File Offset: 0x00D90185
		public int AddStar { get; set; }
	}
}
