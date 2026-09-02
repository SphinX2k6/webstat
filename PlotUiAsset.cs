using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020032BE RID: 12990
[NullableContext(1)]
[Nullable(0)]
public class PlotUiAsset
{
	// Token: 0x0601B397 RID: 111511 RVA: 0x0082DEF7 File Offset: 0x0082C0F7
	public PlotUiAsset(string FlowListName, int FlowId, int StateId)
	{
		this.FlowListName = FlowListName;
		this.FlowId = FlowId;
		this.StateId = StateId;
		this.LoadPromise = new CustomPromise();
	}

	// Token: 0x0601B398 RID: 111512 RVA: 0x0082DF2A File Offset: 0x0082C12A
	public bool IsLoading()
	{
		return this.IsPlotUiAssetLoading && !this.IsPlotUiAssetLoaded;
	}

	// Token: 0x0601B399 RID: 111513 RVA: 0x0082DF3F File Offset: 0x0082C13F
	public bool IsFinished()
	{
		return this.IsPlotUiAssetLoaded;
	}

	// Token: 0x0601B39A RID: 111514 RVA: 0x0082DF48 File Offset: 0x0082C148
	public bool HasPreloadQte(List<int> qteIds)
	{
		foreach (int item in qteIds)
		{
			if (!this.QteIdSet.Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0601B39B RID: 111515 RVA: 0x0082DFA4 File Offset: 0x0082C1A4
	public UniTask WaitForLoadAsync()
	{
		PlotUiAsset.<WaitForLoadAsync>d__11 <WaitForLoadAsync>d__;
		<WaitForLoadAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitForLoadAsync>d__.<>4__this = this;
		<WaitForLoadAsync>d__.<>1__state = -1;
		<WaitForLoadAsync>d__.<>t__builder.Start<PlotUiAsset.<WaitForLoadAsync>d__11>(ref <WaitForLoadAsync>d__);
		return <WaitForLoadAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601B39C RID: 111516 RVA: 0x0082DFE7 File Offset: 0x0082C1E7
	public void Clear()
	{
		this.IsPlotUiAssetLoaded = false;
		this.IsPlotUiAssetLoading = false;
		this.QteIdSet.Clear();
	}

	// Token: 0x0601B39D RID: 111517 RVA: 0x0082E004 File Offset: 0x0082C204
	public UniTask LoadAsync()
	{
		PlotUiAsset.<LoadAsync>d__13 <LoadAsync>d__;
		<LoadAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadAsync>d__.<>4__this = this;
		<LoadAsync>d__.<>1__state = -1;
		<LoadAsync>d__.<>t__builder.Start<PlotUiAsset.<LoadAsync>d__13>(ref <LoadAsync>d__);
		return <LoadAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400DDEB RID: 56811
	private bool IsPlotUiAssetLoading;

	// Token: 0x0400DDEC RID: 56812
	private bool IsPlotUiAssetLoaded;

	// Token: 0x0400DDED RID: 56813
	[Nullable(2)]
	private readonly CustomPromise LoadPromise;

	// Token: 0x0400DDEE RID: 56814
	private readonly HashSet<int> QteIdSet = new HashSet<int>();

	// Token: 0x0400DDEF RID: 56815
	private string FlowListName;

	// Token: 0x0400DDF0 RID: 56816
	private int FlowId;

	// Token: 0x0400DDF1 RID: 56817
	private int StateId;
}
