using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x02007098 RID: 28824
	[NullableContext(1)]
	[Nullable(0)]
	public class CameraRelativeNearClipAction : ICameraNearClipAction<CameraRelativeNearClipConfig>
	{
		// Token: 0x06045DB3 RID: 286131 RVA: 0x0124B034 File Offset: 0x01249234
		public CameraRelativeNearClipAction(int id, CameraRelativeNearClipConfig nearClipConfig)
		{
		}

		// Token: 0x1700A5C1 RID: 42433
		// (get) Token: 0x06045DB4 RID: 286132 RVA: 0x0124B051 File Offset: 0x01249251
		public CameraRelativeNearClipConfig NearClipConfig
		{
			get
			{
				return this.<nearClipConfig>P;
			}
		} = nearClipConfig;

		// Token: 0x06045DB5 RID: 286133 RVA: 0x0124B05C File Offset: 0x0124925C
		public unsafe void Start()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraNearClip][CameraRelativeNearClipAction]Start";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", this.<nearClipConfig>P.NearClipType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Distance", this.<nearClipConfig>P.Distance.ToString("F2"));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.AfterTick), "CameraRelativeNearClipAction", ETickingGroup.TG_PostUpdateWork, false, 0, false);
			this.DefaultPlayAfterTickId = ticker.Id;
		}

		// Token: 0x06045DB6 RID: 286134 RVA: 0x0124B130 File Offset: 0x01249330
		private void AfterTick(float delta)
		{
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
			if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
			{
				return;
			}
			if (fightCameraLogicComponent.FinalCameraDistance < this.<nearClipConfig>P.Distance)
			{
				this.UpdateNearClip(10f);
				return;
			}
			this.UpdateNearClip(fightCameraLogicComponent.FinalCameraDistance - this.<nearClipConfig>P.Distance);
		}

		// Token: 0x06045DB7 RID: 286135 RVA: 0x0124B1A2 File Offset: 0x012493A2
		private void UpdateNearClip(float targetNearClipDistance)
		{
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.CurrentClipDistance, (double)targetNearClipDistance, new double?((double)1)))
			{
				return;
			}
			this.CurrentClipDistance = targetNearClipDistance;
			UKuroCameraFunctionLibrary.DelaySetNearClipPlane(this.CurrentClipDistance);
		}

		// Token: 0x06045DB8 RID: 286136 RVA: 0x0124B1D3 File Offset: 0x012493D3
		public bool IsPause()
		{
			return this.IsPauseState;
		}

		// Token: 0x06045DB9 RID: 286137 RVA: 0x0124B1DC File Offset: 0x012493DC
		public unsafe void Pause()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraNearClip][CameraRelativeNearClipAction]Pause";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", this.<nearClipConfig>P.NearClipType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Distance", this.<nearClipConfig>P.Distance.ToString("F2"));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("this.CurrentClipDistance", this.CurrentClipDistance);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			this.IsPauseState = true;
			if (this.DefaultPlayAfterTickId == -1)
			{
				return;
			}
			Singleton<TickSystem>.Instance.Pause(this.DefaultPlayAfterTickId);
		}

		// Token: 0x06045DBA RID: 286138 RVA: 0x0124B2C8 File Offset: 0x012494C8
		public unsafe void Resume()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraNearClip][CameraRelativeNearClipAction]Resume";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", this.<nearClipConfig>P.NearClipType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Distance", this.<nearClipConfig>P.Distance.ToString("F2"));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("this.CurrentClipDistance", this.CurrentClipDistance);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			this.IsPauseState = false;
			if (this.DefaultPlayAfterTickId == -1)
			{
				return;
			}
			Singleton<TickSystem>.Instance.Resume(this.DefaultPlayAfterTickId);
		}

		// Token: 0x06045DBB RID: 286139 RVA: 0x0124B3B4 File Offset: 0x012495B4
		public unsafe void End()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraNearClip][CameraRelativeNearClipAction]End";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", this.<nearClipConfig>P.NearClipType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Distance", this.<nearClipConfig>P.Distance.ToString("F2"));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (this.DefaultPlayAfterTickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.DefaultPlayAfterTickId);
				this.DefaultPlayAfterTickId = -1;
			}
		}

		// Token: 0x040271F6 RID: 160246
		[CompilerGenerated]
		private CameraRelativeNearClipConfig <nearClipConfig>P;

		// Token: 0x040271F7 RID: 160247
		public readonly int Id = id;

		// Token: 0x040271F8 RID: 160248
		private bool IsPauseState;

		// Token: 0x040271F9 RID: 160249
		private float CurrentClipDistance;

		// Token: 0x040271FA RID: 160250
		private int DefaultPlayAfterTickId = -1;
	}
}
