using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x02005612 RID: 22034
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaBattleGuideMagicUseCardFromMonster : PhantomArenaBattleGuideDataBase<IBvbChangeBoardCard>
	{
		// Token: 0x060382A3 RID: 230051 RVA: 0x00E390B1 File Offset: 0x00E372B1
		public PhantomArenaBattleGuideMagicUseCardFromMonster(EBvbPlayerOperationType type, BvbPlayerOperationConstraint param) : base(type, param)
		{
		}

		// Token: 0x060382A4 RID: 230052 RVA: 0x00E390BC File Offset: 0x00E372BC
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
				string message = "PhantomArenaBattleGuideMagicUseCardFromMonster invalid value";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("battleIndex", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return this.Data.BoardPosIndexList == null || this.Data.BoardPosIndexList.Contains(num + 1);
		}
	}
}
