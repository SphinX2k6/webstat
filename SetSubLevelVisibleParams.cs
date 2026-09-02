using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x0200349D RID: 13469
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class SetSubLevelVisibleParams
{
	// Token: 0x0601C6B3 RID: 116403 RVA: 0x0088446C File Offset: 0x0088266C
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public SetSubLevelVisibleParams()
	{
	}

	// Token: 0x0400E499 RID: 58521
	[RequiredMember]
	public ClientPreEnableSubLevels ActionParams;

	// Token: 0x0400E49A RID: 58522
	[RequiredMember]
	public GeneralContext Context;

	// Token: 0x0400E49B RID: 58523
	public int ActionId;

	// Token: 0x0400E49C RID: 58524
	public int GroupId;

	// Token: 0x0400E49D RID: 58525
	[RequiredMember]
	public Action<bool> FinishCallback;
}
