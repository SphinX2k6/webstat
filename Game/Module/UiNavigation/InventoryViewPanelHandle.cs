using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C96 RID: 19606
	public class InventoryViewPanelHandle : SpecialPanelHandleBase
	{
		// Token: 0x0603318F RID: 209295 RVA: 0x00CCC1E1 File Offset: 0x00CCA3E1
		[NullableContext(1)]
		public InventoryViewPanelHandle(string type) : base(type)
		{
		}

		// Token: 0x170087B9 RID: 34745
		// (get) Token: 0x06033190 RID: 209296 RVA: 0x00CCC1EA File Offset: 0x00CCA3EA
		public bool IsInDestroyMode
		{
			get
			{
				return this.IsInDestroyModeInternal;
			}
		}

		// Token: 0x06033191 RID: 209297 RVA: 0x00CCC1F4 File Offset: 0x00CCA3F4
		[NullableContext(2)]
		private NavigationGroup FindItemGridGroupConfig()
		{
			string groupName = "";
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in this.DefaultNavigationListener)
			{
				if (tsUiNavigationBehaviorListener.GetNavigationComponent().GetType() == ENavigationSelectableDefine.InventoryItemGridToggle)
				{
					groupName = tsUiNavigationBehaviorListener.GroupName;
					break;
				}
			}
			return base.GetNavigationGroup(groupName);
		}

		// Token: 0x06033192 RID: 209298 RVA: 0x00CCC268 File Offset: 0x00CCA468
		public void SetItemGridDestroyMode(bool isInDestroyMode)
		{
			this.IsInDestroyModeInternal = isInDestroyMode;
			NavigationGroup navigationGroup = this.FindItemGridGroupConfig();
			if (navigationGroup == null)
			{
				return;
			}
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in navigationGroup.ListenerList)
			{
				UUIExtendToggle uuiextendToggle = tsUiNavigationBehaviorListener.GetBehaviorComponent() as UUIExtendToggle;
				if (uuiextendToggle != null)
				{
					uuiextendToggle.bToggleOnSelect = !isInDestroyMode;
				}
			}
		}

		// Token: 0x0401DB66 RID: 121702
		private bool IsInDestroyModeInternal;
	}
}
