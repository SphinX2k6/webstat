using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x02005619 RID: 22041
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaBattleGuideUseItemCardSkill : PhantomArenaBattleGuideDataBase<IBvbUseItemCardSkill>
	{
		// Token: 0x060382BC RID: 230076 RVA: 0x00E396FE File Offset: 0x00E378FE
		public PhantomArenaBattleGuideUseItemCardSkill(EBvbPlayerOperationType type, BvbPlayerOperationConstraint param) : base(type, param)
		{
		}

		// Token: 0x060382BD RID: 230077 RVA: 0x00E39710 File Offset: 0x00E37910
		public override bool CheckCanExecute(params object[] params_)
		{
			if (params_.Length < 1)
			{
				return false;
			}
			int num = (int)params_[0];
			if (num == -1)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "PhantomArenaBattleGuideUseItemCardSkill invalid value";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("battleIndex", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return this.Data.BoardPosIndexList == null || this.Data.BoardPosIndexList.Contains(num + 1);
		}

		// Token: 0x060382BE RID: 230078 RVA: 0x00E39786 File Offset: 0x00E37986
		public override void CacheGuideData(params object[] params_)
		{
			if (params_.Length >= 1)
			{
				this.CardId = (int)params_[0];
			}
		}

		// Token: 0x060382BF RID: 230079 RVA: 0x00E3979C File Offset: 0x00E3799C
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

		// Token: 0x0402016A RID: 131434
		protected int CardId = -1;
	}
}
