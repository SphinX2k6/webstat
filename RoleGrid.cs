using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002791 RID: 10129
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class RoleGrid : GridProxyAbstract<RoleGridContentData>
{
	// Token: 0x06013FD6 RID: 81878 RVA: 0x005920C4 File Offset: 0x005902C4
	protected override void OnStart()
	{
	}

	// Token: 0x06013FD7 RID: 81879 RVA: 0x005920C6 File Offset: 0x005902C6
	public override void Refresh(RoleGridContentData data, bool isSelected, int gridIndex)
	{
		this.RefreshMediumItemGrid(data);
	}

	// Token: 0x06013FD8 RID: 81880 RVA: 0x005920D0 File Offset: 0x005902D0
	private UniTask RefreshMediumItemGrid(RoleGridContentData data)
	{
		RoleGrid.<RefreshMediumItemGrid>d__4 <RefreshMediumItemGrid>d__;
		<RefreshMediumItemGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshMediumItemGrid>d__.<>4__this = this;
		<RefreshMediumItemGrid>d__.data = data;
		<RefreshMediumItemGrid>d__.<>1__state = -1;
		<RefreshMediumItemGrid>d__.<>t__builder.Start<RoleGrid.<RefreshMediumItemGrid>d__4>(ref <RefreshMediumItemGrid>d__);
		return <RefreshMediumItemGrid>d__.<>t__builder.Task;
	}

	// Token: 0x04009BA4 RID: 39844
	[Nullable(2)]
	private CustomPromise LoadPromise;

	// Token: 0x04009BA5 RID: 39845
	[Nullable(2)]
	private MediumItemGrid MediumItemGrid;
}
