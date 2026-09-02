using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x02005608 RID: 22024
	[NullableContext(1)]
	public interface IPhantomArenaTabViewModelBase
	{
		// Token: 0x1700905F RID: 36959
		// (get) Token: 0x0603827B RID: 230011
		// (set) Token: 0x0603827C RID: 230012
		string Tips { get; set; }

		// Token: 0x17009060 RID: 36960
		// (get) Token: 0x0603827D RID: 230013
		// (set) Token: 0x0603827E RID: 230014
		EBvbPlayerOperationType Type { get; set; }

		// Token: 0x0603827F RID: 230015
		bool CheckCanExecute(params object[] params_);

		// Token: 0x06038280 RID: 230016
		void CacheGuideData(params object[] params_);

		// Token: 0x06038281 RID: 230017
		bool CheckCanFinishGuide(params object[] params_);
	}
}
