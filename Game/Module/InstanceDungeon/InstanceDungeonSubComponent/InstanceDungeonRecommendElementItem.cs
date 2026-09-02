using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BF0 RID: 23536
	public class InstanceDungeonRecommendElementItem : UiPanelBase
	{
		// Token: 0x0603B924 RID: 244004 RVA: 0x00F19D6C File Offset: 0x00F17F6C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B925 RID: 244005 RVA: 0x00F19DB4 File Offset: 0x00F17FB4
		protected override void OnStart()
		{
			this.ElementLayout = new GenericLayout<TowerElementItem, int>(base.GetHorizontalLayout(0), new Func<TowerElementItem>(this.CreateElementItem), null, false, true);
			if (this.ItemDataHandle != null)
			{
				this.RefreshItem(this.ItemDataHandle.Element);
			}
		}

		// Token: 0x0603B926 RID: 244006 RVA: 0x00F19DF0 File Offset: 0x00F17FF0
		[NullableContext(1)]
		private TowerElementItem CreateElementItem()
		{
			return new TowerElementItem();
		}

		// Token: 0x0603B927 RID: 244007 RVA: 0x00F19DF7 File Offset: 0x00F17FF7
		[NullableContext(1)]
		public void RefreshItem(List<int> element)
		{
			if (base.InAsyncLoading())
			{
				this.ItemDataHandle = new IInstanceDungeonRecommendElementItem
				{
					Element = element
				};
				return;
			}
			GenericLayout<TowerElementItem, int> elementLayout = this.ElementLayout;
			if (elementLayout == null)
			{
				return;
			}
			elementLayout.RefreshByData(element, null, false);
		}

		// Token: 0x04021891 RID: 137361
		[Nullable(2)]
		private IInstanceDungeonRecommendElementItem ItemDataHandle;

		// Token: 0x04021892 RID: 137362
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<TowerElementItem, int> ElementLayout;

		// Token: 0x0200BC67 RID: 48231
		private enum EChildType
		{
			// Token: 0x0403A182 RID: 237954
			RecommendElementLayout
		}
	}
}
