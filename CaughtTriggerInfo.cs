using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003030 RID: 12336
[NullableContext(2)]
[Nullable(0)]
public class CaughtTriggerInfo
{
	// Token: 0x0601937E RID: 103294 RVA: 0x007362C0 File Offset: 0x007344C0
	[NullableContext(1)]
	public void Init(string caughtId, SCaughtInfo info, CharacterActorComponent entityActorComp, CharacterCaughtNewComponent caughtComp, int skillId)
	{
		this.Entity = entityActorComp.Entity;
		this.CaughtId = caughtId;
		this.CaughtInfo = info;
		this.TriggerInfo = this.CaughtInfo.TriggerInfo;
		int id = BulletUtil.CreateBulletFromAN(entityActorComp.Actor, this.TriggerInfo.BulletId, new FTransformDouble?(entityActorComp.ActorTransform), skillId, false, caughtComp.CaughtTriggerAnsMessageId, null, null, null);
		this.BulletEntity = ModelBase<BulletModel>.Instance.GetBulletEntityById(id);
		BulletEntity bulletEntity = this.BulletEntity;
		this.BulletActorComponent = ((bulletEntity != null) ? bulletEntity.GetComponent<BulletActorComponent>() : null);
		if (this.BulletEntity != null)
		{
			this.BulletEntity.GetBulletInfo().AddTagId(GameplayTagDefine.EGameplayTagId["子弹.通用标识.抓取判定"]);
			this.Handle = delegate(global::HitInformation hitData, HitContext _)
			{
				Entity target = hitData.Target;
				if (this.BulletEntity == null || (target == null || !target.Valid) || this.BulletEntity.Id != hitData.BulletEntityId)
				{
					return;
				}
				CreatureDataComponent component = target.GetComponent<CreatureDataComponent>();
				if (component.GetEntityType() == EEntityType.Player || component.GetEntityType() == EEntityType.Monster)
				{
					caughtComp.TryCaught(this, target);
				}
			};
			Singleton<EventSystem>.Instance.AddWithTarget<global::HitInformation, HitContext>(this.Entity, EEventName.CharHitLocal, this.Handle);
		}
	}

	// Token: 0x0601937F RID: 103295 RVA: 0x007363D4 File Offset: 0x007345D4
	public void Clear()
	{
		if (this.BulletEntity != null)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<global::HitInformation, HitContext>(this.Entity, EEventName.CharHitLocal, this.Handle);
		}
		ControllerBase<BulletController>.Instance.DestroyBullet(this.BulletEntity.Id, false, EBulletDestroyReason.Normal, false);
		this.Index = 0;
		this.CaughtId = "";
		this.TriggerInfo = null;
		this.CaughtInfo = null;
		this.BulletEntity = null;
		this.BulletActorComponent = null;
		this.Handle = null;
	}

	// Token: 0x0400C653 RID: 50771
	private Entity Entity;

	// Token: 0x0400C654 RID: 50772
	public int Index;

	// Token: 0x0400C655 RID: 50773
	[Nullable(1)]
	public string CaughtId = "";

	// Token: 0x0400C656 RID: 50774
	private SCaughtInfo CaughtInfo;

	// Token: 0x0400C657 RID: 50775
	public SCaughtTriggerInfo TriggerInfo;

	// Token: 0x0400C658 RID: 50776
	public BulletEntity BulletEntity;

	// Token: 0x0400C659 RID: 50777
	public BulletActorComponent BulletActorComponent;

	// Token: 0x0400C65A RID: 50778
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<global::HitInformation, HitContext> Handle;
}
