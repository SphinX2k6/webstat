using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001FA9 RID: 8105
public class FollowShootAimUnit : HudUnitBase
{
	// Token: 0x0600F3C0 RID: 62400 RVA: 0x0042AEE8 File Offset: 0x004290E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F3C1 RID: 62401 RVA: 0x0042B080 File Offset: 0x00429280
	protected override void OnStart()
	{
		base.OnStart();
		base.InitTweenAnim(9);
		base.InitTweenAnim(10);
		for (int i = 0; i <= 8; i++)
		{
			this.IconList.Add(base.GetTexture(i));
		}
	}

	// Token: 0x0600F3C2 RID: 62402 RVA: 0x0042B0C4 File Offset: 0x004292C4
	public void RefreshState(bool isYellow, bool bForce = false)
	{
		if (this.IsYellowState == isYellow && !bForce)
		{
			return;
		}
		this.IsYellowState = isYellow;
		foreach (UUIItem uuiitem in this.IconList)
		{
			UUIItem uuiitem2 = uuiitem;
			FColor? fcolor = new FColor?(uuiitem.changeColor);
			uuiitem2.SetChangeColor(isYellow, fcolor);
		}
	}

	// Token: 0x0600F3C3 RID: 62403 RVA: 0x0042B13C File Offset: 0x0042933C
	public void SetIsAimTarget(bool isAimTarget)
	{
		if (this.IsAimTarget == isAimTarget)
		{
			return;
		}
		this.IsAimTarget = isAimTarget;
		if (this.IsAimTarget)
		{
			base.StopTweenAnim(10);
			base.PlayTweenAnim(9);
			return;
		}
		base.StopTweenAnim(9);
		base.PlayTweenAnim(10);
	}

	// Token: 0x04007545 RID: 30021
	[Nullable(1)]
	private readonly List<UUIItem> IconList = new List<UUIItem>();

	// Token: 0x04007546 RID: 30022
	private bool IsYellowState;

	// Token: 0x04007547 RID: 30023
	private bool IsAimTarget;

	// Token: 0x0200832B RID: 33579
	private enum EChildType
	{
		// Token: 0x0402C7CD RID: 182221
		AimTexture1,
		// Token: 0x0402C7CE RID: 182222
		AimTexture2,
		// Token: 0x0402C7CF RID: 182223
		AimTexture3,
		// Token: 0x0402C7D0 RID: 182224
		AimTexture4,
		// Token: 0x0402C7D1 RID: 182225
		AimTexture5,
		// Token: 0x0402C7D2 RID: 182226
		AimTexture6,
		// Token: 0x0402C7D3 RID: 182227
		AimTexture7,
		// Token: 0x0402C7D4 RID: 182228
		AimTexture8,
		// Token: 0x0402C7D5 RID: 182229
		AimTexture9,
		// Token: 0x0402C7D6 RID: 182230
		AnimStart,
		// Token: 0x0402C7D7 RID: 182231
		AnimStop
	}
}
