using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x02002797 RID: 10135
[NullableContext(2)]
[Nullable(0)]
public class QuickRoleSelectViewData
{
	// Token: 0x06014016 RID: 81942 RVA: 0x005939C5 File Offset: 0x00591BC5
	[NullableContext(1)]
	public QuickRoleSelectViewData(EFilterSortGroupId useWay, int[] selectedRoleList, List<RoleDataBase> roleList)
	{
		this.UseWay = new EFilterSortGroupId?(useWay);
		this.SelectedRoleList = selectedRoleList;
		this.RoleList = roleList;
	}

	// Token: 0x04009BCF RID: 39887
	public EFilterSortGroupId? UseWay;

	// Token: 0x04009BD0 RID: 39888
	public int[] SelectedRoleList;

	// Token: 0x04009BD1 RID: 39889
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<RoleDataBase> RoleList;

	// Token: 0x04009BD2 RID: 39890
	[Nullable(1)]
	public string YellowTipText = "";

	// Token: 0x04009BD3 RID: 39891
	public bool IsNeedChangeBtnState;

	// Token: 0x04009BD4 RID: 39892
	public bool CanUseSpecialTrialRole;

	// Token: 0x04009BD5 RID: 39893
	public bool ShowDetailButton = true;

	// Token: 0x04009BD6 RID: 39894
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<int[], bool> CanConfirm;

	// Token: 0x04009BD7 RID: 39895
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int[]> OnConfirm;

	// Token: 0x04009BD8 RID: 39896
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<List<int>, UniTask> OnWaitLoadingConfirm;

	// Token: 0x04009BD9 RID: 39897
	public Action OnBack;

	// Token: 0x04009BDA RID: 39898
	public Action OnHideFinish;

	// Token: 0x04009BDB RID: 39899
	public Action OnRoleSelectFull;

	// Token: 0x04009BDC RID: 39900
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<int, int[], bool> CanSelectRole;
}
