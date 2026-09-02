using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200602B RID: 24619
	public class GuardianHeadState : HeadStateViewBase
	{
		// Token: 0x0603E118 RID: 254232 RVA: 0x00FD7718 File Offset: 0x00FD5918
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E119 RID: 254233 RVA: 0x00FD77A2 File Offset: 0x00FD59A2
		[NullableContext(1)]
		protected override void ActiveBattleHeadState(HeadStateData headStateData)
		{
			base.ActiveBattleHeadState(headStateData);
			this.RefreshHp(false);
			this.RefreshHpColor();
		}

		// Token: 0x0603E11A RID: 254234 RVA: 0x00FD77B8 File Offset: 0x00FD59B8
		protected override void OnStart()
		{
			this.HpParentWidth = base.GetSprite(2).GetParentAsUIItem().GetWidth();
		}

		// Token: 0x0603E11B RID: 254235 RVA: 0x00FD77D1 File Offset: 0x00FD59D1
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_GuardianState_Prefab";
		}

		// Token: 0x0603E11C RID: 254236 RVA: 0x00FD77D8 File Offset: 0x00FD59D8
		protected override void OnHealthChanged()
		{
			this.RefreshHp(true);
		}

		// Token: 0x0603E11D RID: 254237 RVA: 0x00FD77E4 File Offset: 0x00FD59E4
		public void RefreshHp(bool bPlayBarAnimation = false)
		{
			ValueTuple<float, float> hpAndMaxHp = base.GetHpAndMaxHp();
			float item = hpAndMaxHp.Item1;
			float item2 = hpAndMaxHp.Item2;
			float num = item / item2;
			this.SetHpBarPercent(num);
			if (bPlayBarAnimation)
			{
				this.PlayBarAnimation(num);
				return;
			}
			this.StopBarLerpAnimation();
		}

		// Token: 0x0603E11E RID: 254238 RVA: 0x00FD7820 File Offset: 0x00FD5A20
		private void SetHpBarPercent(float percent)
		{
			base.GetSprite(0).SetFillAmount(percent);
		}

		// Token: 0x0603E11F RID: 254239 RVA: 0x00FD782F File Offset: 0x00FD5A2F
		protected override void OnBeginBarAnimation(float hpPercent)
		{
			this.SetBarBufferPercent(hpPercent);
		}

		// Token: 0x0603E120 RID: 254240 RVA: 0x00FD7838 File Offset: 0x00FD5A38
		protected override void StopBarLerpAnimation()
		{
			base.StopBarLerpAnimation();
			base.GetSprite(1).SetUIActive(false);
		}

		// Token: 0x0603E121 RID: 254241 RVA: 0x00FD784D File Offset: 0x00FD5A4D
		protected override void OnLerpBarBufferPercent(float percent)
		{
			this.SetBarBufferPercent(percent);
		}

		// Token: 0x0603E122 RID: 254242 RVA: 0x00FD7858 File Offset: 0x00FD5A58
		private void SetBarBufferPercent(float percent)
		{
			UUISprite sprite = base.GetSprite(1);
			sprite.SetFillAmount(percent);
			if (!sprite.IsUIActiveSelf())
			{
				sprite.SetUIActive(true);
			}
			UUISprite sprite2 = base.GetSprite(2);
			sprite2.SetStretchLeft(this.HpParentWidth * this.CurrentBarPercent - 2f);
			sprite2.SetStretchRight(this.HpParentWidth * (1f - percent) - 2f);
		}

		// Token: 0x0603E123 RID: 254243 RVA: 0x00FD78BC File Offset: 0x00FD5ABC
		private void RefreshHpColor()
		{
			string hpColor = base.GetHpColor();
			if (string.IsNullOrEmpty(hpColor))
			{
				return;
			}
			FColor color = FColor.FromHex(hpColor);
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetColor(color);
		}

		// Token: 0x0603E124 RID: 254244 RVA: 0x00FD78F2 File Offset: 0x00FD5AF2
		protected override void RefreshOnCampChanged()
		{
			this.RefreshHpColor();
		}

		// Token: 0x04022CAC RID: 142508
		private float HpParentWidth;

		// Token: 0x0200C0DF RID: 49375
		private enum EChildComponentType
		{
			// Token: 0x0403B63A RID: 243258
			HpBarSprite,
			// Token: 0x0403B63B RID: 243259
			BarBufferSprite,
			// Token: 0x0403B63C RID: 243260
			HpLight
		}
	}
}
