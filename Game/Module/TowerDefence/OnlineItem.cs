using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004E9A RID: 20122
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class OnlineItem : GridProxyAbstract<ITowerDefenseRankPlayerName>
	{
		// Token: 0x06033FF0 RID: 212976 RVA: 0x00D01D8C File Offset: 0x00CFFF8C
		public OnlineItem(bool isShowInBottom)
		{
			this.IsShowInBottom = isShowInBottom;
		}

		// Token: 0x06033FF1 RID: 212977 RVA: 0x00D01D9C File Offset: 0x00CFFF9C
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

		// Token: 0x06033FF2 RID: 212978 RVA: 0x00D01E08 File Offset: 0x00D00008
		private void RefreshName()
		{
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int playerId = this.PlayerName.PlayerId;
			bool flag = id.GetValueOrDefault() == playerId & id != null;
			UUIText text = base.GetText(1);
			if (this.IsShowInBottom && flag)
			{
				string newText = ModelBase<PlayerInfoModel>.Instance.GetAccountName(true) ?? string.Empty;
				text.SetText(newText, true);
				return;
			}
			string playerName = this.PlayerName.PlayerName;
			if (StringUtils.IsBlank(playerName))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "OnlineGymnasium_AnonymityName", Array.Empty<object>());
				return;
			}
			text.SetText(playerName, true);
		}

		// Token: 0x06033FF3 RID: 212979 RVA: 0x00D01EA8 File Offset: 0x00D000A8
		private void RefreshPosTexture()
		{
			UUITexture texture = base.GetTexture(0);
			string posTexture = Singleton<TowerDefenseRankItemUtil>.Instance.GetPosTexture(base.GridIndex);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(posTexture);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}

		// Token: 0x06033FF4 RID: 212980 RVA: 0x00D01EEC File Offset: 0x00D000EC
		public override void Refresh(ITowerDefenseRankPlayerName data, bool isSelected, int gridIndex)
		{
			this.PlayerName = data;
			this.RefreshName();
			this.RefreshPosTexture();
		}

		// Token: 0x0401E0D6 RID: 123094
		private ITowerDefenseRankPlayerName PlayerName;

		// Token: 0x0401E0D7 RID: 123095
		private readonly bool IsShowInBottom;

		// Token: 0x0200AE41 RID: 44609
		[NullableContext(0)]
		private class EOnlineItem
		{
			// Token: 0x040361AB RID: 221611
			public const int PosTexture = 0;

			// Token: 0x040361AC RID: 221612
			public const int Name = 1;
		}
	}
}
