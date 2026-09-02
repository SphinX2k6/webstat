using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C9C RID: 19612
	[NullableContext(1)]
	[Nullable(0)]
	public class RouletteViewPanelHandle : SpecialPanelHandleBase
	{
		// Token: 0x060331B5 RID: 209333 RVA: 0x00CCCBA8 File Offset: 0x00CCADA8
		public RouletteViewPanelHandle(string type) : base(type)
		{
		}

		// Token: 0x060331B6 RID: 209334 RVA: 0x00CCCBB4 File Offset: 0x00CCADB4
		protected override List<TsUiNavigationBehaviorListener> OnGetSuitableNavigationListenerList(bool isDefault)
		{
			if (isDefault)
			{
				return this.DefaultNavigationListener;
			}
			if (!UiNavigationLogic.HasActiveListenerInGroup(base.GetNavigationGroup("Group2")))
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.DefaultNavigationListener[0];
				NavigationGroup navigationGroup = tsUiNavigationBehaviorListener.GetNavigationGroup();
				if (((navigationGroup != null) ? navigationGroup.LastSelectListener : null) != null)
				{
					TsUiNavigationBehaviorListener lastSelectListener = tsUiNavigationBehaviorListener.GetNavigationGroup().LastSelectListener;
					this.DefaultNavigationListener[0] = lastSelectListener;
				}
				return this.DefaultNavigationListener;
			}
			if (this.ChangeListenerList == null)
			{
				this.ChangeListenerList = this.DefaultNavigationListener.ToList<TsUiNavigationBehaviorListener>();
				if (this.ChangeListenerList.Count >= 2)
				{
					List<TsUiNavigationBehaviorListener> changeListenerList = this.ChangeListenerList;
					List<TsUiNavigationBehaviorListener> changeListenerList2 = this.ChangeListenerList;
					TsUiNavigationBehaviorListener value = this.ChangeListenerList[1];
					TsUiNavigationBehaviorListener value2 = this.ChangeListenerList[0];
					changeListenerList[0] = value;
					changeListenerList2[1] = value2;
				}
			}
			return this.ChangeListenerList;
		}

		// Token: 0x0401DB73 RID: 121715
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<TsUiNavigationBehaviorListener> ChangeListenerList;
	}
}
