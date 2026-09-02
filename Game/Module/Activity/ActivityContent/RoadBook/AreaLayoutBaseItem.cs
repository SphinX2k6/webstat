using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064B6 RID: 25782
	[NullableContext(1)]
	[Nullable(0)]
	public class AreaLayoutBaseItem : UiPanelBase, IDynamicScrollBaseItem<AreaLayoutItemData>
	{
		// Token: 0x060409D7 RID: 264663 RVA: 0x01090460 File Offset: 0x0108E660
		public UniTask Init(UUIItem actor)
		{
			AreaLayoutBaseItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<AreaLayoutBaseItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x060409D8 RID: 264664 RVA: 0x010904AC File Offset: 0x0108E6AC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout))
			};
		}

		// Token: 0x060409D9 RID: 264665 RVA: 0x01090534 File Offset: 0x0108E734
		public FVector2D GetItemSize(AreaLayoutItemData itemData)
		{
			float width = this.RootItem.Width;
			if (itemData.IsTitle)
			{
				this.VectorValue.Set((double)width, (double)base.GetVerticalLayout(4).RootUIComp.Get().Height);
				if (!itemData.AreaData.IsUnlock)
				{
					this.VectorValue.Y += (double)(base.GetItem(3).GetHeight() + base.GetVerticalLayout(4).GetSpacing());
				}
			}
			else
			{
				this.VectorValue.Set((double)width, (double)base.GetItem(1).GetHeight());
			}
			this.VectorValue.Y += (double)itemData.ExtraHeight.GetValueOrDefault();
			return this.VectorValue.ToUeVector2D(false);
		}

		// Token: 0x060409DA RID: 264666 RVA: 0x010905FB File Offset: 0x0108E7FB
		public void ClearItem()
		{
		}

		// Token: 0x040242F5 RID: 148213
		private Vector2D VectorValue;
	}
}
