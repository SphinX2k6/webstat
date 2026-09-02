using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C54 RID: 23636
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrActivityMainView : ActivitySubViewBase
	{
		// Token: 0x170097E6 RID: 38886
		// (get) Token: 0x0603BB6C RID: 244588 RVA: 0x00F2042C File Offset: 0x00F1E62C
		[Nullable(2)]
		protected new InfrastructureActivityData ActivityBaseData
		{
			[NullableContext(2)]
			get
			{
				return this.ActivityBaseData as InfrastructureActivityData;
			}
		}

		// Token: 0x0603BB6D RID: 244589 RVA: 0x00F2043C File Offset: 0x00F1E63C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnPermanentRewardClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnLimitRewardClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BB6E RID: 244590 RVA: 0x00F20654 File Offset: 0x00F1E854
		protected override UniTask OnBeforeStartAsync()
		{
			InfrActivityMainView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InfrActivityMainView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BB6F RID: 244591 RVA: 0x00F20698 File Offset: 0x00F1E898
		private UniTask CreateLimitedRewardBtnAsync()
		{
			InfrActivityMainView.<CreateLimitedRewardBtnAsync>d__9 <CreateLimitedRewardBtnAsync>d__;
			<CreateLimitedRewardBtnAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateLimitedRewardBtnAsync>d__.<>4__this = this;
			<CreateLimitedRewardBtnAsync>d__.<>1__state = -1;
			<CreateLimitedRewardBtnAsync>d__.<>t__builder.Start<InfrActivityMainView.<CreateLimitedRewardBtnAsync>d__9>(ref <CreateLimitedRewardBtnAsync>d__);
			return <CreateLimitedRewardBtnAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BB70 RID: 244592 RVA: 0x00F206DC File Offset: 0x00F1E8DC
		private UniTask CreateExchangeBtnAsync()
		{
			InfrActivityMainView.<CreateExchangeBtnAsync>d__10 <CreateExchangeBtnAsync>d__;
			<CreateExchangeBtnAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateExchangeBtnAsync>d__.<>4__this = this;
			<CreateExchangeBtnAsync>d__.<>1__state = -1;
			<CreateExchangeBtnAsync>d__.<>t__builder.Start<InfrActivityMainView.<CreateExchangeBtnAsync>d__10>(ref <CreateExchangeBtnAsync>d__);
			return <CreateExchangeBtnAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BB71 RID: 244593 RVA: 0x00F2071F File Offset: 0x00F1E91F
		protected override void OnStart()
		{
			this.RefreshShopBtn();
			this.RefreshLimitRewardBtn();
			this.RefreshProgress();
			this.RefreshActivityInfo();
			this.RefreshGender();
		}

		// Token: 0x0603BB72 RID: 244594 RVA: 0x00F2073F File Offset: 0x00F1E93F
		protected override void OnRefreshView()
		{
			this.RefreshShopBtn();
			this.RefreshLimitRewardBtn();
			this.RefreshProgress();
			this.RefreshActivityInfo();
			this.RefreshGender();
		}

		// Token: 0x0603BB73 RID: 244595 RVA: 0x00F20760 File Offset: 0x00F1E960
		private void RefreshLimitRewardBtn()
		{
			if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.Infrastructure))
			{
				this.LimitRewardBtn.SetUiActive(false);
				return;
			}
			this.LimitRewardBtn.SetFunction(delegate(int _)
			{
				this.OnBtnLimitRewardClick();
			});
			this.LimitRewardBtn.BindRedDot(ERedDotName.InfrLimitedTask, 0);
			InfrastructureActivityData activityData = ModelBase<InfrastructureModel>.Instance.GetActivityData();
			List<InfrastructureLimitTaskData> list = ((activityData != null) ? activityData.GetActivityTaskDataList() : null) ?? new List<InfrastructureLimitTaskData>();
			int value = list.Count((InfrastructureLimitTaskData item) => item.Status == ActivityTaskState.ActivityTaskTaken);
			ButtonItem limitRewardBtn = this.LimitRewardBtn;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(list.Count);
			limitRewardBtn.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0603BB74 RID: 244596 RVA: 0x00F20838 File Offset: 0x00F1EA38
		private void RefreshShopBtn()
		{
			if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.Infrastructure))
			{
				this.PermanentRewardBtn.SetUiActive(false);
				return;
			}
			InfrastructureModel instance = ModelBase<InfrastructureModel>.Instance;
			int allShopCurrencyNum = instance.GetAllShopCurrencyNum();
			ButtonItem permanentRewardBtn = this.PermanentRewardBtn;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<long>(instance.MoneyHistorySpent);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(allShopCurrencyNum);
			permanentRewardBtn.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
			this.PermanentRewardBtn.BindRedDot(ERedDotName.InfrShop, 0);
		}

		// Token: 0x0603BB75 RID: 244597 RVA: 0x00F208C0 File Offset: 0x00F1EAC0
		private void RefreshProgress()
		{
			InfrastructureConfig instance = ConfigBase<InfrastructureConfig>.Instance;
			int fireLevel = ModelBase<InfrastructureModel>.Instance.FireLevel;
			long fireExp = ModelBase<InfrastructureModel>.Instance.FireExp;
			int num = instance.GetAllLevelConfigs().Max((InfrLevel prev) => prev.Level);
			List<List<bool>> list = new List<List<bool>>();
			for (int i = 1; i < num; i++)
			{
				if (i == num - 1 && fireLevel == num)
				{
					list.Add(new List<bool>
					{
						true,
						true
					});
				}
				else
				{
					list.Add(new List<bool>
					{
						fireExp >= (long)instance.GetLevelConfigById(i).Value.Exp,
						false
					});
				}
			}
			this.ProgressLayout.RefreshByData(list, null, false);
			float num2;
			if (fireLevel == num)
			{
				num2 = 1f;
			}
			else
			{
				num2 = (float)(fireLevel - 1) / (float)(num - 1) + (float)(fireExp - (long)instance.GetLevelConfigById(fireLevel).Value.Exp) / (float)(instance.GetLevelConfigById(fireLevel + 1).Value.Exp - instance.GetLevelConfigById(fireLevel).Value.Exp);
			}
			base.GetSprite(4).SetFillAmount(num2);
			base.GetArtText(7).SetText((num2 * 100f).ToString("0"));
			base.GetArtText(8).SetText((num2 * 100f).ToString("0"));
		}

		// Token: 0x0603BB76 RID: 244598 RVA: 0x00F20A64 File Offset: 0x00F1EC64
		private void RefreshActivityInfo()
		{
			this.CommonInfoPanel.SetBtnText("LongShanStage_Join01", Array.Empty<object>());
			this.CommonInfoPanel.SetClickFunc(delegate(ActivityBaseData _)
			{
				this.OnConfirmBtnClick();
			});
			this.CommonInfoPanel.SetFunctionRedDotVisible(this.ActivityBaseData.CheckRedDot());
			ActivityFunctionalTypeA functional = this.CommonInfoPanel.GetFunctional();
			ActivityFunctionAreaParams parameters = new ActivityFunctionAreaParams
			{
				UnlockBtnTextId = "LongShanStage_Join01",
				UnlockBtnFunction = new Action(this.OnConfirmBtnClick)
			};
			functional.RefreshGeneralPerformance(parameters);
		}

		// Token: 0x0603BB77 RID: 244599 RVA: 0x00F20AE8 File Offset: 0x00F1ECE8
		private void RefreshGender()
		{
			if (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male)
			{
				base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/BgCgBig/Activity/Activity30/ActivityInfrastructure/ActivityMain/T_AcivityMainMale.T_AcivityMainMale", base.GetTexture(11), null, null);
				return;
			}
			base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/BgCgBig/Activity/Activity30/ActivityInfrastructure/ActivityMain/T_AcivityMainFemale.T_AcivityMainFemale", base.GetTexture(11), null, null);
		}

		// Token: 0x0603BB78 RID: 244600 RVA: 0x00F20B3D File Offset: 0x00F1ED3D
		private void OnConfirmBtnClick()
		{
			ControllerBase<InfrastructureController>.Instance.OpenInfrastructureMainView(null).Forget<int?>();
		}

		// Token: 0x0603BB79 RID: 244601 RVA: 0x00F20B4F File Offset: 0x00F1ED4F
		private void OnBtnPermanentRewardClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InfrastructureShopMainView, new InfrastructureDefine.InfrShopOpenParam
			{
				OpenSource = InfrastructureDefine.EInfrViewOpenSource.Activity
			}, null);
		}

		// Token: 0x0603BB7A RID: 244602 RVA: 0x00F20B6D File Offset: 0x00F1ED6D
		private void OnBtnLimitRewardClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InfrLimitTaskMainView, new InfrastructureDefine.InfrLimitTaskOpenParam
			{
				OpenSource = InfrastructureDefine.EInfrViewOpenSource.Activity
			}, null);
		}

		// Token: 0x04021925 RID: 137509
		protected ActivitySubViewGeneralInfo CommonInfoPanel = new ActivitySubViewGeneralInfo();

		// Token: 0x04021926 RID: 137510
		private ButtonItem PermanentRewardBtn = new ButtonItem(null);

		// Token: 0x04021927 RID: 137511
		private ButtonItem LimitRewardBtn = new ButtonItem(null);

		// Token: 0x04021928 RID: 137512
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<InfrActivityProgressItem, List<bool>> ProgressLayout;

		// Token: 0x0200BCCA RID: 48330
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403A29C RID: 238236
			public const int CommonActionInfo = 0;

			// Token: 0x0403A29D RID: 238237
			public const int BtnLimitReward = 1;

			// Token: 0x0403A29E RID: 238238
			public const int BtnPermanentReward = 2;

			// Token: 0x0403A29F RID: 238239
			public const int PanelActivated = 3;

			// Token: 0x0403A2A0 RID: 238240
			public const int SpriteProgress = 4;

			// Token: 0x0403A2A1 RID: 238241
			public const int HorizontalLayoutPoint = 5;

			// Token: 0x0403A2A2 RID: 238242
			public const int PanelPoint = 6;

			// Token: 0x0403A2A3 RID: 238243
			public const int ArtTextProgress = 7;

			// Token: 0x0403A2A4 RID: 238244
			public const int ArtTextProgressBg = 8;

			// Token: 0x0403A2A5 RID: 238245
			public const int TextProgressDescription = 9;

			// Token: 0x0403A2A6 RID: 238246
			public const int TextRewardDescription = 10;

			// Token: 0x0403A2A7 RID: 238247
			public const int TextureRole = 11;
		}
	}
}
