using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002527 RID: 9511
public class VisionMainAttributeComponent : UiPanelBase
{
	// Token: 0x0601281C RID: 75804 RVA: 0x00519491 File Offset: 0x00517691
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0601281D RID: 75805 RVA: 0x005194CA File Offset: 0x005176CA
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<VisionIdentifyAttributeItem, AttrListScrollData>(base.GetVerticalLayout(0), new Func<VisionIdentifyAttributeItem>(this.InitItem), null, false, true);
		this.SetActive(true);
		base.GetItem(1).SetUIActive(false);
	}

	// Token: 0x0601281E RID: 75806 RVA: 0x00519501 File Offset: 0x00517701
	[NullableContext(1)]
	private VisionIdentifyAttributeItem InitItem()
	{
		return new VisionIdentifyAttributeItem();
	}

	// Token: 0x0601281F RID: 75807 RVA: 0x00519508 File Offset: 0x00517708
	[NullableContext(1)]
	public void Update(AttrListScrollData[] data)
	{
		this.Layout.RefreshByData(data.ToList<AttrListScrollData>(), null, false);
	}

	// Token: 0x04009048 RID: 36936
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<VisionIdentifyAttributeItem, AttrListScrollData> Layout;

	// Token: 0x02008850 RID: 34896
	private enum ELevelAttribute
	{
		// Token: 0x0402E0A5 RID: 188581
		Layout,
		// Token: 0x0402E0A6 RID: 188582
		Item
	}
}
