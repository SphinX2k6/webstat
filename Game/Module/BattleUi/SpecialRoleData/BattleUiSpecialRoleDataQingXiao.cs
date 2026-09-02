using System;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.BattleUi.SpecialRoleData
{
	// Token: 0x0200612B RID: 24875
	public class BattleUiSpecialRoleDataQingXiao : BattleUiSpecialRoleDataBase
	{
		// Token: 0x0603ED80 RID: 257408 RVA: 0x0101A008 File Offset: 0x01018208
		protected override void OnInit()
		{
			BattleUiRoleData roleData = this.RoleData;
			bool? flag;
			if (roleData == null)
			{
				flag = null;
			}
			else
			{
				CharacterActorComponent actorComp = roleData.ActorComp;
				flag = ((actorComp != null) ? new bool?(actorComp.IsAutonomousProxy) : null);
			}
			bool? flag2 = flag;
			this.IsAutonomousProxy = flag2.GetValueOrDefault();
			if (!this.IsAutonomousProxy)
			{
				return;
			}
			BattleUiRoleData roleData2 = this.RoleData;
			if (roleData2 != null)
			{
				roleData2.ListenForTagSignificantChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1QingxiaoMd10011.御剑飞行能量.显示"], new BaseTagComponent.TTagSwitchedCallback(this.OnFlyStrengthTagChanged), true);
			}
			if (!Singleton<HudUnitManager>.Instance.GetIsInitHud())
			{
				Singleton<EventSystem>.Instance.Add(EEventName.HudInited, new Action(this.OnHudInited));
			}
		}

		// Token: 0x0603ED81 RID: 257409 RVA: 0x0101A0B4 File Offset: 0x010182B4
		protected override void OnClear()
		{
			if (!this.IsAutonomousProxy)
			{
				return;
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.HudInited, new Action(this.OnHudInited)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.HudInited, new Action(this.OnHudInited));
			}
			this.HasFlyItemTag = false;
			this.RefreshFlyItem();
			this.IsAutonomousProxy = false;
		}

		// Token: 0x0603ED82 RID: 257410 RVA: 0x0101A117 File Offset: 0x01018317
		private void OnHudInited()
		{
			this.RefreshFlyItem();
		}

		// Token: 0x0603ED83 RID: 257411 RVA: 0x0101A11F File Offset: 0x0101831F
		public override void OnChangeRole(bool isCurEntity)
		{
			if (!this.IsAutonomousProxy)
			{
				return;
			}
			this.RefreshFlyItem();
		}

		// Token: 0x0603ED84 RID: 257412 RVA: 0x0101A130 File Offset: 0x01018330
		private void OnFlyStrengthTagChanged(int tagId, bool tagExist)
		{
			if (!this.IsAutonomousProxy)
			{
				return;
			}
			this.HasFlyItemTag = tagExist;
			this.RefreshFlyItem();
		}

		// Token: 0x0603ED85 RID: 257413 RVA: 0x0101A148 File Offset: 0x01018348
		private void RefreshFlyItem()
		{
			if (!Singleton<HudUnitManager>.Instance.GetIsInitHud())
			{
				return;
			}
			BattleUiRoleData roleData = this.RoleData;
			if (roleData == null || !roleData.IsCurEntity || !this.HasFlyItemTag)
			{
				this.RemoveFlyItem();
				return;
			}
			this.AddFlyItem();
		}

		// Token: 0x0603ED86 RID: 257414 RVA: 0x0101A183 File Offset: 0x01018383
		private void AddFlyItem()
		{
			if (this.HasFlyItem)
			{
				return;
			}
			this.HasFlyItem = true;
			Singleton<EventSystem>.Instance.Emit<EStrengthItemType>(EEventName.AddStrengthItem, EStrengthItemType.QingXiaoFly);
		}

		// Token: 0x0603ED87 RID: 257415 RVA: 0x0101A1A6 File Offset: 0x010183A6
		private void RemoveFlyItem()
		{
			if (!this.HasFlyItem)
			{
				return;
			}
			this.HasFlyItem = false;
			Singleton<EventSystem>.Instance.Emit<EStrengthItemType>(EEventName.RemoveStrengthItem, EStrengthItemType.QingXiaoFly);
		}

		// Token: 0x0402341F RID: 144415
		private bool IsAutonomousProxy;

		// Token: 0x04023420 RID: 144416
		private bool HasFlyItem;

		// Token: 0x04023421 RID: 144417
		private bool HasFlyItemTag;
	}
}
