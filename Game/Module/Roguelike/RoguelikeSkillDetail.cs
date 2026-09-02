using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051A4 RID: 20900
	public class RoguelikeSkillDetail : UiPanelBase
	{
		// Token: 0x06035BF4 RID: 220148 RVA: 0x00D838F4 File Offset: 0x00D81AF4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 18;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickBtnUpgrade));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035BF5 RID: 220149 RVA: 0x00D83BB5 File Offset: 0x00D81DB5
		protected override void OnStart()
		{
		}

		// Token: 0x06035BF6 RID: 220150 RVA: 0x00D83BB8 File Offset: 0x00D81DB8
		private void OnClickBtnUpgrade()
		{
			int skillPoint = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null).Value.SkillPoint;
			int? num = new int?(ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(skillPoint, 0));
			int num2 = ModelBase<RoguelikeModel>.Instance.RoguelikeSkillDataMap[this.Data.Value.Id];
			if (((this.Data != null && num2 >= 0 && num2 < this.Data.Value.ConsuleLength) ? this.Data.Value.Consule(num2) : 0) > num.Value)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Roguelike_Skill_Point_Not_Enough", Array.Empty<object>());
				return;
			}
			RogueTalentTree? data = this.Data;
			ControllerBase<RoguelikeController>.Instance.RoguelikeTalentLevelUpRequest(this.Data.Value.Id).ContinueWith(delegate()
			{
				this.Refresh(this.Data.Value);
				ILevelUpSuccessEffectData data;
				RogueTalentTreeDesc? rogueTalentTreeDescConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueTalentTreeDescConfig(data.Value.Describe);
				data = new LevelUpSuccessEffectData
				{
					Title = "Text_ResonanceUnlockSuccess_Text",
					TextList = new List<SingleText>
					{
						new SingleText
						{
							TextId = rogueTalentTreeDescConfig.Value.BaseDesc,
							Params = rogueTalentTreeDescConfig.Value.Params()
						}
					}
				};
				ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessEffectView(data, null);
			});
		}

		// Token: 0x06035BF7 RID: 220151 RVA: 0x00D83CCC File Offset: 0x00D81ECC
		public void Refresh(RogueTalentTree data)
		{
			this.Data = new RogueTalentTree?(data);
			int num = ModelBase<RoguelikeModel>.Instance.RoguelikeSkillDataMap[data.Id];
			RogueTalentTreeDesc? rogueTalentTreeDescConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueTalentTreeDescConfig(data.Describe);
			bool isMax = num >= data.ConsuleLength;
			string talentIcon = rogueTalentTreeDescConfig.Value.TalentIcon;
			bool flag = talentIcon.Contains("Atlas");
			UUITexture texture = base.GetTexture(17);
			texture.SetUIActive(!flag);
			UUISprite sprite = base.GetSprite(1);
			sprite.SetUIActive(flag);
			if (flag)
			{
				this.SetSpriteByPath(talentIcon, sprite, false, null, null);
			}
			else
			{
				base.SetTextureByPath(talentIcon, texture, null, null);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), rogueTalentTreeDescConfig.Value.TalentName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Text_LevelNumber_Text", new <>z__ReadOnlySingleElementList<object>(num));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), rogueTalentTreeDescConfig.Value.BaseDesc, rogueTalentTreeDescConfig.Value.Params());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Text_LevelNumber_Text", new <>z__ReadOnlySingleElementList<object>(num + 1));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), rogueTalentTreeDescConfig.Value.BaseDesc, rogueTalentTreeDescConfig.Value.Params());
			RogueParam? paramConfigBySeasonId = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null);
			RogueCurrency? rogueCurrencyConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCurrencyConfig(paramConfigBySeasonId.Value.SkillPoint);
			int roguelikeCurrency = ModelBase<RoguelikeModel>.Instance.GetRoguelikeCurrency(paramConfigBySeasonId.Value.SkillPoint);
			int? num2 = (num >= 0 && num < data.ConsuleLength) ? new int?(data.Consule(num)) : null;
			bool flag2 = num2 != null && roguelikeCurrency >= num2.Value;
			UUIText text = base.GetText(8);
			text.SetText(((num2 != null) ? num2.GetValueOrDefault().ToString() : null) ?? "", true);
			if (flag2)
			{
				UUIItem uuiitem = text;
				bool bUseChangeColor = false;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			}
			else
			{
				UUIItem uuiitem2 = text;
				bool bUseChangeColor2 = true;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			}
			base.SetTextureByPath(rogueCurrencyConfig.Value.IconSmall, base.GetTexture(12), null, null);
			this.UpdateDetail(num, isMax);
		}

		// Token: 0x06035BF8 RID: 220152 RVA: 0x00D83F8C File Offset: 0x00D8218C
		public void UpdateDetail(int level, bool isMax)
		{
			if (level < 0)
			{
				base.GetItem(2).SetUIActive(false);
				base.GetItem(5).SetUIActive(false);
				base.GetItem(16).SetUIActive(false);
				base.GetButton(9).RootUIComp.Get().SetUIActive(false);
				base.GetItem(14).SetUIActive(true);
				base.GetItem(13).SetUIActive(false);
				return;
			}
			if (level == 0)
			{
				base.GetItem(2).SetUIActive(false);
				base.GetItem(5).SetUIActive(false);
				base.GetItem(16).SetUIActive(true);
				base.GetButton(9).RootUIComp.Get().SetUIActive(true);
				base.GetItem(14).SetUIActive(false);
				base.GetItem(13).SetUIActive(false);
				return;
			}
			base.GetItem(2).SetUIActive(!isMax);
			base.GetItem(5).SetUIActive(!isMax);
			base.GetItem(16).SetUIActive(!isMax);
			base.GetButton(9).RootUIComp.Get().SetUIActive(!isMax);
			base.GetItem(14).SetUIActive(false);
			base.GetItem(13).SetUIActive(isMax);
		}

		// Token: 0x0401ED81 RID: 126337
		public RogueTalentTree? Data;

		// Token: 0x0200B179 RID: 45433
		private static class ERoguelikeSkillDetailDefine
		{
			// Token: 0x04037095 RID: 225429
			public const int TxtSkillName = 0;

			// Token: 0x04037096 RID: 225430
			public const int SprSkillIcon = 1;

			// Token: 0x04037097 RID: 225431
			public const int PanelCurLevel = 2;

			// Token: 0x04037098 RID: 225432
			public const int TxtCurLevel = 3;

			// Token: 0x04037099 RID: 225433
			public const int TxtCurDesc = 4;

			// Token: 0x0403709A RID: 225434
			public const int PanelNextItem = 5;

			// Token: 0x0403709B RID: 225435
			public const int TxtNextLevel = 6;

			// Token: 0x0403709C RID: 225436
			public const int TxtNextDesc = 7;

			// Token: 0x0403709D RID: 225437
			public const int TxtCost = 8;

			// Token: 0x0403709E RID: 225438
			public const int BtnUpgrade = 9;

			// Token: 0x0403709F RID: 225439
			public const int TxtBtnUpgrade = 10;

			// Token: 0x040370A0 RID: 225440
			public const int CostPanel = 11;

			// Token: 0x040370A1 RID: 225441
			public const int TexCostIcon = 12;

			// Token: 0x040370A2 RID: 225442
			public const int PanelMaxLevel = 13;

			// Token: 0x040370A3 RID: 225443
			public const int PanelActivateCondition = 14;

			// Token: 0x040370A4 RID: 225444
			public const int TxtActivateCondition = 15;

			// Token: 0x040370A5 RID: 225445
			public const int PanelCost = 16;

			// Token: 0x040370A6 RID: 225446
			public const int TexSkillIcon = 17;
		}
	}
}
