using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005109 RID: 20745
	[NullableContext(2)]
	public interface IRoguelikeRandomEventOpenParam
	{
		// Token: 0x17008C49 RID: 35913
		// (get) Token: 0x06035750 RID: 218960
		// (set) Token: 0x06035751 RID: 218961
		int BindId { get; set; }

		// Token: 0x17008C4A RID: 35914
		// (get) Token: 0x06035752 RID: 218962
		// (set) Token: 0x06035753 RID: 218963
		Action<int> SelectCallback { get; set; }
	}
}
