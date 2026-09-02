using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002AAF RID: 10927
[NullableContext(2)]
[Nullable(0)]
internal class SubPackageDownLoadVersionItem : UiPanelBase
{
	// Token: 0x06015DC6 RID: 89542 RVA: 0x00610EFC File Offset: 0x0060F0FC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(18, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickHelpBtn)),
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickStartBtn)),
			new ValueTuple<int, Delegate>(10, new Action(this.OnClickAllDownLoadBtn)),
			new ValueTuple<int, Delegate>(11, new Action(this.OnClickStopBtn)),
			new ValueTuple<int, Delegate>(17, new Action<EToggleState>(this.OnClickToggle)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnClickCancelBtn)),
			new ValueTuple<int, Delegate>(13, new Action(this.OnClickPriorityBtn))
		};
	}

	// Token: 0x06015DC7 RID: 89543 RVA: 0x00611179 File Offset: 0x0060F379
	protected override void OnStart()
	{
		base.GetText(4).SetUIActive(false);
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackDownLoadState, new Action(this.OnRefreshSubPackDownLoadVersionState));
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06015DC8 RID: 89544 RVA: 0x006111B5 File Offset: 0x0060F3B5
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackDownLoadState, new Action(this.OnRefreshSubPackDownLoadVersionState));
		if (this.LevelSequencePlayer != null)
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
		}
	}

	// Token: 0x06015DC9 RID: 89545 RVA: 0x006111F0 File Offset: 0x0060F3F0
	public void RefreshItem(int versionId, bool isShowSubItem)
	{
		this.VersionId = versionId;
		this.SubPackageList.Clear();
		DownLoadVersion? downLoadVersionByVersion = ConfigBase<SubPackageConfig>.Instance.GetDownLoadVersionByVersion(this.VersionId);
		if (downLoadVersionByVersion == null)
		{
			return;
		}
		foreach (DownLoadSubPackage downLoadSubPackage in (ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageListByVersion(this.VersionId) ?? new List<DownLoadSubPackage>()))
		{
			this.SubPackageList.Add(downLoadSubPackage.Id);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), downLoadVersionByVersion.Value.Title, Array.Empty<object>());
		base.SetTextureByPath(downLoadVersionByVersion.Value.Pic, base.GetTexture(0), null, null);
		base.GetItem(7).SetUIActive(downLoadVersionByVersion.Value.IsRecommend);
		this.Type = (ESubPackageDownLoadVersionType)downLoadVersionByVersion.Value.Type;
		this.IsSingleVersion = !ModelBase<SubPackageDownLoadModel>.Instance.GetVersionShowArrowByType(downLoadVersionByVersion.Value.Type);
		base.GetItem(6).SetUIActive(!this.IsSingleVersion);
		base.GetExtendToggle(17).SetToggleState(isShowSubItem ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		this.RefreshState();
		this.RefreshTipsText();
	}

	// Token: 0x06015DCA RID: 89546 RVA: 0x00611360 File Offset: 0x0060F560
	public void RefreshState()
	{
		this.State = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadVersionStateById(this.VersionId);
		base.GetButton(9).RootUIComp.Get().SetUIActive(this.State == ESubPackageDownLoadState.Pause);
		base.GetButton(10).RootUIComp.Get().SetUIActive(this.State == ESubPackageDownLoadState.None);
		base.GetButton(11).RootUIComp.Get().SetUIActive(this.State == ESubPackageDownLoadState.DownLoading);
		base.GetItem(14).SetUIActive(this.State == ESubPackageDownLoadState.Waiting && !ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingFinish());
		base.GetItem(15).SetUIActive(this.State == ESubPackageDownLoadState.Finish);
		base.GetButton(12).RootUIComp.Get().SetUIActive((this.State == ESubPackageDownLoadState.DownLoading || this.State == ESubPackageDownLoadState.Waiting || this.State == ESubPackageDownLoadState.Pause) && this.Type != ESubPackageDownLoadVersionType.Key);
		base.GetButton(13).RootUIComp.Get().SetUIActive(this.State == ESubPackageDownLoadState.Waiting && ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingFinish() && this.Type != ESubPackageDownLoadVersionType.Key);
	}

	// Token: 0x06015DCB RID: 89547 RVA: 0x006114AC File Offset: 0x0060F6AC
	public void RefreshTipsText()
	{
		UUIText text = base.GetText(8);
		if (this.State == ESubPackageDownLoadState.DownLoading)
		{
			text.SetUIActive(true);
			text.SetText(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadSpeed()) + "/s", true);
		}
		else if (this.State == ESubPackageDownLoadState.Pause)
		{
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_Pausing_Text", Array.Empty<object>());
		}
		else
		{
			text.SetUIActive(false);
		}
		long num = 0L;
		long num2 = 0L;
		foreach (int id in this.SubPackageList)
		{
			long subPackageSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageSpace(id);
			if (subPackageSpace > 0L)
			{
				if (ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(id) != ESubPackageDownLoadState.Finish)
				{
					num += ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageHaveDownLoadSpace(id);
				}
				else
				{
					num += subPackageSpace;
				}
				num2 += subPackageSpace;
			}
		}
		base.GetText(3).SetUIActive(num2 > 0L);
		if (num <= 0L)
		{
			base.GetText(3).SetText(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(num) + "/" + ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(num2), true);
		}
		else if (this.State == ESubPackageDownLoadState.Finish || this.State == ESubPackageDownLoadState.None)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "ResDownLoadVersion_FinishTips", new <>z__ReadOnlySingleElementList<object>(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(num) + "/" + ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(num2)));
		}
		else
		{
			long num3 = 0L;
			long num4 = 0L;
			foreach (int id2 in this.SubPackageList)
			{
				long subPackageSpace2 = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageSpace(id2);
				if (subPackageSpace2 > 0L)
				{
					ESubPackageDownLoadState subPackageDownLoadItemStateById = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(id2);
					if (subPackageDownLoadItemStateById != ESubPackageDownLoadState.Finish && subPackageDownLoadItemStateById != ESubPackageDownLoadState.None)
					{
						num3 += ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageHaveDownLoadSpace(id2);
						num4 += subPackageSpace2;
					}
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "ResDownLoadVersion_DownLoadingTips", new <>z__ReadOnlyArray<object>(new object[]
			{
				ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(num3) + "/" + ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(num4),
				ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(num2)
			}));
		}
		bool flag = base.GetItem(18).IsUIActiveSelf();
		if (this.State == ESubPackageDownLoadState.Finish || this.State == ESubPackageDownLoadState.None || num2 == 0L)
		{
			base.GetItem(18).SetUIActive(false);
			base.GetSprite(5).SetFillAmount(0f);
			return;
		}
		base.GetItem(18).SetUIActive(num > 0L);
		float fillAmount = (float)num / (float)num2;
		base.GetSprite(5).SetFillAmount(fillAmount);
		if (!flag && num > 0L)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Load", false, null, false);
		}
	}

	// Token: 0x06015DCC RID: 89548 RVA: 0x006117B8 File Offset: 0x0060F9B8
	public void RefreshDownLoadStateByTime()
	{
		if (this.State == ESubPackageDownLoadState.DownLoading)
		{
			this.RefreshTipsText();
		}
	}

	// Token: 0x06015DCD RID: 89549 RVA: 0x006117C9 File Offset: 0x0060F9C9
	[NullableContext(1)]
	public UUIItem GetToggleItem()
	{
		return base.GetExtendToggle(17).RootUIComp;
	}

	// Token: 0x06015DCE RID: 89550 RVA: 0x006117DD File Offset: 0x0060F9DD
	private void OnClickHelpBtn()
	{
		Action<int, UUIItem> onClickHelpBtnCallBack = this.OnClickHelpBtnCallBack;
		if (onClickHelpBtnCallBack == null)
		{
			return;
		}
		onClickHelpBtnCallBack(this.VersionId, base.GetButton(2).RootUIComp);
	}

	// Token: 0x06015DCF RID: 89551 RVA: 0x00611808 File Offset: 0x0060FA08
	private void OnClickStartBtn()
	{
		Action onClickBtn = this.OnClickBtn;
		if (onClickBtn != null)
		{
			onClickBtn();
		}
		foreach (int id in this.SubPackageList)
		{
			if (ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(id) == ESubPackageDownLoadState.Pause)
			{
				ControllerBase<SubPackageController>.Instance.RestartSubPackageDownLoading(id, new Action(this.RefreshDownLoadState));
				break;
			}
		}
	}

	// Token: 0x06015DD0 RID: 89552 RVA: 0x00611890 File Offset: 0x0060FA90
	private void OnClickAllDownLoadBtn()
	{
		Action onClickBtn = this.OnClickBtn;
		if (onClickBtn != null)
		{
			onClickBtn();
		}
		if (ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoading() && this.Type != ESubPackageDownLoadVersionType.Key)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SubPackageDownLoad_Des_WaitKeyItemDownLoad", Array.Empty<object>());
		}
		ControllerBase<SubPackageController>.Instance.PushSubPackageDownLoading(this.SubPackageList, delegate
		{
			if (base.GetExtendToggle(17).ToggleState == EToggleState.ETT_Checked || this.IsSingleVersion)
			{
				this.RefreshDownLoadState();
				return;
			}
			Action<int, bool> onClickCallBack = this.OnClickCallBack;
			if (onClickCallBack == null)
			{
				return;
			}
			onClickCallBack(this.VersionId, true);
		});
	}

	// Token: 0x06015DD1 RID: 89553 RVA: 0x006118F4 File Offset: 0x0060FAF4
	private void OnClickStopBtn()
	{
		Action onClickBtn = this.OnClickBtn;
		if (onClickBtn != null)
		{
			onClickBtn();
		}
		foreach (int id in this.SubPackageList)
		{
			if (ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(id) == ESubPackageDownLoadState.DownLoading)
			{
				ControllerBase<SubPackageController>.Instance.StopSubPackageDownLoading(id, new Action(this.RefreshDownLoadState));
			}
		}
	}

	// Token: 0x06015DD2 RID: 89554 RVA: 0x00611978 File Offset: 0x0060FB78
	private void OnClickCancelBtn()
	{
		Action onClickBtn = this.OnClickBtn;
		if (onClickBtn != null)
		{
			onClickBtn();
		}
		ControllerBase<SubPackageController>.Instance.CancelSubPackageDownLoadingList(this.SubPackageList);
		this.RefreshDownLoadState();
	}

	// Token: 0x06015DD3 RID: 89555 RVA: 0x006119A1 File Offset: 0x0060FBA1
	private void OnClickPriorityBtn()
	{
		Action onClickBtn = this.OnClickBtn;
		if (onClickBtn != null)
		{
			onClickBtn();
		}
		ControllerBase<SubPackageController>.Instance.PrioritySubPackageDownLoading(this.SubPackageList, new Action(this.RefreshDownLoadState));
	}

	// Token: 0x06015DD4 RID: 89556 RVA: 0x006119D1 File Offset: 0x0060FBD1
	private void OnClickToggle(EToggleState state)
	{
		if (this.IsSingleVersion)
		{
			return;
		}
		Action<int, bool> onClickCallBack = this.OnClickCallBack;
		if (onClickCallBack == null)
		{
			return;
		}
		onClickCallBack(this.VersionId, state == EToggleState.ETT_Checked);
	}

	// Token: 0x06015DD5 RID: 89557 RVA: 0x006119F6 File Offset: 0x0060FBF6
	private void RefreshDownLoadState()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshSubPackDownLoadState);
	}

	// Token: 0x06015DD6 RID: 89558 RVA: 0x00611A08 File Offset: 0x0060FC08
	private void OnRefreshSubPackDownLoadVersionState()
	{
		this.RefreshState();
		this.RefreshTipsText();
	}

	// Token: 0x0400A7CC RID: 42956
	public Action OnClickBtn;

	// Token: 0x0400A7CD RID: 42957
	public Action<int, bool> OnClickCallBack;

	// Token: 0x0400A7CE RID: 42958
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, UUIItem> OnClickHelpBtnCallBack;

	// Token: 0x0400A7CF RID: 42959
	public ESubPackageDownLoadVersionType Type = ESubPackageDownLoadVersionType.Key;

	// Token: 0x0400A7D0 RID: 42960
	private int VersionId;

	// Token: 0x0400A7D1 RID: 42961
	private bool IsSingleVersion;

	// Token: 0x0400A7D2 RID: 42962
	[Nullable(1)]
	private List<int> SubPackageList = new List<int>();

	// Token: 0x0400A7D3 RID: 42963
	private ESubPackageDownLoadState State = ESubPackageDownLoadState.None;

	// Token: 0x0400A7D4 RID: 42964
	private LevelSequencePlayer LevelSequencePlayer;
}
