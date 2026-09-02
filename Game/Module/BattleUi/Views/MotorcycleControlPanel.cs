using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkillButtonUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200607F RID: 24703
	public class MotorcycleControlPanel : MotorcycleControlPanelBase
	{
		// Token: 0x0603E4D0 RID: 255184 RVA: 0x00FE8690 File Offset: 0x00FE6890
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E4D1 RID: 255185 RVA: 0x00FE873C File Offset: 0x00FE693C
		protected override UniTask OnBeforeStartAsync()
		{
			MotorcycleControlPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleControlPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4D2 RID: 255186 RVA: 0x00FE8780 File Offset: 0x00FE6980
		public UniTask NewAllKeyItems()
		{
			MotorcycleControlPanel.<NewAllKeyItems>d__6 <NewAllKeyItems>d__;
			<NewAllKeyItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAllKeyItems>d__.<>4__this = this;
			<NewAllKeyItems>d__.<>1__state = -1;
			<NewAllKeyItems>d__.<>t__builder.Start<MotorcycleControlPanel.<NewAllKeyItems>d__6>(ref <NewAllKeyItems>d__);
			return <NewAllKeyItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4D3 RID: 255187 RVA: 0x00FE87C4 File Offset: 0x00FE69C4
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<InputMultiKeyItemGroup> NewKeyItem(AActor rootActor, int inputIndex)
		{
			MotorcycleControlPanel.<NewKeyItem>d__7 <NewKeyItem>d__;
			<NewKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<InputMultiKeyItemGroup>.Create();
			<NewKeyItem>d__.<>4__this = this;
			<NewKeyItem>d__.rootActor = rootActor;
			<NewKeyItem>d__.<>1__state = -1;
			<NewKeyItem>d__.<>t__builder.Start<MotorcycleControlPanel.<NewKeyItem>d__7>(ref <NewKeyItem>d__);
			return <NewKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4D4 RID: 255188 RVA: 0x00FE880F File Offset: 0x00FE6A0F
		private void RefreshAllKeyItems()
		{
			this.RefreshDrift();
			this.RefreshBulletJump();
			this.RefreshGetOff();
		}

		// Token: 0x0603E4D5 RID: 255189 RVA: 0x00FE8823 File Offset: 0x00FE6A23
		private void RefreshDrift()
		{
			this.RefreshKeyItem(0, ESkillButtonType.跳跃, "载具漂移", "HotKeyText_MotorDrift_Name", null, null);
		}

		// Token: 0x0603E4D6 RID: 255190 RVA: 0x00FE8839 File Offset: 0x00FE6A39
		private void RefreshBulletJump()
		{
			this.RefreshKeyItem(1, ESkillButtonType.技能1, "载具子弹跳", null, "载具子弹跳1", "HotKeyText_MotorJump_Name");
		}

		// Token: 0x0603E4D7 RID: 255191 RVA: 0x00FE8853 File Offset: 0x00FE6A53
		private void RefreshGetOff()
		{
			this.RefreshKeyItem(2, ESkillButtonType.大招, "载具退场技和下车", "HotKeyText_MotorOff_Name", null, null);
		}

		// Token: 0x0603E4D8 RID: 255192 RVA: 0x00FE886C File Offset: 0x00FE6A6C
		[NullableContext(2)]
		private void RefreshKeyItem(int index, ESkillButtonType buttonType, [Nullable(1)] string actionName, string descId = null, string actionName2 = null, string descId2 = null)
		{
			InputMultiKeyItemGroup inputMultiKeyItemGroup = this.KeyItemList[index];
			InputActionOrAxisKeyItemGroup inputActionOrAxisKeyItemGroup = new InputActionOrAxisKeyItemGroup();
			inputActionOrAxisKeyItemGroup.SingleActionOrAxisKeyItem = new InputActionOrAxisKeyItem
			{
				ActionOrAxisName = actionName,
				DescriptionId = descId,
				Index = new int?(0)
			};
			InputActionOrAxisKeyItem doubleActionOrAxisKeyItem;
			if (string.IsNullOrEmpty(actionName2))
			{
				doubleActionOrAxisKeyItem = null;
			}
			else
			{
				InputActionOrAxisKeyItem inputActionOrAxisKeyItem = new InputActionOrAxisKeyItem();
				inputActionOrAxisKeyItem.ActionOrAxisName = actionName2;
				inputActionOrAxisKeyItem.DescriptionId = descId2;
				doubleActionOrAxisKeyItem = inputActionOrAxisKeyItem;
				inputActionOrAxisKeyItem.Index = new int?(0);
			}
			inputActionOrAxisKeyItemGroup.DoubleActionOrAxisKeyItem = doubleActionOrAxisKeyItem;
			inputActionOrAxisKeyItemGroup.LinkString = "/";
			InputActionOrAxisKeyItemGroup inputActionOrAxisKeyItemGroup2 = inputActionOrAxisKeyItemGroup;
			inputMultiKeyItemGroup.Refresh(inputActionOrAxisKeyItemGroup2);
			this.RefreshKeyItemVisibleByButtonType(buttonType, index);
		}

		// Token: 0x0603E4D9 RID: 255193 RVA: 0x00FE8900 File Offset: 0x00FE6B00
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			foreach (InputMultiKeyItemGroup inputMultiKeyItemGroup in this.KeyItemList)
			{
				inputMultiKeyItemGroup.Destroy(null);
			}
			this.KeyItemList.Clear();
			this.RemoveEvents();
		}

		// Token: 0x0603E4DA RID: 255194 RVA: 0x00FE8968 File Offset: 0x00FE6B68
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiMotorcycleBulletJumpChanged, new Action(this.OnMotorcycleBulletJumpChanged));
			Singleton<EventSystem>.Instance.Add<ESkillButtonRefreshReason>(EEventName.OnSkillButtonDataRefresh, new Action<ESkillButtonRefreshReason>(this.OnSkillButtonDataRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType, int>(EEventName.OnSkillButtonEnableRefresh, new Action<ESkillButtonType, int>(this.OnSkillButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSkillButtonPanelVisibleChange, new Action(this.OnSkillButtonPanelVisibleChange));
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.BattleUiMotorcycleFlyTagChanged, new Action<int, bool>(this.OnMotorFlyStateChanged));
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.BattleUiMotorcycleCannonTagChanged, new Action<int, bool>(this.OnMotorCannonTagChanged));
		}

		// Token: 0x0603E4DB RID: 255195 RVA: 0x00FE8A3C File Offset: 0x00FE6C3C
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleBulletJumpChanged, new Action(this.OnMotorcycleBulletJumpChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonDataRefresh, new Action<ESkillButtonRefreshReason>(this.OnSkillButtonDataRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonEnableRefresh, new Action<ESkillButtonType, int>(this.OnSkillButtonEnableRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonPanelVisibleChange, new Action(this.OnSkillButtonPanelVisibleChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleFlyTagChanged, new Action<int, bool>(this.OnMotorFlyStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleCannonTagChanged, new Action<int, bool>(this.OnMotorCannonTagChanged));
		}

		// Token: 0x0603E4DC RID: 255196 RVA: 0x00FE8B0D File Offset: 0x00FE6D0D
		private void OnMotorcycleBulletJumpChanged()
		{
			this.RefreshAllKeyItems();
		}

		// Token: 0x0603E4DD RID: 255197 RVA: 0x00FE8B15 File Offset: 0x00FE6D15
		private void OnSkillButtonDataRefresh(ESkillButtonRefreshReason eSkillButtonRefreshReason)
		{
			this.RefreshAllKeyItems();
		}

		// Token: 0x0603E4DE RID: 255198 RVA: 0x00FE8B1D File Offset: 0x00FE6D1D
		private void OnSkillButtonEnableRefresh(ESkillButtonType buttonType, int extendCoolDown)
		{
			this.RefreshKeyItemByButtonType(buttonType);
		}

		// Token: 0x0603E4DF RID: 255199 RVA: 0x00FE8B26 File Offset: 0x00FE6D26
		private void OnSkillButtonCdRefresh(ESkillButtonType buttonType)
		{
			this.RefreshKeyItemByButtonType(buttonType);
		}

		// Token: 0x0603E4E0 RID: 255200 RVA: 0x00FE8B2F File Offset: 0x00FE6D2F
		private void OnSkillButtonPanelVisibleChange()
		{
			base.SetVisible(1, ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.SkillButton));
		}

		// Token: 0x0603E4E1 RID: 255201 RVA: 0x00FE8B49 File Offset: 0x00FE6D49
		private void OnMotorFlyStateChanged(int tagId, bool tagExists)
		{
			if (tagId == GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中"])
			{
				this.IsMotorInAir = tagExists;
				this.RefreshKeyItemByButtonType(ESkillButtonType.跳跃);
			}
		}

		// Token: 0x0603E4E2 RID: 255202 RVA: 0x00FE8B6B File Offset: 0x00FE6D6B
		private void OnMotorCannonTagChanged(int tagId, bool tagExists)
		{
			if (tagId == GameplayTagDefine.EGameplayTagId["载具.摩托.浮游炮.自动开启"])
			{
				this.IsCanonState = tagExists;
				this.RefreshKeyItemByButtonType(ESkillButtonType.技能1);
			}
		}

		// Token: 0x0603E4E3 RID: 255203 RVA: 0x00FE8B8D File Offset: 0x00FE6D8D
		private void RefreshKeyItemByButtonType(ESkillButtonType buttonType)
		{
			if (buttonType == ESkillButtonType.跳跃)
			{
				this.RefreshKeyItemVisibleByButtonType(buttonType, 0);
				return;
			}
			if (buttonType == ESkillButtonType.技能1)
			{
				this.RefreshKeyItemVisibleByButtonType(buttonType, 1);
				return;
			}
			if (buttonType == ESkillButtonType.大招)
			{
				this.RefreshKeyItemVisibleByButtonType(buttonType, 2);
			}
		}

		// Token: 0x0603E4E4 RID: 255204 RVA: 0x00FE8BB8 File Offset: 0x00FE6DB8
		private void RefreshKeyItemVisibleByButtonType(ESkillButtonType buttonType, int index)
		{
			bool active;
			if (!ModelBase<BattleUiModel>.Instance.MotorcycleData.IsShowBulletJumpLeftClick)
			{
				active = false;
			}
			else if (buttonType == ESkillButtonType.跳跃 && this.IsMotorInAir)
			{
				active = false;
			}
			else if (buttonType == ESkillButtonType.技能1 && this.IsCanonState)
			{
				active = false;
			}
			else
			{
				SkillButtonData skillButtonDataByButton = ModelBase<SkillButtonUiModel>.Instance.GetSkillButtonDataByButton(buttonType);
				active = (skillButtonDataByButton != null && skillButtonDataByButton.IsEnable());
			}
			this.KeyItemList[index].SetActive(active);
		}

		// Token: 0x04022EB9 RID: 143033
		[Nullable(1)]
		private readonly List<InputMultiKeyItemGroup> KeyItemList = new List<InputMultiKeyItemGroup>();

		// Token: 0x04022EBA RID: 143034
		private bool IsMotorInAir;

		// Token: 0x04022EBB RID: 143035
		private bool IsCanonState;

		// Token: 0x0200C15F RID: 49503
		private enum EChildType
		{
			// Token: 0x0403B8AC RID: 243884
			LayoutItem,
			// Token: 0x0403B8AD RID: 243885
			Item1,
			// Token: 0x0403B8AE RID: 243886
			Item2,
			// Token: 0x0403B8AF RID: 243887
			Item3
		}
	}
}
