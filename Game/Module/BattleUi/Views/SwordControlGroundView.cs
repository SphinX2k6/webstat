using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006117 RID: 24855
	[NullableContext(2)]
	[Nullable(0)]
	public class SwordControlGroundView : UiViewBase
	{
		// Token: 0x0603EC8E RID: 257166 RVA: 0x01013EAA File Offset: 0x010120AA
		[NullableContext(1)]
		public SwordControlGroundView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603EC8F RID: 257167 RVA: 0x01013EC4 File Offset: 0x010120C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EC90 RID: 257168 RVA: 0x01013F50 File Offset: 0x01012150
		protected override UniTask OnBeforeStartAsync()
		{
			SwordControlGroundView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SwordControlGroundView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EC91 RID: 257169 RVA: 0x01013F93 File Offset: 0x01012193
		protected override void OnBeforeShow()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.Custom, SwordControlGroundView.HideBattleUiChildernList, false, true, 0);
		}

		// Token: 0x0603EC92 RID: 257170 RVA: 0x01013FAD File Offset: 0x010121AD
		protected override void OnAfterHide()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.Custom, SwordControlGroundView.HideBattleUiChildernList, true, true, 0);
		}

		// Token: 0x0603EC93 RID: 257171 RVA: 0x01013FC8 File Offset: 0x010121C8
		protected override void OnStart()
		{
			base.OnStart();
			this.SwordIconLayout = new GenericLayout<GroundSwordStackItem, ESwordStackState>(base.GetHorizontalLayout(1), new Func<GroundSwordStackItem>(this.CreateSwordIconItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
			this.RefreshRoleData();
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnBattleUiCurRoleDataChanged));
		}

		// Token: 0x0603EC94 RID: 257172 RVA: 0x01014030 File Offset: 0x01012230
		protected override void OnBeforeDestroy()
		{
			this.RemoveListenSwordStackTagCountChanged();
			this.RemoveListenLockedTargetTagChanged();
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnBattleUiCurRoleDataChanged));
			SwordControlGroundAttackButton groundAttackButton = this.GroundAttackButton;
			if (groundAttackButton != null)
			{
				groundAttackButton.Destroy(null);
			}
			this.GroundAttackButton = null;
			this.RoleData = null;
			this.SwordIconLayout = null;
		}

		// Token: 0x0603EC95 RID: 257173 RVA: 0x0101408C File Offset: 0x0101228C
		private void OnBattleUiCurRoleDataChanged(int newEntityId, int oldEntityId)
		{
			this.RefreshRoleData();
		}

		// Token: 0x0603EC96 RID: 257174 RVA: 0x01014094 File Offset: 0x01012294
		private void RefreshRoleData()
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (this.RoleData == curRoleData)
			{
				this.RefreshSwordStackCountUI(this.GetCurrentSwordUnlockStackCount(), this.GetCurrentLockedTargetCount(), true);
				this.RefreshAttackButtonUI(this.GetCurrentLockedTargetCount() > 0, true);
				return;
			}
			this.RemoveListenSwordStackTagCountChanged();
			this.RemoveListenLockedTargetTagChanged();
			this.RoleData = curRoleData;
			this.ListenForSwordStackTagCountChanged();
			this.ListenForLockedTargetTagChanged();
			this.RefreshSwordStackCountUI(this.GetCurrentSwordUnlockStackCount(), this.GetCurrentLockedTargetCount(), true);
			this.RefreshAttackButtonUI(this.GetCurrentLockedTargetCount() > 0, true);
		}

		// Token: 0x0603EC97 RID: 257175 RVA: 0x0101411C File Offset: 0x0101231C
		private void ListenForSwordStackTagCountChanged()
		{
			BattleUiRoleData roleData = this.RoleData;
			BaseTagComponent baseTagComponent = (roleData != null) ? roleData.GameplayTagComponent : null;
			if (baseTagComponent == null)
			{
				return;
			}
			this.SwordStackTagTask = baseTagComponent.ListenForTagAnyCountChanged(SwordControlGroundView.SwordUnlockStackTagId, new BaseTagComponent.TTagChangedCallback(this.OnSwordStackTagCountChanged));
		}

		// Token: 0x0603EC98 RID: 257176 RVA: 0x0101415D File Offset: 0x0101235D
		private void RemoveListenSwordStackTagCountChanged()
		{
			ITagTask swordStackTagTask = this.SwordStackTagTask;
			if (swordStackTagTask != null)
			{
				swordStackTagTask.EndTask();
			}
			this.SwordStackTagTask = null;
		}

		// Token: 0x0603EC99 RID: 257177 RVA: 0x01014177 File Offset: 0x01012377
		private void OnSwordStackTagCountChanged(int count, int tagId, int exactTagId, int oldCount)
		{
			this.RefreshSwordStackCountUI(count, this.GetCurrentLockedTargetCount(), false);
		}

		// Token: 0x0603EC9A RID: 257178 RVA: 0x01014188 File Offset: 0x01012388
		private void ListenForLockedTargetTagChanged()
		{
			BattleUiRoleData roleData = this.RoleData;
			BaseTagComponent baseTagComponent = (roleData != null) ? roleData.GameplayTagComponent : null;
			if (baseTagComponent == null)
			{
				return;
			}
			this.LockedTargetTagTask = baseTagComponent.ListenForTagAnyCountChanged(SwordControlGroundView.SwordLockedTargetCountTagId, new BaseTagComponent.TTagChangedCallback(this.OnLockedTargetTagChanged));
		}

		// Token: 0x0603EC9B RID: 257179 RVA: 0x010141C9 File Offset: 0x010123C9
		private void RemoveListenLockedTargetTagChanged()
		{
			ITagTask lockedTargetTagTask = this.LockedTargetTagTask;
			if (lockedTargetTagTask != null)
			{
				lockedTargetTagTask.EndTask();
			}
			this.LockedTargetTagTask = null;
		}

		// Token: 0x0603EC9C RID: 257180 RVA: 0x010141E3 File Offset: 0x010123E3
		private void OnLockedTargetTagChanged(int count, int tagId, int exactTagId, int oldCount)
		{
			this.RefreshSwordStackCountUI(this.GetCurrentSwordUnlockStackCount(), count, false);
			this.RefreshAttackButtonUI(count > 0, false);
		}

		// Token: 0x0603EC9D RID: 257181 RVA: 0x01014200 File Offset: 0x01012400
		private int GetCurrentSwordUnlockStackCount()
		{
			BattleUiRoleData roleData = this.RoleData;
			int? num;
			if (roleData == null)
			{
				num = null;
			}
			else
			{
				BaseTagComponent gameplayTagComponent = roleData.GameplayTagComponent;
				num = ((gameplayTagComponent != null) ? new int?(gameplayTagComponent.GetTagCount(SwordControlGroundView.SwordUnlockStackTagId)) : null);
			}
			int? num2 = num;
			return num2.GetValueOrDefault();
		}

		// Token: 0x0603EC9E RID: 257182 RVA: 0x01014250 File Offset: 0x01012450
		private int GetCurrentLockedTargetCount()
		{
			BattleUiRoleData roleData = this.RoleData;
			int? num;
			if (roleData == null)
			{
				num = null;
			}
			else
			{
				BaseTagComponent gameplayTagComponent = roleData.GameplayTagComponent;
				num = ((gameplayTagComponent != null) ? new int?(gameplayTagComponent.GetTagCount(SwordControlGroundView.SwordLockedTargetCountTagId)) : null);
			}
			int? num2 = num;
			return num2.GetValueOrDefault();
		}

		// Token: 0x0603EC9F RID: 257183 RVA: 0x010142A0 File Offset: 0x010124A0
		private void RefreshSwordStackCountUI(int unlockStackCount, int lockedTargetCount, bool isForced = false)
		{
			int num = Math.Max(0, Math.Min(5, unlockStackCount));
			int num2 = Math.Max(0, Math.Min(num, lockedTargetCount));
			if (this.SwordUnlockCount == num && this.LockedTargetCount == num2 && !isForced)
			{
				return;
			}
			this.SwordUnlockCount = num;
			this.LockedTargetCount = num2;
			List<ESwordStackState> list = new List<ESwordStackState>();
			for (int i = 0; i < 5; i++)
			{
				if (i < num2)
				{
					list.Add(ESwordStackState.Aim);
				}
				else if (i < num)
				{
					list.Add(ESwordStackState.Normal);
				}
				else
				{
					list.Add(ESwordStackState.Lock);
				}
			}
			GenericLayout<GroundSwordStackItem, ESwordStackState> swordIconLayout = this.SwordIconLayout;
			if (swordIconLayout == null)
			{
				return;
			}
			swordIconLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0603ECA0 RID: 257184 RVA: 0x01014333 File Offset: 0x01012533
		private void RefreshAttackButtonUI(bool isAttacking, bool isForced = false)
		{
			if (this.IsAttacking == isAttacking && !isForced)
			{
				return;
			}
			this.IsAttacking = isAttacking;
			SwordControlGroundAttackButton groundAttackButton = this.GroundAttackButton;
			if (groundAttackButton == null)
			{
				return;
			}
			groundAttackButton.SetInteractive(isAttacking, false);
		}

		// Token: 0x0603ECA1 RID: 257185 RVA: 0x0101435B File Offset: 0x0101255B
		[NullableContext(1)]
		private GroundSwordStackItem CreateSwordIconItem()
		{
			return new GroundSwordStackItem();
		}

		// Token: 0x04023374 RID: 144244
		[StaticVariableRuleIgnore]
		private static readonly int SwordUnlockStackTagId = GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.御剑剑意.解锁层数"];

		// Token: 0x04023375 RID: 144245
		private const int SwordStackIconCount = 5;

		// Token: 0x04023376 RID: 144246
		[StaticVariableRuleIgnore]
		private static readonly int SwordLockedTargetCountTagId = GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.御剑剑意.瞄准数量"];

		// Token: 0x04023377 RID: 144247
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyList<EBattleUiChild> HideBattleUiChildernList = new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
		{
			EBattleUiChild.Formation,
			EBattleUiChild.GamepadFormation,
			EBattleUiChild.SkillButton,
			EBattleUiChild.GamepadSkillButton,
			EBattleUiChild.RoleState
		});

		// Token: 0x04023378 RID: 144248
		private BattleUiRoleData RoleData;

		// Token: 0x04023379 RID: 144249
		private ITagTask SwordStackTagTask;

		// Token: 0x0402337A RID: 144250
		private ITagTask LockedTargetTagTask;

		// Token: 0x0402337B RID: 144251
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<GroundSwordStackItem, ESwordStackState> SwordIconLayout;

		// Token: 0x0402337C RID: 144252
		private SwordControlGroundAttackButton GroundAttackButton;

		// Token: 0x0402337D RID: 144253
		private int SwordUnlockCount = -1;

		// Token: 0x0402337E RID: 144254
		private int LockedTargetCount = -1;

		// Token: 0x0402337F RID: 144255
		private bool IsAttacking;

		// Token: 0x0200C2A0 RID: 49824
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403C012 RID: 245778
			BtnSkillNor,
			// Token: 0x0403C013 RID: 245779
			PnlIconList,
			// Token: 0x0403C014 RID: 245780
			PnlIconItem
		}
	}
}
