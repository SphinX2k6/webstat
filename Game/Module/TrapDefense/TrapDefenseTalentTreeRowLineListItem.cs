using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E55 RID: 20053
	public class TrapDefenseTalentTreeRowLineListItem : UiPanelBase
	{
		// Token: 0x06033D1C RID: 212252 RVA: 0x00CF501C File Offset: 0x00CF321C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 22;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
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
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033D1D RID: 212253 RVA: 0x00CF5328 File Offset: 0x00CF3528
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<UUIItem, UUIItem>? GetDotByIndex(int index)
		{
			if (index < 0 || index >= 6)
			{
				return null;
			}
			UUIItem item = base.GetItem(index);
			return new ValueTuple<UUIItem, UUIItem>?(new ValueTuple<UUIItem, UUIItem>(base.GetItem(6 + index), item));
		}

		// Token: 0x06033D1E RID: 212254 RVA: 0x00CF5364 File Offset: 0x00CF3564
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<UUIItem, UUIItem>? GetLinesByIndexInLineId(int index)
		{
			int num = index - 18;
			if (num < 0 || num >= 5)
			{
				return null;
			}
			UUIItem item = base.GetItem(12 + num);
			return new ValueTuple<UUIItem, UUIItem>?(new ValueTuple<UUIItem, UUIItem>(base.GetItem(17 + num), item));
		}

		// Token: 0x06033D1F RID: 212255 RVA: 0x00CF53A8 File Offset: 0x00CF35A8
		[NullableContext(1)]
		public List<UUIItem> GetAllLines()
		{
			List<UUIItem> list = new List<UUIItem>();
			for (int i = 0; i < 5; i++)
			{
				UUIItem item = base.GetItem(12 + i);
				UUIItem item2 = base.GetItem(17 + i);
				list.Add(item);
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x06033D20 RID: 212256 RVA: 0x00CF53EC File Offset: 0x00CF35EC
		[NullableContext(1)]
		public List<UUIItem> GetAllDots()
		{
			List<UUIItem> list = new List<UUIItem>();
			for (int i = 0; i < 6; i++)
			{
				ValueTuple<UUIItem, UUIItem> value = this.GetDotByIndex(i).Value;
				list.Add(value.Item1);
				list.Add(value.Item2);
			}
			return list;
		}

		// Token: 0x06033D21 RID: 212257 RVA: 0x00CF5434 File Offset: 0x00CF3634
		[return: Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public List<ValueTuple<UUIItem, UUIItem>> GetDotsByIndexInLineId(int index)
		{
			List<ValueTuple<UUIItem, UUIItem>> list = new List<ValueTuple<UUIItem, UUIItem>>();
			int num = TrapDefenseDefine.LineIndex2NodeIndex(index);
			if (num == index)
			{
				return list;
			}
			list.Add(this.GetDotByIndex(num).Value);
			if (index >= 18)
			{
				list.Add(this.GetDotByIndex(num + 1).Value);
			}
			return list;
		}

		// Token: 0x0200ADF3 RID: 44531
		private class EComponentDefine
		{
			// Token: 0x04036047 RID: 221255
			public const int ItemDotLock1 = 0;

			// Token: 0x04036048 RID: 221256
			public const int ItemDotLock2 = 1;

			// Token: 0x04036049 RID: 221257
			public const int ItemDotLock3 = 2;

			// Token: 0x0403604A RID: 221258
			public const int ItemDotLock4 = 3;

			// Token: 0x0403604B RID: 221259
			public const int ItemDotLock5 = 4;

			// Token: 0x0403604C RID: 221260
			public const int ItemDotLock6 = 5;

			// Token: 0x0403604D RID: 221261
			public const int ItemDotUnlock1 = 6;

			// Token: 0x0403604E RID: 221262
			public const int ItemDotUnlock2 = 7;

			// Token: 0x0403604F RID: 221263
			public const int ItemDotUnlock3 = 8;

			// Token: 0x04036050 RID: 221264
			public const int ItemDotUnlock4 = 9;

			// Token: 0x04036051 RID: 221265
			public const int ItemDotUnlock5 = 10;

			// Token: 0x04036052 RID: 221266
			public const int ItemDotUnlock6 = 11;

			// Token: 0x04036053 RID: 221267
			public const int ItemDashedLine1 = 12;

			// Token: 0x04036054 RID: 221268
			public const int ItemDashedLine2 = 13;

			// Token: 0x04036055 RID: 221269
			public const int ItemDashedLine3 = 14;

			// Token: 0x04036056 RID: 221270
			public const int ItemDashedLine4 = 15;

			// Token: 0x04036057 RID: 221271
			public const int ItemDashedLine5 = 16;

			// Token: 0x04036058 RID: 221272
			public const int ItemSolidLine1 = 17;

			// Token: 0x04036059 RID: 221273
			public const int ItemSolidLine2 = 18;

			// Token: 0x0403605A RID: 221274
			public const int ItemSolidLine3 = 19;

			// Token: 0x0403605B RID: 221275
			public const int ItemSolidLine4 = 20;

			// Token: 0x0403605C RID: 221276
			public const int ItemSolidLine5 = 21;
		}
	}
}
