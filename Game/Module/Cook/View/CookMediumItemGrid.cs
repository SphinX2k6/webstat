using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E1B RID: 24091
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CookMediumItemGrid : LoopScrollMediumItemGrid<ICookItemData>
	{
		// Token: 0x0603C9D3 RID: 248275 RVA: 0x00F64559 File Offset: 0x00F62759
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x0603C9D4 RID: 248276 RVA: 0x00F6456C File Offset: 0x00F6276C
		protected override void OnBeforeDestroy()
		{
			this.SequencePlayer.Clear();
			this.SequencePlayer = null;
		}

		// Token: 0x0603C9D5 RID: 248277 RVA: 0x00F64580 File Offset: 0x00F62780
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
		}

		// Token: 0x0603C9D6 RID: 248278 RVA: 0x00F6458A File Offset: 0x00F6278A
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x0603C9D7 RID: 248279 RVA: 0x00F64594 File Offset: 0x00F62794
		protected override void OnRefresh(ICookItemData data, bool isSelected, int gridIndex)
		{
			ICookingData cookingData = data as ICookingData;
			if (cookingData != null)
			{
				this.SetSelected(isSelected, false);
				int itemId = data.ItemId;
				PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
				{
					Data = data,
					IsNewVisible = new bool?(data.IsNew),
					IsProhibit = new bool?(!data.IsUnLock),
					IsOmitBottomText = new bool?(true)
				};
				ECookListType mainType = data.MainType;
				if (mainType == ECookListType.Machining)
				{
					int finalItemId = ConfigBase<CookConfig>.Instance.GetCookProcessedById(itemId).FinalItemId;
					CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(finalItemId);
					if (itemConfigData == null)
					{
						return;
					}
					bool flag = ControllerBase<CookController>.Instance.CheckCanProcessed(itemId) && data.IsUnLock;
					propMediumItemGrid.IsDisable = new bool?(data.IsUnLock && !flag);
					propMediumItemGrid.BottomTextId = itemConfigData.Name;
					propMediumItemGrid.ItemConfigId = new int?(finalItemId);
					propMediumItemGrid.StarLevel = new int?(itemConfigData.QualityId);
				}
				if (mainType == ECookListType.Cooking)
				{
					CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(itemId);
					int foodItemId = cookFormulaById.FoodItemId;
					CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(foodItemId);
					if (itemConfigData2 == null)
					{
						return;
					}
					bool flag2 = ControllerBase<CookController>.Instance.CheckCanCook(itemId) && data.IsUnLock;
					propMediumItemGrid.IsDisable = new bool?(data.IsUnLock && !flag2);
					propMediumItemGrid.BottomTextId = itemConfigData2.Name;
					propMediumItemGrid.ItemConfigId = new int?(cookFormulaById.FoodItemId);
					propMediumItemGrid.StarLevel = new int?(itemConfigData2.QualityId);
					propMediumItemGrid.IsTimeFlagVisible = new bool?(cookingData.ExistEndTime > 0.0);
				}
				base.Apply<PropMediumItemGrid>(propMediumItemGrid);
				return;
			}
			if (data is IMachiningData)
			{
				this.SetSelected(isSelected, false);
				int itemId2 = data.ItemId;
				PropMediumItemGrid propMediumItemGrid2 = new PropMediumItemGrid
				{
					Data = data,
					IsNewVisible = new bool?(data.IsNew),
					IsProhibit = new bool?(!data.IsUnLock),
					IsOmitBottomText = new bool?(true)
				};
				if (data.MainType == ECookListType.Machining)
				{
					int finalItemId2 = ConfigBase<CookConfig>.Instance.GetCookProcessedById(itemId2).FinalItemId;
					ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(finalItemId2);
					if (config == null)
					{
						return;
					}
					bool flag3 = ControllerBase<CookController>.Instance.CheckCanProcessed(itemId2) && data.IsUnLock;
					propMediumItemGrid2.IsDisable = new bool?(data.IsUnLock && !flag3);
					propMediumItemGrid2.BottomTextId = config.Value.Name;
					propMediumItemGrid2.ItemConfigId = new int?(finalItemId2);
					propMediumItemGrid2.StarLevel = new int?(config.Value.QualityId);
				}
				base.Apply<PropMediumItemGrid>(propMediumItemGrid2);
			}
		}

		// Token: 0x040220F5 RID: 139509
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;
	}
}
