using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUiSet.View
{
	// Token: 0x0200613C RID: 24892
	[NullableContext(1)]
	[Nullable(0)]
	public class EditMobileBattleView : UiPanelBase
	{
		// Token: 0x0603EDE1 RID: 257505 RVA: 0x0101BF4B File Offset: 0x0101A14B
		public EditMobileBattleView(UUIItem parentItem)
		{
			base.CreateThenShowByResourceIdAsync("UiView_FightEdit", parentItem, false).Forget();
		}

		// Token: 0x0603EDE2 RID: 257506 RVA: 0x0101BF70 File Offset: 0x0101A170
		protected override UniTask OnBeforeStartAsync()
		{
			EditMobileBattleView.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<EditMobileBattleView.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EDE3 RID: 257507 RVA: 0x0101BFB4 File Offset: 0x0101A1B4
		protected override void OnAfterShow()
		{
			BattleUiSetModel instance = ModelBase<BattleUiSetModel>.Instance;
			foreach (BattleUiSetPanelItemData battleUiSetPanelItemData in instance.GetPanelItemDataMap().Values)
			{
				if (battleUiSetPanelItemData.IsDefaultSelected)
				{
					instance.SetPanelItemSelected(battleUiSetPanelItemData);
					break;
				}
			}
		}

		// Token: 0x0603EDE4 RID: 257508 RVA: 0x0101C018 File Offset: 0x0101A218
		private UniTask InitializePanel()
		{
			EditMobileBattleView.<InitializePanel>d__4 <InitializePanel>d__;
			<InitializePanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializePanel>d__.<>4__this = this;
			<InitializePanel>d__.<>1__state = -1;
			<InitializePanel>d__.<>t__builder.Start<EditMobileBattleView.<InitializePanel>d__4>(ref <InitializePanel>d__);
			return <InitializePanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603EDE5 RID: 257509 RVA: 0x0101C05C File Offset: 0x0101A25C
		public void ResetAllPanelItem()
		{
			foreach (EditMobileBattleViewPanel editMobileBattleViewPanel in this.PanelMap.Values)
			{
				editMobileBattleViewPanel.ResetAllPanelItem();
			}
		}

		// Token: 0x0603EDE6 RID: 257510 RVA: 0x0101C0B4 File Offset: 0x0101A2B4
		public void SavePanelItem()
		{
			foreach (EditMobileBattleViewPanel editMobileBattleViewPanel in this.PanelMap.Values)
			{
				editMobileBattleViewPanel.SavePanelItem();
			}
		}

		// Token: 0x0603EDE7 RID: 257511 RVA: 0x0101C10C File Offset: 0x0101A30C
		[NullableContext(2)]
		public EditMobileBattleViewPanel GetPanel(int panelIndex)
		{
			return this.PanelMap.GetValueOrDefault(panelIndex);
		}

		// Token: 0x0603EDE8 RID: 257512 RVA: 0x0101C11C File Offset: 0x0101A31C
		[return: Nullable(2)]
		public EditMobileBattleViewPanelItem GetPanelItem(BattleUiSetPanelItemData panelItemData)
		{
			EditMobileBattleViewPanel editMobileBattleViewPanel;
			if (!this.PanelMap.TryGetValue(panelItemData.PanelIndex, out editMobileBattleViewPanel))
			{
				return null;
			}
			return editMobileBattleViewPanel.GetPanelItem(panelItemData.PanelItemIndex);
		}

		// Token: 0x0603EDE9 RID: 257513 RVA: 0x0101C14C File Offset: 0x0101A34C
		public void RefreshHierarchyIndex()
		{
			foreach (EditMobileBattleViewPanel editMobileBattleViewPanel in this.PanelMap.Values)
			{
				if (editMobileBattleViewPanel.PanelData != null)
				{
					int hierarchyIndex = editMobileBattleViewPanel.GetRootItem().GetHierarchyIndex();
					editMobileBattleViewPanel.RefreshHierarchyIndex(hierarchyIndex);
				}
			}
		}

		// Token: 0x0603EDEA RID: 257514 RVA: 0x0101C1B8 File Offset: 0x0101A3B8
		public bool IsAnyItemOverlap(UUIItem item)
		{
			using (Dictionary<int, EditMobileBattleViewPanel>.ValueCollection.Enumerator enumerator = this.PanelMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsAnyItemOverlap(item))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0402346E RID: 144494
		private readonly Dictionary<int, EditMobileBattleViewPanel> PanelMap = new Dictionary<int, EditMobileBattleViewPanel>();
	}
}
