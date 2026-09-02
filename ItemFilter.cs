using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using FilterDefine;

// Token: 0x020018EB RID: 6379
public class ItemFilter : CommonFilter
{
	// Token: 0x0600B74A RID: 46922 RVA: 0x0030C6C8 File Offset: 0x0030A8C8
	[NullableContext(1)]
	private object GetPhantomItemId(object data, Dictionary<int, string> currentSelectMap)
	{
		global::ItemViewData itemViewData = (global::ItemViewData)data;
		int configId = itemViewData.GetConfigId();
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(configId)) != InventoryDefine.EItemDataType.PhantomItem)
		{
			return null;
		}
		int uniqueId = itemViewData.GetUniqueId();
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
		if (phantomBattleData == null)
		{
			return null;
		}
		return phantomBattleData.GetMonsterId(false);
	}

	// Token: 0x0600B74B RID: 46923 RVA: 0x0030C71C File Offset: 0x0030A91C
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.Phantom, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity1, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity2, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity3, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity4, new TFilterConfig(this.GetPhantomItemId));
	}
}
