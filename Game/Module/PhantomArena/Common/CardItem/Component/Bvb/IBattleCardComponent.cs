using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component.Bvb
{
	// Token: 0x02005564 RID: 21860
	[NullableContext(1)]
	public interface IBattleCardComponent
	{
		// Token: 0x17008F71 RID: 36721
		// (get) Token: 0x06037B76 RID: 228214
		// (set) Token: 0x06037B77 RID: 228215
		Action<EToggleState> CardClickCallback { get; set; }

		// Token: 0x06037B78 RID: 228216
		void SetCardData(PhantomCardData data);

		// Token: 0x06037B79 RID: 228217
		UniTask InitEffect();

		// Token: 0x06037B7A RID: 228218
		UniTask InitSpine();

		// Token: 0x06037B7B RID: 228219
		void Refresh(PhantomCardData data);

		// Token: 0x06037B7C RID: 228220
		UniTask RefreshAsync(PhantomCardData data);

		// Token: 0x06037B7D RID: 228221
		UUIExtendToggle GetCardToggle();

		// Token: 0x06037B7E RID: 228222
		void SetDebugText();

		// Token: 0x06037B7F RID: 228223
		void PlaySequence(string name);

		// Token: 0x06037B80 RID: 228224
		void PlaySpineAnim(string animName, bool isLoop);

		// Token: 0x06037B81 RID: 228225
		void PlayEffect();

		// Token: 0x17008F72 RID: 36722
		// (get) Token: 0x06037B82 RID: 228226
		// (set) Token: 0x06037B83 RID: 228227
		Func<UUIItem, UniTask> PlayHitEffect { get; set; }

		// Token: 0x06037B84 RID: 228228
		UUIItem GetRootItem();

		// Token: 0x17008F73 RID: 36723
		// (get) Token: 0x06037B85 RID: 228229
		// (set) Token: 0x06037B86 RID: 228230
		UiSequencePlayer RootUiSequencePlayer { get; set; }
	}
}
