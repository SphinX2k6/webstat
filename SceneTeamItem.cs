using System;
using System.Runtime.CompilerServices;

// Token: 0x0200295C RID: 10588
[NullableContext(2)]
[Nullable(0)]
public class SceneTeamItem
{
	// Token: 0x060150A2 RID: 86178 RVA: 0x005D2CFC File Offset: 0x005D0EFC
	[NullableContext(1)]
	public static SceneTeamItem Create(ETeamGroupType groupType, int playerId, int configId, long creatureDataId)
	{
		SceneTeamItem sceneTeamItem = new SceneTeamItem();
		sceneTeamItem.GroupType = groupType;
		sceneTeamItem.IsMyRoleInternal = (playerId == ModelBase<CreatureModel>.Instance.GetPlayerId());
		sceneTeamItem.PlayerId = playerId;
		sceneTeamItem.ConfigId = configId;
		sceneTeamItem.CreatureDataId = creatureDataId;
		sceneTeamItem.UpdateEntityHandle();
		EntityHandle entityHandleInternal = sceneTeamItem.EntityHandleInternal;
		object obj;
		if (entityHandleInternal == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = entityHandleInternal.Entity;
			obj = ((entity != null) ? entity.GetComponent<CreatureDataComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null && obj2.IsAutoRole())
		{
			sceneTeamItem.IsAutoRoleInternal = true;
		}
		return sceneTeamItem;
	}

	// Token: 0x060150A3 RID: 86179 RVA: 0x005D2D78 File Offset: 0x005D0F78
	public void Reset()
	{
		this.CreatureDataId = 0L;
		this.EntityHandleInternal = null;
	}

	// Token: 0x060150A4 RID: 86180 RVA: 0x005D2D89 File Offset: 0x005D0F89
	public ETeamGroupType GetGroupType()
	{
		return this.GroupType;
	}

	// Token: 0x060150A5 RID: 86181 RVA: 0x005D2D91 File Offset: 0x005D0F91
	public int GetPlayerId()
	{
		return this.PlayerId;
	}

	// Token: 0x060150A6 RID: 86182 RVA: 0x005D2D99 File Offset: 0x005D0F99
	public bool IsMyRole()
	{
		return this.IsMyRoleInternal;
	}

	// Token: 0x060150A7 RID: 86183 RVA: 0x005D2DA1 File Offset: 0x005D0FA1
	public bool IsAutoRole()
	{
		return this.IsAutoRoleInternal;
	}

	// Token: 0x060150A8 RID: 86184 RVA: 0x005D2DAC File Offset: 0x005D0FAC
	public bool IsControl()
	{
		if (!this.IsMyRoleInternal)
		{
			return this.RemoteIsControl;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity != null && this.EntityHandle != null)
		{
			int id = getCurrentEntity.Id;
			int id2 = this.EntityHandle.Id;
			return id == id2;
		}
		return false;
	}

	// Token: 0x17001B99 RID: 7065
	// (get) Token: 0x060150A9 RID: 86185 RVA: 0x005D2DF5 File Offset: 0x005D0FF5
	public int GetConfigId
	{
		get
		{
			return this.ConfigId;
		}
	}

	// Token: 0x060150AA RID: 86186 RVA: 0x005D2DFD File Offset: 0x005D0FFD
	public long GetCreatureDataId()
	{
		return this.CreatureDataId;
	}

	// Token: 0x060150AB RID: 86187 RVA: 0x005D2E05 File Offset: 0x005D1005
	public void UpdateEntityHandle()
	{
		this.EntityHandleInternal = ModelBase<CreatureModel>.Instance.GetEntity(this.CreatureDataId);
	}

	// Token: 0x17001B9A RID: 7066
	// (get) Token: 0x060150AC RID: 86188 RVA: 0x005D2E20 File Offset: 0x005D1020
	public EntityHandle EntityHandle
	{
		get
		{
			if (this.EntityHandleInternal == null || !this.EntityHandleInternal.Valid)
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.CreatureDataId);
				if (entity == null || !entity.Valid)
				{
					return null;
				}
				this.EntityHandleInternal = entity;
			}
			if (!this.EntityHandleInternal.IsInit)
			{
				return null;
			}
			return this.EntityHandleInternal;
		}
	}

	// Token: 0x060150AD RID: 86189 RVA: 0x005D2E7C File Offset: 0x005D107C
	public bool IsDead()
	{
		EntityHandle entityHandle = this.EntityHandle;
		WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
		if (worldEntity == null)
		{
			return true;
		}
		BaseDeathComponent component = worldEntity.GetComponent<BaseDeathComponent>();
		return component == null || component.IsDead();
	}

	// Token: 0x060150AE RID: 86190 RVA: 0x005D2EB4 File Offset: 0x005D10B4
	public EGoBattleResultType CanGoBattle()
	{
		EntityHandle entityHandle = this.EntityHandle;
		WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
		if (worldEntity == null)
		{
			return EGoBattleResultType.NoEntity;
		}
		CreatureDataComponent component = worldEntity.GetComponent<CreatureDataComponent>();
		if (component != null && component.GetRemoveState())
		{
			return EGoBattleResultType.EntityRemoving;
		}
		BaseDeathComponent component2 = worldEntity.GetComponent<BaseDeathComponent>();
		if (component2 == null || component2.IsDead())
		{
			return EGoBattleResultType.IsDead;
		}
		BaseTagComponent baseTagComponent = worldEntity.CheckGetComponent<BaseTagComponent>();
		if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中"]) && !baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["GameplayEvent.幻象.变身.允许切回"]))
		{
			return EGoBattleResultType.InPhantom;
		}
		return EGoBattleResultType.Success;
	}

	// Token: 0x060150AF RID: 86191 RVA: 0x005D2F3C File Offset: 0x005D113C
	public bool CanControl(bool skipCheckDead = false)
	{
		EntityHandle entityHandle = this.EntityHandle;
		WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
		if (worldEntity == null)
		{
			return false;
		}
		if (!skipCheckDead)
		{
			BaseDeathComponent component = worldEntity.GetComponent<BaseDeathComponent>();
			if (component == null || component.IsDead())
			{
				return false;
			}
		}
		return !this.IsAutoRoleInternal;
	}

	// Token: 0x060150B0 RID: 86192 RVA: 0x005D2F83 File Offset: 0x005D1183
	public void SetRemoteIsControl(bool isControl)
	{
		this.RemoteIsControl = isControl;
	}

	// Token: 0x0400A217 RID: 41495
	private bool IsMyRoleInternal;

	// Token: 0x0400A218 RID: 41496
	private bool IsAutoRoleInternal;

	// Token: 0x0400A219 RID: 41497
	private ETeamGroupType GroupType;

	// Token: 0x0400A21A RID: 41498
	private int PlayerId;

	// Token: 0x0400A21B RID: 41499
	private int ConfigId;

	// Token: 0x0400A21C RID: 41500
	private long CreatureDataId;

	// Token: 0x0400A21D RID: 41501
	private EntityHandle EntityHandleInternal;

	// Token: 0x0400A21E RID: 41502
	private bool RemoteIsControl;
}
