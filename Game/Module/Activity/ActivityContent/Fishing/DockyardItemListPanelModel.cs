using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067BC RID: 26556
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class DockyardItemListPanelModel
	{
		// Token: 0x1700A109 RID: 41225
		// (get) Token: 0x060423EE RID: 271342 RVA: 0x010FEB1A File Offset: 0x010FCD1A
		// (set) Token: 0x060423EF RID: 271343 RVA: 0x010FEB22 File Offset: 0x010FCD22
		public DockyardItemListPanel Panel { get; set; }

		// Token: 0x1700A10A RID: 41226
		// (get) Token: 0x060423F0 RID: 271344 RVA: 0x010FEB2B File Offset: 0x010FCD2B
		// (set) Token: 0x060423F1 RID: 271345 RVA: 0x010FEB33 File Offset: 0x010FCD33
		protected IDockyardWareHouseInterface BackpackPanelModel { get; set; }

		// Token: 0x1700A10B RID: 41227
		// (get) Token: 0x060423F2 RID: 271346 RVA: 0x010FEB3C File Offset: 0x010FCD3C
		// (set) Token: 0x060423F3 RID: 271347 RVA: 0x010FEB44 File Offset: 0x010FCD44
		public List<DockyardItemBlockOriginalData> ShowItemList { get; set; } = new List<DockyardItemBlockOriginalData>();

		// Token: 0x1700A10C RID: 41228
		// (get) Token: 0x060423F4 RID: 271348 RVA: 0x010FEB4D File Offset: 0x010FCD4D
		// (set) Token: 0x060423F5 RID: 271349 RVA: 0x010FEB55 File Offset: 0x010FCD55
		public int InSelectedBlockId { get; set; } = -1;

		// Token: 0x1700A10D RID: 41229
		// (get) Token: 0x060423F6 RID: 271350 RVA: 0x010FEB5E File Offset: 0x010FCD5E
		// (set) Token: 0x060423F7 RID: 271351 RVA: 0x010FEB66 File Offset: 0x010FCD66
		public IPanelComponentData ComponentData { get; set; } = new PanelComponentData
		{
			TitleText = "",
			GetCountText = null,
			HelpBtnId = 0,
			TimeText = ""
		};

		// Token: 0x060423F8 RID: 271352 RVA: 0x010FEB6F File Offset: 0x010FCD6F
		public void RegisterPanel(DockyardItemListPanel panel)
		{
			this.Panel = panel;
			this.OnInit();
		}

		// Token: 0x060423F9 RID: 271353 RVA: 0x010FEB80 File Offset: 0x010FCD80
		public void RefreshShowItemList()
		{
			this.ShowItemMap.Clear();
			this.ShowItemList = this.GetShowItemList();
			foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData in this.ShowItemList)
			{
				this.ShowItemMap.Add(dockyardItemBlockOriginalData.IncId, dockyardItemBlockOriginalData);
			}
		}

		// Token: 0x060423FA RID: 271354 RVA: 0x010FEBF8 File Offset: 0x010FCDF8
		public void RegisterBackpackPanelModel(IDockyardWareHouseInterface backpackPanelModel)
		{
			this.BackpackPanelModel = backpackPanelModel;
		}

		// Token: 0x060423FB RID: 271355 RVA: 0x010FEC04 File Offset: 0x010FCE04
		private UniTask DragClickAsync(DockyardItemBlockOriginalData data)
		{
			DockyardItemListPanelModel.<DragClickAsync>d__24 <DragClickAsync>d__;
			<DragClickAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DragClickAsync>d__.<>4__this = this;
			<DragClickAsync>d__.data = data;
			<DragClickAsync>d__.<>1__state = -1;
			<DragClickAsync>d__.<>t__builder.Start<DockyardItemListPanelModel.<DragClickAsync>d__24>(ref <DragClickAsync>d__);
			return <DragClickAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060423FC RID: 271356 RVA: 0x010FEC4F File Offset: 0x010FCE4F
		public void DragClick(DockyardItemBlockOriginalData data)
		{
			this.DragClickAsync(data);
		}

		// Token: 0x060423FD RID: 271357 RVA: 0x010FEC5C File Offset: 0x010FCE5C
		public void DragBegin(DockyardItemBlockOriginalData data)
		{
			if (!this.CanClick(data.IncId))
			{
				return;
			}
			this.InSelectedBlockId = data.IncId;
			ModelBase<DockyardModel>.Instance.AddListItemReadFlag(data.ItemId);
			IDockyardWareHouseInterface backpackPanelModel = this.BackpackPanelModel;
			if (backpackPanelModel != null)
			{
				backpackPanelModel.WareHouseItemDragBegin(data);
			}
			this.Panel.RefreshListItemRedDot(data.ItemId);
			this.Panel.RefreshListItemStateByIncId(data.IncId);
			this.Panel.RefreshListItem();
		}

		// Token: 0x060423FE RID: 271358 RVA: 0x010FECD4 File Offset: 0x010FCED4
		private bool CanClick(int id)
		{
			if (id == this.InSelectedBlockId)
			{
				return false;
			}
			IDockyardWareHouseInterface backpackPanelModel = this.BackpackPanelModel;
			return backpackPanelModel == null || backpackPanelModel.IsWareHouseItemCanClick(id);
		}

		// Token: 0x060423FF RID: 271359 RVA: 0x010FECF3 File Offset: 0x010FCEF3
		private bool DeleteSelectedItemBlock()
		{
			if (this.InSelectedBlockId == -1)
			{
				return false;
			}
			bool result = this.RemoveShowListData(this.InSelectedBlockId);
			this.InSelectedBlockId = -1;
			return result;
		}

		// Token: 0x06042400 RID: 271360 RVA: 0x010FED13 File Offset: 0x010FCF13
		public void SetItemBlockToWareHouse(DockyardItemBlockOriginalData data)
		{
			this.DeleteSelectedItemBlock();
			this.AddShowListData(data);
			DockyardItemListPanel panel = this.Panel;
			if (panel == null)
			{
				return;
			}
			panel.RefreshListItem();
		}

		// Token: 0x06042401 RID: 271361 RVA: 0x010FED34 File Offset: 0x010FCF34
		public void DeleteItemBlockListFromWareHouse(List<int> incIdList)
		{
			bool flag = false;
			foreach (int id in incIdList)
			{
				bool flag2 = this.RemoveShowListData(id);
				flag = (flag || flag2);
			}
			if (flag)
			{
				DockyardItemListPanel panel = this.Panel;
				if (panel == null)
				{
					return;
				}
				panel.RefreshListItem();
			}
		}

		// Token: 0x06042402 RID: 271362 RVA: 0x010FEDA0 File Offset: 0x010FCFA0
		public void DeleteSelectedItemBlockAndRefresh()
		{
			if (this.DeleteSelectedItemBlock())
			{
				DockyardItemListPanel panel = this.Panel;
				if (panel == null)
				{
					return;
				}
				panel.RefreshListItem();
			}
		}

		// Token: 0x06042403 RID: 271363 RVA: 0x010FEDBB File Offset: 0x010FCFBB
		public void ResetSelectedBlock()
		{
			this.InSelectedBlockId = -1;
		}

		// Token: 0x06042404 RID: 271364 RVA: 0x010FEDC4 File Offset: 0x010FCFC4
		public bool HasItemBlockInWareHouse(int incId)
		{
			return this.ShowItemMap.ContainsKey(incId);
		}

		// Token: 0x06042405 RID: 271365 RVA: 0x010FEDD2 File Offset: 0x010FCFD2
		private void AddShowListData(DockyardItemBlockOriginalData data)
		{
			this.ShowItemList.Insert(0, data);
			this.ShowItemMap.Add(data.IncId, data);
		}

		// Token: 0x06042406 RID: 271366 RVA: 0x010FEDF4 File Offset: 0x010FCFF4
		private bool RemoveShowListData(int id)
		{
			DockyardItemBlockOriginalData item = this.ShowItemMap[id];
			int num = this.ShowItemList.IndexOf(item);
			if (num >= 0)
			{
				this.ShowItemList.RemoveAt(num);
			}
			return this.ShowItemMap.Remove(id);
		}

		// Token: 0x06042407 RID: 271367 RVA: 0x010FEE37 File Offset: 0x010FD037
		private bool CheckOpenFunction()
		{
			return ModelBase<FunctionModel>.Instance.IsOpen(10076);
		}

		// Token: 0x06042408 RID: 271368 RVA: 0x010FEE48 File Offset: 0x010FD048
		protected bool CheckSelectedInList()
		{
			DockyardItemListPanelModel.<>c__DisplayClass37_0 CS$<>8__locals1 = new DockyardItemListPanelModel.<>c__DisplayClass37_0();
			DockyardItemListPanelModel.<>c__DisplayClass37_0 CS$<>8__locals2 = CS$<>8__locals1;
			IDockyardWareHouseInterface backpackPanelModel = this.BackpackPanelModel;
			CS$<>8__locals2.selected = ((backpackPanelModel != null) ? new int?(backpackPanelModel.GetSelectedId()) : null);
			return CS$<>8__locals1.selected.GetValueOrDefault() != -1 && this.GetShowItemList().Any(delegate(DockyardItemBlockOriginalData item)
			{
				int incId = item.IncId;
				int? selected = CS$<>8__locals1.selected;
				return incId == selected.GetValueOrDefault() & selected != null;
			});
		}

		// Token: 0x06042409 RID: 271369 RVA: 0x010FEEA8 File Offset: 0x010FD0A8
		public bool CanDragToListPanel(bool ignoreViewportCheck)
		{
			if (!ignoreViewportCheck && this.Panel != null && !this.Panel.CheckInViewport())
			{
				return false;
			}
			if (!this.CheckOtherCanDragCondition(true))
			{
				return false;
			}
			if (!this.CheckOpenFunction() && !this.CheckSelectedInList())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_FishingBanMoveBack", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x0604240A RID: 271370 RVA: 0x010FEF04 File Offset: 0x010FD104
		public void RefreshDragTips(bool isInDrag, bool isInBackpack)
		{
			if (this.Panel != null)
			{
				bool flag = this.Panel.CheckInViewport() && this.CheckOtherCanDragCondition(false);
				this.Panel.SetDragTipsActive(isInDrag && !isInBackpack && flag);
			}
		}

		// Token: 0x0604240B RID: 271371 RVA: 0x010FEF48 File Offset: 0x010FD148
		protected virtual bool CheckOtherCanDragCondition(bool fromDragResult)
		{
			return true;
		}

		// Token: 0x0604240C RID: 271372
		public abstract List<DockyardItemBlockOriginalData> GetShowItemList();

		// Token: 0x0604240D RID: 271373 RVA: 0x010FEF4B File Offset: 0x010FD14B
		protected virtual void OnInit()
		{
		}

		// Token: 0x04024E54 RID: 151124
		private readonly Dictionary<int, DockyardItemBlockOriginalData> ShowItemMap = new Dictionary<int, DockyardItemBlockOriginalData>();
	}
}
