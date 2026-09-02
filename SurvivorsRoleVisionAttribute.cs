using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B32 RID: 11058
[NullableContext(1)]
[Nullable(0)]
internal class SurvivorsRoleVisionAttribute : UiPanelBase
{
	// Token: 0x06016100 RID: 90368 RVA: 0x0061F64A File Offset: 0x0061D84A
	public SurvivorsRoleVisionAttribute(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x06016101 RID: 90369 RVA: 0x0061F659 File Offset: 0x0061D859
	public void Init()
	{
		base.CreateThenShowByActor(this.SourceItem.GetOwner(), null);
	}

	// Token: 0x06016102 RID: 90370 RVA: 0x0061F66D File Offset: 0x0061D86D
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06016103 RID: 90371 RVA: 0x0061F6A6 File Offset: 0x0061D8A6
	protected override void OnStart()
	{
		this.AttributeScroller = new GenericLayout<SurvivorsAttributeDescItem, ISurvivorsAttributeUiData>(base.GetVerticalLayout(0), new Func<SurvivorsAttributeDescItem>(this.CreateSwitchItem), (AUIBaseActor)base.GetItem(1).GetOwner(), false, true);
	}

	// Token: 0x06016104 RID: 90372 RVA: 0x0061F6D9 File Offset: 0x0061D8D9
	private SurvivorsAttributeDescItem CreateSwitchItem()
	{
		return new SurvivorsAttributeDescItem();
	}

	// Token: 0x06016105 RID: 90373 RVA: 0x0061F6E0 File Offset: 0x0061D8E0
	public void Refresh(IReadOnlyList<ISurvivorsAttributeUiData> data, bool playGridAnim = false)
	{
		this.AttributeScroller.RefreshByData(data.ToList<ISurvivorsAttributeUiData>(), null, playGridAnim);
	}

	// Token: 0x0400A9DF RID: 43487
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public GenericLayout<SurvivorsAttributeDescItem, ISurvivorsAttributeUiData> AttributeScroller;

	// Token: 0x0400A9E0 RID: 43488
	private readonly UUIItem SourceItem;
}
