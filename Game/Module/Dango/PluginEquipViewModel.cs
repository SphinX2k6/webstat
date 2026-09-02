using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Dango
{
	// Token: 0x02005DD8 RID: 24024
	[NullableContext(2)]
	[Nullable(0)]
	public class PluginEquipViewModel : ViewModelBase<EPluginEquipViewData>
	{
		// Token: 0x0603C7A4 RID: 247716 RVA: 0x00F5C226 File Offset: 0x00F5A426
		public PluginEquipViewModel()
		{
			this.DataMap[EPluginEquipViewData.DangoId] = 0;
			this.DataMap[EPluginEquipViewData.SlotIndex] = -1;
			this.DataMap[EPluginEquipViewData.PluginItem] = null;
		}

		// Token: 0x0603C7A5 RID: 247717 RVA: 0x00F5C25F File Offset: 0x00F5A45F
		public void SetDangoId(int dangoId, bool notNotify = false)
		{
			base.SetData(EPluginEquipViewData.DangoId, dangoId, notNotify);
		}

		// Token: 0x0603C7A6 RID: 247718 RVA: 0x00F5C26F File Offset: 0x00F5A46F
		public void SetSlotIndex(int slotIndex, bool notNotify = false)
		{
			base.SetData(EPluginEquipViewData.SlotIndex, slotIndex, notNotify);
		}

		// Token: 0x0603C7A7 RID: 247719 RVA: 0x00F5C27F File Offset: 0x00F5A47F
		public void SetPluginItem(AbyssPluginItemInfo pluginItem, bool notNotify = false)
		{
			base.SetData(EPluginEquipViewData.PluginItem, pluginItem, notNotify);
		}

		// Token: 0x0603C7A8 RID: 247720 RVA: 0x00F5C28A File Offset: 0x00F5A48A
		public int GetDangoId()
		{
			return (int)base.GetData(EPluginEquipViewData.DangoId);
		}

		// Token: 0x0603C7A9 RID: 247721 RVA: 0x00F5C298 File Offset: 0x00F5A498
		public int GetSlotIndex()
		{
			return (int)base.GetData(EPluginEquipViewData.SlotIndex);
		}

		// Token: 0x0603C7AA RID: 247722 RVA: 0x00F5C2A6 File Offset: 0x00F5A4A6
		public AbyssPluginItemInfo GetPluginItem()
		{
			return base.GetData(EPluginEquipViewData.PluginItem) as AbyssPluginItemInfo;
		}
	}
}
