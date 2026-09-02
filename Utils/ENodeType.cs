using System;

namespace CSharpScript.Utils
{
	// Token: 0x020046BE RID: 18110
	public enum ENodeType
	{
		// Token: 0x0401AD48 RID: 109896
		OR,
		// Token: 0x0401AD49 RID: 109897
		AND,
		// Token: 0x0401AD4A RID: 109898
		NOT,
		// Token: 0x0401AD4B RID: 109899
		SequenceTrue,
		// Token: 0x0401AD4C RID: 109900
		Equal,
		// Token: 0x0401AD4D RID: 109901
		NotEqual,
		// Token: 0x0401AD4E RID: 109902
		LessEqual,
		// Token: 0x0401AD4F RID: 109903
		Less,
		// Token: 0x0401AD50 RID: 109904
		GreaterEqual,
		// Token: 0x0401AD51 RID: 109905
		Greater,
		// Token: 0x0401AD52 RID: 109906
		FunctionCall,
		// Token: 0x0401AD53 RID: 109907
		MemberAccess,
		// Token: 0x0401AD54 RID: 109908
		Variable,
		// Token: 0x0401AD55 RID: 109909
		Bool,
		// Token: 0x0401AD56 RID: 109910
		String,
		// Token: 0x0401AD57 RID: 109911
		Number
	}
}
