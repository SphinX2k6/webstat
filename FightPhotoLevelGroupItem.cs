using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

// Token: 0x02001332 RID: 4914
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FightPhotoLevelGroupItem : AutoAttachItem<FightPhotoLevelGroupData>
{
	// Token: 0x06008620 RID: 34336 RVA: 0x00235761 File Offset: 0x00233961
	public FightPhotoLevelGroupItem(AActor uiItem = null) : base(null)
	{
	}

	// Token: 0x06008621 RID: 34337 RVA: 0x0023576C File Offset: 0x0023396C
	protected unsafe override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		int num = 1;
		List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
		Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list;
	}

	// Token: 0x06008622 RID: 34338 RVA: 0x00235871 File Offset: 0x00233A71
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CheckCanClick));
	}

	// Token: 0x06008623 RID: 34339 RVA: 0x00235895 File Offset: 0x00233A95
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshFightPhotoLevelRedDot, new Action(this.OnRefreshFightPhotoLevelRedDot));
	}

	// Token: 0x06008624 RID: 34340 RVA: 0x002358B3 File Offset: 0x00233AB3
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshFightPhotoLevelRedDot, new Action(this.OnRefreshFightPhotoLevelRedDot));
	}

	// Token: 0x06008625 RID: 34341 RVA: 0x002358D1 File Offset: 0x00233AD1
	public override void OnSelect()
	{
		if (this.Data != null && this.OnSelectCallback != null)
		{
			this.OnSelectCallback(base.GetItemIndex(), this.Data);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06008626 RID: 34342 RVA: 0x0023590F File Offset: 0x00233B0F
	protected override void OnUnSelect()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06008627 RID: 34343 RVA: 0x00235928 File Offset: 0x00233B28
	protected override void OnRefreshItem(FightPhotoLevelGroupData data)
	{
		this.Data = data;
		bool flag = data != null;
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(flag && data.IsFinished);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(flag && !data.IsUnLock);
		}
		UUITexture texture = base.GetTexture(4);
		if (texture != null)
		{
			texture.SetUIActive(flag);
		}
		UUITexture texture2 = base.GetTexture(5);
		if (texture2 != null)
		{
			texture2.SetUIActive(flag);
		}
		UUIText text = base.GetText(6);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		this.RefreshRedDot();
		if (!flag)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_BattlePhotoRoleEmpty");
			base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
			base.GetExtendToggle(0).SetSelfInteractive(false);
		}
		else
		{
			base.GetExtendToggle(0).SetSelfInteractive(true);
			string path = this.Data.IsUnLock ? this.Data.RoleTextureLight : this.Data.RoleTextureDark;
			base.SetTextureByPath(path, base.GetTexture(1), null, null);
			base.SetTextureByPath(this.Data.NumTexture, base.GetTexture(4), null, null);
			base.SetTextureByPath(this.Data.NumTexture2, base.GetTexture(5), null, null);
		}
		if (this.Data != null && !this.Data.IsUnLock)
		{
			this.AddTimer();
			return;
		}
		this.RemoveTimer();
	}

	// Token: 0x06008628 RID: 34344 RVA: 0x00235AAD File Offset: 0x00233CAD
	private void UpdateUnlock(float delta)
	{
		if (this.Data != null && this.Data.IsUnLock)
		{
			this.OnRefreshItem(this.Data);
		}
	}

	// Token: 0x06008629 RID: 34345 RVA: 0x00235AD0 File Offset: 0x00233CD0
	private void AddTimer()
	{
		this.RemoveTimer();
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.UpdateUnlock), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
	}

	// Token: 0x0600862A RID: 34346 RVA: 0x00235B07 File Offset: 0x00233D07
	private void RemoveTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x0600862B RID: 34347 RVA: 0x00235B29 File Offset: 0x00233D29
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		this.RemoveTimer();
	}

	// Token: 0x0600862C RID: 34348 RVA: 0x00235B38 File Offset: 0x00233D38
	public void RefreshRedDot()
	{
		bool uiactive = this.Data != null && this.Data.HasRedDot;
		UUIItem item = base.GetItem(7);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600862D RID: 34349 RVA: 0x00235B6E File Offset: 0x00233D6E
	private void OnRefreshFightPhotoLevelRedDot()
	{
		this.RefreshRedDot();
	}

	// Token: 0x0600862E RID: 34350 RVA: 0x00235B76 File Offset: 0x00233D76
	protected override void OnMoveItem()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600862F RID: 34351 RVA: 0x00235B8D File Offset: 0x00233D8D
	private void OnToggleClick(EToggleState toggleState)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		}
		Action<int, FightPhotoLevelGroupData> onToggleClickCallback = this.OnToggleClickCallback;
		if (onToggleClickCallback == null)
		{
			return;
		}
		onToggleClickCallback(base.GetItemIndex(), this.Data);
	}

	// Token: 0x06008630 RID: 34352 RVA: 0x00235BC1 File Offset: 0x00233DC1
	private bool CheckCanClick()
	{
		return this.CheckToggleCanClick == null || this.CheckToggleCanClick();
	}

	// Token: 0x04003F71 RID: 16241
	private FightPhotoLevelGroupData Data;

	// Token: 0x04003F72 RID: 16242
	private TimerHandle TimerHandle;

	// Token: 0x04003F73 RID: 16243
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, FightPhotoLevelGroupData> OnToggleClickCallback;

	// Token: 0x04003F74 RID: 16244
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, FightPhotoLevelGroupData> OnSelectCallback;

	// Token: 0x04003F75 RID: 16245
	public Func<bool> CheckToggleCanClick;

	// Token: 0x020076D5 RID: 30421
	[NullableContext(0)]
	private enum EComponentDefine
	{
		// Token: 0x04028EE7 RID: 167655
		ToggleRoot,
		// Token: 0x04028EE8 RID: 167656
		TextureRole,
		// Token: 0x04028EE9 RID: 167657
		ItemFinished,
		// Token: 0x04028EEA RID: 167658
		ItemLock,
		// Token: 0x04028EEB RID: 167659
		TextureNum,
		// Token: 0x04028EEC RID: 167660
		TextureNum2,
		// Token: 0x04028EED RID: 167661
		TextName,
		// Token: 0x04028EEE RID: 167662
		ItemRedDot
	}
}
