using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EA9 RID: 7849
[NullableContext(1)]
[Nullable(0)]
public class QuestHandBookView : UiViewBase
{
	// Token: 0x0600E824 RID: 59428 RVA: 0x003EC391 File Offset: 0x003EA591
	public QuestHandBookView(UiViewInfo viewInfo) : base(viewInfo)
	{
		this.PlotTypeList = new List<PlotType>();
	}

	// Token: 0x0600E825 RID: 59429 RVA: 0x003EC3A8 File Offset: 0x003EA5A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600E826 RID: 59430 RVA: 0x003EC402 File Offset: 0x003EA602
	protected override void OnStart()
	{
		this.Refresh();
		this.InitCommonTabTitle();
	}

	// Token: 0x0600E827 RID: 59431 RVA: 0x003EC410 File Offset: 0x003EA610
	private void OnHandBookDataUpdate(EHandBookTabType eHandBookTabType, int i)
	{
		this.Refresh();
	}

	// Token: 0x0600E828 RID: 59432 RVA: 0x003EC418 File Offset: 0x003EA618
	protected void Refresh()
	{
		this.InitVerticalLayout();
		this.RefreshCollectText();
	}

	// Token: 0x0600E829 RID: 59433 RVA: 0x003EC428 File Offset: 0x003EA628
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Add<EHandBookTabType, int>(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhotoSelect, new Action<int>(this.OnPhotoSelect));
	}

	// Token: 0x0600E82A RID: 59434 RVA: 0x003EC48C File Offset: 0x003EA68C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhotoSelect, new Action<int>(this.OnPhotoSelect));
	}

	// Token: 0x0600E82B RID: 59435 RVA: 0x003EC4ED File Offset: 0x003EA6ED
	protected override void OnAfterShow()
	{
	}

	// Token: 0x0600E82C RID: 59436 RVA: 0x003EC4F0 File Offset: 0x003EA6F0
	protected void InitCommonTabTitle()
	{
		HandBookEntrance? handBookEntranceConfig = ConfigBase<HandBookConfig>.Instance.GetHandBookEntranceConfig(EHandBookTabType.Quest);
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickCloseButton));
		this.CaptionItem.SetTitleLocalText(handBookEntranceConfig.Value.Name);
		this.CaptionItem.SetTitleIcon(handBookEntranceConfig.Value.TitleIcon);
	}

	// Token: 0x0600E82D RID: 59437 RVA: 0x003EC568 File Offset: 0x003EA768
	protected void InitVerticalLayout()
	{
		List<PlotType> list = ConfigCommon.ToList<PlotType>(ConfigBase<HandBookConfig>.Instance.GetPlotTypeConfigList());
		list.Sort(new Comparison<PlotType>(this.SortIndex));
		this.PlotTypeList = list;
		if (this.GenericLayout == null)
		{
			this.GenericLayout = new GenericLayoutNew<PlotHandBookItem>(base.GetVerticalLayout(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<PlotHandBookItem>(this.InitPlotHandBookItem), null);
		}
		this.GenericLayout.ClearChildren();
		this.GenericLayout.RebuildLayoutByDataNew<PlotType>(this.PlotTypeList, null);
	}

	// Token: 0x0600E82E RID: 59438 RVA: 0x003EC5EC File Offset: 0x003EA7EC
	private ILayoutItem<PlotHandBookItem> InitPlotHandBookItem(object data, UUIItem uiItem, int index)
	{
		PlotHandBookItem plotHandBookItem = new PlotHandBookItem(uiItem);
		plotHandBookItem.Refresh((PlotType)data, false, index);
		return new LayoutItem<PlotHandBookItem>
		{
			Key = index,
			Value = plotHandBookItem
		};
	}

	// Token: 0x0600E82F RID: 59439 RVA: 0x003EC626 File Offset: 0x003EA826
	private int SortIndex(PlotType a, PlotType b)
	{
		return a.Id - b.Id;
	}

	// Token: 0x0600E830 RID: 59440 RVA: 0x003EC637 File Offset: 0x003EA837
	private void OnClickCloseButton()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.QuestHandBookView, null);
	}

	// Token: 0x0600E831 RID: 59441 RVA: 0x003EC64C File Offset: 0x003EA84C
	protected void RefreshCollectText()
	{
		int[] collectProgress = ControllerBase<HandBookController>.Instance.GetCollectProgress(EHandBookTabType.Quest);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
		{
			collectProgress[0],
			collectProgress[1]
		}));
	}

	// Token: 0x0600E832 RID: 59442 RVA: 0x003EC69C File Offset: 0x003EA89C
	protected override void OnBeforeShow()
	{
		bool flag = true;
		GenericLayoutNew<PlotHandBookItem> genericLayout = this.GenericLayout;
		List<PlotHandBookItem> list = (genericLayout != null) ? genericLayout.GetLayoutItemList() : null;
		if (list != null)
		{
			foreach (PlotHandBookItem plotHandBookItem in list)
			{
				foreach (PlotHandBookChildItem plotHandBookChildItem in plotHandBookItem.GetChildItemList())
				{
					UUIExtendToggle tog = plotHandBookChildItem.GetTog();
					if (flag && plotHandBookChildItem.GetIsUnlock())
					{
						tog.SetToggleStateForce(EToggleState.ETT_Checked, false, true, false);
						flag = false;
					}
					else
					{
						tog.SetToggleStateForce(EToggleState.ETT_UnChecked, false, true, false);
					}
				}
			}
		}
	}

	// Token: 0x0600E833 RID: 59443 RVA: 0x003EC768 File Offset: 0x003EA968
	protected override void OnBeforeDestroy()
	{
		if (this.GenericLayout != null)
		{
			this.GenericLayout.ClearChildren();
			this.GenericLayout = null;
		}
		this.PlotTypeList = new List<PlotType>();
	}

	// Token: 0x0600E834 RID: 59444 RVA: 0x003EC790 File Offset: 0x003EA990
	protected void OnPhotoSelect(int configId)
	{
		GenericLayoutNew<PlotHandBookItem> genericLayout = this.GenericLayout;
		List<PlotHandBookItem> list = (genericLayout != null) ? genericLayout.GetLayoutItemList() : null;
		if (list != null)
		{
			foreach (PlotHandBookItem plotHandBookItem in list)
			{
				foreach (PlotHandBookChildItem plotHandBookChildItem in plotHandBookItem.GetChildItemList())
				{
					UUIExtendToggle tog = plotHandBookChildItem.GetTog();
					HandBookCommonItemData data = plotHandBookChildItem.GetData();
					if (data != null)
					{
						if (((PhotographHandBook)data.Config).Id == configId)
						{
							tog.SetToggleStateForce(EToggleState.ETT_Checked, false, true, false);
						}
						else
						{
							tog.SetToggleStateForce(EToggleState.ETT_UnChecked, false, true, false);
						}
					}
				}
			}
		}
	}

	// Token: 0x04006FE4 RID: 28644
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayoutNew<PlotHandBookItem> GenericLayout;

	// Token: 0x04006FE5 RID: 28645
	private List<PlotType> PlotTypeList;

	// Token: 0x04006FE6 RID: 28646
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x020081EA RID: 33258
	[NullableContext(0)]
	private class EGeographyHandBookViewDefine
	{
		// Token: 0x0402C13A RID: 180538
		public const int TitleItem = 0;

		// Token: 0x0402C13B RID: 180539
		public const int VerticalLayout = 1;

		// Token: 0x0402C13C RID: 180540
		public const int CollectCountText = 2;
	}
}
