using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E1E RID: 19998
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseDevelopPreviewLevelBranchItem : GridProxyAbstract<ITrapDefenseDevelopPreviewLevelInfo>
	{
		// Token: 0x06033B5D RID: 211805 RVA: 0x00CECA28 File Offset: 0x00CEAC28
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033B5E RID: 211806 RVA: 0x00CECAD4 File Offset: 0x00CEACD4
		public override void Refresh(ITrapDefenseDevelopPreviewLevelInfo data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			int id = data.Id;
			ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(id);
			bool flag;
			int branchCount;
			if (trapDefenseMachineIdInfo.MachineType == ETrapDefenseMachineType.Building)
			{
				TrapDefenseBuilding? buildingById = ConfigBase<TrapDefenseConfig>.Instance.GetBuildingById(this.Data.Id);
				TrapDefenseBuildingType? buildingTypeById = ConfigBase<TrapDefenseConfig>.Instance.GetBuildingTypeById(buildingById.Value.BuildingType);
				int maxLevel = buildingTypeById.Value.MaxLevel;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), buildingById.Value.DescDetail, buildingById.Value.DescDetailArgs());
				flag = (trapDefenseMachineIdInfo.Level == maxLevel);
				branchCount = buildingTypeById.Value.BranchCount;
			}
			else
			{
				TrapDefenseAuxiliary? auxiliaryById = ConfigBase<TrapDefenseConfig>.Instance.GetAuxiliaryById(this.Data.Id);
				TrapDefenseAuxiliaryType? auxiliaryTypeById = ConfigBase<TrapDefenseConfig>.Instance.GetAuxiliaryTypeById(auxiliaryById.Value.AuxiliaryType);
				int maxLevel2 = auxiliaryTypeById.Value.MaxLevel;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), auxiliaryById.Value.DescDetail, auxiliaryById.Value.DescDetailArgs());
				flag = (trapDefenseMachineIdInfo.Level == maxLevel2);
				branchCount = auxiliaryTypeById.Value.BranchCount;
			}
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(flag && branchCount > 1);
			}
			if (flag && branchCount > 1)
			{
				string branchName = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetBranchName(trapDefenseMachineIdInfo.Branch);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), branchName, Array.Empty<object>());
				UUIItem item2 = base.GetItem(3);
				if (item2 != null)
				{
					item2.SetUIActive(data.IsCurLevel);
				}
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAlpha(data.NeedAlpha.GetValueOrDefault() ? 0.5f : 1f);
		}

		// Token: 0x0401DF0C RID: 122636
		protected ITrapDefenseDevelopPreviewLevelInfo Data;

		// Token: 0x0200AD99 RID: 44441
		[NullableContext(0)]
		private class EBranch
		{
			// Token: 0x04035E8E RID: 220814
			public const int PanelTitleLayout = 0;

			// Token: 0x04035E8F RID: 220815
			public const int TxtBranch = 1;

			// Token: 0x04035E90 RID: 220816
			public const int TxtDesc = 2;

			// Token: 0x04035E91 RID: 220817
			public const int Arrow = 3;
		}
	}
}
