using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006432 RID: 25650
	internal class RoverlikeLootStarLayout : UiPanelBase
	{
		// Token: 0x06040655 RID: 263765 RVA: 0x01082414 File Offset: 0x01080614
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040656 RID: 263766 RVA: 0x0108247D File Offset: 0x0108067D
		protected override void OnStart()
		{
			this.StarGrid = new GenericLayout<RoverlikeLootStarItem, bool>(base.GetHorizontalLayout(0), new Func<RoverlikeLootStarItem>(this.CreateStarItem), base.GetItem(1).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x06040657 RID: 263767 RVA: 0x010824B0 File Offset: 0x010806B0
		protected override void OnBeforeDestroy()
		{
			this.StarGrid = null;
		}

		// Token: 0x06040658 RID: 263768 RVA: 0x010824B9 File Offset: 0x010806B9
		public void SetVisible(bool visible)
		{
			base.SetUiActive(visible);
		}

		// Token: 0x06040659 RID: 263769 RVA: 0x010824C4 File Offset: 0x010806C4
		public void SetStars(int level, int maxLevel)
		{
			List<bool> list = new List<bool>();
			for (int i = 0; i < maxLevel; i++)
			{
				list.Add(i < level);
			}
			GenericLayout<RoverlikeLootStarItem, bool> starGrid = this.StarGrid;
			if (starGrid == null)
			{
				return;
			}
			starGrid.RefreshByData(list, null, false);
		}

		// Token: 0x0604065A RID: 263770 RVA: 0x01082500 File Offset: 0x01080700
		[NullableContext(1)]
		private RoverlikeLootStarItem CreateStarItem()
		{
			return new RoverlikeLootStarItem();
		}

		// Token: 0x0402411B RID: 147739
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoverlikeLootStarItem, bool> StarGrid;

		// Token: 0x0200C4A4 RID: 50340
		private class ERoverlikeLootStarLayout
		{
			// Token: 0x0403C86B RID: 247915
			public const int StarLayout = 0;

			// Token: 0x0403C86C RID: 247916
			public const int StarItem = 1;
		}
	}
}
