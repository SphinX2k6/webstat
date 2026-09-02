using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020010DC RID: 4316
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerGroupAction : GuessJokerActionBase
{
	// Token: 0x06007081 RID: 28801 RVA: 0x001D5FCF File Offset: 0x001D41CF
	public GuessJokerGroupAction(GuessJokerActionBase[] actions)
	{
		this.Actions.AddRange(actions);
	}

	// Token: 0x06007082 RID: 28802 RVA: 0x001D5FF0 File Offset: 0x001D41F0
	protected override void OnStart()
	{
		if (this.Actions.Count == 0)
		{
			this.Done = true;
			return;
		}
		for (int i = 0; i < this.Actions.Count; i++)
		{
			this.Actions[i].Start();
		}
	}

	// Token: 0x06007083 RID: 28803 RVA: 0x001D603C File Offset: 0x001D423C
	protected override void OnTick(float delta)
	{
		for (int i = 0; i < this.Actions.Count; i++)
		{
			this.Actions[i].Tick(delta);
		}
		bool flag = true;
		for (int j = 0; j < this.Actions.Count; j++)
		{
			if (!this.Actions[j].IsDone())
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			this.Done = true;
		}
	}

	// Token: 0x06007084 RID: 28804 RVA: 0x001D60AC File Offset: 0x001D42AC
	protected override void OnFinish()
	{
		for (int i = 0; i < this.Actions.Count; i++)
		{
			this.Actions[i].Finish();
		}
	}

	// Token: 0x0400361E RID: 13854
	private readonly List<GuessJokerActionBase> Actions = new List<GuessJokerActionBase>();
}
