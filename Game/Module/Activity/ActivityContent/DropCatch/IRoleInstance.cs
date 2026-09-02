using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x0200688C RID: 26764
	[NullableContext(1)]
	public interface IRoleInstance
	{
		// Token: 0x06042AE8 RID: 273128
		void Init(IDropCatchRoleParams @params);

		// Token: 0x06042AE9 RID: 273129
		void OnReadyTick(float deltaTime);

		// Token: 0x06042AEA RID: 273130
		void OnTick(float deltaTime);

		// Token: 0x06042AEB RID: 273131
		IDropCatchBounds GetBowlBounds();

		// Token: 0x06042AEC RID: 273132
		IDropCatchBounds GetRoleBounds();

		// Token: 0x06042AED RID: 273133
		Vector2D GetRoleSize();

		// Token: 0x06042AEE RID: 273134
		Vector2D GetBowlSize();

		// Token: 0x06042AEF RID: 273135
		void AddEnergy(float energy, bool isCalRate);

		// Token: 0x06042AF0 RID: 273136
		void FullEnergy();

		// Token: 0x06042AF1 RID: 273137
		void UseSkill();

		// Token: 0x06042AF2 RID: 273138
		void AddShield(float time);

		// Token: 0x06042AF3 RID: 273139
		void RemoveShield();

		// Token: 0x06042AF4 RID: 273140
		bool IsInShield();

		// Token: 0x06042AF5 RID: 273141
		EDropCatchRoleSkillState GetSkillState();

		// Token: 0x06042AF6 RID: 273142
		int GetRoleId();

		// Token: 0x06042AF7 RID: 273143
		float GetEnergy();

		// Token: 0x06042AF8 RID: 273144
		float GetMaxEnergy();

		// Token: 0x06042AF9 RID: 273145
		Vector2D GetRolePos();

		// Token: 0x06042AFA RID: 273146
		EDropCatchRoleAnimState GetAnimState();

		// Token: 0x06042AFB RID: 273147
		DropCatchGameplayAttribute GetSpeedAttr();

		// Token: 0x06042AFC RID: 273148
		Vector2D GetFloatEffPos();

		// Token: 0x06042AFD RID: 273149
		float GetEnergyGetRate();

		// Token: 0x06042AFE RID: 273150
		float GetEnergySelfRecover();

		// Token: 0x06042AFF RID: 273151
		float GetSkillReduceEnergy();

		// Token: 0x06042B00 RID: 273152
		float GetSkillReduceEnergyRateInterval();

		// Token: 0x06042B01 RID: 273153
		float GetSkillReduceEnergyRate();

		// Token: 0x06042B02 RID: 273154
		float GetShieldTime();
	}
}
