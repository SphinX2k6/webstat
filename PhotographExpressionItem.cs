using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020025DB RID: 9691
public class PhotographExpressionItem : UiPanelBase
{
	// Token: 0x06012F20 RID: 77600 RVA: 0x0053D6E0 File Offset: 0x0053B8E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClicked))
		};
	}

	// Token: 0x06012F21 RID: 77601 RVA: 0x0053D789 File Offset: 0x0053B989
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
	}

	// Token: 0x06012F22 RID: 77602 RVA: 0x0053D7A8 File Offset: 0x0053B9A8
	protected override void OnBeforeDestroy()
	{
		base.GetExtendToggle(0).CanExecuteChange.Unbind();
	}

	// Token: 0x06012F23 RID: 77603 RVA: 0x0053D7BC File Offset: 0x0053B9BC
	private bool OnCanExecuteChange()
	{
		bool flag = this.IsUnLock();
		if (flag && this.OnCanExecuteChangeFunc != null)
		{
			return this.OnCanExecuteChangeFunc(this);
		}
		return flag;
	}

	// Token: 0x06012F24 RID: 77604 RVA: 0x0053D7EC File Offset: 0x0053B9EC
	public void Refresh(int photoMontageId)
	{
		this.PhotoMontageId = photoMontageId;
		if (photoMontageId == 0)
		{
			return;
		}
		this.PhotoMontageConfig = ConfigBase<PhotographConfig>.Instance.GetPhotoMontageConfig(photoMontageId);
		if (this.PhotoMontageConfig == null)
		{
			return;
		}
		string name = this.PhotoMontageConfig.Value.Name;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), name, Array.Empty<object>());
		bool flag = this.IsUnLock();
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (flag)
		{
			extendToggle.RootUIComp.Get().SetAlpha(1f);
			int iconType = this.PhotoMontageConfig.Value.IconType;
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("SP_PhotoMotionIcon");
			defaultInterpolatedStringHandler.AppendFormatted<int>(iconType);
			string resourcePath = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
			this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, null);
		}
		else
		{
			extendToggle.RootUIComp.Get().SetAlpha(0.3f);
			string conditionTipsId = this.PhotoMontageConfig.Value.ConditionTipsId;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), conditionTipsId, Array.Empty<object>());
		}
		base.GetText(3).SetUIActive(!flag);
		base.GetSprite(1).SetUIActive(flag);
		base.GetItem(4).SetUIActive(!flag);
	}

	// Token: 0x06012F25 RID: 77605 RVA: 0x0053D950 File Offset: 0x0053BB50
	private bool IsUnLock()
	{
		if (this.PhotoMontageId == 0)
		{
			return true;
		}
		int unLockConditionGroup = this.PhotoMontageConfig.Value.UnLockConditionGroup;
		return unLockConditionGroup == 0 || ControllerBase<LevelGeneralController>.Instance.CheckCondition(unLockConditionGroup.ToString(), null, true, Array.Empty<object>());
	}

	// Token: 0x06012F26 RID: 77606 RVA: 0x0053D998 File Offset: 0x0053BB98
	[NullableContext(1)]
	public void BindOnSelected(Action<PhotographExpressionItem, bool> onSelected)
	{
		this.OnSelected = onSelected;
	}

	// Token: 0x06012F27 RID: 77607 RVA: 0x0053D9A1 File Offset: 0x0053BBA1
	[NullableContext(1)]
	public void BindOnCanExecuteChange(Func<PhotographExpressionItem, bool> canExecuteChange)
	{
		this.OnCanExecuteChangeFunc = canExecuteChange;
	}

	// Token: 0x06012F28 RID: 77608 RVA: 0x0053D9AC File Offset: 0x0053BBAC
	public void SetSelected(bool bSelected, bool bFireEvent = false)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (bSelected)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, bFireEvent, false, false);
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, bFireEvent, false, false);
	}

	// Token: 0x06012F29 RID: 77609 RVA: 0x0053D9D9 File Offset: 0x0053BBD9
	public int GetPhotoMontageId()
	{
		return this.PhotoMontageId;
	}

	// Token: 0x06012F2A RID: 77610 RVA: 0x0053D9E1 File Offset: 0x0053BBE1
	public PhotoMontage? GetPhotoMontageConfig()
	{
		return this.PhotoMontageConfig;
	}

	// Token: 0x06012F2B RID: 77611 RVA: 0x0053D9EC File Offset: 0x0053BBEC
	private void OnClicked(EToggleState state)
	{
		if (!this.IsUnLock())
		{
			return;
		}
		bool arg = state == EToggleState.ETT_Checked;
		if (this.OnSelected != null)
		{
			this.OnSelected(this, arg);
		}
	}

	// Token: 0x040093E8 RID: 37864
	private int PhotoMontageId;

	// Token: 0x040093E9 RID: 37865
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<PhotographExpressionItem, bool> OnSelected;

	// Token: 0x040093EA RID: 37866
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<PhotographExpressionItem, bool> OnCanExecuteChangeFunc;

	// Token: 0x040093EB RID: 37867
	private PhotoMontage? PhotoMontageConfig;

	// Token: 0x040093EC RID: 37868
	private const float LOCK_ALPHA = 0.3f;

	// Token: 0x040093ED RID: 37869
	private const float UNLOCK_ALPHA = 1f;

	// Token: 0x02008944 RID: 35140
	private enum EChildType
	{
		// Token: 0x0402E509 RID: 189705
		Toggle,
		// Token: 0x0402E50A RID: 189706
		SpriteIcon,
		// Token: 0x0402E50B RID: 189707
		TextTitle,
		// Token: 0x0402E50C RID: 189708
		TextLock,
		// Token: 0x0402E50D RID: 189709
		ItemLock
	}
}
