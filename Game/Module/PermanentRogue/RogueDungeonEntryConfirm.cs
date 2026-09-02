using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200566D RID: 22125
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueDungeonEntryConfirm : UiPanelBase
	{
		// Token: 0x06038631 RID: 230961 RVA: 0x00E46C48 File Offset: 0x00E44E48
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
		}

		// Token: 0x06038632 RID: 230962 RVA: 0x00E46D10 File Offset: 0x00E44F10
		protected override UniTask OnBeforeStartAsync()
		{
			RogueDungeonEntryConfirm.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueDungeonEntryConfirm.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038633 RID: 230963 RVA: 0x00E46D53 File Offset: 0x00E44F53
		private void ExtraButtonFunction()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.RogueResEnterInstClicked);
			(ActivityManager.GetActivityController(ActivityType.RogueRes) as ActivityPermanentRogueController).RequestEnterDungeon(this.DungeonId);
			ModelBase<ActivityPermanentRogueModel>.Instance.SetCurrentSelectedInst(this.DungeonId);
		}

		// Token: 0x06038634 RID: 230964 RVA: 0x00E46D8C File Offset: 0x00E44F8C
		[NullableContext(1)]
		public void SetLockTextByTextId(string textId, params string[] args)
		{
			this.PanelLock.SetTextByTextId(textId, args);
		}

		// Token: 0x06038635 RID: 230965 RVA: 0x00E46D9B File Offset: 0x00E44F9B
		public void SetLockSpriteVisible(bool bVisible)
		{
			this.PanelLock.SetSpriteVisible(bVisible);
		}

		// Token: 0x06038636 RID: 230966 RVA: 0x00E46DA9 File Offset: 0x00E44FA9
		public void SetPanelConditionVisible(bool bVisible)
		{
			base.GetItem(0).SetUIActive(bVisible);
		}

		// Token: 0x06038637 RID: 230967 RVA: 0x00E46DB8 File Offset: 0x00E44FB8
		public void SetLockConditionButtonVisible(bool bVisible)
		{
			this.PanelLock.SetButtonVisible(bVisible);
		}

		// Token: 0x06038638 RID: 230968 RVA: 0x00E46DC8 File Offset: 0x00E44FC8
		public void Refresh(int dungeonId)
		{
			this.DungeonId = dungeonId;
			InstanceDungeonEntranceModel instance = ModelBase<InstanceDungeonEntranceModel>.Instance;
			bool flag = instance.CheckInstanceUnlock(dungeonId);
			this.SetPanelConditionVisible(!flag);
			this.SetLockSpriteVisible(!flag);
			if (!flag)
			{
				string unlockTextIdById = instance.GetUnlockTextIdById(dungeonId);
				int[] unlockCondition = ConfigBase<InstanceDungeonConfig>.Instance.GetUnlockCondition(dungeonId);
				if (unlockCondition[0] == 1)
				{
					this.SetLockTextByTextId(unlockTextIdById ?? "", new string[]
					{
						unlockCondition[1].ToString()
					});
				}
				else if (unlockCondition[0] == 4)
				{
					InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(dungeonId);
					if (config != null)
					{
						this.SetLockTextByTextId(unlockTextIdById ?? "", new string[]
						{
							config.Value.MapName
						});
					}
				}
			}
			ActivityButtonItem functionButton = this.FunctionButton;
			if (functionButton == null)
			{
				return;
			}
			functionButton.SetUiActive(flag);
		}

		// Token: 0x04020292 RID: 131730
		protected int DungeonId;

		// Token: 0x04020293 RID: 131731
		public ActivityButtonItem FunctionButton;

		// Token: 0x04020294 RID: 131732
		public FunctionalPanelConditionLock PanelLock;
	}
}
