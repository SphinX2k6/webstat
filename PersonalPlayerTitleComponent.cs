using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002431 RID: 9265
[NullableContext(1)]
[Nullable(0)]
public class PersonalPlayerTitleComponent : UiPanelBase
{
	// Token: 0x06011EB5 RID: 73397 RVA: 0x004EDF80 File Offset: 0x004EC180
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(10, new Action(this.OnClickTitlePreviewBtn))
		};
	}

	// Token: 0x06011EB6 RID: 73398 RVA: 0x004EE0C8 File Offset: 0x004EC2C8
	protected override UniTask OnBeforeStartAsync()
	{
		PersonalPlayerTitleComponent.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PersonalPlayerTitleComponent.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011EB7 RID: 73399 RVA: 0x004EE10C File Offset: 0x004EC30C
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		PersonalPlayerTitleComponent.<OnBeforeShowAsyncImplement>d__9 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<PersonalPlayerTitleComponent.<OnBeforeShowAsyncImplement>d__9>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06011EB8 RID: 73400 RVA: 0x004EE14F File Offset: 0x004EC34F
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
	}

	// Token: 0x06011EB9 RID: 73401 RVA: 0x004EE157 File Offset: 0x004EC357
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPlayerTitleChange, new Action(this.OnPlayerTitleChange));
	}

	// Token: 0x06011EBA RID: 73402 RVA: 0x004EE175 File Offset: 0x004EC375
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerTitleChange, new Action(this.OnPlayerTitleChange));
	}

	// Token: 0x06011EBB RID: 73403 RVA: 0x004EE193 File Offset: 0x004EC393
	public void SetPersonalInfoData(PersonalInfoData personalInfoData)
	{
		this.PersonalInfoData = personalInfoData;
	}

	// Token: 0x06011EBC RID: 73404 RVA: 0x004EE19C File Offset: 0x004EC39C
	public void SetRefreshConfirmBtn(Action<bool, bool> refreshConfirmBtn)
	{
		this.RefreshConfirmBtn = refreshConfirmBtn;
	}

	// Token: 0x06011EBD RID: 73405 RVA: 0x004EE1A5 File Offset: 0x004EC3A5
	private void OnPlayerTitleChange()
	{
		this.RefreshScrollView();
		this.RefreshConfirmBtnState();
	}

	// Token: 0x06011EBE RID: 73406 RVA: 0x004EE1B3 File Offset: 0x004EC3B3
	private PersonalPlayerTitleItem CreatePlayerTitleItem()
	{
		PersonalPlayerTitleItem personalPlayerTitleItem = new PersonalPlayerTitleItem();
		personalPlayerTitleItem.SetToggleCallBack(new Action<int, PersonalPlayerTitleData>(this.PlayerTitleItemToggleClick));
		return personalPlayerTitleItem;
	}

	// Token: 0x06011EBF RID: 73407 RVA: 0x004EE1CC File Offset: 0x004EC3CC
	private void PlayerTitleItemToggleClick(int gridIndex, PersonalPlayerTitleData playerTitleData)
	{
		this.CurPersonalPlayerTitleData = playerTitleData;
		this.RefreshPlayerTitleInfo();
		this.ScrollView.SelectGridProxy(gridIndex, false);
	}

	// Token: 0x06011EC0 RID: 73408 RVA: 0x004EE1E8 File Offset: 0x004EC3E8
	protected void RefreshPlayerTitleInfo()
	{
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetActive(this.CurPersonalPlayerTitleData != null, false);
		}
		if (this.CurPersonalPlayerTitleData != null)
		{
			PlayerTitle? config = ConfigPlayerTitleById.GetConfig(this.CurPersonalPlayerTitleData.PlayerTitleId, true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), config.Value.TitleName, Array.Empty<object>());
			UUIText text = base.GetText(3);
			if (this.CurPersonalPlayerTitleData.IsEffective())
			{
				text.SetUIActive(true);
				int id = config.Value.Id;
				int playerTitleStarLevel = ModelBase<PersonalModel>.Instance.GetPlayerTitleStarLevel(id);
				string playerTitleInfoString = ModelBase<PersonalModel>.Instance.GetPlayerTitleInfoString(id, playerTitleStarLevel, true);
				text.SetText(playerTitleInfoString, true);
			}
			else
			{
				text.SetUIActive(false);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), config.Value.Description, Array.Empty<object>());
			if (config.Value.IsShowProgress)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), config.Value.ItemAccess, new <>z__ReadOnlyArray<object>(new object[]
				{
					this.CurPersonalPlayerTitleData.CurProgress,
					this.CurPersonalPlayerTitleData.TargetProgress
				}));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), config.Value.ItemAccess, Array.Empty<object>());
			}
			double? unlockTime = this.CurPersonalPlayerTitleData.UnlockTime;
			UUIItem item2 = base.GetItem(8);
			if (unlockTime != null && this.CurPersonalPlayerTitleData != null && !this.CurPersonalPlayerTitleData.IsExpired())
			{
				item2.SetUIActive(true);
				base.GetText(6).SetText(Singleton<TimeUtil>.Instance.DateFormat4String(unlockTime.Value / 1000.0), true);
			}
			else
			{
				item2.SetUIActive(false);
			}
			bool flag = this.CurPersonalPlayerTitleData.IsTimeLimitTitle();
			UUIText text2 = base.GetText(11);
			if (text2 != null)
			{
				bool flag2 = flag && !this.CurPersonalPlayerTitleData.IsExpired();
				text2.SetUIActive(flag2);
				if (flag2)
				{
					double remainTime = this.CurPersonalPlayerTitleData.EndTime.Value - Singleton<TimeUtil>.Instance.GetServerTime();
					string item3 = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(remainTime).CountDownText ?? "";
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "LimitTimeTitle", new <>z__ReadOnlySingleElementList<object>(item3));
				}
			}
			this.RefreshConfirmBtnState();
			this.MiniTitlePreView.RefreshView(this.CurPersonalPlayerTitleData);
		}
	}

	// Token: 0x06011EC1 RID: 73409 RVA: 0x004EE478 File Offset: 0x004EC678
	public void RefreshScrollView()
	{
		List<PersonalPlayerTitleData> sortedList = this.GetSortedList();
		this.ScrollView.RefreshByData(sortedList, false, null, false);
		int num = 0;
		if (this.LastLogTitleId.GetValueOrDefault() != -1 && this.PersonalInfoData.CurPlayerTitleId != null && this.PersonalInfoData.CurPlayerTitleId.Value <= 0)
		{
			num = sortedList.FindIndex(delegate(PersonalPlayerTitleData data)
			{
				int playerTitleId = data.PlayerTitleId;
				int? lastLogTitleId = this.LastLogTitleId;
				return playerTitleId == lastLogTitleId.GetValueOrDefault() & lastLogTitleId != null;
			});
		}
		num = ((num < 0) ? 0 : num);
		this.ScrollView.SelectGridProxy(num, false);
		this.ScrollView.ScrollToGridIndex(num, true);
		this.LastLogTitleId = this.PersonalInfoData.CurPlayerTitleId;
		ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.ScrollView.GetGrid(num), true, false, false);
	}

	// Token: 0x06011EC2 RID: 73410 RVA: 0x004EE534 File Offset: 0x004EC734
	public void RefreshConfirmBtnState()
	{
		int? curPlayerTitleId = this.PersonalInfoData.CurPlayerTitleId;
		bool flag = this.CurPersonalPlayerTitleData.IsEffective();
		if (this.RefreshConfirmBtn != null)
		{
			Action<bool, bool> refreshConfirmBtn = this.RefreshConfirmBtn;
			bool arg = flag;
			int? num = curPlayerTitleId;
			int playerTitleId = this.CurPersonalPlayerTitleData.PlayerTitleId;
			refreshConfirmBtn(arg, num.GetValueOrDefault() == playerTitleId & num != null);
		}
	}

	// Token: 0x06011EC3 RID: 73411 RVA: 0x004EE590 File Offset: 0x004EC790
	private List<PersonalPlayerTitleData> GetSortedList()
	{
		List<PersonalPlayerTitleData> list = new List<PersonalPlayerTitleData>(ModelBase<PersonalModel>.Instance.GetPlayerTitleList());
		int num = list.FindIndex(delegate(PersonalPlayerTitleData data)
		{
			int playerTitleId = data.PlayerTitleId;
			int? curPlayerTitleId = this.PersonalInfoData.CurPlayerTitleId;
			return playerTitleId == curPlayerTitleId.GetValueOrDefault() & curPlayerTitleId != null;
		});
		if (num <= 0 || num >= list.Count)
		{
			return list;
		}
		if (list[num].IsExpired())
		{
			return list;
		}
		PersonalPlayerTitleData value = list[num];
		for (int i = num; i > 0; i--)
		{
			list[i] = list[i - 1];
		}
		list[0] = value;
		return list;
	}

	// Token: 0x06011EC4 RID: 73412 RVA: 0x004EE60C File Offset: 0x004EC80C
	public void OnClickConfirm(int _)
	{
		if (this.CurPersonalPlayerTitleData.IsExpired())
		{
			return;
		}
		int num = this.CurPersonalPlayerTitleData.PlayerTitleId;
		int? curPlayerTitleId = this.PersonalInfoData.CurPlayerTitleId;
		int num2 = num;
		if (curPlayerTitleId.GetValueOrDefault() == num2 & curPlayerTitleId != null)
		{
			num = 0;
		}
		ControllerBase<PersonalController>.Instance.SendChangePlayerTitleRequest(num);
	}

	// Token: 0x06011EC5 RID: 73413 RVA: 0x004EE662 File Offset: 0x004EC862
	private void OnClickTitlePreviewBtn()
	{
		ControllerBase<ItemController>.Instance.OpenTitleTipsByItemId(this.CurPersonalPlayerTitleData.PlayerTitleId);
	}

	// Token: 0x04008C63 RID: 35939
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<PersonalPlayerTitleItem, PersonalPlayerTitleData> ScrollView;

	// Token: 0x04008C64 RID: 35940
	[Nullable(2)]
	private PersonalPlayerTitleData CurPersonalPlayerTitleData;

	// Token: 0x04008C65 RID: 35941
	[Nullable(2)]
	private PersonalInfoData PersonalInfoData;

	// Token: 0x04008C66 RID: 35942
	[Nullable(2)]
	private PersonalPlayerTitleMiniPreView MiniTitlePreView;

	// Token: 0x04008C67 RID: 35943
	[Nullable(2)]
	private Action<bool, bool> RefreshConfirmBtn;

	// Token: 0x04008C68 RID: 35944
	private int? LastLogTitleId = new int?(-1);

	// Token: 0x0200876A RID: 34666
	[NullableContext(0)]
	private enum EPersonalTitleComponentDefine
	{
		// Token: 0x0402DC86 RID: 187526
		ScrollView,
		// Token: 0x0402DC87 RID: 187527
		PersonalTitleItem,
		// Token: 0x0402DC88 RID: 187528
		TxtName,
		// Token: 0x0402DC89 RID: 187529
		TxtDetail,
		// Token: 0x0402DC8A RID: 187530
		TxtDescription,
		// Token: 0x0402DC8B RID: 187531
		TxtAccess,
		// Token: 0x0402DC8C RID: 187532
		TxtAccessTime,
		// Token: 0x0402DC8D RID: 187533
		PanelRight,
		// Token: 0x0402DC8E RID: 187534
		PanelAccess,
		// Token: 0x0402DC8F RID: 187535
		PanelCard,
		// Token: 0x0402DC90 RID: 187536
		TitlePreviewBtn,
		// Token: 0x0402DC91 RID: 187537
		TxtTimeLimit
	}
}
