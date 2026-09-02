using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Core.Common;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D7D RID: 7549
public class SpringManorSkillPanel : BattleChildViewPanel
{
	// Token: 0x0600DE1C RID: 56860 RVA: 0x003BBC78 File Offset: 0x003B9E78
	protected override void OnRegisterComponent()
	{
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			list.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
			list.Add(new ValueTuple<int, Type>(3, typeof(UUIItem)));
		}
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DE1D RID: 56861 RVA: 0x003BBCF8 File Offset: 0x003B9EF8
	protected override UniTask OnBeforeStartAsync()
	{
		SpringManorSkillPanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorSkillPanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE1E RID: 56862 RVA: 0x003BBD3C File Offset: 0x003B9F3C
	protected override void OnStart()
	{
		UUIButtonComponent button = base.GetButton(0);
		button.OnPointDownCallBack.Bind(new Action(this.OnJumpButtonPressed));
		button.OnPointUpCallBack.Bind(new Action(this.OnJumpButtonReleased));
		button.OnPointCancelCallBack.Bind(new Action(this.OnJumpButtonCancel));
		UUIButtonComponent button2 = base.GetButton(1);
		button2.OnPointDownCallBack.Bind(new Action(this.OnRunButtonPressed));
		button2.OnPointUpCallBack.Bind(new Action(this.OnRunButtonReleased));
		button2.OnPointCancelCallBack.Bind(new Action(this.OnRunButtonCancel));
		InputMultiKeyItem jumpKeyItem = this.JumpKeyItem;
		if (jumpKeyItem != null)
		{
			jumpKeyItem.RefreshByActionOrAxis(new InputActionOrAxisKeyItem
			{
				ActionOrAxisName = "跳跃"
			}, false);
		}
		InputMultiKeyItem jumpKeyItem2 = this.JumpKeyItem;
		if (jumpKeyItem2 != null)
		{
			jumpKeyItem2.SetUiActive(true);
		}
		InputMultiKeyItem runKeyItem = this.RunKeyItem;
		if (runKeyItem != null)
		{
			runKeyItem.RefreshByActionOrAxis(new InputActionOrAxisKeyItem
			{
				ActionOrAxisName = "闪避"
			}, false);
		}
		InputMultiKeyItem runKeyItem2 = this.RunKeyItem;
		if (runKeyItem2 == null)
		{
			return;
		}
		runKeyItem2.SetUiActive(true);
	}

	// Token: 0x0600DE1F RID: 56863 RVA: 0x003BBE46 File Offset: 0x003BA046
	private void OnJumpButtonPressed()
	{
		ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.跳跃, EInputState.Press);
	}

	// Token: 0x0600DE20 RID: 56864 RVA: 0x003BBE58 File Offset: 0x003BA058
	private void OnJumpButtonCancel()
	{
		ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.跳跃, EInputState.Release);
	}

	// Token: 0x0600DE21 RID: 56865 RVA: 0x003BBE6A File Offset: 0x003BA06A
	private void OnJumpButtonReleased()
	{
		ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.跳跃, EInputState.Release);
	}

	// Token: 0x0600DE22 RID: 56866 RVA: 0x003BBE7C File Offset: 0x003BA07C
	private void OnRunButtonPressed()
	{
		ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.闪避, EInputState.Press);
	}

	// Token: 0x0600DE23 RID: 56867 RVA: 0x003BBE8E File Offset: 0x003BA08E
	private void OnRunButtonCancel()
	{
		ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.闪避, EInputState.Release);
	}

	// Token: 0x0600DE24 RID: 56868 RVA: 0x003BBEA0 File Offset: 0x003BA0A0
	private void OnRunButtonReleased()
	{
		ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.闪避, EInputState.Release);
	}

	// Token: 0x04006AA7 RID: 27303
	[Nullable(2)]
	private InputMultiKeyItem JumpKeyItem;

	// Token: 0x04006AA8 RID: 27304
	[Nullable(2)]
	private InputMultiKeyItem RunKeyItem;

	// Token: 0x020080FD RID: 33021
	private static class EComp
	{
		// Token: 0x0402BDBB RID: 179643
		public const int BtnJump = 0;

		// Token: 0x0402BDBC RID: 179644
		public const int BtnRun = 1;

		// Token: 0x0402BDBD RID: 179645
		public const int JumpKey = 2;

		// Token: 0x0402BDBE RID: 179646
		public const int RunKey = 3;
	}
}
