using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleLangCustomModel
{
	// Token: 0x020050EF RID: 20719
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleLangCustomDeleteInfo : IRoleLangCustomDeleteInfo
	{
		// Token: 0x17008C32 RID: 35890
		// (get) Token: 0x0603564E RID: 218702 RVA: 0x00D64552 File Offset: 0x00D62752
		// (set) Token: 0x0603564F RID: 218703 RVA: 0x00D6455A File Offset: 0x00D6275A
		public int RoleId { get; set; }

		// Token: 0x17008C33 RID: 35891
		// (get) Token: 0x06035650 RID: 218704 RVA: 0x00D64563 File Offset: 0x00D62763
		// (set) Token: 0x06035651 RID: 218705 RVA: 0x00D6456B File Offset: 0x00D6276B
		public Action RefreshCallback { get; set; }

		// Token: 0x17008C34 RID: 35892
		// (get) Token: 0x06035652 RID: 218706 RVA: 0x00D64574 File Offset: 0x00D62774
		// (set) Token: 0x06035653 RID: 218707 RVA: 0x00D6457C File Offset: 0x00D6277C
		public Action CloseCallback { get; set; }
	}
}
