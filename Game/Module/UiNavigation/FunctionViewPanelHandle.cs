using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C94 RID: 19604
	[NullableContext(1)]
	[Nullable(0)]
	public class FunctionViewPanelHandle : SpecialPanelHandleBase
	{
		// Token: 0x06033186 RID: 209286 RVA: 0x00CCC070 File Offset: 0x00CCA270
		public FunctionViewPanelHandle(string type) : base(type)
		{
		}

		// Token: 0x06033187 RID: 209287 RVA: 0x00CCC0A1 File Offset: 0x00CCA2A1
		protected override void OnDefaultNavigationListenerList(TArray<AActor> actorArray)
		{
		}

		// Token: 0x06033188 RID: 209288 RVA: 0x00CCC0A3 File Offset: 0x00CCA2A3
		protected override TsUiNavigationBehaviorListener OnGetLoopOrLayoutListener(TsUiNavigationBehaviorListener listener)
		{
			return listener;
		}

		// Token: 0x06033189 RID: 209289 RVA: 0x00CCC0A8 File Offset: 0x00CCA2A8
		public void AddNavigationListener(TsUiNavigationBehaviorListener listener)
		{
			this.PageListenerSet.Add(listener);
			if (this.PageLayoutActorSet.Contains(listener.LayoutActor))
			{
				return;
			}
			UUIItem parentAsUIItem = (listener.LayoutActor as AUIBaseActor).GetUIItem().GetParentAsUIItem();
			int num = parentAsUIItem.GetParentAsUIItem().UIChildren.FindIndex(parentAsUIItem);
			this.PageLayoutActorSet.Add(listener.LayoutActor);
			this.PageFirstListenerMap[num] = listener;
			if (num == 1)
			{
				this.SetDefaultListener(num, listener);
			}
		}

		// Token: 0x0603318A RID: 209290 RVA: 0x00CCC12A File Offset: 0x00CCA32A
		private void SetDefaultListener(int index, TsUiNavigationBehaviorListener listener)
		{
			this.CurrentPageIndex = index;
			base.SetNavigationGroupDefaultListener(listener, false);
			this.DefaultNavigationListener.Clear();
			this.DefaultNavigationListener.Add(listener);
		}

		// Token: 0x0603318B RID: 209291 RVA: 0x00CCC154 File Offset: 0x00CCA354
		private void FindFocusListener(int index)
		{
			TsUiNavigationBehaviorListener listener;
			if (!this.PageFirstListenerMap.TryGetValue(index, out listener))
			{
				return;
			}
			TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			if (currentNavigationFocusListener == null || !this.PageListenerSet.Contains(currentNavigationFocusListener))
			{
				this.SetDefaultListener(index, listener);
				return;
			}
			this.SetDefaultListener(index, listener);
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
			ModelBase<UiNavigationModel>.Instance.SetCursorActiveDelayTime(350f);
		}

		// Token: 0x0603318C RID: 209292 RVA: 0x00CCC1B8 File Offset: 0x00CCA3B8
		public void FindNextFocusListener()
		{
			this.FindFocusListener(this.CurrentPageIndex + 1);
		}

		// Token: 0x0603318D RID: 209293 RVA: 0x00CCC1C8 File Offset: 0x00CCA3C8
		public void FindPrevFocusListener()
		{
			this.FindFocusListener(this.CurrentPageIndex - 1);
		}

		// Token: 0x0401DB62 RID: 121698
		private readonly HashSet<AActor> PageLayoutActorSet = new HashSet<AActor>();

		// Token: 0x0401DB63 RID: 121699
		private readonly Dictionary<int, TsUiNavigationBehaviorListener> PageFirstListenerMap = new Dictionary<int, TsUiNavigationBehaviorListener>();

		// Token: 0x0401DB64 RID: 121700
		private readonly HashSet<TsUiNavigationBehaviorListener> PageListenerSet = new HashSet<TsUiNavigationBehaviorListener>();

		// Token: 0x0401DB65 RID: 121701
		private int CurrentPageIndex = 1;
	}
}
