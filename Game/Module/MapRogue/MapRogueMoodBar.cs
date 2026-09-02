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
	// Token: 0x02005963 RID: 22883
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueMoodBar : UiPanelBase
	{
		// Token: 0x06039FE0 RID: 237536 RVA: 0x00EACF94 File Offset: 0x00EAB194
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickBtnInfo))
			};
		}

		// Token: 0x06039FE1 RID: 237537 RVA: 0x00EAD081 File Offset: 0x00EAB281
		protected override void OnStart()
		{
			this.LevelSequencePlayerInstance = new LevelSequencePlayer(this.RootItem);
			base.GetItem(1).SetUIActive(false);
		}

		// Token: 0x06039FE2 RID: 237538 RVA: 0x00EAD0A4 File Offset: 0x00EAB2A4
		protected override UniTask OnBeforeStartAsync()
		{
			MapRogueMoodBar.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapRogueMoodBar.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039FE3 RID: 237539 RVA: 0x00EAD0E8 File Offset: 0x00EAB2E8
		protected override UniTask OnShowAsyncImplementImplement()
		{
			MapRogueMoodBar.<OnShowAsyncImplementImplement>d__9 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<MapRogueMoodBar.<OnShowAsyncImplementImplement>d__9>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06039FE4 RID: 237540 RVA: 0x00EAD12C File Offset: 0x00EAB32C
		protected override UniTask OnHideAsyncImplementImplement()
		{
			MapRogueMoodBar.<OnHideAsyncImplementImplement>d__10 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<MapRogueMoodBar.<OnHideAsyncImplementImplement>d__10>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06039FE5 RID: 237541 RVA: 0x00EAD170 File Offset: 0x00EAB370
		public void SetMoodRuleId(int ruleId)
		{
			RogueResMoodRule? moodRuleById = ConfigBase<MapRogueConfig>.Instance.GetMoodRuleById(ruleId);
			if (moodRuleById == null)
			{
				return;
			}
			EMoodRuleType type = (EMoodRuleType)moodRuleById.Value.Type;
			if (type == EMoodRuleType.Safe)
			{
				this.LevelSequencePlayerInstance.PlayLevelSequenceByName("Light", false, null, false);
				return;
			}
			if (type != EMoodRuleType.Danger)
			{
				return;
			}
			this.LevelSequencePlayerInstance.PlayLevelSequenceByName("LightRed", false, null, false);
		}

		// Token: 0x06039FE6 RID: 237542 RVA: 0x00EAD1E3 File Offset: 0x00EAB3E3
		public void SetLimit(int min, int max)
		{
			this.PanelBarL.SetLimit(min);
			this.PanelBarR.SetLimit(max);
		}

		// Token: 0x06039FE7 RID: 237543 RVA: 0x00EAD200 File Offset: 0x00EAB400
		public void SetCurrentValue(int value)
		{
			base.GetText(6).SetText(value.ToString(), true);
			UUITexture texture = base.GetTexture(0);
			string path = (value >= 0) ? "/Game/Aki/UI/UIResources/UiRogue/Image/RogueView/T_RogueIconPositive.T_RogueIconPositive" : "/Game/Aki/UI/UIResources/UiRogue/Image/RogueView/T_RogueIconNegative.T_RogueIconNegative";
			base.SetTextureShowUntilLoaded(path, texture, null);
			this.PanelBarL.SetCurrentValue(value);
			this.PanelBarR.SetCurrentValue(value);
		}

		// Token: 0x06039FE8 RID: 237544 RVA: 0x00EAD25C File Offset: 0x00EAB45C
		public void ShowPreviewValue(int changeValue, int curValue)
		{
			MapRogueMoodBar.<>c__DisplayClass14_0 CS$<>8__locals1 = new MapRogueMoodBar.<>c__DisplayClass14_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.changeValue = changeValue;
			CS$<>8__locals1.curValue = curValue;
			if (CS$<>8__locals1.changeValue == 0)
			{
				return;
			}
			UiAsyncTask task = new UiAsyncTask("MapRogueMoodBar.ShowPreviewValue", delegate()
			{
				MapRogueMoodBar.<>c__DisplayClass14_0.<<ShowPreviewValue>b__0>d <<ShowPreviewValue>b__0>d;
				<<ShowPreviewValue>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<ShowPreviewValue>b__0>d.<>4__this = CS$<>8__locals1;
				<<ShowPreviewValue>b__0>d.<>1__state = -1;
				<<ShowPreviewValue>b__0>d.<>t__builder.Start<MapRogueMoodBar.<>c__DisplayClass14_0.<<ShowPreviewValue>b__0>d>(ref <<ShowPreviewValue>b__0>d);
				return <<ShowPreviewValue>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x06039FE9 RID: 237545 RVA: 0x00EAD2B0 File Offset: 0x00EAB4B0
		public void ClosePreviewValue()
		{
			base.GetItem(1).SetUIActive(false);
			UUIText text = base.GetText(6);
			UUIItem uuiitem = text;
			bool bUseChangeColor = false;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			this.PanelBarL.ClosePreviewValue();
			this.PanelBarR.ClosePreviewValue();
		}

		// Token: 0x06039FEA RID: 237546 RVA: 0x00EAD2FD File Offset: 0x00EAB4FD
		private void OnClickBtnInfo()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(262);
		}

		// Token: 0x06039FEB RID: 237547 RVA: 0x00EAD310 File Offset: 0x00EAB510
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length < 2)
			{
				return null;
			}
			UUIItem guideUiItem = base.GetGuideUiItem(configParams[1]);
			if (guideUiItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				guideUiItem,
				guideUiItem
			};
		}

		// Token: 0x04020DF2 RID: 134642
		private const string POSITIVE_TEXTURE_PATH = "/Game/Aki/UI/UIResources/UiRogue/Image/RogueView/T_RogueIconPositive.T_RogueIconPositive";

		// Token: 0x04020DF3 RID: 134643
		private const string NEGATIVE_TEXTURE_PATH = "/Game/Aki/UI/UIResources/UiRogue/Image/RogueView/T_RogueIconNegative.T_RogueIconNegative";

		// Token: 0x04020DF4 RID: 134644
		private const int MOOD_HELP_ID = 262;

		// Token: 0x04020DF5 RID: 134645
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayerInstance;

		// Token: 0x04020DF6 RID: 134646
		[Nullable(2)]
		protected PanelBar PanelBarL;

		// Token: 0x04020DF7 RID: 134647
		[Nullable(2)]
		protected PanelBar PanelBarR;
	}
}
