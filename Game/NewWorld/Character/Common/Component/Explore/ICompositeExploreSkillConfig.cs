using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x02004957 RID: 18775
	[NullableContext(1)]
	public interface ICompositeExploreSkillConfig
	{
		// Token: 0x170083BD RID: 33725
		// (get) Token: 0x06031186 RID: 201094
		// (set) Token: 0x06031187 RID: 201095
		string Name { get; set; }

		// Token: 0x170083BE RID: 33726
		// (get) Token: 0x06031188 RID: 201096
		// (set) Token: 0x06031189 RID: 201097
		int EntrySkillId { get; set; }

		// Token: 0x170083BF RID: 33727
		// (get) Token: 0x0603118A RID: 201098
		// (set) Token: 0x0603118B RID: 201099
		int ExitSkillId { get; set; }
	}
}
