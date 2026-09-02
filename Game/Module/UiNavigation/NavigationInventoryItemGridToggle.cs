using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CAE RID: 19630
	public class NavigationInventoryItemGridToggle : NavigationToggle
	{
		// Token: 0x0603321A RID: 209434 RVA: 0x00CCDDF8 File Offset: 0x00CCBFF8
		[NullableContext(1)]
		public NavigationInventoryItemGridToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x0603321B RID: 209435 RVA: 0x00CCDE04 File Offset: 0x00CCC004
		protected override void OnStart()
		{
			SpecialPanelHandleBase panelHandle = this.PanelHandle;
			if (((panelHandle != null) ? new ESpecialPanelHandleDefine?(panelHandle.GetType()) : null) == ESpecialPanelHandleDefine.Inventory)
			{
				InventoryViewPanelHandle inventoryViewPanelHandle = this.PanelHandle as InventoryViewPanelHandle;
				(this.Selectable as UUIExtendToggle).bToggleOnSelect = !inventoryViewPanelHandle.IsInDestroyMode;
			}
		}
	}
}
