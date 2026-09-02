using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049AD RID: 18861
	[NullableContext(1)]
	public interface IUiPopFrameInterface
	{
		// Token: 0x17008407 RID: 33799
		// (get) Token: 0x0603149E RID: 201886
		// (set) Token: 0x0603149F RID: 201887
		[Nullable(2)]
		CommonPopViewBase PopItem { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x060314A0 RID: 201888
		void SetCloseBtnInteractive(bool state);

		// Token: 0x060314A1 RID: 201889
		void SetTitleByTextIdAndArg(string textId, params object[] args);

		// Token: 0x060314A2 RID: 201890
		void SetBackBtnShowState(bool state);

		// Token: 0x060314A3 RID: 201891
		AActor GetPopViewRootActor();

		// Token: 0x060314A4 RID: 201892
		UUIItem GetPopViewRootItem();

		// Token: 0x060314A5 RID: 201893
		AActor GetPopViewOriginalActor();

		// Token: 0x060314A6 RID: 201894
		void HidePopView();

		// Token: 0x060314A7 RID: 201895
		void ShowPopView();

		// Token: 0x060314A8 RID: 201896
		void SetViewPermanent();

		// Token: 0x060314A9 RID: 201897
		void PlayLevelSequenceByName(string sequenceName, bool blockClick);

		// Token: 0x060314AA RID: 201898
		UniTask PlaySequenceAsync(string sequenceName, CustomPromise<bool> stopPromise, bool blockClick = false, bool playReverse = false);
	}
}
