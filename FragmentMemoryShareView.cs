using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C86 RID: 7302
public class FragmentMemoryShareView : UiPanelBase
{
	// Token: 0x0600D589 RID: 54665 RVA: 0x0038F438 File Offset: 0x0038D638
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D58A RID: 54666 RVA: 0x0038F4E3 File Offset: 0x0038D6E3
	protected override void OnStart()
	{
		this.RefreshView();
	}

	// Token: 0x0600D58B RID: 54667 RVA: 0x0038F4EB File Offset: 0x0038D6EB
	private void RefreshView()
	{
		this.CurrentData = (this.OpenParam as FragmentMemoryCollectData);
		this.RefreshTexture();
		this.RefreshName();
		this.RefreshDesc();
		this.RefreshTime();
	}

	// Token: 0x0600D58C RID: 54668 RVA: 0x0038F516 File Offset: 0x0038D716
	private void RefreshTime()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "FragmentMemoryCollectTime", new <>z__ReadOnlySingleElementList<object>(this.CurrentData.GetTimeText()));
	}

	// Token: 0x0600D58D RID: 54669 RVA: 0x0038F540 File Offset: 0x0038D740
	private void RefreshTexture()
	{
		base.SetTextureByPath(this.CurrentData.GetBgResource(), base.GetTexture(0), null, null);
	}

	// Token: 0x0600D58E RID: 54670 RVA: 0x0038F56F File Offset: 0x0038D76F
	private void RefreshName()
	{
		base.GetText(1).ShowTextNew(this.CurrentData.GetTitle());
	}

	// Token: 0x0600D58F RID: 54671 RVA: 0x0038F588 File Offset: 0x0038D788
	private void RefreshDesc()
	{
		base.GetText(3).ShowTextNew(this.CurrentData.GetDesc());
	}

	// Token: 0x04006554 RID: 25940
	[Nullable(2)]
	private FragmentMemoryCollectData CurrentData;

	// Token: 0x02007FD0 RID: 32720
	private class EComponents
	{
		// Token: 0x0402B7FA RID: 178170
		public const int Texture = 0;

		// Token: 0x0402B7FB RID: 178171
		public const int Name = 1;

		// Token: 0x0402B7FC RID: 178172
		public const int Time = 2;

		// Token: 0x0402B7FD RID: 178173
		public const int Desc = 3;
	}
}
