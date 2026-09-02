using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefenseUi.HeadState
{
	// Token: 0x02004E7C RID: 20092
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseHeadStateData
	{
		// Token: 0x06033E8B RID: 212619 RVA: 0x00CFDAE5 File Offset: 0x00CFBCE5
		public bool UpdateHp(int hp, int maxHp, int shield)
		{
			if (this.Hp == hp && this.MaxHp == maxHp && this.Shield == shield)
			{
				return false;
			}
			this.Hp = hp;
			this.MaxHp = maxHp;
			this.Shield = shield;
			return true;
		}

		// Token: 0x06033E8C RID: 212620 RVA: 0x00CFDB1A File Offset: 0x00CFBD1A
		public void UpdatePosition(Vector position)
		{
			this.Position.FromUeVector(position);
		}

		// Token: 0x06033E8D RID: 212621 RVA: 0x00CFDB28 File Offset: 0x00CFBD28
		public void RefreshDistance(Vector cameraLocation)
		{
			this.DistanceSquared = Vector.DistSquared(this.Position, cameraLocation);
		}

		// Token: 0x06033E8E RID: 212622 RVA: 0x00CFDB3C File Offset: 0x00CFBD3C
		public void Destroy()
		{
		}

		// Token: 0x06033E8F RID: 212623 RVA: 0x00CFDB3E File Offset: 0x00CFBD3E
		public void SetVisible(bool visible)
		{
			this.Visible = visible;
		}

		// Token: 0x06033E90 RID: 212624 RVA: 0x00CFDB48 File Offset: 0x00CFBD48
		public void RefreshHpAndShield()
		{
			if (this.MaxHp <= 0)
			{
				this.HpPercent = 0f;
				this.ShieldPercent = 0f;
				return;
			}
			this.HpPercent = (float)this.Hp / (float)this.MaxHp;
			this.ShieldPercent = (float)this.Shield / (float)this.MaxHp;
		}

		// Token: 0x06033E91 RID: 212625 RVA: 0x00CFDB9F File Offset: 0x00CFBD9F
		public void Tick(float delta)
		{
			this.RefreshHpBuffer(delta);
			this.RefreshScale();
		}

		// Token: 0x06033E92 RID: 212626 RVA: 0x00CFDBB0 File Offset: 0x00CFBDB0
		private void RefreshScale()
		{
			float floatValue = this.ScaleCurve.GetFloatValue((float)this.DistanceSquared);
			this.ActorScale.X = (double)floatValue;
			this.ActorScale.Y = (double)floatValue;
			this.ActorScale.Z = (double)floatValue;
		}

		// Token: 0x06033E93 RID: 212627 RVA: 0x00CFDBF8 File Offset: 0x00CFBDF8
		private void RefreshHpBuffer(float delta)
		{
			if (this.HpBufferPercent == this.HpPercent)
			{
				return;
			}
			if (this.HpBufferPercent < this.HpPercent)
			{
				this.HpBufferPercent = this.HpPercent;
				return;
			}
			this.HpBufferPercent -= 0.001f * delta;
			if (this.HpBufferPercent < this.HpPercent)
			{
				this.HpBufferPercent = this.HpPercent;
			}
		}

		// Token: 0x0401E04E RID: 122958
		private const float HP_BUFFER_SPEED = 0.001f;

		// Token: 0x0401E04F RID: 122959
		public int EntityId;

		// Token: 0x0401E050 RID: 122960
		public Vector Position = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x0401E051 RID: 122961
		public int MaxHp;

		// Token: 0x0401E052 RID: 122962
		public int Hp;

		// Token: 0x0401E053 RID: 122963
		public int Shield;

		// Token: 0x0401E054 RID: 122964
		public double DistanceSquared;

		// Token: 0x0401E055 RID: 122965
		[Nullable(2)]
		public UCurveFloat ScaleCurve;

		// Token: 0x0401E056 RID: 122966
		public bool Visible;

		// Token: 0x0401E057 RID: 122967
		public float HpPercent;

		// Token: 0x0401E058 RID: 122968
		public float HpBufferPercent;

		// Token: 0x0401E059 RID: 122969
		public float ShieldPercent;

		// Token: 0x0401E05A RID: 122970
		public readonly Vector ActorScale = Vector.Create();
	}
}
