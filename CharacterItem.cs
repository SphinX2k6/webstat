using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013B7 RID: 5047
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CharacterItem : GridProxyAbstract<CharacterData>
{
	// Token: 0x06008B4B RID: 35659 RVA: 0x0024B20B File Offset: 0x0024940B
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06008B4C RID: 35660 RVA: 0x0024B244 File Offset: 0x00249444
	protected override UniTask OnBeforeStartAsync()
	{
		CharacterItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CharacterItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008B4D RID: 35661 RVA: 0x0024B287 File Offset: 0x00249487
	public override void Refresh(CharacterData data, bool isSelected, int gridIndex)
	{
		this.Id = data.Id;
		this.NameItem.Refresh(data, false, 0);
		this.ValueItem.Refresh(data, false, 0);
	}

	// Token: 0x06008B4E RID: 35662 RVA: 0x0024B2B1 File Offset: 0x002494B1
	public void RefreshName(CharacterData data)
	{
		this.NameItem.Refresh(data, false, 0);
	}

	// Token: 0x06008B4F RID: 35663 RVA: 0x0024B2C1 File Offset: 0x002494C1
	public void RefreshProgress(int value, int maxValue)
	{
		this.ValueItem.RefreshProgress(value, maxValue);
	}

	// Token: 0x06008B50 RID: 35664 RVA: 0x0024B2D0 File Offset: 0x002494D0
	public void RefreshCurrentValue(int value)
	{
		this.ValueItem.RefreshCurrentValue(value);
	}

	// Token: 0x06008B51 RID: 35665 RVA: 0x0024B2DE File Offset: 0x002494DE
	public void RefreshProgressAdd(int value, int maxValue)
	{
		this.ValueItem.RefreshProgressAdd(value, maxValue);
	}

	// Token: 0x06008B52 RID: 35666 RVA: 0x0024B2ED File Offset: 0x002494ED
	public void SetLightProgressWidth()
	{
		this.ValueItem.SetLightProgressWidth();
	}

	// Token: 0x06008B53 RID: 35667 RVA: 0x0024B2FA File Offset: 0x002494FA
	public void SetGoodItemActive(bool value)
	{
		CharacterNameItem nameItem = this.NameItem;
		if (nameItem == null)
		{
			return;
		}
		nameItem.SetGoodItemActive(value);
	}

	// Token: 0x06008B54 RID: 35668 RVA: 0x0024B30D File Offset: 0x0024950D
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x04004112 RID: 16658
	[Nullable(2)]
	protected CharacterNameItem NameItem;

	// Token: 0x04004113 RID: 16659
	[Nullable(2)]
	protected CharacterValueItem ValueItem;

	// Token: 0x04004114 RID: 16660
	protected int Id;

	// Token: 0x0200777D RID: 30589
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x04029237 RID: 168503
		public const int NameItem = 0;

		// Token: 0x04029238 RID: 168504
		public const int ValueItem = 1;
	}
}
