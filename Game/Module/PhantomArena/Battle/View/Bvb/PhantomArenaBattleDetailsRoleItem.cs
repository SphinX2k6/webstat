using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Panel;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb
{
	// Token: 0x020055D5 RID: 21973
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDetailsRoleItem : UiPanelBase
	{
		// Token: 0x06037FC0 RID: 229312 RVA: 0x00E2E78C File Offset: 0x00E2C98C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText))
			};
		}

		// Token: 0x06037FC1 RID: 229313 RVA: 0x00E2E83E File Offset: 0x00E2CA3E
		protected override void OnStart()
		{
			this.DelegateDamage = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.TweenCallDamage));
		}

		// Token: 0x06037FC2 RID: 229314 RVA: 0x00E2E857 File Offset: 0x00E2CA57
		protected override void OnBeforeDestroy()
		{
			if (this.TweenerDamage != null)
			{
				this.TweenerDamage = null;
			}
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.TweenCallDamage));
		}

		// Token: 0x06037FC3 RID: 229315 RVA: 0x00E2E87C File Offset: 0x00E2CA7C
		private UniTask InitRoleHead()
		{
			PhantomArenaBattleDetailsRoleItem.<InitRoleHead>d__12 <InitRoleHead>d__;
			<InitRoleHead>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleHead>d__.<>4__this = this;
			<InitRoleHead>d__.<>1__state = -1;
			<InitRoleHead>d__.<>t__builder.Start<PhantomArenaBattleDetailsRoleItem.<InitRoleHead>d__12>(ref <InitRoleHead>d__);
			return <InitRoleHead>d__.<>t__builder.Task;
		}

		// Token: 0x06037FC4 RID: 229316 RVA: 0x00E2E8C0 File Offset: 0x00E2CAC0
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaBattleDetailsRoleItem.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaBattleDetailsRoleItem.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037FC5 RID: 229317 RVA: 0x00E2E904 File Offset: 0x00E2CB04
		public void RefreshLifeNum(int lifeNum, int maxLifeNum)
		{
			this.MaxLife = maxLifeNum;
			this.CurLife = lifeNum;
			base.GetText(1).SetText(lifeNum.ToString() + "/" + maxLifeNum.ToString(), true);
			this.RoleHead.RefreshLifeBar((float)lifeNum / (float)maxLifeNum);
		}

		// Token: 0x06037FC6 RID: 229318 RVA: 0x00E2E954 File Offset: 0x00E2CB54
		public void SetHitNum(int damage)
		{
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText("-" + damage.ToString(), true);
		}

		// Token: 0x06037FC7 RID: 229319 RVA: 0x00E2E97C File Offset: 0x00E2CB7C
		public void RefreshLifeAfterDamage(UCurveFloat curve, int damage)
		{
			int num = Math.Max(0, this.CurLife - damage);
			this.RoleHead.RefreshLifeBar((float)num / (float)this.MaxLife);
			float duration = 0.2f;
			this.TweenerDamage = ULTweenBPLibrary.FloatTo(GlobalData.World, this.DelegateDamage, (float)this.CurLife, (float)num, duration, 0f, LTweenEase.OutCubic);
			if (this.TweenerDamage != null)
			{
				this.TweenerDamage.OnCompleteCallBack.Bind(new Action(this.OnTweenerEnd));
				this.TweenerDamage.SetEase(LTweenEase.CurveFloat);
				this.TweenerDamage.SetCurveFloat(curve);
			}
		}

		// Token: 0x06037FC8 RID: 229320 RVA: 0x00E2EA18 File Offset: 0x00E2CC18
		public void SetBarActive(bool isOwn)
		{
			this.RoleHead.SetBarActive(isOwn);
		}

		// Token: 0x06037FC9 RID: 229321 RVA: 0x00E2EA26 File Offset: 0x00E2CC26
		public void RefreshHeadIcon(string headIcon)
		{
			this.RoleHead.RefreshRoleIcon(headIcon);
		}

		// Token: 0x06037FCA RID: 229322 RVA: 0x00E2EA34 File Offset: 0x00E2CC34
		public void RefreshShieldNum(int shieldNum)
		{
			if (shieldNum > this.LastShieldNum && this.LastShieldNum == 0)
			{
				base.GetText(5).SetText(shieldNum.ToString(), true);
				base.GetItem(4).SetUIActive(true);
				this.LastShieldNum = shieldNum;
				return;
			}
			if (shieldNum >= this.LastShieldNum)
			{
				base.GetText(5).SetText(shieldNum.ToString(), true);
				this.LastShieldNum = shieldNum;
				return;
			}
			if (shieldNum == 0)
			{
				base.GetItem(4).SetUIActive(false);
				this.LastShieldNum = shieldNum;
				return;
			}
			int num = shieldNum - this.LastShieldNum;
			base.GetText(5).SetText(shieldNum.ToString(), true);
			base.GetText(6).SetText(num.ToString(), true);
			this.LastShieldNum = shieldNum;
		}

		// Token: 0x06037FCB RID: 229323 RVA: 0x00E2EAF0 File Offset: 0x00E2CCF0
		public void RegisterViewProxy(PhantomArenaBattleDetailsViewProxy viewProxy)
		{
			this.ViewProxy = viewProxy;
		}

		// Token: 0x06037FCC RID: 229324 RVA: 0x00E2EAF9 File Offset: 0x00E2CCF9
		public void OnAccumulateAfterEvent()
		{
			PhantomArenaHeadItem roleHead = this.RoleHead;
			if (roleHead == null)
			{
				return;
			}
			roleHead.PlayAccumulateDamage();
		}

		// Token: 0x06037FCD RID: 229325 RVA: 0x00E2EB0B File Offset: 0x00E2CD0B
		public FVectorDouble GetHeadLocation()
		{
			return base.GetItem(0).D_K2_GetComponentLocation();
		}

		// Token: 0x06037FCE RID: 229326 RVA: 0x00E2EB1C File Offset: 0x00E2CD1C
		private void TweenCallDamage(float value)
		{
			PhantomArenaHeadItem roleHead = this.RoleHead;
			if (roleHead != null)
			{
				roleHead.RefreshDamageBar(value / (float)this.MaxLife);
			}
			int num = Math.Max(0, (int)Math.Floor((double)value));
			base.GetText(1).SetText(num.ToString() + "/" + this.MaxLife.ToString(), true);
		}

		// Token: 0x06037FCF RID: 229327 RVA: 0x00E2EB7B File Offset: 0x00E2CD7B
		private void OnTweenerEnd()
		{
			if (this.TweenerDamage != null)
			{
				this.TweenerDamage = null;
			}
		}

		// Token: 0x04020031 RID: 131121
		protected PhantomArenaHeadItem RoleHead;

		// Token: 0x04020032 RID: 131122
		protected PhantomArenaBattleDetailsViewProxy ViewProxy;

		// Token: 0x04020033 RID: 131123
		protected ULTweener TweenerDamage;

		// Token: 0x04020034 RID: 131124
		protected FLTweenFloatSetterDynamic DelegateDamage;

		// Token: 0x04020035 RID: 131125
		public bool IsOwn;

		// Token: 0x04020036 RID: 131126
		protected int MaxLife;

		// Token: 0x04020037 RID: 131127
		protected int CurLife;

		// Token: 0x04020038 RID: 131128
		protected int LastShieldNum;

		// Token: 0x0200B5CF RID: 46543
		[NullableContext(0)]
		private class ERoleItem
		{
			// Token: 0x04038418 RID: 230424
			public const int HeadItem = 0;

			// Token: 0x04038419 RID: 230425
			public const int LifeNum = 1;

			// Token: 0x0403841A RID: 230426
			public const int PanelHit = 2;

			// Token: 0x0403841B RID: 230427
			public const int HitNum = 3;

			// Token: 0x0403841C RID: 230428
			public const int ShieldItem = 4;

			// Token: 0x0403841D RID: 230429
			public const int ShieldNum = 5;

			// Token: 0x0403841E RID: 230430
			public const int ShieldReduceNum = 6;
		}
	}
}
