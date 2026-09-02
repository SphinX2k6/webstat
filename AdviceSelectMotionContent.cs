using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001789 RID: 6025
internal class AdviceSelectMotionContent : UiPanelBase
{
	// Token: 0x0600A9F8 RID: 43512 RVA: 0x002D54A0 File Offset: 0x002D36A0
	[NullableContext(1)]
	public AdviceSelectMotionContent(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A9F9 RID: 43513 RVA: 0x002D54B8 File Offset: 0x002D36B8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ButtonClick))
		};
	}

	// Token: 0x0600A9FA RID: 43514 RVA: 0x002D5538 File Offset: 0x002D3738
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickAdviceMotion, new Action(this.OnClickMotion));
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.CanExecuteChange.Unbind();
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanClickLikeToggle));
		}
	}

	// Token: 0x0600A9FB RID: 43515 RVA: 0x002D5590 File Offset: 0x002D3790
	private bool CanClickLikeToggle()
	{
		if (this.Data == null)
		{
			return false;
		}
		int? motionRoleId = ConfigBase<MotionConfig>.Instance.GetMotionRoleId(this.Data.GetIndex());
		MotionModel.EMotionState roleMotionState = ModelBase<MotionModel>.Instance.GetRoleMotionState(motionRoleId.GetValueOrDefault(), this.Data.GetIndex());
		if ((roleMotionState == MotionModel.EMotionState.Lock || roleMotionState == MotionModel.EMotionState.CanUnlock) && this.Data.GetIndex() != -1)
		{
			return false;
		}
		if (ModelBase<AdviceModel>.Instance.PreSelectMotionId != this.Data.GetIndex())
		{
			return true;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnClickAdviceMotion);
		return false;
	}

	// Token: 0x0600A9FC RID: 43516 RVA: 0x002D5620 File Offset: 0x002D3820
	private void ButtonClick(EToggleState state)
	{
		if (this.Data == null)
		{
			return;
		}
		ModelBase<AdviceModel>.Instance.PreSelectMotionId = this.Data.GetIndex();
		ModelBase<AdviceModel>.Instance.CurrentSelectMotionId = this.Data.GetIndex();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnClickAdviceMotion);
	}

	// Token: 0x0600A9FD RID: 43517 RVA: 0x002D5670 File Offset: 0x002D3870
	private void OnClickMotion()
	{
		this.RefreshToggleState();
	}

	// Token: 0x0600A9FE RID: 43518 RVA: 0x002D5678 File Offset: 0x002D3878
	[NullableContext(1)]
	public void RefreshView(AdviceMotionSelectData data)
	{
		this.Data = data;
		if (data.GetIndex() == ConfigBase<AdviceConfig>.Instance.GetAdviceMotionDefaultConfigId())
		{
			string text = ConfigBase<AdviceConfig>.Instance.GetAdviceSpecialParamsContent(data.GetIndex()) ?? "";
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "NoneMotion", Array.Empty<object>());
		}
		else
		{
			string newText = ConfigBase<MotionConfig>.Instance.GetMotionTitle(data.GetIndex()) ?? "";
			UUIText text2 = base.GetText(2);
			if (text2 != null)
			{
				text2.SetText(newText, true);
			}
		}
		this.RefreshLockImg();
		this.RefreshToggleState();
	}

	// Token: 0x0600A9FF RID: 43519 RVA: 0x002D5718 File Offset: 0x002D3918
	private void RefreshToggleState()
	{
		if (this.Data == null)
		{
			return;
		}
		EToggleState toggleState = base.GetExtendToggle(0).ToggleState;
		EToggleState etoggleState = (ModelBase<AdviceModel>.Instance.PreSelectMotionId == this.Data.GetIndex()) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		if (toggleState != etoggleState)
		{
			base.GetExtendToggle(0).SetToggleStateForce(etoggleState, false, false, false);
		}
	}

	// Token: 0x0600AA00 RID: 43520 RVA: 0x002D576C File Offset: 0x002D396C
	private void RefreshLockImg()
	{
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.GetIndex() == ConfigBase<AdviceConfig>.Instance.GetAdviceMotionDefaultConfigId())
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(false);
			return;
		}
		else
		{
			int? motionRoleId = ConfigBase<MotionConfig>.Instance.GetMotionRoleId(this.Data.GetIndex());
			MotionModel.EMotionState roleMotionState = ModelBase<MotionModel>.Instance.GetRoleMotionState(motionRoleId.GetValueOrDefault(), this.Data.GetIndex());
			bool uiactive = roleMotionState == MotionModel.EMotionState.Lock || roleMotionState == MotionModel.EMotionState.CanUnlock;
			UUISprite sprite2 = base.GetSprite(1);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetUIActive(uiactive);
			return;
		}
	}

	// Token: 0x0600AA01 RID: 43521 RVA: 0x002D57FC File Offset: 0x002D39FC
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickAdviceMotion, new Action(this.OnClickMotion));
	}

	// Token: 0x04004FF7 RID: 20471
	[Nullable(2)]
	private AdviceMotionSelectData Data;

	// Token: 0x02007AEB RID: 31467
	private static class EAdviceSelectMotionContent
	{
		// Token: 0x0402A17D RID: 172413
		public const int Toggle = 0;

		// Token: 0x0402A17E RID: 172414
		public const int LockImg = 1;

		// Token: 0x0402A17F RID: 172415
		public const int Text = 2;
	}
}
