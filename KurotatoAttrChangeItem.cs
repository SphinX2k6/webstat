using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001D1B RID: 7451
[Nullable(new byte[]
{
	0,
	1
})]
internal class KurotatoAttrChangeItem : GridProxyAbstract<IKurotatoAttrChangeData>
{
	// Token: 0x0600DAF4 RID: 56052 RVA: 0x003ACC57 File Offset: 0x003AAE57
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x0600DAF5 RID: 56053 RVA: 0x003ACC90 File Offset: 0x003AAE90
	[NullableContext(1)]
	public override void Refresh(IKurotatoAttrChangeData data, bool isSelected, int gridIndex)
	{
		base.GetText(0).SetText(data.Text, true);
		base.SetTextureByPath(data.IconPath, base.GetTexture(1), null, null);
	}

	// Token: 0x02008093 RID: 32915
	private static class EAttrItemComp
	{
		// Token: 0x0402BBA6 RID: 179110
		public const int TextAttr = 0;

		// Token: 0x0402BBA7 RID: 179111
		public const int TextureIcon = 1;
	}
}
