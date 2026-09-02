using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Monster
{
	// Token: 0x020065EF RID: 26095
	[NullableContext(1)]
	public interface IPinballMonsterSkillTabItemData
	{
		// Token: 0x17009F20 RID: 40736
		// (get) Token: 0x06041317 RID: 267031
		// (set) Token: 0x06041318 RID: 267032
		bool IsSelected { get; set; }

		// Token: 0x17009F21 RID: 40737
		// (get) Token: 0x06041319 RID: 267033
		// (set) Token: 0x0604131A RID: 267034
		string Name { get; set; }

		// Token: 0x17009F22 RID: 40738
		// (get) Token: 0x0604131B RID: 267035
		// (set) Token: 0x0604131C RID: 267036
		Action<int> OnSelected { get; set; }
	}
}
