using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028ED RID: 10477
[NullableContext(1)]
[Nullable(0)]
public class RoleVisionAttribute : UiPanelBase
{
	// Token: 0x06014D05 RID: 85253 RVA: 0x005C3C8E File Offset: 0x005C1E8E
	public RoleVisionAttribute(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x06014D06 RID: 85254 RVA: 0x005C3CC2 File Offset: 0x005C1EC2
	public void Init()
	{
		base.CreateThenShowByActor(this.SourceItem.GetOwner(), null);
	}

	// Token: 0x06014D07 RID: 85255 RVA: 0x005C3CD8 File Offset: 0x005C1ED8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014D08 RID: 85256 RVA: 0x005C3D41 File Offset: 0x005C1F41
	protected override void OnStart()
	{
		this.AttributeScroller = new GenericLayout<RoleAttributeItem, RoleAttributeSt>(base.GetVerticalLayout(0), this.CreateSwitchItem, base.GetItem(1).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x06014D09 RID: 85257 RVA: 0x005C3D70 File Offset: 0x005C1F70
	public void Refresh(List<AttrListScrollData> data, bool needCheckBg = false)
	{
		List<RoleAttributeSt> list = new List<RoleAttributeSt>();
		if (data != null)
		{
			foreach (AttrListScrollData data2 in data)
			{
				list.Add(new RoleAttributeSt
				{
					Data = data2,
					NeedCheckBg = needCheckBg
				});
			}
		}
		this.AttributeScroller.RefreshByData(list, null, false);
	}

	// Token: 0x0400A02C RID: 41004
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public GenericLayout<RoleAttributeItem, RoleAttributeSt> AttributeScroller;

	// Token: 0x0400A02D RID: 41005
	[Nullable(2)]
	private readonly UUIItem SourceItem;

	// Token: 0x0400A02E RID: 41006
	private readonly Func<RoleAttributeItem> CreateSwitchItem = () => new RoleAttributeItem();

	// Token: 0x02008C45 RID: 35909
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F3F1 RID: 193521
		VerticalLayout,
		// Token: 0x0402F3F2 RID: 193522
		LayoutItem
	}
}
