using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.MingSu
{
	// Token: 0x02005734 RID: 22324
	[NullableContext(2)]
	public interface IRewardItemData
	{
		// Token: 0x17009129 RID: 37161
		// (get) Token: 0x06038D07 RID: 232711
		ItemConfig ItemInfo { get; }

		// Token: 0x1700912A RID: 37162
		// (get) Token: 0x06038D08 RID: 232712
		int Count { get; }
	}
}
