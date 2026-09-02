using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065A7 RID: 26023
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballWeaponEquipTitleGridData : IMultiTemplateGridData<IPinballWeaponEquipTitleItemData, PinballWeaponEquipTitleItem>, IMultiTemplateGridData
	{
		// Token: 0x17009ECF RID: 40655
		// (get) Token: 0x0604103B RID: 266299 RVA: 0x010AE64D File Offset: 0x010AC84D
		// (set) Token: 0x0604103C RID: 266300 RVA: 0x010AE655 File Offset: 0x010AC855
		public IPinballWeaponEquipTitleItemData Data { get; set; }

		// Token: 0x17009ED0 RID: 40656
		// (get) Token: 0x0604103D RID: 266301 RVA: 0x010AE65E File Offset: 0x010AC85E
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x0604103E RID: 266302 RVA: 0x010AE666 File Offset: 0x010AC866
		public PinballWeaponEquipTitleGridData(IPinballWeaponEquipTitleItemData data)
		{
			this.Data = data;
		}

		// Token: 0x0604103F RID: 266303 RVA: 0x010AE675 File Offset: 0x010AC875
		public int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x06041040 RID: 266304 RVA: 0x010AE678 File Offset: 0x010AC878
		public PinballWeaponEquipTitleItem CreateProxy()
		{
			return new PinballWeaponEquipTitleItem();
		}

		// Token: 0x06041041 RID: 266305 RVA: 0x010AE67F File Offset: 0x010AC87F
		ISyncGridProxy IMultiTemplateGridData.CreateProxy()
		{
			return this.CreateProxy();
		}
	}
}
