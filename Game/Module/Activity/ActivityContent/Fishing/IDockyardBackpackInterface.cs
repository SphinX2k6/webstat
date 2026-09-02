using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006799 RID: 26521
	public interface IDockyardBackpackInterface
	{
		// Token: 0x0604222F RID: 270895
		void CloseClick();

		// Token: 0x06042230 RID: 270896
		bool CheckCurrencyItemClick(int itemId);

		// Token: 0x06042231 RID: 270897
		void ItemBlockClick(int id);

		// Token: 0x06042232 RID: 270898
		void HandleDragBegin();

		// Token: 0x06042233 RID: 270899
		void HandleDragResult();

		// Token: 0x06042234 RID: 270900
		void DeleteClick();

		// Token: 0x06042235 RID: 270901
		void RotateClick();

		// Token: 0x06042236 RID: 270902
		void ConfirmClick();

		// Token: 0x06042237 RID: 270903
		void TrawlClick(bool isSelected);

		// Token: 0x06042238 RID: 270904
		void AllSellClick();

		// Token: 0x06042239 RID: 270905
		void BackpackTick(float deltaTime);

		// Token: 0x0604223A RID: 270906
		bool IsTrawlInteractive();

		// Token: 0x0604223B RID: 270907
		void SetInSelectState(bool inSelectState);

		// Token: 0x0604223C RID: 270908
		[NullableContext(1)]
		void NotifyItemBlockToWareHouse(DockyardItemBlockOriginalData data);

		// Token: 0x0604223D RID: 270909
		[NullableContext(2)]
		UUIItem GetQuicklySellPanelParentItem();

		// Token: 0x0604223E RID: 270910
		void NotifyQuicklySellActive(bool isActive);

		// Token: 0x0604223F RID: 270911
		UniTask<bool> TrySetSelectedItemBlockToWareHouse();

		// Token: 0x06042240 RID: 270912
		UniTask<bool> TrySetSelectedItemBlockToBackpack();
	}
}
