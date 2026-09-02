using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ResManager;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using UnrealEngine;

// Token: 0x02002766 RID: 10086
public class ResDownLoadLoadingView : UiViewBase
{
	// Token: 0x06013E6E RID: 81518 RVA: 0x0058B918 File Offset: 0x00589B18
	[NullableContext(1)]
	public ResDownLoadLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013E6F RID: 81519 RVA: 0x0058B924 File Offset: 0x00589B24
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013E70 RID: 81520 RVA: 0x0058B9AE File Offset: 0x00589BAE
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EVideoDownloadStatus>(EEventName.ResDownLoadStateRefresh, new Action<EVideoDownloadStatus>(this.ResDownLoadStateRefresh));
	}

	// Token: 0x06013E71 RID: 81521 RVA: 0x0058B9CC File Offset: 0x00589BCC
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ResDownLoadStateRefresh, new Action<EVideoDownloadStatus>(this.ResDownLoadStateRefresh));
	}

	// Token: 0x06013E72 RID: 81522 RVA: 0x0058B9EC File Offset: 0x00589BEC
	protected override void OnStart()
	{
		ControllerBase<ResourceManagerController>.Instance.ChangeHttpTickFrequency();
		this.RefreshView();
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.RefreshView();
		}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
	}

	// Token: 0x06013E73 RID: 81523 RVA: 0x0058BA38 File Offset: 0x00589C38
	private void DownloadFinish()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "DownLoadText_Downing", Array.Empty<object>());
		float num = (float)this.MaxSize / (float)this.MaxSize;
		string str = HotFixManager.ByteConverter(0L) + "/s ";
		string str2 = string.Concat(new string[]
		{
			"(",
			HotFixManager.ByteConverter(this.MaxSize),
			"/",
			HotFixManager.ByteConverter(this.MaxSize),
			") "
		});
		base.GetTexture(0).SetFillAmount(num);
		string str3 = (num * 100f).ToString("F2").TrimEnd('0').TrimEnd('.') + "%";
		base.GetText(2).SetText(str + str2 + str3, true);
	}

	// Token: 0x06013E74 RID: 81524 RVA: 0x0058BB34 File Offset: 0x00589D34
	private void RefreshView()
	{
		ValueTuple<long, long, long, long> downLoadProgress = Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.LoginPrepare).GetDownLoadProgress();
		this.MaxSize = downLoadProgress.Item3;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "DownLoadText_Downing", Array.Empty<object>());
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
		base.GetTexture(0).SetFillAmount(num);
		string str3 = (num * 100f).ToString("F2").TrimEnd('0').TrimEnd('.') + "%";
		base.GetText(2).SetText(str + str2 + str3, true);
	}

	// Token: 0x06013E75 RID: 81525 RVA: 0x0058BC34 File Offset: 0x00589E34
	private void ResDownLoadStateRefresh(EVideoDownloadStatus state)
	{
		if (state == EVideoDownloadStatus.Done)
		{
			this.DownloadFinish();
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ResDownLoadDoneConfirm);
			confirmBoxDataNew.IsEscViewTriggerCallBack = true;
			confirmBoxDataNew.FunctionMap.Add(0, delegate
			{
				base.CloseMe(null);
				ModelBase<QuestResourceModel>.Instance.UserClicked();
			});
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				base.CloseMe(null);
				ModelBase<QuestResourceModel>.Instance.UserClicked();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
		}
	}

	// Token: 0x06013E76 RID: 81526 RVA: 0x0058BC99 File Offset: 0x00589E99
	protected override void OnBeforeDestroy()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		ControllerBase<ResourceManagerController>.Instance.RestoreHttpTickFrequency();
	}

	// Token: 0x04009AE3 RID: 39651
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04009AE4 RID: 39652
	private long MaxSize;

	// Token: 0x02008B1E RID: 35614
	private enum EComponentDefine
	{
		// Token: 0x0402EE8D RID: 192141
		BarTexture,
		// Token: 0x0402EE8E RID: 192142
		ProgressText,
		// Token: 0x0402EE8F RID: 192143
		SpeedText
	}
}
