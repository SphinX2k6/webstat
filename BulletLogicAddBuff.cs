using System;
using System.Runtime.CompilerServices;

// Token: 0x02002DB8 RID: 11704
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicAddBuff : BulletLogicController<LogicDataAddBuff, object>
{
	// Token: 0x060179C8 RID: 96712 RVA: 0x00691BA8 File Offset: 0x0068FDA8
	[NullableContext(1)]
	public BulletLogicAddBuff(LogicDataAddBuff logicData, Entity bulletEntity) : base(logicData, bulletEntity)
	{
		this.Config = logicData;
	}

	// Token: 0x060179C9 RID: 96713 RVA: 0x00691BBC File Offset: 0x0068FDBC
	public override void BulletLogicAction(object param = null)
	{
		if (this.Config == null)
		{
			return;
		}
		BulletInfo bulletInfo = this.Bullet.GetBulletInfo();
		BaseBuffComponent attackerBuffComp = bulletInfo.AttackerBuffComp;
		if (attackerBuffComp == null)
		{
			return;
		}
		BaseBuffComponent baseBuffComponent = attackerBuffComp;
		long buffId = this.Config.BuffId;
		AddBuffParam addBuffParam = new AddBuffParam();
		addBuffParam.InstigatorId = attackerBuffComp.CreatureDataId;
		addBuffParam.Level = new int?(bulletInfo.SkillLevel);
		addBuffParam.PreMessageId = bulletInfo.ContextId;
		string str = "子弹";
		BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
		addBuffParam.Reason = str + ((bulletDataMain != null) ? bulletDataMain.BulletRowName : null) + "GB添加buff";
		addBuffParam.BulletMessageId = bulletInfo.ContextId;
		baseBuffComponent.AddBuff(buffId, addBuffParam);
	}

	// Token: 0x0400B5D0 RID: 46544
	private readonly LogicDataAddBuff Config;
}
