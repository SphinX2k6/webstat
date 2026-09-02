using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054B3 RID: 21683
	[NullableContext(1)]
	public interface IPhantomArenaMainViewModel : IPhantomArenaTabViewModelBase
	{
		// Token: 0x17008E72 RID: 36466
		// (get) Token: 0x060373A1 RID: 226209
		// (set) Token: 0x060373A2 RID: 226210
		int SelectedCardRoleId { get; set; }

		// Token: 0x17008E73 RID: 36467
		// (get) Token: 0x060373A3 RID: 226211
		// (set) Token: 0x060373A4 RID: 226212
		int TextureCardRoleId { get; set; }

		// Token: 0x060373A5 RID: 226213
		void Init(int challengeId);

		// Token: 0x060373A6 RID: 226214
		void SetGetSwitchItemFunc(Func<PhantomArenaMainViewSwitchItem> getSwitchItemFunc);

		// Token: 0x17008E74 RID: 36468
		// (get) Token: 0x060373A7 RID: 226215
		// (set) Token: 0x060373A8 RID: 226216
		Action<int, bool> ChangeRoleTexture { get; set; }

		// Token: 0x17008E75 RID: 36469
		// (get) Token: 0x060373A9 RID: 226217
		// (set) Token: 0x060373AA RID: 226218
		Action<bool> ShowRoleTexture { get; set; }

		// Token: 0x17008E76 RID: 36470
		// (get) Token: 0x060373AB RID: 226219
		// (set) Token: 0x060373AC RID: 226220
		Action<bool> HideRoleTexture { get; set; }

		// Token: 0x17008E77 RID: 36471
		// (get) Token: 0x060373AD RID: 226221
		// (set) Token: 0x060373AE RID: 226222
		Action PlayRoleTextureShowAnim { get; set; }

		// Token: 0x17008E78 RID: 36472
		// (get) Token: 0x060373AF RID: 226223
		// (set) Token: 0x060373B0 RID: 226224
		Action RefreshRoleTexture { get; set; }

		// Token: 0x17008E79 RID: 36473
		// (get) Token: 0x060373B1 RID: 226225
		// (set) Token: 0x060373B2 RID: 226226
		Action<string> SetViewTitle { get; set; }

		// Token: 0x17008E7A RID: 36474
		// (get) Token: 0x060373B3 RID: 226227
		// (set) Token: 0x060373B4 RID: 226228
		Action<string> SetViewIcon { get; set; }

		// Token: 0x17008E7B RID: 36475
		// (get) Token: 0x060373B5 RID: 226229
		// (set) Token: 0x060373B6 RID: 226230
		Action<int> SetViewHelpId { get; set; }

		// Token: 0x17008E7C RID: 36476
		// (get) Token: 0x060373B7 RID: 226231
		// (set) Token: 0x060373B8 RID: 226232
		Action<bool> SetViewHelpBtnActive { get; set; }
	}
}
