using System;
using System.Runtime.CompilerServices;

// Token: 0x02002DC2 RID: 11714
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicDestroyOtherBullet : BulletLogicController<LogicDataDestroyOtherBullet, Entity>
{
	// Token: 0x060179EE RID: 96750 RVA: 0x00693047 File Offset: 0x00691247
	public BulletLogicDestroyOtherBullet(LogicDataDestroyOtherBullet data, Entity bullet) : base(data, bullet)
	{
	}

	// Token: 0x060179EF RID: 96751 RVA: 0x00693051 File Offset: 0x00691251
	public override void OnInit()
	{
		this.Bullet.GetBulletInfo().BulletDataMain.Execution.SupportCamp.Add(this.LogicController.Camp);
	}

	// Token: 0x060179F0 RID: 96752 RVA: 0x00693080 File Offset: 0x00691280
	[NullableContext(2)]
	public override void BulletLogicAction(Entity otherBullet)
	{
		BulletInfo bulletInfo = (otherBullet as BulletEntity).GetBulletInfo();
		string bulletId = this.LogicController.BulletId;
		if (!StringUtils.IsEmpty(bulletId) && bulletId != bulletInfo.BulletRowName)
		{
			return;
		}
		ControllerBase<BulletController>.Instance.DestroyBullet(otherBullet.Id, this.LogicController.SummonChildBullet, EBulletDestroyReason.Normal, false);
	}
}
