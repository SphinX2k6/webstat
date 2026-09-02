using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUiSet.View
{
	// Token: 0x0200613D RID: 24893
	[NullableContext(2)]
	[Nullable(0)]
	public class EditMobileBattleViewPanel : UiPanelBase
	{
		// Token: 0x0603EDEB RID: 257515 RVA: 0x0101C218 File Offset: 0x0101A418
		protected override UniTask OnBeforeStartAsync()
		{
			EditMobileBattleViewPanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<EditMobileBattleViewPanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EDEC RID: 257516 RVA: 0x0101C25B File Offset: 0x0101A45B
		protected override void OnBeforeDestroy()
		{
			this.LguiComponentsRegistry = null;
			this.PanelData = null;
			this.BattleViewBaseActor = null;
			this.PanelItemMap.Clear();
		}

		// Token: 0x0603EDED RID: 257517 RVA: 0x0101C280 File Offset: 0x0101A480
		[NullableContext(1)]
		private UniTask InitializePanelItem([Nullable(2)] BattleUiSetPanelData panelData, AUIBaseActor battleViewBaseActor)
		{
			EditMobileBattleViewPanel.<InitializePanelItem>d__6 <InitializePanelItem>d__;
			<InitializePanelItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializePanelItem>d__.<>4__this = this;
			<InitializePanelItem>d__.panelData = panelData;
			<InitializePanelItem>d__.battleViewBaseActor = battleViewBaseActor;
			<InitializePanelItem>d__.<>1__state = -1;
			<InitializePanelItem>d__.<>t__builder.Start<EditMobileBattleViewPanel.<InitializePanelItem>d__6>(ref <InitializePanelItem>d__);
			return <InitializePanelItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EDEE RID: 257518 RVA: 0x0101C2D4 File Offset: 0x0101A4D4
		public void ResetAllPanelItem()
		{
			foreach (EditMobileBattleViewPanelItem editMobileBattleViewPanelItem in this.PanelItemMap.Values)
			{
				if (editMobileBattleViewPanelItem.PanelItemData != null)
				{
					editMobileBattleViewPanelItem.Reset();
				}
			}
		}

		// Token: 0x0603EDEF RID: 257519 RVA: 0x0101C334 File Offset: 0x0101A534
		public void SavePanelItem()
		{
			foreach (EditMobileBattleViewPanelItem editMobileBattleViewPanelItem in this.PanelItemMap.Values)
			{
				editMobileBattleViewPanelItem.OnSave();
			}
		}

		// Token: 0x0603EDF0 RID: 257520 RVA: 0x0101C38C File Offset: 0x0101A58C
		public EditMobileBattleViewPanelItem GetPanelItem(int panelItemIndex)
		{
			return this.PanelItemMap.GetValueOrDefault(panelItemIndex);
		}

		// Token: 0x0603EDF1 RID: 257521 RVA: 0x0101C39C File Offset: 0x0101A59C
		public void RefreshHierarchyIndex(int panelHierarchyIndex)
		{
			foreach (EditMobileBattleViewPanelItem editMobileBattleViewPanelItem in this.PanelItemMap.Values)
			{
				BattleUiSetPanelItemData panelItemData = editMobileBattleViewPanelItem.PanelItemData;
				if (panelItemData != null)
				{
					UUIItem rootItem = editMobileBattleViewPanelItem.GetRootItem();
					panelItemData.EditorHierarchyIndex = rootItem.GetHierarchyIndex();
				}
			}
		}

		// Token: 0x0603EDF2 RID: 257522 RVA: 0x0101C40C File Offset: 0x0101A60C
		[NullableContext(1)]
		public bool IsAnyItemOverlap(UUIItem item)
		{
			TArray<AActor> components = this.LguiComponentsRegistry.Components;
			for (int i = 0; i < components.Num(); i++)
			{
				EditMobileBattleViewPanelItem panelItem = this.GetPanelItem(i);
				if (panelItem != null)
				{
					BattleUiSetPanelItemData panelItemData = panelItem.PanelItemData;
					if (panelItemData == null || panelItemData.IsCheckOverlap)
					{
						AUIBaseActor auibaseActor = components.Get(i) as AUIBaseActor;
						if (auibaseActor != null)
						{
							UUIItem uiitem = auibaseActor.GetUIItem();
							if (uiitem.IsUIActiveInHierarchy() && uiitem.IsRaycastTarget() && uiitem != item && uiitem.GetOverlapWith(item))
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0402346F RID: 144495
		private AUIBaseActor BattleViewBaseActor;

		// Token: 0x04023470 RID: 144496
		public BattleUiSetPanelData PanelData;

		// Token: 0x04023471 RID: 144497
		[Nullable(1)]
		private readonly Dictionary<int, EditMobileBattleViewPanelItem> PanelItemMap = new Dictionary<int, EditMobileBattleViewPanelItem>();

		// Token: 0x04023472 RID: 144498
		private ULGUIComponentsRegistry LguiComponentsRegistry;
	}
}
