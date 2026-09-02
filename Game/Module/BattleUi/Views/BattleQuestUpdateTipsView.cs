using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200604D RID: 24653
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleQuestUpdateTipsView : BattleChildView
	{
		// Token: 0x0603E30D RID: 254733 RVA: 0x00FE0F04 File Offset: 0x00FDF104
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUIItem)));
			}
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickTrack));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603E30E RID: 254734 RVA: 0x00FE1034 File Offset: 0x00FDF234
		protected override void OnStart()
		{
			base.GetText(0).OnSelfLanguageChange.Bind(new Action(this.UpdateQuestName));
			base.GetText(1).OnSelfLanguageChange.Bind(new Action(this.UpdateNodeDescribe));
			base.GetItem(4).SetUIActive(true);
		}

		// Token: 0x0603E30F RID: 254735 RVA: 0x00FE1088 File Offset: 0x00FDF288
		[NullableContext(2)]
		protected override UniTask InitializeAsync(object param = null)
		{
			BattleQuestUpdateTipsView.<InitializeAsync>d__8 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<BattleQuestUpdateTipsView.<InitializeAsync>d__8>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E310 RID: 254736 RVA: 0x00FE10CB File Offset: 0x00FDF2CB
		protected override void OnBeforeDestroy()
		{
			base.GetText(0).OnSelfLanguageChange.Unbind();
			base.GetText(1).OnSelfLanguageChange.Unbind();
			ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603E311 RID: 254737 RVA: 0x00FE110A File Offset: 0x00FDF30A
		public void OnBeforePlayShowSequence(QuestUpdateTipsShowData info)
		{
			this.UpdateData(info);
			ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			ControllerBase<InputDistributeController>.Instance.BindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603E312 RID: 254738 RVA: 0x00FE1149 File Offset: 0x00FDF349
		public void OnBeforePlayHideSequence()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			this.IsPlayCloseSequence = true;
		}

		// Token: 0x0603E313 RID: 254739 RVA: 0x00FE1170 File Offset: 0x00FDF370
		public void OnAfterPlayHideSequence()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			this.IsPlayCloseSequence = false;
			if (!this.IsClicked)
			{
				QuestUpdateTipsShowData showData = this.ShowData;
				if (showData != null && showData.IsNewQuest)
				{
					ControllerBase<QuestNewController>.Instance.TryChangeTrackedQuest(ModelBase<QuestNewModel>.Instance.CurShowUpdateTipsQuest);
				}
			}
			ModelBase<QuestNewModel>.Instance.CurShowUpdateTipsQuest = 0;
			this.ShowData = null;
		}

		// Token: 0x0603E314 RID: 254740 RVA: 0x00FE11E2 File Offset: 0x00FDF3E2
		public void UpdateData(QuestUpdateTipsShowData info)
		{
			this.IsClicked = false;
			this.RefreshUi(info);
			this.OpenNewMissionTipsView();
			QuestUpdateTipsShowData showData = this.ShowData;
			if (showData != null && showData.IsNewQuest)
			{
				ModelBase<QuestNewModel>.Instance.CurShowUpdateTipsQuest = info.QuestId;
			}
		}

		// Token: 0x0603E315 RID: 254741 RVA: 0x00FE121C File Offset: 0x00FDF41C
		public void RefreshUi(QuestUpdateTipsShowData data)
		{
			this.ShowData = data;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "BattleQuestUpdateTipsView:界面刷新";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("任务Id", this.ShowData.QuestId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.SetIcon();
			this.UpdateQuestName();
			this.UpdateNodeDescribe();
		}

		// Token: 0x0603E316 RID: 254742 RVA: 0x00FE1278 File Offset: 0x00FDF478
		private void SetIcon()
		{
			QuestUpdateTipsShowData showData = this.ShowData;
			int markId = (showData != null) ? showData.MissionViewShowData.TrackIconConfigId : 0;
			string questTypeMark = ConfigBase<QuestNewConfig>.Instance.GetQuestTypeMark(markId);
			UUISprite sprite = base.GetSprite(2);
			this.SetSpriteByPath(questTypeMark, sprite, false, null, null);
		}

		// Token: 0x0603E317 RID: 254743 RVA: 0x00FE12C4 File Offset: 0x00FDF4C4
		private void UpdateQuestName()
		{
			if (this.ShowData == null)
			{
				return;
			}
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.ShowData.QuestId);
			if (quest == null)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "BattleQuestUpdateTipsView:UpdateQuestName";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QuestName", quest.Name);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.GetText(0).SetText(quest.Name, true);
		}

		// Token: 0x0603E318 RID: 254744 RVA: 0x00FE1334 File Offset: 0x00FDF534
		private void UpdateNodeDescribe()
		{
			if (this.ShowData == null)
			{
				return;
			}
			string text = string.Empty;
			if (this.ShowData.MissionViewShowData.MainStepInfo != null)
			{
				text = MissionViewStepTextUtil.GetStepTextByConfig(this.ShowData.MissionViewShowData.Id, this.ShowData.MissionViewShowData.MainStepInfo);
			}
			else if (this.ShowData.MissionViewShowData.DataSource == EMissionItemViewDataSource.BehaviorTree)
			{
				text = ControllerBase<GeneralLogicTreeController>.Instance.GetNodeTrackText(this.ShowData.MissionViewShowData.Id, this.ShowData.NodeId);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "BattleQuestUpdateTipsView:UpdateNodeDescribe";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("describe", text);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.GetText(1).SetText(text, true);
		}

		// Token: 0x0603E319 RID: 254745 RVA: 0x00FE13F8 File Offset: 0x00FDF5F8
		private void OpenNewMissionTipsView()
		{
			if (this.ShowData == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.MissionUpdate, this.ShowData.IsNewQuest);
			if (!this.ShowData.IsNewQuest)
			{
				return;
			}
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.ShowData.QuestId);
			EQuest? equest = (quest != null) ? new EQuest?(quest.Type) : null;
			if (equest == null)
			{
				return;
			}
			int? newTipsShowTime = ConfigBase<QuestNewConfig>.Instance.GetNewTipsShowTime((int)equest.Value);
			int num = 0;
			if (newTipsShowTime.GetValueOrDefault() > num & newTipsShowTime != null)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.NewMissionTips, this.ShowData.QuestId, null);
			}
		}

		// Token: 0x0603E31A RID: 254746 RVA: 0x00FE14B8 File Offset: 0x00FDF6B8
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType != InputDistributeDefine.EActionType.Release)
			{
				return;
			}
			this.OnClickTrack();
		}

		// Token: 0x0603E31B RID: 254747 RVA: 0x00FE14C8 File Offset: 0x00FDF6C8
		private void OnClickTrack()
		{
			if (this.LockClickTrack || this.ShowData == null || this.ShowData.QuestId == 0)
			{
				return;
			}
			this.LockClickTrack = true;
			if (!this.IsClicked)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.QuestUpdateTipsClickTrack);
				this.IsClicked = true;
			}
			ControllerBase<QuestNewController>.Instance.RequestTrackQuest(this.ShowData.QuestId, true, ERequestTrackOperate.Manual, ESetTrackReason.None, delegate
			{
				this.LockClickTrack = false;
			});
		}

		// Token: 0x0603E31C RID: 254748 RVA: 0x00FE153E File Offset: 0x00FDF73E
		public bool IsClosing()
		{
			return this.IsPlayCloseSequence;
		}

		// Token: 0x04022DC7 RID: 142791
		[Nullable(2)]
		private CombineKeyItem KeyItem;

		// Token: 0x04022DC8 RID: 142792
		[Nullable(2)]
		private QuestUpdateTipsShowData ShowData;

		// Token: 0x04022DC9 RID: 142793
		private bool LockClickTrack;

		// Token: 0x04022DCA RID: 142794
		private bool IsPlayCloseSequence;

		// Token: 0x04022DCB RID: 142795
		private bool IsClicked;

		// Token: 0x0200C10F RID: 49423
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B736 RID: 243510
			QuestNameText,
			// Token: 0x0403B737 RID: 243511
			NodeDescribeText,
			// Token: 0x0403B738 RID: 243512
			QuestIcon,
			// Token: 0x0403B739 RID: 243513
			TrackBtn,
			// Token: 0x0403B73A RID: 243514
			Step1Item,
			// Token: 0x0403B73B RID: 243515
			KeyItem
		}
	}
}
