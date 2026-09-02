using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200119B RID: 4507
public abstract class AdvanceNoticeTabViewBase : UiTabViewBase
{
	// Token: 0x06007695 RID: 30357 RVA: 0x001F0A9E File Offset: 0x001EEC9E
	protected override void OnBeforeCreate()
	{
		this.ViewModel = (this.Params as AdvanceNoticeViewModel);
	}

	// Token: 0x06007696 RID: 30358 RVA: 0x001F0AB4 File Offset: 0x001EECB4
	protected override void OnBeforeShow()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
		}
		this.RefreshView();
	}

	// Token: 0x06007697 RID: 30359 RVA: 0x001F0AE8 File Offset: 0x001EECE8
	[NullableContext(1)]
	protected void SetTextureWithPath(UUITexture texture, string path)
	{
		bool flag = StringUtils.IsBlank(path);
		texture.SetUIActive(!flag);
		if (!flag)
		{
			base.SetTextureByPath(path, texture, null, null);
		}
	}

	// Token: 0x06007698 RID: 30360 RVA: 0x001F0B1C File Offset: 0x001EED1C
	public void OnSwitchSubTab(int index)
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
		}
		this.RefreshView();
	}

	// Token: 0x06007699 RID: 30361
	protected abstract void RefreshView();

	// Token: 0x04003957 RID: 14679
	[Nullable(2)]
	protected AdvanceNoticeViewModel ViewModel;
}
