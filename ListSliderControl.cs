using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200206E RID: 8302
[NullableContext(1)]
[Nullable(0)]
public class ListSliderControl<[Nullable(0)] T> where T : SliderItem
{
	// Token: 0x0600FD22 RID: 64802 RVA: 0x00456DEC File Offset: 0x00454FEC
	public ListSliderControl(IListSliderControlData<T> data)
	{
		this.Data = data;
		if (data == null)
		{
			return;
		}
		this.ParentUiItem = data.ParentUi;
		if (!string.IsNullOrEmpty(data.ChildResourceId))
		{
			this.ResourceId = data.ChildResourceId;
		}
		else if (data.ChildTemplate != null)
		{
			this.ChildTemplate = data.ChildTemplate;
		}
		else
		{
			this.ChildTemplate = data.ParentUi.GetAttachUIChild(0);
		}
		if (this.ChildTemplate != null)
		{
			UUIItem childTemplate = this.ChildTemplate;
			if (childTemplate != null)
			{
				childTemplate.SetUIActive(false);
			}
			this.ChildHeight = this.ChildTemplate.GetHeight();
		}
		this.LastActiveStatus = data.ParentUi.IsUIActiveInHierarchy();
		this.Layout = (data.ParentUi.GetOwner().GetComponentByClass(UUIVerticalLayout.StaticClass()) as UUIVerticalLayout);
		this.SliderMode = data.SliderMode.GetValueOrDefault(ESliderMode.SliderWhenPlayEndFinish);
		this.TickItemMode = data.TickMode.GetValueOrDefault();
		this.LastMaxCount = data.MaxShowCount.GetValueOrDefault(8);
		this.OffsetIndex = 0;
	}

	// Token: 0x0600FD23 RID: 64803 RVA: 0x00456F20 File Offset: 0x00455120
	public void SetDynamicLoadResourceId(string resourceId)
	{
		this.ResourceId = resourceId;
	}

	// Token: 0x0600FD24 RID: 64804 RVA: 0x00456F2C File Offset: 0x0045512C
	public void DisEnableParentLayout()
	{
		if (this.ParentUiItem == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.ItemHint, ELogAuthor.ZJC, "ListSliderControl错误, ParentUiItem为null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.Layout == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.ItemHint, ELogAuthor.ZJC, "ListSliderControl错误, 父节点不包含UIVerticalLayout组件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.Layout.SetEnable(false);
	}

	// Token: 0x0600FD25 RID: 64805 RVA: 0x00456F90 File Offset: 0x00455190
	public void Tick(float delta)
	{
		this.UpdateLastActiveStatus();
		this.UpdateLastMaxCount();
		if (!this.LastActiveStatus)
		{
			return;
		}
		if (this.ChildrenList.Count <= 0 && !this.CheckNext())
		{
			if (this.IsFinish)
			{
				return;
			}
			this.IsFinish = true;
			IListSliderControlData<T> data = this.Data;
			if (data == null)
			{
				return;
			}
			Action finishCallback = data.FinishCallback;
			if (finishCallback == null)
			{
				return;
			}
			finishCallback();
			return;
		}
		else
		{
			if (this.IsFinish)
			{
				this.IsFinish = false;
			}
			float num = delta;
			if (num > 20f)
			{
				num = 20f;
			}
			int num2 = 0;
			for (int i = 0; i < this.ChildrenList.Count; i++)
			{
				T t = this.ChildrenList[i];
				this.UpdateItemPosition(t, i);
				this.SliderItemTick(t, num, i);
				if (this.SliderMode != ESliderMode.SliderWhenPlayEnd || t.Status < EStatus.Over)
				{
					num2++;
				}
			}
			this.UpdateSliderProcess(num);
			this.RecycleItem();
			if (num2 > this.LastMaxCount)
			{
				return;
			}
			if (this.ShowItemCount != num2)
			{
				this.ShowItemCount = num2;
				this.SetParentHeight();
			}
			if (this.LoadState == EItemLoadState.Loading && this.NextItemAddTime > 2000f)
			{
				this.CacheItem.Status = EStatus.Destroy;
				this.CacheItem = default(T);
				this.LoadState = EItemLoadState.None;
				this.NextItemAddTime = 0f;
			}
			if (this.CheckNext())
			{
				float addItemTime = this.GetAddItemTime();
				if (this.NextItemAddTime >= addItemTime && this.LoadState == EItemLoadState.Loaded)
				{
					if (this.CacheItem != null)
					{
						this.CacheItem.SetActive(true);
						this.CacheItem.Play();
						this.CacheItem = default(T);
					}
					this.NextItemAddTime = 0f;
					this.LoadState = EItemLoadState.None;
				}
				if (this.LoadState == EItemLoadState.None)
				{
					this.LoadState = EItemLoadState.Loading;
					this.GetNewItem().ContinueWith(delegate(T item)
					{
						this.CacheItem = item;
						try
						{
							this.CacheItem.AsyncLoadUiResource().ContinueWith(delegate()
							{
								if (this.CacheItem == null)
								{
									return;
								}
								this.CacheItem.InitData();
								this.CacheItem.SetActive(false);
								this.LoadState = EItemLoadState.Loaded;
							});
						}
						catch (Exception item2)
						{
							this.CacheItem.Status = EStatus.Destroy;
							this.CacheItem = default(T);
							this.LoadState = EItemLoadState.None;
							this.NextItemAddTime = 0f;
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.ItemHint;
							ELogAuthor author = ELogAuthor.XXJ;
							string message = "[ListSliderControl::Tick]异步加载格子失败,到None";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Exception", item2);
							instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						}
					});
				}
				this.NextItemAddTime += num;
				return;
			}
			if (this.LoadState == EItemLoadState.Loading)
			{
				this.NextItemAddTime += num;
				return;
			}
			if (this.LoadState == EItemLoadState.Loaded)
			{
				Singleton<Log>.Instance.Info(ELogModule.ItemHint, ELogAuthor.XXJ, "[ListSliderControl::Tick]检查不到下个对象,执行缓存对象逻辑,到None", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CacheItem.SetActive(true);
				this.CacheItem.Play();
				this.CacheItem = default(T);
				this.LoadState = EItemLoadState.None;
				this.NextItemAddTime = 0f;
			}
			return;
		}
	}

	// Token: 0x0600FD26 RID: 64806 RVA: 0x004571F8 File Offset: 0x004553F8
	private void UpdateLastActiveStatus()
	{
		bool flag = this.ParentUiItem.IsUIActiveInHierarchy();
		if (flag != this.LastActiveStatus)
		{
			this.LastActiveStatus = flag;
			foreach (T t in this.ChildrenList)
			{
				t.ActiveStatusChange(flag);
			}
		}
	}

	// Token: 0x0600FD27 RID: 64807 RVA: 0x0045726C File Offset: 0x0045546C
	private void UpdateLastMaxCount()
	{
		int maxShowCount = this.GetMaxShowCount();
		if (maxShowCount != this.LastMaxCount)
		{
			Singleton<Log>.Instance.Info(ELogModule.ItemHint, ELogAuthor.XXJ, "[ListSliderControl::Tick]最大数量发生变化", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.LastMaxCount = maxShowCount;
			if (this.GetAddItemTime() == 0f)
			{
				foreach (T t in this.ChildrenList)
				{
					t.AddShowTime = 0f;
				}
			}
		}
	}

	// Token: 0x0600FD28 RID: 64808 RVA: 0x00457308 File Offset: 0x00455508
	private void UpdateItemPosition(T sliderItem, int index)
	{
		UUIItem rootItem = sliderItem.GetRootItem();
		float anchorOffsetY = -this.NeedSliderHeight - this.Layout.Padding.Top - this.ChildHeight * 0.5f - (float)(index + this.OffsetIndex) * (this.ChildHeight + this.Layout.Spacing);
		rootItem.SetAnchorOffsetY(anchorOffsetY);
	}

	// Token: 0x0600FD29 RID: 64809 RVA: 0x0045736C File Offset: 0x0045556C
	public void SliderItemTick(T sliderItem, float delta, int index)
	{
		sliderItem.Tick(delta);
		if (this.TickItemMode == ETickItemMode.TickOnlyTop && index != 0)
		{
			return;
		}
		if (sliderItem.Status == EStatus.Halfway)
		{
			ref T ptr = ref sliderItem;
			ptr.AddShowTime += delta;
		}
		if (this.SliderMode != ESliderMode.SliderWhenPlayEnd && index != 0)
		{
			return;
		}
		if (sliderItem.Status == EStatus.Finish)
		{
			sliderItem.Status = EStatus.Destroy;
			return;
		}
		if (sliderItem.Status == EStatus.Halfway && sliderItem.AddShowTime >= this.GetItemShowTime())
		{
			sliderItem.Status = EStatus.Over;
			sliderItem.PlayEnd();
			if (this.SliderMode == ESliderMode.SliderWhenPlayEnd)
			{
				this.OffsetIndex--;
				this.AddNeedSliderHeight();
			}
		}
	}

	// Token: 0x0600FD2A RID: 64810 RVA: 0x0045743C File Offset: 0x0045563C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<T> GetNewItem()
	{
		ListSliderControl<T>.<GetNewItem>d__28 <GetNewItem>d__;
		<GetNewItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
		<GetNewItem>d__.<>4__this = this;
		<GetNewItem>d__.<>1__state = -1;
		<GetNewItem>d__.<>t__builder.Start<ListSliderControl<T>.<GetNewItem>d__28>(ref <GetNewItem>d__);
		return <GetNewItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600FD2B RID: 64811 RVA: 0x00457480 File Offset: 0x00455680
	private void UpdateSliderProcess(float delta)
	{
		if (this.NeedSliderHeight <= 0f)
		{
			return;
		}
		this.NeedSliderHeight -= this.ChildHeight / this.GetItemSliderTime() * delta;
		if (this.NeedSliderHeight > 0f)
		{
			return;
		}
		this.NeedSliderHeight = 0f;
	}

	// Token: 0x0600FD2C RID: 64812 RVA: 0x004574D0 File Offset: 0x004556D0
	private void RecycleItem()
	{
		List<T> childrenList = this.ChildrenList;
		while (childrenList.Count > 0)
		{
			T t = childrenList[0];
			if (t.Status != EStatus.Destroy)
			{
				return;
			}
			t.Status = EStatus.None;
			childrenList.RemoveAt(0);
			t.SetActive(false);
			this.ChildrenPool.Add(t);
			if (this.SliderMode == ESliderMode.SliderWhenPlayEndFinish)
			{
				this.AddNeedSliderHeight();
			}
			else if (this.SliderMode == ESliderMode.SliderWhenPlayEnd)
			{
				this.OffsetIndex++;
			}
		}
	}

	// Token: 0x0600FD2D RID: 64813 RVA: 0x00457558 File Offset: 0x00455758
	private void AddNeedSliderHeight()
	{
		this.NeedSliderHeight += this.ChildHeight + this.Layout.Spacing;
	}

	// Token: 0x0600FD2E RID: 64814 RVA: 0x0045757C File Offset: 0x0045577C
	public void DestroyMe()
	{
		if (this.Layout != null)
		{
			this.Layout.SetEnable(true);
		}
		foreach (UiPoolActor uiPoolActor in this.PoolActorList)
		{
			Singleton<UiActorPool>.Instance.RecycleAsync(uiPoolActor, uiPoolActor.Path);
		}
		this.ChildrenPool = null;
	}

	// Token: 0x0600FD2F RID: 64815 RVA: 0x004575F4 File Offset: 0x004557F4
	private void SetParentHeight()
	{
		this.ParentUiItem.SetHeight((float)this.ShowItemCount * this.ChildHeight);
	}

	// Token: 0x0600FD30 RID: 64816 RVA: 0x0045760F File Offset: 0x0045580F
	private T CreateProxyFunction()
	{
		return this.Data.CreateProxyFunction();
	}

	// Token: 0x0600FD31 RID: 64817 RVA: 0x00457621 File Offset: 0x00455821
	private bool CheckNext()
	{
		return this.Data.CheckNext();
	}

	// Token: 0x0600FD32 RID: 64818 RVA: 0x00457634 File Offset: 0x00455834
	private int GetMaxShowCount()
	{
		IListSliderControlData<T> data = this.Data;
		return ((data != null) ? data.MaxShowCount : null).GetValueOrDefault(8);
	}

	// Token: 0x0600FD33 RID: 64819 RVA: 0x00457664 File Offset: 0x00455864
	private float GetAddItemTime()
	{
		IListSliderControlData<T> data = this.Data;
		return ((data != null) ? data.AddItemTime : null).GetValueOrDefault(100f);
	}

	// Token: 0x0600FD34 RID: 64820 RVA: 0x00457698 File Offset: 0x00455898
	private float GetItemSliderTime()
	{
		IListSliderControlData<T> data = this.Data;
		return ((data != null) ? data.ItemSliderTime : null).GetValueOrDefault(100f);
	}

	// Token: 0x0600FD35 RID: 64821 RVA: 0x004576CC File Offset: 0x004558CC
	private float GetItemShowTime()
	{
		IListSliderControlData<T> data = this.Data;
		return ((data != null) ? data.ItemShowTime : null).GetValueOrDefault(2000f);
	}

	// Token: 0x0400796D RID: 31085
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private readonly IListSliderControlData<T> Data;

	// Token: 0x0400796E RID: 31086
	[Nullable(2)]
	private readonly UUIItem ParentUiItem;

	// Token: 0x0400796F RID: 31087
	[Nullable(2)]
	private readonly UUIVerticalLayout Layout;

	// Token: 0x04007970 RID: 31088
	[Nullable(2)]
	private readonly UUIItem ChildTemplate;

	// Token: 0x04007971 RID: 31089
	private float ChildHeight;

	// Token: 0x04007972 RID: 31090
	private float NeedSliderHeight;

	// Token: 0x04007973 RID: 31091
	private int OffsetIndex;

	// Token: 0x04007974 RID: 31092
	private bool LastActiveStatus;

	// Token: 0x04007975 RID: 31093
	public bool IsFinish;

	// Token: 0x04007976 RID: 31094
	private EItemLoadState LoadState;

	// Token: 0x04007977 RID: 31095
	private int ShowItemCount;

	// Token: 0x04007978 RID: 31096
	private int LastMaxCount;

	// Token: 0x04007979 RID: 31097
	private float NextItemAddTime;

	// Token: 0x0400797A RID: 31098
	private readonly ESliderMode SliderMode;

	// Token: 0x0400797B RID: 31099
	private readonly ETickItemMode TickItemMode;

	// Token: 0x0400797C RID: 31100
	[Nullable(2)]
	private T CacheItem;

	// Token: 0x0400797D RID: 31101
	[Nullable(2)]
	private string ResourceId;

	// Token: 0x0400797E RID: 31102
	private readonly List<T> ChildrenList = new List<T>();

	// Token: 0x0400797F RID: 31103
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<T> ChildrenPool = new List<T>();

	// Token: 0x04007980 RID: 31104
	private readonly List<UiPoolActor> PoolActorList = new List<UiPoolActor>();
}
