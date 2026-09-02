using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200601B RID: 24603
	public class HeadIconEnergyBarCommon : HeadIconEnergyBarBase
	{
		// Token: 0x0603E008 RID: 253960 RVA: 0x00FD249C File Offset: 0x00FD069C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E009 RID: 253961 RVA: 0x00FD2589 File Offset: 0x00FD0789
		protected override void OnStart()
		{
			base.OnStart();
			base.InitTweenAnim(3);
			base.InitTweenAnim(4);
			base.InitTweenAnim(5);
			this.LastPercent = this.PercentMachine.GetCurPercent();
			this.RefreshBarPercent(true);
		}

		// Token: 0x0603E00A RID: 253962 RVA: 0x00FD25C0 File Offset: 0x00FD07C0
		protected override void OnTargetPercentChanged()
		{
			float targetPercent = this.PercentMachine.GetTargetPercent();
			if (targetPercent > this.LastPercent)
			{
				this.PlayAbsorbAni();
			}
			this.LastPercent = targetPercent;
		}

		// Token: 0x0603E00B RID: 253963 RVA: 0x00FD25EF File Offset: 0x00FD07EF
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E00C RID: 253964 RVA: 0x00FD25F8 File Offset: 0x00FD07F8
		private void RefreshBarPercent(bool bForce = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetFillAmount(curPercent);
			}
			this.SetIsFull(curPercent >= 1f, bForce);
		}

		// Token: 0x0603E00D RID: 253965 RVA: 0x00FD2638 File Offset: 0x00FD0838
		private void PlayAbsorbAni()
		{
			if (!this.PlayIncreaseEffect)
			{
				return;
			}
			float num = (float)Singleton<Time>.Instance.NowSeconds;
			if (num <= this.NextAbsorbAniTime)
			{
				return;
			}
			this.NextAbsorbAniTime = num + this.Config.Value.EffectCd;
			base.PlayTweenAnim(5);
		}

		// Token: 0x0603E00E RID: 253966 RVA: 0x00FD2686 File Offset: 0x00FD0886
		private void SetIsFull(bool isFull, bool bForce = false)
		{
			if (this.IsFull == isFull && !bForce)
			{
				return;
			}
			this.IsFull = isFull;
			if (this.IsFull)
			{
				base.StopTweenAnim(4);
				base.PlayTweenAnim(3);
				return;
			}
			base.StopTweenAnim(3);
			base.PlayTweenAnim(4);
		}

		// Token: 0x04022C49 RID: 142409
		private float LastPercent;

		// Token: 0x04022C4A RID: 142410
		private float NextAbsorbAniTime;

		// Token: 0x04022C4B RID: 142411
		private bool IsFull;

		// Token: 0x0200C0C6 RID: 49350
		private enum EChildType
		{
			// Token: 0x0403B599 RID: 243097
			BarItem,
			// Token: 0x0403B59A RID: 243098
			BarSprite,
			// Token: 0x0403B59B RID: 243099
			BarLightItem,
			// Token: 0x0403B59C RID: 243100
			AniBurstIn,
			// Token: 0x0403B59D RID: 243101
			AniBurstOut,
			// Token: 0x0403B59E RID: 243102
			AniAbsorb
		}
	}
}
