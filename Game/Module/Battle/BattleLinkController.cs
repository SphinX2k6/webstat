using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Sequence.Common_Seq.Video.SplitScreen;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F2C RID: 24364
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class BattleLinkController : ControllerBase<BattleLinkController>
	{
		// Token: 0x0603D306 RID: 250630 RVA: 0x00F8D2BC File Offset: 0x00F8B4BC
		protected override bool OnInit()
		{
			Net instance = Singleton<Net>.Instance;
			ENotifyMessageId id = ENotifyMessageId.LinkingStateNotify;
			Action<LinkingStateNotify, Net.CallbackStatus> callback;
			if ((callback = BattleLinkController.<>O.<0>__HandleLinkingStateNotify) == null)
			{
				callback = (BattleLinkController.<>O.<0>__HandleLinkingStateNotify = new Action<LinkingStateNotify, Net.CallbackStatus>(BattleLinkController.HandleLinkingStateNotify));
			}
			instance.Register<LinkingStateNotify>(id, callback);
			Net instance2 = Singleton<Net>.Instance;
			ENotifyMessageId id2 = ENotifyMessageId.LinkExitNotify;
			Action<LinkExitNotify, Net.CallbackStatus> callback2;
			if ((callback2 = BattleLinkController.<>O.<1>__HandleLinkExitNotify) == null)
			{
				callback2 = (BattleLinkController.<>O.<1>__HandleLinkExitNotify = new Action<LinkExitNotify, Net.CallbackStatus>(BattleLinkController.HandleLinkExitNotify));
			}
			instance2.Register<LinkExitNotify>(id2, callback2);
			return true;
		}

		// Token: 0x0603D307 RID: 250631 RVA: 0x00F8D320 File Offset: 0x00F8B520
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LinkingStateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LinkExitNotify);
			this.UnbindEvents();
			return true;
		}

		// Token: 0x0603D308 RID: 250632 RVA: 0x00F8D34C File Offset: 0x00F8B54C
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		protected override ValueTuple<string, CustomPromise<bool>>? OnPreload()
		{
			if (!ModelBase<BattleLinkModel>.Instance.CheckInBattleLink())
			{
				return null;
			}
			this.BindEvents();
			this.InitSequenceActor();
			if (ModelBase<BattleLinkModel>.Instance.CheckInDreamLink())
			{
				CustomPromise<bool> item = ModelBase<BattleLinkModel>.Instance.PreloadTeamRoleRes();
				return new ValueTuple<string, CustomPromise<bool>>?(new ValueTuple<string, CustomPromise<bool>>("BattleLinkController", item));
			}
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo != null && gameInfo.InBattle && ModelBase<BattleLinkModel>.Instance.CheckInNewBattleLink())
			{
				CustomPromise<bool> item2 = ModelBase<BattleLinkModel>.Instance.PreloadTeamRoleRes();
				return new ValueTuple<string, CustomPromise<bool>>?(new ValueTuple<string, CustomPromise<bool>>("BattleLinkController", item2));
			}
			return null;
		}

		// Token: 0x0603D309 RID: 250633 RVA: 0x00F8D3EC File Offset: 0x00F8B5EC
		protected override bool OnLeaveLevel()
		{
			this.UnbindEvents();
			this.IsPlayingSplitScreen = false;
			if (this.LevelSeqActor != null)
			{
				ULevelSequencePlayer sequencePlayer = this.LevelSeqActor.SequencePlayer;
				if (sequencePlayer != null && sequencePlayer.IsPlaying())
				{
					ULevelSequencePlayer sequencePlayer2 = this.LevelSeqActor.SequencePlayer;
					if (sequencePlayer2 != null)
					{
						sequencePlayer2.Stop();
					}
				}
				Singleton<ActorSystem>.Instance.Put("BattleLinkController.OnLeaveLevel", this.LevelSeqActor, null);
			}
			this.LevelSeqActor = null;
			if (this.Timer != null)
			{
				TimerSystem.Instance.Remove(this.Timer);
				this.Timer = null;
				this.OnTimerEnd();
			}
			if (this.VisibleId != null)
			{
				ControllerBase<BattleUiControl>.Instance.SetBattleViewVisible(this.VisibleId.Value);
			}
			this.VisibleId = null;
			if (this.IsInLinkExplosion)
			{
				Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("BattleLinkController.LinkExplosionStart");
				ControllerBase<GameModeController>.Instance.SetTimeDilation(1f, ETimeDilationType.Default);
			}
			this.IsInLinkExplosion = false;
			this.EntityCache.Clear();
			this.NeedEntityCache = true;
			this.RecoverRotation = null;
			this.CurrentLinkBurstBuffs = null;
			this.RoleIdQueue = null;
			return true;
		}

		// Token: 0x0603D30A RID: 250634 RVA: 0x00F8D50C File Offset: 0x00F8B70C
		private void BindEvents()
		{
			if (this.HasBindEvents)
			{
				return;
			}
			this.HasBindEvents = true;
			if (ModelBase<BattleLinkModel>.Instance.CheckInDreamLink())
			{
				Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
				Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
			}
			if (ModelBase<BattleLinkModel>.Instance.CheckInNewBattleLink())
			{
				Singleton<EventSystem>.Instance.Add(EEventName.CharOnRoleDead, new Action<int>(this.OnCharDead));
				Singleton<EventSystem>.Instance.Add<Entity>(EEventName.OnRevive, new Action<Entity>(this.OnCharRevive));
			}
			if (ModelBase<BattleLinkModel>.Instance.CheckInSpecialBattleLink())
			{
				int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
				WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(playerId);
				if (playerEntity != null)
				{
					LinkParam? linkParam = ConfigBase<BattleLinkConfig>.Instance.GetLinkParam(1);
					if (linkParam != null)
					{
						LinkParam valueOrDefault = linkParam.GetValueOrDefault();
						this.LinkBuffRoleIdMap = new Dictionary<long, int>();
						foreach (KeyValuePair<int, int> keyValuePair in valueOrDefault.LinkBuffRoleMap())
						{
							AbilityEvent.Instance.Add(playerEntity, EAbilityEventName.OnBuffAdd, (long)keyValuePair.Key, new Action<long, int>(this.OnBuffAdd));
							this.LinkBuffRoleIdMap[(long)keyValuePair.Key] = keyValuePair.Value;
						}
					}
					this.AbilityEventEntity = playerEntity;
				}
			}
		}

		// Token: 0x0603D30B RID: 250635 RVA: 0x00F8D688 File Offset: 0x00F8B888
		private void UnbindEvents()
		{
			if (!this.HasBindEvents)
			{
				return;
			}
			this.HasBindEvents = false;
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
			}
			if (Singleton<EventSystem>.Instance.Has<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill)))
			{
				Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.CharOnRoleDead, new Action<int>(this.OnCharDead)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.CharOnRoleDead, new Action<int>(this.OnCharDead));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnRevive, new Action<Entity>(this.OnCharRevive)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnRevive, new Action<Entity>(this.OnCharRevive));
			}
			if (ModelBase<BattleLinkModel>.Instance.CheckInSpecialBattleLink() && this.AbilityEventEntity != null && this.LinkBuffRoleIdMap != null)
			{
				foreach (long key in this.LinkBuffRoleIdMap.Keys)
				{
					AbilityEvent.Instance.Remove(this.AbilityEventEntity, EAbilityEventName.OnBuffAdd, key, new Action<long, int>(this.OnBuffAdd));
				}
			}
			this.AbilityEventEntity = null;
			this.LinkBuffRoleIdMap = null;
		}

		// Token: 0x0603D30C RID: 250636 RVA: 0x00F8D810 File Offset: 0x00F8BA10
		private void InitSequenceActor()
		{
			if (this.LevelSeqActor == null)
			{
				this.LevelSeqActor = (Singleton<ActorSystem>.Instance.Get(ALevelSequenceActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, false) as ALevelSequenceActor);
			}
		}

		// Token: 0x0603D30D RID: 250637 RVA: 0x00F8D840 File Offset: 0x00F8BA40
		private void OnCharUseSkill(int entityId, int skillId, bool isAutonomousProxy)
		{
			if (this.NeedEntityCache && !this.EntityCache.ContainsKey(entityId))
			{
				this.AddEntityCache(entityId);
			}
			EntityHandle entityHandle;
			if (!this.EntityCache.TryGetValue(entityId, out entityHandle))
			{
				return;
			}
			WorldEntity entity = entityHandle.Entity;
			object obj;
			if (entity == null)
			{
				obj = null;
			}
			else
			{
				CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
				obj = ((component != null) ? component.GetSkillInfo(skillId) : null);
			}
			object obj2 = obj;
			if (((obj2 != null) ? new TEnumAsByte<ESkillGenre>?(obj2.SkillGenre) : null) == ESkillGenre.大招3 && ModelBase<BattleLinkModel>.Instance.CanUseLinkSkill(new int?(entityId)))
			{
				ModelBase<BattleLinkModel>.Instance.AddLinkEntityId(entityId);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnBattleLinkStop);
				Singleton<EventSystem>.Instance.Emit<ELinkStatus>(EEventName.OnBattleLinkStatusChanged, ELinkStatus.Link);
			}
		}

		// Token: 0x0603D30E RID: 250638 RVA: 0x00F8D914 File Offset: 0x00F8BB14
		private void OnUpdateSceneTeam()
		{
			if (ModelBase<BattleLinkModel>.Instance.CheckInNewBattleLink())
			{
				this.TeamEntityIdList.Clear();
				foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(false))
				{
					EntityHandle entityHandle = sceneTeamItem.EntityHandle;
					int? num;
					if (entityHandle == null)
					{
						num = null;
					}
					else
					{
						WorldEntity entity = entityHandle.Entity;
						num = ((entity != null) ? new int?(entity.Id) : null);
					}
					int? num2 = num;
					int valueOrDefault = num2.GetValueOrDefault();
					if (valueOrDefault != 0)
					{
						this.TeamEntityIdList.Add(valueOrDefault);
					}
				}
				Singleton<EventSystem>.Instance.Emit<ENewLinkStatus>(EEventName.OnNewLinkStatusChanged, ModelBase<BattleLinkModel>.Instance.GetNewLinkStatus());
				return;
			}
			List<int> teamRoleConfigIdList = ModelBase<SceneTeamModel>.Instance.GetTeamRoleConfigIdList(false, true);
			ModelBase<BattleLinkModel>.Instance.SetRoleIdList(teamRoleConfigIdList);
			ModelBase<BattleLinkModel>.Instance.ResetMainBp();
			this.EntityCache.Clear();
			this.NeedEntityCache = true;
		}

		// Token: 0x0603D30F RID: 250639 RVA: 0x00F8DA18 File Offset: 0x00F8BC18
		private void OnCharDead(int entityId)
		{
			this.OnCharDeadOrAliveChanged(entityId, true);
		}

		// Token: 0x0603D310 RID: 250640 RVA: 0x00F8DA22 File Offset: 0x00F8BC22
		[NullableContext(1)]
		private void OnCharRevive(Entity entity)
		{
			this.OnCharDeadOrAliveChanged(entity.Id, false);
		}

		// Token: 0x0603D311 RID: 250641 RVA: 0x00F8DA31 File Offset: 0x00F8BC31
		private void OnCharDeadOrAliveChanged(int entityId, bool isDead)
		{
			if (!this.TeamEntityIdList.Contains(entityId))
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<ENewLinkStatus>(EEventName.OnNewLinkStatusChanged, ModelBase<BattleLinkModel>.Instance.GetNewLinkStatus());
		}

		// Token: 0x0603D312 RID: 250642 RVA: 0x00F8DA5C File Offset: 0x00F8BC5C
		private void OnBuffAdd(long buffId, int handle)
		{
			Dictionary<long, int> linkBuffRoleIdMap = this.LinkBuffRoleIdMap;
			int num = (linkBuffRoleIdMap != null) ? linkBuffRoleIdMap.GetValueOrDefault(buffId) : 0;
			if (num != 0)
			{
				if (this.RoleIdQueue == null)
				{
					this.RoleIdQueue = new List<int>();
				}
				if (!this.RoleIdQueue.Contains(num))
				{
					int item = num;
					LinkParam? linkParam = ConfigBase<BattleLinkConfig>.Instance.GetLinkParam(1);
					if (linkParam != null)
					{
						LinkParam valueOrDefault = linkParam.GetValueOrDefault();
						if (valueOrDefault.ChangeGenderMap().ContainsKey(num))
						{
							MainRoleConfig? mainRoleById = ConfigBase<RoleConfig>.Instance.GetMainRoleById(num);
							if (mainRoleById != null && mainRoleById.GetValueOrDefault().Gender != (int)ModelBase<PlayerInfoModel>.Instance.GetPlayerGender())
							{
								int valueOrDefault2 = valueOrDefault.ChangeGenderMap().GetValueOrDefault(num, 0);
								if (valueOrDefault2 != 0)
								{
									item = valueOrDefault2;
								}
							}
						}
					}
					if (!this.RoleIdQueue.Contains(item))
					{
						this.RoleIdQueue.Insert(0, item);
					}
					if (this.RoleIdQueue.Count > 3)
					{
						this.RoleIdQueue.RemoveRange(3, this.RoleIdQueue.Count - 3);
					}
				}
			}
		}

		// Token: 0x0603D313 RID: 250643 RVA: 0x00F8DB60 File Offset: 0x00F8BD60
		private void AddEntityCache(int entityId)
		{
			if (this.EntityCache.ContainsKey(entityId))
			{
				return;
			}
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			List<SceneTeamRole> roleList = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(playerId).GetCurrentGroup().GetRoleList();
			int num = 0;
			foreach (SceneTeamRole sceneTeamRole in roleList)
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(sceneTeamRole.CreatureDataId);
				if (entity.Entity.Id == entityId)
				{
					this.EntityCache[entity.Entity.Id] = entity;
				}
				if (this.EntityCache.ContainsKey(entity.Entity.Id))
				{
					num++;
				}
			}
			if (num == roleList.Count)
			{
				this.NeedEntityCache = false;
			}
		}

		// Token: 0x0603D314 RID: 250644 RVA: 0x00F8DC44 File Offset: 0x00F8BE44
		public void UseLinkSkill(Entity entity)
		{
			if (entity == null)
			{
				return;
			}
			if (this.MessageId == null)
			{
				return;
			}
			if (ModelBase<BattleLinkModel>.Instance.HasLinkEntityId(entity.Id))
			{
				return;
			}
			CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
			long value = this.MessageId.Value;
			long? long54Config = ConfigCommonParamById.GetLong54Config("LinkSkillNotifyBuff");
			if (long54Config != null)
			{
				component.AddBuff(long54Config.Value, new AddBuffParam
				{
					InstigatorId = component.CreatureDataId,
					Reason = "触发Link大招",
					PreMessageId = new long?(value)
				});
			}
		}

		// Token: 0x0603D315 RID: 250645 RVA: 0x00F8DCD4 File Offset: 0x00F8BED4
		public void StartLink(double startTime = 0.0)
		{
			double num = (startTime == 0.0) ? Singleton<TimeUtil>.Instance.GetServerTimeStamp() : startTime;
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BattleLinkView))
			{
				Singleton<EventSystem>.Instance.Emit<double>(EEventName.OnBattleLinkRestart, num);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BattleLinkView, num, null);
		}

		// Token: 0x0603D316 RID: 250646 RVA: 0x00F8DD34 File Offset: 0x00F8BF34
		public void StopLink()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBattleLinkStop);
		}

		// Token: 0x0603D317 RID: 250647 RVA: 0x00F8DD46 File Offset: 0x00F8BF46
		public void StartLinkExplosion()
		{
			this.StopLink();
			this.TryPlaySplitScreen();
		}

		// Token: 0x0603D318 RID: 250648 RVA: 0x00F8DD54 File Offset: 0x00F8BF54
		public void TryPlaySplitScreen()
		{
			if (this.IsPlayingSplitScreen)
			{
				return;
			}
			if (!ModelBase<BattleLinkModel>.Instance.CheckSplitScreenRes() || this.LevelSeqActor == null)
			{
				return;
			}
			this.IsPlayingSplitScreen = true;
			ModelBase<BattleLinkModel>.Instance.PlayRoleAnim(true);
			if (ModelBase<BattleLinkModel>.Instance.GetSplitScreenMainBp().IsT2)
			{
				this.Timer = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.Timer = null;
					this.PlaySplitScreenSeq();
				}, 100f, null, null, true, 1f);
			}
			else
			{
				this.PlaySplitScreenEffect();
			}
			this.LinkExplosionStart();
		}

		// Token: 0x0603D319 RID: 250649 RVA: 0x00F8DDDC File Offset: 0x00F8BFDC
		private void PlaySplitScreenEffect()
		{
			WorldEntity entity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity;
			if (entity != null)
			{
				CharacterGameplayCueComponent component = entity.GetComponent<CharacterGameplayCueComponent>();
				if (component != null)
				{
					this.ScreenEffectCueHandle = component.AddCue(10010093L, null);
				}
			}
			float interval = 0.3f * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.Timer = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.Timer = null;
				this.OnTimerEnd();
				this.PlaySplitScreenSeq();
			}, interval, null, null, true, 1f);
		}

		// Token: 0x0603D31A RID: 250650 RVA: 0x00F8DE58 File Offset: 0x00F8C058
		private void OnTimerEnd()
		{
			WorldEntity entity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity;
			if (entity != null)
			{
				CharacterGameplayCueComponent component = entity.GetComponent<CharacterGameplayCueComponent>();
				if (component != null)
				{
					component.RemoveCueByHandle((long)this.ScreenEffectCueHandle);
				}
			}
		}

		// Token: 0x0603D31B RID: 250651 RVA: 0x00F8DE90 File Offset: 0x00F8C090
		private void PlaySplitScreenSeq()
		{
			BattleLinkModel instance = ModelBase<BattleLinkModel>.Instance;
			OneOf<BP_SplitScreen_C, BP_SplitScreen_New_C> splitScreenMainBp = instance.GetSplitScreenMainBp();
			ULevelSequence splitScreenSeq = instance.GetSplitScreenSeq();
			if (!splitScreenMainBp.HasValue || splitScreenSeq == null || this.LevelSeqActor == null)
			{
				this.LinkExplosionEnd();
				return;
			}
			Singleton<AudioSystem>.Instance.SetState("sp_rogue_link_vo_reuse_burst", "vo_reuse", true);
			instance.InitBeforeStart();
			instance.PlayRoleAnim(false);
			Singleton<AudioSystem>.Instance.SetState("game_rogue_link_state", "in_link", true);
			instance.PlayRoleLinkAudio();
			global::Rotator cameraRotator = ControllerBase<CameraController>.Instance.MainModel.CameraRotator;
			this.RecoverRotation = new FRotator?(new FRotator(cameraRotator.Pitch, cameraRotator.Yaw, cameraRotator.Roll));
			ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.PlayerComponent.SetBlendTime(0f, 0f);
			ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.PlayerComponent.StopSequence();
			BP_CineCamera_C cineCamera = ModelBase<CameraModel>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera;
			this.LevelSeqActor.SetSequence(splitScreenSeq);
			this.BindingActors.Add(cineCamera);
			this.LevelSeqActor.SetBindingByTag(BattleLinkController.SeqCameraTag, this.BindingActors, false, false);
			this.BindingActors.Empty(true);
			this.BindingActors.Add((AActor)splitScreenMainBp.GetValue());
			this.LevelSeqActor.SetBindingByTag(BattleLinkController.CharacterTag, this.BindingActors, false, false);
			this.BindingActors.Empty(true);
			ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Sequence, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, false, "MainCamera", null);
			if (splitScreenMainBp.IsT1)
			{
				BP_SplitScreen_C asT = splitScreenMainBp.AsT1;
				asT.SetActorHiddenInGame(false);
				asT.Start();
			}
			else
			{
				BP_SplitScreen_New_C asT2 = splitScreenMainBp.AsT2;
				asT2.SetActorHiddenInGame(false);
				asT2.Start();
			}
			this.LevelSeqActor.SequencePlayer.OnFinished.Clear();
			this.LevelSeqActor.SequencePlayer.OnFinished.Add(new Action(this.OnSequenceFinished));
			this.LevelSeqActor.SequencePlayer.Play();
		}

		// Token: 0x0603D31C RID: 250652 RVA: 0x00F8E0A0 File Offset: 0x00F8C2A0
		private void OnSequenceFinished()
		{
			this.IsPlayingSplitScreen = false;
			Singleton<AudioSystem>.Instance.SetState("sp_rogue_link_vo_reuse_burst", "none", true);
			OneOf<BP_SplitScreen_C, BP_SplitScreen_New_C> splitScreenMainBp = ModelBase<BattleLinkModel>.Instance.GetSplitScreenMainBp();
			if (splitScreenMainBp.HasValue)
			{
				if (splitScreenMainBp.IsT1)
				{
					BP_SplitScreen_C asT = splitScreenMainBp.AsT1;
					asT.End();
					asT.SetActorHiddenInGame(true);
				}
				else
				{
					BP_SplitScreen_New_C asT2 = splitScreenMainBp.AsT2;
					asT2.End();
					asT2.SetActorHiddenInGame(true);
				}
			}
			BP_CineCamera_C cineCamera = ModelBase<CameraModel>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera;
			if (cineCamera.GetAttachParentActor() != null)
			{
				cineCamera.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
			}
			ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Sequence, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
			if (this.RecoverRotation != null)
			{
				ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.SetRotation(this.RecoverRotation.Value);
				this.RecoverRotation = null;
			}
			this.LinkExplosionEnd();
		}

		// Token: 0x0603D31D RID: 250653 RVA: 0x00F8E19A File Offset: 0x00F8C39A
		public void LinkExplosionStart()
		{
			Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("BattleLinkController.LinkExplosionStart");
			this.IsInLinkExplosion = true;
			this.VisibleId = new int?(ControllerBase<BattleUiControl>.Instance.SetBattleViewInvisible());
			ControllerBase<GameModeController>.Instance.SetTimeDilation(0f, ETimeDilationType.Default);
		}

		// Token: 0x0603D31E RID: 250654 RVA: 0x00F8E1D8 File Offset: 0x00F8C3D8
		public void LinkExplosionEnd()
		{
			Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("BattleLinkController.LinkExplosionStart");
			this.IsInLinkExplosion = false;
			if (this.VisibleId != null)
			{
				ControllerBase<BattleUiControl>.Instance.SetBattleViewVisible(this.VisibleId.Value);
			}
			this.VisibleId = null;
			ControllerBase<GameModeController>.Instance.SetTimeDilation(1f, ETimeDilationType.Default);
			ModelBase<BattleLinkModel>.Instance.ResetLinkSkillStatus();
			if (this.MessageId != null)
			{
				long value = this.MessageId.Value;
				WorldEntity entity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity;
				CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
				IReadOnlyList<long> readOnlyList = null;
				IReadOnlyList<long> readOnlyList2 = null;
				if (ModelBase<BattleLinkModel>.Instance.CheckInDreamLink())
				{
					readOnlyList = ConfigCommonParamById.GetLong54ArrayConfig("LinkBrustBuffs");
					readOnlyList2 = ConfigCommonParamById.GetLong54ArrayConfig("LinkBrustBullets");
				}
				else
				{
					LinkData? linkConfig = ModelBase<BattleLinkModel>.Instance.GetLinkConfig();
					if (linkConfig != null)
					{
						LinkData valueOrDefault = linkConfig.GetValueOrDefault();
						readOnlyList = valueOrDefault.BuffIdsInBrust();
						readOnlyList2 = valueOrDefault.BulletIdsInBrust();
					}
				}
				if (readOnlyList != null)
				{
					foreach (long num in readOnlyList)
					{
						component.AddBuff(num, new AddBuffParam
						{
							InstigatorId = component.CreatureDataId,
							Reason = "Link爆发结束增加buff",
							PreMessageId = new long?(value)
						});
						if (this.CurrentLinkBurstBuffs == null)
						{
							this.CurrentLinkBurstBuffs = new List<long>();
						}
						this.CurrentLinkBurstBuffs.Add(num);
					}
				}
				if (readOnlyList2 != null)
				{
					foreach (long num2 in readOnlyList2)
					{
						ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(entity, num2.ToString(), null, new BulletController.BulletCreateParams(), new long?(value), global::EBulletCreateSource.Others);
					}
				}
			}
		}

		// Token: 0x0603D31F RID: 250655 RVA: 0x00F8E3C0 File Offset: 0x00F8C5C0
		private void ClearLinkBurstBuffs()
		{
			if (this.CurrentLinkBurstBuffs == null || this.CurrentLinkBurstBuffs.Count == 0)
			{
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
			CharacterBuffComponent characterBuffComponent = (worldEntity != null) ? worldEntity.GetComponent<CharacterBuffComponent>() : null;
			if (characterBuffComponent != null)
			{
				foreach (long buffId in this.CurrentLinkBurstBuffs)
				{
					characterBuffComponent.RemoveBuff(buffId, -1, "离开Link爆发状态移除buff", null, null, null);
				}
			}
			this.CurrentLinkBurstBuffs.Clear();
		}

		// Token: 0x0603D320 RID: 250656 RVA: 0x00F8E47C File Offset: 0x00F8C67C
		public void SetPlayerUltraSkillEnable(bool enable)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			BaseTagComponent baseTagComponent;
			if (baseCharacter == null)
			{
				baseTagComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				baseTagComponent = ((characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (baseTagComponent2 == null)
			{
				return;
			}
			if (enable)
			{
				baseTagComponent2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止大招"]));
				return;
			}
			baseTagComponent2.AddTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止大招"]));
		}

		// Token: 0x0603D321 RID: 250657 RVA: 0x00F8E4E9 File Offset: 0x00F8C6E9
		public void ShowLinkButton(bool isShow, bool isGm = false)
		{
			BattleView battleView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.BattleView) as BattleView;
			if (battleView != null)
			{
				battleView.ShowLinkButton(isShow);
			}
			if (isGm)
			{
				ModelBase<BattleLinkModel>.Instance.SetNewLinkGmTest(isShow);
				this.UnbindEvents();
				this.BindEvents();
			}
		}

		// Token: 0x0603D322 RID: 250658 RVA: 0x00F8E528 File Offset: 0x00F8C728
		public void RefreshAliveRoleIdList()
		{
			List<int> list = ModelBase<SceneTeamModel>.Instance.GetTeamRoleConfigIdList(false, true);
			List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
			List<int> deadRoleIdList = new List<int>();
			foreach (SceneTeamItem sceneTeamItem in teamItems)
			{
				int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(sceneTeamItem.GetConfigId);
				if (baseRoleId != 0 && sceneTeamItem.IsDead())
				{
					deadRoleIdList.Add(baseRoleId);
				}
			}
			list = (from roleId in list
			where !deadRoleIdList.Contains(roleId)
			select roleId).ToList<int>();
			ModelBase<BattleLinkModel>.Instance.SetRoleIdList(list);
			ModelBase<BattleLinkModel>.Instance.ResetMainBp();
		}

		// Token: 0x0603D323 RID: 250659 RVA: 0x00F8E5F0 File Offset: 0x00F8C7F0
		public bool GetIsInLinkExplosion()
		{
			return this.IsInLinkExplosion;
		}

		// Token: 0x0603D324 RID: 250660 RVA: 0x00F8E5F8 File Offset: 0x00F8C7F8
		public void SetMessageId(long? msgId)
		{
			this.MessageId = msgId;
		}

		// Token: 0x0603D325 RID: 250661 RVA: 0x00F8E601 File Offset: 0x00F8C801
		public long? GetMessageId()
		{
			return this.MessageId;
		}

		// Token: 0x0603D326 RID: 250662 RVA: 0x00F8E609 File Offset: 0x00F8C809
		private static void HandleLinkingStateNotify(LinkingStateNotify notify, Net.CallbackStatus callbackStatus)
		{
			ModelBase<BattleLinkModel>.Instance.HandleLinkingStateNotify(notify);
		}

		// Token: 0x0603D327 RID: 250663 RVA: 0x00F8E616 File Offset: 0x00F8C816
		private static void HandleLinkExitNotify(LinkExitNotify notify, Net.CallbackStatus callbackStatus)
		{
			ModelBase<BattleLinkModel>.Instance.HandleLinkExitNotify(notify);
			ControllerBase<BattleLinkController>.Instance.OnExitLinkBurst();
		}

		// Token: 0x0603D328 RID: 250664 RVA: 0x00F8E630 File Offset: 0x00F8C830
		[CombatListen(ENotifyMessageId.NewLinkNotify, false, false)]
		public static void OnNewLinkStateNotify(Entity entity, [Nullable(1)] NewLinkNotify notify, CombatCommon combatCommon = null)
		{
			long value = (combatCommon != null) ? combatCommon.MessageId : 0L;
			if (entity == null || !entity.Valid)
			{
				return;
			}
			ControllerBase<BattleLinkController>.Instance.SetMessageId(new long?(value));
			ModelBase<BattleLinkModel>.Instance.HandleNewLinkStateNotify(notify, combatCommon);
			Singleton<EventSystem>.Instance.Emit<ENewLinkStatus>(EEventName.OnNewLinkStatusChanged, (ENewLinkStatus)notify.Current);
			if (notify.Current == ENewLinkStage.Burst)
			{
				Singleton<EventSystem>.Instance.Emit<ELinkStatus>(EEventName.OnBattleLinkStatusChanged, ELinkStatus.Explosion);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<ELinkStatus>(EEventName.OnBattleLinkStatusChanged, ELinkStatus.None);
		}

		// Token: 0x0603D329 RID: 250665 RVA: 0x00F8E6BB File Offset: 0x00F8C8BB
		public void OnExitLinkBurst()
		{
			Singleton<AudioSystem>.Instance.SetState("game_rogue_link_state", "not_in_link", true);
			this.ClearLinkBurstBuffs();
		}

		// Token: 0x0603D32A RID: 250666 RVA: 0x00F8E6D8 File Offset: 0x00F8C8D8
		public void RequestNewLinkBurst()
		{
			if (this.MessageId == null)
			{
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
			if (worldEntity == null)
			{
				return;
			}
			long value = this.MessageId.Value;
			Singleton<CombatNet>.Instance.Send(EPushMessageId.NewLinkBurstPush, worldEntity, NewLinkBurstPush.Create(), new long?(value), null, null);
			if (this.RoleIdQueue != null)
			{
				ModelBase<BattleLinkModel>.Instance.SetRoleIdList(this.RoleIdQueue);
				ModelBase<BattleLinkModel>.Instance.ResetMainBp();
			}
			else
			{
				this.RefreshAliveRoleIdList();
			}
			this.TryPlaySplitScreen();
		}

		// Token: 0x0603D32B RID: 250667 RVA: 0x00F8E778 File Offset: 0x00F8C978
		public UniTask NewLinkBurstTest()
		{
			BattleLinkController.<NewLinkBurstTest>d__57 <NewLinkBurstTest>d__;
			<NewLinkBurstTest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewLinkBurstTest>d__.<>4__this = this;
			<NewLinkBurstTest>d__.<>1__state = -1;
			<NewLinkBurstTest>d__.<>t__builder.Start<BattleLinkController.<NewLinkBurstTest>d__57>(ref <NewLinkBurstTest>d__);
			return <NewLinkBurstTest>d__.<>t__builder.Task;
		}

		// Token: 0x0603D32C RID: 250668 RVA: 0x00F8E7BC File Offset: 0x00F8C9BC
		[NullableContext(0)]
		public UniTask<bool> PreloadRes(int id)
		{
			BattleLinkController.<PreloadRes>d__58 <PreloadRes>d__;
			<PreloadRes>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PreloadRes>d__.id = id;
			<PreloadRes>d__.<>1__state = -1;
			<PreloadRes>d__.<>t__builder.Start<BattleLinkController.<PreloadRes>d__58>(ref <PreloadRes>d__);
			return <PreloadRes>d__.<>t__builder.Task;
		}

		// Token: 0x040224FB RID: 140539
		[StaticVariableRuleIgnore]
		private static readonly FName SeqCameraTag = new FName("SequenceCamera");

		// Token: 0x040224FC RID: 140540
		[StaticVariableRuleIgnore]
		private static readonly FName CharacterTag = new FName("Character");

		// Token: 0x040224FD RID: 140541
		private bool HasBindEvents;

		// Token: 0x040224FE RID: 140542
		private int? VisibleId;

		// Token: 0x040224FF RID: 140543
		private long? MessageId;

		// Token: 0x04022500 RID: 140544
		private bool IsPlayingSplitScreen;

		// Token: 0x04022501 RID: 140545
		private int ScreenEffectCueHandle;

		// Token: 0x04022502 RID: 140546
		private ALevelSequenceActor LevelSeqActor;

		// Token: 0x04022503 RID: 140547
		[Nullable(1)]
		private readonly TArray<AActor> BindingActors = new TArray<AActor>();

		// Token: 0x04022504 RID: 140548
		private FRotator? RecoverRotation;

		// Token: 0x04022505 RID: 140549
		private TimerHandle Timer;

		// Token: 0x04022506 RID: 140550
		[Nullable(1)]
		private readonly Dictionary<int, EntityHandle> EntityCache = new Dictionary<int, EntityHandle>();

		// Token: 0x04022507 RID: 140551
		private bool NeedEntityCache = true;

		// Token: 0x04022508 RID: 140552
		private bool IsInLinkExplosion;

		// Token: 0x04022509 RID: 140553
		[Nullable(1)]
		private readonly List<int> TeamEntityIdList = new List<int>();

		// Token: 0x0402250A RID: 140554
		private List<long> CurrentLinkBurstBuffs;

		// Token: 0x0402250B RID: 140555
		private WorldEntity AbilityEventEntity;

		// Token: 0x0402250C RID: 140556
		private Dictionary<long, int> LinkBuffRoleIdMap;

		// Token: 0x0402250D RID: 140557
		private List<int> RoleIdQueue;

		// Token: 0x0402250E RID: 140558
		private bool IsLinkTesting;

		// Token: 0x0200BF3E RID: 48958
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403ADDE RID: 241118
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<LinkingStateNotify, Net.CallbackStatus> <0>__HandleLinkingStateNotify;

			// Token: 0x0403ADDF RID: 241119
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<LinkExitNotify, Net.CallbackStatus> <1>__HandleLinkExitNotify;
		}
	}
}
