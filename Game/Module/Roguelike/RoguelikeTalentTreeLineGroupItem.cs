using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051BB RID: 20923
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeTalentTreeLineGroupItem : UiPanelBase
	{
		// Token: 0x06035CAF RID: 220335 RVA: 0x00D87A44 File Offset: 0x00D85C44
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

		// Token: 0x06035CB0 RID: 220336 RVA: 0x00D87D50 File Offset: 0x00D85F50
		protected override void OnStart()
		{
			base.GetItem(12).SetUIActive(false);
			base.GetItem(13).SetUIActive(false);
			base.GetItem(14).SetUIActive(false);
			base.GetItem(15).SetUIActive(false);
			base.GetItem(16).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(8).SetUIActive(false);
			base.GetItem(9).SetUIActive(false);
			base.GetItem(10).SetUIActive(false);
			base.GetItem(11).SetUIActive(false);
		}

		// Token: 0x06035CB1 RID: 220337 RVA: 0x00D87DF4 File Offset: 0x00D85FF4
		[NullableContext(2)]
		public UUIItem GetDotByIndex(int index)
		{
			if (index < 0 || index >= 6)
			{
				return null;
			}
			return base.GetItem(index);
		}

		// Token: 0x06035CB2 RID: 220338 RVA: 0x00D87E08 File Offset: 0x00D86008
		[NullableContext(2)]
		public UUIItem GetLinesByIndexInLineId(int index)
		{
			int num = index - 18;
			if (num < 0 || num >= 5)
			{
				return null;
			}
			return base.GetItem(17 + num);
		}

		// Token: 0x06035CB3 RID: 220339 RVA: 0x00D87E30 File Offset: 0x00D86030
		public List<UUIItem> GetAllLines()
		{
			List<UUIItem> list = new List<UUIItem>();
			for (int i = 0; i < 5; i++)
			{
				UUIItem item = base.GetItem(17 + i);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06035CB4 RID: 220340 RVA: 0x00D87E64 File Offset: 0x00D86064
		public List<UUIItem> GetAllDots()
		{
			List<UUIItem> list = new List<UUIItem>();
			for (int i = 0; i < 6; i++)
			{
				UUIItem dotByIndex = this.GetDotByIndex(i);
				list.Add(dotByIndex);
			}
			return list;
		}

		// Token: 0x06035CB5 RID: 220341 RVA: 0x00D87E94 File Offset: 0x00D86094
		public List<UUIItem> GetDotsByIndexInLineId(int index)
		{
			List<UUIItem> list = new List<UUIItem>();
			int num = RogueTalentTreeDefine.rogueLineIndex2NodeIndex(index);
			if (num == index)
			{
				return list;
			}
			list.Add(this.GetDotByIndex(num));
			if (index >= 18)
			{
				list.Add(this.GetDotByIndex(num + 1));
			}
			return list;
		}

		// Token: 0x0200B19F RID: 45471
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04037150 RID: 225616
			public const int ItemDotLock1 = 0;

			// Token: 0x04037151 RID: 225617
			public const int ItemDotLock2 = 1;

			// Token: 0x04037152 RID: 225618
			public const int ItemDotLock3 = 2;

			// Token: 0x04037153 RID: 225619
			public const int ItemDotLock4 = 3;

			// Token: 0x04037154 RID: 225620
			public const int ItemDotLock5 = 4;

			// Token: 0x04037155 RID: 225621
			public const int ItemDotLock6 = 5;

			// Token: 0x04037156 RID: 225622
			public const int ItemDotUnlock1 = 6;

			// Token: 0x04037157 RID: 225623
			public const int ItemDotUnlock2 = 7;

			// Token: 0x04037158 RID: 225624
			public const int ItemDotUnlock3 = 8;

			// Token: 0x04037159 RID: 225625
			public const int ItemDotUnlock4 = 9;

			// Token: 0x0403715A RID: 225626
			public const int ItemDotUnlock5 = 10;

			// Token: 0x0403715B RID: 225627
			public const int ItemDotUnlock6 = 11;

			// Token: 0x0403715C RID: 225628
			public const int ItemDashedLine1 = 12;

			// Token: 0x0403715D RID: 225629
			public const int ItemDashedLine2 = 13;

			// Token: 0x0403715E RID: 225630
			public const int ItemDashedLine3 = 14;

			// Token: 0x0403715F RID: 225631
			public const int ItemDashedLine4 = 15;

			// Token: 0x04037160 RID: 225632
			public const int ItemDashedLine5 = 16;

			// Token: 0x04037161 RID: 225633
			public const int ItemSolidLine1 = 17;

			// Token: 0x04037162 RID: 225634
			public const int ItemSolidLine2 = 18;

			// Token: 0x04037163 RID: 225635
			public const int ItemSolidLine3 = 19;

			// Token: 0x04037164 RID: 225636
			public const int ItemSolidLine4 = 20;

			// Token: 0x04037165 RID: 225637
			public const int ItemSolidLine5 = 21;
		}
	}
}
