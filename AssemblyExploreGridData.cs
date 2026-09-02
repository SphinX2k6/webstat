using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;

// Token: 0x0200291C RID: 10524
public class AssemblyExploreGridData : AssemblyGridData
{
	// Token: 0x17001B71 RID: 7025
	// (get) Token: 0x06014E0C RID: 85516 RVA: 0x005C799F File Offset: 0x005C5B9F
	public bool HasNew
	{
		get
		{
			return ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.RouletteAssemblyItemRedDot, this.Id);
		}
	}

	// Token: 0x06014E0D RID: 85517 RVA: 0x005C79B2 File Offset: 0x005C5BB2
	public AssemblyExploreGridData()
	{
		this.IconPath = "";
	}

	// Token: 0x0400A0EB RID: 41195
	[Nullable(1)]
	public string IconPath;
}
