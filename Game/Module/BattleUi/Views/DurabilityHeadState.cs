using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006028 RID: 24616
	public class DurabilityHeadState : HeadStateViewBase
	{
		// Token: 0x0603E0C5 RID: 254149 RVA: 0x00FD60E0 File Offset: 0x00FD42E0
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

		// Token: 0x0603E0C6 RID: 254150 RVA: 0x00FD616A File Offset: 0x00FD436A
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_DestructionState_Prefab";
		}

		// Token: 0x0603E0C7 RID: 254151 RVA: 0x00FD6171 File Offset: 0x00FD4371
		[NullableContext(1)]
		protected override void ActiveBattleHeadState(HeadStateData headStateData)
		{
			base.ActiveBattleHeadState(headStateData);
			if (headStateData.OriginalHp != null)
			{
				this.CurrentBarPercent = headStateData.OriginalHp.Value / this.GetMaxHp();
			}
			this.RefreshDurability(true);
		}

		// Token: 0x0603E0C8 RID: 254152 RVA: 0x00FD61A6 File Offset: 0x00FD43A6
		protected override void OnStart()
		{
			this.HpParentWidth = base.GetSprite(2).GetParentAsUIItem().GetWidth();
		}

		// Token: 0x0603E0C9 RID: 254153 RVA: 0x00FD61BF File Offset: 0x00FD43BF
		protected override void BindCallback()
		{
			base.BindCallback();
			this.HeadStateData.BindOnSceneItemDurabilityChange(new Action<int>(this.OnSceneItemDurabilityChange));
		}

		// Token: 0x0603E0CA RID: 254154 RVA: 0x00FD61DE File Offset: 0x00FD43DE
		private void OnSceneItemDurabilityChange(int durability)
		{
			this.RefreshDurability(true);
		}

		// Token: 0x0603E0CB RID: 254155 RVA: 0x00FD61E8 File Offset: 0x00FD43E8
		private void RefreshDurability(bool bPlayBarAnimation = false)
		{
			float hp = this.GetHp();
			float maxHp = this.GetMaxHp();
			float num = hp / maxHp;
			this.SetHpBarPercent(num);
			if (bPlayBarAnimation)
			{
				this.PlayBarAnimation(num);
			}
			else
			{
				this.StopBarLerpAnimation();
			}
			HeadStateData headStateData = this.HeadStateData;
			if (headStateData == null)
			{
				return;
			}
			headStateData.SetOriginalHp(hp);
		}

		// Token: 0x0603E0CC RID: 254156 RVA: 0x00FD6231 File Offset: 0x00FD4431
		private void SetHpBarPercent(float percent)
		{
			base.GetSprite(0).SetFillAmount(percent);
		}

		// Token: 0x0603E0CD RID: 254157 RVA: 0x00FD6240 File Offset: 0x00FD4440
		protected override void OnBeginBarAnimation(float hpPercent)
		{
			this.SetBarBufferPercent(hpPercent);
		}

		// Token: 0x0603E0CE RID: 254158 RVA: 0x00FD6249 File Offset: 0x00FD4449
		protected override void StopBarLerpAnimation()
		{
			base.StopBarLerpAnimation();
			base.GetSprite(1).SetUIActive(false);
		}

		// Token: 0x0603E0CF RID: 254159 RVA: 0x00FD625E File Offset: 0x00FD445E
		protected override void OnLerpBarBufferPercent(float percent)
		{
			this.SetBarBufferPercent(percent);
		}

		// Token: 0x0603E0D0 RID: 254160 RVA: 0x00FD6268 File Offset: 0x00FD4468
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

		// Token: 0x0603E0D1 RID: 254161 RVA: 0x00FD62CC File Offset: 0x00FD44CC
		protected override float GetMaxHp()
		{
			return this.HeadStateData.GetMaxDurable();
		}

		// Token: 0x0603E0D2 RID: 254162 RVA: 0x00FD62D9 File Offset: 0x00FD44D9
		protected override float GetHp()
		{
			return this.HeadStateData.GetDurable();
		}

		// Token: 0x04022C8B RID: 142475
		private float HpParentWidth;

		// Token: 0x0200C0DC RID: 49372
		private enum EChildComponentType
		{
			// Token: 0x0403B611 RID: 243217
			NormalHpBarSprite,
			// Token: 0x0403B612 RID: 243218
			BarBufferSprite,
			// Token: 0x0403B613 RID: 243219
			HpLight
		}
	}
}
