using System;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Popup
{
	// Token: 0x02004B93 RID: 19347
	public class RewardItem : LoopScrollSmallItemGrid<TPreviewItem>
	{
		// Token: 0x0603286C RID: 206956 RVA: 0x00CA5D26 File Offset: 0x00CA3F26
		protected override bool OnCanExecuteChange()
		{
			return false;
		}

		// Token: 0x0603286D RID: 206957 RVA: 0x00CA5D29 File Offset: 0x00CA3F29
		protected override void OnExtendToggleClicked()
		{
			ItemController instance = ControllerBase<ItemController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.OpenItemTipsByItemId(this.ConfigId, true, null);
		}

		// Token: 0x0603286E RID: 206958 RVA: 0x00CA5D44 File Offset: 0x00CA3F44
		protected override void OnRefresh(TPreviewItem data, bool isSelected, int gridIndex)
		{
			this.ConfigId = data.ItemId;
			int count = data.Count;
			InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
			if (((instance != null) ? new InventoryDefine.EItemDataType?(instance.GetItemDataTypeByConfigId(new int?(this.ConfigId))) : null).GetValueOrDefault() == InventoryDefine.EItemDataType.RoleItem)
			{
				RoleConfig instance2 = ConfigBase<RoleConfig>.Instance;
				RoleInfo? roleInfo = (instance2 != null) ? instance2.GetRoleConfig(this.ConfigId) : null;
				CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
				{
					Data = data,
					ItemConfigId = new int?(this.ConfigId),
					BottomText = ((count > 0) ? count.ToString() : ""),
					QualityId = new int?((roleInfo != null) ? roleInfo.GetValueOrDefault().QualityId : 0)
				};
				base.Apply<CharacterSmallItemGrid>(parameters);
				return;
			}
			PropSmallItemGrid parameters2 = new PropSmallItemGrid
			{
				Data = data,
				ItemConfigId = new int?(this.ConfigId),
				BottomText = ((count > 0) ? count.ToString() : "")
			};
			base.Apply<PropSmallItemGrid>(parameters2);
		}

		// Token: 0x0401D76D RID: 120685
		public int ConfigId;
	}
}
