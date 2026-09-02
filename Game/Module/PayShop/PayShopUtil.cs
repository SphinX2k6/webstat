using System;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.PayShop
{
	// Token: 0x020056BA RID: 22202
	public static class PayShopUtil
	{
		// Token: 0x06038848 RID: 231496 RVA: 0x00E518D0 File Offset: 0x00E4FAD0
		public static void OpenItemPreview(InventoryDefine.EItemDataType itemType, int itemId)
		{
			if (itemType == InventoryDefine.EItemDataType.OrnamentItem)
			{
				ControllerBase<RoleController>.Instance.OpenOrnamentPreviewView(itemId, null);
				return;
			}
			if (itemType == InventoryDefine.EItemDataType.MotorDecorationItem)
			{
				ItemMotorPreview? config = ConfigItemMotorPreviewByItemId.GetConfig(itemId, true);
				if (config != null)
				{
					ControllerBase<MotorcycleDiyController>.Instance.OpenMotorGeneralPreviewView(config.Value.PreviewId);
				}
			}
		}
	}
}
