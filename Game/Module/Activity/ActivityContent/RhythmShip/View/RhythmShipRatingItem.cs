using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x02006506 RID: 25862
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class RhythmShipRatingItem : GridProxyAbstract<IRhythmShipSubLevelRatingData>
	{
		// Token: 0x06040B8B RID: 265099 RVA: 0x01098B90 File Offset: 0x01096D90
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIArtText)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
		}

		// Token: 0x06040B8C RID: 265100 RVA: 0x01098C9C File Offset: 0x01096E9C
		public override void Refresh(IRhythmShipSubLevelRatingData data, bool isSelected, int gridIndex)
		{
			this.RefreshItemByData(data);
		}

		// Token: 0x06040B8D RID: 265101 RVA: 0x01098CA8 File Offset: 0x01096EA8
		public void RefreshItemByData(IRhythmShipSubLevelRatingData data)
		{
			RhythmRole? rhythmRoleById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmRoleById(data.RoleId);
			if (rhythmRoleById == null)
			{
				return;
			}
			base.GetArtText(2).SetUIActive(true);
			base.GetTexture(6).SetUIActive(true);
			base.GetText(5).SetText(data.NameText, true);
			base.GetText(7).SetText((data.Accuracy / 100).ToString() + "%", true);
			base.GetText(8).SetText(data.Score.ToString(), true);
			base.SetTextureByPath(rhythmRoleById.Value.RoleHeadTexture, base.GetTexture(6), null, null);
			int valueOrDefault = data.RankingNumber.GetValueOrDefault();
			base.GetArtText(2).SetText(valueOrDefault.ToString());
			UUIItem item = base.GetItem(9);
			string resourceId;
			if (valueOrDefault > 0 && valueOrDefault <= 3)
			{
				resourceId = "T_IconRank0" + valueOrDefault.ToString();
				item.SetUIActive(true);
				item.SetColor(RhythmShipDefine.rhythmShipRankNiaLightColor[valueOrDefault]);
			}
			else
			{
				resourceId = "T_IconRank00";
				item.SetUIActive(false);
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
			UUIItem item2 = base.GetItem(10);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06040B8E RID: 265102 RVA: 0x01098E18 File Offset: 0x01097018
		public void RefreshItemNone()
		{
			base.GetText(5).SetText(ModelBase<PlayerInfoModel>.Instance.GetPlayerName() ?? "", true);
			base.GetText(7).SetText("-", true);
			base.GetText(8).SetText("-", true);
			base.GetArtText(2).SetUIActive(false);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_IconRank00");
			base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
			base.GetTexture(6).SetUIActive(false);
			base.GetItem(9).SetUIActive(false);
			UUIItem item = base.GetItem(10);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(true);
		}
	}
}
