using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x0200688A RID: 26762
	[NullableContext(1)]
	public interface IGameplayLogicContext
	{
		// Token: 0x06042AD4 RID: 273108
		DropCatchGameplayProxy GetProxy();

		// Token: 0x06042AD5 RID: 273109
		DropCatchGameplayTimeMgr GetGameplayTimeMgr();

		// Token: 0x06042AD6 RID: 273110
		DropCatchGameplayRoleMgr GetGameplayRoleMgr();

		// Token: 0x06042AD7 RID: 273111
		DropCatchGameplayDropItemMgr GetGameplayDropItemMgr();

		// Token: 0x06042AD8 RID: 273112
		DropCatchGameplayCollisionMgr GetGameplayCollisionMgr();

		// Token: 0x06042AD9 RID: 273113
		DropCatchGameplayCommandMgr GetGameplayCommandMgr();

		// Token: 0x06042ADA RID: 273114
		DropCatchGameplayInputMgr GetGameplayInputMgr();

		// Token: 0x06042ADB RID: 273115
		DropCatchGameplayModifierMgr GetGameplayModifierMgr();

		// Token: 0x06042ADC RID: 273116
		IDropCatchGameplayArea GetGameplayArea();

		// Token: 0x06042ADD RID: 273117
		DropCatchGameplayAttribute GetAddScoreRateAttr();

		// Token: 0x06042ADE RID: 273118
		DropCatchGameplayAttribute GetEnergyGetRateAttr();

		// Token: 0x06042ADF RID: 273119
		void UseRoleSkill();
	}
}
