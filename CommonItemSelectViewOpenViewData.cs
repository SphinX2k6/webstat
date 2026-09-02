using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020018A4 RID: 6308
[NullableContext(2)]
[Nullable(0)]
public class CommonItemSelectViewOpenViewData<T> : UiPopViewData
{
	// Token: 0x04005591 RID: 21905
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<T> ItemDataBaseList;

	// Token: 0x04005592 RID: 21906
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<ISelectedData> SelectedDataList;

	// Token: 0x04005593 RID: 21907
	public SelectableComponentData SelectableComponentData;

	// Token: 0x04005594 RID: 21908
	public CommonIntensifyPropExpData ExpData;

	// Token: 0x04005595 RID: 21909
	public ESelectableComponentType SelectableComponentType;

	// Token: 0x04005596 RID: 21910
	public EFilterSortGroupId UseWayId;

	// Token: 0x04005597 RID: 21911
	public bool InitSortToggleState;
}
