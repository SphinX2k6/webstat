using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F26 RID: 24358
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeSettleView : UiViewBase
	{
		// Token: 0x0603D2BB RID: 250555 RVA: 0x00F8B9E6 File Offset: 0x00F89BE6
		public FlagChallengeSettleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603D2BC RID: 250556 RVA: 0x00F8B9F0 File Offset: 0x00F89BF0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D2BD RID: 250557 RVA: 0x00F8BAE0 File Offset: 0x00F89CE0
		protected override UniTask OnBeforeStartAsync()
		{
			FlagChallengeSettleView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FlagChallengeSettleView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D2BE RID: 250558 RVA: 0x00F8BB23 File Offset: 0x00F89D23
		protected override void OnBeforeShow()
		{
			this.StartAutoLeaveTimer();
			this.TryPlaySequence();
		}

		// Token: 0x0603D2BF RID: 250559 RVA: 0x00F8BB31 File Offset: 0x00F89D31
		protected override void OnBeforeHide()
		{
			this.ClearAutoLeaveTimer();
		}

		// Token: 0x0603D2C0 RID: 250560 RVA: 0x00F8BB39 File Offset: 0x00F89D39
		protected override void OnBeforeDestroy()
		{
			this.ClearAutoLeaveTimer();
			this.IsPlayed = false;
		}

		// Token: 0x0603D2C1 RID: 250561 RVA: 0x00F8BB48 File Offset: 0x00F89D48
		private void RefreshTitle()
		{
			UUIText text = base.GetText(1);
			text.SetColor(FColor.FromHex("C48B29FF"));
			text.ShowTextNew("GenericPromptTypes_3_GeneralText");
			UUIEffectOutline uuieffectOutline = text.GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass()) as UUIEffectOutline;
			text.outlineColor = FColor.FromHex("C48B29FF");
			base.GetTexture(2).SetColor(FColor.FromHex("8C754D7F"));
			if (uuieffectOutline != null)
			{
				uuieffectOutline.SetOutlineColor(FColor.FromHex("C48B29FF"));
			}
			text.SetColor(FColor.FromHex("f2efd5"));
		}

		// Token: 0x0603D2C2 RID: 250562 RVA: 0x00F8BBDC File Offset: 0x00F89DDC
		private void StartAutoLeaveTimer()
		{
			int leftSecondToAutoLeave = 31;
			this.AutoLeaveTimerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				int leftSecondToAutoLeave;
				if (leftSecondToAutoLeave <= 0)
				{
					TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
					this.OnExitBtnClick();
					return;
				}
				FlagChallengeSettleButton flagChallengeSettleButton = this.ButtonMap[0];
				string textId = "InstanceDungeonLeftTimeToAutoLeave";
				object[] array = new object[1];
				int num = 0;
				leftSecondToAutoLeave = leftSecondToAutoLeave;
				leftSecondToAutoLeave--;
				array[num] = leftSecondToAutoLeave.ToString();
				flagChallengeSettleButton.SetFloatText(textId, array);
			}, 1000f, 1f, null, null, true);
		}

		// Token: 0x0603D2C3 RID: 250563 RVA: 0x00F8BC27 File Offset: 0x00F89E27
		private void TryPlaySequence()
		{
			if (this.IsPlayed)
			{
				return;
			}
			base.PlaySequence("Success", null, false);
			this.IsPlayed = true;
		}

		// Token: 0x0603D2C4 RID: 250564 RVA: 0x00F8BC48 File Offset: 0x00F89E48
		private void RefreshLevelPanel()
		{
			FlagChallengeSettleInfo settleInfo = ModelBase<FlagChallengeBattleModel>.Instance.SettleInfo;
			int level = settleInfo.Level;
			int cacheLevel = settleInfo.CacheLevel;
			int num = Singleton<MathUtils>.Instance.Clamp(level - cacheLevel, 0, level);
			int boxLevel = settleInfo.BoxLevel;
			this.LevelPanel.SetLevelText(level.ToString(), num.ToString(), boxLevel.ToString());
		}

		// Token: 0x0603D2C5 RID: 250565 RVA: 0x00F8BCA3 File Offset: 0x00F89EA3
		private void ClearAutoLeaveTimer()
		{
			if (this.AutoLeaveTimerId != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
			}
			this.AutoLeaveTimerId = null;
		}

		// Token: 0x0603D2C6 RID: 250566 RVA: 0x00F8BCC8 File Offset: 0x00F89EC8
		private UniTask InitButtonAsync()
		{
			FlagChallengeSettleView.<InitButtonAsync>d__19 <InitButtonAsync>d__;
			<InitButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtonAsync>d__.<>4__this = this;
			<InitButtonAsync>d__.<>1__state = -1;
			<InitButtonAsync>d__.<>t__builder.Start<FlagChallengeSettleView.<InitButtonAsync>d__19>(ref <InitButtonAsync>d__);
			return <InitButtonAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D2C7 RID: 250567 RVA: 0x00F8BD0C File Offset: 0x00F89F0C
		private UniTask InitLevelPanelAsync()
		{
			FlagChallengeSettleView.<InitLevelPanelAsync>d__20 <InitLevelPanelAsync>d__;
			<InitLevelPanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLevelPanelAsync>d__.<>4__this = this;
			<InitLevelPanelAsync>d__.<>1__state = -1;
			<InitLevelPanelAsync>d__.<>t__builder.Start<FlagChallengeSettleView.<InitLevelPanelAsync>d__20>(ref <InitLevelPanelAsync>d__);
			return <InitLevelPanelAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D2C8 RID: 250568 RVA: 0x00F8BD50 File Offset: 0x00F89F50
		private UniTask CreateButton(UUIItem uiItem, int buttonIndex, Action clickFunction)
		{
			FlagChallengeSettleView.<CreateButton>d__21 <CreateButton>d__;
			<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButton>d__.<>4__this = this;
			<CreateButton>d__.buttonIndex = buttonIndex;
			<CreateButton>d__.clickFunction = clickFunction;
			<CreateButton>d__.<>1__state = -1;
			<CreateButton>d__.<>t__builder.Start<FlagChallengeSettleView.<CreateButton>d__21>(ref <CreateButton>d__);
			return <CreateButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D2C9 RID: 250569 RVA: 0x00F8BDA4 File Offset: 0x00F89FA4
		private void OnNextLevelBtnClick()
		{
			int activityId = ModelBase<FlagChallengeBattleModel>.Instance.ActivityId;
			int? recommendLevel = ModelBase<FlagChallengeModel>.Instance.GetRecommendLevel(activityId, false);
			if (recommendLevel != null && recommendLevel.GetValueOrDefault() != 0)
			{
				ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeMainView(activityId, recommendLevel);
			}
		}

		// Token: 0x0603D2CA RID: 250570 RVA: 0x00F8BDE7 File Offset: 0x00F89FE7
		private void OnExitBtnClick()
		{
			ControllerBase<FlagChallengeBattleController>.Instance.LeaveFlagChallengeInstance().Forget();
		}

		// Token: 0x040224DA RID: 140506
		private const string SUCCESS_OUTLINE_COLOR = "C48B29FF";

		// Token: 0x040224DB RID: 140507
		private const string SUCCESS_TEXT_COLOR = "f2efd5";

		// Token: 0x040224DC RID: 140508
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Dictionary<int, FlagChallengeSettleButton> ButtonMap;

		// Token: 0x040224DD RID: 140509
		[Nullable(2)]
		protected FlagChallengeResultLevelPanel LevelPanel;

		// Token: 0x040224DE RID: 140510
		[Nullable(2)]
		private TimerHandle AutoLeaveTimerId;

		// Token: 0x040224DF RID: 140511
		private bool IsPlayed;

		// Token: 0x0200BF2F RID: 48943
		[NullableContext(0)]
		private enum EButtons
		{
			// Token: 0x0403AD94 RID: 241044
			LeftButton,
			// Token: 0x0403AD95 RID: 241045
			RightButton
		}

		// Token: 0x0200BF30 RID: 48944
		[NullableContext(0)]
		private enum EComponentType
		{
			// Token: 0x0403AD97 RID: 241047
			TitleItem,
			// Token: 0x0403AD98 RID: 241048
			TitleText,
			// Token: 0x0403AD99 RID: 241049
			TitleTexture,
			// Token: 0x0403AD9A RID: 241050
			ButtonHorizontalItem = 4,
			// Token: 0x0403AD9B RID: 241051
			ButtonItem,
			// Token: 0x0403AD9C RID: 241052
			ContentItem = 20
		}
	}
}
