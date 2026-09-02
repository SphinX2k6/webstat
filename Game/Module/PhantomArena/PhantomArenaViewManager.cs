using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Prepare;
using CSharpScript.Game.Module.PhantomArena.Prepare.ChallengeDetail;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;
using CSharpScript.Game.Module.PhantomArena.Prepare.Entrance;
using CSharpScript.Game.Module.PhantomArena.Prepare.RoleSelect;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x020054A4 RID: 21668
	public static class PhantomArenaViewManager
	{
		// Token: 0x0401FBE0 RID: 130016
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1,
			1
		})]
		[StaticVariableRuleIgnore]
		public static IReadOnlyDictionary<EPhantomArenaChildViewName, ValueTuple<Func<PhantomArenaChildViewBase>, string>> phantomArenaChildViewCreateInfo = new Dictionary<EPhantomArenaChildViewName, ValueTuple<Func<PhantomArenaChildViewBase>, string>>
		{
			{
				EPhantomArenaChildViewName.PhantomArenaRoleSelectTabView,
				new ValueTuple<Func<PhantomArenaChildViewBase>, string>(() => new PhantomArenaRoleSelectTabView(), "UiItem_OutsideSelectRole")
			},
			{
				EPhantomArenaChildViewName.PhantomArenaChallengeDetailTabView,
				new ValueTuple<Func<PhantomArenaChildViewBase>, string>(() => new PhantomArenaChallengeDetailTabView(), "UiItem_OutsideBattleDetail")
			},
			{
				EPhantomArenaChildViewName.PhantomArenaChallengeDetailTabViewNew,
				new ValueTuple<Func<PhantomArenaChildViewBase>, string>(() => new PhantomArenaChallengeDetailTabViewNew(), "UiItem_OutsideBattleDetailNew")
			},
			{
				EPhantomArenaChildViewName.PhantomArenaDeckOverviewTabView,
				new ValueTuple<Func<PhantomArenaChildViewBase>, string>(() => new PhantomArenaDeckOverviewTabView(), "UiItem_DeckManagement")
			},
			{
				EPhantomArenaChildViewName.PhantomArenaDeckBuilderTabView,
				new ValueTuple<Func<PhantomArenaChildViewBase>, string>(() => new PhantomArenaDeckBuilderTabView(), "UiItem_CardManagement")
			},
			{
				EPhantomArenaChildViewName.PhantomArenaNewDeckBuilderTabView,
				new ValueTuple<Func<PhantomArenaChildViewBase>, string>(() => new PhantomArenaNewDeckBuilderTabView(), "UiItem_CardManagementNew")
			},
			{
				EPhantomArenaChildViewName.PhantomArenaEntranceRepeatTabView,
				new ValueTuple<Func<PhantomArenaChildViewBase>, string>(() => new PhantomArenaEntranceRepeatTabView(), "UiItem_SoundRemnantArenaRepeat")
			},
			{
				EPhantomArenaChildViewName.PhantomArenaEntranceGymTabView,
				new ValueTuple<Func<PhantomArenaChildViewBase>, string>(() => new PhantomArenaEntranceGymTabView(), "UiItem_SoundRemnantArenaLevel")
			}
		};

		// Token: 0x0401FBE1 RID: 130017
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static Dictionary<EPhantomArenaChildViewName, bool> roleStateInPhantomArenaMainViewTabView = new Dictionary<EPhantomArenaChildViewName, bool>
		{
			{
				EPhantomArenaChildViewName.PhantomArenaRoleSelectTabView,
				true
			},
			{
				EPhantomArenaChildViewName.PhantomArenaChallengeDetailTabView,
				true
			},
			{
				EPhantomArenaChildViewName.PhantomArenaDeckOverviewTabView,
				false
			},
			{
				EPhantomArenaChildViewName.PhantomArenaDeckBuilderTabView,
				false
			}
		};
	}
}
