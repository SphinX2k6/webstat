using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001F93 RID: 8083
[NullableContext(2)]
[Nullable(0)]
public class LockPredictedHandle : HudUnitHandleBase
{
	// Token: 0x0600F285 RID: 62085 RVA: 0x004245D9 File Offset: 0x004227D9
	protected override void OnInitialize()
	{
		base.OnInitialize();
		this.ListenEntityTag();
	}

	// Token: 0x0600F286 RID: 62086 RVA: 0x004245E7 File Offset: 0x004227E7
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangeRoleNextTick));
	}

	// Token: 0x0600F287 RID: 62087 RVA: 0x00424605 File Offset: 0x00422805
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangeRoleNextTick));
	}

	// Token: 0x0600F288 RID: 62088 RVA: 0x00424623 File Offset: 0x00422823
	private void OnChangeRoleNextTick(int newEntityId, int oldEntityId)
	{
		this.ListenEntityTag();
	}

	// Token: 0x0600F289 RID: 62089 RVA: 0x0042462C File Offset: 0x0042282C
	private void ListenEntityTag()
	{
		this.EndTagTask();
		BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
		if (curRoleData == null)
		{
			return;
		}
		EntityHandle entityHandle = curRoleData.EntityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return;
		}
		BaseTagComponent gameplayTagComponent = curRoleData.GameplayTagComponent;
		if (gameplayTagComponent == null)
		{
			return;
		}
		this.HasTag = gameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.预测锁定"]);
		this.TagTask = gameplayTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.预测锁定"]), new BaseTagComponent.TTagSwitchedCallback(this.OnTagChange), null);
		if (!this.HasTag)
		{
			this.Deactivate();
		}
	}

	// Token: 0x0600F28A RID: 62090 RVA: 0x004246C7 File Offset: 0x004228C7
	private void OnTagChange(int tagId, bool bTagExists)
	{
		this.HasTag = bTagExists;
		if (!this.HasTag)
		{
			this.Deactivate();
		}
	}

	// Token: 0x0600F28B RID: 62091 RVA: 0x004246DE File Offset: 0x004228DE
	protected override void OnDestroyed()
	{
		this.LockPredictedUnit = null;
		this.EndTagTask();
	}

	// Token: 0x0600F28C RID: 62092 RVA: 0x004246ED File Offset: 0x004228ED
	private void EndTagTask()
	{
		this.HasTag = false;
		if (this.TagTask != null)
		{
			this.TagTask.EndTask();
			this.TagTask = null;
		}
	}

	// Token: 0x0600F28D RID: 62093 RVA: 0x00424710 File Offset: 0x00422910
	protected override void OnTick(float delta)
	{
		if (this.IsLoading || !this.HasTag)
		{
			return;
		}
		LockOnInfo targetInfo = this.GetTargetInfo();
		if (targetInfo != null)
		{
			EntityHandle entityHandle = targetInfo.EntityHandle;
			if (entityHandle != null && entityHandle.Valid)
			{
				FVectorDouble? worldLocation = this.GetWorldLocation(targetInfo);
				if (worldLocation == null)
				{
					this.Deactivate();
					return;
				}
				if (!HudUnitUtils.PositionUtil.ProjectWorldToScreen(worldLocation.Value, this.ScreenPos))
				{
					this.Deactivate();
					return;
				}
				this.Activate();
				if (this.LockPredictedUnit == null)
				{
					return;
				}
				UUIItem rootItem = this.LockPredictedUnit.GetRootItem();
				if (rootItem == null)
				{
					return;
				}
				rootItem.SetAnchorOffset(this.ScreenPos.ToUeVector2D(false));
				return;
			}
		}
		this.Deactivate();
	}

	// Token: 0x0600F28E RID: 62094 RVA: 0x004247C0 File Offset: 0x004229C0
	public void Activate()
	{
		if (this.LockPredictedUnit != null)
		{
			this.LockPredictedUnit.Activate();
			return;
		}
		if (this.IsLoading)
		{
			return;
		}
		this.IsLoading = true;
		base.NewHudUnit<LockPredictedUnit>(typeof(LockPredictedUnit), "UiItem_SuoDingArrow", true, false).ContinueWith(delegate(LockPredictedUnit lockPredictedUnit)
		{
			if (lockPredictedUnit == null)
			{
				return;
			}
			this.IsLoading = false;
			this.LockPredictedUnit = lockPredictedUnit;
		});
	}

	// Token: 0x0600F28F RID: 62095 RVA: 0x0042481A File Offset: 0x00422A1A
	public void Deactivate()
	{
		if (this.LockPredictedUnit == null)
		{
			return;
		}
		this.LockPredictedUnit.Deactivate();
	}

	// Token: 0x0600F290 RID: 62096 RVA: 0x00424830 File Offset: 0x00422A30
	public LockOnInfo GetTargetInfo()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || !getCurrentEntity.Valid)
		{
			return null;
		}
		return getCurrentEntity.Entity.CheckGetComponent<CharacterLockOnComponent>().GetPredictedLockOnTarget();
	}

	// Token: 0x0600F291 RID: 62097 RVA: 0x0042486C File Offset: 0x00422A6C
	[NullableContext(1)]
	protected FVectorDouble? GetWorldLocation(LockOnInfo targetInfo)
	{
		EntityHandle entityHandle = targetInfo.EntityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return null;
		}
		AActor owner = entityHandle.Entity.GetComponent<BaseActorComponent>().Owner;
		if (!(owner is TsBaseCharacter))
		{
			return null;
		}
		USkeletalMeshComponent mesh = (owner as TsBaseCharacter).Mesh;
		FName? dynamicFName = FNameUtil.GetDynamicFName(targetInfo.SocketName);
		if (dynamicFName == null || !mesh.DoesSocketExist(dynamicFName.Value))
		{
			dynamicFName = new FName?(LockPredictedHandle._hitCaseSocket);
		}
		return new FVectorDouble?(mesh.D_GetSocketLocation(dynamicFName.Value));
	}

	// Token: 0x04007477 RID: 29815
	private static readonly FName _hitCaseSocket = new FName("HitCase");

	// Token: 0x04007478 RID: 29816
	[Nullable(1)]
	private readonly Vector2D ScreenPos = new Vector2D();

	// Token: 0x04007479 RID: 29817
	private LockPredictedUnit LockPredictedUnit;

	// Token: 0x0400747A RID: 29818
	private bool IsLoading;

	// Token: 0x0400747B RID: 29819
	private bool HasTag;

	// Token: 0x0400747C RID: 29820
	private ITagTask TagTask;
}
