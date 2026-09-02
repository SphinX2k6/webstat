using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;

// Token: 0x02000FA8 RID: 4008
public class ProjectionPhotoViewParams : TPartialMultipleView
{
	// Token: 0x040030C6 RID: 12486
	public long EntityId;

	// Token: 0x040030C7 RID: 12487
	public int PbDataId;

	// Token: 0x040030C8 RID: 12488
	[Nullable(1)]
	public IProjectionMachine Config;

	// Token: 0x040030C9 RID: 12489
	[Nullable(2)]
	public Action<bool> FinishCallback;
}
