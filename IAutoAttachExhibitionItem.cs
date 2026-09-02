using System;
using System.Runtime.CompilerServices;

// Token: 0x0200185E RID: 6238
[NullableContext(1)]
public interface IAutoAttachExhibitionItem
{
	// Token: 0x0600B2A9 RID: 45737
	void OnSelect();

	// Token: 0x0600B2AA RID: 45738
	void OnUnSelect();

	// Token: 0x0600B2AB RID: 45739
	void SetData(object param);

	// Token: 0x0600B2AC RID: 45740
	void RefreshItem(int showItemIndex);

	// Token: 0x0600B2AD RID: 45741
	void OnMoveItem(float offset);

	// Token: 0x0600B2AE RID: 45742
	void OnChangeDirection(int direction);

	// Token: 0x0600B2AF RID: 45743
	void SetShowItemIndex(int showIndex);

	// Token: 0x0600B2B0 RID: 45744
	int GetShowItemIndex();

	// Token: 0x0600B2B1 RID: 45745
	void SetAttachItem(AutoAttachExhibitionItem item);

	// Token: 0x0600B2B2 RID: 45746
	[NullableContext(2)]
	AutoAttachExhibitionItem GetAttachItem();

	// Token: 0x0600B2B3 RID: 45747
	void Clear();
}
