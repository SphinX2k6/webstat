using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053C1 RID: 21441
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotPortraitItem : UiPanelBase
	{
		// Token: 0x06036ACB RID: 223947 RVA: 0x00DDA89C File Offset: 0x00DD8A9C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036ACC RID: 223948 RVA: 0x00DDAADC File Offset: 0x00DD8CDC
		public UniTask OpenAsync(UUIItem parentItem, IHeadStyle param)
		{
			PlotPortraitItem.<OpenAsync>d__27 <OpenAsync>d__;
			<OpenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenAsync>d__.<>4__this = this;
			<OpenAsync>d__.parentItem = parentItem;
			<OpenAsync>d__.param = param;
			<OpenAsync>d__.<>1__state = -1;
			<OpenAsync>d__.<>t__builder.Start<PlotPortraitItem.<OpenAsync>d__27>(ref <OpenAsync>d__);
			return <OpenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036ACD RID: 223949 RVA: 0x00DDAB30 File Offset: 0x00DD8D30
		public UniTask CloseAsync()
		{
			PlotPortraitItem.<CloseAsync>d__28 <CloseAsync>d__;
			<CloseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseAsync>d__.<>4__this = this;
			<CloseAsync>d__.<>1__state = -1;
			<CloseAsync>d__.<>t__builder.Start<PlotPortraitItem.<CloseAsync>d__28>(ref <CloseAsync>d__);
			return <CloseAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036ACE RID: 223950 RVA: 0x00DDAB74 File Offset: 0x00DD8D74
		public UniTask SwitchAsync(IHeadStyle param)
		{
			PlotPortraitItem.<SwitchAsync>d__29 <SwitchAsync>d__;
			<SwitchAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SwitchAsync>d__.<>1__state = -1;
			<SwitchAsync>d__.<>t__builder.Start<PlotPortraitItem.<SwitchAsync>d__29>(ref <SwitchAsync>d__);
			return <SwitchAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036ACF RID: 223951 RVA: 0x00DDABB0 File Offset: 0x00DD8DB0
		protected override UniTask OnCreateAsync()
		{
			PlotPortraitItem.<OnCreateAsync>d__30 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<PlotPortraitItem.<OnCreateAsync>d__30>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036AD0 RID: 223952 RVA: 0x00DDABF3 File Offset: 0x00DD8DF3
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06036AD1 RID: 223953 RVA: 0x00DDAC08 File Offset: 0x00DD8E08
		protected override void OnBeforeShow()
		{
			this.HideAll();
			this.TickId = ControllerBase<PlotController>.Instance.AddTick(new Action<float>(this.OnTick));
			switch (this.OwnedSetHeadIcon.Type)
			{
			case EHeadStyle.Normal:
				this.ShowVideoCall();
				return;
			case EHeadStyle.VoiceOnly:
				this.ShowAudioCall();
				return;
			case EHeadStyle.WeakSignal:
				this.ShowInterferenceCall();
				return;
			case EHeadStyle.Warning:
				this.ShowEmergencyCall();
				return;
			case (EHeadStyle)4:
				break;
			case EHeadStyle.MonsterDisplay:
				this.ShowMonsterDispalyCall();
				break;
			default:
				return;
			}
		}

		// Token: 0x06036AD2 RID: 223954 RVA: 0x00DDAC84 File Offset: 0x00DD8E84
		protected override UniTask OnShowAsyncImplementImplement()
		{
			PlotPortraitItem.<OnShowAsyncImplementImplement>d__33 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<PlotPortraitItem.<OnShowAsyncImplementImplement>d__33>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06036AD3 RID: 223955 RVA: 0x00DDACC8 File Offset: 0x00DD8EC8
		protected override UniTask OnHideAsyncImplementImplement()
		{
			PlotPortraitItem.<OnHideAsyncImplementImplement>d__34 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<PlotPortraitItem.<OnHideAsyncImplementImplement>d__34>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06036AD4 RID: 223956 RVA: 0x00DDAD0B File Offset: 0x00DD8F0B
		protected override void OnAfterHide()
		{
			ControllerBase<PlotController>.Instance.RemoveTick(this.TickId);
		}

		// Token: 0x06036AD5 RID: 223957 RVA: 0x00DDAD1D File Offset: 0x00DD8F1D
		protected override void OnBeforeDestroy()
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
			this.Texture = null;
			this.Name = null;
			this.Intro = null;
			this.CurTime = 0f;
			this.TickId = 0;
		}

		// Token: 0x06036AD6 RID: 223958 RVA: 0x00DDAD58 File Offset: 0x00DD8F58
		private void ShowVideoCall()
		{
			base.GetItem(10).SetUIActive(true);
			base.GetItem(3).SetUIActive(true);
			base.GetItem(4).SetUIActive(true);
			base.GetItem(2).SetUIActive(true);
			base.GetText(0).ShowTextNew(string.IsNullOrEmpty(this.Name) ? "" : this.Name);
			UUITexture texture = base.GetTexture(1);
			UUINiagara uiNiagara = base.GetUiNiagara(8);
			texture.SetTexture(this.Texture);
			uiNiagara.SetNiagaraEmitterCustomTexture("head_portrait_01", "Mask", this.Texture);
			uiNiagara.SetNiagaraEmitterCustomTexture("head_portrait_02", "Mask", this.Texture);
			uiNiagara.SetNiagaraEmitterCustomTexture("head_portrait_03", "Mask", this.Texture);
			uiNiagara.SetNiagaraVarFloat("Size X", texture.Width);
			uiNiagara.SetNiagaraVarFloat("Size Y", texture.Height);
		}

		// Token: 0x06036AD7 RID: 223959 RVA: 0x00DDAE40 File Offset: 0x00DD9040
		private void ShowAudioCall()
		{
			base.GetItem(10).SetUIActive(true);
			base.GetItem(3).SetUIActive(true);
			base.GetItem(5).SetUIActive(true);
			base.GetText(0).ShowTextNew(string.IsNullOrEmpty(this.Name) ? "" : this.Name);
		}

		// Token: 0x06036AD8 RID: 223960 RVA: 0x00DDAE9B File Offset: 0x00DD909B
		private void ShowInterferenceCall()
		{
			base.GetItem(10).SetUIActive(true);
			base.GetItem(6).SetUIActive(true);
			base.GetItem(2).SetUIActive(true);
		}

		// Token: 0x06036AD9 RID: 223961 RVA: 0x00DDAEC5 File Offset: 0x00DD90C5
		private void ShowEmergencyCall()
		{
			base.GetItem(10).SetUIActive(true);
			base.GetItem(7).SetUIActive(true);
			base.GetItem(2).SetUIActive(true);
		}

		// Token: 0x06036ADA RID: 223962 RVA: 0x00DDAEF0 File Offset: 0x00DD90F0
		private void ShowMonsterDispalyCall()
		{
			base.GetItem(9).SetUIActive(true);
			base.GetTexture(11).SetTexture(this.Texture);
			UUINiagara uiNiagara = base.GetUiNiagara(12);
			uiNiagara.SetNiagaraEmitterCustomTexture("Frame001", "BaseTexture", this.Texture);
			uiNiagara.SetNiagaraEmitterCustomTexture("Frame001", "BackgroundTexture", this.Texture);
			base.GetText(13).ShowTextNew(string.IsNullOrEmpty(this.Name) ? "" : this.Name);
			base.GetText(14).ShowTextNew(string.IsNullOrEmpty(this.Intro) ? "" : this.Intro);
		}

		// Token: 0x06036ADB RID: 223963 RVA: 0x00DDAFA0 File Offset: 0x00DD91A0
		private void HideAll()
		{
			base.GetItem(2).SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(9).SetUIActive(false);
			base.GetItem(10).SetUIActive(false);
		}

		// Token: 0x06036ADC RID: 223964 RVA: 0x00DDB018 File Offset: 0x00DD9218
		public void OnTick(float delta)
		{
			if (!this.CanRefresh())
			{
				return;
			}
			this.CurTime += delta;
			if (this.CurTime < this.TargetRefreshInterval)
			{
				return;
			}
			this.CurTime = 0f;
			this.RefreshTargetParams();
			this.RefreshAnchorOffset(delta);
			this.RefreshScale();
			this.RefreshWaveMatParams();
		}

		// Token: 0x06036ADD RID: 223965 RVA: 0x00DDB070 File Offset: 0x00DD9270
		private void RefreshTargetParams()
		{
			FVectorDouble fvectorDouble = Global.BaseCharacter.D_K2_GetActorLocation();
			FVector fvector = fvectorDouble;
			FVector2D fvector2D = new FVector2D();
			APlayerController characterController = Global.CharacterController;
			fvectorDouble = fvector;
			UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble, ref fvector2D, true);
			ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
			this.TargetOffset = canvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D);
			this.TargetOffset.Y = Singleton<UiLayer>.Instance.UiRootItem.Height / 2f;
			Vector cameraLocation = ModelBase<CameraModel>.Instance.MainModel.CameraLocation;
			if (cameraLocation == null)
			{
				return;
			}
			double num = Math.Pow(cameraLocation.X - (double)fvector.X, 2.0) + Math.Pow(cameraLocation.Y - (double)fvector.Y, 2.0) + Math.Pow(cameraLocation.Z - (double)fvector.Z, 2.0);
			num = (double)((float)Math.Sqrt(num));
			if (num < 100.0)
			{
				this.TargetOffset.X = this.TargetOffset.X - (100f - (float)num) * 4f;
				return;
			}
			if (num > 350.0)
			{
				this.TargetOffset.X = this.TargetOffset.X + ((float)num - 350f) * 0.3f;
				float num2 = Singleton<MathUtils>.Instance.Clamp(1f - ((float)num - 350f) * 0.002f, 0.5f, 1f);
				if (this.TargetScale == null)
				{
					this.TargetScale = new FVector?(new FVector(num2));
					return;
				}
				this.TargetScale.Value.Set(num2, num2, num2);
			}
		}

		// Token: 0x06036ADE RID: 223966 RVA: 0x00DDB228 File Offset: 0x00DD9428
		private void RefreshAnchorOffset(float delta)
		{
			FVector2D anchorOffset = this.RootItem.GetAnchorOffset();
			float alpha = Singleton<MathUtils>.Instance.Clamp(delta * 0.01f, 0f, 1f);
			float anchorOffsetX = Singleton<MathUtils>.Instance.Lerp(anchorOffset.X, this.TargetOffset.X, alpha);
			float anchorOffsetY = Singleton<MathUtils>.Instance.Lerp(anchorOffset.Y, this.TargetOffset.Y, alpha);
			this.RootItem.SetAnchorOffsetX(anchorOffsetX);
			this.RootItem.SetAnchorOffsetY(anchorOffsetY);
		}

		// Token: 0x06036ADF RID: 223967 RVA: 0x00DDB2AF File Offset: 0x00DD94AF
		private void RefreshScale()
		{
			if (this.TargetScale != null)
			{
				UUIItem rootItem = this.RootItem;
				if (rootItem == null)
				{
					return;
				}
				rootItem.SetUIItemScale(this.TargetScale.GetValueOrDefault());
			}
		}

		// Token: 0x06036AE0 RID: 223968 RVA: 0x00DDB2DC File Offset: 0x00DD94DC
		private void RefreshWaveMatParams()
		{
		}

		// Token: 0x06036AE1 RID: 223969 RVA: 0x00DDB2E9 File Offset: 0x00DD94E9
		private bool CanRefresh()
		{
			return this.IsShowingPlotPortraitItem && base.GetActive() && Global.BaseCharacter != null;
		}

		// Token: 0x0401F7DD RID: 128989
		private const float VELOCITY_FOLLOW = 0.01f;

		// Token: 0x0401F7DE RID: 128990
		private const float ARM_LENGTH_MIN = 100f;

		// Token: 0x0401F7DF RID: 128991
		private const float ARM_LENGTH_MAX = 350f;

		// Token: 0x0401F7E0 RID: 128992
		private const float HORI_DEC_RATIO = 4f;

		// Token: 0x0401F7E1 RID: 128993
		private const float HORI_INC_RATIO = 0.3f;

		// Token: 0x0401F7E2 RID: 128994
		private const float SCALE_RATIO = 0.002f;

		// Token: 0x0401F7E3 RID: 128995
		private const float VO_RTPC_VALUE_MIN = -48f;

		// Token: 0x0401F7E4 RID: 128996
		private const float VO_RTPC_VALUE_MAX = 0f;

		// Token: 0x0401F7E5 RID: 128997
		private const string AUDIO_GROUP_NAME = "phone_call";

		// Token: 0x0401F7E6 RID: 128998
		[Nullable(2)]
		private IHeadStyle OwnedSetHeadIcon;

		// Token: 0x0401F7E7 RID: 128999
		private int TickId;

		// Token: 0x0401F7E8 RID: 129000
		private FVector2D TargetOffset;

		// Token: 0x0401F7E9 RID: 129001
		private FVector? TargetScale;

		// Token: 0x0401F7EA RID: 129002
		private readonly float TargetRefreshInterval;

		// Token: 0x0401F7EB RID: 129003
		private float CurTime;

		// Token: 0x0401F7EC RID: 129004
		private FVector4 MatParam;

		// Token: 0x0401F7ED RID: 129005
		private float VoRtpcValue;

		// Token: 0x0401F7EE RID: 129006
		private bool IsShowingPlotPortraitItem;

		// Token: 0x0401F7EF RID: 129007
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401F7F0 RID: 129008
		private readonly PlayResult AudioPlayResult = new PlayResult();

		// Token: 0x0401F7F1 RID: 129009
		[Nullable(2)]
		private UTexture Texture;

		// Token: 0x0401F7F2 RID: 129010
		[Nullable(2)]
		private string Name;

		// Token: 0x0401F7F3 RID: 129011
		[Nullable(2)]
		private string Intro;

		// Token: 0x0401F7F4 RID: 129012
		private readonly Dictionary<EHeadStyle, string> AudioSwitchMap = new Dictionary<EHeadStyle, string>
		{
			{
				EHeadStyle.Normal,
				"call_01"
			},
			{
				EHeadStyle.VoiceOnly,
				"call_02"
			},
			{
				EHeadStyle.WeakSignal,
				"call_03"
			},
			{
				EHeadStyle.Warning,
				"call_04"
			}
		};

		// Token: 0x0401F7F5 RID: 129013
		private readonly Dictionary<EHeadStyle, string> SequenceMap = new Dictionary<EHeadStyle, string>
		{
			{
				EHeadStyle.Normal,
				"Start01"
			},
			{
				EHeadStyle.VoiceOnly,
				"Start01"
			},
			{
				EHeadStyle.WeakSignal,
				"Start02"
			},
			{
				EHeadStyle.Warning,
				"Start03"
			}
		};

		// Token: 0x0200B32E RID: 45870
		[NullableContext(0)]
		private static class EPlotPortraitItem
		{
			// Token: 0x04037821 RID: 227361
			public const int Name = 0;

			// Token: 0x04037822 RID: 227362
			public const int HeadIcon = 1;

			// Token: 0x04037823 RID: 227363
			public const int Frame = 2;

			// Token: 0x04037824 RID: 227364
			public const int NormalCall = 3;

			// Token: 0x04037825 RID: 227365
			public const int VideoCall = 4;

			// Token: 0x04037826 RID: 227366
			public const int AudioCall = 5;

			// Token: 0x04037827 RID: 227367
			public const int InterferenceCall = 6;

			// Token: 0x04037828 RID: 227368
			public const int EmergencyCall = 7;

			// Token: 0x04037829 RID: 227369
			public const int HeadIconNiagara = 8;

			// Token: 0x0403782A RID: 227370
			public const int MonsterDisplayCall = 9;

			// Token: 0x0403782B RID: 227371
			public const int CommonBg = 10;

			// Token: 0x0403782C RID: 227372
			public const int MonsterDisplayTexture = 11;

			// Token: 0x0403782D RID: 227373
			public const int MonsterIconNiagara = 12;

			// Token: 0x0403782E RID: 227374
			public const int MonsterName = 13;

			// Token: 0x0403782F RID: 227375
			public const int MonsterIntroduce = 14;

			// Token: 0x04037830 RID: 227376
			public const int AudioCallLine = 15;
		}
	}
}
