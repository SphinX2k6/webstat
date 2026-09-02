using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x02004458 RID: 17496
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariableRuleIgnore]
	public class AutoPropTest
	{
		// Token: 0x0602E3CA RID: 189386 RVA: 0x00ADC7E7 File Offset: 0x00ADA9E7
		static AutoPropTest()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(AutoPropTest.CreateStaticDefaultValue), new Action(AutoPropTest.ResetStaticDefaultValue));
		}

		// Token: 0x0602E3CB RID: 189387 RVA: 0x00ADC806 File Offset: 0x00ADAA06
		public static void CreateStaticDefaultValue()
		{
			AutoPropTest.VarResetInternal = 0;
		}

		// Token: 0x0602E3CC RID: 189388 RVA: 0x00ADC80E File Offset: 0x00ADAA0E
		public static void ResetStaticDefaultValue()
		{
			AutoPropTest.VarResetInternal = 0;
		}

		// Token: 0x17007FB4 RID: 32692
		// (get) Token: 0x0602E3CD RID: 189389 RVA: 0x00ADC816 File Offset: 0x00ADAA16
		// (set) Token: 0x0602E3CE RID: 189390 RVA: 0x00ADC81D File Offset: 0x00ADAA1D
		public static TestClass Obj
		{
			get
			{
				return AutoPropTest.ObjInternal;
			}
			set
			{
				AutoPropTest.ObjInternal = value;
			}
		}

		// Token: 0x17007FB5 RID: 32693
		// (get) Token: 0x0602E3CF RID: 189391 RVA: 0x00ADC825 File Offset: 0x00ADAA25
		// (set) Token: 0x0602E3D0 RID: 189392 RVA: 0x00ADC82C File Offset: 0x00ADAA2C
		public static int VarReset
		{
			get
			{
				return AutoPropTest.VarResetInternal;
			}
			set
			{
				AutoPropTest.VarResetInternal = value;
			}
		}

		// Token: 0x17007FB6 RID: 32694
		// (get) Token: 0x0602E3D1 RID: 189393 RVA: 0x00ADC834 File Offset: 0x00ADAA34
		// (set) Token: 0x0602E3D2 RID: 189394 RVA: 0x00ADC83B File Offset: 0x00ADAA3B
		public static TestClass AutoProp { get; set; }

		// Token: 0x0401A423 RID: 107555
		[StaticVariableRuleIgnore]
		public static TestClass ObjInternal;

		// Token: 0x0401A424 RID: 107556
		private static int VarResetInternal;
	}
}
