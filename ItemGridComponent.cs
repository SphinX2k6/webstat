using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001965 RID: 6501
[NullableContext(2)]
[Nullable(0)]
public class ItemGridComponent : UiPanelBase
{
	// Token: 0x0600BA9D RID: 47773 RVA: 0x0031AC23 File Offset: 0x00318E23
	[NullableContext(1)]
	public void Initialize(UUIItem parentItem, bool useFixedAsync)
	{
		if (this.IsInitialized)
		{
			return;
		}
		this.ParentItem = parentItem;
		this.ResourceId = this.GetResourceId();
		this.UseFixedAsync = useFixedAsync;
		this.OnInitialize();
		this.IsInitialized = true;
	}

	// Token: 0x0600BA9E RID: 47774 RVA: 0x0031AC58 File Offset: 0x00318E58
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<ItemGridComponent> Load()
	{
		ItemGridComponent.<Load>d__9 <Load>d__;
		<Load>d__.<>t__builder = AsyncUniTaskMethodBuilder<ItemGridComponent>.Create();
		<Load>d__.<>4__this = this;
		<Load>d__.<>1__state = -1;
		<Load>d__.<>t__builder.Start<ItemGridComponent.<Load>d__9>(ref <Load>d__);
		return <Load>d__.<>t__builder.Task;
	}

	// Token: 0x0600BA9F RID: 47775 RVA: 0x0031AC9C File Offset: 0x00318E9C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<ItemGridComponent> GetAsync()
	{
		ItemGridComponent.<GetAsync>d__10 <GetAsync>d__;
		<GetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<ItemGridComponent>.Create();
		<GetAsync>d__.<>4__this = this;
		<GetAsync>d__.<>1__state = -1;
		<GetAsync>d__.<>t__builder.Start<ItemGridComponent.<GetAsync>d__10>(ref <GetAsync>d__);
		return <GetAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BAA0 RID: 47776 RVA: 0x0031ACDF File Offset: 0x00318EDF
	protected override void OnStartImplement()
	{
		this.IsBegin = true;
		this.OnActivate();
		if (this.Params != null)
		{
			this.OnRefresh(this.Params);
		}
	}

	// Token: 0x0600BAA1 RID: 47777 RVA: 0x0031AD02 File Offset: 0x00318F02
	public void Refresh(object @params = null)
	{
		this.Params = @params;
		if (base.IsCreateOrCreating)
		{
			return;
		}
		if (this.UseFixedAsync)
		{
			if (this.Params != null)
			{
				this.OnRefresh(this.Params);
			}
			return;
		}
		this.OnRefresh(@params);
	}

	// Token: 0x0600BAA2 RID: 47778 RVA: 0x0031AD38 File Offset: 0x00318F38
	protected override void OnBeforeDestroyImplement()
	{
		if (this.IsBegin)
		{
			this.OnDeactivate();
		}
		this.IsBegin = false;
		this.IsInitialized = false;
		this.Params = null;
	}

	// Token: 0x0600BAA3 RID: 47779 RVA: 0x0031AD5D File Offset: 0x00318F5D
	protected virtual void OnInitialize()
	{
	}

	// Token: 0x0600BAA4 RID: 47780 RVA: 0x0031AD5F File Offset: 0x00318F5F
	protected virtual void OnActivate()
	{
	}

	// Token: 0x0600BAA5 RID: 47781 RVA: 0x0031AD61 File Offset: 0x00318F61
	protected virtual void OnDeactivate()
	{
	}

	// Token: 0x0600BAA6 RID: 47782 RVA: 0x0031AD64 File Offset: 0x00318F64
	protected virtual void OnRefresh(object @params = null)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Inventory;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "没有实现 OnRefresh";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentName", base.GetType().Name);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600BAA7 RID: 47783 RVA: 0x0031ADA4 File Offset: 0x00318FA4
	protected virtual string GetResourceId()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Inventory;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "没有实现 GetResourceId";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentName", base.GetType().Name);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600BAA8 RID: 47784 RVA: 0x0031ADE3 File Offset: 0x00318FE3
	public virtual EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Top;
	}

	// Token: 0x0600BAA9 RID: 47785 RVA: 0x0031ADE6 File Offset: 0x00318FE6
	public override void SetActive(bool visibility)
	{
		if (this.UseFixedAsync)
		{
			base.SetActive(visibility);
			Action<ItemGridComponent, bool> onComponentVisibleChanged = this.OnComponentVisibleChanged;
			if (onComponentVisibleChanged == null)
			{
				return;
			}
			onComponentVisibleChanged(this, visibility);
			return;
		}
		else
		{
			if (visibility && base.IsShowOrShowing)
			{
				return;
			}
			base.SetActive(visibility);
			return;
		}
	}

	// Token: 0x0600BAAA RID: 47786 RVA: 0x0031AE1D File Offset: 0x0031901D
	public void SetHierarchyIndex(int hierarchyIndex)
	{
		if (this.RootItem.GetHierarchyIndex() == hierarchyIndex)
		{
			return;
		}
		this.RootItem.SetHierarchyIndex(hierarchyIndex);
	}

	// Token: 0x0400584B RID: 22603
	private UUIItem ParentItem;

	// Token: 0x0400584C RID: 22604
	private string ResourceId;

	// Token: 0x0400584D RID: 22605
	private object Params;

	// Token: 0x0400584E RID: 22606
	private bool IsInitialized;

	// Token: 0x0400584F RID: 22607
	private bool IsBegin;

	// Token: 0x04005850 RID: 22608
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CustomPromise<ItemGridComponent> WaitLoadPromise;

	// Token: 0x04005851 RID: 22609
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ItemGridComponent, bool> OnComponentVisibleChanged;

	// Token: 0x04005852 RID: 22610
	private bool UseFixedAsync;
}
