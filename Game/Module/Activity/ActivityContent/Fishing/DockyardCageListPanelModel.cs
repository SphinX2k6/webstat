using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067A3 RID: 26531
	public class DockyardCageListPanelModel : DockyardItemListPanelModel
	{
		// Token: 0x060422A2 RID: 271010 RVA: 0x010F9244 File Offset: 0x010F7444
		protected override void OnInit()
		{
			base.ComponentData.TitleText = "Fishing_CageText3";
			base.ComponentData.HelpBtnId = 193;
			DockyardCageData cageDataByConfigId = ModelBase<FishingModel>.Instance.GetCageDataByConfigId(this.ConfigId);
			this.MaxCount = ((cageDataByConfigId != null) ? cageDataByConfigId.Data.MaxCount : 0);
			base.ComponentData.GetCountText = (() => base.ShowItemList.Count.ToString() + "/" + this.MaxCount.ToString());
			if (this.GetShowItemList().Count < this.MaxCount)
			{
				double shipCageNextHarvestTimeStamp = (double)ModelBase<FishingModel>.Instance.GetShipCageNextHarvestTimeStamp(this.ConfigId);
				double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
				double remainTime = (shipCageNextHarvestTimeStamp - serverTimeStamp) / (double)Singleton<TimeUtil>.Instance.InverseMillisecond;
				string countDownText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat4(remainTime).CountDownText;
				base.ComponentData.TimeText = countDownText;
			}
		}

		// Token: 0x060422A3 RID: 271011 RVA: 0x010F930B File Offset: 0x010F750B
		public void Init(int configId)
		{
			this.ConfigId = configId;
		}

		// Token: 0x060422A4 RID: 271012 RVA: 0x010F9314 File Offset: 0x010F7514
		[NullableContext(1)]
		public override List<DockyardItemBlockOriginalData> GetShowItemList()
		{
			return ModelBase<FishingModel>.Instance.GetCageDataList(this.ConfigId);
		}

		// Token: 0x060422A5 RID: 271013 RVA: 0x010F9328 File Offset: 0x010F7528
		protected override bool CheckOtherCanDragCondition(bool fromDragResult)
		{
			if (base.CheckSelectedInList())
			{
				return true;
			}
			bool flag = base.ShowItemList.Count < this.MaxCount;
			if (fromDragResult && !flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_CageFull", Array.Empty<object>());
			}
			return flag;
		}

		// Token: 0x04024DBE RID: 150974
		private int ConfigId;

		// Token: 0x04024DBF RID: 150975
		private int MaxCount;
	}
}
