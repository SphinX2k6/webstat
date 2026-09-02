using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020013AD RID: 5037
[Nullable(new byte[]
{
	0,
	1
})]
public class BuildingAttributeItem : GridProxyAbstract<IAdditionData>
{
	// Token: 0x06008AD8 RID: 35544 RVA: 0x002491E6 File Offset: 0x002473E6
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06008AD9 RID: 35545 RVA: 0x0024921F File Offset: 0x0024741F
	[NullableContext(1)]
	public override void Refresh(IAdditionData data, bool isSelected, int gridIndex)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.TextId, Array.Empty<object>());
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(data.ValueText, true);
	}

	// Token: 0x02007763 RID: 30563
	private static class EComponentDefine
	{
		// Token: 0x040291BF RID: 168383
		public const int Name = 0;

		// Token: 0x040291C0 RID: 168384
		public const int Value = 1;
	}
}
