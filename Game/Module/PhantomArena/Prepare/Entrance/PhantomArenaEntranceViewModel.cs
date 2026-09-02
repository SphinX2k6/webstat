using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054D2 RID: 21714
	public class PhantomArenaEntranceViewModel : ViewModelBase<EViewData>, IPhantomArenaTabViewModelBase, IStaticVariableResetter
	{
		// Token: 0x060374FC RID: 226556 RVA: 0x00E084AA File Offset: 0x00E066AA
		public PhantomArenaEntranceViewModel()
		{
			this.DataMap[EViewData.TabViewName] = EPhantomArenaChildViewName.PhantomArenaEntranceGymTabView;
		}

		// Token: 0x060374FD RID: 226557 RVA: 0x00E084C4 File Offset: 0x00E066C4
		static PhantomArenaEntranceViewModel()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PhantomArenaEntranceViewModel.CreateStaticDefaultValue), new Action(PhantomArenaEntranceViewModel.ResetStaticDefaultValue));
		}

		// Token: 0x060374FE RID: 226558 RVA: 0x00E084E3 File Offset: 0x00E066E3
		public static void CreateStaticDefaultValue()
		{
			PhantomArenaEntranceViewModel.tabViewList = new EPhantomArenaChildViewName[]
			{
				EPhantomArenaChildViewName.PhantomArenaEntranceGymTabView,
				EPhantomArenaChildViewName.PhantomArenaEntranceRepeatTabView
			};
		}

		// Token: 0x060374FF RID: 226559 RVA: 0x00E084F8 File Offset: 0x00E066F8
		public static void ResetStaticDefaultValue()
		{
			PhantomArenaEntranceViewModel.tabViewList = null;
		}

		// Token: 0x06037500 RID: 226560 RVA: 0x00E08500 File Offset: 0x00E06700
		public void SetTabView(EPhantomArenaChildViewName tabView, bool notNotify = false)
		{
			if (!Array.Exists<EPhantomArenaChildViewName>(PhantomArenaEntranceViewModel.tabViewList, (EPhantomArenaChildViewName x) => x == tabView))
			{
				return;
			}
			base.SetData(EViewData.TabViewName, tabView, notNotify);
		}

		// Token: 0x06037501 RID: 226561 RVA: 0x00E08546 File Offset: 0x00E06746
		public EPhantomArenaChildViewName GetTabView()
		{
			return (EPhantomArenaChildViewName)base.GetData(EViewData.TabViewName);
		}

		// Token: 0x06037502 RID: 226562 RVA: 0x00E08554 File Offset: 0x00E06754
		public int GetRepeatChallenge()
		{
			return (int)(base.GetData(EViewData.RepeatChallengeId) ?? 0);
		}

		// Token: 0x06037503 RID: 226563 RVA: 0x00E0856C File Offset: 0x00E0676C
		public void SetRepeatChallenge(int challengeId, bool notNotify = false)
		{
			base.SetData(EViewData.RepeatChallengeId, challengeId, notNotify);
		}

		// Token: 0x0401FC7C RID: 130172
		[Nullable(1)]
		private static EPhantomArenaChildViewName[] tabViewList;
	}
}
