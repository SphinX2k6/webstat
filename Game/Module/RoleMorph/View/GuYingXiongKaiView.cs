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

namespace CSharpScript.Game.Module.RoleMorph.View
{
	// Token: 0x020050E2 RID: 20706
	public class GuYingXiongKaiView : UiTickViewBase
	{
		// Token: 0x06035602 RID: 218626 RVA: 0x00D6356E File Offset: 0x00D6176E
		[NullableContext(1)]
		public GuYingXiongKaiView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035603 RID: 218627 RVA: 0x00D63584 File Offset: 0x00D61784
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035604 RID: 218628 RVA: 0x00D636F0 File Offset: 0x00D618F0
		protected override UniTask OnBeforeStartAsync()
		{
			GuYingXiongKaiView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<GuYingXiongKaiView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035605 RID: 218629 RVA: 0x00D63734 File Offset: 0x00D61934
		public UniTask NewAllSkillItems()
		{
			GuYingXiongKaiView.<NewAllSkillItems>d__10 <NewAllSkillItems>d__;
			<NewAllSkillItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAllSkillItems>d__.<>4__this = this;
			<NewAllSkillItems>d__.<>1__state = -1;
			<NewAllSkillItems>d__.<>t__builder.Start<GuYingXiongKaiView.<NewAllSkillItems>d__10>(ref <NewAllSkillItems>d__);
			return <NewAllSkillItems>d__.<>t__builder.Task;
		}

		// Token: 0x06035606 RID: 218630 RVA: 0x00D63778 File Offset: 0x00D61978
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<GuYingXiongKaiSkillItem> NewSkillItem(AActor rootActor, int inputIndex)
		{
			GuYingXiongKaiView.<NewSkillItem>d__11 <NewSkillItem>d__;
			<NewSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<GuYingXiongKaiSkillItem>.Create();
			<NewSkillItem>d__.<>4__this = this;
			<NewSkillItem>d__.rootActor = rootActor;
			<NewSkillItem>d__.inputIndex = inputIndex;
			<NewSkillItem>d__.<>1__state = -1;
			<NewSkillItem>d__.<>t__builder.Start<GuYingXiongKaiView.<NewSkillItem>d__11>(ref <NewSkillItem>d__);
			return <NewSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x06035607 RID: 218631 RVA: 0x00D637CC File Offset: 0x00D619CC
		protected override void OnAddEventListener()
		{
			this.BtnAttack = base.GetButton(5);
			if (this.BtnAttack != null)
			{
				this.BtnAttack.OnPointDownCallBack.Bind(new Action(this.OnAttackButtonPressed));
				this.BtnAttack.OnPointUpCallBack.Bind(new Action(this.OnAttackButtonReleased));
				this.BtnAttack.OnPointCancelCallBack.Bind(new Action(this.OnAttackButtonCancel));
			}
		}

		// Token: 0x06035608 RID: 218632 RVA: 0x00D63842 File Offset: 0x00D61A42
		protected override void OnRemoveEventListener()
		{
			if (this.BtnAttack != null)
			{
				this.BtnAttack.OnPointDownCallBack.Unbind();
				this.BtnAttack.OnPointUpCallBack.Unbind();
				this.BtnAttack.OnPointCancelCallBack.Unbind();
			}
		}

		// Token: 0x06035609 RID: 218633 RVA: 0x00D6387C File Offset: 0x00D61A7C
		protected override void OnBeforeDestroy()
		{
			foreach (GuYingXiongKaiSkillItem guYingXiongKaiSkillItem in this.SkillItemList)
			{
				guYingXiongKaiSkillItem.Destroy(null);
			}
			this.SkillItemList.Clear();
			this.BtnAttack = null;
		}

		// Token: 0x0603560A RID: 218634 RVA: 0x00D638E0 File Offset: 0x00D61AE0
		private void OnClickClose()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.ChallengeAgain, "玩法放弃");
		}

		// Token: 0x0603560B RID: 218635 RVA: 0x00D638F7 File Offset: 0x00D61AF7
		private void OnAttackButtonPressed()
		{
			ControllerBase<InputDistributeController>.Instance.InputAction("攻击", true);
		}

		// Token: 0x0603560C RID: 218636 RVA: 0x00D6390A File Offset: 0x00D61B0A
		private void OnAttackButtonCancel()
		{
			ControllerBase<InputDistributeController>.Instance.InputAction("攻击", false);
		}

		// Token: 0x0603560D RID: 218637 RVA: 0x00D6391D File Offset: 0x00D61B1D
		private void OnAttackButtonReleased()
		{
			ControllerBase<InputDistributeController>.Instance.InputAction("攻击", false);
		}

		// Token: 0x0603560E RID: 218638 RVA: 0x00D63930 File Offset: 0x00D61B30
		protected override void OnTick(float delta)
		{
			foreach (GuYingXiongKaiSkillItem guYingXiongKaiSkillItem in this.SkillItemList)
			{
				guYingXiongKaiSkillItem.Tick(delta);
			}
			this.OnTickGetCursorInput();
		}

		// Token: 0x0603560F RID: 218639 RVA: 0x00D63988 File Offset: 0x00D61B88
		private void OnTickGetCursorInput()
		{
			if (!Singleton<Info>.Instance.IsInKeyBoard())
			{
				return;
			}
			TsCharacterController characterController = Global.CharacterController;
			Vector2D cursorPosition = characterController.GetCursorPosition();
			if (cursorPosition == null)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			characterController.GetViewportSize(ref num, ref num2);
			float num3 = (float)num * 0.5f;
			float num4 = (float)num2 * 0.5f;
			float num5 = num3 * 0.4f;
			float num6 = num4 * 0.4f;
			double num7 = cursorPosition.X - (double)num3;
			double num8 = (double)num4 - cursorPosition.Y;
			if (Math.Abs(num7) < (double)num5 && Math.Abs(num8) < (double)num6)
			{
				return;
			}
			double num9 = Math.Atan2(num8, num7) * 57.295780181884766;
			if (num9 < 0.0)
			{
				num9 += 360.0;
			}
			GuYingXiongKaiView.ESectorScreen esectorScreen = (GuYingXiongKaiView.ESectorScreen)Math.Floor((num9 + 22.5) * 0.02222222276031971) % (GuYingXiongKaiView.ESectorScreen)8;
			if (esectorScreen == this.LastSector)
			{
				return;
			}
			this.LastSector = esectorScreen;
			switch (esectorScreen)
			{
			case GuYingXiongKaiView.ESectorScreen.Right:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, 1f, true);
				return;
			case GuYingXiongKaiView.ESectorScreen.UpRight:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, 1f, true);
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, 1f, true);
				return;
			case GuYingXiongKaiView.ESectorScreen.Up:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, 1f, true);
				return;
			case GuYingXiongKaiView.ESectorScreen.UpLeft:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, -1f, true);
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, 1f, true);
				return;
			case GuYingXiongKaiView.ESectorScreen.Left:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, -1f, true);
				return;
			case GuYingXiongKaiView.ESectorScreen.DowLeft:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, -1f, true);
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, -1f, true);
				return;
			case GuYingXiongKaiView.ESectorScreen.Down:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, -1f, true);
				return;
			case GuYingXiongKaiView.ESectorScreen.DownRight:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, 1f, true);
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, -1f, true);
				return;
			default:
				return;
			}
		}

		// Token: 0x0401EAB4 RID: 125620
		[Nullable(1)]
		private readonly List<GuYingXiongKaiSkillItem> SkillItemList = new List<GuYingXiongKaiSkillItem>();

		// Token: 0x0401EAB5 RID: 125621
		[Nullable(2)]
		private UUIButtonComponent BtnAttack;

		// Token: 0x0401EAB6 RID: 125622
		private const float SECTOR_ANGLE_SIZE = 0.022222223f;

		// Token: 0x0401EAB7 RID: 125623
		private const float HALF_SECTOR_ANGLE_SIZE = 22.5f;

		// Token: 0x0401EAB8 RID: 125624
		private const int SECTOR_NUM = 8;

		// Token: 0x0401EAB9 RID: 125625
		private GuYingXiongKaiView.ESectorScreen LastSector;

		// Token: 0x0200B07B RID: 45179
		private enum EChildType
		{
			// Token: 0x04036C19 RID: 224281
			LeftContainer,
			// Token: 0x04036C1A RID: 224282
			Item1,
			// Token: 0x04036C1B RID: 224283
			Item2,
			// Token: 0x04036C1C RID: 224284
			Item3,
			// Token: 0x04036C1D RID: 224285
			Item4,
			// Token: 0x04036C1E RID: 224286
			BtnReset,
			// Token: 0x04036C1F RID: 224287
			BtnClose,
			// Token: 0x04036C20 RID: 224288
			BtnHelp
		}

		// Token: 0x0200B07C RID: 45180
		private enum ESectorScreen
		{
			// Token: 0x04036C22 RID: 224290
			Right,
			// Token: 0x04036C23 RID: 224291
			UpRight,
			// Token: 0x04036C24 RID: 224292
			Up,
			// Token: 0x04036C25 RID: 224293
			UpLeft,
			// Token: 0x04036C26 RID: 224294
			Left,
			// Token: 0x04036C27 RID: 224295
			DowLeft,
			// Token: 0x04036C28 RID: 224296
			Down,
			// Token: 0x04036C29 RID: 224297
			DownRight
		}
	}
}
