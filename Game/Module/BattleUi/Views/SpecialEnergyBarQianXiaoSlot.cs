using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060DA RID: 24794
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarQianXiaoSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E9EF RID: 256495 RVA: 0x01006C3C File Offset: 0x01004E3C
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool flag = this.State == SpecialEnergyBarQianXiaoSlot.ESlotState.Normal && this.FullEffectEnable && this.GetKeyEnable();
			SpecialEnergyBarSlotItem specialEnergyBarSlotItem = this.SlotItemList[0];
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.RefreshKeyEnable(flag, isStart);
			}
			float x = curPercent * 187f + (1f - curPercent) * -181f;
			this.PointItemLocation.X = x;
			UUIItem pointItem = this.PointItem;
			if (pointItem != null)
			{
				pointItem.SetUIRelativeLocation(this.PointItemLocation);
			}
			bool flag2 = this.MarkEmpty || this.MarkFull;
			if (this.MarkEmpty)
			{
				this.MarkEmpty = false;
				specialEnergyBarSlotItem.UpdatePercent(0f, false, true);
			}
			else if (this.MarkFull)
			{
				this.MarkFull = false;
				specialEnergyBarSlotItem.UpdatePercent(1f, false, true);
				specialEnergyBarSlotItem.SetFullEffectVisible(false);
			}
			if (this.State != SpecialEnergyBarQianXiaoSlot.ESlotState.Special && flag && this.CanPlayChangeEffect)
			{
				this.CanPlayChangeEffect = false;
				specialEnergyBarSlotItem.PlayChangeEffectWithPercent(1f);
			}
			if (this.State == SpecialEnergyBarQianXiaoSlot.ESlotState.Special)
			{
				specialEnergyBarSlotItem.UpdatePercentWithFullEffect(curPercent, curPercent > 0f, isStart);
				this.GearItemLocation.X = x;
				UUIItem gearItem = this.GearItem;
				if (gearItem != null)
				{
					gearItem.SetUIRelativeLocation(this.GearItemLocation);
				}
			}
			else if (flag)
			{
				specialEnergyBarSlotItem.UpdatePercentWithFullEffect(curPercent, curPercent > 0f, isStart);
			}
			else if (!flag2)
			{
				specialEnergyBarSlotItem.UpdatePercent(curPercent, false, isStart);
			}
			if (this.State == SpecialEnergyBarQianXiaoSlot.ESlotState.Normal && this.BarPercent == 1f && curPercent == 0f)
			{
				specialEnergyBarSlotItem.PlayUseEffectWithPercent(this.BarPercent);
			}
			this.BarPercent = curPercent;
		}

		// Token: 0x0603E9F0 RID: 256496 RVA: 0x01006DD8 File Offset: 0x01004FD8
		public override void Tick(float delta)
		{
			base.Tick(delta);
			if (this.State == SpecialEnergyBarQianXiaoSlot.ESlotState.CoolDown)
			{
				this.GearRollbackTime += (int)delta;
				if (this.GearRollbackTime >= 300)
				{
					this.GearItemLocation.X = 187f;
					UUIItem gearItem = this.GearItem;
					if (gearItem != null)
					{
						gearItem.SetUIRelativeLocation(this.GearItemLocation);
					}
					this.SetState(SpecialEnergyBarQianXiaoSlot.ESlotState.Normal);
				}
				else if (this.GearRollbackCurve != null)
				{
					float floatValue = this.GearRollbackCurve.GetFloatValue((float)this.GearRollbackTime * (float)Singleton<TimeUtil>.Instance.Millisecond);
					this.GearItemLocation.X = floatValue * 187f + (1f - floatValue) * this.GearItemStartX;
					UUIItem gearItem2 = this.GearItem;
					if (gearItem2 != null)
					{
						gearItem2.SetUIRelativeLocation(this.GearItemLocation);
					}
				}
			}
			if (this.GlowEffectFinishTime > 0.0 && this.GlowEffectFinishTime <= Singleton<Time>.Instance.Now)
			{
				UUIItem glowItem = this.GlowItem;
				if (glowItem != null)
				{
					glowItem.SetUIActive(false);
				}
				this.GlowEffectFinishTime = 0.0;
			}
		}

		// Token: 0x0603E9F1 RID: 256497 RVA: 0x01006EE8 File Offset: 0x010050E8
		public void SetState(SpecialEnergyBarQianXiaoSlot.ESlotState state)
		{
			if (this.State == state)
			{
				return;
			}
			this.State = state;
			if (state == SpecialEnergyBarQianXiaoSlot.ESlotState.Normal)
			{
				this.CanPlayChangeEffect = true;
				return;
			}
			if (state == SpecialEnergyBarQianXiaoSlot.ESlotState.Special)
			{
				this.GearItemLocation.X = 187f;
				UUIItem gearItem = this.GearItem;
				if (gearItem != null)
				{
					gearItem.SetUIRelativeLocation(this.GearItemLocation);
				}
				UUIItem glowItem = this.GlowItem;
				if (glowItem != null)
				{
					glowItem.SetUIActive(false);
				}
				this.MarkEmpty = true;
				this.RefreshBarPercent(false);
				return;
			}
			float curPercent = this.PercentMachine.GetCurPercent();
			if (curPercent > 0f)
			{
				UUISliderComponent glowSlider = this.GlowSlider;
				if (glowSlider != null)
				{
					glowSlider.SetValue(curPercent, true);
				}
				UUIItem glowItem2 = this.GlowItem;
				if (glowItem2 != null)
				{
					glowItem2.SetUIActive(true);
				}
			}
			this.GearRollbackTime = 0;
			this.GearItemStartX = this.GearItem.RelativeLocation.X;
			this.GlowEffectFinishTime = 1000.0 + Singleton<Time>.Instance.Now;
			this.CanPlayChangeEffect = true;
		}

		// Token: 0x0603E9F2 RID: 256498 RVA: 0x01006FD4 File Offset: 0x010051D4
		public void SetFullEffectEnable(bool enable)
		{
			if (this.FullEffectEnable == enable)
			{
				return;
			}
			this.FullEffectEnable = enable;
			if (!enable && this.State != SpecialEnergyBarQianXiaoSlot.ESlotState.CoolDown && this.GetKeyEnable())
			{
				this.MarkFull = true;
			}
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E9F3 RID: 256499 RVA: 0x01007009 File Offset: 0x01005209
		[NullableContext(1)]
		public void SetPointItem(UUIItem pointItem)
		{
			this.PointItem = pointItem;
			this.PointItemLocation = pointItem.RelativeLocation;
		}

		// Token: 0x0603E9F4 RID: 256500 RVA: 0x0100701E File Offset: 0x0100521E
		[NullableContext(1)]
		public void SetGearItem(UUIItem gearItem)
		{
			this.GearItem = gearItem;
			this.GearItemLocation = gearItem.RelativeLocation;
		}

		// Token: 0x0603E9F5 RID: 256501 RVA: 0x01007033 File Offset: 0x01005233
		[NullableContext(1)]
		public void SetGearRollbackCurve(UCurveFloat curve)
		{
			this.GearRollbackCurve = curve;
		}

		// Token: 0x0603E9F6 RID: 256502 RVA: 0x0100703C File Offset: 0x0100523C
		public void StopCoolDownState()
		{
			if (this.State == SpecialEnergyBarQianXiaoSlot.ESlotState.CoolDown)
			{
				this.GearItemLocation.X = 187f;
				UUIItem gearItem = this.GearItem;
				if (gearItem != null)
				{
					gearItem.SetUIRelativeLocation(this.GearItemLocation);
				}
				this.SetState(SpecialEnergyBarQianXiaoSlot.ESlotState.Normal);
			}
			if (this.GlowEffectFinishTime > 0.0)
			{
				this.GlowEffectFinishTime = 0.0;
				UUIItem glowItem = this.GlowItem;
				if (glowItem == null)
				{
					return;
				}
				glowItem.SetUIActive(false);
			}
		}

		// Token: 0x0603E9F7 RID: 256503 RVA: 0x010070B1 File Offset: 0x010052B1
		public bool IsInSlotState(SpecialEnergyBarQianXiaoSlot.ESlotState state)
		{
			return this.State == state;
		}

		// Token: 0x040231D6 RID: 143830
		private const int START_LOCATION_X = -181;

		// Token: 0x040231D7 RID: 143831
		private const int END_LOCATION_X = 187;

		// Token: 0x040231D8 RID: 143832
		private const int GEAR_ROLLBACK_DURATION = 300;

		// Token: 0x040231D9 RID: 143833
		private const double GLOW_EFFECT_DURATION = 1000.0;

		// Token: 0x040231DA RID: 143834
		public UUIItem PointItem;

		// Token: 0x040231DB RID: 143835
		public UUIItem GearItem;

		// Token: 0x040231DC RID: 143836
		public UUIItem GlowItem;

		// Token: 0x040231DD RID: 143837
		public UUISliderComponent GlowSlider;

		// Token: 0x040231DE RID: 143838
		public UCurveFloat GearRollbackCurve;

		// Token: 0x040231DF RID: 143839
		public bool FullEffectEnable;

		// Token: 0x040231E0 RID: 143840
		private SpecialEnergyBarQianXiaoSlot.ESlotState State;

		// Token: 0x040231E1 RID: 143841
		private int GearRollbackTime;

		// Token: 0x040231E2 RID: 143842
		private double GlowEffectFinishTime;

		// Token: 0x040231E3 RID: 143843
		private bool CanPlayChangeEffect = true;

		// Token: 0x040231E4 RID: 143844
		private bool MarkEmpty;

		// Token: 0x040231E5 RID: 143845
		private bool MarkFull;

		// Token: 0x040231E6 RID: 143846
		private FVector PointItemLocation;

		// Token: 0x040231E7 RID: 143847
		private FVector GearItemLocation;

		// Token: 0x040231E8 RID: 143848
		private float GearItemStartX;

		// Token: 0x040231E9 RID: 143849
		private float BarPercent;

		// Token: 0x0200C230 RID: 49712
		[NullableContext(0)]
		public enum ESlotState
		{
			// Token: 0x0403BD92 RID: 245138
			Normal,
			// Token: 0x0403BD93 RID: 245139
			Special,
			// Token: 0x0403BD94 RID: 245140
			CoolDown
		}
	}
}
