using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x02005618 RID: 22040
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaBattleGuideUseFieldCardSkill : PhantomArenaBattleGuideDataBase<IBvbUseFieldCardSkill>
	{
		// Token: 0x060382B8 RID: 230072 RVA: 0x00E39663 File Offset: 0x00E37863
		public PhantomArenaBattleGuideUseFieldCardSkill(EBvbPlayerOperationType type, BvbPlayerOperationConstraint param) : base(type, param)
		{
		}

		// Token: 0x060382B9 RID: 230073 RVA: 0x00E39674 File Offset: 0x00E37874
		public override bool CheckCanExecute(params object[] params_)
		{
			return true;
		}

		// Token: 0x060382BA RID: 230074 RVA: 0x00E39677 File Offset: 0x00E37877
		public override void CacheGuideData(params object[] params_)
		{
			if (params_.Length >= 2)
			{
				this.CardId = (int)params_[0];
				this.SkillId = (int)params_[1];
			}
		}

		// Token: 0x060382BB RID: 230075 RVA: 0x00E3969C File Offset: 0x00E3789C
		public override bool CheckCanFinishGuide(params object[] params_)
		{
			if (params_.Length < 2)
			{
				return false;
			}
			bool flag = (EPhantomArenaSkillInteractExecuteResult)params_[0] != EPhantomArenaSkillInteractExecuteResult.Success;
			IPhantomArenaGuideCardSkillData phantomArenaGuideCardSkillData = (IPhantomArenaGuideCardSkillData)params_[1];
			return !flag && (phantomArenaGuideCardSkillData.BuffType == null || !PhantomArenaSkillInteractFactory.HasSkillInteract((int)phantomArenaGuideCardSkillData.BuffType.Value)) && phantomArenaGuideCardSkillData.CardId == this.CardId;
		}

		// Token: 0x04020168 RID: 131432
		protected int CardId = -1;

		// Token: 0x04020169 RID: 131433
		protected int SkillId;
	}
}
