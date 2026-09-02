using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.TabView.VisionSubView
{
	// Token: 0x02005068 RID: 20584
	[NullableContext(1)]
	[Nullable(0)]
	internal class RoleVisionDescScroller : UiPanelBase
	{
		// Token: 0x06035072 RID: 217202 RVA: 0x00D4CFFC File Offset: 0x00D4B1FC
		public RoleVisionDescScroller(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x06035073 RID: 217203 RVA: 0x00D4D011 File Offset: 0x00D4B211
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06035074 RID: 217204 RVA: 0x00D4D04A File Offset: 0x00D4B24A
		protected override void OnStart()
		{
			this.Scroller = new GenericScrollView<RoleVisionFetterDescScrollerItem>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<RoleVisionFetterDescScrollerItem>(this.InitFettersItem), null);
		}

		// Token: 0x06035075 RID: 217205 RVA: 0x00D4D06C File Offset: 0x00D4B26C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private ILayoutItem<RoleVisionFetterDescScrollerItem> InitFettersItem([Nullable(2)] object data, UUIItem item, int index)
		{
			RoleVisionFetterDescScrollerItem roleVisionFetterDescScrollerItem = new RoleVisionFetterDescScrollerItem(item);
			roleVisionFetterDescScrollerItem.Update((PhantomFetter)data);
			return new LayoutItem<RoleVisionFetterDescScrollerItem>
			{
				Key = index,
				Value = roleVisionFetterDescScrollerItem
			};
		}

		// Token: 0x06035076 RID: 217206 RVA: 0x00D4D0A4 File Offset: 0x00D4B2A4
		public void Update(IReadOnlyList<PhantomFetter> data)
		{
			this.Scroller.RefreshByData<PhantomFetter>(new List<PhantomFetter>(data), null);
		}

		// Token: 0x06035077 RID: 217207 RVA: 0x00D4D0CB File Offset: 0x00D4B2CB
		protected override void OnBeforeDestroy()
		{
			this.Scroller.ClearChildren();
		}

		// Token: 0x0401E89B RID: 125083
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollView<RoleVisionFetterDescScrollerItem> Scroller;
	}
}
