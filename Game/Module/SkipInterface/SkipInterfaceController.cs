using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.SkipInterface
{
	// Token: 0x02004F20 RID: 20256
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class SkipInterfaceController : ControllerBase<SkipInterfaceController>
	{
		// Token: 0x0603457E RID: 214398 RVA: 0x00D195C7 File Offset: 0x00D177C7
		protected override bool OnInit()
		{
			this.AddEvents();
			return true;
		}

		// Token: 0x0603457F RID: 214399 RVA: 0x00D195D0 File Offset: 0x00D177D0
		protected override bool OnClear()
		{
			this.RemoveEvents();
			SkipTaskManager.Clear();
			return true;
		}

		// Token: 0x06034580 RID: 214400 RVA: 0x00D195DE File Offset: 0x00D177DE
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EUiViewName>(EEventName.OpenViewBegined, this.OnPreOpenView);
			Singleton<EventSystem>.Instance.Add(EEventName.EnterGameSuccess, new Action(this.EnterGameSuccess));
		}

		// Token: 0x06034581 RID: 214401 RVA: 0x00D1960C File Offset: 0x00D1780C
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName>(EEventName.OpenViewBegined, this.OnPreOpenView);
			Singleton<EventSystem>.Instance.Remove(EEventName.EnterGameSuccess, new Action(this.EnterGameSuccess));
		}

		// Token: 0x06034582 RID: 214402 RVA: 0x00D1963A File Offset: 0x00D1783A
		private void EnterGameSuccess()
		{
			this.RequestAccessPathConfig();
		}

		// Token: 0x06034583 RID: 214403 RVA: 0x00D19644 File Offset: 0x00D17844
		private UniTask RequestAccessPathConfig()
		{
			SkipInterfaceController.<RequestAccessPathConfig>d__6 <RequestAccessPathConfig>d__;
			<RequestAccessPathConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestAccessPathConfig>d__.<>1__state = -1;
			<RequestAccessPathConfig>d__.<>t__builder.Start<SkipInterfaceController.<RequestAccessPathConfig>d__6>(ref <RequestAccessPathConfig>d__);
			return <RequestAccessPathConfig>d__.<>t__builder.Task;
		}

		// Token: 0x06034584 RID: 214404 RVA: 0x00D1967F File Offset: 0x00D1787F
		public SkipInterfaceController()
		{
			Action<EUiViewName> onPreOpenView;
			if ((onPreOpenView = SkipInterfaceController.<>O.<0>__CheckContainRingView) == null)
			{
				onPreOpenView = (SkipInterfaceController.<>O.<0>__CheckContainRingView = new Action<EUiViewName>(SkipTaskManager.CheckContainRingView));
			}
			this.OnPreOpenView = onPreOpenView;
			base..ctor();
		}

		// Token: 0x0401E2FF RID: 123647
		private readonly Action<EUiViewName> OnPreOpenView;

		// Token: 0x0200AF6C RID: 44908
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04036706 RID: 222982
			[Nullable(0)]
			public static Action<EUiViewName> <0>__CheckContainRingView;
		}
	}
}
