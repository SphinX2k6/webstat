using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022C2 RID: 8898
public class MotorcycleLevelAttrDetailView : UiViewBase
{
	// Token: 0x06010D1D RID: 68893 RVA: 0x0049A47C File Offset: 0x0049867C
	[NullableContext(1)]
	public MotorcycleLevelAttrDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010D1E RID: 68894 RVA: 0x0049A488 File Offset: 0x00498688
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06010D1F RID: 68895 RVA: 0x0049A4E4 File Offset: 0x004986E4
	protected override void OnStart()
	{
		string stringConfig = ConfigCommonParamById.GetStringConfig("MotorAttributeIcon");
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnBackButtonClick));
		this.CaptionItem.SetTitleLocalText("PrefabTextItem_1302715335_Text");
		if (!string.IsNullOrEmpty(stringConfig))
		{
			this.CaptionItem.SetTitleIcon(stringConfig);
		}
		this.AttrScrollList = new GenericScrollViewNew<MotorcycleLevelAttrListScrollItem, IMotorLevelAttrData>(base.GetScrollViewWithScrollbar(1), new Func<MotorcycleLevelAttrListScrollItem>(this.InitAttrItem), null, false, null);
		List<IMotorLevelAttrData> list = this.OpenParam as List<IMotorLevelAttrData>;
		this.AttrScrollList.RefreshByData(list ?? new List<IMotorLevelAttrData>(), null, false);
	}

	// Token: 0x06010D20 RID: 68896 RVA: 0x0049A58D File Offset: 0x0049878D
	protected override void OnBeforeDestroy()
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.Destroy(null);
	}

	// Token: 0x06010D21 RID: 68897 RVA: 0x0049A5A0 File Offset: 0x004987A0
	[NullableContext(1)]
	private MotorcycleLevelAttrListScrollItem InitAttrItem()
	{
		return new MotorcycleLevelAttrListScrollItem();
	}

	// Token: 0x06010D22 RID: 68898 RVA: 0x0049A5A7 File Offset: 0x004987A7
	private void OnBackButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400849B RID: 33947
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400849C RID: 33948
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<MotorcycleLevelAttrListScrollItem, IMotorLevelAttrData> AttrScrollList;

	// Token: 0x0200857E RID: 34174
	private class EAttributeView
	{
		// Token: 0x0402D2B8 RID: 185016
		public const int ItemCaption = 0;

		// Token: 0x0402D2B9 RID: 185017
		public const int AttributeContent = 1;

		// Token: 0x0402D2BA RID: 185018
		public const int ItemAttribute = 2;
	}
}
