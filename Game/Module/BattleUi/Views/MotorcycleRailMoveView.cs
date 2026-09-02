using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200607C RID: 24700
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleRailMoveView : UiTickViewBase
	{
		// Token: 0x0603E487 RID: 255111 RVA: 0x00FE6C54 File Offset: 0x00FE4E54
		public MotorcycleRailMoveView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603E488 RID: 255112 RVA: 0x00FE6C74 File Offset: 0x00FE4E74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E489 RID: 255113 RVA: 0x00FE6CE0 File Offset: 0x00FE4EE0
		protected override UniTask OnBeforeStartAsync()
		{
			MotorcycleRailMoveView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleRailMoveView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E48A RID: 255114 RVA: 0x00FE6D23 File Offset: 0x00FE4F23
		protected override void OnStart()
		{
			base.OnStart();
			this.RefreshRoleData();
		}

		// Token: 0x0603E48B RID: 255115 RVA: 0x00FE6D31 File Offset: 0x00FE4F31
		protected override void OnBeforeShow()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.RoleSpecialState, new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
			{
				EBattleUiChild.Joystick,
				EBattleUiChild.Formation,
				EBattleUiChild.GamepadFormation,
				EBattleUiChild.MotorcycleMobileJoystick,
				EBattleUiChild.MotorcycleControlHud
			}), false, true, 0);
		}

		// Token: 0x0603E48C RID: 255116 RVA: 0x00FE6D5D File Offset: 0x00FE4F5D
		protected override void OnAfterHide()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.RoleSpecialState, new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
			{
				EBattleUiChild.Joystick,
				EBattleUiChild.Formation,
				EBattleUiChild.GamepadFormation,
				EBattleUiChild.MotorcycleMobileJoystick,
				EBattleUiChild.MotorcycleControlHud
			}), true, true, 0);
		}

		// Token: 0x0603E48D RID: 255117 RVA: 0x00FE6D8C File Offset: 0x00FE4F8C
		public UniTask NewAllSkillItems()
		{
			MotorcycleRailMoveView.<NewAllSkillItems>d__13 <NewAllSkillItems>d__;
			<NewAllSkillItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAllSkillItems>d__.<>4__this = this;
			<NewAllSkillItems>d__.<>1__state = -1;
			<NewAllSkillItems>d__.<>t__builder.Start<MotorcycleRailMoveView.<NewAllSkillItems>d__13>(ref <NewAllSkillItems>d__);
			return <NewAllSkillItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603E48E RID: 255118 RVA: 0x00FE6DD0 File Offset: 0x00FE4FD0
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<MoveSkillItem> NewSkillItem(AActor rootActor, int inputIndex)
		{
			MotorcycleRailMoveView.<NewSkillItem>d__14 <NewSkillItem>d__;
			<NewSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<MoveSkillItem>.Create();
			<NewSkillItem>d__.<>4__this = this;
			<NewSkillItem>d__.rootActor = rootActor;
			<NewSkillItem>d__.inputIndex = inputIndex;
			<NewSkillItem>d__.<>1__state = -1;
			<NewSkillItem>d__.<>t__builder.Start<MotorcycleRailMoveView.<NewSkillItem>d__14>(ref <NewSkillItem>d__);
			return <NewSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E48F RID: 255119 RVA: 0x00FE6E24 File Offset: 0x00FE5024
		private void RefreshAllSkillItems()
		{
			this.SkillItemList[0].RefreshByMoveType(EInputAxis.MoveRight, -1f, false);
			this.SkillItemList[1].RefreshByMoveType(EInputAxis.MoveRight, 1f, false);
			this.SkillItemList[0].RefreshKeyByActionName(MotorcycleRailMoveView.ActionNameList[0]);
			this.SkillItemList[1].RefreshKeyByActionName(MotorcycleRailMoveView.ActionNameList[1]);
			this.SkillItemList[0].SetCustomSkillItemEnable(false);
			this.SkillItemList[1].SetCustomSkillItemEnable(false);
		}

		// Token: 0x0603E490 RID: 255120 RVA: 0x00FE6EBD File Offset: 0x00FE50BD
		protected override void OnAddEventListener()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<InputDistributeController>.Instance.BindActions(MotorcycleRailMoveView.ActionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
		}

		// Token: 0x0603E491 RID: 255121 RVA: 0x00FE6EE6 File Offset: 0x00FE50E6
		protected override void OnRemoveEventListener()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<InputDistributeController>.Instance.UnBindActions(MotorcycleRailMoveView.ActionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
		}

		// Token: 0x0603E492 RID: 255122 RVA: 0x00FE6F10 File Offset: 0x00FE5110
		protected override void OnBeforeDestroy()
		{
			foreach (MoveSkillItem moveSkillItem in this.SkillItemList)
			{
				moveSkillItem.Destroy(null);
			}
			this.SkillItemList.Clear();
			this.RemoveEntityEvents();
		}

		// Token: 0x0603E493 RID: 255123 RVA: 0x00FE6F74 File Offset: 0x00FE5174
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			for (int i = 0; i < MotorcycleRailMoveView.ActionNameList.Length; i++)
			{
				if (actionName == MotorcycleRailMoveView.ActionNameList[i])
				{
					this.SkillItemList[i].OnInputAction(false);
					return;
				}
			}
		}

		// Token: 0x0603E494 RID: 255124 RVA: 0x00FE6FBC File Offset: 0x00FE51BC
		private void RefreshRoleData()
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			if (!ControllerBase<FormationDataController>.Instance.IsPlayerExist(playerId))
			{
				return;
			}
			this.RemoveEntityEvents();
			this.AddEntityEvents();
		}

		// Token: 0x0603E495 RID: 255125 RVA: 0x00FE6FF0 File Offset: 0x00FE51F0
		private void AddEntityEvents()
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			if (!ControllerBase<FormationDataController>.Instance.IsPlayerExist(playerId))
			{
				return;
			}
			WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(playerId);
			PlayerTagComponent playerTagComponent = (playerEntity != null) ? playerEntity.GetComponent<PlayerTagComponent>() : null;
			if (playerTagComponent == null)
			{
				return;
			}
			this.ListenForTagAddOrRemove(playerTagComponent, MotorcycleRailMoveView.SwitchLeftTag, new BaseTagComponent.TTagSwitchedCallback(this.OnSwitchLeftTagChanged), true);
			this.ListenForTagAddOrRemove(playerTagComponent, MotorcycleRailMoveView.SwitchRightTag, new BaseTagComponent.TTagSwitchedCallback(this.OnSwitchRightTagChanged), true);
		}

		// Token: 0x0603E496 RID: 255126 RVA: 0x00FE7064 File Offset: 0x00FE5264
		private void RemoveEntityEvents()
		{
			foreach (ITagTask tagTask in this.TagTaskList)
			{
				tagTask.EndTask();
			}
			this.TagTaskList.Clear();
		}

		// Token: 0x0603E497 RID: 255127 RVA: 0x00FE70C0 File Offset: 0x00FE52C0
		private void ListenForTagAddOrRemove(BaseTagComponent tagComponent, int tagId, BaseTagComponent.TTagSwitchedCallback callback, bool checkExistImmediately = false)
		{
			if (checkExistImmediately && tagComponent.HasTag(tagId))
			{
				callback(tagId, true);
			}
			ITagTask tagTask = tagComponent.ListenForTagAddOrRemove(new int?(tagId), callback, null);
			if (tagTask != null)
			{
				this.TagTaskList.Add(tagTask);
			}
		}

		// Token: 0x0603E498 RID: 255128 RVA: 0x00FE7100 File Offset: 0x00FE5300
		private void OnSwitchLeftTagChanged(int tagId, bool tagExist)
		{
			this.SkillItemList[0].SetCustomSkillItemEnable(tagExist);
			this.SkillItemList[0].SetCustomDynamicEffectId(tagExist ? 1003 : 0);
		}

		// Token: 0x0603E499 RID: 255129 RVA: 0x00FE7130 File Offset: 0x00FE5330
		private void OnSwitchRightTagChanged(int tagId, bool tagExist)
		{
			this.SkillItemList[1].SetCustomSkillItemEnable(tagExist);
			this.SkillItemList[1].SetCustomDynamicEffectId(tagExist ? 1003 : 0);
		}

		// Token: 0x0603E49A RID: 255130 RVA: 0x00FE7160 File Offset: 0x00FE5360
		protected override void OnTick(float delta)
		{
			foreach (MoveSkillItem moveSkillItem in this.SkillItemList)
			{
				moveSkillItem.Tick(delta);
			}
		}

		// Token: 0x04022E92 RID: 142994
		[StaticVariableRuleIgnore]
		private static readonly string[] ActionNameList = new string[]
		{
			"向左移动",
			"向右移动"
		};

		// Token: 0x04022E93 RID: 142995
		[StaticVariableRuleIgnore]
		private static readonly int SwitchLeftTag = GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.滑轨.能够左跳"];

		// Token: 0x04022E94 RID: 142996
		[StaticVariableRuleIgnore]
		private static readonly int SwitchRightTag = GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.滑轨.能够右跳"];

		// Token: 0x04022E95 RID: 142997
		private const int EFFECT_ID = 1003;

		// Token: 0x04022E96 RID: 142998
		private readonly List<MoveSkillItem> SkillItemList = new List<MoveSkillItem>();

		// Token: 0x04022E97 RID: 142999
		private readonly List<ITagTask> TagTaskList = new List<ITagTask>();

		// Token: 0x0200C14E RID: 49486
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B86A RID: 243818
			SwitchLeftBtn,
			// Token: 0x0403B86B RID: 243819
			SwitchRightBtn
		}
	}
}
