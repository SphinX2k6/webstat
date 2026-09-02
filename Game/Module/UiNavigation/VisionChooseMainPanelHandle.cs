using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C9F RID: 19615
	[NullableContext(1)]
	[Nullable(0)]
	public class VisionChooseMainPanelHandle : SpecialPanelHandleBase
	{
		// Token: 0x060331E1 RID: 209377 RVA: 0x00CCD1F1 File Offset: 0x00CCB3F1
		public VisionChooseMainPanelHandle(string type) : base(type)
		{
		}

		// Token: 0x170087BF RID: 34751
		// (get) Token: 0x060331E2 RID: 209378 RVA: 0x00CCD1FC File Offset: 0x00CCB3FC
		public List<TsUiNavigationBehaviorListener> ChangeListenerList
		{
			get
			{
				if (this.ChangeListenerListInternal == null)
				{
					this.ChangeListenerListInternal = this.DefaultNavigationListener.ToList<TsUiNavigationBehaviorListener>();
					if (this.ChangeListenerListInternal.Count >= 2)
					{
						List<TsUiNavigationBehaviorListener> changeListenerListInternal = this.ChangeListenerListInternal;
						List<TsUiNavigationBehaviorListener> changeListenerListInternal2 = this.ChangeListenerListInternal;
						TsUiNavigationBehaviorListener value = this.ChangeListenerListInternal[1];
						TsUiNavigationBehaviorListener value2 = this.ChangeListenerListInternal[0];
						changeListenerListInternal[0] = value;
						changeListenerListInternal2[1] = value2;
					}
				}
				return this.ChangeListenerListInternal;
			}
		}

		// Token: 0x060331E3 RID: 209379 RVA: 0x00CCD26C File Offset: 0x00CCB46C
		protected override List<TsUiNavigationBehaviorListener> OnGetSuitableNavigationListenerList(bool isDefault)
		{
			if (this.IsFindChangeListenerList)
			{
				return this.ChangeListenerList;
			}
			if (!isDefault)
			{
				return this.DefaultNavigationListener;
			}
			if (!UiNavigationGlobalData.VisionReplaceViewFindDefault)
			{
				return this.ChangeListenerList;
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.FindVisionTabItemListener(this.DefaultNavigationListener[0]);
			if (tsUiNavigationBehaviorListener != null)
			{
				return new List<TsUiNavigationBehaviorListener>
				{
					tsUiNavigationBehaviorListener
				};
			}
			return this.DefaultNavigationListener;
		}

		// Token: 0x060331E4 RID: 209380 RVA: 0x00CCD2C9 File Offset: 0x00CCB4C9
		protected override void OnNotifyFindResult(FindNavigationResult result)
		{
			if (result.IsInLoopingProcess())
			{
				return;
			}
			UiNavigationGlobalData.VisionReplaceViewFindDefault = true;
			this.IsFindChangeListenerList = false;
		}

		// Token: 0x060331E5 RID: 209381 RVA: 0x00CCD2E4 File Offset: 0x00CCB4E4
		[return: Nullable(2)]
		private TsUiNavigationBehaviorListener FindVisionTabItemListener(TsUiNavigationBehaviorListener listener)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = null;
			NavigationGroup navigationGroup = base.GetNavigationGroup(listener.GroupName);
			if (navigationGroup == null)
			{
				return null;
			}
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 in navigationGroup.ListenerList)
			{
				if (tsUiNavigationBehaviorListener == null && tsUiNavigationBehaviorListener2.IsCanFocus())
				{
					tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
				}
				if (tsUiNavigationBehaviorListener2.IsInScrollOrLayoutCanFocus())
				{
					return tsUiNavigationBehaviorListener2;
				}
			}
			return tsUiNavigationBehaviorListener;
		}

		// Token: 0x0401DB7A RID: 121722
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<TsUiNavigationBehaviorListener> ChangeListenerListInternal;

		// Token: 0x0401DB7B RID: 121723
		public bool IsFindChangeListenerList;
	}
}
