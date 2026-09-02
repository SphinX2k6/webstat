using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Panel;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area.Hand
{
	// Token: 0x02005630 RID: 22064
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaRoleHpTween
	{
		// Token: 0x060383F7 RID: 230391 RVA: 0x00E3E36E File Offset: 0x00E3C56E
		public PhantomArenaRoleHpTween()
		{
			this.Delegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.TweenCall));
		}

		// Token: 0x060383F8 RID: 230392 RVA: 0x00E3E38D File Offset: 0x00E3C58D
		private void TweenCall(float value)
		{
			this.RoleItem.RefreshLifeNumTween(value, this.MaxLifeNum);
		}

		// Token: 0x060383F9 RID: 230393 RVA: 0x00E3E3A1 File Offset: 0x00E3C5A1
		private void OnTweenerEnd()
		{
			if (this.Tweener != null)
			{
				this.Tweener = null;
			}
		}

		// Token: 0x060383FA RID: 230394 RVA: 0x00E3E3B2 File Offset: 0x00E3C5B2
		public void SetRoleItem(PhantomArenaRoleItem roleItem)
		{
			this.RoleItem = roleItem;
		}

		// Token: 0x060383FB RID: 230395 RVA: 0x00E3E3BC File Offset: 0x00E3C5BC
		public UniTask InitCurveDamage()
		{
			PhantomArenaRoleHpTween.<InitCurveDamage>d__9 <InitCurveDamage>d__;
			<InitCurveDamage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurveDamage>d__.<>4__this = this;
			<InitCurveDamage>d__.<>1__state = -1;
			<InitCurveDamage>d__.<>t__builder.Start<PhantomArenaRoleHpTween.<InitCurveDamage>d__9>(ref <InitCurveDamage>d__);
			return <InitCurveDamage>d__.<>t__builder.Task;
		}

		// Token: 0x060383FC RID: 230396 RVA: 0x00E3E400 File Offset: 0x00E3C600
		public void PlayHpTween(int oldLife, int lifeNum, int maxLifeNum)
		{
			this.MaxLifeNum = maxLifeNum;
			this.RoleItem.RefreshLifeNumTweenStart(lifeNum, maxLifeNum);
			this.RoleItem.RefreshLifeNumTween((float)oldLife, this.MaxLifeNum);
			this.Tweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.Delegate, (float)oldLife, (float)lifeNum, 0.4f, 0f, LTweenEase.OutCubic);
			if (this.Tweener != null)
			{
				this.Tweener.SetEase(LTweenEase.CurveFloat);
				this.Tweener.SetCurveFloat(this.CurveDamage);
				this.Tweener.OnCompleteCallBack.Bind(new Action(this.OnTweenerEnd));
			}
		}

		// Token: 0x060383FD RID: 230397 RVA: 0x00E3E49D File Offset: 0x00E3C69D
		public void Clear()
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.TweenCall));
			this.CurveDamage = null;
		}

		// Token: 0x040201C2 RID: 131522
		protected PhantomArenaRoleItem RoleItem;

		// Token: 0x040201C3 RID: 131523
		protected int MaxLifeNum;

		// Token: 0x040201C4 RID: 131524
		protected UCurveFloat CurveDamage;

		// Token: 0x040201C5 RID: 131525
		protected ULTweener Tweener;

		// Token: 0x040201C6 RID: 131526
		protected FLTweenFloatSetterDynamic Delegate;
	}
}
