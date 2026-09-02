using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FD7 RID: 24535
	public class BattleSkillSlideControlItem : UiPanelBase
	{
		// Token: 0x0603DBCD RID: 252877 RVA: 0x00FBA33C File Offset: 0x00FB853C
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

		// Token: 0x0603DBCE RID: 252878 RVA: 0x00FBA3C6 File Offset: 0x00FB85C6
		protected override void OnStart()
		{
			this.tweenAnimPlayer.InitTweenAnim(1, base.GetItem(1), false);
			this.tweenAnimPlayer.InitTweenAnim(2, base.GetItem(2), false);
			this.SetComponentActive(this.TargetActive);
		}

		// Token: 0x0603DBCF RID: 252879 RVA: 0x00FBA3FC File Offset: 0x00FB85FC
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			BattleUiSlideControlData slideControlData = ModelBase<BattleUiModel>.Instance.SlideControlData;
			this.RootItem.SetAnchorOffset(slideControlData.Position.ToUeVector2D(false));
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.SlideControl, new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
			{
				EBattleUiChild.Formation,
				EBattleUiChild.SkillButton
			}), false, true, 0);
			this.tweenAnimPlayer.StopTweenAnim(2);
			this.tweenAnimPlayer.PlayTweenAnim(1);
		}

		// Token: 0x0603DBD0 RID: 252880 RVA: 0x00FBA474 File Offset: 0x00FB8674
		protected override void OnBeforeHide()
		{
			base.OnBeforeHide();
			this.InputAction(null);
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.SlideControl, new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
			{
				EBattleUiChild.Formation,
				EBattleUiChild.SkillButton
			}), true, true, 0);
			this.tweenAnimPlayer.StopTweenAnim(1);
			this.tweenAnimPlayer.PlayTweenAnim(2);
		}

		// Token: 0x0603DBD1 RID: 252881 RVA: 0x00FBA4CE File Offset: 0x00FB86CE
		public void SetComponentActive(bool visibility)
		{
			if (this.TargetActive == visibility && !this.IsFirstShow)
			{
				return;
			}
			this.TargetActive = visibility;
			if (base.InAsyncLoading())
			{
				return;
			}
			this.IsFirstShow = false;
			this.SetActive(visibility);
		}

		// Token: 0x0603DBD2 RID: 252882 RVA: 0x00FBA500 File Offset: 0x00FB8700
		public void Tick(float delta)
		{
			if (!base.IsShowOrShowing)
			{
				return;
			}
			if (!this.CheckInTouch())
			{
				ModelBase<BattleUiModel>.Instance.SlideControlData.ForceStop();
				return;
			}
			Vector2D touchMoveDir = ModelBase<BattleUiModel>.Instance.SlideControlData.TouchMoveDir;
			if (touchMoveDir.Y <= -10.0)
			{
				this.InputAction("跳跃");
				return;
			}
			if (touchMoveDir.Y > 10.0)
			{
				this.InputAction("下降");
				return;
			}
			this.InputAction(null);
		}

		// Token: 0x0603DBD3 RID: 252883 RVA: 0x00FBA580 File Offset: 0x00FB8780
		[NullableContext(2)]
		private void InputAction(string inputAction)
		{
			if (this.LastInputAction == inputAction)
			{
				return;
			}
			if (this.LastInputAction != null)
			{
				ControllerBase<InputDistributeController>.Instance.InputAction(this.LastInputAction, false);
				this.LastInputAction = null;
				return;
			}
			if (inputAction != null)
			{
				ControllerBase<InputDistributeController>.Instance.InputAction(inputAction, true);
			}
			this.LastInputAction = inputAction;
		}

		// Token: 0x0603DBD4 RID: 252884 RVA: 0x00FBA5D8 File Offset: 0x00FB87D8
		private bool CheckInTouch()
		{
			if (Singleton<Time>.Instance.Now < this.NextCheckInTouchTime)
			{
				return true;
			}
			this.NextCheckInTouchTime = Singleton<Time>.Instance.Now + 500.0;
			int touchId = ModelBase<BattleUiModel>.Instance.SlideControlData.TouchId;
			TsCharacterController characterController = Global.CharacterController;
			return characterController != null && characterController.IsInTouch((float)touchId);
		}

		// Token: 0x04022A2F RID: 141871
		private const double CHECK_IN_TOUCH_INTERVAL = 500.0;

		// Token: 0x04022A30 RID: 141872
		[Nullable(1)]
		private readonly BattleUiTweenAnimPlayer tweenAnimPlayer = new BattleUiTweenAnimPlayer();

		// Token: 0x04022A31 RID: 141873
		public bool TargetActive;

		// Token: 0x04022A32 RID: 141874
		private bool IsFirstShow = true;

		// Token: 0x04022A33 RID: 141875
		[Nullable(2)]
		private string LastInputAction;

		// Token: 0x04022A34 RID: 141876
		private double NextCheckInTouchTime;

		// Token: 0x0200C048 RID: 49224
		private enum EChildItem
		{
			// Token: 0x0403B2F9 RID: 242425
			DragItem,
			// Token: 0x0403B2FA RID: 242426
			AniArrowIn,
			// Token: 0x0403B2FB RID: 242427
			AniArrowOut
		}
	}
}
