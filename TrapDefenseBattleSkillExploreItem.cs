using System;
using CSharpScript.Game.Module.BattleUi.Views;

// Token: 0x02001D8E RID: 7566
public class TrapDefenseBattleSkillExploreItem : BattleSkillExploreItem
{
	// Token: 0x0600DF00 RID: 57088 RVA: 0x003C005C File Offset: 0x003BE25C
	protected override void OpenRouletteMainView(int touchId)
	{
		TrapDefenseRouletteMainViewProxy trapDefenseRouletteMainViewProxy = new TrapDefenseRouletteMainViewProxy();
		trapDefenseRouletteMainViewProxy.TouchId = new int?(touchId);
		ControllerBase<RouletteController>.Instance.OpenRouletteMainView(trapDefenseRouletteMainViewProxy);
	}
}
