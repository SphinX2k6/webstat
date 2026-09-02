using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Character.Role.Component;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x02004951 RID: 18769
	[NullableContext(1)]
	[Nullable(0)]
	public class CharacterExploreComponent : BaseExploreComponent
	{
		// Token: 0x170083BA RID: 33722
		// (get) Token: 0x06031131 RID: 201009 RVA: 0x00C348F9 File Offset: 0x00C32AF9
		// (set) Token: 0x06031132 RID: 201010 RVA: 0x00C34901 File Offset: 0x00C32B01
		public bool NeedChangeTargetState
		{
			get
			{
				return this.NeedChangeTargetStateInternal;
			}
			set
			{
				this.NeedChangeTargetStateInternal = value;
				if (value && base.FocusTarget != null)
				{
					base.FocusTarget.ChangeHookPointState(this.FocusTargetLegalExceptSkill ? EHookPointState.Interactive : EHookPointState.NonInteractive);
				}
			}
		}

		// Token: 0x06031133 RID: 201011 RVA: 0x00C3492C File Offset: 0x00C32B2C
		protected override bool OnStart()
		{
			this.LogKey = "(角色)探索组件";
			base.OnStart();
			if (this.CheckDisableComponent())
			{
				return true;
			}
			this.ManipulateComponent = base.Entity.GetComponent<CharacterManipulateComponent>();
			this.ManipulateInteractComponent = base.Entity.GetComponent<CharacterManipulateInteractComponent>();
			this.SceneInteractComponent = base.Entity.GetComponent<RoleSceneInteractComponent>();
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleCompleted));
			Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnEnterVehicle, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
			Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnLeaveVehicle, new Action<VehiclePassengerInfo, bool>(this.OnLeaveVehicle));
			return true;
		}

		// Token: 0x06031134 RID: 201012 RVA: 0x00C349EC File Offset: 0x00C32BEC
		protected override bool OnEnd()
		{
			base.OnEnd();
			if (this.CheckDisableComponent())
			{
				return true;
			}
			Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleCompleted));
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnEnterVehicle, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnLeaveVehicle, new Action<VehiclePassengerInfo, bool>(this.OnLeaveVehicle));
			this.OnExploreComponentDisable("OnEnd");
			return true;
		}

		// Token: 0x06031135 RID: 201013 RVA: 0x00C34A77 File Offset: 0x00C32C77
		protected override bool CheckDisableComponent()
		{
			BaseActorComponent actorComponent = this.ActorComponent;
			return actorComponent == null || !actorComponent.IsRoleAndCtrlByMe;
		}

		// Token: 0x06031136 RID: 201014 RVA: 0x00C34A90 File Offset: 0x00C32C90
		protected override bool OnExploreComponentEnable(string reason)
		{
			if (!base.OnExploreComponentEnable(reason))
			{
				return false;
			}
			this.Manipulating = false;
			Singleton<EventSystem>.Instance.Add(EEventName.OnChangeSelectedExploreId, new Action(this.OnExploreVisionSkillChange));
			Singleton<EventSystem>.Instance.Add<bool, Entity, bool>(EEventName.OnManipulateSwitchToNewTarget, new Action<bool, Entity, bool>(this.OnManipulateFound));
			return true;
		}

		// Token: 0x06031137 RID: 201015 RVA: 0x00C34AE8 File Offset: 0x00C32CE8
		protected override bool OnExploreComponentDisable(string reason)
		{
			if (!base.OnExploreComponentDisable(reason))
			{
				return false;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeSelectedExploreId, new Action(this.OnExploreVisionSkillChange));
			Singleton<EventSystem>.Instance.Remove<bool, Entity, bool>(EEventName.OnManipulateSwitchToNewTarget, new Action<bool, Entity, bool>(this.OnManipulateFound));
			return true;
		}

		// Token: 0x06031138 RID: 201016 RVA: 0x00C34B39 File Offset: 0x00C32D39
		protected override void OnTick(float delta)
		{
			this.CheckTick();
		}

		// Token: 0x06031139 RID: 201017 RVA: 0x00C34B41 File Offset: 0x00C32D41
		private void OnEnterVehicle(VehiclePassengerInfo info, bool byChangeRole)
		{
			if (!info.IsDriver || info.PassengerEntity != base.Entity)
			{
				return;
			}
			this.IsInVehicle = true;
			HighlightExploreSkillLogic highlightLogic = this.HighlightLogic;
			if (highlightLogic != null)
			{
				highlightLogic.HideHighlightExploreSkill();
			}
			this.OnExploreComponentDisable("主控角色进入载具");
		}

		// Token: 0x0603113A RID: 201018 RVA: 0x00C34B7E File Offset: 0x00C32D7E
		private void OnLeaveVehicle(VehiclePassengerInfo info, bool byChangeRole)
		{
			if (!info.IsDriver || info.PassengerEntity != base.Entity)
			{
				return;
			}
			this.IsInVehicle = false;
			this.OnExploreComponentEnable("主控角色离开载具");
		}

		// Token: 0x0603113B RID: 201019 RVA: 0x00C34BAC File Offset: 0x00C32DAC
		private void CheckTick()
		{
			CharacterManipulateComponent manipulateComponent = this.ManipulateComponent;
			bool flag;
			if (((manipulateComponent != null) ? manipulateComponent.CurSelectedEntity : null) == null)
			{
				CharacterManipulateInteractComponent manipulateInteractComponent = this.ManipulateInteractComponent;
				flag = (((manipulateInteractComponent != null) ? manipulateInteractComponent.GetCurrentTarget : null) != null);
			}
			else
			{
				flag = true;
			}
			if (!flag && this.ManipulateFound)
			{
				this.ManipulateFound = false;
				this.ManipulateActorComp = null;
				this.CurManipulateEntityId = 0;
				this.LastManipulateEntityId = 0;
			}
			GrapplingHookPointComponent focusTarget = base.FocusTarget;
			if ((focusTarget == null || !focusTarget.Valid) && this.HookFound)
			{
				this.HookFound = false;
				this.CurHookEntityId = 0;
				this.LastHookEntityId = 0;
			}
			if (this.HookFound || this.ManipulateFound)
			{
				if (this.HookFound != this.ManipulateFound)
				{
					this.CheckSimpleTrue();
					return;
				}
				this.CheckBothTrue();
			}
		}

		// Token: 0x0603113C RID: 201020 RVA: 0x00C34C6C File Offset: 0x00C32E6C
		private void CheckSimpleTrue()
		{
			if (this.HookFound && this.CurHookEntityId != this.LastHookEntityId && this.FocusTargetLegalExceptSkill)
			{
				this.TryChangeSkill(CharacterExploreComponent.ESkillType.Hook);
				this.NeedChangeTargetState = true;
				return;
			}
			if (this.ManipulateFound && this.CurManipulateEntityId != this.LastManipulateEntityId)
			{
				this.TryChangeSkill(CharacterExploreComponent.ESkillType.Manipulate);
				this.NeedChangeTargetState = false;
			}
		}

		// Token: 0x0603113D RID: 201021 RVA: 0x00C34CCC File Offset: 0x00C32ECC
		private void CheckBothTrue()
		{
			if (this.Manipulating)
			{
				this.TryChangeSkill(CharacterExploreComponent.ESkillType.Manipulate);
				return;
			}
			Vector actorLocationProxy = this.ActorComponent.ActorLocationProxy;
			Vector hookLocation = base.FocusTarget.HookLocation;
			Vector actorLocationProxy2 = this.ManipulateActorComp.ActorLocationProxy;
			double num = Vector.DistSquared(actorLocationProxy, hookLocation);
			double num2 = Vector.DistSquared(actorLocationProxy, actorLocationProxy2);
			if (Math.Abs(num - num2) < 1.401298464324817E-45 || num > num2)
			{
				if (this.CurManipulateEntityId != this.LastManipulateEntityId)
				{
					this.TryChangeSkill(CharacterExploreComponent.ESkillType.Manipulate);
				}
				this.NeedChangeTargetState = false;
				return;
			}
			if (this.CurHookEntityId != this.LastHookEntityId && this.FocusTargetLegalExceptSkill)
			{
				this.TryChangeSkill(CharacterExploreComponent.ESkillType.Hook);
			}
			this.NeedChangeTargetState = true;
		}

		// Token: 0x0603113E RID: 201022 RVA: 0x00C34D73 File Offset: 0x00C32F73
		public void SendHookMovePushProxy()
		{
			base.SendHookMovePush();
		}

		// Token: 0x0603113F RID: 201023 RVA: 0x00C34D7B File Offset: 0x00C32F7B
		[NullableContext(2)]
		public void SendHookTargetRequestProxy(GrapplingHookPointComponent target, [Nullable(1)] Action onFailure, string compositeSessionName = null)
		{
			base.SendHookTargetRequest(target, onFailure, compositeSessionName);
		}

		// Token: 0x06031140 RID: 201024 RVA: 0x00C34D86 File Offset: 0x00C32F86
		[NullableContext(2)]
		public void SendHookEndRequestProxy(GrapplingHookPointComponent target, string compositeSessionName = null)
		{
			base.SendHookEndRequest(target, compositeSessionName);
		}

		// Token: 0x06031141 RID: 201025 RVA: 0x00C34D90 File Offset: 0x00C32F90
		public void SetDataFromOldRole(EntityHandle oldEntity)
		{
			CharacterExploreComponent component = oldEntity.Entity.GetComponent<CharacterExploreComponent>();
			this.IsInVehicle = component.IsInVehicle;
			if (component.IsLockingTarget)
			{
				base.ForceLockTarget(component.FocusTarget, "上场角色继承下场角色锁定目标");
			}
			else
			{
				base.FocusTarget = component.FocusTarget;
				base.FocusTargetLegal = component.FocusTargetLegal;
			}
			this.PendingHighlightSkill = component.PendingHighlightSkill;
			if (component.HighlightLogic != null)
			{
				this.HighlightLogic = component.HighlightLogic;
				component.HighlightLogic = null;
				HighlightExploreSkillLogic highlightLogic = this.HighlightLogic;
				if (highlightLogic != null)
				{
					highlightLogic.Init(this);
				}
			}
			else
			{
				base.InitHighlightHandle();
			}
			if (component.CurrentIconTagId != null)
			{
				int? num = component.CurrentIconTagId;
				int num2 = 0;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					base.UpdateHookIconTag(true, component.CurrentIconTagId, "上场角色继承下场角色Tag");
				}
			}
			if (component.CurrentIconHighlightTagId != null)
			{
				int? num = component.CurrentIconHighlightTagId;
				int num2 = 0;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					base.UpdateHookIconHighlightTag(true, component.CurrentIconHighlightTagId);
				}
			}
		}

		// Token: 0x06031142 RID: 201026 RVA: 0x00C34EA0 File Offset: 0x00C330A0
		[NullableContext(2)]
		protected override void OnDetectedTargetChanged(GrapplingHookPointComponent prevTarget)
		{
			if (prevTarget != null && prevTarget.Valid && prevTarget != base.FocusTarget)
			{
				prevTarget.ChangeHookPointState(EHookPointState.Normal);
			}
			GrapplingHookPointComponent focusTarget = base.FocusTarget;
			if (focusTarget != null && focusTarget.Valid && this.NeedChangeTargetState)
			{
				base.FocusTarget.ChangeHookPointState(this.FocusTargetLegalExceptSkill ? EHookPointState.Interactive : EHookPointState.NonInteractive);
			}
			this.OnHookPointFound();
			if (base.FocusTarget != null && this.FocusTargetLegalExceptSkill)
			{
				if (ModelBase<RouletteModel>.Instance.CurrentExploreSkillId != 1001)
				{
					this.NeedAddTag = true;
				}
				else if (base.FocusTargetLegal)
				{
					base.UpdateHookIconTag(true, base.FocusTarget.GetTagId(), "(角色)当前选中的钩锁点有效");
					base.UpdateHookIconHighlightTag(true, new int?(base.FocusTarget.GetHighlightTagId()));
				}
				else
				{
					if (ModelBase<CharacterExploreModel>.Instance.AutoResetSkillFinished)
					{
						base.UpdateHookIconTag(false, null, "(角色)当前选中的钩锁点无效，且不需要等待切换技能");
					}
					base.UpdateHookIconHighlightTag(false, null);
				}
			}
			else
			{
				this.NeedAddTag = false;
				if (ModelBase<CharacterExploreModel>.Instance.AutoResetSkillFinished)
				{
					base.UpdateHookIconTag(false, null, "(角色)当前未选中点，且不需要等待切换技能");
				}
				base.UpdateHookIconHighlightTag(false, null);
			}
			this.SceneInteractComponent.OnDetectedTargetChanged();
		}

		// Token: 0x06031143 RID: 201027 RVA: 0x00C34FE4 File Offset: 0x00C331E4
		private void OnChangeRoleCompleted(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
		{
			if (this.IsInVehicle)
			{
				return;
			}
			if (oldEntity == newEntity)
			{
				return;
			}
			int? num = (oldEntity != null) ? new int?(oldEntity.Id) : null;
			int id = base.Entity.Id;
			if (num.GetValueOrDefault() == id & num != null)
			{
				this.OnExploreComponentDisable("OnRoleGoDown");
				return;
			}
			if (newEntity.Id == base.Entity.Id)
			{
				this.OnExploreComponentEnable("OnRoleGoUp");
			}
		}

		// Token: 0x06031144 RID: 201028 RVA: 0x00C35068 File Offset: 0x00C33268
		private void OnExploreVisionSkillChange()
		{
			this.HookFound = false;
			this.ManipulateFound = false;
			if (ModelBase<RouletteModel>.Instance.CurrentExploreSkillId == 1001)
			{
				if (this.NeedAddTag)
				{
					bool add = true;
					GrapplingHookPointComponent focusTarget = base.FocusTarget;
					base.UpdateHookIconTag(add, (focusTarget != null) ? focusTarget.GetTagId() : null, "切换到钩锁技能且NeedAddTag为真时, 添加定点钩索可用标签");
					bool add2 = true;
					GrapplingHookPointComponent focusTarget2 = base.FocusTarget;
					base.UpdateHookIconHighlightTag(add2, (focusTarget2 != null) ? new int?(focusTarget2.GetHighlightTagId()) : null);
				}
				return;
			}
			List<int> onSettingExploreSkillIdList = ModelBase<RouletteModel>.Instance.OnSettingExploreSkillIdList;
			if (onSettingExploreSkillIdList.Count > 0)
			{
				List<int> list = onSettingExploreSkillIdList;
				if (list[list.Count - 1] == 1001)
				{
					return;
				}
			}
			base.UpdateHookIconTag(false, null, "切换到非钩锁技能时，删除定点钩索可用标签");
			base.UpdateHookIconHighlightTag(false, null);
			if (base.FocusTarget != null)
			{
				base.FocusTarget.ChangeHookPointState(EHookPointState.Normal);
				base.FocusTarget = null;
			}
		}

		// Token: 0x06031145 RID: 201029 RVA: 0x00C35154 File Offset: 0x00C33354
		private void OnHookPointFound()
		{
			if (base.FocusTarget == null || !this.FocusTargetLegalExceptSkill)
			{
				this.HookFound = false;
				this.CurHookEntityId = 0;
				this.LastHookEntityId = 0;
				this.CheckExit(CharacterExploreComponent.ESkillType.Hook);
				return;
			}
			if (this.CurHookEntityId == base.FocusTarget.Entity.Id)
			{
				return;
			}
			this.CurHookEntityId = base.FocusTarget.Entity.Id;
			this.HookFound = true;
		}

		// Token: 0x06031146 RID: 201030 RVA: 0x00C351C4 File Offset: 0x00C333C4
		[NullableContext(2)]
		private void OnManipulateFound(bool find, Entity entity, bool isCastTarget)
		{
			this.Manipulating = isCastTarget;
			if (isCastTarget)
			{
				return;
			}
			if (!find)
			{
				this.ManipulateFound = false;
				this.ManipulateActorComp = null;
				this.CurManipulateEntityId = 0;
				this.LastManipulateEntityId = 0;
				this.CheckExit(CharacterExploreComponent.ESkillType.Manipulate);
				return;
			}
			this.ManipulateFound = true;
			this.ManipulateActorComp = entity.GetComponent<BaseActorComponent>();
			this.CurManipulateEntityId = entity.Id;
		}

		// Token: 0x06031147 RID: 201031 RVA: 0x00C35224 File Offset: 0x00C33424
		private unsafe void OnCharSkillEnd(int entityId, int skillId)
		{
			CharacterExploreModel exploreModel = ModelBase<CharacterExploreModel>.Instance;
			if (this.ListenSkillIdMap.Contains((long)skillId))
			{
				if (base.FocusTarget != null && this.FocusTargetLegalExceptSkill)
				{
					this.TryChangeSkill(CharacterExploreComponent.ESkillType.Hook);
				}
				else if (this.ManipulateFound)
				{
					this.TryChangeSkill(CharacterExploreComponent.ESkillType.Manipulate);
				}
				else
				{
					exploreModel.ResetExplodeSkillId(EExploreSkillLayer.Auto, "OnCharSkillEnd");
					int topLayerExplodeSkillId = exploreModel.GetTopLayerExplodeSkillId();
					ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(topLayerExplodeSkillId, delegate(bool _)
					{
						exploreModel.AutoResetSkillFinished = true;
						if (this.FocusTarget == null || !this.FocusTargetLegalExceptSkill)
						{
							this.UpdateHookIconTag(false, null, "(角色)钩锁技能结束且当前选中钩锁点无效, 删除定点钩索可用标签");
						}
					}, true);
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.CK;
				string message = "[CharacterExploreComponent] OnCharSkillEnd";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EndSkillId", skillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FocusTarget", base.FocusTarget);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FocusTargetLegalExceptSkill", this.FocusTargetLegalExceptSkill);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ManipulateFound", this.ManipulateFound);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("OldSkill", ModelBase<RouletteModel>.Instance.CurrentExploreSkillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("TopLayerSkillId", exploreModel.GetTopLayerExplodeSkillId());
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
				this.NeedChangeTargetState = true;
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd));
			}
		}

		// Token: 0x06031148 RID: 201032 RVA: 0x00C353D0 File Offset: 0x00C335D0
		private unsafe void TryChangeSkill(CharacterExploreComponent.ESkillType type)
		{
			int num = 0;
			if (type != CharacterExploreComponent.ESkillType.Hook)
			{
				if (type == CharacterExploreComponent.ESkillType.Manipulate)
				{
					num = 1003;
					this.LastManipulateEntityId = this.CurManipulateEntityId;
				}
			}
			else
			{
				num = 1001;
				this.LastHookEntityId = this.CurHookEntityId;
			}
			if (this.CheckHasSkill(num))
			{
				CharacterExploreModel instance = ModelBase<CharacterExploreModel>.Instance;
				if (instance.CheckNeedChangeSkill(num, EExploreSkillLayer.Auto))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.CK;
					string message = "[CharacterExploreComponent] TryChangeSkill";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("OldSkill", ModelBase<RouletteModel>.Instance.CurrentExploreSkillId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NewSkill", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Id", base.Entity.Id);
					instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(num, null, true);
					instance.AutoResetSkillFinished = false;
				}
				instance.SetExploreSkillId(num, EExploreSkillLayer.Auto, "角色探索组件自动切换技能");
			}
		}

		// Token: 0x06031149 RID: 201033 RVA: 0x00C354DC File Offset: 0x00C336DC
		private unsafe void CheckExit(CharacterExploreComponent.ESkillType type)
		{
			if (this.HookFound)
			{
				this.TryChangeSkill(CharacterExploreComponent.ESkillType.Hook);
				this.NeedChangeTargetState = true;
				return;
			}
			if (this.ManipulateFound)
			{
				return;
			}
			CharacterExploreModel exploreModel = ModelBase<CharacterExploreModel>.Instance;
			if (!exploreModel.ExistAutoLayerSkill())
			{
				exploreModel.AutoResetSkillFinished = true;
				return;
			}
			if (this.IsNeedAddListen(type))
			{
				if (type != CharacterExploreComponent.ESkillType.Hook)
				{
					if (type == CharacterExploreComponent.ESkillType.Manipulate)
					{
						this.ListenSkillIdMap = CharacterExploreComponent.ManipulateSkillIdMap;
					}
				}
				else
				{
					this.ListenSkillIdMap = CharacterExploreComponent.HookSkillIdMap;
				}
				if (!Singleton<EventSystem>.Instance.HasWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd)))
				{
					Singleton<EventSystem>.Instance.AddWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd));
				}
				return;
			}
			exploreModel.ResetExplodeSkillId(EExploreSkillLayer.Auto, "CheckExit");
			int topLayerExplodeSkillId = exploreModel.GetTopLayerExplodeSkillId();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[CharacterExploreComponent] CheckExit";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("OldSkill", ModelBase<RouletteModel>.Instance.CurrentExploreSkillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NewSkill", topLayerExplodeSkillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Id", base.Entity.Id);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(topLayerExplodeSkillId, delegate(bool _)
			{
				exploreModel.AutoResetSkillFinished = true;
			}, true);
			this.NeedChangeTargetState = true;
		}

		// Token: 0x0603114A RID: 201034 RVA: 0x00C35667 File Offset: 0x00C33867
		private bool CheckHasSkill(int skillId)
		{
			return ModelBase<RouletteModel>.Instance.UnlockExploreSkillDataMap.ContainsKey(skillId);
		}

		// Token: 0x0603114B RID: 201035 RVA: 0x00C3567C File Offset: 0x00C3387C
		private bool IsNeedAddListen(CharacterExploreComponent.ESkillType type)
		{
			BaseSkillComponent skillComponent = this.SkillComponent;
			if (((skillComponent != null) ? skillComponent.CurrentSkill : null) == null)
			{
				return false;
			}
			int skillId = this.SkillComponent.CurrentSkill.SkillId;
			return (type == CharacterExploreComponent.ESkillType.Hook && CharacterExploreComponent.HookSkillIdMap.Contains((long)skillId)) || (type == CharacterExploreComponent.ESkillType.Manipulate && CharacterExploreComponent.ManipulateSkillIdMap.Contains((long)skillId));
		}

		// Token: 0x0603114C RID: 201036 RVA: 0x00C356D8 File Offset: 0x00C338D8
		public unsafe long GetFixHookBuffIdByTarget()
		{
			GrapplingHookPointComponent interactingTarget = base.InteractingTarget;
			if (interactingTarget == null || !interactingTarget.Valid)
			{
				return 640003009L;
			}
			long valueOrDefault = interactingTarget.GetHookEffectBuffId().GetValueOrDefault(640003009L);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[CharacterExploreComponent] GetFixHookBuffIdByTarget";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", interactingTarget.EntityConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BuffId", valueOrDefault);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return valueOrDefault;
		}

		// Token: 0x0603114D RID: 201037 RVA: 0x00C3577C File Offset: 0x00C3397C
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterExploreComponent characterExploreComponent = (CharacterExploreComponent)componentTemplate;
			if (base.CanResetComponentProperty("ManipulateComponent"))
			{
				if (characterExploreComponent.ManipulateComponent == null)
				{
					this.ManipulateComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterManipulateComponent>(this.ManipulateComponent), "ManipulateComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ManipulateInteractComponent"))
			{
				if (characterExploreComponent.ManipulateInteractComponent == null)
				{
					this.ManipulateInteractComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterManipulateInteractComponent>(this.ManipulateInteractComponent), "ManipulateInteractComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SceneInteractComponent"))
			{
				if (characterExploreComponent.SceneInteractComponent == null)
				{
					this.SceneInteractComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RoleSceneInteractComponent>(this.SceneInteractComponent), "SceneInteractComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Manipulating"))
			{
				this.Manipulating = characterExploreComponent.Manipulating;
			}
			if (base.CanResetComponentProperty("ListenSkillIdMap"))
			{
				if (characterExploreComponent.ListenSkillIdMap == null)
				{
					this.ListenSkillIdMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<long>(this.ListenSkillIdMap), "ListenSkillIdMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsInVehicle"))
			{
				this.IsInVehicle = characterExploreComponent.IsInVehicle;
			}
			if (base.CanResetComponentProperty("NeedChangeTargetStateInternal"))
			{
				this.NeedChangeTargetStateInternal = characterExploreComponent.NeedChangeTargetStateInternal;
			}
			if (base.CanResetComponentProperty("NeedAddTag"))
			{
				this.NeedAddTag = characterExploreComponent.NeedAddTag;
			}
			if (base.CanResetComponentProperty("HookFound"))
			{
				this.HookFound = characterExploreComponent.HookFound;
			}
			if (base.CanResetComponentProperty("ManipulateFound"))
			{
				this.ManipulateFound = characterExploreComponent.ManipulateFound;
			}
			if (base.CanResetComponentProperty("LastManipulateEntityId"))
			{
				this.LastManipulateEntityId = characterExploreComponent.LastManipulateEntityId;
			}
			if (base.CanResetComponentProperty("CurManipulateEntityId"))
			{
				this.CurManipulateEntityId = characterExploreComponent.CurManipulateEntityId;
			}
			if (base.CanResetComponentProperty("LastHookEntityId"))
			{
				this.LastHookEntityId = characterExploreComponent.LastHookEntityId;
			}
			if (base.CanResetComponentProperty("CurHookEntityId"))
			{
				this.CurHookEntityId = characterExploreComponent.CurHookEntityId;
			}
			if (base.CanResetComponentProperty("ManipulateActorComp"))
			{
				if (characterExploreComponent.ManipulateActorComp == null)
				{
					this.ManipulateActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ManipulateActorComp), "ManipulateActorComp"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401C405 RID: 115717
		private const int MANIPULATE_VISION_ID = 1003;

		// Token: 0x0401C406 RID: 115718
		private const long DEFAULT_FIX_HOOK_BUFF_ID = 640003009L;

		// Token: 0x0401C407 RID: 115719
		[StaticVariableRuleIgnore]
		private static readonly HashSet<long> ManipulateSkillIdMap = new HashSet<long>
		{
			210007L
		};

		// Token: 0x0401C408 RID: 115720
		[StaticVariableRuleIgnore]
		private static readonly HashSet<long> HookSkillIdMap = new HashSet<long>
		{
			100020L,
			100021L,
			100022L,
			200004L,
			210130L,
			100024L,
			210032L
		};

		// Token: 0x0401C409 RID: 115721
		[Nullable(2)]
		private CharacterManipulateComponent ManipulateComponent;

		// Token: 0x0401C40A RID: 115722
		[Nullable(2)]
		private CharacterManipulateInteractComponent ManipulateInteractComponent;

		// Token: 0x0401C40B RID: 115723
		[Nullable(2)]
		private RoleSceneInteractComponent SceneInteractComponent;

		// Token: 0x0401C40C RID: 115724
		private bool Manipulating;

		// Token: 0x0401C40D RID: 115725
		[Nullable(2)]
		private HashSet<long> ListenSkillIdMap;

		// Token: 0x0401C40E RID: 115726
		private bool IsInVehicle;

		// Token: 0x0401C40F RID: 115727
		private bool NeedChangeTargetStateInternal = true;

		// Token: 0x0401C410 RID: 115728
		private bool NeedAddTag;

		// Token: 0x0401C411 RID: 115729
		private bool HookFound;

		// Token: 0x0401C412 RID: 115730
		private bool ManipulateFound;

		// Token: 0x0401C413 RID: 115731
		private int LastManipulateEntityId;

		// Token: 0x0401C414 RID: 115732
		private int CurManipulateEntityId;

		// Token: 0x0401C415 RID: 115733
		private int LastHookEntityId;

		// Token: 0x0401C416 RID: 115734
		private int CurHookEntityId;

		// Token: 0x0401C417 RID: 115735
		[Nullable(2)]
		private BaseActorComponent ManipulateActorComp;

		// Token: 0x0200A9D3 RID: 43475
		[NullableContext(0)]
		private enum ESkillType
		{
			// Token: 0x040348F3 RID: 215283
			Hook,
			// Token: 0x040348F4 RID: 215284
			Manipulate
		}
	}
}
