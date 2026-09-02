using System;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02002D7A RID: 11642
public class BulletActionAttachParentEffect : BulletActionBase
{
	// Token: 0x060177D2 RID: 96210 RVA: 0x00682A14 File Offset: 0x00680C14
	public BulletActionAttachParentEffect(EBulletAction type) : base(type)
	{
	}

	// Token: 0x060177D3 RID: 96211 RVA: 0x00682A20 File Offset: 0x00680C20
	protected override void OnTick(float delta)
	{
		BulletInfo bulletInfo = this.BulletInfo;
		if (bulletInfo.NeedDestroy)
		{
			return;
		}
		AActor sureEffectActor = Singleton<EffectSystem>.Instance.GetSureEffectActor(bulletInfo.ParentEffect);
		if (sureEffectActor != null)
		{
			BulletUtil.AttachParentEffectSkeleton(bulletInfo, sureEffectActor, bulletInfo.ParentEffect);
			this.IsFinish = true;
		}
	}
}
