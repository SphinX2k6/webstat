using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FB7 RID: 20407
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffMainTabItemData : ISheriffMainTabItemData
	{
		// Token: 0x17008A77 RID: 35447
		// (get) Token: 0x06034A6F RID: 215663 RVA: 0x00D349C6 File Offset: 0x00D32BC6
		// (set) Token: 0x06034A70 RID: 215664 RVA: 0x00D349CE File Offset: 0x00D32BCE
		public ESheriffMainTabType TabType { get; set; }

		// Token: 0x17008A78 RID: 35448
		// (get) Token: 0x06034A71 RID: 215665 RVA: 0x00D349D7 File Offset: 0x00D32BD7
		// (set) Token: 0x06034A72 RID: 215666 RVA: 0x00D349DF File Offset: 0x00D32BDF
		public string TabIcon { get; set; } = "";

		// Token: 0x17008A79 RID: 35449
		// (get) Token: 0x06034A73 RID: 215667 RVA: 0x00D349E8 File Offset: 0x00D32BE8
		// (set) Token: 0x06034A74 RID: 215668 RVA: 0x00D349F0 File Offset: 0x00D32BF0
		public string TabTxt { get; set; } = "";

		// Token: 0x17008A7A RID: 35450
		// (get) Token: 0x06034A75 RID: 215669 RVA: 0x00D349F9 File Offset: 0x00D32BF9
		// (set) Token: 0x06034A76 RID: 215670 RVA: 0x00D34A01 File Offset: 0x00D32C01
		public bool? IsLock { get; set; }

		// Token: 0x17008A7B RID: 35451
		// (get) Token: 0x06034A77 RID: 215671 RVA: 0x00D34A0A File Offset: 0x00D32C0A
		// (set) Token: 0x06034A78 RID: 215672 RVA: 0x00D34A12 File Offset: 0x00D32C12
		public EFunctionType FunctionType { get; set; }
	}
}
