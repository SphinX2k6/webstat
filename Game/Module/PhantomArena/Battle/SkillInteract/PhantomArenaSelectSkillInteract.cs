using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract
{
	// Token: 0x020055E6 RID: 21990
	public class PhantomArenaSelectSkillInteract : PhantomArenaSkillInteractBase, ISkillInteractMainUiInteract
	{
		// Token: 0x06038083 RID: 229507 RVA: 0x00E31DDC File Offset: 0x00E2FFDC
		private void TriggerCardActiveSkill()
		{
			PhantomCardData phantomCardData;
			if (this.Data.IsFight)
			{
				phantomCardData = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleCardByCardId(this.Data.DataId.Value);
			}
			else
			{
				phantomCardData = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetHandCardDataByCardId(this.Data.DataId.Value);
			}
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(phantomCardData.ConfigId);
			this.BattleProxy.SkillTriggerMask.ShowTriggerMask(new int?(phantomBattleCardConfig.ActiveSkillId));
			this.BattleProxy.SkillTriggerMask.RefreshSkill(phantomBattleCardConfig.Name, phantomBattleCardConfig.CardEffectDescription, phantomBattleCardConfig.CardEffectDescriptionParams());
		}

		// Token: 0x06038084 RID: 229508 RVA: 0x00E31E94 File Offset: 0x00E30094
		private void TriggerCardClickSkill()
		{
			PhantomCardData battleCardByCardId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleCardByCardId(this.Data.DataId.Value);
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(battleCardByCardId.ConfigId);
			this.BattleProxy.SkillTriggerMask.ShowTriggerMask(new int?(battleCardByCardId.ClickActiveSkillId));
			this.BattleProxy.SkillTriggerMask.RefreshSkill(phantomBattleCardConfig.Name, phantomBattleCardConfig.DurableSkillDescription, phantomBattleCardConfig.DurableSkillDescriptionParams());
		}

		// Token: 0x06038085 RID: 229509 RVA: 0x00E31F18 File Offset: 0x00E30118
		private void TriggerPassiveSkill()
		{
			this.BattleProxy.SkillTriggerMask.ShowTriggerMask(this.Data.DataId);
			if (this.Data.DataId != null)
			{
				PhantomCardData battleCardByCardId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleCardByCardId(this.Data.DataId.Value);
				PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(battleCardByCardId.ConfigId);
				if (battleCardByCardId.IsField)
				{
					Span<int> passiveSkillIdBytes = phantomBattleCardConfig.GetPassiveSkillIdBytes();
					string skillDesc = (passiveSkillIdBytes.Length > 0) ? phantomBattleCardConfig.CardEffectDescription : phantomBattleCardConfig.CountSkillDescription;
					string[] paramsList = (passiveSkillIdBytes.Length > 0) ? phantomBattleCardConfig.CardEffectDescriptionParams() : phantomBattleCardConfig.CountSkillDescriptionParams();
					this.BattleProxy.SkillTriggerMask.RefreshSkill(phantomBattleCardConfig.Name, skillDesc, paramsList);
					return;
				}
				this.BattleProxy.SkillTriggerMask.RefreshSkill(phantomBattleCardConfig.Name, phantomBattleCardConfig.CardEffectDescription, phantomBattleCardConfig.CardEffectDescriptionParams());
			}
		}

		// Token: 0x06038086 RID: 229510 RVA: 0x00E32018 File Offset: 0x00E30218
		private void TriggerRoleSkill()
		{
			this.BattleProxy.SkillTriggerMask.ShowTriggerMask(this.Data.DataId);
			if (this.Data.DataId != null)
			{
				int roleId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.RoleId;
				PhantomBattleCardRole phantomBattleCardRole = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(roleId);
				int num = phantomBattleCardRole.GetActiveSkillIdBytes().IndexOf(this.Data.DataId.Value);
				string skillName = phantomBattleCardRole.SkillNameList()[num];
				string skillDesc = phantomBattleCardRole.SkillDescList()[num];
				string[] paramsList = (phantomBattleCardRole.SkillDescParamsList() != null && num < phantomBattleCardRole.SkillDescParamsList().Length) ? phantomBattleCardRole.SkillDescParamsList()[num].ArrayString() : new string[0];
				this.BattleProxy.SkillTriggerMask.RefreshSkill(skillName, skillDesc, paramsList);
			}
		}

		// Token: 0x06038087 RID: 229511 RVA: 0x00E320F4 File Offset: 0x00E302F4
		private void TriggerSkill()
		{
			if (this.Data.IsRole)
			{
				this.TriggerRoleSkill();
				return;
			}
			if (this.Data.IsPassive)
			{
				this.TriggerPassiveSkill();
				return;
			}
			if (this.Data.DataId != null)
			{
				if (this.Data.IsClickInteract)
				{
					this.TriggerCardClickSkill();
					return;
				}
				this.TriggerCardActiveSkill();
			}
		}

		// Token: 0x06038088 RID: 229512 RVA: 0x00E32158 File Offset: 0x00E30358
		private void ShowSkillTriggerMask()
		{
			this.TriggerSkill();
			this.BattleProxy.SkillTriggerMask.RefreshTips(this.SelectedIdMap.Count, this.ConditionSize);
			this.BattleProxy.SkillTriggerMask.RefreshCancelBtnActive(this.Data.IsPassive);
		}

		// Token: 0x06038089 RID: 229513 RVA: 0x00E321A8 File Offset: 0x00E303A8
		private void SortOrderAreaCanvas()
		{
			List<EPhantomArenaInteractTag> list = new List<EPhantomArenaInteractTag>
			{
				EPhantomArenaInteractTag.OwnMonster,
				EPhantomArenaInteractTag.OpponentAreaMonster
			};
			if (this.Data.IsRole)
			{
				list.Add(EPhantomArenaInteractTag.OwnSkill);
			}
			this.BattleProxy.CanvasManager.SortOrderAreaCanvas(list, this.Data, this);
		}

		// Token: 0x0603808A RID: 229514 RVA: 0x00E321F8 File Offset: 0x00E303F8
		protected override UniTask<EPhantomArenaSkillInteractExecuteResult> OnExecute([Nullable(1)] PhantomArenaBattleProxy proxy)
		{
			PhantomArenaSelectSkillInteract.<OnExecute>d__10 <OnExecute>d__;
			<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder<EPhantomArenaSkillInteractExecuteResult>.Create();
			<OnExecute>d__.<>4__this = this;
			<OnExecute>d__.proxy = proxy;
			<OnExecute>d__.<>1__state = -1;
			<OnExecute>d__.<>t__builder.Start<PhantomArenaSelectSkillInteract.<OnExecute>d__10>(ref <OnExecute>d__);
			return <OnExecute>d__.<>t__builder.Task;
		}

		// Token: 0x0603808B RID: 229515 RVA: 0x00E32244 File Offset: 0x00E30444
		protected UniTask<bool> TryHandleFinish()
		{
			PhantomArenaSelectSkillInteract.<TryHandleFinish>d__11 <TryHandleFinish>d__;
			<TryHandleFinish>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryHandleFinish>d__.<>4__this = this;
			<TryHandleFinish>d__.<>1__state = -1;
			<TryHandleFinish>d__.<>t__builder.Start<PhantomArenaSelectSkillInteract.<TryHandleFinish>d__11>(ref <TryHandleFinish>d__);
			return <TryHandleFinish>d__.<>t__builder.Task;
		}

		// Token: 0x0603808C RID: 229516 RVA: 0x00E32288 File Offset: 0x00E30488
		private void Reset()
		{
			this.BattleProxy.HideLine();
			this.BattleProxy.SkillTriggerMask.HideTriggerMask();
			this.BattleProxy.CanvasManager.ResetAreaCanvas();
			foreach (int index in this.SelectedIdMap.Values)
			{
				this.BattleProxy.OwnArea.FunctionalArea.ResetCardSelectState(index);
			}
			this.BattleProxy.UnRegisterCantDragReason(EPhantomArenaCantDragReason.SelectSkillInteract);
		}

		// Token: 0x0603808D RID: 229517 RVA: 0x00E32328 File Offset: 0x00E30528
		protected unsafe bool OnReceiveClickData(int cardId, int index, bool isSelected)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "Buff期间,接收到卡牌点击";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("卡牌Id", cardId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("是否选中", isSelected);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (isSelected && this.SelectedIdMap.Count >= this.ConditionSize)
			{
				Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "Buff期间,已经选择的卡牌数量达到上限,无法再选择", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (isSelected)
			{
				this.SelectedIdMap[cardId] = index;
				this.LastSelectedId = cardId;
			}
			else
			{
				this.SelectedIdMap.Remove(cardId);
			}
			this.BattleProxy.SkillTriggerMask.RefreshTips(this.SelectedIdMap.Count, this.ConditionSize);
			return true;
		}

		// Token: 0x0603808E RID: 229518 RVA: 0x00E32414 File Offset: 0x00E30614
		protected bool OnCheckCondition()
		{
			return this.SelectedIdMap.Count >= this.ConditionSize;
		}

		// Token: 0x0603808F RID: 229519 RVA: 0x00E3242C File Offset: 0x00E3062C
		protected UniTask<bool> OnHandleFinish()
		{
			PhantomArenaSelectSkillInteract.<OnHandleFinish>d__15 <OnHandleFinish>d__;
			<OnHandleFinish>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnHandleFinish>d__.<>4__this = this;
			<OnHandleFinish>d__.<>1__state = -1;
			<OnHandleFinish>d__.<>t__builder.Start<PhantomArenaSelectSkillInteract.<OnHandleFinish>d__15>(ref <OnHandleFinish>d__);
			return <OnHandleFinish>d__.<>t__builder.Task;
		}

		// Token: 0x06038090 RID: 229520 RVA: 0x00E32470 File Offset: 0x00E30670
		[NullableContext(1)]
		public bool ReceiveClickData(ESkillInteractMainUiInteractType type, params object[] data)
		{
			if (type == ESkillInteractMainUiInteractType.CancelBtn)
			{
				Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "取消执行Buff交互操作", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.Reset();
				this.Info.CancelSkillInteract();
				return true;
			}
			if (type == ESkillInteractMainUiInteractType.ConfirmBtn)
			{
				this.TryHandleFinish().Forget<bool>();
				return true;
			}
			return this.OnReceiveClickData((int)data[0], (int)data[1], (bool)data[2]);
		}

		// Token: 0x0402008F RID: 131215
		[Nullable(1)]
		private readonly Dictionary<int, int> SelectedIdMap = new Dictionary<int, int>();

		// Token: 0x04020090 RID: 131216
		private int LastSelectedId = -1;

		// Token: 0x04020091 RID: 131217
		private int ConditionSize;
	}
}
