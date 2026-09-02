using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020022D6 RID: 8918
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleDiySkinListItem : GridProxyAbstract<MotorcycleDiySkinListItemData>
{
	// Token: 0x06010DFF RID: 69119 RVA: 0x0049F408 File Offset: 0x0049D608
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06010E00 RID: 69120 RVA: 0x0049F464 File Offset: 0x0049D664
	[NullableContext(1)]
	public override void Refresh(MotorcycleDiySkinListItemData data, bool isSelected, int gridIndex)
	{
		string textStringId;
		if (MotorcycleDiyDefine.OutlookToSkinCustomizeNameMap.TryGetValue(data.OutlookType, out textStringId))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		}
		string resourceId;
		if (MotorcycleDiyDefine.OutlookToSkinCustomizeIconMap.TryGetValue(data.OutlookType, out resourceId))
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
		}
		if (data.CanCustomizeNum > 0)
		{
			base.GetText(2).SetText(data.CanCustomizeNum.ToString(), true);
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "MotorSkin_Tips04", Array.Empty<object>());
		}
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetAlpha((data.CanCustomizeNum > 0) ? 1f : 0.5f);
	}

	// Token: 0x020085B2 RID: 34226
	private class EMotorDiySkinListItemComponent
	{
		// Token: 0x0402D3B7 RID: 185271
		public const int TexIcon = 0;

		// Token: 0x0402D3B8 RID: 185272
		public const int TxtName = 1;

		// Token: 0x0402D3B9 RID: 185273
		public const int TxtNum = 2;
	}
}
