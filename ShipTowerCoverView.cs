using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029B0 RID: 10672
public class ShipTowerCoverView : UiViewBase
{
	// Token: 0x0601546D RID: 87149 RVA: 0x005E5754 File Offset: 0x005E3954
	[NullableContext(1)]
	public ShipTowerCoverView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601546E RID: 87150 RVA: 0x005E5760 File Offset: 0x005E3960
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601546F RID: 87151 RVA: 0x005E57EC File Offset: 0x005E39EC
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerCoverView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerCoverView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015470 RID: 87152 RVA: 0x005E5830 File Offset: 0x005E3A30
	protected override void OnBeforeShow()
	{
		ShipTowerStageData stageData = (this.OpenParam as ShipTowerCoverViewParams).StageData;
		this.LeftItem.UpdateData(stageData, false);
		this.RightItem.UpdateData(stageData, true);
	}

	// Token: 0x06015471 RID: 87153 RVA: 0x005E5868 File Offset: 0x005E3A68
	[NullableContext(1)]
	private void OnConfirmCallback(ShipTowerStageData data, bool isCover)
	{
		this.SureCover = isCover;
		if (isCover)
		{
			data.SureCoverChallenge().Forget();
		}
		base.CloseMe(null);
	}

	// Token: 0x06015472 RID: 87154 RVA: 0x005E5888 File Offset: 0x005E3A88
	protected override void OnBeforeDestroy()
	{
		if (!this.SureCover)
		{
			ShipTowerStageData stageData = (this.OpenParam as ShipTowerCoverViewParams).StageData;
			stageData.UpdateToEdit();
			ModelBase<ShipTowerModel>.Instance.SetChallengeStageDataNull();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ShipTowerStageUpdate, stageData.Id);
		}
	}

	// Token: 0x0400A410 RID: 42000
	[Nullable(2)]
	private ShipTowerCoverItem LeftItem;

	// Token: 0x0400A411 RID: 42001
	[Nullable(2)]
	private ShipTowerCoverItem RightItem;

	// Token: 0x0400A412 RID: 42002
	private bool SureCover;

	// Token: 0x02008D01 RID: 36097
	private enum EChildType
	{
		// Token: 0x0402F6E0 RID: 194272
		ItemLeft,
		// Token: 0x0402F6E1 RID: 194273
		ItemRight,
		// Token: 0x0402F6E2 RID: 194274
		TxtTitle
	}
}
