using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Input;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View.Control
{
	// Token: 0x02004F1C RID: 20252
	[NullableContext(2)]
	[Nullable(0)]
	public class MobileControlItem : ControlItem
	{
		// Token: 0x06034567 RID: 214375 RVA: 0x00D19190 File Offset: 0x00D17390
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 5;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnRotateBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnFallDownBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClimbBtnClick));
			num++;
			ref ValueTuple<int, Delegate> ptr = ref span2[num];
			int item = 4;
			Action item2;
			if ((item2 = MobileControlItem.<>O.<0>__OnJumpBtnClick) == null)
			{
				item2 = (MobileControlItem.<>O.<0>__OnJumpBtnClick = new Action(MobileControlItem.OnJumpBtnClick));
			}
			ptr = new ValueTuple<int, Delegate>(item, item2);
			num++;
			ref ValueTuple<int, Delegate> ptr2 = ref span2[num];
			int item3 = 5;
			Action item4;
			if ((item4 = MobileControlItem.<>O.<1>__OnDodgeBtnClick) == null)
			{
				item4 = (MobileControlItem.<>O.<1>__OnDodgeBtnClick = new Action(MobileControlItem.OnDodgeBtnClick));
			}
			ptr2 = new ValueTuple<int, Delegate>(item3, item4);
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034568 RID: 214376 RVA: 0x00D19368 File Offset: 0x00D17568
		protected override UniTask OnBeforeStartAsync()
		{
			MobileControlItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MobileControlItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034569 RID: 214377 RVA: 0x00D193AB File Offset: 0x00D175AB
		public override void OnTick(float delta)
		{
			base.OnTick(delta);
			SlidingBlocksJoystick joystick = this.Joystick;
			if (joystick == null)
			{
				return;
			}
			joystick.Tick(delta);
		}

		// Token: 0x0603456A RID: 214378 RVA: 0x00D193C8 File Offset: 0x00D175C8
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<SlidingBlocksJoystick> InitializeJoystick()
		{
			MobileControlItem.<InitializeJoystick>d__9 <InitializeJoystick>d__;
			<InitializeJoystick>d__.<>t__builder = AsyncUniTaskMethodBuilder<SlidingBlocksJoystick>.Create();
			<InitializeJoystick>d__.<>4__this = this;
			<InitializeJoystick>d__.<>1__state = -1;
			<InitializeJoystick>d__.<>t__builder.Start<MobileControlItem.<InitializeJoystick>d__9>(ref <InitializeJoystick>d__);
			return <InitializeJoystick>d__.<>t__builder.Task;
		}

		// Token: 0x0603456B RID: 214379 RVA: 0x00D1940B File Offset: 0x00D1760B
		private static void OnJumpBtnClick()
		{
			ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.跳跃, EInputState.Press);
		}

		// Token: 0x0603456C RID: 214380 RVA: 0x00D1941D File Offset: 0x00D1761D
		private static void OnDodgeBtnClick()
		{
			ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.闪避, EInputState.Press);
		}

		// Token: 0x0603456D RID: 214381 RVA: 0x00D1942F File Offset: 0x00D1762F
		protected override void OnClimbBtnClick()
		{
			base.OnClimbBtnClick();
		}

		// Token: 0x0603456E RID: 214382 RVA: 0x00D19437 File Offset: 0x00D17637
		protected override void OnRotateBtnClick()
		{
			base.OnRotateBtnClick();
		}

		// Token: 0x0603456F RID: 214383 RVA: 0x00D1943F File Offset: 0x00D1763F
		protected override void OnFallDownBtnClick()
		{
			base.OnFallDownBtnClick();
		}

		// Token: 0x0401E2FA RID: 123642
		private SlidingBlocksJoystick Joystick;

		// Token: 0x0401E2FB RID: 123643
		private UUIButtonComponent RotateBtn;

		// Token: 0x0401E2FC RID: 123644
		private UUIButtonComponent FallDownBtn;

		// Token: 0x0401E2FD RID: 123645
		private UUIButtonComponent ClimbBtn;

		// Token: 0x0401E2FE RID: 123646
		private CharacterClimbComponent ClimbComp;

		// Token: 0x0200AF66 RID: 44902
		[NullableContext(0)]
		private class EViewComponent
		{
			// Token: 0x040366EA RID: 222954
			public const int JoystickItem = 0;

			// Token: 0x040366EB RID: 222955
			public const int RotateBtn = 1;

			// Token: 0x040366EC RID: 222956
			public const int FallDownBtn = 2;

			// Token: 0x040366ED RID: 222957
			public const int ClimbBtn = 3;

			// Token: 0x040366EE RID: 222958
			public const int JumpBtn = 4;

			// Token: 0x040366EF RID: 222959
			public const int DodgeBtn = 5;
		}

		// Token: 0x0200AF67 RID: 44903
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040366F0 RID: 222960
			[Nullable(0)]
			public static Action <0>__OnJumpBtnClick;

			// Token: 0x040366F1 RID: 222961
			[Nullable(0)]
			public static Action <1>__OnDodgeBtnClick;
		}
	}
}
