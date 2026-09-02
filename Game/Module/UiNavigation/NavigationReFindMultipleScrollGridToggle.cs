using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CA4 RID: 19620
	public class NavigationReFindMultipleScrollGridToggle : NavigationToggle
	{
		// Token: 0x06033208 RID: 209416 RVA: 0x00CCDB4A File Offset: 0x00CCBD4A
		[NullableContext(1)]
		public NavigationReFindMultipleScrollGridToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033209 RID: 209417 RVA: 0x00CCDB55 File Offset: 0x00CCBD55
		protected override bool OnCanFocusInScrollOrLayout()
		{
			return false;
		}

		// Token: 0x0603320A RID: 209418 RVA: 0x00CCDB58 File Offset: 0x00CCBD58
		protected override void OnToggleClick(EToggleState state)
		{
			if (this.Listener == null)
			{
				return;
			}
			if (!this.Listener.HasMultiTemplateScrollView())
			{
				return;
			}
			if (this.Listener.PanelConfig == null)
			{
				return;
			}
			int gridIndexByChildComponent = (this.Listener.ScrollProxy.ScrollView as UUIMultiTemplateScrollViewComponent).GetGridIndexByChildComponent(this.Listener.GetSelectableComponent());
			FindMultiTemplateNavigationListener findMultiTemplateNavigationListener = new FindMultiTemplateNavigationListener();
			findMultiTemplateNavigationListener.PanelConfig = this.Listener.PanelConfig;
			findMultiTemplateNavigationListener.AddParam(new object[]
			{
				this.Listener,
				gridIndexByChildComponent
			});
			findMultiTemplateNavigationListener.AddParam(new object[]
			{
				this.Listener
			});
			this.Listener.PanelConfig.SetFindNavigationAction(findMultiTemplateNavigationListener);
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
		}
	}
}
