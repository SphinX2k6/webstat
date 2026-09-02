using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x02005609 RID: 22025
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class PhantomArenaBattleGuideDataBase<[Nullable(0)] T> : IPhantomArenaTabViewModelBase where T : IBvbPlayerOperationType
	{
		// Token: 0x17009061 RID: 36961
		// (get) Token: 0x06038282 RID: 230018 RVA: 0x00E38CFD File Offset: 0x00E36EFD
		// (set) Token: 0x06038283 RID: 230019 RVA: 0x00E38D05 File Offset: 0x00E36F05
		public string Tips { get; set; }

		// Token: 0x17009062 RID: 36962
		// (get) Token: 0x06038284 RID: 230020 RVA: 0x00E38D0E File Offset: 0x00E36F0E
		// (set) Token: 0x06038285 RID: 230021 RVA: 0x00E38D16 File Offset: 0x00E36F16
		public EBvbPlayerOperationType Type { get; set; }

		// Token: 0x06038286 RID: 230022 RVA: 0x00E38D1F File Offset: 0x00E36F1F
		public PhantomArenaBattleGuideDataBase(EBvbPlayerOperationType type, BvbPlayerOperationConstraint param)
		{
			this.Type = type;
			this.Param = param;
			this.Tips = this.Param.TidPromptTxt;
			this.Data = (T)((object)this.Param.EnableOperation);
		}

		// Token: 0x06038287 RID: 230023
		public abstract bool CheckCanExecute(params object[] params_);

		// Token: 0x06038288 RID: 230024 RVA: 0x00E38D5C File Offset: 0x00E36F5C
		public virtual void CacheGuideData(params object[] params_)
		{
		}

		// Token: 0x06038289 RID: 230025 RVA: 0x00E38D5E File Offset: 0x00E36F5E
		public virtual bool CheckCanFinishGuide(params object[] params_)
		{
			return true;
		}

		// Token: 0x0402015A RID: 131418
		protected T Data;

		// Token: 0x0402015D RID: 131421
		protected BvbPlayerOperationConstraint Param;
	}
}
