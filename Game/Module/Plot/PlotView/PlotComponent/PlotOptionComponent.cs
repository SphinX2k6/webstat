using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053EF RID: 21487
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotOptionComponent
	{
		// Token: 0x06036D93 RID: 224659 RVA: 0x00DE8058 File Offset: 0x00DE6258
		public void Init(PlotOptionComponentContext context)
		{
			this.OptionsRefreshDelegate = context.OptionsRefreshDelegate;
			this.OptionsShowDelegate = context.OptionsShowDelegate;
			this.OptionsHideDelegate = context.OptionsHideDelegate;
		}

		// Token: 0x06036D94 RID: 224660 RVA: 0x00DE807E File Offset: 0x00DE627E
		public void RefreshOptions(ITalkOption[] options)
		{
			this.Options = new List<ITalkOption>(options);
			Action<ITalkOption[]> optionsRefreshDelegate = this.OptionsRefreshDelegate;
			if (optionsRefreshDelegate == null)
			{
				return;
			}
			optionsRefreshDelegate(options);
		}

		// Token: 0x06036D95 RID: 224661 RVA: 0x00DE809D File Offset: 0x00DE629D
		public void ShowOptions()
		{
			if (this.IsVisible)
			{
				return;
			}
			Action optionsShowDelegate = this.OptionsShowDelegate;
			if (optionsShowDelegate != null)
			{
				optionsShowDelegate();
			}
			this.IsVisible = true;
		}

		// Token: 0x06036D96 RID: 224662 RVA: 0x00DE80C0 File Offset: 0x00DE62C0
		public void HideOptions()
		{
			if (!this.IsVisible)
			{
				return;
			}
			Action optionsHideDelegate = this.OptionsHideDelegate;
			if (optionsHideDelegate != null)
			{
				optionsHideDelegate();
			}
			this.IsVisible = false;
		}

		// Token: 0x06036D97 RID: 224663 RVA: 0x00DE80E4 File Offset: 0x00DE62E4
		public void SelectOption(int optionIndex)
		{
			List<ITalkOption> options = this.Options;
			if (optionIndex >= options.Count)
			{
				return;
			}
			ITalkOption talkOption;
			if (!options.TryGetValue(optionIndex, out talkOption))
			{
				return;
			}
			ControllerBase<FlowController>.Instance.FlowShowTalk.SelectOption(optionIndex, talkOption.Actions);
		}

		// Token: 0x0401F938 RID: 129336
		private bool IsVisible;

		// Token: 0x0401F939 RID: 129337
		protected List<ITalkOption> Options = new List<ITalkOption>();

		// Token: 0x0401F93A RID: 129338
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<ITalkOption[]> OptionsRefreshDelegate;

		// Token: 0x0401F93B RID: 129339
		[Nullable(2)]
		private Action OptionsShowDelegate;

		// Token: 0x0401F93C RID: 129340
		[Nullable(2)]
		private Action OptionsHideDelegate;
	}
}
