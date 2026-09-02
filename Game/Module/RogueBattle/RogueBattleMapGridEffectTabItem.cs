using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051E3 RID: 20963
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleMapGridEffectTabItem : GridProxyAbstract<IRogueBattleMapGridEffectInfo>
	{
		// Token: 0x06035D5B RID: 220507 RVA: 0x00D8BB3C File Offset: 0x00D89D3C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
		}

		// Token: 0x06035D5C RID: 220508 RVA: 0x00D8BBAC File Offset: 0x00D89DAC
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06035D5D RID: 220509 RVA: 0x00D8BBC0 File Offset: 0x00D89DC0
		public override void Refresh(IRogueBattleMapGridEffectInfo data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.TagKey, Array.Empty<object>());
			string text;
			if (!data.IsRatio)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
				defaultInterpolatedStringHandler.AppendLiteral("%");
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			string newText = text;
			UUIText text2 = base.GetText(2);
			if (text2 != null)
			{
				text2.SetText(newText, true);
			}
			base.SetTextureByPath(data.Icon, base.GetTexture(0), null, null);
		}
	}
}
