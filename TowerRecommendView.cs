using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BFC RID: 11260
public class TowerRecommendView : UiViewBase
{
	// Token: 0x06016789 RID: 92041 RVA: 0x0063EE30 File Offset: 0x0063D030
	[NullableContext(1)]
	public TowerRecommendView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0601678A RID: 92042 RVA: 0x0063EE39 File Offset: 0x0063D039
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0601678B RID: 92043 RVA: 0x0063EE72 File Offset: 0x0063D072
	protected override void OnStart()
	{
		this.FormationScroll = new GenericScrollViewNew<TowerRecommendItem, TowerRecommendFormation>(base.GetScrollViewWithScrollbar(0), new Func<TowerRecommendItem>(this.RefreshItem), null, false, null);
		this.RefreshView();
	}

	// Token: 0x0601678C RID: 92044 RVA: 0x0063EE9B File Offset: 0x0063D09B
	protected override void OnBeforeDestroy()
	{
		this.FormationScroll = null;
	}

	// Token: 0x0601678D RID: 92045 RVA: 0x0063EEA4 File Offset: 0x0063D0A4
	private void RefreshView()
	{
		if (ModelBase<TowerModel>.Instance.RecommendFormation != null && ModelBase<TowerModel>.Instance.RecommendFormation.Length != 0)
		{
			this.FormationScroll.SetActive(true);
			List<TowerRecommendFormation> list = new List<TowerRecommendFormation>();
			int num = ModelBase<TowerModel>.Instance.RecommendFormation.Length;
			for (int i = 0; i < num; i++)
			{
				list.Add(ModelBase<TowerModel>.Instance.RecommendFormation[i]);
			}
			this.FormationScroll.RefreshByData(list, null, false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_DataFromOther_Text", Array.Empty<object>());
			return;
		}
		this.FormationScroll.SetActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_DataCollation_Text", Array.Empty<object>());
	}

	// Token: 0x0601678E RID: 92046 RVA: 0x0063EF58 File Offset: 0x0063D158
	[NullableContext(1)]
	private TowerRecommendItem RefreshItem()
	{
		return new TowerRecommendItem();
	}

	// Token: 0x0400ADEF RID: 44527
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<TowerRecommendItem, TowerRecommendFormation> FormationScroll;

	// Token: 0x02008EF6 RID: 36598
	private enum EChildType
	{
		// Token: 0x04030076 RID: 196726
		ScrollView,
		// Token: 0x04030077 RID: 196727
		TipText
	}
}
