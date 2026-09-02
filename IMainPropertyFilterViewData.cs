using System;
using System.Runtime.CompilerServices;

// Token: 0x02001915 RID: 6421
[NullableContext(2)]
public interface IMainPropertyFilterViewData
{
	// Token: 0x17000F10 RID: 3856
	// (get) Token: 0x0600B893 RID: 47251
	// (set) Token: 0x0600B894 RID: 47252
	int UniqueId { get; set; }

	// Token: 0x17000F11 RID: 3857
	// (get) Token: 0x0600B895 RID: 47253
	// (set) Token: 0x0600B896 RID: 47254
	int DefaultSelectCostTab { get; set; }

	// Token: 0x17000F12 RID: 3858
	// (get) Token: 0x0600B897 RID: 47255
	// (set) Token: 0x0600B898 RID: 47256
	Action ConfirmFunction { get; set; }

	// Token: 0x17000F13 RID: 3859
	// (get) Token: 0x0600B899 RID: 47257
	// (set) Token: 0x0600B89A RID: 47258
	int? CurrentFetterId { get; set; }
}
