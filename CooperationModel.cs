using System;
using System.Runtime.CompilerServices;

// Token: 0x020017B2 RID: 6066
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class CooperationModel : ModelBase<CooperationModel>
{
	// Token: 0x0600AB27 RID: 43815 RVA: 0x002DBEDF File Offset: 0x002DA0DF
	protected override bool OnInit()
	{
		this.Handlers = new ICooperationHandler[]
		{
			new LinkCooperationHandler(),
			new QteCooperationHandler(),
			new SceneTeamCooperationHandler()
		};
		return true;
	}

	// Token: 0x0600AB28 RID: 43816 RVA: 0x002DBF08 File Offset: 0x002DA108
	protected override bool OnLeaveLevel()
	{
		if (this.Handlers != null)
		{
			ICooperationHandler[] handlers = this.Handlers;
			for (int i = 0; i < handlers.Length; i++)
			{
				handlers[i].Clear();
			}
		}
		return true;
	}

	// Token: 0x0600AB29 RID: 43817 RVA: 0x002DBF3B File Offset: 0x002DA13B
	public ICooperationHandler[] GetHandlers()
	{
		return this.Handlers;
	}

	// Token: 0x0400516C RID: 20844
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ICooperationHandler[] Handlers;
}
