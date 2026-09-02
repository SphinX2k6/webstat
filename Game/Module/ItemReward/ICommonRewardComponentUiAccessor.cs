using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B45 RID: 23365
	[NullableContext(2)]
	public interface ICommonRewardComponentUiAccessor
	{
		// Token: 0x0603B18F RID: 242063
		UUIItem GetItemForComponent(int childType);

		// Token: 0x0603B190 RID: 242064
		UUIText GetTextForComponent(int childType);

		// Token: 0x0603B191 RID: 242065
		UUIGridLayout GetGridLayoutForComponent(int childType);

		// Token: 0x0603B192 RID: 242066
		UUIButtonComponent GetButtonForComponent(int childType);
	}
}
