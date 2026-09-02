using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C99 RID: 19609
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomManageConfigPanelHandle : SpecialPanelHandleBase
	{
		// Token: 0x060331A3 RID: 209315 RVA: 0x00CCC650 File Offset: 0x00CCA850
		public PhantomManageConfigPanelHandle(string type) : base(type)
		{
		}

		// Token: 0x060331A4 RID: 209316 RVA: 0x00CCC664 File Offset: 0x00CCA864
		public void AddNavigationListener(AActor layout, TsUiNavigationBehaviorListener listener, UUIItem item)
		{
			List<TsUiNavigationBehaviorListener> list;
			if (!this.LayoutListenerListMap.TryGetValue(layout, out list))
			{
				list = new List<TsUiNavigationBehaviorListener>();
				this.LayoutListenerListMap[layout] = list;
			}
			if (!list.Contains(listener))
			{
				list.Add(listener);
				list.Sort(new Comparison<TsUiNavigationBehaviorListener>(this.ListenerListSortFunction));
			}
		}

		// Token: 0x060331A5 RID: 209317 RVA: 0x00CCC6B8 File Offset: 0x00CCA8B8
		public void FindNextFocusListener(AActor layout, TsUiNavigationBehaviorListener listener)
		{
			List<TsUiNavigationBehaviorListener> list;
			if (!this.LayoutListenerListMap.TryGetValue(layout, out list))
			{
				return;
			}
			if (listener.IsCanFocus())
			{
				return;
			}
			if (list.Count == 0)
			{
				return;
			}
			int num = list.IndexOf(listener);
			if (num <= 0)
			{
				return;
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.FindActiveListener(list, num - 1, -1, -1);
			if (tsUiNavigationBehaviorListener == null)
			{
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(tsUiNavigationBehaviorListener.RootUIComp, true, false, false);
		}

		// Token: 0x060331A6 RID: 209318 RVA: 0x00CCC720 File Offset: 0x00CCA920
		[return: Nullable(2)]
		private TsUiNavigationBehaviorListener FindActiveListener(List<TsUiNavigationBehaviorListener> list, int start, int end, int step)
		{
			for (int num = start; num != end; num += step)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = list[num];
				if (tsUiNavigationBehaviorListener != null && tsUiNavigationBehaviorListener.IsCanFocus())
				{
					return tsUiNavigationBehaviorListener;
				}
			}
			return null;
		}

		// Token: 0x060331A7 RID: 209319 RVA: 0x00CCC750 File Offset: 0x00CCA950
		private int ListenerListSortFunction(TsUiNavigationBehaviorListener aListener, TsUiNavigationBehaviorListener bListener)
		{
			int num = aListener.IsValid() ? aListener.RootUIComp.Get().hierarchyIndex : 0;
			int num2 = bListener.IsValid() ? bListener.RootUIComp.Get().hierarchyIndex : 0;
			if (num != num2)
			{
				return num - num2;
			}
			return -1;
		}

		// Token: 0x0401DB69 RID: 121705
		private readonly Dictionary<AActor, List<TsUiNavigationBehaviorListener>> LayoutListenerListMap = new Dictionary<AActor, List<TsUiNavigationBehaviorListener>>();
	}
}
