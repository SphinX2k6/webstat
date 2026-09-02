using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.UniversalComponents
{
	// Token: 0x02006252 RID: 25170
	[NullableContext(1)]
	public interface IActivityTab
	{
		// Token: 0x17009C28 RID: 39976
		// (get) Token: 0x0603F717 RID: 259863
		// (set) Token: 0x0603F718 RID: 259864
		IActivityRewardDataPage TabData { get; set; }

		// Token: 0x17009C29 RID: 39977
		// (get) Token: 0x0603F719 RID: 259865
		// (set) Token: 0x0603F71A RID: 259866
		Action<int> TabFunction { get; set; }

		// Token: 0x17009C2A RID: 39978
		// (get) Token: 0x0603F71B RID: 259867
		// (set) Token: 0x0603F71C RID: 259868
		Func<bool, int, bool> TabCanExecuteFunction { get; set; }
	}
}
