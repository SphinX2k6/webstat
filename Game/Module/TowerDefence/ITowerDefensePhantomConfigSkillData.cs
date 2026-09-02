using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EB4 RID: 20148
	[NullableContext(1)]
	public interface ITowerDefensePhantomConfigSkillData
	{
		// Token: 0x17008960 RID: 35168
		// (get) Token: 0x060340CB RID: 213195
		// (set) Token: 0x060340CC RID: 213196
		string Name { get; set; }

		// Token: 0x17008961 RID: 35169
		// (get) Token: 0x060340CD RID: 213197
		// (set) Token: 0x060340CE RID: 213198
		string Description { get; set; }

		// Token: 0x17008962 RID: 35170
		// (get) Token: 0x060340CF RID: 213199
		// (set) Token: 0x060340D0 RID: 213200
		string UnlockDescription { get; set; }

		// Token: 0x17008963 RID: 35171
		// (get) Token: 0x060340D1 RID: 213201
		// (set) Token: 0x060340D2 RID: 213202
		double? ExpThreshold { get; set; }

		// Token: 0x17008964 RID: 35172
		// (get) Token: 0x060340D3 RID: 213203
		// (set) Token: 0x060340D4 RID: 213204
		int PhantomSkill { get; set; }
	}
}
