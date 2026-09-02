using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200109C RID: 4252
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FurniturePresetGridItem : GridProxyAbstract<IFurniturePresetGridItemData>
{
	// Token: 0x06006EE2 RID: 28386 RVA: 0x001CD584 File Offset: 0x001CB784
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06006EE3 RID: 28387 RVA: 0x001CD5DE File Offset: 0x001CB7DE
	public override void Refresh(IFurniturePresetGridItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.UpdateItemsVisible();
		this.RefreshDetail();
	}

	// Token: 0x06006EE4 RID: 28388 RVA: 0x001CD5F4 File Offset: 0x001CB7F4
	private void UpdateItemsVisible()
	{
		IFurniturePresetGridItemData data = this.Data;
		bool uiactive = data != null && data.IsLock;
		IFurniturePresetGridItemData data2 = this.Data;
		bool uiactive2 = data2 != null && data2.IsFinished;
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(uiactive);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(uiactive2);
	}

	// Token: 0x06006EE5 RID: 28389 RVA: 0x001CD64C File Offset: 0x001CB84C
	public void RefreshDetail()
	{
		IFurniturePresetGridItemData data = this.Data;
		string textStringId = ((data != null) ? data.FurnitureConfig.Name : null) ?? "";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, Array.Empty<object>());
	}

	// Token: 0x040034E5 RID: 13541
	[Nullable(2)]
	private IFurniturePresetGridItemData Data;
}
