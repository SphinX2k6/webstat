using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CF5 RID: 23797
	[NullableContext(1)]
	[Nullable(0)]
	public class TakePicturesWithTimeScaleChildQuestNode : TickBehaviorNode
	{
		// Token: 0x0603BFD5 RID: 245717 RVA: 0x00F366A8 File Offset: 0x00F348A8
		public TakePicturesWithTimeScaleChildQuestNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BFD6 RID: 245718 RVA: 0x00F366B4 File Offset: 0x00F348B4
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			if (!base.OnCreate(nodeConfig))
			{
				return false;
			}
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			ITimeScaledPhotograph timeScaledPhotograph = childQuestBtNode.Condition as ITimeScaledPhotograph;
			if (timeScaledPhotograph == null)
			{
				return false;
			}
			this.TipType = new ETimeScaledPhotographTip?(timeScaledPhotograph.ViewFinderTip);
			this.PhotographCondition = timeScaledPhotograph.PhotographCondition;
			if (timeScaledPhotograph.CameraCondition.Condition.Conditions.Count != 0)
			{
				this.CameraCondition = timeScaledPhotograph.CameraCondition;
			}
			this.IsInAutoViewFinderState = false;
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
			this.PostEffectHandle = instance.SpawnEffect(world, ftransformDouble, "/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_Post_ForTimeStop_White.DA_Fx_Group_Post_ForTimeStop_White", "TackPictureQuest_effect", null, EEffectType.Scene, null, new Action<ELoadEffectResult, int>(this.OnEffectLoaded), null, true, false);
			ModelBase<FightPhotoModel>.Instance.IsNewTaskCreated = true;
			return true;
		}

		// Token: 0x0603BFD7 RID: 245719 RVA: 0x00F36780 File Offset: 0x00F34980
		protected override void AddEventsOnChildQuestStart()
		{
			base.AddEventsOnChildQuestStart();
			Singleton<EventSystem>.Instance.Add(EEventName.NotifyBtFightPhotoTaskFinish, new Action(this.OnFightPhotoTaskFinish));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		}

		// Token: 0x0603BFD8 RID: 245720 RVA: 0x00F367E0 File Offset: 0x00F349E0
		protected override void RemoveEventsOnChildQuestEnd()
		{
			base.RemoveEventsOnChildQuestEnd();
			Singleton<EventSystem>.Instance.Remove(EEventName.NotifyBtFightPhotoTaskFinish, new Action(this.OnFightPhotoTaskFinish));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		}

		// Token: 0x0603BFD9 RID: 245721 RVA: 0x00F36840 File Offset: 0x00F34A40
		protected override void OnTick(float delta)
		{
			if (ControllerBase<PhotographController>.Instance.CheckIfInFightPhotographCamera())
			{
				if (this.LastStateIsCanFinishTask)
				{
					this.LastStateIsCanFinishTask = false;
					Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnNeedShowFightPhotoFocus, false);
				}
				return;
			}
			ETimeScaledPhotographTip? tipType = this.TipType;
			ETimeScaledPhotographTip etimeScaledPhotographTip = ETimeScaledPhotographTip.NoTip;
			if (tipType.GetValueOrDefault() == etimeScaledPhotographTip & tipType != null)
			{
				return;
			}
			if (ModelBase<FightPhotoModel>.Instance.CheckRoleInCamera(this.PhotographCondition) && ModelBase<FightPhotoModel>.Instance.CheckPhotographCondition(this.PhotographCondition))
			{
				if (!this.IsForceUpdate && this.LastStateIsCanFinishTask)
				{
					return;
				}
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnNeedShowFightPhotoFocus, true);
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "PhotoBattleStartFocus");
				this.HighLightExploreSkill(true);
				this.LastStateIsCanFinishTask = true;
				this.IsForceUpdate = false;
				if (this.TipType.GetValueOrDefault() == ETimeScaledPhotographTip.AutoViewFinder)
				{
					ModelBase<PhotographModel>.Instance.SetPhotographTimeDilation(ModelBase<BattleUiModel>.Instance.TimeDilationSkillRatio);
					this.IsInAutoViewFinderState = true;
					this.UpdateAllEffectState();
					return;
				}
			}
			else
			{
				if (!this.IsForceUpdate && !this.LastStateIsCanFinishTask)
				{
					return;
				}
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnNeedShowFightPhotoFocus, false);
				this.HighLightExploreSkill(false);
				this.LastStateIsCanFinishTask = false;
				this.IsForceUpdate = false;
				if (this.TipType.GetValueOrDefault() == ETimeScaledPhotographTip.AutoViewFinder)
				{
					ModelBase<PhotographModel>.Instance.SetPhotographTimeDilation(1f);
					Singleton<AudioSystem>.Instance.SetState("game_sys_fightphoto", "none", true);
					this.IsInAutoViewFinderState = false;
					this.UpdateAllEffectState();
				}
			}
		}

		// Token: 0x0603BFDA RID: 245722 RVA: 0x00F369B4 File Offset: 0x00F34BB4
		private void HighLightExploreSkill(bool isHighLight)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterExploreComponent characterExploreComponent;
			if (baseCharacter == null)
			{
				characterExploreComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				if (characterActorComponent == null)
				{
					characterExploreComponent = null;
				}
				else
				{
					Entity entity = characterActorComponent.Entity;
					characterExploreComponent = ((entity != null) ? entity.GetComponent<CharacterExploreComponent>() : null);
				}
			}
			CharacterExploreComponent characterExploreComponent2 = characterExploreComponent;
			if (characterExploreComponent2 == null)
			{
				return;
			}
			if (isHighLight)
			{
				characterExploreComponent2.ShowHighlightExploreSkill(1029, -1f, new bool?(false), "系统.活动.拍照活动.时停技能高亮", null, null, null);
				return;
			}
			characterExploreComponent2.HideHighlightExploreSkill();
		}

		// Token: 0x0603BFDB RID: 245723 RVA: 0x00F36A30 File Offset: 0x00F34C30
		public int? GetTargetRoleId()
		{
			IPhotographCondition photographCondition = this.PhotographCondition;
			if (photographCondition != null)
			{
				IPhotographTargetPlayer photographTargetPlayer = photographCondition.Target as IPhotographTargetPlayer;
				if (photographTargetPlayer != null)
				{
					return photographTargetPlayer.RoleId;
				}
			}
			return null;
		}

		// Token: 0x0603BFDC RID: 245724 RVA: 0x00F36A66 File Offset: 0x00F34C66
		private void UpdateAllEffectState()
		{
			this.UpdatePostEffect();
			this.UpdateScreenEffect();
		}

		// Token: 0x0603BFDD RID: 245725 RVA: 0x00F36A74 File Offset: 0x00F34C74
		private void UpdatePostEffect()
		{
			if (!Singleton<EffectSystem>.Instance.IsValid(this.PostEffectHandle))
			{
				return;
			}
			if (this.IsInAutoViewFinderState && !this.IsPhotographViewOpen)
			{
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				int postEffectHandle = this.PostEffectHandle;
				string reason = "[TackPictureQuest.ReplayEffect]";
				FTransformDouble? ftransformDouble = null;
				instance.ReplayEffect(postEffectHandle, reason, ftransformDouble);
				Singleton<EffectSystem>.Instance.SetEffectHidden(this.PostEffectHandle, false, null, false);
				return;
			}
			Singleton<EffectSystem>.Instance.SetEffectHidden(this.PostEffectHandle, true, null, false);
		}

		// Token: 0x0603BFDE RID: 245726 RVA: 0x00F36AEC File Offset: 0x00F34CEC
		private void UpdateScreenEffect()
		{
			if (this.ScreenEffectHandle != 0)
			{
				ModelBase<ScreenEffectModel>.Instance.EndScreenEffect(this.ScreenEffectHandle);
			}
			if (!this.IsInAutoViewFinderState || this.IsPhotographViewOpen)
			{
				return;
			}
			this.ScreenEffectHandle = ModelBase<ScreenEffectModel>.Instance.PlayScreenEffect("/Game/Aki/Effect/DataAsset/ScreenDA/SD_Fight/Bigworld/DA_Fx_Screen_ForTimeStop_White.DA_Fx_Screen_ForTimeStop_White", null, null);
		}

		// Token: 0x0603BFDF RID: 245727 RVA: 0x00F36B39 File Offset: 0x00F34D39
		private void OnFightPhotoTaskFinish()
		{
			this.SubmitNode(null);
		}

		// Token: 0x0603BFE0 RID: 245728 RVA: 0x00F36B42 File Offset: 0x00F34D42
		private void OnEffectLoaded(ELoadEffectResult result, int handle)
		{
			if (result != ELoadEffectResult.Success)
			{
				return;
			}
			this.UpdatePostEffect();
		}

		// Token: 0x0603BFE1 RID: 245729 RVA: 0x00F36B4F File Offset: 0x00F34D4F
		private void OnOpenView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.FightPhotographView)
			{
				return;
			}
			this.IsPhotographViewOpen = true;
			this.UpdateAllEffectState();
		}

		// Token: 0x0603BFE2 RID: 245730 RVA: 0x00F36B6C File Offset: 0x00F34D6C
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.FightPhotographView)
			{
				return;
			}
			this.IsPhotographViewOpen = false;
			this.UpdateAllEffectState();
		}

		// Token: 0x0603BFE3 RID: 245731 RVA: 0x00F36B8C File Offset: 0x00F34D8C
		protected override void OnEnd(bool bFinished)
		{
			if (this.IsInAutoViewFinderState)
			{
				ModelBase<PhotographModel>.Instance.SetPhotographTimeDilation(1f);
			}
			this.HighLightExploreSkill(false);
			this.IsInAutoViewFinderState = false;
			if (this.PostEffectHandle != 0)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.PostEffectHandle, "[TackPictureQuest]OnEnd", true, null);
				this.PostEffectHandle = 0;
			}
			if (this.ScreenEffectHandle != 0)
			{
				ModelBase<ScreenEffectModel>.Instance.EndScreenEffect(this.ScreenEffectHandle);
				this.ScreenEffectHandle = 0;
			}
			base.OnEnd(bFinished);
		}

		// Token: 0x04021B40 RID: 138048
		private const string POST_EFFECT_PATH = "/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_Post_ForTimeStop_White.DA_Fx_Group_Post_ForTimeStop_White";

		// Token: 0x04021B41 RID: 138049
		private const string SCREEN_EFFECT_PATH = "/Game/Aki/Effect/DataAsset/ScreenDA/SD_Fight/Bigworld/DA_Fx_Screen_ForTimeStop_White.DA_Fx_Screen_ForTimeStop_White";

		// Token: 0x04021B42 RID: 138050
		public ETimeScaledPhotographTip? TipType;

		// Token: 0x04021B43 RID: 138051
		[Nullable(2)]
		public IPhotographCondition PhotographCondition;

		// Token: 0x04021B44 RID: 138052
		[Nullable(2)]
		public ICameraCondition CameraCondition;

		// Token: 0x04021B45 RID: 138053
		private bool LastStateIsCanFinishTask;

		// Token: 0x04021B46 RID: 138054
		private bool IsInAutoViewFinderState;

		// Token: 0x04021B47 RID: 138055
		private bool IsForceUpdate;

		// Token: 0x04021B48 RID: 138056
		private int PostEffectHandle;

		// Token: 0x04021B49 RID: 138057
		private int ScreenEffectHandle;

		// Token: 0x04021B4A RID: 138058
		private bool IsPhotographViewOpen;
	}
}
