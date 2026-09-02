using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CB9 RID: 23737
	[NullableContext(2)]
	[Nullable(0)]
	public class FloatLineFloatTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE39 RID: 245305 RVA: 0x00F2D90A File Offset: 0x00F2BB0A
		[NullableContext(1)]
		public FloatLineFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE3A RID: 245306 RVA: 0x00F2D914 File Offset: 0x00F2BB14
		protected override void OnStart()
		{
			base.OnStart();
			this.TextAnimDataComp = (base.MainText.GetOwner().GetComponentByClass(UUIEffectTextAnimation.StaticClass()) as UUIEffectTextAnimation);
			this.TextPlayTweenComp = (base.ExtraText.GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			UUIEffectTextAnimation textAnimDataComp = this.TextAnimDataComp;
			if (textAnimDataComp != null)
			{
				textAnimDataComp.SetSelectorOffset(1f);
			}
			if (this.TextPlayTweenComp != null)
			{
				double num = 0.5 * this.TickDuration;
				double num2 = ((double)this.TextPlayTweenComp.GetPlayTween().duration > num) ? num : ((double)this.TextPlayTweenComp.GetPlayTween().duration);
				this.TextPlayTweenComp.GetPlayTween().duration = (float)num2;
				ULGUIPlayTweenComponent textPlayTweenComp = this.TextPlayTweenComp;
				if (textPlayTweenComp == null)
				{
					return;
				}
				textPlayTweenComp.Play();
			}
		}

		// Token: 0x04021AB0 RID: 137904
		private UUIEffectTextAnimation TextAnimDataComp;

		// Token: 0x04021AB1 RID: 137905
		private ULGUIPlayTweenComponent TextPlayTweenComp;
	}
}
