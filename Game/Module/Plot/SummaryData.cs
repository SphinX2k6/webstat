using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200535E RID: 21342
	[NullableContext(2)]
	[Nullable(0)]
	public class SummaryData
	{
		// Token: 0x17008D74 RID: 36212
		// (get) Token: 0x06036710 RID: 222992 RVA: 0x00DBBAC6 File Offset: 0x00DB9CC6
		// (set) Token: 0x06036711 RID: 222993 RVA: 0x00DBBACE File Offset: 0x00DB9CCE
		[Nullable(1)]
		public string Text { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17008D75 RID: 36213
		// (get) Token: 0x06036712 RID: 222994 RVA: 0x00DBBAD7 File Offset: 0x00DB9CD7
		// (set) Token: 0x06036713 RID: 222995 RVA: 0x00DBBADF File Offset: 0x00DB9CDF
		public Action ConfirmFunc { get; set; }

		// Token: 0x17008D76 RID: 36214
		// (get) Token: 0x06036714 RID: 222996 RVA: 0x00DBBAE8 File Offset: 0x00DB9CE8
		// (set) Token: 0x06036715 RID: 222997 RVA: 0x00DBBAF0 File Offset: 0x00DB9CF0
		public Action CancelFunc { get; set; }
	}
}
