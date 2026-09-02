using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x02002790 RID: 10128
[NullableContext(1)]
[Nullable(0)]
internal class RoleGridContentData
{
	// Token: 0x04009B9F RID: 39839
	[Nullable(2)]
	public MultiTeamRoleGridData Data;

	// Token: 0x04009BA0 RID: 39840
	public int[] CurrentSelectedRoleList = new int[0];

	// Token: 0x04009BA1 RID: 39841
	public int CurrentTagBranchId = -1;

	// Token: 0x04009BA2 RID: 39842
	public Action<MediumItemGridExtendCallback> OnToggleCallBack = delegate(MediumItemGridExtendCallback _)
	{
	};

	// Token: 0x04009BA3 RID: 39843
	[Nullable(new byte[]
	{
		1,
		2
	})]
	public Func<object, bool, EToggleState, bool> CanExecuteChangeCallBack = (object data, bool isForceSelected, EToggleState state) => true;
}
