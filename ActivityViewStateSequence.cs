using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001161 RID: 4449
public class ActivityViewStateSequence : IStaticVariableResetter
{
	// Token: 0x06007510 RID: 29968 RVA: 0x001ECC1F File Offset: 0x001EAE1F
	static ActivityViewStateSequence()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ActivityViewStateSequence.CreateStaticDefaultValue), new Action(ActivityViewStateSequence.ResetStaticDefaultValue));
	}

	// Token: 0x06007511 RID: 29969 RVA: 0x001ECC40 File Offset: 0x001EAE40
	public static void CreateStaticDefaultValue()
	{
		ActivityViewStateSequence.Value = new Dictionary<EActivityViewState, string[]>
		{
			{
				EActivityViewState.Side,
				new string[]
				{
					"SideIn",
					"SideOut"
				}
			},
			{
				EActivityViewState.Global,
				new string[]
				{
					"GlobalIn",
					"GlobalOut"
				}
			}
		};
	}

	// Token: 0x06007512 RID: 29970 RVA: 0x001ECC93 File Offset: 0x001EAE93
	public static void ResetStaticDefaultValue()
	{
		ActivityViewStateSequence.Value = null;
	}

	// Token: 0x040038C6 RID: 14534
	[Nullable(1)]
	public static Dictionary<EActivityViewState, string[]> Value;
}
