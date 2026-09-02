using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006030 RID: 24624
	public class MingSuTiHeadState : HeadStateViewBase
	{
		// Token: 0x0603E1B3 RID: 254387 RVA: 0x00FD9B64 File Offset: 0x00FD7D64
		protected unsafe override void OnRegisterComponent()
		{
			int num = 21;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E1B4 RID: 254388 RVA: 0x00FD9E4D File Offset: 0x00FD804D
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_MingsutiState_Prefab";
		}

		// Token: 0x0603E1B5 RID: 254389 RVA: 0x00FD9E54 File Offset: 0x00FD8054
		protected unsafe override void OnStart()
		{
			int num = 20;
			List<UUISprite> list = new List<UUISprite>(num);
			CollectionsMarshal.SetCount<UUISprite>(list, num);
			Span<UUISprite> span = CollectionsMarshal.AsSpan<UUISprite>(list);
			int num2 = 0;
			*span[num2] = base.GetSprite(1);
			num2++;
			*span[num2] = base.GetSprite(2);
			num2++;
			*span[num2] = base.GetSprite(3);
			num2++;
			*span[num2] = base.GetSprite(4);
			num2++;
			*span[num2] = base.GetSprite(5);
			num2++;
			*span[num2] = base.GetSprite(6);
			num2++;
			*span[num2] = base.GetSprite(7);
			num2++;
			*span[num2] = base.GetSprite(8);
			num2++;
			*span[num2] = base.GetSprite(9);
			num2++;
			*span[num2] = base.GetSprite(10);
			num2++;
			*span[num2] = base.GetSprite(11);
			num2++;
			*span[num2] = base.GetSprite(12);
			num2++;
			*span[num2] = base.GetSprite(13);
			num2++;
			*span[num2] = base.GetSprite(14);
			num2++;
			*span[num2] = base.GetSprite(15);
			num2++;
			*span[num2] = base.GetSprite(16);
			num2++;
			*span[num2] = base.GetSprite(17);
			num2++;
			*span[num2] = base.GetSprite(18);
			num2++;
			*span[num2] = base.GetSprite(19);
			num2++;
			*span[num2] = base.GetSprite(20);
			this.HpStateSpriteList = list;
		}

		// Token: 0x0603E1B6 RID: 254390 RVA: 0x00FDA018 File Offset: 0x00FD8218
		[NullableContext(1)]
		protected override void ActiveBattleHeadState(HeadStateData headStateData)
		{
			base.ActiveBattleHeadState(headStateData);
			this.RefreshHp();
			this.RefreshHpColor();
			this.InitHp();
		}

		// Token: 0x0603E1B7 RID: 254391 RVA: 0x00FDA033 File Offset: 0x00FD8233
		protected override void OnHealthChanged()
		{
			this.RefreshHp();
		}

		// Token: 0x0603E1B8 RID: 254392 RVA: 0x00FDA03B File Offset: 0x00FD823B
		[NullableContext(2)]
		private UUISprite GetHpStateSprite(int index)
		{
			return this.HpStateSpriteList.GetValueOrDefault(index);
		}

		// Token: 0x0603E1B9 RID: 254393 RVA: 0x00FDA04C File Offset: 0x00FD824C
		private void RefreshHp()
		{
			ValueTuple<float, float> hpAndMaxHp = base.GetHpAndMaxHp();
			float item = hpAndMaxHp.Item1;
			float item2 = hpAndMaxHp.Item2;
			if (this.CurrentHp == item)
			{
				return;
			}
			this.CurrentHp = item;
			int num = 0;
			while ((double)num < Math.Floor((double)item2))
			{
				UUISprite hpStateSprite = this.GetHpStateSprite(num);
				if (hpStateSprite != null && (float)num < item != hpStateSprite.bIsUIActive)
				{
					hpStateSprite.SetUIActive((float)num < item);
				}
				num++;
			}
		}

		// Token: 0x0603E1BA RID: 254394 RVA: 0x00FDA0B4 File Offset: 0x00FD82B4
		private void InitHp()
		{
			for (int i = (int)this.GetMaxHp(); i < this.HpStateSpriteList.Count; i++)
			{
				UUISprite hpStateSprite = this.GetHpStateSprite(i);
				if (hpStateSprite != null)
				{
					hpStateSprite.GetParentAsUIItem().SetUIActive(false);
				}
			}
		}

		// Token: 0x0603E1BB RID: 254395 RVA: 0x00FDA0F4 File Offset: 0x00FD82F4
		private void RefreshHpColor()
		{
			string hpColor = base.GetHpColor();
			if (string.IsNullOrEmpty(hpColor))
			{
				return;
			}
			FColor color = FColor.FromHex(hpColor);
			foreach (UUISprite uuisprite in this.HpStateSpriteList)
			{
				uuisprite.SetColor(color);
			}
		}

		// Token: 0x0603E1BC RID: 254396 RVA: 0x00FDA15C File Offset: 0x00FD835C
		protected override void RefreshOnCampChanged()
		{
			this.RefreshHpColor();
		}

		// Token: 0x04022D19 RID: 142617
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<UUISprite> HpStateSpriteList;

		// Token: 0x04022D1A RID: 142618
		private float CurrentHp;

		// Token: 0x0200C0E5 RID: 49381
		private enum EChildType
		{
			// Token: 0x0403B65E RID: 243294
			HpHorizontalBox,
			// Token: 0x0403B65F RID: 243295
			HpSprite1,
			// Token: 0x0403B660 RID: 243296
			HpSprite2,
			// Token: 0x0403B661 RID: 243297
			HpSprite3,
			// Token: 0x0403B662 RID: 243298
			HpSprite4,
			// Token: 0x0403B663 RID: 243299
			HpSprite5,
			// Token: 0x0403B664 RID: 243300
			HpSprite6,
			// Token: 0x0403B665 RID: 243301
			HpSprite7,
			// Token: 0x0403B666 RID: 243302
			HpSprite8,
			// Token: 0x0403B667 RID: 243303
			HpSprite9,
			// Token: 0x0403B668 RID: 243304
			HpSprite10,
			// Token: 0x0403B669 RID: 243305
			HpSprite11,
			// Token: 0x0403B66A RID: 243306
			HpSprite12,
			// Token: 0x0403B66B RID: 243307
			HpSprite13,
			// Token: 0x0403B66C RID: 243308
			HpSprite14,
			// Token: 0x0403B66D RID: 243309
			HpSprite15,
			// Token: 0x0403B66E RID: 243310
			HpSprite16,
			// Token: 0x0403B66F RID: 243311
			HpSprite17,
			// Token: 0x0403B670 RID: 243312
			HpSprite18,
			// Token: 0x0403B671 RID: 243313
			HpSprite19,
			// Token: 0x0403B672 RID: 243314
			HpSprite20
		}
	}
}
