using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006090 RID: 24720
	[NullableContext(1)]
	[Nullable(0)]
	public class RailSlideView : UiTickViewBase
	{
		// Token: 0x0603E5F8 RID: 255480 RVA: 0x00FEE057 File Offset: 0x00FEC257
		public RailSlideView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603E5F9 RID: 255481 RVA: 0x00FEE078 File Offset: 0x00FEC278
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

		// Token: 0x0603E5FA RID: 255482 RVA: 0x00FEE0E4 File Offset: 0x00FEC2E4
		protected override UniTask OnBeforeStartAsync()
		{
			RailSlideView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RailSlideView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E5FB RID: 255483 RVA: 0x00FEE127 File Offset: 0x00FEC327
		protected override void OnStart()
		{
			base.OnStart();
			this.RefreshRoleData();
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnBattleUiCurRoleDataChanged));
		}

		// Token: 0x0603E5FC RID: 255484 RVA: 0x00FEE151 File Offset: 0x00FEC351
		protected override void OnBeforeShow()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.RoleSpecialState, EBattleUiChild.Joystick, false, true, 0);
		}

		// Token: 0x0603E5FD RID: 255485 RVA: 0x00FEE16A File Offset: 0x00FEC36A
		protected override void OnAfterHide()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.RoleSpecialState, EBattleUiChild.Joystick, true, true, 0);
		}

		// Token: 0x0603E5FE RID: 255486 RVA: 0x00FEE184 File Offset: 0x00FEC384
		public UniTask NewAllSkillItems()
		{
			RailSlideView.<NewAllSkillItems>d__15 <NewAllSkillItems>d__;
			<NewAllSkillItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAllSkillItems>d__.<>4__this = this;
			<NewAllSkillItems>d__.<>1__state = -1;
			<NewAllSkillItems>d__.<>t__builder.Start<RailSlideView.<NewAllSkillItems>d__15>(ref <NewAllSkillItems>d__);
			return <NewAllSkillItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603E5FF RID: 255487 RVA: 0x00FEE1C8 File Offset: 0x00FEC3C8
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<MoveSkillItem> NewSkillItem(AActor rootActor, int inputIndex)
		{
			RailSlideView.<NewSkillItem>d__16 <NewSkillItem>d__;
			<NewSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<MoveSkillItem>.Create();
			<NewSkillItem>d__.<>4__this = this;
			<NewSkillItem>d__.rootActor = rootActor;
			<NewSkillItem>d__.inputIndex = inputIndex;
			<NewSkillItem>d__.<>1__state = -1;
			<NewSkillItem>d__.<>t__builder.Start<RailSlideView.<NewSkillItem>d__16>(ref <NewSkillItem>d__);
			return <NewSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E600 RID: 255488 RVA: 0x00FEE21C File Offset: 0x00FEC41C
		private void RefreshAllSkillItems()
		{
			this.SkillItemList[0].RefreshByMoveType(EInputAxis.MoveRight, -1f, false);
			this.SkillItemList[1].RefreshByMoveType(EInputAxis.MoveRight, 1f, false);
			this.SkillItemList[0].RefreshKeyByActionName(RailSlideView.ActionNameList[0]);
			this.SkillItemList[1].RefreshKeyByActionName(RailSlideView.ActionNameList[1]);
		}

		// Token: 0x0603E601 RID: 255489 RVA: 0x00FEE291 File Offset: 0x00FEC491
		protected override void OnAddEventListener()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<InputDistributeController>.Instance.BindActions(RailSlideView.ActionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
		}

		// Token: 0x0603E602 RID: 255490 RVA: 0x00FEE2BA File Offset: 0x00FEC4BA
		protected override void OnRemoveEventListener()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<InputDistributeController>.Instance.UnBindActions(RailSlideView.ActionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
		}

		// Token: 0x0603E603 RID: 255491 RVA: 0x00FEE2E4 File Offset: 0x00FEC4E4
		protected override void OnBeforeDestroy()
		{
			foreach (MoveSkillItem moveSkillItem in this.SkillItemList)
			{
				moveSkillItem.Destroy(null);
			}
			this.SkillItemList.Clear();
			this.RemoveEntityEvents();
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnBattleUiCurRoleDataChanged));
		}

		// Token: 0x0603E604 RID: 255492 RVA: 0x00FEE364 File Offset: 0x00FEC564
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			for (int i = 0; i < RailSlideView.ActionNameList.Length; i++)
			{
				if (actionName == RailSlideView.ActionNameList[i])
				{
					this.SkillItemList[i].OnInputAction(false);
					return;
				}
			}
		}

		// Token: 0x0603E605 RID: 255493 RVA: 0x00FEE3A9 File Offset: 0x00FEC5A9
		private void OnBattleUiCurRoleDataChanged(int i, int i1)
		{
			this.RefreshRoleData();
		}

		// Token: 0x0603E606 RID: 255494 RVA: 0x00FEE3B4 File Offset: 0x00FEC5B4
		private void RefreshRoleData()
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (this.RoleData == curRoleData)
			{
				return;
			}
			this.RemoveEntityEvents();
			this.RoleData = curRoleData;
			this.AddEntityEvents();
		}

		// Token: 0x0603E607 RID: 255495 RVA: 0x00FEE3EC File Offset: 0x00FEC5EC
		private void AddEntityEvents()
		{
			if (this.RoleData == null)
			{
				return;
			}
			BaseTagComponent gameplayTagComponent = this.RoleData.GameplayTagComponent;
			if (gameplayTagComponent == null)
			{
				return;
			}
			this.ListenForTagAddOrRemove(gameplayTagComponent, RailSlideView.Tag1, new BaseTagComponent.TTagSwitchedCallback(this.OnEnableTag1Changed), true);
			this.ListenForTagAddOrRemove(gameplayTagComponent, RailSlideView.Tag2, new BaseTagComponent.TTagSwitchedCallback(this.OnEnableTag2Changed), true);
			this.ListenForTagAddOrRemove(gameplayTagComponent, RailSlideView.ForbidMoveTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnForbidMoveTagIdChanged), true);
		}

		// Token: 0x0603E608 RID: 255496 RVA: 0x00FEE460 File Offset: 0x00FEC660
		private void RemoveEntityEvents()
		{
			foreach (ITagTask tagTask in this.TagTaskList)
			{
				tagTask.EndTask();
			}
			this.TagTaskList.Clear();
			this.RoleData = null;
		}

		// Token: 0x0603E609 RID: 255497 RVA: 0x00FEE4C4 File Offset: 0x00FEC6C4
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

		// Token: 0x0603E60A RID: 255498 RVA: 0x00FEE504 File Offset: 0x00FEC704
		private void OnEnableTag1Changed(int tagId, bool tagExist)
		{
			this.SkillItemList[0].SetCustomDynamicEffectId(tagExist ? 1003 : 0);
		}

		// Token: 0x0603E60B RID: 255499 RVA: 0x00FEE522 File Offset: 0x00FEC722
		private void OnEnableTag2Changed(int tagId, bool tagExist)
		{
			this.SkillItemList[1].SetCustomDynamicEffectId(tagExist ? 1003 : 0);
		}

		// Token: 0x0603E60C RID: 255500 RVA: 0x00FEE540 File Offset: 0x00FEC740
		private void OnForbidMoveTagIdChanged(int tagId, bool tagExist)
		{
			this.SkillItemList[0].SetUiActive(!tagExist);
			this.SkillItemList[1].SetUiActive(!tagExist);
		}

		// Token: 0x0603E60D RID: 255501 RVA: 0x00FEE56C File Offset: 0x00FEC76C
		protected override void OnTick(float delta)
		{
			foreach (MoveSkillItem moveSkillItem in this.SkillItemList)
			{
				moveSkillItem.Tick(delta);
			}
		}

		// Token: 0x04022F48 RID: 143176
		[StaticVariableRuleIgnore]
		private static readonly string[] ActionNameList = new string[]
		{
			"向左移动",
			"向右移动"
		};

		// Token: 0x04022F49 RID: 143177
		[StaticVariableRuleIgnore]
		private static readonly int Tag1 = GameplayTagDefine.EGameplayTagId["关卡.关卡运动.关卡运动类型.滑轨.能够左跳"];

		// Token: 0x04022F4A RID: 143178
		[StaticVariableRuleIgnore]
		private static readonly int Tag2 = GameplayTagDefine.EGameplayTagId["关卡.关卡运动.关卡运动类型.滑轨.能够右跳"];

		// Token: 0x04022F4B RID: 143179
		[StaticVariableRuleIgnore]
		private static readonly int ForbidMoveTagId = GameplayTagDefine.EGameplayTagId["关卡.关卡运动.关卡运动类型.滑轨UI.隐藏跳跃按键"];

		// Token: 0x04022F4C RID: 143180
		private const int EFFECT_ID = 1003;

		// Token: 0x04022F4D RID: 143181
		private readonly List<MoveSkillItem> SkillItemList = new List<MoveSkillItem>();

		// Token: 0x04022F4E RID: 143182
		[Nullable(2)]
		private BattleUiRoleData RoleData;

		// Token: 0x04022F4F RID: 143183
		private readonly List<ITagTask> TagTaskList = new List<ITagTask>();

		// Token: 0x0200C17D RID: 49533
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B953 RID: 244051
			Item1,
			// Token: 0x0403B954 RID: 244052
			Item2
		}
	}
}
