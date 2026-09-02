using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Core.Common;
using CSharpScript.Game.Input;
using CSharpScript.Game.KuroSimpleCombat;
using UnrealEngine;

// Token: 0x02000F8C RID: 3980
[NullableContext(2)]
[Nullable(0)]
public class TowerDefenseInputLayer : InputLayer
{
	// Token: 0x06006536 RID: 25910 RVA: 0x00195346 File Offset: 0x00193546
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.TowerDefense;
	}

	// Token: 0x06006537 RID: 25911 RVA: 0x0019534C File Offset: 0x0019354C
	public unsafe override SInputCommand HandlePress(CSharpScript.Game.Input.EInputAction action, float time)
	{
		KscLog.EModule flag = KscLog.EModule.Input;
		ELogAuthor author = ELogAuthor.PZ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "塔防输入层按下";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("action", action);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("action name", action.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("time", time);
		KscLog.Debug(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		switch (action)
		{
		case 1:
		{
			FGameplayTag tagValue = default(FGameplayTag);
			return new SInputCommand(ECommandType.Jump, 1, tagValue);
		}
		case 3:
			return null;
		case 4:
			this.ExecShootAction(EKSC_OperateType.OnPress, time);
			return InputLayer.GetSwallowCommand();
		case 5:
		{
			FGameplayTag tagValue2 = default(FGameplayTag);
			return new SInputCommand(ECommandType.Sprint, 1, tagValue2);
		}
		case 7:
			this.TriggerUseItemAction();
			return InputLayer.GetSwallowCommand();
		}
		return InputLayer.GetSwallowCommand();
	}

	// Token: 0x06006538 RID: 25912 RVA: 0x00195458 File Offset: 0x00193658
	public unsafe override SInputCommand HandleRelease(CSharpScript.Game.Input.EInputAction action, float time)
	{
		KscLog.EModule flag = KscLog.EModule.Input;
		ELogAuthor author = ELogAuthor.PZ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "塔防输入层抬起";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("action", action);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("action name", action.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("time", time);
		KscLog.Debug(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		byte b = action;
		if (b == 4)
		{
			this.ExecShootAction(EKSC_OperateType.OnRelease, time);
			return InputLayer.GetSwallowCommand();
		}
		if (b != 7)
		{
			return InputLayer.GetSwallowCommand();
		}
		this.ExecUseItemAction();
		return InputLayer.GetSwallowCommand();
	}

	// Token: 0x06006539 RID: 25913 RVA: 0x0019551C File Offset: 0x0019371C
	public unsafe override SInputCommand HandleHold(CSharpScript.Game.Input.EInputAction action, float time)
	{
		KscLog.EModule flag = KscLog.EModule.Input;
		ELogAuthor author = ELogAuthor.PZ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "塔防输入层长按";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("action", action);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("action name", action.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("time", time);
		KscLog.Debug(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		byte b = action;
		if (b == 4)
		{
			this.ExecShootAction(EKSC_OperateType.OnHold, time);
			return InputLayer.GetSwallowCommand();
		}
		if (b != 7)
		{
			return InputLayer.GetSwallowCommand();
		}
		this.CancelUseItemAction();
		return InputLayer.GetSwallowCommand();
	}

	// Token: 0x0600653A RID: 25914 RVA: 0x001955DE File Offset: 0x001937DE
	private void ExecShootAction(EKSC_OperateType operateType, float time)
	{
		TowerDefensePlayerController.HandleTowerDefenseCommit(operateType, time);
	}

	// Token: 0x0600653B RID: 25915 RVA: 0x001955E7 File Offset: 0x001937E7
	private void ExecUseItemAction()
	{
		if (!this.IsInLongTimeUseItem)
		{
			TowerDefensePlayerController.HandleUseItem();
		}
		this.IsInLongTimeUseItem = false;
	}

	// Token: 0x0600653C RID: 25916 RVA: 0x001955FD File Offset: 0x001937FD
	private void TriggerUseItemAction()
	{
		this.IsInLongTimeUseItem = false;
	}

	// Token: 0x0600653D RID: 25917 RVA: 0x00195606 File Offset: 0x00193806
	private void CancelUseItemAction()
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			this.IsInLongTimeUseItem = true;
		}
	}

	// Token: 0x04003038 RID: 12344
	private bool IsInLongTimeUseItem;
}
