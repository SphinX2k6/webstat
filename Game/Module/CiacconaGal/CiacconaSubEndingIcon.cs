using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ECB RID: 24267
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CiacconaSubEndingIcon : GridProxyAbstract<CiacconaGalSubEndingData>
	{
		// Token: 0x0603CFD6 RID: 249814 RVA: 0x00F7D904 File Offset: 0x00F7BB04
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

		// Token: 0x0603CFD7 RID: 249815 RVA: 0x00F7D94C File Offset: 0x00F7BB4C
		[NullableContext(1)]
		public override void Refresh(CiacconaGalSubEndingData data, bool isSelected, int gridIndex)
		{
			string resourceId = "SP_PlotReasoningLock";
			if (data.IsFinished)
			{
				resourceId = ((data.Type == ECiacconaGalSubEndingType.Main) ? "SP_PlotReasoningFinishMain" : "SP_PlotReasoningFinishBranch");
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
		}

		// Token: 0x0200BEC6 RID: 48838
		private class EEndingIconComponentDefine
		{
			// Token: 0x0403AB7D RID: 240509
			public const int SpriteIcon = 0;
		}
	}
}
