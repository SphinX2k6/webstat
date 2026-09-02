using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049F8 RID: 18936
	public static class InputDistributeSetupDefine
	{
		// Token: 0x0401CCD4 RID: 117972
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Type[] inputDistributeSetups = new Type[]
		{
			typeof(BlockInputDistribute),
			typeof(ReconnectInputDistribute),
			typeof(PlotInputDistribute),
			typeof(GuideInputDistributeSetup),
			typeof(CreateCharacterInputDistribute),
			typeof(LoginInputDistribute),
			typeof(UiProhibitFightInputDistribute),
			typeof(ExploreInputDistribute),
			typeof(RoleMorphInputDistribute),
			typeof(LevelEventInputDistribute),
			typeof(InteractionInputDistribute),
			typeof(AutoPilotInputDistribute),
			typeof(MusicalInstrumentInputDistribute),
			typeof(FightInputDistribute),
			typeof(UiInputDistribute)
		};
	}
}
