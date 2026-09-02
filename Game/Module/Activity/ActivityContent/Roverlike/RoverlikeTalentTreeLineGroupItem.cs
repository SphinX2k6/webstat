using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006469 RID: 25705
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeTalentTreeLineGroupItem : UiPanelBase
	{
		// Token: 0x060407A8 RID: 264104 RVA: 0x01085E3C File Offset: 0x0108403C
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

		// Token: 0x060407A9 RID: 264105 RVA: 0x01086148 File Offset: 0x01084348
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

		// Token: 0x060407AA RID: 264106 RVA: 0x010861EC File Offset: 0x010843EC
		public UUIItem GetLockDotByIndex(int nodeIndex)
		{
			if (nodeIndex < 0 || nodeIndex >= 6)
			{
				return null;
			}
			return base.GetItem(nodeIndex);
		}

		// Token: 0x060407AB RID: 264107 RVA: 0x010861FF File Offset: 0x010843FF
		public UUIItem GetUnlockDotByIndex(int nodeIndex)
		{
			if (nodeIndex < 0 || nodeIndex >= 6)
			{
				return null;
			}
			return base.GetItem(6 + nodeIndex);
		}

		// Token: 0x060407AC RID: 264108 RVA: 0x01086214 File Offset: 0x01084414
		public UUIItem GetSolidLineByIndexInLineId(int index)
		{
			int num = index - 18;
			if (num < 0 || num >= 5)
			{
				return null;
			}
			return base.GetItem(17 + num);
		}

		// Token: 0x060407AD RID: 264109 RVA: 0x0108623C File Offset: 0x0108443C
		public UUIItem GetDashedLineByIndexInLineId(int index)
		{
			int num = index - 18;
			if (num < 0 || num >= 5)
			{
				return null;
			}
			return base.GetItem(12 + num);
		}

		// Token: 0x060407AE RID: 264110 RVA: 0x01086264 File Offset: 0x01084464
		[NullableContext(1)]
		public List<UUIItem> GetAllLines()
		{
			List<UUIItem> list = new List<UUIItem>();
			for (int i = 0; i < 5; i++)
			{
				list.Add(base.GetItem(17 + i));
				list.Add(base.GetItem(12 + i));
			}
			return list;
		}

		// Token: 0x060407AF RID: 264111 RVA: 0x010862A4 File Offset: 0x010844A4
		[NullableContext(1)]
		public List<UUIItem> GetAllDots()
		{
			List<UUIItem> list = new List<UUIItem>();
			for (int i = 0; i < 6; i++)
			{
				list.Add(base.GetItem(i));
				list.Add(base.GetItem(6 + i));
			}
			return list;
		}

		// Token: 0x060407B0 RID: 264112 RVA: 0x010862E0 File Offset: 0x010844E0
		[NullableContext(1)]
		public List<int> GetDotNodeIndicesByLineId(int index)
		{
			List<int> list = new List<int>();
			int num = RoverlikeTalentTreeDefine.RoverlikeLineIndex2NodeIndex(index);
			if (num == index)
			{
				return list;
			}
			list.Add(num);
			if (index >= 18)
			{
				list.Add(num + 1);
			}
			return list;
		}

		// Token: 0x0200C4C0 RID: 50368
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403C8FB RID: 248059
			public const int ItemDotLock1 = 0;

			// Token: 0x0403C8FC RID: 248060
			public const int ItemDotLock2 = 1;

			// Token: 0x0403C8FD RID: 248061
			public const int ItemDotLock3 = 2;

			// Token: 0x0403C8FE RID: 248062
			public const int ItemDotLock4 = 3;

			// Token: 0x0403C8FF RID: 248063
			public const int ItemDotLock5 = 4;

			// Token: 0x0403C900 RID: 248064
			public const int ItemDotLock6 = 5;

			// Token: 0x0403C901 RID: 248065
			public const int ItemDotUnlock1 = 6;

			// Token: 0x0403C902 RID: 248066
			public const int ItemDotUnlock2 = 7;

			// Token: 0x0403C903 RID: 248067
			public const int ItemDotUnlock3 = 8;

			// Token: 0x0403C904 RID: 248068
			public const int ItemDotUnlock4 = 9;

			// Token: 0x0403C905 RID: 248069
			public const int ItemDotUnlock5 = 10;

			// Token: 0x0403C906 RID: 248070
			public const int ItemDotUnlock6 = 11;

			// Token: 0x0403C907 RID: 248071
			public const int ItemDashedLine1 = 12;

			// Token: 0x0403C908 RID: 248072
			public const int ItemDashedLine2 = 13;

			// Token: 0x0403C909 RID: 248073
			public const int ItemDashedLine3 = 14;

			// Token: 0x0403C90A RID: 248074
			public const int ItemDashedLine4 = 15;

			// Token: 0x0403C90B RID: 248075
			public const int ItemDashedLine5 = 16;

			// Token: 0x0403C90C RID: 248076
			public const int ItemSolidLine1 = 17;

			// Token: 0x0403C90D RID: 248077
			public const int ItemSolidLine2 = 18;

			// Token: 0x0403C90E RID: 248078
			public const int ItemSolidLine3 = 19;

			// Token: 0x0403C90F RID: 248079
			public const int ItemSolidLine4 = 20;

			// Token: 0x0403C910 RID: 248080
			public const int ItemSolidLine5 = 21;
		}
	}
}
