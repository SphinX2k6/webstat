using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E43 RID: 20035
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMonsterWaveDynamicItem : UiPanelBase, IDynamicScrollBaseItem<TrapDefenseMonsterWaveData>
	{
		// Token: 0x06033C96 RID: 212118 RVA: 0x00CF1C80 File Offset: 0x00CEFE80
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033C97 RID: 212119 RVA: 0x00CF1E5C File Offset: 0x00CF005C
		public FVector2D GetItemSize(TrapDefenseMonsterWaveData data)
		{
			if (this.VectorValue == null)
			{
				this.VectorValue = Vector2D.Create();
			}
			this.CalcValue();
			double num = Math.Ceiling((double)((float)data.GetMonsterDataList().Count / (float)this.ColCount));
			float num2 = data.IsEndlessStart ? this.EndlessTotalHeight : 0f;
			double inY = (double)(this.ItemRootHeight + num2) + (num - 1.0) * (double)this.CellHeight;
			this.VectorValue.Set((double)this.ItemRootWidth, inY);
			return this.VectorValue.ToUeVector2D(false);
		}

		// Token: 0x06033C98 RID: 212120 RVA: 0x00CF1EF0 File Offset: 0x00CF00F0
		private void CalcValue()
		{
			if (this.ItemRootWidth > 0f)
			{
				return;
			}
			UUIItem item = base.GetItem(10);
			UUIGridLayout gridLayout = base.GetGridLayout(7);
			UUIItem item2 = base.GetItem(9);
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(12);
			this.ItemRootWidth = this.RootItem.GetWidth() - 10f;
			this.ItemRootHeight = item.GetHeight();
			this.EndlessTotalHeight = verticalLayout.Padding.Top + verticalLayout.Padding.Bottom + item2.GetHeight();
			FVector2D cellSize = gridLayout.CellSize;
			FMargin padding = gridLayout.Padding;
			FVector2D spacing = gridLayout.Spacing;
			this.CellHeight = cellSize.Y + spacing.Y;
			this.ColCount = (int)Math.Floor((double)((this.ItemRootWidth - padding.Left - padding.Right + spacing.X) / this.CellHeight));
		}

		// Token: 0x06033C99 RID: 212121 RVA: 0x00CF1FD0 File Offset: 0x00CF01D0
		public UniTask Init(UUIItem actor)
		{
			TrapDefenseMonsterWaveDynamicItem.<Init>d__9 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseMonsterWaveDynamicItem.<Init>d__9>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033C9A RID: 212122 RVA: 0x00CF201B File Offset: 0x00CF021B
		public void ClearItem()
		{
		}

		// Token: 0x0401DF77 RID: 122743
		private Vector2D VectorValue;

		// Token: 0x0401DF78 RID: 122744
		private float ItemRootWidth;

		// Token: 0x0401DF79 RID: 122745
		private float ItemRootHeight;

		// Token: 0x0401DF7A RID: 122746
		private float EndlessTotalHeight;

		// Token: 0x0401DF7B RID: 122747
		private int ColCount;

		// Token: 0x0401DF7C RID: 122748
		private float CellHeight;
	}
}
