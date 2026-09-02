using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001189 RID: 4489
[Nullable(new byte[]
{
	0,
	1
})]
public class AdvanceNoticeFetterSuitDetailItem : GridProxyAbstract<IAdvanceNoticeFetterSuitDetailItemData>
{
	// Token: 0x06007629 RID: 30249 RVA: 0x001EE5F8 File Offset: 0x001EC7F8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600762A RID: 30250 RVA: 0x001EE634 File Offset: 0x001EC834
	[NullableContext(1)]
	public override void Refresh(IAdvanceNoticeFetterSuitDetailItemData data, bool isSelected, int gridIndex)
	{
		if (!string.IsNullOrEmpty(data.TitleTextData.TextKey))
		{
			base.GetText(0).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.TitleTextData.TextKey, data.TitleTextData.Params);
		}
		else
		{
			base.GetText(0).SetUIActive(false);
		}
		if (!string.IsNullOrEmpty(data.DescTextData.TextKey))
		{
			base.GetText(1).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.DescTextData.TextKey, data.DescTextData.Params);
			return;
		}
		base.GetText(1).SetUIActive(false);
	}

	// Token: 0x020074E4 RID: 29924
	private class EComponentDefine
	{
		// Token: 0x040285A7 RID: 165287
		public const int TitleText = 0;

		// Token: 0x040285A8 RID: 165288
		public const int DescText = 1;
	}
}
