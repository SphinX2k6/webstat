using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x0200276B RID: 10091
[NullableContext(1)]
[Nullable(0)]
public class ResDownLoadView : UiViewBase
{
	// Token: 0x06013E9B RID: 81563 RVA: 0x0058C5C5 File Offset: 0x0058A7C5
	public ResDownLoadView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013E9C RID: 81564 RVA: 0x0058C5D8 File Offset: 0x0058A7D8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickLeftBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickRightBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013E9D RID: 81565 RVA: 0x0058C834 File Offset: 0x0058AA34
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EVideoDownloadStatus>(EEventName.ResDownLoadStateRefresh, new Action<EVideoDownloadStatus>(this.ResDownLoadStateRefresh));
	}

	// Token: 0x06013E9E RID: 81566 RVA: 0x0058C852 File Offset: 0x0058AA52
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ResDownLoadStateRefresh, new Action<EVideoDownloadStatus>(this.ResDownLoadStateRefresh));
	}

	// Token: 0x06013E9F RID: 81567 RVA: 0x0058C870 File Offset: 0x0058AA70
	protected override void OnStart()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView != null)
		{
			CommonPopViewBase popItem = childPopView.PopItem;
			if (popItem != null)
			{
				popItem.SetMaskResponsibleState(false);
			}
		}
		this.DownLoadTabLayout = new GenericLayout<ResDownLoadViewTabItem, int>(base.GetVerticalLayout(1), () => new ResDownLoadViewTabItem
		{
			OnClickExtendToggleCallBack = new Action<int, int, UUIExtendToggle>(this.OnClickToggle)
		}, null, false, true);
		this.DownloadState = Singleton<VideoUpdateManager>.Instance.GetVideoUpdater((EVideoResSizeType)this.SelectResType).GetDownLoadState();
		if (this.UpdateProxy == null)
		{
			this.UpdateProxy = new VideoResourceUpdateProxy();
		}
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.RefreshDownLoadState();
		}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		base.GetButton(8).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x06013EA0 RID: 81568 RVA: 0x0058C932 File Offset: 0x0058AB32
	protected override void OnBeforeDestroy()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		if (this.UpdateProxy != null)
		{
			this.UpdateProxy = null;
		}
	}

	// Token: 0x06013EA1 RID: 81569 RVA: 0x0058C964 File Offset: 0x0058AB64
	protected override void OnBeforeShow()
	{
		QuestResourceModel instance = ModelBase<QuestResourceModel>.Instance;
		if (instance != null)
		{
			instance.CalcPrepareResource();
		}
		List<int> list = new List<int>();
		list.Add(3);
		list.Add(4);
		this.DownLoadTabLayout.RefreshByData(list, delegate
		{
			if (ModelBase<ResDownLoadModel>.Instance.CurrentDownLoadVideo <= 0)
			{
				this.DownLoadTabLayout.GetLayoutItemByIndex(0).SelectToggle();
				return;
			}
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			if ((playerGender == EPlayerGender.Male && ModelBase<ResDownLoadModel>.Instance.CurrentDownLoadVideo == 3) || (playerGender == EPlayerGender.Female && ModelBase<ResDownLoadModel>.Instance.CurrentDownLoadVideo == 4))
			{
				this.DownLoadTabLayout.GetLayoutItemByIndex(1).SelectToggle();
				return;
			}
			this.DownLoadTabLayout.GetLayoutItemByIndex(0).SelectToggle();
		}, false);
		this.RefreshDownLoadState();
	}

	// Token: 0x06013EA2 RID: 81570 RVA: 0x0058C9B4 File Offset: 0x0058ABB4
	private void ResDownLoadStateRefresh(EVideoDownloadStatus state)
	{
		this.DownloadState = Singleton<VideoUpdateManager>.Instance.GetVideoUpdater((EVideoResSizeType)this.SelectResType).GetDownLoadState();
		this.RefreshDownLoadState();
	}

	// Token: 0x06013EA3 RID: 81571 RVA: 0x0058C9D7 File Offset: 0x0058ABD7
	private void OnClickLeftBtn()
	{
		if (this.DownloadState != EVideoDownloadStatus.Pause)
		{
			return;
		}
		ModelBase<ResDownLoadModel>.Instance.CurrentDownLoadVideo = -1;
		Singleton<VideoUpdateManager>.Instance.GetVideoUpdater((EVideoResSizeType)this.SelectResType).CancelDownload();
	}

	// Token: 0x06013EA4 RID: 81572 RVA: 0x0058CA04 File Offset: 0x0058AC04
	private void OnClickRightBtn()
	{
		if (ModelBase<ResDownLoadModel>.Instance.CurrentDownLoadVideo > 0 && this.SelectResType != ModelBase<ResDownLoadModel>.Instance.CurrentDownLoadVideo)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DownLoadTips_WaitOtherDown", Array.Empty<object>());
			return;
		}
		if (this.DownloadState == EVideoDownloadStatus.None)
		{
			long freeSpace = Singleton<VideoResUpdate>.Instance.GetFreeSpace();
			if (Singleton<VideoResUpdate>.Instance.GetVideoResSize((EVideoResSizeType)this.SelectResType) <= 0L)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HaveDownLoadResTips", Array.Empty<object>());
				return;
			}
			if (freeSpace < Singleton<VideoResUpdate>.Instance.GetVideoResSize((EVideoResSizeType)this.SelectResType))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DownLoadTips_NotEnough", Array.Empty<object>());
				return;
			}
			ControllerBase<QuestNewController>.Instance.SetIsReportDownloadNotEnoughSpace(false);
			Singleton<VideoUpdateManager>.Instance.GetVideoUpdater((EVideoResSizeType)this.SelectResType).Update((EVideoResSizeType)this.SelectResType, this.UpdateProxy).Forget<bool>();
			ModelBase<ResDownLoadModel>.Instance.CurrentDownLoadVideo = this.SelectResType;
			return;
		}
		else
		{
			if (this.DownloadState == EVideoDownloadStatus.Downloading)
			{
				Singleton<VideoUpdateManager>.Instance.GetVideoUpdater((EVideoResSizeType)this.SelectResType).Pause();
				ModelBase<QuestResourceModel>.Instance.CalcPrepareResource();
				ModelBase<ResDownLoadModel>.Instance.CurrentDownLoadVideo = -1;
				return;
			}
			if (this.DownloadState == EVideoDownloadStatus.Pause)
			{
				ControllerBase<QuestNewController>.Instance.SetIsReportDownloadNotEnoughSpace(false);
				Singleton<VideoUpdateManager>.Instance.GetVideoUpdater((EVideoResSizeType)this.SelectResType).Update((EVideoResSizeType)this.SelectResType, this.UpdateProxy).Forget<bool>();
				ModelBase<ResDownLoadModel>.Instance.CurrentDownLoadVideo = this.SelectResType;
			}
			return;
		}
	}

	// Token: 0x06013EA5 RID: 81573 RVA: 0x0058CB6C File Offset: 0x0058AD6C
	private void RefreshDownLoadState()
	{
		switch (this.DownloadState)
		{
		case EVideoDownloadStatus.None:
			this.ShowNoneState();
			return;
		case EVideoDownloadStatus.Downloading:
		{
			ValueTuple<long, long, long, long> downLoadProgress = Singleton<VideoUpdateManager>.Instance.GetVideoUpdater((EVideoResSizeType)this.SelectResType).GetDownLoadProgress();
			if (downLoadProgress.Item3 == 0L)
			{
				base.GetTexture(6).SetFillAmount(0f);
				return;
			}
			base.GetText(7).SetUIActive(true);
			base.GetText(4).SetUIActive(false);
			base.GetItem(5).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "DownLoadText_Downing", Array.Empty<object>());
			float num = (float)downLoadProgress.Item2 / (float)downLoadProgress.Item3;
			string str = HotFixManager.ByteConverter(downLoadProgress.Item4) + "/s ";
			string str2 = string.Concat(new string[]
			{
				"(",
				HotFixManager.ByteConverter(downLoadProgress.Item2),
				"/",
				HotFixManager.ByteConverter(downLoadProgress.Item3),
				") "
			});
			base.GetTexture(6).SetFillAmount(num);
			string str3 = (num * 100f).ToString("F2").TrimEnd('0').TrimEnd('.') + "%";
			base.GetText(7).SetText(str + str2 + str3, true);
			base.GetButton(10).RootUIComp.Get().SetUIActive(true);
			base.GetItem(13).SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "DownLoadButton_Pause", Array.Empty<object>());
			return;
		}
		case EVideoDownloadStatus.Pause:
		{
			base.GetText(4).SetUIActive(false);
			base.GetItem(5).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "DownLoadText_Pause", Array.Empty<object>());
			base.GetButton(10).RootUIComp.Get().SetUIActive(true);
			base.GetItem(13).SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "DownLoadButton_Cancel", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "DownLoadButton_Continue", Array.Empty<object>());
			ValueTuple<long, long, long, long> downLoadProgress2 = Singleton<VideoUpdateManager>.Instance.GetVideoUpdater((EVideoResSizeType)this.SelectResType).GetDownLoadProgress();
			if (downLoadProgress2.Item3 != 0L)
			{
				float num2 = (float)downLoadProgress2.Item2 / (float)downLoadProgress2.Item3;
				string str4 = string.Concat(new string[]
				{
					"(",
					HotFixManager.ByteConverter(downLoadProgress2.Item2),
					"/",
					HotFixManager.ByteConverter(downLoadProgress2.Item3),
					") "
				});
				base.GetTexture(6).SetFillAmount(num2);
				string str5 = (num2 * 100f).ToString("F2").TrimEnd('0').TrimEnd('.') + "%";
				base.GetText(7).SetUIActive(true);
				base.GetText(7).SetText(str4 + str5, true);
				return;
			}
			base.GetText(7).SetUIActive(false);
			return;
		}
		case EVideoDownloadStatus.Done:
			base.GetItem(13).SetUIActive(true);
			base.GetButton(10).RootUIComp.Get().SetUIActive(false);
			base.GetText(4).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			return;
		default:
			return;
		}
	}

	// Token: 0x06013EA6 RID: 81574 RVA: 0x0058CED8 File Offset: 0x0058B0D8
	private void ShowNoneState()
	{
		long freeSpace = Singleton<VideoResUpdate>.Instance.GetFreeSpace();
		if (freeSpace > Singleton<VideoResUpdate>.Instance.GetVideoResSize((EVideoResSizeType)this.SelectResType))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "DownLoadText_LeftSpace", new <>z__ReadOnlySingleElementList<object>("<color=#36cd33>" + HotFixManager.ByteConverter(freeSpace) + "</color>"));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "DownLoadText_LeftSpace", new <>z__ReadOnlySingleElementList<object>("<color=#c25757>" + HotFixManager.ByteConverter(freeSpace) + "</color>"));
		}
		base.GetText(4).SetUIActive(true);
		base.GetItem(5).SetUIActive(false);
		base.GetButton(10).RootUIComp.Get().SetUIActive(true);
		base.GetItem(13).SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "DownLoadButton_Down", Array.Empty<object>());
	}

	// Token: 0x06013EA7 RID: 81575 RVA: 0x0058CFC4 File Offset: 0x0058B1C4
	private void OnClickToggle(int tabIndex, int resType, UUIExtendToggle toggle)
	{
		UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
		if (currentSelectToggle != null)
		{
			currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.SelectResType = resType;
		this.RefreshTabContent(tabIndex);
	}

	// Token: 0x06013EA8 RID: 81576 RVA: 0x0058CFF4 File Offset: 0x0058B1F4
	private void RefreshTabContent(int tabIndex)
	{
		DownLoadTab? config = ConfigDownLoadTabById.GetConfig(tabIndex, true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), config.Value.ContentTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), config.Value.Content, Array.Empty<object>());
		this.DownloadState = Singleton<VideoUpdateManager>.Instance.GetVideoUpdater((EVideoResSizeType)this.SelectResType).GetDownLoadState();
		if (this.DownloadState == EVideoDownloadStatus.None)
		{
			if (Singleton<VideoResUpdate>.Instance.GetIsResPakDownloading((EVideoResSizeType)this.SelectResType))
			{
				this.DownloadState = EVideoDownloadStatus.Pause;
			}
			else if (Singleton<VideoResUpdate>.Instance.GetVideoResSize((EVideoResSizeType)this.SelectResType) == Singleton<VideoResUpdate>.Instance.GetVideoResSavedSize((EVideoResSizeType)this.SelectResType))
			{
				this.DownloadState = EVideoDownloadStatus.Done;
			}
		}
		this.RefreshDownLoadState();
	}

	// Token: 0x06013EA9 RID: 81577 RVA: 0x0058D0C0 File Offset: 0x0058B2C0
	protected override void OnBeforeHide()
	{
		if (this.DownloadState == EVideoDownloadStatus.Downloading)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DownLoadTips_Downing", Array.Empty<object>());
		}
	}

	// Token: 0x04009AE8 RID: 39656
	private int SelectResType = -1;

	// Token: 0x04009AE9 RID: 39657
	private EVideoDownloadStatus DownloadState;

	// Token: 0x04009AEA RID: 39658
	private GenericLayout<ResDownLoadViewTabItem, int> DownLoadTabLayout;

	// Token: 0x04009AEB RID: 39659
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x04009AEC RID: 39660
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04009AED RID: 39661
	[Nullable(2)]
	private VideoResourceUpdateProxy UpdateProxy;

	// Token: 0x02008B24 RID: 35620
	[NullableContext(0)]
	private enum EComponentDefine
	{
		// Token: 0x0402EEA4 RID: 192164
		LayoutItem,
		// Token: 0x0402EEA5 RID: 192165
		TabLayout,
		// Token: 0x0402EEA6 RID: 192166
		TitleText,
		// Token: 0x0402EEA7 RID: 192167
		DesText,
		// Token: 0x0402EEA8 RID: 192168
		MemoryText,
		// Token: 0x0402EEA9 RID: 192169
		DownLoadBarItem,
		// Token: 0x0402EEAA RID: 192170
		DownLoadBarTexture,
		// Token: 0x0402EEAB RID: 192171
		SpeedText,
		// Token: 0x0402EEAC RID: 192172
		LeftBtn,
		// Token: 0x0402EEAD RID: 192173
		LeftBtnText,
		// Token: 0x0402EEAE RID: 192174
		RightBtn,
		// Token: 0x0402EEAF RID: 192175
		RightBtnText,
		// Token: 0x0402EEB0 RID: 192176
		DownLoadStateText,
		// Token: 0x0402EEB1 RID: 192177
		DoneItem
	}

	// Token: 0x02008B25 RID: 35621
	[NullableContext(0)]
	private enum EDownLoadTab
	{
		// Token: 0x0402EEB3 RID: 192179
		Same = 3,
		// Token: 0x0402EEB4 RID: 192180
		Change
	}
}
