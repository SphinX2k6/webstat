using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F0C RID: 24332
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BossPilingScoreTabItem : GridProxyAbstract<BossPilingScoreTabInfo>
	{
		// Token: 0x0603D1C1 RID: 250305 RVA: 0x00F85F44 File Offset: 0x00F84144
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D1C2 RID: 250306 RVA: 0x00F85FF0 File Offset: 0x00F841F0
		[NullableContext(1)]
		public override void Refresh(BossPilingScoreTabInfo data, bool isSelected, int gridIndex)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetUIActive(!data.IsAchieve);
			}
			UUISprite sprite2 = base.GetSprite(1);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(data.IsAchieve);
			}
			string resourceId = BossPilingDefine.BossPilingScoreTexMap[data.Quality];
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetSpriteByPath(resourcePath, base.GetSprite(2), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "BossPilingActivity_DungeonDetail04", new <>z__ReadOnlySingleElementList<object>(data.BossHp));
			FColor changeColor = base.GetText(3).changeColor;
			UUIItem text = base.GetText(3);
			bool isAchieve = data.IsAchieve;
			FColor? fcolor = new FColor?(changeColor);
			text.SetChangeColor(isAchieve, fcolor);
		}

		// Token: 0x0200BF0C RID: 48908
		private enum EDefine
		{
			// Token: 0x0403ACE1 RID: 240865
			SpriteNorIcon,
			// Token: 0x0403ACE2 RID: 240866
			SpriteFinish,
			// Token: 0x0403ACE3 RID: 240867
			SpriteScore,
			// Token: 0x0403ACE4 RID: 240868
			TxtTarget
		}
	}
}
