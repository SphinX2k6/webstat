using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F22 RID: 24354
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FlagChallengePauseInfoItem : GridProxyAbstract<FlagChallengePauseInfo>
	{
		// Token: 0x0603D2AB RID: 250539 RVA: 0x00F8B11C File Offset: 0x00F8931C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D2AC RID: 250540 RVA: 0x00F8B1C8 File Offset: 0x00F893C8
		[NullableContext(1)]
		public override void Refresh(FlagChallengePauseInfo data, bool isSelected, int gridIndex)
		{
			this.SetSpriteByPath(data.IconPath, base.GetSprite(0), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TitleKey, Array.Empty<object>());
			base.GetText(2).SetText(data.Content, true);
			base.GetSprite(3).SetUIActive(data.ShowLine);
		}

		// Token: 0x0200BF2B RID: 48939
		private enum EInfoItemType
		{
			// Token: 0x0403AD78 RID: 241016
			IconSprite,
			// Token: 0x0403AD79 RID: 241017
			TitleTxt,
			// Token: 0x0403AD7A RID: 241018
			ContentTxt,
			// Token: 0x0403AD7B RID: 241019
			SplitSprite
		}
	}
}
