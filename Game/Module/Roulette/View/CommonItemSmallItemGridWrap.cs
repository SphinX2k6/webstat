using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roulette.View
{
	// Token: 0x02005016 RID: 20502
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CommonItemSmallItemGridWrap : GridProxyAbstract<ItemRefreshData>
	{
		// Token: 0x06034D64 RID: 216420 RVA: 0x00D43E60 File Offset: 0x00D42060
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034D65 RID: 216421 RVA: 0x00D43EA8 File Offset: 0x00D420A8
		public override void Refresh(ItemRefreshData data, bool isSelected, int gridIndex)
		{
			this.GridItem.RefreshByConfigId(data.ItemId, null, null, false, false);
			this.GridItem.SetLockVisible(data.NeedLock);
			bool flag = data.Text != null;
			this.GridItem.SetBottomTextVisible(flag);
			if (flag)
			{
				this.GridItem.SetBottomText(data.Text);
			}
		}

		// Token: 0x06034D66 RID: 216422 RVA: 0x00D43F10 File Offset: 0x00D42110
		protected override void OnStart()
		{
			this.GridItem = new CommonItemSmallItemGrid();
			UUIItem item = base.GetItem(0);
			this.GridItem.Initialize(item.GetOwner());
		}

		// Token: 0x06034D67 RID: 216423 RVA: 0x00D43F41 File Offset: 0x00D42141
		protected override void OnBeforeDestroy()
		{
			this.GridItem.Destroy(null);
		}

		// Token: 0x0401E74D RID: 124749
		[Nullable(2)]
		public CommonItemSmallItemGrid GridItem;
	}
}
