using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024C5 RID: 9413
[NullableContext(2)]
[Nullable(0)]
public class PhantomInteractDetailPanelGroup
{
	// Token: 0x06012481 RID: 74881 RVA: 0x00506E98 File Offset: 0x00505098
	[NullableContext(1)]
	public UniTask CreateWithParent(UUIItem parent)
	{
		PhantomInteractDetailPanelGroup.<CreateWithParent>d__4 <CreateWithParent>d__;
		<CreateWithParent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateWithParent>d__.<>4__this = this;
		<CreateWithParent>d__.parent = parent;
		<CreateWithParent>d__.<>1__state = -1;
		<CreateWithParent>d__.<>t__builder.Start<PhantomInteractDetailPanelGroup.<CreateWithParent>d__4>(ref <CreateWithParent>d__);
		return <CreateWithParent>d__.<>t__builder.Task;
	}

	// Token: 0x06012482 RID: 74882 RVA: 0x00506EE4 File Offset: 0x005050E4
	public void RefreshDetailPanel(bool isShow, PhantomInteractDetailViewModel viewModel = null)
	{
		if (!isShow)
		{
			PhantomInteractDetailPanel specialContentPanel = this.SpecialContentPanel;
			if (specialContentPanel != null)
			{
				specialContentPanel.SetScrollListenerActive(false);
			}
			PhantomInteractDetailPanel normalContentPanel = this.NormalContentPanel;
			if (normalContentPanel != null)
			{
				normalContentPanel.SetScrollListenerActive(false);
			}
			PhantomInteractDetailPanel specialContentPanel2 = this.SpecialContentPanel;
			if (specialContentPanel2 != null)
			{
				specialContentPanel2.SetUiActive(false);
			}
			PhantomInteractDetailPanel normalContentPanel2 = this.NormalContentPanel;
			if (normalContentPanel2 != null)
			{
				normalContentPanel2.SetUiActive(false);
			}
			this.CurrentMonsterId = 0;
			return;
		}
		if (viewModel == null)
		{
			return;
		}
		this.RefreshPanelAsync(viewModel);
	}

	// Token: 0x06012483 RID: 74883 RVA: 0x00506F50 File Offset: 0x00505150
	[NullableContext(1)]
	private UniTask RefreshPanelAsync(PhantomInteractDetailViewModel viewModel)
	{
		PhantomInteractDetailPanelGroup.<RefreshPanelAsync>d__6 <RefreshPanelAsync>d__;
		<RefreshPanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshPanelAsync>d__.<>4__this = this;
		<RefreshPanelAsync>d__.viewModel = viewModel;
		<RefreshPanelAsync>d__.<>1__state = -1;
		<RefreshPanelAsync>d__.<>t__builder.Start<PhantomInteractDetailPanelGroup.<RefreshPanelAsync>d__6>(ref <RefreshPanelAsync>d__);
		return <RefreshPanelAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04008E9A RID: 36506
	private PhantomInteractDetailPanel SpecialContentPanel;

	// Token: 0x04008E9B RID: 36507
	private PhantomInteractDetailPanel NormalContentPanel;

	// Token: 0x04008E9C RID: 36508
	private int CurrentMonsterId;

	// Token: 0x04008E9D RID: 36509
	private bool IsSpecial;
}
