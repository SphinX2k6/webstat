using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C17 RID: 19479
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrMainView : UiViewBase
	{
		// Token: 0x06032CE7 RID: 208103 RVA: 0x00CBABA4 File Offset: 0x00CB8DA4
		public VillageInfrMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06032CE8 RID: 208104 RVA: 0x00CBAC18 File Offset: 0x00CB8E18
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickBtnReward)),
				new ValueTuple<int, Delegate>(11, new Action(this.OnClickBtnCloseMask))
			};
		}

		// Token: 0x06032CE9 RID: 208105 RVA: 0x00CBAD77 File Offset: 0x00CB8F77
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.VillageInfrTreeDataUpdate, new Action(this.OnTreeDataUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.VillageInfrActivityTaskDataUpdate, new Action(this.OnTaskDataUpdate));
		}

		// Token: 0x06032CEA RID: 208106 RVA: 0x00CBADB1 File Offset: 0x00CB8FB1
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.VillageInfrTreeDataUpdate, new Action(this.OnTreeDataUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.VillageInfrActivityTaskDataUpdate, new Action(this.OnTaskDataUpdate));
		}

		// Token: 0x06032CEB RID: 208107 RVA: 0x00CBADEC File Offset: 0x00CB8FEC
		protected override UniTask OnBeforeStartAsync()
		{
			VillageInfrMainView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VillageInfrMainView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032CEC RID: 208108 RVA: 0x00CBAE30 File Offset: 0x00CB9030
		private void SetOpenParam()
		{
			if (this.OpenParam != null)
			{
				IVillageInfrMainParam villageInfrMainParam = this.OpenParam as IVillageInfrMainParam;
				EVillageInfrSelectType? evillageInfrSelectType;
				if (villageInfrMainParam == null)
				{
					evillageInfrSelectType = null;
				}
				else
				{
					IVillageInfrBuildFinishTipParam buildFinishParam = villageInfrMainParam.BuildFinishParam;
					evillageInfrSelectType = ((buildFinishParam != null) ? new EVillageInfrSelectType?(buildFinishParam.SelectType) : null);
				}
				EVillageInfrSelectType? evillageInfrSelectType2 = evillageInfrSelectType;
				this.FinishType = evillageInfrSelectType2.GetValueOrDefault();
				int? num;
				if (villageInfrMainParam == null)
				{
					num = null;
				}
				else
				{
					IVillageInfrBuildFinishTipParam buildFinishParam2 = villageInfrMainParam.BuildFinishParam;
					num = ((buildFinishParam2 != null) ? new int?(buildFinishParam2.SelectId) : null);
				}
				int? num2 = num;
				this.FinishId = num2.GetValueOrDefault();
			}
		}

		// Token: 0x06032CED RID: 208109 RVA: 0x00CBAECC File Offset: 0x00CB90CC
		private UniTask CreateCaption()
		{
			VillageInfrMainView.<CreateCaption>d__21 <CreateCaption>d__;
			<CreateCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaption>d__.<>4__this = this;
			<CreateCaption>d__.<>1__state = -1;
			<CreateCaption>d__.<>t__builder.Start<VillageInfrMainView.<CreateCaption>d__21>(ref <CreateCaption>d__);
			return <CreateCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06032CEE RID: 208110 RVA: 0x00CBAF10 File Offset: 0x00CB9110
		private UniTask CreateTreeItems()
		{
			VillageInfrMainView.<CreateTreeItems>d__22 <CreateTreeItems>d__;
			<CreateTreeItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateTreeItems>d__.<>4__this = this;
			<CreateTreeItems>d__.<>1__state = -1;
			<CreateTreeItems>d__.<>t__builder.Start<VillageInfrMainView.<CreateTreeItems>d__22>(ref <CreateTreeItems>d__);
			return <CreateTreeItems>d__.<>t__builder.Task;
		}

		// Token: 0x06032CEF RID: 208111 RVA: 0x00CBAF54 File Offset: 0x00CB9154
		private UniTask CreateVillageItem()
		{
			VillageInfrMainView.<CreateVillageItem>d__23 <CreateVillageItem>d__;
			<CreateVillageItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateVillageItem>d__.<>4__this = this;
			<CreateVillageItem>d__.<>1__state = -1;
			<CreateVillageItem>d__.<>t__builder.Start<VillageInfrMainView.<CreateVillageItem>d__23>(ref <CreateVillageItem>d__);
			return <CreateVillageItem>d__.<>t__builder.Task;
		}

		// Token: 0x06032CF0 RID: 208112 RVA: 0x00CBAF97 File Offset: 0x00CB9197
		protected override void OnStart()
		{
			this.RefreshBtnVisible();
			this.RefreshSequence();
			this.RefreshPanelEffect();
			this.InitPosTweener();
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.VillageInfrTask, base.GetItem(9), null, 0);
		}

		// Token: 0x06032CF1 RID: 208113 RVA: 0x00CBAFCC File Offset: 0x00CB91CC
		protected override void OnBeforeShow()
		{
			this.RefreshTreeItems();
			this.RefreshVillageItem();
			this.RefreshBtnReward();
			if (this.FinishType == EVillageInfrSelectType.Tree)
			{
				VillageInfrTreeItem villageInfrTreeItem = null;
				foreach (VillageInfrTreeItem villageInfrTreeItem2 in this.TreeList)
				{
					if (villageInfrTreeItem2.Id == this.FinishId)
					{
						villageInfrTreeItem = villageInfrTreeItem2;
						break;
					}
				}
				bool flag = Array.IndexOf<int>(VillageInfrDefine.villageInfrNeedMoveTreeId, this.SelectedId) >= 0;
				if (villageInfrTreeItem != null)
				{
					villageInfrTreeItem.PlayLevelSequenceByName(flag ? "GetR" : "GetL");
				}
			}
		}

		// Token: 0x06032CF2 RID: 208114 RVA: 0x00CBB078 File Offset: 0x00CB9278
		private void RefreshSequence()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06032CF3 RID: 208115 RVA: 0x00CBB08C File Offset: 0x00CB928C
		private void RefreshPanelEffect()
		{
			IEnumerable<InfrV2TreeBuild> infrTreeBuildAll = ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuildAll();
			bool uiactive = true;
			foreach (InfrV2TreeBuild infrV2TreeBuild in infrTreeBuildAll)
			{
				IVillageInfrTreeData treeData = ModelBase<VillageInfrModel>.Instance.GetTreeData(infrV2TreeBuild.Id);
				if (treeData == null || treeData.Status != InfrV2StatusPb.InfrV2StatusComplete)
				{
					uiactive = false;
					break;
				}
			}
			base.GetItem(10).SetUIActive(uiactive);
		}

		// Token: 0x06032CF4 RID: 208116 RVA: 0x00CBB110 File Offset: 0x00CB9310
		protected override void OnBeforeDestroy()
		{
			this.ClearPosTweener();
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.VillageInfrTask);
		}

		// Token: 0x06032CF5 RID: 208117 RVA: 0x00CBB128 File Offset: 0x00CB9328
		private void RefreshTreeItems()
		{
			this.TreeDict.Clear();
			IReadOnlyList<InfrV2TreeBuild> infrTreeBuildAll = ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuildAll();
			for (int i = 0; i < this.TreeList.Count; i++)
			{
				VillageInfrTreeItem villageInfrTreeItem = this.TreeList[i];
				int value = this.TreeCompList[i];
				this.TreeDict[infrTreeBuildAll[i].Id] = value;
				int id = infrTreeBuildAll[i].Id;
				EVillageInfrSelectType type = EVillageInfrSelectType.Tree;
				IVillageInfrMainParam villageInfrMainParam = this.OpenParam as IVillageInfrMainParam;
				villageInfrTreeItem.Refresh(id, type, (villageInfrMainParam != null) ? villageInfrMainParam.BuildFinishParam : null);
				villageInfrTreeItem.SetSelectCb(new Action<int, EVillageInfrSelectType>(this.OnClickTreeItem));
				villageInfrTreeItem.SetOnGetSeqEnd(delegate
				{
					if (this.FinishType != EVillageInfrSelectType.None)
					{
						Singleton<UiManager>.Instance.OpenView(EUiViewName.VillageInfrBuildFinishTipView, (this.OpenParam as IVillageInfrMainParam).BuildFinishParam, null);
						this.FinishType = EVillageInfrSelectType.None;
					}
				});
			}
		}

		// Token: 0x06032CF6 RID: 208118 RVA: 0x00CBB1EB File Offset: 0x00CB93EB
		private void RefreshVillageItem()
		{
			this.VillageItem.Refresh(ModelBase<VillageInfrModel>.Instance.GetVillageLevel(), EVillageInfrSelectType.Village, null);
			this.VillageItem.SetSelectCb(new Action<int, EVillageInfrSelectType>(this.OnClickVillageItem));
		}

		// Token: 0x06032CF7 RID: 208119 RVA: 0x00CBB21C File Offset: 0x00CB941C
		private void RefreshBtnReward()
		{
			List<VillageInfrLimitTaskData> activityTaskDataList = ModelBase<VillageInfrModel>.Instance.GetActivityTaskDataList();
			int num = 0;
			using (List<VillageInfrLimitTaskData>.Enumerator enumerator = activityTaskDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == ConditionTaskState.ConditionTaskTaken)
					{
						num++;
					}
				}
			}
			UUIText text = base.GetText(8);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(activityTaskDataList.Count);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06032CF8 RID: 208120 RVA: 0x00CBB2BC File Offset: 0x00CB94BC
		private void RefreshBtnVisible()
		{
			this.Caption.SetUiActive(this.SelectType == EVillageInfrSelectType.None);
			UUIButtonComponent button = base.GetButton(7);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(this.SelectType == EVillageInfrSelectType.None);
			}
			if (this.SelectType == EVillageInfrSelectType.None)
			{
				LevelSequencePlayer seqPlayer = this.SeqPlayer;
				if (seqPlayer != null)
				{
					seqPlayer.PlayLevelSequenceByName("Restore", false, null, false);
				}
			}
			else
			{
				LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
				if (seqPlayer2 != null)
				{
					seqPlayer2.PlayLevelSequenceByName("Switch", false, null, false);
				}
			}
			if (this.SelectType == EVillageInfrSelectType.Village || (this.SelectType == EVillageInfrSelectType.Tree && Array.IndexOf<int>(VillageInfrDefine.villageInfrNeedMoveTreeId, this.SelectedId) >= 0))
			{
				int valueOrDefault = ConfigCommonParamById.GetIntConfig("VillageInfrMainMoveOffset").GetValueOrDefault();
				this.MoveToTargetPosWithTween(new Vector2D(this.StartPos.X - (double)valueOrDefault, this.StartPos.Y), LTweenEase.InOutSine);
				return;
			}
			this.MoveToTargetPosWithTween(new Vector2D(this.StartPos.X, this.StartPos.Y), LTweenEase.InOutSine);
		}

		// Token: 0x06032CF9 RID: 208121 RVA: 0x00CBB3E0 File Offset: 0x00CB95E0
		private void InitPosTweener()
		{
			this.Delegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenVector2SetterDynamic>(new Action<FVector2D>(this.OnTweenUpdate));
			FVector2D anchorOffset = base.GetItem(1).GetAnchorOffset();
			this.StartPos.Set((double)anchorOffset.X, (double)anchorOffset.Y);
		}

		// Token: 0x06032CFA RID: 208122 RVA: 0x00CBB42A File Offset: 0x00CB962A
		private void ClearPosTweener()
		{
			this.KillPosTweener();
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FVector2D>(this.OnTweenUpdate));
		}

		// Token: 0x06032CFB RID: 208123 RVA: 0x00CBB444 File Offset: 0x00CB9644
		public void MoveToTargetPosWithTween(Vector2D targetPos, LTweenEase tweenEase = LTweenEase.InOutSine)
		{
			this.IsTween = true;
			this.KillPosTweener();
			float duration = (float)ConfigCommonParamById.GetIntConfig("VillageInfrMainMoveInterval").GetValueOrDefault() / (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.PosTweener = ULTweenBPLibrary.Vector2To(GlobalData.World, this.Delegate, base.GetItem(1).GetAnchorOffset(), targetPos.ToUeVector2D(false), duration, 0f, tweenEase);
			this.PosTweener.OnCompleteCallBack.Bind(delegate()
			{
				this.IsTween = false;
			});
		}

		// Token: 0x06032CFC RID: 208124 RVA: 0x00CBB4CA File Offset: 0x00CB96CA
		private void KillPosTweener()
		{
			if (this.PosTweener != null)
			{
				this.PosTweener.Kill(false);
				this.PosTweener = null;
			}
		}

		// Token: 0x06032CFD RID: 208125 RVA: 0x00CBB4E7 File Offset: 0x00CB96E7
		private void OnTweenUpdate(FVector2D targetPos)
		{
			base.GetItem(1).SetAnchorOffset(targetPos);
		}

		// Token: 0x06032CFE RID: 208126 RVA: 0x00CBB4F6 File Offset: 0x00CB96F6
		private void OnTreeDataUpdate()
		{
			this.RefreshTreeItems();
			this.RefreshVillageItem();
			this.RefreshPanelEffect();
		}

		// Token: 0x06032CFF RID: 208127 RVA: 0x00CBB50A File Offset: 0x00CB970A
		private void OnTaskDataUpdate()
		{
			this.RefreshBtnReward();
		}

		// Token: 0x06032D00 RID: 208128 RVA: 0x00CBB512 File Offset: 0x00CB9712
		private void OnClickBtnReward()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VillageInfrTaskMainView, null, null);
		}

		// Token: 0x06032D01 RID: 208129 RVA: 0x00CBB525 File Offset: 0x00CB9725
		private void OnClickBtnCloseMask()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.CloseVillageInfrBuildInfoView);
		}

		// Token: 0x06032D02 RID: 208130 RVA: 0x00CBB538 File Offset: 0x00CB9738
		private void OnClickTreeItem(int id, EVillageInfrSelectType type)
		{
			VillageInfrTreeItem selectedItem = this.SelectedItem;
			if (selectedItem != null)
			{
				selectedItem.SetSelected(false);
			}
			this.SelectedId = id;
			this.SelectType = type;
			VillageInfrTreeItem selectedItem2 = null;
			foreach (VillageInfrTreeItem villageInfrTreeItem in this.TreeList)
			{
				if (villageInfrTreeItem.Id == id)
				{
					selectedItem2 = villageInfrTreeItem;
					break;
				}
			}
			this.SelectedItem = selectedItem2;
			this.ProcessBuildInfoView(new VillageInfrBuildInfoParam
			{
				SelectType = this.SelectType,
				SelectId = this.SelectedId,
				IsDelivery = false,
				CloseCb = new Action(this.SelectCloseCb)
			});
			this.RefreshBtnVisible();
		}

		// Token: 0x06032D03 RID: 208131 RVA: 0x00CBB5FC File Offset: 0x00CB97FC
		private void OnClickVillageItem(int id, EVillageInfrSelectType type)
		{
			VillageInfrTreeItem selectedItem = this.SelectedItem;
			if (selectedItem != null)
			{
				selectedItem.SetSelected(false);
			}
			this.SelectedId = id;
			this.SelectType = type;
			this.SelectedItem = this.VillageItem;
			this.ProcessBuildInfoView(new VillageInfrBuildInfoParam
			{
				SelectType = this.SelectType,
				SelectId = ModelBase<VillageInfrModel>.Instance.GetVillageLevel(),
				IsDelivery = false,
				CloseCb = new Action(this.SelectCloseCb)
			});
			this.RefreshBtnVisible();
		}

		// Token: 0x06032D04 RID: 208132 RVA: 0x00CBB67C File Offset: 0x00CB987C
		private void ProcessBuildInfoView(IVillageInfrBuildInfoParam param)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.VillageInfrBuildInfoView))
			{
				Singleton<EventSystem>.Instance.Emit<IVillageInfrBuildInfoParam>(EEventName.VillageInfrMainViewOnSelect, param);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VillageInfrBuildInfoView, param, delegate(bool isSuccess, int viewId)
			{
				if (isSuccess)
				{
					base.AddChildViewById(viewId);
				}
			});
		}

		// Token: 0x06032D05 RID: 208133 RVA: 0x00CBB6C8 File Offset: 0x00CB98C8
		private void SelectCloseCb()
		{
			VillageInfrTreeItem selectedItem = this.SelectedItem;
			if (selectedItem != null)
			{
				selectedItem.SetSelected(false);
			}
			this.SelectedItem = null;
			this.SelectType = EVillageInfrSelectType.None;
			this.RefreshBtnVisible();
		}

		// Token: 0x0401D91F RID: 121119
		private int SelectedId;

		// Token: 0x0401D920 RID: 121120
		private EVillageInfrSelectType SelectType;

		// Token: 0x0401D921 RID: 121121
		private readonly List<VillageInfrTreeItem> TreeList = new List<VillageInfrTreeItem>();

		// Token: 0x0401D922 RID: 121122
		private readonly List<int> TreeCompList = new List<int>
		{
			2,
			3,
			4,
			5
		};

		// Token: 0x0401D923 RID: 121123
		private readonly Dictionary<int, int> TreeDict = new Dictionary<int, int>();

		// Token: 0x0401D924 RID: 121124
		private readonly VillageInfrTreeItem VillageItem = new VillageInfrTreeItem();

		// Token: 0x0401D925 RID: 121125
		private readonly PopupCaptionItem Caption = new PopupCaptionItem(null);

		// Token: 0x0401D926 RID: 121126
		[Nullable(2)]
		private VillageInfrTreeItem SelectedItem;

		// Token: 0x0401D927 RID: 121127
		[Nullable(2)]
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0401D928 RID: 121128
		private EVillageInfrSelectType FinishType;

		// Token: 0x0401D929 RID: 121129
		public int FinishId;

		// Token: 0x0401D92A RID: 121130
		[Nullable(2)]
		private ULTweener PosTweener;

		// Token: 0x0401D92B RID: 121131
		[Nullable(2)]
		private FLTweenVector2SetterDynamic Delegate;

		// Token: 0x0401D92C RID: 121132
		public bool IsTween;

		// Token: 0x0401D92D RID: 121133
		private readonly Vector2D StartPos = Vector2D.Create();
	}
}
