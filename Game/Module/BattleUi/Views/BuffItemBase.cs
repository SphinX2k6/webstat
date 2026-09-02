using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FF6 RID: 24566
	public abstract class BuffItemBase : UiPanelBase
	{
		// Token: 0x0603DDEE RID: 253422
		[NullableContext(2)]
		public abstract void Activate(GameplayCue buffCueConfig, IActiveBuff buff, bool playAnim = false, int buffNum = 0);

		// Token: 0x0603DDEF RID: 253423 RVA: 0x00FC6B14 File Offset: 0x00FC4D14
		public virtual void SetNum(int num)
		{
		}

		// Token: 0x0603DDF0 RID: 253424
		public abstract void Tick(float delta);

		// Token: 0x0603DDF1 RID: 253425
		public abstract bool TickHiding(float delta);

		// Token: 0x0603DDF2 RID: 253426
		public abstract void Deactivate();

		// Token: 0x0603DDF3 RID: 253427
		public abstract void DeactivateWithCloseAnim();

		// Token: 0x0603DDF4 RID: 253428 RVA: 0x00FC6B16 File Offset: 0x00FC4D16
		public virtual void PlayAddBuffAnim()
		{
		}
	}
}
