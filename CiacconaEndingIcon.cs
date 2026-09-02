using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.CiacconaGal;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001299 RID: 4761
[Nullable(new byte[]
{
	0,
	1
})]
public class CiacconaEndingIcon : GridProxyAbstract<CiacconaGalEndingData>
{
	// Token: 0x06007F88 RID: 32648 RVA: 0x0021B4CC File Offset: 0x002196CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007F89 RID: 32649 RVA: 0x0021B514 File Offset: 0x00219714
	[NullableContext(1)]
	public override void Refresh(CiacconaGalEndingData data, bool isSelected, int gridIndex)
	{
		string resourceId = "SP_PlotReasoningLock";
		if (data.IsFinished)
		{
			resourceId = ((data.Type == ECiacconaGalEndingType.Main) ? "SP_PlotReasoningFinishMain" : "SP_PlotReasoningFinishBranch");
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
	}

	// Token: 0x02007617 RID: 30231
	private class EEndingIconComponentDefine
	{
		// Token: 0x04028B6B RID: 166763
		public const int SpriteIcon = 0;
	}
}
