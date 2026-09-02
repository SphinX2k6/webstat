using System;
using System.Runtime.CompilerServices;

// Token: 0x02001ADA RID: 6874
[NullableContext(2)]
[Nullable(0)]
internal class TabData
{
	// Token: 0x04005ECD RID: 24269
	public DangoAbyssActivityData ActivityData;

	// Token: 0x04005ECE RID: 24270
	public int CurrentSelectTabId;

	// Token: 0x04005ECF RID: 24271
	public int TabId;

	// Token: 0x04005ED0 RID: 24272
	public Action<int> ClickCallBack;
}
