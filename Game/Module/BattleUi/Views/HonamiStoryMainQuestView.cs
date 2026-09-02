using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200603E RID: 24638
	public class HonamiStoryMainQuestView : HonamiStoryViewBase
	{
		// Token: 0x0603E25F RID: 254559 RVA: 0x00FDD2CC File Offset: 0x00FDB4CC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E260 RID: 254560 RVA: 0x00FDD420 File Offset: 0x00FDB620
		protected override void OnInitData()
		{
			this.HpTextType = 2;
			this.InTweenType = 7;
			this.OutTweenType = 8;
			this.DangerPercentConfigId = "HonamiStoryMainQuestDangerLifeSupportPercent";
			this.ShowFunctionType = new EFunctionType?(EFunctionType.HonamiStoryMainQuestLifeSupport);
			this.HideFunctionType = new EFunctionType?(EFunctionType.HonamiStoryLifeSupport);
		}

		// Token: 0x0603E261 RID: 254561 RVA: 0x00FDD46D File Offset: 0x00FDB66D
		protected override void OnStart()
		{
			base.OnStart();
			base.GetSlider(5).SetValue(this.DangerPercent, true);
			base.GetSlider(6).SetValue(this.DangerPercent, true);
		}

		// Token: 0x0603E262 RID: 254562 RVA: 0x00FDD49B File Offset: 0x00FDB69B
		protected override void OnRefreshAttribute(float percent, EHpStateType state)
		{
			base.GetSprite(0).SetFillAmount(percent);
			base.GetSprite(1).SetFillAmount(percent);
		}

		// Token: 0x0603E263 RID: 254563 RVA: 0x00FDD4B8 File Offset: 0x00FDB6B8
		protected override void OnRefreshState(EHpStateType state)
		{
			bool flag = state == EHpStateType.Normal;
			base.GetItem(3).SetUIActive(flag);
			base.GetItem(4).SetUIActive(!flag);
			FColor color = FColor.FromHex(flag ? "#E3F1F5" : "#E5426A");
			base.GetSprite(0).SetColor(color);
			base.GetSprite(1).SetColor(color);
		}

		// Token: 0x0200C100 RID: 49408
		private enum EComponentType
		{
			// Token: 0x0403B6E9 RID: 243433
			BarLeft,
			// Token: 0x0403B6EA RID: 243434
			BarRight,
			// Token: 0x0403B6EB RID: 243435
			HpText,
			// Token: 0x0403B6EC RID: 243436
			NormalItem,
			// Token: 0x0403B6ED RID: 243437
			DangerItem,
			// Token: 0x0403B6EE RID: 243438
			SliderLeft,
			// Token: 0x0403B6EF RID: 243439
			SliderRight,
			// Token: 0x0403B6F0 RID: 243440
			InTween,
			// Token: 0x0403B6F1 RID: 243441
			OutTween
		}
	}
}
