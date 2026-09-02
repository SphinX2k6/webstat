using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006010 RID: 24592
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleTimeDilationButton : FormationExtraButton
	{
		// Token: 0x0603DF59 RID: 253785 RVA: 0x00FCF128 File Offset: 0x00FCD328
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(0, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUISprite)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIText)));
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUIItem)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUIItem)));
			}
		}

		// Token: 0x0603DF5A RID: 253786 RVA: 0x00FCF204 File Offset: 0x00FCD404
		protected override UniTask OnBeforeStartAsync()
		{
			BattleTimeDilationButton.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleTimeDilationButton.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DF5B RID: 253787 RVA: 0x00FCF247 File Offset: 0x00FCD447
		protected override void OnBeforeCreateImplement()
		{
			this.UiLevelSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiLevelSequence);
		}

		// Token: 0x0603DF5C RID: 253788 RVA: 0x00FCF264 File Offset: 0x00FCD464
		protected override void OnStart()
		{
			base.OnStart();
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				CombineKeyItem keyItemPc = this.KeyItemPc;
				if (keyItemPc != null)
				{
					keyItemPc.RefreshAction("Link大招");
				}
				CombineKeyItem keyItemGp = this.KeyItemGp;
				if (keyItemGp != null)
				{
					keyItemGp.RefreshAction("Link大招");
				}
				this.RefreshKeyItemVisible();
			}
			this.PanelCdRoot = base.GetItem(2);
			this.BarCdSprite = base.GetSprite(3);
			this.BarCdText = base.GetText(4);
			this.ToggleHourGlass = base.GetExtendToggle(1);
			UUIExtendToggle toggleHourGlass = this.ToggleHourGlass;
			if (toggleHourGlass != null)
			{
				toggleHourGlass.OnPointDownCallBack.Bind(new Action<EToggleState>(this.OnClicked));
			}
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
			this.PostEffectHandle = instance.SpawnEffect(world, ftransformDouble, "/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_Post_ForTimeStop_White.DA_Fx_Group_Post_ForTimeStop_White", "BattleTimeDilationButton_effect", null, EEffectType.Scene, null, new Action<ELoadEffectResult, int>(this.OnEffectLoaded), null, true, false);
			ControllerBase<InputDistributeController>.Instance.BindAction("Link大招", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputActive));
		}

		// Token: 0x0603DF5D RID: 253789 RVA: 0x00FCF36C File Offset: 0x00FCD56C
		protected override void OnShowBattleChildView()
		{
			base.OnShowBattleChildView();
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiTimeDilationStateChanged, new Action(this.OnStateChanged));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			this.OnStateChanged();
		}

		// Token: 0x0603DF5E RID: 253790 RVA: 0x00FCF3F0 File Offset: 0x00FCD5F0
		protected override void OnHideBattleChildView()
		{
			base.OnHideBattleChildView();
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiTimeDilationStateChanged, new Action(this.OnStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			this.EnableCoolDown = false;
		}

		// Token: 0x0603DF5F RID: 253791 RVA: 0x00FCF474 File Offset: 0x00FCD674
		public override void Tick(float delta)
		{
			if (!this.EnableCoolDown)
			{
				return;
			}
			if (this.TotalCoolDownTime <= 0f)
			{
				return;
			}
			double num = (double)this.TotalCoolDownTime - Singleton<Time>.Instance.WorldTime * Singleton<TimeUtil>.Instance.Millisecond + (double)this.CoolDownStartTime;
			double num2 = num / (double)this.TotalCoolDownTime;
			UUISprite barCdSprite = this.BarCdSprite;
			if (barCdSprite != null)
			{
				barCdSprite.SetFillAmount((float)num2);
			}
			UUIText barCdText = this.BarCdText;
			if (barCdText == null)
			{
				return;
			}
			barCdText.SetText(num.ToString("F1"), true);
		}

		// Token: 0x0603DF60 RID: 253792 RVA: 0x00FCF4F8 File Offset: 0x00FCD6F8
		[NullableContext(1)]
		private void OnInputActive(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (!base.GetActive())
			{
				return;
			}
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			this.TriggerAction();
		}

		// Token: 0x0603DF61 RID: 253793 RVA: 0x00FCF50D File Offset: 0x00FCD70D
		private void OnClicked(EToggleState _)
		{
			this.TriggerAction();
		}

		// Token: 0x0603DF62 RID: 253794 RVA: 0x00FCF515 File Offset: 0x00FCD715
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.RefreshKeyItemVisible();
		}

		// Token: 0x0603DF63 RID: 253795 RVA: 0x00FCF520 File Offset: 0x00FCD720
		private void TriggerAction()
		{
			Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.LJM, "[BattleTimeDilationButton]", default(ReadOnlySpan<ValueTuple<string, object>>));
			switch (ModelBase<BattleUiModel>.Instance.CurrentTimeDilationSkillState)
			{
			case ETimeDilationSkillState.Ready:
				ModelBase<BattleUiModel>.Instance.SetTimeDilationState(ETimeDilationSkillState.InUse);
				return;
			case ETimeDilationSkillState.InUse:
				ModelBase<BattleUiModel>.Instance.SetTimeDilationState(ETimeDilationSkillState.CD);
				return;
			case ETimeDilationSkillState.CD:
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhotoFightTimeSlowNotReady", Array.Empty<object>());
				return;
			default:
				return;
			}
		}

		// Token: 0x0603DF64 RID: 253796 RVA: 0x00FCF594 File Offset: 0x00FCD794
		private void ClearAction()
		{
			Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.LJM, "[BattleTimeDilationButton]ClearAction", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (this.PostEffectHandle != 0)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.PostEffectHandle, "[BattleTimeDilationButton]ClearAction", true, null);
				this.PostEffectHandle = 0;
			}
			if (this.ScreenEffectHandle != 0)
			{
				ModelBase<ScreenEffectModel>.Instance.EndScreenEffect(this.ScreenEffectHandle);
				this.ScreenEffectHandle = 0;
			}
			if (ModelBase<BattleUiModel>.Instance.CurrentTimeDilationSkillState == ETimeDilationSkillState.InUse)
			{
				ModelBase<BattleUiModel>.Instance.SetTimeDilationState(ETimeDilationSkillState.CD);
			}
		}

		// Token: 0x0603DF65 RID: 253797 RVA: 0x00FCF624 File Offset: 0x00FCD824
		private void OnStateChanged()
		{
			switch (ModelBase<BattleUiModel>.Instance.CurrentTimeDilationSkillState)
			{
			case ETimeDilationSkillState.Ready:
			{
				this.EnableCoolDown = false;
				UUIItem panelCdRoot = this.PanelCdRoot;
				if (panelCdRoot != null)
				{
					panelCdRoot.SetUIActive(false);
				}
				this.PlayShowAnim();
				break;
			}
			case ETimeDilationSkillState.InUse:
			{
				this.EnableCoolDown = false;
				UUIItem panelCdRoot2 = this.PanelCdRoot;
				if (panelCdRoot2 != null)
				{
					panelCdRoot2.SetUIActive(false);
				}
				this.PlayLoopAnim();
				this.FightPhotoLogReport();
				break;
			}
			case ETimeDilationSkillState.CD:
			{
				this.EnableCoolDown = true;
				UUIItem panelCdRoot3 = this.PanelCdRoot;
				if (panelCdRoot3 != null)
				{
					panelCdRoot3.SetUIActive(true);
				}
				this.CoolDownStartTime = ModelBase<BattleUiModel>.Instance.TimeDilationCoolDownStartTime;
				this.TotalCoolDownTime = ModelBase<BattleUiModel>.Instance.TimeDilationSkillCdTime;
				this.PlayCloseAnim();
				break;
			}
			}
			this.UpdateAllEffectState();
		}

		// Token: 0x0603DF66 RID: 253798 RVA: 0x00FCF6E0 File Offset: 0x00FCD8E0
		private void FightPhotoLogReport()
		{
			FightPhotoTimeDilationLogEvent fightPhotoTimeDilationLogEvent = new FightPhotoTimeDilationLogEvent();
			FightPhotoLevelData currentLevelData = ControllerBase<FightPhotoController>.Instance.GetActivityData().GetCurrentLevelData(true);
			fightPhotoTimeDilationLogEvent.inst_id = currentLevelData.InstanceId;
			fightPhotoTimeDilationLogEvent.inst_diff = ((currentLevelData.IsDifficulty > false) ? 1 : 0);
			fightPhotoTimeDilationLogEvent.trace_id = ModelBase<CreatureModel>.Instance.GetSceneTraceId().ToString();
			ControllerBase<LogReportController>.Instance.LogReport(fightPhotoTimeDilationLogEvent);
		}

		// Token: 0x0603DF67 RID: 253799 RVA: 0x00FCF748 File Offset: 0x00FCD948
		public void PlayShowAnim()
		{
			if (this.UiLevelSequence.HasSequenceNameInPlaying("Start"))
			{
				return;
			}
			if (this.UiLevelSequence.IsInSequence())
			{
				this.UiLevelSequence.StopPrevSequence(false, true);
			}
			this.UiLevelSequence.PlaySequence("Start", false, null);
		}

		// Token: 0x0603DF68 RID: 253800 RVA: 0x00FCF79C File Offset: 0x00FCD99C
		public void PlayLoopAnim()
		{
			if (this.UiLevelSequence.HasSequenceNameInPlaying("Loop"))
			{
				return;
			}
			if (this.UiLevelSequence.IsInSequence())
			{
				this.UiLevelSequence.StopPrevSequence(false, true);
			}
			this.UiLevelSequence.PlaySequence("Loop", false, null);
		}

		// Token: 0x0603DF69 RID: 253801 RVA: 0x00FCF7F0 File Offset: 0x00FCD9F0
		public void PlayCloseAnim()
		{
			if (this.UiLevelSequence.HasSequenceNameInPlaying("Close"))
			{
				return;
			}
			if (this.UiLevelSequence.IsInSequence())
			{
				this.UiLevelSequence.StopPrevSequence(false, true);
			}
			this.UiLevelSequence.PlaySequence("Close", false, null);
		}

		// Token: 0x0603DF6A RID: 253802 RVA: 0x00FCF844 File Offset: 0x00FCDA44
		private void RefreshKeyItemVisible()
		{
			CombineKeyItem keyItemPc = this.KeyItemPc;
			if (keyItemPc != null)
			{
				keyItemPc.SetUiActive(Singleton<Info>.Instance.IsInKeyBoard());
			}
			CombineKeyItem keyItemGp = this.KeyItemGp;
			if (keyItemGp == null)
			{
				return;
			}
			keyItemGp.SetUiActive(Singleton<Info>.Instance.IsInGamepad());
		}

		// Token: 0x0603DF6B RID: 253803 RVA: 0x00FCF87B File Offset: 0x00FCDA7B
		protected override void OnBeforeDestroy()
		{
			this.ClearAction();
			ControllerBase<InputDistributeController>.Instance.UnBindAction("Link大招", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputActive));
		}

		// Token: 0x0603DF6C RID: 253804 RVA: 0x00FCF89E File Offset: 0x00FCDA9E
		private void OnEffectLoaded(ELoadEffectResult result, int handle)
		{
			if (result != ELoadEffectResult.Success)
			{
				return;
			}
			this.UpdateEffectState(handle);
		}

		// Token: 0x0603DF6D RID: 253805 RVA: 0x00FCF8AC File Offset: 0x00FCDAAC
		private void OnOpenView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.FightPhotographView)
			{
				return;
			}
			this.IsPhotographViewOpen = true;
			this.OnStateChanged();
		}

		// Token: 0x0603DF6E RID: 253806 RVA: 0x00FCF8C9 File Offset: 0x00FCDAC9
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.FightPhotographView)
			{
				return;
			}
			this.IsPhotographViewOpen = false;
			this.OnStateChanged();
		}

		// Token: 0x0603DF6F RID: 253807 RVA: 0x00FCF8E6 File Offset: 0x00FCDAE6
		private void UpdateAllEffectState()
		{
			this.UpdateEffectState(this.PostEffectHandle);
			this.UpdateScreenEffect();
		}

		// Token: 0x0603DF70 RID: 253808 RVA: 0x00FCF8FC File Offset: 0x00FCDAFC
		private void UpdateEffectState(int handle)
		{
			if (!Singleton<EffectSystem>.Instance.IsValid(handle))
			{
				return;
			}
			if (this.IsPhotographViewOpen)
			{
				Singleton<EffectSystem>.Instance.SetEffectHidden(handle, true, null, false);
				return;
			}
			switch (ModelBase<BattleUiModel>.Instance.CurrentTimeDilationSkillState)
			{
			case ETimeDilationSkillState.Ready:
			case ETimeDilationSkillState.CD:
				Singleton<EffectSystem>.Instance.SetEffectHidden(handle, true, null, false);
				return;
			case ETimeDilationSkillState.InUse:
			{
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				string reason = "[BattleTimeDilationButton.ReplayEffect]";
				FTransformDouble? ftransformDouble = null;
				instance.ReplayEffect(handle, reason, ftransformDouble);
				Singleton<EffectSystem>.Instance.SetEffectHidden(handle, false, null, false);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0603DF71 RID: 253809 RVA: 0x00FCF984 File Offset: 0x00FCDB84
		private void UpdateScreenEffect()
		{
			if (this.ScreenEffectHandle != 0)
			{
				ModelBase<ScreenEffectModel>.Instance.EndScreenEffect(this.ScreenEffectHandle);
			}
			if (this.IsPhotographViewOpen)
			{
				return;
			}
			if (ModelBase<BattleUiModel>.Instance.CurrentTimeDilationSkillState == ETimeDilationSkillState.InUse)
			{
				this.ScreenEffectHandle = ModelBase<ScreenEffectModel>.Instance.PlayScreenEffect("/Game/Aki/Effect/DataAsset/ScreenDA/SD_Fight/Bigworld/DA_Fx_Screen_ForTimeStop_White.DA_Fx_Screen_ForTimeStop_White", null, null);
			}
		}

		// Token: 0x04022BFD RID: 142333
		[Nullable(1)]
		private const string POST_EFFECT_PATH = "/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_Post_ForTimeStop_White.DA_Fx_Group_Post_ForTimeStop_White";

		// Token: 0x04022BFE RID: 142334
		[Nullable(1)]
		private const string SCREEN_EFFECT_PATH = "/Game/Aki/Effect/DataAsset/ScreenDA/SD_Fight/Bigworld/DA_Fx_Screen_ForTimeStop_White.DA_Fx_Screen_ForTimeStop_White";

		// Token: 0x04022BFF RID: 142335
		private CombineKeyItem KeyItemPc;

		// Token: 0x04022C00 RID: 142336
		private CombineKeyItem KeyItemGp;

		// Token: 0x04022C01 RID: 142337
		private UUIItem PanelCdRoot;

		// Token: 0x04022C02 RID: 142338
		private UUISprite BarCdSprite;

		// Token: 0x04022C03 RID: 142339
		private UUIText BarCdText;

		// Token: 0x04022C04 RID: 142340
		private UUIExtendToggle ToggleHourGlass;

		// Token: 0x04022C05 RID: 142341
		public UiBehaviorLevelSequence UiLevelSequence;

		// Token: 0x04022C06 RID: 142342
		private int PostEffectHandle;

		// Token: 0x04022C07 RID: 142343
		private int ScreenEffectHandle;

		// Token: 0x04022C08 RID: 142344
		private float TotalCoolDownTime;

		// Token: 0x04022C09 RID: 142345
		private float CoolDownStartTime;

		// Token: 0x04022C0A RID: 142346
		private bool EnableCoolDown;

		// Token: 0x04022C0B RID: 142347
		private bool IsPhotographViewOpen;

		// Token: 0x0200C0AE RID: 49326
		[NullableContext(0)]
		private enum EDesktopChildType
		{
			// Token: 0x0403B530 RID: 242992
			KeyItemPc = 5,
			// Token: 0x0403B531 RID: 242993
			KeyItemGp
		}

		// Token: 0x0200C0AF RID: 49327
		[NullableContext(0)]
		private enum EBattleTimeDilationComponent
		{
			// Token: 0x0403B533 RID: 242995
			RootItem,
			// Token: 0x0403B534 RID: 242996
			ToggleHourGlass,
			// Token: 0x0403B535 RID: 242997
			PanelCDRoot,
			// Token: 0x0403B536 RID: 242998
			BarCDSprite,
			// Token: 0x0403B537 RID: 242999
			BarCDText
		}
	}
}
