using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001970 RID: 6512
[NullableContext(2)]
public interface IItemGridVariantSelect
{
	// Token: 0x17000F29 RID: 3881
	// (get) Token: 0x0600BB17 RID: 47895
	bool IsItemGridVariantSelect { get; }

	// Token: 0x0600BB18 RID: 47896
	void RefreshItemShowState(bool stateState);

	// Token: 0x0600BB19 RID: 47897
	void RefreshReduceButtonShowState(bool stateState);

	// Token: 0x0600BB1A RID: 47898
	UUIItem GetFinishSelectItem();

	// Token: 0x0600BB1B RID: 47899
	UUIItem GetFinishMiddleItem();

	// Token: 0x0600BB1C RID: 47900
	UUIItem GetControlItem();

	// Token: 0x0600BB1D RID: 47901
	UUIButtonComponent GetReduceButton();

	// Token: 0x0600BB1E RID: 47902
	UUIButtonComponent GetAddButton();

	// Token: 0x0600BB1F RID: 47903
	[NullableContext(1)]
	void SetAddButtonCallBack(Action call);

	// Token: 0x0600BB20 RID: 47904
	[NullableContext(1)]
	void SetReduceClickEvent(Action call);
}
