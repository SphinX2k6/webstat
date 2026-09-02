using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x0200690E RID: 26894
	[NullableContext(2)]
	[Nullable(0)]
	public class DropCatchGameplayRoleFxView : UiPanelBase
	{
		// Token: 0x06042CB8 RID: 273592 RVA: 0x011249B8 File Offset: 0x01122BB8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUINiagara)),
				new ValueTuple<int, Type>(1, typeof(UUINiagara)),
				new ValueTuple<int, Type>(2, typeof(UUINiagara)),
				new ValueTuple<int, Type>(3, typeof(UUINiagara))
			};
		}

		// Token: 0x06042CB9 RID: 273593 RVA: 0x01124A28 File Offset: 0x01122C28
		protected override void OnStart()
		{
			this.ResetView();
			this.Delegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.OnTweenUpdate));
		}

		// Token: 0x06042CBA RID: 273594 RVA: 0x01124A47 File Offset: 0x01122C47
		public void PlayShield()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(0);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(true);
			}
			this.PlayShieldTween(0f, 1f, this.TWEENTIME, LTweenEase.InOutSine, null);
		}

		// Token: 0x06042CBB RID: 273595 RVA: 0x01124A75 File Offset: 0x01122C75
		public void PlayAdd()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(1);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(true);
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(1);
			if (uiNiagara2 == null)
			{
				return;
			}
			uiNiagara2.ActivateSystem(true);
		}

		// Token: 0x06042CBC RID: 273596 RVA: 0x01124A9C File Offset: 0x01122C9C
		public void PlayShieldEnd()
		{
			this.PlayShieldTween(1f, 0f, this.TWEENTIME, LTweenEase.InOutSine, delegate
			{
				UUINiagara uiNiagara = base.GetUiNiagara(0);
				if (uiNiagara == null)
				{
					return;
				}
				uiNiagara.SetUIActive(false);
			});
		}

		// Token: 0x06042CBD RID: 273597 RVA: 0x01124AC2 File Offset: 0x01122CC2
		public void PlaySpeedUp()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(3);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(true);
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(3);
			if (uiNiagara2 == null)
			{
				return;
			}
			uiNiagara2.ActivateSystem(true);
		}

		// Token: 0x06042CBE RID: 273598 RVA: 0x01124AE9 File Offset: 0x01122CE9
		public void HideSpeedUp()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(3);
			if (uiNiagara == null)
			{
				return;
			}
			uiNiagara.SetUIActive(false);
		}

		// Token: 0x06042CBF RID: 273599 RVA: 0x01124AFD File Offset: 0x01122CFD
		private void OnTweenUpdate(float value)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(0);
			if (uiNiagara == null)
			{
				return;
			}
			uiNiagara.SetNiagaraVarFloat("Dissolve", value);
		}

		// Token: 0x06042CC0 RID: 273600 RVA: 0x01124B18 File Offset: 0x01122D18
		private void PlayShieldTween(float startValue, float endValue, float tweenTime, LTweenEase tweenEase, Action callback = null)
		{
			this.KillTweener();
			this.Tweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.Delegate, startValue, endValue, tweenTime, 0f, tweenEase);
			this.Tweener.OnCompleteCallBack.Bind(delegate()
			{
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			});
		}

		// Token: 0x06042CC1 RID: 273601 RVA: 0x01124B75 File Offset: 0x01122D75
		private void KillTweener()
		{
			if (this.Tweener != null)
			{
				this.Tweener.Kill(false);
				this.Tweener = null;
			}
		}

		// Token: 0x06042CC2 RID: 273602 RVA: 0x01124B92 File Offset: 0x01122D92
		protected override void OnBeforeDestroy()
		{
			this.KillTweener();
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.OnTweenUpdate));
		}

		// Token: 0x06042CC3 RID: 273603 RVA: 0x01124BAC File Offset: 0x01122DAC
		public void ResetView()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(0);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(false);
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(1);
			if (uiNiagara2 != null)
			{
				uiNiagara2.SetUIActive(false);
			}
			UUINiagara uiNiagara3 = base.GetUiNiagara(2);
			if (uiNiagara3 != null)
			{
				uiNiagara3.SetUIActive(false);
			}
			UUINiagara uiNiagara4 = base.GetUiNiagara(3);
			if (uiNiagara4 == null)
			{
				return;
			}
			uiNiagara4.SetUIActive(false);
		}

		// Token: 0x04025384 RID: 152452
		private readonly float TWEENTIME = 0.4f;

		// Token: 0x04025385 RID: 152453
		private ULTweener Tweener;

		// Token: 0x04025386 RID: 152454
		private FLTweenFloatSetterDynamic Delegate;
	}
}
