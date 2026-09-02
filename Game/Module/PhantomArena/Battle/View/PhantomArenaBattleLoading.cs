using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Audio;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055A8 RID: 21928
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleLoading : UiTickViewBase, IUiViewResource
	{
		// Token: 0x06037CF2 RID: 228594 RVA: 0x00E23BDA File Offset: 0x00E21DDA
		public PhantomArenaBattleLoading(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06037CF3 RID: 228595 RVA: 0x00E23BF0 File Offset: 0x00E21DF0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(5, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUITexture))
			};
		}

		// Token: 0x06037CF4 RID: 228596 RVA: 0x00E23CB8 File Offset: 0x00E21EB8
		protected override void OnBeforeShow()
		{
			ControllerBase<GameAudioController>.Instance.UpdateLoadingType(new ELoadingPerform?(ELoadingPerform.Loading));
		}

		// Token: 0x06037CF5 RID: 228597 RVA: 0x00E23CCC File Offset: 0x00E21ECC
		protected override void OnBeforeHide()
		{
			ControllerBase<GameAudioController>.Instance.UpdateLoadingType(null);
		}

		// Token: 0x06037CF6 RID: 228598 RVA: 0x00E23CEC File Offset: 0x00E21EEC
		protected override void OnAfterHide()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaBattleLoadingHide);
		}

		// Token: 0x06037CF7 RID: 228599 RVA: 0x00E23D00 File Offset: 0x00E21F00
		private UniTask InitLoadingBg()
		{
			PhantomArenaBattleLoading.<InitLoadingBg>d__19 <InitLoadingBg>d__;
			<InitLoadingBg>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLoadingBg>d__.<>4__this = this;
			<InitLoadingBg>d__.<>1__state = -1;
			<InitLoadingBg>d__.<>t__builder.Start<PhantomArenaBattleLoading.<InitLoadingBg>d__19>(ref <InitLoadingBg>d__);
			return <InitLoadingBg>d__.<>t__builder.Task;
		}

		// Token: 0x06037CF8 RID: 228600 RVA: 0x00E23D44 File Offset: 0x00E21F44
		private UniTask InitOpponentLayout()
		{
			PhantomArenaBattleLoading.<InitOpponentLayout>d__20 <InitOpponentLayout>d__;
			<InitOpponentLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitOpponentLayout>d__.<>4__this = this;
			<InitOpponentLayout>d__.<>1__state = -1;
			<InitOpponentLayout>d__.<>t__builder.Start<PhantomArenaBattleLoading.<InitOpponentLayout>d__20>(ref <InitOpponentLayout>d__);
			return <InitOpponentLayout>d__.<>t__builder.Task;
		}

		// Token: 0x06037CF9 RID: 228601 RVA: 0x00E23D87 File Offset: 0x00E21F87
		private int GetOpponentIndex(int index)
		{
			if (index < 3)
			{
				return 3 + index;
			}
			return index - 3;
		}

		// Token: 0x06037CFA RID: 228602 RVA: 0x00E23D94 File Offset: 0x00E21F94
		private UniTask InitOwnLayout()
		{
			PhantomArenaBattleLoading.<InitOwnLayout>d__22 <InitOwnLayout>d__;
			<InitOwnLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitOwnLayout>d__.<>4__this = this;
			<InitOwnLayout>d__.<>1__state = -1;
			<InitOwnLayout>d__.<>t__builder.Start<PhantomArenaBattleLoading.<InitOwnLayout>d__22>(ref <InitOwnLayout>d__);
			return <InitOwnLayout>d__.<>t__builder.Task;
		}

		// Token: 0x06037CFB RID: 228603 RVA: 0x00E23DD8 File Offset: 0x00E21FD8
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaBattleLoading.<OnBeforeStartAsync>d__23 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaBattleLoading.<OnBeforeStartAsync>d__23>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037CFC RID: 228604 RVA: 0x00E23E1B File Offset: 0x00E2201B
		private PhantomArenaBattleLoadingItem InitLoadItem()
		{
			return new PhantomArenaBattleLoadingItem();
		}

		// Token: 0x06037CFD RID: 228605 RVA: 0x00E23E24 File Offset: 0x00E22024
		protected void WaitEntityLoadFinish()
		{
			List<long> allEntityIdList = ModelBase<PhantomArenaBattleModel>.Instance.BattleData.GetAllEntityIdList();
			if (allEntityIdList.Count == 0)
			{
				this.NotNeedEntity = true;
			}
			else
			{
				this.NotNeedEntity = false;
				this.EntityTotal = allEntityIdList.Count;
				this.CurCount = 0f;
				this.CountSpeed = 2f * (float)this.EntityTotal;
				this.WaitTask = WaitEntityTask.Create("PhantomArenaEntityNotify", allEntityIdList, delegate(bool? _)
				{
				}, 60000, true, false);
			}
			this.IsLoadStart = true;
		}

		// Token: 0x06037CFE RID: 228606 RVA: 0x00E23EC4 File Offset: 0x00E220C4
		protected override void OnTick(float delta)
		{
			if (!this.IsLoadStart || this.IsLoadEnd)
			{
				return;
			}
			if (!this.NotNeedEntity)
			{
				int currentLoading = ModelBase<PhantomArenaBattleModel>.Instance.CurrentLoading;
				if (this.CurCount < (float)currentLoading)
				{
					float num = delta * this.CountSpeed / 1000f;
					this.CurCount = Math.Min(this.CurCount + num, (float)currentLoading);
					this.CurCount = Math.Min(this.CurCount, (float)this.EntityTotal);
				}
				float loadingValue = this.CurCount / (float)this.EntityTotal;
				this.SetLoadingValue(loadingValue);
				if (this.CurCount >= (float)this.EntityTotal)
				{
					this.OnLoadingEnd();
				}
				return;
			}
			this.NotNeedTimeCount += delta;
			if (this.NotNeedTimeCount >= 2f)
			{
				this.NotNeedTimeCount = 2f;
				this.SetLoadingValue(1f);
				this.OnLoadingEnd();
				return;
			}
			this.SetLoadingValue(this.NotNeedTimeCount / 2f);
		}

		// Token: 0x06037CFF RID: 228607 RVA: 0x00E23FB4 File Offset: 0x00E221B4
		protected void SetLoadingValue(float value)
		{
			UUISliderComponent slider = base.GetSlider(4);
			if (slider != null)
			{
				slider.SetValue(value, true);
			}
			UUISliderComponent slider2 = base.GetSlider(5);
			if (slider2 != null)
			{
				slider2.SetValue(value, true);
			}
			UUIText text = base.GetText(6);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Floor((double)(value * 100f)));
			defaultInterpolatedStringHandler.AppendLiteral("%");
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06037D00 RID: 228608 RVA: 0x00E2402B File Offset: 0x00E2222B
		protected void OnLoadingEnd()
		{
			this.IsLoadEnd = true;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaBattleVsView, null, delegate(bool _, int _)
			{
				ModelBase<PhantomArenaBattleModel>.Instance.IsBattleLoading = false;
				ModelBase<PhantomArenaBattleModel>.Instance.CurrentLoading = 0;
				Singleton<UiManager>.Instance.CloseView(EUiViewName.PhantomArenaBattleLoading, null);
			});
		}

		// Token: 0x06037D01 RID: 228609 RVA: 0x00E24063 File Offset: 0x00E22263
		public string GetExtraResourceId(object param = null)
		{
			if (!ModelBase<PhantomArenaBattleModel>.Instance.IsOldBvb)
			{
				return "UiView_DesktopLoadingNew";
			}
			return "UiView_DesktopLoading";
		}

		// Token: 0x0401FF50 RID: 130896
		private const int CARD_FRONT = 3;

		// Token: 0x0401FF51 RID: 130897
		private const int CARD_TOTAL = 6;

		// Token: 0x0401FF52 RID: 130898
		private const float PER_INTERVAL = 2f;

		// Token: 0x0401FF53 RID: 130899
		protected GenericLayout<PhantomArenaBattleLoadingItem, IPhantomArenaBattleLoadingInfo> OpponentLayout;

		// Token: 0x0401FF54 RID: 130900
		protected GenericLayout<PhantomArenaBattleLoadingItem, IPhantomArenaBattleLoadingInfo> OwnLayout;

		// Token: 0x0401FF55 RID: 130901
		protected bool IsLoadStart;

		// Token: 0x0401FF56 RID: 130902
		protected bool IsLoadEnd;

		// Token: 0x0401FF57 RID: 130903
		protected bool NotNeedEntity;

		// Token: 0x0401FF58 RID: 130904
		protected float NotNeedTimeCount;

		// Token: 0x0401FF59 RID: 130905
		protected WaitEntityTask WaitTask;

		// Token: 0x0401FF5A RID: 130906
		protected int EntityTotal;

		// Token: 0x0401FF5B RID: 130907
		protected float CurCount;

		// Token: 0x0401FF5C RID: 130908
		protected float CountSpeed = 1f;

		// Token: 0x0200B532 RID: 46386
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038165 RID: 229733
			public const int OpponentLayout = 0;

			// Token: 0x04038166 RID: 229734
			public const int OpponentItem = 1;

			// Token: 0x04038167 RID: 229735
			public const int OwnLayout = 2;

			// Token: 0x04038168 RID: 229736
			public const int OwnItem = 3;

			// Token: 0x04038169 RID: 229737
			public const int SliderL = 4;

			// Token: 0x0403816A RID: 229738
			public const int SliderR = 5;

			// Token: 0x0403816B RID: 229739
			public const int TxtTitle = 6;

			// Token: 0x0403816C RID: 229740
			public const int LoadingBg = 7;
		}
	}
}
