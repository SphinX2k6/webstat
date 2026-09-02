using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005682 RID: 22146
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueIllustratedTokenItem : GridProxyAbstract<RogueResGainData>
	{
		// Token: 0x060386C6 RID: 231110 RVA: 0x00E4A420 File Offset: 0x00E48620
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUISprite))
			};
		}

		// Token: 0x060386C7 RID: 231111 RVA: 0x00E4A52C File Offset: 0x00E4872C
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RogueBattleDescModeChange, new Action(this.RefreshDescText));
		}

		// Token: 0x060386C8 RID: 231112 RVA: 0x00E4A54A File Offset: 0x00E4874A
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueBattleDescModeChange, new Action(this.RefreshDescText));
		}

		// Token: 0x060386C9 RID: 231113 RVA: 0x00E4A568 File Offset: 0x00E48768
		protected override void OnStart()
		{
			this.ElementLayout = new GenericLayout<RogueBattleTokenElement, int>(base.GetHorizontalLayout(3), () => new RogueBattleTokenElement(), null, false, true);
			base.GetExtendToggle(5).SetEnable(false);
			base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
			base.GetItem(6).SetUIActive(false);
		}

		// Token: 0x060386CA RID: 231114 RVA: 0x00E4A5D4 File Offset: 0x00E487D4
		[NullableContext(1)]
		public override void Refresh(RogueResGainData data, bool isSelected, int gridIndex)
		{
			RogueIllustratedTokenItem.<>c__DisplayClass8_0 CS$<>8__locals1 = new RogueIllustratedTokenItem.<>c__DisplayClass8_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			if (CS$<>8__locals1.data.RogueResToken == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.RogueBattle, ELogAuthor.LPH, "RogueBattleTokenItem.Refresh data.RogueResToken is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			RogueResToken rogueResToken = CS$<>8__locals1.data.RogueResToken;
			RogueBattleConfig instance = ConfigBase<RogueBattleConfig>.Instance;
			RogueResBuffPool? rogueResBuffPool = (instance != null) ? instance.GetRogueResBuffPoolById(rogueResToken.ConfigId) : null;
			if (rogueResBuffPool == null)
			{
				return;
			}
			this.GainData = CS$<>8__locals1.data;
			RogueResCollection? config = ConfigRogueResCollectionById.GetConfig(rogueResToken.ConfigId, true);
			SignState collectItemState = ModelBase<ActivityPermanentRogueModel>.Instance.GetCollectItemState(config.Value.IdKey);
			this.IsUnlock = (collectItemState > SignState.Lock);
			base.GetText(2).ShowTextNew(this.IsUnlock ? rogueResBuffPool.Value.BuffName : "RogueRes_CollectionEventLock");
			base.SetTextureByPath(rogueResBuffPool.Value.BuffIcon, base.GetTexture(1), null, null);
			WeeklyRogueConfig instance2 = ConfigBase<WeeklyRogueConfig>.Instance;
			RogueWeekQualityConfig? rogueWeekQualityConfig = (instance2 != null) ? instance2.GetRogueWeeklyQualityConfig(rogueResBuffPool.Value.Quality) : null;
			if (rogueWeekQualityConfig != null)
			{
				base.SetTextureByPath(rogueWeekQualityConfig.Value.TokenBg, base.GetTexture(0), null, null);
			}
			base.GetSprite(7).SetColor(FColor.FromHex(rogueWeekQualityConfig.Value.TokenColor));
			base.GetItem(8).SetUIActive(rogueResBuffPool.Value.Quality == 6);
			base.GetItem(9).SetUIActive(rogueResBuffPool.Value.Quality == 5);
			this.RefreshDescText();
			UiAsyncTask task = new UiAsyncTask("RogueBattleTokenItem.Refresh", delegate()
			{
				RogueIllustratedTokenItem.<>c__DisplayClass8_0.<<Refresh>b__0>d <<Refresh>b__0>d;
				<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
				<<Refresh>b__0>d.<>1__state = -1;
				<<Refresh>b__0>d.<>t__builder.Start<RogueIllustratedTokenItem.<>c__DisplayClass8_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
				return <<Refresh>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x060386CB RID: 231115 RVA: 0x00E4A7D4 File Offset: 0x00E489D4
		public void RefreshDescText()
		{
			if (this.GainData == null)
			{
				return;
			}
			if (!this.IsUnlock)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "RogueRes_CollectionEventLock", Array.Empty<object>());
				return;
			}
			RogueResToken rogueResToken = this.GainData.RogueResToken;
			RogueBattleConfig instance = ConfigBase<RogueBattleConfig>.Instance;
			RogueResBuffPool? rogueResBuffPool = (instance != null) ? instance.GetRogueResBuffPoolById(rogueResToken.ConfigId) : null;
			if (rogueResBuffPool == null)
			{
				return;
			}
			if (ModelBase<RogueBattleModel>.Instance.DescMode == EDescModel.SIMPLE)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), rogueResBuffPool.Value.BuffDescSimple, Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), rogueResBuffPool.Value.BuffDesc, rogueResBuffPool.Value.BuffDescParam());
		}

		// Token: 0x04020325 RID: 131877
		public RogueResGainData GainData;

		// Token: 0x04020326 RID: 131878
		public Action<int?> OnClickHandle;

		// Token: 0x04020327 RID: 131879
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RogueBattleTokenElement, int> ElementLayout;

		// Token: 0x04020328 RID: 131880
		private bool IsUnlock;
	}
}
