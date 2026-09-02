using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x02006907 RID: 26887
	public abstract class DropCatchGameplayPoolPanelBase : UiPanelBase
	{
		// Token: 0x04025368 RID: 152424
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DropCatchGameplayPoolPanelBase> OnRecycle;
	}
}
