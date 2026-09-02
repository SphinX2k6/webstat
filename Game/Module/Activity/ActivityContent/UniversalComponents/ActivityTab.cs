using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.UniversalComponents
{
	// Token: 0x02006253 RID: 25171
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityTab : IActivityTab
	{
		// Token: 0x17009C2B RID: 39979
		// (get) Token: 0x0603F71D RID: 259869 RVA: 0x01043B58 File Offset: 0x01041D58
		// (set) Token: 0x0603F71E RID: 259870 RVA: 0x01043B60 File Offset: 0x01041D60
		public IActivityRewardDataPage TabData { get; set; }

		// Token: 0x17009C2C RID: 39980
		// (get) Token: 0x0603F71F RID: 259871 RVA: 0x01043B69 File Offset: 0x01041D69
		// (set) Token: 0x0603F720 RID: 259872 RVA: 0x01043B71 File Offset: 0x01041D71
		public Action<int> TabFunction { get; set; }

		// Token: 0x17009C2D RID: 39981
		// (get) Token: 0x0603F721 RID: 259873 RVA: 0x01043B7A File Offset: 0x01041D7A
		// (set) Token: 0x0603F722 RID: 259874 RVA: 0x01043B82 File Offset: 0x01041D82
		public Func<bool, int, bool> TabCanExecuteFunction { get; set; }
	}
}
