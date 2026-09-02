using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.QuestMultiLine;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002663 RID: 9827
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestUtil : Singleton<QuestUtil>
{
	// Token: 0x060135AD RID: 79277 RVA: 0x0056292C File Offset: 0x00560B2C
	public bool SetTrackDistanceText([Nullable(2)] UUIText uiText, global::Vector inLocation)
	{
		if (uiText == null || !ObjectUtils.IsValid(uiText))
		{
			return false;
		}
		if (inLocation == null)
		{
			return false;
		}
		global::Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
		if (playerLocation == null)
		{
			return false;
		}
		double a = global::Vector.Dist(inLocation, playerLocation) * 0.009999999776482582;
		a = Math.Round(a);
		double num = inLocation.Z - playerLocation.Z;
		string item = a.ToString();
		Singleton<LguiUtil>.Instance.SetLocalText(uiText, "Meter", new <>z__ReadOnlySingleElementList<object>(item));
		string text = uiText.GetText();
		if (num > 300.0)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_YellowArrowUp");
			text = text + "<texture=" + resourcePath + "/>";
		}
		else if (num < -300.0)
		{
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_YellowArrowDown");
			text = text + "<texture=" + resourcePath2 + "/>";
		}
		uiText.SetText(text, true);
		return true;
	}

	// Token: 0x060135AE RID: 79278 RVA: 0x00562A18 File Offset: 0x00560C18
	[NullableContext(2)]
	public bool SetTrackDistanceText(UUIText uiText, FVector inLocation)
	{
		if (uiText == null || !ObjectUtils.IsValid(uiText))
		{
			return false;
		}
		global::Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
		if (playerLocation == null)
		{
			return false;
		}
		FVector fvector = playerLocation.ToUeVectorOld();
		double a = (double)(FVector.Dist(inLocation, fvector) * 0.01f);
		a = Math.Round(a);
		double num = (double)inLocation.Z - playerLocation.Z;
		string item = a.ToString();
		Singleton<LguiUtil>.Instance.SetLocalText(uiText, "Meter", new <>z__ReadOnlySingleElementList<object>(item));
		string text = uiText.GetText();
		if (num > 300.0)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_YellowArrowUp");
			text = text + "<texture=" + resourcePath + "/>";
		}
		else if (num < -300.0)
		{
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_YellowArrowDown");
			text = text + "<texture=" + resourcePath2 + "/>";
		}
		uiText.SetText(text, true);
		return true;
	}

	// Token: 0x060135AF RID: 79279 RVA: 0x00562B08 File Offset: 0x00560D08
	public int? GetQuestMarkId(int questType, int? questId = null)
	{
		if (questId != null && questId.GetValueOrDefault() != 0)
		{
			TaskMark? taskMarkConfigByQuestId = ConfigBase<MapConfig>.Instance.GetTaskMarkConfigByQuestId(questId.Value);
			if (taskMarkConfigByQuestId != null)
			{
				return new int?(taskMarkConfigByQuestId.Value.MarkId);
			}
		}
		return ConfigBase<QuestNewConfig>.Instance.GetQuestTypeMarkId(questType);
	}

	// Token: 0x060135B0 RID: 79280 RVA: 0x00562B64 File Offset: 0x00560D64
	public string GetQuestMarkIconPathByQuestId(int questId)
	{
		IQuest questConfig = ModelBase<QuestNewModel>.Instance.GetQuestConfig(questId);
		QuestType? questTypeConfig = ConfigBase<QuestNewConfig>.Instance.GetQuestTypeConfig((int)((questConfig != null) ? questConfig.Type : ((EQuest)0)));
		if (questTypeConfig == null)
		{
			return "";
		}
		int valueOrDefault = this.GetQuestMarkId(questTypeConfig.Value.MainId, new int?(questId)).GetValueOrDefault();
		return ConfigBase<QuestNewConfig>.Instance.GetQuestTypeMark(valueOrDefault);
	}

	// Token: 0x060135B1 RID: 79281 RVA: 0x00562BD4 File Offset: 0x00560DD4
	[NullableContext(2)]
	public bool HandleTrackCustomBoard(ITrackCustomBoard trackCustomBoard, bool isFromHotKey = false)
	{
		if (trackCustomBoard == null)
		{
			return false;
		}
		if (isFromHotKey && !Singleton<InputManager>.Instance.IsAllowOpenViewByShortcutKey())
		{
			return false;
		}
		if (trackCustomBoard.TrackPhoneMessageBoard != null)
		{
			int valueOrDefault = trackCustomBoard.TrackPhoneMessageBoard.PhoneMessageId.GetValueOrDefault();
			ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(valueOrDefault);
			if (phoneMsgConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Quest;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "找不到对应的短信配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("短信ID", valueOrDefault);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (!ModelBase<PhoneMsgModel>.Instance.IsPhoneMsgUnlock(valueOrDefault))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Quest;
				ELogAuthor author2 = ELogAuthor.HYF;
				string message2 = "短信未解锁，无法追踪";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("短信ID", valueOrDefault);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhoneMsgPanelViewBig) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhoneMsgPanelViewSmall))
			{
				Singleton<Log>.Instance.Info(ELogModule.Quest, ELogAuthor.HYF, "手机短信界面已打开，无需重复打开", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}
			PhoneMsgPanelViewData param = new PhoneMsgPanelViewData
			{
				ShortMessage = phoneMsgConfig,
				NeedShowTips = false,
				NeedForceReadAllMsg = false,
				OpenWay = EPhoneMsgOpenWay.QuestTrack,
				ViewType = EPhoneMsgViewType.Big
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgPanelViewBig, param, null);
			return true;
		}
		else
		{
			ITrackQuestBranchBoardConfig trackQuestBranchBoard = trackCustomBoard.TrackQuestBranchBoard;
			if (trackQuestBranchBoard != null)
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.QuestMultiLineView))
				{
					Singleton<Log>.Instance.Info(ELogModule.QuestMultiLine, ELogAuthor.CCJ, "分线界面已打开，无需重复打开", default(ReadOnlySpan<ValueTuple<string, object>>));
					return true;
				}
				int id = trackQuestBranchBoard.Id;
				bool valueOrDefault2 = trackQuestBranchBoard.EnableAnimation.GetValueOrDefault();
				ControllerBase<QuestMultiLineController>.Instance.OpenQuestMultiLineView(id, valueOrDefault2, false).Forget<int?>();
				return true;
			}
			else
			{
				if (trackCustomBoard.SheriffAnomalyProgressBoard != null)
				{
					return this.HandleAnomalyProgressBoard(trackCustomBoard);
				}
				if (trackCustomBoard.SheriffReasoningBoard != null)
				{
					return this.HandleSheriffReasoningBoard(trackCustomBoard);
				}
				return trackCustomBoard.SheriffClueDetailBoard != null && this.HandleSheriffClueDetailBoard(trackCustomBoard);
			}
		}
	}

	// Token: 0x060135B2 RID: 79282 RVA: 0x00562DB8 File Offset: 0x00560FB8
	private bool HandleAnomalyProgressBoard(ITrackCustomBoard trackCustomBoard)
	{
		ISheriffAnomalyProgressBoardConfig sheriffAnomalyProgressBoard = trackCustomBoard.SheriffAnomalyProgressBoard;
		if (sheriffAnomalyProgressBoard == null)
		{
			return false;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SheriffReportPop))
		{
			Singleton<Log>.Instance.Info(ELogModule.Sheriff, ELogAuthor.SYB, "案情进展界面已打开，无需重复打开", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}
		int anomalyId = sheriffAnomalyProgressBoard.AnomalyId;
		SheriffAnomaly? anomalyConfigById = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(anomalyId);
		if (anomalyConfigById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Sheriff;
			ELogAuthor author = ELogAuthor.SYB;
			string message = "找不到对应的案情事件配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("事件Id", anomalyId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		int criminalId = anomalyConfigById.Value.CriminalId;
		ControllerBase<SheriffController>.Instance.OpenSheriffReportPop(criminalId, true);
		return true;
	}

	// Token: 0x060135B3 RID: 79283 RVA: 0x00562E74 File Offset: 0x00561074
	private bool HandleSheriffReasoningBoard(ITrackCustomBoard trackCustomBoard)
	{
		ISheriffReasoningBoardConfig sheriffReasoningBoard = trackCustomBoard.SheriffReasoningBoard;
		if (sheriffReasoningBoard == null)
		{
			return false;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SheriffMainView))
		{
			Singleton<Log>.Instance.Info(ELogModule.Sheriff, ELogAuthor.WHJ, "推理进展界面已打开，无需重复打开", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}
		int id = sheriffReasoningBoard.Id;
		ControllerBase<SheriffController>.Instance.OpenAnalysisClueView(id);
		return true;
	}

	// Token: 0x060135B4 RID: 79284 RVA: 0x00562ED4 File Offset: 0x005610D4
	private bool HandleSheriffClueDetailBoard(ITrackCustomBoard trackCustomBoard)
	{
		if (trackCustomBoard.SheriffClueDetailBoard == null)
		{
			return false;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SheriffShowClueViewPop))
		{
			Singleton<Log>.Instance.Info(ELogModule.Sheriff, ELogAuthor.WHJ, "推理线索界面已打开，无需重复打开", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}
		ControllerBase<SheriffController>.Instance.OpenDetailClueFromQuestPanel();
		return true;
	}
}
