using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Manufacture.Common;

namespace CSharpScript.Game.Module.Manufacture.Compose.View
{
	// Token: 0x020059C5 RID: 22981
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ComposeExchangeItem : LoopScrollMediumItemGrid<ISingleItemInfo>
	{
		// Token: 0x0603A379 RID: 238457 RVA: 0x00EBFC0C File Offset: 0x00EBDE0C
		protected override void OnRefresh(ISingleItemInfo data, bool isSelected, int gridIndex)
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(data.Proto_ItemId, 0);
			string bottomText;
			if (itemCountByConfigId < 2)
			{
				bottomText = StringUtils.Format("<color=#dc0300>{0}</color>", new string[]
				{
					itemCountByConfigId.ToString()
				});
			}
			else
			{
				bottomText = StringUtils.Format("<color=#ffffff>{0}</color>", new string[]
				{
					itemCountByConfigId.ToString()
				});
			}
			PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
			{
				Data = data,
				BottomText = bottomText,
				IsDisable = new bool?(itemCountByConfigId < 2)
			};
			if (data.Proto_IsUnlock)
			{
				propMediumItemGrid.ItemConfigId = new int?(data.Proto_ItemId);
			}
			base.Apply<PropMediumItemGrid>(propMediumItemGrid);
			base.SetIsPhantomLock(new bool?(!data.Proto_IsUnlock));
			this.SetSelected(false, false);
		}

		// Token: 0x0603A37A RID: 238458 RVA: 0x00EBFCCC File Offset: 0x00EBDECC
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
		}

		// Token: 0x0603A37B RID: 238459 RVA: 0x00EBFCD6 File Offset: 0x00EBDED6
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}
	}
}
