using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EF2 RID: 28402
	[NullableContext(2)]
	[Nullable(0)]
	public class DollGrabMachineCaptionPanel : UiPanelBase
	{
		// Token: 0x06044D67 RID: 281959 RVA: 0x011E97A8 File Offset: 0x011E79A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBackButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnHelpInfoButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044D68 RID: 281960 RVA: 0x011E9938 File Offset: 0x011E7B38
		protected override UniTask OnBeforeStartAsync()
		{
			DollGrabMachineCaptionPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DollGrabMachineCaptionPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044D69 RID: 281961 RVA: 0x011E997C File Offset: 0x011E7B7C
		protected override void OnBeforeCreate()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(true);
			}
			this.BtnBack = base.GetButton(3);
			this.BtnHelpInfo = base.GetButton(2);
			UUIButtonComponent btnBack = this.BtnBack;
			if (btnBack != null)
			{
				btnBack.SetSelfInteractive(true);
			}
			UUIButtonComponent btnHelpInfo = this.BtnHelpInfo;
			if (btnHelpInfo != null)
			{
				btnHelpInfo.SetSelfInteractive(true);
			}
			Singleton<EventSystem>.Instance.Add<EDollGrabMachineEndReason>(EEventName.OnDollGrabMachineEnd, new Action<EDollGrabMachineEndReason>(this.OnDollGrabMachineEnd));
			Singleton<EventSystem>.Instance.Add(EEventName.OnDollGrabMachineRestart, new Action(this.OnDollGrabMachineRestart));
			Singleton<EventSystem>.Instance.Add<Action>(EEventName.OnDollGrabMachineStartCoolDown, new Action<Action>(this.OnDollGrabMachineStartCoolDown));
		}

		// Token: 0x06044D6A RID: 281962 RVA: 0x011E9A30 File Offset: 0x011E7C30
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<EDollGrabMachineEndReason>(EEventName.OnDollGrabMachineEnd, new Action<EDollGrabMachineEndReason>(this.OnDollGrabMachineEnd));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnDollGrabMachineRestart, new Action(this.OnDollGrabMachineRestart));
			Singleton<EventSystem>.Instance.Remove<Action>(EEventName.OnDollGrabMachineStartCoolDown, new Action<Action>(this.OnDollGrabMachineStartCoolDown));
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnDollGrabMachineEndCoolDown, new Action(this.OnDollGrabMachineEndCoolDown)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnDollGrabMachineEndCoolDown, new Action(this.OnDollGrabMachineEndCoolDown));
			}
		}

		// Token: 0x06044D6B RID: 281963 RVA: 0x011E9ACA File Offset: 0x011E7CCA
		private void OnBackButtonClick()
		{
			ControllerBase<DollGrabMachineController>.Instance.PauseDollGrabMachine(false);
		}

		// Token: 0x06044D6C RID: 281964 RVA: 0x011E9AD7 File Offset: 0x011E7CD7
		private void OnHelpInfoButtonClick()
		{
			ControllerBase<DollGrabMachineController>.Instance.PauseDollGrabMachine(true);
		}

		// Token: 0x06044D6D RID: 281965 RVA: 0x011E9AE4 File Offset: 0x011E7CE4
		private void RefreashButton(bool toggle)
		{
			UUIButtonComponent btnBack = this.BtnBack;
			if (btnBack != null)
			{
				btnBack.SetSelfInteractive(toggle);
			}
			UUIButtonComponent btnHelpInfo = this.BtnHelpInfo;
			if (btnHelpInfo == null)
			{
				return;
			}
			btnHelpInfo.SetSelfInteractive(toggle);
		}

		// Token: 0x06044D6E RID: 281966 RVA: 0x011E9B09 File Offset: 0x011E7D09
		private void OnDollGrabMachineEnd(EDollGrabMachineEndReason endReason)
		{
			this.RefreashButton(false);
		}

		// Token: 0x06044D6F RID: 281967 RVA: 0x011E9B12 File Offset: 0x011E7D12
		private void OnDollGrabMachineRestart()
		{
			this.RefreashButton(true);
			if (!ControllerBase<DollGrabMachineController>.Instance.IsEndlessMode)
			{
				base.GetItem(4).SetUIActive(true);
			}
		}

		// Token: 0x06044D70 RID: 281968 RVA: 0x011E9B34 File Offset: 0x011E7D34
		private void OnDollGrabMachineStartCoolDown(Action callback)
		{
			this.RefreashButton(false);
			Singleton<EventSystem>.Instance.Once(EEventName.OnDollGrabMachineEndCoolDown, new Action(this.OnDollGrabMachineEndCoolDown));
			if (!ControllerBase<DollGrabMachineController>.Instance.IsEndlessMode)
			{
				base.GetItem(4).SetUIActive(false);
			}
		}

		// Token: 0x06044D71 RID: 281969 RVA: 0x011E9B72 File Offset: 0x011E7D72
		private void OnDollGrabMachineEndCoolDown()
		{
			this.RefreashButton(true);
		}

		// Token: 0x04026595 RID: 157077
		private UUIButtonComponent BtnHelpInfo;

		// Token: 0x04026596 RID: 157078
		private UUIButtonComponent BtnBack;
	}
}
