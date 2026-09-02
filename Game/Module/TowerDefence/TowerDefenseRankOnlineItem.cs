using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EA8 RID: 20136
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TowerDefenseRankOnlineItem : GridProxyAbstract<ITowerDefenseRankPlayerName>
	{
		// Token: 0x06034065 RID: 213093 RVA: 0x00D03C34 File Offset: 0x00D01E34
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034066 RID: 213094 RVA: 0x00D03CA0 File Offset: 0x00D01EA0
		private void RefreshName()
		{
			UUIText text = base.GetText(1);
			string playerName = this.PlayerName.PlayerName;
			if (StringUtils.IsBlank(playerName))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "OnlineGymnasium_AnonymityName", Array.Empty<object>());
				return;
			}
			text.SetText(playerName, true);
		}

		// Token: 0x06034067 RID: 213095 RVA: 0x00D03CE8 File Offset: 0x00D01EE8
		private void RefreshPosTexture()
		{
			UUITexture texture = base.GetTexture(0);
			string posTexture = Singleton<TowerDefenseRankItemUtil>.Instance.GetPosTexture(base.GridIndex);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(posTexture);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}

		// Token: 0x06034068 RID: 213096 RVA: 0x00D03D2C File Offset: 0x00D01F2C
		public override void Refresh(ITowerDefenseRankPlayerName data, bool isSelected, int gridIndex)
		{
			this.PlayerName = data;
			this.RefreshName();
			this.RefreshPosTexture();
		}

		// Token: 0x0401E10F RID: 123151
		private ITowerDefenseRankPlayerName PlayerName;

		// Token: 0x0200AE5B RID: 44635
		[NullableContext(0)]
		private class EOnlineItemComponent
		{
			// Token: 0x04036218 RID: 221720
			public const int PosTexture = 0;

			// Token: 0x04036219 RID: 221721
			public const int Name = 1;
		}
	}
}
