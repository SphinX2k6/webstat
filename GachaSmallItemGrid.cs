using System;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02001CF0 RID: 7408
public class GachaSmallItemGrid : LoopScrollSmallItemGrid<int>
{
	// Token: 0x0600D97C RID: 55676 RVA: 0x003A5590 File Offset: 0x003A3790
	protected override void OnRefresh(int itemId, bool isSelected, int gridIndex)
	{
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemId)) == InventoryDefine.EItemDataType.RoleItem)
		{
			CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
			{
				ItemConfigId = new int?(itemId),
				Data = null
			};
			base.Apply<CharacterSmallItemGrid>(parameters);
			return;
		}
		PropSmallItemGrid parameters2 = new PropSmallItemGrid
		{
			Data = null,
			ItemConfigId = new int?(itemId)
		};
		base.Apply<PropSmallItemGrid>(parameters2);
		base.SetToggleInteractive(false);
	}

	// Token: 0x0600D97D RID: 55677 RVA: 0x003A55F8 File Offset: 0x003A37F8
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x0600D97E RID: 55678 RVA: 0x003A55FB File Offset: 0x003A37FB
	protected override void OnExtendToggleClicked()
	{
	}
}
