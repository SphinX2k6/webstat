using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050BA RID: 20666
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleDevelopProjectMaterialListItem : LoopScrollSmallItemGrid<RoleDevelopNeedItem>
	{
		// Token: 0x060353F4 RID: 218100 RVA: 0x00D5939C File Offset: 0x00D5759C
		protected override void OnRefresh(RoleDevelopNeedItem data, bool isSelected, int gridIndex)
		{
			if (RoleDevelopUtil.IsUnknownItem(data.ItemId))
			{
				base.SetIconByPath(ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig().Value.UnknownItemIcon ?? "");
				base.SetToggleInteractive(false);
				base.SetBottomTextVisible(false);
				base.SetQuality(null);
				return;
			}
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(data.ItemId, 0);
			string bottomText = StringUtils.Format((itemCountByConfigId >= data.Count) ? "<color=#f7eba6>{0}</color>/{1}" : "<color=#f55e66>{0}</color>/{1}", new string[]
			{
				itemCountByConfigId.ToString(),
				data.Count.ToString()
			});
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				ItemConfigId = new int?(data.ItemId),
				BottomText = bottomText,
				Data = data
			};
			base.Apply<PropSmallItemGrid>(parameters);
			base.SetToggleInteractive(true);
		}

		// Token: 0x060353F5 RID: 218101 RVA: 0x00D59488 File Offset: 0x00D57688
		protected override void OnExtendToggleClicked()
		{
			RoleDevelopNeedItem roleDevelopNeedItem = this.Data as RoleDevelopNeedItem;
			if (roleDevelopNeedItem == null)
			{
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(roleDevelopNeedItem.ItemId, true, null);
		}

		// Token: 0x060353F6 RID: 218102 RVA: 0x00D594B7 File Offset: 0x00D576B7
		protected override bool OnCanExecuteChange()
		{
			return false;
		}
	}
}
