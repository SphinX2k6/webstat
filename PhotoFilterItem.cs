using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025D0 RID: 9680
public class PhotoFilterItem : UiPanelBase
{
	// Token: 0x06012EBB RID: 77499 RVA: 0x0053C1A0 File Offset: 0x0053A3A0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClicked))
		};
	}

	// Token: 0x06012EBC RID: 77500 RVA: 0x0053C2B8 File Offset: 0x0053A4B8
	protected override void OnStart()
	{
		UUISliderComponent slider = base.GetSlider(4);
		if (slider != null)
		{
			slider.OnValueChangeCb.Bind(new Action<float>(this.OnValueChanged));
		}
		this.FilterItemLevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		base.GetExtendToggle(0).OnPointEnterCallBack.Bind(new Action<EToggleState>(this.PointEnterCallBack));
	}

	// Token: 0x06012EBD RID: 77501 RVA: 0x0053C316 File Offset: 0x0053A516
	protected override void OnBeforeDestroy()
	{
		UUISliderComponent slider = base.GetSlider(4);
		if (slider != null)
		{
			slider.OnValueChangeCb.Unbind();
		}
		this.FilterItemLevelSequencePlayer = null;
	}

	// Token: 0x06012EBE RID: 77502 RVA: 0x0053C338 File Offset: 0x0053A538
	protected override void OnBeforeShow()
	{
		bool bSelected = !this.IsUnSelected();
		this.SetSelected(bSelected, false);
	}

	// Token: 0x06012EBF RID: 77503 RVA: 0x0053C358 File Offset: 0x0053A558
	public void Refresh(int photoFilterId)
	{
		if (photoFilterId == 0)
		{
			return;
		}
		this.PhotoFilterId = photoFilterId;
		this.PhotoFilterConfig = ConfigBase<PhotographConfig>.Instance.GetPhotoFilterConfigById(photoFilterId);
		if (this.PhotoFilterConfig == null)
		{
			return;
		}
		string name = this.PhotoFilterConfig.Value.Name;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), name, Array.Empty<object>());
		string icon = this.PhotoFilterConfig.Value.Icon;
		base.SetTextureByPath(icon, base.GetTexture(2), null, null);
		UUISliderComponent slider = base.GetSlider(4);
		if (slider != null)
		{
			slider.SetMinValue(0f, false, false);
		}
		if (slider != null)
		{
			slider.SetMaxValue(1f, false, false);
		}
		float filterStrengthByFilterId = ModelBase<PhotographModel>.Instance.GetFilterStrengthByFilterId(this.PhotoFilterId);
		if (slider != null)
		{
			slider.SetValue(filterStrengthByFilterId, false);
		}
		int num = (int)Math.Floor((double)(filterStrengthByFilterId * 100f));
		base.GetText(3).SetText(num.ToString(), true);
	}

	// Token: 0x06012EC0 RID: 77504 RVA: 0x0053C458 File Offset: 0x0053A658
	private bool IsUnSelected()
	{
		return ModelBase<PhotographModel>.Instance.GetPhotographFilter() != this.PhotoFilterId;
	}

	// Token: 0x06012EC1 RID: 77505 RVA: 0x0053C470 File Offset: 0x0053A670
	private void OnValueChanged(float value)
	{
		ControllerBase<PhotographController>.Instance.SetSingleFilterStrength(this.PhotoFilterId, value);
		int num = (int)Math.Floor((double)(value * 100f));
		base.GetText(3).SetText(num.ToString(), true);
	}

	// Token: 0x06012EC2 RID: 77506 RVA: 0x0053C4B1 File Offset: 0x0053A6B1
	[NullableContext(1)]
	public void BindOnSelected(Action<PhotoFilterItem, bool> onSelected)
	{
		this.OnSelected = onSelected;
	}

	// Token: 0x06012EC3 RID: 77507 RVA: 0x0053C4BC File Offset: 0x0053A6BC
	public void SetSelected(bool bSelected, bool bFireEvent = false)
	{
		UUISprite sprite = base.GetSprite(7);
		if (sprite != null)
		{
			sprite.SetUIActive(bSelected);
		}
		this.SetFilterStrengthVisible(bSelected, false);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (bSelected)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, bFireEvent, false, false);
			ModelBase<PhotographModel>.Instance.SetPhotographFilter(this.PhotoFilterId);
			ControllerBase<PhotographController>.Instance.InitPostProcessVolBlendWeight(this.PhotoFilterId);
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, bFireEvent, false, false);
	}

	// Token: 0x06012EC4 RID: 77508 RVA: 0x0053C524 File Offset: 0x0053A724
	private void OnClicked(EToggleState state)
	{
		if (ModelBase<PhotographModel>.Instance.GetPhotographFilter() == this.PhotoFilterId)
		{
			bool bShow = state == EToggleState.ETT_Checked;
			this.SetFilterStrengthVisible(bShow, true);
			return;
		}
		if (this.OnSelected != null)
		{
			this.OnSelected(this, true);
		}
	}

	// Token: 0x06012EC5 RID: 77509 RVA: 0x0053C568 File Offset: 0x0053A768
	public void SetFilterStrengthVisible(bool bShow, bool needAnim = true)
	{
		UUIItem panelFilterStrength = base.GetItem(8);
		if (this.PhotoFilterId == 1)
		{
			UUISprite sprite = base.GetSprite(9);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUIItem panelFilterStrength5 = panelFilterStrength;
			if (panelFilterStrength5 == null)
			{
				return;
			}
			panelFilterStrength5.SetUIActive(false);
			return;
		}
		else if (!needAnim)
		{
			UUIItem panelFilterStrength2 = panelFilterStrength;
			if (panelFilterStrength2 == null)
			{
				return;
			}
			panelFilterStrength2.SetUIActive(bShow);
			return;
		}
		else if (bShow)
		{
			UUIItem panelFilterStrength3 = panelFilterStrength;
			if (panelFilterStrength3 != null)
			{
				panelFilterStrength3.SetUIActive(true);
			}
			if (this.ScrollToSelectedItem != null)
			{
				this.ScrollToSelectedItem(this);
			}
			LevelSequencePlayer filterItemLevelSequencePlayer = this.FilterItemLevelSequencePlayer;
			if (filterItemLevelSequencePlayer == null)
			{
				return;
			}
			filterItemLevelSequencePlayer.PlayLevelSequenceByName("Unfold", false, null, false);
			return;
		}
		else
		{
			LevelSequencePlayer filterItemLevelSequencePlayer2 = this.FilterItemLevelSequencePlayer;
			if (filterItemLevelSequencePlayer2 == null)
			{
				return;
			}
			filterItemLevelSequencePlayer2.PlaySequenceAsync("Collapse", new CustomPromise<bool>(), false, false, null, false).ContinueWith(delegate()
			{
				UUIItem panelFilterStrength4 = panelFilterStrength;
				if (panelFilterStrength4 == null)
				{
					return;
				}
				panelFilterStrength4.SetUIActive(false);
			}).Forget();
			return;
		}
	}

	// Token: 0x06012EC6 RID: 77510 RVA: 0x0053C652 File Offset: 0x0053A852
	public void ShowFilterItem()
	{
		this.IsVisible = true;
		this.SetActive(true);
	}

	// Token: 0x06012EC7 RID: 77511 RVA: 0x0053C662 File Offset: 0x0053A862
	public int GetPhotoFilterId()
	{
		return this.PhotoFilterId;
	}

	// Token: 0x06012EC8 RID: 77512 RVA: 0x0053C66A File Offset: 0x0053A86A
	public void PlayDisappearSequence(bool isByClickToggle)
	{
		this.IsVisible = false;
		if (isByClickToggle)
		{
			this.PlayDisappearSequenceAsync().Forget();
			return;
		}
		this.SetActive(false);
	}

	// Token: 0x06012EC9 RID: 77513 RVA: 0x0053C68C File Offset: 0x0053A88C
	public UniTask PlayDisappearSequenceAsync()
	{
		PhotoFilterItem.<PlayDisappearSequenceAsync>d__21 <PlayDisappearSequenceAsync>d__;
		<PlayDisappearSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayDisappearSequenceAsync>d__.<>4__this = this;
		<PlayDisappearSequenceAsync>d__.<>1__state = -1;
		<PlayDisappearSequenceAsync>d__.<>t__builder.Start<PhotoFilterItem.<PlayDisappearSequenceAsync>d__21>(ref <PlayDisappearSequenceAsync>d__);
		return <PlayDisappearSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012ECA RID: 77514 RVA: 0x0053C6CF File Offset: 0x0053A8CF
	[NullableContext(1)]
	public void BindScrollToSelectedItem(Action<PhotoFilterItem> scrollToSelectedItem)
	{
		this.ScrollToSelectedItem = scrollToSelectedItem;
	}

	// Token: 0x06012ECB RID: 77515 RVA: 0x0053C6D8 File Offset: 0x0053A8D8
	private void PointEnterCallBack(EToggleState _)
	{
		if (this.IsUnSelected())
		{
			return;
		}
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		if (this.ScrollToSelectedItem != null)
		{
			this.ScrollToSelectedItem(this);
		}
	}

	// Token: 0x040093C6 RID: 37830
	private int PhotoFilterId;

	// Token: 0x040093C7 RID: 37831
	[Nullable(2)]
	private LevelSequencePlayer FilterItemLevelSequencePlayer;

	// Token: 0x040093C8 RID: 37832
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<PhotoFilterItem, bool> OnSelected;

	// Token: 0x040093C9 RID: 37833
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<PhotoFilterItem> ScrollToSelectedItem;

	// Token: 0x040093CA RID: 37834
	private PhotoFilter? PhotoFilterConfig;

	// Token: 0x040093CB RID: 37835
	private bool IsVisible;

	// Token: 0x0200893B RID: 35131
	private enum EChildType
	{
		// Token: 0x0402E4E1 RID: 189665
		Toggle,
		// Token: 0x0402E4E2 RID: 189666
		TextName,
		// Token: 0x0402E4E3 RID: 189667
		TextureIcon,
		// Token: 0x0402E4E4 RID: 189668
		TextFilterStrengthNum,
		// Token: 0x0402E4E5 RID: 189669
		ValueSlider,
		// Token: 0x0402E4E6 RID: 189670
		SpriteHandle,
		// Token: 0x0402E4E7 RID: 189671
		RedPoint,
		// Token: 0x0402E4E8 RID: 189672
		SpriteSelected,
		// Token: 0x0402E4E9 RID: 189673
		PanelFilterStrength,
		// Token: 0x0402E4EA RID: 189674
		SpriteArrow
	}
}
