using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Controller
{
	// Token: 0x02007059 RID: 28761
	[NullableContext(2)]
	[Nullable(0)]
	public class TsPureActionHandle
	{
		// Token: 0x06045A4F RID: 285263 RVA: 0x0123314E File Offset: 0x0123134E
		[NullableContext(1)]
		public void Initialize(TsBasePlayerController playerController)
		{
			this.PlayerController = playerController;
			this.OnPressStat = Stat.Create("TsPureActionHandle.OnPressAction", "", "STATGROUP_KuroBattle");
			this.OnReleaseStat = Stat.Create("TsPureActionHandle.OnReleaseAction", "", "STATGROUP_KuroBattle");
		}

		// Token: 0x06045A50 RID: 285264 RVA: 0x0123318C File Offset: 0x0123138C
		[NullableContext(1)]
		public void AddActionBinding(string actionName, Action<string, bool, FKey> onInputAction)
		{
			this.ActionName = actionName;
			this.OnInputActionCallback = onInputAction;
			FName value = FNameUtil.GetDynamicFName(actionName).Value;
			if (this.OnPressActionDelegate == null)
			{
				this.OnPressActionDelegate = global::DelegateUtils.ToManualReleaseDelegate<FActionBindingDelegate>(new Action<FKey>(this.OnPressAction));
			}
			UKuroInputDelegateLibrary.RegisterActionBinding(value, EInputEvent.IE_Pressed, this.PlayerController, this.OnPressActionDelegate);
			if (this.OnReleaseActionDelegate == null)
			{
				this.OnReleaseActionDelegate = global::DelegateUtils.ToManualReleaseDelegate<FActionBindingDelegate>(new Action<FKey>(this.OnReleaseAction));
			}
			UKuroInputDelegateLibrary.RegisterActionBinding(value, EInputEvent.IE_Released, this.PlayerController, this.OnReleaseActionDelegate);
		}

		// Token: 0x06045A51 RID: 285265 RVA: 0x01233218 File Offset: 0x01231418
		[NullableContext(1)]
		private void OnPressAction(FKey key)
		{
			if (this.OnInputActionCallback != null)
			{
				this.OnInputActionCallback(this.ActionName, true, key);
			}
		}

		// Token: 0x06045A52 RID: 285266 RVA: 0x01233235 File Offset: 0x01231435
		[NullableContext(1)]
		private void OnReleaseAction(FKey key)
		{
			if (this.OnInputActionCallback != null)
			{
				this.OnInputActionCallback(this.ActionName, false, key);
			}
		}

		// Token: 0x06045A53 RID: 285267 RVA: 0x01233254 File Offset: 0x01231454
		public void Reset()
		{
			this.PlayerController = null;
			this.ActionName = null;
			this.OnInputActionCallback = null;
			if (this.OnReleaseActionDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FKey>(this.OnPressAction));
				this.OnReleaseActionDelegate = null;
			}
			if (this.OnPressActionDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FKey>(this.OnReleaseAction));
				this.OnPressActionDelegate = null;
			}
		}

		// Token: 0x04026E0A RID: 159242
		private TsBasePlayerController PlayerController;

		// Token: 0x04026E0B RID: 159243
		private string ActionName;

		// Token: 0x04026E0C RID: 159244
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<string, bool, FKey> OnInputActionCallback;

		// Token: 0x04026E0D RID: 159245
		private Stat OnPressStat;

		// Token: 0x04026E0E RID: 159246
		private Stat OnReleaseStat;

		// Token: 0x04026E0F RID: 159247
		private FActionBindingDelegate OnPressActionDelegate;

		// Token: 0x04026E10 RID: 159248
		private FActionBindingDelegate OnReleaseActionDelegate;
	}
}
