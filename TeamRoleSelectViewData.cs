using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200279E RID: 10142
[NullableContext(2)]
[Nullable(0)]
public class TeamRoleSelectViewData : UiPopViewData
{
	// Token: 0x0601404A RID: 81994 RVA: 0x005953D4 File Offset: 0x005935D4
	public TeamRoleSelectViewData(EFilterSortGroupId useWay, int currentRoleId, [Nullable(1)] List<RoleDataBase> roleList, Action<int> confirmFunction, Action backFunction, int? position = null, ETeamRoleUseFunction? forFunction = null)
	{
		this.UseWay = new EFilterSortGroupId?(useWay);
		this.CurrentRoleId = currentRoleId;
		this.RoleList = roleList;
		this.BackCallBack = backFunction;
		this.ConfirmCallBack = confirmFunction;
		this.Position = position;
		this.ForFunction = forFunction.GetValueOrDefault();
	}

	// Token: 0x0601404B RID: 81995 RVA: 0x00595432 File Offset: 0x00593632
	[NullableContext(1)]
	public void SetHideFinishCallBack(Action hideFinishFunction)
	{
		this.OnHideFinishCallBack = hideFinishFunction;
	}

	// Token: 0x0601404C RID: 81996 RVA: 0x0059543B File Offset: 0x0059363B
	public void SetGetConfirmButtonTextFunction([Nullable(new byte[]
	{
		1,
		2
	})] Func<int, string> getConfirmButtonTextCallBack)
	{
		this.GetConfirmButtonTextCallBack = getConfirmButtonTextCallBack;
	}

	// Token: 0x0601404D RID: 81997 RVA: 0x00595444 File Offset: 0x00593644
	[NullableContext(1)]
	public void SetGetConfirmButtonEnableFunction(Func<int, bool> getConfirmButtonEnableCallBack)
	{
		this.GetConfirmButtonEnableCallBack = getConfirmButtonEnableCallBack;
	}

	// Token: 0x0601404E RID: 81998 RVA: 0x0059544D File Offset: 0x0059364D
	[NullableContext(1)]
	public void SetOtherTeamSlotData(List<EditBattleRoleSlotData> dataList)
	{
		this.EditBattleRoleSlotDataList = dataList;
	}

	// Token: 0x0601404F RID: 81999 RVA: 0x00595456 File Offset: 0x00593656
	[NullableContext(1)]
	public void SetConfirmCheckFunction(Func<int, bool> getConfirmCheckCallBack)
	{
		this.CanConfirmFunc = getConfirmCheckCallBack;
	}

	// Token: 0x04009BEE RID: 39918
	public EFilterSortGroupId? UseWay;

	// Token: 0x04009BEF RID: 39919
	public int CurrentRoleId;

	// Token: 0x04009BF0 RID: 39920
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<RoleDataBase> RoleList;

	// Token: 0x04009BF1 RID: 39921
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<EditBattleRoleSlotData> EditBattleRoleSlotDataList;

	// Token: 0x04009BF2 RID: 39922
	public int? Position = new int?(0);

	// Token: 0x04009BF3 RID: 39923
	public ETeamRoleUseFunction ForFunction;

	// Token: 0x04009BF4 RID: 39924
	public int[] FormationRoleList;

	// Token: 0x04009BF5 RID: 39925
	public bool CanUseSpecialTrialRole;

	// Token: 0x04009BF6 RID: 39926
	public Action<int> ConfirmCallBack;

	// Token: 0x04009BF7 RID: 39927
	public Action OnHideFinishCallBack;

	// Token: 0x04009BF8 RID: 39928
	public Action BackCallBack;

	// Token: 0x04009BF9 RID: 39929
	public Func<int, string> GetConfirmButtonTextCallBack;

	// Token: 0x04009BFA RID: 39930
	public Func<int, bool> GetConfirmButtonEnableCallBack;

	// Token: 0x04009BFB RID: 39931
	public Func<int, bool> IsNeedRevive;

	// Token: 0x04009BFC RID: 39932
	public Func<int, bool> CanConfirmFunc;

	// Token: 0x04009BFD RID: 39933
	public Func<int, bool> CanJoinTeam;

	// Token: 0x04009BFE RID: 39934
	public Action<int> OnRoleSelect;

	// Token: 0x04009BFF RID: 39935
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Func<int, List<TeamRoleSkillData>> GetCustomSkillShowData;

	// Token: 0x04009C00 RID: 39936
	public Action<int> DetailCallback;

	// Token: 0x04009C01 RID: 39937
	public Func<int, bool> ShowLockPanel;

	// Token: 0x04009C02 RID: 39938
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<int, string> GetLockTextCallBack;

	// Token: 0x04009C03 RID: 39939
	public Func<int, bool> GetDetailButtonVisible;

	// Token: 0x04009C04 RID: 39940
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<TeamRoleGridBase> OverrideGridProxyCreate;
}
