using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb
{
	// Token: 0x020055D6 RID: 21974
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDetailsSkillItem : UiPanelBase
	{
		// Token: 0x06037FD1 RID: 229329 RVA: 0x00E2EB94 File Offset: 0x00E2CD94
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUINiagara))
			};
		}

		// Token: 0x06037FD2 RID: 229330 RVA: 0x00E2EC30 File Offset: 0x00E2CE30
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.DelegateX = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.TweenCallX));
			this.DelegateZ = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.TweenerCallZ));
			base.GetUiNiagara(5).SetUIActive(false);
		}

		// Token: 0x06037FD3 RID: 229331 RVA: 0x00E2EC8C File Offset: 0x00E2CE8C
		protected override void OnBeforeDestroy()
		{
			if (this.TweenerX != null)
			{
				this.TweenerX = null;
			}
			if (this.TweenerZ != null)
			{
				this.TweenerZ = null;
			}
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.TweenCallX));
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.TweenerCallZ));
		}

		// Token: 0x06037FD4 RID: 229332 RVA: 0x00E2ECDC File Offset: 0x00E2CEDC
		public void RefreshIcon(string icon)
		{
			base.SetTextureByPath(icon, base.GetTexture(0), null, null);
		}

		// Token: 0x06037FD5 RID: 229333 RVA: 0x00E2ED01 File Offset: 0x00E2CF01
		public void RefreshSettlePointText(int settlePoint)
		{
			this.SettlePoint = settlePoint;
			base.GetText(1).SetText(settlePoint.ToString(), true);
		}

		// Token: 0x06037FD6 RID: 229334 RVA: 0x00E2ED20 File Offset: 0x00E2CF20
		public int ShowWinAnim()
		{
			if (this.SettlePoint == 0)
			{
				return 0;
			}
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.PlayLevelSequenceByName(EPhantomBattleHeadAnim.DamageAccumulate.ToString(), false, null, false);
			}
			return this.SettlePoint;
		}

		// Token: 0x06037FD7 RID: 229335 RVA: 0x00E2ED69 File Offset: 0x00E2CF69
		public int GetDamage()
		{
			return this.SettlePoint;
		}

		// Token: 0x06037FD8 RID: 229336 RVA: 0x00E2ED74 File Offset: 0x00E2CF74
		public void OnAccumulateEvent(float endX, float endZ, UCurveFloat curveCommon)
		{
			if (this.SettlePoint == 0)
			{
				return;
			}
			base.GetUiNiagara(5).SetUIActive(true);
			FVectorDouble fvectorDouble = base.GetTexture(0).D_K2_GetComponentLocation();
			this.TweenerX = ULTweenBPLibrary.FloatTo(GlobalData.World, this.DelegateX, (float)fvectorDouble.X, endX, 0.3f, 0f, LTweenEase.OutCubic);
			this.TweenerZ = ULTweenBPLibrary.FloatTo(GlobalData.World, this.DelegateZ, (float)fvectorDouble.Z, endZ, 0.3f, 0f, LTweenEase.OutCubic);
			if (this.TweenerX != null)
			{
				this.TweenerX.SetEase(LTweenEase.CurveFloat);
				this.TweenerX.SetCurveFloat(curveCommon);
				this.TweenerX.OnCompleteCallBack.Bind(new Action(this.OnTweenerXEnd));
			}
			if (this.TweenerZ != null)
			{
				this.TweenerZ.SetEase(LTweenEase.CurveFloat);
				this.TweenerZ.SetCurveFloat(curveCommon);
				this.TweenerZ.OnCompleteCallBack.Bind(new Action(this.OnTweenerZEnd));
			}
		}

		// Token: 0x06037FD9 RID: 229337 RVA: 0x00E2EE74 File Offset: 0x00E2D074
		private void TweenCallX(float value)
		{
			FVectorDouble fvectorDouble = base.GetUiNiagara(5).D_K2_GetComponentLocation();
			FVectorDouble newLocation = Vector.Create((double)value, fvectorDouble.Y, fvectorDouble.Z).ToUeVector(false);
			base.GetUiNiagara(5).D_K2_SetWorldLocation(newLocation, false, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x06037FDA RID: 229338 RVA: 0x00E2EEBC File Offset: 0x00E2D0BC
		private void TweenerCallZ(float value)
		{
			FVectorDouble fvectorDouble = base.GetUiNiagara(5).D_K2_GetComponentLocation();
			FVectorDouble newLocation = Vector.Create(fvectorDouble.X, fvectorDouble.Y, (double)value).ToUeVector(false);
			base.GetUiNiagara(5).D_K2_SetWorldLocation(newLocation, false, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x06037FDB RID: 229339 RVA: 0x00E2EF04 File Offset: 0x00E2D104
		private void OnTweenerXEnd()
		{
			if (this.TweenerX != null)
			{
				this.TweenerX = null;
			}
			base.GetUiNiagara(5).SetUIActive(false);
		}

		// Token: 0x06037FDC RID: 229340 RVA: 0x00E2EF22 File Offset: 0x00E2D122
		private void OnTweenerZEnd()
		{
			if (this.TweenerZ != null)
			{
				this.TweenerZ = null;
			}
		}

		// Token: 0x04020039 RID: 131129
		protected ULTweener TweenerX;

		// Token: 0x0402003A RID: 131130
		protected ULTweener TweenerZ;

		// Token: 0x0402003B RID: 131131
		protected FLTweenFloatSetterDynamic DelegateX;

		// Token: 0x0402003C RID: 131132
		protected FLTweenFloatSetterDynamic DelegateZ;

		// Token: 0x0402003D RID: 131133
		protected int SettlePoint;

		// Token: 0x0402003E RID: 131134
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x0200B5D2 RID: 46546
		[NullableContext(0)]
		private class ESkillItem
		{
			// Token: 0x04038427 RID: 230439
			public const int Icon = 0;

			// Token: 0x04038428 RID: 230440
			public const int SettlePointText = 1;

			// Token: 0x04038429 RID: 230441
			public const int PanelSkill = 2;

			// Token: 0x0403842A RID: 230442
			public const int SpriteSkillCost = 3;

			// Token: 0x0403842B RID: 230443
			public const int Content = 4;

			// Token: 0x0403842C RID: 230444
			public const int NiagaraPoint = 5;
		}
	}
}
