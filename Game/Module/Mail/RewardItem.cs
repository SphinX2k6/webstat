using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.Mail
{
	// Token: 0x020059F8 RID: 23032
	internal class RewardItem : LoopScrollSmallItemGrid<TItem>
	{
		// Token: 0x0603A595 RID: 238997 RVA: 0x00ECB6F1 File Offset: 0x00EC98F1
		protected override void OnRefresh(TItem data, bool isSelected, int gridIndex)
		{
			this.Refresh(data, isSelected, gridIndex);
		}

		// Token: 0x0603A596 RID: 238998 RVA: 0x00ECB6FC File Offset: 0x00EC98FC
		protected override void OnExtendToggleClicked()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ConfigId, true, null);
		}

		// Token: 0x0603A597 RID: 238999 RVA: 0x00ECB710 File Offset: 0x00EC9910
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x0603A598 RID: 239000 RVA: 0x00ECB71C File Offset: 0x00EC991C
		public override void Refresh(TItem data, bool isSelected, int gridIndex)
		{
			InventoryDefine.IGetItemData itemData = data.ItemData;
			int count = data.Count;
			this.ConfigId = itemData.ItemId;
			MailBoxView onwner = this.Onwner;
			bool flag;
			if (onwner == null)
			{
				flag = false;
			}
			else
			{
				MailData selectedMailData = onwner.SelectedMailData;
				flag = (((selectedMailData != null) ? new EMailAttachment?(selectedMailData.GetAttachmentStatus()) : null).GetValueOrDefault() == EMailAttachment.AttachmentPicked);
			}
			bool value = flag;
			InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(this.ConfigId));
			if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleItem)
			{
				RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.ConfigId);
				CharacterSmallItemGrid characterSmallItemGrid = new CharacterSmallItemGrid();
				characterSmallItemGrid.Data = data;
				characterSmallItemGrid.ElementId = new int?(roleConfig.Value.ElementId);
				characterSmallItemGrid.IsReceivedVisible = new bool?(value);
				characterSmallItemGrid.ItemConfigId = new int?(this.ConfigId);
				string bottomText;
				if (count <= 0)
				{
					bottomText = "";
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(count);
					bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				characterSmallItemGrid.BottomText = bottomText;
				characterSmallItemGrid.QualityId = new int?(roleConfig.Value.QualityId);
				CharacterSmallItemGrid parameters = characterSmallItemGrid;
				base.Apply<CharacterSmallItemGrid>(parameters);
				return;
			}
			if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.PhantomItem)
			{
				PhantomSmallItemGrid phantomSmallItemGrid = new PhantomSmallItemGrid();
				phantomSmallItemGrid.Data = data;
				phantomSmallItemGrid.IsReceivedVisible = new bool?(value);
				phantomSmallItemGrid.ItemConfigId = new int?(this.ConfigId);
				string bottomText2;
				if (count <= 0)
				{
					bottomText2 = "";
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(count);
					bottomText2 = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				phantomSmallItemGrid.BottomText = bottomText2;
				PhantomSmallItemGrid parameters2 = phantomSmallItemGrid;
				base.Apply<PhantomSmallItemGrid>(parameters2);
				return;
			}
			PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
			propSmallItemGrid.Data = data;
			propSmallItemGrid.IsReceivedVisible = new bool?(value);
			propSmallItemGrid.ItemConfigId = new int?(this.ConfigId);
			string bottomText3;
			if (count <= 0)
			{
				bottomText3 = "";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(count);
				bottomText3 = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			propSmallItemGrid.BottomText = bottomText3;
			PropSmallItemGrid parameters3 = propSmallItemGrid;
			base.Apply<PropSmallItemGrid>(parameters3);
		}

		// Token: 0x040210B1 RID: 135345
		[Nullable(1)]
		public MailBoxView Onwner;

		// Token: 0x040210B2 RID: 135346
		private int ConfigId;
	}
}
