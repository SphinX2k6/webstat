using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200568E RID: 22158
	public class RogueResSkillDetail : UiPanelBase
	{
		// Token: 0x06038718 RID: 231192 RVA: 0x00E4BFD8 File Offset: 0x00E4A1D8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUITexture)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIText)),
				new ValueTuple<int, Type>(16, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickBtnUpgrade))
			};
		}

		// Token: 0x06038719 RID: 231193 RVA: 0x00E4C194 File Offset: 0x00E4A394
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText("", true);
			}
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.SetText("", true);
			}
			UUIText text3 = base.GetText(4);
			if (text3 != null)
			{
				text3.SetText("", true);
			}
			UUIText text4 = base.GetText(6);
			if (text4 != null)
			{
				text4.SetText("", true);
			}
			UUIText text5 = base.GetText(7);
			if (text5 != null)
			{
				text5.SetText("", true);
			}
			UUIText text6 = base.GetText(8);
			if (text6 == null)
			{
				return;
			}
			text6.SetText("", true);
		}

		// Token: 0x0603871A RID: 231194 RVA: 0x00E4C258 File Offset: 0x00E4A458
		private void OnClickBtnUpgrade()
		{
			RogueResTheme value = ConfigRogueResThemeById.GetConfig(ConfigRogueResTalentTreeById.GetConfig(this.Data.Value.Id, true).Value.SeasonId, true).Value;
			int currency = ModelBase<ActivityPermanentRogueModel>.Instance.GetCurrency(value.SkillItem);
			int skillLevelById = ModelBase<ActivityPermanentRogueModel>.Instance.GetSkillLevelById(this.Data.Value.Id);
			if (((this.Data != null && skillLevelById >= 0 && skillLevelById < this.Data.Value.ConsuleLength) ? this.Data.Value.Consule(skillLevelById) : 0) > currency)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_200003_Text", Array.Empty<object>());
				return;
			}
			ControllerBase<ActivityPermanentRogueController>.Instance.RequestRogueResTalentSkillLevel(this.Data.Value.Id).ContinueWith(delegate()
			{
				this.Refresh(this.Data.Value);
				RogueResTalentTreeDesc value2 = ConfigRogueResTalentTreeDescById.GetConfig(this.Data.Value.Describe, true).Value;
				SingleText singleText = new SingleText();
				singleText.TextId = value2.TalentDesc;
				singleText.Params = value2.Args();
				LevelUpSuccessEffectData data = new LevelUpSuccessEffectData
				{
					Title = "Text_ResonanceUnlockSuccess_Text",
					TextList = new List<SingleText>
					{
						singleText
					}
				};
				ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessEffectView(data, null);
			});
		}

		// Token: 0x0603871B RID: 231195 RVA: 0x00E4C35C File Offset: 0x00E4A55C
		public void Refresh(RogueResTalentTree data)
		{
			this.Data = new RogueResTalentTree?(data);
			int skillLevelById = ModelBase<ActivityPermanentRogueModel>.Instance.GetSkillLevelById(data.Id);
			RogueResTalentTreeDesc value = ConfigRogueResTalentTreeDescById.GetConfig(data.Describe, true).Value;
			bool flag = skillLevelById >= data.ConsuleLength;
			this.SetSpriteByPath(value.TalentIcon, base.GetSprite(1), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.TalentName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Text_LevelNumber_Text", new <>z__ReadOnlySingleElementList<object>(skillLevelById));
			int num = (skillLevelById <= 0) ? 0 : (skillLevelById - 1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), value.TalentDesc, new <>z__ReadOnlySingleElementList<object>((num >= 0 && num < value.ArgsLength) ? value.Args(num) : null));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Text_LevelNumber_Text", new <>z__ReadOnlySingleElementList<object>(skillLevelById + 1));
			int num2 = flag ? (skillLevelById - 1) : skillLevelById;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), value.TalentDesc, new <>z__ReadOnlySingleElementList<object>((num2 >= 0 && num2 < value.ArgsLength) ? value.Args(num2) : null));
			RogueResTheme value2 = ConfigRogueResThemeById.GetConfig(ConfigRogueResTalentTreeById.GetConfig(this.Data.Value.Id, true).Value.SeasonId, true).Value;
			RogueResCurrency? config = ConfigRogueResCurrencyById.GetConfig(value2.SkillItem, true);
			int currency = ModelBase<ActivityPermanentRogueModel>.Instance.GetCurrency(value2.SkillItem);
			int num3 = (skillLevelById >= 0 && skillLevelById < data.ConsuleLength) ? data.Consule(skillLevelById) : 0;
			bool flag2 = currency >= num3;
			UUIText text = base.GetText(8);
			text.SetText(num3.ToString(), true);
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
			base.SetTextureByPath(config.Value.IconSmall, base.GetTexture(12), null, null);
			this.UpdateDetail(skillLevelById, flag);
		}

		// Token: 0x0603871C RID: 231196 RVA: 0x00E4C5B0 File Offset: 0x00E4A7B0
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

		// Token: 0x0402036E RID: 131950
		public RogueResTalentTree? Data;
	}
}
