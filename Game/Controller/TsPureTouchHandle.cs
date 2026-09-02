using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Controller
{
	// Token: 0x0200705C RID: 28764
	[NullableContext(2)]
	[Nullable(0)]
	public class TsPureTouchHandle
	{
		// Token: 0x06045A62 RID: 285282 RVA: 0x012336A9 File Offset: 0x012318A9
		public void Initialize(TsBasePlayerController playerController, PlayerInputHandle playerInputHandle)
		{
			this.PlayerController = playerController;
			this.PlayerInputHandle = playerInputHandle;
		}

		// Token: 0x06045A63 RID: 285283 RVA: 0x012336BC File Offset: 0x012318BC
		public void Reset()
		{
			this.PlayerController = null;
			this.PlayerInputHandle = null;
			if (this.OnTouchBeginDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<TEnumAsByte<ETouchIndex>, FVector>(this.OnTouchBegin));
				this.OnTouchBeginDelegate = null;
			}
			if (this.OnTouchEndDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<TEnumAsByte<ETouchIndex>, FVector>(this.OnTouchEnd));
				this.OnTouchEndDelegate = null;
			}
			if (this.OnTouchMoveDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<TEnumAsByte<ETouchIndex>, FVector>(this.OnTouchMove));
				this.OnTouchMoveDelegate = null;
			}
		}

		// Token: 0x06045A64 RID: 285284 RVA: 0x01233738 File Offset: 0x01231938
		public void BindTouch()
		{
			if (this.PlayerController == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.WLJ, "[TsPureTouchHandle::BindTouch]PlayerController为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.OnTouchBeginDelegate == null)
			{
				this.OnTouchBeginDelegate = global::DelegateUtils.ToManualReleaseDelegate<FTouchBindingDelegate>(new Action<TEnumAsByte<ETouchIndex>, FVector>(this.OnTouchBegin));
			}
			UKuroInputDelegateLibrary.RegisterTouchBinding(EInputEvent.IE_Pressed, this.PlayerController, this.OnTouchBeginDelegate);
			if (this.OnTouchEndDelegate == null)
			{
				this.OnTouchEndDelegate = global::DelegateUtils.ToManualReleaseDelegate<FTouchBindingDelegate>(new Action<TEnumAsByte<ETouchIndex>, FVector>(this.OnTouchEnd));
			}
			UKuroInputDelegateLibrary.RegisterTouchBinding(EInputEvent.IE_Released, this.PlayerController, this.OnTouchEndDelegate);
			if (this.OnTouchMoveDelegate == null)
			{
				this.OnTouchMoveDelegate = global::DelegateUtils.ToManualReleaseDelegate<FTouchBindingDelegate>(new Action<TEnumAsByte<ETouchIndex>, FVector>(this.OnTouchMove));
			}
			UKuroInputDelegateLibrary.RegisterTouchBinding(EInputEvent.IE_Repeat, this.PlayerController, this.OnTouchMoveDelegate);
		}

		// Token: 0x06045A65 RID: 285285 RVA: 0x012337FD File Offset: 0x012319FD
		[NullableContext(0)]
		protected void OnTouchBegin(TEnumAsByte<ETouchIndex> touchIndex, FVector position)
		{
			if (this.PlayerInputHandle == null)
			{
				return;
			}
			this.PlayerInputHandle.TouchBegin(touchIndex, position);
			ModelBase<LogReportModel>.Instance.RecordOperateTime(false, "", 0.0);
		}

		// Token: 0x06045A66 RID: 285286 RVA: 0x01233833 File Offset: 0x01231A33
		[NullableContext(0)]
		protected void OnTouchEnd(TEnumAsByte<ETouchIndex> touchIndex, FVector position)
		{
			if (this.PlayerInputHandle == null)
			{
				return;
			}
			this.PlayerInputHandle.TouchEnd(touchIndex, position);
		}

		// Token: 0x06045A67 RID: 285287 RVA: 0x01233850 File Offset: 0x01231A50
		[NullableContext(0)]
		protected void OnTouchMove(TEnumAsByte<ETouchIndex> touchIndex, FVector position)
		{
			if (this.PlayerInputHandle == null)
			{
				return;
			}
			this.PlayerInputHandle.TouchMove(touchIndex, position);
		}

		// Token: 0x04026E1C RID: 159260
		private TsBasePlayerController PlayerController;

		// Token: 0x04026E1D RID: 159261
		private PlayerInputHandle PlayerInputHandle;

		// Token: 0x04026E1E RID: 159262
		private FTouchBindingDelegate OnTouchBeginDelegate;

		// Token: 0x04026E1F RID: 159263
		private FTouchBindingDelegate OnTouchEndDelegate;

		// Token: 0x04026E20 RID: 159264
		private FTouchBindingDelegate OnTouchMoveDelegate;
	}
}
