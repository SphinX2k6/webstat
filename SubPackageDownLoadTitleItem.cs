using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002AAD RID: 10925
internal class SubPackageDownLoadTitleItem : UiPanelBase
{
	// Token: 0x06015DC3 RID: 89539 RVA: 0x00610E4E File Offset: 0x0060F04E
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06015DC4 RID: 89540 RVA: 0x00610E88 File Offset: 0x0060F088
	public void RefreshItem(ESubPackageDownLoadVersionType type)
	{
		if (type == ESubPackageDownLoadVersionType.Key)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "SubPackageDownLoadTitle_Must", Array.Empty<object>());
		}
		if (type == ESubPackageDownLoadVersionType.Optional)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "SubPackageDownLoadTitle_Optional", Array.Empty<object>());
		}
		if (type == ESubPackageDownLoadVersionType.Expand)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "SubPackageDownLoadTitle_Expand", Array.Empty<object>());
		}
	}
}
