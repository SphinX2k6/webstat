using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002434 RID: 9268
public class PersonalPlayerTitleMiniPreView : UiPanelBase
{
	// Token: 0x06011ED4 RID: 73428 RVA: 0x004EEA30 File Offset: 0x004ECC30
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06011ED5 RID: 73429 RVA: 0x004EEAB8 File Offset: 0x004ECCB8
	protected override UniTask OnBeforeStartAsync()
	{
		PersonalPlayerTitleMiniPreView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PersonalPlayerTitleMiniPreView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011ED6 RID: 73430 RVA: 0x004EEAFC File Offset: 0x004ECCFC
	[NullableContext(1)]
	public void RefreshView(PersonalPlayerTitleData data)
	{
		if (data == null)
		{
			return;
		}
		int sex = ModelBase<PersonalModel>.Instance.GetSex();
		this.PlayerTitleItem.Refresh(new int?(data.PlayerTitleId), data.StarLevel, new int?(sex));
	}

	// Token: 0x04008C74 RID: 35956
	[Nullable(2)]
	private PlayerTitleItem PlayerTitleItem;

	// Token: 0x0200876E RID: 34670
	private enum EComponent
	{
		// Token: 0x0402DCA0 RID: 187552
		PnlSatate,
		// Token: 0x0402DCA1 RID: 187553
		ItemCard,
		// Token: 0x0402DCA2 RID: 187554
		ItemUsed,
		// Token: 0x0402DCA3 RID: 187555
		ItemLock,
		// Token: 0x0402DCA4 RID: 187556
		PersonalTitleItem
	}
}
