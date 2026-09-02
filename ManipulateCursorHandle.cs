using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Render;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02001F97 RID: 8087
[NullableContext(2)]
[Nullable(0)]
public class ManipulateCursorHandle : HudUnitHandleBase
{
	// Token: 0x0600F2B4 RID: 62132 RVA: 0x00425190 File Offset: 0x00423390
	protected override void OnInitialize()
	{
		base.InitCursorAxis();
		this.CurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		EntityHandle currentEntity = this.CurrentEntity;
		if (currentEntity == null || !currentEntity.Valid)
		{
			return;
		}
		this.CurrentTagComponent = this.CurrentEntity.Entity.GetComponent<BaseTagComponent>();
		this.CurrentEntityActorComponent = this.CurrentEntity.Entity.GetComponent<BaseActorComponent>();
		this.CurrentEntityManipulateComponent = this.CurrentEntity.Entity.GetComponent<CharacterManipulateComponent>();
		this.FightCameraLogicComponent = (ControllerBase<CameraController>.Instance.MainModel.FightCamera.GetComponent(typeof(FightCameraLogicComponent)) as FightCameraLogicComponent);
		string stringConfig = ConfigCommonParamById.GetStringConfig("ManipulateAimVisibleTags");
		if (string.IsNullOrEmpty(stringConfig))
		{
			return;
		}
		string[] array = stringConfig.Split(',', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			int tagIdByName = GameplayTagUtils.GetTagIdByName(array[i]);
			if (tagIdByName > 0)
			{
				this.DisableTagIds.Add(tagIdByName);
			}
		}
	}

	// Token: 0x0600F2B5 RID: 62133 RVA: 0x0042527B File Offset: 0x0042347B
	protected override void OnDestroyed()
	{
		this.Deactivate();
		this.ClearDisableTagTasks();
		this.CurrentEntity = null;
		this.CurrentEntityActorComponent = null;
		this.CurrentEntityManipulateComponent = null;
		this.CurrentTagComponent = null;
		this.DisableTagIds.Clear();
	}

	// Token: 0x0600F2B6 RID: 62134 RVA: 0x004252B0 File Offset: 0x004234B0
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleCompleted));
		Singleton<EventSystem>.Instance.Add<bool, Entity, bool>(EEventName.OnManipulateSwitchToNewTarget, new Action<bool, Entity, bool>(this.OnSwitchToNewTarget));
		Singleton<EventSystem>.Instance.Add<float, string>(EEventName.OnManipulateStartChanting, new Action<float, string>(this.OnManipulateStart));
		Singleton<EventSystem>.Instance.Add(EEventName.OnManipulateCancelChanting, new Action(this.OnManipulateCancel));
		Singleton<EventSystem>.Instance.Add(EEventName.OnManipulateCompleteChanting, new Action(this.OnManipulateComplete));
		Singleton<EventSystem>.Instance.Add<Entity, CharacterPart>(EEventName.ManipulateStartLockCastTarget, new Action<Entity, CharacterPart>(this.OnManipulateStartLockCastTarget));
		Singleton<EventSystem>.Instance.Add(EEventName.ManipulateEndLockCastTarget, new Action(this.OnManipulateEndLockCastTarget));
		Singleton<EventSystem>.Instance.Add(EEventName.HiddenManipulateUI, new Action(this.OnManipulateEnded));
	}

	// Token: 0x0600F2B7 RID: 62135 RVA: 0x004253A0 File Offset: 0x004235A0
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleCompleted));
		Singleton<EventSystem>.Instance.Remove<bool, Entity, bool>(EEventName.OnManipulateSwitchToNewTarget, new Action<bool, Entity, bool>(this.OnSwitchToNewTarget));
		Singleton<EventSystem>.Instance.Remove<float, string>(EEventName.OnManipulateStartChanting, new Action<float, string>(this.OnManipulateStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnManipulateCancelChanting, new Action(this.OnManipulateCancel));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnManipulateCompleteChanting, new Action(this.OnManipulateComplete));
		Singleton<EventSystem>.Instance.Remove<Entity, CharacterPart>(EEventName.ManipulateStartLockCastTarget, new Action<Entity, CharacterPart>(this.OnManipulateStartLockCastTarget));
		Singleton<EventSystem>.Instance.Remove(EEventName.ManipulateEndLockCastTarget, new Action(this.OnManipulateEndLockCastTarget));
		Singleton<EventSystem>.Instance.Remove(EEventName.HiddenManipulateUI, new Action(this.OnManipulateEnded));
	}

	// Token: 0x0600F2B8 RID: 62136 RVA: 0x00425490 File Offset: 0x00423690
	[NullableContext(1)]
	private void OnChangeRoleCompleted(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
	{
		this.CurrentEntity = newEntityHandle;
		this.CurrentEntityActorComponent = this.CurrentEntity.Entity.GetComponent<BaseActorComponent>();
		this.CurrentEntityManipulateComponent = this.CurrentEntity.Entity.GetComponent<CharacterManipulateComponent>();
		this.CurrentTagComponent = newEntityHandle.Entity.GetComponent<BaseTagComponent>();
		this.ClearDisableTagTasks();
		foreach (int value in this.DisableTagIds)
		{
			ITagTask tagTask = this.CurrentTagComponent.ListenForTagAddOrRemove(new int?(value), new BaseTagComponent.TTagSwitchedCallback(this.OnDisableTagChanged), ManipulateCursorHandle.ListenTagStat);
			if (tagTask != null)
			{
				this.DisableTagTasks.Add(tagTask);
			}
		}
	}

	// Token: 0x0600F2B9 RID: 62137 RVA: 0x00425558 File Offset: 0x00423758
	[NullableContext(1)]
	private void OnManipulateStart(float time, string resId)
	{
		this.LockEntityAimVisible = string.IsNullOrEmpty(resId);
		this.ChangeState(EManipulateCursorState.Chanting);
		ManipulateCursorUnit manipulateCursorUnit = this.ManipulateCursorUnit;
		if (manipulateCursorUnit == null)
		{
			return;
		}
		manipulateCursorUnit.StartProcess(time);
	}

	// Token: 0x0600F2BA RID: 62138 RVA: 0x0042557E File Offset: 0x0042377E
	private void OnManipulateCancel()
	{
		this.ChangeState(EManipulateCursorState.NoTarget);
	}

	// Token: 0x0600F2BB RID: 62139 RVA: 0x00425587 File Offset: 0x00423787
	private void OnManipulateComplete()
	{
		this.ChangeState(EManipulateCursorState.Holding);
	}

	// Token: 0x0600F2BC RID: 62140 RVA: 0x00425590 File Offset: 0x00423790
	[NullableContext(1)]
	private void OnManipulateStartLockCastTarget(Entity lockEntity, CharacterPart lockPart)
	{
		if (!lockEntity.Valid)
		{
			this.IsCastTarget = false;
			this.ChangeState(EManipulateCursorState.NoTarget);
			return;
		}
		this.IsCastTarget = true;
		if (!this.LockEntityAimVisible)
		{
			this.ChangeState(EManipulateCursorState.Holding);
			return;
		}
		this.Activate(lockEntity);
	}

	// Token: 0x0600F2BD RID: 62141 RVA: 0x004255C7 File Offset: 0x004237C7
	private void OnManipulateEndLockCastTarget()
	{
		this.IsCastTarget = false;
		this.ChangeState(EManipulateCursorState.NoTarget);
	}

	// Token: 0x0600F2BE RID: 62142 RVA: 0x004255D7 File Offset: 0x004237D7
	private void OnManipulateEnded()
	{
		this.ChangeState(EManipulateCursorState.NoTarget);
	}

	// Token: 0x0600F2BF RID: 62143 RVA: 0x004255E0 File Offset: 0x004237E0
	public new void OnInputControllerChanged(EInputControllerType last, EInputControllerType now)
	{
		if (this.ManipulateCursorUnit == null)
		{
			return;
		}
		if (last != now && (last == EInputControllerType.Touch || now == EInputControllerType.Touch))
		{
			base.DestroyHudUnit(this.ManipulateCursorUnit);
			this.ManipulateCursorUnit = null;
			this.NewManipulateCursorUnit();
		}
	}

	// Token: 0x0600F2C0 RID: 62144 RVA: 0x00425610 File Offset: 0x00423810
	private void OnSwitchToNewTarget(bool isActive, Entity entity, bool isCastTarget)
	{
		this.IsCastTarget = isCastTarget;
		if (!isActive)
		{
			this.ChangeState(EManipulateCursorState.NoTarget);
			return;
		}
		if (entity == null || !entity.Valid)
		{
			if (isCastTarget)
			{
				this.ChangeState(EManipulateCursorState.Holding);
				return;
			}
			this.ChangeState(EManipulateCursorState.NoTarget);
			return;
		}
		else
		{
			if (this.IsCastTarget && !this.LockEntityAimVisible)
			{
				this.ChangeState(EManipulateCursorState.Holding);
				return;
			}
			this.Activate(entity);
			return;
		}
	}

	// Token: 0x0600F2C1 RID: 62145 RVA: 0x00425672 File Offset: 0x00423872
	protected override void OnAfterTick(float delta)
	{
		this.Refresh();
	}

	// Token: 0x0600F2C2 RID: 62146 RVA: 0x0042567A File Offset: 0x0042387A
	private void OnDisableTagChanged(int tagId, bool tagExists)
	{
		if (!tagExists)
		{
			this.RefreshVisible();
			return;
		}
		ManipulateCursorUnit manipulateCursorUnit = this.ManipulateCursorUnit;
		if (manipulateCursorUnit == null)
		{
			return;
		}
		manipulateCursorUnit.SetActive(false);
	}

	// Token: 0x0600F2C3 RID: 62147 RVA: 0x00425698 File Offset: 0x00423898
	private bool RefreshVisible()
	{
		if (this.ManipulateCursorUnit == null)
		{
			return false;
		}
		if (this.ManipulateCursorUnit.InAsyncLoading())
		{
			return false;
		}
		bool flag = !this.HasDisableTag();
		if (this.ManipulateCursorUnit.GetActive() != flag)
		{
			this.ManipulateCursorUnit.SetActive(flag);
		}
		return flag;
	}

	// Token: 0x0600F2C4 RID: 62148 RVA: 0x004256E4 File Offset: 0x004238E4
	private bool HasDisableTag()
	{
		if (this.DisableTagIds.Count == 0)
		{
			return false;
		}
		foreach (int tagId in this.DisableTagIds)
		{
			if (this.CurrentTagComponent.HasTag(tagId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600F2C5 RID: 62149 RVA: 0x00425754 File Offset: 0x00423954
	private void PlayActivateEffect()
	{
		ManipulateCursorUnit manipulateCursorUnit = this.ManipulateCursorUnit;
		if (manipulateCursorUnit == null)
		{
			return;
		}
		manipulateCursorUnit.PlayActivateEffect();
	}

	// Token: 0x0600F2C6 RID: 62150 RVA: 0x00425768 File Offset: 0x00423968
	[NullableContext(1)]
	private void Activate(Entity entity)
	{
		this.SelectEntity = entity;
		this.SelectActorComponent = entity.GetComponent<BaseActorComponent>();
		SceneItemActorComponent sceneItemActorComponent = this.SelectActorComponent as SceneItemActorComponent;
		if (sceneItemActorComponent != null)
		{
			this.SelectActor = SceneInteractionManager.Get().GetMainCollisionActor(sceneItemActorComponent.GetSceneInteractionLevelHandleId());
			AActor selectActor = this.SelectActor;
			if (selectActor == null || !selectActor.IsValid())
			{
				this.SelectActor = this.SelectActorComponent.Owner;
			}
		}
		else
		{
			this.SelectActor = this.SelectActorComponent.Owner;
		}
		this.ChangeState(EManipulateCursorState.Target);
		if (this.ManipulateCursorUnit != null)
		{
			if (!this.ManipulateCursorUnit.InAsyncLoading())
			{
				this.Refresh();
				this.RefreshVisible();
				this.PlayActivateEffect();
				this.RefreshIconPath();
			}
			return;
		}
		this.NewManipulateCursorUnit();
	}

	// Token: 0x0600F2C7 RID: 62151 RVA: 0x00425824 File Offset: 0x00423A24
	private void RefreshIconPath()
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			return;
		}
		Entity selectEntity = this.SelectEntity;
		SceneItemExploreInteractComponent sceneItemExploreInteractComponent = (selectEntity != null) ? selectEntity.GetComponent<SceneItemExploreInteractComponent>() : null;
		string iconPath = (sceneItemExploreInteractComponent != null) ? sceneItemExploreInteractComponent.ExploreSkillUiResource : null;
		ManipulateCursorUnit manipulateCursorUnit = this.ManipulateCursorUnit;
		if (manipulateCursorUnit == null)
		{
			return;
		}
		manipulateCursorUnit.SetIconPath(iconPath);
	}

	// Token: 0x0600F2C8 RID: 62152 RVA: 0x0042586E File Offset: 0x00423A6E
	private void Deactivate()
	{
		if (this.ManipulateCursorUnit == null)
		{
			return;
		}
		base.DestroyHudUnit(this.ManipulateCursorUnit);
		this.ManipulateCursorUnit = null;
		this.SelectEntity = null;
		this.SelectActorComponent = null;
		this.SelectActor = null;
	}

	// Token: 0x0600F2C9 RID: 62153 RVA: 0x004258A4 File Offset: 0x00423AA4
	private void ClearDisableTagTasks()
	{
		foreach (ITagTask tagTask in this.DisableTagTasks)
		{
			tagTask.EndTask();
		}
		this.DisableTagTasks.Clear();
	}

	// Token: 0x0600F2CA RID: 62154 RVA: 0x00425900 File Offset: 0x00423B00
	private void Refresh()
	{
		if (this.ManipulateCursorUnit == null)
		{
			return;
		}
		if (this.ManipulateCursorUnit.InAsyncLoading())
		{
			return;
		}
		if (!this.ManipulateCursorUnit.GetActive())
		{
			return;
		}
		global::Vector selectActorLocation = this.GetSelectActorLocation();
		if (selectActorLocation == null)
		{
			return;
		}
		global::Vector playerLocation = this.GetPlayerLocation();
		ValueTuple<FVector2D, FVector2D?> inEllipsePosition = base.GetInEllipsePosition(playerLocation, selectActorLocation.ToUeVector(false));
		Vector2D vector2D = new Vector2D();
		vector2D.FromUeVector2D(inEllipsePosition.Item1);
		FVector2D? item = inEllipsePosition.Item2;
		bool isInScreen = false;
		if (item != null)
		{
			isInScreen = this.FightCameraLogicComponent.GetScreenPositionIsInRange(item.Value, this.FightCameraLogicComponent.CameraAdjustController.CheckInScreenMinX, this.FightCameraLogicComponent.CameraAdjustController.CheckInScreenMaxX, this.FightCameraLogicComponent.CameraAdjustController.CheckInScreenMinY, this.FightCameraLogicComponent.CameraAdjustController.CheckInScreenMaxY);
		}
		this.ManipulateCursorUnit.Refresh(isInScreen, vector2D, this.IsCastTarget);
	}

	// Token: 0x0600F2CB RID: 62155 RVA: 0x004259E6 File Offset: 0x00423BE6
	private global::Vector GetPlayerLocation()
	{
		return this.CurrentEntityActorComponent.ActorLocationProxy;
	}

	// Token: 0x0600F2CC RID: 62156 RVA: 0x004259F4 File Offset: 0x00423BF4
	private global::Vector GetSelectActorLocation()
	{
		Entity selectEntity = this.SelectEntity;
		if (selectEntity == null || !selectEntity.Valid)
		{
			return null;
		}
		AActor selectActor = this.SelectActor;
		if (selectActor == null || !selectActor.IsValid())
		{
			return null;
		}
		global::Vector vector = global::Vector.Create(this.SelectActor.D_K2_GetActorLocation());
		SceneItemManipulatableComponent component = this.SelectEntity.GetComponent<SceneItemManipulatableComponent>();
		if (component != null && component.GetPassThroughPortalType() != CharacterManipulateComponent.EPassThroughPortalType.None)
		{
			Singleton<PortalUtils>.Instance.GetMappingPosToOtherPortal(vector, component.GetPassThroughPortalId(), component.GetPassThroughPortalType() == CharacterManipulateComponent.EPassThroughPortalType.AToB, vector);
		}
		global::Vector targetPartLocation = ModelBase<ManipulaterModel>.Instance.GetTargetPartLocation();
		if (targetPartLocation != global::Vector.ZeroVectorProxy)
		{
			vector = targetPartLocation;
		}
		SceneItemDamageComponent component2 = this.SelectEntity.GetComponent<SceneItemDamageComponent>();
		if (component2 != null && this.IsCastTarget)
		{
			vector = component2.GetHitPoint();
		}
		SceneItemOutletComponent component3 = this.SelectEntity.GetComponent<SceneItemOutletComponent>();
		if (component3 != null && this.IsCastTarget)
		{
			vector = component3.GetSocketLocation(this.CurrentEntityManipulateComponent.GetHoldingEntity());
		}
		GamePlayHitGearComponent component4 = this.SelectEntity.GetComponent<GamePlayHitGearComponent>();
		if (component4 != null && this.IsCastTarget)
		{
			vector = component4.GetHitPoint();
		}
		SceneItemExploreInteractComponent component5 = this.SelectEntity.GetComponent<SceneItemExploreInteractComponent>();
		if (component5 != null)
		{
			vector = component5.Location;
		}
		return vector;
	}

	// Token: 0x0600F2CD RID: 62157 RVA: 0x00425B16 File Offset: 0x00423D16
	private void NewManipulateCursorUnit()
	{
		base.NewHudUnitWithReturn<ManipulateCursorUnit>(typeof(ManipulateCursorUnit), "UiItem_ObjControl", out this.ManipulateCursorUnit, true, delegate(ManipulateCursorUnit _)
		{
			if (this.State == EManipulateCursorState.NoTarget)
			{
				this.Deactivate();
				return;
			}
			ManipulateCursorUnit manipulateCursorUnit = this.ManipulateCursorUnit;
			if (manipulateCursorUnit != null)
			{
				manipulateCursorUnit.SetCloseAnimCallback(new Action(this.Deactivate));
			}
			this.Refresh();
			this.RefreshVisible();
			this.PlayActivateEffect();
			this.RefreshIconPath();
		}, false);
	}

	// Token: 0x0600F2CE RID: 62158 RVA: 0x00425B44 File Offset: 0x00423D44
	private void ChangeState(EManipulateCursorState state)
	{
		if (this.State == state)
		{
			return;
		}
		EManipulateCursorState state2 = this.State;
		this.State = state;
		if (this.ManipulateCursorUnit == null)
		{
			return;
		}
		switch (this.State)
		{
		case EManipulateCursorState.NoTarget:
			if (state2 == EManipulateCursorState.Target)
			{
				this.ManipulateCursorUnit.EndProcess(true);
				this.ManipulateCursorUnit.PlayCloseAnim(0f);
				return;
			}
			if (state2 == EManipulateCursorState.Chanting)
			{
				this.ManipulateCursorUnit.EndProcess(true);
				this.ManipulateCursorUnit.PlayInterruptedAnim();
				this.ManipulateCursorUnit.PlayCloseAnim(200f);
				return;
			}
			break;
		case EManipulateCursorState.Target:
			this.ManipulateCursorUnit.StopCloseAnim();
			this.ManipulateCursorUnit.EndProcess(true);
			this.ManipulateCursorUnit.Appear();
			return;
		case EManipulateCursorState.Chanting:
			this.ManipulateCursorUnit.PlayStartAnim();
			this.ManipulateCursorUnit.PlayProcessAnim();
			return;
		case EManipulateCursorState.Holding:
			if (state2 == EManipulateCursorState.Chanting)
			{
				this.ManipulateCursorUnit.EndProcess(false);
				this.ManipulateCursorUnit.PlayCompleteAnim();
				this.ManipulateCursorUnit.PlayCloseAnim(500f);
				return;
			}
			this.ManipulateCursorUnit.PlayCloseAnim(0f);
			break;
		default:
			return;
		}
	}

	// Token: 0x04007492 RID: 29842
	private const int COMPLETE_ANIM_TIME = 500;

	// Token: 0x04007493 RID: 29843
	private const int INTERRUPT_ANIM_TIME = 200;

	// Token: 0x04007494 RID: 29844
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat ListenTagStat = Stat.Create("[ManipulateCursorHandle]ListenTag", "", "");

	// Token: 0x04007495 RID: 29845
	private EManipulateCursorState State;

	// Token: 0x04007496 RID: 29846
	private ManipulateCursorUnit ManipulateCursorUnit;

	// Token: 0x04007497 RID: 29847
	private Entity SelectEntity;

	// Token: 0x04007498 RID: 29848
	private BaseActorComponent SelectActorComponent;

	// Token: 0x04007499 RID: 29849
	private AActor SelectActor;

	// Token: 0x0400749A RID: 29850
	private FVector ActorOrigin = new FVector();

	// Token: 0x0400749B RID: 29851
	private bool IsCastTarget;

	// Token: 0x0400749C RID: 29852
	private EntityHandle CurrentEntity;

	// Token: 0x0400749D RID: 29853
	private BaseActorComponent CurrentEntityActorComponent;

	// Token: 0x0400749E RID: 29854
	private CharacterManipulateComponent CurrentEntityManipulateComponent;

	// Token: 0x0400749F RID: 29855
	private FightCameraLogicComponent FightCameraLogicComponent;

	// Token: 0x040074A0 RID: 29856
	private BaseTagComponent CurrentTagComponent;

	// Token: 0x040074A1 RID: 29857
	[Nullable(1)]
	private readonly List<int> DisableTagIds = new List<int>();

	// Token: 0x040074A2 RID: 29858
	[Nullable(1)]
	private readonly List<ITagTask> DisableTagTasks = new List<ITagTask>();

	// Token: 0x040074A3 RID: 29859
	private bool LockEntityAimVisible = true;
}
