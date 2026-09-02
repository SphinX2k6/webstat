using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FD2 RID: 24530
	public class BattleSkillLeftRouletteItem : UiPanelBase
	{
		// Token: 0x0603DB96 RID: 252822 RVA: 0x00FB973C File Offset: 0x00FB793C
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

		// Token: 0x0603DB97 RID: 252823 RVA: 0x00FB9784 File Offset: 0x00FB7984
		protected override UniTask OnBeforeStartAsync()
		{
			BattleSkillLeftRouletteItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleSkillLeftRouletteItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DB98 RID: 252824 RVA: 0x00FB97C7 File Offset: 0x00FB79C7
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiRouletteKeyChanged, new Action(this.OnRouletteKeyChanged));
		}

		// Token: 0x0603DB99 RID: 252825 RVA: 0x00FB97E5 File Offset: 0x00FB79E5
		private void OnRouletteKeyChanged()
		{
			this.RefreshKeyItem();
			this.RefreshVisible();
		}

		// Token: 0x0603DB9A RID: 252826 RVA: 0x00FB97F4 File Offset: 0x00FB79F4
		public void RefreshKeyItem()
		{
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData.RouletteKey == EKey.Gamepad_LeftShoulder)
			{
				return;
			}
			if (!string.IsNullOrEmpty(gamepadData.RouletteKey))
			{
				InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
				{
					ActionOrAxisName = "幻象探索选择界面"
				};
				this.KeyItem.RefreshByActionOrAxis(actionOrAxisKeyItem, false);
			}
		}

		// Token: 0x0603DB9B RID: 252827 RVA: 0x00FB9850 File Offset: 0x00FB7A50
		public void RefreshVisible()
		{
			if (base.IsDestroyOrDestroying)
			{
				return;
			}
			if (ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance())
			{
				this.SetActive(false);
				return;
			}
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				this.SetActive(false);
				return;
			}
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData.GetIsPressCombineButton())
			{
				this.SetActive(false);
				return;
			}
			bool funcFlagEnable = ModelBase<LevelFuncFlagModel>.Instance.GetFuncFlagEnable(ELevelFuncFlagId.ExploreSkillRoulette);
			bool active = gamepadData.RouletteKey != EKey.Gamepad_LeftShoulder && gamepadData.RouletteKey != null && funcFlagEnable;
			this.SetActive(active);
		}

		// Token: 0x04022A1B RID: 141851
		[Nullable(2)]
		private InputMultiKeyItem KeyItem;

		// Token: 0x0200C03F RID: 49215
		private enum EChildType
		{
			// Token: 0x0403B2E2 RID: 242402
			KeyItem
		}
	}
}
