using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E17 RID: 19991
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingUpgradeItem : UiPanelBase
	{
		// Token: 0x06033B23 RID: 211747 RVA: 0x00CEB540 File Offset: 0x00CE9740
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClicked));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickJump));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033B24 RID: 211748 RVA: 0x00CEB6D0 File Offset: 0x00CE98D0
		public bool RefreshButton(TrapDefenseBuildingDevelopItemData data)
		{
			this.Data = data;
			bool flag = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.CurRecommendLevel != null;
			bool isUnlock = this.Data.GetIsUnlock();
			base.GetButton(6).RootUIComp.Get().SetUIActive(isUnlock || !flag);
			bool isMaxLevel = data.GetIsMaxLevel(false);
			bool flag2 = data.GetIsMaxLevel(true) && !isMaxLevel;
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(data.GetIsUnlock() && !data.GetIsMaxLevel(true));
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(!data.GetIsUnlock() || flag2);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(data.GetIsUnlock() && isMaxLevel);
			}
			int upgradeCost = data.GetUpgradeCost();
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(upgradeCost.ToString(), true);
			}
			if (!data.GetIsUnlock() || data.GetIsMaxLevel(true))
			{
				if (!data.GetIsUnlock())
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "TowerDefense_Building_BdLock_Text", Array.Empty<object>());
				}
				else if (flag2)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "TowerDefense_Building_CurMax_Text", Array.Empty<object>());
				}
				return false;
			}
			int remainPoints = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.RemainPoints;
			bool flag3 = upgradeCost <= remainPoints;
			UUIText text2 = base.GetText(1);
			UUIItem uuiitem = text2;
			bool bUseChangeColor = !flag3;
			FColor? fcolor = new FColor?(text2.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			UUIText text3 = base.GetText(2);
			UUIItem uuiitem2 = text3;
			bool bUseChangeColor2 = !flag3;
			fcolor = new FColor?(text3.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			return flag3;
		}

		// Token: 0x06033B25 RID: 211749 RVA: 0x00CEB88C File Offset: 0x00CE9A8C
		private void OnClicked()
		{
			if (this.OnClickCb != null)
			{
				this.OnClickCb();
			}
		}

		// Token: 0x06033B26 RID: 211750 RVA: 0x00CEB8A4 File Offset: 0x00CE9AA4
		private void OnClickJump()
		{
			if (!this.Data.GetIsUnlock())
			{
				int? num = null;
				if (this.Data.IsBuilding)
				{
					num = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.LevelUnlockBuilding.GetValueOrNull(this.Data.GetDataType());
				}
				else
				{
					num = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.LevelUnlockAuxiliary.GetValueOrNull(this.Data.GetDataType());
				}
				if (num != null)
				{
					int? num2 = num;
					int num3 = 0;
					if (!(num2.GetValueOrDefault() == num3 & num2 != null))
					{
						TrapDefenseLevelData trapDefenseLevelData;
						ModelBase<TrapDefenseModel>.Instance.LevelDataFromIdMap.TryGetValue(num.Value, out trapDefenseLevelData);
						if (trapDefenseLevelData == null)
						{
							return;
						}
						if (trapDefenseLevelData.Config.ModeType == 1)
						{
							ModelBase<TrapDefenseModel>.Instance.OpenViewMainLevelMode(new int?(num.Value), new ETrapDefenseDifficultyLevel?((ETrapDefenseDifficultyLevel)trapDefenseLevelData.Config.Difficulty), null);
							goto IL_109;
						}
						ModelBase<TrapDefenseModel>.Instance.OpenViewRougeLevelMode(new int?(num.Value), null);
						goto IL_109;
					}
				}
				return;
			}
			IL_109:
			if (!this.Data.GetIsMaxLevel(true) && !this.Data.GetIsMaxLevel(false))
			{
				return;
			}
			ETrapDefenseTalentFuncType value = this.Data.IsBuilding ? ETrapDefenseTalentFuncType.MachineLevelLimitIncrease : ETrapDefenseTalentFuncType.AuxiliaryLevelLimitIncrease;
			ITrapDefenseTalentTreeViewParam param = new TrapDefenseTalentTreeViewParam
			{
				TalentFuncType = new ETrapDefenseTalentFuncType?(value)
			};
			ModelBase<TrapDefenseModel>.Instance.OpenViewTalentTree(param);
		}

		// Token: 0x0401DEFA RID: 122618
		public Action OnClickCb;

		// Token: 0x0401DEFB RID: 122619
		private TrapDefenseBuildingDevelopItemData Data;

		// Token: 0x0200AD93 RID: 44435
		[NullableContext(0)]
		private class EBtnUpgrade
		{
			// Token: 0x04035E73 RID: 220787
			public const int BtnUpgrade = 0;

			// Token: 0x04035E74 RID: 220788
			public const int TxtCost = 1;

			// Token: 0x04035E75 RID: 220789
			public const int TxtConfirm = 2;

			// Token: 0x04035E76 RID: 220790
			public const int PanelLockLayout = 3;

			// Token: 0x04035E77 RID: 220791
			public const int PanelMaxLayout = 4;

			// Token: 0x04035E78 RID: 220792
			public const int RedDot = 5;

			// Token: 0x04035E79 RID: 220793
			public const int BtnJump = 6;

			// Token: 0x04035E7A RID: 220794
			public const int TxtLock = 7;
		}
	}
}
