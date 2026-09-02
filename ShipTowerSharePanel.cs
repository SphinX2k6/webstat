using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020029DA RID: 10714
public class ShipTowerSharePanel : UiPanelBase
{
	// Token: 0x060155BE RID: 87486 RVA: 0x005EB2F8 File Offset: 0x005E94F8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText))
		};
	}

	// Token: 0x060155BF RID: 87487 RVA: 0x005EB3C0 File Offset: 0x005E95C0
	protected override void OnStart()
	{
		ShipTowerRecordShareData shipTowerRecordShareData = this.OpenParam as ShipTowerRecordShareData;
		if (shipTowerRecordShareData == null)
		{
			return;
		}
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(shipTowerRecordShareData.TotalScore.ToString(), true);
		}
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			text2.SetText(shipTowerRecordShareData.TotalWave.ToString(), true);
		}
		UUIText text3 = base.GetText(5);
		if (text3 != null)
		{
			text3.SetText(shipTowerRecordShareData.DateText, true);
		}
		UUITexture texture = base.GetTexture(2);
		if (texture != null)
		{
			bool flag = shipTowerRecordShareData.GradeResId != null;
			texture.SetUIActive(flag);
			if (flag)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(shipTowerRecordShareData.GradeResId);
				base.SetTextureByPath(resourcePath, texture, null, null);
			}
		}
		UUIItem item = base.GetItem(4);
		AUIBaseActor gridActor = ((item != null) ? item.GetOwner() : null) as AUIBaseActor;
		this.LineupLayout = new GenericLayout<ShipTowerShareLineupItem, ShipTowerRecordItemData>(base.GetVerticalLayout(3), () => new ShipTowerShareLineupItem(), gridActor, false, true);
		this.LineupLayout.RefreshByData(shipTowerRecordShareData.RecordList, null, false);
	}

	// Token: 0x060155C0 RID: 87488 RVA: 0x005EB4D7 File Offset: 0x005E96D7
	[NullableContext(2)]
	public AActor GetBlurOverrideActor()
	{
		AUIBaseActor rootActor = this.RootActor;
		TsUiBlur tsUiBlur = ((rootActor != null) ? rootActor.GetComponentByClass(TsUiBlur.StaticClass()) : null) as TsUiBlur;
		if (tsUiBlur == null)
		{
			return null;
		}
		return tsUiBlur.OverrideItem;
	}

	// Token: 0x0400A47C RID: 42108
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerShareLineupItem, ShipTowerRecordItemData> LineupLayout;

	// Token: 0x02008D46 RID: 36166
	private enum EShipTowerSharePanelComp
	{
		// Token: 0x0402F825 RID: 194597
		TxtJifenNum,
		// Token: 0x0402F826 RID: 194598
		TxtLunciNum,
		// Token: 0x0402F827 RID: 194599
		TexScore,
		// Token: 0x0402F828 RID: 194600
		PnlLineup,
		// Token: 0x0402F829 RID: 194601
		LineupItem,
		// Token: 0x0402F82A RID: 194602
		TxtDate,
		// Token: 0x0402F82B RID: 194603
		PnlTips,
		// Token: 0x0402F82C RID: 194604
		TxtTips
	}
}
