using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BC1 RID: 27585
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelEventPlayDynamicSettlement : LevelEventBase
	{
		// Token: 0x06044043 RID: 278595 RVA: 0x011A2AE4 File Offset: 0x011A0CE4
		public LevelEventPlayDynamicSettlement(int id) : base(id)
		{
		}

		// Token: 0x06044044 RID: 278596 RVA: 0x011A2AFF File Offset: 0x011A0CFF
		[NullableContext(1)]
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06044045 RID: 278597 RVA: 0x011A2B0C File Offset: 0x011A0D0C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			PlayDynamicSettlement playDynamicSettlement = inParams as PlayDynamicSettlement;
			if (playDynamicSettlement == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CFT, "战斗结算镜头效果参数不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			IDynamicSettlementConfig dynamicSettlementConfig = playDynamicSettlement.DynamicSettlementConfig;
			this.SettlementType = dynamicSettlementConfig.Type;
			int num = 0;
			IBattleSettlement battleSettlement = dynamicSettlementConfig as IBattleSettlement;
			if (battleSettlement != null)
			{
				int? gamePlayCue = battleSettlement.GamePlayCue;
				if (gamePlayCue != null)
				{
					num = gamePlayCue.Value;
				}
			}
			this.ScreenEffectCueId = ((num > 0) ? num : 10010092);
			this.BgmType = ((battleSettlement != null) ? battleSettlement.BgmType : null);
			Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
			Singleton<EventSystem>.Instance.Add(EEventName.DisActiveBattleView, new Action(this.OnDisActiveBattleView));
			if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView))
			{
				this.IsWaitBattleView = true;
				return;
			}
			this.PlayBattleSettlement();
		}

		// Token: 0x06044046 RID: 278598 RVA: 0x011A2C08 File Offset: 0x011A0E08
		private void OnActiveBattleView()
		{
			if (!this.IsWaitBattleView)
			{
				return;
			}
			this.IsWaitBattleView = false;
			if (this.Timer != null)
			{
				TimerSystem.Instance.Resume(this.Timer);
				ModelBase<BattleUiModel>.Instance.IsInBattleSettlement = true;
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleSettlementStateChanged, true);
				return;
			}
			this.PlayBattleSettlement();
		}

		// Token: 0x06044047 RID: 278599 RVA: 0x011A2C6C File Offset: 0x011A0E6C
		private void OnDisActiveBattleView()
		{
			if (this.IsWaitBattleView)
			{
				return;
			}
			this.IsWaitBattleView = true;
			if (this.Timer != null)
			{
				TimerSystem.Instance.Pause(this.Timer, null);
				ModelBase<BattleUiModel>.Instance.IsInBattleSettlement = false;
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleSettlementStateChanged, false);
			}
		}

		// Token: 0x06044048 RID: 278600 RVA: 0x011A2CCC File Offset: 0x011A0ECC
		private void PlayBattleSettlement()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.LevelEvent, new EBattleUiChild[]
			{
				EBattleUiChild.DamageView
			}, 0);
			ModelBase<BattleUiModel>.Instance.IsInBattleSettlement = true;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.PlaySettlementCamera(this.SettlementType);
			UCurveFloat loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/Data/Fight/Curves/C_FightFinishSlowMo.C_FightFinishSlowMo");
			this.HandleTimeScale(loadedAsset);
			ControllerBase<DamageUiController>.Instance.SetDamageTimeScaleEnable(true);
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Entity entity = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
			if (entity != null)
			{
				if (this.ScreenEffectCueId != 0)
				{
					this.CueComp = entity.GetComponent<CharacterGameplayCueComponent>();
					if (this.CueComp != null)
					{
						this.ScreenEffectCueHandleId = this.CueComp.AddCue((long)this.ScreenEffectCueId, null);
					}
				}
				CharacterInputComponent component = entity.GetComponent<CharacterInputComponent>();
				if (component != null)
				{
					component.ClearInputCache(0, EInputState.None);
				}
			}
			EBattleSettlementBgmType? bgmType = this.BgmType;
			EBattleSettlementBgmType ebattleSettlementBgmType = EBattleSettlementBgmType.BattleSoundWave;
			if (bgmType.GetValueOrDefault() == ebattleSettlementBgmType & bgmType != null)
			{
				Singleton<AudioSystem>.Instance.SetState("plot_phantom_arena_battle_state", "ending", true);
			}
			else
			{
				string stringConfig = ConfigCommonParamById.GetStringConfig("BattleSettlementAudioEvent");
				if (stringConfig != null)
				{
					Singleton<AudioSystem>.Instance.PostEvent(stringConfig);
				}
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleSettlementStateChanged, true);
			EDynamicSettlementType settlementType = this.SettlementType;
			if (settlementType != EDynamicSettlementType.Battle)
			{
				if (settlementType != EDynamicSettlementType.SoaringChallenge)
				{
					return;
				}
				if (this.IsAsync)
				{
					Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
					base.FinishExecute(true, false, true);
					return;
				}
				this.OpenTimer();
			}
			else
			{
				this.OpenTimer();
				if (this.IsAsync)
				{
					base.FinishExecute(true, false, true);
					return;
				}
			}
		}

		// Token: 0x06044049 RID: 278601 RVA: 0x011A2E70 File Offset: 0x011A1070
		private void HandleTimeScale(UCurveFloat curve)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (((baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null) != null)
			{
				TsBaseCharacter baseCharacter2 = Global.BaseCharacter;
				global::Vector vector;
				if (baseCharacter2 == null)
				{
					vector = null;
				}
				else
				{
					CharacterActorComponent characterActorComponent = baseCharacter2.CharacterActorComponent;
					vector = ((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
				}
				global::Vector vector2 = vector;
				if (vector2 != null)
				{
					int value = ConfigCommonParamById.GetIntConfig("BattleSettlementTimeScaleRadius").Value;
					int value2 = ConfigCommonParamById.GetIntConfig("BattleSettlementTimeScalePriority").Value;
					float value3 = ConfigCommonParamById.GetFloatConfig("BattleSettlementTimeDilation").Value;
					float value4 = ConfigCommonParamById.GetFloatConfig("BattleSettlementTimeScaleDuration").Value;
					IReadOnlyList<EntityHandle> allEntities = ModelBase<CreatureModel>.Instance.GetAllEntities();
					if (allEntities != null)
					{
						foreach (EntityHandle entityHandle in allEntities)
						{
							this.HandleEntityTimeScale(entityHandle, vector2, value, value2, value3, curve, value4);
						}
					}
					foreach (EntityHandle entityHandle2 in ModelBase<CreatureModel>.Instance.DelayRemoveContainer.GetAllEntities())
					{
						this.HandleEntityTimeScale(entityHandle2, vector2, value, value2, value3, curve, value4);
					}
					ModelBase<BulletModel>.Instance.SetAllBulletTimeScale(vector2, (float)value, value2, value3, curve, value4, true);
				}
			}
		}

		// Token: 0x0604404A RID: 278602 RVA: 0x011A2FCC File Offset: 0x011A11CC
		private void HandleEntityTimeScale(EntityHandle entityHandle, [Nullable(1)] global::Vector centerLocation, int radius, int priority, float timeDilation, UCurveFloat curve, float duration)
		{
			if (entityHandle == null || !entityHandle.Valid)
			{
				return;
			}
			WorldEntity entity = entityHandle.Entity;
			if (entity == null || !entity.IsInit)
			{
				return;
			}
			PawnTimeScaleComponent component = entity.GetComponent<PawnTimeScaleComponent>();
			if (component == null)
			{
				return;
			}
			BaseActorComponent component2 = entity.GetComponent<BaseActorComponent>();
			global::Vector vector = (component2 != null) ? component2.ActorLocationProxy : null;
			if (vector == null)
			{
				return;
			}
			if (Math.Abs(vector.X - centerLocation.X) <= (double)radius && Math.Abs(vector.Y - centerLocation.Y) <= (double)radius && Math.Abs(vector.Z - centerLocation.Z) <= (double)radius)
			{
				int value = component.SetTimeScale(priority, timeDilation, curve, duration, ETimeScaleSourceType.BattleSettlement, false, false);
				this.EntityTimeScaleMap[entityHandle] = value;
			}
		}

		// Token: 0x0604404B RID: 278603 RVA: 0x011A3087 File Offset: 0x011A1287
		private void OnOpenView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.FlySettlementView)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			this.OnTimerEnd();
		}

		// Token: 0x0604404C RID: 278604 RVA: 0x011A30B8 File Offset: 0x011A12B8
		private void OpenTimer()
		{
			float interval = ConfigCommonParamById.GetFloatConfig("BattleSettlementTime").Value * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.Timer = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.Timer = null;
				this.OnTimerEnd();
				base.FinishExecute(true, false, true);
			}, interval, null, null, true, 1f);
		}

		// Token: 0x0604404D RID: 278605 RVA: 0x011A310C File Offset: 0x011A130C
		private void OnTimerEnd()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.LevelEvent, 0);
			ModelBase<BattleUiModel>.Instance.IsInBattleSettlement = false;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
			Singleton<EventSystem>.Instance.Remove(EEventName.DisActiveBattleView, new Action(this.OnDisActiveBattleView));
			this.EntityTimeScaleMap.Clear();
			ControllerBase<DamageUiController>.Instance.SetDamageTimeScaleEnable(false);
			if (this.ScreenEffectCueHandleId != 0)
			{
				BaseGameplayCueComponent cueComp = this.CueComp;
				if (cueComp != null)
				{
					cueComp.RemoveCueByHandle((long)this.ScreenEffectCueHandleId);
				}
				this.ScreenEffectCueHandleId = 0;
				this.CueComp = null;
			}
			this.ScreenEffectCueId = 0;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleSettlementStateChanged, false);
		}

		// Token: 0x0604404E RID: 278606 RVA: 0x011A31D4 File Offset: 0x011A13D4
		public override void Release()
		{
			base.Release();
			if (this.Timer != null)
			{
				TimerSystem.Instance.Remove(this.Timer);
				this.Timer = null;
				this.OnTimerEnd();
			}
			EBattleSettlementBgmType? bgmType = this.BgmType;
			EBattleSettlementBgmType ebattleSettlementBgmType = EBattleSettlementBgmType.BattleSoundWave;
			if (bgmType.GetValueOrDefault() == ebattleSettlementBgmType & bgmType != null)
			{
				Singleton<AudioSystem>.Instance.SetState("plot_phantom_arena_battle_state", "none", true);
			}
		}

		// Token: 0x04026044 RID: 155716
		private TimerHandle Timer;

		// Token: 0x04026045 RID: 155717
		[Nullable(1)]
		private readonly Dictionary<EntityHandle, int> EntityTimeScaleMap = new Dictionary<EntityHandle, int>();

		// Token: 0x04026046 RID: 155718
		private bool IsWaitBattleView = true;

		// Token: 0x04026047 RID: 155719
		private int ScreenEffectCueId;

		// Token: 0x04026048 RID: 155720
		private int ScreenEffectCueHandleId;

		// Token: 0x04026049 RID: 155721
		private BaseGameplayCueComponent CueComp;

		// Token: 0x0402604A RID: 155722
		private EDynamicSettlementType SettlementType;

		// Token: 0x0402604B RID: 155723
		private EBattleSettlementBgmType? BgmType;
	}
}
