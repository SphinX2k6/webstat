using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013C3 RID: 5059
[NullableContext(1)]
[Nullable(0)]
public class EditTeamModule : UiPanelBase
{
	// Token: 0x06008B9C RID: 35740 RVA: 0x0024C034 File Offset: 0x0024A234
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06008B9D RID: 35741 RVA: 0x0024C090 File Offset: 0x0024A290
	protected override UniTask OnBeforeStartAsync()
	{
		EditTeamModule.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<EditTeamModule.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008B9E RID: 35742 RVA: 0x0024C0D4 File Offset: 0x0024A2D4
	public UniTask RefreshEditTeamModule()
	{
		EditTeamModule.<RefreshEditTeamModule>d__8 <RefreshEditTeamModule>d__;
		<RefreshEditTeamModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshEditTeamModule>d__.<>4__this = this;
		<RefreshEditTeamModule>d__.<>1__state = -1;
		<RefreshEditTeamModule>d__.<>t__builder.Start<EditTeamModule.<RefreshEditTeamModule>d__8>(ref <RefreshEditTeamModule>d__);
		return <RefreshEditTeamModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008B9F RID: 35743 RVA: 0x0024C117 File Offset: 0x0024A317
	private EditTeamItem InitScrollItem()
	{
		EditTeamItem editTeamItem = new EditTeamItem();
		editTeamItem.SetClickEvent(this.OnClickEvent);
		editTeamItem.SetCanExecuteChange(this.CanExecuteChange);
		editTeamItem.SetIsItemSelected(this.IsItemSelected);
		return editTeamItem;
	}

	// Token: 0x06008BA0 RID: 35744 RVA: 0x0024C142 File Offset: 0x0024A342
	public void SetClickEvent(TEditTeamClick onClickEvent)
	{
		this.OnClickEvent = onClickEvent;
	}

	// Token: 0x06008BA1 RID: 35745 RVA: 0x0024C14B File Offset: 0x0024A34B
	[NullableContext(2)]
	public void SetCanExecuteChange(TEditTeamCanExecuteChange canExecuteChange)
	{
		this.CanExecuteChange = canExecuteChange;
	}

	// Token: 0x06008BA2 RID: 35746 RVA: 0x0024C154 File Offset: 0x0024A354
	[NullableContext(2)]
	public void SetIsItemSelected(TEditTeamItemSelected isItemSelected)
	{
		this.IsItemSelected = isItemSelected;
	}

	// Token: 0x06008BA3 RID: 35747 RVA: 0x0024C15D File Offset: 0x0024A35D
	public void SelectEditTeamItem(int index, bool fireEvent = false)
	{
		LoopScrollView<EditTeamItem, EditTeamData> loopScroll = this.LoopScroll;
		if (loopScroll == null)
		{
			return;
		}
		loopScroll.SelectGridProxy(index, fireEvent);
	}

	// Token: 0x06008BA4 RID: 35748 RVA: 0x0024C171 File Offset: 0x0024A371
	public void SetEditTeamDataList(List<EditTeamData> dataList)
	{
		this.DataList = dataList;
	}

	// Token: 0x06008BA5 RID: 35749 RVA: 0x0024C17A File Offset: 0x0024A37A
	public int GetDataLength()
	{
		return this.DataList.Count;
	}

	// Token: 0x06008BA6 RID: 35750 RVA: 0x0024C188 File Offset: 0x0024A388
	public int GetSelectGridIndex()
	{
		int selectedGridIndex = this.LoopScroll.GetSelectedGridIndex();
		if (selectedGridIndex != -1)
		{
			return selectedGridIndex;
		}
		return 0;
	}

	// Token: 0x06008BA7 RID: 35751 RVA: 0x0024C1A8 File Offset: 0x0024A3A8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 1)
		{
			return null;
		}
		string a = configParams[0];
		if (a == "Helper".ToString())
		{
			int num = -1;
			for (int i = 0; i < this.DataList.Count; i++)
			{
				if (this.DataList[i].GetTeamDataUnLockState() == EEditTeamDataUnLockState.TaskUnFinish)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				return null;
			}
			LoopScrollView<EditTeamItem, EditTeamData> loopScroll = this.LoopScroll;
			UUIItem uuiitem = (loopScroll != null) ? loopScroll.GetGrid(num) : null;
			if (uuiitem == null)
			{
				return null;
			}
			LoopScrollView<EditTeamItem, EditTeamData> loopScroll2 = this.LoopScroll;
			if (loopScroll2 != null)
			{
				loopScroll2.ScrollToGridIndex(num, true);
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}
		else
		{
			if (!(a == "Delegation".ToString()) && !(a == "HelperFirst".ToString()))
			{
				return null;
			}
			LoopScrollView<EditTeamItem, EditTeamData> loopScroll3 = this.LoopScroll;
			UUIItem uuiitem2 = (loopScroll3 != null) ? loopScroll3.GetGrid(0) : null;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}
	}

	// Token: 0x06008BA8 RID: 35752 RVA: 0x0024C295 File Offset: 0x0024A495
	public void SetTitleItemActive(bool value)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(value);
	}

	// Token: 0x04004123 RID: 16675
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<EditTeamItem, EditTeamData> LoopScroll;

	// Token: 0x04004124 RID: 16676
	protected TEditTeamClick OnClickEvent;

	// Token: 0x04004125 RID: 16677
	[Nullable(2)]
	protected TEditTeamCanExecuteChange CanExecuteChange;

	// Token: 0x04004126 RID: 16678
	[Nullable(2)]
	protected TEditTeamItemSelected IsItemSelected;

	// Token: 0x04004127 RID: 16679
	protected List<EditTeamData> DataList = new List<EditTeamData>();

	// Token: 0x0200778D RID: 30605
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x04029276 RID: 168566
		public const int Scroll = 0;

		// Token: 0x04029277 RID: 168567
		public const int ScrollItem = 1;

		// Token: 0x04029278 RID: 168568
		public const int TitleItem = 2;
	}
}
