using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066B6 RID: 26294
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorParkourGameRankItem : GridProxyAbstract<MotorParkourRankData>
	{
		// Token: 0x06041A8D RID: 268941 RVA: 0x010D60EC File Offset: 0x010D42EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041A8E RID: 268942 RVA: 0x010D6178 File Offset: 0x010D4378
		[NullableContext(1)]
		public override void Refresh(MotorParkourRankData data, bool isSelected, int gridIndex)
		{
			int id = gridIndex + 1;
			this.SetSpriteByPath(ConfigBase<MotorParkourConfig>.Instance.GetMotorParkourRankById(id).Value.SpriteNum, base.GetSprite(0), false, null, null);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText(data.ShowTimeString, true);
			}
			if (!data.IsOwn)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
				return;
			}
			string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(playerName, true);
		}

		// Token: 0x0200C6DA RID: 50906
		private class EComponents
		{
			// Token: 0x0403D396 RID: 250774
			public const int SpriteRankNum = 0;

			// Token: 0x0403D397 RID: 250775
			public const int TextName = 1;

			// Token: 0x0403D398 RID: 250776
			public const int TextTime = 2;
		}
	}
}
