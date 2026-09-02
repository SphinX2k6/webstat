using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056D3 RID: 22227
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class MusicalInstrumentBaseView : UiViewBase
	{
		// Token: 0x0603893E RID: 231742 RVA: 0x00E5596B File Offset: 0x00E53B6B
		[NullableContext(1)]
		protected MusicalInstrumentBaseView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603893F RID: 231743
		protected abstract EInstrumentType GetMusicalInstrumentType();

		// Token: 0x06038940 RID: 231744 RVA: 0x00E5597F File Offset: 0x00E53B7F
		protected virtual void OnQtePerformance(int rowIndex, int columnIndex, bool success)
		{
		}

		// Token: 0x06038941 RID: 231745 RVA: 0x00E55984 File Offset: 0x00E53B84
		protected MusicalInstrumentKeyItem GetKeyItem(int rowIndex, int columnIndex)
		{
			if (rowIndex < 0 || rowIndex >= this.KeyItems.Count)
			{
				return null;
			}
			List<MusicalInstrumentKeyItem> list = this.KeyItems[rowIndex];
			if (columnIndex < 0 || columnIndex >= list.Count)
			{
				return null;
			}
			return list[columnIndex];
		}

		// Token: 0x06038942 RID: 231746 RVA: 0x00E559C8 File Offset: 0x00E53BC8
		protected void FocusCurrentQte()
		{
			MusicalInstrumentSubModel subModel = this.GetSubModel();
			List<MusicalInstrumentQteItemData> list;
			if (subModel == null)
			{
				list = null;
			}
			else
			{
				MusicalInstrumentQteData qteData = subModel.GetQteData();
				list = ((qteData != null) ? qteData.ItemDataList : null);
			}
			List<MusicalInstrumentQteItemData> list2 = list;
			if (list2 == null || this.QteCurrentIndex < 0 || this.QteCurrentIndex >= list2.Count)
			{
				return;
			}
			MusicalInstrumentQteItemData musicalInstrumentQteItemData = list2[this.QteCurrentIndex];
			MusicalInstrumentKeyItem keyItem = this.GetKeyItem(musicalInstrumentQteItemData.RowIndex, musicalInstrumentQteItemData.ColumnIndex);
			if (keyItem == null)
			{
				return;
			}
			keyItem.OnQteFocus(true);
		}

		// Token: 0x06038943 RID: 231747 RVA: 0x00E55A39 File Offset: 0x00E53C39
		protected virtual MusicalInstrumentSubModel GetSubModel()
		{
			return ModelBase<MusicalInstrumentModel>.Instance.GetSubModel(this.GetMusicalInstrumentType());
		}

		// Token: 0x06038944 RID: 231748 RVA: 0x00E55A4B File Offset: 0x00E53C4B
		protected MusicalInstrumentSubController GetSubController()
		{
			return ControllerBase<MusicalInstrumentController>.Instance.GetSubController(this.GetMusicalInstrumentType());
		}

		// Token: 0x06038945 RID: 231749 RVA: 0x00E55A5D File Offset: 0x00E53C5D
		protected void OnKeyItemPointerDown(int rowIndex, int columnIndex)
		{
			MusicalInstrumentSubModel subModel = this.GetSubModel();
			if (((subModel != null) ? subModel.GetQteData() : null) != null)
			{
				this.CheckQteSuccess(rowIndex, columnIndex);
				return;
			}
			this.PostAudioEventByIndex(rowIndex, columnIndex);
		}

		// Token: 0x06038946 RID: 231750
		protected abstract void PostAudioEventByIndex(int rowIndex, int columnIndex);

		// Token: 0x06038947 RID: 231751 RVA: 0x00E55A84 File Offset: 0x00E53C84
		protected void CheckQteSuccess(int rowIndex, int columnIndex)
		{
			MusicalInstrumentSubModel subModel = this.GetSubModel();
			MusicalInstrumentQteData musicalInstrumentQteData = (subModel != null) ? subModel.GetQteData() : null;
			if (musicalInstrumentQteData == null)
			{
				return;
			}
			List<MusicalInstrumentQteItemData> itemDataList = musicalInstrumentQteData.ItemDataList;
			if (this.QteCurrentIndex >= itemDataList.Count)
			{
				return;
			}
			MusicalInstrumentQteItemData musicalInstrumentQteItemData = musicalInstrumentQteData.ItemDataList[this.QteCurrentIndex];
			if (rowIndex != musicalInstrumentQteItemData.RowIndex || columnIndex != musicalInstrumentQteItemData.ColumnIndex)
			{
				MusicalInstrumentKeyItem keyItem = this.GetKeyItem(rowIndex, columnIndex);
				if (keyItem != null)
				{
					keyItem.OnQtePerformance(false);
				}
				this.OnQtePerformance(rowIndex, columnIndex, false);
				return;
			}
			musicalInstrumentQteItemData.Finished = true;
			musicalInstrumentQteItemData.IsFocus = false;
			MusicalInstrumentKeyItem keyItem2 = this.GetKeyItem(rowIndex, columnIndex);
			if (keyItem2 != null)
			{
				keyItem2.OnQteFocus(false);
			}
			MusicalInstrumentKeyItem keyItem3 = this.GetKeyItem(rowIndex, columnIndex);
			if (keyItem3 != null)
			{
				keyItem3.OnQtePerformance(true);
			}
			this.OnQtePerformance(rowIndex, columnIndex, true);
			this.QteCurrentIndex++;
			if (this.QteCurrentIndex >= itemDataList.Count)
			{
				MusicalInstrumentSubController subController = this.GetSubController();
				if (subController == null)
				{
					return;
				}
				subController.OnQteCompleted();
				return;
			}
			else
			{
				MusicalInstrumentQteItemData musicalInstrumentQteItemData2 = itemDataList[this.QteCurrentIndex];
				musicalInstrumentQteItemData2.IsFocus = true;
				MusicalInstrumentKeyItem keyItem4 = this.GetKeyItem(musicalInstrumentQteItemData2.RowIndex, musicalInstrumentQteItemData2.ColumnIndex);
				if (keyItem4 == null)
				{
					return;
				}
				keyItem4.OnQteFocus(true);
				return;
			}
		}

		// Token: 0x06038948 RID: 231752 RVA: 0x00E55BA3 File Offset: 0x00E53DA3
		protected void Exit()
		{
			ControllerBase<MusicalInstrumentController>.Instance.Exit(new MusicalInstrumentExitParam
			{
				Type = this.GetMusicalInstrumentType()
			}).Forget<bool>();
		}

		// Token: 0x04020477 RID: 132215
		protected int QteCurrentIndex;

		// Token: 0x04020478 RID: 132216
		[Nullable(1)]
		protected readonly List<List<MusicalInstrumentKeyItem>> KeyItems = new List<List<MusicalInstrumentKeyItem>>();
	}
}
