using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067A4 RID: 26532
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardCageViewModel : DockyardWareHouseViewModelBase
	{
		// Token: 0x1700A0F1 RID: 41201
		// (get) Token: 0x060422A8 RID: 271016 RVA: 0x010F93AD File Offset: 0x010F75AD
		public virtual DockyardCageBackpackPanelModel BackpackPanelModel { [PreserveBaseOverrides] get; } = new DockyardCageBackpackPanelModel();

		// Token: 0x1700A0F2 RID: 41202
		// (get) Token: 0x060422A9 RID: 271017 RVA: 0x010F93B5 File Offset: 0x010F75B5
		public virtual DockyardCageListPanelModel ListPanelModel { [PreserveBaseOverrides] get; } = new DockyardCageListPanelModel();

		// Token: 0x1700A0F3 RID: 41203
		// (get) Token: 0x060422AA RID: 271018 RVA: 0x010F93BD File Offset: 0x010F75BD
		protected override CabinType RequestCabinType { get; } = 3;

		// Token: 0x1700A0F4 RID: 41204
		// (get) Token: 0x060422AB RID: 271019 RVA: 0x010F93C5 File Offset: 0x010F75C5
		protected override int RequestId
		{
			get
			{
				return this.ConfigId;
			}
		}

		// Token: 0x060422AC RID: 271020 RVA: 0x010F93CD File Offset: 0x010F75CD
		protected override void OnInit()
		{
			this.ViewTitle = "Fishing_CageText3";
			this.BackpackPanelModel.Init(this.ConfigId);
			this.ListPanelModel.Init(this.ConfigId);
		}

		// Token: 0x060422AD RID: 271021 RVA: 0x010F93FC File Offset: 0x010F75FC
		public override DockyardItemBlockOriginalData GetItemBlockData(int id)
		{
			DockyardItemBlockOriginalData itemBlockData = ModelBase<DockyardModel>.Instance.GetItemBlockData(id);
			if (itemBlockData != null)
			{
				return itemBlockData;
			}
			return ModelBase<FishingModel>.Instance.GetDataByCage(this.ConfigId, id);
		}

		// Token: 0x04024DC3 RID: 150979
		public int ConfigId;
	}
}
