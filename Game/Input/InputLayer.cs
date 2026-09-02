using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using UnrealEngine;

namespace CSharpScript.Game.Input
{
	// Token: 0x02006FD1 RID: 28625
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class InputLayer : IStaticVariableResetter
	{
		// Token: 0x0604541D RID: 283677 RVA: 0x012179BD File Offset: 0x01215BBD
		static InputLayer()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(InputLayer.CreateStaticDefaultValue), new Action(InputLayer.ResetStaticDefaultValue));
		}

		// Token: 0x0604541E RID: 283678 RVA: 0x012179DC File Offset: 0x01215BDC
		public virtual void Clear()
		{
		}

		// Token: 0x0604541F RID: 283679 RVA: 0x012179DE File Offset: 0x01215BDE
		public virtual EInputLayer GetLayerType()
		{
			return EInputLayer.None;
		}

		// Token: 0x06045420 RID: 283680 RVA: 0x012179E4 File Offset: 0x01215BE4
		[NullableContext(1)]
		public static SInputCommand GetSwallowCommand()
		{
			if (InputLayer.SwallowCommand == null)
			{
				InputLayer.SwallowCommand = new SInputCommand(ECommandType.Swallow, 0, default(FGameplayTag));
			}
			return InputLayer.SwallowCommand;
		}

		// Token: 0x06045421 RID: 283681 RVA: 0x01217A1E File Offset: 0x01215C1E
		public virtual SInputCommand HandlePress(EInputAction action, float time)
		{
			return null;
		}

		// Token: 0x06045422 RID: 283682 RVA: 0x01217A21 File Offset: 0x01215C21
		public virtual SInputCommand HandleRelease(EInputAction action, float time)
		{
			return null;
		}

		// Token: 0x06045423 RID: 283683 RVA: 0x01217A24 File Offset: 0x01215C24
		public virtual SInputCommand HandleHold(EInputAction action, float time)
		{
			return null;
		}

		// Token: 0x06045424 RID: 283684 RVA: 0x01217A27 File Offset: 0x01215C27
		public virtual void DispatchPressEvent(EInputAction action, float time)
		{
		}

		// Token: 0x06045425 RID: 283685 RVA: 0x01217A29 File Offset: 0x01215C29
		public virtual void DispatchReleaseEvent(EInputAction action, float time)
		{
		}

		// Token: 0x06045426 RID: 283686 RVA: 0x01217A2B File Offset: 0x01215C2B
		public virtual bool CheckBlockDispatchEvent(EInputAction action)
		{
			return false;
		}

		// Token: 0x06045427 RID: 283687 RVA: 0x01217A2E File Offset: 0x01215C2E
		public virtual SInputCommand HandlePressEx(EInputAction action, float time, float param = 0f)
		{
			return this.HandlePress(action, time);
		}

		// Token: 0x06045428 RID: 283688 RVA: 0x01217A38 File Offset: 0x01215C38
		public virtual SInputCommand HandleReleaseEx(EInputAction action, float time, float param = 0f)
		{
			return this.HandleRelease(action, time);
		}

		// Token: 0x06045429 RID: 283689 RVA: 0x01217A42 File Offset: 0x01215C42
		public virtual SInputCommand HandleHoldEx(EInputAction action, float time, float param = 0f)
		{
			return this.HandleHold(action, time);
		}

		// Token: 0x0604542A RID: 283690 RVA: 0x01217A4C File Offset: 0x01215C4C
		public virtual void DispatchPressEventEx(EInputAction action, float time, float param = 0f)
		{
			this.DispatchPressEvent(action, time);
		}

		// Token: 0x0604542B RID: 283691 RVA: 0x01217A56 File Offset: 0x01215C56
		public virtual void DispatchReleaseEventEx(EInputAction action, float time, float param = 0f)
		{
			this.DispatchReleaseEvent(action, time);
		}

		// Token: 0x0604542C RID: 283692 RVA: 0x01217A60 File Offset: 0x01215C60
		public static void CreateStaticDefaultValue()
		{
			InputLayer.IsTestMode = false;
		}

		// Token: 0x0604542D RID: 283693 RVA: 0x01217A68 File Offset: 0x01215C68
		public static void ResetStaticDefaultValue()
		{
			InputLayer.IsTestMode = false;
			InputLayer.SwallowCommand = null;
		}

		// Token: 0x04026A6D RID: 158317
		public int UnitId;

		// Token: 0x04026A6E RID: 158318
		public static bool IsTestMode;

		// Token: 0x04026A6F RID: 158319
		protected static SInputCommand SwallowCommand;
	}
}
