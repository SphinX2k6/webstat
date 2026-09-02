using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F31 RID: 7985
public class PnlTeam : UiPanelBase
{
	// Token: 0x0600EEC8 RID: 61128 RVA: 0x004143D4 File Offset: 0x004125D4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnTeamBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EEC9 RID: 61129 RVA: 0x004144FE File Offset: 0x004126FE
	protected override void OnStart()
	{
		this.InitBoxList();
		this.RefreshView();
	}

	// Token: 0x0600EECA RID: 61130 RVA: 0x0041450C File Offset: 0x0041270C
	private void InitBoxList()
	{
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		for (int i = 0; i < 3; i++)
		{
			UUIItem uuiitem;
			if (i == 0)
			{
				uuiitem = item2;
			}
			else
			{
				uuiitem = Singleton<LguiUtil>.Instance.CopyItem(item2, item);
			}
			PnlHeadBox pnlHeadBox = new PnlHeadBox();
			pnlHeadBox.CreateThenShowByActor(uuiitem.GetOwner(), null);
			this.HeadBoxItemList.Add(pnlHeadBox);
		}
	}

	// Token: 0x0600EECB RID: 61131 RVA: 0x00414570 File Offset: 0x00412770
	public void RefreshView()
	{
		int powerLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().PowerLevel;
		base.GetText(1).SetText(powerLevel.ToString(), true);
		bool uiactive = ModelBase<HonamiStoryModel>.Instance.QuickAllCheck(false);
		base.GetSprite(2).SetUIActive(uiactive);
		base.GetItem(5).SetUIActive(uiactive);
		int[] allRoleIdList = ModelBase<HonamiStoryModel>.Instance.GetAllRoleIdList();
		if (allRoleIdList == null)
		{
			return;
		}
		for (int i = 0; i < this.HeadBoxItemList.Count; i++)
		{
			if (i < allRoleIdList.Length)
			{
				this.HeadBoxItemList[i].RefreshView(allRoleIdList[i]);
			}
			else
			{
				this.HeadBoxItemList[i].RefreshView(0);
			}
		}
	}

	// Token: 0x0600EECC RID: 61132 RVA: 0x0041461A File Offset: 0x0041281A
	private void OnTeamBtnClick()
	{
		ControllerBase<HonamiStoryController>.Instance.OpenHonamiStoryBag();
	}

	// Token: 0x040072DD RID: 29405
	[Nullable(1)]
	private readonly List<PnlHeadBox> HeadBoxItemList = new List<PnlHeadBox>();
}
