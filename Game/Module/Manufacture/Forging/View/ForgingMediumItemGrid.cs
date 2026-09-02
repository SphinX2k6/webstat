using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.Manufacture.Forging.View
{
	// Token: 0x020059B0 RID: 22960
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ForgingMediumItemGrid : LoopScrollMediumItemGrid<IWeaponForgingData>
	{
		// Token: 0x0603A1FE RID: 238078 RVA: 0x00EB682B File Offset: 0x00EB4A2B
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
		}

		// Token: 0x0603A1FF RID: 238079 RVA: 0x00EB6835 File Offset: 0x00EB4A35
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x0603A200 RID: 238080 RVA: 0x00EB6840 File Offset: 0x00EB4A40
		protected override void OnRefresh(IWeaponForgingData data, bool isSelected, int gridIndex)
		{
			int itemId = data.ItemId;
			int itemId2 = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(itemId).Value.ItemId;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId2);
			if (itemConfigData == null)
			{
				return;
			}
			int isUnlock = data.IsUnlock;
			bool flag;
			if (isUnlock > 0)
			{
				flag = ControllerBase<ForgingController>.Instance.CheckCanForging(itemId);
			}
			else
			{
				flag = ControllerBase<ForgingController>.Instance.CheckCanUnlock(itemId);
			}
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = data,
				ItemConfigId = new int?(itemId2),
				BottomTextId = itemConfigData.Name,
				IsProhibit = new bool?(isUnlock == 0),
				IsNewVisible = new bool?(data.IsNew),
				IsDisable = new bool?(isUnlock > 0 && !flag),
				IsRedDotVisible = new bool?(flag && data.IsUnlock == 0),
				StarLevel = new int?(itemConfigData.QualityId),
				IsOmitBottomText = new bool?(true),
				IsTimeFlagVisible = new bool?(data.ExistEndTime > 0.0)
			};
			base.Apply<PropMediumItemGrid>(parameters);
			this.SetSelected(isSelected, false);
		}
	}
}
