using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FFC RID: 28668
	[NullableContext(1)]
	[Nullable(0)]
	public class InputCombinationActionKey
	{
		// Token: 0x0604566F RID: 284271 RVA: 0x012259FE File Offset: 0x01223BFE
		public static InputCombinationActionKey New(string actionName, string mainKeyName, string secondaryKeyName)
		{
			return new InputCombinationActionKey
			{
				ActionName = actionName,
				MainKeyName = mainKeyName,
				SecondaryKeyName = secondaryKeyName
			};
		}

		// Token: 0x06045670 RID: 284272 RVA: 0x01225A1A File Offset: 0x01223C1A
		[NullableContext(2)]
		public InputKey GetMainKey()
		{
			return Singleton<InputSettings>.Instance.GetKey(this.MainKeyName);
		}

		// Token: 0x06045671 RID: 284273 RVA: 0x01225A2C File Offset: 0x01223C2C
		[NullableContext(2)]
		public InputKey GetSecondaryKey()
		{
			return Singleton<InputSettings>.Instance.GetKey(this.SecondaryKeyName);
		}

		// Token: 0x06045672 RID: 284274 RVA: 0x01225A40 File Offset: 0x01223C40
		public FInputActionKeyMapping MainKeyToUeInputActionKeyMapping()
		{
			FName value = FNameUtil.GetDynamicFName(this.ActionName).Value;
			FKey key = new FKey(FNameUtil.GetDynamicFName(this.MainKeyName).Value);
			return new FInputActionKeyMapping(value, false, false, false, false, key);
		}

		// Token: 0x06045673 RID: 284275 RVA: 0x01225A84 File Offset: 0x01223C84
		public FInputActionKeyMapping SecondaryKeyToUeInputActionKeyMapping()
		{
			FName value = FNameUtil.GetDynamicFName(this.ActionName).Value;
			FKey key = new FKey(FNameUtil.GetDynamicFName(this.SecondaryKeyName).Value);
			return new FInputActionKeyMapping(value, false, false, false, false, key);
		}

		// Token: 0x04026CBA RID: 158906
		public string ActionName = "";

		// Token: 0x04026CBB RID: 158907
		public string MainKeyName = "";

		// Token: 0x04026CBC RID: 158908
		public string SecondaryKeyName = "";
	}
}
