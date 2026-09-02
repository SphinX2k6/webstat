using System;
using CSharpScript.Game.Ui;

// Token: 0x02002B8B RID: 11147
public class SurvivorsRogueCommandViewData : IViewOpenParamMultipleView
{
	// Token: 0x17001CF0 RID: 7408
	// (get) Token: 0x0601635F RID: 90975 RVA: 0x00629594 File Offset: 0x00627794
	public int CommandIncId { get; }

	// Token: 0x17001CF1 RID: 7409
	// (get) Token: 0x06016360 RID: 90976 RVA: 0x0062959C File Offset: 0x0062779C
	// (set) Token: 0x06016361 RID: 90977 RVA: 0x006295A4 File Offset: 0x006277A4
	public bool IsMultipleView { get; set; }

	// Token: 0x06016362 RID: 90978 RVA: 0x006295AD File Offset: 0x006277AD
	public SurvivorsRogueCommandViewData(int commandIncId, bool isMultipleView = false)
	{
		this.CommandIncId = commandIncId;
		this.IsMultipleView = isMultipleView;
	}
}
