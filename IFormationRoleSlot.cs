using System;

// Token: 0x02001B49 RID: 6985
public interface IFormationRoleSlot
{
	// Token: 0x0600C9F8 RID: 51704
	void Reset();

	// Token: 0x0600C9F9 RID: 51705
	void MouseCancelDrag();

	// Token: 0x0600C9FA RID: 51706
	int GetPlayerId();

	// Token: 0x0600C9FB RID: 51707
	int? GetConfigId();

	// Token: 0x0600C9FC RID: 51708
	void EndShowDragItem();

	// Token: 0x0600C9FD RID: 51709
	void ShowOtherItemUpState();

	// Token: 0x0600C9FE RID: 51710
	void GamePadPress();

	// Token: 0x0600C9FF RID: 51711
	void GamePadRelease();

	// Token: 0x0600CA00 RID: 51712
	void GamePadUp(bool isCancel = false);

	// Token: 0x0600CA01 RID: 51713
	void RefreshLockItemState(bool isDrag);
}
