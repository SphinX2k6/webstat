using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020013A6 RID: 5030
[NullableContext(1)]
[Nullable(0)]
public class BuildingLevelUpView : UiTickViewBase
{
	// Token: 0x06008A9C RID: 35484 RVA: 0x00247EAB File Offset: 0x002460AB
	public BuildingLevelUpView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06008A9D RID: 35485 RVA: 0x00247EC0 File Offset: 0x002460C0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.Vc.CloseSelf))
		};
	}

	// Token: 0x06008A9E RID: 35486 RVA: 0x0024803C File Offset: 0x0024623C
	protected override void OnStart()
	{
		this.Vc.RegisterView(this);
		this.Vc.Start();
		this.Slider = base.GetSlider(0);
		this.BuildingSequencePlayer = new UiSequencePlayer(base.GetItem(13));
		this.SetFillAmount(0f);
	}

	// Token: 0x06008A9F RID: 35487 RVA: 0x0024808B File Offset: 0x0024628B
	protected override void OnTick(float delta)
	{
		this.Vc.Tick(delta);
	}

	// Token: 0x06008AA0 RID: 35488 RVA: 0x0024809C File Offset: 0x0024629C
	public void InitUnlock(int buildingId)
	{
		Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(buildingId);
		EntrustRole entrustRoleById = ConfigBase<BusinessConfig>.Instance.GetEntrustRoleById(buildingById.AssociateRole);
		UUISliderComponent slider = base.GetSlider(0);
		if (slider != null)
		{
			UUIItem rootComponent = slider.GetRootComponent();
			if (rootComponent != null)
			{
				rootComponent.SetUIActive(true);
			}
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIButtonComponent button = base.GetButton(6);
		if (button != null)
		{
			UUIItem rootComponent2 = button.GetRootComponent();
			if (rootComponent2 != null)
			{
				rootComponent2.SetUIActive(false);
			}
		}
		UUIButtonComponent button2 = base.GetButton(5);
		if (button2 != null)
		{
			button2.OnPointDownCallBack.Bind(new Action(this.Vc.UnlockPress));
		}
		if (button2 != null)
		{
			button2.OnPointUpCallBack.Bind(new Action(this.Vc.UnlockRelease));
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Moonfiesta_StartBuild", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), entrustRoleById.BuildSuccessDialog, Array.Empty<object>());
		base.SetTextureByPath(entrustRoleById.SmallHeadIcon, base.GetTexture(8), null, null);
		UUIItem item2 = base.GetItem(10);
		if (item2 != null)
		{
			item2.SetUIActive(true);
		}
		UUIItem item3 = base.GetItem(11);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		UUIItem item4 = base.GetItem(12);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(false);
	}

	// Token: 0x06008AA1 RID: 35489 RVA: 0x002481F2 File Offset: 0x002463F2
	public void ShowUnlock()
	{
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UUIButtonComponent button = base.GetButton(5);
		if (button == null)
		{
			return;
		}
		UUIItem rootComponent = button.GetRootComponent();
		if (rootComponent == null)
		{
			return;
		}
		rootComponent.SetUIActive(false);
	}

	// Token: 0x06008AA2 RID: 35490 RVA: 0x00248224 File Offset: 0x00246424
	public void FinishUnlock(int buildingId)
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(buildingId);
		UUISliderComponent slider = base.GetSlider(0);
		if (slider != null)
		{
			UUIItem rootComponent = slider.GetRootComponent();
			if (rootComponent != null)
			{
				rootComponent.SetUIActive(false);
			}
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		UUIButtonComponent button = base.GetButton(6);
		if (button != null)
		{
			UUIItem rootComponent2 = button.GetRootComponent();
			if (rootComponent2 != null)
			{
				rootComponent2.SetUIActive(true);
			}
		}
		base.SetTextureByPath(ConfigBase<BuildingConfig>.Instance.GetBuildingById(buildingId).BuildingTexture, base.GetTexture(7), null, null);
		string levelUpIncreaseDesc = buildingDataById.GetLevelUpIncreaseDesc();
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			text2.SetText(levelUpIncreaseDesc, true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Moonfiesta_BuildingTips_Built", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Moonfiesta_ClickContinue", Array.Empty<object>());
		UUIItem item2 = base.GetItem(10);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(11);
		if (item3 != null)
		{
			item3.SetUIActive(true);
		}
		UUIItem item4 = base.GetItem(12);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(true);
	}

	// Token: 0x06008AA3 RID: 35491 RVA: 0x00248354 File Offset: 0x00246554
	public void InitLevelUp(int buildingId)
	{
		UUISliderComponent slider = base.GetSlider(0);
		if (slider != null)
		{
			UUIItem rootComponent = slider.GetRootComponent();
			if (rootComponent != null)
			{
				rootComponent.SetUIActive(false);
			}
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIButtonComponent button = base.GetButton(5);
		if (button != null)
		{
			UUIItem rootComponent2 = button.GetRootComponent();
			if (rootComponent2 != null)
			{
				rootComponent2.SetUIActive(false);
			}
		}
		UUIButtonComponent button2 = base.GetButton(6);
		if (button2 != null)
		{
			UUIItem rootComponent3 = button2.GetRootComponent();
			if (rootComponent3 != null)
			{
				rootComponent3.SetUIActive(false);
			}
		}
		base.SetTextureByPath(ConfigBase<BuildingConfig>.Instance.GetBuildingById(buildingId).BuildingTexture, base.GetTexture(7), null, null);
		UUIItem item2 = base.GetItem(10);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(11);
		if (item3 != null)
		{
			item3.SetUIActive(true);
		}
		UUIItem item4 = base.GetItem(12);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(true);
	}

	// Token: 0x06008AA4 RID: 35492 RVA: 0x00248433 File Offset: 0x00246633
	public void ShowLevelUp()
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x06008AA5 RID: 35493 RVA: 0x00248448 File Offset: 0x00246648
	public void FinishLevelUp(int buildingId)
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(buildingId);
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		UUIButtonComponent button = base.GetButton(6);
		if (button != null)
		{
			UUIItem rootComponent = button.GetRootComponent();
			if (rootComponent != null)
			{
				rootComponent.SetUIActive(true);
			}
		}
		string levelUpIncreaseDesc = buildingDataById.GetLevelUpIncreaseDesc();
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			text2.SetText(levelUpIncreaseDesc, true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Moonfiesta_BuildingTips_Built", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Moonfiesta_ClickContinue", Array.Empty<object>());
	}

	// Token: 0x06008AA6 RID: 35494 RVA: 0x002484F4 File Offset: 0x002466F4
	public void SetFillAmount(float fillAmount)
	{
		this.Slider.SetValue(fillAmount, true);
	}

	// Token: 0x06008AA7 RID: 35495 RVA: 0x00248504 File Offset: 0x00246704
	public void PlayBuildingLoopSequence(bool isPlay)
	{
		if (this.IsPlayingBuildingSequence == isPlay)
		{
			return;
		}
		this.IsPlayingBuildingSequence = isPlay;
		if (isPlay)
		{
			this.BuildingSequencePlayer.PlaySequence("Loop", false, null);
			return;
		}
		this.BuildingSequencePlayer.StopPrevSequence(false, true);
	}

	// Token: 0x040040E0 RID: 16608
	private UUISliderComponent Slider;

	// Token: 0x040040E1 RID: 16609
	[Nullable(2)]
	private UiSequencePlayer BuildingSequencePlayer;

	// Token: 0x040040E2 RID: 16610
	private bool IsPlayingBuildingSequence;

	// Token: 0x040040E3 RID: 16611
	private readonly BuildingLevelUpViewController Vc = new BuildingLevelUpViewController();

	// Token: 0x02007761 RID: 30561
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x040291AF RID: 168367
		public const int Slider = 0;

		// Token: 0x040291B0 RID: 168368
		public const int ProgressText = 1;

		// Token: 0x040291B1 RID: 168369
		public const int FinishItem = 2;

		// Token: 0x040291B2 RID: 168370
		public const int FinishText = 3;

		// Token: 0x040291B3 RID: 168371
		public const int RewardTips = 4;

		// Token: 0x040291B4 RID: 168372
		public const int UnlockBtn = 5;

		// Token: 0x040291B5 RID: 168373
		public const int CloseBtn = 6;

		// Token: 0x040291B6 RID: 168374
		public const int Texture = 7;

		// Token: 0x040291B7 RID: 168375
		public const int BuildSuccessTexture = 8;

		// Token: 0x040291B8 RID: 168376
		public const int BuildSuccessDialog = 9;

		// Token: 0x040291B9 RID: 168377
		public const int BuildFrameTexture = 10;

		// Token: 0x040291BA RID: 168378
		public const int LevelUpFrameBgTexture = 11;

		// Token: 0x040291BB RID: 168379
		public const int LevelUpFrameTexture = 12;

		// Token: 0x040291BC RID: 168380
		public const int BuildingItem = 13;
	}
}
