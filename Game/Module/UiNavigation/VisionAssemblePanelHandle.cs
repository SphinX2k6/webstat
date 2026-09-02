using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C9E RID: 19614
	[NullableContext(1)]
	[Nullable(0)]
	public class VisionAssemblePanelHandle : SpecialPanelHandleBase
	{
		// Token: 0x060331DA RID: 209370 RVA: 0x00CCD0FE File Offset: 0x00CCB2FE
		public VisionAssemblePanelHandle(string type) : base(type)
		{
		}

		// Token: 0x170087BE RID: 34750
		// (get) Token: 0x060331DB RID: 209371 RVA: 0x00CCD107 File Offset: 0x00CCB307
		// (set) Token: 0x060331DC RID: 209372 RVA: 0x00CCD10F File Offset: 0x00CCB30F
		public bool IsInCompare { get; set; }

		// Token: 0x060331DD RID: 209373 RVA: 0x00CCD118 File Offset: 0x00CCB318
		protected override void OnInit()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnVisionAssembleNavigationRefresh, new Action<bool>(this.RefreshNavigation));
		}

		// Token: 0x060331DE RID: 209374 RVA: 0x00CCD136 File Offset: 0x00CCB336
		protected override void OnClear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionAssembleNavigationRefresh, new Action<bool>(this.RefreshNavigation));
		}

		// Token: 0x060331DF RID: 209375 RVA: 0x00CCD154 File Offset: 0x00CCB354
		protected override List<TsUiNavigationBehaviorListener> OnGetSuitableNavigationListenerList(bool isDefault)
		{
			if (isDefault)
			{
				return base.OnGetSuitableNavigationListenerList(isDefault);
			}
			if (this.TempListenerList == null)
			{
				this.TempListenerList = new List<TsUiNavigationBehaviorListener>();
				foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in this.DefaultNavigationListener)
				{
					if (tsUiNavigationBehaviorListener.IsScrollOrLayoutActor())
					{
						this.TempListenerList.Add(tsUiNavigationBehaviorListener);
					}
				}
			}
			return this.TempListenerList;
		}

		// Token: 0x060331E0 RID: 209376 RVA: 0x00CCD1D8 File Offset: 0x00CCB3D8
		private void RefreshNavigation(bool isCompareTrigger)
		{
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
			if (isCompareTrigger)
			{
				ModelBase<UiNavigationModel>.Instance.MarkMoveInstantly();
			}
		}

		// Token: 0x0401DB78 RID: 121720
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<TsUiNavigationBehaviorListener> TempListenerList;
	}
}
