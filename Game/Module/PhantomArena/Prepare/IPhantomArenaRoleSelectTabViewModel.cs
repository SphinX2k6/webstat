using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054B1 RID: 21681
	[NullableContext(1)]
	public interface IPhantomArenaRoleSelectTabViewModel : IPhantomArenaTabViewModelBase
	{
		// Token: 0x17008E51 RID: 36433
		// (get) Token: 0x0603735D RID: 226141
		// (set) Token: 0x0603735E RID: 226142
		int SelectedCardRoleId { get; set; }

		// Token: 0x17008E52 RID: 36434
		// (get) Token: 0x0603735F RID: 226143
		// (set) Token: 0x06037360 RID: 226144
		int TextureCardRoleId { get; set; }

		// Token: 0x17008E53 RID: 36435
		// (get) Token: 0x06037361 RID: 226145
		// (set) Token: 0x06037362 RID: 226146
		bool RoleTextureActive { get; set; }

		// Token: 0x17008E54 RID: 36436
		// (get) Token: 0x06037363 RID: 226147
		// (set) Token: 0x06037364 RID: 226148
		List<int> CardRoleList { get; set; }

		// Token: 0x17008E55 RID: 36437
		// (get) Token: 0x06037365 RID: 226149
		// (set) Token: 0x06037366 RID: 226150
		bool CanShowRewardInRoleSelectTabView { get; set; }

		// Token: 0x17008E56 RID: 36438
		// (get) Token: 0x06037367 RID: 226151
		// (set) Token: 0x06037368 RID: 226152
		bool CanShowSelectBtnInRoleSelectTabView { get; set; }

		// Token: 0x17008E57 RID: 36439
		// (get) Token: 0x06037369 RID: 226153
		// (set) Token: 0x0603736A RID: 226154
		bool RoleSelectedConfirmFlag { get; set; }

		// Token: 0x17008E58 RID: 36440
		// (get) Token: 0x0603736B RID: 226155
		// (set) Token: 0x0603736C RID: 226156
		Action<int, bool> ChangeRoleTexture { get; set; }

		// Token: 0x17008E59 RID: 36441
		// (get) Token: 0x0603736D RID: 226157
		// (set) Token: 0x0603736E RID: 226158
		Action<bool> ShowRoleTexture { get; set; }

		// Token: 0x17008E5A RID: 36442
		// (get) Token: 0x0603736F RID: 226159
		// (set) Token: 0x06037370 RID: 226160
		Action PlayRoleTextureShowAnim { get; set; }

		// Token: 0x17008E5B RID: 36443
		// (get) Token: 0x06037371 RID: 226161
		// (set) Token: 0x06037372 RID: 226162
		Action RefreshRoleTexture { get; set; }

		// Token: 0x17008E5C RID: 36444
		// (get) Token: 0x06037373 RID: 226163
		// (set) Token: 0x06037374 RID: 226164
		Action<string> SetViewTitle { get; set; }

		// Token: 0x17008E5D RID: 36445
		// (get) Token: 0x06037375 RID: 226165
		// (set) Token: 0x06037376 RID: 226166
		Action<string> SetViewIcon { get; set; }

		// Token: 0x17008E5E RID: 36446
		// (get) Token: 0x06037377 RID: 226167
		// (set) Token: 0x06037378 RID: 226168
		Action<int> SetViewHelpId { get; set; }

		// Token: 0x17008E5F RID: 36447
		// (get) Token: 0x06037379 RID: 226169
		// (set) Token: 0x0603737A RID: 226170
		Action<bool> SetViewHelpBtnActive { get; set; }
	}
}
