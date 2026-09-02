using System;
using System.Runtime.CompilerServices;

// Token: 0x02003212 RID: 12818
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class SimpleNpcLoadController : ControllerBase<SimpleNpcLoadController>
{
	// Token: 0x0601AA1E RID: 109086 RVA: 0x007E703C File Offset: 0x007E523C
	protected override bool OnInit()
	{
		int capacity = 256;
		this.SimpleNpcLoadList = new Queue<TsSimpleNpc>(capacity);
		return true;
	}

	// Token: 0x0601AA1F RID: 109087 RVA: 0x007E705C File Offset: 0x007E525C
	protected override bool OnLeaveLevel()
	{
		return true;
	}

	// Token: 0x0601AA20 RID: 109088 RVA: 0x007E7060 File Offset: 0x007E5260
	protected override void OnTick(float deltaTime)
	{
		if (!ModelBase<GameModeModel>.Instance.WorldDone)
		{
			return;
		}
		if (this.SimpleNpcLoadList == null || this.SimpleNpcLoadList.Size == 0)
		{
			return;
		}
		TsSimpleNpc tsSimpleNpc = this.SimpleNpcLoadList.Pop();
		if (!ObjectUtils.IsValid(tsSimpleNpc))
		{
			return;
		}
		if (tsSimpleNpc.Mesh == null)
		{
			return;
		}
		if (tsSimpleNpc.LoadModelByDA())
		{
			tsSimpleNpc.SetDefaultCollision();
		}
		tsSimpleNpc.StartFlowLogic();
	}

	// Token: 0x0601AA21 RID: 109089 RVA: 0x007E70C2 File Offset: 0x007E52C2
	public void AddSimpleNpc(TsSimpleNpc npc)
	{
		if (this.SimpleNpcLoadList == null)
		{
			return;
		}
		this.SimpleNpcLoadList.Push(npc);
	}

	// Token: 0x0400D79C RID: 55196
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Queue<TsSimpleNpc> SimpleNpcLoadList;
}
