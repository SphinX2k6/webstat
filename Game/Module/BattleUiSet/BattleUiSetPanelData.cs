using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUiSet
{
	// Token: 0x02006139 RID: 24889
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiSetPanelData
	{
		// Token: 0x0603EDB5 RID: 257461 RVA: 0x0101AD10 File Offset: 0x01018F10
		public BattleUiSetPanelData(int panelIndex, IReadOnlyList<BattleUiSetPanelItemData> panelItemDataList)
		{
			this.PanelIndex = panelIndex;
			foreach (BattleUiSetPanelItemData battleUiSetPanelItemData in panelItemDataList)
			{
				int panelItemIndex = battleUiSetPanelItemData.PanelItemIndex;
				if (panelItemIndex == -1)
				{
					this.IsOnlyPanelEdit = true;
					this.ItemDataMap.Clear();
					this.ItemDataMap[panelItemIndex] = battleUiSetPanelItemData;
					break;
				}
				this.ItemDataMap[panelItemIndex] = battleUiSetPanelItemData;
			}
		}

		// Token: 0x0603EDB6 RID: 257462 RVA: 0x0101ADA4 File Offset: 0x01018FA4
		[NullableContext(2)]
		public BattleUiSetPanelItemData GetPanelItemData(int index)
		{
			return this.ItemDataMap.GetValueOrDefault(index);
		}

		// Token: 0x0603EDB7 RID: 257463 RVA: 0x0101ADB2 File Offset: 0x01018FB2
		public IReadOnlyDictionary<int, BattleUiSetPanelItemData> GetPanelItemDataMap()
		{
			return this.ItemDataMap;
		}

		// Token: 0x0402344F RID: 144463
		public readonly int PanelIndex;

		// Token: 0x04023450 RID: 144464
		private readonly Dictionary<int, BattleUiSetPanelItemData> ItemDataMap = new Dictionary<int, BattleUiSetPanelItemData>();

		// Token: 0x04023451 RID: 144465
		public readonly bool IsOnlyPanelEdit;
	}
}
