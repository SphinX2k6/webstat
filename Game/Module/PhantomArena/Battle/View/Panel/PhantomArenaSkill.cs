using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Canvas;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055C2 RID: 21954
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaSkill : UiPanelBase, IAreaCanvas, ISkillInteractMainInterface
	{
		// Token: 0x06037EA2 RID: 229026 RVA: 0x00E2AA2C File Offset: 0x00E28C2C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnClick))
			};
		}

		// Token: 0x06037EA3 RID: 229027 RVA: 0x00E2AAD8 File Offset: 0x00E28CD8
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			UUIButtonComponent button = base.GetButton(2);
			button.OnPointEnterCallBack.Bind(new Action(this.OnPointEnter));
			button.OnPointExitCallBack.Bind(new Action(this.OnPointExit));
			this.ViewProxy.BanButtonClickModule.RegisterButton(base.GetButton(2));
		}

		// Token: 0x06037EA4 RID: 229028 RVA: 0x00E2AB41 File Offset: 0x00E28D41
		private void OnPointEnter()
		{
			this.ViewProxy.ShowSkillTips(this.SkillData, base.GetItem(4));
		}

		// Token: 0x06037EA5 RID: 229029 RVA: 0x00E2AB5B File Offset: 0x00E28D5B
		private void OnPointExit()
		{
			this.ViewProxy.HideSkillTips();
		}

		// Token: 0x06037EA6 RID: 229030 RVA: 0x00E2AB68 File Offset: 0x00E28D68
		private void OnClick()
		{
			if (this.ViewProxy.InCantDragState())
			{
				return;
			}
			if (this.SkillData.IsPassive)
			{
				return;
			}
			if (this.ViewProxy.GuideManager.CheckInGuideAndShowTips())
			{
				return;
			}
			int battleStatusValue;
			if (this.SkillData.IsOwn)
			{
				battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleCostPoint);
			}
			else
			{
				battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleCostPoint);
			}
			if (ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleSkillConfig(this.SkillData.SkillId).CostConsume > battleStatusValue)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1063", Array.Empty<object>());
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "使用角色技能";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("技能", this.SkillData.SkillId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OnHandleRoleSkillClick().Forget();
		}

		// Token: 0x06037EA7 RID: 229031 RVA: 0x00E2AC50 File Offset: 0x00E28E50
		protected UniTask OnHandleRoleSkillClick()
		{
			PhantomArenaSkill.<OnHandleRoleSkillClick>d__10 <OnHandleRoleSkillClick>d__;
			<OnHandleRoleSkillClick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHandleRoleSkillClick>d__.<>4__this = this;
			<OnHandleRoleSkillClick>d__.<>1__state = -1;
			<OnHandleRoleSkillClick>d__.<>t__builder.Start<PhantomArenaSkill.<OnHandleRoleSkillClick>d__10>(ref <OnHandleRoleSkillClick>d__);
			return <OnHandleRoleSkillClick>d__.<>t__builder.Task;
		}

		// Token: 0x06037EA8 RID: 229032 RVA: 0x00E2AC94 File Offset: 0x00E28E94
		protected UniTask ExecuteBuffEffect()
		{
			PhantomArenaSkill.<ExecuteBuffEffect>d__11 <ExecuteBuffEffect>d__;
			<ExecuteBuffEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteBuffEffect>d__.<>4__this = this;
			<ExecuteBuffEffect>d__.<>1__state = -1;
			<ExecuteBuffEffect>d__.<>t__builder.Start<PhantomArenaSkill.<ExecuteBuffEffect>d__11>(ref <ExecuteBuffEffect>d__);
			return <ExecuteBuffEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037EA9 RID: 229033 RVA: 0x00E2ACD8 File Offset: 0x00E28ED8
		private void RefreshPassiveSkill()
		{
			base.GetText(1).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.SetTextureByPath(this.SkillData.Icon, base.GetTexture(0), null, null);
		}

		// Token: 0x06037EAA RID: 229034 RVA: 0x00E2AD24 File Offset: 0x00E28F24
		private void RefreshActiveSkill()
		{
			base.GetText(1).SetUIActive(true);
			base.GetItem(3).SetUIActive(true);
			base.SetTextureByPath(this.SkillData.Icon, base.GetTexture(0), null, null);
			base.GetText(1).SetText(this.SkillData.CostConsume.ToString(), true);
		}

		// Token: 0x06037EAB RID: 229035 RVA: 0x00E2AD8D File Offset: 0x00E28F8D
		public void Refresh(IPhantomArenaSkillData skillData)
		{
			this.SkillData = skillData;
			if (skillData.IsPassive)
			{
				this.RefreshPassiveSkill();
			}
			else
			{
				this.RefreshActiveSkill();
			}
			this.RefreshSkillEffect();
		}

		// Token: 0x06037EAC RID: 229036 RVA: 0x00E2ADB4 File Offset: 0x00E28FB4
		public void RefreshSkillEffect()
		{
			if (this.SkillData == null || this.SkillData.IsPassive)
			{
				return;
			}
			bool flag = ModelBase<PhantomArenaBattleModel>.Instance.CheckSkillEnoughCost(this.SkillData.SkillId);
			if (flag == this.IsCanUse)
			{
				return;
			}
			if (flag)
			{
				this.Sequence.StopSequenceByKey("Use", false, true);
				this.Sequence.PlaySequencePurely("Activate", false, false);
			}
			else
			{
				this.Sequence.StopSequenceByKey("Activate", false, true);
				this.Sequence.PlaySequencePurely("Use", false, false);
			}
			this.IsCanUse = flag;
		}

		// Token: 0x06037EAD RID: 229037 RVA: 0x00E2AE4C File Offset: 0x00E2904C
		public bool CheckCanvasSortOrder(List<EPhantomArenaInteractTag> tagList, ISkillTriggerInfo skillTriggerInfo)
		{
			if (!tagList.Contains(EPhantomArenaInteractTag.OwnSkill))
			{
				return false;
			}
			int? dataId = skillTriggerInfo.DataId;
			int skillId = this.SkillData.SkillId;
			return dataId.GetValueOrDefault() == skillId & dataId != null;
		}

		// Token: 0x06037EAE RID: 229038 RVA: 0x00E2AE8E File Offset: 0x00E2908E
		public void HandleSortOrder()
		{
			this.RootItem.GetRenderCanvas().SetSortOrderNew(2, true);
		}

		// Token: 0x06037EAF RID: 229039 RVA: 0x00E2AEA2 File Offset: 0x00E290A2
		public void CancelSortOrder()
		{
			this.RootItem.GetRenderCanvas().SetSortOrderNew(0, true);
		}

		// Token: 0x06037EB0 RID: 229040 RVA: 0x00E2AEB8 File Offset: 0x00E290B8
		public UniTask StartSkillInteract()
		{
			return default(UniTask);
		}

		// Token: 0x06037EB1 RID: 229041 RVA: 0x00E2AECE File Offset: 0x00E290CE
		public ISkillTriggerInfo GetData()
		{
			return ModelBase<PhantomArenaBattleModel>.Instance.BuffEffectData.RoleSkillTriggerInfo;
		}

		// Token: 0x06037EB2 RID: 229042 RVA: 0x00E2AEDF File Offset: 0x00E290DF
		public void FinishSkillInteract()
		{
		}

		// Token: 0x06037EB3 RID: 229043 RVA: 0x00E2AEE1 File Offset: 0x00E290E1
		public void CancelSkillInteract()
		{
		}

		// Token: 0x06037EB4 RID: 229044 RVA: 0x00E2AEE3 File Offset: 0x00E290E3
		[NullableContext(2)]
		public void ReceiveUiInteract(ISkillInteractMainUiInteract uiInteract)
		{
		}

		// Token: 0x0401FFDC RID: 131036
		private IPhantomArenaSkillData SkillData;

		// Token: 0x0401FFDD RID: 131037
		private bool IsCanUse;

		// Token: 0x0401FFDE RID: 131038
		public PhantomArenaBattleProxy ViewProxy;

		// Token: 0x0401FFDF RID: 131039
		protected UiSequencePlayer Sequence;

		// Token: 0x0200B5A2 RID: 46498
		[NullableContext(0)]
		private class ESkillDefine
		{
			// Token: 0x04038342 RID: 230210
			public const int SkillIcon = 0;

			// Token: 0x04038343 RID: 230211
			public const int CostNum = 1;

			// Token: 0x04038344 RID: 230212
			public const int Button = 2;

			// Token: 0x04038345 RID: 230213
			public const int CostItem = 3;

			// Token: 0x04038346 RID: 230214
			public const int AttachItem = 4;
		}
	}
}
