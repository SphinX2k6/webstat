using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001777 RID: 6007
[NullableContext(1)]
[Nullable(0)]
public class AdivceSelectItem : UiPanelBase
{
	// Token: 0x0600A926 RID: 43302 RVA: 0x002D124C File Offset: 0x002CF44C
	public AdivceSelectItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A927 RID: 43303 RVA: 0x002D1278 File Offset: 0x002CF478
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0600A928 RID: 43304 RVA: 0x002D12E8 File Offset: 0x002CF4E8
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600A929 RID: 43305 RVA: 0x002D1310 File Offset: 0x002CF510
	public void RefreshView(AdviceSelectItemData[] dataList)
	{
		this.ResetView();
		int num = 0;
		int num2 = 0;
		foreach (AdviceSelectItemData adviceSelectItemData in dataList)
		{
			if (adviceSelectItemData.GetIndex() != EAdviceSelectItemEnum.CutLine)
			{
				AdviceSelectBtnContentItem adviceSelectBtnItem = this.GetAdviceSelectBtnItem(num);
				adviceSelectBtnItem.GetRootItem().SetUIParent(base.GetScrollViewWithScrollbar(0).ContentUIItem, false);
				adviceSelectBtnItem.RefreshView(adviceSelectItemData);
				num++;
			}
			else
			{
				this.GetLineItem(num2).GetRootItem().SetUIParent(base.GetScrollViewWithScrollbar(0).ContentUIItem, false);
				num2++;
			}
		}
	}

	// Token: 0x0600A92A RID: 43306 RVA: 0x002D13A0 File Offset: 0x002CF5A0
	private void ResetView()
	{
		foreach (AdviceSelectBtnContentItem adviceSelectBtnContentItem in this.AdviceSelectBtnContentItem)
		{
			adviceSelectBtnContentItem.GetRootItem().SetUIActive(false);
			adviceSelectBtnContentItem.GetRootItem().SetUIParent(this.RootItem, false);
		}
		foreach (AdviceSelectLineContentItem adviceSelectLineContentItem in this.AdviceSelectLineContentItem)
		{
			adviceSelectLineContentItem.GetRootItem().SetUIActive(false);
			adviceSelectLineContentItem.GetRootItem().SetUIParent(this.RootItem, false);
		}
	}

	// Token: 0x0600A92B RID: 43307 RVA: 0x002D1460 File Offset: 0x002CF660
	private AdviceSelectBtnContentItem GetAdviceSelectBtnItem(int index)
	{
		if (this.AdviceSelectBtnContentItem.Count > index)
		{
			this.AdviceSelectBtnContentItem[index].GetRootItem().SetUIActive(true);
			return this.AdviceSelectBtnContentItem[index];
		}
		UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(2), null);
		uuiitem.SetUIActive(true);
		AdviceSelectBtnContentItem adviceSelectBtnContentItem = new AdviceSelectBtnContentItem(uuiitem);
		this.AdviceSelectBtnContentItem.Add(adviceSelectBtnContentItem);
		return adviceSelectBtnContentItem;
	}

	// Token: 0x0600A92C RID: 43308 RVA: 0x002D14CC File Offset: 0x002CF6CC
	private AdviceSelectLineContentItem GetLineItem(int index)
	{
		if (this.AdviceSelectLineContentItem.Count > index)
		{
			this.AdviceSelectLineContentItem[index].GetRootItem().SetUIActive(true);
			return this.AdviceSelectLineContentItem[index];
		}
		UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(3), null);
		uuiitem.SetUIActive(true);
		AdviceSelectLineContentItem adviceSelectLineContentItem = new AdviceSelectLineContentItem(uuiitem);
		this.AdviceSelectLineContentItem.Add(adviceSelectLineContentItem);
		return adviceSelectLineContentItem;
	}

	// Token: 0x04004FBE RID: 20414
	public const string SPRITEONE = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnOne.SP_AdviceBtnOne";

	// Token: 0x04004FBF RID: 20415
	public const string SPRITETWO = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnTwo.SP_AdviceBtnTwo";

	// Token: 0x04004FC0 RID: 20416
	public const string SPRITETHREE = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnThree.SP_AdviceBtnThree";

	// Token: 0x04004FC1 RID: 20417
	public const string SPRITEEXPRESSION = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnbiaoqing.SP_AdviceBtnbiaoqing";

	// Token: 0x04004FC2 RID: 20418
	public const string SPRITECHANGE = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnHuan.SP_AdviceBtnHuan";

	// Token: 0x04004FC3 RID: 20419
	public const string SPRITEADD = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnJia.SP_AdviceBtnJia";

	// Token: 0x04004FC4 RID: 20420
	public const string SPRITEDECREASE = "/Game/Aki/UI/UIResources/UiAdvice/Atlas/SP_AdviceBtnJian.SP_AdviceBtnJian";

	// Token: 0x04004FC5 RID: 20421
	private readonly List<AdviceSelectBtnContentItem> AdviceSelectBtnContentItem = new List<AdviceSelectBtnContentItem>();

	// Token: 0x04004FC6 RID: 20422
	private readonly List<AdviceSelectLineContentItem> AdviceSelectLineContentItem = new List<AdviceSelectLineContentItem>();

	// Token: 0x02007ADA RID: 31450
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x0402A121 RID: 172321
		public const int Scroller = 0;

		// Token: 0x0402A122 RID: 172322
		public const int Content = 1;

		// Token: 0x0402A123 RID: 172323
		public const int BtnItem = 2;

		// Token: 0x0402A124 RID: 172324
		public const int LineItem = 3;
	}
}
