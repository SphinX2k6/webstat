using System;
using CSharpScript.Game.Ui;

// Token: 0x02001B4A RID: 6986
public abstract class FormationRoleSlot : UiPanelBase, IFormationRoleSlot
{
	// Token: 0x0600CA02 RID: 51714
	public abstract void Reset();

	// Token: 0x0600CA03 RID: 51715
	public abstract void MouseCancelDrag();

	// Token: 0x0600CA04 RID: 51716
	public abstract int GetPlayerId();

	// Token: 0x0600CA05 RID: 51717
	public abstract int? GetConfigId();

	// Token: 0x0600CA06 RID: 51718
	public abstract void EndShowDragItem();

	// Token: 0x0600CA07 RID: 51719
	public abstract void ShowOtherItemUpState();

	// Token: 0x0600CA08 RID: 51720
	public abstract void GamePadPress();

	// Token: 0x0600CA09 RID: 51721
	public abstract void GamePadRelease();

	// Token: 0x0600CA0A RID: 51722
	public abstract void GamePadUp(bool isCancel = false);

	// Token: 0x0600CA0B RID: 51723
	public abstract void RefreshLockItemState(bool isDrag);
}
