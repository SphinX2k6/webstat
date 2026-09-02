using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020013A0 RID: 5024
[NullableContext(1)]
[Nullable(0)]
public class BuildingItem : UiPanelBase
{
	// Token: 0x06008A4F RID: 35407 RVA: 0x00246A93 File Offset: 0x00244C93
	public BuildingItem(int buildingId)
	{
		this.BuildingId = buildingId;
	}

	// Token: 0x17000BC2 RID: 3010
	// (get) Token: 0x06008A50 RID: 35408 RVA: 0x00246AA2 File Offset: 0x00244CA2
	public int BuildingId { get; }

	// Token: 0x06008A51 RID: 35409 RVA: 0x00246AAC File Offset: 0x00244CAC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(2, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(3, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OpenBuildingTips))
		};
	}

	// Token: 0x06008A52 RID: 35410 RVA: 0x00246BC4 File Offset: 0x00244DC4
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.HideBuildingTips), false);
	}

	// Token: 0x06008A53 RID: 35411 RVA: 0x00246BEF File Offset: 0x00244DEF
	protected override void OnBeforeShow()
	{
		this.AddEventListener();
		this.Refresh();
	}

	// Token: 0x06008A54 RID: 35412 RVA: 0x00246BFD File Offset: 0x00244DFD
	protected override void OnBeforeHide()
	{
		this.RemoveEventListener();
	}

	// Token: 0x06008A55 RID: 35413 RVA: 0x00246C05 File Offset: 0x00244E05
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MoonChasingRefreshBuildingRedDot, new Action(this.RefreshRedDot));
	}

	// Token: 0x06008A56 RID: 35414 RVA: 0x00246C23 File Offset: 0x00244E23
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MoonChasingRefreshBuildingRedDot, new Action(this.RefreshRedDot));
	}

	// Token: 0x06008A57 RID: 35415 RVA: 0x00246C41 File Offset: 0x00244E41
	protected override void OnBeforeDestroy()
	{
		this.SequencePlayer.Clear();
	}

	// Token: 0x06008A58 RID: 35416 RVA: 0x00246C50 File Offset: 0x00244E50
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		UUIItem rootComponent = base.GetButton(6).GetRootComponent();
		if (rootComponent == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			rootComponent,
			rootComponent
		};
	}

	// Token: 0x06008A59 RID: 35417 RVA: 0x00246C7D File Offset: 0x00244E7D
	private void OpenBuildingTips()
	{
		ControllerBase<MoonChasingController>.Instance.OpenBuildingTipsInfoView(this.BuildingId);
	}

	// Token: 0x06008A5A RID: 35418 RVA: 0x00246C90 File Offset: 0x00244E90
	private void HideBuildingTips(string sequenceName)
	{
		if (sequenceName == "Close")
		{
			bool isBuild = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(this.BuildingId).IsBuild;
			this.SetTipsActive(false);
			base.GetItem(9).SetUIActive(isBuild);
			base.GetTexture(0).SetUIActive(isBuild);
		}
	}

	// Token: 0x06008A5B RID: 35419 RVA: 0x00246CE2 File Offset: 0x00244EE2
	public void SetTipsActive(bool value)
	{
		UUIItem item = base.GetItem(7);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(value);
	}

	// Token: 0x06008A5C RID: 35420 RVA: 0x00246CF8 File Offset: 0x00244EF8
	public void SetExhibitionMode(bool bHide)
	{
		bool isBuild = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(this.BuildingId).IsBuild;
		this.SetTipsActive(!bHide);
		base.GetTexture(0).SetUIActive(!bHide || isBuild);
		base.GetItem(9).SetUIActive(!bHide);
	}

	// Token: 0x06008A5D RID: 35421 RVA: 0x00246D4C File Offset: 0x00244F4C
	public void SetBuildingItemActive(bool value)
	{
		bool isBuild = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(this.BuildingId).IsBuild;
		this.RefreshRedDot();
		if (value)
		{
			string sequenceName = isBuild ? "Close" : "Close01";
			this.SequencePlayer.StopSequenceByKey(sequenceName, false, false);
			this.SetTipsActive(true);
			base.GetTexture(0).SetUIActive(true);
			base.GetItem(9).SetUIActive(true);
			string sequenceName2 = isBuild ? "Start" : "Start01";
			this.SequencePlayer.PlayLevelSequenceByName(sequenceName2, false, null, false);
		}
		else
		{
			string sequenceName3 = isBuild ? "Close" : "Close01";
			this.SequencePlayer.PlayLevelSequenceByName(sequenceName3, false, null, false);
		}
		this.SetInteractive(value);
	}

	// Token: 0x06008A5E RID: 35422 RVA: 0x00246E11 File Offset: 0x00245011
	public void SetInteractive(bool value)
	{
		UUIButtonComponent button = base.GetButton(6);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(value);
	}

	// Token: 0x06008A5F RID: 35423 RVA: 0x00246E28 File Offset: 0x00245028
	private void SetBuildingTexture()
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(this.BuildingId);
		Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(this.BuildingId);
		if (buildingDataById.IsUnlock)
		{
			if (!buildingDataById.IsBuild)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_BuildItemBUnlock");
				base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
				return;
			}
			base.SetTextureByPath(buildingById.BuildingTexture, base.GetTexture(0), null, null);
		}
	}

	// Token: 0x06008A60 RID: 35424 RVA: 0x00246EB0 File Offset: 0x002450B0
	private void SetStateSprite()
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(this.BuildingId);
		string resourcePath;
		if (buildingDataById.IsMax)
		{
			resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_TogPointMaxNor");
		}
		else if (buildingDataById.IsUnlock)
		{
			if (buildingDataById.Level == 0)
			{
				resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_TogPointUnLock");
			}
			else
			{
				resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_TogPointNor");
			}
		}
		else
		{
			resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_TogPointNorLock");
		}
		UUISpriteTransition uiSpriteTransition = base.GetUiSpriteTransition(3);
		base.SetSpriteTransitionByPath(resourcePath, uiSpriteTransition, EUISelectableSelectionState.Normal).Forget();
	}

	// Token: 0x06008A61 RID: 35425 RVA: 0x00246F44 File Offset: 0x00245144
	private void SetTipsSprite()
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(this.BuildingId);
		Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(this.BuildingId);
		UUISpriteTransition uiSpriteTransition = base.GetUiSpriteTransition(1);
		uiSpriteTransition.RootUIComp.Get().SetUIActive(buildingDataById.IsUnlock);
		FColor? fcolor = null;
		if (buildingDataById.IsMax)
		{
			fcolor = new FColor?(FColor.FromHex("#ecb138"));
		}
		else if (buildingDataById.IsUnlock)
		{
			if (buildingDataById.Level == 0)
			{
				fcolor = new FColor?(FColor.FromHex("#595854"));
			}
			else
			{
				fcolor = new FColor?(FColor.FromHex("#b49570"));
			}
		}
		else
		{
			fcolor = new FColor?(FColor.FromHex("#ffffff"));
		}
		base.SetSpriteTransitionByPath(buildingById.TipsSprite, uiSpriteTransition, EUISelectableSelectionState.EUISelectableSelectionState_MAX).Forget();
		uiSpriteTransition.TransitionInfo.NormalTransition.Color = fcolor.Value;
	}

	// Token: 0x06008A62 RID: 35426 RVA: 0x0024702C File Offset: 0x0024522C
	private void SetLockTipsSprite()
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(this.BuildingId);
		base.GetUiSpriteTransition(2).RootUIComp.Get().SetUIActive(!buildingDataById.IsUnlock);
	}

	// Token: 0x06008A63 RID: 35427 RVA: 0x0024706C File Offset: 0x0024526C
	private void SetLevelUpItem()
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(this.BuildingId);
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(buildingDataById.IsAvailableLevelUp);
	}

	// Token: 0x06008A64 RID: 35428 RVA: 0x002470A4 File Offset: 0x002452A4
	private void SetRedDot()
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(this.BuildingId);
		bool uiactive = ModelBase<MoonChasingBuildingModel>.Instance.CheckBuildingRedDotState(buildingDataById);
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x06008A65 RID: 35429 RVA: 0x002470E0 File Offset: 0x002452E0
	private void RefreshRedDot()
	{
		this.SetRedDot();
	}

	// Token: 0x06008A66 RID: 35430 RVA: 0x002470E8 File Offset: 0x002452E8
	private void SetName()
	{
		Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(this.BuildingId);
		UUIText text = base.GetText(8);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, buildingById.Name, Array.Empty<object>());
	}

	// Token: 0x06008A67 RID: 35431 RVA: 0x00247125 File Offset: 0x00245325
	public void Refresh()
	{
		this.SetBuildingTexture();
		this.SetTipsSprite();
		this.SetLockTipsSprite();
		this.SetStateSprite();
		this.SetLevelUpItem();
		this.SetRedDot();
		this.SetName();
	}

	// Token: 0x040040CE RID: 16590
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x0200774C RID: 30540
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x04029142 RID: 168258
		public const int Texture = 0;

		// Token: 0x04029143 RID: 168259
		public const int TipsSprite = 1;

		// Token: 0x04029144 RID: 168260
		public const int LockTipsSprite = 2;

		// Token: 0x04029145 RID: 168261
		public const int StateSprite = 3;

		// Token: 0x04029146 RID: 168262
		public const int CanLevelUpItem = 4;

		// Token: 0x04029147 RID: 168263
		public const int RedDotItem = 5;

		// Token: 0x04029148 RID: 168264
		public const int InteractiveBtn = 6;

		// Token: 0x04029149 RID: 168265
		public const int TipsItem = 7;

		// Token: 0x0402914A RID: 168266
		public const int Name = 8;

		// Token: 0x0402914B RID: 168267
		public const int NameItem = 9;
	}
}
