using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024C8 RID: 9416
public class PhantomInteractDetailSpecialContent : UiPanelBase, IDetailContent
{
	// Token: 0x06012488 RID: 74888 RVA: 0x00506FE8 File Offset: 0x005051E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent))
		};
	}

	// Token: 0x06012489 RID: 74889 RVA: 0x0050706E File Offset: 0x0050526E
	protected override void OnStart()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "PhantomDisplay_SpecialSkillTitle", Array.Empty<object>());
	}

	// Token: 0x0601248A RID: 74890 RVA: 0x0050708C File Offset: 0x0050528C
	[NullableContext(1)]
	public void Refresh(PhantomInteractDetailViewModel viewModel)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), viewModel.SkillDescription, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), viewModel.SkillName, Array.Empty<object>());
		UUITexture texture = base.GetTexture(1);
		if (viewModel.SkillPicturePath != null && texture != null)
		{
			base.SetTextureByPath(viewModel.SkillPicturePath, texture, null, null);
		}
	}

	// Token: 0x0601248B RID: 74891 RVA: 0x005070FC File Offset: 0x005052FC
	public void SetScrollListenerActive(bool active)
	{
		if (!Singleton<Info>.Instance.IsPcPlatform() || this.ScrollListenerActive == active)
		{
			return;
		}
		ULGUIEventSystem lguiEventSystem = Singleton<LguiEventSystemManager>.Instance.LguiEventSystem;
		if (lguiEventSystem == null)
		{
			return;
		}
		this.ScrollListenerActive = active;
		if (active)
		{
			lguiEventSystem.OnScrollTriggeredDelegate.Bind(new Action<ULGUIPointerEventData>(this.OnGlobalScrollTriggered));
			return;
		}
		lguiEventSystem.OnScrollTriggeredDelegate.Unbind();
	}

	// Token: 0x0601248C RID: 74892 RVA: 0x0050715C File Offset: 0x0050535C
	[NullableContext(2)]
	private void OnGlobalScrollTriggered(ULGUIPointerEventData eventData)
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar == null || !scrollViewWithScrollbar.IsValid())
		{
			return;
		}
		scrollViewWithScrollbar.TriggerScrollEventManually(eventData);
	}

	// Token: 0x04008EA2 RID: 36514
	private bool ScrollListenerActive;

	// Token: 0x020087DA RID: 34778
	private enum EComponent
	{
		// Token: 0x0402DE60 RID: 188000
		TxtName,
		// Token: 0x0402DE61 RID: 188001
		TexPix,
		// Token: 0x0402DE62 RID: 188002
		TxtDescTitle,
		// Token: 0x0402DE63 RID: 188003
		TxtDesc,
		// Token: 0x0402DE64 RID: 188004
		SvDesc
	}
}
