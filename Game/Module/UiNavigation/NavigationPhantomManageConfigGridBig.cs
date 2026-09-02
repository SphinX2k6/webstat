using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CBF RID: 19647
	public class NavigationPhantomManageConfigGridBig : NavigationButton
	{
		// Token: 0x06033297 RID: 209559 RVA: 0x00CCF124 File Offset: 0x00CCD324
		[NullableContext(1)]
		public NavigationPhantomManageConfigGridBig(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033298 RID: 209560 RVA: 0x00CCF130 File Offset: 0x00CCD330
		protected override void OnStart()
		{
			SpecialPanelHandleBase panelHandle = this.PanelHandle;
			if (((panelHandle != null) ? new ESpecialPanelHandleDefine?(panelHandle.GetType()) : null) == ESpecialPanelHandleDefine.PhantomManageConfig)
			{
				PhantomManageConfigPanelHandle phantomManageConfigPanelHandle = this.PanelHandle as PhantomManageConfigPanelHandle;
				TsUiNavigationBehaviorListener listener = this.Listener;
				AActor aactor = (listener != null) ? listener.LayoutActor : null;
				TWeakObjectPtr<UUIItem> rootUIComp = this.Selectable.RootUIComp;
				if (phantomManageConfigPanelHandle != null && this.Listener != null && aactor != null)
				{
					phantomManageConfigPanelHandle.AddNavigationListener(aactor, this.Listener, rootUIComp);
				}
			}
		}

		// Token: 0x06033299 RID: 209561 RVA: 0x00CCF1D0 File Offset: 0x00CCD3D0
		protected override void OnButtonClick()
		{
			PhantomManageConfigPanelHandle phantomManageConfigPanelHandle = this.PanelHandle as PhantomManageConfigPanelHandle;
			TsUiNavigationBehaviorListener listener = this.Listener;
			AActor aactor = (listener != null) ? listener.LayoutActor : null;
			if (phantomManageConfigPanelHandle != null && this.Listener != null && aactor != null)
			{
				phantomManageConfigPanelHandle.FindNextFocusListener(aactor, this.Listener);
			}
		}
	}
}
