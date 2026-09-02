using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063C4 RID: 25540
	[NullableContext(2)]
	public interface IRoverlikeBlessingReplaceParam
	{
		// Token: 0x17009D9D RID: 40349
		// (get) Token: 0x06040219 RID: 262681
		// (set) Token: 0x0604021A RID: 262682
		int CurBlessId { get; set; }

		// Token: 0x17009D9E RID: 40350
		// (get) Token: 0x0604021B RID: 262683
		// (set) Token: 0x0604021C RID: 262684
		int NewBlessId { get; set; }

		// Token: 0x17009D9F RID: 40351
		// (get) Token: 0x0604021D RID: 262685
		// (set) Token: 0x0604021E RID: 262686
		ERoverlikeBlessingReplaceType Type { get; set; }

		// Token: 0x17009DA0 RID: 40352
		// (get) Token: 0x0604021F RID: 262687
		// (set) Token: 0x06040220 RID: 262688
		Action OnConfirm { get; set; }
	}
}
