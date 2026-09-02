using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FFD RID: 28669
	[NullableContext(1)]
	[Nullable(0)]
	public class InputCombinationAxisKey
	{
		// Token: 0x06045675 RID: 284277 RVA: 0x01225AF0 File Offset: 0x01223CF0
		public static InputCombinationAxisKey New(string axisName, string mainKeyName, string secondaryKeyName, float scale)
		{
			return new InputCombinationAxisKey
			{
				AxisName = axisName,
				MainKeyName = mainKeyName,
				SecondaryKeyName = secondaryKeyName,
				Scale = scale
			};
		}

		// Token: 0x06045676 RID: 284278 RVA: 0x01225B13 File Offset: 0x01223D13
		[NullableContext(2)]
		public InputKey GetMainKey()
		{
			return Singleton<InputSettings>.Instance.GetKey(this.MainKeyName);
		}

		// Token: 0x06045677 RID: 284279 RVA: 0x01225B25 File Offset: 0x01223D25
		[NullableContext(2)]
		public InputKey GetSecondaryKey()
		{
			return Singleton<InputSettings>.Instance.GetKey(this.SecondaryKeyName);
		}

		// Token: 0x06045678 RID: 284280 RVA: 0x01225B38 File Offset: 0x01223D38
		public FInputActionKeyMapping MainKeyToUeInputActionKeyMapping()
		{
			FName value = FNameUtil.GetDynamicFName(this.AxisName).Value;
			FKey key = new FKey(FNameUtil.GetDynamicFName(this.MainKeyName).Value);
			return new FInputActionKeyMapping(value, false, false, false, false, key);
		}

		// Token: 0x06045679 RID: 284281 RVA: 0x01225B7C File Offset: 0x01223D7C
		public FInputAxisKeyMapping SecondaryKeyToUeInputActionKeyMapping()
		{
			FName value = FNameUtil.GetDynamicFName(this.AxisName).Value;
			FKey key = new FKey(FNameUtil.GetDynamicFName(this.SecondaryKeyName).Value);
			return new FInputAxisKeyMapping(value, this.Scale, key);
		}

		// Token: 0x04026CBD RID: 158909
		public string AxisName = "";

		// Token: 0x04026CBE RID: 158910
		public string MainKeyName = "";

		// Token: 0x04026CBF RID: 158911
		public string SecondaryKeyName = "";

		// Token: 0x04026CC0 RID: 158912
		public float Scale;
	}
}
