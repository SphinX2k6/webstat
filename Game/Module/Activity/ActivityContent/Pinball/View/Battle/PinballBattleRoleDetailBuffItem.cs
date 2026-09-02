using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Battle
{
	// Token: 0x0200663F RID: 26175
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballBattleRoleDetailBuffItem : GridProxyAbstract<BuffView>
	{
		// Token: 0x06041608 RID: 267784 RVA: 0x010C5528 File Offset: 0x010C3728
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041609 RID: 267785 RVA: 0x010C55D4 File Offset: 0x010C37D4
		[NullableContext(1)]
		public override void Refresh(BuffView data, bool isSelected, int gridIndex)
		{
			PinballBuffConfig? pinballBuffConfigById = ConfigBase<PinballConfig>.Instance.GetPinballBuffConfigById(data.BuffId);
			if (pinballBuffConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Pinball;
				ELogAuthor author = ELogAuthor.CB;
				string message = "Buff配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("buffId", data.BuffId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), pinballBuffConfigById.Value.BuffName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), pinballBuffConfigById.Value.BuffDesc, pinballBuffConfigById.Value.BuffParam());
			if (data.BuffType == EPinballBuffType.Special)
			{
				base.TrySetSpriteByPath(pinballBuffConfigById.Value.BuffIcon, base.GetSprite(2), false, null, null);
			}
			else
			{
				PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
				string path = "";
				if (pinballBattleSubModel != null)
				{
					if (pinballBattleSubModel.WorldConfigCache != null)
					{
						pinballBattleSubModel.WorldConfigCache.GetValueOrDefault().CommonBuffIconMap().TryGetValue((int)data.BuffType, out path);
					}
				}
				base.TrySetSpriteByPath(path, base.GetSprite(2), false, null, null);
			}
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("x");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.BuffCount);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0200C665 RID: 50789
		private enum EPinballBattleRoleDetailBuffItemComp
		{
			// Token: 0x0403D142 RID: 250178
			TextTitle,
			// Token: 0x0403D143 RID: 250179
			TextDescription,
			// Token: 0x0403D144 RID: 250180
			SpriteIcon,
			// Token: 0x0403D145 RID: 250181
			TextCount
		}
	}
}
