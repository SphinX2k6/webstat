using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.View.Components;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A7F RID: 23167
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class GridItem : SyncGridProxyAbstract<GridItemCellData>
	{
		// Token: 0x0603A9F5 RID: 240117 RVA: 0x00ED9C34 File Offset: 0x00ED7E34
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603A9F6 RID: 240118 RVA: 0x00ED9C9D File Offset: 0x00ED7E9D
		protected override void OnStart()
		{
			this.GridItemInner.CreateThenShowByActor(base.GetItem(1).GetOwner());
		}

		// Token: 0x0603A9F7 RID: 240119 RVA: 0x00ED9CB8 File Offset: 0x00ED7EB8
		public override void Refresh(GridItemCellData data)
		{
			this.Data = data;
			this.OnClick = data.OnClick;
			if (data.Item.Type == EKurotatoCardType.None)
			{
				base.GetSprite(0).SetUIActive(true);
				base.GetItem(1).SetUIActive(false);
				return;
			}
			base.GetSprite(0).SetUIActive(false);
			base.GetItem(1).SetUIActive(true);
			this.GridItemInner.Refresh(data.Item);
			this.GridItemInner.BindCallback(delegate(IKurotatoSmallItemGridData d, EToggleState state, int gridIndex)
			{
				this.GridItemInner.SetSelected(false, false);
				Action onClick = this.OnClick;
				if (onClick == null)
				{
					return;
				}
				onClick();
			});
		}

		// Token: 0x04021295 RID: 135829
		public GridItemCellData Data;

		// Token: 0x04021296 RID: 135830
		private readonly KurotatoWeaponSmallItemGrid GridItemInner = new KurotatoWeaponSmallItemGrid(false);

		// Token: 0x04021297 RID: 135831
		[Nullable(2)]
		private Action OnClick;

		// Token: 0x0200BA54 RID: 47700
		[NullableContext(0)]
		private class EGridComp
		{
			// Token: 0x0403988E RID: 235662
			public const int SpriteEmpty = 0;

			// Token: 0x0403988F RID: 235663
			public const int GridItem = 1;
		}
	}
}
