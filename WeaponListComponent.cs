using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D14 RID: 11540
[NullableContext(1)]
[Nullable(0)]
public class WeaponListComponent
{
	// Token: 0x06017491 RID: 95377 RVA: 0x006741AF File Offset: 0x006723AF
	public void Init(UUIScrollViewWithScrollbarComponent scrollView)
	{
		this.ScrollView = new GenericScrollViewNew<WeaponItemSmallItemGrid, WeaponDataBase>(scrollView, new Func<WeaponItemSmallItemGrid>(this.InitWeaponItem), null, false, null);
	}

	// Token: 0x06017492 RID: 95378 RVA: 0x006741CC File Offset: 0x006723CC
	protected WeaponItemSmallItemGrid InitWeaponItem()
	{
		WeaponItemSmallItemGrid weaponItemSmallItemGrid = new WeaponItemSmallItemGrid();
		weaponItemSmallItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnToggleClick));
		weaponItemSmallItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanToggleExecuteChange));
		return weaponItemSmallItemGrid;
	}

	// Token: 0x06017493 RID: 95379 RVA: 0x006741F7 File Offset: 0x006723F7
	public void SetWeaponChangeCallBack(Action callBack)
	{
		this.OnWeaponChangeCallBack = callBack;
	}

	// Token: 0x06017494 RID: 95380 RVA: 0x00674200 File Offset: 0x00672400
	public UniTask UpdateDataList(List<WeaponDataBase> dataList)
	{
		WeaponListComponent.<UpdateDataList>d__6 <UpdateDataList>d__;
		<UpdateDataList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateDataList>d__.<>4__this = this;
		<UpdateDataList>d__.dataList = dataList;
		<UpdateDataList>d__.<>1__state = -1;
		<UpdateDataList>d__.<>t__builder.Start<WeaponListComponent.<UpdateDataList>d__6>(ref <UpdateDataList>d__);
		return <UpdateDataList>d__.<>t__builder.Task;
	}

	// Token: 0x06017495 RID: 95381 RVA: 0x0067424C File Offset: 0x0067244C
	public void SetCurSelect(int selectedIndex)
	{
		if (this.WeaponDataList == null || selectedIndex < 0 || selectedIndex >= this.WeaponDataList.Count || selectedIndex == this.ScrollView.GetGenericLayout().GetSelectedGridIndex())
		{
			return;
		}
		WeaponItemSmallItemGrid scrollItemByIndex = this.ScrollView.GetScrollItemByIndex(selectedIndex);
		if (scrollItemByIndex != null)
		{
			if (scrollItemByIndex != null)
			{
				scrollItemByIndex.SetSelected(true, false);
			}
			this.OnItemToggleCallBack(selectedIndex);
		}
	}

	// Token: 0x06017496 RID: 95382 RVA: 0x006742A9 File Offset: 0x006724A9
	private bool CanToggleExecuteChange(object data, bool isForceSelected, EToggleState state)
	{
		return this.GetCurSelectedData() != data;
	}

	// Token: 0x06017497 RID: 95383 RVA: 0x006742B8 File Offset: 0x006724B8
	private void OnToggleClick(MediumItemGridExtendCallback callbackParameter)
	{
		if (callbackParameter.State == EToggleState.ETT_Checked)
		{
			WeaponItemSmallItemGrid weaponItemSmallItemGrid = callbackParameter.MediumItemGrid as WeaponItemSmallItemGrid;
			if (weaponItemSmallItemGrid != null)
			{
				this.OnItemToggleCallBack(weaponItemSmallItemGrid.GridIndex);
			}
		}
	}

	// Token: 0x06017498 RID: 95384 RVA: 0x006742E9 File Offset: 0x006724E9
	private void OnItemToggleCallBack(int index)
	{
		GenericLayout<WeaponItemSmallItemGrid, WeaponDataBase> genericLayout = this.ScrollView.GetGenericLayout();
		if (genericLayout != null)
		{
			genericLayout.DeselectCurrentGridProxy();
		}
		GenericLayout<WeaponItemSmallItemGrid, WeaponDataBase> genericLayout2 = this.ScrollView.GetGenericLayout();
		if (genericLayout2 != null)
		{
			genericLayout2.SelectGridProxy(index, false);
		}
		Action onWeaponChangeCallBack = this.OnWeaponChangeCallBack;
		if (onWeaponChangeCallBack == null)
		{
			return;
		}
		onWeaponChangeCallBack();
	}

	// Token: 0x06017499 RID: 95385 RVA: 0x0067432C File Offset: 0x0067252C
	[NullableContext(2)]
	public WeaponDataBase GetCurSelectedData()
	{
		int selectedGridIndex = this.ScrollView.GetGenericLayout().GetSelectedGridIndex();
		if (this.WeaponDataList == null || selectedGridIndex < 0 || selectedGridIndex >= this.WeaponDataList.Count)
		{
			return null;
		}
		return this.WeaponDataList[selectedGridIndex];
	}

	// Token: 0x0601749A RID: 95386 RVA: 0x00674372 File Offset: 0x00672572
	public void CancelSelect()
	{
		GenericLayout<WeaponItemSmallItemGrid, WeaponDataBase> genericLayout = this.ScrollView.GetGenericLayout();
		if (genericLayout == null)
		{
			return;
		}
		genericLayout.DeselectCurrentGridProxy();
	}

	// Token: 0x0400B2E5 RID: 45797
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<WeaponDataBase> WeaponDataList;

	// Token: 0x0400B2E6 RID: 45798
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<WeaponItemSmallItemGrid, WeaponDataBase> ScrollView;

	// Token: 0x0400B2E7 RID: 45799
	[Nullable(2)]
	private Action OnWeaponChangeCallBack;
}
