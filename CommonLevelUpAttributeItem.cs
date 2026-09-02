using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020018A6 RID: 6310
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonLevelUpAttributeItem : GridProxyAbstract<IAttributeInfo>
{
	// Token: 0x0600B54D RID: 46413 RVA: 0x0030438C File Offset: 0x0030258C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture))
		};
	}

	// Token: 0x0600B54E RID: 46414 RVA: 0x00304414 File Offset: 0x00302614
	[NullableContext(1)]
	public override void Refresh(IAttributeInfo data, bool isSelected, int gridIndex)
	{
		if (data.IconPath != null)
		{
			base.SetTextureByPath(data.IconPath, base.GetTexture(4), null, null);
		}
		base.GetTexture(4).SetUIActive(data.IconPath != null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
		if (!string.IsNullOrEmpty(data.PreText))
		{
			base.GetText(1).SetText(data.PreText, true);
		}
		else
		{
			base.GetText(1).SetUIActive(false);
		}
		base.GetItem(2).SetUIActive(data.ShowArrow.GetValueOrDefault());
		if (!string.IsNullOrEmpty(data.CurText))
		{
			base.GetText(3).SetText(data.CurText, true);
			return;
		}
		base.GetText(3).SetUIActive(false);
	}

	// Token: 0x02007C30 RID: 31792
	private enum EComponent
	{
		// Token: 0x0402A6AB RID: 173739
		AttributeText,
		// Token: 0x0402A6AC RID: 173740
		BeforeText,
		// Token: 0x0402A6AD RID: 173741
		ArrowItem,
		// Token: 0x0402A6AE RID: 173742
		AfterText,
		// Token: 0x0402A6AF RID: 173743
		AttributeTexture
	}
}
