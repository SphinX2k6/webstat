using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006823 RID: 26659
	public class FishingQuestShapePanelItem : GridProxyAbstract<ValueTuple<int, int>>
	{
		// Token: 0x06042779 RID: 272249 RVA: 0x0110D60C File Offset: 0x0110B80C
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

		// Token: 0x0604277A RID: 272250 RVA: 0x0110D654 File Offset: 0x0110B854
		public override void Refresh(ValueTuple<int, int> data, bool isSelected, int gridIndex)
		{
			this.RowIndex = data.Item1;
			this.ColumnIndex = data.Item2;
		}

		// Token: 0x0604277B RID: 272251 RVA: 0x0110D670 File Offset: 0x0110B870
		[NullableContext(1)]
		public void SetGirdSprite(int category, string path)
		{
			if (category == 0)
			{
				UUISprite sprite = base.GetSprite(0);
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridEmpty");
				this.SetSpriteByPath(resourcePath, sprite, false, null, null);
				return;
			}
			UUISprite sprite2 = base.GetSprite(0);
			this.SetSpriteByPath(path, sprite2, false, null, null);
		}

		// Token: 0x04024FFB RID: 151547
		public int RowIndex;

		// Token: 0x04024FFC RID: 151548
		public int ColumnIndex;

		// Token: 0x0200C85E RID: 51294
		private class EComponentDefine
		{
			// Token: 0x0403DA9B RID: 252571
			public const int Sprite = 0;
		}
	}
}
