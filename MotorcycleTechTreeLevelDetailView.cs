using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022CA RID: 8906
public class MotorcycleTechTreeLevelDetailView : UiViewBase
{
	// Token: 0x06010D96 RID: 69014 RVA: 0x0049CA50 File Offset: 0x0049AC50
	[NullableContext(1)]
	public MotorcycleTechTreeLevelDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010D97 RID: 69015 RVA: 0x0049CA5C File Offset: 0x0049AC5C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06010D98 RID: 69016 RVA: 0x0049CAB8 File Offset: 0x0049ACB8
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnBackButtonClick));
		this.CaptionItem.SetTitleLocalText("MotorBike_TechTree_TechLevelDetail");
		this.CaptionItem.SetHelpBtnActive(false);
		this.LevelScrollList = new GenericScrollViewNew<MotorcycleTechTreeListLevelItem, IMotorTechLevelPoint>(base.GetScrollViewWithScrollbar(1), new Func<MotorcycleTechTreeListLevelItem>(this.InitItem), null, false, null);
		List<IMotorTechLevelPoint> list = this.OpenParam as List<IMotorTechLevelPoint>;
		this.LevelScrollList.RefreshByData(list ?? new List<IMotorTechLevelPoint>(), null, false);
	}

	// Token: 0x06010D99 RID: 69017 RVA: 0x0049CB4E File Offset: 0x0049AD4E
	protected override void OnBeforeDestroy()
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.Destroy(null);
	}

	// Token: 0x06010D9A RID: 69018 RVA: 0x0049CB61 File Offset: 0x0049AD61
	[NullableContext(1)]
	private MotorcycleTechTreeListLevelItem InitItem()
	{
		return new MotorcycleTechTreeListLevelItem();
	}

	// Token: 0x06010D9B RID: 69019 RVA: 0x0049CB68 File Offset: 0x0049AD68
	private void OnBackButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x040084CE RID: 33998
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040084CF RID: 33999
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<MotorcycleTechTreeListLevelItem, IMotorTechLevelPoint> LevelScrollList;

	// Token: 0x0200859A RID: 34202
	private class EMotorTechTreeLevelComponent
	{
		// Token: 0x0402D336 RID: 185142
		public const int ItemCaption = 0;

		// Token: 0x0402D337 RID: 185143
		public const int LevelContent = 1;

		// Token: 0x0402D338 RID: 185144
		public const int ItemLevel = 2;
	}
}
