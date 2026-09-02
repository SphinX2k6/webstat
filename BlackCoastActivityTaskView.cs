using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200126C RID: 4716
[NullableContext(1)]
[Nullable(0)]
public class BlackCoastActivityTaskView : UiViewBase
{
	// Token: 0x06007DDA RID: 32218 RVA: 0x0021341F File Offset: 0x0021161F
	public BlackCoastActivityTaskView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06007DDB RID: 32219 RVA: 0x0021343C File Offset: 0x0021163C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickPre));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickNext));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007DDC RID: 32220 RVA: 0x00213654 File Offset: 0x00211854
	protected override UniTask OnBeforeStartAsync()
	{
		BlackCoastActivityTaskView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BlackCoastActivityTaskView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007DDD RID: 32221 RVA: 0x00213698 File Offset: 0x00211898
	private UniTask LoadMaterial()
	{
		BlackCoastActivityTaskView.<LoadMaterial>d__12 <LoadMaterial>d__;
		<LoadMaterial>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadMaterial>d__.<>4__this = this;
		<LoadMaterial>d__.<>1__state = -1;
		<LoadMaterial>d__.<>t__builder.Start<BlackCoastActivityTaskView.<LoadMaterial>d__12>(ref <LoadMaterial>d__);
		return <LoadMaterial>d__.<>t__builder.Task;
	}

	// Token: 0x06007DDE RID: 32222 RVA: 0x002136DC File Offset: 0x002118DC
	protected override void OnBeforeShow()
	{
		ControllerBase<ActivityController>.Instance.CheckIsActivityClose(null, new int?(this.ActivityBaseData.Id));
	}

	// Token: 0x06007DDF RID: 32223 RVA: 0x0021370C File Offset: 0x0021190C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshTaskLayout));
	}

	// Token: 0x06007DE0 RID: 32224 RVA: 0x0021372A File Offset: 0x0021192A
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshTaskLayout));
	}

	// Token: 0x06007DE1 RID: 32225 RVA: 0x00213748 File Offset: 0x00211948
	protected override void OnBeforeDestroy()
	{
		MediaPlayer mediaPlayer = this.MediaPlayer;
		if (mediaPlayer != null)
		{
			mediaPlayer.Clear();
		}
		this.MediaPlayer = null;
		this.CancelLoad();
	}

	// Token: 0x06007DE2 RID: 32226 RVA: 0x00213768 File Offset: 0x00211968
	private void CancelLoad()
	{
		if (this.HandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.HandleId);
			this.HandleId = -1;
		}
	}

	// Token: 0x06007DE3 RID: 32227 RVA: 0x0021378A File Offset: 0x0021198A
	private PageDot<int> InitPageDot()
	{
		return new PageDot<int>();
	}

	// Token: 0x06007DE4 RID: 32228 RVA: 0x00213791 File Offset: 0x00211991
	private BlackCoastTaskItem CreateTaskItem()
	{
		return new BlackCoastTaskItem();
	}

	// Token: 0x06007DE5 RID: 32229 RVA: 0x00213798 File Offset: 0x00211998
	private void OnRefreshTaskLayout(int activityId)
	{
		if (this.ActivityBaseData != null && this.ActivityBaseData.Id == activityId)
		{
			BlackCoastStageInfo stageById = this.ActivityBaseData.GetStageById(this.StageIdList[this.CurrentSelectedIndex]);
			this.RefreshStageInfo();
			this.RefreshTaskList(stageById.GetTaskList(), false);
		}
	}

	// Token: 0x06007DE6 RID: 32230 RVA: 0x002137EB File Offset: 0x002119EB
	private void OnClickPre()
	{
		this.RefreshView(this.CurrentSelectedIndex - 1);
	}

	// Token: 0x06007DE7 RID: 32231 RVA: 0x002137FC File Offset: 0x002119FC
	private void OnClickNext()
	{
		int index = this.CurrentSelectedIndex + 1;
		BlackCoastStageInfo stageById = this.ActivityBaseData.GetStageById(this.StageIdList[index]);
		if (stageById.IsUnlock)
		{
			this.RefreshView(index);
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(stageById.GetLockConditionText(), Array.Empty<object>());
	}

	// Token: 0x06007DE8 RID: 32232 RVA: 0x00213850 File Offset: 0x00211A50
	private UniTask InitView(int index)
	{
		BlackCoastActivityTaskView.<InitView>d__23 <InitView>d__;
		<InitView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitView>d__.<>4__this = this;
		<InitView>d__.index = index;
		<InitView>d__.<>1__state = -1;
		<InitView>d__.<>t__builder.Start<BlackCoastActivityTaskView.<InitView>d__23>(ref <InitView>d__);
		return <InitView>d__.<>t__builder.Task;
	}

	// Token: 0x06007DE9 RID: 32233 RVA: 0x0021389C File Offset: 0x00211A9C
	private UniTask RefreshView(int index)
	{
		BlackCoastActivityTaskView.<RefreshView>d__24 <RefreshView>d__;
		<RefreshView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshView>d__.<>4__this = this;
		<RefreshView>d__.index = index;
		<RefreshView>d__.<>1__state = -1;
		<RefreshView>d__.<>t__builder.Start<BlackCoastActivityTaskView.<RefreshView>d__24>(ref <RefreshView>d__);
		return <RefreshView>d__.<>t__builder.Task;
	}

	// Token: 0x06007DEA RID: 32234 RVA: 0x002138E8 File Offset: 0x00211AE8
	private void RefreshStageInfo()
	{
		BlackCoastStageInfo stageById = this.ActivityBaseData.GetStageById(this.StageIdList[this.CurrentSelectedIndex]);
		BlackCoastThemeStageRe? stageConfig = ConfigBase<ActivityBlackCoastConfig>.Instance.GetStageConfig(stageById.StageId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "BlackCoastTheme_TaskCompleteProgress", new <>z__ReadOnlySingleElementList<object>(stageById.GetTaskProgress()));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), stageConfig.Value.TitleDetail, Array.Empty<object>());
	}

	// Token: 0x06007DEB RID: 32235 RVA: 0x0021396F File Offset: 0x00211B6F
	private void RefreshTaskList(List<BlackCoastTaskData> data, bool playGridAnim = false)
	{
		this.TaskScroll.RefreshByData(data, null, playGridAnim);
	}

	// Token: 0x06007DEC RID: 32236 RVA: 0x00213980 File Offset: 0x00211B80
	private void RefreshBg()
	{
		BlackCoastStageInfo stageById = this.ActivityBaseData.GetStageById(this.StageIdList[this.CurrentSelectedIndex]);
		this.MediaPlayer.PlayVideo(stageById.StageId.ToString(), stageById.GetVideoSource(), true);
	}

	// Token: 0x06007DED RID: 32237 RVA: 0x002139CA File Offset: 0x00211BCA
	private void CloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x04003C67 RID: 15463
	protected ActivityBlackCoastData ActivityBaseData;

	// Token: 0x04003C68 RID: 15464
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003C69 RID: 15465
	private GenericLayout<PageDot<int>, int> PageDotLayout;

	// Token: 0x04003C6A RID: 15466
	private GenericLayout<BlackCoastTaskItem, BlackCoastTaskData> TaskScroll;

	// Token: 0x04003C6B RID: 15467
	private List<int> StageIdList = new List<int>();

	// Token: 0x04003C6C RID: 15468
	private int CurrentSelectedIndex;

	// Token: 0x04003C6D RID: 15469
	private MediaPlayer MediaPlayer;

	// Token: 0x04003C6E RID: 15470
	private int HandleId = -1;

	// Token: 0x020075E3 RID: 30179
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028A6A RID: 166506
		public const int Caption = 0;

		// Token: 0x04028A6B RID: 166507
		public const int PanelBg = 1;

		// Token: 0x04028A6C RID: 166508
		public const int DotLayout = 2;

		// Token: 0x04028A6D RID: 166509
		public const int Dot = 3;

		// Token: 0x04028A6E RID: 166510
		public const int TaskLayout = 4;

		// Token: 0x04028A6F RID: 166511
		public const int TaskItem = 5;

		// Token: 0x04028A70 RID: 166512
		public const int ButtonPre = 6;

		// Token: 0x04028A71 RID: 166513
		public const int ButtonNext = 7;

		// Token: 0x04028A72 RID: 166514
		public const int TextProgress = 8;

		// Token: 0x04028A73 RID: 166515
		public const int CG = 9;

		// Token: 0x04028A74 RID: 166516
		public const int TextName = 10;

		// Token: 0x04028A75 RID: 166517
		public const int TextureIcon = 11;
	}
}
