using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006006 RID: 24582
	[NullableContext(2)]
	[Nullable(0)]
	public class ExecutionPanel : UiPanelBase
	{
		// Token: 0x0603DEB8 RID: 253624 RVA: 0x00FCB964 File Offset: 0x00FC9B64
		[NullableContext(1)]
		public void Init(UUIItem parentItem)
		{
			this.ChildViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			this.ChildVisible = this.ChildViewData.GetChildVisible(EBattleUiChild.BattleHud);
			this.Initialize(parentItem).Forget();
		}

		// Token: 0x0603DEB9 RID: 253625 RVA: 0x00FCB998 File Offset: 0x00FC9B98
		[NullableContext(1)]
		public UniTask Initialize(UUIItem parentItem)
		{
			ExecutionPanel.<Initialize>d__12 <Initialize>d__;
			<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.parentItem = parentItem;
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<ExecutionPanel.<Initialize>d__12>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x0603DEBA RID: 253626 RVA: 0x00FCB9E4 File Offset: 0x00FC9BE4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DEBB RID: 253627 RVA: 0x00FCBA6E File Offset: 0x00FC9C6E
		public UUIItem GetExecutionItem()
		{
			if (!base.IsShowOrShowing)
			{
				return null;
			}
			return base.GetItem(0);
		}

		// Token: 0x0603DEBC RID: 253628 RVA: 0x00FCBA84 File Offset: 0x00FC9C84
		protected override UniTask OnBeforeStartAsync()
		{
			ExecutionPanel.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ExecutionPanel.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DEBD RID: 253629 RVA: 0x00FCBAC8 File Offset: 0x00FC9CC8
		[NullableContext(0)]
		private UniTask<bool> NewSkillItem()
		{
			ExecutionPanel.<NewSkillItem>d__16 <NewSkillItem>d__;
			<NewSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<NewSkillItem>d__.<>4__this = this;
			<NewSkillItem>d__.<>1__state = -1;
			<NewSkillItem>d__.<>t__builder.Start<ExecutionPanel.<NewSkillItem>d__16>(ref <NewSkillItem>d__);
			return <NewSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603DEBE RID: 253630 RVA: 0x00FCBB0B File Offset: 0x00FC9D0B
		protected override void OnStart()
		{
			this.InitTweenAnim(1);
			this.InitTweenAnim(2);
		}

		// Token: 0x0603DEBF RID: 253631 RVA: 0x00FCBB1B File Offset: 0x00FC9D1B
		protected override void OnAfterShow()
		{
			this.StopTweenAnim(2);
			this.PlayTweenAnim(1);
		}

		// Token: 0x0603DEC0 RID: 253632 RVA: 0x00FCBB2C File Offset: 0x00FC9D2C
		protected override UniTask OnBeforeHideAsync()
		{
			ExecutionPanel.<OnBeforeHideAsync>d__19 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<ExecutionPanel.<OnBeforeHideAsync>d__19>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DEC1 RID: 253633 RVA: 0x00FCBB6F File Offset: 0x00FC9D6F
		private void OnCloseAnimTimerEnd(float _)
		{
			this.CloseTimer = null;
			this.Promise.SetResult();
			this.Promise = null;
		}

		// Token: 0x0603DEC2 RID: 253634 RVA: 0x00FCBB8C File Offset: 0x00FC9D8C
		protected override void OnBeforeDestroy()
		{
			if (this.CloseTimer != null)
			{
				TimerSystem.Instance.Remove(this.CloseTimer);
				this.CloseTimer = null;
				this.Promise.SetResult();
			}
			ExecutionItem skillItem = this.SkillItem;
			if (skillItem != null)
			{
				skillItem.Destroy(null);
			}
			this.SkillItem = null;
			this.RemoveEvents();
		}

		// Token: 0x0603DEC3 RID: 253635 RVA: 0x00FCBBE4 File Offset: 0x00FC9DE4
		private void AddEvents()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<InputDistributeController>.Instance.BindAction("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
			this.ChildViewData.AddCallback(EBattleUiChild.BattleHud, new Action(this.OnBattleChildVisibleChanged));
		}

		// Token: 0x0603DEC4 RID: 253636 RVA: 0x00FCBC34 File Offset: 0x00FC9E34
		private void RemoveEvents()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<InputDistributeController>.Instance.UnBindAction("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
			this.ChildViewData.RemoveCallback(EBattleUiChild.BattleHud, new Action(this.OnBattleChildVisibleChanged));
		}

		// Token: 0x0603DEC5 RID: 253637 RVA: 0x00FCBC81 File Offset: 0x00FC9E81
		[NullableContext(1)]
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType == InputDistributeDefine.EActionType.Release)
			{
				this.OnInteract();
			}
		}

		// Token: 0x0603DEC6 RID: 253638 RVA: 0x00FCBC90 File Offset: 0x00FC9E90
		private void OnInteract()
		{
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null || !entityHandle.Valid)
			{
				this.RemoveEntityEvents();
				this.EntityHandle = null;
				base.Hide(null);
				return;
			}
			ExecutionItem skillItem = this.SkillItem;
			if (skillItem != null)
			{
				skillItem.OnInputAction(false);
			}
			PawnInteractBaseComponent component = this.EntityHandle.Entity.GetComponent<PawnInteractBaseComponent>();
			if (component == null || !component.IsPawnInteractive())
			{
				return;
			}
			component.InteractPawn(-1, null);
		}

		// Token: 0x0603DEC7 RID: 253639 RVA: 0x00FCBD08 File Offset: 0x00FC9F08
		private void OnBattleChildVisibleChanged()
		{
			this.ChildVisible = this.ChildViewData.GetChildVisible(EBattleUiChild.BattleHud);
			if (this.ChildVisible)
			{
				EntityHandle entityHandle = this.EntityHandle;
				if (entityHandle != null && entityHandle.Valid && !base.IsShowOrShowing)
				{
					base.Show(null);
					return;
				}
			}
			else if (!base.IsHideOrHiding)
			{
				base.Hide(null);
			}
		}

		// Token: 0x0603DEC8 RID: 253640 RVA: 0x00FCBD64 File Offset: 0x00FC9F64
		private void InitTweenAnim(int componentType)
		{
			TArray<UActorComponent> tarray = base.GetItem(componentType).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			List<ULGUIPlayTweenComponent> list = new List<ULGUIPlayTweenComponent>(tarray.Count);
			foreach (UActorComponent uactorComponent in tarray)
			{
				list.Add((ULGUIPlayTweenComponent)uactorComponent);
			}
			if (this.TweenAnimMap == null)
			{
				this.TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();
			}
			this.TweenAnimMap[componentType] = list;
		}

		// Token: 0x0603DEC9 RID: 253641 RVA: 0x00FCBDF8 File Offset: 0x00FC9FF8
		private void PlayTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap != null && this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Play();
				}
			}
		}

		// Token: 0x0603DECA RID: 253642 RVA: 0x00FCBE5C File Offset: 0x00FCA05C
		private void StopTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap != null && this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Stop();
				}
			}
		}

		// Token: 0x0603DECB RID: 253643 RVA: 0x00FCBEC0 File Offset: 0x00FCA0C0
		public void ShowByEntity(int entityId, ECustomOptionType? optionType)
		{
			ECustomOptionType? optionType2 = this.OptionType;
			ECustomOptionType? ecustomOptionType = optionType;
			if (!(optionType2.GetValueOrDefault() == ecustomOptionType.GetValueOrDefault() & optionType2 != null == (ecustomOptionType != null)))
			{
				this.OptionType = optionType;
				if (this.OptionType.GetValueOrDefault() == ECustomOptionType.Execution)
				{
					ExecutionItem skillItem = this.SkillItem;
					if (skillItem != null)
					{
						skillItem.RefreshSkillIconByResId("SP_IconPutDeath");
					}
				}
				else if (this.OptionType.GetValueOrDefault() == ECustomOptionType.BreakWeakness)
				{
					ExecutionItem skillItem2 = this.SkillItem;
					if (skillItem2 != null)
					{
						skillItem2.RefreshSkillIconByResId("T_MstSkil_1002_UI");
					}
				}
			}
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle != null && entityHandle.Id == entityId)
			{
				return;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
			if (entityById == null)
			{
				this.OnRemove();
				return;
			}
			this.RemoveEntityEvents();
			this.EntityHandle = entityById;
			this.OnAdd();
		}

		// Token: 0x0603DECC RID: 253644 RVA: 0x00FCBF8B File Offset: 0x00FCA18B
		public void HideByEntity(int entityId)
		{
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null || entityHandle.Id != entityId)
			{
				return;
			}
			this.OnRemove();
		}

		// Token: 0x0603DECD RID: 253645 RVA: 0x00FCBFAE File Offset: 0x00FCA1AE
		private void OnAdd()
		{
			this.AddEntityEvents();
			if (!base.IsShowOrShowing && this.ChildVisible)
			{
				base.Show(null);
			}
			ModelBase<BattleUiModel>.Instance.SetExecutionInteractEnable(true);
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.Custom, EBattleUiChild.InteractionHint, false, true, 0);
		}

		// Token: 0x0603DECE RID: 253646 RVA: 0x00FCBFEE File Offset: 0x00FCA1EE
		private void OnRemove()
		{
			this.RemoveEntityEvents();
			this.EntityHandle = null;
			if (!base.IsHideOrHiding)
			{
				base.Hide(null);
			}
			ModelBase<BattleUiModel>.Instance.SetExecutionInteractEnable(false);
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.Custom, EBattleUiChild.InteractionHint, true, true, 0);
		}

		// Token: 0x0603DECF RID: 253647 RVA: 0x00FCC02D File Offset: 0x00FCA22D
		private void AddEntityEvents()
		{
			if (this.EntityHandle == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}

		// Token: 0x0603DED0 RID: 253648 RVA: 0x00FCC05A File Offset: 0x00FCA25A
		private void RemoveEntityEvents()
		{
			if (this.EntityHandle == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}

		// Token: 0x0603DED1 RID: 253649 RVA: 0x00FCC087 File Offset: 0x00FCA287
		[NullableContext(1)]
		private void OnRemoveEntity(ERemoveEntityType eRemoveEntityType, EntityHandle entityHandle)
		{
			this.OnRemove();
		}

		// Token: 0x04022BBE RID: 142270
		private const float CLOSE_ANIM_TIME = 300f;

		// Token: 0x04022BBF RID: 142271
		private const EBattleUiChild ChildType = EBattleUiChild.BattleHud;

		// Token: 0x04022BC0 RID: 142272
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap;

		// Token: 0x04022BC1 RID: 142273
		private EntityHandle EntityHandle;

		// Token: 0x04022BC2 RID: 142274
		private ExecutionItem SkillItem;

		// Token: 0x04022BC3 RID: 142275
		private TimerHandle CloseTimer;

		// Token: 0x04022BC4 RID: 142276
		private CustomPromise Promise;

		// Token: 0x04022BC5 RID: 142277
		private BattleUiChildViewData ChildViewData;

		// Token: 0x04022BC6 RID: 142278
		private bool ChildVisible = true;

		// Token: 0x04022BC7 RID: 142279
		private ECustomOptionType? OptionType = new ECustomOptionType?(ECustomOptionType.Execution);

		// Token: 0x0200C09A RID: 49306
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B4CD RID: 242893
			SkillItem,
			// Token: 0x0403B4CE RID: 242894
			AnimStart,
			// Token: 0x0403B4CF RID: 242895
			AnimClose
		}
	}
}
