using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003127 RID: 12583
[NullableContext(1)]
[Nullable(0)]
public class RoleKuroFastCollisionComponent : BaseKuroFastCollisionComponent
{
	// Token: 0x0601A0D7 RID: 106711 RVA: 0x007A20AC File Offset: 0x007A02AC
	public bool CanDodge()
	{
		return this.HasDodgeTag && !this.HasUltimateDodgeTag;
	}

	// Token: 0x0601A0D8 RID: 106712 RVA: 0x007A20C1 File Offset: 0x007A02C1
	protected override bool OnStart()
	{
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		return base.OnStart();
	}

	// Token: 0x0601A0D9 RID: 106713 RVA: 0x007A20DC File Offset: 0x007A02DC
	protected override void OnStartKuroFastCollision()
	{
		if (this.IsListening)
		{
			return;
		}
		this.IsListening = true;
		if (this.TagComp == null)
		{
			return;
		}
		this.HasDodgeTag = this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌.角色闪避"]);
		this.HasUltimateDodgeTag = this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.极限闪避"]);
		this.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌.角色闪避"], new BaseTagComponent.TTagSwitchedCallback(this.OnDodgeTagChanged));
		this.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.极限闪避"], new BaseTagComponent.TTagSwitchedCallback(this.OnUltimateDodgeTagChanged));
		if (this.CanDodge())
		{
			this.UpdateDodgeState();
		}
	}

	// Token: 0x0601A0DA RID: 106714 RVA: 0x007A2192 File Offset: 0x007A0392
	protected override void OnStopKuroFastCollision()
	{
		if (!this.IsListening)
		{
			return;
		}
		this.IsListening = false;
		this.ClearAllTagCountChangedCallback();
	}

	// Token: 0x0601A0DB RID: 106715 RVA: 0x007A21AA File Offset: 0x007A03AA
	private void OnDodgeTagChanged(int tagId, bool tagExist)
	{
		this.HasDodgeTag = tagExist;
		this.UpdateDodgeState();
	}

	// Token: 0x0601A0DC RID: 106716 RVA: 0x007A21B9 File Offset: 0x007A03B9
	private void OnUltimateDodgeTagChanged(int tagId, bool tagExist)
	{
		this.HasUltimateDodgeTag = tagExist;
		this.UpdateDodgeState();
	}

	// Token: 0x0601A0DD RID: 106717 RVA: 0x007A21C8 File Offset: 0x007A03C8
	private void ListenForTagAddOrRemoveChanged(int tagId, BaseTagComponent.TTagSwitchedCallback onTagChange)
	{
		if (this.TagComp == null)
		{
			return;
		}
		ITagTask tagTask = this.TagComp.ListenForTagAddOrRemove(new int?(tagId), onTagChange, null);
		if (tagTask != null)
		{
			this.TagTaskList.Add(tagTask);
		}
	}

	// Token: 0x0601A0DE RID: 106718 RVA: 0x007A2204 File Offset: 0x007A0404
	private void ClearAllTagCountChangedCallback()
	{
		foreach (ITagTask tagTask in this.TagTaskList)
		{
			tagTask.EndTask();
		}
		this.TagTaskList.Clear();
	}

	// Token: 0x0601A0DF RID: 106719 RVA: 0x007A2260 File Offset: 0x007A0460
	private void UpdateDodgeState()
	{
		UBulletHitWorldEntityManager bulletHitWorldEntityManager = ModelBase<BulletModel>.Instance.GetBulletHitWorldEntityManager();
		if (bulletHitWorldEntityManager == null)
		{
			return;
		}
		bulletHitWorldEntityManager.SetEntityCanDodge(base.Entity.Id, this.CanDodge());
	}

	// Token: 0x0601A0E0 RID: 106720 RVA: 0x007A2294 File Offset: 0x007A0494
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleKuroFastCollisionComponent roleKuroFastCollisionComponent = (RoleKuroFastCollisionComponent)componentTemplate;
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (roleKuroFastCollisionComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HasDodgeTag"))
		{
			this.HasDodgeTag = roleKuroFastCollisionComponent.HasDodgeTag;
		}
		if (base.CanResetComponentProperty("HasUltimateDodgeTag"))
		{
			this.HasUltimateDodgeTag = roleKuroFastCollisionComponent.HasUltimateDodgeTag;
		}
		if (base.CanResetComponentProperty("TagTaskList") && roleKuroFastCollisionComponent.TagTaskList != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.TagTaskList), "TagTaskList"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("IsListening"))
		{
			this.IsListening = roleKuroFastCollisionComponent.IsListening;
		}
		return true;
	}

	// Token: 0x0400D0F4 RID: 53492
	[Nullable(2)]
	protected BaseTagComponent TagComp;

	// Token: 0x0400D0F5 RID: 53493
	private bool HasDodgeTag;

	// Token: 0x0400D0F6 RID: 53494
	private bool HasUltimateDodgeTag;

	// Token: 0x0400D0F7 RID: 53495
	private readonly List<ITagTask> TagTaskList = new List<ITagTask>();

	// Token: 0x0400D0F8 RID: 53496
	private bool IsListening;
}
