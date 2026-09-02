using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063C5 RID: 25541
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeBlessingReplaceParam : IRoverlikeBlessingReplaceParam
	{
		// Token: 0x17009DA1 RID: 40353
		// (get) Token: 0x06040221 RID: 262689 RVA: 0x0106FDB5 File Offset: 0x0106DFB5
		// (set) Token: 0x06040222 RID: 262690 RVA: 0x0106FDBD File Offset: 0x0106DFBD
		public int CurBlessId { get; set; }

		// Token: 0x17009DA2 RID: 40354
		// (get) Token: 0x06040223 RID: 262691 RVA: 0x0106FDC6 File Offset: 0x0106DFC6
		// (set) Token: 0x06040224 RID: 262692 RVA: 0x0106FDCE File Offset: 0x0106DFCE
		public int NewBlessId { get; set; }

		// Token: 0x17009DA3 RID: 40355
		// (get) Token: 0x06040225 RID: 262693 RVA: 0x0106FDD7 File Offset: 0x0106DFD7
		// (set) Token: 0x06040226 RID: 262694 RVA: 0x0106FDDF File Offset: 0x0106DFDF
		public ERoverlikeBlessingReplaceType Type { get; set; }

		// Token: 0x17009DA4 RID: 40356
		// (get) Token: 0x06040227 RID: 262695 RVA: 0x0106FDE8 File Offset: 0x0106DFE8
		// (set) Token: 0x06040228 RID: 262696 RVA: 0x0106FDF0 File Offset: 0x0106DFF0
		public Action OnConfirm { get; set; }
	}
}
