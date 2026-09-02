using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x02005535 RID: 21813
	public class CardElementItem : GridProxyAbstract<ECardElement>
	{
		// Token: 0x06037A09 RID: 227849 RVA: 0x00E1D12C File Offset: 0x00E1B32C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUITexture))
			};
		}

		// Token: 0x06037A0A RID: 227850 RVA: 0x00E1D165 File Offset: 0x00E1B365
		public override void Refresh(ECardElement data, bool isSelected = false, int gridIndex = 0)
		{
			this.RefreshElement(data);
		}

		// Token: 0x06037A0B RID: 227851 RVA: 0x00E1D170 File Offset: 0x00E1B370
		public void RefreshElement(ECardElement elementId)
		{
			if (elementId == ECardElement.Physical)
			{
				this.SetActive(false);
				return;
			}
			this.SetActive(true);
			UUITexture texture = base.GetTexture(1);
			if (texture == null)
			{
				return;
			}
			PhantomBattleCardElement phantomBattleElementConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleElementConfig((int)elementId);
			FColor color = FColor.FromHex(phantomBattleElementConfig.TabElementColor);
			base.GetSprite(0).SetColor(color);
			base.SetTextureByPath(phantomBattleElementConfig.CardElementIcon, texture, null, null);
		}

		// Token: 0x06037A0C RID: 227852 RVA: 0x00E1D1DC File Offset: 0x00E1B3DC
		public void RefreshElementTabIcon(ECardElement elementId)
		{
			if (elementId == ECardElement.Physical)
			{
				this.SetActive(false);
				return;
			}
			this.SetActive(true);
			UUITexture texture = base.GetTexture(1);
			if (texture == null)
			{
				return;
			}
			PhantomBattleCardElement phantomBattleElementConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleElementConfig((int)elementId);
			FColor color = FColor.FromHex(phantomBattleElementConfig.TabElementColor);
			base.GetSprite(0).SetColor(color);
			base.SetTextureByPath(phantomBattleElementConfig.TabIcon, texture, null, null);
		}

		// Token: 0x0200B4CD RID: 46285
		private static class EElementItem
		{
			// Token: 0x04037F8E RID: 229262
			public const int BgSprite = 0;

			// Token: 0x04037F8F RID: 229263
			public const int ElementTexture = 1;
		}
	}
}
