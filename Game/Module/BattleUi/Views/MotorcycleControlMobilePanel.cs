using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200607E RID: 24702
	public class MotorcycleControlMobilePanel : MotorcycleControlPanelBase
	{
		// Token: 0x0603E4C1 RID: 255169 RVA: 0x00FE8338 File Offset: 0x00FE6538
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

		// Token: 0x0603E4C2 RID: 255170 RVA: 0x00FE83A4 File Offset: 0x00FE65A4
		protected override UniTask OnBeforeStartAsync()
		{
			MotorcycleControlMobilePanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleControlMobilePanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4C3 RID: 255171 RVA: 0x00FE83E8 File Offset: 0x00FE65E8
		private UniTask NewSkillButtonPanel()
		{
			MotorcycleControlMobilePanel.<NewSkillButtonPanel>d__6 <NewSkillButtonPanel>d__;
			<NewSkillButtonPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewSkillButtonPanel>d__.<>4__this = this;
			<NewSkillButtonPanel>d__.<>1__state = -1;
			<NewSkillButtonPanel>d__.<>t__builder.Start<MotorcycleControlMobilePanel.<NewSkillButtonPanel>d__6>(ref <NewSkillButtonPanel>d__);
			return <NewSkillButtonPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4C4 RID: 255172 RVA: 0x00FE842C File Offset: 0x00FE662C
		private UniTask NewJoysticks()
		{
			MotorcycleControlMobilePanel.<NewJoysticks>d__7 <NewJoysticks>d__;
			<NewJoysticks>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewJoysticks>d__.<>4__this = this;
			<NewJoysticks>d__.<>1__state = -1;
			<NewJoysticks>d__.<>t__builder.Start<MotorcycleControlMobilePanel.<NewJoysticks>d__7>(ref <NewJoysticks>d__);
			return <NewJoysticks>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4C5 RID: 255173 RVA: 0x00FE846F File Offset: 0x00FE666F
		protected override void OnStart()
		{
			base.OnStart();
			this.RefreshJoystickEnable();
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnMotorcycleRoundJoystickChanged, new Action<bool>(this.OnMotorcycleRoundJoystickChanged));
		}

		// Token: 0x0603E4C6 RID: 255174 RVA: 0x00FE8499 File Offset: 0x00FE6699
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			MotorcycleSkillButtonMobilePanel skillButtonPanel = this.SkillButtonPanel;
			if (skillButtonPanel != null)
			{
				skillButtonPanel.SetVisible(0, true);
			}
			this.ApplyTouchUiEditData();
			Singleton<EventSystem>.Instance.Add<ECommonTouchUiEditGroup>(EEventName.OnTouchUiEditSave, new Action<ECommonTouchUiEditGroup>(this.OnTouchUiEditSave));
		}

		// Token: 0x0603E4C7 RID: 255175 RVA: 0x00FE84D6 File Offset: 0x00FE66D6
		protected override void OnBeforeHide()
		{
			base.OnBeforeHide();
			MotorcycleSkillButtonMobilePanel skillButtonPanel = this.SkillButtonPanel;
			if (skillButtonPanel != null)
			{
				skillButtonPanel.SetVisible(0, false);
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnTouchUiEditSave, new Action<ECommonTouchUiEditGroup>(this.OnTouchUiEditSave));
		}

		// Token: 0x0603E4C8 RID: 255176 RVA: 0x00FE850D File Offset: 0x00FE670D
		public override void Tick(float delta)
		{
			if (!base.IsShowOrShowing)
			{
				return;
			}
			MotorcycleSkillButtonMobilePanel skillButtonPanel = this.SkillButtonPanel;
			if (skillButtonPanel != null)
			{
				skillButtonPanel.Tick(delta);
			}
			if (this.JoystickEnable)
			{
				MotorcycleJoystick joystick = this.Joystick;
				if (joystick == null)
				{
					return;
				}
				joystick.Tick((double)delta);
			}
		}

		// Token: 0x0603E4C9 RID: 255177 RVA: 0x00FE8544 File Offset: 0x00FE6744
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMotorcycleRoundJoystickChanged, new Action<bool>(this.OnMotorcycleRoundJoystickChanged));
			MotorcycleSkillButtonMobilePanel skillButtonPanel = this.SkillButtonPanel;
			if (skillButtonPanel != null)
			{
				skillButtonPanel.Destroy(null);
			}
			this.SkillButtonPanel = null;
			MotorcycleJoystick joystick = this.Joystick;
			if (joystick != null)
			{
				joystick.Destroy(null);
			}
			this.Joystick = null;
			base.Reset();
		}

		// Token: 0x0603E4CA RID: 255178 RVA: 0x00FE85AB File Offset: 0x00FE67AB
		private void CacheTouchUiEditInitData()
		{
			TouchUiEditApplyHelper.CacheTouchUiEditInitData(ECommonTouchUiEditGroup.Motorcycle, this.SkillButtonPanel, "UiItem_MotorcycleMobileKey");
			TouchUiEditApplyHelper.CacheTouchUiEditInitData(ECommonTouchUiEditGroup.MotorcycleRoundStick, this.SkillButtonPanel, "UiItem_MotorcycleMobileKeyRoundStickEdit");
		}

		// Token: 0x0603E4CB RID: 255179 RVA: 0x00FE85D0 File Offset: 0x00FE67D0
		private void ApplyTouchUiEditData()
		{
			this.CacheTouchUiEditInitData();
			if (ModelBase<BattleUiModel>.Instance.MotorcycleData.GetIsRoundJoystickButtonLayout())
			{
				TouchUiEditApplyHelper.ApplyCommonTouchUiEditData(ECommonTouchUiEditGroup.MotorcycleRoundStick, this.SkillButtonPanel, "UiItem_MotorcycleMobileKeyRoundStickEdit");
			}
			else
			{
				TouchUiEditApplyHelper.ApplyCommonTouchUiEditData(ECommonTouchUiEditGroup.Motorcycle, this.SkillButtonPanel, "UiItem_MotorcycleMobileKey");
			}
			TouchUiEditApplyHelper.ApplyCommonTouchUiEditData(ECommonTouchUiEditGroup.Motorcycle, this.Joystick, "UiItem_MotorcycleJoystickEdit");
		}

		// Token: 0x0603E4CC RID: 255180 RVA: 0x00FE8629 File Offset: 0x00FE6829
		private void OnTouchUiEditSave(ECommonTouchUiEditGroup group)
		{
			if (group != ECommonTouchUiEditGroup.Motorcycle && group != ECommonTouchUiEditGroup.MotorcycleRoundStick)
			{
				return;
			}
			this.ApplyTouchUiEditData();
		}

		// Token: 0x0603E4CD RID: 255181 RVA: 0x00FE863A File Offset: 0x00FE683A
		private void OnMotorcycleRoundJoystickChanged(bool b)
		{
			this.RefreshJoystickEnable();
			this.ApplyTouchUiEditData();
		}

		// Token: 0x0603E4CE RID: 255182 RVA: 0x00FE8648 File Offset: 0x00FE6848
		private void RefreshJoystickEnable()
		{
			BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
			this.JoystickEnable = !motorcycleData.GetIsRoundJoystick();
			MotorcycleJoystick joystick = this.Joystick;
			if (joystick == null)
			{
				return;
			}
			joystick.SetEnable(this.JoystickEnable);
		}

		// Token: 0x04022EB6 RID: 143030
		[Nullable(2)]
		private MotorcycleSkillButtonMobilePanel SkillButtonPanel;

		// Token: 0x04022EB7 RID: 143031
		[Nullable(2)]
		private MotorcycleJoystick Joystick;

		// Token: 0x04022EB8 RID: 143032
		private bool JoystickEnable;

		// Token: 0x0200C15B RID: 49499
		private enum EChildType
		{
			// Token: 0x0403B89D RID: 243869
			SkillButtonPanel,
			// Token: 0x0403B89E RID: 243870
			JoystickItem
		}
	}
}
