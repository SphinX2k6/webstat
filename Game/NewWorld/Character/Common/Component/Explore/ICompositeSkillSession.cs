using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x02004959 RID: 18777
	[NullableContext(1)]
	public interface ICompositeSkillSession
	{
		// Token: 0x170083C3 RID: 33731
		// (get) Token: 0x06031193 RID: 201107
		// (set) Token: 0x06031194 RID: 201108
		ICompositeExploreSkillConfig Config { get; set; }

		// Token: 0x170083C4 RID: 33732
		// (get) Token: 0x06031195 RID: 201109
		// (set) Token: 0x06031196 RID: 201110
		bool EnterSent { get; set; }

		// Token: 0x170083C5 RID: 33733
		// (get) Token: 0x06031197 RID: 201111
		// (set) Token: 0x06031198 RID: 201112
		double CreatedTime { get; set; }
	}
}
