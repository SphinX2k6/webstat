using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;

// Token: 0x02001AEC RID: 6892
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssItemSmallItemGrid : SmallItemGrid, IGridProxy<AbyssPluginItemInfo>
{
	// Token: 0x0600C659 RID: 50777 RVA: 0x00346BB0 File Offset: 0x00344DB0
	public void Refresh(AbyssPluginItemInfo data)
	{
		TItemConfig config = data.GetConfig();
		AbyssQuality? abyssQualityByPluginItemId = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityByPluginItemId(data.GetConfigId());
		if (config == null || abyssQualityByPluginItemId == null)
		{
			return;
		}
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.GetConfigId()),
			BottomTextId = config.As<AbyssItem>().Value.Name,
			IsLockVisible = new bool?(data.GetIsLock())
		};
		base.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x17001005 RID: 4101
	// (get) Token: 0x0600C65A RID: 50778 RVA: 0x00346C35 File Offset: 0x00344E35
	// (set) Token: 0x0600C65B RID: 50779 RVA: 0x00346C3D File Offset: 0x00344E3D
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<AbyssPluginItemInfo>, AbyssPluginItemInfo> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x17001006 RID: 4102
	// (get) Token: 0x0600C65C RID: 50780 RVA: 0x00346C46 File Offset: 0x00344E46
	// (set) Token: 0x0600C65D RID: 50781 RVA: 0x00346C4E File Offset: 0x00344E4E
	public int GridIndex { get; set; }

	// Token: 0x17001007 RID: 4103
	// (get) Token: 0x0600C65E RID: 50782 RVA: 0x00346C57 File Offset: 0x00344E57
	// (set) Token: 0x0600C65F RID: 50783 RVA: 0x00346C5F File Offset: 0x00344E5F
	public int DisplayIndex { get; set; }

	// Token: 0x0600C660 RID: 50784 RVA: 0x00346C68 File Offset: 0x00344E68
	public void Clear()
	{
	}

	// Token: 0x0600C661 RID: 50785 RVA: 0x00346C6A File Offset: 0x00344E6A
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600C662 RID: 50786 RVA: 0x00346C6C File Offset: 0x00344E6C
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600C663 RID: 50787 RVA: 0x00346C6E File Offset: 0x00344E6E
	public object GetKey(AbyssPluginItemInfo data, int gridIndex)
	{
		return this.GridIndex;
	}
}
