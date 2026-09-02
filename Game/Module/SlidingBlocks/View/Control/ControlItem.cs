using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Input;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View.Control
{
	// Token: 0x02004F1B RID: 20251
	[NullableContext(2)]
	[Nullable(0)]
	public class ControlItem : UiPanelBase
	{
		// Token: 0x0603455E RID: 214366 RVA: 0x00D18EE8 File Offset: 0x00D170E8
		protected override UniTask OnBeforeStartAsync()
		{
			ControlItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ControlItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603455F RID: 214367 RVA: 0x00D18F2B File Offset: 0x00D1712B
		protected override void OnAfterShow()
		{
			ControlButton climbBtnItem = this.ClimbBtnItem;
			if (climbBtnItem != null)
			{
				climbBtnItem.Show(null);
			}
			ControlButton rotateBtnItem = this.RotateBtnItem;
			if (rotateBtnItem != null)
			{
				rotateBtnItem.Show(null);
			}
			ControlButton fallDownBtnItem = this.FallDownBtnItem;
			if (fallDownBtnItem == null)
			{
				return;
			}
			fallDownBtnItem.Show(null);
		}

		// Token: 0x06034560 RID: 214368 RVA: 0x00D18F64 File Offset: 0x00D17164
		public virtual void OnTick(float delta)
		{
			Tetromino curTetromino = ModelBase<SlidingBlocksModel>.Instance.GameData.CurTetromino;
			if (curTetromino != null)
			{
				ControlButton rotateBtnItem = this.RotateBtnItem;
				if (rotateBtnItem != null)
				{
					UUIButtonComponent button = rotateBtnItem.Button;
					if (button != null)
					{
						button.SetSelfInteractive(curTetromino.GetState() == ETetrominoState.Aiming);
					}
				}
				ControlButton fallDownBtnItem = this.FallDownBtnItem;
				if (fallDownBtnItem != null)
				{
					UUIButtonComponent button2 = fallDownBtnItem.Button;
					if (button2 != null)
					{
						button2.SetSelfInteractive(curTetromino.GetState() == ETetrominoState.Aiming);
					}
				}
			}
			if (this.ClimbComp != null)
			{
				bool uiactive = this.ClimbComp.GetTsClimbState().攀爬状态 > EClimbState.无;
				ControlButton climbBtnItem = this.ClimbBtnItem;
				if (climbBtnItem == null)
				{
					return;
				}
				UUIButtonComponent button3 = climbBtnItem.Button;
				if (button3 == null)
				{
					return;
				}
				UUIItem uuiitem = button3.RootUIComp.Get();
				if (uuiitem == null)
				{
					return;
				}
				uuiitem.SetUIActive(uiactive);
			}
		}

		// Token: 0x06034561 RID: 214369 RVA: 0x00D19018 File Offset: 0x00D17218
		protected virtual void OnClimbBtnClick()
		{
			ControlButton climbBtnItem = this.ClimbBtnItem;
			bool flag;
			if (climbBtnItem == null)
			{
				flag = true;
			}
			else
			{
				UUIButtonComponent button = climbBtnItem.Button;
				bool? flag2;
				if (button == null)
				{
					flag2 = null;
				}
				else
				{
					UUIItem uuiitem = button.RootUIComp.Get();
					flag2 = ((uuiitem != null) ? new bool?(uuiitem.IsUIActiveInHierarchy()) : null);
				}
				bool? flag3 = flag2;
				flag = !flag3.GetValueOrDefault();
			}
			if (flag)
			{
				return;
			}
			ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.攀爬, EInputState.Press);
			ControlButton climbBtnItem2 = this.ClimbBtnItem;
			if (climbBtnItem2 == null)
			{
				return;
			}
			climbBtnItem2.PlayClickEffect();
		}

		// Token: 0x06034562 RID: 214370 RVA: 0x00D1909C File Offset: 0x00D1729C
		protected virtual void OnRotateBtnClick()
		{
			Tetromino curTetromino = ModelBase<SlidingBlocksModel>.Instance.GameData.CurTetromino;
			if (curTetromino == null || curTetromino.GetState() != ETetrominoState.Aiming)
			{
				return;
			}
			if (curTetromino.Rotate(true))
			{
				SlidingBlocksController.OpenAudio(ModelBase<SlidingBlocksModel>.Instance.GameData.AudioData.RotateAudio);
			}
			ControlButton rotateBtnItem = this.RotateBtnItem;
			if (rotateBtnItem == null)
			{
				return;
			}
			rotateBtnItem.PlayClickEffect();
		}

		// Token: 0x06034563 RID: 214371 RVA: 0x00D190FC File Offset: 0x00D172FC
		protected virtual void OnFallDownBtnClick()
		{
			Tetromino curTetromino = ModelBase<SlidingBlocksModel>.Instance.GameData.CurTetromino;
			if (curTetromino == null || curTetromino.GetState() != ETetrominoState.Aiming)
			{
				return;
			}
			curTetromino.SkipAimingStage();
			ControlButton fallDownBtnItem = this.FallDownBtnItem;
			if (fallDownBtnItem == null)
			{
				return;
			}
			fallDownBtnItem.PlayClickEffect();
		}

		// Token: 0x06034564 RID: 214372 RVA: 0x00D1913C File Offset: 0x00D1733C
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected UniTask<ControlButton> NewButton(AActor rootActor)
		{
			ControlItem.<NewButton>d__10 <NewButton>d__;
			<NewButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<ControlButton>.Create();
			<NewButton>d__.rootActor = rootActor;
			<NewButton>d__.<>1__state = -1;
			<NewButton>d__.<>t__builder.Start<ControlItem.<NewButton>d__10>(ref <NewButton>d__);
			return <NewButton>d__.<>t__builder.Task;
		}

		// Token: 0x0401E2F6 RID: 123638
		protected ControlButton ClimbBtnItem;

		// Token: 0x0401E2F7 RID: 123639
		protected ControlButton RotateBtnItem;

		// Token: 0x0401E2F8 RID: 123640
		protected ControlButton FallDownBtnItem;

		// Token: 0x0401E2F9 RID: 123641
		private CharacterClimbComponent ClimbComp;
	}
}
