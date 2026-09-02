using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E0B RID: 24075
	[NullableContext(1)]
	[Nullable(0)]
	public class CookRoleItemData : ICookRoleItemData
	{
		// Token: 0x1700991D RID: 39197
		// (get) Token: 0x0603C956 RID: 248150 RVA: 0x00F62407 File Offset: 0x00F60607
		// (set) Token: 0x0603C957 RID: 248151 RVA: 0x00F6240F File Offset: 0x00F6060F
		public int RoleId { get; set; }

		// Token: 0x1700991E RID: 39198
		// (get) Token: 0x0603C958 RID: 248152 RVA: 0x00F62418 File Offset: 0x00F60618
		// (set) Token: 0x0603C959 RID: 248153 RVA: 0x00F62420 File Offset: 0x00F60620
		public string RoleName { get; set; }

		// Token: 0x1700991F RID: 39199
		// (get) Token: 0x0603C95A RID: 248154 RVA: 0x00F62429 File Offset: 0x00F60629
		// (set) Token: 0x0603C95B RID: 248155 RVA: 0x00F62431 File Offset: 0x00F60631
		public string RoleIcon { get; set; }

		// Token: 0x17009920 RID: 39200
		// (get) Token: 0x0603C95C RID: 248156 RVA: 0x00F6243A File Offset: 0x00F6063A
		// (set) Token: 0x0603C95D RID: 248157 RVA: 0x00F62442 File Offset: 0x00F60642
		public bool IsBuff { get; set; }

		// Token: 0x17009921 RID: 39201
		// (get) Token: 0x0603C95E RID: 248158 RVA: 0x00F6244B File Offset: 0x00F6064B
		// (set) Token: 0x0603C95F RID: 248159 RVA: 0x00F62453 File Offset: 0x00F60653
		public int ItemId { get; set; }
	}
}
