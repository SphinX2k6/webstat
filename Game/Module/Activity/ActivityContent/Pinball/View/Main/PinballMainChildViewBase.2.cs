using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065F9 RID: 26105
	[NullableContext(2)]
	[Nullable(0)]
	public class PinballMainChildViewBase<TViewModel> : PinballMainChildViewBase
	{
		// Token: 0x17009F36 RID: 40758
		// (get) Token: 0x0604137A RID: 267130 RVA: 0x010BAAEF File Offset: 0x010B8CEF
		// (set) Token: 0x0604137B RID: 267131 RVA: 0x010BAAFC File Offset: 0x010B8CFC
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
