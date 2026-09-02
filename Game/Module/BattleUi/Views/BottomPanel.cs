using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F9D RID: 24477
	[NullableContext(2)]
	[Nullable(0)]
	public class BottomPanel : BattleChildViewPanel
	{
		// Token: 0x0603D75D RID: 251741 RVA: 0x00FA38B8 File Offset: 0x00FA1AB8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D75E RID: 251742 RVA: 0x00FA39C8 File Offset: 0x00FA1BC8
		public override UniTask InitializeAsync()
		{
			BottomPanel.<InitializeAsync>d__18 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<BottomPanel.<InitializeAsync>d__18>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D75F RID: 251743 RVA: 0x00FA3A0B File Offset: 0x00FA1C0B
		private void RefreshBuffView(BattleUiRoleData roleData)
		{
			this.RoleBuffView.Refresh(roleData);
			this.RoleUniqueBuffView.Refresh(roleData);
		}

		// Token: 0x0603D760 RID: 251744 RVA: 0x00FA3A28 File Offset: 0x00FA1C28
		private void OnSeamlessTravelRefresh()
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			this.RefreshBuffView(curRoleData);
		}

		// Token: 0x0603D761 RID: 251745 RVA: 0x00FA3A48 File Offset: 0x00FA1C48
		public override void Reset()
		{
			this.RoleStateView = null;
			this.ConcertoResponseItem = null;
			this.RoleBuffView = null;
			this.SpecialEnergyBarContainer = null;
			this.RoleUniqueBuffView = null;
			this.BossBuffNumItem = null;
			this.PendingBossBuffCues.Clear();
			this.SetFishingStateViewActive(false);
			base.Reset();
		}

		// Token: 0x0603D762 RID: 251746 RVA: 0x00FA3A97 File Offset: 0x00FA1C97
		protected override void OnShowBattleChildViewPanel(bool isFirst)
		{
			RoleStateView roleStateView = this.RoleStateView;
			if (roleStateView == null)
			{
				return;
			}
			roleStateView.SetNiagaraActive(false);
		}

		// Token: 0x0603D763 RID: 251747 RVA: 0x00FA3AAC File Offset: 0x00FA1CAC
		public override void OnTickBattleChildViewPanel(float delta)
		{
			RoleStateView roleStateView = this.RoleStateView;
			if (roleStateView != null)
			{
				roleStateView.Tick(delta);
			}
			RoleBuffView roleBuffView = this.RoleBuffView;
			if (roleBuffView != null)
			{
				roleBuffView.Tick(delta);
			}
			SpecialEnergyBarContainer specialEnergyBarContainer = this.SpecialEnergyBarContainer;
			if (specialEnergyBarContainer != null)
			{
				specialEnergyBarContainer.Tick(delta);
			}
			RoleUniqueBuffView roleUniqueBuffView = this.RoleUniqueBuffView;
			if (roleUniqueBuffView != null)
			{
				roleUniqueBuffView.Tick(delta);
			}
			BossBuffNumItem bossBuffNumItem = this.BossBuffNumItem;
			if (bossBuffNumItem == null)
			{
				return;
			}
			bossBuffNumItem.Tick(delta);
		}

		// Token: 0x0603D764 RID: 251748 RVA: 0x00FA3B14 File Offset: 0x00FA1D14
		private UniTask NewRoleStateViewAsync()
		{
			BottomPanel.<NewRoleStateViewAsync>d__24 <NewRoleStateViewAsync>d__;
			<NewRoleStateViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewRoleStateViewAsync>d__.<>4__this = this;
			<NewRoleStateViewAsync>d__.<>1__state = -1;
			<NewRoleStateViewAsync>d__.<>t__builder.Start<BottomPanel.<NewRoleStateViewAsync>d__24>(ref <NewRoleStateViewAsync>d__);
			return <NewRoleStateViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D765 RID: 251749 RVA: 0x00FA3B58 File Offset: 0x00FA1D58
		private UniTask NewElementBallItemAsync()
		{
			BottomPanel.<NewElementBallItemAsync>d__25 <NewElementBallItemAsync>d__;
			<NewElementBallItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewElementBallItemAsync>d__.<>4__this = this;
			<NewElementBallItemAsync>d__.<>1__state = -1;
			<NewElementBallItemAsync>d__.<>t__builder.Start<BottomPanel.<NewElementBallItemAsync>d__25>(ref <NewElementBallItemAsync>d__);
			return <NewElementBallItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D766 RID: 251750 RVA: 0x00FA3B9C File Offset: 0x00FA1D9C
		private UniTask NewRoleBuffViewAsync()
		{
			BottomPanel.<NewRoleBuffViewAsync>d__26 <NewRoleBuffViewAsync>d__;
			<NewRoleBuffViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewRoleBuffViewAsync>d__.<>4__this = this;
			<NewRoleBuffViewAsync>d__.<>1__state = -1;
			<NewRoleBuffViewAsync>d__.<>t__builder.Start<BottomPanel.<NewRoleBuffViewAsync>d__26>(ref <NewRoleBuffViewAsync>d__);
			return <NewRoleBuffViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D767 RID: 251751 RVA: 0x00FA3BE0 File Offset: 0x00FA1DE0
		private UniTask NewSpecialEnergyBarAsync()
		{
			BottomPanel.<NewSpecialEnergyBarAsync>d__27 <NewSpecialEnergyBarAsync>d__;
			<NewSpecialEnergyBarAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewSpecialEnergyBarAsync>d__.<>4__this = this;
			<NewSpecialEnergyBarAsync>d__.<>1__state = -1;
			<NewSpecialEnergyBarAsync>d__.<>t__builder.Start<BottomPanel.<NewSpecialEnergyBarAsync>d__27>(ref <NewSpecialEnergyBarAsync>d__);
			return <NewSpecialEnergyBarAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D768 RID: 251752 RVA: 0x00FA3C24 File Offset: 0x00FA1E24
		private UniTask NewRoleTopBuffViewAsync()
		{
			BottomPanel.<NewRoleTopBuffViewAsync>d__28 <NewRoleTopBuffViewAsync>d__;
			<NewRoleTopBuffViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewRoleTopBuffViewAsync>d__.<>4__this = this;
			<NewRoleTopBuffViewAsync>d__.<>1__state = -1;
			<NewRoleTopBuffViewAsync>d__.<>t__builder.Start<BottomPanel.<NewRoleTopBuffViewAsync>d__28>(ref <NewRoleTopBuffViewAsync>d__);
			return <NewRoleTopBuffViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D769 RID: 251753 RVA: 0x00FA3C68 File Offset: 0x00FA1E68
		private UniTask NewHonamiStoryViewAsync()
		{
			BottomPanel.<NewHonamiStoryViewAsync>d__29 <NewHonamiStoryViewAsync>d__;
			<NewHonamiStoryViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewHonamiStoryViewAsync>d__.<>4__this = this;
			<NewHonamiStoryViewAsync>d__.<>1__state = -1;
			<NewHonamiStoryViewAsync>d__.<>t__builder.Start<BottomPanel.<NewHonamiStoryViewAsync>d__29>(ref <NewHonamiStoryViewAsync>d__);
			return <NewHonamiStoryViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D76A RID: 251754 RVA: 0x00FA3CAC File Offset: 0x00FA1EAC
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiEnergyBarVisible, new Action<bool>(this.OnEnergyBarVisibleChange));
			Singleton<EventSystem>.Instance.Add<Entity>(EEventName.BattleUiRemoveRoleData, new Action<Entity>(this.OnRemoveEntity));
			Singleton<EventSystem>.Instance.Add(EEventName.CharOnBuffAddUITexture, new Action<int, GameplayCue, bool, int>(this.OnAddOrRemoveBuff));
			Singleton<EventSystem>.Instance.Add(EEventName.OnServerAttributeChange, new Action<int, AttributeChangedNotify>(this.OnServerAttributeChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnConcertoResponseOpen, new Action<bool>(this.OnConcertoResponseOpen));
			Singleton<EventSystem>.Instance.Add(EEventName.DriveFishingShipStateChanged, new Action<bool>(this.OnDriveFishingShipStateChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMoraleActiveChanged, new Action<bool>(this.OnMoraleActiveChanged));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnFlagChallengeDungeonActiveChanged, new Action<bool>(this.OnFlagChallengeDungeonActiveChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.SeamlessTravelUIRefresh, new Action(this.OnSeamlessTravelRefresh));
		}

		// Token: 0x0603D76B RID: 251755 RVA: 0x00FA3DF0 File Offset: 0x00FA1FF0
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiEnergyBarVisible, new Action<bool>(this.OnEnergyBarVisibleChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiRemoveRoleData, new Action<Entity>(this.OnRemoveEntity));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnServerAttributeChange, new Action<int, AttributeChangedNotify>(this.OnServerAttributeChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.CharOnBuffAddUITexture, new Action<int, GameplayCue, bool, int>(this.OnAddOrRemoveBuff));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnConcertoResponseOpen, new Action<bool>(this.OnConcertoResponseOpen));
			Singleton<EventSystem>.Instance.Remove(EEventName.DriveFishingShipStateChanged, new Action<bool>(this.OnDriveFishingShipStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMoraleActiveChanged, new Action<bool>(this.OnMoraleActiveChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeDungeonActiveChanged, new Action<bool>(this.OnFlagChallengeDungeonActiveChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.SeamlessTravelUIRefresh, new Action(this.OnSeamlessTravelRefresh));
		}

		// Token: 0x0603D76C RID: 251756 RVA: 0x00FA3F31 File Offset: 0x00FA2131
		private void OnConcertoResponseOpen(bool isOpen)
		{
			ConcertoResponseItem concertoResponseItem = this.ConcertoResponseItem;
			if (concertoResponseItem == null)
			{
				return;
			}
			concertoResponseItem.RefreshVisible();
		}

		// Token: 0x0603D76D RID: 251757 RVA: 0x00FA3F44 File Offset: 0x00FA2144
		private void OnChangeRole(int i, int i1)
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData == null)
			{
				return;
			}
			if (curRoleData.IsPhantom() && curRoleData.RoleConfig.Value.SpecialEnergyBarId > 0 && curRoleData.MorphShowSpecialEnergyBar)
			{
				this.RoleStateView.Refresh(null);
				this.ConcertoResponseItem.Refresh(null);
			}
			else
			{
				this.RoleStateView.Refresh(curRoleData);
				this.ConcertoResponseItem.Refresh(curRoleData);
			}
			this.SpecialEnergyBarContainer.OnChangeRole(curRoleData.MorphShowSpecialEnergyBar ? curRoleData : null);
			this.RefreshBuffView(curRoleData);
		}

		// Token: 0x0603D76E RID: 251758 RVA: 0x00FA3FD8 File Offset: 0x00FA21D8
		private void OnEnergyBarVisibleChange(bool visible)
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData == null)
			{
				return;
			}
			if (curRoleData.IsPhantom() && !visible)
			{
				this.RoleStateView.Refresh(null);
				this.ConcertoResponseItem.Refresh(null);
			}
			else
			{
				this.RoleStateView.Refresh(curRoleData);
				this.ConcertoResponseItem.Refresh(curRoleData);
			}
			this.SpecialEnergyBarContainer.OnChangeRole(visible ? curRoleData : null);
		}

		// Token: 0x0603D76F RID: 251759 RVA: 0x00FA4044 File Offset: 0x00FA2244
		[NullableContext(1)]
		private void OnRemoveEntity(Entity entity)
		{
			int? entityId = this.RoleStateView.GetEntityId();
			int id = entity.Id;
			if (entityId.GetValueOrDefault() == id & entityId != null)
			{
				this.RoleStateView.Refresh(null);
			}
			entityId = this.ConcertoResponseItem.GetEntityId();
			id = entity.Id;
			if (entityId.GetValueOrDefault() == id & entityId != null)
			{
				this.ConcertoResponseItem.Refresh(null);
			}
			entityId = this.RoleBuffView.GetEntityId();
			id = entity.Id;
			if (entityId.GetValueOrDefault() == id & entityId != null)
			{
				this.RefreshBuffView(null);
			}
			this.RoleUniqueBuffView.OnRemoveEntity(entity.Id);
			this.SpecialEnergyBarContainer.OnRemoveEntity(entity.Id);
		}

		// Token: 0x0603D770 RID: 251760 RVA: 0x00FA4108 File Offset: 0x00FA2308
		[NullableContext(1)]
		private void OnServerAttributeChange(int entityId, AttributeChangedNotify attributeData)
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid || attributeData == null)
			{
				return;
			}
			if (getCurrentEntity.Id != entityId)
			{
				return;
			}
			using (IEnumerator<GameplayAttributeData> enumerator = attributeData.Attributes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.AttributeType == 3)
					{
						this.RoleStateView.RefreshHpAndShield(true);
					}
				}
			}
		}

		// Token: 0x0603D771 RID: 251761 RVA: 0x00FA418C File Offset: 0x00FA238C
		private void OnAddOrRemoveBuff(int entityId, GameplayCue cue, bool isAdd, int handleId)
		{
			if (cue.CueType == 38)
			{
				this.OnBossBuffCueChanged(cue, isAdd, handleId, entityId);
				return;
			}
			int? entityId2 = this.RoleBuffView.GetEntityId();
			if (!(entityId2.GetValueOrDefault() == entityId & entityId2 != null))
			{
				return;
			}
			if (cue.CueType == 24)
			{
				if (isAdd)
				{
					this.RoleUniqueBuffView.AddBuff(cue, handleId);
					return;
				}
				this.RoleUniqueBuffView.RemoveBuff(cue, handleId);
				return;
			}
			else
			{
				if (isAdd)
				{
					this.RoleBuffView.AddBuff(cue, handleId);
					return;
				}
				this.RoleBuffView.RemoveBuff(cue, handleId);
				return;
			}
		}

		// Token: 0x0603D772 RID: 251762 RVA: 0x00FA421F File Offset: 0x00FA241F
		private void OnDriveFishingShipStateChanged(bool isDriving)
		{
			this.SetRoleViewVisible(2, !isDriving);
			this.SetFishingStateViewActive(isDriving);
		}

		// Token: 0x0603D773 RID: 251763 RVA: 0x00FA4233 File Offset: 0x00FA2433
		private void OnBattleStateChanged(bool isInBattleState)
		{
			if (ModelBase<MoraleBattleModel>.Instance.IsMoraleActive())
			{
				this.SetMoraleTempExpViewActive(isInBattleState);
			}
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsFlagChallengeBattleActive())
			{
				this.SetFlagChallengeTempExpViewActive(isInBattleState);
			}
		}

		// Token: 0x0603D774 RID: 251764 RVA: 0x00FA425B File Offset: 0x00FA245B
		private void OnMoraleActiveChanged(bool active)
		{
			if (!active)
			{
				this.SetMoraleTempExpViewActive(false);
				return;
			}
			if (ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
			{
				this.SetMoraleTempExpViewActive(true);
			}
		}

		// Token: 0x0603D775 RID: 251765 RVA: 0x00FA427B File Offset: 0x00FA247B
		private void OnFlagChallengeDungeonActiveChanged(bool active)
		{
			if (!active)
			{
				this.SetFlagChallengeTempExpViewActive(false);
				return;
			}
			if (ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
			{
				this.SetFlagChallengeTempExpViewActive(true);
			}
		}

		// Token: 0x0603D776 RID: 251766 RVA: 0x00FA429C File Offset: 0x00FA249C
		private void SetRoleViewVisible(int reason, bool bVisible)
		{
			RoleStateView roleStateView = this.RoleStateView;
			if (roleStateView != null)
			{
				roleStateView.SetVisible(reason, bVisible);
			}
			ConcertoResponseItem concertoResponseItem = this.ConcertoResponseItem;
			if (concertoResponseItem != null)
			{
				concertoResponseItem.SetVisible(reason, bVisible);
			}
			RoleBuffView roleBuffView = this.RoleBuffView;
			if (roleBuffView != null)
			{
				roleBuffView.SetVisible(reason, bVisible);
			}
			SpecialEnergyBarContainer specialEnergyBarContainer = this.SpecialEnergyBarContainer;
			if (specialEnergyBarContainer != null)
			{
				specialEnergyBarContainer.SetVisible(reason, bVisible);
			}
			RoleUniqueBuffView roleUniqueBuffView = this.RoleUniqueBuffView;
			if (roleUniqueBuffView == null)
			{
				return;
			}
			roleUniqueBuffView.SetVisible(reason, bVisible);
		}

		// Token: 0x0603D777 RID: 251767 RVA: 0x00FA4308 File Offset: 0x00FA2508
		private void SetFishingStateViewActive(bool bActive)
		{
			if (bActive)
			{
				if (this.FishingStateView == null)
				{
					this.FishingStateView = base.NewDynamicChildViewByResourceIdWithCallback<FishingStateView>(this.RootItem, "UiItem_NavigationFightHp", false, null, null);
					return;
				}
			}
			else if (this.FishingStateView != null)
			{
				this.FishingStateView.Destroy(null);
				this.FishingStateView = null;
			}
		}

		// Token: 0x0603D778 RID: 251768 RVA: 0x00FA4358 File Offset: 0x00FA2558
		private UniTask NewMoraleTempExpViewAsync()
		{
			BottomPanel.<NewMoraleTempExpViewAsync>d__44 <NewMoraleTempExpViewAsync>d__;
			<NewMoraleTempExpViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewMoraleTempExpViewAsync>d__.<>4__this = this;
			<NewMoraleTempExpViewAsync>d__.<>1__state = -1;
			<NewMoraleTempExpViewAsync>d__.<>t__builder.Start<BottomPanel.<NewMoraleTempExpViewAsync>d__44>(ref <NewMoraleTempExpViewAsync>d__);
			return <NewMoraleTempExpViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D779 RID: 251769 RVA: 0x00FA439C File Offset: 0x00FA259C
		private void SetMoraleTempExpViewActive(bool active)
		{
			if (active)
			{
				if (this.MoraleTempExpView == null)
				{
					this.NewMoraleTempExpViewAsync().ContinueWith(delegate()
					{
						if (ModelBase<MoraleBattleModel>.Instance.IsMoraleActive() && ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
						{
							MoraleTempExpView moraleTempExpView3 = this.MoraleTempExpView;
							if (moraleTempExpView3 == null)
							{
								return;
							}
							moraleTempExpView3.ShowBattleVisibleChildView(false);
						}
					}).Forget();
					return;
				}
				MoraleTempExpView moraleTempExpView = this.MoraleTempExpView;
				if (moraleTempExpView == null)
				{
					return;
				}
				moraleTempExpView.ShowBattleVisibleChildView(false);
				return;
			}
			else
			{
				MoraleTempExpView moraleTempExpView2 = this.MoraleTempExpView;
				if (moraleTempExpView2 == null)
				{
					return;
				}
				moraleTempExpView2.HideBattleVisibleChildView();
				return;
			}
		}

		// Token: 0x0603D77A RID: 251770 RVA: 0x00FA43F4 File Offset: 0x00FA25F4
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "MoraleTempExp"))
			{
				return null;
			}
			MoraleTempExpView moraleTempExpView = this.MoraleTempExpView;
			UUIItem uuiitem = (moraleTempExpView != null) ? moraleTempExpView.GetRootItem() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x0603D77B RID: 251771 RVA: 0x00FA4444 File Offset: 0x00FA2644
		private UniTask NewFlagChallengeTempExpViewAsync()
		{
			BottomPanel.<NewFlagChallengeTempExpViewAsync>d__47 <NewFlagChallengeTempExpViewAsync>d__;
			<NewFlagChallengeTempExpViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewFlagChallengeTempExpViewAsync>d__.<>4__this = this;
			<NewFlagChallengeTempExpViewAsync>d__.<>1__state = -1;
			<NewFlagChallengeTempExpViewAsync>d__.<>t__builder.Start<BottomPanel.<NewFlagChallengeTempExpViewAsync>d__47>(ref <NewFlagChallengeTempExpViewAsync>d__);
			return <NewFlagChallengeTempExpViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D77C RID: 251772 RVA: 0x00FA4488 File Offset: 0x00FA2688
		private void SetFlagChallengeTempExpViewActive(bool active)
		{
			if (active)
			{
				if (this.FlagChallengeTempExpView == null)
				{
					this.NewFlagChallengeTempExpViewAsync().ContinueWith(delegate()
					{
						if (ModelBase<FlagChallengeBattleModel>.Instance.IsFlagChallengeBattleActive() && ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
						{
							FlagChallengeTempExpView flagChallengeTempExpView3 = this.FlagChallengeTempExpView;
							if (flagChallengeTempExpView3 == null)
							{
								return;
							}
							flagChallengeTempExpView3.ShowBattleVisibleChildView(false);
						}
					});
					return;
				}
				FlagChallengeTempExpView flagChallengeTempExpView = this.FlagChallengeTempExpView;
				if (flagChallengeTempExpView == null)
				{
					return;
				}
				flagChallengeTempExpView.ShowBattleVisibleChildView(false);
				return;
			}
			else
			{
				FlagChallengeTempExpView flagChallengeTempExpView2 = this.FlagChallengeTempExpView;
				if (flagChallengeTempExpView2 == null)
				{
					return;
				}
				flagChallengeTempExpView2.HideBattleVisibleChildView();
				return;
			}
		}

		// Token: 0x0603D77D RID: 251773 RVA: 0x00FA44DC File Offset: 0x00FA26DC
		private void OnBossBuffCueChanged(GameplayCue cueConfig, bool isAdd, int handleId, int entityId)
		{
			if (isAdd && !this.ValidateFormationBuff(entityId, handleId))
			{
				return;
			}
			EBossBuffNumMode ebossBuffNumMode = (cueConfig.ParametersLength > 0 && cueConfig.Parameters(0) == "1") ? EBossBuffNumMode.PresenceMode : EBossBuffNumMode.StackMode;
			if (this.BossBuffNumItem != null)
			{
				this.BossBuffNumItem.OnCueChanged(handleId, entityId, ebossBuffNumMode, isAdd);
				return;
			}
			this.PendingBossBuffCues.Add(new ValueTuple<int, int, EBossBuffNumMode, bool>(handleId, entityId, ebossBuffNumMode, isAdd));
			this.CreateBossBuffNumItem().Forget();
		}

		// Token: 0x0603D77E RID: 251774 RVA: 0x00FA4554 File Offset: 0x00FA2754
		private UniTask CreateBossBuffNumItem()
		{
			BottomPanel.<CreateBossBuffNumItem>d__51 <CreateBossBuffNumItem>d__;
			<CreateBossBuffNumItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBossBuffNumItem>d__.<>4__this = this;
			<CreateBossBuffNumItem>d__.<>1__state = -1;
			<CreateBossBuffNumItem>d__.<>t__builder.Start<BottomPanel.<CreateBossBuffNumItem>d__51>(ref <CreateBossBuffNumItem>d__);
			return <CreateBossBuffNumItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D77F RID: 251775 RVA: 0x00FA4598 File Offset: 0x00FA2798
		private IActiveBuff GetBuffByHandleId(int entityId, int handleId)
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
			if (((entityById != null) ? entityById.Entity : null) == null)
			{
				return null;
			}
			CharacterBuffComponent characterBuffComponent = entityById.Entity.CheckGetComponent<CharacterBuffComponent>();
			IActiveBuff activeBuff = (characterBuffComponent != null) ? characterBuffComponent.GetBuffByHandle(handleId) : null;
			if (activeBuff == null)
			{
				RoleBuffComponent roleBuffComponent = entityById.Entity.CheckGetComponent<RoleBuffComponent>();
				IActiveBuff activeBuff2;
				if (roleBuffComponent == null)
				{
					activeBuff2 = null;
				}
				else
				{
					PlayerBuffComponent formationBuffComp = roleBuffComponent.GetFormationBuffComp();
					activeBuff2 = ((formationBuffComp != null) ? formationBuffComp.GetBuffByHandle(handleId) : null);
				}
				activeBuff = activeBuff2;
			}
			return activeBuff;
		}

		// Token: 0x0603D780 RID: 251776 RVA: 0x00FA4604 File Offset: 0x00FA2804
		private bool ValidateFormationBuff(int entityId, int handleId)
		{
			IActiveBuff buffByHandleId = this.GetBuffByHandleId(entityId, handleId);
			if (buffByHandleId != null)
			{
				BuffDefinition config = buffByHandleId.Config;
				if (config == null || config.FormationPolicy != EBuffFormationPolicy.FormationBuff)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.GHY;
					string message = "BottomPanel: BossBuffNum关联的buff不是编队buff，请检查buff配置";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
					string item = "buffId";
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<long>(buffByHandleId.Id);
					ptr = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item2 = "formationPolicy";
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					BuffDefinition config2 = buffByHandleId.Config;
					defaultInterpolatedStringHandler.AppendFormatted<EBuffFormationPolicy?>((config2 != null) ? new EBuffFormationPolicy?(config2.FormationPolicy) : null);
					ptr2 = new ValueTuple<string, object>(item2, defaultInterpolatedStringHandler.ToStringAndClear());
					ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
					string item3 = "handleId";
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
					ptr3 = new ValueTuple<string, object>(item3, defaultInterpolatedStringHandler.ToStringAndClear());
					ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
					string item4 = "entityId";
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
					ptr4 = new ValueTuple<string, object>(item4, defaultInterpolatedStringHandler.ToStringAndClear());
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
					return false;
				}
			}
			return true;
		}

		// Token: 0x0402288E RID: 141454
		private RoleStateView RoleStateView;

		// Token: 0x0402288F RID: 141455
		private RoleBuffView RoleBuffView;

		// Token: 0x04022890 RID: 141456
		private ConcertoResponseItem ConcertoResponseItem;

		// Token: 0x04022891 RID: 141457
		private SpecialEnergyBarContainer SpecialEnergyBarContainer;

		// Token: 0x04022892 RID: 141458
		private RoleUniqueBuffView RoleUniqueBuffView;

		// Token: 0x04022893 RID: 141459
		private FishingStateView FishingStateView;

		// Token: 0x04022894 RID: 141460
		private MoraleTempExpView MoraleTempExpView;

		// Token: 0x04022895 RID: 141461
		private FlagChallengeTempExpView FlagChallengeTempExpView;

		// Token: 0x04022896 RID: 141462
		private HonamiStoryView HonamiStoryView;

		// Token: 0x04022897 RID: 141463
		private HonamiStoryMainQuestView HonamiStoryMainQuestView;

		// Token: 0x04022898 RID: 141464
		private bool IsLoadingMoraleView;

		// Token: 0x04022899 RID: 141465
		private bool IsLoadingFlagChallengeView;

		// Token: 0x0402289A RID: 141466
		private BossBuffNumItem BossBuffNumItem;

		// Token: 0x0402289B RID: 141467
		private bool IsLoadingBossBuffNumView;

		// Token: 0x0402289C RID: 141468
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject = Stat.Create("[BattleView]BottomPanelTick", "", "");

		// Token: 0x0402289D RID: 141469
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat ChangeRoleStat = Stat.Create("[ChangeRole]BottomPanel", "", "");

		// Token: 0x0402289E RID: 141470
		[TupleElementNames(new string[]
		{
			"HandleId",
			"EntityId",
			"Mode",
			"IsAdd"
		})]
		[Nullable(new byte[]
		{
			1,
			0
		})]
		private readonly List<ValueTuple<int, int, EBossBuffNumMode, bool>> PendingBossBuffCues = new List<ValueTuple<int, int, EBossBuffNumMode, bool>>();

		// Token: 0x0200BF8D RID: 49037
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403AF5D RID: 241501
			RoleStateItem,
			// Token: 0x0403AF5E RID: 241502
			ConcertoResponseItem,
			// Token: 0x0403AF5F RID: 241503
			SpecialEnergyItem,
			// Token: 0x0403AF60 RID: 241504
			RoleBuffItem,
			// Token: 0x0403AF61 RID: 241505
			PhantomContainerItem,
			// Token: 0x0403AF62 RID: 241506
			RoleTopBuffItem,
			// Token: 0x0403AF63 RID: 241507
			MoraleTempExpItem
		}
	}
}
