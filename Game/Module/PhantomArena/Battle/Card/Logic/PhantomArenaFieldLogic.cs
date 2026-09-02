using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Card.Logic
{
	// Token: 0x02005626 RID: 22054
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaFieldLogic : PhantomArenaCardLogic
	{
		// Token: 0x06038354 RID: 230228 RVA: 0x00E3B74B File Offset: 0x00E3994B
		public PhantomArenaFieldLogic(PhantomArenaCard card, PhantomArenaBattleProxy viewProxy) : base(card, viewProxy)
		{
		}

		// Token: 0x06038355 RID: 230229 RVA: 0x00E3B755 File Offset: 0x00E39955
		public override Tuple<bool, EPhantomCardSettingFailReason> CheckFunctionalSettingCondition(PhantomArenaCard oldCard)
		{
			if (oldCard != null)
			{
				return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.ExistCard);
			}
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(true, EPhantomCardSettingFailReason.None);
		}

		// Token: 0x06038356 RID: 230230 RVA: 0x00E3B771 File Offset: 0x00E39971
		public override Tuple<bool, EPhantomCardSettingFailReason> CheckMonsterSettingCondition(PhantomArenaCard oldCard)
		{
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.FieldCantDragToMonster);
		}

		// Token: 0x06038357 RID: 230231 RVA: 0x00E3B77E File Offset: 0x00E3997E
		protected override Tuple<bool, EPhantomCardSettingFailReason> OnCheckRecycleSettingConditionFromHead()
		{
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.FieldCantDragToRecycle);
		}

		// Token: 0x06038358 RID: 230232 RVA: 0x00E3B78B File Offset: 0x00E3998B
		protected override Tuple<bool, EPhantomCardSettingFailReason> OnCheckRecycleSettingConditionFromFunctional()
		{
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.FieldCantDragToRecycle);
		}
	}
}
