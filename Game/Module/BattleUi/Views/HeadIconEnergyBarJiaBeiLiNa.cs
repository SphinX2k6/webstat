using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200601F RID: 24607
	public class HeadIconEnergyBarJiaBeiLiNa : HeadIconEnergyBarBase
	{
		// Token: 0x0603E02E RID: 253998 RVA: 0x00FD2F28 File Offset: 0x00FD1128
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E02F RID: 253999 RVA: 0x00FD3057 File Offset: 0x00FD1257
		protected override void OnStart()
		{
			base.OnStart();
			base.InitTweenAnim(6);
			base.InitTweenAnim(5);
			base.InitTweenAnim(7);
			this.LastPercent = this.PercentMachine.GetCurPercent();
			this.RefreshBarPercent(true);
		}

		// Token: 0x0603E030 RID: 254000 RVA: 0x00FD308C File Offset: 0x00FD128C
		protected override void OnTargetPercentChanged()
		{
			float targetPercent = this.PercentMachine.GetTargetPercent();
			if (targetPercent > this.LastPercent)
			{
				this.PlayAbsorbAni();
			}
			this.LastPercent = targetPercent;
		}

		// Token: 0x0603E031 RID: 254001 RVA: 0x00FD30BB File Offset: 0x00FD12BB
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E032 RID: 254002 RVA: 0x00FD30C4 File Offset: 0x00FD12C4
		private void RefreshBarPercent(bool bForce = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetFillAmount(curPercent);
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetAnchorOffsetX(116f * (curPercent - 0.5f));
			}
			this.SetIsFull(curPercent >= 1f, bForce);
		}

		// Token: 0x0603E033 RID: 254003 RVA: 0x00FD3124 File Offset: 0x00FD1324
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
			base.PlayTweenAnim(7);
		}

		// Token: 0x0603E034 RID: 254004 RVA: 0x00FD3172 File Offset: 0x00FD1372
		private void SetIsFull(bool isFull, bool bForce = false)
		{
			if (this.IsFull == isFull && !bForce)
			{
				return;
			}
			this.IsFull = isFull;
			if (this.IsFull)
			{
				base.StopTweenAnim(5);
				base.PlayTweenAnim(6);
				return;
			}
			base.StopTweenAnim(6);
			base.PlayTweenAnim(5);
		}

		// Token: 0x04022C5D RID: 142429
		private float LastPercent;

		// Token: 0x04022C5E RID: 142430
		private float NextAbsorbAniTime;

		// Token: 0x04022C5F RID: 142431
		private bool IsFull;

		// Token: 0x0200C0CC RID: 49356
		private enum EChildType
		{
			// Token: 0x0403B5BF RID: 243135
			BarItem,
			// Token: 0x0403B5C0 RID: 243136
			BarSprite,
			// Token: 0x0403B5C1 RID: 243137
			BarLightItem,
			// Token: 0x0403B5C2 RID: 243138
			FullItem,
			// Token: 0x0403B5C3 RID: 243139
			FullBarSprite,
			// Token: 0x0403B5C4 RID: 243140
			AniBurstOut,
			// Token: 0x0403B5C5 RID: 243141
			AniBurstIn,
			// Token: 0x0403B5C6 RID: 243142
			AniAbsorb
		}
	}
}
