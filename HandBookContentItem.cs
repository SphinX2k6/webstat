using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E52 RID: 7762
public class HandBookContentItem : UiPanelBase
{
	// Token: 0x0600E603 RID: 58883 RVA: 0x003E1655 File Offset: 0x003DF855
	[NullableContext(1)]
	public HandBookContentItem(HandBookContentItemData handBookContentItemData, UUIItem uiItem)
	{
		this.HandBookContentItemData = handBookContentItemData;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600E604 RID: 58884 RVA: 0x003E1671 File Offset: 0x003DF871
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600E605 RID: 58885 RVA: 0x003E16AC File Offset: 0x003DF8AC
	protected override void OnStart()
	{
		if (this.HandBookContentItemData == null)
		{
			return;
		}
		UUIText text = base.GetText(0);
		if (!string.IsNullOrEmpty(this.HandBookContentItemData.Title))
		{
			text.SetUIActive(true);
			text.SetText(this.HandBookContentItemData.Title, true);
		}
		else
		{
			text.SetUIActive(false);
		}
		UUIText text2 = base.GetText(1);
		if (!string.IsNullOrEmpty(this.HandBookContentItemData.Desc))
		{
			text2.SetUIActive(true);
			text2.SetText(this.HandBookContentItemData.Desc, true);
			return;
		}
		text2.SetUIActive(false);
	}

	// Token: 0x0600E606 RID: 58886 RVA: 0x003E1739 File Offset: 0x003DF939
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x04006EB1 RID: 28337
	[Nullable(1)]
	public HandBookContentItemData HandBookContentItemData;

	// Token: 0x020081B2 RID: 33202
	private class EHandBookContentItemDefine
	{
		// Token: 0x0402C04F RID: 180303
		public const int TitleText = 0;

		// Token: 0x0402C050 RID: 180304
		public const int ContentText = 1;
	}
}
