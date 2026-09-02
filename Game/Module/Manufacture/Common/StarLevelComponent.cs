using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059F5 RID: 23029
	[NullableContext(1)]
	[Nullable(0)]
	public class StarLevelComponent
	{
		// Token: 0x0603A586 RID: 238982 RVA: 0x00ECB3BB File Offset: 0x00EC95BB
		public StarLevelComponent(UUILayoutBase layout)
		{
			this.StarLayout = new GenericLayoutNew<StarItem>(layout, new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<StarItem>(this.OnCreateStarProxy), null);
		}

		// Token: 0x0603A587 RID: 238983 RVA: 0x00ECB3DC File Offset: 0x00EC95DC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private ILayoutItem<StarItem> OnCreateStarProxy(object data, UUIItem uiItem, int index)
		{
			if (data is bool)
			{
				bool state = (bool)data;
				StarItem starItem = new StarItem();
				starItem.CreateThenShowByActor(uiItem.GetOwner(), null);
				starItem.SetState(state);
				return new LayoutItem<StarItem>
				{
					Key = index,
					Value = starItem
				};
			}
			return null;
		}

		// Token: 0x0603A588 RID: 238984 RVA: 0x00ECB430 File Offset: 0x00EC9630
		public void ShowLevel(int current, int max)
		{
			List<bool> list = new List<bool>(new bool[max]);
			for (int i = 0; i < current; i++)
			{
				list[i] = true;
			}
			this.StarLayout.RebuildLayoutByDataNew<bool>(list, null);
		}

		// Token: 0x0603A589 RID: 238985 RVA: 0x00ECB472 File Offset: 0x00EC9672
		public void Clear()
		{
			this.StarLayout.ClearChildren();
		}

		// Token: 0x040210AD RID: 135341
		private readonly GenericLayoutNew<StarItem> StarLayout;
	}
}
