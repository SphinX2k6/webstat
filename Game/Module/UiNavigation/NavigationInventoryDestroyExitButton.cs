using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CAD RID: 19629
	public class NavigationInventoryDestroyExitButton : NavigationButton
	{
		// Token: 0x06033218 RID: 209432 RVA: 0x00CCDDD5 File Offset: 0x00CCBFD5
		[NullableContext(1)]
		public NavigationInventoryDestroyExitButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033219 RID: 209433 RVA: 0x00CCDDE0 File Offset: 0x00CCBFE0
		protected override void OnButtonClick()
		{
			InventoryViewPanelHandle inventoryViewPanelHandle = this.PanelHandle as InventoryViewPanelHandle;
			if (inventoryViewPanelHandle == null)
			{
				return;
			}
			inventoryViewPanelHandle.SetItemGridDestroyMode(false);
		}
	}
}
