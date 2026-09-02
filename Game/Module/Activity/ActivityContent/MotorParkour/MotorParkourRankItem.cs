using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066B9 RID: 26297
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorParkourRankItem : GridProxyAbstract<MotorParkourRankData>
	{
		// Token: 0x06041AA1 RID: 268961 RVA: 0x010D6734 File Offset: 0x010D4934
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041AA2 RID: 268962 RVA: 0x010D67E0 File Offset: 0x010D49E0
		[NullableContext(1)]
		public override void Refresh(MotorParkourRankData data, bool isSelected, int gridIndex)
		{
			int id = gridIndex + 1;
			MotorParkourRank? motorParkourRankById = ConfigBase<MotorParkourConfig>.Instance.GetMotorParkourRankById(id);
			this.SetSpriteByPath(motorParkourRankById.Value.SpriteNum, base.GetSprite(0), false, null, null);
			this.SetSpriteByPath(motorParkourRankById.Value.SpriteBg, base.GetSprite(1), false, null, null);
			string remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5((double)data.Time * Singleton<TimeUtil>.Instance.Millisecond);
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetText(remainTimeDataFormat, true);
			}
			if (!data.IsOwn)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Name, Array.Empty<object>());
				return;
			}
			string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
			UUIText text2 = base.GetText(2);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(playerName, true);
		}

		// Token: 0x0200C6E0 RID: 50912
		private class EComponents
		{
			// Token: 0x0403D3B2 RID: 250802
			public const int SpriteRankNum = 0;

			// Token: 0x0403D3B3 RID: 250803
			public const int SpriteRankBg = 1;

			// Token: 0x0403D3B4 RID: 250804
			public const int TextName = 2;

			// Token: 0x0403D3B5 RID: 250805
			public const int TextTime = 3;
		}
	}
}
