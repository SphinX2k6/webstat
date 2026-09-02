using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002484 RID: 9348
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhantomManagerConfigNewSettingItem : GridProxyAbstract<IPhantomManagerConfigNewSettingInfo>
{
	// Token: 0x06012240 RID: 74304 RVA: 0x004FC950 File Offset: 0x004FAB50
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06012241 RID: 74305 RVA: 0x004FC9FB File Offset: 0x004FABFB
	protected override void OnStart()
	{
		this.InfoLayout = new GenericLayout<PhantomManagerConfigNewPropItem, IPhantomManagerConfigNewSettingDetailInfo>(base.GetGridLayout(2), new Func<PhantomManagerConfigNewPropItem>(this.CreateItem), null, false, true);
	}

	// Token: 0x06012242 RID: 74306 RVA: 0x004FCA20 File Offset: 0x004FAC20
	public override void Refresh(IPhantomManagerConfigNewSettingInfo data, bool isSelected, int gridIndex)
	{
		this.CurData = data;
		UUIText text = base.GetText(0);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
			defaultInterpolatedStringHandler.AppendLiteral("COST");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Cost);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		int[] phantomMainPropItemRefineAvailableIdList = ModelBase<PhantomBattleModel>.Instance.GetPhantomMainPropItemRefineAvailableIdList(data.ItemId);
		List<IPhantomManagerConfigNewSettingDetailInfo> list = new List<IPhantomManagerConfigNewSettingDetailInfo>();
		foreach (int id in phantomMainPropItemRefineAvailableIdList)
		{
			PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(id);
			list.Add(new PhantomManagerConfigNewSettingDetailInfo
			{
				FetterId = data.FetterId,
				Cost = data.Cost,
				MainPropId = phantomMainPropertyItemId.PropId,
				IsEdit = data.IsEdit
			});
		}
		this.InfoLayout.RefreshByData(list, null, true);
	}

	// Token: 0x06012243 RID: 74307 RVA: 0x004FCB24 File Offset: 0x004FAD24
	public void RefreshState(bool isEdit, bool needAnim = false)
	{
		foreach (PhantomManagerConfigNewPropItem phantomManagerConfigNewPropItem in this.InfoLayout.GetLayoutItemList())
		{
			phantomManagerConfigNewPropItem.RefreshState(isEdit, needAnim);
		}
	}

	// Token: 0x06012244 RID: 74308 RVA: 0x004FCB7C File Offset: 0x004FAD7C
	private PhantomManagerConfigNewPropItem CreateItem()
	{
		return new PhantomManagerConfigNewPropItem();
	}

	// Token: 0x04008D91 RID: 36241
	[Nullable(2)]
	private IPhantomManagerConfigNewSettingInfo CurData;

	// Token: 0x04008D92 RID: 36242
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<PhantomManagerConfigNewPropItem, IPhantomManagerConfigNewSettingDetailInfo> InfoLayout;

	// Token: 0x0200879D RID: 34717
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402DD82 RID: 187778
		TxtCostTitle,
		// Token: 0x0402DD83 RID: 187779
		TxtCount,
		// Token: 0x0402DD84 RID: 187780
		PanelGrid,
		// Token: 0x0402DD85 RID: 187781
		BtnSetProperty
	}
}
