using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x0200175F RID: 5983
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class NewSoundTypeItem : SyncGridProxyAbstract<INewSoundTypeItemData>
{
	// Token: 0x0600A81D RID: 43037 RVA: 0x002CC42C File Offset: 0x002CA62C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A81E RID: 43038 RVA: 0x002CC598 File Offset: 0x002CA798
	protected override void OnStart()
	{
		this.Toggle = base.GetExtendToggle(3);
		UUIExtendToggle toggle = this.Toggle;
		if (toggle != null)
		{
			toggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		}
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			this.Tag = new NewSoundTypeTagItem();
			this.Tag.CreateByActorAsync(item.GetOwner(), null, false).Forget();
		}
	}

	// Token: 0x0600A81F RID: 43039 RVA: 0x002CC604 File Offset: 0x002CA804
	[NullableContext(1)]
	public void BindOnToggleFunc(Action<int, UUIExtendToggle> toggleFunc)
	{
		this.ToggleFunc = delegate(int curId, UUIExtendToggle toggle)
		{
			toggleFunc(curId, toggle);
			if (this.GetRedDotState())
			{
				ModelBase<AdventureGuideModel>.Instance.RecordAllDetectionBySecondary(this.TypeId);
				this.RefreshRedDotState();
				if (this.FromTabViewName != null)
				{
					if (this.FromTabViewName == EUiTabViewName.NewSoundAreaView)
					{
						Singleton<EventSystem>.Instance.Emit(EEventName.RedDotNewSoundAreaTabUpdate);
						return;
					}
					if (this.FromTabViewName == EUiTabViewName.DisposableChallengeView)
					{
						Singleton<EventSystem>.Instance.Emit(EEventName.RedDotAdventureChallengeTabUpdate);
					}
				}
			}
		};
	}

	// Token: 0x0600A820 RID: 43040 RVA: 0x002CC637 File Offset: 0x002CA837
	[NullableContext(1)]
	public void BindCanToggleExecuteChange(Func<int, bool> toggle)
	{
		this.OnCanToggleClicked = toggle;
	}

	// Token: 0x0600A821 RID: 43041 RVA: 0x002CC640 File Offset: 0x002CA840
	private bool CanToggleExecuteChange()
	{
		return this.OnCanToggleClicked == null || this.OnCanToggleClicked((int)this.TypeId);
	}

	// Token: 0x0600A822 RID: 43042 RVA: 0x002CC660 File Offset: 0x002CA860
	[NullableContext(1)]
	public override void Refresh(INewSoundTypeItemData data)
	{
		this.TypeId = data.TypeId;
		this.FromTabViewName = data.FromTabViewName;
		SecondaryGuideData value = ConfigBase<AdventureGuideConfig>.Instance.GetSecondaryGuideDataConf((int)this.TypeId).Value;
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, value.Text, Array.Empty<object>());
		UUIText text2 = base.GetText(2);
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(text2, value.SubText, Array.Empty<object>());
		this.SetSpriteByPath(value.Icon, base.GetSprite(0), false, null, null);
		this.SetSpriteByPath(value.Icon, base.GetSprite(6), false, null, null);
		this.Toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.RefreshDoubleIcon();
		this.RefreshRedDotState();
	}

	// Token: 0x0600A823 RID: 43043 RVA: 0x002CC738 File Offset: 0x002CA938
	public void RefreshDoubleIcon()
	{
		this.RefreshAllTagState();
	}

	// Token: 0x0600A824 RID: 43044 RVA: 0x002CC740 File Offset: 0x002CA940
	public void RefreshRedDotState()
	{
		bool flag = ModelBase<AdventureGuideModel>.Instance.CheckRedDotSecondary(this.TypeId);
		bool flag2 = ModelBase<AdventureGuideModel>.Instance.CheckExtraRedDotSecondary(this.TypeId);
		this.RedDotState = (flag || flag2);
		this.RefreshAllTagState();
	}

	// Token: 0x0600A825 RID: 43045 RVA: 0x002CC77E File Offset: 0x002CA97E
	public bool GetRedDotState()
	{
		return this.RedDotState;
	}

	// Token: 0x0600A826 RID: 43046 RVA: 0x002CC788 File Offset: 0x002CA988
	private void RefreshAllTagState()
	{
		bool flag = ControllerBase<ActivityDoubleRewardController>.Instance.GetAdventureUpActivity(this.TypeId) != null || ModelBase<ActivityRegressModel>.Instance.IsHasDoubleDrop(this.TypeId);
		bool flag2 = !flag && this.CheckIsActivityTag();
		bool flag3 = !flag && !flag2 && ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByDungeonType(this.TypeId);
		bool uiactive = !flag && !flag2 && !flag3 && this.RedDotState;
		base.GetItem(4).SetUIActive(flag);
		base.GetItem(5).SetUIActive(uiactive);
		if (flag2)
		{
			base.GetItem(7).SetUIActive(true);
			NewSoundTypeTagItem tag = this.Tag;
			if (tag == null)
			{
				return;
			}
			tag.RefreshItem(true);
			return;
		}
		else
		{
			if (!flag3)
			{
				base.GetItem(7).SetUIActive(false);
				return;
			}
			base.GetItem(7).SetUIActive(true);
			NewSoundTypeTagItem tag2 = this.Tag;
			if (tag2 == null)
			{
				return;
			}
			tag2.RefreshItem(false);
			return;
		}
	}

	// Token: 0x0600A827 RID: 43047 RVA: 0x002CC860 File Offset: 0x002CAA60
	private bool CheckIsActivityTag()
	{
		if (this.TypeId != EDungeonType.NoSoundArea)
		{
			return false;
		}
		List<EAdventurePreOpenPlayType> playerType = ControllerBase<AdventureGuideController>.Instance.GetPlayerType();
		return playerType.Contains(EAdventurePreOpenPlayType.Regress) || playerType.Contains(EAdventurePreOpenPlayType.Beginner);
	}

	// Token: 0x0600A828 RID: 43048 RVA: 0x002CC896 File Offset: 0x002CAA96
	private void OnToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.ToggleFunc((int)this.TypeId, this.Toggle);
		}
	}

	// Token: 0x0600A829 RID: 43049 RVA: 0x002CC8B3 File Offset: 0x002CAAB3
	public void OnSelected(bool bFireEvent)
	{
		if (bFireEvent)
		{
			this.SetSelectToggle(EToggleState.ETT_Checked);
		}
	}

	// Token: 0x0600A82A RID: 43050 RVA: 0x002CC8BF File Offset: 0x002CAABF
	public void SetSelectToggle(EToggleState state = EToggleState.ETT_Checked)
	{
		base.GetExtendToggle(3).SetToggleStateForce(state, false, false, true);
		this.ToggleFunc((int)this.TypeId, this.Toggle);
	}

	// Token: 0x0600A82B RID: 43051 RVA: 0x002CC8E8 File Offset: 0x002CAAE8
	public UUIExtendToggle GetSelfToggle()
	{
		return base.GetExtendToggle(3);
	}

	// Token: 0x0600A82C RID: 43052 RVA: 0x002CC8F4 File Offset: 0x002CAAF4
	public UUIItem GetButtonItem()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle == null)
		{
			return null;
		}
		return extendToggle.RootUIComp.Get();
	}

	// Token: 0x04004F47 RID: 20295
	private EDungeonType TypeId = EDungeonType.Mat;

	// Token: 0x04004F48 RID: 20296
	private EUiTabViewName? FromTabViewName;

	// Token: 0x04004F49 RID: 20297
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, UUIExtendToggle> ToggleFunc;

	// Token: 0x04004F4A RID: 20298
	private Func<int, bool> OnCanToggleClicked;

	// Token: 0x04004F4B RID: 20299
	private UUIExtendToggle Toggle;

	// Token: 0x04004F4C RID: 20300
	private bool RedDotState;

	// Token: 0x04004F4D RID: 20301
	private NewSoundTypeTagItem Tag;

	// Token: 0x02007AC2 RID: 31426
	[NullableContext(0)]
	private enum ENodeDefine
	{
		// Token: 0x0402A0C7 RID: 172231
		Icon,
		// Token: 0x0402A0C8 RID: 172232
		TypeText,
		// Token: 0x0402A0C9 RID: 172233
		SubText,
		// Token: 0x0402A0CA RID: 172234
		Toggle,
		// Token: 0x0402A0CB RID: 172235
		DoubleTip,
		// Token: 0x0402A0CC RID: 172236
		RedDotItem,
		// Token: 0x0402A0CD RID: 172237
		SprIconR,
		// Token: 0x0402A0CE RID: 172238
		TagItem
	}
}
