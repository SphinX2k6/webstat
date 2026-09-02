using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054B2 RID: 21682
	[NullableContext(1)]
	public interface IPhantomArenaChallengeDetailTabViewModel : IPhantomArenaTabViewModelBase
	{
		// Token: 0x17008E60 RID: 36448
		// (get) Token: 0x0603737B RID: 226171
		// (set) Token: 0x0603737C RID: 226172
		int NpcId { get; set; }

		// Token: 0x17008E61 RID: 36449
		// (get) Token: 0x0603737D RID: 226173
		// (set) Token: 0x0603737E RID: 226174
		int NpcDeckConfigId { get; set; }

		// Token: 0x17008E62 RID: 36450
		// (get) Token: 0x0603737F RID: 226175
		// (set) Token: 0x06037380 RID: 226176
		int SelectedCardRoleId { get; set; }

		// Token: 0x17008E63 RID: 36451
		// (get) Token: 0x06037381 RID: 226177
		// (set) Token: 0x06037382 RID: 226178
		int TextureCardRoleId { get; set; }

		// Token: 0x17008E64 RID: 36452
		// (get) Token: 0x06037383 RID: 226179
		// (set) Token: 0x06037384 RID: 226180
		bool RoleTextureActive { get; set; }

		// Token: 0x17008E65 RID: 36453
		// (get) Token: 0x06037385 RID: 226181
		// (set) Token: 0x06037386 RID: 226182
		bool RoleSelectedConfirmFlag { get; set; }

		// Token: 0x17008E66 RID: 36454
		// (get) Token: 0x06037387 RID: 226183
		// (set) Token: 0x06037388 RID: 226184
		bool DeckSelectedConfirmFlag { get; set; }

		// Token: 0x17008E67 RID: 36455
		// (get) Token: 0x06037389 RID: 226185
		// (set) Token: 0x0603738A RID: 226186
		int UsedDeckIndex { get; set; }

		// Token: 0x17008E68 RID: 36456
		// (get) Token: 0x0603738B RID: 226187
		// (set) Token: 0x0603738C RID: 226188
		int SelectedDeckIndex { get; set; }

		// Token: 0x17008E69 RID: 36457
		// (get) Token: 0x0603738D RID: 226189
		// (set) Token: 0x0603738E RID: 226190
		[Nullable(2)]
		DeckInfo RecommendDeck { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x0603738F RID: 226191
		[NullableContext(2)]
		DeckInfo GetUsedDeck();

		// Token: 0x06037390 RID: 226192
		int GetChallengeId();

		// Token: 0x17008E6A RID: 36458
		// (get) Token: 0x06037391 RID: 226193
		// (set) Token: 0x06037392 RID: 226194
		Action<int, bool> ChangeRoleTexture { get; set; }

		// Token: 0x17008E6B RID: 36459
		// (get) Token: 0x06037393 RID: 226195
		// (set) Token: 0x06037394 RID: 226196
		Action<bool> ShowRoleTexture { get; set; }

		// Token: 0x17008E6C RID: 36460
		// (get) Token: 0x06037395 RID: 226197
		// (set) Token: 0x06037396 RID: 226198
		Action<bool> HideRoleTexture { get; set; }

		// Token: 0x17008E6D RID: 36461
		// (get) Token: 0x06037397 RID: 226199
		// (set) Token: 0x06037398 RID: 226200
		Action RefreshRoleTexture { get; set; }

		// Token: 0x17008E6E RID: 36462
		// (get) Token: 0x06037399 RID: 226201
		// (set) Token: 0x0603739A RID: 226202
		Action<string> SetViewTitle { get; set; }

		// Token: 0x17008E6F RID: 36463
		// (get) Token: 0x0603739B RID: 226203
		// (set) Token: 0x0603739C RID: 226204
		Action<string> SetViewIcon { get; set; }

		// Token: 0x17008E70 RID: 36464
		// (get) Token: 0x0603739D RID: 226205
		// (set) Token: 0x0603739E RID: 226206
		Action<int> SetViewHelpId { get; set; }

		// Token: 0x17008E71 RID: 36465
		// (get) Token: 0x0603739F RID: 226207
		// (set) Token: 0x060373A0 RID: 226208
		Action<bool> SetViewHelpBtnActive { get; set; }
	}
}
