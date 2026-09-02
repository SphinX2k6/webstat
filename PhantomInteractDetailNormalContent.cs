using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024C0 RID: 9408
public class PhantomInteractDetailNormalContent : UiPanelBase, IDetailContent
{
	// Token: 0x0601246C RID: 74860 RVA: 0x00506B7A File Offset: 0x00504D7A
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0601246D RID: 74861 RVA: 0x00506BB3 File Offset: 0x00504DB3
	protected override void OnStart()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "PhantomDisplay_GeneralSkillTitle", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "PhantomDisplay_GeneralDesc", Array.Empty<object>());
	}

	// Token: 0x0601246E RID: 74862 RVA: 0x00506BEC File Offset: 0x00504DEC
	[NullableContext(1)]
	public void Refresh(PhantomInteractDetailViewModel viewModel)
	{
		TableTextArgNew item = new TableTextArgNew(viewModel.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "PhantomDisplay_GeneralDesc", new <>z__ReadOnlySingleElementList<object>(item));
	}

	// Token: 0x0601246F RID: 74863 RVA: 0x00506C26 File Offset: 0x00504E26
	public void SetScrollListenerActive(bool active)
	{
	}

	// Token: 0x020087D3 RID: 34771
	private enum EComponent
	{
		// Token: 0x0402DE43 RID: 187971
		TxtName,
		// Token: 0x0402DE44 RID: 187972
		TxtDesc
	}
}
