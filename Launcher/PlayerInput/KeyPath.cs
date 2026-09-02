using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.PlayerInput
{
	// Token: 0x0200454B RID: 17739
	[NullableContext(1)]
	[Nullable(0)]
	public class KeyPath : IKeyPath
	{
		// Token: 0x1700805B RID: 32859
		// (get) Token: 0x0602EAEF RID: 191215 RVA: 0x00B0FB8C File Offset: 0x00B0DD8C
		// (set) Token: 0x0602EAF0 RID: 191216 RVA: 0x00B0FB94 File Offset: 0x00B0DD94
		[Nullable(2)]
		public string XBox { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700805C RID: 32860
		// (get) Token: 0x0602EAF1 RID: 191217 RVA: 0x00B0FB9D File Offset: 0x00B0DD9D
		// (set) Token: 0x0602EAF2 RID: 191218 RVA: 0x00B0FBA5 File Offset: 0x00B0DDA5
		public string Ps { get; set; } = "";
	}
}
