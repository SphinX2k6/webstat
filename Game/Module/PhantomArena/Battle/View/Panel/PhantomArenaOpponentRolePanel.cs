using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Hand;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.Opponent;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Field;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055BF RID: 21951
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaOpponentRolePanel : UiPanelBase
	{
		// Token: 0x06037E58 RID: 228952 RVA: 0x00E298D8 File Offset: 0x00E27AD8
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

		// Token: 0x06037E59 RID: 228953 RVA: 0x00E29948 File Offset: 0x00E27B48
		protected UniTask InitGamepadFieldItem()
		{
			PhantomArenaOpponentRolePanel.<InitGamepadFieldItem>d__8 <InitGamepadFieldItem>d__;
			<InitGamepadFieldItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitGamepadFieldItem>d__.<>4__this = this;
			<InitGamepadFieldItem>d__.<>1__state = -1;
			<InitGamepadFieldItem>d__.<>t__builder.Start<PhantomArenaOpponentRolePanel.<InitGamepadFieldItem>d__8>(ref <InitGamepadFieldItem>d__);
			return <InitGamepadFieldItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E5A RID: 228954 RVA: 0x00E2998B File Offset: 0x00E27B8B
		private void FieldPointerEnter(PhantomArenaFieldData fieldData, UUIItem attachItem)
		{
			this.ParentArea.ViewProxy.FieldPointerEnter(fieldData, attachItem, true);
		}

		// Token: 0x06037E5B RID: 228955 RVA: 0x00E299A0 File Offset: 0x00E27BA0
		protected UniTask CreateSkillItem(IPhantomArenaSkillData skillData)
		{
			PhantomArenaOpponentRolePanel.<CreateSkillItem>d__10 <CreateSkillItem>d__;
			<CreateSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateSkillItem>d__.<>4__this = this;
			<CreateSkillItem>d__.skillData = skillData;
			<CreateSkillItem>d__.<>1__state = -1;
			<CreateSkillItem>d__.<>t__builder.Start<PhantomArenaOpponentRolePanel.<CreateSkillItem>d__10>(ref <CreateSkillItem>d__);
			return <CreateSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E5C RID: 228956 RVA: 0x00E299EC File Offset: 0x00E27BEC
		protected UniTask CreateGamepadSkillItem(IPhantomArenaSkillData skillData)
		{
			PhantomArenaOpponentRolePanel.<CreateGamepadSkillItem>d__11 <CreateGamepadSkillItem>d__;
			<CreateGamepadSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateGamepadSkillItem>d__.<>4__this = this;
			<CreateGamepadSkillItem>d__.skillData = skillData;
			<CreateGamepadSkillItem>d__.<>1__state = -1;
			<CreateGamepadSkillItem>d__.<>t__builder.Start<PhantomArenaOpponentRolePanel.<CreateGamepadSkillItem>d__11>(ref <CreateGamepadSkillItem>d__);
			return <CreateGamepadSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E5D RID: 228957 RVA: 0x00E29A38 File Offset: 0x00E27C38
		protected UniTask InitSkillItem()
		{
			PhantomArenaOpponentRolePanel.<InitSkillItem>d__12 <InitSkillItem>d__;
			<InitSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSkillItem>d__.<>4__this = this;
			<InitSkillItem>d__.<>1__state = -1;
			<InitSkillItem>d__.<>t__builder.Start<PhantomArenaOpponentRolePanel.<InitSkillItem>d__12>(ref <InitSkillItem>d__);
			return <InitSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E5E RID: 228958 RVA: 0x00E29A7C File Offset: 0x00E27C7C
		private UniTask InitRoleItem()
		{
			PhantomArenaOpponentRolePanel.<InitRoleItem>d__13 <InitRoleItem>d__;
			<InitRoleItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleItem>d__.<>4__this = this;
			<InitRoleItem>d__.<>1__state = -1;
			<InitRoleItem>d__.<>t__builder.Start<PhantomArenaOpponentRolePanel.<InitRoleItem>d__13>(ref <InitRoleItem>d__);
			return <InitRoleItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E5F RID: 228959 RVA: 0x00E29AC0 File Offset: 0x00E27CC0
		private UniTask InitRoleHpTween()
		{
			PhantomArenaOpponentRolePanel.<InitRoleHpTween>d__14 <InitRoleHpTween>d__;
			<InitRoleHpTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleHpTween>d__.<>4__this = this;
			<InitRoleHpTween>d__.<>1__state = -1;
			<InitRoleHpTween>d__.<>t__builder.Start<PhantomArenaOpponentRolePanel.<InitRoleHpTween>d__14>(ref <InitRoleHpTween>d__);
			return <InitRoleHpTween>d__.<>t__builder.Task;
		}

		// Token: 0x06037E60 RID: 228960 RVA: 0x00E29B04 File Offset: 0x00E27D04
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaOpponentRolePanel.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaOpponentRolePanel.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037E61 RID: 228961 RVA: 0x00E29B47 File Offset: 0x00E27D47
		protected override void OnStart()
		{
			this.RoleHpTween.SetRoleItem(this.RoleItem);
			this.RoleItem.SetBarActive(true);
		}

		// Token: 0x06037E62 RID: 228962 RVA: 0x00E29B66 File Offset: 0x00E27D66
		protected override void OnBeforeDestroy()
		{
			this.RoleHpTween.Clear();
		}

		// Token: 0x06037E63 RID: 228963 RVA: 0x00E29B74 File Offset: 0x00E27D74
		private void InitLifeNum()
		{
			int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleLife);
			int battleStatusValue2 = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleMaxLife);
			ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.SetPrevShowLife(battleStatusValue);
			this.RoleItem.RefreshLifeNum(battleStatusValue, battleStatusValue2);
		}

		// Token: 0x06037E64 RID: 228964 RVA: 0x00E29BC0 File Offset: 0x00E27DC0
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
		}

		// Token: 0x06037E65 RID: 228965 RVA: 0x00E29BE0 File Offset: 0x00E27DE0
		public void RefreshLifeNumWithEffect()
		{
			int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleLife);
			int battleStatusValue2 = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleMaxLife);
			ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.SetPrevShowLife(battleStatusValue);
			this.RoleItem.PlayHpEffect(battleStatusValue);
			this.RoleItem.RefreshLifeNum(battleStatusValue, battleStatusValue2);
		}

		// Token: 0x06037E66 RID: 228966 RVA: 0x00E29C38 File Offset: 0x00E27E38
		public void TryDoLifeChangeShow()
		{
			int oldLife = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.PrevShowLife;
			int lifeNum = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleLife);
			if (oldLife == lifeNum)
			{
				return;
			}
			int maxLifeNum = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleMaxLife);
			ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.SetPrevShowLife(lifeNum);
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.RoleHpTween.PlayHpTween(oldLife, lifeNum, maxLifeNum);
				if (oldLife > lifeNum)
				{
					this.RoleItem.PlayHitAnim();
				}
			}, 300f, null, null, true, 1f);
		}

		// Token: 0x06037E67 RID: 228967 RVA: 0x00E29CDC File Offset: 0x00E27EDC
		public void PlayHpTween()
		{
			int prevShowLife = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.PrevShowLife;
			int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleLife);
			if (prevShowLife == battleStatusValue)
			{
				return;
			}
			int battleStatusValue2 = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleMaxLife);
			ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.SetPrevShowLife(battleStatusValue);
			this.RoleHpTween.PlayHpTween(prevShowLife, battleStatusValue, battleStatusValue2);
		}

		// Token: 0x06037E68 RID: 228968 RVA: 0x00E29D40 File Offset: 0x00E27F40
		public void RefreshShieldNum()
		{
			int battleBattleAttr = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleBattleAttr(PhantomBattleCardAttr.Defence);
			this.RoleItem.RefreshShieldNum(battleBattleAttr);
		}

		// Token: 0x06037E69 RID: 228969 RVA: 0x00E29D6C File Offset: 0x00E27F6C
		public void RefreshTask()
		{
			PhantomArenaCardTaskData taskData = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.TaskData;
			if (taskData == null || taskData.IsAllFinish)
			{
				this.RoleItem.SetPhantomBtnActive(false);
				return;
			}
			this.RoleItem.SetPhantomBtnActive(true);
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(taskData.TaskCardConfigId);
			this.RoleItem.RefreshMonsterIcon(phantomBattleCardConfig.TaskBg);
		}

		// Token: 0x06037E6A RID: 228970 RVA: 0x00E29DD0 File Offset: 0x00E27FD0
		public UniTask PlayBeHitEffect(int damage)
		{
			PhantomArenaOpponentRolePanel.<PlayBeHitEffect>d__25 <PlayBeHitEffect>d__;
			<PlayBeHitEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayBeHitEffect>d__.<>4__this = this;
			<PlayBeHitEffect>d__.damage = damage;
			<PlayBeHitEffect>d__.<>1__state = -1;
			<PlayBeHitEffect>d__.<>t__builder.Start<PhantomArenaOpponentRolePanel.<PlayBeHitEffect>d__25>(ref <PlayBeHitEffect>d__);
			return <PlayBeHitEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037E6B RID: 228971 RVA: 0x00E29E1B File Offset: 0x00E2801B
		public void RegisterBattleArea(OpponentArea area)
		{
			this.ParentArea = area;
		}

		// Token: 0x06037E6C RID: 228972 RVA: 0x00E29E24 File Offset: 0x00E28024
		public void SwitchFieldState(bool active)
		{
			PhantomArenaFieldItem gamepadFieldItem = this.GamepadFieldItem;
			if (gamepadFieldItem == null)
			{
				return;
			}
			gamepadFieldItem.SetFieldItemActive(active);
		}

		// Token: 0x06037E6D RID: 228973 RVA: 0x00E29E37 File Offset: 0x00E28037
		public void RefreshSkillState()
		{
			PhantomArenaSkill skillItem = this.SkillItem;
			if (skillItem != null)
			{
				skillItem.SetActive(!Singleton<Info>.Instance.IsInGamepad());
			}
			PhantomArenaSkill gamepadSkillItem = this.GamepadSkillItem;
			if (gamepadSkillItem == null)
			{
				return;
			}
			gamepadSkillItem.SetActive(Singleton<Info>.Instance.IsInGamepad());
		}

		// Token: 0x06037E6E RID: 228974 RVA: 0x00E29E71 File Offset: 0x00E28071
		public void RefreshField()
		{
			PhantomArenaFieldItem gamepadFieldItem = this.GamepadFieldItem;
			if (gamepadFieldItem == null)
			{
				return;
			}
			gamepadFieldItem.Refresh(ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.FieldData).Forget();
		}

		// Token: 0x06037E6F RID: 228975 RVA: 0x00E29E97 File Offset: 0x00E28097
		public UUIItem GetRoleRootItem()
		{
			return this.RoleItem.GetRootItem();
		}

		// Token: 0x0401FFC9 RID: 131017
		protected OpponentArea ParentArea;

		// Token: 0x0401FFCA RID: 131018
		protected PhantomArenaRoleItem RoleItem;

		// Token: 0x0401FFCB RID: 131019
		protected PhantomArenaSkill SkillItem;

		// Token: 0x0401FFCC RID: 131020
		protected PhantomArenaSkill GamepadSkillItem;

		// Token: 0x0401FFCD RID: 131021
		protected PhantomArenaFieldItem GamepadFieldItem;

		// Token: 0x0401FFCE RID: 131022
		protected PhantomArenaRoleHpTween RoleHpTween;

		// Token: 0x0200B58B RID: 46475
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x040382D8 RID: 230104
			public const int RoleItem = 0;

			// Token: 0x040382D9 RID: 230105
			public const int GamepadSkillItem = 1;

			// Token: 0x040382DA RID: 230106
			public const int GamepadFieldItem = 2;

			// Token: 0x040382DB RID: 230107
			public const int SkillItem = 3;
		}
	}
}
