using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Core.Extension
{
	// Token: 0x0200712D RID: 28973
	public static class VectorExtension
	{
		// Token: 0x060462A0 RID: 287392 RVA: 0x0126D258 File Offset: 0x0126B458
		[NullableContext(1)]
		public static bool ContainsNaN(this IVector value)
		{
			global::Vector vector = value as global::Vector;
			if (vector != null)
			{
				return vector.ContainsNaN();
			}
			if (value is FVector)
			{
				return ((FVector)value).ContainsNaN();
			}
			return value is FVectorDouble && ((FVectorDouble)value).ContainsNaN();
		}

		// Token: 0x060462A1 RID: 287393 RVA: 0x0126D2A8 File Offset: 0x0126B4A8
		[NullableContext(2)]
		public static Aki.Protocol.Vector ToProtocolVector(Aki.Config.Vector? vector)
		{
			if (vector == null)
			{
				return null;
			}
			return new Aki.Protocol.Vector
			{
				X = vector.Value.X,
				Y = vector.Value.Y,
				Z = vector.Value.Z
			};
		}
	}
}
