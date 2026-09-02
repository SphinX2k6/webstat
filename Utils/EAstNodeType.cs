using System;

namespace CSharpScript.Utils
{
	// Token: 0x0200469F RID: 18079
	public enum EAstNodeType
	{
		// Token: 0x0401AD08 RID: 109832
		Number,
		// Token: 0x0401AD09 RID: 109833
		Boolean,
		// Token: 0x0401AD0A RID: 109834
		String,
		// Token: 0x0401AD0B RID: 109835
		Array,
		// Token: 0x0401AD0C RID: 109836
		Identifier,
		// Token: 0x0401AD0D RID: 109837
		BinaryOperator,
		// Token: 0x0401AD0E RID: 109838
		UnaryOperator,
		// Token: 0x0401AD0F RID: 109839
		FunctionCall,
		// Token: 0x0401AD10 RID: 109840
		ParenthesizedExpression,
		// Token: 0x0401AD11 RID: 109841
		Index
	}
}
