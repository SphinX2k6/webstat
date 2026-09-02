using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x02005614 RID: 22036
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaBattleGuideRecycleCardFromHand : PhantomArenaBattleGuideDataBase<IBvbRecycleHandCard>
	{
		// Token: 0x060382B0 RID: 230064 RVA: 0x00E393E8 File Offset: 0x00E375E8
		public PhantomArenaBattleGuideRecycleCardFromHand(EBvbPlayerOperationType type, BvbPlayerOperationConstraint param) : base(type, param)
		{
		}

		// Token: 0x060382B1 RID: 230065 RVA: 0x00E393F4 File Offset: 0x00E375F4
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
				string message = "PhantomArenaBattleGuideRecycleCardFromHand invalid value";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("battleIndex", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return this.Data.HandCardIndex == null || this.Data.HandCardIndex.Value - 1 == num;
		}
	}
}
