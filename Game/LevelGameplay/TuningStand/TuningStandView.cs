using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.TuningStand.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.TuningStand
{
	// Token: 0x02006A7B RID: 27259
	[NullableContext(2)]
	[Nullable(0)]
	public class TuningStandView : UiViewBase
	{
		// Token: 0x060436C7 RID: 276167 RVA: 0x0115E7EA File Offset: 0x0115C9EA
		[NullableContext(1)]
		public TuningStandView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060436C8 RID: 276168 RVA: 0x0115E7F4 File Offset: 0x0115C9F4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(12, typeof(UUIText)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIItem)),
				new ValueTuple<int, Type>(20, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(21, typeof(UUIItem)),
				new ValueTuple<int, Type>(22, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(13, new Action(this.ResetGrid)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickedTips)),
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickedTips)),
				new ValueTuple<int, Delegate>(20, new Action(this.OnCloseGuide))
			};
		}

		// Token: 0x060436C9 RID: 276169 RVA: 0x0115EA6C File Offset: 0x0115CC6C
		protected override UniTask OnBeforeStartAsync()
		{
			TuningStandView.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TuningStandView.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060436CA RID: 276170 RVA: 0x0115EAB0 File Offset: 0x0115CCB0
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(1));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickClose));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickHelp));
			this.IsTuning = (this.Config.VisualType == ETuningStandVisualType.Tuning);
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(this.IsTuning);
			}
			UUIItem item2 = base.GetItem(7);
			if (item2 != null)
			{
				item2.SetUIActive(this.IsTuning);
			}
			if (this.IsTuning)
			{
				string path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("IconRoleHeadMemes_FLL") ?? "";
				base.SetTextureByPath(path, base.GetTexture(4), null, null);
				string resourceId = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? "IconRoleHeadMemes_Nv" : "IconRoleHeadMemes_Nan";
				string path2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId) ?? "";
				base.SetTextureByPath(path2, base.GetTexture(8), null, null);
			}
			UUIItem item3 = base.GetItem(19);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			this.FloroSequencer = new LevelSequencePlayer(base.GetItem(3));
			this.MainSequencer = new LevelSequencePlayer(base.GetItem(7));
			this.LightButtonLeft = new LevelSequencePlayer(base.GetButton(5).RootUIComp);
			this.LightButtonRight = new LevelSequencePlayer(base.GetButton(9).RootUIComp);
			this.UiViewSequence.AddSequenceFinishEvent("Start", new Action<string>(this.OnStartEnd), false);
		}

		// Token: 0x060436CB RID: 276171 RVA: 0x0115EC50 File Offset: 0x0115CE50
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int?>(EEventName.TuningStandUpdate, new Action<int?>(this.OnRefreshGrid));
			Singleton<EventSystem>.Instance.Add(EEventName.TuningStandSuccess, new Action(this.OnClear));
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.TuningStandSuccessShowStart, new Action<IReadOnlyList<int>>(this.ClearAnimShowStart));
			Singleton<EventSystem>.Instance.Add(EEventName.TuningStandSuccessShowEnd, new Action(this.ClearAnimShowEnd));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.TuningStandTooLongTime, new Action<bool>(this.OnTooLong));
			Singleton<EventSystem>.Instance.Add<ITuningStandBubbleData>(EEventName.TuningStandBubbleUpdate, new Action<ITuningStandBubbleData>(this.OnBubble));
			Singleton<EventSystem>.Instance.Add<ETuningStandBubbleTriggerType>(EEventName.TuningStandBubbleEnd, new Action<ETuningStandBubbleTriggerType>(this.OnBubbleEnd));
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnAnimEvent));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.TuningStandOnLinkMiss, new Action<bool>(this.OnLinkMiss));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		}

		// Token: 0x060436CC RID: 276172 RVA: 0x0115ED78 File Offset: 0x0115CF78
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int?>(EEventName.TuningStandUpdate, new Action<int?>(this.OnRefreshGrid));
			Singleton<EventSystem>.Instance.Remove(EEventName.TuningStandSuccess, new Action(this.OnClear));
			Singleton<EventSystem>.Instance.Remove<IReadOnlyList<int>>(EEventName.TuningStandSuccessShowStart, new Action<IReadOnlyList<int>>(this.ClearAnimShowStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.TuningStandSuccessShowEnd, new Action(this.ClearAnimShowEnd));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.TuningStandTooLongTime, new Action<bool>(this.OnTooLong));
			Singleton<EventSystem>.Instance.Remove<ITuningStandBubbleData>(EEventName.TuningStandBubbleUpdate, new Action<ITuningStandBubbleData>(this.OnBubble));
			Singleton<EventSystem>.Instance.Remove<ETuningStandBubbleTriggerType>(EEventName.TuningStandBubbleEnd, new Action<ETuningStandBubbleTriggerType>(this.OnBubbleEnd));
			Singleton<EventSystem>.Instance.Remove<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnAnimEvent));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.TuningStandOnLinkMiss, new Action<bool>(this.OnLinkMiss));
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		}

		// Token: 0x060436CD RID: 276173 RVA: 0x0115EE9D File Offset: 0x0115D09D
		protected override void OnBeforeHide()
		{
			if (!this.LastHide)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x060436CE RID: 276174 RVA: 0x0115EEB0 File Offset: 0x0115D0B0
		protected override void OnBeforeDestroy()
		{
			if (this.TooLongHandle != null)
			{
				if (TimerSystem.GameplayTimeInstance.Has(this.TooLongHandle))
				{
					TimerSystem.GameplayTimeInstance.Remove(this.TooLongHandle);
				}
				this.TooLongHandle = null;
			}
			this.MusicItem = null;
			this.MusicItemPlay = null;
			this.GuideItem = null;
			ModelBase<TuningStandModel>.Instance.UnloadData();
			TuningStandNodeTween redTweener = this.RedTweener;
			if (redTweener != null)
			{
				redTweener.Clear();
			}
			this.RedTweener = null;
			TuningStandNodeTween blueTweener = this.BlueTweener;
			if (blueTweener != null)
			{
				blueTweener.Clear();
			}
			this.BlueTweener = null;
		}

		// Token: 0x060436CF RID: 276175 RVA: 0x0115EF3E File Offset: 0x0115D13E
		private void OnClickClose()
		{
			this.UiViewSequence.CloseSequenceName = "Close";
			if (this.IsGameClear)
			{
				this.OnClearClose();
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x060436D0 RID: 276176 RVA: 0x0115EF66 File Offset: 0x0115D166
		private void OnClickHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(346);
		}

		// Token: 0x060436D1 RID: 276177 RVA: 0x0115EF77 File Offset: 0x0115D177
		[NullableContext(1)]
		private TuningStandGridItem CreateGrid()
		{
			return new TuningStandGridItem();
		}

		// Token: 0x060436D2 RID: 276178 RVA: 0x0115EF80 File Offset: 0x0115D180
		private void OnRefreshGrid(int? index = null)
		{
			List<TuningStandGridItem> layoutItemList = this.GridLayout.GetLayoutItemList();
			if (index != null)
			{
				layoutItemList[index.Value].RefreshGrid();
				return;
			}
			foreach (TuningStandGridItem tuningStandGridItem in layoutItemList)
			{
				tuningStandGridItem.RefreshGrid();
			}
		}

		// Token: 0x060436D3 RID: 276179 RVA: 0x0115EFF4 File Offset: 0x0115D1F4
		private void OnClear()
		{
			if (this.TooLongHandle != null)
			{
				if (TimerSystem.GameplayTimeInstance.Has(this.TooLongHandle))
				{
					TimerSystem.GameplayTimeInstance.Remove(this.TooLongHandle);
				}
				this.TooLongHandle = null;
			}
			ControllerBase<UiNavigationNewController>.Instance.ResetNavigationFocusForViewWithDirtyCheck();
			this.IsGameClear = true;
			base.GetItem(19).SetUIActive(true);
			if (this.IsTuning)
			{
				ModelBase<TuningStandModel>.Instance.TryStartBubbleFlow(ETuningStandBubbleTriggerType.LinkComplete);
			}
		}

		// Token: 0x060436D4 RID: 276180 RVA: 0x0115F068 File Offset: 0x0115D268
		[NullableContext(1)]
		private void ClearAnimShowStart(IReadOnlyList<int> startIndex)
		{
			List<TuningStandGridItem> layoutItemList = this.GridLayout.GetLayoutItemList();
			List<TuningGridData> gridList = ModelBase<TuningStandModel>.Instance.GetGridList();
			bool flag = false;
			for (int i = 0; i < layoutItemList.Count; i++)
			{
				if (!startIndex.Contains(i))
				{
					layoutItemList[i].StartRevolving();
				}
			}
			foreach (int index in startIndex)
			{
				TuningStandGridItem item = layoutItemList[index];
				ETuningStandGridType gridType = gridList[index].GridType;
				UUIItem activeNode = this.MusicItem.GetActiveNode(gridType);
				FVectorDouble start = item.GetRootItem().D_K2_GetComponentLocation();
				FVectorDouble end = activeNode.D_K2_GetComponentLocation();
				if (gridType == ETuningStandGridType.Start1)
				{
					TimerSystem.Instance.Delay(delegate(float _)
					{
						TuningStandNodeTween redTweener = this.RedTweener;
						if (redTweener != null)
						{
							redTweener.PlayTween(start, end, true);
						}
						item.StartRevolving();
					}, 250f, null, null, true, 1f);
				}
				if (gridType == ETuningStandGridType.Start2)
				{
					flag = true;
					item.StartRevolving();
					TuningStandNodeTween blueTweener = this.BlueTweener;
					if (blueTweener != null)
					{
						blueTweener.PlayTween(start, end, true);
					}
				}
			}
			if (!flag)
			{
				FVectorDouble fvectorDouble = base.GetItem(0).D_K2_GetComponentLocation();
				TuningStandNodeTween blueTweener2 = this.BlueTweener;
				if (blueTweener2 == null)
				{
					return;
				}
				blueTweener2.PlayTween(fvectorDouble, fvectorDouble, false);
			}
		}

		// Token: 0x060436D5 RID: 276181 RVA: 0x0115F1DC File Offset: 0x0115D3DC
		private void ClearAnimShowEnd()
		{
			this.OnClearAnimShowEnd();
		}

		// Token: 0x060436D6 RID: 276182 RVA: 0x0115F1E8 File Offset: 0x0115D3E8
		private UniTask OnClearAnimShowEnd()
		{
			TuningStandView.<OnClearAnimShowEnd>d__38 <OnClearAnimShowEnd>d__;
			<OnClearAnimShowEnd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnClearAnimShowEnd>d__.<>4__this = this;
			<OnClearAnimShowEnd>d__.<>1__state = -1;
			<OnClearAnimShowEnd>d__.<>t__builder.Start<TuningStandView.<OnClearAnimShowEnd>d__38>(ref <OnClearAnimShowEnd>d__);
			return <OnClearAnimShowEnd>d__.<>t__builder.Task;
		}

		// Token: 0x060436D7 RID: 276183 RVA: 0x0115F22C File Offset: 0x0115D42C
		private void ResetGrid()
		{
			if (this.IsGameClear)
			{
				return;
			}
			ModelBase<TuningStandModel>.Instance.ResetGrid();
			List<TuningGridData> gridList = ModelBase<TuningStandModel>.Instance.GetGridList();
			this.GridLayout.RefreshByData(gridList, null, false);
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.SetFocusOnStart();
			}, 500f, null, null, true, 1f);
		}

		// Token: 0x060436D8 RID: 276184 RVA: 0x0115F289 File Offset: 0x0115D489
		private void OnBubbleEnd(ETuningStandBubbleTriggerType type)
		{
			if (type == ETuningStandBubbleTriggerType.Enter)
			{
				this.OnEnterBubbleEnd();
			}
		}

		// Token: 0x060436D9 RID: 276185 RVA: 0x0115F294 File Offset: 0x0115D494
		private void OnTooLong(bool isMain)
		{
			if (this.IsTuning)
			{
				UUIButtonComponent button = base.GetButton(5);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(!isMain);
				}
				UUIButtonComponent button2 = base.GetButton(9);
				if (button2 != null)
				{
					button2.RootUIComp.Get().SetUIActive(isMain);
				}
				if (isMain)
				{
					this.LightButtonRight.PlayLevelSequenceByName("Start", false, null, false);
					return;
				}
				this.LightButtonLeft.PlayLevelSequenceByName("Start", false, null, false);
			}
		}

		// Token: 0x060436DA RID: 276186 RVA: 0x0115F328 File Offset: 0x0115D528
		[NullableContext(1)]
		private void OnBubble(ITuningStandBubbleData data)
		{
			if (this.BubbleTimer != null)
			{
				if (TimerSystem.GameplayTimeInstance.Has(this.BubbleTimer))
				{
					TimerSystem.GameplayTimeInstance.Remove(this.BubbleTimer);
				}
				this.BubbleTimer = null;
			}
			if (data.MainRoleTex != null)
			{
				base.SetTextureByPath(data.MainRoleTex, base.GetTexture(8), null, null);
			}
			if (data.FloroTex != null)
			{
				base.SetTextureByPath(data.FloroTex, base.GetTexture(4), null, null);
			}
			if (data.MainRoleTalk != null)
			{
				UUIText text = base.GetText(10);
				if (text == null || !text.IsUIActiveSelf())
				{
					UUIText text2 = base.GetText(10);
					if (text2 != null)
					{
						text2.SetUIActive(true);
					}
				}
				this.IsMainTalking = true;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), data.MainRoleTalk, Array.Empty<object>());
				this.PlayBubbleFadeIn(this.MainSequencer);
			}
			else if (this.IsMainTalking)
			{
				this.IsMainTalking = false;
				this.PlayBubbleFadeOut(this.MainSequencer);
			}
			if (data.FloroTalk != null)
			{
				UUIText text3 = base.GetText(6);
				if (text3 == null || !text3.IsUIActiveSelf())
				{
					UUIText text4 = base.GetText(6);
					if (text4 != null)
					{
						text4.SetUIActive(true);
					}
				}
				this.IsFloroTalking = true;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), data.FloroTalk, Array.Empty<object>());
				this.PlayBubbleFadeIn(this.FloroSequencer);
			}
			else if (this.IsFloroTalking)
			{
				this.IsFloroTalking = false;
				this.PlayBubbleFadeOut(this.FloroSequencer);
			}
			double num = (((double)data.WaitTime > 1.5) ? ((double)data.WaitTime - 0.5) : ((double)data.WaitTime)) * 1000.0;
			this.BubbleTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.OnBubbleDelayEnd();
			}, (float)((long)num), null, null, true, 1f);
		}

		// Token: 0x060436DB RID: 276187 RVA: 0x0115F510 File Offset: 0x0115D710
		private void OnClickedTips()
		{
			UUIItem item = base.GetItem(14);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(true);
		}

		// Token: 0x060436DC RID: 276188 RVA: 0x0115F525 File Offset: 0x0115D725
		private void OnCloseGuide()
		{
			UUIItem item = base.GetItem(14);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x060436DD RID: 276189 RVA: 0x0115F53A File Offset: 0x0115D73A
		[NullableContext(1)]
		private void OnStartEnd(string _)
		{
			if (this.IsTuning && !ModelBase<TuningStandModel>.Instance.TryStartBubbleFlow(ETuningStandBubbleTriggerType.Enter))
			{
				this.OnEnterBubbleEnd();
			}
			TimerSystem.Instance.Next(delegate(float __)
			{
				this.SetFocusOnStart();
			}, null, null);
		}

		// Token: 0x060436DE RID: 276190 RVA: 0x0115F570 File Offset: 0x0115D770
		private void OnSuccessEnd()
		{
			this.UiViewSequence.CloseSequenceName = "Close2";
			this.OnClearClose();
		}

		// Token: 0x060436DF RID: 276191 RVA: 0x0115F588 File Offset: 0x0115D788
		[NullableContext(1)]
		private void OnAnimEvent(string param)
		{
			if (param == "In")
			{
				TuningStandLineItem musicItem = this.MusicItem;
				if (musicItem != null)
				{
					musicItem.OnStartAnim();
				}
				foreach (TuningStandGridItem tuningStandGridItem in this.GridLayout.GetLayoutItemList())
				{
					tuningStandGridItem.PlayShowAnim();
				}
			}
		}

		// Token: 0x060436E0 RID: 276192 RVA: 0x0115F5FC File Offset: 0x0115D7FC
		private void OnLinkMiss(bool isEnd)
		{
			foreach (TuningStandGridItem tuningStandGridItem in this.GridLayout.GetLayoutItemList())
			{
				tuningStandGridItem.OnLinkMiss(isEnd);
			}
		}

		// Token: 0x060436E1 RID: 276193 RVA: 0x0115F654 File Offset: 0x0115D854
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			if (!Singleton<Info>.Instance.IsInGamepad() || this.IsGameClear)
			{
				return;
			}
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.SetFocusOnStart();
			}, null, null);
		}

		// Token: 0x060436E2 RID: 276194 RVA: 0x0115F684 File Offset: 0x0115D884
		private void OnEnterBubbleEnd()
		{
			this.DoTooLongDelay();
		}

		// Token: 0x060436E3 RID: 276195 RVA: 0x0115F68C File Offset: 0x0115D88C
		private void DoTooLongDelay()
		{
			this.TooLongDelayCount++;
			if (this.TooLongDelayCount > 3)
			{
				ModelBase<TuningStandModel>.Instance.ProcessTooLong();
				return;
			}
			this.TooLongHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.DoTooLongDelay();
			}, 60000f, null, null, true, 1f);
		}

		// Token: 0x060436E4 RID: 276196 RVA: 0x0115F6E4 File Offset: 0x0115D8E4
		private void PlayBubbleFadeIn(LevelSequencePlayer player)
		{
			if (player == null)
			{
				return;
			}
			if (player.IsPlayingSequence("Off"))
			{
				player.StopSequenceByKey("Off", false, false);
			}
			if (player.IsPlayingSequence("On"))
			{
				player.ReplaySequenceByKey("On");
				return;
			}
			player.PlayLevelSequenceByName("On", false, null, false);
		}

		// Token: 0x060436E5 RID: 276197 RVA: 0x0115F740 File Offset: 0x0115D940
		private void PlayBubbleFadeOut(LevelSequencePlayer player)
		{
			if (player == null)
			{
				return;
			}
			if (player.IsPlayingSequence("On"))
			{
				player.StopSequenceByKey("On", false, false);
			}
			if (player.IsPlayingSequence("Off"))
			{
				player.ReplaySequenceByKey("Off");
				return;
			}
			player.PlayLevelSequenceByName("Off", false, null, false);
		}

		// Token: 0x060436E6 RID: 276198 RVA: 0x0115F79C File Offset: 0x0115D99C
		private void OnBubbleDelayEnd()
		{
			if (this.BubbleTimer != null)
			{
				if (TimerSystem.GameplayTimeInstance.Has(this.BubbleTimer))
				{
					TimerSystem.GameplayTimeInstance.Remove(this.BubbleTimer);
				}
				this.BubbleTimer = null;
			}
			if (this.IsMainTalking)
			{
				this.IsMainTalking = false;
				this.PlayBubbleFadeOut(this.MainSequencer);
			}
			if (this.IsFloroTalking)
			{
				this.IsFloroTalking = false;
				this.PlayBubbleFadeOut(this.FloroSequencer);
			}
		}

		// Token: 0x060436E7 RID: 276199 RVA: 0x0115F814 File Offset: 0x0115DA14
		[NullableContext(1)]
		protected TuningStandGridBase GetFirstStartItem()
		{
			List<TuningStandGridItem> layoutItemList = this.GridLayout.GetLayoutItemList();
			List<TuningGridData> gridList = ModelBase<TuningStandModel>.Instance.GetGridList();
			int index = 0;
			foreach (TuningGridData tuningGridData in gridList)
			{
				if (tuningGridData.GridMainType == EGridMainType.Start)
				{
					index = tuningGridData.Index;
					break;
				}
			}
			return layoutItemList[index].GetGrid();
		}

		// Token: 0x060436E8 RID: 276200 RVA: 0x0115F890 File Offset: 0x0115DA90
		protected void SetFocusOnStart()
		{
			TuningStandGridBase firstStartItem = this.GetFirstStartItem();
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(firstStartItem.GetRootItem(), true, false, false);
		}

		// Token: 0x060436E9 RID: 276201 RVA: 0x0115F8B8 File Offset: 0x0115DAB8
		protected void OnClearClose()
		{
			if (this.FinishCb != null)
			{
				this.FinishCb();
				this.FinishCb = null;
			}
			base.CloseMe(null);
		}

		// Token: 0x04025A6C RID: 154220
		protected TuningStandLineItem MusicItem;

		// Token: 0x04025A6D RID: 154221
		protected TuningStandLineItem MusicItemPlay;

		// Token: 0x04025A6E RID: 154222
		protected UiPanelBase GuideItem;

		// Token: 0x04025A6F RID: 154223
		protected PopupCaptionItem CaptionItem;

		// Token: 0x04025A70 RID: 154224
		protected ITuningStand Config;

		// Token: 0x04025A71 RID: 154225
		protected bool IsTuning;

		// Token: 0x04025A72 RID: 154226
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<TuningStandGridItem, TuningGridData> GridLayout;

		// Token: 0x04025A73 RID: 154227
		protected Action FinishCb;

		// Token: 0x04025A74 RID: 154228
		protected TimerHandle TooLongHandle;

		// Token: 0x04025A75 RID: 154229
		protected LevelSequencePlayer FloroSequencer;

		// Token: 0x04025A76 RID: 154230
		protected bool IsFloroTalking;

		// Token: 0x04025A77 RID: 154231
		protected LevelSequencePlayer MainSequencer;

		// Token: 0x04025A78 RID: 154232
		protected bool IsMainTalking;

		// Token: 0x04025A79 RID: 154233
		protected TimerHandle BubbleTimer;

		// Token: 0x04025A7A RID: 154234
		private int TooLongDelayCount;

		// Token: 0x04025A7B RID: 154235
		protected LevelSequencePlayer LightButtonLeft;

		// Token: 0x04025A7C RID: 154236
		protected LevelSequencePlayer LightButtonRight;

		// Token: 0x04025A7D RID: 154237
		private TuningStandNodeTween RedTweener;

		// Token: 0x04025A7E RID: 154238
		private TuningStandNodeTween BlueTweener;

		// Token: 0x04025A7F RID: 154239
		private bool HasTweenerEnd;

		// Token: 0x04025A80 RID: 154240
		private bool IsGameClear;

		// Token: 0x0200C9C6 RID: 51654
		[NullableContext(1)]
		[Nullable(0)]
		[RequiredMember]
		public class Params
		{
			// Token: 0x0604F3CC RID: 324556 RVA: 0x0161300A File Offset: 0x0161120A
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public Params()
			{
			}

			// Token: 0x0403E025 RID: 253989
			[RequiredMember]
			public ITuningStand Config;

			// Token: 0x0403E026 RID: 253990
			[RequiredMember]
			public Action Cb;
		}

		// Token: 0x0200C9C7 RID: 51655
		[NullableContext(0)]
		public enum ETuningDefine
		{
			// Token: 0x0403E028 RID: 253992
			PanelMainUI,
			// Token: 0x0403E029 RID: 253993
			Caption,
			// Token: 0x0403E02A RID: 253994
			DigitalMazeLineItem,
			// Token: 0x0403E02B RID: 253995
			PanelLeftDialogue,
			// Token: 0x0403E02C RID: 253996
			TexLeftRole,
			// Token: 0x0403E02D RID: 253997
			HeadTipsLeft,
			// Token: 0x0403E02E RID: 253998
			TxtLeftDialogue,
			// Token: 0x0403E02F RID: 253999
			PanelRightDialogue,
			// Token: 0x0403E030 RID: 254000
			TexRightRole,
			// Token: 0x0403E031 RID: 254001
			HeadTipsRight,
			// Token: 0x0403E032 RID: 254002
			TxtRightDialogue,
			// Token: 0x0403E033 RID: 254003
			PanelLatticeGridList,
			// Token: 0x0403E034 RID: 254004
			TxtBottomTips,
			// Token: 0x0403E035 RID: 254005
			BtnReset,
			// Token: 0x0403E036 RID: 254006
			PanelMaskGuide,
			// Token: 0x0403E037 RID: 254007
			PanelPlayUI,
			// Token: 0x0403E038 RID: 254008
			DigitalMazeLineStaffPlayItem,
			// Token: 0x0403E039 RID: 254009
			PanelMainLine,
			// Token: 0x0403E03A RID: 254010
			EmptyItem,
			// Token: 0x0403E03B RID: 254011
			OpMaskItem,
			// Token: 0x0403E03C RID: 254012
			BtnMaskGuide,
			// Token: 0x0403E03D RID: 254013
			PanelFlyFxRed,
			// Token: 0x0403E03E RID: 254014
			PanelFlyFxBlue
		}
	}
}
