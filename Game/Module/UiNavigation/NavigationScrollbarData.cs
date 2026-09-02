using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C91 RID: 19601
	[NullableContext(2)]
	[Nullable(0)]
	public class NavigationScrollbarData
	{
		// Token: 0x06033178 RID: 209272 RVA: 0x00CCBC70 File Offset: 0x00CC9E70
		private void FindSuitableScrollbar()
		{
			TsUiNavigationBehaviorListener currentListener = this.CurrentListener;
			if (currentListener != null && currentListener.IsListenerActive())
			{
				return;
			}
			TsUiNavigationBehaviorListener currentScrollbar = null;
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in this.ScrollbarList)
			{
				if (tsUiNavigationBehaviorListener.IsListenerActive())
				{
					currentScrollbar = tsUiNavigationBehaviorListener;
					break;
				}
			}
			this.SetCurrentScrollbar(currentScrollbar);
		}

		// Token: 0x06033179 RID: 209273 RVA: 0x00CCBCE8 File Offset: 0x00CC9EE8
		private void SetCurrentScrollbar(TsUiNavigationBehaviorListener listener)
		{
			if (this.CurrentListener != null)
			{
				this.CurrentListener.IsFocusScrollbar = false;
			}
			if (listener != null)
			{
				listener.IsFocusScrollbar = true;
			}
			this.LastListener = this.CurrentListener;
			this.CurrentListener = listener;
			this.CurrentScrollbar = (((listener != null) ? listener.GetBehaviorComponent() : null) as UUIScrollViewComponent);
		}

		// Token: 0x0603317A RID: 209274 RVA: 0x00CCBD40 File Offset: 0x00CC9F40
		[NullableContext(1)]
		public void AddScrollbar(List<NavigationGroup> groupArray)
		{
			this.ScrollbarList.Clear();
			foreach (NavigationGroup navigationGroup in groupArray)
			{
				foreach (TsUiNavigationBehaviorListener item in navigationGroup.ListenerList)
				{
					this.ScrollbarList.Add(item);
				}
			}
			this.ScrollbarList.Sort((TsUiNavigationBehaviorListener aListener, TsUiNavigationBehaviorListener bListener) => (int)(aListener.ScrollbarIndex - bListener.ScrollbarIndex));
			this.FindSuitableScrollbar();
		}

		// Token: 0x0603317B RID: 209275 RVA: 0x00CCBE08 File Offset: 0x00CCA008
		public void DeleteScrollbar(NavigationGroup group)
		{
			List<TsUiNavigationBehaviorListener> list = (group != null) ? group.ListenerList : null;
			if (list == null)
			{
				return;
			}
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in list)
			{
				int num = this.ScrollbarList.IndexOf(tsUiNavigationBehaviorListener);
				if (num >= 0)
				{
					this.ScrollbarList.RemoveAt(num);
				}
				if (this.CurrentListener == tsUiNavigationBehaviorListener)
				{
					this.SetCurrentScrollbar(null);
				}
			}
			this.FindSuitableScrollbar();
		}

		// Token: 0x0603317C RID: 209276 RVA: 0x00CCBE94 File Offset: 0x00CCA094
		public void ResumeLastListener()
		{
			TsUiNavigationBehaviorListener lastListener = this.LastListener;
			if (lastListener != null && lastListener.IsValid() && this.LastListener.IsListenerActive())
			{
				this.SetCurrentScrollbar(this.LastListener);
				return;
			}
			this.FindSuitableScrollbar();
		}

		// Token: 0x0603317D RID: 209277 RVA: 0x00CCBECA File Offset: 0x00CCA0CA
		[NullableContext(1)]
		public TsUiNavigationBehaviorListener GetCurrentListener()
		{
			return this.CurrentListener;
		}

		// Token: 0x0603317E RID: 209278 RVA: 0x00CCBED2 File Offset: 0x00CCA0D2
		[NullableContext(1)]
		public UUIScrollViewComponent GetCurrentScrollbar()
		{
			return this.CurrentScrollbar;
		}

		// Token: 0x0603317F RID: 209279 RVA: 0x00CCBEDA File Offset: 0x00CCA0DA
		public bool HasActiveScrollbarList()
		{
			return this.ScrollbarList.FindAll((TsUiNavigationBehaviorListener listener) => listener.IsListenerActive()).Count > 1;
		}

		// Token: 0x06033180 RID: 209280 RVA: 0x00CCBF10 File Offset: 0x00CCA110
		public void FindNextScrollbar()
		{
			if (this.CurrentListener == null)
			{
				this.FindSuitableScrollbar();
			}
			else
			{
				int count = this.ScrollbarList.Count;
				if (count == 1)
				{
					this.SetCurrentScrollbar(null);
					return;
				}
				int num = this.ScrollbarList.IndexOf(this.CurrentListener);
				int num2 = (num + 1 < count) ? (num + 1) : 0;
				while (num != num2)
				{
					if (this.ScrollbarList[num2].IsListenerActive())
					{
						this.SetCurrentScrollbar(this.ScrollbarList[num2]);
						break;
					}
					num2 = ((num2 + 1 < count) ? (num2 + 1) : 0);
				}
			}
			Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
		}

		// Token: 0x06033181 RID: 209281 RVA: 0x00CCBFAC File Offset: 0x00CCA1AC
		public void FindPrevScrollbar()
		{
			if (this.CurrentListener == null)
			{
				this.FindSuitableScrollbar();
			}
			else
			{
				int count = this.ScrollbarList.Count;
				if (count == 1)
				{
					return;
				}
				int num = this.ScrollbarList.IndexOf(this.CurrentListener);
				int num2 = (num - 1 >= 0) ? (num - 1) : (count - 1);
				while (num != num2)
				{
					if (this.ScrollbarList[num2].IsListenerActive())
					{
						this.SetCurrentScrollbar(this.ScrollbarList[num2]);
						break;
					}
					num2 = ((num2 - 1 >= 0) ? (num2 - 1) : (count - 1));
				}
			}
			Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
		}

		// Token: 0x06033182 RID: 209282 RVA: 0x00CCC043 File Offset: 0x00CCA243
		public void TryFindScrollbar()
		{
			this.FindSuitableScrollbar();
		}

		// Token: 0x0401DB5E RID: 121694
		[Nullable(1)]
		private List<TsUiNavigationBehaviorListener> ScrollbarList = new List<TsUiNavigationBehaviorListener>();

		// Token: 0x0401DB5F RID: 121695
		private TsUiNavigationBehaviorListener CurrentListener;

		// Token: 0x0401DB60 RID: 121696
		private UUIScrollViewComponent CurrentScrollbar;

		// Token: 0x0401DB61 RID: 121697
		private TsUiNavigationBehaviorListener LastListener;
	}
}
