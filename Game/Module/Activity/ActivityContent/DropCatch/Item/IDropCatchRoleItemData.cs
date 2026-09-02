using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068F1 RID: 26865
	public interface IDropCatchRoleItemData
	{
		// Token: 0x1700A1C5 RID: 41413
		// (get) Token: 0x06042C09 RID: 273417
		// (set) Token: 0x06042C0A RID: 273418
		int RoleCfgId { get; set; }

		// Token: 0x1700A1C6 RID: 41414
		// (get) Token: 0x06042C0B RID: 273419
		// (set) Token: 0x06042C0C RID: 273420
		int BookCfgId { get; set; }

		// Token: 0x1700A1C7 RID: 41415
		// (get) Token: 0x06042C0D RID: 273421
		// (set) Token: 0x06042C0E RID: 273422
		bool IsUnlock { get; set; }
	}
}
