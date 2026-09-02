using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BF7 RID: 11255
public class TowerGuidePanel : UiPanelBase
{
	// Token: 0x0601675B RID: 91995 RVA: 0x0063D460 File Offset: 0x0063B660
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601675C RID: 91996 RVA: 0x0063D52C File Offset: 0x0063B72C
	protected override void OnStart()
	{
		this.BuffShowLayout = new GenericScrollViewNew<TowerBuffShowItem, long>(base.GetScrollViewWithScrollbar(4), new Func<TowerBuffShowItem>(this.InitBuffItem), null, false, null);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_ImgHelp_DailyTower_001_UI");
		base.SetTextureByPath(resourcePath, base.GetTexture(3), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "TowerGuideDes", Array.Empty<object>());
	}

	// Token: 0x0601675D RID: 91997 RVA: 0x0063D5A0 File Offset: 0x0063B7A0
	protected override void OnBeforeShow()
	{
		int currentTowerId = ModelBase<TowerModel>.Instance.CurrentTowerId;
		if (currentTowerId == 0)
		{
			return;
		}
		TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(currentTowerId);
		if (towerInfo == null)
		{
			return;
		}
		this.BuffShowLayout.RefreshByData(towerInfo.Value.ShowBuffs().ToList<long>(), null, false);
	}

	// Token: 0x0601675E RID: 91998 RVA: 0x0063D5F3 File Offset: 0x0063B7F3
	[NullableContext(1)]
	private TowerBuffShowItem InitBuffItem()
	{
		return new TowerBuffShowItem();
	}

	// Token: 0x0400ADDF RID: 44511
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<TowerBuffShowItem, long> BuffShowLayout;

	// Token: 0x02008EEE RID: 36590
	private enum EChildType
	{
		// Token: 0x04030034 RID: 196660
		ItemOffset,
		// Token: 0x04030035 RID: 196661
		TxtSubTitle,
		// Token: 0x04030036 RID: 196662
		TxtTutorials,
		// Token: 0x04030037 RID: 196663
		TexPicture,
		// Token: 0x04030038 RID: 196664
		ScrollBuff
	}
}
