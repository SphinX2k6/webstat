using System;
using System.Runtime.CompilerServices;

// Token: 0x02002FC0 RID: 12224
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PassiveSkillPlayerQueueController : ControllerBase<PassiveSkillPlayerQueueController>
{
	// Token: 0x06018ED6 RID: 102102 RVA: 0x0071027F File Offset: 0x0070E47F
	protected override bool OnInit()
	{
		this.Queue.Clear();
		return true;
	}

	// Token: 0x06018ED7 RID: 102103 RVA: 0x0071028D File Offset: 0x0070E48D
	protected override bool OnClear()
	{
		this.Queue.Clear();
		return true;
	}

	// Token: 0x06018ED8 RID: 102104 RVA: 0x0071029B File Offset: 0x0070E49B
	public bool DoAction(TPassiveSkillQueueCallback func)
	{
		return this.Queue.DoActionCheckCd(func);
	}

	// Token: 0x0400C2D9 RID: 49881
	private readonly PassiveSkillPlayerQueue Queue = new PassiveSkillPlayerQueue();
}
