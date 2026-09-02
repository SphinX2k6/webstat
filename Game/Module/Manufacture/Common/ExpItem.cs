using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059F4 RID: 23028
	public class ExpItem : UiPanelBase
	{
		// Token: 0x0603A580 RID: 238976 RVA: 0x00ECB272 File Offset: 0x00EC9472
		[NullableContext(1)]
		public ExpItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603A581 RID: 238977 RVA: 0x00ECB288 File Offset: 0x00EC9488
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603A582 RID: 238978 RVA: 0x00ECB334 File Offset: 0x00EC9534
		public void SetExpSprite(int last, int sum)
		{
			double num = Singleton<MathUtils>.Instance.GetFloatPointFloor((double)last / (double)sum, 3);
			num = ((num > 1.0) ? 1.0 : num);
			base.GetSprite(0).SetFillAmount((float)num);
		}

		// Token: 0x0603A583 RID: 238979 RVA: 0x00ECB379 File Offset: 0x00EC9579
		public void SetAddText(int add)
		{
			base.GetText(1).SetText(add.ToString(), true);
		}

		// Token: 0x0603A584 RID: 238980 RVA: 0x00ECB38F File Offset: 0x00EC958F
		public void SetLastText(int last)
		{
			base.GetText(2).SetText(last.ToString(), true);
		}

		// Token: 0x0603A585 RID: 238981 RVA: 0x00ECB3A5 File Offset: 0x00EC95A5
		public void SetSumText(int sum)
		{
			base.GetText(3).SetText(sum.ToString(), true);
		}

		// Token: 0x0200B9C4 RID: 47556
		private class EExpItemDefine
		{
			// Token: 0x0403966E RID: 235118
			public const int ExpSprite = 0;

			// Token: 0x0403966F RID: 235119
			public const int AddText = 1;

			// Token: 0x04039670 RID: 235120
			public const int LastText = 2;

			// Token: 0x04039671 RID: 235121
			public const int SumText = 3;
		}
	}
}
