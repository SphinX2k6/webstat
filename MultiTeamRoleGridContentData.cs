using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x0200278E RID: 10126
[NullableContext(1)]
[Nullable(0)]
public class MultiTeamRoleGridContentData
{
	// Token: 0x04009B98 RID: 39832
	public bool ShowGridAnimation;

	// Token: 0x04009B99 RID: 39833
	[Nullable(2)]
	public MultiTeamRoleData Data;

	// Token: 0x04009B9A RID: 39834
	public int[] CurrentSelectedRoleList = new int[0];

	// Token: 0x04009B9B RID: 39835
	public Dictionary<int, int> CurrentSelectTagMap = new Dictionary<int, int>();

	// Token: 0x04009B9C RID: 39836
	public Action<MediumItemGridExtendCallback> OnToggleCallBack = delegate(MediumItemGridExtendCallback _)
	{
	};

	// Token: 0x04009B9D RID: 39837
	public Func<object, bool, EToggleState, bool> CanExecuteChangeCallBack = (object data, bool isForceSelected, EToggleState state) => true;
}
