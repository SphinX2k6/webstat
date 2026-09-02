using System;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

// Token: 0x020015AE RID: 5550
public static class ActivitySevenDaySignDefine
{
	// Token: 0x06009C63 RID: 40035 RVA: 0x0028F444 File Offset: 0x0028D644
	public static void OpenSignActivityRewardPreviewWhenLocked(int itemId)
	{
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemId)) == InventoryDefine.EItemDataType.MotorDecorationItem)
		{
			ItemMotorPreview? config = ConfigItemMotorPreviewByItemId.GetConfig(itemId, true);
			if (config != null && config.Value.PreviewId > 0)
			{
				ControllerBase<MotorcycleDiyController>.Instance.OpenMotorGeneralPreviewView(config.Value.PreviewId);
				return;
			}
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemId, true, null);
	}
}
