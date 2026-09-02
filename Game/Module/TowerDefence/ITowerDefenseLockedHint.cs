using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EC5 RID: 20165
	[NullableContext(1)]
	public interface ITowerDefenseLockedHint
	{
		// Token: 0x170089B4 RID: 35252
		// (get) Token: 0x0603417C RID: 213372
		// (set) Token: 0x0603417D RID: 213373
		string TextId { get; set; }

		// Token: 0x170089B5 RID: 35253
		// (get) Token: 0x0603417E RID: 213374
		// (set) Token: 0x0603417F RID: 213375
		[Nullable(new byte[]
		{
			2,
			1
		})]
		string[] Args { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
