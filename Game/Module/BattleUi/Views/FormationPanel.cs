using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkillButtonUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FA2 RID: 24482
	[NullableContext(1)]
	[Nullable(0)]
	public class FormationPanel : BattleChildViewPanel
	{
		// Token: 0x0603D7EB RID: 251883 RVA: 0x00FA6AE8 File Offset: 0x00FA4CE8
		public override UniTask InitializeAsync()
		{
			FormationPanel.<InitializeAsync>d__12 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<FormationPanel.<InitializeAsync>d__12>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D7EC RID: 251884 RVA: 0x00FA6B2B File Offset: 0x00FA4D2B
		public void SetIsGamepad()
		{
			this.IsGamepad = true;
			base.SetVisible(EBattleUiVisibleReason.Gamepad, Singleton<Info>.Instance.IsInGamepad() == this.IsGamepad);
		}

		// Token: 0x0603D7ED RID: 251885 RVA: 0x00FA6B50 File Offset: 0x00FA4D50
		public override void Reset()
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				formationItem.ResetItem();
			}
			this.FormationItemList.Clear();
			GuestItem guest = this.Guest;
			if (guest != null)
			{
				guest.Destroy(null);
			}
			this.Guest = null;
			this.FormationHeadIconEnergyBar.Destroy();
			base.Reset();
		}

		// Token: 0x0603D7EE RID: 251886 RVA: 0x00FA6BD8 File Offset: 0x00FA4DD8
		protected unsafe override void OnRegisterComponent()
		{
			EOperationType operationType = base.GetOperationType();
			if (operationType == EOperationType.Desktop)
			{
				int num = 4;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
				this.ComponentRegisterInfos = list;
				if (Singleton<Info>.Instance.IsInGamepad())
				{
					this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout)));
					return;
				}
			}
			else if (operationType == EOperationType.Pad)
			{
				int num2 = 4;
				List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
				int num = 0;
				*span[num] = new ValueTuple<int, Type>(0, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(1, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(2, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
				this.ComponentRegisterInfos = list2;
			}
		}

		// Token: 0x0603D7EF RID: 251887 RVA: 0x00FA6D64 File Offset: 0x00FA4F64
		public override void OnTickBattleChildViewPanel(float delta)
		{
			if (!this.Visible)
			{
				return;
			}
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				formationItem.OnTick(delta);
			}
			this.FormationHeadIconEnergyBar.Tick(delta);
		}

		// Token: 0x0603D7F0 RID: 251888 RVA: 0x00FA6DCC File Offset: 0x00FA4FCC
		protected override void OnShowBattleChildViewPanel(bool isFirst)
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				formationItem.RefreshCoolDownOnShow();
			}
			this.OnRefreshGuest();
		}

		// Token: 0x0603D7F1 RID: 251889 RVA: 0x00FA6E24 File Offset: 0x00FA5024
		private UniTask NewFormationItemAsync(AActor rootActor, FormationPanel.EPosition position)
		{
			FormationPanel.<NewFormationItemAsync>d__18 <NewFormationItemAsync>d__;
			<NewFormationItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewFormationItemAsync>d__.<>4__this = this;
			<NewFormationItemAsync>d__.rootActor = rootActor;
			<NewFormationItemAsync>d__.position = position;
			<NewFormationItemAsync>d__.<>1__state = -1;
			<NewFormationItemAsync>d__.<>t__builder.Start<FormationPanel.<NewFormationItemAsync>d__18>(ref <NewFormationItemAsync>d__);
			return <NewFormationItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D7F2 RID: 251890 RVA: 0x00FA6E78 File Offset: 0x00FA5078
		private UniTask ActivateAllFormationItems()
		{
			FormationPanel.<ActivateAllFormationItems>d__19 <ActivateAllFormationItems>d__;
			<ActivateAllFormationItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ActivateAllFormationItems>d__.<>4__this = this;
			<ActivateAllFormationItems>d__.<>1__state = -1;
			<ActivateAllFormationItems>d__.<>t__builder.Start<FormationPanel.<ActivateAllFormationItems>d__19>(ref <ActivateAllFormationItems>d__);
			return <ActivateAllFormationItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603D7F3 RID: 251891 RVA: 0x00FA6EBC File Offset: 0x00FA50BC
		private UniTask ResetFormationItemAsync()
		{
			FormationPanel.<ResetFormationItemAsync>d__20 <ResetFormationItemAsync>d__;
			<ResetFormationItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResetFormationItemAsync>d__.<>4__this = this;
			<ResetFormationItemAsync>d__.<>1__state = -1;
			<ResetFormationItemAsync>d__.<>t__builder.Start<FormationPanel.<ResetFormationItemAsync>d__20>(ref <ResetFormationItemAsync>d__);
			return <ResetFormationItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D7F4 RID: 251892 RVA: 0x00FA6F00 File Offset: 0x00FA5100
		[NullableContext(2)]
		private FormationItem GetFormationItemByConfigId(int configId)
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				if (formationItem.RoleConfigId == configId)
				{
					return formationItem;
				}
			}
			return null;
		}

		// Token: 0x0603D7F5 RID: 251893 RVA: 0x00FA6F5C File Offset: 0x00FA515C
		[NullableContext(2)]
		private FormationItem GetFormationItemByEntityId(int entityId)
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				int? entityId2 = formationItem.EntityId;
				if (entityId2.GetValueOrDefault() == entityId & entityId2 != null)
				{
					return formationItem;
				}
			}
			return null;
		}

		// Token: 0x0603D7F6 RID: 251894 RVA: 0x00FA6FD0 File Offset: 0x00FA51D0
		public List<FormationItem> GetFormationItemList()
		{
			return this.FormationItemList;
		}

		// Token: 0x0603D7F7 RID: 251895 RVA: 0x00FA6FD8 File Offset: 0x00FA51D8
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangedRoleCompleted));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangedRoleNextTick));
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiAllRoleDataChanged, new Action(this.OnFormationLoadCompleted));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.CharExecuteMultiQte, new Action<int, int>(this.OnExecuteMultiQte));
			Singleton<EventSystem>.Instance.Add(EEventName.FormationPanelUIShowRoleHeal, new Action<Entity>(this.OnRoleCure));
			Singleton<EventSystem>.Instance.Add(EEventName.CharOnRoleDead, new Action<int>(this.OnRoleDead));
			Singleton<EventSystem>.Instance.Add(EEventName.OnFormationPlayLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
			Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			Singleton<EventSystem>.Instance.Add(EEventName.RoleRefreshName, new Action(this.OnRoleRefreshName));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshRoleHp, new Action(this.UpdateRoleHp));
			Singleton<EventSystem>.Instance.Add(EEventName.OnConcertoResponseOpen, new Action<bool>(this.OnConcertoResponseOpen));
			Singleton<EventSystem>.Instance.Add<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnTextLanguageChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshPlayerPing, new Action<int, ENetPingState>(this.OnRefreshPlayerPing));
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnOtherChangeRole, new Action<EntityHandle, EntityHandle>(this.OnOtherChangeRole));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Add(EEventName.RefreshGuest, new Action(this.OnRefreshGuest));
			if (base.GetOperationType() == EOperationType.Desktop)
			{
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnPressMotorcycleCombineButtonChanged));
			}
		}

		// Token: 0x0603D7F8 RID: 251896 RVA: 0x00FA71C4 File Offset: 0x00FA53C4
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangedRoleCompleted));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangedRoleNextTick));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiAllRoleDataChanged, new Action(this.OnFormationLoadCompleted));
			Singleton<EventSystem>.Instance.Remove(EEventName.CharExecuteMultiQte, new Action<int, int>(this.OnExecuteMultiQte));
			Singleton<EventSystem>.Instance.Remove(EEventName.FormationPanelUIShowRoleHeal, new Action<Entity>(this.OnRoleCure));
			Singleton<EventSystem>.Instance.Remove(EEventName.CharOnRoleDead, new Action<int>(this.OnRoleDead));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFormationPlayLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
			Singleton<EventSystem>.Instance.Remove(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoleRefreshName, new Action(this.OnRoleRefreshName));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshRoleHp, new Action(this.UpdateRoleHp));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnConcertoResponseOpen, new Action<bool>(this.OnConcertoResponseOpen));
			Singleton<EventSystem>.Instance.Remove(EEventName.TextLanguageChange, new Action<string, string>(this.OnTextLanguageChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshPlayerPing, new Action<int, ENetPingState>(this.OnRefreshPlayerPing));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnOtherChangeRole, new Action<EntityHandle, EntityHandle>(this.OnOtherChangeRole));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGuest, new Action(this.OnRefreshGuest));
			if (base.GetOperationType() == EOperationType.Desktop)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnPressMotorcycleCombineButtonChanged));
			}
		}

		// Token: 0x0603D7F9 RID: 251897 RVA: 0x00FA73B0 File Offset: 0x00FA55B0
		private void OnChangedRoleCompleted(int newEntityId, int oldEntityId)
		{
			this.ChangeList.Add(new ValueTuple<int, int>(newEntityId, oldEntityId));
		}

		// Token: 0x0603D7FA RID: 251898 RVA: 0x00FA73C4 File Offset: 0x00FA55C4
		private void OnChangedRoleNextTick(int i, int i1)
		{
			if (this.ChangeList.Count <= 0)
			{
				return;
			}
			EOperationType operationType = base.GetOperationType();
			foreach (ValueTuple<int, int> valueTuple in this.ChangeList)
			{
				if (operationType == EOperationType.Desktop)
				{
					this.OnDesktopChangedRoleCompleted(valueTuple.Item1, valueTuple.Item2);
				}
				else if (operationType == EOperationType.Pad)
				{
					this.OnPadChangedRoleCompleted(valueTuple.Item1, valueTuple.Item2);
				}
			}
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				formationItem.RefreshQteActive();
			}
			this.ChangeList.Clear();
		}

		// Token: 0x0603D7FB RID: 251899 RVA: 0x00FA74A0 File Offset: 0x00FA56A0
		private void OnDesktopChangedRoleCompleted(int newEntityId, int oldEntityId)
		{
			BattleUiRoleData roleData = ModelBase<BattleUiModel>.Instance.GetRoleData(newEntityId);
			FormationItem formationItemByEntityId = this.GetFormationItemByEntityId(this.CurEntityId.Value);
			this.FormationHeadIconEnergyBar.RefreshVisible(this.CurEntityId.Value, false, (formationItemByEntityId != null) ? formationItemByEntityId.PrefabIndex : -1);
			this.CurEntityId = new int?(newEntityId);
			FormationItem formationItemByEntityId2 = this.GetFormationItemByEntityId(this.CurEntityId.Value);
			if (formationItemByEntityId != null)
			{
				formationItemByEntityId.RefreshSelectedRole();
			}
			if (formationItemByEntityId2 == null)
			{
				return;
			}
			formationItemByEntityId2.RefreshSelectedRole();
			this.FormationHeadIconEnergyBar.RefreshVisible(this.CurEntityId.Value, true, -1);
			BattleUiRoleData roleData2 = ModelBase<BattleUiModel>.Instance.GetRoleData(oldEntityId);
			if (roleData2 != null && roleData != null && roleData.GameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.CD"]))
			{
				formationItemByEntityId2.ActivateConcertoChangeEffect((int)roleData.ElementType.Value, (int)roleData2.ElementType.Value);
			}
		}

		// Token: 0x0603D7FC RID: 251900 RVA: 0x00FA7584 File Offset: 0x00FA5784
		private void OnPadChangedRoleCompleted(int newEntityId, int oldEntityId)
		{
			BattleUiRoleData roleData = ModelBase<BattleUiModel>.Instance.GetRoleData(oldEntityId);
			BattleUiRoleData roleData2 = ModelBase<BattleUiModel>.Instance.GetRoleData(newEntityId);
			this.CurEntityId = new int?(newEntityId);
			if (this.CurEntityId == null)
			{
				return;
			}
			FormationItem formationItemByEntityId = this.GetFormationItemByEntityId(this.CurEntityId.Value);
			if (formationItemByEntityId == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.CFT, "角色上场时找不到之前的头像", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (roleData != null)
			{
				int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
				formationItemByEntityId.Refresh(valueOrDefault, roleData.CreatureRoleId, roleData.CreatureSkinId.GetValueOrDefault(), roleData);
				this.FormationHeadIconEnergyBar.RefreshVisible(oldEntityId, false, formationItemByEntityId.PrefabIndex);
				this.FormationHeadIconEnergyBar.RefreshVisible(newEntityId, true, formationItemByEntityId.PrefabIndex);
			}
			else
			{
				Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.LYY, "角色上场时找不到下场角色数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				formationItemByEntityId.ResetItem();
			}
			if (roleData != null && roleData2 != null && roleData2.GameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.CD"]))
			{
				formationItemByEntityId.ActivateConcertoChangeEffect((int)roleData2.ElementType.Value, (int)roleData.ElementType.Value);
			}
		}

		// Token: 0x0603D7FD RID: 251901 RVA: 0x00FA76AF File Offset: 0x00FA58AF
		private void OnFormationLoadCompleted()
		{
			if (ModelBase<SceneTeamModel>.Instance.IsSeamlessUpdateTeam)
			{
				return;
			}
			this.ActivateAllFormationItems().Forget();
			this.OnRefreshGuest();
			this.ChangeList.Clear();
		}

		// Token: 0x0603D7FE RID: 251902 RVA: 0x00FA76DA File Offset: 0x00FA58DA
		private void OnExecuteMultiQte(int entityId, int goDownEntityId)
		{
			FormationItem formationItemByEntityId = this.GetFormationItemByEntityId(goDownEntityId);
			if (formationItemByEntityId == null)
			{
				return;
			}
			formationItemByEntityId.ActivateConcertoChangeEffect(0, 0);
		}

		// Token: 0x0603D7FF RID: 251903 RVA: 0x00FA76EF File Offset: 0x00FA58EF
		private void OnRoleCure(Entity target)
		{
			FormationItem formationItemByEntityId = this.GetFormationItemByEntityId(target.Id);
			if (formationItemByEntityId == null)
			{
				return;
			}
			formationItemByEntityId.CureRole();
		}

		// Token: 0x0603D800 RID: 251904 RVA: 0x00FA7707 File Offset: 0x00FA5907
		private void OnRoleDead(int entityId)
		{
			FormationItem formationItemByEntityId = this.GetFormationItemByEntityId(entityId);
			if (formationItemByEntityId == null)
			{
				return;
			}
			formationItemByEntityId.RefreshRoleHealthPercent();
		}

		// Token: 0x0603D801 RID: 251905 RVA: 0x00FA771A File Offset: 0x00FA591A
		private void OnRoleLevelUp(int configId, int exp, int level)
		{
			FormationItem formationItemByConfigId = this.GetFormationItemByConfigId(configId);
			if (formationItemByConfigId == null)
			{
				return;
			}
			formationItemByConfigId.LevelUp(level);
		}

		// Token: 0x0603D802 RID: 251906 RVA: 0x00FA772E File Offset: 0x00FA592E
		private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			FormationItem formationItemByEntityId = this.GetFormationItemByEntityId(handle.Id);
			if (formationItemByEntityId != null)
			{
				formationItemByEntityId.ClearData();
			}
			this.FormationHeadIconEnergyBar.RemoveEntity(handle.Id);
		}

		// Token: 0x0603D803 RID: 251907 RVA: 0x00FA7758 File Offset: 0x00FA5958
		private void OnRoleRefreshName()
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				formationItem.RefreshRoleName();
			}
		}

		// Token: 0x0603D804 RID: 251908 RVA: 0x00FA77A8 File Offset: 0x00FA59A8
		private void UpdateRoleHp()
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				formationItem.RefreshRoleHealthPercent();
			}
		}

		// Token: 0x0603D805 RID: 251909 RVA: 0x00FA77F8 File Offset: 0x00FA59F8
		private void OnConcertoResponseOpen(bool isOpen)
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				formationItem.RefreshConcertoResponseModule(isOpen);
			}
		}

		// Token: 0x0603D806 RID: 251910 RVA: 0x00FA784C File Offset: 0x00FA5A4C
		private void OnTextLanguageChange(string s, string s1)
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				formationItem.RefreshRoleName();
			}
		}

		// Token: 0x0603D807 RID: 251911 RVA: 0x00FA789C File Offset: 0x00FA5A9C
		private void OnRefreshPlayerPing(int playerId, ENetPingState ping)
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				if (formationItem.PlayerId == playerId)
				{
					formationItem.RefreshPlayerPingState(ping);
				}
			}
		}

		// Token: 0x0603D808 RID: 251912 RVA: 0x00FA78F8 File Offset: 0x00FA5AF8
		private void OnOtherChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				if (!formationItem.IsMyRole)
				{
					formationItem.RefreshOnlineItem();
				}
			}
		}

		// Token: 0x0603D809 RID: 251913 RVA: 0x00FA7954 File Offset: 0x00FA5B54
		private void InputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			base.SetVisible(EBattleUiVisibleReason.Gamepad, Singleton<Info>.Instance.IsInGamepad() == this.IsGamepad);
		}

		// Token: 0x0603D80A RID: 251914 RVA: 0x00FA796F File Offset: 0x00FA5B6F
		public void RefreshOnDelayShow()
		{
		}

		// Token: 0x0603D80B RID: 251915 RVA: 0x00FA7974 File Offset: 0x00FA5B74
		public void RefreshFormationCooldownExternal(int playerId, int roleId, float? remainCd, float? totalCd)
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				if (playerId == formationItem.PlayerId && (roleId == formationItem.RoleConfigId || roleId == 0))
				{
					formationItem.RefreshCoolDownExternal(remainCd, totalCd);
				}
			}
		}

		// Token: 0x0603D80C RID: 251916 RVA: 0x00FA79E0 File Offset: 0x00FA5BE0
		public void ResetFormationCooldownExternal()
		{
			foreach (FormationItem formationItem in this.FormationItemList)
			{
				formationItem.RefreshCoolDownExternal(new float?(0f), new float?(0f));
			}
		}

		// Token: 0x0603D80D RID: 251917 RVA: 0x00FA7A44 File Offset: 0x00FA5C44
		private void OnRefreshGuest()
		{
			if (this.IsOperating)
			{
				this.NeedFresh = true;
				return;
			}
			int guestId = ModelBase<BattleUiModel>.Instance.GuestId;
			this.IsOperating = true;
			if (guestId != 0)
			{
				this.SetGuest(guestId).ContinueWith(new Action(this.OnAfterRefresh)).Forget();
				return;
			}
			this.RemoveGuest().ContinueWith(new Action(this.OnAfterRefresh)).Forget();
		}

		// Token: 0x0603D80E RID: 251918 RVA: 0x00FA7AB0 File Offset: 0x00FA5CB0
		private void OnAfterRefresh()
		{
			this.IsOperating = false;
			if (this.NeedFresh)
			{
				this.NeedFresh = false;
				this.OnRefreshGuest();
			}
		}

		// Token: 0x0603D80F RID: 251919 RVA: 0x00FA7AD0 File Offset: 0x00FA5CD0
		private UniTask SetGuest(int id)
		{
			FormationPanel.<SetGuest>d__52 <SetGuest>d__;
			<SetGuest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetGuest>d__.<>4__this = this;
			<SetGuest>d__.id = id;
			<SetGuest>d__.<>1__state = -1;
			<SetGuest>d__.<>t__builder.Start<FormationPanel.<SetGuest>d__52>(ref <SetGuest>d__);
			return <SetGuest>d__.<>t__builder.Task;
		}

		// Token: 0x0603D810 RID: 251920 RVA: 0x00FA7B1C File Offset: 0x00FA5D1C
		private UniTask RemoveGuest()
		{
			FormationPanel.<RemoveGuest>d__53 <RemoveGuest>d__;
			<RemoveGuest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RemoveGuest>d__.<>4__this = this;
			<RemoveGuest>d__.<>1__state = -1;
			<RemoveGuest>d__.<>t__builder.Start<FormationPanel.<RemoveGuest>d__53>(ref <RemoveGuest>d__);
			return <RemoveGuest>d__.<>t__builder.Task;
		}

		// Token: 0x0603D811 RID: 251921 RVA: 0x00FA7B5F File Offset: 0x00FA5D5F
		private void OnPressMotorcycleCombineButtonChanged(bool b)
		{
			this.RefreshKeyItemEnableInMotorcycle();
		}

		// Token: 0x0603D812 RID: 251922 RVA: 0x00FA7B68 File Offset: 0x00FA5D68
		public void RefreshKeyItemEnableInMotorcycle()
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
			if (motorcycleData == null || !motorcycleData.IsDriving)
			{
				return;
			}
			SkillButtonUiMotorcycleGamepadData skillButtonUiMotorcycleGamepadData = ModelBase<SkillButtonUiModel>.Instance.GetGamepadDataByType(ESkillButtonGamepadDataType.Motorcycle) as SkillButtonUiMotorcycleGamepadData;
			if (skillButtonUiMotorcycleGamepadData != null && skillButtonUiMotorcycleGamepadData.GetIsPressCombineButton())
			{
				using (List<FormationItem>.Enumerator enumerator = this.FormationItemList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						FormationItem formationItem = enumerator.Current;
						formationItem.SetInvisibleByKeyList(skillButtonUiMotorcycleGamepadData.MusicSubKeyList);
					}
					return;
				}
			}
			foreach (FormationItem formationItem2 in this.FormationItemList)
			{
				formationItem2.SetInvisibleByKeyList(null);
			}
		}

		// Token: 0x0603D813 RID: 251923 RVA: 0x00FA7C44 File Offset: 0x00FA5E44
		public void AddChildToRoleHeadPanel(UUIItem child)
		{
			EOperationType operationType = base.GetOperationType();
			if (operationType != EOperationType.Desktop)
			{
				if (operationType == EOperationType.Pad)
				{
					UUIVerticalLayout verticalLayout = base.GetVerticalLayout(3);
					child.SetUIParent(verticalLayout.RootUIComp, false);
					child.SetAsLastHierarchy();
				}
				return;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				UUIVerticalLayout verticalLayout2 = base.GetVerticalLayout(4);
				child.SetUIParent(verticalLayout2.RootUIComp, false);
				child.SetAsLastHierarchy();
				return;
			}
			UUIItem rootItem = base.GetRootItem();
			child.SetUIParent(rootItem, false);
			child.SetAsLastHierarchy();
		}

		// Token: 0x040228C3 RID: 141507
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject = Stat.Create("[BattleView]FormationPanelTick", "", "");

		// Token: 0x040228C4 RID: 141508
		[StaticVariableRuleIgnore]
		private static readonly Stat ChangeRoleStat = Stat.Create("[ChangeRole]FormationPanel", "", "");

		// Token: 0x040228C5 RID: 141509
		private const string GUEST_RESOURCE_ID = "FightRoleHeadGuest";

		// Token: 0x040228C6 RID: 141510
		private readonly List<FormationItem> FormationItemList = new List<FormationItem>();

		// Token: 0x040228C7 RID: 141511
		private bool IsUpdatingFormationItem;

		// Token: 0x040228C8 RID: 141512
		private bool IsGamepad;

		// Token: 0x040228C9 RID: 141513
		private int? CurEntityId = new int?(0);

		// Token: 0x040228CA RID: 141514
		[TupleElementNames(new string[]
		{
			"newEntityId",
			"oldEntityId"
		})]
		[Nullable(new byte[]
		{
			1,
			0
		})]
		private readonly List<ValueTuple<int, int>> ChangeList = new List<ValueTuple<int, int>>();

		// Token: 0x040228CB RID: 141515
		private readonly FormationHeadIconEnergyBar FormationHeadIconEnergyBar = new FormationHeadIconEnergyBar();

		// Token: 0x040228CC RID: 141516
		[Nullable(2)]
		private GuestItem Guest;

		// Token: 0x040228CD RID: 141517
		private int GuestId;

		// Token: 0x040228CE RID: 141518
		private bool NeedFresh;

		// Token: 0x040228CF RID: 141519
		private bool IsOperating;

		// Token: 0x0200BFA6 RID: 49062
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403AFD3 RID: 241619
			FormationChildItem1,
			// Token: 0x0403AFD4 RID: 241620
			FormationChildItem2,
			// Token: 0x0403AFD5 RID: 241621
			FormationChildItem3,
			// Token: 0x0403AFD6 RID: 241622
			FormationChildItem4,
			// Token: 0x0403AFD7 RID: 241623
			Layout
		}

		// Token: 0x0200BFA7 RID: 49063
		[NullableContext(0)]
		private enum EPadType
		{
			// Token: 0x0403AFD9 RID: 241625
			Layout = 3
		}

		// Token: 0x0200BFA8 RID: 49064
		[NullableContext(0)]
		private enum EPosition
		{
			// Token: 0x0403AFDB RID: 241627
			OnePlayer,
			// Token: 0x0403AFDC RID: 241628
			TwoPlayer,
			// Token: 0x0403AFDD RID: 241629
			ThreePlayer,
			// Token: 0x0403AFDE RID: 241630
			FourPlayer
		}
	}
}
