using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roulette.View
{
	// Token: 0x0200500F RID: 20495
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RouletteAssemblyGridItem : LoopScrollMediumItemGrid<AssemblyGridData>
	{
		// Token: 0x17008ACA RID: 35530
		// (get) Token: 0x06034D3C RID: 216380 RVA: 0x00D431CC File Offset: 0x00D413CC
		[Nullable(2)]
		protected new AssemblyGridData Data
		{
			[NullableContext(2)]
			get
			{
				return this.Data as AssemblyGridData;
			}
		}

		// Token: 0x06034D3D RID: 216381 RVA: 0x00D431D9 File Offset: 0x00D413D9
		protected override void OnStart()
		{
			this.GetItemGridExtendToggle().bLockStateOnSelect = true;
			base.SetUseFixedAsync(true);
		}

		// Token: 0x06034D3E RID: 216382 RVA: 0x00D431F0 File Offset: 0x00D413F0
		protected override void OnRefresh(AssemblyGridData data, bool isSelected, int gridIndex)
		{
			PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
			{
				QualityType = new CommonDefine.EQualityIconType?(CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath),
				Data = data,
				IsOmitBottomText = new bool?(false),
				IsNewOverRedDot = new bool?(true)
			};
			if (data.GridType == ERouletteGridType.EquipItem)
			{
				AssemblyEquipItemGridData assemblyEquipItemGridData = data as AssemblyEquipItemGridData;
				propMediumItemGrid.QualityId = new int?(assemblyEquipItemGridData.QualityId);
			}
			else
			{
				propMediumItemGrid.QualityId = new int?(1);
			}
			if (data.RelativeIndex != 0)
			{
				propMediumItemGrid.SortIndex = new int?(data.RelativeIndex);
			}
			GridRedDotInfo gridRedDotInfo = null;
			foreach (GridRedDotInfo gridRedDotInfo2 in RouletteAssemblyGridItem.gridRedDotInfoList)
			{
				if (gridRedDotInfo2.Id == (ERouletteExploreId)data.Id)
				{
					gridRedDotInfo = gridRedDotInfo2;
					break;
				}
			}
			if (gridRedDotInfo != null)
			{
				propMediumItemGrid.IsRedDotVisible = new bool?(gridRedDotInfo.CheckFunction(data));
			}
			switch (data.GridType)
			{
			case ERouletteGridType.Explore:
			{
				AssemblyExploreGridData assemblyExploreGridData = data as AssemblyExploreGridData;
				propMediumItemGrid.SpriteIconPath = assemblyExploreGridData.IconPath;
				propMediumItemGrid.BottomTextId = assemblyExploreGridData.Name;
				propMediumItemGrid.IsNewVisible = new bool?(assemblyExploreGridData.HasNew);
				break;
			}
			case ERouletteGridType.Function:
			{
				AssemblyFunctionGridData assemblyFunctionGridData = data as AssemblyFunctionGridData;
				if (assemblyFunctionGridData.IconPath.Contains("Atlas"))
				{
					propMediumItemGrid.SpriteIconPath = assemblyFunctionGridData.IconPath;
				}
				else
				{
					propMediumItemGrid.IconPath = assemblyFunctionGridData.IconPath;
				}
				propMediumItemGrid.BottomTextId = data.Name;
				break;
			}
			case ERouletteGridType.EquipItem:
			{
				AssemblyEquipItemGridData assemblyEquipItemGridData2 = data as AssemblyEquipItemGridData;
				propMediumItemGrid.ItemConfigId = new int?(assemblyEquipItemGridData2.Id);
				propMediumItemGrid.BottomText = assemblyEquipItemGridData2.ItemNum.ToString();
				CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(data.Id, 0);
				if (commonItemData != null)
				{
					propMediumItemGrid.BuffIconType = new EMediumItemGridBuffType?((EMediumItemGridBuffType)commonItemData.GetConfig().As<ItemInfo>().Value.ItemBuffType);
				}
				break;
			}
			}
			base.Apply<PropMediumItemGrid>(propMediumItemGrid);
			this.Data.Index = gridIndex;
			this.SetSelected(isSelected, false);
		}

		// Token: 0x06034D3F RID: 216383 RVA: 0x00D433EC File Offset: 0x00D415EC
		public override void OnSelected(bool fireEvent)
		{
			this.GetItemGridExtendToggle().SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x06034D40 RID: 216384 RVA: 0x00D433FE File Offset: 0x00D415FE
		public override void OnDeselected(bool fireEvent)
		{
			this.GetItemGridExtendToggle().SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x0401E730 RID: 124720
		[StaticVariableRuleIgnore]
		private static GridRedDotInfo[] gridRedDotInfoList = new GridRedDotInfo[]
		{
			new GridRedDotInfo
			{
				Id = ERouletteExploreId.声骸显像,
				CheckFunction = ((AssemblyGridData data) => ModelBase<PhantomInteractModel>.Instance.CheckAnyPhantomInteractUnlockRedDot())
			},
			new GridRedDotInfo
			{
				Id = ERouletteExploreId.摩托车声骸显像,
				CheckFunction = ((AssemblyGridData data) => ModelBase<PhantomInteractModel>.Instance.CheckAnyPhantomInteractUnlockRedDot())
			}
		};
	}
}
