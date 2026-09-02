using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Area;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Hand;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Field;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055C0 RID: 21952
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaOwnRolePanel : UiPanelBase
	{
		// Token: 0x06037E71 RID: 228977 RVA: 0x00E29EAC File Offset: 0x00E280AC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06037E72 RID: 228978 RVA: 0x00E29F1C File Offset: 0x00E2811C
		protected UniTask InitGamepadFieldItem()
		{
			PhantomArenaOwnRolePanel.<InitGamepadFieldItem>d__8 <InitGamepadFieldItem>d__;
			<InitGamepadFieldItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitGamepadFieldItem>d__.<>4__this = this;
			<InitGamepadFieldItem>d__.<>1__state = -1;
			<InitGamepadFieldItem>d__.<>t__builder.Start<PhantomArenaOwnRolePanel.<InitGamepadFieldItem>d__8>(ref <InitGamepadFieldItem>d__);
			return <InitGamepadFieldItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E73 RID: 228979 RVA: 0x00E29F5F File Offset: 0x00E2815F
		private void FieldPointerEnter(PhantomArenaFieldData fieldData, UUIItem attachItem)
		{
			this.ParentArea.ViewProxy.FieldPointerEnter(fieldData, attachItem, true);
		}

		// Token: 0x06037E74 RID: 228980 RVA: 0x00E29F74 File Offset: 0x00E28174
		protected UniTask InitRoleHpTween()
		{
			PhantomArenaOwnRolePanel.<InitRoleHpTween>d__10 <InitRoleHpTween>d__;
			<InitRoleHpTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleHpTween>d__.<>4__this = this;
			<InitRoleHpTween>d__.<>1__state = -1;
			<InitRoleHpTween>d__.<>t__builder.Start<PhantomArenaOwnRolePanel.<InitRoleHpTween>d__10>(ref <InitRoleHpTween>d__);
			return <InitRoleHpTween>d__.<>t__builder.Task;
		}

		// Token: 0x06037E75 RID: 228981 RVA: 0x00E29FB8 File Offset: 0x00E281B8
		protected UniTask InitRoleItem()
		{
			PhantomArenaOwnRolePanel.<InitRoleItem>d__11 <InitRoleItem>d__;
			<InitRoleItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleItem>d__.<>4__this = this;
			<InitRoleItem>d__.<>1__state = -1;
			<InitRoleItem>d__.<>t__builder.Start<PhantomArenaOwnRolePanel.<InitRoleItem>d__11>(ref <InitRoleItem>d__);
			return <InitRoleItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E76 RID: 228982 RVA: 0x00E29FFC File Offset: 0x00E281FC
		protected UniTask InitSkillItem(UUIItem uiItem, bool needShow)
		{
			PhantomArenaOwnRolePanel.<InitSkillItem>d__12 <InitSkillItem>d__;
			<InitSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSkillItem>d__.<>4__this = this;
			<InitSkillItem>d__.uiItem = uiItem;
			<InitSkillItem>d__.needShow = needShow;
			<InitSkillItem>d__.<>1__state = -1;
			<InitSkillItem>d__.<>t__builder.Start<PhantomArenaOwnRolePanel.<InitSkillItem>d__12>(ref <InitSkillItem>d__);
			return <InitSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E77 RID: 228983 RVA: 0x00E2A050 File Offset: 0x00E28250
		protected UniTask InitSkillList()
		{
			PhantomArenaOwnRolePanel.<InitSkillList>d__13 <InitSkillList>d__;
			<InitSkillList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSkillList>d__.<>4__this = this;
			<InitSkillList>d__.<>1__state = -1;
			<InitSkillList>d__.<>t__builder.Start<PhantomArenaOwnRolePanel.<InitSkillList>d__13>(ref <InitSkillList>d__);
			return <InitSkillList>d__.<>t__builder.Task;
		}

		// Token: 0x06037E78 RID: 228984 RVA: 0x00E2A094 File Offset: 0x00E28294
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaOwnRolePanel.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaOwnRolePanel.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037E79 RID: 228985 RVA: 0x00E2A0D7 File Offset: 0x00E282D7
		protected override void OnStart()
		{
			this.RoleHpTween.SetRoleItem(this.RoleItem);
			this.RoleItem.SetBarActive(true);
			this.InitAll();
		}

		// Token: 0x06037E7A RID: 228986 RVA: 0x00E2A0FC File Offset: 0x00E282FC
		protected override void OnBeforeDestroy()
		{
			this.RoleHpTween.Clear();
		}

		// Token: 0x06037E7B RID: 228987 RVA: 0x00E2A109 File Offset: 0x00E28309
		private void InitAll()
		{
			this.InitLifeNum();
			this.RefreshTask();
			this.RefreshSkillEffect();
		}

		// Token: 0x06037E7C RID: 228988 RVA: 0x00E2A120 File Offset: 0x00E28320
		private void InitLifeNum()
		{
			int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleLife);
			int battleStatusValue2 = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleMaxLife);
			ModelBase<PhantomArenaBattleModel>.Instance.OwnData.SetPrevShowLife(battleStatusValue);
			this.RoleItem.RefreshLifeNum(battleStatusValue, battleStatusValue2);
		}

		// Token: 0x06037E7D RID: 228989 RVA: 0x00E2A16C File Offset: 0x00E2836C
		public void RefreshAll(bool isFromWorldDone)
		{
			if (isFromWorldDone)
			{
				this.InitLifeNum();
			}
			else
			{
				this.RefreshShieldNum();
				this.TryDoLifeChangeShow();
			}
			this.RefreshTask();
			this.RefreshSkillEffect();
		}

		// Token: 0x06037E7E RID: 228990 RVA: 0x00E2A194 File Offset: 0x00E28394
		public void RefreshLifeNumWithEffect()
		{
			int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleLife);
			int battleStatusValue2 = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleMaxLife);
			this.RoleItem.PlayHpEffect(battleStatusValue);
			this.RoleItem.RefreshLifeNum(battleStatusValue, battleStatusValue2);
		}

		// Token: 0x06037E7F RID: 228991 RVA: 0x00E2A1DC File Offset: 0x00E283DC
		public void TryDoLifeChangeShow()
		{
			int oldLife = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.PrevShowLife;
			int lifeNum = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleLife);
			if (oldLife == lifeNum)
			{
				return;
			}
			int maxLifeNum = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleMaxLife);
			ModelBase<PhantomArenaBattleModel>.Instance.OwnData.SetPrevShowLife(lifeNum);
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.RoleHpTween.PlayHpTween(oldLife, lifeNum, maxLifeNum);
				if (oldLife > lifeNum)
				{
					this.RoleItem.PlayHitAnim();
				}
			}, 300f, null, null, true, 1f);
		}

		// Token: 0x06037E80 RID: 228992 RVA: 0x00E2A280 File Offset: 0x00E28480
		public void PlayHpTween()
		{
			int prevShowLife = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.PrevShowLife;
			int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleLife);
			if (prevShowLife == battleStatusValue)
			{
				return;
			}
			int battleStatusValue2 = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleMaxLife);
			ModelBase<PhantomArenaBattleModel>.Instance.OwnData.SetPrevShowLife(battleStatusValue);
			this.RoleHpTween.PlayHpTween(prevShowLife, battleStatusValue, battleStatusValue2);
		}

		// Token: 0x06037E81 RID: 228993 RVA: 0x00E2A2E4 File Offset: 0x00E284E4
		public void RefreshShieldNum()
		{
			int battleBattleAttr = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleBattleAttr(PhantomBattleCardAttr.Defence);
			this.RoleItem.RefreshShieldNum(battleBattleAttr);
		}

		// Token: 0x06037E82 RID: 228994 RVA: 0x00E2A310 File Offset: 0x00E28510
		public void RefreshTask()
		{
			PhantomArenaCardTaskData taskData = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.TaskData;
			if (taskData == null || taskData.IsAllFinish)
			{
				this.RoleItem.SetPhantomBtnActive(false);
				return;
			}
			this.RoleItem.SetPhantomBtnActive(this.IsFourCostShowInFirstTime);
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(taskData.TaskCardConfigId);
			this.RoleItem.RefreshMonsterIcon(phantomBattleCardConfig.TaskBg);
		}

		// Token: 0x06037E83 RID: 228995 RVA: 0x00E2A37C File Offset: 0x00E2857C
		public UniTask PlayBeHitEffect(int damage)
		{
			PhantomArenaOwnRolePanel.<PlayBeHitEffect>d__25 <PlayBeHitEffect>d__;
			<PlayBeHitEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayBeHitEffect>d__.<>4__this = this;
			<PlayBeHitEffect>d__.damage = damage;
			<PlayBeHitEffect>d__.<>1__state = -1;
			<PlayBeHitEffect>d__.<>t__builder.Start<PhantomArenaOwnRolePanel.<PlayBeHitEffect>d__25>(ref <PlayBeHitEffect>d__);
			return <PlayBeHitEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037E84 RID: 228996 RVA: 0x00E2A3C7 File Offset: 0x00E285C7
		public void ActiveIsFourCostShowInFirstTime()
		{
			this.IsFourCostShowInFirstTime = true;
			this.RoleItem.ShowPhantomBtn();
		}

		// Token: 0x06037E85 RID: 228997 RVA: 0x00E2A3DC File Offset: 0x00E285DC
		public void RefreshSkillEffect()
		{
			foreach (PhantomArenaSkill phantomArenaSkill in this.SkillList)
			{
				phantomArenaSkill.RefreshSkillEffect();
			}
		}

		// Token: 0x06037E86 RID: 228998 RVA: 0x00E2A42C File Offset: 0x00E2862C
		public void RegisterBattleArea(PhantomArenaOwnArea area)
		{
			this.ParentArea = area;
		}

		// Token: 0x06037E87 RID: 228999 RVA: 0x00E2A435 File Offset: 0x00E28635
		public void SwitchFieldState(bool active)
		{
			PhantomArenaFieldItem gamepadFieldItem = this.GamepadFieldItem;
			if (gamepadFieldItem == null)
			{
				return;
			}
			gamepadFieldItem.SetFieldItemActive(active);
		}

		// Token: 0x06037E88 RID: 229000 RVA: 0x00E2A448 File Offset: 0x00E28648
		public void RefreshField()
		{
			PhantomArenaFieldItem gamepadFieldItem = this.GamepadFieldItem;
			if (gamepadFieldItem == null)
			{
				return;
			}
			gamepadFieldItem.Refresh(ModelBase<PhantomArenaBattleModel>.Instance.OwnData.FieldData).Forget();
		}

		// Token: 0x06037E89 RID: 229001 RVA: 0x00E2A46E File Offset: 0x00E2866E
		public UUIItem GetRoleRootItem()
		{
			return this.RoleItem.GetRootItem();
		}

		// Token: 0x06037E8A RID: 229002 RVA: 0x00E2A47B File Offset: 0x00E2867B
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "Task"))
			{
				return null;
			}
			PhantomArenaRoleItem roleItem = this.RoleItem;
			if (roleItem == null)
			{
				return null;
			}
			return roleItem.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0401FFCF RID: 131023
		protected PhantomArenaOwnArea ParentArea;

		// Token: 0x0401FFD0 RID: 131024
		protected PhantomArenaRoleItem RoleItem;

		// Token: 0x0401FFD1 RID: 131025
		protected bool IsFourCostShowInFirstTime;

		// Token: 0x0401FFD2 RID: 131026
		protected PhantomArenaRoleHpTween RoleHpTween;

		// Token: 0x0401FFD3 RID: 131027
		protected List<PhantomArenaSkill> SkillList = new List<PhantomArenaSkill>();

		// Token: 0x0401FFD4 RID: 131028
		protected PhantomArenaFieldItem GamepadFieldItem;

		// Token: 0x0200B595 RID: 46485
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038303 RID: 230147
			public const int RoleItem = 0;

			// Token: 0x04038304 RID: 230148
			public const int SkillItemTwo = 1;

			// Token: 0x04038305 RID: 230149
			public const int SkillItemOne = 2;

			// Token: 0x04038306 RID: 230150
			public const int GamepadFieldItem = 3;
		}
	}
}
