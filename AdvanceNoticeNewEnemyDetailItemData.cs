using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200118F RID: 4495
[NullableContext(1)]
[Nullable(0)]
public class AdvanceNoticeNewEnemyDetailItemData
{
	// Token: 0x0400393F RID: 14655
	public string Title = "";

	// Token: 0x04003940 RID: 14656
	public object[] TitleArgs = Array.Empty<object>();

	// Token: 0x04003941 RID: 14657
	public List<PhantomFetterGroup> FetterSuitList = new List<PhantomFetterGroup>();

	// Token: 0x04003942 RID: 14658
	public string DescText = "";

	// Token: 0x04003943 RID: 14659
	public bool TitleChangeColor;
}
