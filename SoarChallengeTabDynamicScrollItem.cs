using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001393 RID: 5011
[NullableContext(1)]
[Nullable(0)]
public class SoarChallengeTabDynamicScrollItem : UiPanelBase, IDynamicScrollItem<SoarChallengePlayData>
{
	// Token: 0x060089C6 RID: 35270 RVA: 0x00243DB8 File Offset: 0x00241FB8
	public UniTask Init(UUIItem actor)
	{
		SoarChallengeTabDynamicScrollItem.<Init>d__5 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<SoarChallengeTabDynamicScrollItem.<Init>d__5>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060089C7 RID: 35271 RVA: 0x00243E04 File Offset: 0x00242004
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060089C8 RID: 35272 RVA: 0x00243E70 File Offset: 0x00242070
	protected override UniTask OnBeforeStartAsync()
	{
		SoarChallengeTabDynamicScrollItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SoarChallengeTabDynamicScrollItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060089C9 RID: 35273 RVA: 0x00243EB3 File Offset: 0x002420B3
	public AUIBaseActor GetUsingItem(SoarChallengePlayData data)
	{
		if (data.IsUnlock)
		{
			return this.GetItemActor(1);
		}
		return this.GetItemActor(0);
	}

	// Token: 0x060089CA RID: 35274 RVA: 0x00243ECC File Offset: 0x002420CC
	private AUIBaseActor GetItemActor(int key)
	{
		return base.GetItem(key).GetOwner() as AUIBaseActor;
	}

	// Token: 0x060089CB RID: 35275 RVA: 0x00243EE0 File Offset: 0x002420E0
	public void Update(SoarChallengePlayData data, int index)
	{
		this.Data = data;
		this.LockItem.SetUiActive(!data.IsUnlock);
		this.NormalItem.SetUiActive(data.IsUnlock);
		if (!data.IsUnlock)
		{
			this.LockItem.RefreshByData(data);
		}
		else
		{
			this.NormalItem.RefreshByData(data);
		}
		if (this.IsSelectedOn != null && this.IsSelectedOn(data))
		{
			this.SetSelected(true, false);
			return;
		}
		this.SetSelected(false, false);
	}

	// Token: 0x060089CC RID: 35276 RVA: 0x00243F62 File Offset: 0x00242162
	public void SetSelected(bool bOn, bool bFireEvent)
	{
		this.LockItem.SetToggleState(bOn, bFireEvent && !this.Data.IsUnlock);
		this.NormalItem.SetToggleState(bOn, bFireEvent && this.Data.IsUnlock);
	}

	// Token: 0x060089CD RID: 35277 RVA: 0x00243FA1 File Offset: 0x002421A1
	public void SetItemNewVisible(bool bVisible)
	{
		if (this.Data == null || !this.Data.IsUnlock)
		{
			return;
		}
		this.NormalItem.SetItemNewVisible(bVisible);
	}

	// Token: 0x060089CE RID: 35278 RVA: 0x00243FC5 File Offset: 0x002421C5
	public void BindSelectedCallBack(Action<SoarChallengePlayData> selectCallback)
	{
		this.SelectedCallBack = selectCallback;
	}

	// Token: 0x060089CF RID: 35279 RVA: 0x00243FCE File Offset: 0x002421CE
	public void BindIsSelectedOn(Func<SoarChallengePlayData, bool> isSelectedOn)
	{
		this.IsSelectedOn = isSelectedOn;
	}

	// Token: 0x060089D0 RID: 35280 RVA: 0x00243FD7 File Offset: 0x002421D7
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x04004092 RID: 16530
	[Nullable(2)]
	private MapTravelTabItem NormalItem;

	// Token: 0x04004093 RID: 16531
	[Nullable(2)]
	private MapTravelTabItemLock LockItem;

	// Token: 0x04004094 RID: 16532
	[Nullable(2)]
	protected SoarChallengePlayData Data;

	// Token: 0x04004095 RID: 16533
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Action<SoarChallengePlayData> SelectedCallBack;

	// Token: 0x04004096 RID: 16534
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Func<SoarChallengePlayData, bool> IsSelectedOn;

	// Token: 0x02007732 RID: 30514
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040290B5 RID: 168117
		public const int NormalItem = 0;

		// Token: 0x040290B6 RID: 168118
		public const int LockItem = 1;
	}
}
