using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002853 RID: 10323
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleFavorClassifyItem : GridProxyAbstract<RoleFavorClassifyDataBase>
{
	// Token: 0x06014797 RID: 83863 RVA: 0x005AEC83 File Offset: 0x005ACE83
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06014798 RID: 83864 RVA: 0x005AECBC File Offset: 0x005ACEBC
	protected override void OnStart()
	{
		this.ContentGenericLayout = new GenericLayout<RoleFavorContentItem, RoleFavorContentDataBase>(base.GetVerticalLayout(0), new Func<RoleFavorContentItem>(this.CreateContentItem), null, false, true);
	}

	// Token: 0x06014799 RID: 83865 RVA: 0x005AECDF File Offset: 0x005ACEDF
	protected override void OnBeforeDestroy()
	{
		this.ClassifyData = null;
	}

	// Token: 0x0601479A RID: 83866 RVA: 0x005AECE8 File Offset: 0x005ACEE8
	public override void Refresh(RoleFavorClassifyDataBase data, bool isSelected, int gridIndex)
	{
		this.ClassifyData = data;
		base.GridIndex = gridIndex;
		base.DisplayIndex = gridIndex;
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalText(text, this.ClassifyData.TitleTableId, Array.Empty<object>());
		List<RoleFavorContentDataBase> contentDataList = this.ClassifyData.GetContentDataList();
		GenericLayout<RoleFavorContentItem, RoleFavorContentDataBase> contentGenericLayout = this.ContentGenericLayout;
		if (contentGenericLayout == null)
		{
			return;
		}
		contentGenericLayout.RefreshByData(contentDataList, null, false);
	}

	// Token: 0x0601479B RID: 83867 RVA: 0x005AED4C File Offset: 0x005ACF4C
	public IReadOnlyList<RoleFavorContentItem> GetContentItemList()
	{
		return this.ContentItemList;
	}

	// Token: 0x0601479C RID: 83868 RVA: 0x005AED54 File Offset: 0x005ACF54
	private RoleFavorContentItem CreateContentItem()
	{
		RoleFavorContentItem roleFavorContentItem = new RoleFavorContentItem();
		this.ContentItemList.Add(roleFavorContentItem);
		return roleFavorContentItem;
	}

	// Token: 0x04009E38 RID: 40504
	[Nullable(2)]
	private RoleFavorClassifyDataBase ClassifyData;

	// Token: 0x04009E39 RID: 40505
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public GenericLayout<RoleFavorContentItem, RoleFavorContentDataBase> ContentGenericLayout;

	// Token: 0x04009E3A RID: 40506
	private readonly List<RoleFavorContentItem> ContentItemList = new List<RoleFavorContentItem>();

	// Token: 0x02008BD2 RID: 35794
	[NullableContext(0)]
	private enum ERoleFavorClassifyItemDefine
	{
		// Token: 0x0402F1C6 RID: 192966
		ContentVerticalLayout,
		// Token: 0x0402F1C7 RID: 192967
		TitleText
	}
}
