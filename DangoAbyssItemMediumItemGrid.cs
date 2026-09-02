using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02001AEB RID: 6891
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoAbyssItemMediumItemGrid : LoopScrollMediumItemGrid<AbyssPluginItemInfo>
{
	// Token: 0x0600C655 RID: 50773 RVA: 0x00346AE0 File Offset: 0x00344CE0
	protected override void OnRefresh(AbyssPluginItemInfo itemData, bool isSelected, int gridIndex)
	{
		AbyssQuality? abyssQualityByPluginItemId = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityByPluginItemId(itemData.GetConfigId());
		if (itemData == null || abyssQualityByPluginItemId == null)
		{
			return;
		}
		TItemConfig config = itemData.GetConfig();
		DangoRoleHeadInfo dangoRoleHeadInfo = new DangoRoleHeadInfo
		{
			DangoConfigId = new int?(itemData.GetRoleId())
		};
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = itemData,
			ItemConfigId = new int?(itemData.GetConfigId()),
			BottomTextId = config.As<AbyssItem>().Value.Name,
			IsLockVisible = new bool?(itemData.GetIsLock()),
			DangoRoleHeadInfo = dangoRoleHeadInfo
		};
		base.SetReduceButton(null);
		base.Apply<PropMediumItemGrid>(parameters);
		this.SetSelected(isSelected, false);
	}

	// Token: 0x0600C656 RID: 50774 RVA: 0x00346B93 File Offset: 0x00344D93
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x0600C657 RID: 50775 RVA: 0x00346B9D File Offset: 0x00344D9D
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}
}
