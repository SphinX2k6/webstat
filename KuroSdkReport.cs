using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EEB RID: 3819
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class KuroSdkReport : Singleton<KuroSdkReport>
{
	// Token: 0x06005E5C RID: 24156 RVA: 0x00179C41 File Offset: 0x00177E41
	public void Init()
	{
		this.AddEvent();
	}

	// Token: 0x06005E5D RID: 24157 RVA: 0x00179C49 File Offset: 0x00177E49
	public void Report(SdkReportData data)
	{
		Singleton<HotPatchKuroSdk>.Instance.ReportEvent(data);
	}

	// Token: 0x06005E5E RID: 24158 RVA: 0x00179C58 File Offset: 0x00177E58
	private void AddEvent()
	{
		Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		Singleton<EventSystem>.Instance.Add<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus, ENodeStatusUpdateReason>(EEventName.OnLogicTreeChildQuestNodeStatusChange, new Action<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus, ENodeStatusUpdateReason>(this.OnChildQuestNodeStatusChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06005E5F RID: 24159 RVA: 0x00179CBC File Offset: 0x00177EBC
	public void OnPlayerLevelChange(int level)
	{
		if (SdkReportLevel.IfNeedReport(level))
		{
			SdkReportLevel data = new SdkReportLevel(null)
			{
				Level = level
			};
			this.Report(data);
		}
	}

	// Token: 0x06005E60 RID: 24160 RVA: 0x00179CE8 File Offset: 0x00177EE8
	public void OnPlotFinish(FlowContext context)
	{
		if (SdkReportStartFlow.IfNeedReport(context.FlowId, context.FlowStateId))
		{
			SdkReportStartFlow data = new SdkReportStartFlow(null)
			{
				FlowId = context.FlowId
			};
			this.Report(data);
		}
	}

	// Token: 0x06005E61 RID: 24161 RVA: 0x00179D24 File Offset: 0x00177F24
	public void OnSdkPay()
	{
		SdkReportPay data = new SdkReportPay(null);
		this.Report(data);
	}

	// Token: 0x06005E62 RID: 24162 RVA: 0x00179D40 File Offset: 0x00177F40
	public void OnPayShopDirectBuy(int shopItemId)
	{
		if (SdkReportDirectBuy.IfNeedReport(shopItemId))
		{
			SdkReportDirectBuy data = new SdkReportDirectBuy(null)
			{
				PayItemId = shopItemId
			};
			this.Report(data);
		}
	}

	// Token: 0x06005E63 RID: 24163 RVA: 0x00179D6A File Offset: 0x00177F6A
	public void OnChapterStart(int chapterId, int chapterState)
	{
	}

	// Token: 0x06005E64 RID: 24164 RVA: 0x00179D6C File Offset: 0x00177F6C
	private void OnPayItemSuccess(PayItemSuccess payItem)
	{
		if (SdkReportRecharge.IfNeedReport(payItem.PayItemId))
		{
			SdkReportRecharge data = new SdkReportRecharge(null)
			{
				PayItemId = payItem.PayItemId
			};
			this.Report(data);
		}
	}

	// Token: 0x06005E65 RID: 24165 RVA: 0x00179DA0 File Offset: 0x00177FA0
	private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason _)
	{
		if (SdkReportQuestFinish.IfNeedReport(questId))
		{
			SdkReportQuestFinish data = new SdkReportQuestFinish(null)
			{
				QuestId = questId
			};
			this.Report(data);
		}
		if (SdkReportChapter.IfNeedReport(questId, 0) && state == QuestState.Finish)
		{
			SdkReportChapter data2 = new SdkReportChapter(null)
			{
				TreeConfigId = questId
			};
			this.Report(data2);
		}
	}

	// Token: 0x06005E66 RID: 24166 RVA: 0x00179DEC File Offset: 0x00177FEC
	private void OnChildQuestNodeStatusChange(GeneralContext context, ChildQuestNodeStatus oldStatus, ChildQuestNodeStatus newStatus, ENodeStatusUpdateReason _)
	{
		if (context.Type.GetValueOrDefault() != EGeneralContextType.GeneralLogicTree)
		{
			return;
		}
		GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
		int? num = (generalLogicTreeContext != null) ? new int?(generalLogicTreeContext.TreeConfigId) : null;
		GeneralLogicTreeContext generalLogicTreeContext2 = context as GeneralLogicTreeContext;
		int? num2 = (generalLogicTreeContext2 != null) ? new int?(generalLogicTreeContext2.NodeId) : null;
		if (num == null || num2 == null)
		{
			return;
		}
		if (SdkReportBattleTech.IfNeedReport(num.Value, num2.Value) && newStatus == ChildQuestNodeStatus.CqnsFinished)
		{
			this.Report(new SdkReportBattleTech(null)
			{
				TreeConfigId = num.Value,
				NodeId = num2.Value
			});
		}
	}

	// Token: 0x06005E67 RID: 24167 RVA: 0x00179E9C File Offset: 0x0017809C
	public void OnGachaResult(int gachaId, Aki.Protocol.GachaResult[] message)
	{
		if (gachaId == 0)
		{
			return;
		}
		GachaPoolData gachaPoolData = Array.Find<GachaPoolData>(ModelBase<GachaModel>.Instance.GetValidGachaList(), (GachaPoolData value) => value.GachaInfo.Id == gachaId);
		if (gachaPoolData == null)
		{
			return;
		}
		if (ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(gachaPoolData.PoolInfo.Id) != null)
		{
			GachaViewInfo? gachaViewInfo;
			int type = gachaViewInfo.GetValueOrDefault().Type;
		}
		GachaDefine.EGachaViewType? egachaViewType = null;
		if (egachaViewType.GetValueOrDefault() != GachaDefine.EGachaViewType.RoleUp && egachaViewType.GetValueOrDefault() != GachaDefine.EGachaViewType.RoleCommon)
		{
			return;
		}
		Dictionary<string, int> dictionary = LocalStorage.GetPlayer<Dictionary<string, int>>(ELocalStoragePlayerKey.SdkReportStateMap, null);
		if (dictionary != null)
		{
			int num;
			if (egachaViewType.GetValueOrDefault() == GachaDefine.EGachaViewType.RoleUp && dictionary.TryGetValue("HIGHGACHAPOOLREPORTSTATEKEY", out num) && num == 1)
			{
				return;
			}
			int num2;
			if (egachaViewType.GetValueOrDefault() == GachaDefine.EGachaViewType.RoleCommon && dictionary.TryGetValue("NORMALGACHAPOOLREPORTSTATEKEY", out num2) && num2 == 1)
			{
				return;
			}
		}
		if (dictionary == null)
		{
			dictionary = new Dictionary<string, int>();
		}
		for (int i = 0; i < message.Length; i++)
		{
			GachaReward gachaReward = message[i].GachaReward;
			int? num3 = (gachaReward != null) ? new int?(gachaReward.ItemId) : null;
			RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(num3.Value);
			if (roleInfoById != null && roleInfoById.Value.QualityId >= 5)
			{
				if (egachaViewType.GetValueOrDefault() == GachaDefine.EGachaViewType.RoleUp)
				{
					SdkReportFirstUpFiveStarHero data = new SdkReportFirstUpFiveStarHero(null);
					this.Report(data);
					dictionary["HIGHGACHAPOOLREPORTSTATEKEY"] = 1;
					LocalStorage.SetPlayer<Dictionary<string, int>>(ELocalStoragePlayerKey.SdkReportStateMap, dictionary);
					return;
				}
				if (egachaViewType.GetValueOrDefault() == GachaDefine.EGachaViewType.RoleCommon)
				{
					SdkReportFirstNormalFiveStarHero data2 = new SdkReportFirstNormalFiveStarHero(null);
					this.Report(data2);
					dictionary["NORMALGACHAPOOLREPORTSTATEKEY"] = 1;
					LocalStorage.SetPlayer<Dictionary<string, int>>(ELocalStoragePlayerKey.SdkReportStateMap, dictionary);
					return;
				}
			}
		}
	}

	// Token: 0x06005E68 RID: 24168 RVA: 0x0017A060 File Offset: 0x00178260
	public void OnRougeFinish()
	{
		Dictionary<string, int> dictionary = LocalStorage.GetPlayer<Dictionary<string, int>>(ELocalStoragePlayerKey.SdkReportStateMap, null);
		int num;
		if (dictionary != null && dictionary.TryGetValue("ROUGEFINISHSTATEKEY", out num) && num == 1)
		{
			return;
		}
		if (dictionary == null)
		{
			dictionary = new Dictionary<string, int>();
		}
		SdkReportGetRougeLevel60 data = new SdkReportGetRougeLevel60(null);
		this.Report(data);
		dictionary["ROUGEFINISHSTATEKEY"] = 1;
		LocalStorage.SetPlayer<Dictionary<string, int>>(ELocalStoragePlayerKey.SdkReportStateMap, dictionary);
	}

	// Token: 0x04002DA2 RID: 11682
	private const int KILLPHANTOMMISSION = 139000025;

	// Token: 0x04002DA3 RID: 11683
	private const int CAPTUREPHANTOMMISSION = 139000026;

	// Token: 0x04002DA4 RID: 11684
	private const int CHAPTERCPRE1 = 139000025;

	// Token: 0x04002DA5 RID: 11685
	private const int CHAPTERCPRE2 = 139000026;

	// Token: 0x04002DA6 RID: 11686
	private const int CHAPTERC11 = 139000027;

	// Token: 0x04002DA7 RID: 11687
	private const int CHAPTERC12 = 139000029;

	// Token: 0x04002DA8 RID: 11688
	private const int CHAPTERC13 = 139000030;

	// Token: 0x04002DA9 RID: 11689
	private const int CHAPTERC14 = 139000031;

	// Token: 0x04002DAA RID: 11690
	private const int CHAPTERC15 = 114000020;

	// Token: 0x04002DAB RID: 11691
	private const int CHAPTERC16 = 140000004;

	// Token: 0x04002DAC RID: 11692
	private const int KILLPHANTOMSTEP1 = 6;

	// Token: 0x04002DAD RID: 11693
	private const int KILLPHANTOMSTEP2 = 10;

	// Token: 0x04002DAE RID: 11694
	private const int KILLPHANTOMSTEP3 = 91;

	// Token: 0x04002DAF RID: 11695
	private const int KILLPHANTOMSTEP4 = 132;

	// Token: 0x04002DB0 RID: 11696
	private const int GOJINZHOU = 16;

	// Token: 0x04002DB1 RID: 11697
	private const int STARTFLOW = 1;

	// Token: 0x04002DB2 RID: 11698
	private const int STARTSTATE = 1;

	// Token: 0x04002DB3 RID: 11699
	private const int RECHARGEONE = 1;

	// Token: 0x04002DB4 RID: 11700
	private const int RECHARGETWO = 2;

	// Token: 0x04002DB5 RID: 11701
	private const int RECHARGETHREE = 3;

	// Token: 0x04002DB6 RID: 11702
	private const int RECHARGEFOUR = 4;

	// Token: 0x04002DB7 RID: 11703
	private const int RECHARGEFIVE = 5;

	// Token: 0x04002DB8 RID: 11704
	private const int RECHARGESIX = 6;

	// Token: 0x04002DB9 RID: 11705
	private const int REPORTLEVEL8 = 8;

	// Token: 0x04002DBA RID: 11706
	private const int REPORTLEVEL10 = 10;

	// Token: 0x04002DBB RID: 11707
	private const int REPORTLEVEL12 = 12;

	// Token: 0x04002DBC RID: 11708
	private const int REPORTLEVEL15 = 15;

	// Token: 0x04002DBD RID: 11709
	private const int REPORTLEVEL20 = 20;

	// Token: 0x04002DBE RID: 11710
	private const int REPORTLEVEL25 = 25;

	// Token: 0x04002DBF RID: 11711
	private const int REPORTLEVEL30 = 30;

	// Token: 0x04002DC0 RID: 11712
	private const int REPORTLEVEL35 = 35;

	// Token: 0x04002DC1 RID: 11713
	private const int REPORTLEVEL40 = 40;

	// Token: 0x04002DC2 RID: 11714
	private const int REPORTLEVEL45 = 45;

	// Token: 0x04002DC3 RID: 11715
	private const string CREATEROLEEVENTID = "101104";

	// Token: 0x04002DC4 RID: 11716
	private const string BATTLEEVENTID = "101803";

	// Token: 0x04002DC5 RID: 11717
	private const string QUESTEVENTID = "101805";

	// Token: 0x04002DC6 RID: 11718
	private const string FLOWEVENTID = "123000";

	// Token: 0x04002DC7 RID: 11719
	private const string NORMALGACHAPOOLREPORTSTATEKEY = "NORMALGACHAPOOLREPORTSTATEKEY";

	// Token: 0x04002DC8 RID: 11720
	private const string HIGHGACHAPOOLREPORTSTATEKEY = "HIGHGACHAPOOLREPORTSTATEKEY";

	// Token: 0x04002DC9 RID: 11721
	private const string ROUGEFINISHSTATEKEY = "ROUGEFINISHSTATEKEY";
}
