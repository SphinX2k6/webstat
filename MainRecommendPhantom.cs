using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200250B RID: 9483
[NullableContext(1)]
[Nullable(0)]
internal class MainRecommendPhantom : UiPanelBase
{
	// Token: 0x060126A1 RID: 75425 RVA: 0x005106C1 File Offset: 0x0050E8C1
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x060126A2 RID: 75426 RVA: 0x005106FA File Offset: 0x0050E8FA
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<MainPhantomContent, IMainPhantomItemData>(base.GetVerticalLayout(0), new Func<MainPhantomContent>(this.InitItem), null, false, true);
	}

	// Token: 0x060126A3 RID: 75427 RVA: 0x0051071D File Offset: 0x0050E91D
	private MainPhantomContent InitItem()
	{
		return new MainPhantomContent();
	}

	// Token: 0x060126A4 RID: 75428 RVA: 0x00510724 File Offset: 0x0050E924
	public void Refresh(List<IMainPhantomItemData> data)
	{
		GenericLayout<MainPhantomContent, IMainPhantomItemData> layout = this.Layout;
		if (layout == null)
		{
			return;
		}
		layout.RefreshByData(data, null, false);
	}

	// Token: 0x04008FA0 RID: 36768
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MainPhantomContent, IMainPhantomItemData> Layout;
}
