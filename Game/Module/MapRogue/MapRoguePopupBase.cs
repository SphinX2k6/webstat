using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005945 RID: 22853
	[NullableContext(2)]
	[Nullable(0)]
	public class MapRoguePopupBase : UiPanelBase
	{
		// Token: 0x06039F5C RID: 237404 RVA: 0x00EAB598 File Offset: 0x00EA9798
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnMaskBtnClick))
			};
		}

		// Token: 0x06039F5D RID: 237405 RVA: 0x00EAB644 File Offset: 0x00EA9844
		protected override UniTask OnBeforeStartAsync()
		{
			MapRoguePopupBase.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapRoguePopupBase.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039F5E RID: 237406 RVA: 0x00EAB688 File Offset: 0x00EA9888
		protected override void OnBeforeShow()
		{
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo == null)
			{
				return;
			}
			this.MoodBar.SetLimit(gameInfo.MoodMin, gameInfo.MoodMax);
			this.MoodBar.SetCurrentValue(gameInfo.Mood);
			int teamLvAnim = gameInfo.TeamLvAnim;
			this.PanelLv.SetLv(teamLvAnim, false);
			int lvCurrent = gameInfo.TeamLv;
			if (teamLvAnim == lvCurrent)
			{
				return;
			}
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.PanelLv.SetLv(lvCurrent, true);
			}, 500f, null, null, true, 1f);
		}

		// Token: 0x06039F5F RID: 237407 RVA: 0x00EAB727 File Offset: 0x00EA9927
		private void OnBackBtnClick()
		{
			ControllerBase<MapRogueController>.Instance.OpenExploreEnd(false);
		}

		// Token: 0x06039F60 RID: 237408 RVA: 0x00EAB734 File Offset: 0x00EA9934
		private void OnMaskBtnClick()
		{
			Action onMaskClick = this.OnMaskClick;
			if (onMaskClick == null)
			{
				return;
			}
			onMaskClick();
		}

		// Token: 0x06039F61 RID: 237409 RVA: 0x00EAB746 File Offset: 0x00EA9946
		private void OnBtnHelp()
		{
			ControllerBase<MapRogueController>.Instance.OpenMapHelpView();
		}

		// Token: 0x06039F62 RID: 237410 RVA: 0x00EAB754 File Offset: 0x00EA9954
		public void SetMaskButtonVisible(bool bVisible)
		{
			base.GetButton(3).RootUIComp.Get().SetUIActive(bVisible);
		}

		// Token: 0x06039F63 RID: 237411 RVA: 0x00EAB77B File Offset: 0x00EA997B
		[NullableContext(1)]
		public void SetHelpCallBack(Action call)
		{
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetHelpCallBack(call);
		}

		// Token: 0x04020D7F RID: 134527
		protected LevelSequencePlayer LevelSequencePlayerInstance;

		// Token: 0x04020D80 RID: 134528
		protected PopupCaptionItem CaptionItem;

		// Token: 0x04020D81 RID: 134529
		protected MapRoguePanelLv PanelLv;

		// Token: 0x04020D82 RID: 134530
		protected MapRogueTitleItem MapTitleItem;

		// Token: 0x04020D83 RID: 134531
		public MapRogueMoodBar MoodBar;

		// Token: 0x04020D84 RID: 134532
		public Action OnMaskClick;

		// Token: 0x04020D85 RID: 134533
		private const int LV_CHANGE_DELAY = 500;
	}
}
