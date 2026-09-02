using System;
using CSharpScript.Core.Common;

// Token: 0x0200262E RID: 9774
[EnumExtensions]
public enum EQteItem
{
	// Token: 0x0400962C RID: 38444
	[EnumStringMember("UiItem_QteBtnSingleTap")]
	SingleClickItem,
	// Token: 0x0400962D RID: 38445
	[EnumStringMember("UiItem_QteBtnTapRapidly")]
	ContinuousClickItem,
	// Token: 0x0400962E RID: 38446
	[EnumStringMember("UiItem_QteDrag")]
	DragItem,
	// Token: 0x0400962F RID: 38447
	[EnumStringMember("UiItem_QteBtnLongPress")]
	LongPressItem,
	// Token: 0x04009630 RID: 38448
	[EnumStringMember("UiView_PlotInteraction")]
	SelectOptionItem,
	// Token: 0x04009631 RID: 38449
	[EnumStringMember("UiItem_QteObjectPos")]
	CustomOptionItem,
	// Token: 0x04009632 RID: 38450
	[EnumStringMember("UiItem_PullUp")]
	PullUpItem,
	// Token: 0x04009633 RID: 38451
	[EnumStringMember("UiItem_PullDown")]
	PullDownItem,
	// Token: 0x04009634 RID: 38452
	[EnumStringMember("UiItem_FocusSingleButton")]
	FocusSingleButtonItem,
	// Token: 0x04009635 RID: 38453
	[EnumStringMember("UiItem_QteBtnRingTab")]
	RingTapItem,
	// Token: 0x04009636 RID: 38454
	[EnumStringMember("UiItem_QteBtnRingMatch")]
	RingMatchTapItem,
	// Token: 0x04009637 RID: 38455
	[EnumStringMember("UiItem_CompassRotate")]
	CompassRotateItem,
	// Token: 0x04009638 RID: 38456
	[EnumStringMember("UiItem_FullScreenLongPress")]
	FullScreenLongPressItem,
	// Token: 0x04009639 RID: 38457
	[EnumStringMember("UiItem_RightScreenDragItem")]
	RightScreenDragItem,
	// Token: 0x0400963A RID: 38458
	[EnumStringMember("UiItem_PlotQteSuisui")]
	SuisuiSlideItem,
	// Token: 0x0400963B RID: 38459
	[EnumStringMember("UiItem_PlotQteSuisuiRight")]
	SuisuiRight,
	// Token: 0x0400963C RID: 38460
	[EnumStringMember("UiItem_PlotQteSuisuiDown")]
	SuisuiDown
}
