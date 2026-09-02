using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FAC RID: 24492
	public class MissionViewRuleConfig : IStaticVariableResetter
	{
		// Token: 0x0603D8AA RID: 252074 RVA: 0x00FAAF37 File Offset: 0x00FA9137
		static MissionViewRuleConfig()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MissionViewRuleConfig.CreateStaticDefaultValue), new Action(MissionViewRuleConfig.ResetStaticDefaultValue));
		}

		// Token: 0x0603D8AB RID: 252075 RVA: 0x00FAAF56 File Offset: 0x00FA9156
		public static void CreateStaticDefaultValue()
		{
			MissionViewRuleConfig.specialDungeonRules = new TrackingDisplayRuleBase[]
			{
				new HonamiStoryTrackingRule(),
				new SpringManorTrackingRule()
			};
		}

		// Token: 0x0603D8AC RID: 252076 RVA: 0x00FAAF73 File Offset: 0x00FA9173
		public static void ResetStaticDefaultValue()
		{
			MissionViewRuleConfig.specialDungeonRules = null;
		}

		// Token: 0x040228F1 RID: 141553
		[Nullable(1)]
		public static TrackingDisplayRuleBase[] specialDungeonRules;
	}
}
