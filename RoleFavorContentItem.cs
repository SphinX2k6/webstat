using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002857 RID: 10327
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleFavorContentItem : GridProxyAbstract<RoleFavorContentDataBase>
{
	// Token: 0x060147AE RID: 83886 RVA: 0x005AEF8C File Offset: 0x005AD18C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnToggleClick)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnButtonClick))
		};
	}

	// Token: 0x060147AF RID: 83887 RVA: 0x005AF07C File Offset: 0x005AD27C
	protected override void OnStart()
	{
		this.Toggle = base.GetExtendToggle(4);
		this.Button = base.GetButton(6);
		UUIButtonComponent button = this.Button;
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x060147B0 RID: 83888 RVA: 0x005AF0C1 File Offset: 0x005AD2C1
	[NullableContext(1)]
	public override void Refresh(RoleFavorContentDataBase data, bool isSelected, int gridIndex)
	{
		this.ContentData = data;
		base.GridIndex = gridIndex;
		base.DisplayIndex = gridIndex;
		this.RefreshContentItem();
	}

	// Token: 0x060147B1 RID: 83889 RVA: 0x005AF0E0 File Offset: 0x005AD2E0
	public void RefreshContentItem()
	{
		switch (this.ContentData.FavorContentType)
		{
		case EFavorContentType.Voice:
			this.InitVoiceInfo();
			if (this.Toggle != null)
			{
				this.Toggle.bToggleOnSelect = false;
				return;
			}
			break;
		case EFavorContentType.ExperienceFile:
		case EFavorContentType.ExperienceStory:
			this.InitExperienceInfo();
			return;
		case EFavorContentType.Action:
			this.InitActionInfo();
			if (this.Toggle != null)
			{
				this.Toggle.bToggleOnSelect = false;
				return;
			}
			break;
		case EFavorContentType.PreciousItem:
			this.InitPreciousItem();
			break;
		default:
			return;
		}
	}

	// Token: 0x060147B2 RID: 83890 RVA: 0x005AF157 File Offset: 0x005AD357
	[NullableContext(1)]
	public void BindToggleFunction(TRoleFavorContentItemToggleFunction toggleFunction)
	{
		this.ToggleFunction = toggleFunction;
	}

	// Token: 0x060147B3 RID: 83891 RVA: 0x005AF160 File Offset: 0x005AD360
	[NullableContext(1)]
	public void BindButtonFunction(TRoleFavorContentItemButtonFunction buttonFunction)
	{
		this.ButtonFunction = buttonFunction;
	}

	// Token: 0x060147B4 RID: 83892 RVA: 0x005AF16C File Offset: 0x005AD36C
	private void OnToggleClick(EToggleState state)
	{
		if (this.ToggleFunction != null)
		{
			bool flag = state == EToggleState.ETT_Checked;
			UUIButtonComponent button = this.Button;
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(flag);
			}
			this.ToggleFunction(flag, this.ContentData, this);
		}
	}

	// Token: 0x060147B5 RID: 83893 RVA: 0x005AF1B8 File Offset: 0x005AD3B8
	private void OnButtonClick()
	{
		if (this.ButtonFunction != null)
		{
			this.ButtonFunction(this.ContentData, this);
		}
	}

	// Token: 0x060147B6 RID: 83894 RVA: 0x005AF1D4 File Offset: 0x005AD3D4
	private void InitRoleBaseInfo()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "FavorBaseInfo", Array.Empty<object>());
		this.SetLockItemActive(false);
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.FavorItemStatus = new EFavorItemStatus?(EFavorItemStatus.ItemUnLocked);
	}

	// Token: 0x060147B7 RID: 83895 RVA: 0x005AF224 File Offset: 0x005AD424
	private void InitRolePowerFile()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "FavorPowerFile", Array.Empty<object>());
		this.SetLockItemActive(false);
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.FavorItemStatus = new EFavorItemStatus?(EFavorItemStatus.ItemUnLocked);
	}

	// Token: 0x060147B8 RID: 83896 RVA: 0x005AF274 File Offset: 0x005AD474
	private void InitExperienceInfo()
	{
		RoleFavorRoleInfoContentData roleFavorRoleInfoContentData = this.ContentData as RoleFavorRoleInfoContentData;
		if (roleFavorRoleInfoContentData == null)
		{
			this.InitRoleExperience();
			return;
		}
		EFavorExperienceSubType favorExperienceSubType = roleFavorRoleInfoContentData.FavorExperienceSubType;
		if (favorExperienceSubType == EFavorExperienceSubType.RoleBaseInfo)
		{
			this.InitRoleBaseInfo();
			return;
		}
		if (favorExperienceSubType == EFavorExperienceSubType.RolePowerFile)
		{
			this.InitRolePowerFile();
			return;
		}
		this.InitRoleExperience();
	}

	// Token: 0x060147B9 RID: 83897 RVA: 0x005AF2BC File Offset: 0x005AD4BC
	private void InitRoleExperience()
	{
		RoleFavorStoryContentData roleFavorStoryContentData = this.ContentData as RoleFavorStoryContentData;
		if (roleFavorStoryContentData == null)
		{
			return;
		}
		this.InitLockState();
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(roleFavorStoryContentData.Title, true);
		}
		this.RefreshRedDot();
	}

	// Token: 0x060147BA RID: 83898 RVA: 0x005AF300 File Offset: 0x005AD500
	private void InitActionInfo()
	{
		RoleFavorActionContentData roleFavorActionContentData = this.ContentData as RoleFavorActionContentData;
		if (roleFavorActionContentData == null)
		{
			return;
		}
		this.InitLockState();
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(roleFavorActionContentData.Title, true);
		}
		if (this.FavorItemStatus.GetValueOrDefault() == EFavorItemStatus.ItemUnLocked)
		{
			this.SetPlayerState(EFavorPlayerStatus.Stop);
		}
		this.InitMontageCompletedFunction();
		this.RefreshRedDot();
	}

	// Token: 0x060147BB RID: 83899 RVA: 0x005AF360 File Offset: 0x005AD560
	private void InitVoiceInfo()
	{
		RoleFavorVoiceContentData roleFavorVoiceContentData = this.ContentData as RoleFavorVoiceContentData;
		if (roleFavorVoiceContentData == null)
		{
			return;
		}
		this.InitLockState();
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(roleFavorVoiceContentData.Title, true);
		}
		EFavorItemStatus? favorItemStatus = this.FavorItemStatus;
		EFavorItemStatus efavorItemStatus = EFavorItemStatus.ItemLocked;
		if (!(favorItemStatus.GetValueOrDefault() == efavorItemStatus & favorItemStatus != null))
		{
			this.SetPlayerState(EFavorPlayerStatus.Stop);
		}
		this.InitAudioCompletedFunction();
		this.RefreshRedDot();
	}

	// Token: 0x060147BC RID: 83900 RVA: 0x005AF3CC File Offset: 0x005AD5CC
	private void InitPreciousItem()
	{
		RoleFavorPreciousItemContentData roleFavorPreciousItemContentData = this.ContentData as RoleFavorPreciousItemContentData;
		if (roleFavorPreciousItemContentData == null)
		{
			return;
		}
		this.InitLockState();
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(roleFavorPreciousItemContentData.Title, true);
		}
		if (this.FavorItemStatus.GetValueOrDefault() != EFavorItemStatus.ItemUnLocked)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "Unknown", Array.Empty<object>());
		}
		this.RefreshRedDot();
	}

	// Token: 0x060147BD RID: 83901 RVA: 0x005AF430 File Offset: 0x005AD630
	private void InitMontageCompletedFunction()
	{
		if (this.OnMontageCompleted == null)
		{
			this.OnMontageCompleted = delegate(UAnimMontage montage, bool bInterrupted)
			{
				if (bInterrupted)
				{
					return;
				}
				this.EndPlay();
			};
		}
	}

	// Token: 0x060147BE RID: 83902 RVA: 0x005AF44C File Offset: 0x005AD64C
	private void InitAudioCompletedFunction()
	{
		if (this.CloseAudioDelegate == null)
		{
			this.CloseAudioDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnAkPostEventCallback>(new Action<EAkCallbackType, UAkCallbackInfo>(this.EndPlayDelegate));
		}
	}

	// Token: 0x060147BF RID: 83903 RVA: 0x005AF470 File Offset: 0x005AD670
	protected override void OnBeforeDestroy()
	{
		this.ContentData = null;
		this.Toggle = null;
		this.Button = null;
		this.ToggleFunction = null;
		this.ButtonFunction = null;
		this.CurPlayerStatus = EFavorPlayerStatus.Stop;
		this.FavorItemStatus = new EFavorItemStatus?(EFavorItemStatus.ItemLocked);
		if (this.CloseAudioDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EAkCallbackType, UAkCallbackInfo>(this.EndPlayDelegate));
			this.CloseAudioDelegate = null;
		}
		if (this.OnMontageCompleted != null)
		{
			this.OnMontageCompleted = null;
		}
	}

	// Token: 0x060147C0 RID: 83904 RVA: 0x005AF4E4 File Offset: 0x005AD6E4
	private void InitLockState()
	{
		EFavorContentType favorContentType = this.ContentData.FavorContentType;
		int configId = this.ContentData.ConfigId;
		if (favorContentType == EFavorContentType.Action)
		{
			RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.ContentData.RoleId);
			if (roleInstanceById == null)
			{
				return;
			}
			MotionModel.EMotionState roleMotionState = ModelBase<MotionModel>.Instance.GetRoleMotionState(roleInstanceById.GetRoleId(), configId);
			this.FavorItemStatus = new EFavorItemStatus?((EFavorItemStatus)roleMotionState);
			this.SetLockItemActive(this.FavorItemStatus.GetValueOrDefault() != EFavorItemStatus.ItemUnLocked);
			return;
		}
		else
		{
			RoleInstance roleInstanceById2 = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.ContentData.RoleId);
			if (roleInstanceById2 == null)
			{
				return;
			}
			EFavorItemStatus favorItemState = roleInstanceById2.GetFavorData().GetFavorItemState(configId, favorContentType);
			this.SetLockItemActive(favorItemState == EFavorItemStatus.ItemLocked);
			this.FavorItemStatus = new EFavorItemStatus?(favorItemState);
			return;
		}
	}

	// Token: 0x060147C1 RID: 83905 RVA: 0x005AF5A1 File Offset: 0x005AD7A1
	public void SetLockItemActive(bool active)
	{
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(active);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(2);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(false);
	}

	// Token: 0x060147C2 RID: 83906 RVA: 0x005AF5DC File Offset: 0x005AD7DC
	private void SetPlayerState(EFavorPlayerStatus playerStatus)
	{
		if (this.ContentData == null)
		{
			return;
		}
		EFavorContentType favorContentType = this.ContentData.FavorContentType;
		if (favorContentType != EFavorContentType.Action && favorContentType != EFavorContentType.Voice)
		{
			return;
		}
		EFavorItemStatus? favorItemStatus = this.FavorItemStatus;
		EFavorItemStatus efavorItemStatus = EFavorItemStatus.ItemLocked;
		if (favorItemStatus.GetValueOrDefault() == efavorItemStatus & favorItemStatus != null)
		{
			return;
		}
		this.CurPlayerStatus = playerStatus;
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(playerStatus == EFavorPlayerStatus.Play);
		}
		UUIItem item3 = base.GetItem(2);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(playerStatus == EFavorPlayerStatus.Stop);
	}

	// Token: 0x060147C3 RID: 83907 RVA: 0x005AF669 File Offset: 0x005AD869
	public EFavorPlayerStatus GetCurVoiceState()
	{
		return this.CurPlayerStatus;
	}

	// Token: 0x060147C4 RID: 83908 RVA: 0x005AF671 File Offset: 0x005AD871
	public void EndPlayDelegate(EAkCallbackType type, UAkCallbackInfo info)
	{
		if (type == EAkCallbackType.EndOfEvent)
		{
			this.EndPlay();
		}
	}

	// Token: 0x060147C5 RID: 83909 RVA: 0x005AF67C File Offset: 0x005AD87C
	public void EndPlay()
	{
		this.SetPlayerState(EFavorPlayerStatus.Stop);
	}

	// Token: 0x060147C6 RID: 83910 RVA: 0x005AF685 File Offset: 0x005AD885
	public void StartPlay()
	{
		this.SetPlayerState(EFavorPlayerStatus.Play);
	}

	// Token: 0x060147C7 RID: 83911 RVA: 0x005AF68E File Offset: 0x005AD88E
	public void SetToggleState(EToggleState state)
	{
		if (this.Toggle != null)
		{
			this.Toggle.SetToggleState(state, false, false, false);
		}
	}

	// Token: 0x060147C8 RID: 83912 RVA: 0x005AF6A8 File Offset: 0x005AD8A8
	public void SetButtonActive(bool active)
	{
		if (this.Button != null)
		{
			this.Button.RootUIComp.Get().SetUIActive(active);
		}
	}

	// Token: 0x060147C9 RID: 83913 RVA: 0x005AF6D8 File Offset: 0x005AD8D8
	private void RefreshRedDot()
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.ContentData.RoleId);
		if (roleInstanceById == null)
		{
			return;
		}
		RoleFavorData favorData = roleInstanceById.GetFavorData();
		EFavorItemStatus efavorItemStatus;
		if (this.ContentData.FavorContentType == EFavorContentType.Action)
		{
			efavorItemStatus = (EFavorItemStatus)ModelBase<MotionModel>.Instance.GetRoleMotionState(roleInstanceById.GetRoleId(), this.ContentData.ConfigId);
		}
		else
		{
			efavorItemStatus = favorData.GetFavorItemState(this.ContentData.ConfigId, this.ContentData.FavorContentType);
		}
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(efavorItemStatus == EFavorItemStatus.ItemCanUnLock);
	}

	// Token: 0x04009E3B RID: 40507
	public RoleFavorContentDataBase ContentData;

	// Token: 0x04009E3C RID: 40508
	private UUIExtendToggle Toggle;

	// Token: 0x04009E3D RID: 40509
	private UUIButtonComponent Button;

	// Token: 0x04009E3E RID: 40510
	private TRoleFavorContentItemToggleFunction ToggleFunction;

	// Token: 0x04009E3F RID: 40511
	private TRoleFavorContentItemButtonFunction ButtonFunction;

	// Token: 0x04009E40 RID: 40512
	private EFavorPlayerStatus CurPlayerStatus = EFavorPlayerStatus.Stop;

	// Token: 0x04009E41 RID: 40513
	private EFavorItemStatus? FavorItemStatus;

	// Token: 0x04009E42 RID: 40514
	[Nullable(1)]
	public FOnAkPostEventCallback CloseAudioDelegate;

	// Token: 0x04009E43 RID: 40515
	public Action<UAnimMontage, bool> OnMontageCompleted;

	// Token: 0x02008BD3 RID: 35795
	[NullableContext(0)]
	private enum ERoleFavorContentItemDefine
	{
		// Token: 0x0402F1C9 RID: 192969
		LockItem,
		// Token: 0x0402F1CA RID: 192970
		PlayVoiceItem,
		// Token: 0x0402F1CB RID: 192971
		StopVoiceItem,
		// Token: 0x0402F1CC RID: 192972
		TitleText,
		// Token: 0x0402F1CD RID: 192973
		Toggle,
		// Token: 0x0402F1CE RID: 192974
		RedDot,
		// Token: 0x0402F1CF RID: 192975
		Button
	}
}
