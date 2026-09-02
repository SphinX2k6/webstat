using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.Controller
{
	// Token: 0x0200705B RID: 28763
	[NullableContext(2)]
	[Nullable(0)]
	public class TsPureKeyHandle
	{
		// Token: 0x06045A5C RID: 285276 RVA: 0x012334DF File Offset: 0x012316DF
		public void Initialize(TsBasePlayerController playerController, PlayerInputHandle playerInputHandle)
		{
			this.PlayerController = playerController;
			this.PlayerInputHandle = playerInputHandle;
		}

		// Token: 0x06045A5D RID: 285277 RVA: 0x012334EF File Offset: 0x012316EF
		public void Reset()
		{
			this.PlayerController = null;
			this.PlayerInputHandle = null;
		}

		// Token: 0x06045A5E RID: 285278 RVA: 0x01233500 File Offset: 0x01231700
		public void BindKey()
		{
			if (this.OnPressAnyKeyDelegate == null)
			{
				this.OnPressAnyKeyDelegate = new FKeyBindingDelegate();
				this.OnPressAnyKeyDelegate.Bind(new Action<FKey>(this.OnPressAnyKey));
			}
			if (this.OnReleaseAnyKeyDelegate == null)
			{
				this.OnReleaseAnyKeyDelegate = new FKeyBindingDelegate();
				this.OnReleaseAnyKeyDelegate.Bind(new Action<FKey>(this.OnReleaseAnyKey));
			}
			FInputChord chord = new FInputChord(new FKey(FNameUtil.GetDynamicFName("AnyKey") ?? FName.NAME_None), false, false, false, false);
			EInputEvent keyEvent = EInputEvent.IE_Pressed;
			TsBasePlayerController playerController = this.PlayerController;
			if (playerController == null)
			{
				throw new NullReferenceException();
			}
			UKuroInputDelegateLibrary.RegisterKeyBinding(chord, keyEvent, playerController, this.OnPressAnyKeyDelegate);
			FInputChord chord2 = new FInputChord(new FKey(FNameUtil.GetDynamicFName("AnyKey") ?? FName.NAME_None), false, false, false, false);
			EInputEvent keyEvent2 = EInputEvent.IE_Released;
			TsBasePlayerController playerController2 = this.PlayerController;
			if (playerController2 == null)
			{
				throw new NullReferenceException();
			}
			UKuroInputDelegateLibrary.RegisterKeyBinding(chord2, keyEvent2, playerController2, this.OnReleaseAnyKeyDelegate);
		}

		// Token: 0x06045A5F RID: 285279 RVA: 0x012335FC File Offset: 0x012317FC
		[NullableContext(1)]
		protected void OnPressAnyKey(FKey key)
		{
			if (!Singleton<Info>.Instance.IsBuildShipping)
			{
				TsBasePlayerController playerController = this.PlayerController;
				if (playerController == null)
				{
					throw new NullReferenceException();
				}
				playerController.OnPressAnyKey(key);
				return;
			}
			else
			{
				ModelBase<PlatformModel>.Instance.OnPressAnyKey(key);
				ModelBase<LogReportModel>.Instance.RecordOperateTime(false, "", 0.0);
				PlayerInputHandle playerInputHandle = this.PlayerInputHandle;
				if (playerInputHandle == null)
				{
					throw new NullReferenceException();
				}
				playerInputHandle.PressAnyKey(key);
				return;
			}
		}

		// Token: 0x06045A60 RID: 285280 RVA: 0x01233666 File Offset: 0x01231866
		[NullableContext(1)]
		protected void OnReleaseAnyKey(FKey key)
		{
			if (!Singleton<Info>.Instance.IsBuildShipping)
			{
				TsBasePlayerController playerController = this.PlayerController;
				if (playerController == null)
				{
					throw new NullReferenceException();
				}
				playerController.OnReleaseAnyKey(key);
				return;
			}
			else
			{
				PlayerInputHandle playerInputHandle = this.PlayerInputHandle;
				if (playerInputHandle == null)
				{
					throw new NullReferenceException();
				}
				playerInputHandle.ReleaseAnyKey(key);
				return;
			}
		}

		// Token: 0x04026E18 RID: 159256
		private TsBasePlayerController PlayerController;

		// Token: 0x04026E19 RID: 159257
		private PlayerInputHandle PlayerInputHandle;

		// Token: 0x04026E1A RID: 159258
		private FKeyBindingDelegate OnPressAnyKeyDelegate;

		// Token: 0x04026E1B RID: 159259
		private FKeyBindingDelegate OnReleaseAnyKeyDelegate;
	}
}
