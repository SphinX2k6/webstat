using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002032 RID: 8242
[NullableContext(1)]
[Nullable(0)]
public class ItemExpiredAutoConvertTipsViewDefine
{
	// Token: 0x0400788F RID: 30863
	public string TitleText = "";

	// Token: 0x04007890 RID: 30864
	public string BeforeTitleText = "";

	// Token: 0x04007891 RID: 30865
	public string AfterTitleText = "";

	// Token: 0x04007892 RID: 30866
	public IReadOnlyList<TItem> BeforeItemList = Array.Empty<TItem>();

	// Token: 0x04007893 RID: 30867
	public IReadOnlyList<TItem> AfterItemList = Array.Empty<TItem>();

	// Token: 0x04007894 RID: 30868
	public string CancelButtonText = "";

	// Token: 0x04007895 RID: 30869
	public string ConfirmButtonText = "";

	// Token: 0x04007896 RID: 30870
	[Nullable(2)]
	public Action<int> OnCancelCallBack;

	// Token: 0x04007897 RID: 30871
	[Nullable(2)]
	public Action<int> OnConfirmCallBack;
}
