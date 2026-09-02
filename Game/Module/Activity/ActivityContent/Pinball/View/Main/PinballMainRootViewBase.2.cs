using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065FC RID: 26108
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class PinballMainRootViewBase<TViewModel> : PinballMainRootViewBase
	{
		// Token: 0x060413AA RID: 267178 RVA: 0x010BB393 File Offset: 0x010B9593
		[NullableContext(1)]
		public PinballMainRootViewBase(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x17009F37 RID: 40759
		// (get) Token: 0x060413AB RID: 267179 RVA: 0x010BB39C File Offset: 0x010B959C
		// (set) Token: 0x060413AC RID: 267180 RVA: 0x010BB3A9 File Offset: 0x010B95A9
		public new TViewModel ViewModel
		{
			get
			{
				return (TViewModel)((object)this.ViewModel);
			}
			set
			{
				this.ViewModel = value;
			}
		}
	}
}
