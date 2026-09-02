using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001215 RID: 4629
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MutexGroupItem : GridProxyAbstract<IBabelTowerMutexGroupData>
{
	// Token: 0x06007ADA RID: 31450 RVA: 0x00201B48 File Offset: 0x001FFD48
	[NullableContext(1)]
	public void SetParentItem(BabelTowerSvBuffItem parent)
	{
		this.ParentItem = parent;
	}

	// Token: 0x06007ADB RID: 31451 RVA: 0x00201B51 File Offset: 0x001FFD51
	public bool IsQuickSelectMode()
	{
		BabelTowerSvBuffItem parentItem = this.ParentItem;
		return parentItem != null && parentItem.IsQuickSelectMode();
	}

	// Token: 0x06007ADC RID: 31452 RVA: 0x00201B64 File Offset: 0x001FFD64
	public bool GetIsNecessary()
	{
		return this.IsNecessary;
	}

	// Token: 0x06007ADD RID: 31453 RVA: 0x00201B6C File Offset: 0x001FFD6C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007ADE RID: 31454 RVA: 0x00201BD8 File Offset: 0x001FFDD8
	protected override UniTask OnBeforeStartAsync()
	{
		MutexGroupItem.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MutexGroupItem.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007ADF RID: 31455 RVA: 0x00201C1C File Offset: 0x001FFE1C
	[NullableContext(1)]
	public override void Refresh(IBabelTowerMutexGroupData data, bool isSelected, int gridIndex)
	{
		this.IsNecessary = data.IsNecessary.GetValueOrDefault();
		List<int> deTermList = data.DeTermList;
		GenericLayout<SvBuffGridItem, int> buffLayout = this.BuffLayout;
		if (buffLayout == null)
		{
			return;
		}
		Func<bool> <>9__2;
		Func<bool> <>9__3;
		buffLayout.RefreshByData(deTermList, delegate
		{
			List<SvBuffGridItem> layoutItemList = this.BuffLayout.GetLayoutItemList();
			foreach (SvBuffGridItem svBuffGridItem in layoutItemList)
			{
				svBuffGridItem.SuppressToggleCallback(true);
			}
			foreach (SvBuffGridItem svBuffGridItem2 in layoutItemList)
			{
				IBabelTowerSelectInfo valueOrDefault = ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo.GetValueOrDefault(svBuffGridItem2.BuffId);
				if (valueOrDefault != null && valueOrDefault.State == EBabelTowerDeTermState.Lock)
				{
					svBuffGridItem2.SetToggleState(EToggleState.ETT_UnDetermined);
					svBuffGridItem2.SetCanClickCallBack(() => true);
				}
				else if ((valueOrDefault != null && valueOrDefault.State == EBabelTowerDeTermState.Select) || (valueOrDefault != null && valueOrDefault.State == EBabelTowerDeTermState.StaticSelect))
				{
					svBuffGridItem2.SetToggleState(EToggleState.ETT_Checked);
					SvBuffGridItem svBuffGridItem3 = svBuffGridItem2;
					Func<bool> canClickCallBack;
					if ((canClickCallBack = <>9__2) == null)
					{
						canClickCallBack = (<>9__2 = delegate()
						{
							if (this.IsNecessary)
							{
								ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerNecessaryDeTerm", Array.Empty<object>());
								return false;
							}
							return true;
						});
					}
					svBuffGridItem3.SetCanClickCallBack(canClickCallBack);
				}
				else
				{
					svBuffGridItem2.SetToggleState(EToggleState.ETT_UnChecked);
					SvBuffGridItem svBuffGridItem4 = svBuffGridItem2;
					Func<bool> canClickCallBack2;
					if ((canClickCallBack2 = <>9__3) == null)
					{
						canClickCallBack2 = (<>9__3 = delegate()
						{
							if (this.IsNecessary)
							{
								ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerNecessaryDeTerm", Array.Empty<object>());
								return false;
							}
							return true;
						});
					}
					svBuffGridItem4.SetCanClickCallBack(canClickCallBack2);
				}
			}
			foreach (SvBuffGridItem svBuffGridItem5 in layoutItemList)
			{
				svBuffGridItem5.SuppressToggleCallback(false);
			}
			this.CurrentDeTermId = data.CurrentDeTermId.GetValueOrDefault();
			this.RefreshItemColor();
		}, false);
	}

	// Token: 0x06007AE0 RID: 31456 RVA: 0x00201C80 File Offset: 0x001FFE80
	public void HandleToggle(int deTermId, UUIExtendToggle toggle)
	{
		if (this.IsNecessary)
		{
			return;
		}
		if (this.IsHandlingToggle)
		{
			return;
		}
		this.IsHandlingToggle = true;
		int currentDeTermId = this.CurrentDeTermId;
		if (deTermId != 0)
		{
			BabelTowerSelectInfo babelTowerSelectInfo = new BabelTowerSelectInfo();
			babelTowerSelectInfo.State = EBabelTowerDeTermState.Normal;
			BabelTowerModel instance = ModelBase<BabelTowerModel>.Instance;
			int deTermSelectIndex = instance.DeTermSelectIndex;
			instance.DeTermSelectIndex = deTermSelectIndex + 1;
			babelTowerSelectInfo.SelectIndex = deTermSelectIndex;
			BabelTowerSelectInfo value = babelTowerSelectInfo;
			ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[currentDeTermId] = value;
			BabelTowerSelectInfo babelTowerSelectInfo2 = new BabelTowerSelectInfo();
			babelTowerSelectInfo2.State = EBabelTowerDeTermState.Select;
			BabelTowerModel instance2 = ModelBase<BabelTowerModel>.Instance;
			deTermSelectIndex = instance2.DeTermSelectIndex;
			instance2.DeTermSelectIndex = deTermSelectIndex + 1;
			babelTowerSelectInfo2.SelectIndex = deTermSelectIndex;
			BabelTowerSelectInfo value2 = babelTowerSelectInfo2;
			ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[deTermId] = value2;
		}
		else
		{
			BabelTowerSelectInfo babelTowerSelectInfo3 = new BabelTowerSelectInfo();
			babelTowerSelectInfo3.State = EBabelTowerDeTermState.Normal;
			BabelTowerModel instance3 = ModelBase<BabelTowerModel>.Instance;
			int deTermSelectIndex = instance3.DeTermSelectIndex;
			instance3.DeTermSelectIndex = deTermSelectIndex + 1;
			babelTowerSelectInfo3.SelectIndex = deTermSelectIndex;
			BabelTowerSelectInfo value3 = babelTowerSelectInfo3;
			ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[currentDeTermId] = value3;
		}
		this.CurrentDeTermId = deTermId;
		this.IsHandlingToggle = false;
		Singleton<EventSystem>.Instance.Emit(EEventName.BabelTowerRefreshLevelInfo);
		BabelTowerSvBuffItem parentItem = this.ParentItem;
		if (parentItem == null)
		{
			return;
		}
		parentItem.NotifyDeTermToggle(deTermId);
	}

	// Token: 0x06007AE1 RID: 31457 RVA: 0x00201D90 File Offset: 0x001FFF90
	private void RefreshItemColor()
	{
		GenericLayout<SvBuffGridItem, int> buffLayout = this.BuffLayout;
		List<SvBuffGridItem> list = (buffLayout != null) ? buffLayout.GetLayoutItemList() : null;
		if (list == null)
		{
			return;
		}
		foreach (SvBuffGridItem svBuffGridItem in list)
		{
			IBabelTowerSelectInfo valueOrDefault = ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo.GetValueOrDefault(svBuffGridItem.BuffId);
			bool flag = valueOrDefault != null && valueOrDefault.State == EBabelTowerDeTermState.Normal;
			svBuffGridItem.UseChangeColor(flag && this.CurrentDeTermId != 0);
		}
	}

	// Token: 0x06007AE2 RID: 31458 RVA: 0x00201E28 File Offset: 0x00200028
	[NullableContext(1)]
	private SvBuffGridItem CreateBuffItem()
	{
		SvBuffGridItem svBuffGridItem = new SvBuffGridItem();
		svBuffGridItem.SetParentItem(this);
		svBuffGridItem.OnClickCallBack = new Action<int, UUIExtendToggle>(this.OnBuffItemClick);
		return svBuffGridItem;
	}

	// Token: 0x06007AE3 RID: 31459 RVA: 0x00201E48 File Offset: 0x00200048
	private void OnBuffItemClick(int deTermId, UUIExtendToggle toggle)
	{
		this.HandleToggle(deTermId, toggle);
	}

	// Token: 0x06007AE4 RID: 31460 RVA: 0x00201E54 File Offset: 0x00200054
	public SvBuffGridItem GetBuffItemById(int deTermId)
	{
		GenericLayout<SvBuffGridItem, int> buffLayout = this.BuffLayout;
		List<SvBuffGridItem> list = (buffLayout != null) ? buffLayout.GetLayoutItemList() : null;
		if (list == null)
		{
			return null;
		}
		foreach (SvBuffGridItem svBuffGridItem in list)
		{
			if (svBuffGridItem.BuffId == deTermId)
			{
				return svBuffGridItem;
			}
		}
		return null;
	}

	// Token: 0x04003AEC RID: 15084
	public Action<int, UUIExtendToggle> OnBuffClick;

	// Token: 0x04003AED RID: 15085
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<SvBuffGridItem, int> BuffLayout;

	// Token: 0x04003AEE RID: 15086
	private bool IsNecessary;

	// Token: 0x04003AEF RID: 15087
	private int CurrentDeTermId;

	// Token: 0x04003AF0 RID: 15088
	private bool IsHandlingToggle;

	// Token: 0x04003AF1 RID: 15089
	private BabelTowerSvBuffItem ParentItem;

	// Token: 0x0200756B RID: 30059
	[NullableContext(0)]
	private class EBuffItemSubComponent
	{
		// Token: 0x04028838 RID: 165944
		public const int GridLayout = 0;

		// Token: 0x04028839 RID: 165945
		public const int ItemGroup = 1;
	}
}
