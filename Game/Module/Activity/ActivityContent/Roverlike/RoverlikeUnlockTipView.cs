using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006436 RID: 25654
	public class RoverlikeUnlockTipView : UiViewBase
	{
		// Token: 0x06040687 RID: 263815 RVA: 0x0108305F File Offset: 0x0108125F
		[NullableContext(1)]
		public RoverlikeUnlockTipView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040688 RID: 263816 RVA: 0x01083068 File Offset: 0x01081268
		protected override void OnAfterShow()
		{
			base.CloseMe(null);
		}
	}
}
