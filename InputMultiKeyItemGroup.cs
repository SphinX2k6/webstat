using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001960 RID: 6496
[NullableContext(2)]
[Nullable(0)]
public class InputMultiKeyItemGroup : UiPanelBase
{
	// Token: 0x0600BA53 RID: 47699 RVA: 0x00319E14 File Offset: 0x00318014
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BA54 RID: 47700 RVA: 0x00319EA0 File Offset: 0x003180A0
	protected override UniTask OnBeforeStartAsync()
	{
		InputMultiKeyItemGroup.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<InputMultiKeyItemGroup.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BA55 RID: 47701 RVA: 0x00319EE3 File Offset: 0x003180E3
	protected override void OnStart()
	{
	}

	// Token: 0x0600BA56 RID: 47702 RVA: 0x00319EE5 File Offset: 0x003180E5
	protected override void OnBeforeDestroy()
	{
		this.OneInputMultiKeyItem = null;
		this.TwoInputMultiKeyItem = null;
	}

	// Token: 0x0600BA57 RID: 47703 RVA: 0x00319EF5 File Offset: 0x003180F5
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		if (this.InputActionOrAxisKeyItemGroup != null)
		{
			this.RefreshInternal(this.InputActionOrAxisKeyItemGroup);
		}
	}

	// Token: 0x0600BA58 RID: 47704 RVA: 0x00319F27 File Offset: 0x00318127
	protected override void OnAfterHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
	}

	// Token: 0x0600BA59 RID: 47705 RVA: 0x00319F45 File Offset: 0x00318145
	private void InputControllerChange(EInputControllerType eInputControllerType, EInputControllerType inputControllerType)
	{
		if (this.InputActionOrAxisKeyItemGroup == null)
		{
			return;
		}
		this.RefreshInternal(this.InputActionOrAxisKeyItemGroup);
	}

	// Token: 0x0600BA5A RID: 47706 RVA: 0x00319F5C File Offset: 0x0031815C
	[NullableContext(1)]
	public void Refresh(InputActionOrAxisKeyItemGroup inputActionOrAxisKeyItemGroup)
	{
		this.InputActionOrAxisKeyItemGroup = inputActionOrAxisKeyItemGroup;
		this.RefreshInternal(inputActionOrAxisKeyItemGroup);
	}

	// Token: 0x0600BA5B RID: 47707 RVA: 0x00319F6C File Offset: 0x0031816C
	[NullableContext(1)]
	private void RefreshInternal(InputActionOrAxisKeyItemGroup inputActionOrAxisKeyItemGroup)
	{
		InputActionOrAxisKeyItem singleActionOrAxisKeyItem = inputActionOrAxisKeyItemGroup.SingleActionOrAxisKeyItem;
		InputActionOrAxisKeyItem doubleActionOrAxisKeyItem = inputActionOrAxisKeyItemGroup.DoubleActionOrAxisKeyItem;
		string linkString = inputActionOrAxisKeyItemGroup.LinkString;
		UUIText text = base.GetText(0);
		InputMultiKeyItem oneInputMultiKeyItem = this.OneInputMultiKeyItem;
		if (oneInputMultiKeyItem != null)
		{
			oneInputMultiKeyItem.RefreshByActionOrAxis(singleActionOrAxisKeyItem, false);
		}
		InputMultiKeyItem oneInputMultiKeyItem2 = this.OneInputMultiKeyItem;
		if (oneInputMultiKeyItem2 != null)
		{
			oneInputMultiKeyItem2.SetActive(true);
		}
		if (doubleActionOrAxisKeyItem != null)
		{
			InputMultiKeyItem twoInputMultiKeyItem = this.TwoInputMultiKeyItem;
			if (twoInputMultiKeyItem != null)
			{
				twoInputMultiKeyItem.RefreshByActionOrAxis(doubleActionOrAxisKeyItem, false);
			}
			InputMultiKeyItem twoInputMultiKeyItem2 = this.TwoInputMultiKeyItem;
			if (twoInputMultiKeyItem2 != null)
			{
				twoInputMultiKeyItem2.SetActive(true);
			}
			text.SetText(linkString ?? "/", true);
			text.SetUIActive(true);
			return;
		}
		InputMultiKeyItem twoInputMultiKeyItem3 = this.TwoInputMultiKeyItem;
		if (twoInputMultiKeyItem3 != null)
		{
			twoInputMultiKeyItem3.SetActive(false);
		}
		text.SetUIActive(false);
	}

	// Token: 0x0600BA5C RID: 47708 RVA: 0x0031A015 File Offset: 0x00318215
	public void SetEnable(bool bEnable, bool bForce = false)
	{
		if (this.IsEnable == bEnable && !bForce)
		{
			return;
		}
		if (bEnable)
		{
			this.RootItem.SetAlpha(1f);
		}
		else
		{
			this.RootItem.SetAlpha(0.2f);
		}
		this.IsEnable = bEnable;
	}

	// Token: 0x04005829 RID: 22569
	private InputMultiKeyItem OneInputMultiKeyItem;

	// Token: 0x0400582A RID: 22570
	private InputMultiKeyItem TwoInputMultiKeyItem;

	// Token: 0x0400582B RID: 22571
	private bool IsEnable;

	// Token: 0x0400582C RID: 22572
	private InputActionOrAxisKeyItemGroup InputActionOrAxisKeyItemGroup;

	// Token: 0x02007C7D RID: 31869
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A832 RID: 174130
		public const int AddText = 0;

		// Token: 0x0402A833 RID: 174131
		public const int KeyItem1 = 1;

		// Token: 0x0402A834 RID: 174132
		public const int KeyItem2 = 2;
	}
}
