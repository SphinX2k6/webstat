using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Panel;
using CSharpScript.Game.Module.Plot.Flow;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Dialog
{
	// Token: 0x0200561B RID: 22043
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDialog : IStaticVariableResetter
	{
		// Token: 0x060382DA RID: 230106 RVA: 0x00E39DDC File Offset: 0x00E37FDC
		public PhantomArenaBattleDialog()
		{
			this.InitSpeakerId();
			this.InitLogic();
		}

		// Token: 0x060382DB RID: 230107 RVA: 0x00E39E06 File Offset: 0x00E38006
		static PhantomArenaBattleDialog()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PhantomArenaBattleDialog.CreateStaticDefaultValue), new Action(PhantomArenaBattleDialog.ResetStaticDefaultValue));
		}

		// Token: 0x060382DC RID: 230108 RVA: 0x00E39E25 File Offset: 0x00E38025
		public static void CreateStaticDefaultValue()
		{
			PhantomArenaBattleDialog.typeMap = new Dictionary<EBvbPlayDialogType, int>
			{
				{
					EBvbPlayDialogType.DungeonBegin,
					1
				},
				{
					EBvbPlayDialogType.PlayerBattleWin,
					2
				},
				{
					EBvbPlayDialogType.PlayerWin,
					3
				},
				{
					EBvbPlayDialogType.PlayerLose,
					4
				},
				{
					EBvbPlayDialogType.NewTurnBegin,
					5
				}
			};
		}

		// Token: 0x060382DD RID: 230109 RVA: 0x00E39E59 File Offset: 0x00E38059
		public static void ResetStaticDefaultValue()
		{
			PhantomArenaBattleDialog.typeMap = null;
		}

		// Token: 0x060382DE RID: 230110 RVA: 0x00E39E64 File Offset: 0x00E38064
		protected void InitLogic()
		{
			CommonFlowTextLogicData<object> data = new CommonFlowTextLogicData<object>
			{
				GetTextComp = new Func<ITalkItem, UUIText>(this.GetDialogText),
				TextAnimStartDelegate = new Action<ITalkItem, object>(this.TextAnimStartDelegate),
				TextAnimFinishDelegate = new Action<ITalkItem, object>(this.TextAnimFinishDelegate),
				ClearDelegate = new Action(this.ClearDelegate)
			};
			this.Logic.InitData(data);
		}

		// Token: 0x060382DF RID: 230111 RVA: 0x00E39ECB File Offset: 0x00E380CB
		protected void InitSpeakerId()
		{
			this.OwnSpeakId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaOwnSpeakerId();
			this.OpponentSpeakId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaOpponentSpeakerId();
		}

		// Token: 0x060382E0 RID: 230112 RVA: 0x00E39EED File Offset: 0x00E380ED
		public void SetOpponentDialogItem(PhantomArenaDialogItem dialogItem)
		{
			this.OpponentDialogItem = dialogItem;
		}

		// Token: 0x060382E1 RID: 230113 RVA: 0x00E39EF6 File Offset: 0x00E380F6
		public void SetOwnDialogItem(PhantomArenaDialogItem dialogItem)
		{
			this.OwnDialogItem = dialogItem;
		}

		// Token: 0x060382E2 RID: 230114 RVA: 0x00E39F00 File Offset: 0x00E38100
		public unsafe void NotifyDialogType(EBvbPlayDialogType dialogType)
		{
			this.TalkData = new List<ITalkItem>();
			this.TalkIndex = 0;
			int challengeId = ModelBase<PhantomArenaBattleModel>.Instance.ChallengeId;
			int num;
			ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId).DialogMap().TryGetValue(PhantomArenaBattleDialog.typeMap[dialogType], out num);
			if (num == 0)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "找不到对应的对话配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ChallengeId", challengeId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DialogType", dialogType);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			PhantomBattleDialog phantomBattleDialog = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleDialog(num);
			List<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(phantomBattleDialog.PlotName, phantomBattleDialog.FlowId, phantomBattleDialog.StateId);
			if (flowStateActions == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.PhantomArena;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "找不到对应的剧本配置";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PlotName", phantomBattleDialog.PlotName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("FlowId", phantomBattleDialog.FlowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("StateId", phantomBattleDialog.StateId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return;
			}
			foreach (ActionInfo actionInfo in flowStateActions)
			{
				if (actionInfo.Name == EAction.ShowTalk)
				{
					ShowTalk showTalk = actionInfo.Params as ShowTalk;
					if (showTalk != null)
					{
						foreach (ITalkItem item in showTalk.TalkItems)
						{
							this.TalkData.Add(item);
						}
					}
				}
			}
			this.Logic.PlayFlowText(this.TalkData[this.TalkIndex], null);
		}

		// Token: 0x060382E3 RID: 230115 RVA: 0x00E3A138 File Offset: 0x00E38338
		public void Clear()
		{
			this.Logic.Clear();
		}

		// Token: 0x060382E4 RID: 230116 RVA: 0x00E3A148 File Offset: 0x00E38348
		private unsafe UUIText GetDialogText(ITalkItem talkData)
		{
			int? whoId = talkData.WhoId;
			int num = this.OwnSpeakId;
			if (whoId.GetValueOrDefault() == num & whoId != null)
			{
				PhantomArenaDialogItem ownDialogItem = this.OwnDialogItem;
				if (ownDialogItem == null)
				{
					return null;
				}
				return ownDialogItem.GetDialog();
			}
			else
			{
				whoId = talkData.WhoId;
				num = this.OpponentSpeakId;
				if (!(whoId.GetValueOrDefault() == num & whoId != null))
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.PhantomArena;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "说话人配置错误";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("编辑器配置ID", talkData.WhoId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("己方说话人ID", this.OwnSpeakId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("对方说话人ID", this.OpponentSpeakId);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					return null;
				}
				PhantomArenaDialogItem opponentDialogItem = this.OpponentDialogItem;
				if (opponentDialogItem == null)
				{
					return null;
				}
				return opponentDialogItem.GetDialog();
			}
		}

		// Token: 0x060382E5 RID: 230117 RVA: 0x00E3A24C File Offset: 0x00E3844C
		private void TextAnimStartDelegate(ITalkItem talkData, object _)
		{
			int? whoId = talkData.WhoId;
			int num = this.OwnSpeakId;
			if (!(whoId.GetValueOrDefault() == num & whoId != null))
			{
				whoId = talkData.WhoId;
				num = this.OpponentSpeakId;
				if (whoId.GetValueOrDefault() == num & whoId != null)
				{
					PhantomArenaDialogItem opponentDialogItem = this.OpponentDialogItem;
					if (opponentDialogItem == null)
					{
						return;
					}
					opponentDialogItem.SetDialogActive(true);
				}
				return;
			}
			PhantomArenaDialogItem ownDialogItem = this.OwnDialogItem;
			if (ownDialogItem == null)
			{
				return;
			}
			ownDialogItem.SetDialogActive(true);
		}

		// Token: 0x060382E6 RID: 230118 RVA: 0x00E3A2C0 File Offset: 0x00E384C0
		private void TextAnimFinishDelegate(ITalkItem talkData, object _)
		{
			int? whoId = talkData.WhoId;
			int num = this.OwnSpeakId;
			if (whoId.GetValueOrDefault() == num & whoId != null)
			{
				PhantomArenaDialogItem ownDialogItem = this.OwnDialogItem;
				if (ownDialogItem != null)
				{
					ownDialogItem.SetDialogActive(false);
				}
			}
			else
			{
				whoId = talkData.WhoId;
				num = this.OpponentSpeakId;
				if (whoId.GetValueOrDefault() == num & whoId != null)
				{
					PhantomArenaDialogItem opponentDialogItem = this.OpponentDialogItem;
					if (opponentDialogItem != null)
					{
						opponentDialogItem.SetDialogActive(false);
					}
				}
			}
			this.TalkIndex++;
			if (this.TalkIndex >= this.TalkData.Count)
			{
				return;
			}
			this.Logic.PlayFlowText(this.TalkData[this.TalkIndex], this.TalkIndex);
		}

		// Token: 0x060382E7 RID: 230119 RVA: 0x00E3A380 File Offset: 0x00E38580
		private void ClearDelegate()
		{
			PhantomArenaDialogItem ownDialogItem = this.OwnDialogItem;
			if (ownDialogItem != null)
			{
				ownDialogItem.SetActive(false);
			}
			PhantomArenaDialogItem opponentDialogItem = this.OpponentDialogItem;
			if (opponentDialogItem == null)
			{
				return;
			}
			opponentDialogItem.SetActive(false);
		}

		// Token: 0x04020171 RID: 131441
		private static Dictionary<EBvbPlayDialogType, int> typeMap;

		// Token: 0x04020172 RID: 131442
		protected PhantomArenaDialogItem OpponentDialogItem;

		// Token: 0x04020173 RID: 131443
		protected PhantomArenaDialogItem OwnDialogItem;

		// Token: 0x04020174 RID: 131444
		protected CommonFlowTextLogic<object> Logic = new CommonFlowTextLogic<object>();

		// Token: 0x04020175 RID: 131445
		protected List<ITalkItem> TalkData = new List<ITalkItem>();

		// Token: 0x04020176 RID: 131446
		protected int TalkIndex;

		// Token: 0x04020177 RID: 131447
		protected int OwnSpeakId;

		// Token: 0x04020178 RID: 131448
		protected int OpponentSpeakId;
	}
}
