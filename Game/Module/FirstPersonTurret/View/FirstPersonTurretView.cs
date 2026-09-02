using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Gamepad;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FirstPersonTurret.View
{
	// Token: 0x02005D86 RID: 23942
	[NullableContext(1)]
	[Nullable(0)]
	public class FirstPersonTurretView : UiTickViewBase
	{
		// Token: 0x0603C47E RID: 246910 RVA: 0x00F4BA80 File Offset: 0x00F49C80
		public FirstPersonTurretView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C47F RID: 246911 RVA: 0x00F4BAA0 File Offset: 0x00F49CA0
		protected unsafe override void OnRegisterComponent()
		{
			int num;
			Span<ValueTuple<int, Type>> span;
			int num2;
			if (Singleton<Info>.Instance.IsInTouch())
			{
				num = 8;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
				this.ComponentRegisterInfos = list;
				return;
			}
			num2 = 7;
			List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
			span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
			num = 0;
			*span[num] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num++;
			*span[num] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num++;
			*span[num] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num++;
			*span[num] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num++;
			*span[num] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list2;
		}

		// Token: 0x0603C480 RID: 246912 RVA: 0x00F4BCE0 File Offset: 0x00F49EE0
		protected override UniTask OnBeforeStartAsync()
		{
			FirstPersonTurretView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FirstPersonTurretView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C481 RID: 246913 RVA: 0x00F4BD24 File Offset: 0x00F49F24
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<ESkillButtonRefreshReason>(EEventName.OnSkillButtonDataRefresh, new Action<ESkillButtonRefreshReason>(this.OnSkillButtonDataRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType, int>(EEventName.OnSkillButtonEnableRefresh, new Action<ESkillButtonType, int>(this.OnSkillButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonVisibleRefresh, new Action<ESkillButtonType>(this.OnSkillButtonVisibleRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonDynamicEffectRefresh, new Action<ESkillButtonType>(this.OnSkillButtonDynamicEffectRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType, int, int>(EEventName.OnSkillButtonCustomRefresh, new Action<ESkillButtonType, int, int>(this.OnSkillButtonCustomRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonSkillIdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonSkillIdRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonAttributeRefresh, new Action<ESkillButtonType>(this.OnSkillButtonAttributeRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonIconPathRefresh, new Action<ESkillButtonType>(this.OnSkillButtonIconPathRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonLongPressRefresh, new Action<ESkillButtonType>(this.OnSkillButtonLongPressRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonExtraEffectRefresh, new Action<ESkillButtonType>(this.OnSkillButtonExtraEffectRefresh));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		}

		// Token: 0x0603C482 RID: 246914 RVA: 0x00F4BE84 File Offset: 0x00F4A084
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonDataRefresh, new Action<ESkillButtonRefreshReason>(this.OnSkillButtonDataRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonEnableRefresh, new Action<ESkillButtonType, int>(this.OnSkillButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonVisibleRefresh, new Action<ESkillButtonType>(this.OnSkillButtonVisibleRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonDynamicEffectRefresh, new Action<ESkillButtonType>(this.OnSkillButtonDynamicEffectRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonCustomRefresh, new Action<ESkillButtonType, int, int>(this.OnSkillButtonCustomRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonSkillIdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonSkillIdRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonAttributeRefresh, new Action<ESkillButtonType>(this.OnSkillButtonAttributeRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonIconPathRefresh, new Action<ESkillButtonType>(this.OnSkillButtonIconPathRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonLongPressRefresh, new Action<ESkillButtonType>(this.OnSkillButtonLongPressRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonExtraEffectRefresh, new Action<ESkillButtonType>(this.OnSkillButtonExtraEffectRefresh));
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		}

		// Token: 0x0603C483 RID: 246915 RVA: 0x00F4BFE1 File Offset: 0x00F4A1E1
		protected override void OnAfterShow()
		{
			this.RefreshGamepadPsFeedback();
		}

		// Token: 0x0603C484 RID: 246916 RVA: 0x00F4BFEC File Offset: 0x00F4A1EC
		protected override void OnTick(float delta)
		{
			this.InitPlayerData();
			this.RefreshKscPlayerHp();
			FirstPersonTurretRoleHpPanel roleHpPanel = this.RoleHpPanel;
			if (roleHpPanel != null)
			{
				roleHpPanel.Tick(delta);
			}
			foreach (FirstPersonTurretSkillItem firstPersonTurretSkillItem in this.SkillItemList)
			{
				firstPersonTurretSkillItem.Tick(delta);
			}
		}

		// Token: 0x0603C485 RID: 246917 RVA: 0x00F4C05C File Offset: 0x00F4A25C
		protected override void OnBeforeDestroy()
		{
			ControllerBase<GamepadController>.Instance.RemoveFeedbackReason(EGamepadPsFeedbackReason.FirstPersonTurret);
			this.RoleHpPanel = null;
			foreach (FirstPersonTurretSkillItem firstPersonTurretSkillItem in this.SkillItemList)
			{
				firstPersonTurretSkillItem.RestoreActionInput();
				firstPersonTurretSkillItem.Destroy(null);
			}
			this.SkillItemList.Clear();
			this.SkillItemMap.Clear();
			this.ClearKscPlayerData();
		}

		// Token: 0x0603C486 RID: 246918 RVA: 0x00F4C0E4 File Offset: 0x00F4A2E4
		private UniTask CreateRoleHpPanelAsync()
		{
			FirstPersonTurretView.<CreateRoleHpPanelAsync>d__17 <CreateRoleHpPanelAsync>d__;
			<CreateRoleHpPanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateRoleHpPanelAsync>d__.<>4__this = this;
			<CreateRoleHpPanelAsync>d__.<>1__state = -1;
			<CreateRoleHpPanelAsync>d__.<>t__builder.Start<FirstPersonTurretView.<CreateRoleHpPanelAsync>d__17>(ref <CreateRoleHpPanelAsync>d__);
			return <CreateRoleHpPanelAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C487 RID: 246919 RVA: 0x00F4C127 File Offset: 0x00F4A327
		private void ClearKscPlayerData()
		{
			this.AttrMap = null;
			this.LastSyncHp = null;
			this.LastSyncMaxHp = null;
		}

		// Token: 0x0603C488 RID: 246920 RVA: 0x00F4C148 File Offset: 0x00F4A348
		private void InitPlayerData()
		{
			KscSubModelBase curSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
			AKSC_Entity aksc_Entity = (curSubModel != null) ? curSubModel.KscPlayerEntity : null;
			if (aksc_Entity == null)
			{
				this.AttrMap = null;
				return;
			}
			UKSC_SkillComp skillComp = aksc_Entity.GetSkillComp();
			TMap<EKSC_AttrType, int> tmap;
			if (skillComp == null)
			{
				tmap = null;
			}
			else
			{
				UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
				tmap = ((attrSet_ != null) ? attrSet_.Attrs_ : null);
			}
			TMap<EKSC_AttrType, int> tmap2 = tmap;
			if (tmap2 == null)
			{
				this.AttrMap = null;
				return;
			}
			this.AttrMap = tmap2;
		}

		// Token: 0x0603C489 RID: 246921 RVA: 0x00F4C1A8 File Offset: 0x00F4A3A8
		private void RefreshKscPlayerHp()
		{
			if (this.AttrMap == null)
			{
				return;
			}
			int num;
			int hp = this.AttrMap.TryGetValue(EKSC_AttrType.Life, out num) ? num : 0;
			int num2;
			int maxHp = this.AttrMap.TryGetValue(EKSC_AttrType.LifeMax, out num2) ? num2 : 0;
			this.TrySyncKscPlayerHp(hp, maxHp);
		}

		// Token: 0x0603C48A RID: 246922 RVA: 0x00F4C1F0 File Offset: 0x00F4A3F0
		private void TrySyncKscPlayerHp(int hp, int maxHp)
		{
			int? num = this.LastSyncHp;
			if (num.GetValueOrDefault() == hp & num != null)
			{
				num = this.LastSyncMaxHp;
				if (num.GetValueOrDefault() == maxHp & num != null)
				{
					return;
				}
			}
			this.LastSyncHp = new int?(hp);
			this.LastSyncMaxHp = new int?(maxHp);
			FirstPersonTurretRoleHpPanel roleHpPanel = this.RoleHpPanel;
			if (roleHpPanel == null)
			{
				return;
			}
			roleHpPanel.Refresh((float)this.LastSyncHp.Value, (float)this.LastSyncMaxHp.Value);
		}

		// Token: 0x0603C48B RID: 246923 RVA: 0x00F4C278 File Offset: 0x00F4A478
		private UniTask CreateSkillItemsAsync()
		{
			FirstPersonTurretView.<CreateSkillItemsAsync>d__22 <CreateSkillItemsAsync>d__;
			<CreateSkillItemsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateSkillItemsAsync>d__.<>4__this = this;
			<CreateSkillItemsAsync>d__.<>1__state = -1;
			<CreateSkillItemsAsync>d__.<>t__builder.Start<FirstPersonTurretView.<CreateSkillItemsAsync>d__22>(ref <CreateSkillItemsAsync>d__);
			return <CreateSkillItemsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C48C RID: 246924 RVA: 0x00F4C2BC File Offset: 0x00F4A4BC
		private UniTask CreateSkillItemAsync([Nullable(2)] UUIButtonComponent button, FirstPersonTurretSkillItemParam param)
		{
			FirstPersonTurretView.<CreateSkillItemAsync>d__23 <CreateSkillItemAsync>d__;
			<CreateSkillItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateSkillItemAsync>d__.<>4__this = this;
			<CreateSkillItemAsync>d__.button = button;
			<CreateSkillItemAsync>d__.param = param;
			<CreateSkillItemAsync>d__.<>1__state = -1;
			<CreateSkillItemAsync>d__.<>t__builder.Start<FirstPersonTurretView.<CreateSkillItemAsync>d__23>(ref <CreateSkillItemAsync>d__);
			return <CreateSkillItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C48D RID: 246925 RVA: 0x00F4C30F File Offset: 0x00F4A50F
		private void RefreshAllSkillItems()
		{
			this.RefreshSkillItemsByButtonType(ESkillButtonType.攻击);
			this.RefreshSkillItemsByButtonType(ESkillButtonType.技能1);
			this.RefreshSkillItemsByButtonType(ESkillButtonType.大招);
		}

		// Token: 0x0603C48E RID: 246926 RVA: 0x00F4C328 File Offset: 0x00F4A528
		private void RefreshSkillItemsByButtonType(ESkillButtonType buttonType)
		{
			this.ForEachSkillItem(buttonType, delegate(FirstPersonTurretSkillItem skillItem)
			{
				SkillButtonData skillButtonDataByButton = ModelBase<SkillButtonUiModel>.Instance.GetSkillButtonDataByButton(buttonType);
				if (skillButtonDataByButton == null || skillButtonDataByButton.GetSkillId() == 0)
				{
					skillItem.Deactivate();
					return;
				}
				skillItem.Refresh(skillButtonDataByButton);
			});
		}

		// Token: 0x0603C48F RID: 246927 RVA: 0x00F4C35C File Offset: 0x00F4A55C
		private void ForEachSkillItem(ESkillButtonType buttonType, Action<FirstPersonTurretSkillItem> callback)
		{
			List<FirstPersonTurretSkillItem> list;
			if (!this.SkillItemMap.TryGetValue(buttonType, out list))
			{
				return;
			}
			foreach (FirstPersonTurretSkillItem obj in list)
			{
				callback(obj);
			}
		}

		// Token: 0x0603C490 RID: 246928 RVA: 0x00F4C3BC File Offset: 0x00F4A5BC
		private void OnSignoutClicked()
		{
			Action onExitClicked = this.OnExitClicked;
			if (onExitClicked == null)
			{
				return;
			}
			onExitClicked();
		}

		// Token: 0x0603C491 RID: 246929 RVA: 0x00F4C3CE File Offset: 0x00F4A5CE
		private void RefreshGamepadPsFeedback()
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				ControllerBase<GamepadController>.Instance.TryAddFeedbackReason(EGamepadPsFeedbackReason.FirstPersonTurret, "FirstPersonTurret");
				return;
			}
			ControllerBase<GamepadController>.Instance.RemoveFeedbackReason(EGamepadPsFeedbackReason.FirstPersonTurret);
		}

		// Token: 0x0603C492 RID: 246930 RVA: 0x00F4C3F8 File Offset: 0x00F4A5F8
		private void OnInputControllerChange(EInputControllerType _1, EInputControllerType _2)
		{
			this.RefreshGamepadPsFeedback();
		}

		// Token: 0x0603C493 RID: 246931 RVA: 0x00F4C400 File Offset: 0x00F4A600
		private void OnSkillButtonDataRefresh(ESkillButtonRefreshReason refreshReason)
		{
			this.RefreshAllSkillItems();
		}

		// Token: 0x0603C494 RID: 246932 RVA: 0x00F4C408 File Offset: 0x00F4A608
		private void OnSkillButtonEnableRefresh(ESkillButtonType buttonType, int extendCoolDown)
		{
			this.ForEachSkillItem(buttonType, delegate(FirstPersonTurretSkillItem skillItem)
			{
				if (skillItem.GetSkillButtonData() == null)
				{
					return;
				}
				skillItem.RefreshEnable(false);
			});
		}

		// Token: 0x0603C495 RID: 246933 RVA: 0x00F4C430 File Offset: 0x00F4A630
		private void OnSkillButtonVisibleRefresh(ESkillButtonType buttonType)
		{
			this.ForEachSkillItem(buttonType, delegate(FirstPersonTurretSkillItem skillItem)
			{
				if (skillItem.GetSkillButtonData() == null)
				{
					return;
				}
				skillItem.RefreshVisible();
				skillItem.RefreshKey();
			});
		}

		// Token: 0x0603C496 RID: 246934 RVA: 0x00F4C458 File Offset: 0x00F4A658
		private void OnSkillButtonDynamicEffectRefresh(ESkillButtonType buttonType)
		{
			this.ForEachSkillItem(buttonType, delegate(FirstPersonTurretSkillItem skillItem)
			{
				if (skillItem.GetSkillButtonData() == null)
				{
					return;
				}
				skillItem.RefreshDynamicEffect();
			});
		}

		// Token: 0x0603C497 RID: 246935 RVA: 0x00F4C480 File Offset: 0x00F4A680
		private void OnSkillButtonCustomRefresh(ESkillButtonType buttonType, int from, int param)
		{
			this.ForEachSkillItem(buttonType, delegate(FirstPersonTurretSkillItem skillItem)
			{
				if (skillItem.GetSkillButtonData() == null)
				{
					return;
				}
				skillItem.RefreshCustomHdData(from, param);
			});
		}

		// Token: 0x0603C498 RID: 246936 RVA: 0x00F4C4B4 File Offset: 0x00F4A6B4
		private void OnSkillButtonSkillIdRefresh(ESkillButtonType buttonType)
		{
			this.RefreshSkillItemsByButtonType(buttonType);
		}

		// Token: 0x0603C499 RID: 246937 RVA: 0x00F4C4BD File Offset: 0x00F4A6BD
		private void OnSkillButtonAttributeRefresh(ESkillButtonType buttonType)
		{
			this.ForEachSkillItem(buttonType, delegate(FirstPersonTurretSkillItem skillItem)
			{
				skillItem.RefreshAttribute(true);
			});
		}

		// Token: 0x0603C49A RID: 246938 RVA: 0x00F4C4E5 File Offset: 0x00F4A6E5
		private void OnSkillButtonIconPathRefresh(ESkillButtonType buttonType)
		{
			this.ForEachSkillItem(buttonType, delegate(FirstPersonTurretSkillItem skillItem)
			{
				skillItem.RefreshSkillIcon();
				skillItem.RefreshSkillName();
			});
		}

		// Token: 0x0603C49B RID: 246939 RVA: 0x00F4C50D File Offset: 0x00F4A70D
		private void OnSkillButtonCdRefresh(ESkillButtonType buttonType)
		{
			this.ForEachSkillItem(buttonType, delegate(FirstPersonTurretSkillItem skillItem)
			{
				skillItem.RefreshSkillCoolDown();
			});
		}

		// Token: 0x0603C49C RID: 246940 RVA: 0x00F4C535 File Offset: 0x00F4A735
		private void OnSkillButtonLongPressRefresh(ESkillButtonType buttonType)
		{
			this.ForEachSkillItem(buttonType, delegate(FirstPersonTurretSkillItem skillItem)
			{
				skillItem.RefreshSkillButtonLongPress();
				skillItem.RefreshConfigLongPress(-1, 0);
			});
		}

		// Token: 0x0603C49D RID: 246941 RVA: 0x00F4C55D File Offset: 0x00F4A75D
		private void OnSkillButtonExtraEffectRefresh(ESkillButtonType buttonType)
		{
			this.ForEachSkillItem(buttonType, delegate(FirstPersonTurretSkillItem skillItem)
			{
				skillItem.RefreshExtraEffect();
			});
		}

		// Token: 0x04021E77 RID: 138871
		[Nullable(2)]
		public Action OnExitClicked;

		// Token: 0x04021E78 RID: 138872
		private const string PS_FEEDBACK_ID = "FirstPersonTurret";

		// Token: 0x04021E79 RID: 138873
		[Nullable(2)]
		private UUIButtonComponent ExitButton;

		// Token: 0x04021E7A RID: 138874
		private readonly List<FirstPersonTurretSkillItem> SkillItemList = new List<FirstPersonTurretSkillItem>();

		// Token: 0x04021E7B RID: 138875
		private readonly Dictionary<ESkillButtonType, List<FirstPersonTurretSkillItem>> SkillItemMap = new Dictionary<ESkillButtonType, List<FirstPersonTurretSkillItem>>();

		// Token: 0x04021E7C RID: 138876
		[Nullable(2)]
		private FirstPersonTurretRoleHpPanel RoleHpPanel;

		// Token: 0x04021E7D RID: 138877
		[Nullable(2)]
		private TMap<EKSC_AttrType, int> AttrMap;

		// Token: 0x04021E7E RID: 138878
		private int? LastSyncHp;

		// Token: 0x04021E7F RID: 138879
		private int? LastSyncMaxHp;
	}
}
