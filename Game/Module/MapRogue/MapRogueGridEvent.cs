using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005972 RID: 22898
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueGridEvent : UiPanelBase
	{
		// Token: 0x0603A043 RID: 237635 RVA: 0x00EAEC34 File Offset: 0x00EACE34
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUINiagara)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText))
			};
		}

		// Token: 0x0603A044 RID: 237636 RVA: 0x00EAECE6 File Offset: 0x00EACEE6
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603A045 RID: 237637 RVA: 0x00EAECFC File Offset: 0x00EACEFC
		protected override UniTask OnHideAsyncImplementImplement()
		{
			MapRogueGridEvent.<OnHideAsyncImplementImplement>d__14 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<MapRogueGridEvent.<OnHideAsyncImplementImplement>d__14>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603A046 RID: 237638 RVA: 0x00EAED40 File Offset: 0x00EACF40
		public void Refresh(MapGridData data)
		{
			if (this.EventId == data.GridEventId)
			{
				return;
			}
			this.Data = data;
			this.EventId = data.GridEventId;
			RogueResGridEvent? gridEventConfigById = ConfigBase<MapRogueConfig>.Instance.GetGridEventConfigById(data.GridEventId);
			if (gridEventConfigById == null)
			{
				return;
			}
			RogueResEventCue? rogueResEventCueByType = ConfigBase<MapRogueConfig>.Instance.GetRogueResEventCueByType(gridEventConfigById.Value.Fx);
			if (rogueResEventCueByType == null)
			{
				return;
			}
			if (rogueResEventCueByType.Value.IsSpecial)
			{
				this.SetEventSpecial();
			}
			else
			{
				this.SetEventNormal(rogueResEventCueByType.Value.FxColor, rogueResEventCueByType.Value.SpriteColor);
			}
			base.SetTextureShowUntilLoaded(rogueResEventCueByType.Value.IconPath, base.GetTexture(1), null);
			this.RefreshStar(gridEventConfigById.Value.Star > 0, gridEventConfigById.Value.Star);
			this.RefreshLv(true);
		}

		// Token: 0x0603A047 RID: 237639 RVA: 0x00EAEE38 File Offset: 0x00EAD038
		private void SetEventSpecial()
		{
			UUISprite sprite1 = base.GetSprite(2);
			UUISprite sprite2 = base.GetSprite(3);
			UUINiagara uiNiagara = base.GetUiNiagara(0);
			base.SetNiagaraSystemByPath("/Game/Aki/Effect/UI/Niagaras/RouGe/NS_Fx_LGUI_RouGeStar_Start_Color.NS_Fx_LGUI_RouGeStar_Start_Color", uiNiagara, null);
			FKuroCurveLinearColor fkuroCurveLinearColor = uiNiagara.ColorParameter.Get("Color");
			FColor fcolor = FColor.FromHex("FFFFFFFF");
			fkuroCurveLinearColor.Constant = FLinearColor.FromSRGBColor(fcolor);
			uiNiagara.SetUIActive(true);
			this.SetSpriteByPath("/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/SP_EventVfx2.SP_EventVfx2", sprite1, false, null, delegate(bool _)
			{
				sprite1.SetUIActive(true);
			});
			this.SetSpriteByPath("/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/SP_EventVfx2.SP_EventVfx2", sprite2, false, null, delegate(bool _)
			{
				sprite2.SetUIActive(true);
			});
		}

		// Token: 0x0603A048 RID: 237640 RVA: 0x00EAEEF8 File Offset: 0x00EAD0F8
		private void SetEventNormal(string fxColor, string spriteColor)
		{
			UUISprite sprite = base.GetSprite(2);
			UUISprite sprite2 = base.GetSprite(3);
			UUINiagara uiNiagara = base.GetUiNiagara(0);
			bool flag = !StringUtils.IsEmpty(fxColor);
			if (flag)
			{
				base.SetNiagaraSystemByPath("/Game/Aki/Effect/UI/Niagaras/RouGe/NS_Fx_LGUI_RouGeStar_Start.NS_Fx_LGUI_RouGeStar_Start", uiNiagara, null);
				FKuroCurveLinearColor fkuroCurveLinearColor = uiNiagara.ColorParameter.Get("Color");
				FColor fcolor = FColor.FromHex(fxColor);
				fkuroCurveLinearColor.Constant = FLinearColor.FromSRGBColor(fcolor);
			}
			uiNiagara.SetUIActive(flag);
			bool flag2 = !StringUtils.IsEmpty(spriteColor);
			if (flag2)
			{
				this.SetSpriteByPath("/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/SP_EventVfx1.SP_EventVfx1", sprite, false, null, null);
				this.SetSpriteByPath("/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/SP_EventVfx1.SP_EventVfx1", sprite2, false, null, null);
				sprite.SetColor(FColor.FromHex(spriteColor));
				sprite2.SetColor(FColor.FromHex(spriteColor));
			}
			sprite.SetUIActive(flag2);
			sprite2.SetUIActive(flag2);
		}

		// Token: 0x0603A049 RID: 237641 RVA: 0x00EAEFCC File Offset: 0x00EAD1CC
		private void RefreshStar(bool isActive, int starNum)
		{
			UUISprite sprite = base.GetSprite(4);
			if (isActive)
			{
				int key = Math.Min(3, starNum);
				this.SetSpriteByPath(this.starSpriteMap[key], sprite, false, null, null);
			}
			sprite.SetUIActive(isActive);
		}

		// Token: 0x0603A04A RID: 237642 RVA: 0x00EAF014 File Offset: 0x00EAD214
		private void SetLv(bool isActive, int lv, bool useChangeColor, string changeColor)
		{
			base.GetItem(5).SetUIActive(isActive);
			if (isActive)
			{
				UUIItem text = base.GetText(6);
				FColor? fcolor = new FColor?(FColor.FromHex(changeColor));
				text.SetChangeColor(useChangeColor, fcolor);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "RogueRes_MapPointLvl", new <>z__ReadOnlySingleElementList<object>(lv));
			}
		}

		// Token: 0x0603A04B RID: 237643 RVA: 0x00EAF070 File Offset: 0x00EAD270
		public void RefreshLv(bool bShowLv = true)
		{
			if (this.Data == null)
			{
				return;
			}
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (!gameInfo.IsOverEventRecommendLv(this.Data.GridIndex))
			{
				this.SetLv(this.Data.Lv > 0 && bShowLv, this.Data.Lv, true, "c25757");
				return;
			}
			if (gameInfo.IsGridCanSkipBattle(this.Data.GridIndex))
			{
				this.SetLv(this.Data.Lv > 0 && bShowLv, this.Data.Lv, true, "5cc35e");
				return;
			}
			this.SetLv(this.Data.Lv > 0 && bShowLv, this.Data.Lv, false, "5cc35e");
		}

		// Token: 0x0603A04C RID: 237644 RVA: 0x00EAF12E File Offset: 0x00EAD32E
		public void SetVision(bool bHasVision)
		{
			this.SetActive(bHasVision);
		}

		// Token: 0x04020E43 RID: 134723
		[Nullable(2)]
		private MapGridData Data;

		// Token: 0x04020E44 RID: 134724
		private int EventId = -1;

		// Token: 0x04020E45 RID: 134725
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04020E46 RID: 134726
		private const string SPECIAL_NIAGARA_PATH = "/Game/Aki/Effect/UI/Niagaras/RouGe/NS_Fx_LGUI_RouGeStar_Start_Color.NS_Fx_LGUI_RouGeStar_Start_Color";

		// Token: 0x04020E47 RID: 134727
		private const string NORMAL_NIAGARA_PATH = "/Game/Aki/Effect/UI/Niagaras/RouGe/NS_Fx_LGUI_RouGeStar_Start.NS_Fx_LGUI_RouGeStar_Start";

		// Token: 0x04020E48 RID: 134728
		private const string SPECIAL_SPRITE_PATH = "/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/SP_EventVfx2.SP_EventVfx2";

		// Token: 0x04020E49 RID: 134729
		private const string NORMAL_SPRITE_PATH = "/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/SP_EventVfx1.SP_EventVfx1";

		// Token: 0x04020E4A RID: 134730
		private const string SPECIAL_NIAGARA_COLOR = "FFFFFFFF";

		// Token: 0x04020E4B RID: 134731
		private const int STAR_MAX_COUNT = 3;

		// Token: 0x04020E4C RID: 134732
		private const string LOW_LEVEL_COLOR = "c25757";

		// Token: 0x04020E4D RID: 134733
		private const string SKIP_LEVEL_COLOR = "5cc35e";

		// Token: 0x04020E4E RID: 134734
		public readonly Dictionary<int, string> starSpriteMap = new Dictionary<int, string>
		{
			{
				1,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/SP_EventStar1.SP_EventStar1"
			},
			{
				2,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/SP_EventStar2.SP_EventStar2"
			},
			{
				3,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/SP_EventStar3.SP_EventStar3"
			}
		};
	}
}
