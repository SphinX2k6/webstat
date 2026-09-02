using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.Item
{
	// Token: 0x020059DA RID: 23002
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ComposeItem : GridProxyAbstract<IBaseItemData>
	{
		// Token: 0x0603A474 RID: 238708 RVA: 0x00EC6AF0 File Offset: 0x00EC4CF0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnItemButtonClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A475 RID: 238709 RVA: 0x00EC6C3F File Offset: 0x00EC4E3F
		public override void Refresh(IBaseItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			this.RefreshName();
			this.RefreshQuality();
			this.RefreshIcon();
			this.RefreshLock();
			this.RefreshShadow();
			this.RefreshNew();
			this.Selected(isSelected, false);
		}

		// Token: 0x0603A476 RID: 238710 RVA: 0x00EC6C74 File Offset: 0x00EC4E74
		private void RefreshName()
		{
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.GetConfigId(this.ItemData));
			string localText = ConfigBase<ComposeConfig>.Instance.GetLocalText(synthesisFormulaById.Value.Name);
			base.GetText(12).SetText(localText, true);
		}

		// Token: 0x0603A477 RID: 238711 RVA: 0x00EC6CC4 File Offset: 0x00EC4EC4
		private void RefreshQuality()
		{
			switch (this.GetMainType(this.ItemData))
			{
			case EComposeListType.ReagentProduction:
				if (((IReagentProductionData)this.ItemData).SubType == ESubComposeDataType.ComposeMenu)
				{
					base.SetItemQualityIcon(base.GetSprite(10), this.GetConfigId(this.ItemData), null, CommonDefine.EQualityIconType.BackgroundSprite, null);
					return;
				}
				break;
			case EComposeListType.Structure:
				if (((IStructureData)this.ItemData).SubType == ESubStructureDataType.StructureMenu)
				{
					base.SetItemQualityIcon(base.GetSprite(10), this.GetConfigId(this.ItemData), null, CommonDefine.EQualityIconType.BackgroundSprite, null);
					return;
				}
				break;
			}
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.GetConfigId(this.ItemData));
			base.SetItemQualityIcon(base.GetSprite(10), synthesisFormulaById.Value.ItemId, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
		}

		// Token: 0x0603A478 RID: 238712 RVA: 0x00EC6DB0 File Offset: 0x00EC4FB0
		private void RefreshIcon()
		{
			switch (this.GetMainType(this.ItemData))
			{
			case EComposeListType.ReagentProduction:
				if (((IReagentProductionData)this.ItemData).SubType == ESubComposeDataType.Compose)
				{
					SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.GetConfigId(this.ItemData));
					base.SetItemIcon(base.GetTexture(11), synthesisFormulaById.Value.ItemId, null, null);
					return;
				}
				base.SetItemIcon(base.GetTexture(11), this.GetConfigId(this.ItemData), null, null);
				return;
			case EComposeListType.Structure:
				if (((IStructureData)this.ItemData).SubType == ESubStructureDataType.Structure)
				{
					SynthesisFormula? synthesisFormulaById2 = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.GetConfigId(this.ItemData));
					base.SetItemIcon(base.GetTexture(11), synthesisFormulaById2.Value.ItemId, null, null);
					return;
				}
				base.SetItemIcon(base.GetTexture(11), this.GetConfigId(this.ItemData), null, null);
				return;
			case EComposeListType.Purification:
			{
				SynthesisFormula? synthesisFormulaById3 = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.GetConfigId(this.ItemData));
				base.SetItemIcon(base.GetTexture(11), synthesisFormulaById3.Value.ItemId, null, null);
				return;
			}
			case EComposeListType.Exchange:
				break;
			case EComposeListType.Collect:
			{
				SynthesisFormula? synthesisFormulaById4 = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.GetConfigId(this.ItemData));
				base.SetItemIcon(base.GetTexture(11), synthesisFormulaById4.Value.ItemId, null, null);
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0603A479 RID: 238713 RVA: 0x00EC6F54 File Offset: 0x00EC5154
		private void RefreshLock()
		{
			switch (this.GetMainType(this.ItemData))
			{
			case EComposeListType.ReagentProduction:
				base.GetItem(7).SetUIActive(false);
				return;
			case EComposeListType.Structure:
				base.GetItem(7).SetUIActive(false);
				return;
			case EComposeListType.Purification:
			{
				IPurificationData purificationData = (IPurificationData)this.ItemData;
				base.GetItem(7).SetUIActive(purificationData.IsUnlock == 0);
				return;
			}
			case EComposeListType.Exchange:
				break;
			case EComposeListType.Collect:
			{
				ICollectData collectData = (ICollectData)this.ItemData;
				base.GetItem(7).SetUIActive(collectData.IsUnlock == 0);
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0603A47A RID: 238714 RVA: 0x00EC6FEC File Offset: 0x00EC51EC
		private void RefreshShadow()
		{
			switch (this.GetMainType(this.ItemData))
			{
			case EComposeListType.ReagentProduction:
			{
				IReagentProductionData reagentProductionData = (IReagentProductionData)this.ItemData;
				if (reagentProductionData.SubType == ESubComposeDataType.ComposeMenu)
				{
					base.GetItem(8).SetUIActive(false);
					return;
				}
				bool flag = ControllerBase<ComposeController>.Instance.CheckCanReagentProduction(reagentProductionData.ConfigId);
				base.GetItem(8).SetUIActive(!flag);
				return;
			}
			case EComposeListType.Structure:
			{
				IStructureData structureData = (IStructureData)this.ItemData;
				if (structureData.SubType == ESubStructureDataType.StructureMenu)
				{
					base.GetItem(8).SetUIActive(false);
					return;
				}
				bool flag2 = ControllerBase<ComposeController>.Instance.CheckCanStructure(structureData.ConfigId);
				base.GetItem(8).SetUIActive(!flag2);
				return;
			}
			case EComposeListType.Purification:
			{
				IPurificationData purificationData = (IPurificationData)this.ItemData;
				if (ModelBase<ComposeModel>.Instance.GetPurificationDataById(purificationData.ConfigId).IsUnlock == 0)
				{
					base.GetItem(8).SetUIActive(true);
					return;
				}
				bool flag3 = ControllerBase<ComposeController>.Instance.CheckCanPurification(purificationData.ConfigId);
				base.GetItem(8).SetUIActive(!flag3);
				return;
			}
			case EComposeListType.Exchange:
				break;
			case EComposeListType.Collect:
			{
				ICollectData collectData = (ICollectData)this.ItemData;
				if (ModelBase<ComposeModel>.Instance.GetCollectDataById(collectData.ConfigId).IsUnlock == 0)
				{
					base.GetItem(8).SetUIActive(true);
					return;
				}
				bool flag4 = ControllerBase<ComposeController>.Instance.CheckCanCollect(collectData.ConfigId);
				base.GetItem(8).SetUIActive(!flag4);
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0603A47B RID: 238715 RVA: 0x00EC7160 File Offset: 0x00EC5360
		private void RefreshNew()
		{
			base.GetItem(9).SetUIActive(this.GetIsNew(this.ItemData));
		}

		// Token: 0x0603A47C RID: 238716 RVA: 0x00EC717B File Offset: 0x00EC537B
		public void BindOnClickedCallback(Action<object> onItemButtonClicked)
		{
			this.OnClickedCallback = onItemButtonClicked;
		}

		// Token: 0x0603A47D RID: 238717 RVA: 0x00EC7184 File Offset: 0x00EC5384
		public override void OnSelected(bool fireEvent)
		{
			this.Selected(true, true);
		}

		// Token: 0x0603A47E RID: 238718 RVA: 0x00EC718E File Offset: 0x00EC538E
		public override void OnDeselected(bool fireEvent)
		{
			this.Selected(false, true);
		}

		// Token: 0x0603A47F RID: 238719 RVA: 0x00EC7198 File Offset: 0x00EC5398
		private void Selected(bool bSelected, bool fire = true)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(6);
			if (bSelected)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, fire, false, false);
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603A480 RID: 238720 RVA: 0x00EC71C7 File Offset: 0x00EC53C7
		private void OnItemButtonClicked(EToggleState state)
		{
			if (this.OnClickedCallback != null)
			{
				this.OnClickedCallback(this.ItemData);
				this.RefreshNew();
			}
		}

		// Token: 0x0603A481 RID: 238721 RVA: 0x00EC71E8 File Offset: 0x00EC53E8
		private int GetConfigId(object data)
		{
			ICollectData collectData = data as ICollectData;
			if (collectData != null)
			{
				return collectData.ConfigId;
			}
			IPurificationData purificationData = data as IPurificationData;
			if (purificationData != null)
			{
				return purificationData.ConfigId;
			}
			IReagentProductionData reagentProductionData = data as IReagentProductionData;
			if (reagentProductionData != null)
			{
				return reagentProductionData.ConfigId;
			}
			IStructureData structureData = data as IStructureData;
			if (structureData != null)
			{
				return structureData.ConfigId;
			}
			return 0;
		}

		// Token: 0x0603A482 RID: 238722 RVA: 0x00EC723C File Offset: 0x00EC543C
		private EComposeListType GetMainType(object data)
		{
			ICollectData collectData = data as ICollectData;
			if (collectData != null)
			{
				return collectData.MainType;
			}
			IPurificationData purificationData = data as IPurificationData;
			if (purificationData != null)
			{
				return purificationData.MainType;
			}
			IReagentProductionData reagentProductionData = data as IReagentProductionData;
			if (reagentProductionData != null)
			{
				return reagentProductionData.MainType;
			}
			IStructureData structureData = data as IStructureData;
			if (structureData != null)
			{
				return structureData.MainType;
			}
			return EComposeListType.Purification;
		}

		// Token: 0x0603A483 RID: 238723 RVA: 0x00EC7290 File Offset: 0x00EC5490
		private bool GetIsNew(object data)
		{
			ICollectData collectData = data as ICollectData;
			if (collectData != null)
			{
				return collectData.IsNew;
			}
			IPurificationData purificationData = data as IPurificationData;
			if (purificationData != null)
			{
				return purificationData.IsNew;
			}
			IReagentProductionData reagentProductionData = data as IReagentProductionData;
			if (reagentProductionData != null)
			{
				return reagentProductionData.IsNew;
			}
			IStructureData structureData = data as IStructureData;
			return structureData != null && structureData.IsNew;
		}

		// Token: 0x04021063 RID: 135267
		[Nullable(2)]
		private IBaseItemData ItemData;

		// Token: 0x04021064 RID: 135268
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IBaseItemData> OnClickedCallback;

		// Token: 0x0200B9B1 RID: 47537
		[NullableContext(0)]
		private class EComposeContentItemDefine
		{
			// Token: 0x04039610 RID: 235024
			public const int ComposeExtendToggle = 6;

			// Token: 0x04039611 RID: 235025
			public const int LockItem = 7;

			// Token: 0x04039612 RID: 235026
			public const int ShadowItem = 8;

			// Token: 0x04039613 RID: 235027
			public const int NewItem = 9;

			// Token: 0x04039614 RID: 235028
			public const int QualitySprite = 10;

			// Token: 0x04039615 RID: 235029
			public const int IconTexture = 11;

			// Token: 0x04039616 RID: 235030
			public const int TxtName = 12;
		}
	}
}
