using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200679B RID: 26523
	[NullableContext(1)]
	public interface IDockyardWareHouseInterface
	{
		// Token: 0x06042243 RID: 270915
		void WareHouseItemClick(DockyardItemBlockOriginalData itemData);

		// Token: 0x06042244 RID: 270916
		void WareHouseItemDragBegin(DockyardItemBlockOriginalData itemData);

		// Token: 0x06042245 RID: 270917
		[NullableContext(0)]
		UniTask<bool> TrySetSelectedItemBlockConfirm();

		// Token: 0x06042246 RID: 270918
		bool IsWareHouseItemCanClick(int id);

		// Token: 0x06042247 RID: 270919
		int GetSelectedId();
	}
}
