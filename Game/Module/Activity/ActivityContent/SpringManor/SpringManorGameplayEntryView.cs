using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006350 RID: 25424
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorGameplayEntryView : UiTickViewBase
	{
		// Token: 0x0603FD6F RID: 261487 RVA: 0x01060410 File Offset: 0x0105E610
		public SpringManorGameplayEntryView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FD70 RID: 261488 RVA: 0x01060424 File Offset: 0x0105E624
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickClose))
			};
		}

		// Token: 0x0603FD71 RID: 261489 RVA: 0x010604E4 File Offset: 0x0105E6E4
		protected override UniTask OnBeforeStartAsync()
		{
			SpringManorGameplayEntryView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorGameplayEntryView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FD72 RID: 261490 RVA: 0x01060527 File Offset: 0x0105E727
		protected override void OnBeforeShow()
		{
			this.PauseTimeDilation();
		}

		// Token: 0x0603FD73 RID: 261491 RVA: 0x0106052F File Offset: 0x0105E72F
		protected override void OnBeforeHide()
		{
			this.ResumeTimeDilation();
		}

		// Token: 0x0603FD74 RID: 261492 RVA: 0x01060537 File Offset: 0x0105E737
		protected override void OnStart()
		{
			PopupCaptionItem caption = this.Caption;
			if (caption == null)
			{
				return;
			}
			caption.SetCloseCallBack(new Action(this.OnClickClose));
		}

		// Token: 0x0603FD75 RID: 261493 RVA: 0x01060555 File Offset: 0x0105E755
		protected void PauseTimeDilation()
		{
			Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("SpringManorGameplayEntryView");
		}

		// Token: 0x0603FD76 RID: 261494 RVA: 0x01060566 File Offset: 0x0105E766
		protected void ResumeTimeDilation()
		{
			Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("SpringManorGameplayEntryView");
		}

		// Token: 0x0603FD77 RID: 261495 RVA: 0x01060578 File Offset: 0x0105E778
		protected override void OnTick(float delta)
		{
			if (this.Timer > 0.0)
			{
				this.Timer -= (double)delta;
				return;
			}
			this.Timer = 500.0;
			foreach (FunctionItem functionItem in this.FunctionItems)
			{
				functionItem.Refresh();
			}
		}

		// Token: 0x0603FD78 RID: 261496 RVA: 0x010605F8 File Offset: 0x0105E7F8
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x04023E19 RID: 146969
		private const int TICK_INTERVAL = 500;

		// Token: 0x04023E1A RID: 146970
		private readonly List<FunctionItem> FunctionItems = new List<FunctionItem>();

		// Token: 0x04023E1B RID: 146971
		[Nullable(2)]
		private PopupCaptionItem Caption;

		// Token: 0x04023E1C RID: 146972
		private double Timer;
	}
}
