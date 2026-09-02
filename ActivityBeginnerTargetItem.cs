using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200124C RID: 4684
public class ActivityBeginnerTargetItem : GridProxyAbstract<int>
{
	// Token: 0x06007CD9 RID: 31961 RVA: 0x0020DBEC File Offset: 0x0020BDEC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnJumpClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007CDA RID: 31962 RVA: 0x0020DD37 File Offset: 0x0020BF37
	protected override void OnStart()
	{
		this.Grid = new SmallItemGrid();
		this.Grid.Initialize(base.GetItem(2).GetOwner());
	}

	// Token: 0x06007CDB RID: 31963 RVA: 0x0020DD5C File Offset: 0x0020BF5C
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.DataId = data;
		WorldNewJourney activityBeginnerConfig = ConfigBase<ActivityBeginnerBookConfig>.Instance.GetActivityBeginnerConfig(data);
		this.RefreshGrid(activityBeginnerConfig);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), activityBeginnerConfig.SourceTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), activityBeginnerConfig.SourceDesc, Array.Empty<object>());
		this.Condition = activityBeginnerConfig.ConditionId;
		if (activityBeginnerConfig.JumpToLength <= 0)
		{
			return;
		}
		foreach (DicIntString dicIntString in activityBeginnerConfig.JumpToIter())
		{
			this.JumpParam = new ValueTuple<int, string>(dicIntString.Key, dicIntString.Value);
		}
	}

	// Token: 0x06007CDC RID: 31964 RVA: 0x0020DE28 File Offset: 0x0020C028
	private void RefreshGrid(WorldNewJourney config)
	{
		switch (config.SourceType)
		{
		case 0:
		{
			CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
			{
				Data = null,
				ItemConfigId = new int?(config.SourceId)
			};
			SmallItemGrid grid = this.Grid;
			if (grid != null)
			{
				grid.Apply<CharacterSmallItemGrid>(parameters);
			}
			SmallItemGrid grid2 = this.Grid;
			if (grid2 == null)
			{
				return;
			}
			grid2.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
			{
				List<int> roleIdList = new List<int>
				{
					config.SourceId
				};
				ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, 0, roleIdList, null, null);
			});
			return;
		}
		case 1:
		{
			TrialWeaponInfo? trialWeaponConfig = ConfigBase<WeaponConfig>.Instance.GetTrialWeaponConfig(config.SourceId);
			PropSmallItemGrid parameters2 = new PropSmallItemGrid
			{
				Data = null,
				ItemConfigId = ((trialWeaponConfig != null) ? new int?(trialWeaponConfig.GetValueOrDefault().WeaponId) : null)
			};
			SmallItemGrid grid3 = this.Grid;
			if (grid3 != null)
			{
				grid3.Apply<PropSmallItemGrid>(parameters2);
			}
			SmallItemGrid grid4 = this.Grid;
			if (grid4 == null)
			{
				return;
			}
			grid4.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
			{
				WeaponTrialData weaponTrialData = new WeaponTrialData();
				weaponTrialData.SetTrialId(config.SourceId, true);
				WeaponPreviewViewParam param = new WeaponPreviewViewParam
				{
					WeaponDataList = new WeaponDataBase[]
					{
						weaponTrialData
					},
					SelectedIndex = 0
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
			});
			return;
		}
		case 2:
		{
			PhantomSmallItemGrid parameters3 = new PhantomSmallItemGrid
			{
				Data = null,
				ItemConfigId = new int?(config.SourceId)
			};
			SmallItemGrid grid5 = this.Grid;
			if (grid5 != null)
			{
				grid5.Apply<PhantomSmallItemGrid>(parameters3);
			}
			SmallItemGrid grid6 = this.Grid;
			if (grid6 == null)
			{
				return;
			}
			grid6.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(config.SourceId, true, null);
			});
			return;
		}
		case 3:
		{
			PropSmallItemGrid parameters4 = new PropSmallItemGrid
			{
				Data = null,
				ItemConfigId = new int?(config.SourceId)
			};
			SmallItemGrid grid7 = this.Grid;
			if (grid7 != null)
			{
				grid7.Apply<PropSmallItemGrid>(parameters4);
			}
			SmallItemGrid grid8 = this.Grid;
			if (grid8 == null)
			{
				return;
			}
			grid8.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(config.SourceId, true, null);
			});
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x06007CDD RID: 31965 RVA: 0x0020DFE2 File Offset: 0x0020C1E2
	public void SetEnableJump(bool enable)
	{
		this.EnableJump = enable;
	}

	// Token: 0x06007CDE RID: 31966 RVA: 0x0020DFEC File Offset: 0x0020C1EC
	public void SetFinish(bool isFinish)
	{
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(!isFinish);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(isFinish);
		}
		UUIItem item3 = base.GetItem(3);
		if (item3 != null)
		{
			item3.SetUIActive(isFinish);
		}
		UUIButtonComponent button = base.GetButton(4);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(!isFinish);
	}

	// Token: 0x06007CDF RID: 31967 RVA: 0x0020E058 File Offset: 0x0020C258
	private unsafe void OnJumpClick()
	{
		if (!this.EnableJump)
		{
			string hintText = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(this.Condition).Value.HintText;
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById(hintText, Array.Empty<object>());
			return;
		}
		switch (this.JumpParam.Item1)
		{
		case 1:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.JumpParam.Item2, null);
			return;
		case 2:
		{
			int num;
			int markId = int.TryParse(this.JumpParam.Item2, out num) ? num : -1;
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			if (configMark == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.LJQ;
				string message = "配置了错误的鸣域新程";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type: ", this.JumpParam.Item1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Parma: ", this.JumpParam.Item2);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkType = (EMarkType)configMark.Value.ObjectType,
				MarkId = new int?(configMark.Value.MarkId),
				OpenFogId = new int?(0)
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Mouse, false, data, null);
			return;
		}
		case 3:
			if (this.JumpParam.Item2 == EUiViewName.RoleRootView.ToString())
			{
				ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, 0, null, null, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView((EUiViewName)this.JumpParam.Item2, null, null);
			return;
		case 4:
		{
			EUiTabViewName value = (EUiTabViewName)this.JumpParam.Item2;
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, 0, new List<int>(), new EUiTabViewName?(value), null);
			return;
		}
		case 5:
		{
			CalabashRootViewData param = new CalabashRootViewData
			{
				TabViewName = (EUiTabViewName)this.JumpParam.Item2,
				Param = null
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CalabashRootView, param, null);
			return;
		}
		case 6:
		{
			int num2;
			ControllerBase<PayShopController>.Instance.OpenPayShopViewWithTab((PayShopDefine.EPayShopTabType)(int.TryParse(this.JumpParam.Item2, out num2) ? num2 : 0), 0);
			return;
		}
		case 7:
		{
			int num3;
			ControllerBase<ActivityController>.Instance.OpenActivityById(int.TryParse(this.JumpParam.Item2, out num3) ? num3 : 0, EActivityViewOpenType.Other, null, null);
			return;
		}
		case 8:
			ControllerBase<AdventureGuideController>.Instance.OpenGuideView(new EUiTabViewName?((EUiTabViewName)this.JumpParam.Item2), null, null);
			return;
		default:
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Activity;
			ELogAuthor author2 = ELogAuthor.LJQ;
			string message2 = "配置了错误的鸣域新程";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Type: ", this.JumpParam.Item1);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Param: ", this.JumpParam.Item2);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		}
	}

	// Token: 0x04003BB2 RID: 15282
	[Nullable(new byte[]
	{
		0,
		1
	})]
	private ValueTuple<int, string> JumpParam = new ValueTuple<int, string>(-1, "");

	// Token: 0x04003BB3 RID: 15283
	private bool EnableJump;

	// Token: 0x04003BB4 RID: 15284
	private int Condition = -1;

	// Token: 0x04003BB5 RID: 15285
	public int DataId = -1;

	// Token: 0x04003BB6 RID: 15286
	[Nullable(2)]
	private SmallItemGrid Grid;

	// Token: 0x020075C5 RID: 30149
	private class EComponents
	{
		// Token: 0x04028A07 RID: 166407
		public const int BgUnfinishItem = 0;

		// Token: 0x04028A08 RID: 166408
		public const int BgFinishItem = 1;

		// Token: 0x04028A09 RID: 166409
		public const int RewardItem = 2;

		// Token: 0x04028A0A RID: 166410
		public const int RewardFinishItem = 3;

		// Token: 0x04028A0B RID: 166411
		public const int JumpButton = 4;

		// Token: 0x04028A0C RID: 166412
		public const int TitleText = 5;

		// Token: 0x04028A0D RID: 166413
		public const int DesText = 6;
	}
}
