using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.GreatSword
{
	// Token: 0x02004BB6 RID: 19382
	public class GreatSwordMarkTargetListItemPanel : UiPanelBase
	{
		// Token: 0x0603299F RID: 207263 RVA: 0x00CAC874 File Offset: 0x00CAAA74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060329A0 RID: 207264 RVA: 0x00CAC8DD File Offset: 0x00CAAADD
		[NullableContext(1)]
		public void SetDescTxt(string txt)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), txt, Array.Empty<object>());
		}

		// Token: 0x060329A1 RID: 207265 RVA: 0x00CAC8F8 File Offset: 0x00CAAAF8
		public void SetState(bool completed)
		{
			string resourceId;
			if (!completed)
			{
				resourceId = "T_MapDifficultyEmpty";
			}
			else
			{
				resourceId = "T_MapDifficultyTick";
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
		}

		// Token: 0x0200AC9A RID: 44186
		public static class EComponents
		{
			// Token: 0x04035A28 RID: 219688
			public const int TxtDesc = 0;

			// Token: 0x04035A29 RID: 219689
			public const int TexState = 1;
		}
	}
}
