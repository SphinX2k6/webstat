using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200286E RID: 10350
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleFavorLockItem : GridProxyAbstract<RoleFavorLockItemData>
{
	// Token: 0x06014802 RID: 83970 RVA: 0x005AFFA0 File Offset: 0x005AE1A0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x06014803 RID: 83971 RVA: 0x005B0010 File Offset: 0x005AE210
	[NullableContext(1)]
	public override void Refresh(RoleFavorLockItemData roleFavorLockItemData, bool isSelected, int gridIndex)
	{
		this.RoleFavorLockItemData = roleFavorLockItemData;
		this.RefreshView();
	}

	// Token: 0x06014804 RID: 83972 RVA: 0x005B0020 File Offset: 0x005AE220
	private void RefreshView()
	{
		if (this.RoleFavorLockItemData == null)
		{
			return;
		}
		string desc = this.RoleFavorLockItemData.Desc;
		bool isLock = this.RoleFavorLockItemData.IsLock;
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(desc, true);
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetText(desc, true);
		}
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(isLock);
		}
		UUIItem item2 = base.GetItem(0);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(!isLock);
	}

	// Token: 0x06014805 RID: 83973 RVA: 0x005B009E File Offset: 0x005AE29E
	protected override void OnBeforeDestroy()
	{
		this.RoleFavorLockItemData = null;
	}

	// Token: 0x04009E75 RID: 40565
	[Nullable(2)]
	private RoleFavorLockItemData RoleFavorLockItemData;

	// Token: 0x02008BD6 RID: 35798
	private enum ERoleFavorLockItemDefine
	{
		// Token: 0x0402F1D7 RID: 192983
		UnLockItem,
		// Token: 0x0402F1D8 RID: 192984
		LockItem,
		// Token: 0x0402F1D9 RID: 192985
		UnLockDescText,
		// Token: 0x0402F1DA RID: 192986
		LockDescText
	}
}
