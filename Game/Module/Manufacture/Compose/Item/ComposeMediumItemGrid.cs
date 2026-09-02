using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.Manufacture.Compose.Item
{
	// Token: 0x020059DB RID: 23003
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ComposeMediumItemGrid : LoopScrollMediumItemGrid<IBaseItemData>
	{
		// Token: 0x0603A485 RID: 238725 RVA: 0x00EC72EA File Offset: 0x00EC54EA
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
		}

		// Token: 0x0603A486 RID: 238726 RVA: 0x00EC72F4 File Offset: 0x00EC54F4
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x0603A487 RID: 238727 RVA: 0x00EC7300 File Offset: 0x00EC5500
		protected override void OnRefresh(IBaseItemData data, bool isSelected, int gridIndex)
		{
			int configId = data.ConfigId;
			bool flag = data.IsUnlock > 0;
			int num = 0;
			bool flag2 = true;
			switch (data.MainType)
			{
			case EComposeListType.ReagentProduction:
			{
				SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId);
				num = ((synthesisFormulaById != null) ? synthesisFormulaById.GetValueOrDefault().ItemId : 0);
				flag2 = (((IReagentProductionData)data).SubType == ESubComposeDataType.ComposeMenu || ControllerBase<ComposeController>.Instance.CheckCanReagentProduction(configId));
				break;
			}
			case EComposeListType.Structure:
			{
				SynthesisFormula? synthesisFormulaById2 = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId);
				num = ((synthesisFormulaById2 != null) ? synthesisFormulaById2.GetValueOrDefault().ItemId : 0);
				IStructureData structureData = (IStructureData)data;
				flag2 = ControllerBase<ComposeController>.Instance.CheckCanStructure(structureData.ConfigId);
				break;
			}
			case EComposeListType.Purification:
			{
				SynthesisFormula? synthesisFormulaById3 = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId);
				num = ((synthesisFormulaById3 != null) ? synthesisFormulaById3.GetValueOrDefault().ItemId : 0);
				IPurificationData purificationData = (IPurificationData)data;
				flag2 = (ModelBase<ComposeModel>.Instance.GetPurificationDataById(purificationData.ConfigId).IsUnlock != 0 && ControllerBase<ComposeController>.Instance.CheckCanPurification(purificationData.ConfigId));
				break;
			}
			case EComposeListType.Exchange:
			{
				num = data.ConfigId;
				IExchangeData exchangeData = (IExchangeData)data;
				flag2 = (ModelBase<ComposeModel>.Instance.GetExchangeDataById(exchangeData.ConfigId).IsUnlock != 0 && ControllerBase<ComposeController>.Instance.CheckCanExchange(exchangeData.ConfigId));
				break;
			}
			case EComposeListType.Collect:
			{
				SynthesisFormula? synthesisFormulaById4 = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId);
				num = ((synthesisFormulaById4 != null) ? synthesisFormulaById4.GetValueOrDefault().ItemId : 0);
				ICollectData collectData = (ICollectData)data;
				flag2 = (ModelBase<ComposeModel>.Instance.GetCollectDataById(collectData.ConfigId).IsUnlock != 0 && ControllerBase<ComposeController>.Instance.CheckCanCollect(collectData.ConfigId));
				break;
			}
			}
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(num);
			if (itemConfigData == null)
			{
				return;
			}
			bool isLimitForever = data.IsLimitForever;
			bool flag3 = data.TotalMakeCountInLimitTime > 0;
			CSharpScript.Game.Module.Common.MediumItemGrid.MediumItemGridComposeTag mediumItemGridComposeTag = new CSharpScript.Game.Module.Common.MediumItemGrid.MediumItemGridComposeTag
			{
				IsLimitTimeItem = (flag3 && isLimitForever),
				IsRefreshItem = (flag3 && !isLimitForever),
				BuffItem = (EMediumItemGridBuffType)itemConfigData.ItemBuffType
			};
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = data,
				ItemConfigId = new int?(num),
				StarLevel = new int?(itemConfigData.QualityId),
				BottomTextId = itemConfigData.Name,
				IsProhibit = new bool?(!flag),
				IsNewVisible = new bool?(data.IsNew),
				IsDisable = new bool?(flag && !flag2),
				IsOmitBottomText = new bool?(true),
				ComposeIconTag = (flag ? mediumItemGridComposeTag : null)
			};
			base.Apply<PropMediumItemGrid>(parameters);
			this.SetSelected(isSelected, false);
		}
	}
}
