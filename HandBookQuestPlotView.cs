using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E8C RID: 7820
[NullableContext(1)]
[Nullable(0)]
public class HandBookQuestPlotView : UiViewBase
{
	// Token: 0x0600E70B RID: 59147 RVA: 0x003E56DC File Offset: 0x003E38DC
	public HandBookQuestPlotView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E70C RID: 59148 RVA: 0x003E5748 File Offset: 0x003E3948
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIDynScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIDynScrollViewComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickLeftBtn)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickRightBtn))
		};
	}

	// Token: 0x0600E70D RID: 59149 RVA: 0x003E5864 File Offset: 0x003E3A64
	protected override UniTask OnBeforeStartAsync()
	{
		HandBookQuestPlotView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HandBookQuestPlotView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E70E RID: 59150 RVA: 0x003E58A8 File Offset: 0x003E3AA8
	protected override void OnStart()
	{
		this.TalkTagString = (ConfigMultiTextLang.GetLocalTextNew("ColonTag", null) ?? "");
		this.TalkTagString += " ";
		this.PopupCaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.PopupCaptionItem.SetCloseCallBack(new Action(this.OnBtnCloseClick));
		this.PopupCaptionItem.SetHelpBtnActive(false);
		HandBookQuestViewOpenParam handBookQuestViewOpenParam = this.OpenParam as HandBookQuestViewOpenParam;
		this.ConfigIdList = handBookQuestViewOpenParam.ConfigIdList;
		this.CurrentSelectIndex = handBookQuestViewOpenParam.Index;
		this.RefreshView();
	}

	// Token: 0x0600E70F RID: 59151 RVA: 0x003E5944 File Offset: 0x003E3B44
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhotoSelect, this.ConfigIdList[this.CurrentSelectIndex]);
		HandBookQuestPlotTalkAudioUtil.ClearCurPlayAudio();
	}

	// Token: 0x0600E710 RID: 59152 RVA: 0x003E5968 File Offset: 0x003E3B68
	private void RefreshView()
	{
		int[] configIdList = this.ConfigIdList;
		int num = (configIdList != null) ? configIdList.Length : 0;
		if (this.CurrentSelectIndex >= num || this.CurrentSelectIndex < 0)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.HandBook;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "HandBookPlot_剧情图鉴选择任务出错";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index:", this.CurrentSelectIndex);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		UUIButtonComponent button = base.GetButton(5);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(this.CurrentSelectIndex > 0);
		}
		UUIButtonComponent button2 = base.GetButton(6);
		if (button2 != null)
		{
			button2.RootUIComp.Get().SetUIActive(this.CurrentSelectIndex + 1 < num);
		}
		int id = this.ConfigIdList[this.CurrentSelectIndex];
		PhotographHandBook? plotHandBookConfig = ConfigBase<HandBookConfig>.Instance.GetPlotHandBookConfig(id);
		if (plotHandBookConfig == null)
		{
			return;
		}
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo((EHandBookTabType)plotHandBookConfig.Value.Type, id);
		if (handBookInfo == null || !handBookInfo.IsRead)
		{
			int type = plotHandBookConfig.Value.Type;
			PlotType? plotType;
			int? num2 = (ConfigBase<HandBookConfig>.Instance.GetPlotTypeConfig(type) != null) ? new int?(plotType.GetValueOrDefault().Type) : null;
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest((EHandBookTabType)num2.Value, id);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), plotHandBookConfig.Value.Descrtption, Array.Empty<object>());
		IQuest questConfig = ModelBase<QuestNewModel>.Instance.GetQuestConfig(plotHandBookConfig.Value.QuestId);
		string title = (!string.IsNullOrEmpty((questConfig != null) ? questConfig.TidName : null)) ? Singleton<PublicUtil>.Instance.GetConfigTextByKey(questConfig.TidName) : "";
		this.PopupCaptionItem.SetTitle(title);
		PlotType? plotTypeConfig = ConfigBase<HandBookConfig>.Instance.GetPlotTypeConfig(plotHandBookConfig.Value.Type);
		HandBookQuestTab? questTab = ConfigBase<HandBookConfig>.Instance.GetQuestTab(plotTypeConfig.Value.Type);
		this.PopupCaptionItem.SetTitleIcon(questTab.Value.Icon);
		List<IPlotHandBookNode> list = new List<IPlotHandBookNode>();
		foreach (int num3 in plotHandBookConfig.Value.ShowQuestList())
		{
			PlotHandBookConfig? questPlotConfig = ConfigBase<HandBookConfig>.Instance.GetQuestPlotConfig(num3);
			if (questPlotConfig == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.HandBook;
				ELogAuthor author2 = ELogAuthor.LJQ;
				string message2 = "HandBookPlot_剧情图鉴获取任务对应剧情配置出错";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("questId:", num3);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			List<IPlotHandBookNode> list2 = Json.Decode<List<IPlotHandBookNode>>(questPlotConfig.Value.Data, null);
			if (list2 != null)
			{
				list.AddRange(list2);
			}
		}
		this.NodeToTidMap.Clear();
		this.NodeTextList = new List<string>();
		string text = "";
		foreach (IPlotHandBookNode plotHandBookNode in list)
		{
			string text2 = plotHandBookNode.IsHideUi ? "" : plotHandBookNode.TidTip;
			List<IPlotHandBookNode> list6;
			if (text2 == "")
			{
				if (text == "")
				{
					string text3 = ((questConfig != null) ? questConfig.TidName : null) ?? "";
					List<IPlotHandBookNode> list3;
					if (!this.NodeToTidMap.TryGetValue(text3, out list3))
					{
						list3 = new List<IPlotHandBookNode>();
						list3.Add(plotHandBookNode);
						text = text3;
						this.NodeToTidMap[text3] = list3;
						continue;
					}
				}
				List<IPlotHandBookNode> list4;
				if (this.NodeToTidMap.TryGetValue(text, out list4))
				{
					list4.Add(plotHandBookNode);
				}
			}
			else if (text != "" && text2 != "" && Singleton<PublicUtil>.Instance.GetConfigTextByKey(text) == Singleton<PublicUtil>.Instance.GetConfigTextByKey(text2))
			{
				List<IPlotHandBookNode> list5;
				if (this.NodeToTidMap.TryGetValue(text, out list5))
				{
					list5.Add(plotHandBookNode);
				}
			}
			else if (!this.NodeToTidMap.TryGetValue(text2, out list6))
			{
				list6 = new List<IPlotHandBookNode>();
				list6.Add(plotHandBookNode);
				text = text2;
				this.NodeToTidMap[text2] = list6;
			}
			else
			{
				list6.Add(plotHandBookNode);
			}
		}
		List<HandBookQuestDynamicData> list7 = new List<HandBookQuestDynamicData>();
		foreach (string text4 in this.NodeToTidMap.Keys)
		{
			list7.Add(new HandBookQuestDynamicData
			{
				TidText = text4
			});
			this.NodeTextList.Add(text4);
		}
		this.NodeScrollView.RefreshByData(list7.ToArray(), false, false);
		string tidText = list7[0].TidText;
		this.RefreshByTidText(false, tidText);
	}

	// Token: 0x0600E711 RID: 59153 RVA: 0x003E5E90 File Offset: 0x003E4090
	private HandBookQuestPlotItem CreateNodeGrid(HandBookQuestDynamicData data, UUIItem uiItem, int index)
	{
		HandBookQuestPlotItem handBookQuestPlotItem = new HandBookQuestPlotItem();
		handBookQuestPlotItem.BindClickCallback(new TSelectedCallback(this.OnClickNodeItem));
		handBookQuestPlotItem.BindIsSelectFunction(new TSelectFunction(this.IsNodeSelect));
		return handBookQuestPlotItem;
	}

	// Token: 0x0600E712 RID: 59154 RVA: 0x003E5EBB File Offset: 0x003E40BB
	private HandBookQuestPlotList CreatePlotGrid(HandBookPlotDynamicData data, UUIItem uiItem, int index)
	{
		HandBookQuestPlotList handBookQuestPlotList = new HandBookQuestPlotList();
		handBookQuestPlotList.BindClickOptionToggleBack(new TSelectedOpenCallback(this.OnClickOption));
		handBookQuestPlotList.BindOnRefreshNode(new TRefreshNode(this.OnNodeSelectRefresh));
		return handBookQuestPlotList;
	}

	// Token: 0x0600E713 RID: 59155 RVA: 0x003E5EE6 File Offset: 0x003E40E6
	private void OnBtnCloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600E714 RID: 59156 RVA: 0x003E5EF0 File Offset: 0x003E40F0
	private void OnClickNodeItem(string tidText, [Nullable(2)] UUIExtendToggle toggle = null)
	{
		if (this.IsClickNodeItemWaitScroll)
		{
			return;
		}
		int index = 0;
		int count = this.HandBookPlotDynamicDataList.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.HandBookPlotDynamicDataList[i].NodeText == tidText)
			{
				index = i;
			}
		}
		this.OnNodeSelectRefresh(tidText);
		this.IsClickNodeItemWaitScroll = true;
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			DynamicScrollView<HandBookQuestPlotList, HandBootPlotDynamicItem, HandBookPlotDynamicData> plotListScrollView = this.PlotListScrollView;
			if (plotListScrollView != null)
			{
				plotListScrollView.ScrollToItemIndexByOffset(index);
			}
		}
		else
		{
			DynamicScrollView<HandBookQuestPlotList, HandBootPlotDynamicItem, HandBookPlotDynamicData> plotListScrollView2 = this.PlotListScrollView;
			if (plotListScrollView2 != null)
			{
				plotListScrollView2.ScrollToItemIndex(index, true, false);
			}
		}
		DynamicScrollView<HandBookQuestPlotList, HandBootPlotDynamicItem, HandBookPlotDynamicData> plotListScrollView3 = this.PlotListScrollView;
		if (plotListScrollView3 == null)
		{
			return;
		}
		plotListScrollView3.BindLateUpdate(delegate(float deltaTime)
		{
			this.IsClickNodeItemWaitScroll = false;
			DynamicScrollView<HandBookQuestPlotList, HandBootPlotDynamicItem, HandBookPlotDynamicData> plotListScrollView4 = this.PlotListScrollView;
			if (plotListScrollView4 == null)
			{
				return;
			}
			plotListScrollView4.UnBindLateUpdate();
		});
	}

	// Token: 0x0600E715 RID: 59157 RVA: 0x003E5F9C File Offset: 0x003E419C
	[NullableContext(2)]
	private void RefreshByTidText(bool keepPosition = true, string tidText = null)
	{
		this.HandBookPlotDynamicDataList = new List<HandBookPlotDynamicData>();
		this.HandlePlotList();
		DynamicScrollView<HandBookQuestPlotList, HandBootPlotDynamicItem, HandBookPlotDynamicData> plotListScrollView = this.PlotListScrollView;
		if (plotListScrollView != null)
		{
			plotListScrollView.RefreshByData(this.HandBookPlotDynamicDataList.ToArray(), keepPosition, false);
		}
		this.IsRefreshingView = true;
		DynamicScrollView<HandBookQuestPlotList, HandBootPlotDynamicItem, HandBookPlotDynamicData> plotListScrollView2 = this.PlotListScrollView;
		if (plotListScrollView2 == null)
		{
			return;
		}
		plotListScrollView2.BindLateUpdate(delegate(float deltaTime)
		{
			this.IsRefreshingView = false;
			if (!string.IsNullOrEmpty(tidText))
			{
				this.OnNodeSelectRefresh(tidText);
			}
			this.LateUpdate();
		});
	}

	// Token: 0x0600E716 RID: 59158 RVA: 0x003E6010 File Offset: 0x003E4210
	private void HandlePlotList()
	{
		int num = 0;
		foreach (KeyValuePair<string, List<IPlotHandBookNode>> keyValuePair in this.NodeToTidMap)
		{
			string key = keyValuePair.Key;
			List<IPlotHandBookNode> value = keyValuePair.Value;
			HandBookPlotDynamicData handBookPlotDynamicData = new HandBookPlotDynamicData();
			handBookPlotDynamicData.NodeText = key;
			handBookPlotDynamicData.BelongToNode = key;
			this.HandBookPlotDynamicDataList.Add(handBookPlotDynamicData);
			foreach (IPlotHandBookNode plotHandBookNode in value)
			{
				if (!string.IsNullOrEmpty(plotHandBookNode.Flow.FlowListName))
				{
					List<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(plotHandBookNode.Flow.FlowListName, plotHandBookNode.Flow.FlowId, plotHandBookNode.Flow.StateId);
					if (flowStateActions != null)
					{
						this.HandlePlotActions(flowStateActions, num++, key);
					}
				}
			}
		}
	}

	// Token: 0x0600E717 RID: 59159 RVA: 0x003E6124 File Offset: 0x003E4324
	private void HandlePlotActions(List<ActionInfo> plotActions, int flowIndex, string tidText)
	{
		this.JumpToTalkId = 0;
		foreach (ActionInfo actionInfo in plotActions)
		{
			if (actionInfo.Name != EAction.PlayMovie && actionInfo.Name == EAction.ShowTalk)
			{
				List<ITalkItem> talkItems = ((ShowTalk)actionInfo.Params).TalkItems;
				int num = 0;
				this.TalkItemMap.Clear();
				foreach (ITalkItem talkItem in talkItems)
				{
					this.TalkItemMap[talkItem.Id] = num++;
					if (this.JumpToTalkId < 0)
					{
						return;
					}
					if (this.JumpToTalkId != 0)
					{
						int? num2 = null;
						int value;
						if (this.TalkItemMap.TryGetValue(this.JumpToTalkId, out value))
						{
							num2 = new int?(value);
						}
						int num3 = this.TalkItemMap[talkItem.Id];
						if (num2 == null)
						{
							continue;
						}
						int? num4 = num2;
						int num5 = num3;
						if (num4.GetValueOrDefault() > num5 & num4 != null)
						{
							continue;
						}
					}
					if (talkItem.Type.GetValueOrDefault() != ETalkItemType.QTE)
					{
						if (talkItem.Type.GetValueOrDefault() == ETalkItemType.NoTextItem)
						{
							if (talkItem.Actions != null && this.HandleChildAction(talkItem.Actions, talkItem.Id))
							{
								return;
							}
						}
						else
						{
							this.JumpToTalkId = 0;
							if (talkItem.WhoId == null)
							{
								goto IL_186;
							}
							int? num4 = talkItem.WhoId;
							int num5 = 0;
							if (num4.GetValueOrDefault() == num5 & num4 != null)
							{
								goto IL_186;
							}
							goto IL_197;
							IL_2DC:
							if (talkItem.Options != null && talkItem.Options.Count > 0)
							{
								int num6 = 0;
								Dictionary<int, int> dictionary;
								int num7;
								if (this.OptionChose.TryGetValue(flowIndex, out dictionary) && dictionary.TryGetValue(talkItem.Id, out num7))
								{
									num6 = num7;
								}
								ITalkOption talkOption = talkItem.Options[num6];
								this.HandleChildAction(talkOption.Actions, talkItem.Id);
								this.HandleOptions(talkItem.Options, num6, tidText, flowIndex, talkItem.Id);
							}
							if (talkItem.Actions != null && this.HandleChildAction(talkItem.Actions, talkItem.Id))
							{
								return;
							}
							continue;
							IL_197:
							if (talkItem.Type.GetValueOrDefault() != ETalkItemType.Option)
							{
								HandBookPlotDynamicData handBookPlotDynamicData = new HandBookPlotDynamicData();
								handBookPlotDynamicData.BelongToNode = tidText;
								Speaker? speaker = (talkItem.WhoId != null) ? ConfigSpeakerById.GetConfig(talkItem.WhoId.Value, true) : null;
								string text = "";
								if (speaker != null)
								{
									text = (Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerName, new int?(speaker.Value.Id)) ?? "");
								}
								if (text != " " && text != "")
								{
									text += this.TalkTagString;
								}
								handBookPlotDynamicData.TalkOwnerName = text;
								if (talkItem.PlayVoice != null && talkItem.PlayVoice.Value)
								{
									PlotAudio? config = ConfigPlotAudioById.GetConfig(talkItem.TidTalk, true);
									handBookPlotDynamicData.PlotAudio = config;
								}
								string flowConfigLocalText = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(talkItem.TidTalk);
								handBookPlotDynamicData.TalkText = flowConfigLocalText;
								handBookPlotDynamicData.PlotId = flowIndex;
								handBookPlotDynamicData.TalkItemId = talkItem.Id;
								this.HandBookPlotDynamicDataList.Add(handBookPlotDynamicData);
								goto IL_2DC;
							}
							goto IL_2DC;
							IL_186:
							if (!string.IsNullOrEmpty(talkItem.TidTalk))
							{
								goto IL_197;
							}
							goto IL_2DC;
						}
					}
				}
			}
		}
	}

	// Token: 0x0600E718 RID: 59160 RVA: 0x003E6518 File Offset: 0x003E4718
	private bool HandleChildAction([Nullable(new byte[]
	{
		2,
		1
	})] List<ActionInfo> actions, int talkItemId)
	{
		if (actions == null)
		{
			return false;
		}
		foreach (ActionInfo actionInfo in actions)
		{
			if (actionInfo.Name == EAction.FinishTalk || actionInfo.Name == EAction.FinishState)
			{
				return true;
			}
			if (actionInfo.Name == EAction.JumpTalk)
			{
				int talkId = ((JumpTalk)actionInfo.Params).TalkId;
				int? num = null;
				int value;
				if (this.TalkItemMap.TryGetValue(talkId, out value))
				{
					num = new int?(value);
				}
				int num2 = this.TalkItemMap[talkItemId];
				if (num != null && num.Value <= num2)
				{
					this.JumpToTalkId = -1;
					break;
				}
				this.JumpToTalkId = talkId;
			}
		}
		return false;
	}

	// Token: 0x0600E719 RID: 59161 RVA: 0x003E65F8 File Offset: 0x003E47F8
	private void HandleOptions(List<ITalkOption> options, int choseIndex, string tidText, int flowIndex, int talkItemId)
	{
		HandBookPlotDynamicData handBookPlotDynamicData = new HandBookPlotDynamicData();
		handBookPlotDynamicData.BelongToNode = tidText;
		handBookPlotDynamicData.OptionTalker = new bool?(true);
		this.HandBookPlotDynamicDataList.Add(handBookPlotDynamicData);
		for (int i = 0; i < options.Count; i++)
		{
			ITalkOption talkOption = options[i];
			HandBookPlotDynamicData handBookPlotDynamicData2 = new HandBookPlotDynamicData();
			handBookPlotDynamicData2.BelongToNode = tidText;
			handBookPlotDynamicData2.OptionIndex = new int?(i);
			handBookPlotDynamicData2.TalkOption = talkOption;
			handBookPlotDynamicData2.IsChoseOption = new bool?(choseIndex == i);
			handBookPlotDynamicData2.PlotId = flowIndex;
			handBookPlotDynamicData2.TalkItemId = talkItemId;
			this.HandBookPlotDynamicDataList.Add(handBookPlotDynamicData2);
		}
	}

	// Token: 0x0600E71A RID: 59162 RVA: 0x003E6690 File Offset: 0x003E4890
	private void LateUpdate()
	{
		if (this.NavigationFocusData.Count > 0)
		{
			DynamicScrollView<HandBookQuestPlotList, HandBootPlotDynamicItem, HandBookPlotDynamicData> plotListScrollView = this.PlotListScrollView;
			HandBookQuestPlotList[] array = (plotListScrollView != null) ? plotListScrollView.GetScrollItemItems() : null;
			if (array != null)
			{
				HandBookQuestPlotList[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					HandBookQuestPlotList data = array2[i];
					HandBookPlotDynamicData optionData = data.OptionData;
					if (((optionData != null) ? optionData.TalkOption : null) != null)
					{
						HandBookPlotDynamicData optionData2 = data.OptionData;
						int? num = (optionData2 != null) ? new int?(optionData2.PlotId) : null;
						int num2 = this.NavigationFocusData[0];
						if (num.GetValueOrDefault() == num2 & num != null)
						{
							HandBookPlotDynamicData optionData3 = data.OptionData;
							num = ((optionData3 != null) ? new int?(optionData3.TalkItemId) : null);
							num2 = this.NavigationFocusData[1];
							if (num.GetValueOrDefault() == num2 & num != null)
							{
								HandBookPlotDynamicData optionData4 = data.OptionData;
								num = ((optionData4 != null) ? optionData4.OptionIndex : null);
								num2 = this.NavigationFocusData[2];
								if (num.GetValueOrDefault() == num2 & num != null)
								{
									TimerSystem.Instance.Next(delegate(float _)
									{
										ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(data.GetOptionToggle().GetRootComponent(), false, false, false);
									}, null, null);
									this.NavigationFocusData = new List<int>();
									return;
								}
							}
						}
					}
				}
				return;
			}
		}
		else
		{
			DynamicScrollView<HandBookQuestPlotList, HandBootPlotDynamicItem, HandBookPlotDynamicData> plotListScrollView2 = this.PlotListScrollView;
			if (plotListScrollView2 == null)
			{
				return;
			}
			plotListScrollView2.UnBindLateUpdate();
		}
	}

	// Token: 0x0600E71B RID: 59163 RVA: 0x003E681C File Offset: 0x003E4A1C
	private void OnClickOption(int plotId, int talkItemId, int optionIndex, UUIExtendToggle toggle)
	{
		Dictionary<int, int> dictionary;
		if (!this.OptionChose.TryGetValue(plotId, out dictionary))
		{
			dictionary = new Dictionary<int, int>();
			dictionary[talkItemId] = optionIndex;
		}
		else
		{
			dictionary[talkItemId] = optionIndex;
		}
		this.OptionChose[plotId] = dictionary;
		this.NavigationFocusData = new List<int>
		{
			plotId,
			talkItemId,
			optionIndex
		};
		DynamicScrollView<HandBookQuestPlotList, HandBootPlotDynamicItem, HandBookPlotDynamicData> plotListScrollView = this.PlotListScrollView;
		this.NeedScrollIndex = ((plotListScrollView != null) ? plotListScrollView.GetDisplayGridStartIndex() : 0);
		this.RefreshByTidText(true, null);
		HandBookQuestPlotTalkAudioUtil.ClearCurPlayAudio();
	}

	// Token: 0x0600E71C RID: 59164 RVA: 0x003E68A3 File Offset: 0x003E4AA3
	private void OnClickLeftBtn()
	{
		HandBookQuestPlotTalkAudioUtil.ClearCurPlayAudio();
		this.CurrentSelectIndex--;
		this.OptionChose.Clear();
		this.RefreshView();
	}

	// Token: 0x0600E71D RID: 59165 RVA: 0x003E68C9 File Offset: 0x003E4AC9
	private void OnClickRightBtn()
	{
		HandBookQuestPlotTalkAudioUtil.ClearCurPlayAudio();
		this.CurrentSelectIndex++;
		this.OptionChose.Clear();
		this.RefreshView();
	}

	// Token: 0x0600E71E RID: 59166 RVA: 0x003E68F0 File Offset: 0x003E4AF0
	private void OnNodeSelectRefresh(string tidText)
	{
		if (this.IsClickNodeItemWaitScroll)
		{
			return;
		}
		if (this.SelectNodeText == tidText || this.IsRefreshingView)
		{
			return;
		}
		this.SelectNodeText = tidText;
		HandBookQuestPlotItem[] scrollItemItems = this.NodeScrollView.GetScrollItemItems();
		bool flag = false;
		foreach (HandBookQuestPlotItem handBookQuestPlotItem in scrollItemItems)
		{
			if (((handBookQuestPlotItem != null) ? handBookQuestPlotItem.GetTidText() : null) == tidText)
			{
				handBookQuestPlotItem.SetToggleState(EToggleState.ETT_Checked);
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForViewSameGroup(handBookQuestPlotItem.GetToggleItem().GetRootComponent());
				flag = true;
			}
			else
			{
				handBookQuestPlotItem.SetToggleState(EToggleState.ETT_UnChecked);
			}
		}
		if (flag)
		{
			return;
		}
		int num = 0;
		using (Dictionary<string, List<IPlotHandBookNode>>.KeyCollection.Enumerator enumerator = this.NodeToTidMap.Keys.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == tidText)
				{
					break;
				}
				num++;
			}
		}
		DynamicScrollView<HandBookQuestPlotItem, HandBootQuestDynamicItem, HandBookQuestDynamicData> nodeScrollView = this.NodeScrollView;
		if (nodeScrollView == null)
		{
			return;
		}
		nodeScrollView.ScrollToItemIndex(num, true, false).ContinueWith(delegate()
		{
			DynamicScrollView<HandBookQuestPlotItem, HandBootQuestDynamicItem, HandBookQuestDynamicData> nodeScrollView2 = this.NodeScrollView;
			if (nodeScrollView2 == null)
			{
				return;
			}
			HandBookQuestPlotItem scrollItemFromIndex = nodeScrollView2.GetScrollItemFromIndex(0);
			if (scrollItemFromIndex == null)
			{
				return;
			}
			scrollItemFromIndex.SetToggleState(EToggleState.ETT_Checked);
		});
	}

	// Token: 0x0600E71F RID: 59167 RVA: 0x003E6A04 File Offset: 0x003E4C04
	private bool IsNodeSelect(string tidText)
	{
		return this.SelectNodeText == tidText;
	}

	// Token: 0x04006F73 RID: 28531
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	protected DynamicScrollView<HandBookQuestPlotItem, HandBootQuestDynamicItem, HandBookQuestDynamicData> NodeScrollView;

	// Token: 0x04006F74 RID: 28532
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	protected DynamicScrollView<HandBookQuestPlotList, HandBootPlotDynamicItem, HandBookPlotDynamicData> PlotListScrollView;

	// Token: 0x04006F75 RID: 28533
	[Nullable(2)]
	private PopupCaptionItem PopupCaptionItem;

	// Token: 0x04006F76 RID: 28534
	[Nullable(2)]
	private HandBootQuestDynamicItem HandBookQuestBaseItem;

	// Token: 0x04006F77 RID: 28535
	[Nullable(2)]
	private HandBootPlotDynamicItem HandBookPlotBaseItem;

	// Token: 0x04006F78 RID: 28536
	private List<HandBookPlotDynamicData> HandBookPlotDynamicDataList = new List<HandBookPlotDynamicData>();

	// Token: 0x04006F79 RID: 28537
	private readonly Dictionary<int, Dictionary<int, int>> OptionChose = new Dictionary<int, Dictionary<int, int>>();

	// Token: 0x04006F7A RID: 28538
	[Nullable(2)]
	private int[] ConfigIdList;

	// Token: 0x04006F7B RID: 28539
	private int CurrentSelectIndex;

	// Token: 0x04006F7C RID: 28540
	public int NeedScrollIndex;

	// Token: 0x04006F7D RID: 28541
	private int JumpToTalkId;

	// Token: 0x04006F7E RID: 28542
	private bool IsClickNodeItemWaitScroll;

	// Token: 0x04006F7F RID: 28543
	private string SelectNodeText = "";

	// Token: 0x04006F80 RID: 28544
	private bool IsRefreshingView;

	// Token: 0x04006F81 RID: 28545
	private string TalkTagString = "";

	// Token: 0x04006F82 RID: 28546
	private readonly Dictionary<string, List<IPlotHandBookNode>> NodeToTidMap = new Dictionary<string, List<IPlotHandBookNode>>();

	// Token: 0x04006F83 RID: 28547
	private List<string> NodeTextList = new List<string>();

	// Token: 0x04006F84 RID: 28548
	private readonly Dictionary<int, int> TalkItemMap = new Dictionary<int, int>();

	// Token: 0x04006F85 RID: 28549
	private List<int> NavigationFocusData = new List<int>();

	// Token: 0x020081C9 RID: 33225
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402C09A RID: 180378
		public const int TitleItem = 0;

		// Token: 0x0402C09B RID: 180379
		public const int NodeScrollView = 1;

		// Token: 0x0402C09C RID: 180380
		public const int ScrollViewItem = 2;

		// Token: 0x0402C09D RID: 180381
		public const int PlotContent = 3;

		// Token: 0x0402C09E RID: 180382
		public const int PlotItem = 4;

		// Token: 0x0402C09F RID: 180383
		public const int LeftBtn = 5;

		// Token: 0x0402C0A0 RID: 180384
		public const int RightBtn = 6;

		// Token: 0x0402C0A1 RID: 180385
		public const int PlotNameText = 7;

		// Token: 0x0402C0A2 RID: 180386
		public const int PlotScrollView = 8;
	}
}
