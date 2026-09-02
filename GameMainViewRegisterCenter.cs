using System;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.GameMainView.PinballBattle;

// Token: 0x02001D17 RID: 7447
public class GameMainViewRegisterCenter
{
	// Token: 0x0600DAE0 RID: 56032 RVA: 0x003AC714 File Offset: 0x003AA914
	public static void Init()
	{
		GameMainViewStorage.RegisterMainViewInfo(EDungeonSubType.TowerDefenseEvent, typeof(TrapDefenseMainViewProxy));
		GameMainViewStorage.RegisterMainViewInfo(EDungeonSubType.Survivors, typeof(SurvivorsRogueMainViewProxy));
		GameMainViewStorage.RegisterMainViewInfo(EDungeonSubType.MotorcycleArrow, typeof(MotorcycleArrowMainViewProxy));
		GameMainViewStorage.RegisterMainViewInfo(EDungeonSubType.Kurotato, typeof(KurotatoMainViewProxy));
		GameMainViewStorage.RegisterMainViewInfo(EDungeonSubType.PinballBattle, typeof(PinballBattleMainViewProxy));
		GameMainViewStorage.RegisterMainViewInfoWorldInstance(EWorldDungeonSubType.SpringManorWorld, typeof(SpringManorMainViewProxy));
	}
}
