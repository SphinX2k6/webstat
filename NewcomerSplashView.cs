using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200145E RID: 5214
[NullableContext(1)]
[Nullable(0)]
public class NewcomerSplashView : UiViewBase
{
	// Token: 0x06009157 RID: 37207 RVA: 0x00264C97 File Offset: 0x00262E97
	public NewcomerSplashView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009158 RID: 37208 RVA: 0x00264CA0 File Offset: 0x00262EA0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickEmptyBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009159 RID: 37209 RVA: 0x00264DA9 File Offset: 0x00262FA9
	private void OnClickEmptyBtn()
	{
		if (!this.CheckActivityData(this.ActivityIdCached))
		{
			return;
		}
		ControllerBase<ActivityController>.Instance.OpenActivityById(this.ActivityIdCached, EActivityViewOpenType.HotKey, null, null);
		base.CloseMe(null);
	}

	// Token: 0x0600915A RID: 37210 RVA: 0x00264DD8 File Offset: 0x00262FD8
	protected override UniTask OnBeforeStartAsync()
	{
		NewcomerSplashView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<NewcomerSplashView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600915B RID: 37211 RVA: 0x00264E1C File Offset: 0x0026301C
	private bool CheckActivityData(int activityId)
	{
		if (activityId <= 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ActivityAdvice", Array.Empty<object>());
			base.CloseMe(null);
			return false;
		}
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(activityId);
		if (activityById == null)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ActivityAdvice", Array.Empty<object>());
			base.CloseMe(null);
			return false;
		}
		if (!(activityById is ActivitySevenDaySignData))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ActivityAdvice", Array.Empty<object>());
			base.CloseMe(null);
			return false;
		}
		if (!activityById.CheckIfInShowTime())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ActivityAdvice", Array.Empty<object>());
			base.CloseMe(null);
			return false;
		}
		return true;
	}

	// Token: 0x0600915C RID: 37212 RVA: 0x00264EC1 File Offset: 0x002630C1
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		CommonItemSmallItemGrid commonItemSmallItemGrid = new CommonItemSmallItemGrid();
		commonItemSmallItemGrid.SetAllowClickBack(false);
		return commonItemSmallItemGrid;
	}

	// Token: 0x0600915D RID: 37213 RVA: 0x00264ED0 File Offset: 0x002630D0
	protected override void OnBeforeShow()
	{
		this.LoadLogoTexture();
		int? intConfig = ConfigCommonParamById.GetIntConfig("NewPlayerSplashScreenItem");
		if (intConfig != null)
		{
			int? num = intConfig;
			int num2 = 0;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				try
				{
					List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(intConfig.Value);
					GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
					if (rewardLayout != null)
					{
						rewardLayout.RefreshByData(dropPackagePreviewItemList, null, false);
					}
				}
				catch
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ActivityAdvice", Array.Empty<object>());
					base.CloseMe(null);
				}
				finally
				{
					ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.NewcomerActivity);
				}
			}
		}
	}

	// Token: 0x0600915E RID: 37214 RVA: 0x00264F80 File Offset: 0x00263180
	private void LoadLogoTexture()
	{
		UUITexture texture = base.GetTexture(6);
		UUITexture texture2 = base.GetTexture(7);
		if (texture != null && texture2 != null)
		{
			PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
			string resourceId = (((instance != null) ? instance.GetPlayerGender() : EPlayerGender.None) == EPlayerGender.Male) ? "T_RoleLogoMale" : "T_RoleLogoFemale";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (!string.IsNullOrEmpty(resourcePath))
			{
				base.SetTextureByPath(resourcePath, texture, null, null);
				base.SetTextureByPath(resourcePath, texture2, null, null);
			}
		}
	}

	// Token: 0x0400437D RID: 17277
	private const string NEWCOMER_LOGO_MALE_RESOURCE_ID = "T_RoleLogoMale";

	// Token: 0x0400437E RID: 17278
	private const string NEWCOMER_LOGO_FEMALE_RESOURCE_ID = "T_RoleLogoFemale";

	// Token: 0x0400437F RID: 17279
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x04004380 RID: 17280
	private int ActivityIdCached;

	// Token: 0x0200785B RID: 30811
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04029646 RID: 169542
		public const int TxtDesc = 0;

		// Token: 0x04029647 RID: 169543
		public const int RewardLayout = 1;

		// Token: 0x04029648 RID: 169544
		public const int RewardItem = 2;

		// Token: 0x04029649 RID: 169545
		public const int TxtTipTitle = 3;

		// Token: 0x0402964A RID: 169546
		public const int TxtTitle = 4;

		// Token: 0x0402964B RID: 169547
		public const int EmptyBtn = 5;

		// Token: 0x0402964C RID: 169548
		public const int TitleLogo = 6;

		// Token: 0x0402964D RID: 169549
		public const int TitleLogo2 = 7;
	}
}
