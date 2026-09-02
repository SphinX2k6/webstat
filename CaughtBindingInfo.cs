using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

// Token: 0x02003031 RID: 12337
[NullableContext(2)]
[Nullable(0)]
public class CaughtBindingInfo
{
	// Token: 0x170021FE RID: 8702
	// (get) Token: 0x06019381 RID: 103297 RVA: 0x00736462 File Offset: 0x00734662
	public BulletEntity BulletEntity
	{
		get
		{
			if (this.BulletEntityId != null)
			{
				return Singleton<EntitySystem>.Instance.Get(this.BulletEntityId.Value) as BulletEntity;
			}
			return null;
		}
	}

	// Token: 0x06019382 RID: 103298 RVA: 0x00736490 File Offset: 0x00734690
	[NullableContext(1)]
	public CaughtBindingInfo(string id, SCaughtInfo info, CharacterActorComponent entityActorComp, CharacterCaughtNewComponent caughtComp, int skillId)
	{
		this.CaughtId = id;
		this.CaughtInfo = info;
		this.BindingInfo = this.CaughtInfo.BindingInfo;
		SCaughtBindingInfo bindingInfo = this.BindingInfo;
		if (!string.IsNullOrEmpty((bindingInfo != null) ? bindingInfo.BulletId : null))
		{
			this.BulletEntityId = new int?(BulletUtil.CreateBulletFromAN(entityActorComp.Actor, this.BindingInfo.BulletId, new FTransformDouble?(entityActorComp.ActorTransform), skillId, false, caughtComp.CaughtBindingAnsMessageId, null, null, null));
		}
		BulletEntity bulletEntity = this.BulletEntity;
		this.BulletActorComponent = ((bulletEntity != null) ? bulletEntity.GetComponent<BulletActorComponent>() : null);
	}

	// Token: 0x06019383 RID: 103299 RVA: 0x0073654F File Offset: 0x0073474F
	public void Clear()
	{
		this.CaughtId = "";
		this.BindingInfo = null;
		this.CaughtInfo = null;
		this.BulletEntityId = null;
		this.BulletActorComponent = null;
	}

	// Token: 0x0400C65B RID: 50779
	[Nullable(1)]
	public string CaughtId;

	// Token: 0x0400C65C RID: 50780
	private SCaughtInfo CaughtInfo;

	// Token: 0x0400C65D RID: 50781
	public SCaughtBindingInfo BindingInfo;

	// Token: 0x0400C65E RID: 50782
	public int? BulletEntityId;

	// Token: 0x0400C65F RID: 50783
	public BulletActorComponent BulletActorComponent;

	// Token: 0x0400C660 RID: 50784
	[Nullable(1)]
	public List<Entity> Targets = new List<Entity>();
}
