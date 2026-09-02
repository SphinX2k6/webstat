using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006040 RID: 24640
	public class HonamiStoryView : HonamiStoryViewBase
	{
		// Token: 0x0603E26E RID: 254574 RVA: 0x00FDD868 File Offset: 0x00FDBA68
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E26F RID: 254575 RVA: 0x00FDD9B9 File Offset: 0x00FDBBB9
		protected override void OnInitData()
		{
			this.HpTextType = 4;
			this.InTweenType = 7;
			this.OutTweenType = 8;
			this.DangerPercentConfigId = "HonamiStoryDangerLifeSupportPercent";
			this.ShowFunctionType = new EFunctionType?(EFunctionType.HonamiStoryLifeSupport);
		}

		// Token: 0x0603E270 RID: 254576 RVA: 0x00FDD9EC File Offset: 0x00FDBBEC
		protected override void OnRefreshAttribute(float percent, EHpStateType state)
		{
			if (state == EHpStateType.Normal)
			{
				float fillAmount = (percent - this.DangerPercent) / this.NormalPercent;
				base.GetSprite(1).SetFillAmount(fillAmount);
				base.GetSprite(3).SetFillAmount(fillAmount);
				return;
			}
			float fillAmount2 = percent / this.DangerPercent;
			base.GetSprite(0).SetFillAmount(fillAmount2);
			base.GetSprite(2).SetFillAmount(fillAmount2);
		}

		// Token: 0x0603E271 RID: 254577 RVA: 0x00FDDA4C File Offset: 0x00FDBC4C
		protected override void OnRefreshState(EHpStateType state)
		{
			bool flag = state == EHpStateType.Normal;
			base.GetItem(5).SetUIActive(flag);
			base.GetItem(6).SetUIActive(!flag);
			if (flag)
			{
				UUISprite sprite = base.GetSprite(0);
				UUISprite sprite2 = base.GetSprite(2);
				sprite.SetFillAmount(1f);
				sprite2.SetFillAmount(1f);
				FColor color = FColor.FromHex("#E3F1F5");
				sprite.SetColor(color);
				sprite2.SetColor(color);
				return;
			}
			base.GetSprite(1).SetFillAmount(0f);
			base.GetSprite(3).SetFillAmount(0f);
			FColor color2 = FColor.FromHex("#E5426A");
			base.GetSprite(0).SetColor(color2);
			base.GetSprite(2).SetColor(color2);
		}

		// Token: 0x0200C103 RID: 49411
		private enum EComponentType
		{
			// Token: 0x0403B6FC RID: 243452
			DangerBarLeft,
			// Token: 0x0403B6FD RID: 243453
			NormalBarLeft,
			// Token: 0x0403B6FE RID: 243454
			DangerBarRight,
			// Token: 0x0403B6FF RID: 243455
			NormalBarRight,
			// Token: 0x0403B700 RID: 243456
			HpText,
			// Token: 0x0403B701 RID: 243457
			NormalItem,
			// Token: 0x0403B702 RID: 243458
			DangerItem,
			// Token: 0x0403B703 RID: 243459
			InTween,
			// Token: 0x0403B704 RID: 243460
			OutTween
		}
	}
}
