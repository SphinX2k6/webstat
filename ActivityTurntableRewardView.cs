using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020015F8 RID: 5624
public class ActivityTurntableRewardView : UiViewBase
{
	// Token: 0x06009E84 RID: 40580 RVA: 0x00297B52 File Offset: 0x00295D52
	[NullableContext(1)]
	public ActivityTurntableRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009E85 RID: 40581 RVA: 0x00297B5B File Offset: 0x00295D5B
	protected override void OnAfterShow()
	{
		base.CloseMe(delegate(bool _)
		{
			Action closeFunc = this.CloseFunc;
			if (closeFunc == null)
			{
				return;
			}
			closeFunc();
		});
	}

	// Token: 0x06009E86 RID: 40582 RVA: 0x00297B6F File Offset: 0x00295D6F
	protected override void OnStart()
	{
		this.CloseFunc = (this.OpenParam as Action);
	}

	// Token: 0x040048E9 RID: 18665
	[Nullable(2)]
	private Action CloseFunc;
}
