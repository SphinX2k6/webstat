using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005234 RID: 21044
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleTokenItem : GridProxyAbstract<RogueResGainData>
	{
		// Token: 0x06035E62 RID: 220770 RVA: 0x00D91180 File Offset: 0x00D8F380
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
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.ToggleCallBackInternal))
			};
		}

		// Token: 0x06035E63 RID: 220771 RVA: 0x00D912B0 File Offset: 0x00D8F4B0
		protected override void OnStart()
		{
			this.ElementLayout = new GenericLayout<RogueBattleTokenElement, int>(base.GetHorizontalLayout(3), () => new RogueBattleTokenElement(), null, false, true);
			base.GetItem(10).SetUIActive(false);
		}

		// Token: 0x06035E64 RID: 220772 RVA: 0x00D912FF File Offset: 0x00D8F4FF
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RogueBattleDescModeChange, new Action(this.RefreshDescText));
		}

		// Token: 0x06035E65 RID: 220773 RVA: 0x00D9131D File Offset: 0x00D8F51D
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueBattleDescModeChange, new Action(this.RefreshDescText));
		}

		// Token: 0x06035E66 RID: 220774 RVA: 0x00D9133C File Offset: 0x00D8F53C
		private void ToggleCallBackInternal(EToggleState state)
		{
			if (base.GetExtendToggle(5).GetToggleState() == EToggleState.ETT_Checked)
			{
				this.OnSelected(true);
				Action<int?> onClickHandle = this.OnClickHandle;
				if (onClickHandle == null)
				{
					return;
				}
				onClickHandle(new int?(base.GridIndex));
				return;
			}
			else
			{
				this.OnDeselected(true);
				Action<int?> onClickHandle2 = this.OnClickHandle;
				if (onClickHandle2 == null)
				{
					return;
				}
				onClickHandle2(null);
				return;
			}
		}

		// Token: 0x06035E67 RID: 220775 RVA: 0x00D9139C File Offset: 0x00D8F59C
		[NullableContext(1)]
		public override void Refresh(RogueResGainData data, bool isSelected, int gridIndex)
		{
			RogueBattleTokenItem.<>c__DisplayClass8_0 CS$<>8__locals1 = new RogueBattleTokenItem.<>c__DisplayClass8_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			if (CS$<>8__locals1.data.RogueResToken == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.RogueBattle, ELogAuthor.LPH, "RogueBattleTokenItem.Refresh data.RogueResToken is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.GainData = CS$<>8__locals1.data;
			RogueResToken rogueResToken = CS$<>8__locals1.data.RogueResToken;
			base.GetItem(6).SetUIActive(rogueResToken.IsNew);
			RogueResBuffPool? rogueResBuffPoolById = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBuffPoolById(rogueResToken.ConfigId);
			if (rogueResBuffPoolById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RogueBattle;
				ELogAuthor author = ELogAuthor.LPH;
				string message = "RogueBattleTokenItem.Refresh tokenConfig is null";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", rogueResToken.ConfigId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			base.GetText(2).ShowTextNew(rogueResBuffPoolById.Value.BuffName);
			base.SetTextureByPath(rogueResBuffPoolById.Value.BuffIcon, base.GetTexture(1), null, null);
			RogueWeekQualityConfig? rogueWeeklyQualityConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyQualityConfig(rogueResBuffPoolById.Value.Quality);
			if (rogueWeeklyQualityConfig != null)
			{
				base.SetTextureByPath(rogueWeeklyQualityConfig.Value.TokenBg, base.GetTexture(0), null, null);
				base.GetSprite(7).SetColor(FColor.FromHex(rogueWeeklyQualityConfig.Value.TokenColor));
			}
			base.GetItem(8).SetUIActive(rogueResBuffPoolById.Value.Quality == 6);
			base.GetItem(9).SetUIActive(rogueResBuffPoolById.Value.Quality == 5);
			this.RefreshDescText();
			UiAsyncTask task = new UiAsyncTask("RogueBattleTokenItem.Refresh", delegate()
			{
				RogueBattleTokenItem.<>c__DisplayClass8_0.<<Refresh>b__0>d <<Refresh>b__0>d;
				<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
				<<Refresh>b__0>d.<>1__state = -1;
				<<Refresh>b__0>d.<>t__builder.Start<RogueBattleTokenItem.<>c__DisplayClass8_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
				return <<Refresh>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x06035E68 RID: 220776 RVA: 0x00D9157C File Offset: 0x00D8F77C
		public void RefreshDescText()
		{
			if (this.GainData == null)
			{
				return;
			}
			RogueResToken rogueResToken = this.GainData.RogueResToken;
			RogueResBuffPool? rogueResBuffPoolById = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBuffPoolById(rogueResToken.ConfigId);
			if (rogueResBuffPoolById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RogueBattle;
				ELogAuthor author = ELogAuthor.LPH;
				string message = "RogueBattleTokenItem.RefreshDescText tokenConfig is null";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", rogueResToken.ConfigId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (ModelBase<RogueBattleModel>.Instance.DescMode == EDescModel.SIMPLE)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), rogueResBuffPoolById.Value.BuffDescSimple, Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), rogueResBuffPoolById.Value.BuffDesc, rogueResBuffPoolById.Value.BuffDescParam());
		}

		// Token: 0x06035E69 RID: 220777 RVA: 0x00D9164E File Offset: 0x00D8F84E
		public override void OnSelected(bool fireEvent)
		{
			ModelBase<RogueBattleModel>.Instance.SelectGainData = this.GainData;
			base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x06035E6A RID: 220778 RVA: 0x00D91671 File Offset: 0x00D8F871
		public override void OnDeselected(bool fireEvent)
		{
			ModelBase<RogueBattleModel>.Instance.SelectGainData = null;
			base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0401EF9B RID: 126875
		public RogueResGainData GainData;

		// Token: 0x0401EF9C RID: 126876
		public Action<int?> OnClickHandle;

		// Token: 0x0401EF9D RID: 126877
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RogueBattleTokenElement, int> ElementLayout;
	}
}
