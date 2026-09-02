using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001786 RID: 6022
public class AdviceMotionItem : UiPanelBase
{
	// Token: 0x0600A9D0 RID: 43472 RVA: 0x002D4778 File Offset: 0x002D2978
	[NullableContext(1)]
	public AdviceMotionItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A9D1 RID: 43473 RVA: 0x002D4790 File Offset: 0x002D2990
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x0600A9D2 RID: 43474 RVA: 0x002D4850 File Offset: 0x002D2A50
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.CanExecuteChange.Unbind();
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickAdviceMotion, new Action(this.OnClickMotion));
	}

	// Token: 0x0600A9D3 RID: 43475 RVA: 0x002D48A6 File Offset: 0x002D2AA6
	private void OnClickToggle(EToggleState state)
	{
		ModelBase<AdviceModel>.Instance.PreSelectMotionId = this.CurrentId;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnClickAdviceMotion);
	}

	// Token: 0x0600A9D4 RID: 43476 RVA: 0x002D48C8 File Offset: 0x002D2AC8
	private void OnClickMotion()
	{
		this.RefreshToggleState();
	}

	// Token: 0x0600A9D5 RID: 43477 RVA: 0x002D48D0 File Offset: 0x002D2AD0
	private bool CanExecuteChange()
	{
		bool flag = this.CurrentId == ModelBase<AdviceModel>.Instance.PreSelectMotionId;
		if (this.CurrentId == ConfigBase<AdviceConfig>.Instance.GetAdviceMotionDefaultConfigId())
		{
			return !flag;
		}
		int? motionRoleId = ConfigBase<MotionConfig>.Instance.GetMotionRoleId(this.CurrentId);
		MotionModel.EMotionState roleMotionState = ModelBase<MotionModel>.Instance.GetRoleMotionState(motionRoleId.GetValueOrDefault(), this.CurrentId);
		bool flag2 = roleMotionState == MotionModel.EMotionState.Lock || roleMotionState == MotionModel.EMotionState.CanUnlock;
		if (flag2)
		{
			Motion? motionConfig = ConfigBase<MotionConfig>.Instance.GetMotionConfig(this.CurrentId);
			if (motionConfig != null)
			{
				ConditionGroup? conditionInfo = ConfigBase<ComposeConfig>.Instance.GetConditionInfo(motionConfig.Value.CondGroupId);
				if (conditionInfo != null)
				{
					string localText = ConfigBase<ComposeConfig>.Instance.GetLocalText(conditionInfo.Value.HintText);
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("UnlockCondition", new object[]
					{
						localText
					});
				}
			}
		}
		return !flag && !flag2;
	}

	// Token: 0x0600A9D6 RID: 43478 RVA: 0x002D49BD File Offset: 0x002D2BBD
	public void Update(int id)
	{
		this.CurrentId = id;
		this.RefreshView();
	}

	// Token: 0x0600A9D7 RID: 43479 RVA: 0x002D49CC File Offset: 0x002D2BCC
	private void RefreshView()
	{
		this.RefreshSelectState();
		this.RefreshTexture();
		this.RefreshName();
		this.RefreshToggleState();
		this.RefreshLockState();
	}

	// Token: 0x0600A9D8 RID: 43480 RVA: 0x002D49EC File Offset: 0x002D2BEC
	private void RefreshName()
	{
		string newText;
		if (this.CurrentId == ConfigBase<AdviceConfig>.Instance.GetAdviceMotionDefaultConfigId())
		{
			newText = (ConfigBase<AdviceConfig>.Instance.GetAdviceSpecialParamsContent(this.CurrentId) ?? "");
		}
		else
		{
			newText = (ConfigBase<MotionConfig>.Instance.GetMotionContent(this.CurrentId) ?? "");
		}
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(newText, true);
	}

	// Token: 0x0600A9D9 RID: 43481 RVA: 0x002D4A5C File Offset: 0x002D2C5C
	private void RefreshTexture()
	{
		string path;
		if (this.CurrentId == ConfigBase<AdviceConfig>.Instance.GetAdviceMotionDefaultConfigId())
		{
			AdviceParams? adviceSpecialParams = ConfigBase<AdviceConfig>.Instance.GetAdviceSpecialParams(this.CurrentId);
			path = (((adviceSpecialParams != null) ? adviceSpecialParams.GetValueOrDefault().MotionImg : null) ?? "");
		}
		else
		{
			Motion? motionConfig = ConfigBase<MotionConfig>.Instance.GetMotionConfig(this.CurrentId);
			path = (((motionConfig != null) ? motionConfig.GetValueOrDefault().MotionImg : null) ?? "");
		}
		base.SetTextureByPath(path, base.GetTexture(2), null, null);
	}

	// Token: 0x0600A9DA RID: 43482 RVA: 0x002D4B0C File Offset: 0x002D2D0C
	private void RefreshSelectState()
	{
		bool uiactive = this.CurrentId == ModelBase<AdviceModel>.Instance.CurrentSelectMotionId;
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600A9DB RID: 43483 RVA: 0x002D4B40 File Offset: 0x002D2D40
	private void RefreshToggleState()
	{
		EToggleState etoggleState = (this.CurrentId == ModelBase<AdviceModel>.Instance.PreSelectMotionId) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		if (base.GetExtendToggle(0).ToggleState != etoggleState)
		{
			base.GetExtendToggle(0).SetToggleStateForce(etoggleState, false, false, false);
		}
	}

	// Token: 0x0600A9DC RID: 43484 RVA: 0x002D4B84 File Offset: 0x002D2D84
	private void RefreshLockState()
	{
		if (this.CurrentId == ConfigBase<AdviceConfig>.Instance.GetAdviceMotionDefaultConfigId())
		{
			UUISprite sprite = base.GetSprite(3);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			int? motionRoleId = ConfigBase<MotionConfig>.Instance.GetMotionRoleId(this.CurrentId);
			MotionModel.EMotionState roleMotionState = ModelBase<MotionModel>.Instance.GetRoleMotionState(motionRoleId.GetValueOrDefault(), this.CurrentId);
			bool uiactive = roleMotionState == MotionModel.EMotionState.Lock || roleMotionState == MotionModel.EMotionState.CanUnlock;
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(uiactive);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(uiactive);
			return;
		}
	}

	// Token: 0x0600A9DD RID: 43485 RVA: 0x002D4C22 File Offset: 0x002D2E22
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickAdviceMotion, new Action(this.OnClickMotion));
	}

	// Token: 0x04004FED RID: 20461
	private int CurrentId;

	// Token: 0x02007AE8 RID: 31464
	private static class EChildType
	{
		// Token: 0x0402A16C RID: 172396
		public const int Toggle = 0;

		// Token: 0x0402A16D RID: 172397
		public const int NameText = 1;

		// Token: 0x0402A16E RID: 172398
		public const int MiddleTexture = 2;

		// Token: 0x0402A16F RID: 172399
		public const int GrayTexture = 3;

		// Token: 0x0402A170 RID: 172400
		public const int SelectItem = 4;

		// Token: 0x0402A171 RID: 172401
		public const int LockItem = 5;
	}
}
