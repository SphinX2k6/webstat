using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FirstPersonTurret.View
{
	// Token: 0x02005D85 RID: 23941
	[NullableContext(1)]
	[Nullable(0)]
	public class FirstPersonTurretRoleHpItem : UiPanelBase
	{
		// Token: 0x0603C473 RID: 246899 RVA: 0x00F4B544 File Offset: 0x00F49744
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C474 RID: 246900 RVA: 0x00F4B6FC File Offset: 0x00F498FC
		protected override void OnStart()
		{
			this.HpBarSprite = base.GetSprite(0);
			this.LowHpBarSprite = base.GetSprite(3);
			this.HpBufferSprite = base.GetSprite(4);
			this.ShieldBarSprite = base.GetSprite(5);
			this.HpText = base.GetText(1);
			this.HpText2 = base.GetText(7);
			this.HpTextMask = (base.GetItem(8).GetOwner().GetComponentByClass(ULGUICanvas.StaticClass()) as ULGUICanvas);
			this.HpTextWidth = this.HpText.GetWidth();
			this.HpBufferAnimDuration = (float)ConfigCommonParamById.GetIntConfig("PlayerHPAttenuateBufferSpeed").GetValueOrDefault();
			UUINiagara uiNiagara = base.GetUiNiagara(6);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(false);
			}
			UUISprite sprite = base.GetSprite(10);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUIItem item = base.GetItem(11);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			this.InitHpBar();
		}

		// Token: 0x0603C475 RID: 246901 RVA: 0x00F4B7FB File Offset: 0x00F499FB
		public void Refresh(float hp, float hpMax)
		{
			this.RefreshHpAndShield(hp, hpMax);
		}

		// Token: 0x0603C476 RID: 246902 RVA: 0x00F4B805 File Offset: 0x00F49A05
		public void Tick(float delta)
		{
			this.LerpBarPercent(delta);
		}

		// Token: 0x0603C477 RID: 246903 RVA: 0x00F4B80E File Offset: 0x00F49A0E
		private void InitHpBar()
		{
			this.LowHpBarSprite.SetUIActive(false);
			this.HpBarSprite.SetUIActive(true);
			this.HpBufferSprite.SetUIActive(false);
			this.ShieldBarSprite.SetUIActive(false);
		}

		// Token: 0x0603C478 RID: 246904 RVA: 0x00F4B840 File Offset: 0x00F49A40
		private void RefreshHpAndShield(float hp, float hpMax)
		{
			if (hpMax <= 0f)
			{
				return;
			}
			this.CurHp = hp;
			this.CurHpMax = hpMax;
			float num = hp / hpMax;
			this.UeMargin.Right = -(1f - num) * this.HpTextWidth;
			this.HpTextMask.SetRectClipOffset(this.UeMargin);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>((int)Math.Ceiling((double)hp));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>((int)Math.Ceiling((double)hpMax));
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			this.HpText.SetText(newText, true);
			this.HpText2.SetText(newText, true);
			this.SetHpBarPercent(num);
			this.PlayBarAnimation();
			this.CurrentBarPercent = num;
		}

		// Token: 0x0603C479 RID: 246905 RVA: 0x00F4B8FC File Offset: 0x00F49AFC
		private void SetHpBarPercent(float percent)
		{
			if (percent <= 0.2f)
			{
				this.LowHpBarSprite.SetUIActive(true);
				this.HpBarSprite.SetUIActive(false);
				this.LowHpBarSprite.SetFillAmount(percent);
				return;
			}
			this.LowHpBarSprite.SetUIActive(false);
			this.HpBarSprite.SetUIActive(true);
			this.HpBarSprite.SetFillAmount(percent);
		}

		// Token: 0x0603C47A RID: 246906 RVA: 0x00F4B95C File Offset: 0x00F49B5C
		private void PlayBarAnimation()
		{
			float num = this.CurHp / this.CurHpMax;
			float currentBarPercent = this.CurrentBarPercent;
			if (num >= currentBarPercent)
			{
				return;
			}
			this.TargetBarPercent = num;
			this.SourceBarPercent = currentBarPercent;
			this.HpBufferAnimTime = 0f;
		}

		// Token: 0x0603C47B RID: 246907 RVA: 0x00F4B99C File Offset: 0x00F49B9C
		private void StopBarLerpAnimation()
		{
			this.TargetBarPercent = 0f;
			this.SourceBarPercent = 0f;
			this.HpBufferAnimTime = -1f;
			this.HpBufferSprite.SetUIActive(false);
		}

		// Token: 0x0603C47C RID: 246908 RVA: 0x00F4B9CC File Offset: 0x00F49BCC
		private void LerpBarPercent(float delta)
		{
			if (this.HpBufferAnimTime == -1f)
			{
				return;
			}
			if (this.HpBufferAnimTime >= this.HpBufferAnimDuration)
			{
				this.StopBarLerpAnimation();
				return;
			}
			if (this.TargetBarPercent >= this.SourceBarPercent)
			{
				return;
			}
			float alpha = this.HpBufferAnimTime / this.HpBufferAnimDuration;
			float fillAmount = Singleton<MathUtils>.Instance.Lerp(this.SourceBarPercent, this.TargetBarPercent, alpha);
			this.HpBufferSprite.SetFillAmount(fillAmount);
			this.HpBufferSprite.SetUIActive(true);
			this.HpBufferAnimTime += delta;
		}

		// Token: 0x04021E66 RID: 138854
		private const float LOW_HP_PERCENT = 0.2f;

		// Token: 0x04021E67 RID: 138855
		private UUISprite HpBarSprite;

		// Token: 0x04021E68 RID: 138856
		private UUISprite LowHpBarSprite;

		// Token: 0x04021E69 RID: 138857
		private UUISprite HpBufferSprite;

		// Token: 0x04021E6A RID: 138858
		private UUISprite ShieldBarSprite;

		// Token: 0x04021E6B RID: 138859
		private UUIText HpText;

		// Token: 0x04021E6C RID: 138860
		private UUIText HpText2;

		// Token: 0x04021E6D RID: 138861
		private ULGUICanvas HpTextMask;

		// Token: 0x04021E6E RID: 138862
		private float HpTextWidth;

		// Token: 0x04021E6F RID: 138863
		private FMargin UeMargin;

		// Token: 0x04021E70 RID: 138864
		private float CurrentBarPercent = -1f;

		// Token: 0x04021E71 RID: 138865
		private float TargetBarPercent;

		// Token: 0x04021E72 RID: 138866
		private float SourceBarPercent;

		// Token: 0x04021E73 RID: 138867
		private float HpBufferAnimTime = -1f;

		// Token: 0x04021E74 RID: 138868
		private float HpBufferAnimDuration;

		// Token: 0x04021E75 RID: 138869
		private float CurHp;

		// Token: 0x04021E76 RID: 138870
		private float CurHpMax = 1f;
	}
}
