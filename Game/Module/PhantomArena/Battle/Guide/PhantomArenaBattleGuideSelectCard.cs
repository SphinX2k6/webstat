using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x02005616 RID: 22038
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaBattleGuideSelectCard : PhantomArenaBattleGuideDataBase<IBvbSelectCard>
	{
		// Token: 0x060382B4 RID: 230068 RVA: 0x00E394F6 File Offset: 0x00E376F6
		public PhantomArenaBattleGuideSelectCard(EBvbPlayerOperationType type, BvbPlayerOperationConstraint param) : base(type, param)
		{
		}

		// Token: 0x060382B5 RID: 230069 RVA: 0x00E39500 File Offset: 0x00E37700
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
				string message = "PhantomArenaBattleGuideRecycleCardFromMonster invalid value";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cardId", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return this.Data.CardIdList == null || this.Data.CardIdList.Contains(num);
		}
	}
}
