using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020014FD RID: 5373
public class SignItem : UiPanelBase
{
	// Token: 0x06009660 RID: 38496 RVA: 0x00275320 File Offset: 0x00273520
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009661 RID: 38497 RVA: 0x00275474 File Offset: 0x00273674
	public void RefreshSignItem(bool isHyper, bool haveRedDot)
	{
		base.GetItem(1).SetUIActive(!isHyper);
		base.GetItem(2).SetUIActive(!isHyper);
		base.GetItem(3).SetUIActive(!isHyper);
		base.GetItem(4).SetUIActive(isHyper);
		base.GetItem(5).SetUIActive(isHyper);
		base.GetItem(6).SetUIActive(isHyper);
		base.GetItem(7).SetUIActive(isHyper && haveRedDot);
	}

	// Token: 0x020078C1 RID: 30913
	private class ESignItem
	{
		// Token: 0x04029838 RID: 170040
		public const int Button = 0;

		// Token: 0x04029839 RID: 170041
		public const int NormalItem1 = 1;

		// Token: 0x0402983A RID: 170042
		public const int NormalItem2 = 2;

		// Token: 0x0402983B RID: 170043
		public const int NormalItem3 = 3;

		// Token: 0x0402983C RID: 170044
		public const int GoldenItem1 = 4;

		// Token: 0x0402983D RID: 170045
		public const int GoldenItem2 = 5;

		// Token: 0x0402983E RID: 170046
		public const int GoldenItem3 = 6;

		// Token: 0x0402983F RID: 170047
		public const int GoldenItem4 = 7;

		// Token: 0x04029840 RID: 170048
		public const int ItemTexture = 8;

		// Token: 0x04029841 RID: 170049
		public const int ItemText = 9;

		// Token: 0x04029842 RID: 170050
		public const int RedDotItem = 10;
	}
}
