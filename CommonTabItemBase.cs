using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001A65 RID: 6757
[NullableContext(1)]
[Nullable(0)]
public abstract class CommonTabItemBase : UiPanelBase, IGridProxy<CommonTabItemData>
{
	// Token: 0x0600C162 RID: 49506 RVA: 0x0032F229 File Offset: 0x0032D429
	public CommonTabItemBase()
	{
	}

	// Token: 0x17000FDA RID: 4058
	// (get) Token: 0x0600C163 RID: 49507 RVA: 0x0032F231 File Offset: 0x0032D431
	// (set) Token: 0x0600C164 RID: 49508 RVA: 0x0032F239 File Offset: 0x0032D439
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<CommonTabItemData>, CommonTabItemData> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x17000FDB RID: 4059
	// (get) Token: 0x0600C165 RID: 49509 RVA: 0x0032F242 File Offset: 0x0032D442
	// (set) Token: 0x0600C166 RID: 49510 RVA: 0x0032F24A File Offset: 0x0032D44A
	public int GridIndex { get; set; }

	// Token: 0x17000FDC RID: 4060
	// (get) Token: 0x0600C167 RID: 49511 RVA: 0x0032F253 File Offset: 0x0032D453
	// (set) Token: 0x0600C168 RID: 49512 RVA: 0x0032F25B File Offset: 0x0032D45B
	public int DisplayIndex { get; set; }

	// Token: 0x0600C169 RID: 49513 RVA: 0x0032F264 File Offset: 0x0032D464
	public virtual void Refresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		this.OnRefresh(data, isSelected, gridIndex);
	}

	// Token: 0x0600C16A RID: 49514 RVA: 0x0032F276 File Offset: 0x0032D476
	protected virtual void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
	}

	// Token: 0x0600C16B RID: 49515 RVA: 0x0032F278 File Offset: 0x0032D478
	public virtual void Clear()
	{
		this.OnClear();
	}

	// Token: 0x0600C16C RID: 49516 RVA: 0x0032F280 File Offset: 0x0032D480
	protected virtual void OnClear()
	{
	}

	// Token: 0x0600C16D RID: 49517 RVA: 0x0032F282 File Offset: 0x0032D482
	public virtual void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600C16E RID: 49518 RVA: 0x0032F284 File Offset: 0x0032D484
	public virtual void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600C16F RID: 49519 RVA: 0x0032F286 File Offset: 0x0032D486
	public void CreateThenShowByActor(AActor actor)
	{
		base.CreateThenShowByActor(actor, null);
	}

	// Token: 0x0600C170 RID: 49520 RVA: 0x0032F290 File Offset: 0x0032D490
	public UniTask CreateThenShowByActorAsync(AActor actor)
	{
		return base.CreateThenShowByActorAsync(actor, null, false);
	}

	// Token: 0x0600C171 RID: 49521 RVA: 0x0032F29B File Offset: 0x0032D49B
	public UniTask CreateByActorAsync(AActor actor)
	{
		return base.CreateByActorAsync(actor, null, false);
	}

	// Token: 0x0600C172 RID: 49522 RVA: 0x0032F2A6 File Offset: 0x0032D4A6
	public virtual object GetKey(CommonTabItemData data, int gridIndex)
	{
		return this.GridIndex;
	}

	// Token: 0x0600C173 RID: 49523 RVA: 0x0032F2B3 File Offset: 0x0032D4B3
	public virtual void InitTabItem()
	{
	}

	// Token: 0x0600C174 RID: 49524 RVA: 0x0032F2B5 File Offset: 0x0032D4B5
	protected override void OnStart()
	{
		this.GetTabToggle().CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
	}

	// Token: 0x0600C175 RID: 49525 RVA: 0x0032F2D3 File Offset: 0x0032D4D3
	private bool CanExecuteChange()
	{
		if (this.CanExecuteChangeFunction != null)
		{
			bool result = this.CanExecuteChangeFunction(this.GridIndex, this.AllowForceSwitch);
			this.AllowForceSwitch = false;
			return result;
		}
		return true;
	}

	// Token: 0x0600C176 RID: 49526 RVA: 0x0032F2FD File Offset: 0x0032D4FD
	public void SetSelectedCallBack(Action<int> callback)
	{
		this.SelectedCallBack = callback;
	}

	// Token: 0x0600C177 RID: 49527 RVA: 0x0032F306 File Offset: 0x0032D506
	public void SetCanExecuteChange(Func<int, bool, bool> callback)
	{
		this.CanExecuteChangeFunction = callback;
	}

	// Token: 0x0600C178 RID: 49528 RVA: 0x0032F30F File Offset: 0x0032D50F
	public void UpdateTabIcon(string iconPath)
	{
		this.OnUpdateTabIcon(iconPath);
	}

	// Token: 0x0600C179 RID: 49529 RVA: 0x0032F318 File Offset: 0x0032D518
	public void SetForceSwitch(EToggleState state, bool bFire = false)
	{
		this.AllowForceSwitch = true;
		this.SetToggleState(state, bFire);
	}

	// Token: 0x0600C17A RID: 49530 RVA: 0x0032F329 File Offset: 0x0032D529
	public void SetToggleState(EToggleState state, bool bFire = false)
	{
		this.OnSetToggleState(state, bFire);
	}

	// Token: 0x0600C17B RID: 49531
	protected abstract void OnUpdateTabIcon(string iconPath);

	// Token: 0x0600C17C RID: 49532
	protected abstract void OnSetToggleState(EToggleState state, bool bFire);

	// Token: 0x0600C17D RID: 49533
	protected abstract UUIExtendToggle GetTabToggle();

	// Token: 0x04005A8C RID: 23180
	[Nullable(2)]
	protected CommonTabItemData CurrentData;

	// Token: 0x04005A90 RID: 23184
	private bool AllowForceSwitch;

	// Token: 0x04005A91 RID: 23185
	[Nullable(2)]
	protected Action<int> SelectedCallBack;

	// Token: 0x04005A92 RID: 23186
	[Nullable(2)]
	private Func<int, bool, bool> CanExecuteChangeFunction;
}
