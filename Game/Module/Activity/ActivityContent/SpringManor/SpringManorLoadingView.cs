using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006353 RID: 25427
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorLoadingView : LoadingViewBase
	{
		// Token: 0x0603FD85 RID: 261509 RVA: 0x01060BA7 File Offset: 0x0105EDA7
		public SpringManorLoadingView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FD86 RID: 261510 RVA: 0x01060BBC File Offset: 0x0105EDBC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(3, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(4, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(5, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(6, typeof(UUINiagara))
			};
		}

		// Token: 0x0603FD87 RID: 261511 RVA: 0x01060C70 File Offset: 0x0105EE70
		protected override void OnStart()
		{
			base.OnStart();
			this.SpineList.Add(new SpineAnimationQueue(base.GetSpine(2)));
			this.SpineList.Add(new SpineAnimationQueue(base.GetSpine(3)));
			this.SpineList.Add(new SpineAnimationQueue(base.GetSpine(4)));
			this.SpineList.Add(new SpineAnimationQueue(base.GetSpine(5)));
			foreach (SpineAnimationQueue spineAnimationQueue in this.SpineList)
			{
				spineAnimationQueue.PushAnimation(0, "start", false);
				spineAnimationQueue.PushAnimation(0, "idle", true);
			}
			this.NiagaraBar = base.GetUiNiagara(6);
		}

		// Token: 0x0603FD88 RID: 261512 RVA: 0x01060D44 File Offset: 0x0105EF44
		protected override void UpdateProgressRate(float rate)
		{
			UUINiagara niagaraBar = this.NiagaraBar;
			if (niagaraBar == null)
			{
				return;
			}
			niagaraBar.SetNiagaraVarFloat("Dissolve", rate);
		}

		// Token: 0x0603FD89 RID: 261513 RVA: 0x01060D5C File Offset: 0x0105EF5C
		protected override void UpdateShowTipsUi(string title, string tips)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(tips);
		}

		// Token: 0x0603FD8A RID: 261514 RVA: 0x01060D70 File Offset: 0x0105EF70
		protected override void UpdateProgressValue(float value)
		{
		}

		// Token: 0x04023E28 RID: 146984
		private readonly List<SpineAnimationQueue> SpineList = new List<SpineAnimationQueue>();

		// Token: 0x04023E29 RID: 146985
		[Nullable(2)]
		private UUINiagara NiagaraBar;
	}
}
