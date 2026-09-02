using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.DreamLink;
using UnrealEngine;

// Token: 0x02001479 RID: 5241
public class NewPlayerSupportRoleSpineItem : NewPlayerSupportRoleBaseItem
{
	// Token: 0x060092B3 RID: 37555 RVA: 0x0026B3A8 File Offset: 0x002695A8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060092B4 RID: 37556 RVA: 0x0026B432 File Offset: 0x00269632
	protected override void OnStart()
	{
		base.OnStart();
		base.GetItem(0).SetUIActive(false);
		base.GetTexture(1).SetUIActive(false);
	}

	// Token: 0x060092B5 RID: 37557 RVA: 0x0026B454 File Offset: 0x00269654
	public override void Refresh()
	{
		base.GetSpine(2).SetAnimation(0, EDreamLinkSpineDefine.Idle.ToString(), true);
	}

	// Token: 0x02007886 RID: 30854
	private class EComponentType
	{
		// Token: 0x04029728 RID: 169768
		public const int DescItem = 0;

		// Token: 0x04029729 RID: 169769
		public const int ThemeTextTexture = 1;

		// Token: 0x0402972A RID: 169770
		public const int SpineActor = 2;
	}
}
