using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FD5 RID: 24533
	public class BattleSkillRouletteItem : UiPanelBase
	{
		// Token: 0x0603DBB6 RID: 252854 RVA: 0x00FB9DC4 File Offset: 0x00FB7FC4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DBB7 RID: 252855 RVA: 0x00FB9E0C File Offset: 0x00FB800C
		protected override UniTask OnBeforeStartAsync()
		{
			BattleSkillRouletteItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleSkillRouletteItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DBB8 RID: 252856 RVA: 0x00FB9E4F File Offset: 0x00FB804F
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiRouletteKeyChanged, new Action(this.OnRouletteKeyChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		}

		// Token: 0x0603DBB9 RID: 252857 RVA: 0x00FB9E89 File Offset: 0x00FB8089
		private void OnRouletteKeyChanged()
		{
			this.RefreshKeyItem();
			this.RefreshVisible();
		}

		// Token: 0x0603DBBA RID: 252858 RVA: 0x00FB9E97 File Offset: 0x00FB8097
		private void InputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.RefreshKeyItem();
		}

		// Token: 0x0603DBBB RID: 252859 RVA: 0x00FB9EA0 File Offset: 0x00FB80A0
		public void RefreshKeyItem()
		{
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData.RouletteKey == EKey.Gamepad_LeftShoulder)
			{
				InputKeyItemData singleInputKeyItemData = new InputKeyItemData
				{
					KeyName = EKey.Gamepad_Right2D
				};
				this.KeyItem.RefreshByKeyList(singleInputKeyItemData, null);
				return;
			}
			if (!string.IsNullOrEmpty(gamepadData.RouletteKey))
			{
				return;
			}
			if (!string.IsNullOrEmpty(gamepadData.RouletteSecondKey))
			{
				InputKeyItemData singleInputKeyItemData2 = new InputKeyItemData
				{
					KeyName = gamepadData.RouletteSecondKey
				};
				this.KeyItem.RefreshByKeyList(singleInputKeyItemData2, null);
			}
		}

		// Token: 0x0603DBBC RID: 252860 RVA: 0x00FB9F30 File Offset: 0x00FB8130
		public void RefreshVisible()
		{
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (!gamepadData.GetIsPressCombineButton())
			{
				this.SetActive(false);
				return;
			}
			bool active = gamepadData.RouletteKey == EKey.Gamepad_LeftShoulder || (gamepadData.RouletteKey == null && gamepadData.RouletteSecondKey != null);
			this.SetActive(active);
		}

		// Token: 0x04022A27 RID: 141863
		[Nullable(2)]
		private InputMultiKeyItem KeyItem;

		// Token: 0x0200C045 RID: 49221
		private enum EChildType
		{
			// Token: 0x0403B2F1 RID: 242417
			KeyItem
		}
	}
}
