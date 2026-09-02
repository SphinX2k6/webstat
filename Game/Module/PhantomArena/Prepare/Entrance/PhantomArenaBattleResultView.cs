using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054BE RID: 21694
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleResultView : UiViewBase
	{
		// Token: 0x06037419 RID: 226329 RVA: 0x00E0443E File Offset: 0x00E0263E
		public PhantomArenaBattleResultView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603741A RID: 226330 RVA: 0x00E04448 File Offset: 0x00E02648
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUISprite)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIText)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIText)),
				new ValueTuple<int, Type>(15, typeof(UUIText)),
				new ValueTuple<int, Type>(16, typeof(UUISprite)),
				new ValueTuple<int, Type>(17, typeof(UUISprite)),
				new ValueTuple<int, Type>(18, typeof(UUIText)),
				new ValueTuple<int, Type>(19, typeof(UUIItem)),
				new ValueTuple<int, Type>(20, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickClose))
			};
		}

		// Token: 0x0603741B RID: 226331 RVA: 0x00E04660 File Offset: 0x00E02860
		protected override void OnStart()
		{
			BattleResultViewOpenParam battleResultViewOpenParam = this.OpenParam as BattleResultViewOpenParam;
			this.Result = battleResultViewOpenParam.Result;
			if (this.Result.Reward == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.WDX, "结算页数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.CallbackOnClose = battleResultViewOpenParam.CallbackOnClose;
			this.ExpTweenComponent = new ExpTweenComponent(base.GetSprite(16), base.GetSprite(10), base.GetSprite(17), null, null);
		}

		// Token: 0x0603741C RID: 226332 RVA: 0x00E046E2 File Offset: 0x00E028E2
		protected override void OnBeforeShow()
		{
			UUIItem item = base.GetItem(19);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.RefreshAll();
		}

		// Token: 0x0603741D RID: 226333 RVA: 0x00E04700 File Offset: 0x00E02900
		protected override void OnAfterShow()
		{
			PhantomBattleBoardSettleNotify result = this.Result;
			string sequenceName = (result != null && result.IsWin) ? "Success" : "Fail";
			this.UiViewSequence.AddSequenceFinishEvent(sequenceName, new Action<string>(this.OnSequenceShowFinish), false);
			this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnEventSequence));
			this.UiViewSequence.PlaySequence(sequenceName, false, null);
		}

		// Token: 0x0603741E RID: 226334 RVA: 0x00E0477C File Offset: 0x00E0297C
		protected override void OnBeforeDestroy()
		{
			if (this.ExpTweenComponent != null)
			{
				this.ExpTweenComponent.Destroy();
			}
			this.RootActor.OnSequencePlayEvent.Unbind();
			PhantomBattleBoardSettleNotify result = this.Result;
			string sequenceName = (result != null && result.IsWin) ? "Success" : "Fail";
			this.UiViewSequence.RemoveSequenceFinishEvent(sequenceName, new Action<string>(this.OnSequenceShowFinish));
		}

		// Token: 0x0603741F RID: 226335 RVA: 0x00E047E5 File Offset: 0x00E029E5
		private void RefreshAll()
		{
			this.RefreshViewTitle();
			this.RefreshLevelTitle();
			this.RefreshPointsSkill();
		}

		// Token: 0x06037420 RID: 226336 RVA: 0x00E047FC File Offset: 0x00E029FC
		private void RefreshViewTitle()
		{
			PhantomBattleBoardSettleNotify result = this.Result;
			string textStringId = (result != null && result.IsWin) ? "GenericPromptTypes_3_GeneralText" : "GenericPromptTypes_4_GeneralText";
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), textStringId, Array.Empty<object>());
			bool flag = this.Result.IsWin && this.Result.SettleType != PhantomBattleBoardSettleType.CommonSettle && this.Result.SettleType != PhantomBattleBoardSettleType.Skip;
			UUIText text = base.GetText(20);
			if (text != null)
			{
				text.SetUIActive(flag);
			}
			if (!flag)
			{
				return;
			}
			PhantomBattleBoardSettleType settleType = this.Result.SettleType;
			string text2 = null;
			if (settleType == PhantomBattleBoardSettleType.CommonSettle)
			{
				text2 = "PhantomBattle_1145";
			}
			else if (settleType == PhantomBattleBoardSettleType.RoundSettle)
			{
				text2 = "PhantomBattle_1146";
			}
			else if (settleType == PhantomBattleBoardSettleType.LimitSettle)
			{
				text2 = "PhantomBattle_1147";
			}
			if (text2 != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), text2, Array.Empty<object>());
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "声骸bvb结算类型不存在对应的结算文本";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("settleType", (int)settleType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06037421 RID: 226337 RVA: 0x00E04904 File Offset: 0x00E02B04
		private void RefreshLevelTitle()
		{
			int beforeLv = this.Result.Reward.BeforeLv;
			int afterLv = this.Result.Reward.AfterLv;
			base.GetText(4).SetText(beforeLv.ToString(), true);
			base.GetText(5).SetText(afterLv.ToString(), true);
			base.GetItem(3).SetUIActive(beforeLv != afterLv);
			base.GetText(2).SetText(beforeLv.ToString(), true);
			int addExp = this.Result.Reward.AddExp;
			int totalExp = this.Result.Reward.TotalExp;
			string newText = StringUtils.Format("EXP+{0}", new string[]
			{
				addExp.ToString()
			});
			base.GetText(8).SetText(newText, true);
			base.GetText(8).SetUIActive(addExp > 0);
			PhantomBattleMasterLevel? masterLevelConfig = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelConfig(beforeLv, this.Result.ActId);
			int num = Math.Max(totalExp - addExp, 0) - masterLevelConfig.Value.ExpNeed;
			int expNext = masterLevelConfig.Value.ExpNext;
			base.GetSprite(16).SetFillAmount((float)num / (float)expNext);
			base.GetSprite(10).SetFillAmount(0f);
			base.GetSprite(17).SetFillAmount(0f);
			int masterTitleIdByLevel = ModelBase<PhantomArenaModel>.Instance.GetMasterTitleIdByLevel(beforeLv, this.Result.ActId);
			string name = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleMasterTitleById(masterTitleIdByLevel).Name;
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(7), name, Array.Empty<object>());
			int masterExpNextNeed = ModelBase<PhantomArenaModel>.Instance.GetMasterExpNextNeed(this.Result.ActId);
			string newText2 = StringUtils.Format("{0}/{1}", new string[]
			{
				totalExp.ToString(),
				masterExpNextNeed.ToString()
			});
			base.GetText(9).SetText(newText2, true);
		}

		// Token: 0x06037422 RID: 226338 RVA: 0x00E04AF4 File Offset: 0x00E02CF4
		private void RefreshPointsSkill()
		{
			int beforeLv = this.Result.Reward.BeforeLv;
			int afterLv = this.Result.Reward.AfterLv;
			int pointsItemId = ModelBase<PhantomArenaModel>.Instance.GetPointsItemId(this.Result.ActId);
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(pointsItemId, 0);
			int num = 0;
			foreach (PhantomBattleReward phantomBattleReward in this.Result.Reward.Reward)
			{
				if (phantomBattleReward.ItemId == pointsItemId)
				{
					num = phantomBattleReward.Count;
				}
			}
			int num2 = commonItemCount - num;
			string newText = (num >= 0) ? ("+" + num.ToString()) : num.ToString();
			base.GetText(14).SetText(num2.ToString(), true);
			base.GetText(18).SetText(newText, true);
			base.GetText(15).SetText(commonItemCount.ToString(), true);
			base.GetItem(13).SetUIActive(num != 0);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(12), "Text_ResultLevelSkillDesc_Text", new <>z__ReadOnlySingleElementList<object>(afterLv));
			base.GetItem(11).SetUIActive(beforeLv != afterLv);
		}

		// Token: 0x06037423 RID: 226339 RVA: 0x00E04C50 File Offset: 0x00E02E50
		private void PlayExpTween()
		{
			if (this.Result.Reward.AddExp <= 0)
			{
				return;
			}
			int beforeLv = this.Result.Reward.BeforeLv;
			int afterLv = this.Result.Reward.AfterLv;
			PhantomBattleMasterLevel? masterLevelConfig = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelConfig(afterLv, this.Result.ActId);
			float num = (float)(this.Result.Reward.TotalExp - masterLevelConfig.Value.ExpNeed) / (float)masterLevelConfig.Value.ExpNext;
			int num2 = afterLv - beforeLv + 1;
			if (num2 > 2)
			{
				num2 = 2;
			}
			if (num >= 1f)
			{
				num2 = 1;
			}
			this.ExpTweenComponent.PlayExpTween(num2, num, 0f, LTweenEase.InOutSine);
		}

		// Token: 0x06037424 RID: 226340 RVA: 0x00E04D0E File Offset: 0x00E02F0E
		private void OnSequenceShowFinish(string _)
		{
			this.PlayExpTween();
			this.PlayUnlockSequence();
			this.PlayTitleSequence();
		}

		// Token: 0x06037425 RID: 226341 RVA: 0x00E04D24 File Offset: 0x00E02F24
		private void PlayUnlockSequence()
		{
			int beforeLv = this.Result.Reward.BeforeLv;
			int afterLv = this.Result.Reward.AfterLv;
			if (beforeLv == afterLv)
			{
				return;
			}
			this.UiViewSequence.PlaySequence("Unlock", false, null);
		}

		// Token: 0x06037426 RID: 226342 RVA: 0x00E04D70 File Offset: 0x00E02F70
		private void PlayTitleSequence()
		{
			int beforeLv = this.Result.Reward.BeforeLv;
			int afterLv = this.Result.Reward.AfterLv;
			int masterTitleIdByLevel = ModelBase<PhantomArenaModel>.Instance.GetMasterTitleIdByLevel(beforeLv, this.Result.ActId);
			int masterTitleIdByLevel2 = ModelBase<PhantomArenaModel>.Instance.GetMasterTitleIdByLevel(afterLv, this.Result.ActId);
			if (masterTitleIdByLevel == masterTitleIdByLevel2)
			{
				return;
			}
			this.UiViewSequence.PlaySequence("NameChange", false, null);
		}

		// Token: 0x06037427 RID: 226343 RVA: 0x00E04DEC File Offset: 0x00E02FEC
		private void OnEventSequence(string sequenceName, string eventName)
		{
			int afterLv = this.Result.Reward.AfterLv;
			if (sequenceName == "Unlock".ToString() && eventName == "LevelChange")
			{
				base.GetText(2).SetText(afterLv.ToString(), true);
				return;
			}
			if (sequenceName == "NameChange".ToString() && eventName == "NameChange")
			{
				int masterTitleIdByLevel = ModelBase<PhantomArenaModel>.Instance.GetMasterTitleIdByLevel(afterLv, this.Result.ActId);
				string name = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleMasterTitleById(masterTitleIdByLevel).Name;
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(7), name, Array.Empty<object>());
			}
		}

		// Token: 0x06037428 RID: 226344 RVA: 0x00E04E9F File Offset: 0x00E0309F
		private void OnClickClose()
		{
			base.CloseMe(this.CallbackOnClose);
		}

		// Token: 0x0401FC3D RID: 130109
		[Nullable(2)]
		private ExpTweenComponent ExpTweenComponent;

		// Token: 0x0401FC3E RID: 130110
		[Nullable(2)]
		private PhantomBattleBoardSettleNotify Result;

		// Token: 0x0401FC3F RID: 130111
		[Nullable(2)]
		private Action<bool> CallbackOnClose;

		// Token: 0x0200B427 RID: 46119
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037BEA RID: 228330
			public const int TextViewTitle = 0;

			// Token: 0x04037BEB RID: 228331
			public const int BtnClose = 1;

			// Token: 0x04037BEC RID: 228332
			public const int TextLevel = 2;

			// Token: 0x04037BED RID: 228333
			public const int PanelLevelUp = 3;

			// Token: 0x04037BEE RID: 228334
			public const int TextLevelBofore = 4;

			// Token: 0x04037BEF RID: 228335
			public const int TextLevelAfter = 5;

			// Token: 0x04037BF0 RID: 228336
			public const int PanelPlayerTitle = 6;

			// Token: 0x04037BF1 RID: 228337
			public const int TextPlayerTitle = 7;

			// Token: 0x04037BF2 RID: 228338
			public const int TextExpUp = 8;

			// Token: 0x04037BF3 RID: 228339
			public const int TextExpAll = 9;

			// Token: 0x04037BF4 RID: 228340
			public const int SpriteNextExp = 10;

			// Token: 0x04037BF5 RID: 228341
			public const int PanelUnlock = 11;

			// Token: 0x04037BF6 RID: 228342
			public const int TextUnlock = 12;

			// Token: 0x04037BF7 RID: 228343
			public const int PanelPoints = 13;

			// Token: 0x04037BF8 RID: 228344
			public const int TextPointsOld = 14;

			// Token: 0x04037BF9 RID: 228345
			public const int TextPointsNew = 15;

			// Token: 0x04037BFA RID: 228346
			public const int SpriteCurrExp = 16;

			// Token: 0x04037BFB RID: 228347
			public const int SpriteAddExp = 17;

			// Token: 0x04037BFC RID: 228348
			public const int TextPointsAdd = 18;

			// Token: 0x04037BFD RID: 228349
			public const int ItemScorePanel = 19;

			// Token: 0x04037BFE RID: 228350
			public const int TextWinReason = 20;
		}
	}
}
