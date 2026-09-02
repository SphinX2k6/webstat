using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200600C RID: 24588
	[NullableContext(2)]
	[Nullable(0)]
	public class FormationItem : BattleChildView
	{
		// Token: 0x0603DEEA RID: 253674 RVA: 0x00FCC66C File Offset: 0x00FCA86C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 24;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(24, typeof(UUIItem)));
			}
		}

		// Token: 0x0603DEEB RID: 253675 RVA: 0x00FCC9E3 File Offset: 0x00FCABE3
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.PrefabIndex = (int)param;
			this.ConcertoChangeEffectDelay = ModelBase<BattleUiModel>.Instance.ConcertoChangeEffectDelay;
			base.GetTexture(9).SetUIActive(false);
			this.AddEvents();
		}

		// Token: 0x0603DEEC RID: 253676 RVA: 0x00FCCA1C File Offset: 0x00FCAC1C
		protected override UniTask InitializeAsync(object param = null)
		{
			FormationItem.<InitializeAsync>d__39 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<FormationItem.<InitializeAsync>d__39>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DEED RID: 253677 RVA: 0x00FCCA60 File Offset: 0x00FCAC60
		private UniTask InitTrialComponent()
		{
			FormationItem.<InitTrialComponent>d__40 <InitTrialComponent>d__;
			<InitTrialComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTrialComponent>d__.<>4__this = this;
			<InitTrialComponent>d__.<>1__state = -1;
			<InitTrialComponent>d__.<>t__builder.Start<FormationItem.<InitTrialComponent>d__40>(ref <InitTrialComponent>d__);
			return <InitTrialComponent>d__.<>t__builder.Task;
		}

		// Token: 0x0603DEEE RID: 253678 RVA: 0x00FCCAA3 File Offset: 0x00FCACA3
		public void ResetItem()
		{
			this.ClearData();
			this.SetActive(false);
		}

		// Token: 0x0603DEEF RID: 253679 RVA: 0x00FCCAB4 File Offset: 0x00FCACB4
		public void Refresh(int playerId, int roleConfigId, int roleSkinId, BattleUiRoleData roleData)
		{
			this.ClearData();
			this.PlayerId = playerId;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			this.IsMyRole = (playerId == id.GetValueOrDefault() & id != null);
			if (this.RoleConfigId != roleConfigId || this.RoleSkinId != roleSkinId)
			{
				this.RoleConfigId = roleConfigId;
				this.RoleSkinId = roleSkinId;
				this.RoleConfig = ConfigBase<CSharpScript.Game.Module.RoleUi.RoleConfig>.Instance.GetRoleConfig(this.RoleConfigId);
				if (this.RoleConfig.Value.RoleType == 1)
				{
					this.RoleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(this.RoleSkinId);
				}
				else
				{
					this.RoleSkinConfig = null;
				}
				this.RefreshRoleHead();
				this.RefreshRoleName();
			}
			this.RefreshOnlineItem();
			WorldEntity worldEntity;
			if (roleData == null)
			{
				worldEntity = null;
			}
			else
			{
				EntityHandle entityHandle = roleData.EntityHandle;
				worldEntity = ((entityHandle != null) ? entityHandle.Entity : null);
			}
			WorldEntity worldEntity2 = worldEntity;
			if (worldEntity2 == null || !worldEntity2.IsInit)
			{
				this.RefreshRoleHealthPercent();
				base.GetItem(14).SetUIActive(false);
				base.GetSprite(17).SetUIActive(false);
				this.SetActive(true);
				return;
			}
			this.EntityId = new int?(worldEntity2.Id);
			this.RoleData = roleData;
			BattleUiRoleData roleData2 = this.RoleData;
			this.IsAssistRole = (roleData2 != null && roleData2.GameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.辅战QTE状态"]));
			this.AddEntityEvents(worldEntity2);
			this.RefreshRoleHealthPercent();
			this.RefreshFormationConcertoItem();
			this.RefreshSuperSkillVisible();
			this.RefreshUltimateColor();
			this.RefreshKeyItem();
			this.RefreshChangeCoolDown();
			this.RefreshQteActive();
			this.RefreshLinkEffect();
			this.RefreshIsAssist();
			this.SetActive(true);
		}

		// Token: 0x0603DEF0 RID: 253680 RVA: 0x00FCCC54 File Offset: 0x00FCAE54
		public void ClearData()
		{
			BattleUiRoleData roleData = this.RoleData;
			WorldEntity worldEntity;
			if (roleData == null)
			{
				worldEntity = null;
			}
			else
			{
				EntityHandle entityHandle = roleData.EntityHandle;
				worldEntity = ((entityHandle != null) ? entityHandle.Entity : null);
			}
			WorldEntity worldEntity2 = worldEntity;
			if (worldEntity2 == null && this.EntityId != null)
			{
				EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(this.EntityId.Value);
				worldEntity2 = ((handle != null) ? handle.Entity : null);
			}
			this.RemoveEntityEvents(worldEntity2);
			this.RoleData = null;
			this.EntityId = null;
			this.PlayerId = 0;
			this.IsMyRole = false;
			this.RoleConfigId = 0;
			this.RoleConfig = null;
		}

		// Token: 0x0603DEF1 RID: 253681 RVA: 0x00FCCCF0 File Offset: 0x00FCAEF0
		private void AddEvents()
		{
			base.GetExtendToggle(0).OnPointDownCallBack.Bind(new Action<EToggleState>(this.OnFormationTogglePointDown));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.BattleUiElementEnergyChanged, new Action<int>(this.OnElementEnergyChanged));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.BattleUiEnergyChanged, new Action<int>(this.OnEnergyChanged));
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.BattleUiElementHideTagChanged, new Action<int, int, bool>(this.OnElementHideTagChanged));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.BattleUiHealthChanged, new Action<int>(this.OnHealthChanged));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.BattleUiShieldChanged, new Action<int>(this.OnShieldChanged));
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.BattleUiQteEnableTagChanged, new Action<int, int, bool>(this.OnQteEnableTagChanged));
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.BattleUiDeadTagChanged, new Action<int, int, bool>(this.OnBattleUiDeadTagChanged));
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.BattleUiQteCdTagChanged, new Action<int, int, bool>(this.OnBattleUiQteCdTagChanged));
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.CharInQteChanged, new Action<int, bool>(this.OnCharInQteChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			Singleton<EventSystem>.Instance.Add<ELinkStatus>(EEventName.OnBattleLinkStatusChanged, new Action<ELinkStatus>(this.OnBattleLinkStatusChanged));
		}

		// Token: 0x0603DEF2 RID: 253682 RVA: 0x00FCCE4C File Offset: 0x00FCB04C
		private void RemoveEvents()
		{
			base.GetExtendToggle(0).OnPointDownCallBack.Unbind();
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiElementEnergyChanged, new Action<int>(this.OnElementEnergyChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiEnergyChanged, new Action<int>(this.OnEnergyChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiElementHideTagChanged, new Action<int, int, bool>(this.OnElementHideTagChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiHealthChanged, new Action<int>(this.OnHealthChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiShieldChanged, new Action<int>(this.OnShieldChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiQteEnableTagChanged, new Action<int, int, bool>(this.OnQteEnableTagChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiDeadTagChanged, new Action<int, int, bool>(this.OnBattleUiDeadTagChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiQteCdTagChanged, new Action<int, int, bool>(this.OnBattleUiQteCdTagChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.CharInQteChanged, new Action<int, bool>(this.OnCharInQteChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleLinkStatusChanged, new Action<ELinkStatus>(this.OnBattleLinkStatusChanged));
		}

		// Token: 0x0603DEF3 RID: 253683 RVA: 0x00FCCF9C File Offset: 0x00FCB19C
		[NullableContext(1)]
		private void AddEntityEvents(Entity entity)
		{
			Singleton<EventSystem>.Instance.AddWithTarget<double>(entity, EEventName.OnChangeRoleCoolDownChanged, new Action<double>(this.OnEnterChangeCoolDownCallback));
			if (!this.IsMyRole)
			{
				BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
				this.ListenForTagSignificantChanged(component, GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.激活QTE"], new BaseTagComponent.TTagSwitchedCallback(this.OnTeammateQteEnableTagChanged));
				return;
			}
			BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
			this.ListenForTagSignificantChanged(component2, GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.辅战CD"], new BaseTagComponent.TTagSwitchedCallback(this.OnAssistQteCdTagChanged));
			this.ListenForTagSignificantChanged(component2, GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.辅战QTE状态"], new BaseTagComponent.TTagSwitchedCallback(this.OnAssistRoleTagChanged));
		}

		// Token: 0x0603DEF4 RID: 253684 RVA: 0x00FCD044 File Offset: 0x00FCB244
		[NullableContext(1)]
		private void ListenForTagSignificantChanged(BaseTagComponent gameplayTagComponent, int tagId, BaseTagComponent.TTagSwitchedCallback callback)
		{
			ITagTask tagTask = gameplayTagComponent.ListenForTagAddOrRemove(new int?(tagId), callback, null);
			if (tagTask != null)
			{
				this.TagSignificantChangedTaskList.Add(tagTask);
			}
		}

		// Token: 0x0603DEF5 RID: 253685 RVA: 0x00FCD070 File Offset: 0x00FCB270
		protected void RemoveEntityEvents(Entity entity)
		{
			if (entity != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<double>(entity, EEventName.OnChangeRoleCoolDownChanged, new Action<double>(this.OnEnterChangeCoolDownCallback));
			}
			foreach (ITagTask tagTask in this.TagSignificantChangedTaskList)
			{
				tagTask.EndTask();
			}
			this.TagSignificantChangedTaskList.Clear();
		}

		// Token: 0x0603DEF6 RID: 253686 RVA: 0x00FCD0EC File Offset: 0x00FCB2EC
		protected override void OnShowBattleChildView()
		{
			this.SetCoolDownItemVisible(false);
		}

		// Token: 0x0603DEF7 RID: 253687 RVA: 0x00FCD0F8 File Offset: 0x00FCB2F8
		public override void Reset()
		{
			this.KeyItem = null;
			this.RemoveEvents();
			this.CoolDownTime = 0.0;
			this.ResetChangeCoolDown();
			this.DeactivateConcertoChangeEffect();
			if (TimerSystem.Instance.Has(this.CureDelayTimerId))
			{
				TimerSystem.Instance.Remove(this.CureDelayTimerId);
			}
			if (this.TrialComponent != null)
			{
				this.TrialComponent.Destroy(null);
				this.TrialComponent = null;
			}
			if (this.LevelUpComponent != null)
			{
				this.LevelUpComponent.Destroy(null);
				this.LevelUpComponent = null;
			}
			if (this.RoleHeadOnlineComponent != null)
			{
				this.RoleHeadOnlineComponent.Destroy(null);
				this.RoleHeadOnlineComponent = null;
			}
			if (TimerSystem.Instance.Has(this.RefreshKeyItemTimer))
			{
				TimerSystem.Instance.Remove(this.RefreshKeyItemTimer);
				this.RefreshKeyItemTimer = null;
			}
			base.Reset();
		}

		// Token: 0x0603DEF8 RID: 253688 RVA: 0x00FCD1D4 File Offset: 0x00FCB3D4
		public void OnTick(float delta)
		{
			if (this.CoolDownTime > 0.0)
			{
				double num = this.CoolDownEndTime - Singleton<Time>.Instance.PlayerWorldTime;
				if (num <= 0.0)
				{
					this.CoolDownTime = 0.0;
					this.ResetChangeCoolDown();
					return;
				}
				if (Math.Abs(this.LastRefreshTextCoolDownTime - num) > 100.0)
				{
					this.LastRefreshTextCoolDownTime -= 100.0;
					this.RefreshCoolDownText();
				}
				this.UpdateChangeRoleCoolDownAnim(num);
			}
		}

		// Token: 0x0603DEF9 RID: 253689 RVA: 0x00FCD264 File Offset: 0x00FCB464
		private bool IsCurrentRole()
		{
			SceneTeamPlayer teamPlayerData = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(this.PlayerId);
			int? num2;
			if (teamPlayerData != null)
			{
				SceneTeamGroup group = teamPlayerData.GetGroup(ETeamGroupType.Battle);
				int? num;
				if (group == null)
				{
					num = null;
				}
				else
				{
					SceneTeamRole currentRole = group.GetCurrentRole();
					num = ((currentRole != null) ? new int?(currentRole.RoleId) : null);
				}
				num2 = num;
			}
			else
			{
				global::WorldTeamPlayerFightInfo worldTeamPlayerFightInfo = ModelBase<OnlineModel>.Instance.GetWorldTeamPlayerFightInfo(this.PlayerId);
				num2 = ((worldTeamPlayerFightInfo != null) ? new int?(worldTeamPlayerFightInfo.CurRoleId) : null);
			}
			int? num3 = num2;
			int roleConfigId = this.RoleConfigId;
			return num3.GetValueOrDefault() == roleConfigId & num3 != null;
		}

		// Token: 0x0603DEFA RID: 253690 RVA: 0x00FCD304 File Offset: 0x00FCB504
		private void OnEnterChangeCoolDownCallback(double coolDownTime)
		{
			if (Singleton<Info>.Instance.OperationType == global::EOperationType.Desktop)
			{
				double num = coolDownTime * (double)Singleton<TimeUtil>.Instance.InverseMillisecond;
				this.PlayChangeRoleCoolDown(num, num);
			}
		}

		// Token: 0x0603DEFB RID: 253691 RVA: 0x00FCD334 File Offset: 0x00FCB534
		private void OnShieldChanged(int entityId)
		{
			if (this.RoleData == null)
			{
				return;
			}
			this.RefreshRoleHealthPercent();
		}

		// Token: 0x0603DEFC RID: 253692 RVA: 0x00FCD348 File Offset: 0x00FCB548
		private void OnHealthChanged(int entityId)
		{
			if (this.RoleData == null)
			{
				return;
			}
			int? entityId2 = this.EntityId;
			if (!(entityId2.GetValueOrDefault() == entityId & entityId2 != null))
			{
				return;
			}
			this.RefreshRoleHealthPercent();
		}

		// Token: 0x0603DEFD RID: 253693 RVA: 0x00FCD382 File Offset: 0x00FCB582
		private void ResetAllConcertoNiagara()
		{
			this.SetCanUseQte(false, true);
		}

		// Token: 0x0603DEFE RID: 253694 RVA: 0x00FCD38C File Offset: 0x00FCB58C
		private void OnQteEnableTagChanged(int entityId, int tagId, bool bTagExists)
		{
			if (ControllerBase<FormationDataController>.Instance.IsBattleMulti())
			{
				return;
			}
			this.RefreshSingleModeQteEnable();
		}

		// Token: 0x0603DEFF RID: 253695 RVA: 0x00FCD3A1 File Offset: 0x00FCB5A1
		private void OnTeammateQteEnableTagChanged(int tagId, bool tagExist)
		{
			this.RefreshMultiModeQteEnable();
		}

		// Token: 0x0603DF00 RID: 253696 RVA: 0x00FCD3A9 File Offset: 0x00FCB5A9
		private void OnAssistQteCdTagChanged(int tagId, bool tagExist)
		{
			this.RefreshAssistCoolDown();
		}

		// Token: 0x0603DF01 RID: 253697 RVA: 0x00FCD3B1 File Offset: 0x00FCB5B1
		private void OnAssistRoleTagChanged(int tagId, bool tagExist)
		{
			if (this.IsAssistRole == tagExist)
			{
				return;
			}
			this.IsAssistRole = tagExist;
			this.RefreshIsAssist();
		}

		// Token: 0x0603DF02 RID: 253698 RVA: 0x00FCD3CA File Offset: 0x00FCB5CA
		private void OnBattleUiDeadTagChanged(int entityId, int tagId, bool tagExist)
		{
			this.RefreshQteActive();
		}

		// Token: 0x0603DF03 RID: 253699 RVA: 0x00FCD3D2 File Offset: 0x00FCB5D2
		private void OnBattleUiQteCdTagChanged(int entityId, int tagId, bool tagExist)
		{
			this.RefreshQteActive();
		}

		// Token: 0x0603DF04 RID: 253700 RVA: 0x00FCD3DA File Offset: 0x00FCB5DA
		private void OnCharInQteChanged(int entityId, bool tagExist)
		{
			this.RefreshQteActive();
		}

		// Token: 0x0603DF05 RID: 253701 RVA: 0x00FCD3E2 File Offset: 0x00FCB5E2
		private void OnBattleStateChanged(bool isFight)
		{
			this.RefreshQteActive();
		}

		// Token: 0x0603DF06 RID: 253702 RVA: 0x00FCD3EA File Offset: 0x00FCB5EA
		public void RefreshQteActive()
		{
			if (ControllerBase<FormationDataController>.Instance.IsBattleMulti())
			{
				this.RefreshMultiModeQteEnable();
				return;
			}
			this.RefreshSingleModeQteEnable();
		}

		// Token: 0x0603DF07 RID: 253703 RVA: 0x00FCD408 File Offset: 0x00FCB608
		private void RefreshSingleModeQteEnable()
		{
			if (this.RoleData == null)
			{
				this.ResetAllConcertoNiagara();
				return;
			}
			bool bCanUseQte = false;
			if (this.IsConcertoResponseOpen)
			{
				BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
				EntityHandle entityHandle = (curRoleData != null) ? curRoleData.EntityHandle : null;
				if (entityHandle != null && this.RoleData.EntityHandle != entityHandle)
				{
					RoleQteComponent roleQteComponent = this.RoleData.RoleQteComponent;
					bCanUseQte = (roleQteComponent != null && roleQteComponent.IsQteReady(entityHandle));
				}
			}
			this.SetCanUseQte(bCanUseQte, false);
		}

		// Token: 0x0603DF08 RID: 253704 RVA: 0x00FCD478 File Offset: 0x00FCB678
		private void RefreshMultiModeQteEnable()
		{
			if (this.RoleData == null || this.IsMyRole)
			{
				this.ResetAllConcertoNiagara();
				return;
			}
			bool bCanUseQte = false;
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			EntityHandle entityHandle = (curRoleData != null) ? curRoleData.EntityHandle : null;
			EntityHandle entityHandle2 = this.RoleData.EntityHandle;
			if (entityHandle != null && entityHandle2 != null && entityHandle2.IsInit)
			{
				bCanUseQte = entityHandle.Entity.GetComponent<RoleQteComponent>().IsQteReady(entityHandle2);
			}
			this.SetCanUseQte(bCanUseQte, false);
		}

		// Token: 0x0603DF09 RID: 253705 RVA: 0x00FCD4EC File Offset: 0x00FCB6EC
		private void SetCanUseQte(bool bCanUseQte, bool isInit)
		{
			if (this.QteNiagaraActive == bCanUseQte)
			{
				this.RefreshKeyItemGray();
				return;
			}
			this.QteNiagaraActive = bCanUseQte;
			UUINiagara uiNiagara = base.GetUiNiagara(5);
			uiNiagara.SetUIActive(bCanUseQte);
			if (bCanUseQte)
			{
				uiNiagara.ActivateSystem(true);
				if (!isInit)
				{
					EBattleUiAudioType type = this.IsAssistRole ? EBattleUiAudioType.QteCanUseRogue : EBattleUiAudioType.QteCanUse;
					EBattleUiChild uiChildType = Singleton<Info>.Instance.IsInGamepad() ? EBattleUiChild.GamepadFormation : EBattleUiChild.Formation;
					ModelBase<BattleUiModel>.Instance.AudioData.PlayAudio(type, uiChildType);
				}
			}
			else
			{
				uiNiagara.Deactivate();
			}
			this.RefreshKeyItemGray();
		}

		// Token: 0x0603DF0A RID: 253706 RVA: 0x00FCD56C File Offset: 0x00FCB76C
		private void RefreshChangeCoolDown()
		{
			BattleUiRoleData roleData = this.RoleData;
			RoleTeamComponent roleTeamComponent;
			if (roleData == null)
			{
				roleTeamComponent = null;
			}
			else
			{
				EntityHandle entityHandle = roleData.EntityHandle;
				if (entityHandle == null)
				{
					roleTeamComponent = null;
				}
				else
				{
					WorldEntity entity = entityHandle.Entity;
					roleTeamComponent = ((entity != null) ? entity.GetComponent<RoleTeamComponent>() : null);
				}
			}
			RoleTeamComponent roleTeamComponent2 = roleTeamComponent;
			if (roleTeamComponent2 == null)
			{
				return;
			}
			double changeRoleCoolDown = roleTeamComponent2.GetChangeRoleCoolDown();
			if (changeRoleCoolDown <= 0.0)
			{
				return;
			}
			this.PlayChangeRoleCoolDown(changeRoleCoolDown, changeRoleCoolDown);
		}

		// Token: 0x0603DF0B RID: 253707 RVA: 0x00FCD5C4 File Offset: 0x00FCB7C4
		private void SetSelectedNiagara(bool bSelected)
		{
			if (this.SelectedNiagaraActive == bSelected)
			{
				return;
			}
			this.SelectedNiagaraActive = bSelected;
			if (bSelected)
			{
				this.StopTweenAnim(19);
				this.PlayTweenAnim(18);
				return;
			}
			this.StopTweenAnim(18);
			this.PlayTweenAnim(19);
		}

		// Token: 0x0603DF0C RID: 253708 RVA: 0x00FCD5FC File Offset: 0x00FCB7FC
		private void ResetChangeCoolDown()
		{
			Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.CFT, "重置换人冷却表现", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SetCoolDownItemVisible(false);
		}

		// Token: 0x0603DF0D RID: 253709 RVA: 0x00FCD62C File Offset: 0x00FCB82C
		private void OnFormationTogglePointDown(EToggleState state)
		{
			BattleUiRoleData roleData = this.RoleData;
			long? num = (roleData != null) ? new long?(roleData.CreatureDataId) : null;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Formation;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "当点击阵容头像按钮时";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", num);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (GlobalData.GameInstance != null && num != null)
			{
				ControllerBase<CooperationController>.Instance.TryCooperate(num.Value);
			}
		}

		// Token: 0x0603DF0E RID: 253710 RVA: 0x00FCD6A8 File Offset: 0x00FCB8A8
		public void LevelUp(int level)
		{
			string levelText = level.ToString();
			if (this.LevelUpComponent == null)
			{
				this.LevelUpComponent = new FormationLevelUpItem(this.RootItem);
			}
			else
			{
				this.LevelUpComponent.SetActive(true);
			}
			this.LevelUpComponent.SetLevelText(levelText);
			TimerSystem.Instance.Delay(delegate(float _)
			{
				FormationLevelUpItem levelUpComponent = this.LevelUpComponent;
				if (levelUpComponent == null)
				{
					return;
				}
				levelUpComponent.SetActive(false);
			}, 5000f, null, null, true, 1f);
		}

		// Token: 0x0603DF0F RID: 253711 RVA: 0x00FCD714 File Offset: 0x00FCB914
		public void RefreshConcertoResponseModule(bool isOpen)
		{
			this.IsConcertoResponseOpen = isOpen;
			this.RefreshElementVisible();
		}

		// Token: 0x0603DF10 RID: 253712 RVA: 0x00FCD724 File Offset: 0x00FCB924
		public void CureRole()
		{
			if (!this.IsCurrentRole())
			{
				BattleUiRoleData roleData = this.RoleData;
				bool? flag;
				if (roleData == null)
				{
					flag = null;
				}
				else
				{
					BaseDeathComponent baseDeathComponent = roleData.BaseDeathComponent;
					flag = ((baseDeathComponent != null) ? new bool?(baseDeathComponent.IsDead()) : null);
				}
				bool? flag2 = flag;
				if (!flag2.GetValueOrDefault(true))
				{
					base.GetItem(4).SetUIActive(true);
					this.CureDelayTimerId = TimerSystem.Instance.Delay(delegate(float _)
					{
						base.GetItem(4).SetUIActive(false);
					}, 1000f, null, null, true, 1f);
					return;
				}
			}
		}

		// Token: 0x0603DF11 RID: 253713 RVA: 0x00FCD7B0 File Offset: 0x00FCB9B0
		[NullableContext(1)]
		private void SetRoleHead(string roleTexturePath, int roleConfigId)
		{
			FormationItem.<>c__DisplayClass76_0 CS$<>8__locals1 = new FormationItem.<>c__DisplayClass76_0();
			CS$<>8__locals1.roleTexture = base.GetTexture(9);
			if (CS$<>8__locals1.roleTexture == null)
			{
				return;
			}
			CS$<>8__locals1.changeRoleCoolDownBarTexture = base.GetTexture(2);
			if (CS$<>8__locals1.changeRoleCoolDownBarTexture == null)
			{
				return;
			}
			base.SetRoleIcon(roleTexturePath, CS$<>8__locals1.roleTexture, roleConfigId, null, new Action<bool>(CS$<>8__locals1.<SetRoleHead>g__IconCallback|0));
			CS$<>8__locals1.changeRoleCoolDownBarTexture.SetUIActive(false);
			base.SetRoleIcon(roleTexturePath, CS$<>8__locals1.changeRoleCoolDownBarTexture, roleConfigId, null, new Action<bool>(CS$<>8__locals1.<SetRoleHead>g__MaskCallback|1));
		}

		// Token: 0x0603DF12 RID: 253714 RVA: 0x00FCD844 File Offset: 0x00FCBA44
		[NullableContext(1)]
		private void SetRoleSkinHead(string roleTexturePath, int roleSkinId)
		{
			FormationItem.<>c__DisplayClass77_0 CS$<>8__locals1 = new FormationItem.<>c__DisplayClass77_0();
			CS$<>8__locals1.roleTexture = base.GetTexture(9);
			if (CS$<>8__locals1.roleTexture == null)
			{
				return;
			}
			CS$<>8__locals1.changeRoleCoolDownBarTexture = base.GetTexture(2);
			if (CS$<>8__locals1.changeRoleCoolDownBarTexture == null)
			{
				return;
			}
			base.SetRoleSkinIcon(roleTexturePath, CS$<>8__locals1.roleTexture, roleSkinId, null, new Action<bool>(CS$<>8__locals1.<SetRoleSkinHead>g__IconCallback|0));
			CS$<>8__locals1.changeRoleCoolDownBarTexture.SetUIActive(false);
			base.SetRoleSkinIcon(roleTexturePath, CS$<>8__locals1.changeRoleCoolDownBarTexture, roleSkinId, null, new Action<bool>(CS$<>8__locals1.<SetRoleSkinHead>g__MaskCallback|1));
		}

		// Token: 0x0603DF13 RID: 253715 RVA: 0x00FCD8D8 File Offset: 0x00FCBAD8
		private void SetHealthPercent(float healthPercent)
		{
			UUISprite sprite;
			if (healthPercent <= 0.2f)
			{
				sprite = base.GetSprite(13);
				base.GetSprite(12).SetUIActive(false);
				base.GetSprite(13).SetUIActive(true);
			}
			else
			{
				sprite = base.GetSprite(12);
				base.GetSprite(12).SetUIActive(true);
				base.GetSprite(13).SetUIActive(false);
			}
			if (sprite != null)
			{
				sprite.SetFillAmount(healthPercent);
			}
		}

		// Token: 0x0603DF14 RID: 253716 RVA: 0x00FCD944 File Offset: 0x00FCBB44
		public void RefreshRoleName()
		{
			int roleConfigId = this.RoleConfigId;
			if (roleConfigId <= 100000)
			{
				FormationTrialItem trialComponent = this.TrialComponent;
				if (trialComponent == null)
				{
					return;
				}
				trialComponent.SetActive(false);
				return;
			}
			else
			{
				TrialRoleInfo? trialRoleConfig = ConfigBase<CSharpScript.Game.Module.RoleUi.RoleConfig>.Instance.GetTrialRoleConfig(roleConfigId);
				if (trialRoleConfig != null && trialRoleConfig.GetValueOrDefault().HideTrialLabel)
				{
					FormationTrialItem trialComponent2 = this.TrialComponent;
					if (trialComponent2 == null)
					{
						return;
					}
					trialComponent2.SetActive(false);
					return;
				}
				else
				{
					FormationTrialItem trialComponent3 = this.TrialComponent;
					if (trialComponent3 != null)
					{
						trialComponent3.SetActive(true);
					}
					string nameText;
					if (this.IsMyRole)
					{
						nameText = (RoleUtils.IsSpecialTrialRole(roleConfigId) ? string.Empty : ModelBase<RoleModel>.Instance.GetRoleName(roleConfigId, null));
					}
					else
					{
						OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(this.PlayerId);
						nameText = (((currentTeamListById != null) ? currentTeamListById.Name : null) ?? string.Empty);
					}
					FormationTrialItem trialComponent4 = this.TrialComponent;
					if (trialComponent4 != null)
					{
						trialComponent4.SetNameText(nameText);
					}
					ETrialRoleType trialRoleType = ETrialRoleType.NormalTrial;
					if (trialRoleConfig != null)
					{
						trialRoleType = (ETrialRoleType)trialRoleConfig.Value.Type;
					}
					string trialRoleLabelIconByType = RoleUtils.GetTrialRoleLabelIconByType(trialRoleType);
					FormationTrialItem trialComponent5 = this.TrialComponent;
					if (trialComponent5 == null)
					{
						return;
					}
					trialComponent5.SetTrialIcon(trialRoleLabelIconByType);
					return;
				}
			}
		}

		// Token: 0x0603DF15 RID: 253717 RVA: 0x00FCDA60 File Offset: 0x00FCBC60
		public void SetRoleSelected(bool bSelected)
		{
			if (Singleton<Info>.Instance.OperationType == global::EOperationType.Desktop)
			{
				bool selectedNiagara = false;
				if (ModelBase<SceneTeamModel>.Instance.GetTeamLength() > 1)
				{
					selectedNiagara = bSelected;
				}
				this.SetSelectedNiagara(selectedNiagara);
			}
			else
			{
				this.SetSelectedNiagara(bSelected);
			}
			this.RefreshSuperSkillVisible();
		}

		// Token: 0x0603DF16 RID: 253718 RVA: 0x00FCDAA1 File Offset: 0x00FCBCA1
		public void RefreshCoolDownOnShow()
		{
			if (this.RoleData == null)
			{
				return;
			}
			this.RefreshChangeCoolDown();
			this.RefreshAssistCoolDown();
		}

		// Token: 0x0603DF17 RID: 253719 RVA: 0x00FCDAB8 File Offset: 0x00FCBCB8
		private void PlayChangeRoleCoolDown(double coolDownTime, double coolDownTimeRemain)
		{
			if (coolDownTime <= 0.0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Formation;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "播放换人冷却CD时，CD时间小于0，不会播放换人冷却CD表现";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("coolDownTime", coolDownTime);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.ResetChangeCoolDown();
				return;
			}
			this.CoolDownEndTime = Singleton<Time>.Instance.PlayerWorldTime + coolDownTimeRemain;
			this.CoolDownTime = coolDownTime;
			this.LastRefreshTextCoolDownTime = coolDownTimeRemain;
			this.RefreshCoolDownText();
			this.UpdateChangeRoleCoolDownAnim(coolDownTimeRemain);
			this.SetCoolDownItemVisible(true);
		}

		// Token: 0x0603DF18 RID: 253720 RVA: 0x00FCDB38 File Offset: 0x00FCBD38
		private void UpdateChangeRoleCoolDownAnim(double coolDownTimeRemain)
		{
			if (this.RefreshCooldownExternalLock)
			{
				return;
			}
			if (coolDownTimeRemain <= 0.0)
			{
				return;
			}
			double num = coolDownTimeRemain / this.CoolDownTime;
			base.GetTexture(2).SetFillAmount((float)num);
		}

		// Token: 0x0603DF19 RID: 253721 RVA: 0x00FCDB74 File Offset: 0x00FCBD74
		private void RefreshCoolDownText()
		{
			if (this.RefreshCooldownExternalLock)
			{
				return;
			}
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText((this.LastRefreshTextCoolDownTime * Singleton<TimeUtil>.Instance.Millisecond).ToString("F1"), true);
		}

		// Token: 0x0603DF1A RID: 253722 RVA: 0x00FCDBBA File Offset: 0x00FCBDBA
		private void SetCoolDownItemVisible(bool bVisible)
		{
			if (this.RefreshCooldownExternalLock)
			{
				return;
			}
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(bVisible);
		}

		// Token: 0x0603DF1B RID: 253723 RVA: 0x00FCDBD8 File Offset: 0x00FCBDD8
		public void RefreshCoolDownExternal(float? remainCd = 0f, float? totalCd = 0f)
		{
			UUIItem item = base.GetItem(1);
			if (remainCd == null || totalCd == null)
			{
				if (this.RefreshCooldownExternalLock)
				{
					this.RefreshCooldownExternalLock = false;
					if (item != null)
					{
						item.SetUIActive(false);
					}
				}
				return;
			}
			this.RefreshCooldownExternalLock = true;
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetText(remainCd.Value.ToString("F1"), true);
			}
			float? num = remainCd / totalCd;
			base.GetTexture(2).SetFillAmount(num.Value);
		}

		// Token: 0x0603DF1C RID: 253724 RVA: 0x00FCDC9C File Offset: 0x00FCBE9C
		private void RefreshRoleHead()
		{
			if (this.RoleSkinConfig != null)
			{
				string roleHeadIconBig = this.RoleSkinConfig.Value.RoleHeadIconBig;
				if (!string.IsNullOrEmpty(roleHeadIconBig))
				{
					this.SetRoleSkinHead(roleHeadIconBig, this.RoleSkinConfig.Value.Id);
					return;
				}
			}
			if (this.RoleConfig == null)
			{
				return;
			}
			string roleHeadIconBig2 = this.RoleConfig.Value.RoleHeadIconBig;
			if (string.IsNullOrEmpty(roleHeadIconBig2))
			{
				return;
			}
			this.SetRoleHead(roleHeadIconBig2, this.RoleConfig.Value.Id);
		}

		// Token: 0x0603DF1D RID: 253725 RVA: 0x00FCDD34 File Offset: 0x00FCBF34
		public void RefreshSelectedRole()
		{
			BattleUiRoleData roleData = this.RoleData;
			if (((roleData != null) ? roleData.AttributeComponent : null) == null)
			{
				return;
			}
			if (!this.IsMyRole)
			{
				this.SetRoleSelected(false);
				return;
			}
			this.RefreshKeyItem();
			if (this.RoleData.AttributeComponent.GetCurrentValue(EAttributeType.Life) <= 0f)
			{
				this.SetRoleSelected(false);
				return;
			}
			bool roleSelected = this.IsCurrentRole();
			this.SetRoleSelected(roleSelected);
			this.RefreshElementVisible();
		}

		// Token: 0x0603DF1E RID: 253726 RVA: 0x00FCDDA0 File Offset: 0x00FCBFA0
		public void ActivateConcertoChangeEffect(int elementId1, int elementId2)
		{
			base.GetText(8).SetUIActive(false);
			base.GetUiNiagara(7).ActivateSystem(true);
			UUIItem item = base.GetItem(6);
			if (!item.IsUIActiveSelf())
			{
				item.SetUIActive(true);
			}
			this.ConcertoChangeTimerId = TimerSystem.Instance.Delay(new TTimerAction(this.OnConcertoEffectEnded), (float)this.ConcertoChangeEffectDelay, null, null, true, 1f);
		}

		// Token: 0x0603DF1F RID: 253727 RVA: 0x00FCDE09 File Offset: 0x00FCC009
		private void OnConcertoEffectEnded(float delta)
		{
			this.DeactivateConcertoChangeEffect();
		}

		// Token: 0x0603DF20 RID: 253728 RVA: 0x00FCDE14 File Offset: 0x00FCC014
		private void DeactivateConcertoChangeEffect()
		{
			UUIItem item = base.GetItem(6);
			if (item.IsUIActiveSelf())
			{
				item.SetUIActive(false);
			}
			base.GetUiNiagara(7).DeactivateSystem();
			if (this.ConcertoChangeTimerId != null && TimerSystem.Instance.Has(this.ConcertoChangeTimerId))
			{
				TimerSystem.Instance.Remove(this.ConcertoChangeTimerId);
				this.ConcertoChangeTimerId = null;
			}
		}

		// Token: 0x0603DF21 RID: 253729 RVA: 0x00FCDE76 File Offset: 0x00FCC076
		private void RefreshIsAssist()
		{
			base.GetItem(10).SetUIActive(!this.IsAssistRole);
			this.RefreshAssistCoolDown();
		}

		// Token: 0x0603DF22 RID: 253730 RVA: 0x00FCDE94 File Offset: 0x00FCC094
		private void RefreshAssistCoolDown()
		{
			if (!this.IsAssistRole)
			{
				return;
			}
			BattleUiRoleData roleData = this.RoleData;
			if (roleData == null || !roleData.GameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.辅战CD"]))
			{
				this.ResetChangeCoolDown();
				return;
			}
			BattleUiRoleData roleData2 = this.RoleData;
			ActiveBuffInternal activeBuffInternal = (roleData2 != null) ? roleData2.BuffComponent.GetBuffById(900000000012L) : null;
			float num = (activeBuffInternal != null) ? activeBuffInternal.GetRemainDuration() : 0f;
			float num2 = (activeBuffInternal != null) ? activeBuffInternal.Duration : 0f;
			if (num <= 0f || num2 <= 0f)
			{
				this.ResetChangeCoolDown();
				return;
			}
			this.PlayChangeRoleCoolDown((double)((int)(num2 * (float)Singleton<TimeUtil>.Instance.InverseMillisecond)), (double)((int)(num * (float)Singleton<TimeUtil>.Instance.InverseMillisecond)));
		}

		// Token: 0x0603DF23 RID: 253731 RVA: 0x00FCDF57 File Offset: 0x00FCC157
		[NullableContext(1)]
		public UUIItem GetExtraContainer()
		{
			return base.GetItem(23);
		}

		// Token: 0x0603DF24 RID: 253732 RVA: 0x00FCDF64 File Offset: 0x00FCC164
		public void RefreshRoleHealthPercent()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			BattleUiRoleData roleData = this.RoleData;
			float? num;
			if (roleData == null)
			{
				num = null;
			}
			else
			{
				BaseAttributeComponent attributeComponent = roleData.AttributeComponent;
				num = ((attributeComponent != null) ? new float?(attributeComponent.GetCurrentValue(EAttributeType.Life)) : null);
			}
			float? num2 = num;
			float valueOrDefault = num2.GetValueOrDefault(1f);
			BattleUiRoleData roleData2 = this.RoleData;
			float? num3;
			if (roleData2 == null)
			{
				num3 = null;
			}
			else
			{
				BaseAttributeComponent attributeComponent2 = roleData2.AttributeComponent;
				num3 = ((attributeComponent2 != null) ? new float?(attributeComponent2.GetCurrentValue(EAttributeType.LifeMax)) : null);
			}
			num2 = num3;
			float valueOrDefault2 = num2.GetValueOrDefault(1f);
			BattleUiRoleData roleData3 = this.RoleData;
			float num4 = (roleData3 != null) ? roleData3.ShieldComponent.ShieldTotal : 0f;
			if (valueOrDefault <= 0f || valueOrDefault2 <= 0f)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
				base.GetTexture(9).SetIsGray(true);
				UUITexture texture = base.GetTexture(2);
				if (texture != null)
				{
					texture.SetIsGray(true);
				}
				base.GetSprite(11).SetUIActive(false);
				this.SetHealthPercent(0f);
				return;
			}
			if (num4 > 0f)
			{
				UUISprite sprite = base.GetSprite(11);
				sprite.SetUIActive(true);
				sprite.SetFillAmount(num4 / valueOrDefault2);
			}
			else
			{
				base.GetSprite(11).SetUIActive(false);
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			base.GetTexture(9).SetIsGray(false);
			UUITexture texture2 = base.GetTexture(2);
			if (texture2 != null)
			{
				texture2.SetIsGray(false);
			}
			this.SetHealthPercent(valueOrDefault / valueOrDefault2);
			this.RefreshSelectedRole();
		}

		// Token: 0x0603DF25 RID: 253733 RVA: 0x00FCE0E4 File Offset: 0x00FCC2E4
		private void RefreshSuperSkillVisible()
		{
			if (Singleton<Info>.Instance.OperationType != global::EOperationType.Desktop)
			{
				bool uiactive = this.CanUseSuperSkill();
				base.GetSprite(17).SetUIActive(uiactive);
				return;
			}
			if (this.IsMyRole && this.IsCurrentRole())
			{
				base.GetSprite(17).SetUIActive(false);
				return;
			}
			bool uiactive2 = this.CanUseSuperSkill();
			base.GetSprite(17).SetUIActive(uiactive2);
		}

		// Token: 0x0603DF26 RID: 253734 RVA: 0x00FCE148 File Offset: 0x00FCC348
		private void RefreshUltimateColor()
		{
			BattleUiRoleData roleData = this.RoleData;
			ElementInfo? elementInfo = (roleData != null) ? roleData.ElementConfig : null;
			if (elementInfo == null)
			{
				return;
			}
			if (this.CurrentSetUltimateColor != elementInfo.Value.UltimateSkillColor)
			{
				this.CurrentSetUltimateColor = elementInfo.Value.UltimateSkillColor;
				base.GetSprite(17).SetColor(this.RoleData.UltimateSkillColor.Value);
			}
		}

		// Token: 0x0603DF27 RID: 253735 RVA: 0x00FCE1C8 File Offset: 0x00FCC3C8
		private void RefreshKeyItem()
		{
			if (Singleton<Info>.Instance.OperationType == global::EOperationType.Desktop)
			{
				if (this.IsMyRole && this.IsCurrentRole())
				{
					this.KeyItem.SetActive(false);
					return;
				}
				BattleUiFormationPanelData formationPanelData = ModelBase<BattleUiModel>.Instance.FormationPanelData;
				int num = (formationPanelData != null) ? formationPanelData.GetRolePosition(this.PlayerId, this.RoleConfigId) : 0;
				if (num <= 0)
				{
					this.KeyItem.SetActive(false);
					return;
				}
				KeyItemBase keyItem = this.KeyItem;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendLiteral("切换角色");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				keyItem.RefreshAction(defaultInterpolatedStringHandler.ToStringAndClear());
				string keyName = this.KeyItem.GetKeyName();
				if (!string.IsNullOrEmpty(keyName))
				{
					List<string> invisibleKeyList = this.InvisibleKeyList;
					if (invisibleKeyList != null && invisibleKeyList.Contains(keyName))
					{
						this.KeyItem.SetActive(false);
						return;
					}
				}
				this.KeyItem.SetActive(true);
			}
		}

		// Token: 0x0603DF28 RID: 253736 RVA: 0x00FCE2A8 File Offset: 0x00FCC4A8
		private void RefreshKeyItemGray()
		{
			if (this.KeyItem == null)
			{
				return;
			}
			bool gray = false;
			if (!this.IsMyRole)
			{
				gray = !this.QteNiagaraActive;
			}
			this.KeyItem.SetGray(gray);
		}

		// Token: 0x0603DF29 RID: 253737 RVA: 0x00FCE2DE File Offset: 0x00FCC4DE
		private bool CanUseSuperSkill()
		{
			BattleUiRoleData roleData = this.RoleData;
			return roleData != null && roleData.CanUseUltraSkill();
		}

		// Token: 0x0603DF2A RID: 253738 RVA: 0x00FCE2F4 File Offset: 0x00FCC4F4
		private void RefreshFormationConcertoItem()
		{
			if (this.RoleData == null)
			{
				base.GetItem(14).SetUIActive(false);
				return;
			}
			EElementType? currentElementType = this.CurrentElementType;
			EElementType? elementType = this.RoleData.ElementType;
			if (!(currentElementType.GetValueOrDefault() == elementType.GetValueOrDefault() & currentElementType != null == (elementType != null)))
			{
				this.CurrentElementType = this.RoleData.ElementType;
				this.CurrentElementInfo = this.RoleData.ElementConfig;
				ElementInfo value = this.CurrentElementInfo.Value;
				this.SetElementStyle(value, this.CurrentElementType.Value);
			}
			this.UpdateElementBar();
			this.RefreshElementVisible();
		}

		// Token: 0x0603DF2B RID: 253739 RVA: 0x00FCE39C File Offset: 0x00FCC59C
		private void OnElementEnergyChanged(int entityId)
		{
			int? entityId2 = this.EntityId;
			if (!(entityId == entityId2.GetValueOrDefault() & entityId2 != null))
			{
				return;
			}
			this.UpdateElementBar();
		}

		// Token: 0x0603DF2C RID: 253740 RVA: 0x00FCE3CC File Offset: 0x00FCC5CC
		private void OnEnergyChanged(int entityId)
		{
			int? entityId2 = this.EntityId;
			if (!(entityId == entityId2.GetValueOrDefault() & entityId2 != null))
			{
				return;
			}
			this.RefreshSuperSkillVisible();
		}

		// Token: 0x0603DF2D RID: 253741 RVA: 0x00FCE3FC File Offset: 0x00FCC5FC
		private void OnElementHideTagChanged(int entityId, int tagId, bool tagExist)
		{
			int? entityId2 = this.EntityId;
			if (!(entityId == entityId2.GetValueOrDefault() & entityId2 != null))
			{
				return;
			}
			this.RefreshElementVisible();
		}

		// Token: 0x0603DF2E RID: 253742 RVA: 0x00FCE42C File Offset: 0x00FCC62C
		public void RefreshElementVisible()
		{
			if (this.RoleData == null)
			{
				return;
			}
			UUIItem item = base.GetItem(14);
			if (!this.IsConcertoResponseOpen)
			{
				item.SetUIActive(false);
				return;
			}
			if (this.RoleConfig != null && this.RoleConfig.GetValueOrDefault().RoleType == 2)
			{
				item.SetUIActive(false);
				this.ResetAllConcertoNiagara();
				return;
			}
			if (Singleton<Info>.Instance.OperationType == global::EOperationType.Desktop && this.IsMyRole && this.IsCurrentRole())
			{
				item.SetUIActive(false);
				return;
			}
			foreach (int tagId in BattleUiRoleData.HideElementTagList)
			{
				BaseTagComponent gameplayTagComponent = this.RoleData.GameplayTagComponent;
				if (gameplayTagComponent != null && gameplayTagComponent.HasTag(tagId))
				{
					item.SetUIActive(false);
					return;
				}
			}
			item.SetUIActive(true);
		}

		// Token: 0x0603DF2F RID: 253743 RVA: 0x00FCE4F8 File Offset: 0x00FCC6F8
		private void SetElementStyle(in ElementInfo elementConfig, EElementType elementType)
		{
			ElementInfo elementInfo = elementConfig;
			string icon = elementInfo.Icon5;
			UUIItem sprite = base.GetSprite(16);
			UUITexture texture = base.GetTexture(15);
			base.SetElementIcon(icon, texture, (int)elementType, null);
			texture.SetColor(this.RoleData.ElementColor.Value);
			sprite.SetColor(this.RoleData.ElementColor.Value);
		}

		// Token: 0x0603DF30 RID: 253744 RVA: 0x00FCE564 File Offset: 0x00FCC764
		private void UpdateElementBar()
		{
			UUISprite sprite = base.GetSprite(16);
			BattleUiRoleData roleData = this.RoleData;
			float fillAmount = (roleData != null) ? roleData.GetElementAttributePercent() : 0f;
			sprite.SetFillAmount(fillAmount);
		}

		// Token: 0x0603DF31 RID: 253745 RVA: 0x00FCE598 File Offset: 0x00FCC798
		public void RefreshOnlineItem()
		{
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				FormationOnlineItem roleHeadOnlineComponent = this.RoleHeadOnlineComponent;
				if (roleHeadOnlineComponent != null)
				{
					roleHeadOnlineComponent.Destroy(null);
				}
				this.RoleHeadOnlineComponent = null;
				return;
			}
			if (this.RoleHeadOnlineComponent == null)
			{
				this.RoleHeadOnlineComponent = new FormationOnlineItem(this.RootItem);
			}
			OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(this.PlayerId);
			if (currentTeamListById != null)
			{
				this.RefreshPlayerPingState(currentTeamListById.PingState);
			}
			if (this.IsMyRole)
			{
				this.RoleHeadOnlineComponent.SetOnlineNumber(-1);
				this.RoleHeadOnlineComponent.SetNameText(string.Empty);
				this.RoleHeadOnlineComponent.RefreshThirdPartyItem(ModelBase<PlayerInfoModel>.Instance.GetThirdPartyUserId() ?? string.Empty);
				return;
			}
			this.RoleHeadOnlineComponent.SetOnlineNumber((currentTeamListById != null) ? currentTeamListById.PlayerNumber : -1);
			this.RoleHeadOnlineComponent.SetNameText(((currentTeamListById != null) ? currentTeamListById.GetFormationName() : null) ?? string.Empty);
			string thirdPartyAccountId = Singleton<Info>.Instance.IsPs5Platform() ? (((currentTeamListById != null) ? currentTeamListById.PlayerDetails.PsnAccountId : null) ?? string.Empty) : (((currentTeamListById != null) ? currentTeamListById.PlayerDetails.XboxAccountId : null) ?? string.Empty);
			this.RoleHeadOnlineComponent.RefreshThirdPartyItem(thirdPartyAccountId);
			this.RoleHeadOnlineComponent.SetIsGrayByOtherControl(!this.IsCurrentRole());
		}

		// Token: 0x0603DF32 RID: 253746 RVA: 0x00FCE6E4 File Offset: 0x00FCC8E4
		public void RefreshPlayerPingState(ENetPingState pingState)
		{
			if (this.RoleHeadOnlineComponent == null)
			{
				return;
			}
			if (pingState == ENetPingState.Poor)
			{
				this.RoleHeadOnlineComponent.SetNetWeak(true);
				this.RoleHeadOnlineComponent.SetNetDisconnect(false);
				return;
			}
			if (pingState == ENetPingState.Unknown)
			{
				this.RoleHeadOnlineComponent.SetNetDisconnect(true);
				this.RoleHeadOnlineComponent.SetNetWeak(false);
				return;
			}
			this.RoleHeadOnlineComponent.SetNetWeak(false);
			this.RoleHeadOnlineComponent.SetNetDisconnect(false);
		}

		// Token: 0x0603DF33 RID: 253747 RVA: 0x00FCE74C File Offset: 0x00FCC94C
		private void InitTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list = new List<ULGUIPlayTweenComponent>();
			TArray<UActorComponent> tarray = base.GetItem(componentType).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				list.Add((ULGUIPlayTweenComponent)tarray.Get(i));
			}
			if (this.TweenAnimMap == null)
			{
				this.TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();
			}
			this.TweenAnimMap[componentType] = list;
		}

		// Token: 0x0603DF34 RID: 253748 RVA: 0x00FCE7C0 File Offset: 0x00FCC9C0
		private void PlayTweenAnim(int componentType)
		{
			if (this.TweenAnimMap == null)
			{
				return;
			}
			List<ULGUIPlayTweenComponent> list;
			if (!this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				return;
			}
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
			{
				ulguiplayTweenComponent.Play();
			}
		}

		// Token: 0x0603DF35 RID: 253749 RVA: 0x00FCE828 File Offset: 0x00FCCA28
		private void StopTweenAnim(int componentType)
		{
			if (this.TweenAnimMap == null)
			{
				return;
			}
			List<ULGUIPlayTweenComponent> list;
			if (!this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				return;
			}
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
			{
				ulguiplayTweenComponent.Stop();
			}
		}

		// Token: 0x0603DF36 RID: 253750 RVA: 0x00FCE890 File Offset: 0x00FCCA90
		public void RefreshLinkEffect()
		{
			if (ModelBase<BattleLinkModel>.Instance.CheckInDreamLink())
			{
				ELinkStatus linkStatus = ModelBase<BattleLinkModel>.Instance.GetLinkStatus();
				this.OnBattleLinkStatusChanged(linkStatus);
				return;
			}
			this.OnBattleLinkStatusChanged(ELinkStatus.None);
		}

		// Token: 0x0603DF37 RID: 253751 RVA: 0x00FCE8C4 File Offset: 0x00FCCAC4
		public void RefreshLinkActive(bool isActive, bool isExplosion = false)
		{
			if (this.LinkActive == isActive && this.IsInitLinkEffect)
			{
				return;
			}
			this.LinkActive = isActive;
			this.IsInitLinkEffect = true;
			UUIItem item = base.GetItem(20);
			if (item != null)
			{
				item.SetUIActive(isActive);
			}
			UUINiagara uiNiagara = base.GetUiNiagara(21);
			UUINiagara uiNiagara2 = base.GetUiNiagara(22);
			bool flag = isExplosion && isActive;
			bool flag2 = isActive && !flag;
			if (uiNiagara != null)
			{
				if (flag2)
				{
					uiNiagara.ActivateSystem(true);
				}
				else
				{
					uiNiagara.Deactivate();
				}
				uiNiagara.SetUIActive(flag2);
			}
			if (uiNiagara2 != null)
			{
				if (flag)
				{
					uiNiagara2.ActivateSystem(true);
				}
				else
				{
					uiNiagara2.Deactivate();
				}
				uiNiagara2.SetUIActive(flag);
			}
		}

		// Token: 0x0603DF38 RID: 253752 RVA: 0x00FCE960 File Offset: 0x00FCCB60
		private void OnBattleLinkStatusChanged(ELinkStatus state)
		{
			if (ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
			{
				this.RefreshLinkActive(false, false);
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
			if (worldEntity != null)
			{
				int id = worldEntity.Id;
				int? entityId = this.EntityId;
				if ((id == entityId.GetValueOrDefault() & entityId != null) && state != ELinkStatus.Explosion)
				{
					this.RefreshLinkActive(false, false);
					return;
				}
			}
			if (state == ELinkStatus.Ready)
			{
				this.RefreshLinkActive(true, false);
				return;
			}
			if (state == ELinkStatus.Link)
			{
				if (this.EntityId != null)
				{
					bool isActive = !ModelBase<BattleLinkModel>.Instance.HasLinkEntityId(this.EntityId.Value);
					this.RefreshLinkActive(isActive, false);
					return;
				}
				this.RefreshLinkActive(false, false);
				return;
			}
			else
			{
				if (state == ELinkStatus.Explosion)
				{
					this.RefreshLinkActive(true, true);
					return;
				}
				if (state == ELinkStatus.None)
				{
					this.RefreshLinkActive(false, false);
					return;
				}
				this.RefreshLinkActive(false, false);
				return;
			}
		}

		// Token: 0x0603DF39 RID: 253753 RVA: 0x00FCEA33 File Offset: 0x00FCCC33
		public void SetInvisibleByKeyList([Nullable(new byte[]
		{
			2,
			1
		})] List<string> keyList)
		{
			this.InvisibleKeyList = keyList;
			this.RefreshKeyItemNextTick();
		}

		// Token: 0x0603DF3A RID: 253754 RVA: 0x00FCEA42 File Offset: 0x00FCCC42
		private void RefreshKeyItemNextTick()
		{
			if (this.RefreshKeyItemTimer != null)
			{
				return;
			}
			this.RefreshKeyItemTimer = TimerSystem.Instance.Next(delegate(float _)
			{
				this.RefreshKeyItem();
				this.RefreshKeyItemTimer = null;
			}, null, null);
		}

		// Token: 0x04022BCE RID: 142286
		private const int REFRESH_COOLDOWN_INTERVAL = 100;

		// Token: 0x04022BCF RID: 142287
		private const int CURE_DELAY = 1000;

		// Token: 0x04022BD0 RID: 142288
		private const float LOW_HP_PERCENT = 0.2f;

		// Token: 0x04022BD1 RID: 142289
		private const int LEVE_UP_TIME = 5000;

		// Token: 0x04022BD2 RID: 142290
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap;

		// Token: 0x04022BD3 RID: 142291
		public int PrefabIndex;

		// Token: 0x04022BD4 RID: 142292
		public int PlayerId;

		// Token: 0x04022BD5 RID: 142293
		public bool IsMyRole;

		// Token: 0x04022BD6 RID: 142294
		public int RoleConfigId;

		// Token: 0x04022BD7 RID: 142295
		public int RoleSkinId;

		// Token: 0x04022BD8 RID: 142296
		public BattleUiRoleData RoleData;

		// Token: 0x04022BD9 RID: 142297
		public int? EntityId;

		// Token: 0x04022BDA RID: 142298
		public RoleInfo? RoleConfig;

		// Token: 0x04022BDB RID: 142299
		public RoleSkin? RoleSkinConfig;

		// Token: 0x04022BDC RID: 142300
		[Nullable(1)]
		private readonly List<ITagTask> TagSignificantChangedTaskList = new List<ITagTask>();

		// Token: 0x04022BDD RID: 142301
		private double CoolDownEndTime;

		// Token: 0x04022BDE RID: 142302
		private double CoolDownTime;

		// Token: 0x04022BDF RID: 142303
		private double LastRefreshTextCoolDownTime;

		// Token: 0x04022BE0 RID: 142304
		private TimerHandle CureDelayTimerId;

		// Token: 0x04022BE1 RID: 142305
		private EElementType? CurrentElementType;

		// Token: 0x04022BE2 RID: 142306
		private ElementInfo? CurrentElementInfo;

		// Token: 0x04022BE3 RID: 142307
		[Nullable(1)]
		private string CurrentSetUltimateColor = string.Empty;

		// Token: 0x04022BE4 RID: 142308
		private bool IsConcertoResponseOpen;

		// Token: 0x04022BE5 RID: 142309
		private TimerHandle ConcertoChangeTimerId;

		// Token: 0x04022BE6 RID: 142310
		private int ConcertoChangeEffectDelay;

		// Token: 0x04022BE7 RID: 142311
		private CombineKeyItem KeyItem;

		// Token: 0x04022BE8 RID: 142312
		private FormationLevelUpItem LevelUpComponent;

		// Token: 0x04022BE9 RID: 142313
		private FormationTrialItem TrialComponent;

		// Token: 0x04022BEA RID: 142314
		private FormationOnlineItem RoleHeadOnlineComponent;

		// Token: 0x04022BEB RID: 142315
		private bool IsAssistRole;

		// Token: 0x04022BEC RID: 142316
		private bool QteNiagaraActive;

		// Token: 0x04022BED RID: 142317
		private bool SelectedNiagaraActive;

		// Token: 0x04022BEE RID: 142318
		private bool LinkActive;

		// Token: 0x04022BEF RID: 142319
		private bool IsInitLinkEffect;

		// Token: 0x04022BF0 RID: 142320
		private bool RefreshCooldownExternalLock;

		// Token: 0x04022BF1 RID: 142321
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<string> InvisibleKeyList;

		// Token: 0x04022BF2 RID: 142322
		private TimerHandle RefreshKeyItemTimer;

		// Token: 0x0200C0A4 RID: 49316
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B4F4 RID: 242932
			FormationToggle,
			// Token: 0x0403B4F5 RID: 242933
			ChangeRoleCoolDownItem,
			// Token: 0x0403B4F6 RID: 242934
			ChangeRoleCoolDownBarTexture,
			// Token: 0x0403B4F7 RID: 242935
			ChangeRoleCoolDownText,
			// Token: 0x0403B4F8 RID: 242936
			CureItem,
			// Token: 0x0403B4F9 RID: 242937
			QTENiagara,
			// Token: 0x0403B4FA RID: 242938
			ConcertoChangeItem,
			// Token: 0x0403B4FB RID: 242939
			ConcertoChangeNiagara,
			// Token: 0x0403B4FC RID: 242940
			ConcertoChangeText,
			// Token: 0x0403B4FD RID: 242941
			RoleHeadTexture,
			// Token: 0x0403B4FE RID: 242942
			HpItem,
			// Token: 0x0403B4FF RID: 242943
			ShieldSprite,
			// Token: 0x0403B500 RID: 242944
			HpBarSprite,
			// Token: 0x0403B501 RID: 242945
			LowHpBarSprite,
			// Token: 0x0403B502 RID: 242946
			ConcertoItem,
			// Token: 0x0403B503 RID: 242947
			ElementTexture,
			// Token: 0x0403B504 RID: 242948
			ElementBarSprite,
			// Token: 0x0403B505 RID: 242949
			UltimateTag,
			// Token: 0x0403B506 RID: 242950
			AnimSelect,
			// Token: 0x0403B507 RID: 242951
			AnimSwitch,
			// Token: 0x0403B508 RID: 242952
			LinkItem,
			// Token: 0x0403B509 RID: 242953
			LinkNiagara,
			// Token: 0x0403B50A RID: 242954
			LinkExplosionNiagara,
			// Token: 0x0403B50B RID: 242955
			ExtraContainer,
			// Token: 0x0403B50C RID: 242956
			KeyItem
		}
	}
}
