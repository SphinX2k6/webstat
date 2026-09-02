using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CF6 RID: 7414
[NullableContext(1)]
[Nullable(0)]
public class UpWeaponGachaPoolItem : GachaPoolItem
{
	// Token: 0x17001151 RID: 4433
	// (get) Token: 0x0600D9A6 RID: 55718 RVA: 0x003A649D File Offset: 0x003A469D
	private bool IsLock
	{
		get
		{
			return this.Operating;
		}
	}

	// Token: 0x0600D9A7 RID: 55719 RVA: 0x003A64A5 File Offset: 0x003A46A5
	public UpWeaponGachaPoolItem(GachaDefine.EGachaViewType gachaType) : base(gachaType)
	{
	}

	// Token: 0x0600D9A8 RID: 55720 RVA: 0x003A64D0 File Offset: 0x003A46D0
	private void Lock()
	{
		this.Operating = true;
	}

	// Token: 0x0600D9A9 RID: 55721 RVA: 0x003A64DC File Offset: 0x003A46DC
	private void Unlock()
	{
		this.Operating = false;
		if (this.OperationQueue.Size == 0)
		{
			return;
		}
		int weaponId = this.OperationQueue.Pop();
		this.UpdateByWeaponId(weaponId);
	}

	// Token: 0x0600D9AA RID: 55722 RVA: 0x003A6514 File Offset: 0x003A4714
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D9AB RID: 55723 RVA: 0x003A65A0 File Offset: 0x003A47A0
	protected override UniTask OnBeforeStartAsync()
	{
		UpWeaponGachaPoolItem.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<UpWeaponGachaPoolItem.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D9AC RID: 55724 RVA: 0x003A65E3 File Offset: 0x003A47E3
	protected override void OnPlayStartSeq()
	{
		if (this.CurWeaponItem != null)
		{
			this.PlayWeaponStartSeq(this.CurWeaponItem);
		}
	}

	// Token: 0x0600D9AD RID: 55725 RVA: 0x003A65F9 File Offset: 0x003A47F9
	protected override void OnAfterHide()
	{
		this.ResetCurrentShowWeaponItem();
	}

	// Token: 0x0600D9AE RID: 55726 RVA: 0x003A6604 File Offset: 0x003A4804
	public override void Refresh()
	{
		if (this.GachaViewInfo == null)
		{
			return;
		}
		int weaponId = this.GachaViewInfo.Value.GetShowIdListArray()[0];
		this.UpdateByWeaponId(weaponId);
	}

	// Token: 0x0600D9AF RID: 55727 RVA: 0x003A663C File Offset: 0x003A483C
	private void UpdateByWeaponId(int weaponId)
	{
		if (this.IsLock)
		{
			this.OperationQueue.Push(weaponId);
			return;
		}
		this.Lock();
		this.UpdateByWeaponIdAsync(weaponId).ContinueWith(new Action(this.Unlock)).Forget();
	}

	// Token: 0x0600D9B0 RID: 55728 RVA: 0x003A6678 File Offset: 0x003A4878
	private UniTask UpdateByWeaponIdAsync(int weaponId)
	{
		UpWeaponGachaPoolItem.<UpdateByWeaponIdAsync>d__18 <UpdateByWeaponIdAsync>d__;
		<UpdateByWeaponIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateByWeaponIdAsync>d__.<>4__this = this;
		<UpdateByWeaponIdAsync>d__.weaponId = weaponId;
		<UpdateByWeaponIdAsync>d__.<>1__state = -1;
		<UpdateByWeaponIdAsync>d__.<>t__builder.Start<UpWeaponGachaPoolItem.<UpdateByWeaponIdAsync>d__18>(ref <UpdateByWeaponIdAsync>d__);
		return <UpdateByWeaponIdAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D9B1 RID: 55729 RVA: 0x003A66C4 File Offset: 0x003A48C4
	private void PlayWeaponStartSeq(UUIItem weaponItem)
	{
		LevelSequencePlayer levelSequencePlayer;
		if (!this.LevelSequencePlayerMap.TryGetValue(weaponItem, out levelSequencePlayer))
		{
			return;
		}
		levelSequencePlayer.StopSequenceByKey("Loop", false, false);
		levelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x0600D9B2 RID: 55730 RVA: 0x003A6704 File Offset: 0x003A4904
	[NullableContext(2)]
	private void StopPlayWeaponItemSequence(UUIItem weaponItem)
	{
		if (weaponItem == null)
		{
			return;
		}
		LevelSequencePlayer levelSequencePlayer;
		if (this.LevelSequencePlayerMap.TryGetValue(weaponItem, out levelSequencePlayer))
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
	}

	// Token: 0x0600D9B3 RID: 55731 RVA: 0x003A672D File Offset: 0x003A492D
	private void ResetCurrentShowWeaponItem()
	{
		if (this.CurWeaponItem == null)
		{
			return;
		}
		this.CurWeaponItem.SetUIActive(false);
		this.StopPlayWeaponItemSequence(this.CurWeaponItem);
		this.CurWeaponItem = null;
	}

	// Token: 0x040067DD RID: 26589
	[Nullable(2)]
	private WeaponDescribeComponent DescComponent;

	// Token: 0x040067DE RID: 26590
	private readonly Dictionary<string, UUIItem> WeaponItemMap = new Dictionary<string, UUIItem>();

	// Token: 0x040067DF RID: 26591
	private readonly Dictionary<UUIItem, LevelSequencePlayer> LevelSequencePlayerMap = new Dictionary<UUIItem, LevelSequencePlayer>();

	// Token: 0x040067E0 RID: 26592
	[Nullable(2)]
	private UUIItem CurWeaponItem;

	// Token: 0x040067E1 RID: 26593
	private readonly Queue<int> OperationQueue = new Queue<int>(4);

	// Token: 0x040067E2 RID: 26594
	private bool Operating;

	// Token: 0x02008063 RID: 32867
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402BAC6 RID: 178886
		ContentRootItem,
		// Token: 0x0402BAC7 RID: 178887
		DescItem,
		// Token: 0x0402BAC8 RID: 178888
		ThemeTextTexture
	}
}
