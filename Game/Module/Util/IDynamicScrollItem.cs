using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C6F RID: 19567
	[NullableContext(1)]
	public interface IDynamicScrollItem<[Nullable(2)] TData>
	{
		// Token: 0x06032F9F RID: 208799
		[return: Nullable(2)]
		AUIBaseActor GetUsingItem(TData data);

		// Token: 0x06032FA0 RID: 208800
		void Update(TData data, int index);

		// Token: 0x06032FA1 RID: 208801
		UniTask Init(UUIItem actor);

		// Token: 0x06032FA2 RID: 208802
		void ClearItem();

		// Token: 0x17008786 RID: 34694
		// (set) Token: 0x06032FA3 RID: 208803
		bool SkipDestroyActor { set; }

		// Token: 0x06032FA4 RID: 208804
		void SetUiActive(bool visibility);
	}
}
